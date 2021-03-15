Imports MachineMonitoringSystem.dsMonitoringTableAdapters
Imports MachineMonitoringSystem.dsMonitoring

Public Class frmLogin
    Private userid As Integer = 0
    Private employeeId As String = String.Empty
    Private userName As String = String.Empty
    Private nickname As String = String.Empty
    Private userItem As String = String.Empty
    Private isAdmin As Boolean = True
    Private workgroupId As Integer = 0
    Private workgroupName As String = String.Empty
    Private workgroupIsActive As Boolean = True
    Private sectionId As Integer = 0
    Private sectionName As String = String.Empty
    Private sectionIsActive As Boolean = True
    Private areaId As Integer = 0
    Private processName As String = String.Empty
    Private departmentId As Integer = 0
    Private departmentShortName As String = String.Empty
    Private departmentName As String = String.Empty

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = txtEmployeeId

        'sir alvin
        'txtEmployeeId.Text = "1705-025"

        'sir clark
        'txtEmployeeId.Text = "1709-006"

        'sir mon
        'txtEmployeeId.Text = "1506-001"

        'sir emman
        'txtEmployeeId.Text = "1701-066"

        'sir harry
        'txtEmployeeId.Text = "1807-002"

        'sir noriel
        'txtEmployeeId.Text = "1901-033"

        'sir jhon
        'txtEmployeeId.Text = "1811-031"

        'sir tony
        'txtEmployeeId.Text = "1605-002"

        'mam liza
        'txtEmployeeId.Text = "2009-015"
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrEmpty(txtEmployeeId.Text.Trim) Then
            MessageBox.Show("Please enter your employee ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmployeeId.Focus()
            Return
        End If

        Dim _adpSecUser As New SecUserTableAdapter
        Dim _dtSecUser As SecUserDataTable = _adpSecUser.GetDataByEmployeeId(txtEmployeeId.Text.Trim)

        If _dtSecUser.Rows.Count > 0 Then
            With _dtSecUser.Rows(0)
                userid = .Item("UserId").ToString
                employeeId = .Item("EmployeeId").ToString
                userName = .Item("UserName").ToString.Trim
                nickname = .Item("Nickname").ToString.Trim
                userItem = .Item("UserItem").ToString.Trim
                isAdmin = .Item("IsAdmin")
                workgroupId = .Item("WorkgroupId")
                workgroupName = .Item("WorkgroupName").ToString.Trim
                workgroupIsActive = .Item("WorkgroupIsActive")
                sectionId = .Item("SectionId")
                sectionName = .Item("SectionName").ToString.Trim
                sectionIsActive = .Item("SectionIsActive")
                areaId = IIf(.Item("AreaId") Is DBNull.Value, 0, .Item("AreaId"))
                processName = IIf(.Item("AreaName") Is DBNull.Value, "", .Item("AreaName").ToString.Trim)
                departmentId = .Item("DepartmentId")
                departmentShortName = .Item("DepartmentShortName").ToString.Trim
                departmentName = .Item("DepartmentName").ToString.Trim
            End With

            If workgroupIsActive = False Then
                MessageBox.Show("Workgroup is inactive.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If sectionIsActive = False Then
                MessageBox.Show("Section is inactive.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Me.Hide()
            Dim _frmMain As New frmMain(userid, employeeId, userName, nickname, userItem, isAdmin, workgroupId, workgroupName, sectionId, sectionName, areaId, processName, departmentId, departmentShortName, departmentName)
            _frmMain.Show()
            txtEmployeeId.Clear()
        Else
            MessageBox.Show("Invalid employee ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEmployeeId.Focus()
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

End Class