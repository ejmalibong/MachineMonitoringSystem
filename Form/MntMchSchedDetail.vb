Imports System.Data.SqlClient
Imports System.Globalization
Imports BlackCoffeeLibrary

Public Class MntMchSchedDetail
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dicWeekNumber As New Dictionary(Of String, Integer)
    Private scheduleId As Integer = 0
    Private userId As Integer = 0

    Private dtSchedule As New DataTable

    Private frequencyId As String = String.Empty

    Public Sub New(_userId As Integer, Optional _scheduleId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        scheduleId = _scheduleId

        LoadMonth()
        LoadMachine()
    End Sub

    Public Property pKey As Integer = 0

    Public Shared Function GetWeekOfMonth(dt As DateTime) As Integer
        Dim cultureInfo As CultureInfo = New CultureInfo("en-US")
        Dim calendar As Calendar = cultureInfo.Calendar
        Dim calWeekRule As CalendarWeekRule = 2 'firstfourdayweek rule
        Dim firstDayOfWeek As DayOfWeek = 0 'sunday

        Return calendar.GetWeekOfYear(dt, calWeekRule, firstDayOfWeek)
    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If scheduleId > 0 Then
                If rdDone.Checked = True Then
                    MessageBox.Show("Unable to delete record that have already been completed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                Else
                    Dim question = String.Format("Are you sure you want to delete this record?")
                    If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim prmDel(0) As SqlParameter
                        prmDel(0) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                        prmDel(0).Value = scheduleId

                        dbMethod.ExecuteNonQuery("DelMntMachineSchedule", CommandType.StoredProcedure, prmDel)

                        Me.DialogResult = DialogResult.OK
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtYearId.MaskCompleted Then
                If scheduleId = 0 AndAlso txtYearId.Text < Year(dbMethod.GetServerDate) Then
                    MessageBox.Show("Creating schedule for previous years is not allowed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtYearId.Focus()
                    Return
                End If
            Else
                MessageBox.Show("Please input a valid year.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtYearId.Focus()
                Return
            End If

            If cmbMonth.SelectedValue = 0 Then
                MessageBox.Show("Please select a month.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbMonth.Focus()
                Return
            End If

            If cmbWeekNo.SelectedValue = 0 Then
                MessageBox.Show("Please select a week no.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbWeekNo.Focus()
                Return
            End If

            If cmbMachineName.SelectedValue = 0 Then
                MessageBox.Show("Please select a machine.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbMachineName.Focus()
                Return
            End If

            If scheduleId = 0 Then 'new record
                If IsSchedExists(cmbMachineName.SelectedValue, frequencyId, cmbMonth.SelectedValue, CInt(txtYearId.Text)) = True Then
                    MessageBox.Show("Schedule already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                    Exit Sub
                End If

                Dim prmSchd(13) As SqlParameter
                prmSchd(0) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                prmSchd(0).Direction = ParameterDirection.Output
                prmSchd(1) = New SqlParameter("@YearId", SqlDbType.Int)
                prmSchd(1).Value = txtYearId.Text
                prmSchd(2) = New SqlParameter("@MonthId", SqlDbType.Int)
                prmSchd(2).Value = cmbMonth.SelectedValue
                prmSchd(3) = New SqlParameter("@WeekId", SqlDbType.Int)
                prmSchd(3).Value = cmbWeekNo.SelectedValue
                prmSchd(4) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                prmSchd(4).Value = userId
                prmSchd(5) = New SqlParameter("@TrxId", SqlDbType.Int)
                prmSchd(5).Value = Nothing
                prmSchd(6) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmSchd(6).Value = cmbMachineName.SelectedValue
                prmSchd(7) = New SqlParameter("@ActivityBy", SqlDbType.Int)
                prmSchd(7).Value = Nothing
                prmSchd(8) = New SqlParameter("@ActivityDate", SqlDbType.Date)
                prmSchd(8).Value = Nothing
                prmSchd(9) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                prmSchd(9).Value = Nothing
                prmSchd(10) = New SqlParameter("@ModifiedDate", SqlDbType.Date)
                prmSchd(10).Value = Nothing
                prmSchd(11) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                prmSchd(11).Value = Nothing
                prmSchd(12) = New SqlParameter("@IsChecklistCompleted", SqlDbType.Bit)
                prmSchd(12).Value = False
                prmSchd(13) = New SqlParameter("@IsDone", SqlDbType.Bit)
                prmSchd(13).Value = False

                dbMethod.ExecuteNonQuery("InsMntMachineSchedule", CommandType.StoredProcedure, prmSchd)
                pKey = prmSchd(0).Value

                'run parent form's sub-procedure from child from
                'https://stackoverflow.com/a/26469623/10744672
                'might not work if multiple forms with the same name are open
                For Each frm As Form In Application.OpenForms
                    If frm.Name = "MntMchSched" Then
                        Dim frmMchSchd As MntMchSched = DirectCast(frm, MntMchSched)
                        frmMchSchd.Reload()
                        frmMchSchd.bsSchedule.Position = frmMchSchd.bsSchedule.Find("ScheduleId", pKey)
                    End If
                Next

                ResetForm()
            Else 'old record
                If IsSchedExists(cmbMachineName.SelectedValue, frequencyId, cmbMonth.SelectedValue, CInt(txtYearId.Text), scheduleId) = True Then
                    MessageBox.Show("Schedule already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If rdDone.Checked = True Then
                    MessageBox.Show("Unable to modify record that have already been completed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim prmSchd(7) As SqlParameter
                prmSchd(0) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                prmSchd(0).Value = scheduleId
                prmSchd(1) = New SqlParameter("@YearId", SqlDbType.Int)
                prmSchd(1).Value = txtYearId.Text
                prmSchd(2) = New SqlParameter("@MonthId", SqlDbType.Int)
                prmSchd(2).Value = cmbMonth.SelectedValue
                prmSchd(3) = New SqlParameter("@WeekId", SqlDbType.Int)
                prmSchd(3).Value = cmbWeekNo.SelectedValue
                prmSchd(4) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmSchd(4).Value = cmbMachineName.SelectedValue
                prmSchd(5) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                prmSchd(5).Value = userId
                prmSchd(6) = New SqlParameter("@ModifiedDate", SqlDbType.Date)
                prmSchd(6).Value = dbMethod.GetServerDate
                prmSchd(7) = New SqlParameter("@IsDone", SqlDbType.Bit)

                If rdDone.Checked = True Then
                    prmSchd(7).Value = True
                Else
                    prmSchd(7).Value = False
                End If

                dbMethod.ExecuteNonQuery("UpdMntMachineSchedule", CommandType.StoredProcedure, prmSchd)

                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachineName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbMachineName.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachineName_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbMachineName.SelectedValue = 0 Then
                txtPmFrequency.Text = String.Empty
            Else
                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                prm(0).Value = cmbMachineName.SelectedValue

                Dim rdr As IDataReader = dbMethod.ExecuteReader("RdMntMachine", CommandType.StoredProcedure, prm)

                While rdr.Read
                    frequencyId = rdr("PmFrequencyId").ToString
                    txtPmFrequency.Text = rdr("FrequencyName").ToString
                End While
                rdr.Close()

                btnSave.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbWeekNo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbWeekNo.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMonth_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbMonth.SelectedValue = 0 Then
                cmbWeekNo.Enabled = False
            Else
                cmbWeekNo.Enabled = True
                LoadWeekNumber()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMonth_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbMonth.Validating
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbMonth.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMachine()
        Try
            cmbMachineName.DisplayMember = "MachineName"
            cmbMachineName.ValueMember = "MachineId"

            Dim prmMch(0) As SqlParameter
            prmMch(0) = New SqlParameter("@IsActive", SqlDbType.Bit)
            prmMch(0).Value = True

            dbMethod.FillCmbWithCaption("RdMntMachine", CommandType.StoredProcedure, "MachineId", "MachineName", cmbMachineName, "< Select Machine >", prmMch)

            AddHandler cmbMachineName.SelectedValueChanged, AddressOf cmbMachineName_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMonth()
        Try
            cmbMonth.DisplayMember = "MonthName"
            cmbMonth.ValueMember = "MonthId"
            dbMethod.FillCmbWithCaption("RdGenMonth", CommandType.StoredProcedure, "MonthId", "MonthName", cmbMonth, "< Select Month >")

            AddHandler cmbMonth.Validating, AddressOf cmbMonth_Validating
            AddHandler cmbMonth.SelectedValueChanged, AddressOf cmbMonth_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadWeekNumber()
        Try
            dicWeekNumber.Clear()

            'fill dropdown with number of weeks and dates in a month
            'https://stackoverflow.com/questions/17539159/how-to-fill-dropdown-number-of-weeks-and-dates-in-a-month
            Dim month As Integer = Convert.ToInt32(cmbMonth.SelectedValue)
            Dim beginningDate As DateTime = beginningDate.AddYears(CInt(txtYearId.Text) - 1).AddMonths(CInt(cmbMonth.SelectedValue) - 1)
            Dim beginningDay As Integer = beginningDate.Date.Day
            Dim numberOfDays As Integer = System.DateTime.DaysInMonth(txtYearId.Text, month)
            Dim weekNo As Integer = GetWeekOfMonth(beginningDate)
            Dim weekStartDate As Integer = 1
            Dim str As String = ""

            dicWeekNumber.Add("< Select Week No >", 0)

            While beginningDay <= numberOfDays
                Dim newWeekNo As Integer = GetWeekOfMonth(beginningDate)
                str = "Week " & weekNo.ToString() & "  [" & weekStartDate

                If weekNo = newWeekNo Then
                Else
                    If weekStartDate = beginningDate.AddDays(-1).Day Then
                        str += "]"
                    Else
                        str += "-" & beginningDate.AddDays(-1).Day & "]"
                    End If

                    dicWeekNumber.Add(str, weekNo)
                    weekNo = newWeekNo
                    weekStartDate = beginningDate.Date.Day
                End If

                beginningDate = beginningDate.AddDays(1)
                beginningDay += 1
            End While

            If Not str.Contains("]") Then
                str += "-" & numberOfDays & "]"
                dicWeekNumber.Add(str, weekNo)
            End If

            cmbWeekNo.DisplayMember = "Key"
            cmbWeekNo.ValueMember = "Value"
            cmbWeekNo.DataSource = New BindingSource(dicWeekNumber, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MntMchSchedDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F8) Then
            e.Handled = True
            btnDelete.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub MntMchSchedDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If scheduleId = 0 Then
            Me.Text = "New Schedule Entry"

            txtYearId.Text = Year(dbMethod.GetServerDate)
            cmbWeekNo.Enabled = False
            rdComplete.Checked = True
            rdPending.Checked = True

            Dim prmCreator(0) As SqlParameter
            prmCreator(0) = New SqlParameter("@UserId", SqlDbType.Int)
            prmCreator(0).Value = userId
            Dim rdrCreator As IDataReader = dbMethod.ExecuteReader("RdSecUser", CommandType.StoredProcedure, prmCreator)

            While rdrCreator.Read
                txtCreatedBy.Text = rdrCreator("UserName").ToString.Trim
            End While
            rdrCreator.Close()

            Me.ActiveControl = cmbMonth
            txtYearId.Select(txtYearId.Text.Trim.Length, 0)
        Else
            Me.Text = "Schedule No. " & scheduleId

            Dim prmsched(0) As SqlParameter
            prmsched(0) = New SqlParameter("@ScheduleId", SqlDbType.Int)
            prmsched(0).Value = scheduleId
            dtSchedule = dbMethod.FillDataTable("RdMntMachineSchedule", CommandType.StoredProcedure, prmsched)

            For Each row As DataRow In dtSchedule.Rows
                txtYearId.Text = row("YearId")
                cmbMonth.SelectedValue = row("MonthId")
                cmbWeekNo.SelectedValue = row("WeekId")
                cmbMachineName.SelectedValue = row("MachineId")
                txtCreatedBy.Text = row("CreatedByName").ToString.Trim
                txtActivityBy.Text = row("ActivityByName").ToString.Trim
                txtActivityDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("ActivityDate")).ToString.Trim
                txtModifiedBy.Text = row("ModifiedByName").ToString.Trim
                txtModifiedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("ModifiedDate")).ToString.Trim

                If row("IsChecklistCompleted") = True Then
                    rdComplete.Checked = True
                Else
                    rdIncomplete.Checked = True
                End If

                If row("IsDone") = True Then
                    rdDone.Checked = True
                Else
                    rdPending.Checked = True
                End If
            Next
        End If

        pnlChecklist.Enabled = False
        pnlRemarks.Enabled = False
    End Sub

    Private Sub ResetForm()
        Try
            txtYearId.Text = Year(dbMethod.GetServerDate)
            cmbMonth.SelectedValue = 0
            cmbWeekNo.SelectedValue = 0
            cmbMachineName.SelectedValue = 0
            txtPmFrequency.Text = String.Empty
            txtCreatedBy.Text = String.Empty
            txtActivityBy.Text = String.Empty
            txtActivityDate.Text = String.Empty
            txtModifiedBy.Text = String.Empty
            txtModifiedDate.Text = String.Empty
            rdComplete.Checked = True
            rdPending.Checked = True

            Me.ActiveControl = cmbMonth
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtYearId_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtYearId.Validating
        Try
            If txtYearId.MaskCompleted Then
                If scheduleId = 0 AndAlso txtYearId.Text.Trim < Year(dbMethod.GetServerDate) Then
                    MessageBox.Show("Creating schedule for previous years is not allowed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                End If
            Else
                MessageBox.Show("Please input a valid year.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsSchedExists(machineId As Integer, frequencyId As String, monthId As Integer, yearId As Integer,
                                   Optional scheduleId As Integer = 0) As Boolean
        Dim isDuplicate As Boolean
        Dim count As Integer = 0

        Try
            Select Case frequencyId
                Case "M"
                    If scheduleId = 0 Then
                        Dim prm(2) As SqlParameter
                        prm(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prm(0).Value = machineId
                        prm(1) = New SqlParameter("@YearId", SqlDbType.Int)
                        prm(1).Value = yearId
                        prm(2) = New SqlParameter("@MonthId", SqlDbType.Int)
                        prm(2).Value = monthId

                        count = dbMethod.ExecuteScalar("SELECT COUNT(ScheduleId) FROM dbo.MntMachineSchedule " &
                                                       "WHERE MachineId = @MachineId AND YearId = @YearId AND MonthId = @MonthId", CommandType.Text, prm)
                    Else
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prm(0).Value = machineId
                        prm(1) = New SqlParameter("@YearId", SqlDbType.Int)
                        prm(1).Value = yearId
                        prm(2) = New SqlParameter("@MonthId", SqlDbType.Int)
                        prm(2).Value = monthId
                        prm(3) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                        prm(3).Value = scheduleId

                        count = dbMethod.ExecuteScalar("SELECT COUNT(ScheduleId) FROM dbo.MntMachineSchedule " &
                                                       "WHERE MachineId = @MachineId AND YearId = @YearId AND MonthId = @MonthId AND ScheduleId <> @ScheduleId", CommandType.Text, prm)
                    End If

                    If count > 0 Then
                        isDuplicate = True
                    End If

                Case "Q"
                    Dim quarterId As Integer = (monthId - 1) \ 3 + 1

                    If scheduleId = 0 Then
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prm(0).Value = machineId
                        prm(1) = New SqlParameter("@YearId", SqlDbType.Int)
                        prm(1).Value = yearId
                        prm(2) = New SqlParameter("@StartMonth", SqlDbType.Int)
                        prm(3) = New SqlParameter("@EndMonth", SqlDbType.Int)

                        Select Case quarterId
                            Case 1
                                prm(2).Value = 1
                                prm(3).Value = 3

                            Case 2
                                prm(2).Value = 4
                                prm(3).Value = 6

                            Case 3
                                prm(2).Value = 7
                                prm(3).Value = 9

                            Case 4
                                prm(2).Value = 10
                                prm(3).Value = 12
                        End Select

                        count = dbMethod.ExecuteScalar("SELECT COUNT(ScheduleId) FROM dbo.MntMachineSchedule " &
                                                       "WHERE MachineId = @MachineId AND YearId = @YearId " &
                                                       "AND MonthId BETWEEN @StartMonth AND @EndMonth", CommandType.Text, prm)
                    Else
                        Dim prm(4) As SqlParameter
                        prm(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prm(0).Value = machineId
                        prm(1) = New SqlParameter("@YearId", SqlDbType.Int)
                        prm(1).Value = yearId
                        prm(2) = New SqlParameter("@StartMonth", SqlDbType.Int)
                        prm(3) = New SqlParameter("@EndMonth", SqlDbType.Int)
                        prm(4) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                        prm(4).Value = scheduleId

                        Select Case quarterId
                            Case 1
                                prm(2).Value = 1
                                prm(3).Value = 3

                            Case 2
                                prm(2).Value = 4
                                prm(3).Value = 6

                            Case 3
                                prm(2).Value = 7
                                prm(3).Value = 9

                            Case 4
                                prm(2).Value = 10
                                prm(3).Value = 12
                        End Select

                        count = dbMethod.ExecuteScalar("SELECT COUNT(ScheduleId) FROM dbo.MntMachineSchedule " &
                                                       "WHERE MachineId = @MachineId AND YearId = @YearId " &
                                                       "AND MonthId BETWEEN @StartMonth AND @EndMonth AND ScheduleId <> @ScheduleId", CommandType.Text, prm)
                    End If

                    If count > 0 Then
                        isDuplicate = True
                    End If

                Case "A"
                    If scheduleId = 0 Then
                        Dim prm(1) As SqlParameter
                        prm(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prm(0).Value = machineId
                        prm(1) = New SqlParameter("@YearId", SqlDbType.Int)
                        prm(1).Value = yearId

                        count = dbMethod.ExecuteScalar("SELECT COUNT(ScheduleId) FROM dbo.MntMachineSchedule " &
                                                       "WHERE MachineId = @MachineId AND YearId = @YearId", CommandType.Text, prm)
                    Else
                        Dim prm(2) As SqlParameter
                        prm(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prm(0).Value = machineId
                        prm(1) = New SqlParameter("@YearId", SqlDbType.Int)
                        prm(1).Value = yearId
                        prm(2) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                        prm(2).Value = scheduleId

                        count = dbMethod.ExecuteScalar("SELECT COUNT(ScheduleId) FROM dbo.MntMachineSchedule " &
                                                       "WHERE MachineId = @MachineId AND YearId = @YearId AND ScheduleId <> @ScheduleId", CommandType.Text, prm)
                    End If

                    If count > 0 Then
                        isDuplicate = True
                    End If

                Case Else
                    isDuplicate = False
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return isDuplicate
    End Function

    Private Sub txtYearId_Enter(sender As Object, e As EventArgs) Handles txtYearId.Enter
        lblYearId.ForeColor = Color.White
        lblYearId.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtYearId_Leave(sender As Object, e As EventArgs) Handles txtYearId.Leave
        lblYearId.ForeColor = Color.Black
        lblYearId.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbMonth_Enter(sender As Object, e As EventArgs) Handles cmbMonth.Enter
        lblMonth.ForeColor = Color.White
        lblMonth.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbMonth_Leave(sender As Object, e As EventArgs) Handles cmbMonth.Leave
        lblMonth.ForeColor = Color.Black
        lblMonth.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbWeekNo_Enter(sender As Object, e As EventArgs) Handles cmbWeekNo.Enter
        lblWeekNo.ForeColor = Color.White
        lblWeekNo.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbWeekNo_Leave(sender As Object, e As EventArgs) Handles cmbWeekNo.Leave
        lblWeekNo.ForeColor = Color.Black
        lblWeekNo.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbMachineName_Enter(sender As Object, e As EventArgs) Handles cmbMachineName.Enter
        lblMachineName.ForeColor = Color.White
        lblMachineName.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbMachineName_Leave(sender As Object, e As EventArgs) Handles cmbMachineName.Leave
        lblMachineName.ForeColor = Color.Black
        lblMachineName.BackColor = SystemColors.Control
    End Sub

    Private Sub pnlChecklist_Enter(sender As Object, e As EventArgs) Handles pnlChecklist.Enter
        lblChecklist.ForeColor = Color.White
        lblChecklist.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub pnlChecklist_Leave(sender As Object, e As EventArgs) Handles pnlChecklist.Leave
        lblChecklist.ForeColor = Color.Black
        lblChecklist.BackColor = SystemColors.Control
    End Sub

    Private Sub pnlStatus_Enter(sender As Object, e As EventArgs) Handles pnlRemarks.Enter
        lblRemarks.ForeColor = Color.White
        lblRemarks.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub pnlStatus_Leave(sender As Object, e As EventArgs) Handles pnlRemarks.Leave
        lblRemarks.ForeColor = Color.Black
        lblRemarks.BackColor = SystemColors.Control
    End Sub

End Class