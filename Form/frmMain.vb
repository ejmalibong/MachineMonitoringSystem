Imports System.Data.SqlClient
Imports BlackCoffeeLibrary
Imports System.Deployment.Application

Public Class frmMain
    Private connection As New clsConnection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
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

    Public Sub New(ByVal _userId As Integer, ByVal _userName As String, ByVal _departmentId As Integer, ByVal _departmentName As String, _
                   ByVal _sectionId As Integer, ByVal _sectionName As String, ByVal _workgroupId As Integer, ByVal _workgroupName As String, _
                   ByVal _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        userName = _userName
        departmentId = _departmentId
        departmentName = _departmentName
        sectionId = _sectionId
        sectionName = _sectionName
        workgroupId = _workgroupId
        workgroupName = _workgroupName
        isAdmin = _isAdmin

        UsernameToolStripMenuItem.Text = "  " & StrConv(userName, VbStrConv.ProperCase)

        If departmentName.Equals(sectionName) Then
            DepartmentToolStripStatusLabel.Text = departmentName
            SectionToolStripStatusLabel.Text = String.Empty
            UserItemToolStripMenuItem.Text = workgroupName
        Else
            If String.IsNullOrEmpty(sectionName) Then
                DepartmentToolStripStatusLabel.Text = departmentName
                SectionToolStripStatusLabel.Text = String.Empty
                UserItemToolStripMenuItem.Text = workgroupName
            Else
                DepartmentToolStripStatusLabel.Text = departmentName
                SectionToolStripStatusLabel.Text = sectionName
                UserItemToolStripMenuItem.Text = sectionName & " " & workgroupName
            End If
        End If

        If ApplicationDeployment.IsNetworkDeployed Then
            VersionToolStripStatusLabel.Text = "Version " & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Else
            VersionToolStripStatusLabel.Text = "Version " & Application.ProductVersion.ToString
        End If

        GetWorkgroupAccess(workgroupId, sectionId)
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'disable the resize or maximize button of the form if the form is maximized, then enable if the form is minimized
        AddHandler Me.SizeChanged, AddressOf frmMain_SizeEventHandler

        Me.MaximizeBox = False

        tmrMain.Start()
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        tmrMain.Stop()
        Application.Exit()
    End Sub

    Private Sub tmrMain_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick
        DatetimeToolStripMenuItem.Text = CDate(dbMethod.GetServerDate).ToString("dd MMMM yyyy")
    End Sub

    Private Sub frmMain_MdiChildActivate(sender As Object, e As EventArgs) Handles MyBase.MdiChildActivate
        Dim _frm As Form = Me.ActiveMdiChild

        If Not _frm Is Nothing Then
            Me.Text = "Machine Monitoring System - " & _frm.Text & ""
        End If
    End Sub

    'file
    Private Sub MntTransactionConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntTransactionConsoleToolStripMenuItem.Click
        dbMain.FormLoader(Me, New frmMntTrxConsole(userId, workgroupId, isAdmin), True)
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Hide()
        frmLogin.Show()
        frmLogin.BringToFront()
        frmLogin.txtEmployeeId.Clear()
        frmLogin.txtPassword.Clear()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    'reports
    Private Sub MntActivityReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntActivityReportToolStripMenuItem.Click
        Try
            dbMain.FormLoader(Me, New frmMntActivityReport)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'maintenance
    Private Sub MachineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntMachineToolStripMenuItem.Click
        dbMain.FormLoader(Me, frmMntMachine)
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SecUserToolStripMenuItem.Click
        dbMain.FormLoader(Me, New frmSecUser(sectionId, departmentId, isAdmin))
    End Sub

    Private Sub GetWorkgroupAccess(ByVal _workgroupdId As Integer, ByVal _sectionId As Integer)
        Select Case _sectionId
            Case 1 'manager level
                MntTransactionConsoleToolStripMenuItem.Text = "Maintenance Transaction Console"
                MntTransactionApprovalToolStripMenuItem.Text = "Maintenance Transaction Approval"
                FacTransactionConsoleToolStripMenuItem.Text = "Facility Transaction Console"
                FacTransactionApprovalToolStripMenuItem.Text = "Facility Transaction Approval"
                MntActivityReportToolStripMenuItem.Text = "Maintenance Activity Report"
                FacActivityReportToolStripMenuItem.Text = "Facility Activity Report"

            Case 2 'maintenance
                FacTransactionConsoleToolStripMenuItem.Visible = False
                FacTransactionApprovalToolStripMenuItem.Visible = False
                FacActivityReportToolStripMenuItem.Visible = False

                'dbMain.FormLoader(Me, New frmMntMachine)

                Select Case _workgroupdId
                    Case 30 'sv
                        dbMain.FormLoader(Me, New frmMntTrxConsole(userId, workgroupId, isAdmin), True)

                    Case 29 'asv
                        dbMain.FormLoader(Me, New frmMntTrxConsole(userId, workgroupId, isAdmin), True)

                    Case Else 'technician, maintenance assistant
                        MntTransactionApprovalToolStripMenuItem.Enabled = False
                        SecUserToolStripMenuItem.Enabled = False

                        dbMain.FormLoader(Me, New frmMntTrxConsole(userId, workgroupId, isAdmin), True)
                End Select

            Case 3 'facility
                MntTransactionConsoleToolStripMenuItem.Visible = False
                MntTransactionApprovalToolStripMenuItem.Visible = False
                MntActivityReportToolStripMenuItem.Visible = False

                Select Case _workgroupdId
                    Case 10 'technician
                        FacTransactionApprovalToolStripMenuItem.Visible = False
                        SecUserToolStripMenuItem.Visible = False
                        MasterToolStripSeparator2.Visible = False
                End Select

            Case 4 'it
                MntTransactionConsoleToolStripMenuItem.Text = "Maintenance Transaction Console"
                MntTransactionApprovalToolStripMenuItem.Text = "Maintenance Transaction Approval"

                FacTransactionConsoleToolStripMenuItem.Text = "Facility Transaction Console"
                FacTransactionApprovalToolStripMenuItem.Text = "Facility Transaction Approval"

                MntActivityReportToolStripMenuItem.Text = "Maintenance Activity Report"
                FacActivityReportToolStripMenuItem.Text = "Facility Activity Report"

        End Select
    End Sub

    'prevent form resizing when double clicked the titlebar or dragged
    Protected Overloads Overrides Sub WndProc(ByRef m As Message)
        Const WM_NCLBUTTONDBLCLK As Integer = 163 'define doubleclick event
        Const WM_NCLBUTTONDOWN As Integer = 161 'define leftbuttondown event
        Const WM_SYSCOMMAND As Integer = 274 'define move action
        Const HTCAPTION As Integer = 2 'define that the WM_NCLBUTTONDOWN is at titlebar
        Const SC_MOVE As Integer = 61456 'trap move action
        'disable moving of title bar
        If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_MOVE) Then
            Exit Sub
        End If
        'track whether clicked on title bar
        If (m.Msg = WM_NCLBUTTONDOWN) AndAlso (m.WParam.ToInt32() = HTCAPTION) Then
            Exit Sub
        End If
        'disable double click on title bar
        If (m.Msg = WM_NCLBUTTONDBLCLK) Then
            Exit Sub
        End If

        MyBase.WndProc(m)
    End Sub

    Private Sub frmMain_SizeEventHandler(ByVal sender As Object, ByVal e As EventArgs)
        If Me.WindowState = FormWindowState.Minimized Then
            Me.MaximizeBox = True

        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.MaximizeBox = False
        End If
    End Sub

End Class