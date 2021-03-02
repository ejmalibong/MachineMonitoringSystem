Imports MachineMonitoringSystem.dsReport
Imports MachineMonitoringSystem.dsReportTableAdapters
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmFacActivityReport
    Private connection As New clsConnection
    Private method As New clsMethod
    Private dbMethod As New clsSqlDbMethod
    Private table As DataTable

    Private myDataset As New dsReport
    Private adpActReport As New FacActivityReportTableAdapter
    Private dtActReport As New FacActivityReportDataTable
    Private bsActReport As New BindingSource

    Private query As String = String.Empty
    Private userName As String = String.Empty
    Private shift As Char

    Private Sub frmMntActivityReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim _paramsUser(1) As SqlParameter
            _paramsUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            _paramsUser(0).Value = 3
            _paramsUser(1) = New SqlParameter("@ExcludedWorkgroupId", SqlDbType.Int)
            _paramsUser(1).Value = 27

            Dim _paramsStatus(0) As SqlParameter
            _paramsStatus(0) = New SqlParameter("MachineStatusId", SqlDbType.Int)
            _paramsStatus(0).Value = 1

            method.FillCmbWithCaption("RedSecUserBySectionId", "UserId", "UserName", cmbTechnician, " < All Technician > ", _paramsUser)
            method.FillCmbWithCaption("RedGenTransactionStatus", "TrxStatusId", "TrxStatusName", cmbTrxStatus, " < All Status > ")
            method.FillCmbWithCaption("RedFacMachineStatus", "MachineStatusId", "MachineStatusName", cmbStatus, " < All Status > ", _paramsStatus)

            Me.adpActReport.Fill(Me.myDataset.FacActivityReport)
            Me.bsActReport.DataSource = Me.myDataset
            Me.bsActReport.DataMember = dtActReport.TableName

            rdBoth.Checked = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMntActivityReport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        ElseIf e.KeyCode.Equals(Keys.F10) Then
            btnGenerate.PerformClick()
        End If
    End Sub

    Private Sub frmMntActivityReport_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        method.FormTrap(Me)
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            If dtpStartDate.Value.Date > dtpEndDate.Value.Date Then
                MessageBox.Show("Invalid date range.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dtpStartDate.Value = dtpEndDate.Value Then
                GoTo ShowReport
            Else
ShowReport:
                If rdDay.Checked = True Then
                    shift = "D"
                ElseIf rdNight.Checked = True Then
                    shift = "N"
                Else
                    shift = " "
                End If

                query = "DatetimeStarted >= '" + method.FormatDate(dtpStartDate.Value.Date, True) + "' AND DatetimeStarted < '" + method.FormatDate(dtpEndDate.Value.Date, False) + "'"

                If Not rdBoth.Checked = True Then
                    query += " AND ShiftId = '" & shift & "'"
                End If

                If Not cmbTechnician.SelectedValue = 0 Then
                    query += " AND UserId = " & cmbTechnician.SelectedValue & ""
                    userName = cmbTechnician.Text
                Else
                    userName = " "
                End If

                If Not cmbStatus.SelectedValue = 0 Then
                    query += " AND DowntimeMachineStatusId = '" & cmbStatus.SelectedValue & "'"
                End If

                If Not cmbTrxStatus.SelectedValue = 0 Then
                    query += " AND TrxStatusId = '" & cmbTrxStatus.SelectedValue & "'"
                End If

                Me.bsActReport.Filter = String.Format(query)

                If Me.bsActReport.Count > 0 Then
                    rptViewer.LocalReport.ReportPath = "ReportFile\FacActivityReport.rdlc"
                    rptViewer.LocalReport.DataSources.Clear()
                    rptViewer.LocalReport.DataSources.Add(New ReportDataSource(dtActReport.TableName, Me.bsActReport))

                    Dim _rptParam As New ReportParameterCollection
                    _rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("UserName", userName))
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
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        rdBoth.Checked = True
        method.ClearForm(Me)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class