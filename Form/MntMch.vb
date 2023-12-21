Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class MntMch
    Public WithEvents bsMachine As New BindingSource
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dicSearchCriteria As New Dictionary(Of String, Integer)
    Private dicRemarks As New Dictionary(Of String, Object)
    Private dtMachine As New DataTable
    Private indexPosition As Integer = 0
    Private indexScroll As Integer = 0
    Private isFilterByMachineName As Boolean = False
    Private isFilterByArea As Boolean = False
    Private isFilterByMachineStatus As Boolean = False
    Private isFilterByMachineSubStatus As Boolean = False
    Private isFilterByGroup As Boolean = False
    Private isFilterByFrequency As Boolean = False
    Private isFilterByRemarks As Boolean = False
    Private isFilterBySerialNo As Boolean = False
    Private pageCount As Integer
    Private pageIndex As Integer
    Private pageSize As Integer
    Private totalCount As Integer
    Private userId As Integer = 0

    Public Sub New(_userId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
    End Sub

    Public Sub Reload()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
        pageIndex = 0
        LoadData()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        LoadData()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        LoadData()
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If

        LoadData()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If

        LoadData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Using frm As New MntMchDetail()
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Reload()
                    bsMachine.Position = bsMachine.Find("MachineId", frm.pKey)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If Me.dgvList.Rows.Count > 0 Then
                Dim machineId As Integer = CType(Me.bsMachine.Current, DataRowView).Item("MachineId")

                Dim prmCnt(0) As SqlParameter
                prmCnt(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmCnt(0).Value = machineId

                Dim count As Integer = dbMethod.ExecuteScalar("CntMntMachineByTrx", CommandType.StoredProcedure, prmCnt)

                If count > 0 Then
                    MessageBox.Show("This machine contains activities. Set to inactive instead.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim question = String.Format("Are you sure you want to delete this machine?")
                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Dim prmDel(0) As SqlParameter
                    prmDel(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmDel(0).Value = machineId

                    dbMethod.ExecuteNonQuery("DelMntMachine", CommandType.StoredProcedure, prmDel)

                    Me.DialogResult = DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If Me.dgvList.Rows.Count > 0 Then
                Dim machineId As Integer = CType(Me.bsMachine.Current, DataRowView).Item("MachineId")

                Using frm As New MntMchDetail(machineId)
                    If frm.ShowDialog(Me) = DialogResult.OK Then
                        Reload()
                        bsMachine.Position = bsMachine.Find("MachineId", frm.pKey)
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Invoke(New Action(AddressOf GetScrollingIndex))
        LoadData()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            isFilterByMachineName = False
            isFilterByArea = False
            isFilterByMachineStatus = False
            isFilterByMachineSubStatus = False
            isFilterByGroup = False
            isFilterByFrequency = False
            isFilterBySerialNo = False

            cmbSearchCriteria.SelectedValue = 1

            pageIndex = 0
            LoadData()
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
                    isFilterByFrequency = False
                    isFilterByRemarks = False
                    isFilterBySerialNo = False

                Case 2
                    isFilterByMachineName = False
                    isFilterByArea = True
                    isFilterByMachineStatus = False
                    isFilterByMachineSubStatus = False
                    isFilterByGroup = False
                    isFilterByFrequency = False
                    isFilterByRemarks = False
                    isFilterBySerialNo = False

                Case 3
                    isFilterByMachineName = False
                    isFilterByArea = False
                    isFilterByMachineStatus = True
                    isFilterByMachineSubStatus = False
                    isFilterByGroup = False
                    isFilterByFrequency = False
                    isFilterByRemarks = False
                    isFilterBySerialNo = False

                Case 4
                    isFilterByMachineName = False
                    isFilterByArea = False
                    isFilterByMachineStatus = False
                    isFilterByMachineSubStatus = True
                    isFilterByGroup = False
                    isFilterByFrequency = False
                    isFilterByRemarks = False
                    isFilterBySerialNo = False

                Case 5
                    isFilterByMachineName = False
                    isFilterByArea = False
                    isFilterByMachineStatus = False
                    isFilterByMachineSubStatus = False
                    isFilterByGroup = True
                    isFilterByFrequency = False
                    isFilterByRemarks = False
                    isFilterBySerialNo = False

                Case 6
                    isFilterByMachineName = False
                    isFilterByArea = False
                    isFilterByMachineStatus = False
                    isFilterByMachineSubStatus = False
                    isFilterByGroup = False
                    isFilterByFrequency = True
                    isFilterByRemarks = False
                    isFilterBySerialNo = False

                Case 7
                    isFilterByMachineName = False
                    isFilterByArea = False
                    isFilterByMachineStatus = False
                    isFilterByMachineSubStatus = False
                    isFilterByGroup = False
                    isFilterByFrequency = False
                    isFilterByRemarks = True
                    isFilterBySerialNo = False

                Case 8
                    isFilterByMachineName = False
                    isFilterByArea = False
                    isFilterByMachineStatus = False
                    isFilterByMachineSubStatus = False
                    isFilterByGroup = False
                    isFilterByFrequency = False
                    isFilterByRemarks = False
                    isFilterBySerialNo = True
            End Select

            pageIndex = 0
            LoadData()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCommon_Validated(sender As Object, e As EventArgs) Handles cmbCommon.Validated
        If cmbSearchCriteria.SelectedValue = 6 Then
            If cmbCommon.SelectedValue = CStr(0) Then
                cmbCommon.SelectedValue = CStr(0)
            End If
        Else
            If cmbCommon.SelectedValue = 0 Then
                cmbCommon.SelectedValue = 0
            End If

            If cmbCommon.SelectedValue Is Nothing Then
                cmbCommon.SelectedIndex = 0
            End If
        End If

    End Sub

    Private Sub cmbSearchCriteria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSearchCriteria.SelectedValueChanged
        Try
            cmbCommon.SelectedValue = 0
            cmbCommon.DataSource = Nothing
            cmbCommon.Items.Clear()

            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    pnlSearchByCmb.Visible = False
                    pnlSearchByText.Visible = True

                Case 2
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadArea()

                Case 3
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadMachineStatus()

                Case 4
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadMachineSubStatus()

                Case 5
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadPartGroup()

                Case 6
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadFrequency()

                Case 7
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadRemarks()

                Case 8
                    pnlSearchByCmb.Visible = False
                    pnlSearchByText.Visible = True
            End Select

            Select Case cmbSearchCriteria.SelectedValue
                Case 2, 3, 4, 5, 6
                    ActiveControl = cmbCommon
                    cmbCommon.SelectedValue = 0
                Case 1, 8
                    ActiveControl = txtCommon
                    txtCommon.Text = String.Empty
                Case 7
                    ActiveControl = cmbCommon
                    cmbCommon.SelectedIndex = 0
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvTransactionHeader_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    Private Sub dgvTransactionHeader_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvList.DataError
        e.Cancel = False
    End Sub

    Private Sub GetScrollingIndex()
        indexScroll = dgvList.FirstDisplayedCell.RowIndex
        indexPosition = dgvList.CurrentRow.Index
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
            LoadData()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadArea()
        cmbCommon.DisplayMember = "AreaName"
        cmbCommon.ValueMember = "AreaId"

        dbMethod.FillCmbWithCaption("RdMntArea", CommandType.StoredProcedure, "AreaId", "AreaName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadMachineStatus()
        cmbCommon.DisplayMember = "MachineStatusName"
        cmbCommon.ValueMember = "MachineStatusId"

        dbMethod.FillCmbWithCaption("RdMntMachineStatus", CommandType.StoredProcedure, "MachineStatusId", "MachineStatusName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadMachineSubStatus()
        cmbCommon.DisplayMember = "MachineSubStatusName"
        cmbCommon.ValueMember = "MachineSubStatusId"

        dbMethod.FillCmbWithCaption("RdMntMachineSubStatus", CommandType.StoredProcedure, "MachineSubStatusId", "MachineSubStatusName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadPartGroup()
        cmbCommon.DisplayMember = "GroupName"
        cmbCommon.ValueMember = "GroupId"

        dbMethod.FillCmbWithCaption("RdMntMachinePartGroup", CommandType.StoredProcedure, "GroupId", "GroupName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadFrequency()
        cmbCommon.DisplayMember = "FrequencyName"
        cmbCommon.ValueMember = "FrequencyId"

        dbMethod.FillCmbWithCaption("RdGenFrequency", CommandType.StoredProcedure, "FrequencyId", "FrequencyName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadData()
        Try
            totalCount = 0

            If isFilterByMachineName = True Then
                Dim prmMasterlist(3) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@MachineName", SqlDbType.NVarChar)
                prmMasterlist(3).Value = txtCommon.Text.Trim

                dtMachine = dbMethod.FillDataTable("RdMntMachineMasterlistByMachineName", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value

            ElseIf isFilterByArea = True Then
                Dim prmMasterlist(3) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@AreaId", SqlDbType.Int)
                prmMasterlist(3).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                dtMachine = dbMethod.FillDataTable("RdMntMachineMasterlistByAreaId", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value

            ElseIf isFilterByMachineStatus = True Then
                Dim prmMasterlist(3) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                prmMasterlist(3).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                dtMachine = dbMethod.FillDataTable("RdMntMachineMasterlistByMachineStatusId", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value

            ElseIf isFilterByMachineSubStatus = True Then
                Dim prmMasterlist(3) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                prmMasterlist(3).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                dtMachine = dbMethod.FillDataTable("RdMntMachineMasterlistByMachineSubStatusId", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value

            ElseIf isFilterByGroup = True Then
                Dim prmMasterlist(3) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@GroupId", SqlDbType.Int)
                prmMasterlist(3).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                dtMachine = dbMethod.FillDataTable("RdMntMachineMasterlistByGroupId", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value

            ElseIf isFilterByFrequency = True Then
                Dim prmMasterlist(3) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@PmFrequencyId", SqlDbType.Char)
                prmMasterlist(3).Value = IIf(cmbCommon.SelectedValue = CStr(0), Nothing, cmbCommon.SelectedValue)

                dtMachine = dbMethod.FillDataTable("RdMntMachineMasterlistByPmFrequencyId", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value

            ElseIf isFilterByRemarks = True Then
                Dim prmMasterlist(3) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmMasterlist(3).Value = IIf(cmbCommon.SelectedValue Is Nothing, Nothing, IIf(cmbCommon.SelectedValue = 1, 1, 0))

                dtMachine = dbMethod.FillDataTable("RdMntMachineMasterlistByIsActive", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value

            ElseIf isFilterBySerialNo = True Then
                Dim prmMasterlist(3) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@SerialNumber", SqlDbType.VarChar)
                prmMasterlist(3).Value = txtCommon.Text.Trim

                dtMachine = dbMethod.FillDataTable("RdMntMachineMasterlistBySerialNumber", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value

            Else
                Dim prmMasterlist(2) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount

                dtMachine = dbMethod.FillDataTable("RdMntMachineMasterlist", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value
            End If

            Me.Text = String.Empty
            If CInt(totalCount) = 0 Or CInt(totalCount) = 1 Then
                Me.Text = "Machine Masterlist - " & totalCount & " item"
            Else
                Me.Text = "Machine Masterlist - " & totalCount & " items"
            End If

            bsMachine.DataSource = dtMachine
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
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSearchCriteria()
        Try
            dicSearchCriteria.Add(" Machine Name", 1)
            dicSearchCriteria.Add(" Area", 2)
            dicSearchCriteria.Add(" Status", 3)
            dicSearchCriteria.Add(" Sub-Status", 4)
            dicSearchCriteria.Add(" Part Group", 5)
            dicSearchCriteria.Add(" PM Frequency", 6)
            dicSearchCriteria.Add(" Remarks", 7)
            dicSearchCriteria.Add(" Serial No.", 8)

            cmbSearchCriteria.DisplayMember = "Key"
            cmbSearchCriteria.ValueMember = "Value"
            cmbSearchCriteria.DataSource = New BindingSource(dicSearchCriteria, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadRemarks()
        Try
            dicRemarks.Clear()

            dicRemarks.Add("< All >", Nothing)
            dicRemarks.Add(" Active", 1)
            dicRemarks.Add(" Inactive", 2)
            cmbCommon.DisplayMember = "Key"
            cmbCommon.ValueMember = "Value"
            cmbCommon.DataSource = New BindingSource(dicRemarks, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MntMch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvList.Dispose()
    End Sub

    Private Sub MntMch_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F2) Then
            e.Handled = True
            btnAdd.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F3) Then
            e.Handled = True
            btnEdit.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F5) Then
            e.Handled = True
            btnRefresh.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F8) Then
            e.Handled = True
            btnDelete.PerformClick()
        End If
    End Sub

    Private Sub MntMch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSearchCriteria()

        pageIndex = 0
        pageSize = 100
        LoadData()

        dbMain.EnableDoubleBuffered(dgvList)
        Me.ActiveControl = dgvList

        Me.dgvList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub SetScrollingIndex()
        dgvList.FirstDisplayedScrollingRowIndex = indexScroll
        If dgvList.Rows.Count > indexPosition Then
            dgvList.Rows(indexPosition).Selected = True
        Else
            dgvList.Rows(indexPosition - 1).Selected = True
        End If
        Me.bsMachine.Position = dgvList.SelectedCells(0).RowIndex
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

End Class