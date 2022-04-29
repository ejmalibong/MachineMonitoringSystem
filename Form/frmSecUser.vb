Imports System.Data.SqlClient
Imports BlackCoffeeLibrary
Imports MachineMonitoringSystem.dsMonitoring
Imports MachineMonitoringSystem.dsMonitoringTableAdapters

Public Class frmSecUser
    Private connection As New clsConnection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbMain As New Main

    Private dsMonitoring As New dsMonitoring
    Private adpUser As New SecUserTableAdapter
    Private adpSection As New SecSectionTableAdapter
    Private adpWorkgroup As New SecWorkgroupTableAdapter

    Private dtUser As New SecUserDataTable
    Private dtSection As New SecSectionDataTable
    Private dtWorkgroup As New SecWorkgroupDataTable

    Private WithEvents bsUser As New BindingSource
    Private WithEvents bsSection As New BindingSource
    Private WithEvents bsWorkgroup As New BindingSource

    Private pageSize As Integer
    Private pageIndex As Integer
    Private totalCount As Integer
    Private pageCount As Integer
    Private indexScroll As Integer = 0
    Private indexPosition As Integer = 0

    Private dictSearchCriteria As New Dictionary(Of String, Integer)

    Private isFilterByUserName As Boolean = False
    Private isFilterBySection As Boolean = False
    Private isFilterByWorkgroup As Boolean = False

    Private isExists As Boolean = False
    Private isValidate As Boolean = False
    Private isClickedDgv As Boolean = False
    Private isEditMode As Boolean = False

    Private sectionId As Integer = 0
    Private departmentId As Integer = 0
    Private isAdmin As Boolean = False

    Public Sub New(ByVal _sectionId As Integer, ByVal _departmentId As Integer, ByVal _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        sectionId = _sectionId
        departmentId = _departmentId
        isAdmin = _isAdmin
    End Sub

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

    Private Sub frmSecUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If bsUser.Current Is Nothing Then
                Exit Sub
            End If

            Dim currentRow = CType(bsUser.Current, DataRowView).Row
            Dim state = currentRow.RowState

            Select Case state
                Case DataRowState.Added, DataRowState.Detached, DataRowState.Modified
                    If dgvList.SelectedCells.Count > 0 Then
                        Dim message = String.Format("Do you want to save your changes?")

                        Select Case MessageBox.Show(message, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                            Case Windows.Forms.DialogResult.Yes
                                adpUser.Update(dsMonitoring.SecUser)
                                e.Cancel = False
                            Case Windows.Forms.DialogResult.No
                                bsUser.CancelEdit()
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
                    txtCommon.Text = String.Empty

                    pnlSearchByCmb.Visible = False
                    pnlSearchByText.Visible = True
                Case 2
                    FillSearchByWorkgroup()

                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False
                Case 3
                    FillSearchBySection()

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
                    isFilterByUserName = True
                    isFilterBySection = False
                    isFilterByWorkgroup = False
                Case 2
                    isFilterByUserName = False
                    isFilterByWorkgroup = True
                    isFilterBySection = False
                Case 3
                    isFilterByUserName = False
                    isFilterByWorkgroup = False
                    isFilterBySection = True
            End Select

            pageIndex = 0
            BindPage()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            isFilterByUserName = False
            isFilterBySection = False
            isFilterByWorkgroup = False

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
                bsUser.AddNew()
                bsUser.MoveLast()
                dgvList.CurrentCell = dgvList.CurrentRow.Cells("ColEmployeeId")
                dgvList.BeginEdit(True)

                EditMode(True)

            ElseIf btnAddSave.Text.Trim = "Save" Then
                Validate()
                bsUser.EndEdit()

                If dsMonitoring.HasChanges Then
                    adpUser.Update(dsMonitoring.SecUser)
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
                dgvList.CurrentCell = dgvList.CurrentRow.Cells("ColEmployeeId")
                dgvList.BeginEdit(True)

                EditMode(True)

            ElseIf btnEditCancel.Text.Trim = "Cancel" Then
                Validate()

                Dim _currentRow = CType(bsUser.Current, DataRowView).Row
                Dim _state = _currentRow.RowState

                Select Case _state
                    Case DataRowState.Added
                        bsUser.RemoveCurrent()
                    Case DataRowState.Detached, DataRowState.Modified
                        Dim _result As DialogResult = MessageBox.Show("Discard your changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                        If _result = Windows.Forms.DialogResult.Yes Then
                            dgvList.CancelEdit()
                            bsUser.CancelEdit()
                            dsMonitoring.RejectChanges()

                        ElseIf _result = Windows.Forms.DialogResult.No Then
                            dgvList.CurrentRow.Cells("ColEmployeeId").Selected = True
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
            If bsUser.Current Is Nothing Then
                Exit Sub
            End If

            Dim _currentRow = CType(bsUser.Current, DataRowView).Row
            Dim _state = _currentRow.RowState

            Select Case _state
                Case DataRowState.Added
                    bsUser.RemoveCurrent()
                Case DataRowState.Deleted
                    MessageBox.Show("Item is already deleted.", "")
                Case DataRowState.Detached
                    bsUser.CancelEdit()
                Case DataRowState.Modified, DataRowState.Unchanged
                    If dgvList.SelectedCells.Count > 0 AndAlso dgvList.SelectedCells(0).RowIndex = dgvList.NewRowIndex Then
                        bsUser.CancelEdit()
                        Exit Sub
                    End If

                    Dim _prmCount(0) As SqlParameter
                    _prmCount(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                    _prmCount(0).Value = CInt(bsUser.Current("UserId"))

                    Dim _count As Integer = 0
                    _count = dbMethod.ExecuteScalar("SELECT COUNT(TrxDetailId) FROM dbo.MntTransactionDetail WHERE UserId = @UserId", CommandType.Text, _prmCount)

                    If _count > 0 Then
                        MessageBox.Show(bsUser.Current("UserName") & " contains transactions.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    Else
                        Dim message = String.Format("Are you sure you want to delete {0}?", bsUser.Current("UserName"))
                        If MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            bsUser.RemoveCurrent()
                            adpUser.Update(dsMonitoring.SecUser)
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

    Private Sub bsUser_AddingNew(sender As Object, e As ComponentModel.AddingNewEventArgs) Handles bsUser.AddingNew
        Try
            Dim dv As DataView = CType(bsUser.List, DataView)
            Dim row As DataRowView = dv.AddNew()

            If isAdmin = 1 Then
                row("SectionId") = 1
            Else
                row("SectionId") = sectionId
            End If

            row("Password") = "default"
            row("WorkgroupId") = 1
            row("IsAdmin") = False
            row("IsActive") = True
            e.NewObject = row

            bsUser.MoveLast()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvList_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvList.CellBeginEdit
        isEditMode = True

        'cancel the editing of machine status column and machine sub-status column since these columns is not set as read-only
        If isAdmin = 0 Then
            If e.ColumnIndex = 6 Then
                e.Cancel = True
            End If
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

    Private Sub dgvList_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvList.CellValidating
        Try
            If isValidate = True Then
                Select Case e.ColumnIndex
                    Case dgvList.Columns("ColEmployeeId").Index
                        If String.IsNullOrEmpty(e.FormattedValue.ToString.Trim) Then
                            MessageBox.Show("Please enter employee ID .", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            e.Cancel = True
                        End If

                        If dgvList.IsCurrentCellDirty Then
                            dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit)
                        End If

                        isExists = False

                        For x As Integer = 0 To dgvList.Rows.Count - 1
                            For y As Integer = 0 To dgvList.Rows.Count - 1
                                If y <> x AndAlso dgvList.Rows(x).Cells("ColEmployeeId").Value.ToString.Trim = dgvList.Rows(y).Cells("ColEmployeeId").Value.ToString.Trim Then
                                    isExists = True
                                End If
                            Next
                        Next

                        If isExists = True Then
                            MessageBox.Show("Employee ID already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            e.Cancel = True
                        End If

                    Case dgvList.Columns("ColUserName").Index
                        If String.IsNullOrEmpty(e.FormattedValue.ToString.Trim) Then
                            MessageBox.Show("Please enter employee name .", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            e.Cancel = True
                        End If

                        If dgvList.IsCurrentCellDirty Then
                            dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit)
                        End If

                        isExists = False

                        For x As Integer = 0 To dgvList.Rows.Count - 1
                            For y As Integer = 0 To dgvList.Rows.Count - 1
                                If y <> x AndAlso dgvList.Rows(x).Cells(dgvList.CurrentCell.OwningColumn.Name.Trim).Value.ToString.ToLower.Trim =
                                    dgvList.Rows(y).Cells(dgvList.CurrentCell.OwningColumn.Name.Trim).Value.ToString.ToLower.Trim Then
                                    isExists = True
                                End If
                            Next
                        Next

                        If isExists = True Then
                            MessageBox.Show("Employee name already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            e.Cancel = True
                        End If
                End Select
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
            dictSearchCriteria.Add(" UserName", 1)
            dictSearchCriteria.Add(" Workgroup", 2)

            If isAdmin = 1 Then
                dictSearchCriteria.Add(" Section", 3)
            End If

            cmbSearchCriteria.DisplayMember = "Key"
            cmbSearchCriteria.ValueMember = "Value"
            cmbSearchCriteria.DataSource = New BindingSource(dictSearchCriteria, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillSearchBySection()
        If isAdmin = 0 Then
            Dim _prmSection(1) As SqlParameter
            _prmSection(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            _prmSection(0).Value = sectionId
            _prmSection(1) = New SqlParameter("@DepartmentId", SqlDbType.Int)
            _prmSection(1).Value = departmentId

            dbMethod.FillCmbWithCaption("RdSecSection", CommandType.StoredProcedure, "MachineId", "MachineName", cmbCommon, "< All > ", _prmSection)
        Else
            dbMethod.FillCmbWithCaption("RdSecSection", CommandType.StoredProcedure, "MachineId", "MachineName", cmbCommon, "< All > ")
        End If
    End Sub

    Private Sub FillSearchByWorkgroup()
        If isAdmin = 0 Then
            Dim _prmWorkgroup(0) As SqlParameter
            _prmWorkgroup(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            _prmWorkgroup(0).Value = sectionId

            dbMethod.FillCmbWithCaption("RdSecWorkgroup", CommandType.StoredProcedure, "WorkgroupId", "WorkgroupName", cmbCommon, "< All > ", _prmWorkgroup)
        Else
            dbMethod.FillCmbWithCaption("RdSecWorkgroup", CommandType.StoredProcedure, "WorkgroupId", "WorkgroupCompleteName", cmbCommon, "< All >")
        End If
    End Sub

    Private Sub BindPage()
        Try
            totalCount = 0

            If isFilterByUserName = True Then
                adpUser.FillSecUserMasterlistByUserName(dsMonitoring.SecUser, pageIndex, pageSize, totalCount, IIf(isAdmin = 1, Nothing, sectionId), isAdmin, txtCommon.Text.Trim)
            ElseIf isFilterBySection = True Then
                adpUser.FillSecUserMasterlistBySectionId(dsMonitoring.SecUser, pageIndex, pageSize, totalCount, IIf(isAdmin = 1, Nothing, sectionId), isAdmin)
            ElseIf isFilterByWorkgroup = True Then
                adpUser.FillSecUserMasterlistByWorkgroupId(dsMonitoring.SecUser, pageIndex, pageSize, totalCount, IIf(isAdmin = 1, Nothing, sectionId), isAdmin, cmbCommon.SelectedValue)
            Else
                adpUser.FillSecUserMasterlist(dsMonitoring.SecUser, pageIndex, pageSize, totalCount, IIf(isAdmin = 1, Nothing, sectionId), isAdmin)
            End If

            bsUser.DataSource = dsMonitoring
            bsUser.DataMember = dtUser.TableName
            bsUser.ResetBindings(True)
            dgvList.AutoGenerateColumns = False
            dgvList.DataSource = bsUser

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
        bsUser.Position = dgvList.SelectedCells(0).RowIndex
    End Sub

    Private Sub SetupDgv()
        Try
            adpSection.Fill(dsMonitoring.SecSection)
            bsSection.DataSource = dsMonitoring
            bsSection.DataMember = dtSection.TableName
            bsSection.ResetBindings(True)

            Dim colSection As DataGridViewComboBoxColumn = DirectCast(dgvList.Columns("ColSection"), DataGridViewComboBoxColumn)
            colSection.ValueMember = "SectionId"
            colSection.DisplayMember = "SectionName"
            colSection.DataSource = bsSection
            colSection.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            colSection.DisplayStyleForCurrentCellOnly = False

            adpWorkgroup.Fill(dsMonitoring.SecWorkgroup)
            bsWorkgroup.DataSource = dsMonitoring
            bsWorkgroup.DataMember = dtWorkgroup.TableName
            bsWorkgroup.ResetBindings(True)

            Dim colWorkgroup As DataGridViewComboBoxColumn = DirectCast(dgvList.Columns("ColWorkgroup"), DataGridViewComboBoxColumn)
            colWorkgroup.ValueMember = "WorkgroupId"
            colWorkgroup.DisplayMember = "WorkgroupName"
            colWorkgroup.DataSource = bsWorkgroup
            colWorkgroup.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            colWorkgroup.DisplayStyleForCurrentCellOnly = False

            dgvList.Columns("ColUserName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvList.Columns("ColWorkgroup").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            If isAdmin Then
                dgvList.Columns("ColPassword").Visible = True
            Else
                dgvList.Columns("ColPassword").Visible = False
            End If

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

                For Each cell As DataGridViewCell In dgvList.CurrentRow.Cells
                    cell.ReadOnly = False
                Next

                isEditMode = True
            Else
                btnAddSave.Text = " Add"
                btnAddSave.Image = MachineMonitoringSystem.My.Resources.Create_16_x_16

                btnEditCancel.Text = " Edit"
                btnEditCancel.Image = MachineMonitoringSystem.My.Resources.Modify_16_x_16

                btnDelete.Enabled = True

                For Each column As DataGridViewColumn In dgvList.Columns
                    column.ReadOnly = True
                Next

                isEditMode = False
            End If

            SetupDgv()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class