Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class MntJigDetail
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)

    Private dtMachine As New DataTable

    Private jigId As Integer = 0
    Private orgMachineName As String = String.Empty

    Public Sub New(Optional _machineId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        jigId = _machineId

        LoadArea()
        LoadModel()
        LoadExtension()
        LoadType()
        LoadFrequency()
    End Sub

    Public Property pKey As Integer = 0

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If jigId > 0 Then
                Dim prmCnt(0) As SqlParameter
                prmCnt(0) = New SqlParameter("@JigId", SqlDbType.Int)
                prmCnt(0).Value = jigId

                Dim count As Integer = dbMethod.ExecuteScalar("CntMntJigByTrx", CommandType.StoredProcedure, prmCnt)

                If count > 0 Then
                    MessageBox.Show("This jig contains activities. Set to inactive instead.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim question = String.Format("Are you sure you want to delete this jig?")
                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Dim prmDel(0) As SqlParameter
                    prmDel(0) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmDel(0).Value = jigId

                    dbMethod.ExecuteNonQuery("DelMntJig", CommandType.StoredProcedure, prmDel)

                    Me.DialogResult = DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(txtJigName.Text.Trim) Then
                MessageBox.Show("Jig name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtJigName.Focus()
                Return
            End If

            If cmbArea.SelectedValue = 0 Then
                MessageBox.Show("Please select an area.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbArea.Focus()
                Return
            End If

            If cmbJigType.SelectedValue = 0 Then
                MessageBox.Show("Please select a jig type.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbJigType.Focus()
                Return
            End If

            If cmbFrequency.SelectedValue = CStr(0) Then
                MessageBox.Show("Please select a frequency.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbFrequency.Focus()
                Return
            End If

            If jigId = 0 Then 'new record
                If IsJigExist(txtJigName.Text.Trim) = True Then
                    MessageBox.Show("Jig is already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtJigName.Focus()
                    Return
                End If

                Dim prmJig(9) As SqlParameter
                prmJig(0) = New SqlParameter("@JigId", SqlDbType.Int)
                prmJig(0).Direction = ParameterDirection.Output
                prmJig(1) = New SqlParameter("@JigName", SqlDbType.NVarChar)
                prmJig(1).Value = txtJigName.Text.Trim
                prmJig(2) = New SqlParameter("@AreaId", SqlDbType.Int)
                prmJig(2).Value = cmbArea.SelectedValue
                prmJig(3) = New SqlParameter("@ModelId", SqlDbType.Int)
                prmJig(3).Value = IIf(cmbModel.SelectedValue = 0, Nothing, cmbModel.SelectedValue)
                prmJig(4) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                prmJig(4).Value = IIf(cmbExtension.SelectedValue = 0, Nothing, cmbExtension.SelectedValue)
                prmJig(5) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                prmJig(5).Value = 1
                prmJig(6) = New SqlParameter("@JigSubStatusId", SqlDbType.Int)
                prmJig(6).Value = 1
                prmJig(7) = New SqlParameter("@PmFrequencyId", SqlDbType.Char)
                prmJig(7).Value = cmbFrequency.SelectedValue
                prmJig(8) = New SqlParameter("@JigTypeId", SqlDbType.Int)
                prmJig(8).Value = cmbJigType.SelectedValue
                prmJig(9) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmJig(9).Value = IIf(rdActive.Checked = True, True, False)

                dbMethod.ExecuteNonQuery("InsMntJig", CommandType.StoredProcedure, prmJig)
                pKey = prmJig(0).Value
                'edit the insert sp - include extension
            Else 'old record
                If Not txtJigName.Text.Trim.Equals(orgMachineName) Then
                    If IsJigExist(txtJigName.Text.Trim) = True Then
                        MessageBox.Show("Machine is already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtJigName.Focus()
                        Return
                    End If
                End If

                Dim prmJig(9) As SqlParameter
                prmJig(0) = New SqlParameter("@JigId", SqlDbType.Int)
                prmJig(0).Value = jigId
                prmJig(1) = New SqlParameter("@JigName", SqlDbType.NVarChar)
                prmJig(1).Value = txtJigName.Text.Trim
                prmJig(2) = New SqlParameter("@AreaId", SqlDbType.Int)
                prmJig(2).Value = cmbArea.SelectedValue
                prmJig(3) = New SqlParameter("@ModelId", SqlDbType.Int)
                prmJig(3).Value = IIf(cmbModel.SelectedValue = 0, Nothing, cmbModel.SelectedValue)
                prmJig(4) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                prmJig(4).Value = IIf(cmbExtension.SelectedValue = 0, Nothing, cmbExtension.SelectedValue)
                prmJig(5) = New SqlParameter("@PmFrequencyId", SqlDbType.Char)
                prmJig(5).Value = cmbFrequency.SelectedValue
                prmJig(6) = New SqlParameter("@JigTypeId", SqlDbType.Int)
                prmJig(6).Value = cmbJigType.SelectedValue
                prmJig(7) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmJig(7).Value = IIf(rdActive.Checked = True, True, False)

                If rdActive.Checked = True Then
                    prmJig(8) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                    prmJig(8).Value = 1
                    prmJig(9) = New SqlParameter("@JigSubStatusId", SqlDbType.Int)
                    prmJig(9).Value = 1
                Else
                    prmJig(8) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                    prmJig(8).Value = 4
                    prmJig(9) = New SqlParameter("@JigSubStatusId", SqlDbType.Int)
                    prmJig(9).Value = 5
                End If

                dbMethod.ExecuteNonQuery("UpdMntJig", CommandType.StoredProcedure, prmJig)
                pKey = jigId
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

    Private Sub cmbModel_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbModel.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbExtension_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbExtension.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbJigType_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbJigType.Text)
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

    Private Function GetJigStatus(jigStatusIs As Integer) As String
        Dim status As String = String.Empty

        Try
            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@JigStatusId", SqlDbType.Int)
            prm(0).Value = jigStatusIs

            Dim rdr As IDataReader = dbMethod.ExecuteReader("RdMntJigStatus", CommandType.StoredProcedure, prm)

            While rdr.Read
                status = rdr("JigStatusName").ToString
            End While
            rdr.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return status
    End Function

    Private Function GetJigSubStatusId(jigSubStatusId As Integer) As String
        Dim status As String = String.Empty

        Try
            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@JigSubStatusId", SqlDbType.Int)
            prm(0).Value = jigSubStatusId

            Dim rdr As IDataReader = dbMethod.ExecuteReader("RdMntJigSubStatus", CommandType.StoredProcedure, prm)

            While rdr.Read
                status = rdr("JigSubStatusName").ToString
            End While
            rdr.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return status
    End Function

    Private Function IsJigExist(jigName As String) As Boolean
        Dim count As Integer = 0

        Try
            Dim prmCnt(0) As SqlParameter
            prmCnt(0) = New SqlParameter("@JigName", SqlDbType.NVarChar)
            prmCnt(0).Value = jigName

            count = dbMethod.ExecuteScalar("SELECT COUNT(JigId) FROM dbo.MntJig WHERE TRIM(JigName) = @JigName", CommandType.Text, prmCnt)
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

    Private Sub LoadModel()
        Try
            cmbModel.DisplayMember = "ModelName"
            cmbModel.ValueMember = "ModelId"
            dbMethod.FillCmbWithCaption("RdMntJigModel", CommandType.StoredProcedure, "ModelId", "ModelName", cmbModel, "< N/A >")

            AddHandler cmbModel.Validating, AddressOf cmbModel_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadExtension()
        Try
            cmbExtension.DisplayMember = "ExtensionName"
            cmbExtension.ValueMember = "ExtensionId"
            dbMethod.FillCmbWithCaption("RdMntModelExtension", CommandType.StoredProcedure, "ExtensionId", "ExtensionName", cmbExtension, "< N/A >")

            AddHandler cmbExtension.Validating, AddressOf cmbExtension_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadType()
        Try
            cmbJigType.DisplayMember = "JigTypeName"
            cmbJigType.ValueMember = "JigTypeId"
            dbMethod.FillCmbWithCaption("RdMntJigType", CommandType.StoredProcedure, "JigTypeId", "JigTypeName", cmbJigType, "< Select Type >")

            AddHandler cmbJigType.Validating, AddressOf cmbJigType_Validating
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
        If jigId = 0 Then
            Me.Text = "New Jig Entry"

            txtJigName.Clear()
            cmbArea.SelectedValue = 0
            cmbModel.SelectedValue = 0
            cmbJigType.SelectedValue = 0
            cmbFrequency.SelectedValue = 0
            rdActive.Checked = True

            txtMachineStatus.Text = GetJigStatus(1)
            txtMachineSubStatus.Text = GetJigSubStatusId(1)
        Else
            Me.Text = "Jig No. " & jigId

            Dim prmMch(0) As SqlParameter
            prmMch(0) = New SqlParameter("@JigId", SqlDbType.Int)
            prmMch(0).Value = jigId
            dtMachine = dbMethod.FillDataTable("RdMntJig", CommandType.StoredProcedure, prmMch)

            For Each row As DataRow In dtMachine.Rows
                txtJigName.Text = row("JigName").ToString.Trim
                orgMachineName = row("JigName").ToString.Trim
                cmbArea.SelectedValue = row("AreaId")

                If row("ModelId") Is DBNull.Value Then
                    cmbModel.SelectedValue = 0
                Else
                    cmbModel.SelectedValue = row("ModelId")
                End If

                If row("ExtensionId") Is DBNull.Value Then
                    cmbExtension.SelectedValue = 0
                Else
                    cmbExtension.SelectedValue = row("ExtensionId")
                End If

                cmbJigType.SelectedValue = row("JigTypeId")
                cmbFrequency.SelectedValue = row("PmFrequencyId")
                txtMachineStatus.Text = GetJigStatus(row("JigStatusId"))
                txtMachineSubStatus.Text = GetJigSubStatusId(row("JigSubStatusId"))

                If row("IsActive") = True Then
                    rdActive.Checked = True
                Else
                    rdInactive.Checked = True
                End If
            Next
        End If

        Me.ActiveControl = txtJigName
        txtJigName.Select(txtJigName.Text.Trim.Length, 0)
    End Sub

    Private Sub ResetForm()
        Try
            txtJigName.Clear()
            cmbArea.SelectedValue = 0
            cmbModel.SelectedValue = 0
            cmbJigType.SelectedValue = 0
            cmbFrequency.SelectedValue = 0
            rdActive.Checked = True

            Me.ActiveControl = txtJigName
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtJigName_Enter(sender As Object, e As EventArgs) Handles txtJigName.Enter
        lblJigName.ForeColor = Color.White
        lblJigName.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtJigName_Leave(sender As Object, e As EventArgs) Handles txtJigName.Leave
        lblJigName.ForeColor = Color.Black
        lblJigName.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbArea_Enter(sender As Object, e As EventArgs) Handles cmbArea.Enter
        lblArea.ForeColor = Color.White
        lblArea.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbArea_Leave(sender As Object, e As EventArgs) Handles cmbArea.Leave
        lblArea.ForeColor = Color.Black
        lblArea.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbModel_Enter(sender As Object, e As EventArgs) Handles cmbModel.Enter
        lblModel.ForeColor = Color.White
        lblModel.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbModel_Leave(sender As Object, e As EventArgs) Handles cmbModel.Leave
        lblModel.ForeColor = Color.Black
        lblModel.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbJigType_Enter(sender As Object, e As EventArgs) Handles cmbJigType.Enter
        lblJigType.ForeColor = Color.White
        lblJigType.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbJigType_Leave(sender As Object, e As EventArgs) Handles cmbJigType.Leave
        lblJigType.ForeColor = Color.Black
        lblJigType.BackColor = SystemColors.Control
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
        lblRemarks.ForeColor = Color.White
        lblRemarks.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub pnlStatus_Leave(sender As Object, e As EventArgs) Handles pnlStatus.Leave
        lblRemarks.ForeColor = Color.Black
        lblRemarks.BackColor = SystemColors.Control
    End Sub

End Class