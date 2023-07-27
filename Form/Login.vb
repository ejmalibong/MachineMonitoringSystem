Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports BlackCoffeeLibrary

Public Class Login
    Private dbConnection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)

    Private userId As Integer = 0
    Private userName As String = String.Empty
    Private departmentId As Integer = 0
    Private departmentName As String = String.Empty
    Private sectionId As Integer = 0
    Private sectionName As String = String.Empty
    Private workgroupId As Integer = 0
    Private workgroupName As String = String.Empty
    Private isAdmin As Boolean = False
    Private isActive As Boolean = False

    Private imgHide As Image = My.Resources.Password_Hide
    Private imgShow As Image = My.Resources.Password_Show

    Private isDebug As Boolean = My.Settings.IsDebug

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If isDebug = True Then
            'sir alvin
            'txtEmployeeId.Text = "1705-025"
            'txtPassword.Text = "aranes"

            'sir mon
            'txtEmployeeId.Text = "1506-001"
            'txtPassword.Text = "bayani"

            'txtEmployeeId.Text = "1605-002"
            'txtPassword.Text = "atienza"

            'sir emman
            txtEmployeeId.Text = "1701-066"
            txtPassword.Text = "ESandoval"

            'sir harry
            'txtEmployeeId.Text = "1807-002"
            'txtPassword.Text = "tanega"

            'sys admin
            'txtEmployeeId.Text = "XXXX-XXX"
            'txtPassword.Text = "Adm1nAcc3ss"

            'ej
            'txtEmployeeId.Text = "2009-002"
            'txtPassword.Text = "malibong"

            'karlin
            'txtEmployeeId.Text = "2106-020"
            'txtPassword.Text = "tano"

            'noriel
            'txtEmployeeId.Text = "1901-033"
            'txtPassword.Text = "aquino"

            'liza
            'txtEmployeeId.Text = "2009-015"
            'txtPassword.Text = "pastrana"
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

    Private Sub Login_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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
                MessageBox.Show("Please enter your employee ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmployeeId.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtPassword.Text.Trim) Then
                MessageBox.Show("Please enter your password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Focus()
                Return
            End If

            Dim count As Integer = 0
            Dim prmCount(1) As SqlParameter
            prmCount(0) = New SqlParameter("@EmployeeId", SqlDbType.NVarChar)
            prmCount(0).Value = txtEmployeeId.Text.Trim
            prmCount(1) = New SqlParameter("@Password", SqlDbType.NVarChar)
            prmCount(1).Value = txtPassword.Text.Trim

            count = dbMethod.ExecuteScalar("CntSecUserByLogin", CommandType.StoredProcedure, prmCount)

            If count > 0 Then
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
                    isActive = rdrUser.Item("IsActive")
                End While
                rdrUser.Close()

                If isActive = False Then
                    MessageBox.Show("User is inactive.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtPassword.Clear()
                    txtPassword.Focus()
                    Exit Sub
                Else
                    Me.Hide()
                    Dim frmMain As New Main(userId, userName, departmentId, departmentName, sectionId, sectionName, workgroupId, workgroupName, isAdmin)
                    frmMain.Show()
                    txtEmployeeId.Clear()
                    txtPassword.Clear()
                End If
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