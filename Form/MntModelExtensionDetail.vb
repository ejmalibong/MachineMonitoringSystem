Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class MntModelExtensionDetail
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)

    Private dtExtension As New DataTable

    Private extensionId As Integer = 0
    Private orgExtensioName As String = String.Empty

    Public Sub New(Optional _extensionId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        extensionId = _extensionId
    End Sub

    Public Property pKey As Integer = 0

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If extensionId > 0 Then
                Dim prmCnt(0) As SqlParameter
                prmCnt(0) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                prmCnt(0).Value = extensionId

                Dim count As Integer = dbMethod.ExecuteScalar("CntMntModelExtension", CommandType.StoredProcedure, prmCnt)
                Dim msg As String = String.Empty

                If count > 0 Then
                    If count = 1 Then
                        msg = String.Format("{0} model is using this extension. Mark this as inactive?", count)
                    Else
                        msg = String.Format("{0} models are using this extension. Mark this as inactive?", count)
                    End If

                    If MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim prmUpd(0) As SqlParameter
                        prmUpd(0) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                        prmUpd(0).Value = extensionId

                        dbMethod.ExecuteNonQuery("UPDATE dbo.MntModelExtension SET IsActive = 0 WHERE ExtensionId = @ExtensionId", CommandType.Text, prmUpd)
                    Else
                        Exit Sub
                    End If
                Else
                    msg = "Are you sure you want to delete this extension?"
                    If MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim prmDel(0) As SqlParameter
                        prmDel(0) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                        prmDel(0).Value = extensionId

                        dbMethod.ExecuteNonQuery("DelMntModelExtension", CommandType.StoredProcedure, prmDel)
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
            If String.IsNullOrEmpty(txtExtensionName.Text.Trim) Then
                MessageBox.Show("Extension name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtExtensionName.Focus()
                Return
            End If

            If extensionId = 0 Then 'new record
                If IsExtensionExist(txtExtensionName.Text.Trim) = True Then
                    MessageBox.Show("Extension name is already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtExtensionName.Focus()
                    Return
                End If

                Dim prmModel(2) As SqlParameter
                prmModel(0) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                prmModel(0).Direction = ParameterDirection.Output
                prmModel(1) = New SqlParameter("@ExtensionName", SqlDbType.NVarChar)
                prmModel(1).Value = txtExtensionName.Text.Trim
                prmModel(2) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmModel(2).Value = IIf(rdActive.Checked = True, True, False)

                dbMethod.ExecuteNonQuery("InsMntModelExtension", CommandType.StoredProcedure, prmModel)
                pKey = prmModel(0).Value
            Else 'old record
                If Not txtExtensionName.Text.Trim.Equals(orgExtensioName) Then
                    If IsExtensionExist(txtExtensionName.Text.Trim) = True Then
                        MessageBox.Show("Extension name is already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtExtensionName.Focus()
                        Return
                    End If
                End If

                Dim prmModel(2) As SqlParameter
                prmModel(0) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                prmModel(0).Value = extensionId
                prmModel(1) = New SqlParameter("@ExtensionName", SqlDbType.NVarChar)
                prmModel(1).Value = txtExtensionName.Text.Trim
                prmModel(2) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmModel(2).Value = IIf(rdActive.Checked = True, True, False)

                dbMethod.ExecuteNonQuery("UpdMntModelExtension", CommandType.StoredProcedure, prmModel)
                pKey = extensionId
            End If

            Me.DialogResult = DialogResult.OK
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
        If extensionId = 0 Then
            Me.Text = "New Extension Entry"

            txtExtensionName.Clear()
            rdActive.Checked = True
        Else
            Me.Text = "Extension No. " & extensionId
            orgExtensioName = txtExtensionName.Text.Trim
        End If

        Me.ActiveControl = txtExtensionName
        txtExtensionName.Select(txtExtensionName.Text.Trim.Length, 0)
    End Sub

    Private Function IsExtensionExist(modelName As String) As Boolean
        Dim count As Integer = 0

        Try
            Dim prmCnt(0) As SqlParameter
            prmCnt(0) = New SqlParameter("@ExtensionName", SqlDbType.NVarChar)
            prmCnt(0).Value = modelName

            count = dbMethod.ExecuteScalar("SELECT COUNT(ExtensionId) FROM dbo.MntModelExtension WHERE TRIM(ExtensionName) = @ExtensionName", CommandType.Text, prmCnt)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub pnlStatus_Enter(sender As Object, e As EventArgs) Handles pnlRemarks.Enter
        lblRemarks.ForeColor = Color.White
        lblRemarks.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub pnlStatus_Leave(sender As Object, e As EventArgs) Handles pnlRemarks.Leave
        lblRemarks.ForeColor = Color.Black
        lblRemarks.BackColor = SystemColors.Control
    End Sub

    Private Sub txtExtensionName_Enter(sender As Object, e As EventArgs) Handles txtExtensionName.Enter
        lblExtensionName.ForeColor = Color.White
        lblExtensionName.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtExtensionName_Leave(sender As Object, e As EventArgs) Handles txtExtensionName.Leave
        lblExtensionName.ForeColor = Color.Black
        lblExtensionName.BackColor = SystemColors.Control
    End Sub

End Class