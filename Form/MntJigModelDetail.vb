Imports System.Data.SqlClient
Imports System.Globalization
Imports BlackCoffeeLibrary
Public Class MntJigModelDetail
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)

    Private dtModel As New DataTable

    Private modelId As Integer = 0
    Private orgModelName As String = String.Empty

    Public Sub New(Optional _modelId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        modelId = _modelId

        LoadExtension()
    End Sub

    Public Property pKey As Integer = 0
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If modelId > 0 Then
                Dim prmCnt(0) As SqlParameter
                prmCnt(0) = New SqlParameter("@ModelId", SqlDbType.Int)
                prmCnt(0).Value = modelId

                Dim count As Integer = dbMethod.ExecuteScalar("CntMntJigByModel", CommandType.StoredProcedure, prmCnt)
                Dim msg As String = String.Empty

                If count > 0 Then
                    If count = 1 Then
                        msg = String.Format("{0} jig is using this model. Mark this as inactive?", count)
                    Else
                        msg = String.Format("{0} jigs are using this model. Mark this as inactive?", count)
                    End If

                    If MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim prmUpd(0) As SqlParameter
                        prmUpd(0) = New SqlParameter("@ModelId", SqlDbType.Int)
                        prmUpd(0).Value = modelId

                        dbMethod.ExecuteNonQuery("UPDATE dbo.MntJigModel SET IsActive = 0 WHERE ModelId = @ModelId", CommandType.Text, prmUpd)
                    Else
                        Exit Sub
                    End If
                Else
                    msg = "Are you sure you want to delete this model?"
                    If MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim prmDel(0) As SqlParameter
                        prmDel(0) = New SqlParameter("@ModelId", SqlDbType.Int)
                        prmDel(0).Value = modelId

                        dbMethod.ExecuteNonQuery("DelMntJigModel", CommandType.StoredProcedure, prmDel)
                    Else
                        Exit Sub
                    End If
                End If

                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(txtModelName.Text.Trim) Then
                MessageBox.Show("Model name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtModelName.Focus()
                Return
            End If

            If modelId = 0 Then 'new record
                If IsModelExist(txtModelName.Text.Trim) = True Then
                    MessageBox.Show("Model name is already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtModelName.Focus()
                    Return
                End If

                Dim prmModel(3) As SqlParameter
                prmModel(0) = New SqlParameter("@ModelId", SqlDbType.Int)
                prmModel(0).Direction = ParameterDirection.Output
                prmModel(1) = New SqlParameter("@ModelName", SqlDbType.NVarChar)
                prmModel(1).Value = txtModelName.Text.Trim
                prmModel(2) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                prmModel(2).Value = IIf(cmbExtension.SelectedValue = 0, Nothing, cmbExtension.SelectedValue)
                prmModel(3) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmModel(3).Value = IIf(rdActive.Checked = True, True, False)

                dbMethod.ExecuteNonQuery("InsMntJigModel", CommandType.StoredProcedure, prmModel)
                pKey = prmModel(0).Value

            Else 'old record
                If Not txtModelName.Text.Trim.Equals(orgModelName) Then
                    If IsModelExist(txtModelName.Text.Trim) = True Then
                        MessageBox.Show("Model name is already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtModelName.Focus()
                        Return
                    End If
                End If

                Dim prmModel(3) As SqlParameter
                prmModel(0) = New SqlParameter("@ModelId", SqlDbType.Int)
                prmModel(0).Value = modelId
                prmModel(1) = New SqlParameter("@ModelName", SqlDbType.NVarChar)
                prmModel(1).Value = txtModelName.Text.Trim
                prmModel(2) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                prmModel(2).Value = IIf(cmbExtension.SelectedValue = 0, Nothing, cmbExtension.SelectedValue)
                prmModel(3) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmModel(3).Value = IIf(rdActive.Checked = True, True, False)

                dbMethod.ExecuteNonQuery("UpdMntJigModel", CommandType.StoredProcedure, prmModel)
                pKey = modelId
            End If

            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbExtension_Enter(sender As Object, e As EventArgs) Handles cmbExtension.Enter
        lblExtension.ForeColor = Color.White
        lblExtension.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbExtension_Leave(sender As Object, e As EventArgs) Handles cmbExtension.Leave
        lblExtension.ForeColor = Color.Black
        lblExtension.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbExtension_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbExtension.SelectedValue = 0 Then
                cmbExtension.SelectedValue = 0
            End If

            If cmbExtension.SelectedValue Is Nothing Then
                cmbExtension.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbExtension_Validated(sender As Object, e As EventArgs)
        Try
            If cmbExtension.SelectedValue = 0 Then
                cmbExtension.SelectedValue = 0
            End If

            If cmbExtension.SelectedValue Is Nothing Then
                cmbExtension.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F8) Then
            e.Handled = True
            btnDelete.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If modelId = 0 Then
            Me.Text = "New Model Entry"

            txtModelName.Clear()
            cmbExtension.SelectedValue = 0
            rdActive.Checked = True
        Else
            Me.Text = "Model No. " & modelId
            orgModelName = txtModelName.Text.Trim
        End If

        Me.ActiveControl = txtModelName
        txtModelName.Select(txtModelName.Text.Trim.Length, 0)
    End Sub

    Private Function IsModelExist(modelName As String) As Boolean
        Dim count As Integer = 0

        Try
            Dim prmCnt(0) As SqlParameter
            prmCnt(0) = New SqlParameter("@ModelName", SqlDbType.NVarChar)
            prmCnt(0).Value = modelName

            count = dbMethod.ExecuteScalar("SELECT COUNT(ModelId) FROM dbo.MntJigModel WHERE TRIM(ModelName) = @ModelName", CommandType.Text, prmCnt)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub LoadExtension()
        Try
            cmbExtension.DisplayMember = "ExtensioName"
            cmbExtension.ValueMember = "ExtensionId"
            dbMethod.FillCmbWithCaption("RdMntModelExtension", CommandType.StoredProcedure, "ExtensionId", "ExtensionName", cmbExtension, "< None >")

            AddHandler cmbExtension.Validated, AddressOf cmbExtension_Validated
            AddHandler cmbExtension.SelectedValueChanged, AddressOf cmbExtension_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub pnlStatus_Enter(sender As Object, e As EventArgs) Handles pnlRemarks.Enter
        lblRemarks.ForeColor = Color.White
        lblRemarks.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub pnlStatus_Leave(sender As Object, e As EventArgs) Handles pnlRemarks.Leave
        lblRemarks.ForeColor = Color.Black
        lblRemarks.BackColor = SystemColors.Control
    End Sub

    Private Sub txtMachineName_Enter(sender As Object, e As EventArgs) Handles txtModelName.Enter
        lblModelName.ForeColor = Color.White
        lblModelName.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtMachineName_Leave(sender As Object, e As EventArgs) Handles txtModelName.Leave
        lblModelName.ForeColor = Color.Black
        lblModelName.BackColor = SystemColors.Control
    End Sub
End Class