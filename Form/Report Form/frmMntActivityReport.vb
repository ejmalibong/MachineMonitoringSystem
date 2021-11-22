Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports BlackCoffeeLibrary
Imports MachineMonitoringSystem.dsReport
Imports MachineMonitoringSystem.dsReportTableAdapters

Public Class frmMntActivityReport
    Private connection As New clsConnection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbMain As New Main

    Private dsReport As New dsReport
    Private adpActivityReport As New RptMntActivityReportTableAdapter
    Private dtActivityReport As New RptMntActivityReportDataTable
    Private bsActivityReport As New BindingSource

    Private shift As Char = String.Empty

    Private Sub frmMntActivityReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim _prmTechnician(0) As SqlParameter
            _prmTechnician(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            _prmTechnician(0).Value = 2

            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbUserName, "< All > ", _prmTechnician)

            rdBoth.Checked = True

            Dim _prmArea(0) As SqlParameter
            _prmArea(0) = New SqlParameter("@AreaId", SqlDbType.Int)
            _prmArea(0).Value = Nothing

            dbMethod.FillCmbWithCaption("RdMntArea", CommandType.StoredProcedure, "AreaId", "AreaName", cmbArea, "< All > ", _prmArea)

            Dim _prmTransactionStatus(0) As SqlParameter
            _prmTransactionStatus(0) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
            _prmTransactionStatus(0).Value = Nothing

            dbMethod.FillCmbWithCaption("RdGenTransactionStatus", CommandType.StoredProcedure, "TrxStatusId", "TrxStatusName", cmbTransactionStatus, "< All > ", _prmTransactionStatus)

            Dim _prMachineStatus(0) As SqlParameter
            _prMachineStatus(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
            _prMachineStatus(0).Value = Nothing

            dbMethod.FillCmbWithCaption("RdMntMachineStatus", CommandType.StoredProcedure, "MachineStatusId", "MachineStatusName", cmbMachineDowntimeStatus, "< All > ", _prMachineStatus)

            Dim _prmMachine(0) As SqlParameter
            _prmMachine(0) = New SqlParameter("@MachineId", SqlDbType.Int)
            _prmMachine(0).Value = Nothing

            dbMethod.FillCmbWithCaption("RdMntMachine", CommandType.StoredProcedure, "MachineId", "MachineName", cmbMachine, "< All > ", _prmMachine)

            Dim _prmJigStatus(0) As SqlParameter
            _prmJigStatus(0) = New SqlParameter("@JigStatusId", SqlDbType.Int)
            _prmJigStatus(0).Value = Nothing

            dbMethod.FillCmbWithCaption("RdMntJigStatus", CommandType.StoredProcedure, "JigStatusId", "JigStatusName", cmbJigDowntimeStatus, "< All > ", _prmJigStatus)

            Dim _prmJig(0) As SqlParameter
            _prmJig(0) = New SqlParameter("@JigId", SqlDbType.Int)
            _prmJig(0).Value = Nothing

            dbMethod.FillCmbWithCaption("RdMntJig", CommandType.StoredProcedure, "JigId", "JigName", cmbJig, "< All > ", _prmJig)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub frmMntActivityReport_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
    '    dbMain.FormTrap(Me)
    'End Sub

    Private Sub frmMntActivityReport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        ElseIf e.KeyCode.Equals(Keys.F10) Then
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
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
        Me.adpActivityReport.Fill(Me.dsReport.RptMntActivityReport, dbMain.FormatDate(dtpStartDate.Value.Date, True), dbMain.FormatDate(dtpEndDate.Value.Date, False), _
                                  GetShift, GetArea, GetTransactionStatus, GetDowntimeMachineStatus, GetMachine, GetDowntimeJigStatus, GetJig, GetUserName)

        Me.bsActivityReport.DataSource = Me.dsReport
        Me.bsActivityReport.DataMember = dtActivityReport.TableName
        Me.bsActivityReport.ResetBindings(True)

        If Not rdBoth.Checked = True Then
            If rdDay.Checked = True Then
                shift = "D"
            Else
                shift = "N"
            End If
        Else
            shift = "B"
        End If

        If Me.bsActivityReport.Count > 0 Then
            rptViewer.LocalReport.ReportPath = "ReportFile\MntActivityReport.rdlc"
            rptViewer.LocalReport.DataSources.Clear()
            rptViewer.LocalReport.DataSources.Add(New ReportDataSource(dtActivityReport.TableName, Me.bsActivityReport))

            Dim _rptParam As New ReportParameterCollection
            _rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("StartDate", dtpStartDate.Value.Date.ToString("MMMM dd, yyyy")))
            _rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("EndDate", dtpEndDate.Value.Date.ToString("MMMM dd, yyyy")))
            _rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("Shift", shift))
            rptViewer.LocalReport.SetParameters(_rptParam)

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

    Private Sub cmbUserName_Validated(sender As Object, e As EventArgs) Handles cmbUserName.Validated
        Try
            If cmbUserName.Text.Trim.Length = 0 Then
                cmbUserName.SelectedValue = 0
            End If

            If cmbUserName.SelectedValue = 0 Then
                cmbUserName.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbArea_Validated(sender As Object, e As EventArgs) Handles cmbArea.Validated
        Try
            If cmbArea.Text.Trim.Length = 0 Then
                cmbArea.SelectedValue = 0
            End If

            If cmbArea.SelectedValue = 0 Then
                cmbArea.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachine_Validated(sender As Object, e As EventArgs) Handles cmbMachine.Validated
        Try
            If cmbMachine.Text.Trim.Length = 0 Then
                cmbMachine.SelectedValue = 0
            End If

            If cmbMachine.SelectedValue = 0 Then
                cmbMachine.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbJig_Validated(sender As Object, e As EventArgs) Handles cmbJig.Validated
        Try
            If cmbJig.Text.Trim.Length = 0 Then
                cmbJig.SelectedValue = 0
            End If

            If cmbJig.SelectedValue = 0 Then
                cmbJig.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class