<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.DatetimeToolStripMenuItem = New System.Windows.Forms.ToolStripLabel()
        Me.UserItemToolStripMenuItem = New System.Windows.Forms.ToolStripLabel()
        Me.UsernameToolStripMenuItem = New System.Windows.Forms.ToolStripLabel()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntTransactionConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntTransactionApprovalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacTransactionConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacTransactionApprovalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntActivityReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacActivityReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterlistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntMachineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntMachinePartsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntProcessAreaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MntJigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntJigModelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MntModelExtensionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatetimeToolStripMenuItem, Me.UserItemToolStripMenuItem, Me.UsernameToolStripMenuItem, Me.FileToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.MasterlistToolStripMenuItem, Me.WindowToolStripMenuItem})
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MntTransactionConsoleToolStripMenuItem, Me.MntTransactionApprovalToolStripMenuItem, Me.FacTransactionConsoleToolStripMenuItem, Me.FacTransactionApprovalToolStripMenuItem, Me.FileToolStripSeparator, Me.LogOutToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'MntTransactionConsoleToolStripMenuItem
        '
        Me.MntTransactionConsoleToolStripMenuItem.Name = "MntTransactionConsoleToolStripMenuItem"
        Me.MntTransactionConsoleToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.MntTransactionConsoleToolStripMenuItem.Tag = ""
        Me.MntTransactionConsoleToolStripMenuItem.Text = "Transaction Console"
        '
        'MntTransactionApprovalToolStripMenuItem
        '
        Me.MntTransactionApprovalToolStripMenuItem.Name = "MntTransactionApprovalToolStripMenuItem"
        Me.MntTransactionApprovalToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.MntTransactionApprovalToolStripMenuItem.Text = "Transaction Approval"
        '
        'FacTransactionConsoleToolStripMenuItem
        '
        Me.FacTransactionConsoleToolStripMenuItem.Name = "FacTransactionConsoleToolStripMenuItem"
        Me.FacTransactionConsoleToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.FacTransactionConsoleToolStripMenuItem.Text = "Transaction Console"
        '
        'FacTransactionApprovalToolStripMenuItem
        '
        Me.FacTransactionApprovalToolStripMenuItem.Name = "FacTransactionApprovalToolStripMenuItem"
        Me.FacTransactionApprovalToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.FacTransactionApprovalToolStripMenuItem.Text = "Transaction Approval"
        '
        'FileToolStripSeparator
        '
        Me.FileToolStripSeparator.Name = "FileToolStripSeparator"
        Me.FileToolStripSeparator.Size = New System.Drawing.Size(182, 6)
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.LogOutToolStripMenuItem.Text = "Log Out"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MntActivityReportToolStripMenuItem, Me.FacActivityReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'MntActivityReportToolStripMenuItem
        '
        Me.MntActivityReportToolStripMenuItem.Name = "MntActivityReportToolStripMenuItem"
        Me.MntActivityReportToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MntActivityReportToolStripMenuItem.Text = "Activity Report"
        '
        'FacActivityReportToolStripMenuItem
        '
        Me.FacActivityReportToolStripMenuItem.Name = "FacActivityReportToolStripMenuItem"
        Me.FacActivityReportToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FacActivityReportToolStripMenuItem.Text = "Activity Report"
        '
        'MasterlistToolStripMenuItem
        '
        Me.MasterlistToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MntMachineToolStripMenuItem, Me.MntMachinePartsToolStripMenuItem, Me.MntProcessAreaToolStripMenuItem, Me.MasterToolStripSeparator1, Me.MntJigToolStripMenuItem, Me.MntJigModelToolStripMenuItem, Me.MntModelExtensionToolStripMenuItem, Me.MasterToolStripSeparator2, Me.SecUserToolStripMenuItem})
        Me.MasterlistToolStripMenuItem.Name = "MasterlistToolStripMenuItem"
        Me.MasterlistToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.MasterlistToolStripMenuItem.Text = "Masterlist"
        '
        'MntMachineToolStripMenuItem
        '
        Me.MntMachineToolStripMenuItem.Name = "MntMachineToolStripMenuItem"
        Me.MntMachineToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.MntMachineToolStripMenuItem.Text = "Machine"
        '
        'MntMachinePartsToolStripMenuItem
        '
        Me.MntMachinePartsToolStripMenuItem.Name = "MntMachinePartsToolStripMenuItem"
        Me.MntMachinePartsToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.MntMachinePartsToolStripMenuItem.Text = "Machine Parts"
        '
        'MntProcessAreaToolStripMenuItem
        '
        Me.MntProcessAreaToolStripMenuItem.Name = "MntProcessAreaToolStripMenuItem"
        Me.MntProcessAreaToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.MntProcessAreaToolStripMenuItem.Text = "Process / Area"
        '
        'MasterToolStripSeparator1
        '
        Me.MasterToolStripSeparator1.Name = "MasterToolStripSeparator1"
        Me.MasterToolStripSeparator1.Size = New System.Drawing.Size(159, 6)
        '
        'MntJigToolStripMenuItem
        '
        Me.MntJigToolStripMenuItem.Name = "MntJigToolStripMenuItem"
        Me.MntJigToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.MntJigToolStripMenuItem.Text = "Jig"
        '
        'MntJigModelToolStripMenuItem
        '
        Me.MntJigModelToolStripMenuItem.Name = "MntJigModelToolStripMenuItem"
        Me.MntJigModelToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.MntJigModelToolStripMenuItem.Text = "Jig Model"
        '
        'MntModelExtensionToolStripMenuItem
        '
        Me.MntModelExtensionToolStripMenuItem.Name = "MntModelExtensionToolStripMenuItem"
        Me.MntModelExtensionToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.MntModelExtensionToolStripMenuItem.Text = "Model Extension"
        '
        'MasterToolStripSeparator2
        '
        Me.MasterToolStripSeparator2.Name = "MasterToolStripSeparator2"
        Me.MasterToolStripSeparator2.Size = New System.Drawing.Size(159, 6)
        '
        'SecUserToolStripMenuItem
        '
        Me.SecUserToolStripMenuItem.Name = "SecUserToolStripMenuItem"
        Me.SecUserToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
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
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(684, 261)
        Me.Controls.Add(Me.stsMain)
        Me.Controls.Add(Me.mnuMain)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "frmMain"
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
    Friend WithEvents MasterlistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntTransactionConsoleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntTransactionApprovalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacTransactionConsoleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacTransactionApprovalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LogOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntActivityReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacActivityReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntMachineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntMachinePartsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntProcessAreaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MntJigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntJigModelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MntModelExtensionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SecUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VersionToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
End Class
