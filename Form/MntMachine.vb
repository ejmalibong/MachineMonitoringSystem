Imports System.Data.SqlClient
Imports BlackCoffeeLibrary
Imports MachineMonitoringSystem.dsMonitoring
Imports MachineMonitoringSystem.dsMonitoringTableAdapters

Public Class MntMachine
    Private connection As New Connection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private dsMonitoring As New Monitoring
    Private adpMachine As New MntMachineTableAdapter
    Private adpArea As New MntAreaTableAdapter
    Private adpMachineStatus As New MntMachineStatusTableAdapter
    Private adpMachineSubStatus As New MntMachineSubStatusTableAdapter
    Private adpMachinePartGroup As New MntMachinePartGroupTableAdapter

    Private dtMachine As New MntMachineDataTable
    Private dtArea As New MntAreaDataTable
    Private dtMachineStatus As New MntMachineStatusDataTable
    Private dtMachineSubStatus As New MntMachineSubStatusDataTable
    Private dtMachinePartGroup As New MntMachinePartGroupDataTable

    Private WithEvents bsMachine As New BindingSource
    Private WithEvents bsArea As New BindingSource
    Private WithEvents bsMachineStatus As New BindingSource
    Private WithEvents bsMachineSubStatus As New BindingSource
    Private WithEvents bsMachinePartGroup As New BindingSource

    Private pageSize As Integer
    Private pageIndex As Integer
    Private totalCount As Integer
    Private pageCount As Integer
    Private indexScroll As Integer = 0
    Private indexPosition As Integer = 0

    Private dictSearchCriteria As New Dictionary(Of String, Integer)

    Private isFilterByMachineName As Boolean = False
    Private isFilterByArea As Boolean = False
    Private isFilterByMachineStatus As Boolean = False
    Private isFilterByMachineSubStatus As Boolean = False
    Private isFilterByGroup As Boolean = False

    Private isExists As Boolean = False
    Private isValidate As Boolean = False
    Private isClickedDgv As Boolean = False
    Private isEditMode As Boolean = False

    Private Sub frmMntMachine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pageIndex = 0
        pageSize = 100
        BindPage()
        SetupDgv()

        FillSearchCriteria()

        EditMode(False)

        dbMain.EnableDoubleBuffered(dgvList)
        ActiveControl = dgvList
    End Sub

    Private Sub frmMntMachine_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                e.Handled = True
                btnAddSave.PerformClick()
            Case Keys.F5
                e.Handled = True
                btnRefresh.PerformClick()
            Case Keys.F8
                e.Handled = True
                btnDelete.PerformClick()
            Case Keys.F10
                e.Handled = True
                btnAddSave.PerformClick()
        End Select
    End Sub

    Private Sub frmMntMachine_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If bsMachine.Current Is Nothing Then
                Exit Sub
            End If

            Dim _currentRow = CType(bsMachine.Current, DataRowView).Row
            Dim _state = _currentRow.RowState

            Select Case _state
                Case DataRowState.Added, DataRowState.Detached, DataRowState.Modified
                    If dgvList.SelectedCells.Count > 0 Then
                        Dim message = String.Format("Do you want to save your changes?")

                        Select Case MessageBox.Show(message, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                            Case Windows.Forms.DialogResult.Yes
                                adpMachine.Update(dsMonitoring.MntMachine)
                                e.Cancel = False
                            Case Windows.Forms.DialogResult.No
                                bsMachine.CancelEdit()
                                e.Cancel = False
                            Case Windows.Forms.DialogResult.Cancel
                                e.Cancel = True
                                Return
                        End Select
                    End If
                Case DataRowState.Deleted
                    MessageBox.Show("Item is already deleted.", "")
                    e.Cancel = False
                Case Else
                    Exit Sub
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbSearchCriteria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSearchCriteria.SelectedValueChanged
        Try
            cmbCommon.SelectedValue = 0
            cmbCommon.DataSource = Nothing
            cmbCommon.Items.Clear()

            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    FillSearchByMachineName()

                    pnlSearchByCmb.Visible = False
                    pnlSearchByText.Visible = True
                Case 2
                    FillSearchByArea()

                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False
                Case 3
                    FillSearchByMachineStatus()

                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False
                Case 4
                    FillSearchByMachineSubStatus()

                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False
                Case 5
                    FillSearchByGroup()

                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False
            End Select

            ActiveControl = cmbCommon
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    isFilterByMachineName = True
                    isFilterByArea = False
                    isFilterByMachineStatus = False
                    isFilterByMachineSubStatus = False
                    isFilterByGroup = False
                Case 2
                    isFilterByMachineName = False
                    isFilterByArea = True
                    isFilterByMachineStatus = False
                    isFilterByMachineSubStatus = False
                    isFilterByGroup = False
                Case 3
                    isFilterByMachineName = False
                    isFilterByArea = False
                    isFilterByMachineStatus = True
                    isFilterByMachineSubStatus = False
                    isFilterByGroup = False
                Case 4
                    isFilterByMachineName = False
                    isFilterByArea = False
                    isFilterByMachineStatus = False
                    isFilterByMachineSubStatus = True
                    isFilterByGroup = False
                Case 5
                    isFilterByMachineName = False
                    isFilterByArea = False
                    isFilterByMachineStatus = False
                    isFilterByMachineSubStatus = False
                    isFilterByGroup = True
            End Select

            pageIndex = 0
            BindPage()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            isFilterByMachineName = False
            isFilterByArea = False
            isFilterByMachineStatus = False
            isFilterByMachineSubStatus = False
            isFilterByGroup = False

            cmbCommon.SelectedValue = 0

            pageIndex = 0
            BindPage()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddSave_Click(sender As Object, e As EventArgs) Handles btnAddSave.Click
        Try
            If btnAddSave.Text.Trim = "Add" Then
                dgvList.ClearSelection()
                bsMachine.AddNew()
                bsMachine.MoveLast()
                dgvList.CurrentCell = dgvList.CurrentRow.Cells("ColMachineName")
                dgvList.BeginEdit(True)

                EditMode(True)

            ElseIf btnAddSave.Text.Trim = "Save" Then
                Validate()
                bsMachine.EndEdit()

                If dsMonitoring.HasChanges Then
                    adpMachine.Update(dsMonitoring.MntMachine)
                End If

                EditMode(False)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEditCancel_Click(sender As Object, e As EventArgs) Handles btnEditCancel.Click
        Try
            If btnEditCancel.Text.Trim = "Edit" Then
                dgvList.CurrentCell = dgvList.CurrentRow.Cells("ColMachineName")
                dgvList.BeginEdit(True)

                EditMode(True)

            ElseIf btnEditCancel.Text.Trim = "Cancel" Then
                Validate()

                Dim _currentRow = CType(bsMachine.Current, DataRowView).Row
                Dim _state = _currentRow.RowState

                Select Case _state
                    Case DataRowState.Added
                        bsMachine.RemoveCurrent()
                    Case DataRowState.Detached, DataRowState.Modified
                        Dim _result As DialogResult = MessageBox.Show("Discard your changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                        If _result = Windows.Forms.DialogResult.Yes Then
                            dgvList.CancelEdit()
                            bsMachine.CancelEdit()
                            dsMonitoring.RejectChanges()

                        ElseIf _result = Windows.Forms.DialogResult.No Then
                            dgvList.CurrentRow.Cells("ColMachineName").Selected = True
                            dgvList.BeginEdit(True)
                            Return
                        End If
                    Case DataRowState.Deleted
                        MessageBox.Show("Item is already deleted.", "")
                End Select

                EditMode(False)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If bsMachine.Current Is Nothing Then
                Exit Sub
            End If

            Dim _currentRow = CType(bsMachine.Current, DataRowView).Row
            Dim _state = _currentRow.RowState

            Select Case _state
                Case DataRowState.Added
                    bsMachine.RemoveCurrent()
                Case DataRowState.Deleted
                    MessageBox.Show("Item is already deleted.", "")
                Case DataRowState.Detached
                    bsMachine.CancelEdit()
                Case DataRowState.Modified, DataRowState.Unchanged
                    If dgvList.SelectedCells.Count > 0 AndAlso dgvList.SelectedCells(0).RowIndex = dgvList.NewRowIndex Then
                        bsMachine.CancelEdit()
                        Exit Sub
                    End If

                    Dim _prmCount(0) As SqlParameter
                    _prmCount(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                    _prmCount(0).Value = CInt(bsMachine.Current("MachineId"))

                    Dim _count As Integer = 0
                    _count = dbMethod.ExecuteScalar("SELECT COUNT(TrxId) FROM dbo.MntTransactionHeader WHERE MachineId = @MachineId", CommandType.Text, _prmCount)

                    If _count > 0 Then
                        MessageBox.Show(bsMachine.Current("MachineName") & " contains transactions.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    Else
                        Dim message = String.Format("Are you sure you want to delete {0}?", bsMachine.Current("MachineName"))
                        If MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            bsMachine.RemoveCurrent()
                            adpMachine.Update(dsMonitoring.MntMachine)
                        End If
                    End If
                Case Else
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshList()
    End Sub

    Private Sub bsMachine_AddingNew(sender As Object, e As ComponentModel.AddingNewEventArgs) Handles bsMachine.AddingNew
        Try
            Dim _dataView As DataView = CType(bsMachine.List, DataView)
            Dim _dataRowView As DataRowView = _dataView.AddNew()

            _dataRowView("AreaId") = 1
            _dataRowView("MachineStatusId") = 1
            _dataRowView("MachineSubStatusId") = 1
            _dataRowView("GroupId") = DBNull.Value
            _dataRowView("IsActive") = True
            e.NewObject = _dataRowView

            bsMachine.MoveLast()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvList_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvList.CellBeginEdit
        isEditMode = True

        'cancel the editing of machine status column and machine sub-status column since these columns is not set as read-only
        If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub dgvList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellEndEdit
        isEditMode = False
    End Sub

    Private Sub dgvList_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvList.MouseDown
        isClickedDgv = True
    End Sub

    Private Sub dgvList_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvList.RowValidating
        If isClickedDgv AndAlso isEditMode Then
            e.Cancel = True
            isClickedDgv = False
        End If
    End Sub

    Private Sub dgvList_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        Try
            If Not e Is Nothing Then
                e.FormattingApplied = True

                'use column name instead of column index to get the value of hidden columns
                For _i As Integer = 0 To dgvList.Rows.Count - 1
                    Dim machineStatusId As Integer = dgvList.Rows(_i).Cells("ColMachineStatus").Value

                    If machineStatusId = 1 Then
                        dgvList.Rows(_i).DefaultCellStyle.BackColor = Color.LightGreen 'operational
                    ElseIf machineStatusId = 2 Then
                        dgvList.Rows(_i).DefaultCellStyle.BackColor = Color.Orange 'scheduled
                    Else
                        dgvList.Rows(_i).DefaultCellStyle.BackColor = Color.LightCoral 'unscheduled
                    End If
                Next
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvList_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvList.CellValidating
        Try
            If isValidate = True Then
                If e.ColumnIndex = dgvList.Columns("ColMachineName").Index Then
                    If String.IsNullOrEmpty(e.FormattedValue.ToString.Trim) Then
                        MessageBox.Show("Please enter machine name.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        e.Cancel = True
                    End If

                    If dgvList.IsCurrentCellDirty Then
                        dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit)
                    End If

                    isExists = False

                    For x As Integer = 0 To dgvList.Rows.Count - 1
                        For y As Integer = 0 To dgvList.Rows.Count - 1
                            If y <> x AndAlso dgvList.Rows(x).Cells("ColMachineName").Value.ToString.Trim = dgvList.Rows(y).Cells("ColMachineName").Value.ToString.Trim Then
                                isExists = True
                            End If
                        Next
                    Next

                    If isExists = True Then
                        MessageBox.Show("Machine already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvList.DataError
        e.Cancel = False
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If
        BindPage()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If
        BindPage()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        BindPage()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        BindPage()
    End Sub

    Private Sub btnCancel_MouseEnter(sender As Object, e As EventArgs) Handles btnEditCancel.MouseEnter
        If btnEditCancel.Text = "Cancel" Then
            isValidate = False
        End If
    End Sub

    Private Sub btnCancel_MouseLeave(sender As Object, e As EventArgs) Handles btnEditCancel.MouseLeave
        If btnEditCancel.Text = "Cancel" Then
            isValidate = True
        End If
    End Sub

    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        isValidate = False
    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        isValidate = True
    End Sub

    Private Sub txtPageNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPageNumber.KeyPress
        If ((Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57) OrElse Asc(e.KeyChar) = 8 OrElse Asc(e.KeyChar) = 13 OrElse Asc(e.KeyChar) = 127) Then
            e.Handled = False
            If Asc(e.KeyChar) = 13 Then
                Go()
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub FillSearchCriteria()
        Try
            dictSearchCriteria.Add(" Machine Name", 1)
            dictSearchCriteria.Add(" Area", 2)
            dictSearchCriteria.Add(" Downtime Status", 3)
            dictSearchCriteria.Add(" Sub-Status", 4)
            dictSearchCriteria.Add(" Part Group", 5)

            cmbSearchCriteria.DisplayMember = "Key"
            cmbSearchCriteria.ValueMember = "Value"
            cmbSearchCriteria.DataSource = New BindingSource(dictSearchCriteria, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillSearchByMachineName()
        dbMethod.FillCmbWithCaption("RdMntMachine", CommandType.StoredProcedure, "MachineId", "MachineName", cmbCommon, "< All > ")
    End Sub

    Private Sub FillSearchByArea()
        dbMethod.FillCmbWithCaption("RdMntArea", CommandType.StoredProcedure, "AreaId", "AreaName", cmbCommon, "< All >")
    End Sub

    Private Sub FillSearchByMachineStatus()
        dbMethod.FillCmbWithCaption("RdMntMachineStatus", CommandType.StoredProcedure, "MachineStatusId", "MachineStatusName", cmbCommon, "< All >")
    End Sub

    Private Sub FillSearchByMachineSubStatus()
        dbMethod.FillCmbWithCaption("RdMntMachineSubStatus", CommandType.StoredProcedure, "MachineSubStatusId", "MachineSubStatusName", cmbCommon, "< All >")
    End Sub

    Private Sub FillSearchByGroup()
        dbMethod.FillCmbWithCaption("RdMntMachinePartGroup", CommandType.StoredProcedure, "GroupId", "GroupName", cmbCommon, "< All >")
    End Sub

    Private Sub BindPage()
        Try
            totalCount = 0

            If isFilterByMachineName = True Then
                adpMachine.FillMntMachineMasterlistByMachineName(dsMonitoring.MntMachine, pageIndex, pageSize, totalCount, IIf(String.IsNullOrEmpty(txtCommon.Text.Trim), Nothing, txtCommon.Text.Trim))
            ElseIf isFilterByArea = True Then
                adpMachine.FillMntMachineMasterlistByAreaId(dsMonitoring.MntMachine, pageIndex, pageSize, totalCount, IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue))
            ElseIf isFilterByMachineStatus = True Then
                adpMachine.FillMntMachineMasterlistByMachineStatusId(dsMonitoring.MntMachine, pageIndex, pageSize, totalCount, IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue))
            ElseIf isFilterByMachineSubStatus = True Then
                adpMachine.FillMntMachineMasterlistByMachineSubStatusId(dsMonitoring.MntMachine, pageIndex, pageSize, totalCount, IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue))
            ElseIf isFilterByGroup = True Then
                adpMachine.FillMntMachineMasterlistByGroupId(dsMonitoring.MntMachine, pageIndex, pageSize, totalCount, IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue))
            Else
                adpMachine.FillMntMachineMasterlist(dsMonitoring.MntMachine, pageIndex, pageSize, totalCount)
            End If

            bsMachine.DataSource = dsMonitoring
            bsMachine.DataMember = dtMachine.TableName
            bsMachine.ResetBindings(True)
            dgvList.AutoGenerateColumns = False
            dgvList.DataSource = bsMachine

            If totalCount Mod pageSize = 0 Then
                If totalCount = 0 Then
                    pageCount = (totalCount / pageSize) + 1
                Else
                    pageCount = totalCount / pageSize
                End If
            Else
                pageCount = Math.Truncate(totalCount / pageSize) + 1
            End If

            'current page index and total number of pages
            txtPageNumber.Text = pageIndex + 1
            txtTotalPageNumber.Text = "of " & CInt(pageCount) & " Page(s)"

            'enables pager
            txtPageNumber.Enabled = True
            txtTotalPageNumber.Enabled = True
            BindingNavigatorMoveFirstItem.Enabled = True
            BindingNavigatorMovePreviousItem.Enabled = True
            BindingNavigatorMoveNextItem.Enabled = True
            BindingNavigatorMoveLastItem.Enabled = True

            SetupDgv()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Go()
        Try
            If String.IsNullOrEmpty(txtPageNumber.Text) Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPageNumber.Focus()
                Return
            End If

            If CInt(txtPageNumber.Text) > pageCount Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPageNumber.Focus()
                Return
            End If

            If CInt(txtPageNumber.Text) = 0 Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPageNumber.Focus()
                Return
            End If

            pageIndex = CInt(txtPageNumber.Text) - 1
            BindPage()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub RefreshList()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Invoke(New Action(AddressOf GetScrollingIndex))
        pageIndex = 0
        BindPage()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub GetScrollingIndex()
        indexScroll = dgvList.FirstDisplayedCell.RowIndex
        indexPosition = dgvList.CurrentRow.Index
    End Sub

    Private Sub SetScrollingIndex()
        dgvList.FirstDisplayedScrollingRowIndex = indexScroll
        If dgvList.Rows.Count > indexPosition Then
            dgvList.Rows(indexPosition).Selected = True
        Else
            dgvList.Rows(indexPosition - 1).Selected = True
        End If
        bsMachine.Position = dgvList.SelectedCells(0).RowIndex
    End Sub

    Private Sub SetupDgv()
        Try
            adpArea.Fill(dsMonitoring.MntArea)
            bsArea.DataSource = dsMonitoring
            bsArea.DataMember = dtArea.TableName
            bsArea.ResetBindings(True)

            Dim colArea As DataGridViewComboBoxColumn = DirectCast(dgvList.Columns("ColArea"), DataGridViewComboBoxColumn)
            colArea.ValueMember = "AreaId"
            colArea.DisplayMember = "AreaName"
            colArea.DataSource = bsArea

            adpMachineStatus.Fill(dsMonitoring.MntMachineStatus)
            bsMachineStatus.DataSource = dsMonitoring
            bsMachineStatus.DataMember = dtMachineStatus.TableName
            bsMachineStatus.ResetBindings(True)

            Dim colMachineStatus As DataGridViewComboBoxColumn = DirectCast(dgvList.Columns("ColMachineStatus"), DataGridViewComboBoxColumn)
            colMachineStatus.ValueMember = "MachineStatusId"
            colMachineStatus.DisplayMember = "MachineStatusName"
            colMachineStatus.DataSource = bsMachineStatus
            colMachineStatus.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            colMachineStatus.DisplayStyleForCurrentCellOnly = False

            adpMachineSubStatus.Fill(dsMonitoring.MntMachineSubStatus)
            bsMachineSubStatus.DataSource = dsMonitoring
            bsMachineSubStatus.DataMember = dtMachineSubStatus.TableName
            bsMachineSubStatus.ResetBindings(True)

            Dim colMachineSubStatus As DataGridViewComboBoxColumn = DirectCast(dgvList.Columns("ColMachineSubStatus"), DataGridViewComboBoxColumn)
            colMachineSubStatus.ValueMember = "MachineSubStatusId"
            colMachineSubStatus.DisplayMember = "MachineSubStatusName"
            colMachineSubStatus.DataSource = bsMachineSubStatus
            colMachineSubStatus.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            colMachineSubStatus.DisplayStyleForCurrentCellOnly = False

            adpMachinePartGroup.Fill(dsMonitoring.MntMachinePartGroup)
            bsMachinePartGroup.DataSource = dsMonitoring
            bsMachinePartGroup.DataMember = dtMachinePartGroup.TableName
            bsMachinePartGroup.Sort = "GroupId ASC"
            bsMachinePartGroup.ResetBindings(True)

            Dim colPartGroup As DataGridViewNullableComboBoxColumn = DirectCast(dgvList.Columns("ColGroup"), DataGridViewNullableComboBoxColumn)
            colPartGroup.ValueMember = "GroupId"
            colPartGroup.DisplayMember = "GroupName"
            colPartGroup.DataSource = bsMachinePartGroup
            colPartGroup.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            colPartGroup.DisplayStyleForCurrentCellOnly = False

            Dim newRowGroup As Monitoring.MntMachinePartGroupRow = dsMonitoring.MntMachinePartGroup.NewMntMachinePartGroupRow
            newRowGroup.Item("GroupId") = 0
            newRowGroup.Item("GroupName") = "N/A"
            dsMonitoring.MntMachinePartGroup.AddMntMachinePartGroupRow(newRowGroup)

            dgvList.Columns("ColMachineName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvList.Columns("ColArea").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            For Each column As DataGridViewColumn In dgvList.Columns
                column.DefaultCellStyle.SelectionBackColor = Color.White
                column.DefaultCellStyle.SelectionBackColor = Color.Black
            Next
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EditMode(ByVal _isEditMode As Boolean)
        Try
            If _isEditMode = True Then
                btnAddSave.Text = " Save"
                btnAddSave.Image = MachineMonitoringSystem.My.Resources.Save_16_x_16

                btnEditCancel.Text = "Cancel"
                btnEditCancel.Image = MachineMonitoringSystem.My.Resources.Red_tag_16_x_16

                btnDelete.Enabled = False

                dgvList.CurrentRow.Cells("ColMachineName").ReadOnly = False
                dgvList.CurrentRow.Cells("ColArea").ReadOnly = False
                dgvList.CurrentRow.Cells("ColMachineStatus").ReadOnly = False
                dgvList.CurrentRow.Cells("ColMachineSubStatus").ReadOnly = False
                dgvList.CurrentRow.Cells("ColGroup").ReadOnly = False
                dgvList.CurrentRow.Cells("ColIsActive").ReadOnly = False

                isEditMode = True
            Else
                btnAddSave.Text = " Add"
                btnAddSave.Image = MachineMonitoringSystem.My.Resources.Create_16_x_16

                btnEditCancel.Text = " Edit"
                btnEditCancel.Image = MachineMonitoringSystem.My.Resources.Modify_16_x_16

                btnDelete.Enabled = True

                dgvList.Columns("ColMachineName").ReadOnly = True
                dgvList.Columns("ColArea").ReadOnly = True
                dgvList.Columns("ColMachineStatus").ReadOnly = True
                dgvList.Columns("ColMachineSubStatus").ReadOnly = True
                dgvList.Columns("ColGroup").ReadOnly = True
                dgvList.Columns("ColIsActive").ReadOnly = True

                isEditMode = False
            End If

            SetupDgv()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class