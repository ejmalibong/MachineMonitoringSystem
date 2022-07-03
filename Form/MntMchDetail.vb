Imports System.Data.SqlClient
Imports System.Globalization
Imports BlackCoffeeLibrary
Public Class MntMchDetail
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)

    Private dtMachine As New DataTable

    Private machineId As Integer = 0
    Private orgMachineName As String = String.Empty

    Public Sub New(Optional _machineId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        machineId = _machineId

        LoadArea()
        LoadPartGroup()
        LoadFrequency()
    End Sub

    Public Property pKey As Integer = 0
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If machineId > 0 Then
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(txtMachineName.Text.Trim) Then
                MessageBox.Show("Machine name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMachineName.Focus()
                Return
            End If

            If cmbArea.SelectedValue = 0 Then
                MessageBox.Show("Please select an area.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbArea.Focus()
                Return
            End If

            If cmbPartGroup.SelectedValue = 0 Then
                MessageBox.Show("Please select a part group.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbPartGroup.Focus()
                Return
            End If

            If cmbFrequency.SelectedValue = CStr(0) Then
                MessageBox.Show("Please select a frequency.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbFrequency.Focus()
                Return
            End If

            If machineId = 0 Then 'new record
                If IsMachineExist(txtMachineName.Text.Trim) = True Then
                    MessageBox.Show("Machine is already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtMachineName.Focus()
                    Return
                End If

                Dim prmMch(7) As SqlParameter
                prmMch(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmMch(0).Direction = ParameterDirection.Output
                prmMch(1) = New SqlParameter("@MachineName", SqlDbType.NVarChar)
                prmMch(1).Value = txtMachineName.Text.Trim
                prmMch(2) = New SqlParameter("@AreaId", SqlDbType.Int)
                prmMch(2).Value = cmbArea.SelectedValue
                prmMch(3) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                prmMch(3).Value = 1
                prmMch(4) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                prmMch(4).Value = 1
                prmMch(5) = New SqlParameter("@GroupId", SqlDbType.Int)
                prmMch(5).Value = IIf(cmbPartGroup.SelectedValue = 0, Nothing, cmbPartGroup.SelectedValue)
                prmMch(6) = New SqlParameter("@PmFrequencyId", SqlDbType.Char)
                prmMch(6).Value = cmbFrequency.SelectedValue
                prmMch(7) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmMch(7).Value = IIf(rdActive.Checked = True, True, False)

                dbMethod.ExecuteNonQuery("InsMntMachine", CommandType.StoredProcedure, prmMch)
                pKey = prmMch(0).Value

            Else 'old record
                If Not txtMachineName.Text.Trim.Equals(orgMachineName) Then
                    If IsMachineExist(txtMachineName.Text.Trim) = True Then
                        MessageBox.Show("Machine is already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtMachineName.Focus()
                        Return
                    End If
                End If

                Dim prmMch(5) As SqlParameter
                prmMch(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmMch(0).Value = machineId
                prmMch(1) = New SqlParameter("@MachineName", SqlDbType.NVarChar)
                prmMch(1).Value = txtMachineName.Text.Trim
                prmMch(2) = New SqlParameter("@AreaId", SqlDbType.Int)
                prmMch(2).Value = cmbArea.SelectedValue
                prmMch(3) = New SqlParameter("@GroupId", SqlDbType.Int)
                prmMch(3).Value = IIf(cmbPartGroup.SelectedValue = 0, Nothing, cmbPartGroup.SelectedValue)
                prmMch(4) = New SqlParameter("@PmFrequencyId", SqlDbType.Char)
                prmMch(4).Value = cmbFrequency.SelectedValue
                prmMch(5) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmMch(5).Value = IIf(rdActive.Checked = True, True, False)

                dbMethod.ExecuteNonQuery("UpdMntMachine", CommandType.StoredProcedure, prmMch)
                pKey = machineId
            End If

            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbArea_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbArea.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbFrequency_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbFrequency.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPartGroup_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbPartGroup.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function GetMachineStatus(machineStatusId As Integer) As String
        Dim status As String = String.Empty

        Try
            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
            prm(0).Value = machineStatusId

            Dim rdr As IDataReader = dbMethod.ExecuteReader("RdMntMachineStatus", CommandType.StoredProcedure, prm)

            While rdr.Read
                status = rdr("MachineStatusName").ToString
            End While
            rdr.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return status
    End Function

    Private Function GetMachineSubStatus(machineSubStatusId As Integer) As String
        Dim status As String = String.Empty

        Try
            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
            prm(0).Value = machineSubStatusId

            Dim rdr As IDataReader = dbMethod.ExecuteReader("RdMntMachineSubStatus", CommandType.StoredProcedure, prm)

            While rdr.Read
                status = rdr("MachineSubStatusName").ToString
            End While
            rdr.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return status
    End Function

    Private Function IsMachineExist(machineName As String) As Boolean
        Dim count As Integer = 0

        Try
            Dim prmCnt(0) As SqlParameter
            prmCnt(0) = New SqlParameter("@MachineName", SqlDbType.NVarChar)
            prmCnt(0).Value = machineName

            count = dbMethod.ExecuteScalar("SELECT COUNT(MachineId) FROM dbo.MntMachine WHERE MachineName = @MachineName", CommandType.Text, prmCnt)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub LoadArea()
        Try
            cmbArea.DisplayMember = "AreaName"
            cmbArea.ValueMember = "AreaId"
            dbMethod.FillCmbWithCaption("RdMntArea", CommandType.StoredProcedure, "AreaId", "AreaName", cmbArea, "< Select Area >")

            AddHandler cmbArea.Validating, AddressOf cmbArea_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadFrequency()
        Try
            cmbFrequency.DisplayMember = "FrequencyName"
            cmbFrequency.ValueMember = "FrequencyId"
            dbMethod.FillCmbWithCaption("RdGenFrequency", CommandType.StoredProcedure, "FrequencyId", "FrequencyName", cmbFrequency, "< Select Frequency >")

            AddHandler cmbFrequency.Validating, AddressOf cmbFrequency_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadPartGroup()
        Try
            cmbPartGroup.DisplayMember = "GroupName"
            cmbPartGroup.ValueMember = "GroupId"
            dbMethod.FillCmbWithCaption("RdMntMachinePartGroup", CommandType.StoredProcedure, "GroupId", "GroupName", cmbPartGroup, "< N/A >")

            AddHandler cmbFrequency.Validating, AddressOf cmbPartGroup_Validating
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
        If machineId = 0 Then
            Me.Text = "New Machine Entry"

            txtMachineName.Clear()
            cmbArea.SelectedValue = 0
            cmbPartGroup.SelectedValue = 0
            cmbFrequency.SelectedValue = 0
            rdActive.Checked = True

            txtMachineStatus.Text = GetMachineStatus(1)
            txtMachineSubStatus.Text = GetMachineSubStatus(1)
        Else
            Me.Text = "Machine No. " & machineId

            Dim prmMch(0) As SqlParameter
            prmMch(0) = New SqlParameter("@MachineId", SqlDbType.Int)
            prmMch(0).Value = machineId
            dtMachine = dbMethod.FillDataTable("RdMntMachine", CommandType.StoredProcedure, prmMch)

            For Each row As DataRow In dtMachine.Rows
                txtMachineName.Text = row("MachineName").ToString.Trim
                orgMachineName = row("MachineName").ToString.Trim
                cmbArea.SelectedValue = row("AreaId")

                If row("GroupId") Is DBNull.Value Then
                    cmbPartGroup.SelectedValue = 0
                Else
                    cmbPartGroup.SelectedValue = row("GroupId")
                End If

                cmbFrequency.SelectedValue = row("PmFrequencyId")
                txtMachineStatus.Text = GetMachineStatus(row("MachineStatusId"))
                txtMachineSubStatus.Text = GetMachineSubStatus(row("MachineSubStatusId"))

                If row("IsActive") = True Then
                    rdActive.Checked = True
                Else
                    rdInactive.Checked = True
                End If
            Next
        End If

        Me.ActiveControl = txtMachineName
        txtMachineName.Select(txtMachineName.Text.Trim.Length, 0)
    End Sub
    Private Sub ResetForm()
        Try
            txtMachineName.Clear()
            cmbArea.SelectedValue = 0
            cmbPartGroup.SelectedValue = 0
            cmbFrequency.SelectedValue = 0
            rdActive.Checked = True

            Me.ActiveControl = txtMachineName
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMachineName_Enter(sender As Object, e As EventArgs) Handles txtMachineName.Enter
        lblMachineName.ForeColor = Color.White
        lblMachineName.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtMachineName_Leave(sender As Object, e As EventArgs) Handles txtMachineName.Leave
        lblMachineName.ForeColor = Color.Black
        lblMachineName.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbArea_Enter(sender As Object, e As EventArgs) Handles cmbArea.Enter
        lblArea.ForeColor = Color.White
        lblArea.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbArea_Leave(sender As Object, e As EventArgs) Handles cmbArea.Leave
        lblArea.ForeColor = Color.Black
        lblArea.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbPartGroup_Enter(sender As Object, e As EventArgs) Handles cmbPartGroup.Enter
        lblPartGroup.ForeColor = Color.White
        lblPartGroup.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbPartGroup_Leave(sender As Object, e As EventArgs) Handles cmbPartGroup.Leave
        lblPartGroup.ForeColor = Color.Black
        lblPartGroup.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbFrequency_Enter(sender As Object, e As EventArgs) Handles cmbFrequency.Enter
        lblFrequency.ForeColor = Color.White
        lblFrequency.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbFrequency_Leave(sender As Object, e As EventArgs) Handles cmbFrequency.Leave
        lblFrequency.ForeColor = Color.Black
        lblFrequency.BackColor = SystemColors.Control
    End Sub

    Private Sub pnlStatus_Enter(sender As Object, e As EventArgs) Handles pnlStatus.Enter
        lblStatus.ForeColor = Color.White
        lblStatus.BackColor = Color.DarkSlateGray
    End Sub


    Private Sub pnlStatus_Leave(sender As Object, e As EventArgs) Handles pnlStatus.Leave
        lblStatus.ForeColor = Color.Black
        lblStatus.BackColor = SystemColors.Control
    End Sub
End Class