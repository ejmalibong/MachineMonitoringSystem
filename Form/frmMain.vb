Public Class frmMain
    Private method As New clsMethod
    Private userId As Integer = 0
    Private employeeId As String = String.Empty
    Private userName As String = String.Empty
    Private nickname As String = String.Empty
    Private userItem As String = String.Empty
    Private isAdmin As Boolean = True
    Private workgroupId As Integer = 0
    Private workgroupName As String = String.Empty
    Private sectionId As Integer = 0
    Private sectionName As String = String.Empty
    Private areaId As Integer = 0
    Private areaName As String = String.Empty
    Private departmentId As Integer = 0
    Private departmentShortName As String = String.Empty
    Private departmentName As String = String.Empty

    Public Sub New(ByVal _userId As Integer, ByVal _employeeId As String, ByVal _userName As String, ByVal _nickName As String, ByVal _userItem As String, ByVal _isAdmin As Boolean, ByVal _workgroupId As Integer, ByVal _workgroupName As String, ByVal _sectionId As Integer, ByVal _sectionName As String, ByVal _areaId As Integer, ByVal _areaName As String, ByVal _departmentId As Integer, ByVal _departmentShortName As String, ByVal _departmentName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        employeeId = _employeeId
        userName = _userName
        nickname = _nickName
        userItem = _userItem
        isAdmin = _isAdmin
        workgroupId = _workgroupId
        workgroupName = _workgroupName
        sectionId = _sectionId
        sectionName = _sectionName
        areaId = _sectionId
        areaName = _sectionName
        departmentId = _departmentId
        departmentShortName = _departmentShortName
        departmentName = _departmentName

        UsernameToolStripMenuItem.Text = "  " & userName
        UserItemToolStripMenuItem.Text = userItem
        DepartmentToolStripStatusLabel.Text = " " & departmentName & "  |"
        SectionToolStripStatusLabel.Text = sectionName

        tmrMain.Start()

        DefineAccess()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'disable the resize/maximize button of the form if maximize, enable if the form is minimize
        AddHandler Me.SizeChanged, AddressOf frmMain_SizeEventHandler

        'disable resize/maximize button of the form
        Me.MaximizeBox = False
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        tmrMain.Stop()
        Application.Exit()
    End Sub

    Private Sub tmrMain_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick
        DatetimeToolStripMenuItem.Text = DateTime.Now.ToString("dd MMMM yyyy")
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Hide()
        frmLogin.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    'file
    Private Sub MntTransactionApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntTransactionApprovalToolStripMenuItem.Click
        method.FormLoader(Me, New frmMntTrxApproval(userId, workgroupId, isAdmin))
    End Sub

    Private Sub MntTransactionConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntTransactionConsoleToolStripMenuItem.Click
        method.FormLoader(Me, New frmMntTrxConsole(userId, workgroupId, isAdmin))
    End Sub

    Private Sub FacTransactionApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacTransactionApprovalToolStripMenuItem.Click

    End Sub

    Private Sub FacTransactionConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacTransactionConsoleToolStripMenuItem.Click

    End Sub

    'prevent form resizing when double clicked the titlebar or dragged
    Protected Overloads Overrides Sub WndProc(ByRef m As Message)
        Const WM_NCLBUTTONDBLCLK As Integer = 163 'define doubleclick event
        Const WM_NCLBUTTONDOWN As Integer = 161 'define leftbuttondown event
        Const WM_SYSCOMMAND As Integer = 274 'define move action
        Const HTCAPTION As Integer = 2 'define that the WM_NCLBUTTONDOWN is at titlebar
        Const SC_MOVE As Integer = 61456 'trap move action
        'disable moving titleBar
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

    Private Sub DefineAccess()
        'sys admin, senior manager and engineering manager
        If workgroupId.Equals(1) Or workgroupId.Equals(2) Or workgroupId.Equals(3) Or workgroupId.Equals(13) Or workgroupId.Equals(14) Then
            MntTransactionApprovalToolStripMenuItem.Text = "Maintenance Transaction Approval"
            MntTransactionConsoleToolStripMenuItem.Text = "Maintenance Transaction Console"

            FacTransactionApprovalToolStripMenuItem.Text = "Facility Transaction Approval"
            FacTransactionConsoleToolStripMenuItem.Text = "Facility Transaction Console"
        End If

        'maintenance
        If sectionId = 2 Then
            FacTransactionApprovalToolStripMenuItem.Visible = False 'file
            FacTransactionConsoleToolStripMenuItem.Visible = False 'file

            'technician
            If workgroupId = 5 Or workgroupId = 6 Then
                method.FormLoader(Me, New frmMntTrxConsole(userId, workgroupId, isAdmin))
                MntTransactionApprovalToolStripMenuItem.Visible = False
                MasterlistToolStripMenuItem.Visible = False
                OptionsToolStripMenuItem.Visible = False
                'senior engineer
            ElseIf workgroupId = 4 Then
                method.FormLoader(Me, New frmMntTrxApproval(userId, workgroupId, isAdmin))
            End If

            'facility
        ElseIf sectionId = 3 Then
            MntTransactionApprovalToolStripMenuItem.Visible = False 'file
            MntTransactionConsoleToolStripMenuItem.Visible = False 'file

            'technician
            If workgroupId = 9 Or workgroupId = 10 Then
                'method.FormLoader(Me, New frmFacTrxConsole(userId, workgroupId, isAdmin))
                FacTransactionApprovalToolStripMenuItem.Visible = False
                MasterlistToolStripMenuItem.Visible = False
                OptionsToolStripMenuItem.Visible = False

                'senior engineer, engineer
            ElseIf workgroupId = 7 Or workgroupId = 8 Then
                'method.FormLoader(Me, New frmFacDashboard(userId, workgroupId))
            End If
        End If
    End Sub

    Private Sub MntActivityReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntActivityReportToolStripMenuItem.Click
        method.FormLoader(Me, New frmMntActivityReport)
    End Sub

End Class