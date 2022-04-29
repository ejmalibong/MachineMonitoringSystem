Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports BlackCoffeeLibrary

Public Class frmMain
    Private connection As New clsConnection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbMain As New Main
    Private impersonation As New UserImpersonation.UserImpersonation

    Private userId As Integer = 0
    Private userName As String = String.Empty
    Private workgroupId As Integer = 0
    Private workgroupName As String = String.Empty
    Private sectionId As Integer = 0
    Private sectionName As String = String.Empty
    Private departmentId As Integer = 0
    Private departmentName As String = String.Empty
    Private isAdmin As Boolean = False

    Public Sub New(_userId As Integer, _userName As String, _departmentId As Integer, _departmentName As String, _sectionId As Integer,
                   _sectionName As String, _workgroupId As Integer, _workgroupName As String, _isAdmin As Boolean)

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
        UserItemToolStripMenuItem.Text = workgroupName

        If departmentName.Equals(sectionName) Then
            DepartmentToolStripStatusLabel.Text = departmentName
            SectionToolStripStatusLabel.Text = String.Empty
            SectionToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.None
        Else
            If String.IsNullOrEmpty(sectionName) Then
                DepartmentToolStripStatusLabel.Text = departmentName
                SectionToolStripStatusLabel.Text = String.Empty
                SectionToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.None
            Else
                DepartmentToolStripStatusLabel.Text = departmentName
                SectionToolStripStatusLabel.Text = sectionName
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
        tmrMain.Start()

        'disable the resize or maximize button of the form if the form is maximized, then enable if the form is minimized
        AddHandler Me.SizeChanged, AddressOf frmMain_SizeEventHandler
        Me.MaximizeBox = False
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub tmrMain_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick
        DatetimeToolStripMenuItem.Text = CDate(dbMethod.GetServerDate).ToString("dd MMMM yyyy")
    End Sub

    Private Sub frmMain_MdiChildActivate(sender As Object, e As EventArgs) Handles MyBase.MdiChildActivate
        Dim activeForm As Form = Me.ActiveMdiChild

        If Not activeForm Is Nothing Then
            Me.Text = "Machine Monitoring System - " & activeForm.Text & ""
        Else
            Me.Text = "Machine Monitoring System"
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

    Private Sub GetWorkgroupAccess(wgroupId As Integer, sectId As Integer)
        Select Case sectId
            Case 1 'manager, sys admin

            Case 2 'maintenance
                Select Case wgroupId
                    Case 29, 30, 35 'asv, sv, asm
                        dbMain.FormLoader(Me, New frmMntTrxConsole(userId, workgroupId, isAdmin), True)

                    Case Else 'technician, maintenance assistant, sr technician
                        MntTransactionApprovalToolStripMenuItem.Visible = False
                        SecUserToolStripMenuItem.Visible = False
                        MntModelExtensionSeparator.Visible = False

                        dbMain.FormLoader(Me, New frmMntTrxConsole(userId, workgroupId, isAdmin), True)
                End Select

            Case 4 'it

            Case Else
                Application.Exit()

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