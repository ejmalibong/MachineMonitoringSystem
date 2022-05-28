Imports System.Data.SqlClient
Imports BlackCoffeeLibrary
Imports Microsoft.Reporting.WinForms

Public Class MntActivityReport
    Private connection As New Connection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private shift As Char = String.Empty

    Private Sub frmMntActivityReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim prmTechnician(0) As SqlParameter
            prmTechnician(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmTechnician(0).Value = 2
            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbUserName, "< All > ", prmTechnician)
            AddHandler cmbUserName.Validated, AddressOf cmbUserName_Validated

            rdBoth.Checked = True

            Dim prmArea(0) As SqlParameter
            prmArea(0) = New SqlParameter("@AreaId", SqlDbType.Int)
            prmArea(0).Value = Nothing
            dbMethod.FillCmbWithCaption("RdMntArea", CommandType.StoredProcedure, "AreaId", "AreaName", cmbArea, "< All > ", prmArea)
            AddHandler cmbArea.Validated, AddressOf cmbArea_Validated

            Dim prmTrxStatus(0) As SqlParameter
            prmTrxStatus(0) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
            prmTrxStatus(0).Value = Nothing
            dbMethod.FillCmbWithCaption("RdGenTransactionStatus", CommandType.StoredProcedure, "TrxStatusId", "TrxStatusName", cmbTransactionStatus, "< All > ", prmTrxStatus)

            Dim prMachineStatus(0) As SqlParameter
            prMachineStatus(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
            prMachineStatus(0).Value = Nothing
            dbMethod.FillCmbWithCaption("RdMntMachineStatus", CommandType.StoredProcedure, "MachineStatusId", "MachineStatusName", cmbMachineDowntimeStatus, "< All > ", prMachineStatus)

            Dim prmMachine(0) As SqlParameter
            prmMachine(0) = New SqlParameter("@MachineId", SqlDbType.Int)
            prmMachine(0).Value = Nothing
            dbMethod.FillCmbWithCaption("RdMntMachine", CommandType.StoredProcedure, "MachineId", "MachineName", cmbMachine, "< All > ", prmMachine)
            AddHandler cmbMachine.Validated, AddressOf cmbMachine_Validated

            Dim prmJigStatus(0) As SqlParameter
            prmJigStatus(0) = New SqlParameter("@JigStatusId", SqlDbType.Int)
            prmJigStatus(0).Value = Nothing
            dbMethod.FillCmbWithCaption("RdMntJigStatus", CommandType.StoredProcedure, "JigStatusId", "JigStatusName", cmbJigDowntimeStatus, "< All > ", prmJigStatus)

            Dim prmJig(0) As SqlParameter
            prmJig(0) = New SqlParameter("@JigId", SqlDbType.Int)
            prmJig(0).Value = Nothing
            dbMethod.FillCmbWithCaption("RdMntJig", CommandType.StoredProcedure, "JigId", "JigCompleteName", cmbJig, "< All > ", prmJig)
            AddHandler cmbJig.Validated, AddressOf cmbJig_Validated
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMntActivityReport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnGenerate.PerformClick()
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            If dtpStartDate.Value.Date > dtpEndDate.Value.Date Then
                MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dtpStartDate.Value.Date = dtpEndDate.Value.Date Then
                GenerateReport()
            Else
                GenerateReport()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        dtpStartDate.Value = CDate(dbMethod.GetServerDate).Date
        dtpEndDate.Value = CDate(dbMethod.GetServerDate).Date
        cmbUserName.SelectedValue = 0
        rdBoth.Checked = True
        cmbArea.SelectedValue = 0
        cmbTransactionStatus.SelectedValue = 0
        cmbMachineDowntimeStatus.SelectedValue = 0
        cmbMachine.SelectedValue = 0
        cmbJigDowntimeStatus.SelectedValue = 0
        cmbJig.SelectedValue = 0
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub GenerateReport()
        Dim prmRpt(9) As SqlParameter
        prmRpt(0) = New SqlParameter("@StartDate", SqlDbType.Date)
        prmRpt(0).Value = dbMain.FormatDate(dtpStartDate.Value.Date, True)
        prmRpt(1) = New SqlParameter("@EndDate", SqlDbType.Date)
        prmRpt(1).Value = dbMain.FormatDate(dtpEndDate.Value.Date, False)
        prmRpt(2) = New SqlParameter("@ShiftId", SqlDbType.Char)
        prmRpt(2).Value = GetShift()
        prmRpt(3) = New SqlParameter("@AreaId", SqlDbType.Int)
        prmRpt(3).Value = GetArea()
        prmRpt(4) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
        prmRpt(4).Value = GetTransactionStatus()
        prmRpt(5) = New SqlParameter("@DowntimeMachineStatusId", SqlDbType.Int)
        prmRpt(5).Value = GetDowntimeMachineStatus()
        prmRpt(6) = New SqlParameter("@MachineId", SqlDbType.Int)
        prmRpt(6).Value = GetMachine()
        prmRpt(7) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
        prmRpt(7).Value = GetDowntimeJigStatus()
        prmRpt(8) = New SqlParameter("@JigId", SqlDbType.Int)
        prmRpt(8).Value = GetJig()
        prmRpt(9) = New SqlParameter("@UserId", SqlDbType.Int)
        prmRpt(9).Value = GetUserName()

        Dim dtReport As New DataTable
        dtReport = dbMethod.FillDataTable("RptMntActivityReport", CommandType.StoredProcedure, prmRpt)

        If Not rdBoth.Checked = True Then
            If rdDay.Checked = True Then
                shift = "D"
            Else
                shift = "N"
            End If
        Else
            shift = "B"
        End If

        If dtReport.Rows.Count > 0 Then
            rptViewer.LocalReport.ReportPath = "ReportFile\MntActivityReport.rdlc"
            rptViewer.LocalReport.DataSources.Clear()
            rptViewer.LocalReport.DataSources.Add(New ReportDataSource("RptMntActivityReport", dtReport))

            Dim rptParam As New ReportParameterCollection
            rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("StartDate", dtpStartDate.Value.Date.ToString("MMMM dd, yyyy")))
            rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("EndDate", dtpEndDate.Value.Date.ToString("MMMM dd, yyyy")))
            rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("Shift", shift))
            rptViewer.LocalReport.SetParameters(rptParam)

            rptViewer.SetDisplayMode(DisplayMode.PrintLayout)
            rptViewer.ZoomMode = ZoomMode.PageWidth
            rptViewer.LocalReport.DisplayName = "Activity Report"
            rptViewer.RefreshReport()
        Else
            MessageBox.Show("No records found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function GetShift() As Object
        If Not rdBoth.Checked = True Then
            If rdDay.Checked = True Then
                Return "D"
            Else
                Return "N"
            End If
        Else
            Return Nothing
        End If
    End Function

    Private Function GetArea() As Object
        If Not cmbArea.SelectedValue = 0 Then
            Return cmbArea.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Function GetTransactionStatus() As Object
        If Not cmbTransactionStatus.SelectedValue = 0 Then
            Return cmbTransactionStatus.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Function GetDowntimeMachineStatus() As Object
        If Not cmbMachineDowntimeStatus.SelectedValue = 0 Then
            Return cmbMachineDowntimeStatus.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Function GetMachine() As Object
        If Not cmbMachine.SelectedValue = 0 Then
            Return cmbMachine.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Function GetDowntimeJigStatus() As Object
        If Not cmbJigDowntimeStatus.SelectedValue = 0 Then
            Return cmbJigDowntimeStatus.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Function GetJig() As Object
        If Not cmbJig.SelectedValue = 0 Then
            Return cmbJig.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Function GetUserName() As Object
        If Not cmbUserName.SelectedValue = 0 Then
            Return cmbUserName.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Sub cmbUserName_Validated(sender As Object, e As EventArgs)
        Try
            If cmbUserName.SelectedValue = 0 Then cmbUserName.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbArea_Validated(sender As Object, e As EventArgs)
        Try
            If cmbArea.SelectedValue = 0 Then cmbArea.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachine_Validated(sender As Object, e As EventArgs)
        Try
            If cmbMachine.SelectedValue = 0 Then cmbMachine.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbJig_Validated(sender As Object, e As EventArgs)
        Try
            If cmbJig.SelectedValue = 0 Then cmbJig.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class