Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class MntTrxConsole
    Private dbConnection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)

    Private dtJig As New DataTable
    Private dtMachine As New DataTable
    Private dtTrxHeader As New DataTable

    Private bsJigAccumulatedTime As New BindingSource
    Private bsMachineAccumulatedTime As New BindingSource
    Private bsTransactionHeader As New BindingSource

    Private isFilterByActionTaken As Boolean = False
    Private isFilterByAreaId As Boolean = False
    Private isFilterByDatetimeEnded As Boolean = False
    Private isFilterByDatetimeStarted As Boolean = False
    Private isFilterByDowntimeJigStatusId As Boolean = False
    Private isFilterByDowntimeMachineStatusId As Boolean = False
    Private isFilterByJigId As Boolean = False
    Private isFilterByJoNumber As Boolean = False
    Private isFilterByJoRequestor As Boolean = False
    Private isFilterByMachineId As Boolean = False
    Private isFilterByProblem As Boolean = False
    Private isFilterByRootCause As Boolean = False
    Private isFilterByShiftId As Boolean = False
    Private isFilterByTransactionDate As Boolean = False
    Private isFilterByUserId As Boolean = False

    Private pageIndex As Integer
    Private pageSize As Integer
    Private pageCount As Integer
    Private totalCount As Integer

    Private indexPosition As Integer = 0
    Private indexScroll As Integer = 0

    Private lastMachineTransactionDate As New DateTime
    Private tmrMachineSpan As TimeSpan = Nothing
    Private tmrMachineDays As Integer = 0
    Private tmrMachineHours As Integer = 0
    Private tmrMachineMinutes As Integer = 0

    Private lastJigTransactionDate As New DateTime
    Private tmrJigSpan As TimeSpan = Nothing
    Private tmrJigDays As Integer = 0
    Private tmrJigHours As Integer = 0
    Private tmrJigMinutes As Integer = 0

    Private dicSearch As New Dictionary(Of String, Integer)
    Private dicStatus As New Dictionary(Of String, Integer)
    Private dicShift As New Dictionary(Of String, Object)

    Private machineStatusId As Integer = 1
    Private jigStatusId As Integer = 1

    Private accessLevelId As Integer = 0

    Private userId As Integer = 0
    Private workgroupId As Integer = 0
    Private sectionId As Integer = 0
    Private isAdmin As Boolean = False

    Private superiorWorkgroupId As New List(Of Integer) From {29, 30, 35, 2}

    Private isDebug As Boolean = My.Settings.IsDebug

    Public Sub New(_userId As Integer, _workgroupId As Integer, _sectionId As Integer, _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        workgroupId = _workgroupId
        sectionId = _sectionId
        isAdmin = _isAdmin

        Select Case workgroupId
            Case 1, 2, 3 Or isAdmin 'sys admin, sr mngr, mngr
                accessLevelId = 1
            Case 35, 40 'mngr, asst mngr
                accessLevelId = 2
            Case 29, 30 'sv, asv
                accessLevelId = 3
            Case 5 'sr tech
                accessLevelId = 4
            Case Else
                accessLevelId = 99
        End Select
    End Sub

    Private Sub MntTrxConsole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchCriteria()
        TransactionStatus()

        pageIndex = 0
        pageSize = 50
        LoadTransaction()

        LoadJig()
        LoadMachine()

        dbMain.EnableDoubleBuffered(dgvMachine)
        dbMain.EnableDoubleBuffered(dgvList)
        Me.ActiveControl = dgvList

        Me.dgvList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvMachine.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvJig.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        cmbStatus.SelectedValue = 7
    End Sub

    Private Sub MntTrxConsole_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F2) Then
            e.Handled = True
            btnCreate.PerformClick()
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

    Private Sub MntTrxConsole_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvMachine.Dispose()
        dgvList.Dispose()
        tmrElapsedTime.Stop()
    End Sub

    Private Sub dgvTransactionHeader_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    Private Sub dgvTransactionHeader_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvList.DataError
        e.Cancel = False
    End Sub

    Private Sub dgvMachine_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMachine.SelectionChanged
        dgvMachine.ClearSelection()
    End Sub

    Private Sub dgvMachine_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvMachine.CellFormatting
        Try
            'for loop was used to access hidden column
            For i As Integer = 0 To dgvMachine.Rows.Count - 1
                machineStatusId = dgvMachine.Rows(i).Cells("ColMachineStatusId").Value

                If machineStatusId = 1 Then
                    dgvMachine.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen 'operational
                ElseIf machineStatusId = 2 Then
                    dgvMachine.Rows(i).DefaultCellStyle.BackColor = Color.Orange 'scheduled
                Else
                    dgvMachine.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral 'unscheduled
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvMachine_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvMachine.DataBindingComplete
        Try
            tmrElapsedTime.Start()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvJig_SelectionChanged(sender As Object, e As EventArgs) Handles dgvJig.SelectionChanged
        dgvJig.ClearSelection()
    End Sub

    Private Sub dgvJig_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvJig.CellFormatting
        Try
            'for loop was used to access hidden column
            For i As Integer = 0 To dgvJig.Rows.Count - 1
                jigStatusId = dgvJig.Rows(i).Cells("ColJigStatusId").Value

                If jigStatusId = 1 Then
                    dgvJig.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen 'operational
                ElseIf jigStatusId = 2 Then
                    dgvJig.Rows(i).DefaultCellStyle.BackColor = Color.Orange 'scheduled
                ElseIf jigStatusId = 3 Then
                    dgvJig.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral 'unscheduled
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvJig_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvJig.DataBindingComplete
        Try
            tmrElapsedTime.Start()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Try
            cmsConsole.Show(btnCreate, New Point(0, 0))
            MachineRelatedToolStripMenuItem.Select()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MachineRelatedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MachineRelatedToolStripMenuItem.Click
        Try
            Using frmDetail As New MntTrxDetailMch(userId, workgroupId, isAdmin)
                If frmDetail.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Reload()
                    LoadJig()
                    LoadMachine()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub JigRelatedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JigRelatedToolStripMenuItem.Click
        Try
            Using frmDetail As New MntTrxDetailJig(userId, workgroupId, isAdmin)
                If frmDetail.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Reload()
                    LoadJig()
                    LoadMachine()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OthersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OthersToolStripMenuItem.Click
        Try
            Using frmDetail As New MntTrxDetailOth(userId, workgroupId, isAdmin)
                frmDetail.ShowDialog(Me)
                If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                    Reload()
                    LoadJig()
                    LoadMachine()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If Me.dgvList.Rows.Count > 0 Then
                Dim trxId As Integer = CType(Me.bsTransactionHeader.Current, DataRowView).Item("TrxId")

                If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId") Is DBNull.Value Then
                    Using frmDetail As New MntTrxDetailMch(userId, workgroupId, isAdmin, trxId)
                        frmDetail.ShowDialog(Me)
                        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                            Reload()
                            LoadJig()
                            LoadMachine()
                        End If
                    End Using

                ElseIf Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("JigId") Is DBNull.Value Then
                    Using frmDetail As New MntTrxDetailJig(userId, workgroupId, isAdmin, trxId)
                        frmDetail.ShowDialog(Me)
                        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                            Reload()
                            LoadJig()
                            LoadMachine()
                        End If
                    End Using
                Else
                    Using frmDetail As New MntTrxDetailOth(userId, workgroupId, isAdmin, trxId)
                        frmDetail.ShowDialog(Me)
                        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                            Reload()
                            LoadJig()
                            LoadMachine()
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            'allow delete function from senior technician and above only
            If accessLevelId >= 4 Then 'technician and below
                MessageBox.Show("You do not have permission to delete a record.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to delete this record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) =
                Windows.Forms.DialogResult.Yes Then

                Dim trxId As Integer = CType(Me.bsTransactionHeader.Current, DataRowView).Item("TrxId")

                If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId") Is DBNull.Value Then
                    Dim prmCnt(0) As SqlParameter
                    prmCnt(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmCnt(0).Value = trxId

                    If dbMethod.ExecuteScalar("CntMntMachineSchedule", CommandType.StoredProcedure, prmCnt) > 0 Then
                        Dim prmSch(0) As SqlParameter
                        prmSch(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmSch(0).Value = trxId

                        Dim scheduleId As Integer = dbMethod.ExecuteScalar("SELECT ScheduleId FROM dbo.MntMachineSchedule WHERE TrxId = @TrxId", CommandType.Text)

                        Dim prmMchSchdOrg(8) As SqlParameter 'revert schedule to pending
                        prmMchSchdOrg(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmMchSchdOrg(0).Value = Nothing
                        prmMchSchdOrg(1) = New SqlParameter("@IsDone", SqlDbType.Bit)
                        prmMchSchdOrg(1).Value = False
                        prmMchSchdOrg(2) = New SqlParameter("@IsChecklistCompleted", SqlDbType.Bit)
                        prmMchSchdOrg(2).Value = False
                        prmMchSchdOrg(3) = New SqlParameter("@ActivityBy", SqlDbType.Int)
                        prmMchSchdOrg(3).Value = Nothing
                        prmMchSchdOrg(4) = New SqlParameter("@ActivityDate", SqlDbType.Date)
                        prmMchSchdOrg(4).Value = Nothing
                        prmMchSchdOrg(5) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                        prmMchSchdOrg(5).Value = Nothing
                        prmMchSchdOrg(6) = New SqlParameter("@ModifiedDate", SqlDbType.Date)
                        prmMchSchdOrg(6).Value = Nothing
                        prmMchSchdOrg(7) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                        prmMchSchdOrg(7).Value = Nothing
                        prmMchSchdOrg(8) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                        prmMchSchdOrg(8).Value = scheduleId

                        dbMethod.ExecuteNonQuery("UpdMntMachineScheduleByScheduleId", CommandType.StoredProcedure, prmMchSchdOrg)
                    End If

                    'if this is the last on-going transaction, revert the machine to operational status
                    Dim machineId As Integer = CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId")

                    Dim prmIsLast(0) As SqlParameter
                    prmIsLast(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmIsLast(0).Value = machineId

                    If trxId = dbMethod.ExecuteScalar("SELECT TOP 1 TrxId FROM dbo.MntTransactionHeader WHERE MachineId = @MachineId AND TrxStatusId = 2 ORDER BY TrxId DESC",
                                                  CommandType.Text, prmIsLast) Then
                        Dim prmMachineStatus(2) As SqlParameter
                        prmMachineStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prmMachineStatus(0).Value = CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId")
                        prmMachineStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                        prmMachineStatus(1).Value = 1
                        prmMachineStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                        prmMachineStatus(2).Value = 1

                        dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMachineStatus)
                    End If
                End If

                If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("JigId") Is DBNull.Value Then
                    Dim prmCnt(0) As SqlParameter
                    prmCnt(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmCnt(0).Value = trxId

                    If dbMethod.ExecuteScalar("CntMntJigSchedule", CommandType.StoredProcedure, prmCnt) > 0 Then
                        Dim prmSch(0) As SqlParameter
                        prmSch(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmSch(0).Value = trxId

                        Dim scheduleId As Integer = dbMethod.ExecuteScalar("SELECT ScheduleId FROM dbo.MntJigSchedule WHERE TrxId = @TrxId", CommandType.Text)

                        Dim prmMchSchdOrg(8) As SqlParameter
                        prmMchSchdOrg(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmMchSchdOrg(0).Value = Nothing
                        prmMchSchdOrg(1) = New SqlParameter("@IsDone", SqlDbType.Bit)
                        prmMchSchdOrg(1).Value = False
                        prmMchSchdOrg(2) = New SqlParameter("@IsChecklistCompleted", SqlDbType.Bit)
                        prmMchSchdOrg(2).Value = False
                        prmMchSchdOrg(3) = New SqlParameter("@ActivityBy", SqlDbType.Int)
                        prmMchSchdOrg(3).Value = Nothing
                        prmMchSchdOrg(4) = New SqlParameter("@ActivityDate", SqlDbType.Date)
                        prmMchSchdOrg(4).Value = Nothing
                        prmMchSchdOrg(5) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                        prmMchSchdOrg(5).Value = Nothing
                        prmMchSchdOrg(6) = New SqlParameter("@ModifiedDate", SqlDbType.Date)
                        prmMchSchdOrg(6).Value = Nothing
                        prmMchSchdOrg(7) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                        prmMchSchdOrg(7).Value = Nothing
                        prmMchSchdOrg(8) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                        prmMchSchdOrg(8).Value = scheduleId

                        dbMethod.ExecuteNonQuery("UpdMntJigScheduleByScheduleId", CommandType.StoredProcedure, prmMchSchdOrg)
                    End If

                    'if this is the last on-going transaction, revert the machine to operational status
                    Dim jigId As Integer = CType(Me.bsTransactionHeader.Current, DataRowView).Item("JigId")

                    Dim prmIsLast(0) As SqlParameter
                    prmIsLast(0) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmIsLast(0).Value = jigId

                    If trxId = dbMethod.ExecuteScalar("SELECT TOP 1 TrxId FROM dbo.MntTransactionHeader WHERE JigId = @JigId AND TrxStatusId = 2 ORDER BY TrxId DESC",
                                                  CommandType.Text, prmIsLast) Then

                        Dim prmMachineStatus(2) As SqlParameter
                        prmMachineStatus(0) = New SqlParameter("@JigId", SqlDbType.Int)
                        prmMachineStatus(0).Value = CType(Me.bsTransactionHeader.Current, DataRowView).Item("JigId")
                        prmMachineStatus(1) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                        prmMachineStatus(1).Value = 1
                        prmMachineStatus(2) = New SqlParameter("@JigSubStatusId", SqlDbType.Int)
                        prmMachineStatus(2).Value = 1

                        dbMethod.ExecuteNonQuery("UpdMntJigByJigStatusId", CommandType.StoredProcedure, prmMachineStatus)
                    End If
                End If

                Dim prmDel(0) As SqlParameter
                prmDel(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                prmDel(0).Value = trxId

                dbMethod.ExecuteNonQuery("DelMntTransactionHeader", CommandType.StoredProcedure, prmDel)

                Reload()
                LoadJig()
                LoadMachine()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbSearchCriteria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSearchCriteria.SelectedValueChanged
        Try
            Select Case cmbSearchCriteria.SelectedValue
                Case 1, 7, 8
                    dtpStartDate.Value = CDate(dbMethod.GetServerDate).Date
                    dtpEndDate.Value = CDate(dbMethod.GetServerDate).Date

                    pnlSearchByDate.Visible = True
                    pnlSearchByCmb.Visible = False
                    pnlSearchByText.Visible = False
                    Me.ActiveControl = dtpStartDate

                Case 2, 3, 4, 5, 6, 12, 13
                    cmbCommonCmb.SelectedValue = 0
                    cmbCommonCmb.DataSource = Nothing
                    cmbCommonCmb.Items.Clear()

                    Select Case cmbSearchCriteria.SelectedValue
                        Case 2
                            dbMethod.FillCmbWithCaption("RdMntMachine", CommandType.StoredProcedure, "MachineId", "MachineName", cmbCommonCmb, "< All >")

                        Case 3
                            dbMethod.FillCmbWithCaption("RdMntMachineStatus", CommandType.StoredProcedure, "MachineStatusId", "MachineStatusName", cmbCommonCmb, "< All >")

                        Case 4
                            dbMethod.FillCmbWithCaption("RdMntJig", CommandType.StoredProcedure, "JigId", "JigCompleteName", cmbCommonCmb, "< All >")

                        Case 5
                            dbMethod.FillCmbWithCaption("RdMntJigStatus", CommandType.StoredProcedure, "JigStatusId", "JigStatusName", cmbCommonCmb, "< All >")

                        Case 6
                            dbMethod.FillCmbWithCaption("RdMntArea", CommandType.StoredProcedure, "AreaId", "AreaName", cmbCommonCmb, "< All >")

                        Case 12
                            Dim prmSec(0) As SqlParameter
                            prmSec(0) = New SqlParameter("@SectionId", SqlDbType.Int)
                            prmSec(0).Value = sectionId

                            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbCommonCmb, "< All >", prmSec)

                        Case 13
                            GetShift()
                    End Select

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    Me.ActiveControl = cmbCommonCmb

                Case 9, 10, 11, 14, 15
                    txtCommonTxt.Text = String.Empty

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = False
                    pnlSearchByText.Visible = True
                    Me.ActiveControl = txtCommonTxt
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCommonCmb_Validated(sender As Object, e As EventArgs) Handles cmbCommonCmb.Validated
        Try
            Select Case cmbSearchCriteria.SelectedValue
                Case 2, 3, 4, 5, 6, 12
                    If String.IsNullOrEmpty(cmbCommonCmb.Text) Or cmbCommonCmb.SelectedValue = 0 Or cmbCommonCmb.SelectedValue Is Nothing Then
                        cmbCommonCmb.SelectedValue = 0
                    End If
                Case 13
                    If String.IsNullOrEmpty(cmbCommonCmb.Text) Or cmbCommonCmb.SelectedValue Is Nothing Then
                        cmbCommonCmb.SelectedIndex = 0
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    If dtpStartDate.Value.Date > dtpEndDate.Value.Date Then
                        MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    isFilterByTransactionDate = True
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 2
                    isFilterByTransactionDate = False
                    isFilterByMachineId = True
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 3
                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = True
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 4
                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = True
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 5
                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = True
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 6
                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = True
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 7
                    If dtpStartDate.Value.Date > dtpEndDate.Value.Date Then
                        MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = True
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 8
                    If dtpStartDate.Value.Date > dtpEndDate.Value.Date Then
                        MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = True
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 9
                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = True
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 10
                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = True
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 11
                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = True
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 12
                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = True
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 13
                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = True
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 14
                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = True
                    isFilterByJoRequestor = False

                Case 15
                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = True
            End Select

            pageIndex = 0
            LoadTransaction()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    dtpStartDate.Value = CDate(dbMethod.GetServerDate).Date
                    dtpEndDate.Value = CDate(dbMethod.GetServerDate).Date

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 2
                    cmbCommonCmb.SelectedValue = 0

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 3
                    cmbCommonCmb.SelectedValue = 0

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 4
                    cmbCommonCmb.SelectedValue = 0

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 5
                    cmbCommonCmb.SelectedValue = 0

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 6
                    cmbCommonCmb.SelectedValue = 0

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 7
                    dtpStartDate.Value = CDate(dbMethod.GetServerDate).Date
                    dtpEndDate.Value = CDate(dbMethod.GetServerDate).Date

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 8
                    dtpStartDate.Value = CDate(dbMethod.GetServerDate).Date
                    dtpEndDate.Value = CDate(dbMethod.GetServerDate).Date

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 9
                    txtCommonTxt.Text = String.Empty

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 10
                    txtCommonTxt.Text = String.Empty

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 11
                    txtCommonTxt.Text = String.Empty

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 12
                    cmbCommonCmb.SelectedValue = 0

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 13
                    cmbCommonCmb.SelectedValue = 0

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 14
                    txtCommonTxt.Text = String.Empty

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False

                Case 15
                    txtCommonTxt.Text = String.Empty

                    isFilterByTransactionDate = False
                    isFilterByMachineId = False
                    isFilterByDowntimeMachineStatusId = False
                    isFilterByJigId = False
                    isFilterByDowntimeJigStatusId = False
                    isFilterByAreaId = False
                    isFilterByDatetimeStarted = False
                    isFilterByDatetimeEnded = False
                    isFilterByProblem = False
                    isFilterByRootCause = False
                    isFilterByActionTaken = False
                    isFilterByUserId = False
                    isFilterByShiftId = False
                    isFilterByJoNumber = False
                    isFilterByJoRequestor = False
            End Select

            pageIndex = 0
            LoadTransaction()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        LoadTransaction()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If

        LoadTransaction()
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If

        LoadTransaction()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        LoadTransaction()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            pageIndex = 0
            pageSize = 50
            LoadTransaction()

            LoadJig()
            LoadMachine()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub cmbStatus_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedValueChanged
        pageIndex = 0
        pageSize = 50
        LoadTransaction()
    End Sub

    Private Sub tmrElapsed_Tick(sender As Object, e As EventArgs) Handles tmrElapsedTime.Tick
        Try
            For i As Integer = 0 To dgvMachine.Rows.Count - 1
                If Not dgvMachine.Rows(i).Cells("ColMachineLastTransaction").Value.Equals(DBNull.Value) Then
                    lastMachineTransactionDate = dgvMachine.Rows(i).Cells("ColMachineLastTransaction").Value

                    If Not lastMachineTransactionDate = "01/01/0001 12:00:00 AM" Then
                        tmrMachineSpan = (lastMachineTransactionDate - DateTime.Now).Duration()
                        tmrMachineMinutes = tmrMachineSpan.Minutes
                        tmrMachineHours = tmrMachineSpan.Hours
                        tmrMachineDays = tmrMachineSpan.Days

                        dgvMachine.Rows(i).Cells("ColMachineElapsedTime").Value = tmrMachineDays.ToString("00") & ":" & tmrMachineHours.ToString("00") & ":" & tmrMachineMinutes.ToString("00")
                    End If
                End If
            Next

            For i As Integer = 0 To dgvJig.Rows.Count - 1
                If Not dgvJig.Rows(i).Cells("ColJigLastTransaction").Value.Equals(DBNull.Value) Then
                    lastJigTransactionDate = dgvJig.Rows(i).Cells("ColJigLastTransaction").Value

                    If Not lastJigTransactionDate = "01/01/0001 12:00:00 AM" Then
                        tmrJigSpan = (lastJigTransactionDate - DateTime.Now).Duration()
                        tmrJigMinutes = tmrJigSpan.Minutes
                        tmrJigHours = tmrJigSpan.Hours
                        tmrJigDays = tmrJigSpan.Days

                        dgvJig.Rows(i).Cells("ColJigElapsedTime").Value = tmrJigDays.ToString("00") & ":" & tmrJigHours.ToString("00") & ":" & tmrJigMinutes.ToString("00")
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SearchCriteria()
        dicSearch.Add(" Transaction Date", 1)
        dicSearch.Add(" Machine Name", 2)
        dicSearch.Add(" Machine Status", 3)
        dicSearch.Add(" Jig Name", 4)
        dicSearch.Add(" Jig Status", 5)
        dicSearch.Add(" Area", 6)
        dicSearch.Add(" Date Started", 7)
        dicSearch.Add(" Date Ended", 8)
        dicSearch.Add(" Problem", 9)
        dicSearch.Add(" Root Cause", 10)
        dicSearch.Add(" Action Taken", 11)
        dicSearch.Add(" Username", 12)
        dicSearch.Add(" Shift", 13)
        dicSearch.Add(" JO Number", 14)
        dicSearch.Add(" JO Requestor", 15)
        cmbSearchCriteria.DisplayMember = "Key"
        cmbSearchCriteria.ValueMember = "Value"
        cmbSearchCriteria.DataSource = New BindingSource(dicSearch, Nothing)
    End Sub

    Private Sub LoadTransaction()
        Try
            totalCount = 0

            If isFilterByTransactionDate = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value.Date
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value.Date

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdTrxDate", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdTrxDate", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdTrxDate", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdTrxDate", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdTrxDate", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdTrxDate", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdTrxDate", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByMachineId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdMachineId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdMachineId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdMachineId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdMachineId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdMachineId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdMachineId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdMachineId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByDowntimeMachineStatusId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@DowntimeMachineStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@DowntimeMachineStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@DowntimeMachineStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@DowntimeMachineStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@DowntimeMachineStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@DowntimeMachineStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@DowntimeMachineStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByJigId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJigId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJigId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJigId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJigId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJigId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJigId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJigId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByDowntimeJigStatusId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByAreaId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@AreaId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdAreaId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@AreaId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdAreaId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@AreaId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdAreaId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@AreaId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdAreaId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@AreaId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdAreaId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@AreaId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdAreaId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@AreaId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdAreaId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByDatetimeStarted = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeStarted", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByDatetimeEnded = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(5) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmRouting(4).Value = dtpStartDate.Value
                    prmRouting(5) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmRouting(5).Value = dtpEndDate.Value

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdDatetimeEnded", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByProblem = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdProblem", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdProblem", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@AreaId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdAreaId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdProblem", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdProblem", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdProblem", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdProblem", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByRootCause = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdRootCause", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdRootCause", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdRootCause", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdRootCause", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdRootCause", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdRootCause", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdRootCause", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByActionTaken = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdActionTaken", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdActionTaken", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdActionTaken", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdActionTaken", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdActionTaken", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdActionTaken", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdActionTaken", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByUserId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@UserId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdUserId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@UserId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdUserId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@UserId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdUserId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@UserId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdUserId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@UserId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdUserId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@UserId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdUserId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@UserId", SqlDbType.Int)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdUserId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByShiftId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@ShiftId", SqlDbType.Char)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue Is Nothing, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdShiftId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@ShiftId", SqlDbType.Char)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue Is Nothing, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdShiftId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@ShiftId", SqlDbType.Char)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue Is Nothing, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdShiftId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@ShiftId", SqlDbType.Char)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue Is Nothing, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdShiftId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@ShiftId", SqlDbType.Char)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue Is Nothing, Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdShiftId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@ShiftId", SqlDbType.Char)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = "0", Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdShiftId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@ShiftId", SqlDbType.Char)
                    prmRouting(4).Value = IIf(cmbCommonCmb.SelectedValue = "0", Nothing, cmbCommonCmb.SelectedValue)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdShiftId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByJoNumber = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@JoNumber", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoNumber", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@JoNumber", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoNumber", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@JoNumber", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoNumber", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@JoNumber", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoNumber", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@JoNumber", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoNumber", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@JoNumber", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoNumber", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@JoNumber", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoNumber", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If

            ElseIf isFilterByJoRequestor = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5
                    prmRouting(4) = New SqlParameter("@JoRequestor", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoRequestor", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6
                    prmRouting(4) = New SqlParameter("@JoRequestor", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoRequestor", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4
                    prmRouting(4) = New SqlParameter("@JoRequestor", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoRequestor", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3
                    prmRouting(4) = New SqlParameter("@JoRequestor", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoRequestor", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2
                    prmRouting(4) = New SqlParameter("@JoRequestor", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoRequestor", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1
                    prmRouting(4) = New SqlParameter("@JoRequestor", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoRequestor", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(4) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing
                    prmRouting(4) = New SqlParameter("@JoRequestor", SqlDbType.NVarChar)
                    prmRouting(4).Value = IIf(String.IsNullOrEmpty(txtCommonTxt.Text.Trim), Nothing, txtCommonTxt.Text.Trim)

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusIdJoRequestor", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If
            Else
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Dim prmRouting(3) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 5

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Dim prmRouting(3) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 6

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of approver 1
                    Dim prmRouting(3) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 4

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of approver 2
                    Dim prmRouting(3) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 3

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of approver 3
                    Dim prmRouting(3) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 2

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Dim prmRouting(3) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = 1

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Dim prmRouting(3) As SqlParameter
                    prmRouting(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                    prmRouting(0).Value = pageIndex
                    prmRouting(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                    prmRouting(1).Value = pageSize
                    prmRouting(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                    prmRouting(2).Direction = ParameterDirection.Output
                    prmRouting(2).Value = totalCount
                    prmRouting(3) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmRouting(3).Value = Nothing

                    dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByRoutingStatusId", CommandType.StoredProcedure, prmRouting)
                    totalCount = prmRouting(2).Value
                End If
            End If

            Me.bsTransactionHeader.DataSource = dtTrxHeader
            Me.bsTransactionHeader.ResetBindings(True)
            dgvList.AutoGenerateColumns = False
            Me.dgvList.DataSource = Me.bsTransactionHeader

            If totalCount Mod pageSize = 0 Then
                If totalCount = 0 Then
                    pageCount = (totalCount / pageSize) + 1
                Else
                    pageCount = totalCount / pageSize
                End If
            Else
                pageCount = Math.Truncate(totalCount / pageSize) + 1
            End If

            txtPageNumber.Enabled = True
            txtTotalPageNumber.Enabled = True
            txtPageNumber.Text = pageIndex + 1
            txtTotalPageNumber.Text = "of " & CInt(pageCount) & " Page(s)"

            BindingNavigatorMoveFirstItem.Enabled = True
            BindingNavigatorMovePreviousItem.Enabled = True
            BindingNavigatorMoveNextItem.Enabled = True
            BindingNavigatorMoveLastItem.Enabled = True
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMachine()
        Try
            Dim prmMachine(0) As SqlParameter
            prmMachine(0) = New SqlParameter("@MachineId", SqlDbType.Int)
            prmMachine(0).Value = Nothing

            dtMachine = dbMethod.FillDataTable("RdMntMachineAccumulatedTime", CommandType.StoredProcedure, prmMachine)

            bsMachineAccumulatedTime.DataSource = dtMachine
            bsMachineAccumulatedTime.Filter = "IsActive = 1"
            bsMachineAccumulatedTime.Sort = "MachineStatusId DESC, MachineName ASC"
            bsMachineAccumulatedTime.ResetBindings(True)

            dgvMachine.AutoGenerateColumns = False
            dgvMachine.DataSource = bsMachineAccumulatedTime
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadJig()
        Try
            Dim prmJig(0) As SqlParameter
            prmJig(0) = New SqlParameter("@JigId", SqlDbType.Int)
            prmJig(0).Value = Nothing

            dtJig = dbMethod.FillDataTable("RdMntJigAccumulatedTime", CommandType.StoredProcedure, prmJig)

            bsJigAccumulatedTime.DataSource = dtJig
            bsJigAccumulatedTime.Filter = "IsActive = 1"
            bsJigAccumulatedTime.Sort = "JigStatusId DESC, JigName ASC"
            bsJigAccumulatedTime.ResetBindings(True)

            dgvJig.AutoGenerateColumns = False
            dgvJig.DataSource = bsJigAccumulatedTime
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
            LoadTransaction()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        Me.bsTransactionHeader.Position = dgvList.SelectedCells(0).RowIndex
    End Sub

    Public Sub Reload()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
        pageIndex = 0
        LoadTransaction()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub TransactionStatus()
        dicStatus.Add(" On-going Activity", 1)
        'dicStatus.Add(" Done", 2)
        dicStatus.Add(" Returned for revision", 2)
        dicStatus.Add(" For approval of Superior 1", 3)
        dicStatus.Add(" For approval of Superior 2", 4)
        dicStatus.Add(" For approval of Superior 3", 5)
        dicStatus.Add(" Completed", 6)
        dicStatus.Add(" All Records", 7)
        cmbStatus.DisplayMember = "Key"
        cmbStatus.ValueMember = "Value"
        cmbStatus.DataSource = New BindingSource(dicStatus, Nothing)
    End Sub

    Private Sub GetShift()
        dicShift.Add(" < All >", Nothing)
        dicShift.Add(" Day Shift", "D")
        dicShift.Add(" Night Shift", "N")
        cmbCommonCmb.DisplayMember = "Key"
        cmbCommonCmb.ValueMember = "Value"
        cmbCommonCmb.DataSource = New BindingSource(dicShift, Nothing)
    End Sub

End Class