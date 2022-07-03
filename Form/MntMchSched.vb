Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class MntMchSched
    Public WithEvents bsSchedule As New BindingSource
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dicCriteriaStatus As New Dictionary(Of String, Integer)
    Private dicSearchCriteria As New Dictionary(Of String, Integer)
    Private dtSchedule As New DataTable
    Private indexPosition As Integer = 0
    Private indexScroll As Integer = 0
    Private isFilterByActivityBy As Boolean = False
    Private isFilterByActivityDate As Boolean = False
    Private isFilterByCreatedBy As Boolean = False
    Private isFilterByMachine As Boolean = False
    Private isFilterByMonth As Boolean = False
    Private isFilterByStatus As Boolean = False
    Private isFilterByWeek As Boolean = False
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
        txtYearId.Text = Year(dbMethod.GetServerDate)
    End Sub

    Public Sub Reload()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
        pageIndex = 0
        LoadSchedule()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        LoadSchedule()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        LoadSchedule()
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If

        LoadSchedule()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If

        LoadSchedule()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Using frm As New MntMchSchedDetail(userId)
                frm.ShowDialog(Me)
                Reload()
                bsSchedule.Position = bsSchedule.Find("ScheduleId", frm.pKey)
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
                Dim schedId As Integer = CType(Me.bsSchedule.Current, DataRowView).Item("ScheduleId")
                Dim isDone As Boolean = CType(Me.bsSchedule.Current, DataRowView).Item("IsDone")
                Dim question = String.Format("Are you sure you want to delete this record?")

                If isDone = True Then
                    MessageBox.Show("Unable to delete record that have already been completed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                Else
                    If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim prmDel(0) As SqlParameter
                        prmDel(0) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                        prmDel(0).Value = schedId

                        dbMethod.ExecuteNonQuery("DelMntMachineSchedule", CommandType.StoredProcedure, prmDel)

                        Reload()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If Me.dgvList.Rows.Count > 0 Then
                Dim schedId As Integer = CType(Me.bsSchedule.Current, DataRowView).Item("ScheduleId")

                Using frm As New MntMchSchedDetail(userId, schedId)
                    If frm.ShowDialog(Me) = DialogResult.OK Then
                        Reload()
                        bsSchedule.Position = bsSchedule.Find("ScheduleId", frm.pKey)
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
        pageIndex = 0
        LoadSchedule()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            isFilterByMachine = False
            isFilterByMonth = False
            isFilterByWeek = False
            isFilterByCreatedBy = False
            isFilterByActivityBy = False
            isFilterByActivityDate = False
            isFilterByStatus = False

            cmbSearchCriteria.SelectedValue = 1

            pageIndex = 0
            LoadSchedule()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    isFilterByMachine = True
                    isFilterByMonth = False
                    isFilterByWeek = False
                    isFilterByCreatedBy = False
                    isFilterByActivityBy = False
                    isFilterByActivityDate = False
                    isFilterByStatus = False

                Case 2
                    isFilterByMachine = False
                    isFilterByMonth = True
                    isFilterByWeek = False
                    isFilterByCreatedBy = False
                    isFilterByActivityBy = False
                    isFilterByActivityDate = False
                    isFilterByStatus = False

                Case 3
                    isFilterByMachine = False
                    isFilterByMonth = False
                    isFilterByWeek = True
                    isFilterByCreatedBy = False
                    isFilterByActivityBy = False
                    isFilterByActivityDate = False
                    isFilterByStatus = False

                Case 4
                    isFilterByMachine = False
                    isFilterByMonth = False
                    isFilterByWeek = False
                    isFilterByCreatedBy = True
                    isFilterByActivityBy = False
                    isFilterByActivityDate = False
                    isFilterByStatus = False

                Case 5
                    isFilterByMachine = False
                    isFilterByMonth = False
                    isFilterByWeek = False
                    isFilterByCreatedBy = False
                    isFilterByActivityBy = True
                    isFilterByActivityDate = False
                    isFilterByStatus = False

                Case 6
                    isFilterByMachine = False
                    isFilterByMonth = False
                    isFilterByWeek = False
                    isFilterByCreatedBy = False
                    isFilterByActivityBy = False
                    isFilterByActivityDate = True
                    isFilterByStatus = False

                Case 7
                    isFilterByMachine = False
                    isFilterByMonth = False
                    isFilterByWeek = False
                    isFilterByCreatedBy = False
                    isFilterByActivityBy = False
                    isFilterByActivityDate = False
                    isFilterByStatus = True
            End Select

            pageIndex = 0
            LoadSchedule()
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
                    LoadMachine()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                Case 2
                    LoadMonth()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                Case 3
                    txtCommon.Text = String.Empty

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = False
                    pnlSearchByText.Visible = True

                Case 4
                    LoadUserCreatedBy()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                Case 5
                    LoadUserActivityBy()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                Case 6
                    dtpStartDate.Value = CDate(Date.Now)
                    dtpEndDate.Value = CDate(Date.Now)

                    pnlSearchByDate.Visible = True
                    pnlSearchByCmb.Visible = False
                    pnlSearchByText.Visible = False

                Case 7
                    LoadStatus()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False
            End Select

            Select Case cmbSearchCriteria.SelectedValue
                Case 1, 3, 4, 5, 7
                    ActiveControl = cmbCommon
                Case 2
                    ActiveControl = txtCommon
                Case Else
                    ActiveControl = dtpStartDate
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
            LoadSchedule()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GoYear()
        Try
            If Not txtYearId.MaskCompleted Then
                MessageBox.Show("Please input a valid year.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtYearId.Focus()
                Return
            End If

            Reload()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMachine()
        dbMethod.FillCmbWithCaption("RdMntMachine", CommandType.StoredProcedure, "MachineId", "MachineName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadMonth()
        dbMethod.FillCmbWithCaption("RdGenMonth", CommandType.StoredProcedure, "MonthId", "MonthName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadSchedule()
        Try
            totalCount = 0

            If isFilterByMachine = True Then
                Dim prmSchedule(4) As SqlParameter
                prmSchedule(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmSchedule(0).Value = pageIndex
                prmSchedule(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmSchedule(1).Value = pageSize
                prmSchedule(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmSchedule(2).Direction = ParameterDirection.Output
                prmSchedule(2).Value = totalCount
                prmSchedule(3) = New SqlParameter("@YearId", SqlDbType.Int)
                prmSchedule(3).Value = txtYearId.Text
                prmSchedule(4) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmSchedule(4).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                dtSchedule = dbMethod.FillDataTable("RdMntMachineScheduleMasterlistByMachineId", CommandType.StoredProcedure, prmSchedule)
                totalCount = prmSchedule(2).Value

            ElseIf isFilterByMonth = True Then
                Dim prmSchedule(4) As SqlParameter
                prmSchedule(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmSchedule(0).Value = pageIndex
                prmSchedule(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmSchedule(1).Value = pageSize
                prmSchedule(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmSchedule(2).Direction = ParameterDirection.Output
                prmSchedule(2).Value = totalCount
                prmSchedule(3) = New SqlParameter("@YearId", SqlDbType.Int)
                prmSchedule(3).Value = txtYearId.Text
                prmSchedule(4) = New SqlParameter("@MonthId", SqlDbType.Int)
                prmSchedule(4).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                dtSchedule = dbMethod.FillDataTable("RdMntMachineScheduleMasterlistByMonthId", CommandType.StoredProcedure, prmSchedule)
                totalCount = prmSchedule(2).Value

            ElseIf isFilterByWeek = True Then
                Dim prmSchedule(4) As SqlParameter
                prmSchedule(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmSchedule(0).Value = pageIndex
                prmSchedule(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmSchedule(1).Value = pageSize
                prmSchedule(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmSchedule(2).Direction = ParameterDirection.Output
                prmSchedule(2).Value = totalCount
                prmSchedule(3) = New SqlParameter("@YearId", SqlDbType.Int)
                prmSchedule(3).Value = txtYearId.Text
                prmSchedule(4) = New SqlParameter("@WeekId", SqlDbType.Int)
                prmSchedule(4).Value = IIf(String.IsNullOrEmpty(txtCommon.Text.Trim), Nothing, txtCommon.Text)

                dtSchedule = dbMethod.FillDataTable("RdMntMachineScheduleMasterlistByWeekId", CommandType.StoredProcedure, prmSchedule)
                totalCount = prmSchedule(2).Value

            ElseIf isFilterByCreatedBy = True Then
                Dim prmSchedule(4) As SqlParameter
                prmSchedule(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmSchedule(0).Value = pageIndex
                prmSchedule(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmSchedule(1).Value = pageSize
                prmSchedule(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmSchedule(2).Direction = ParameterDirection.Output
                prmSchedule(2).Value = totalCount
                prmSchedule(3) = New SqlParameter("@YearId", SqlDbType.Int)
                prmSchedule(3).Value = txtYearId.Text
                prmSchedule(4) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                prmSchedule(4).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                dtSchedule = dbMethod.FillDataTable("RdMntMachineScheduleMasterlistByCreatedBy", CommandType.StoredProcedure, prmSchedule)
                totalCount = prmSchedule(2).Value

            ElseIf isFilterByActivityBy = True Then
                Dim prmSchedule(4) As SqlParameter
                prmSchedule(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmSchedule(0).Value = pageIndex
                prmSchedule(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmSchedule(1).Value = pageSize
                prmSchedule(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmSchedule(2).Direction = ParameterDirection.Output
                prmSchedule(2).Value = totalCount
                prmSchedule(3) = New SqlParameter("@YearId", SqlDbType.Int)
                prmSchedule(3).Value = txtYearId.Text
                prmSchedule(4) = New SqlParameter("@ActivityBy", SqlDbType.Int)
                prmSchedule(4).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                dtSchedule = dbMethod.FillDataTable("RdMntMachineScheduleMasterlistByActivityBy", CommandType.StoredProcedure, prmSchedule)
                totalCount = prmSchedule(2).Value

            ElseIf isFilterByActivityDate = True Then
                Dim prmSchedule(4) As SqlParameter
                prmSchedule(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmSchedule(0).Value = pageIndex
                prmSchedule(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmSchedule(1).Value = pageSize
                prmSchedule(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmSchedule(2).Direction = ParameterDirection.Output
                prmSchedule(2).Value = totalCount
                prmSchedule(3) = New SqlParameter("@StartDate", SqlDbType.Date)
                prmSchedule(3).Value = CDate(dtpStartDate.Value)
                prmSchedule(4) = New SqlParameter("@EndDate", SqlDbType.Date)
                prmSchedule(4).Value = CDate(dtpEndDate.Value)

                dtSchedule = dbMethod.FillDataTable("RdMntMachineScheduleMasterlistByActivityDate", CommandType.StoredProcedure, prmSchedule)
                totalCount = prmSchedule(2).Value

            ElseIf isFilterByStatus = True Then
                Dim prmSchedule(4) As SqlParameter
                prmSchedule(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmSchedule(0).Value = pageIndex
                prmSchedule(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmSchedule(1).Value = pageSize
                prmSchedule(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmSchedule(2).Direction = ParameterDirection.Output
                prmSchedule(2).Value = totalCount
                prmSchedule(3) = New SqlParameter("@YearId", SqlDbType.Int)
                prmSchedule(3).Value = txtYearId.Text
                prmSchedule(4) = New SqlParameter("@IsDone", SqlDbType.Bit)
                Select Case cmbCommon.SelectedValue
                    Case 0
                        prmSchedule(4).Value = Nothing

                    Case 1
                        prmSchedule(4).Value = True

                    Case 2
                        prmSchedule(4).Value = False
                End Select

                dtSchedule = dbMethod.FillDataTable("RdMntMachineScheduleMasterlistByStatus", CommandType.StoredProcedure, prmSchedule)
                totalCount = prmSchedule(2).Value
            Else
                Dim prmSchedule(3) As SqlParameter
                prmSchedule(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmSchedule(0).Value = pageIndex
                prmSchedule(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmSchedule(1).Value = pageSize
                prmSchedule(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmSchedule(2).Direction = ParameterDirection.Output
                prmSchedule(2).Value = totalCount
                prmSchedule(3) = New SqlParameter("@YearId", SqlDbType.Int)
                prmSchedule(3).Value = txtYearId.Text

                dtSchedule = dbMethod.FillDataTable("RdMntMachineScheduleMasterlist", CommandType.StoredProcedure, prmSchedule)
                totalCount = prmSchedule(2).Value
            End If

            bsSchedule.DataSource = dtSchedule
            bsSchedule.ResetBindings(True)
            dgvList.AutoGenerateColumns = False
            dgvList.DataSource = bsSchedule

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
            dicSearchCriteria.Add(" Machine", 1)
            dicSearchCriteria.Add(" Month", 2)
            dicSearchCriteria.Add(" Week No", 3)
            dicSearchCriteria.Add(" Created By", 4)
            dicSearchCriteria.Add(" Activity By", 5)
            dicSearchCriteria.Add(" Activity Date", 6)
            dicSearchCriteria.Add(" Status", 7)

            cmbSearchCriteria.DisplayMember = "Key"
            cmbSearchCriteria.ValueMember = "Value"
            cmbSearchCriteria.DataSource = New BindingSource(dicSearchCriteria, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadStatus()
        dicCriteriaStatus.Clear()

        dicCriteriaStatus.Add(" < All >", 0)
        dicCriteriaStatus.Add(" Done", 1)
        dicCriteriaStatus.Add(" Pending", 2)

        cmbCommon.DisplayMember = "Key"
        cmbCommon.ValueMember = "Value"
        cmbCommon.DataSource = New BindingSource(dicCriteriaStatus, Nothing)
    End Sub

    Private Sub LoadUserActivityBy()
        Dim prmUser(0) As SqlParameter
        prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
        prmUser(0).Value = 2

        dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbCommon, "< All >", prmUser)
    End Sub

    Private Sub LoadUserCreatedBy()
        Dim prmUser(0) As SqlParameter
        prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
        prmUser(0).Value = 2

        dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbCommon, "< All >", prmUser)
    End Sub

    Private Sub MntMchSchedule_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvList.Dispose()
    End Sub

    Private Sub MntMchSchedule_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub MntMchSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSearchCriteria()

        pageIndex = 0
        pageSize = 100
        LoadSchedule()

        dbMain.EnableDoubleBuffered(dgvList)
        Me.ActiveControl = dgvList

        Me.dgvList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub SetScrollingIndex()
        dgvList.FirstDisplayedScrollingRowIndex = indexScroll
        If dgvList.Rows.Count > indexPosition Then
            dgvList.Rows(indexPosition).Selected = True
        Else
            dgvList.Rows(indexPosition - 1).Selected = True
        End If
        Me.bsSchedule.Position = dgvList.SelectedCells(0).RowIndex
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

    Private Sub txtYearId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtYearId.KeyPress
        If ((Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57) OrElse Asc(e.KeyChar) = 8 OrElse Asc(e.KeyChar) = 13 OrElse Asc(e.KeyChar) = 127) Then
            e.Handled = False
            If Asc(e.KeyChar) = 13 Then
                GoYear()
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtYearId_Validated(sender As Object, e As EventArgs) Handles txtYearId.Validated
        GoYear()
    End Sub

    Private Sub txtYearId_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtYearId.Validating
        If Not txtYearId.MaskCompleted Then
            MessageBox.Show("Please input a valid year.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub cmbCommon_Validated(sender As Object, e As EventArgs) Handles cmbCommon.Validated
        If cmbCommon.SelectedValue = 0 Then
            cmbCommon.SelectedValue = 0
        End If
    End Sub

    Private Sub txtYearId_Enter(sender As Object, e As EventArgs) Handles txtYearId.Enter
        lblYear.ForeColor = Color.White
        lblYear.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtYearId_Leave(sender As Object, e As EventArgs) Handles txtYearId.Leave
        lblYear.ForeColor = Color.Black
        lblYear.BackColor = SystemColors.Control
    End Sub

End Class