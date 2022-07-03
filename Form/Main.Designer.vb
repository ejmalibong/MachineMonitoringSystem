<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.DatetimeToolStripMenuItem = New System.Windows.Forms.ToolStripLabel()
        Me.UserItemToolStripMenuItem = New System.Windows.Forms.ToolStripLabel()
        Me.UsernameToolStripMenuItem = New System.Windows.Forms.ToolStripLabel()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntTransactionConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntTransactionApprovalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntMachineScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntJigScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntActivityReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntPmReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntMachineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntMachinePartsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntProcessAreaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntProcessAreaSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.MntJigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntJigModelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntModelExtensionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntModelExtensionSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SecUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.stsMain = New System.Windows.Forms.StatusStrip()
        Me.DepartmentToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SectionToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.VersionToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.mnuMain.SuspendLayout()
        Me.stsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.BackColor = System.Drawing.Color.White
        Me.mnuMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatetimeToolStripMenuItem, Me.UserItemToolStripMenuItem, Me.UsernameToolStripMenuItem, Me.FileToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.MaintenanceToolStripMenuItem, Me.WindowToolStripMenuItem})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.MdiWindowListItem = Me.WindowToolStripMenuItem
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.ShowItemToolTips = True
        Me.mnuMain.Size = New System.Drawing.Size(684, 24)
        Me.mnuMain.TabIndex = 1
        '
        'DatetimeToolStripMenuItem
        '
        Me.DatetimeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.DatetimeToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.DatetimeToolStripMenuItem.Name = "DatetimeToolStripMenuItem"
        Me.DatetimeToolStripMenuItem.Size = New System.Drawing.Size(55, 17)
        Me.DatetimeToolStripMenuItem.Text = "Datetime"
        Me.DatetimeToolStripMenuItem.ToolTipText = "Current Date"
        '
        'UserItemToolStripMenuItem
        '
        Me.UserItemToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.UserItemToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.UserItemToolStripMenuItem.Name = "UserItemToolStripMenuItem"
        Me.UserItemToolStripMenuItem.Size = New System.Drawing.Size(54, 17)
        Me.UserItemToolStripMenuItem.Text = "UserItem"
        Me.UserItemToolStripMenuItem.ToolTipText = "Position"
        '
        'UsernameToolStripMenuItem
        '
        Me.UsernameToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.UsernameToolStripMenuItem.Image = Global.MachineMonitoringSystem.My.Resources.Resources.User
        Me.UsernameToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsernameToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.UsernameToolStripMenuItem.Name = "UsernameToolStripMenuItem"
        Me.UsernameToolStripMenuItem.Size = New System.Drawing.Size(76, 17)
        Me.UsernameToolStripMenuItem.Text = "Username"
        Me.UsernameToolStripMenuItem.ToolTipText = "Username"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MntTransactionConsoleToolStripMenuItem, Me.MntTransactionApprovalToolStripMenuItem, Me.MntMachineScheduleToolStripMenuItem, Me.MntJigScheduleToolStripMenuItem, Me.FileToolStripSeparator, Me.LogOutToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'MntTransactionConsoleToolStripMenuItem
        '
        Me.MntTransactionConsoleToolStripMenuItem.Name = "MntTransactionConsoleToolStripMenuItem"
        Me.MntTransactionConsoleToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MntTransactionConsoleToolStripMenuItem.Tag = ""
        Me.MntTransactionConsoleToolStripMenuItem.Text = "Transaction Console"
        '
        'MntTransactionApprovalToolStripMenuItem
        '
        Me.MntTransactionApprovalToolStripMenuItem.Name = "MntTransactionApprovalToolStripMenuItem"
        Me.MntTransactionApprovalToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MntTransactionApprovalToolStripMenuItem.Text = "Transaction Approval"
        '
        'MntMachineScheduleToolStripMenuItem
        '
        Me.MntMachineScheduleToolStripMenuItem.Name = "MntMachineScheduleToolStripMenuItem"
        Me.MntMachineScheduleToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MntMachineScheduleToolStripMenuItem.Text = "Machine PM Schedule"
        '
        'MntJigScheduleToolStripMenuItem
        '
        Me.MntJigScheduleToolStripMenuItem.Name = "MntJigScheduleToolStripMenuItem"
        Me.MntJigScheduleToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MntJigScheduleToolStripMenuItem.Text = "Jig PM Schedule"
        '
        'FileToolStripSeparator
        '
        Me.FileToolStripSeparator.Name = "FileToolStripSeparator"
        Me.FileToolStripSeparator.Size = New System.Drawing.Size(189, 6)
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.LogOutToolStripMenuItem.Text = "Log Out"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MntActivityReportToolStripMenuItem, Me.MntPmReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ReportsToolStripMenuItem.Text = "Report"
        '
        'MntActivityReportToolStripMenuItem
        '
        Me.MntActivityReportToolStripMenuItem.Name = "MntActivityReportToolStripMenuItem"
        Me.MntActivityReportToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MntActivityReportToolStripMenuItem.Text = "Activity Report"
        '
        'MntPmReportToolStripMenuItem
        '
        Me.MntPmReportToolStripMenuItem.Name = "MntPmReportToolStripMenuItem"
        Me.MntPmReportToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MntPmReportToolStripMenuItem.Text = "PM Report"
        Me.MntPmReportToolStripMenuItem.Visible = False
        '
        'MaintenanceToolStripMenuItem
        '
        Me.MaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MntMachineToolStripMenuItem, Me.MntMachinePartsToolStripMenuItem, Me.MntProcessAreaToolStripMenuItem, Me.MntProcessAreaSeparator, Me.MntJigToolStripMenuItem, Me.MntJigModelToolStripMenuItem, Me.MntModelExtensionToolStripMenuItem, Me.MntModelExtensionSeparator, Me.SecUserToolStripMenuItem})
        Me.MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem"
        Me.MaintenanceToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.MaintenanceToolStripMenuItem.Text = "Maintenance"
        '
        'MntMachineToolStripMenuItem
        '
        Me.MntMachineToolStripMenuItem.Name = "MntMachineToolStripMenuItem"
        Me.MntMachineToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MntMachineToolStripMenuItem.Text = "Machine"
        '
        'MntMachinePartsToolStripMenuItem
        '
        Me.MntMachinePartsToolStripMenuItem.Name = "MntMachinePartsToolStripMenuItem"
        Me.MntMachinePartsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MntMachinePartsToolStripMenuItem.Text = "Machine Parts"
        Me.MntMachinePartsToolStripMenuItem.Visible = False
        '
        'MntProcessAreaToolStripMenuItem
        '
        Me.MntProcessAreaToolStripMenuItem.Name = "MntProcessAreaToolStripMenuItem"
        Me.MntProcessAreaToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MntProcessAreaToolStripMenuItem.Text = "Process / Area"
        Me.MntProcessAreaToolStripMenuItem.Visible = False
        '
        'MntProcessAreaSeparator
        '
        Me.MntProcessAreaSeparator.Name = "MntProcessAreaSeparator"
        Me.MntProcessAreaSeparator.Size = New System.Drawing.Size(177, 6)
        Me.MntProcessAreaSeparator.Visible = False
        '
        'MntJigToolStripMenuItem
        '
        Me.MntJigToolStripMenuItem.Name = "MntJigToolStripMenuItem"
        Me.MntJigToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MntJigToolStripMenuItem.Text = "Jig"
        '
        'MntJigModelToolStripMenuItem
        '
        Me.MntJigModelToolStripMenuItem.Name = "MntJigModelToolStripMenuItem"
        Me.MntJigModelToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MntJigModelToolStripMenuItem.Text = "Jig Model"
        Me.MntJigModelToolStripMenuItem.Visible = False
        '
        'MntModelExtensionToolStripMenuItem
        '
        Me.MntModelExtensionToolStripMenuItem.Name = "MntModelExtensionToolStripMenuItem"
        Me.MntModelExtensionToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MntModelExtensionToolStripMenuItem.Text = "Model Extension"
        Me.MntModelExtensionToolStripMenuItem.Visible = False
        '
        'MntModelExtensionSeparator
        '
        Me.MntModelExtensionSeparator.Name = "MntModelExtensionSeparator"
        Me.MntModelExtensionSeparator.Size = New System.Drawing.Size(177, 6)
        Me.MntModelExtensionSeparator.Visible = False
        '
        'SecUserToolStripMenuItem
        '
        Me.SecUserToolStripMenuItem.Name = "SecUserToolStripMenuItem"
        Me.SecUserToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SecUserToolStripMenuItem.Text = "User Profile"
        Me.SecUserToolStripMenuItem.Visible = False
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'stsMain
        '
        Me.stsMain.BackColor = System.Drawing.Color.White
        Me.stsMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.stsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DepartmentToolStripStatusLabel, Me.SectionToolStripStatusLabel, Me.VersionToolStripStatusLabel})
        Me.stsMain.Location = New System.Drawing.Point(0, 237)
        Me.stsMain.Name = "stsMain"
        Me.stsMain.Size = New System.Drawing.Size(684, 24)
        Me.stsMain.SizingGrip = False
        Me.stsMain.TabIndex = 2
        '
        'DepartmentToolStripStatusLabel
        '
        Me.DepartmentToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.DepartmentToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.DepartmentToolStripStatusLabel.Name = "DepartmentToolStripStatusLabel"
        Me.DepartmentToolStripStatusLabel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.DepartmentToolStripStatusLabel.Size = New System.Drawing.Size(79, 19)
        Me.DepartmentToolStripStatusLabel.Text = "Department"
        Me.DepartmentToolStripStatusLabel.ToolTipText = "Department"
        '
        'SectionToolStripStatusLabel
        '
        Me.SectionToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.SectionToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.SectionToolStripStatusLabel.Name = "SectionToolStripStatusLabel"
        Me.SectionToolStripStatusLabel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.SectionToolStripStatusLabel.Size = New System.Drawing.Size(55, 19)
        Me.SectionToolStripStatusLabel.Text = "Section"
        Me.SectionToolStripStatusLabel.ToolTipText = "Workgroup"
        '
        'VersionToolStripStatusLabel
        '
        Me.VersionToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.VersionToolStripStatusLabel.Name = "VersionToolStripStatusLabel"
        Me.VersionToolStripStatusLabel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.VersionToolStripStatusLabel.Size = New System.Drawing.Size(50, 19)
        Me.VersionToolStripStatusLabel.Text = "Version"
        Me.VersionToolStripStatusLabel.ToolTipText = "System Version"
        '
        'tmrMain
        '
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(684, 261)
        Me.Controls.Add(Me.stsMain)
        Me.Controls.Add(Me.mnuMain)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Machine Monitoring System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.stsMain.ResumeLayout(False)
        Me.stsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents stsMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tmrMain As System.Windows.Forms.Timer
    Friend WithEvents UsernameToolStripMenuItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents UserItemToolStripMenuItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DatetimeToolStripMenuItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DepartmentToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SectionToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntTransactionConsoleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntTransactionApprovalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LogOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntActivityReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntMachineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntMachinePartsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntProcessAreaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntProcessAreaSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MntJigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntJigModelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntModelExtensionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntModelExtensionSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SecUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VersionToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MntMachineScheduleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MntJigScheduleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MntPmReportToolStripMenuItem As ToolStripMenuItem
End Class
