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
        Me.FacTransactionConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacActivtyApprovalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacMachineScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssFileFa = New System.Windows.Forms.ToolStripSeparator()
        Me.MntTransactionConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntActivtyApprovalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntMachineScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntJigScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssFileMt = New System.Windows.Forms.ToolStripSeparator()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacActivityReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssReport = New System.Windows.Forms.ToolStripSeparator()
        Me.MntActivityReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntMchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntMchPartsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntMchChecksheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntAreaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssMaintenance1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MntJigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntJigChecksheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntJigModelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntModelExtensionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssMaintenance2 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacTransactionConsoleToolStripMenuItem, Me.FacActivtyApprovalToolStripMenuItem, Me.FacMachineScheduleToolStripMenuItem, Me.tssFileFa, Me.MntTransactionConsoleToolStripMenuItem, Me.MntActivtyApprovalToolStripMenuItem, Me.MntMachineScheduleToolStripMenuItem, Me.MntJigScheduleToolStripMenuItem, Me.tssFileMt, Me.LogOutToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'FacTransactionConsoleToolStripMenuItem
        '
        Me.FacTransactionConsoleToolStripMenuItem.Name = "FacTransactionConsoleToolStripMenuItem"
        Me.FacTransactionConsoleToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.FacTransactionConsoleToolStripMenuItem.Tag = "FA"
        Me.FacTransactionConsoleToolStripMenuItem.Text = "Activity Console"
        '
        'FacActivtyApprovalToolStripMenuItem
        '
        Me.FacActivtyApprovalToolStripMenuItem.Name = "FacActivtyApprovalToolStripMenuItem"
        Me.FacActivtyApprovalToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.FacActivtyApprovalToolStripMenuItem.Tag = "FA"
        Me.FacActivtyApprovalToolStripMenuItem.Text = "Activity Approval"
        Me.FacActivtyApprovalToolStripMenuItem.Visible = False
        '
        'FacMachineScheduleToolStripMenuItem
        '
        Me.FacMachineScheduleToolStripMenuItem.Name = "FacMachineScheduleToolStripMenuItem"
        Me.FacMachineScheduleToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.FacMachineScheduleToolStripMenuItem.Tag = "FA"
        Me.FacMachineScheduleToolStripMenuItem.Text = "Machine PM Schedule"
        '
        'tssFileFa
        '
        Me.tssFileFa.Name = "tssFileFa"
        Me.tssFileFa.Size = New System.Drawing.Size(189, 6)
        Me.tssFileFa.Tag = "FA"
        '
        'MntTransactionConsoleToolStripMenuItem
        '
        Me.MntTransactionConsoleToolStripMenuItem.Name = "MntTransactionConsoleToolStripMenuItem"
        Me.MntTransactionConsoleToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MntTransactionConsoleToolStripMenuItem.Tag = "MT"
        Me.MntTransactionConsoleToolStripMenuItem.Text = "Activity Console"
        '
        'MntActivtyApprovalToolStripMenuItem
        '
        Me.MntActivtyApprovalToolStripMenuItem.Name = "MntActivtyApprovalToolStripMenuItem"
        Me.MntActivtyApprovalToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MntActivtyApprovalToolStripMenuItem.Tag = "MT"
        Me.MntActivtyApprovalToolStripMenuItem.Text = "Activity Approval"
        Me.MntActivtyApprovalToolStripMenuItem.Visible = False
        '
        'MntMachineScheduleToolStripMenuItem
        '
        Me.MntMachineScheduleToolStripMenuItem.Name = "MntMachineScheduleToolStripMenuItem"
        Me.MntMachineScheduleToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MntMachineScheduleToolStripMenuItem.Tag = "MT"
        Me.MntMachineScheduleToolStripMenuItem.Text = "Machine PM Schedule"
        '
        'MntJigScheduleToolStripMenuItem
        '
        Me.MntJigScheduleToolStripMenuItem.Name = "MntJigScheduleToolStripMenuItem"
        Me.MntJigScheduleToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MntJigScheduleToolStripMenuItem.Tag = "MT"
        Me.MntJigScheduleToolStripMenuItem.Text = "Jig PM Schedule"
        '
        'tssFileMt
        '
        Me.tssFileMt.Name = "tssFileMt"
        Me.tssFileMt.Size = New System.Drawing.Size(189, 6)
        Me.tssFileMt.Tag = "MT"
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.LogOutToolStripMenuItem.Tag = "GE"
        Me.LogOutToolStripMenuItem.Text = "Log Out"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ExitToolStripMenuItem.Tag = "GE"
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacActivityReportToolStripMenuItem, Me.tssReport, Me.MntActivityReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ReportsToolStripMenuItem.Text = "Report"
        '
        'FacActivityReportToolStripMenuItem
        '
        Me.FacActivityReportToolStripMenuItem.Name = "FacActivityReportToolStripMenuItem"
        Me.FacActivityReportToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.FacActivityReportToolStripMenuItem.Tag = "FA"
        Me.FacActivityReportToolStripMenuItem.Text = "Activity Report"
        '
        'tssReport
        '
        Me.tssReport.Name = "tssReport"
        Me.tssReport.Size = New System.Drawing.Size(177, 6)
        Me.tssReport.Tag = "MT"
        '
        'MntActivityReportToolStripMenuItem
        '
        Me.MntActivityReportToolStripMenuItem.Name = "MntActivityReportToolStripMenuItem"
        Me.MntActivityReportToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MntActivityReportToolStripMenuItem.Tag = "MT"
        Me.MntActivityReportToolStripMenuItem.Text = "Activity Report"
        '
        'MaintenanceToolStripMenuItem
        '
        Me.MaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MntMchToolStripMenuItem, Me.MntMchPartsToolStripMenuItem, Me.MntMchChecksheetToolStripMenuItem, Me.MntAreaToolStripMenuItem, Me.tssMaintenance1, Me.MntJigToolStripMenuItem, Me.MntJigChecksheetToolStripMenuItem, Me.MntJigModelToolStripMenuItem, Me.MntModelExtensionToolStripMenuItem, Me.tssMaintenance2, Me.SecUserToolStripMenuItem})
        Me.MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem"
        Me.MaintenanceToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.MaintenanceToolStripMenuItem.Text = "Maintenance"
        '
        'MntMchToolStripMenuItem
        '
        Me.MntMchToolStripMenuItem.AccessibleName = ""
        Me.MntMchToolStripMenuItem.Name = "MntMchToolStripMenuItem"
        Me.MntMchToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.MntMchToolStripMenuItem.Tag = "MT"
        Me.MntMchToolStripMenuItem.Text = "Machine"
        '
        'MntMchPartsToolStripMenuItem
        '
        Me.MntMchPartsToolStripMenuItem.Name = "MntMchPartsToolStripMenuItem"
        Me.MntMchPartsToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.MntMchPartsToolStripMenuItem.Tag = "MT"
        Me.MntMchPartsToolStripMenuItem.Text = "Machine Parts"
        Me.MntMchPartsToolStripMenuItem.Visible = False
        '
        'MntMchChecksheetToolStripMenuItem
        '
        Me.MntMchChecksheetToolStripMenuItem.Name = "MntMchChecksheetToolStripMenuItem"
        Me.MntMchChecksheetToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.MntMchChecksheetToolStripMenuItem.Tag = "MT"
        Me.MntMchChecksheetToolStripMenuItem.Text = "Machine Checksheet"
        '
        'MntAreaToolStripMenuItem
        '
        Me.MntAreaToolStripMenuItem.Name = "MntAreaToolStripMenuItem"
        Me.MntAreaToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.MntAreaToolStripMenuItem.Tag = "MT"
        Me.MntAreaToolStripMenuItem.Text = "Area"
        Me.MntAreaToolStripMenuItem.Visible = False
        '
        'tssMaintenance1
        '
        Me.tssMaintenance1.Name = "tssMaintenance1"
        Me.tssMaintenance1.Size = New System.Drawing.Size(181, 6)
        Me.tssMaintenance1.Tag = "MT"
        '
        'MntJigToolStripMenuItem
        '
        Me.MntJigToolStripMenuItem.Name = "MntJigToolStripMenuItem"
        Me.MntJigToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.MntJigToolStripMenuItem.Tag = "MT"
        Me.MntJigToolStripMenuItem.Text = "Jig"
        '
        'MntJigChecksheetToolStripMenuItem
        '
        Me.MntJigChecksheetToolStripMenuItem.Name = "MntJigChecksheetToolStripMenuItem"
        Me.MntJigChecksheetToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.MntJigChecksheetToolStripMenuItem.Tag = "MT"
        Me.MntJigChecksheetToolStripMenuItem.Text = "Jig Checksheet"
        '
        'MntJigModelToolStripMenuItem
        '
        Me.MntJigModelToolStripMenuItem.Name = "MntJigModelToolStripMenuItem"
        Me.MntJigModelToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.MntJigModelToolStripMenuItem.Tag = "MT"
        Me.MntJigModelToolStripMenuItem.Text = "Model"
        '
        'MntModelExtensionToolStripMenuItem
        '
        Me.MntModelExtensionToolStripMenuItem.Name = "MntModelExtensionToolStripMenuItem"
        Me.MntModelExtensionToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.MntModelExtensionToolStripMenuItem.Tag = "MT"
        Me.MntModelExtensionToolStripMenuItem.Text = "Extension"
        '
        'tssMaintenance2
        '
        Me.tssMaintenance2.Name = "tssMaintenance2"
        Me.tssMaintenance2.Size = New System.Drawing.Size(181, 6)
        Me.tssMaintenance2.Tag = "MT"
        '
        'SecUserToolStripMenuItem
        '
        Me.SecUserToolStripMenuItem.Name = "SecUserToolStripMenuItem"
        Me.SecUserToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.SecUserToolStripMenuItem.Tag = "AD"
        Me.SecUserToolStripMenuItem.Text = "User"
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
    Friend WithEvents MntActivtyApprovalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tssFileMt As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LogOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntActivityReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntMchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntMchPartsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntAreaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tssMaintenance1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MntJigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntJigModelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntModelExtensionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tssMaintenance2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SecUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VersionToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MntMachineScheduleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MntJigScheduleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MntMchChecksheetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MntJigChecksheetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacTransactionConsoleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacActivtyApprovalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacMachineScheduleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tssFileFa As ToolStripSeparator
    Friend WithEvents FacActivityReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tssReport As ToolStripSeparator
End Class
