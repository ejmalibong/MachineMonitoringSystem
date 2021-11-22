Imports System.Data.SqlClient
Imports BlackCoffeeLibrary
Imports System.Deployment.Application

Public Class frmLogin
    Private connection As New clsConnection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbException As New SqlDbException
    Private dbMain As New Main

    Private userId As Integer = 0
    Private userName As String = String.Empty
    Private workgroupId As Integer = 0
    Private workgroupName As String = String.Empty
    Private sectionId As Integer = 0
    Private sectionName As String = String.Empty
    Private departmentId As Integer = 0
    Private departmentName As String = String.Empty
    Private isAdmin As Boolean = False

    Dim imgShow As Image = My.Resources.Password_Show
    Dim imgHide As Image = My.Resources.Password_Hide

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'sir alvin
        'txtEmployeeId.Text = "1705-025"

        'sir clark
        'txtEmployeeId.Text = "1709-006"

        ''sir mon
        'txtEmployeeId.Text = "1506-001"
        'txtPassword.Text = "bayani"

        ''sir emman
        'txtEmployeeId.Text = "1701-066"
        'txtPassword.Text = "sandoval"

        ''sir harry
        'txtEmployeeId.Text = "1807-002"
        'txtPassword.Text = "tanega"

        'sir noriel
        'txtEmployeeId.Text = "1901-033"

        'sir jhon
        'txtEmployeeId.Text = "1811-031"

        'sir tony
        'txtEmployeeId.Text = "1605-002"

        'mam liza
        'txtEmployeeId.Text = "2009-015"

        'me
        'txtEmployeeId.Text = "2009-002"
        'txtPassword.Text = "malibong"

        ''karlin
        'txtEmployeeId.Text = "2106-020"
        'txtPassword.Text = "tano"

        picPassword.Image = imgHide
        txtPassword.UseSystemPasswordChar = True
        txtPassword.PasswordChar = "●"

        If ApplicationDeployment.IsNetworkDeployed Then
            lblVersion.Text = "ver. " & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Else
            lblVersion.Text = "ver. " & Application.ProductVersion.ToString
        End If

        Me.ActiveControl = txtEmployeeId
    End Sub

    Private Sub frmLogin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.ActiveControl = txtEmployeeId
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            If ApplicationDeployment.IsNetworkDeployed Then
                If Not My.Computer.Network.IsAvailable Then
                    MessageBox.Show("No network connection.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            If String.IsNullOrEmpty(txtEmployeeId.Text.Trim) Then
                MessageBox.Show("Please enter your employee ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtEmployeeId.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtPassword.Text.Trim) Then
                MessageBox.Show("Please enter your password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Focus()
                Return
            End If

            Dim _count1 As Integer = 0
            Dim _prm1(1) As SqlParameter
            _prm1(0) = New SqlParameter("@EmployeeId", SqlDbType.NVarChar)
            _prm1(0).Value = txtEmployeeId.Text.Trim
            _prm1(1) = New SqlParameter("@Password", SqlDbType.NVarChar)
            _prm1(1).Value = txtPassword.Text.Trim

            'use latin1 general collation for case-sensitive password
            _count1 = dbMethod.ExecuteScalar("SELECT COUNT(UserId) FROM dbo.SecUser WHERE TRIM(EmployeeId) COLLATE Latin1_General_CS_AS = @EmployeeId AND " & _
                                             "TRIM(Password) COLLATE Latin1_General_CS_AS = @Password", CommandType.Text, _prm1)

            If _count1 > 0 Then
                Dim _prm2(1) As SqlParameter
                _prm2(0) = New SqlParameter("@EmployeeId", SqlDbType.NVarChar)
                _prm2(0).Value = txtEmployeeId.Text.Trim
                _prm2(1) = New SqlParameter("@Password", SqlDbType.NVarChar)
                _prm2(1).Value = txtPassword.Text.Trim

                Dim _reader As IDataReader = dbMethod.ExecuteReader("RdSecUser", CommandType.StoredProcedure, _prm2)

                While _reader.Read
                    userId = _reader.Item("UserId")
                    userName = _reader.Item("UserName").ToString.Trim
                    departmentId = _reader.Item("DepartmentId")
                    departmentName = _reader.Item("DepartmentName").ToString.Trim
                    sectionId = _reader.Item("SectionId")
                    sectionName = _reader.Item("SectionName").ToString.Trim
                    workgroupId = _reader.Item("WorkgroupId")
                    workgroupName = _reader.Item("WorkgroupName").ToString.Trim
                    isAdmin = _reader.Item("IsAdmin")
                End While
                _reader.Close()

                Me.Hide()
                Dim _frmMain As New frmMain(userId, userName, departmentId, departmentName, sectionId, sectionName, workgroupId, workgroupName, isAdmin)
                _frmMain.Show()
                txtEmployeeId.Clear()
            Else
                MessageBox.Show("Incorrect employee ID or password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Clear()
                txtPassword.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub picPassword_Click(sender As Object, e As EventArgs) Handles picPassword.Click
        If picPassword.Image Is imgHide Then
            picPassword.Image = imgShow
            txtPassword.UseSystemPasswordChar = False
            txtPassword.PasswordChar = ""
        Else
            picPassword.Image = imgHide
            txtPassword.UseSystemPasswordChar = True
            txtPassword.PasswordChar = "●"
        End If
    End Sub

End Class