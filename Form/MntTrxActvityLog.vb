Imports System.ComponentModel
Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class MntTrxActvityLog
    Private dbConnection As New Connection
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private userId As Integer = 0
    Private trxId As Integer = 0

    Public Sub New(_userId As Integer, Optional _trxId As Integer = 0)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        trxId = _trxId

        Dim prmUser(0) As SqlParameter
        prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
        prmUser(0).Value = 2
        dbMethod.FillCmb("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbTechnician, prmUser)
    End Sub

    Private Sub MntTrxActvityLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTrxDate.Text = String.Format("{0:MMMM dd, yyyy hh:mm tt}", dbMethod.GetServerDate)
        cmbTechnician.SelectedValue = userId
        GetCurrentShift()
        dtpFrom.Value = CDate(dbMethod.GetServerDate).Date
        dtpTo.Value = CDate(dbMethod.GetServerDate).Date
    End Sub

    Private Sub MntTrxActvityLog_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub cmbTechnician_Validating(sender As Object, e As CancelEventArgs) Handles cmbTechnician.Validating
        e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbTechnician.Text)
        If e.Cancel Then Beep()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim datetimeStarted As New DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, dtpFrom.Value.Hour, dtpFrom.Value.Minute, 0)
            Dim datetimeEnded As New DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, dtpTo.Value.Hour, dtpTo.Value.Minute, 0)

            GetElapsedTime()

            If dtpFrom.Value.Equals(dtpTo.Value) Or txtElapsedTime.Text.Trim = "0" Then
                MessageBox.Show("Datetime started should not be equals to datetime ended.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpTo.Focus()
                Return
            End If

            If dtpFrom.Value > DateTime.Now Then
                MessageBox.Show("Start time is later than current time. Advanced encoding is not allowed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Else
                If dtpFrom.Value > dtpTo.Value Then
                    MessageBox.Show("Start time is later than end time. Advanced encoding is not allowed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        GetElapsedTime()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        GetElapsedTime()
    End Sub

    'set the default value of shift based on the current hour
    Private Sub GetCurrentShift()
        Try
            If DateTime.Now.Hour >= 7 And DateTime.Now.Hour <= 16 Then
                rdDay.Checked = True
            Else
                rdNight.Checked = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'get the elapsed time between the two datetime
    Private Sub GetElapsedTime()
        Try
            Dim datetimeStarted As New DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, dtpFrom.Value.Hour, dtpFrom.Value.Minute, 0)
            Dim datetimeEnded As New DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, dtpTo.Value.Hour, dtpTo.Value.Minute, 0)
            Dim lastDatetime As DateTime = Nothing
            Dim span As TimeSpan = Nothing
            Dim minutes As Integer = 0
            Dim hours As Integer = 0
            Dim days As Integer = 0

            span = (datetimeStarted - datetimeEnded).Duration()
            txtElapsedTime.Text = span.TotalMinutes.ToString.Trim
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbUser_Enter(sender As Object, e As EventArgs) Handles cmbTechnician.Enter
        lblTechnician.ForeColor = Color.White
        lblTechnician.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbUser_Leave(sender As Object, e As EventArgs) Handles cmbTechnician.Leave
        lblTechnician.ForeColor = Color.Black
        lblTechnician.BackColor = SystemColors.Control
    End Sub

    Private Sub grpShift_Enter(sender As Object, e As EventArgs) Handles grpShift.Enter
        lblShift.ForeColor = Color.White
        lblShift.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub grpShift_Leave(sender As Object, e As EventArgs) Handles grpShift.Leave
        lblShift.ForeColor = Color.Black
        lblShift.BackColor = SystemColors.Control
    End Sub

    Private Sub dtpFrom_Enter(sender As Object, e As EventArgs) Handles dtpFrom.Enter
        lblFrom.ForeColor = Color.White
        lblFrom.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub dtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        lblFrom.ForeColor = Color.Black
        lblFrom.BackColor = SystemColors.Control
    End Sub

    Private Sub dtpTo_Enter(sender As Object, e As EventArgs) Handles dtpTo.Enter
        lblTo.ForeColor = Color.White
        lblTo.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub dtpTo_Leave(sender As Object, e As EventArgs) Handles dtpTo.Leave
        lblTo.ForeColor = Color.Black
        lblTo.BackColor = SystemColors.Control
    End Sub

End Class