Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class SecUserDetail
    Private connection As New Connection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private userId As Integer = 0
    Private departmentId As Integer = 0
    Private sectionId As Integer = 0
    Private workgroupId As Integer = 0
    Private isAdmin As Boolean = False

    Public Property SubjectId As Integer = 0

    Public Sub New(_userId As Integer, _departmentId As Integer, _sectionId As Integer, _workgroupId As Integer, _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        departmentId = _departmentId
        sectionId = _sectionId
        workgroupId = _workgroupId
        isAdmin = _isAdmin

        FillSection(sectionId)
    End Sub

    Private Sub frmSecUserEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If isAdmin Or sectionId = 1 Or sectionId = 4 Then
            cmbSection.Enabled = True
            pnlIsAdmin.Enabled = True
        Else
            cmbSection.Enabled = False
            cmbSection.SelectedValue = sectionId
            pnlIsAdmin.Enabled = False
        End If

        If userId = 0 Then
            rdAdminNo.Checked = True
            rdActiveYes.Checked = True
            btnDelete.Enabled = False

            If isAdmin Or sectionId = 1 Or sectionId = 4 Then
                cmbWorkgroup.Enabled = False
                cmbWorkgroup.SelectedValue = 0
            End If
        End If

        Me.ActiveControl = txtEmployeeId
        txtEmployeeId.Select(txtEmployeeId.Text.Trim.Length, 0)
    End Sub

    Private Sub frmSecUserEditor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F8) Then
            e.Handled = True
            btnDelete.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub cmbSection_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbSection.SelectedValue = 0 Then
                cmbWorkgroup.SelectedValue = 0
                cmbWorkgroup.Enabled = False

                cmbWorkgroup.DataSource = Nothing
                cmbWorkgroup.Items.Clear()
            Else
                cmbWorkgroup.Enabled = True
                FillWorkgroup(cmbSection.SelectedValue)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(txtEmployeeId.Text.Trim) Then
                MessageBox.Show("Please enter the employee ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmployeeId.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtUserName.Text.Trim) Then
                MessageBox.Show("Please enter the username.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUserName.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtPassword.Text.Trim) Then
                MessageBox.Show("Please enter the password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtNickname.Text.Trim) Then
                MessageBox.Show("Please enter the nickname.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNickname.Focus()
                Return
            End If

            If cmbSection.SelectedValue = 0 Then
                MessageBox.Show("Please select a section.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbSection.Focus()
                Return
            End If

            If cmbWorkgroup.SelectedValue = 0 Then
                MessageBox.Show("Please select a workgroup.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbWorkgroup.Focus()
                Return
            End If

            Dim cntUsername As Integer = 0
            Dim cntEmployeeId As Integer = 0

            If userId = 0 Then
                Dim prmCountEmployeeId(0) As SqlParameter
                prmCountEmployeeId(0) = New SqlParameter("@EmployeeId", SqlDbType.Char, 8)
                prmCountEmployeeId(0).Value = txtEmployeeId.Text.Trim

                cntEmployeeId = dbMethod.ExecuteScalar("SELECT COUNT(EmployeeId) FROM dbo.SecUser WHERE EmployeeId = @EmployeeId", CommandType.Text, prmCountEmployeeId)

                If cntEmployeeId > 0 Then
                    MessageBox.Show("Employee ID already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtEmployeeId.Focus()
                    Return
                End If

                Dim prmUserName(0) As SqlParameter
                prmUserName(0) = New SqlParameter("@UserName", SqlDbType.VarChar)
                prmUserName(0).Value = txtUserName.Text.Trim

                cntUsername = dbMethod.ExecuteScalar("SELECT COUNT(UserId) FROM dbo.SecUser WHERE UserName = @UserName", CommandType.Text, prmUserName)

                If cntUsername > 0 Then
                    MessageBox.Show("User name already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtUserName.Focus()
                    Return
                End If

                Dim prmUser(8) As SqlParameter
                prmUser(0) = New SqlParameter("@UserId", SqlDbType.Int)
                prmUser(0).Direction = ParameterDirection.Output
                prmUser(1) = New SqlParameter("@EmployeeId", SqlDbType.Char, 8)
                prmUser(1).Value = txtEmployeeId.Text.Trim
                prmUser(2) = New SqlParameter("@UserName", SqlDbType.VarChar, 30)
                prmUser(2).Value = txtUserName.Text.Trim
                prmUser(3) = New SqlParameter("@Password", SqlDbType.NVarChar, 50)
                prmUser(3).Value = txtPassword.Text.Trim
                prmUser(4) = New SqlParameter("@Nickname", SqlDbType.VarChar, 10)
                prmUser(4).Value = txtNickname.Text.Trim
                prmUser(5) = New SqlParameter("@UserItem", SqlDbType.NVarChar, 50)
                prmUser(5).Value = txtUserItem.Text.Trim
                prmUser(6) = New SqlParameter("@WorkgroupId", SqlDbType.Int)
                prmUser(6).Value = cmbWorkgroup.SelectedValue
                prmUser(7) = New SqlParameter("@IsAdmin", SqlDbType.Bit)
                prmUser(7).Value = IIf(rdAdminYes.Checked, True, False)
                prmUser(8) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmUser(8).Value = IIf(rdActiveYes.Checked, True, False)

                dbMethod.ExecuteNonQuery("InsSecUser", CommandType.StoredProcedure, prmUser)
                SubjectId = prmUser(0).Value

            Else
                Dim prmCountEmployeeId(1) As SqlParameter
                prmCountEmployeeId(0) = New SqlParameter("@EmployeeId", SqlDbType.Char, 8)
                prmCountEmployeeId(0).Value = txtEmployeeId.Text.Trim
                prmCountEmployeeId(1) = New SqlParameter("@UserId", SqlDbType.Int)
                prmCountEmployeeId(1).Value = userId

                cntEmployeeId = dbMethod.ExecuteScalar("SELECT COUNT(EmployeeId) FROM dbo.SecUser WHERE EmployeeId = @EmployeeId AND UserId <> @UserId", CommandType.Text, prmCountEmployeeId)

                If cntEmployeeId > 0 Then
                    MessageBox.Show("Employee ID already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtEmployeeId.Focus()
                    Return
                End If

                Dim prmUserName(1) As SqlParameter
                prmUserName(0) = New SqlParameter("@UserName", SqlDbType.VarChar)
                prmUserName(0).Value = txtUserName.Text.Trim
                prmUserName(1) = New SqlParameter("@UserId", SqlDbType.Int)
                prmUserName(1).Value = userId

                cntUsername = dbMethod.ExecuteScalar("SELECT COUNT(UserId) FROM dbo.SecUser WHERE UserName = @UserName AND UserId <> @UserId", CommandType.Text, prmUserName)

                If cntUsername > 0 Then
                    MessageBox.Show("User name already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtUserName.Focus()
                    Return
                End If

                Dim prmUser(8) As SqlParameter
                prmUser(0) = New SqlParameter("@UserId", SqlDbType.Int)
                prmUser(0).Value = userId
                prmUser(1) = New SqlParameter("@EmployeeId", SqlDbType.Char, 8)
                prmUser(1).Value = txtEmployeeId.Text.Trim
                prmUser(2) = New SqlParameter("@UserName", SqlDbType.VarChar, 30)
                prmUser(2).Value = txtUserName.Text.Trim
                prmUser(3) = New SqlParameter("@Password", SqlDbType.NVarChar, 50)
                prmUser(3).Value = txtPassword.Text.Trim
                prmUser(4) = New SqlParameter("@Nickname", SqlDbType.VarChar, 10)
                prmUser(4).Value = txtNickname.Text.Trim
                prmUser(5) = New SqlParameter("@UserItem", SqlDbType.NVarChar, 50)
                prmUser(5).Value = txtUserItem.Text.Trim
                prmUser(6) = New SqlParameter("@WorkgroupId", SqlDbType.Int)
                prmUser(6).Value = cmbWorkgroup.SelectedValue
                prmUser(7) = New SqlParameter("@IsAdmin", SqlDbType.Bit)
                prmUser(7).Value = IIf(rdAdminYes.Checked, True, False)
                prmUser(8) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmUser(8).Value = IIf(rdActiveYes.Checked, True, False)

                dbMethod.ExecuteNonQuery("UpdSecUser", CommandType.StoredProcedure, prmUser)

                SubjectId = userId
            End If

            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If userId <> 0 Then
                Dim prmCount(0) As SqlParameter
                prmCount(0) = New SqlParameter("@UserId", SqlDbType.Int)
                prmCount(0).Value = userId

                Dim count As Integer = 0
                count = dbMethod.ExecuteScalar("SELECT COUNT(TrxDetailId) FROM dbo.MntTransactionDetail WHERE UserId = @UserId", CommandType.Text, prmCount)

                If count > 0 Then
                    Dim message1 = String.Format("This user is already included in activities." & Environment.NewLine &
                                                 "Mark this user as inactive instead?")
                    If MessageBox.Show(message1, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim prmInactive(0) As SqlParameter
                        prmInactive(0) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmInactive(0).Value = userId

                        dbMethod.ExecuteNonQuery("UPDATE dbo.SecUser SET IsActive = 0 WHERE UserId = @UserId", CommandType.Text, prmInactive)

                        Me.DialogResult = DialogResult.OK
                    End If
                Else
                    Dim message2 = String.Format("Are you sure you want to delete this user?")
                    If MessageBox.Show(message2, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim prmInactive(0) As SqlParameter
                        prmInactive(0) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmInactive(0).Value = userId

                        dbMethod.ExecuteNonQuery("DELETE FROM dbo.SecUser WHERE UserId = @UserId", CommandType.Text, prmInactive)

                        Me.DialogResult = DialogResult.OK
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillSection(sectionId As Integer)
        Try
            cmbSection.DisplayMember = "SectionName"
            cmbSection.ValueMember = "SectionId"

            If isAdmin Or sectionId = 1 Or sectionId = 4 Then
                dbMethod.FillCmbWithCaption("RdSecSection", CommandType.StoredProcedure, "SectionId", "SectionName", cmbSection, "< Select Section >")
            Else
                Dim prmSection(0) As SqlParameter
                prmSection(0) = New SqlParameter("@SectionId", SqlDbType.Int)
                prmSection(0).Value = sectionId

                dbMethod.FillCmbWithCaption("RdSecSection", CommandType.StoredProcedure, "SectionId", "SectionName", cmbSection, "< Select Section >", prmSection)
            End If

            AddHandler cmbSection.SelectedValueChanged, AddressOf cmbSection_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillWorkgroup(sectionId As Integer)
        Try
            cmbWorkgroup.DisplayMember = "WorkgroupName"
            cmbWorkgroup.ValueMember = "WorkgroupId"

            Dim prmWorkgroup(0) As SqlParameter
            prmWorkgroup(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmWorkgroup(0).Value = sectionId

            dbMethod.FillCmbWithCaption("RdSecWorkgroup", CommandType.StoredProcedure, "WorkgroupId", "WorkgroupName", cmbWorkgroup, "< Select Workgroup >", prmWorkgroup)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class