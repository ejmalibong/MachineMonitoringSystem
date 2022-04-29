Imports System.Data.SqlClient
Imports BlackCoffeeLibrary
Imports MachineMonitoringSystem.dsMonitoring
Imports MachineMonitoringSystem.dsMonitoringTableAdapters

Public Class frmMntTrxConsole
    Private connection As New clsConnection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbMain As New Main

    Private dsMonitoring As New dsMonitoring
    Private adpTransactionHeader As New MntTransactionHeaderTableAdapter
    Private adpMachine As New MntMachineTableAdapter
    Private adpJig As New MntJigTableAdapter

    Private dtTransactionHeader As New MntTransactionHeaderDataTable
    Private dtMachine As New MntMachineDataTable
    Private dtJig As New MntJigDataTable

    Private bsTransactionHeader As New BindingSource
    Private bsMachineAccumulatedTime As New BindingSource
    Private bsJigAccumulatedTime As New BindingSource

    Private pageSize As Integer
    Private pageIndex As Integer
    Private totalCount As Integer
    Private pageCount As Integer
    Private indexScroll As Integer = 0
    Private indexPosition As Integer = 0

    Private dictSearch As New Dictionary(Of String, Integer)
    Private dictStatus As New Dictionary(Of String, Integer)

    Private isFilterByTransactionDate As Boolean = False
    Private isFilterByMachineId As Boolean = False
    Private isFilterByDowntimeMachineStatusId As Boolean = False
    Private isFilterByJigId As Boolean = False
    Private isFilterByDowntimeJigStatusId As Boolean = False
    Private isFilterByAreaId As Boolean = False
    Private isFilterByDatetimeStarted As Boolean = False
    Private isFilterByDatetimeEnded As Boolean = False
    Private isFilterByProblem As Boolean = False
    Private isFilterByRootCause As Boolean = False
    Private isFilterByActionTaken As Boolean = False
    Private isFilterByUserId As Boolean = False
    Private isFilterByShiftId As Boolean = False
    Private isFilterByJoNumber As Boolean = False
    Private isFilterByJoRequestor As Boolean = False

    Private userId As Integer = 0
    Private workgroupId As Integer = 0
    Private isAdmin As Boolean = False

    Private machineStatusId As Integer = 1
    Private jigStatusId As Integer = 1
    Private lastMachineTransactionDate As New DateTime
    Private lastJigTransactionDate As New DateTime
    Private tmrMachineSpan As TimeSpan = Nothing
    Private tmrMachineMinutes As Integer = 0
    Private tmrMachineHours As Integer = 0
    Private tmrMachineDays As Integer = 0
    Private tmrJigSpan As TimeSpan = Nothing
    Private tmrJigMinutes As Integer = 0
    Private tmrJigHours As Integer = 0
    Private tmrJigDays As Integer = 0

    Private superiorWorkgroupId As New List(Of Integer) From {29, 30, 35, 2} 'sv, asv, sr mngr

    Public Sub New(_userId As Integer, _workgroupId As Integer, _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        workgroupId = _workgroupId
        isAdmin = _isAdmin
    End Sub

    Private Sub frmMntTrxConsole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchCriteria()
        TransactionStatus()

        cmbStatus.SelectedValue = 1

        pageIndex = 0
        pageSize = 50
        BindPageTransaction()

        BindJig()
        BindMachine()

        dbMain.EnableDoubleBuffered(dgvMachine)
        dbMain.EnableDoubleBuffered(dgvList)
        Me.ActiveControl = dgvList

        Me.dgvList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvMachine.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvJig.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub frmMntTrxConsole_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frmMntTrxConsole_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvMachine.Dispose()
        dgvList.Dispose()
        tmrElapsedTime.Stop()
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

    Private Sub dgvJig_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvJig.CellFormatting
        Try
            'for loop was used to access hidden column
            For i As Integer = 0 To dgvJig.Rows.Count - 1
                jigStatusId = dgvJig.Rows(i).Cells("ColJigStatusId").Value

                If jigStatusId = 1 Then
                    dgvJig.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen 'operational
                ElseIf jigStatusId = 2 Then
                    dgvJig.Rows(i).DefaultCellStyle.BackColor = Color.Orange 'preventive maintenance
                ElseIf jigStatusId = 3 Then
                    dgvJig.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral 'modification
                ElseIf jigStatusId = 4 Then
                    dgvJig.Rows(i).DefaultCellStyle.BackColor = Color.DarkSalmon 'modification
                Else
                    dgvJig.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral 'repair
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

    Private Sub dgvJig_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvJig.DataBindingComplete
        Try
            tmrElapsedTime.Start()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub dgvMachine_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMachine.SelectionChanged
        dgvMachine.ClearSelection()
    End Sub

    Private Sub dgvJig_SelectionChanged(sender As Object, e As EventArgs) Handles dgvJig.SelectionChanged
        dgvJig.ClearSelection()
    End Sub

    Private Sub dgvTransactionHeader_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            pageIndex = 0
            pageSize = 50
            BindPageTransaction()

            BindJig()
            BindMachine()
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
            Using frmDetail As New frmMntTrxDetailMch(userId, workgroupId, isAdmin)
                frmDetail.ShowDialog(Me)
                If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                    RefreshList()
                    BindJig()
                    BindMachine()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub JigRelatedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JigRelatedToolStripMenuItem.Click
        Try
            Using frmDetail As New frmMntTrxDetailJig(userId, workgroupId, isAdmin)
                frmDetail.ShowDialog(Me)
                If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                    RefreshList()
                    BindJig()
                    BindMachine()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OthersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OthersToolStripMenuItem.Click
        Try
            Using frmDetail As New frmMntTrxDetailOth(userId, workgroupId, isAdmin)
                frmDetail.ShowDialog(Me)
                If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                    RefreshList()
                    BindJig()
                    BindMachine()
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
                    Using frmDetail As New frmMntTrxDetailMch(userId, workgroupId, isAdmin, trxId)
                        frmDetail.ShowDialog(Me)
                        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                            RefreshList()
                            BindJig()
                            BindMachine()
                        End If
                    End Using

                ElseIf Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("JigId") Is DBNull.Value Then
                    Using frmDetail As New frmMntTrxDetailJig(userId, workgroupId, isAdmin, trxId)
                        frmDetail.ShowDialog(Me)
                        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                            RefreshList()
                            BindJig()
                            BindMachine()
                        End If
                    End Using
                Else
                    Using frmDetail As New frmMntTrxDetailOth(userId, workgroupId, isAdmin, trxId)
                        frmDetail.ShowDialog(Me)
                        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                            RefreshList()
                            BindJig()
                            BindMachine()
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
            If isAdmin Or superiorWorkgroupId.Contains(workgroupId) Then
                Dim trxId As Integer = CType(Me.bsTransactionHeader.Current, DataRowView).Item("TrxId")
                Dim trxStatusId As Integer = CType(Me.bsTransactionHeader.Current, DataRowView).Item("TrxStatusId")
                Dim question = String.Format("Are you sure you want to delete this record?")

                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    If trxStatusId = 2 Then
                        If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId") Is DBNull.Value Then
                            Dim prmMachineStatus(2) As SqlParameter
                            prmMachineStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                            prmMachineStatus(0).Value = CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId")
                            prmMachineStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                            prmMachineStatus(1).Value = 1
                            prmMachineStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                            prmMachineStatus(2).Value = 1

                            dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMachineStatus)
                        End If

                        If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("JigId") Is DBNull.Value Then
                            Dim prmJigStatus(1) As SqlParameter
                            prmJigStatus(0) = New SqlParameter("@JigId", SqlDbType.Int)
                            prmJigStatus(0).Value = CType(Me.bsTransactionHeader.Current, DataRowView).Item("JigId")
                            prmJigStatus(1) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                            prmJigStatus(1).Value = 1

                            dbMethod.ExecuteNonQuery("UpdMntJigByJigStatusId", CommandType.StoredProcedure, prmJigStatus)
                        End If
                    End If

                    Me.bsTransactionHeader.RemoveCurrent()
                    Me.adpTransactionHeader.Update(Me.dsMonitoring.MntTransactionHeader)
                    Me.dsMonitoring.AcceptChanges()
                End If
            Else
                MessageBox.Show("You do not have permission to delete record.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbStatus_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedValueChanged
        pageIndex = 0
        pageSize = 50
        BindPageTransaction()
    End Sub

    Private Sub dgvTransactionHeader_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvList.DataError
        e.Cancel = False
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        BindPageTransaction()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If

        BindPageTransaction()
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If

        BindPageTransaction()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        BindPageTransaction()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
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

    Private Sub BindPageTransaction()
        Try
            totalCount = 0

            If isFilterByTransactionDate = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdTrxDate(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdTrxDate(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdTrxDate(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdTrxDate(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdTrxDate(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdTrxDate(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdTrxDate(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                End If

            ElseIf isFilterByMachineId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdMachineId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdMachineId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdMachineId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdMachineId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdMachineId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdMachineId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdMachineId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                End If

            ElseIf isFilterByDowntimeMachineStatusId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeMachineStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                End If

            ElseIf isFilterByJigId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJigId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJigId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJigId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJigId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJigId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJigId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJigId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                End If

            ElseIf isFilterByDowntimeJigStatusId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDowntimeJigStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                End If

            ElseIf isFilterByAreaId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdAreaId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdAreaId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdAreaId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdAreaId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdAreaId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdAreaId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdAreaId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                End If

            ElseIf isFilterByDatetimeStarted = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeStarted(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeStarted(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeStarted(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeStarted(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeStarted(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeStarted(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeStarted(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                End If

            ElseIf isFilterByDatetimeEnded = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeEnded(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeEnded(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeEnded(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeEnded(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeEnded(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeEnded(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdDatetimeEnded(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                End If

            ElseIf isFilterByProblem = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdProblem(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdProblem(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdProblem(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdProblem(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdProblem(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdProblem(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdProblem(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, txtCommonTxt.Text.Trim)
                End If

            ElseIf isFilterByRootCause = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdRootCause(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdRootCause(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdRootCause(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdRootCause(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdRootCause(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdRootCause(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdRootCause(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, txtCommonTxt.Text.Trim)
                End If

            ElseIf isFilterByActionTaken = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdActionTaken(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdActionTaken(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdActionTaken(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdActionTaken(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdActionTaken(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdActionTaken(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdActionTaken(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, txtCommonTxt.Text.Trim)
                End If

            ElseIf isFilterByUserId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdUserId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdUserId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdUserId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdUserId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdUserId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdUserId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdUserId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, IIf(cmbCommonCmb.SelectedValue = 0, Nothing, cmbCommonCmb.SelectedValue))
                End If

            ElseIf isFilterByShiftId = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdShiftId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, IIf(cmbCommonCmb.SelectedValue = "0", Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdShiftId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, IIf(cmbCommonCmb.SelectedValue = "0", Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdShiftId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, IIf(cmbCommonCmb.SelectedValue = "0", Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdShiftId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, IIf(cmbCommonCmb.SelectedValue = "0", Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdShiftId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, IIf(cmbCommonCmb.SelectedValue = "0", Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdShiftId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, IIf(cmbCommonCmb.SelectedValue = "0", Nothing, cmbCommonCmb.SelectedValue))
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdShiftId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, IIf(cmbCommonCmb.SelectedValue = "0", Nothing, cmbCommonCmb.SelectedValue))
                End If

            ElseIf isFilterByJoNumber = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoNumber(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoNumber(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoNumber(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoNumber(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoNumber(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoNumber(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoNumber(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, txtCommonTxt.Text.Trim)
                End If

            ElseIf isFilterByJoRequestor = True Then
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoRequestor(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoRequestor(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoRequestor(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoRequestor(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoRequestor(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoRequestor(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1, txtCommonTxt.Text.Trim)
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusIdJoRequestor(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing, txtCommonTxt.Text.Trim)
                End If
            Else
                If cmbStatus.SelectedValue = 1 Then 'on-going activity
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 5)
                ElseIf cmbStatus.SelectedValue = 2 Then 'done activity but not yet completed to approvers
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 99)
                ElseIf cmbStatus.SelectedValue = 3 Then 'for approval of sr mngr
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 2)
                ElseIf cmbStatus.SelectedValue = 4 Then 'for approval of sv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 3)
                ElseIf cmbStatus.SelectedValue = 5 Then 'for approval of asv
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 4)
                ElseIf cmbStatus.SelectedValue = 6 Then 'completed
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, 1)
                ElseIf cmbStatus.SelectedValue = 7 Then 'all records
                    Me.adpTransactionHeader.FillMntTransactionHeaderByRoutingStatusId(Me.dsMonitoring.MntTransactionHeader, pageIndex, pageSize, totalCount, Nothing)
                End If
            End If

            Me.bsTransactionHeader.DataSource = Me.dsMonitoring
            Me.bsTransactionHeader.DataMember = dtTransactionHeader.TableName
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

    Private Sub BindMachine()
        Try
            Me.adpMachine.FillMntMachineAccumulatedTime(Me.dsMonitoring.MntMachine, Nothing)

            Me.bsMachineAccumulatedTime.DataSource = Me.dsMonitoring
            Me.bsMachineAccumulatedTime.DataMember = dtMachine.TableName
            Me.bsMachineAccumulatedTime.Filter = "IsActive = 1"
            Me.bsMachineAccumulatedTime.Sort = "MachineStatusId DESC, MachineName ASC"
            Me.bsMachineAccumulatedTime.ResetBindings(True)
            dgvMachine.AutoGenerateColumns = False
            dgvMachine.DataSource = Me.bsMachineAccumulatedTime
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindJig()
        Try
            Me.adpJig.FillMntJigAccumulatedTime(Me.dsMonitoring.MntJig, Nothing)

            Me.bsJigAccumulatedTime.DataSource = Me.dsMonitoring
            Me.bsJigAccumulatedTime.DataMember = dtJig.TableName
            Me.bsJigAccumulatedTime.Filter = "IsActive = 1"
            Me.bsJigAccumulatedTime.Sort = "JigStatusId DESC, JigName ASC"
            Me.bsJigAccumulatedTime.ResetBindings(True)
            dgvJig.AutoGenerateColumns = False
            dgvJig.DataSource = Me.bsJigAccumulatedTime
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
            BindPageTransaction()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub RefreshList()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
        pageIndex = 0
        BindPageTransaction()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))
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

    Private Sub SearchCriteria()
        dictSearch.Add(" Transaction Date", 1)
        dictSearch.Add(" Machine Name", 2)
        dictSearch.Add(" Machine Status", 3)
        dictSearch.Add(" Jig Name", 4)
        dictSearch.Add(" Jig Status", 5)
        dictSearch.Add(" Area", 6)
        dictSearch.Add(" DatetimeStarted", 7)
        dictSearch.Add(" DatetimeEnded", 8)
        dictSearch.Add(" Problem", 9)
        dictSearch.Add(" Root Cause", 10)
        dictSearch.Add(" Action Taken", 11)
        dictSearch.Add(" Username", 12)
        dictSearch.Add(" Shift", 13)
        dictSearch.Add(" JoNumber", 14)
        dictSearch.Add(" JoRequestor", 15)
        cmbSearchCriteria.DisplayMember = "Key"
        cmbSearchCriteria.ValueMember = "Value"
        cmbSearchCriteria.DataSource = New BindingSource(dictSearch, Nothing)
    End Sub

    Private Sub TransactionStatus()
        dictStatus.Add(" On-going Activity", 1)
        dictStatus.Add(" Done", 2)
        dictStatus.Add(" For approval of Superior 1", 3)
        dictStatus.Add(" For approval of Superior 2", 4)
        dictStatus.Add(" For approval of Superior 3", 5)
        dictStatus.Add(" Completed", 6)
        dictStatus.Add(" All Records", 7)
        cmbStatus.DisplayMember = "Key"
        cmbStatus.ValueMember = "Value"
        cmbStatus.DataSource = New BindingSource(dictStatus, Nothing)
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
                            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbCommonCmb, "< All >")

                        Case 13
                            dbMethod.FillCmbWithCaption("RdGenShift", CommandType.StoredProcedure, "ShiftId", "ShiftName", cmbCommonCmb, "< All >")
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
            BindPageTransaction()
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
            BindPageTransaction()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class