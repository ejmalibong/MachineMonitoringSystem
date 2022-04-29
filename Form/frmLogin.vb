Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports BlackCoffeeLibrary

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
        If MachineMonitoringSystem.My.Settings.IsDebug = True Then
            'sir alvin
            'txtEmployeeId.Text = "1705-025"
            'txtPassword.Text = "aranes"

            'sir mon
            'txtEmployeeId.Text = "1506-001"
            'txtPassword.Text = "bayani"

            'sir emman
            'txtEmployeeId.Text = "1701-066"
            'txtPassword.Text = "sandoval"

            'sir harry
            txtEmployeeId.Text = "1807-002"
            txtPassword.Text = "tanega"

            ''sys admin
            'txtEmployeeId.Text = "XXXX-XX"
            'txtPassword.Text = "Adm1nAcc3ss"

            ''ej
            'txtEmployeeId.Text = "2009-002"
            'txtPassword.Text = "malibong"
        End If

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

            Dim countId As Integer = 0
            Dim prmCountId(1) As SqlParameter
            prmCountId(0) = New SqlParameter("@EmployeeId", SqlDbType.NVarChar)
            prmCountId(0).Value = txtEmployeeId.Text.Trim
            prmCountId(1) = New SqlParameter("@Password", SqlDbType.NVarChar)
            prmCountId(1).Value = txtPassword.Text.Trim

            'use latin1 general collation for case-sensitive password
            countId = dbMethod.ExecuteScalar("SELECT COUNT(UserId) FROM dbo.SecUser WHERE TRIM(EmployeeId) COLLATE Latin1_General_CS_AS = @EmployeeId AND " &
                                             "TRIM(Password) COLLATE Latin1_General_CS_AS = @Password", CommandType.Text, prmCountId)

            If countId > 0 Then
                Dim prmUser(1) As SqlParameter
                prmUser(0) = New SqlParameter("@EmployeeId", SqlDbType.NVarChar)
                prmUser(0).Value = txtEmployeeId.Text.Trim
                prmUser(1) = New SqlParameter("@Password", SqlDbType.NVarChar)
                prmUser(1).Value = txtPassword.Text.Trim

                Dim rdrUser As IDataReader = dbMethod.ExecuteReader("RdSecUser", CommandType.StoredProcedure, prmUser)

                While rdrUser.Read
                    userId = rdrUser.Item("UserId")
                    userName = rdrUser.Item("UserName").ToString.Trim
                    departmentId = rdrUser.Item("DepartmentId")
                    departmentName = rdrUser.Item("DepartmentName").ToString.Trim
                    sectionId = rdrUser.Item("SectionId")
                    sectionName = rdrUser.Item("SectionName").ToString.Trim
                    workgroupId = rdrUser.Item("WorkgroupId")
                    workgroupName = rdrUser.Item("WorkgroupName").ToString.Trim
                    isAdmin = rdrUser.Item("IsAdmin")
                End While
                rdrUser.Close()

                Me.Hide()
                Dim frmMain As New frmMain(userId, userName, departmentId, departmentName, sectionId, sectionName, workgroupId, workgroupName, isAdmin)
                frmMain.Show()
                txtEmployeeId.Clear()
                txtPassword.Clear()
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