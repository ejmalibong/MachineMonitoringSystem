Imports System.Deployment.Application
Imports BlackCoffeeLibrary

Public Class Main
    Private dbConnection As New Connection
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private userId As Integer = 0
    Private userName As String = String.Empty
    Private departmentId As Integer = 0
    Private departmentName As String = String.Empty
    Private sectionId As Integer = 0
    Private sectionName As String = String.Empty
    Private workgroupId As Integer = 0
    Private workgroupName As String = String.Empty
    Private isAdmin As Boolean = False

    Private accessLevelId As Integer = 0

    Private arrSplitted() As String

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

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrMain.Start()

        'disable the resize or maximize button of the form if the form is maximized, then enable if the form is minimized
        AddHandler Me.SizeChanged, AddressOf Main_SizeEventHandler
        Me.MaximizeBox = False
    End Sub

    Private Sub Main_MdiChildActivate(sender As Object, e As EventArgs) Handles MyBase.MdiChildActivate
        Dim activeForm As Form = Me.ActiveMdiChild

        If activeForm IsNot Nothing Then
            arrSplitted = Split(activeForm.Text.Trim, " - ", 2)
            Me.Text = "Machine Monitoring System - " & arrSplitted(0) & ""
        Else
            Me.Text = "Machine Monitoring System"
        End If
    End Sub

    Private Sub Main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub Main_SizeEventHandler(ByVal sender As Object, ByVal e As EventArgs)
        If Me.WindowState = FormWindowState.Minimized Then
            Me.MaximizeBox = True

        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.MaximizeBox = False
        End If
    End Sub

    Private Sub tmrMain_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick
        DatetimeToolStripMenuItem.Text = CDate(dbMethod.GetServerDate).ToString("dd MMMM yyyy")
    End Sub

    'file
    Private Sub MntTransactionConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntTransactionConsoleToolStripMenuItem.Click
        dbMain.FormLoader(Me, New MntTrxConsole(userId, workgroupId, sectionId, isAdmin), True)
    End Sub

    Private Sub MntMachineScheduleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntMachineScheduleToolStripMenuItem.Click
        dbMain.FormLoader(Me, New MntMchSched(userId))
    End Sub

    Private Sub MntJigScheduleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntJigScheduleToolStripMenuItem.Click
        dbMain.FormLoader(Me, New MntJigSched(userId))
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Hide()
        Login.Show()
        Login.BringToFront()
        Login.txtEmployeeId.Clear()
        Login.txtPassword.Clear()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    'report
    Private Sub MntActivityReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntActivityReportToolStripMenuItem.Click
        dbMain.FormLoader(Me, New MntActivityReport, True)
    End Sub

    'maintenance
    Private Sub MntMachineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntMchToolStripMenuItem.Click
        dbMain.FormLoader(Me, New MntMch(userId))
    End Sub

    Private Sub MntMchChecksheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntMchChecksheetToolStripMenuItem.Click
        dbMain.FormLoader(Me, New MntMchCs)
    End Sub

    Private Sub MntJigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntJigToolStripMenuItem.Click
        dbMain.FormLoader(Me, New MntJig(userId))
    End Sub

    Private Sub MntJigChecksheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntJigChecksheetToolStripMenuItem.Click
        dbMain.FormLoader(Me, New MntJigCs)
    End Sub

    Private Sub MntJigModelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntJigModelToolStripMenuItem.Click
        dbMain.FormLoader(Me, New MntJigModel)
    End Sub

    Private Sub MntModelExtensionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntModelExtensionToolStripMenuItem.Click
        dbMain.FormLoader(Me, New MntModelExtension)
    End Sub

    Private Sub SecUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SecUserToolStripMenuItem.Click
        dbMain.FormLoader(Me, New SecUser(departmentId, sectionId, workgroupId, isAdmin))
    End Sub

    Private Sub GetWorkgroupAccess(wgroupId As Integer, sectId As Integer)
        Select Case sectId
            Case 1, 4 'manager, sys admin
                For Each itm As ToolStripItem In FileToolStripMenuItem.DropDownItems
                    If TypeOf (itm) Is ToolStripMenuItem Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("FA") Then
                            itm.Text = "FA " & itm.Text
                        End If

                        If itm.Tag.ToString.Substring(0, 2).Equals("MT") Then
                            itm.Text = "MT " & itm.Text
                        End If
                    End If
                Next

                For Each itm As ToolStripItem In ReportsToolStripMenuItem.DropDownItems
                    If TypeOf (itm) Is ToolStripMenuItem Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("FA") Then
                            itm.Text = "FA " & itm.Text
                        End If

                        If itm.Tag.ToString.Substring(0, 2).Equals("MT") Then
                            itm.Text = "MT " & itm.Text
                        End If
                    End If
                Next

                For Each itm As ToolStripItem In MaintenanceToolStripMenuItem.DropDownItems
                    If TypeOf (itm) Is ToolStripMenuItem Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("FA") Then
                            itm.Text = "FA " & itm.Text
                        End If

                        If itm.Tag.ToString.Substring(0, 2).Equals("MT") Then
                            itm.Text = "MT " & itm.Text
                        End If
                    End If
                Next

            Case 2 'maintenance
                Select Case wgroupId
                    Case 1, 2, 3 Or isAdmin 'engg sys admin, sr mngr, mngr
                        accessLevelId = 1
                    Case 35, 40 'mt mgr, am
                        accessLevelId = 2
                    Case 29, 30 'mt sv, asv
                        accessLevelId = 3
                    Case 5 'mt sr tech
                        accessLevelId = 4
                    Case Else
                        accessLevelId = 99
                End Select

                For Each itm As ToolStripItem In FileToolStripMenuItem.DropDownItems
                    If TypeOf (itm) Is ToolStripMenuItem Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("FA") Then
                            itm.Visible = False
                        End If
                    End If

                    If TypeOf (itm) Is ToolStripSeparator Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("FA") Then
                            itm.Visible = False
                        End If
                    End If
                Next

                For Each itm As ToolStripItem In ReportsToolStripMenuItem.DropDownItems
                    If TypeOf (itm) Is ToolStripMenuItem Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("FA") Then
                            itm.Visible = False
                        End If
                    End If

                    If TypeOf (itm) Is ToolStripSeparator Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("FA") Then
                            itm.Visible = False
                        End If
                    End If
                Next

                For Each itm As ToolStripItem In MaintenanceToolStripMenuItem.DropDownItems
                    If TypeOf (itm) Is ToolStripMenuItem Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("FA") Then
                            itm.Visible = False
                        End If
                    End If

                    If TypeOf (itm) Is ToolStripSeparator Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("FA") Then
                            itm.Visible = False
                        End If
                    End If
                Next

                Select Case accessLevelId
                    Case 1

                    Case 2, 3
                        dbMain.FormLoader(Me, New MntTrxConsole(userId, workgroupId, sectionId, isAdmin), True)

                    Case Else
                        SecUserToolStripMenuItem.Visible = False
                        tssMaintenance3.Visible = False

                        'dbMain.FormLoader(Me, New MntTrxConsole(userId, workgroupId, sectionId, isAdmin), True)
                        dbMain.FormLoader(Me, New MntSparePart(userId, workgroupId, isAdmin), True)
                End Select

            Case 3 'facility
                Select Case wgroupId
                    Case 1, 2, 3 Or isAdmin 'sys admin, sr mngr, mngr
                        accessLevelId = 1
                    Case 36 'fc am
                        accessLevelId = 2
                    Case 31, 32, 7, 8 'fc sv, asv, sr engr, engr
                        accessLevelId = 3
                    Case 9 'fc sr tech
                        accessLevelId = 4
                    Case Else
                        accessLevelId = 99
                End Select

                For Each itm As ToolStripItem In FileToolStripMenuItem.DropDownItems
                    If TypeOf (itm) Is ToolStripMenuItem Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("MT") Then
                            itm.Visible = False
                        End If
                    End If

                    If TypeOf (itm) Is ToolStripSeparator Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("MT") Then
                            itm.Visible = False
                        End If
                    End If
                Next

                For Each itm As ToolStripItem In ReportsToolStripMenuItem.DropDownItems
                    If TypeOf (itm) Is ToolStripMenuItem Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("MT") Then
                            itm.Visible = False
                        End If
                    End If

                    If TypeOf (itm) Is ToolStripSeparator Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("MT") Then
                            itm.Visible = False
                        End If
                    End If
                Next

                For Each itm As ToolStripItem In MaintenanceToolStripMenuItem.DropDownItems
                    If TypeOf (itm) Is ToolStripMenuItem Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("MT") Then
                            itm.Visible = False
                        End If
                    End If

                    If TypeOf (itm) Is ToolStripSeparator Then
                        If itm.Tag.ToString.Substring(0, 2).Equals("MT") Then
                            itm.Visible = False
                        End If
                    End If
                Next

                Select Case accessLevelId
                    Case 1

                    Case 2, 3
                        dbMain.FormLoader(Me, New FacTrxConsole(userId, workgroupId, sectionId, isAdmin), True)

                    Case Else
                        dbMain.FormLoader(Me, New FacTrxConsole(userId, workgroupId, sectionId, isAdmin), True)
                        SecUserToolStripMenuItem.Visible = False
                        tssMaintenance2.Visible = False

                        dbMain.FormLoader(Me, New FacTrxConsole(userId, workgroupId, sectionId, isAdmin), True)
                End Select

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

    Private Sub FacTransactionConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacTransactionConsoleToolStripMenuItem.Click
        dbMain.FormLoader(Me, New FacTrxConsole(userId, workgroupId, sectionId, isAdmin), True)
    End Sub

    Private Sub FacActivityReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacActivityReportToolStripMenuItem.Click
        dbMain.FormLoader(Me, New FacActivityReport)
    End Sub

    Private Sub FacMachineScheduleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacMachineScheduleToolStripMenuItem.Click
        dbMain.FormLoader(Me, New FacMchSched(userId))
    End Sub

    Private Sub MntActivityReportToolStripMenuItem_VisibleChanged(sender As Object, e As EventArgs) Handles MntActivityReportToolStripMenuItem.VisibleChanged
        If FacActivityReportToolStripMenuItem.Visible = False Or MntActivityReportToolStripMenuItem.Visible = False Then
            tssReport.Visible = False
        End If
    End Sub

    Private Sub FacActivityReportToolStripMenuItem_VisibleChanged(sender As Object, e As EventArgs) Handles FacActivityReportToolStripMenuItem.VisibleChanged
        If FacActivityReportToolStripMenuItem.Visible = False Or MntActivityReportToolStripMenuItem.Visible = False Then
            tssReport.Visible = False
        End If
    End Sub

    Private Sub MntSparePartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MntSparePartToolStripMenuItem.Click
        dbMain.FormLoader(Me, New MntSparePart(userId, workgroupId, isAdmin), True)
    End Sub

End Class