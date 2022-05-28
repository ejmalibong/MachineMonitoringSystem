<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MntActivityReport
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
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.cmbUserName = New SergeUtils.EasyCompletionComboBox()
        Me.cmbArea = New SergeUtils.EasyCompletionComboBox()
        Me.cmbJigDowntimeStatus = New System.Windows.Forms.ComboBox()
        Me.lblJigDowntimeStatus = New System.Windows.Forms.Label()
        Me.lblJig = New System.Windows.Forms.Label()
        Me.cmbJig = New SergeUtils.EasyCompletionComboBox()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.cmbMachine = New SergeUtils.EasyCompletionComboBox()
        Me.btnReset = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnGenerate = New PinkieControls.ButtonXP()
        Me.lblTransactionStatus = New System.Windows.Forms.Label()
        Me.cmbTransactionStatus = New System.Windows.Forms.ComboBox()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.cmbMachineDowntimeStatus = New System.Windows.Forms.ComboBox()
        Me.lblMachineDowntimeStatus = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.grpShift = New System.Windows.Forms.GroupBox()
        Me.rdBoth = New System.Windows.Forms.RadioButton()
        Me.rdDay = New System.Windows.Forms.RadioButton()
        Me.rdNight = New System.Windows.Forms.RadioButton()
        Me.rptViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.pnlLeft.SuspendLayout()
        Me.grpShift.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.cmbUserName)
        Me.pnlLeft.Controls.Add(Me.cmbArea)
        Me.pnlLeft.Controls.Add(Me.cmbJigDowntimeStatus)
        Me.pnlLeft.Controls.Add(Me.lblJigDowntimeStatus)
        Me.pnlLeft.Controls.Add(Me.lblJig)
        Me.pnlLeft.Controls.Add(Me.cmbJig)
        Me.pnlLeft.Controls.Add(Me.lblMachine)
        Me.pnlLeft.Controls.Add(Me.cmbMachine)
        Me.pnlLeft.Controls.Add(Me.btnReset)
        Me.pnlLeft.Controls.Add(Me.btnClose)
        Me.pnlLeft.Controls.Add(Me.btnGenerate)
        Me.pnlLeft.Controls.Add(Me.lblTransactionStatus)
        Me.pnlLeft.Controls.Add(Me.cmbTransactionStatus)
        Me.pnlLeft.Controls.Add(Me.lblArea)
        Me.pnlLeft.Controls.Add(Me.cmbMachineDowntimeStatus)
        Me.pnlLeft.Controls.Add(Me.lblMachineDowntimeStatus)
        Me.pnlLeft.Controls.Add(Me.lblShift)
        Me.pnlLeft.Controls.Add(Me.lblUserName)
        Me.pnlLeft.Controls.Add(Me.lblEndDate)
        Me.pnlLeft.Controls.Add(Me.dtpEndDate)
        Me.pnlLeft.Controls.Add(Me.lblStartDate)
        Me.pnlLeft.Controls.Add(Me.dtpStartDate)
        Me.pnlLeft.Controls.Add(Me.grpShift)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(210, 586)
        Me.pnlLeft.TabIndex = 0
        '
        'cmbUserName
        '
        Me.cmbUserName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUserName.FormattingEnabled = True
        Me.cmbUserName.Location = New System.Drawing.Point(7, 110)
        Me.cmbUserName.Name = "cmbUserName"
        Me.cmbUserName.Size = New System.Drawing.Size(196, 23)
        Me.cmbUserName.TabIndex = 2
        '
        'cmbArea
        '
        Me.cmbArea.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(7, 203)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(196, 23)
        Me.cmbArea.TabIndex = 4
        '
        'cmbJigDowntimeStatus
        '
        Me.cmbJigDowntimeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJigDowntimeStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbJigDowntimeStatus.FormattingEnabled = True
        Me.cmbJigDowntimeStatus.Location = New System.Drawing.Point(7, 379)
        Me.cmbJigDowntimeStatus.Name = "cmbJigDowntimeStatus"
        Me.cmbJigDowntimeStatus.Size = New System.Drawing.Size(196, 23)
        Me.cmbJigDowntimeStatus.TabIndex = 8
        '
        'lblJigDowntimeStatus
        '
        Me.lblJigDowntimeStatus.AutoSize = True
        Me.lblJigDowntimeStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJigDowntimeStatus.Location = New System.Drawing.Point(4, 362)
        Me.lblJigDowntimeStatus.Name = "lblJigDowntimeStatus"
        Me.lblJigDowntimeStatus.Size = New System.Drawing.Size(114, 15)
        Me.lblJigDowntimeStatus.TabIndex = 161
        Me.lblJigDowntimeStatus.Text = "Jig Downtime Status"
        '
        'lblJig
        '
        Me.lblJig.AutoSize = True
        Me.lblJig.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJig.Location = New System.Drawing.Point(4, 406)
        Me.lblJig.Name = "lblJig"
        Me.lblJig.Size = New System.Drawing.Size(56, 15)
        Me.lblJig.TabIndex = 159
        Me.lblJig.Text = "Jig Name"
        '
        'cmbJig
        '
        Me.cmbJig.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbJig.FormattingEnabled = True
        Me.cmbJig.Location = New System.Drawing.Point(7, 424)
        Me.cmbJig.Name = "cmbJig"
        Me.cmbJig.Size = New System.Drawing.Size(196, 23)
        Me.cmbJig.TabIndex = 9
        '
        'lblMachine
        '
        Me.lblMachine.AutoSize = True
        Me.lblMachine.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachine.Location = New System.Drawing.Point(4, 318)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(88, 15)
        Me.lblMachine.TabIndex = 157
        Me.lblMachine.Text = "Machine Name"
        '
        'cmbMachine
        '
        Me.cmbMachine.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMachine.FormattingEnabled = True
        Me.cmbMachine.Location = New System.Drawing.Point(7, 335)
        Me.cmbMachine.Name = "cmbMachine"
        Me.cmbMachine.Size = New System.Drawing.Size(196, 23)
        Me.cmbMachine.TabIndex = 7
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnReset.DefaultScheme = False
        Me.btnReset.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Hint = ""
        Me.btnReset.Location = New System.Drawing.Point(11, 504)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnReset.Size = New System.Drawing.Size(187, 35)
        Me.btnReset.TabIndex = 155
        Me.btnReset.TabStop = False
        Me.btnReset.Text = "Reset"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Hint = ""
        Me.btnClose.Location = New System.Drawing.Point(11, 545)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(187, 35)
        Me.btnClose.TabIndex = 154
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        '
        'btnGenerate
        '
        Me.btnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerate.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnGenerate.DefaultScheme = False
        Me.btnGenerate.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnGenerate.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Hint = ""
        Me.btnGenerate.Location = New System.Drawing.Point(11, 463)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnGenerate.Size = New System.Drawing.Size(187, 35)
        Me.btnGenerate.TabIndex = 153
        Me.btnGenerate.TabStop = False
        Me.btnGenerate.Text = "Generate"
        '
        'lblTransactionStatus
        '
        Me.lblTransactionStatus.AutoSize = True
        Me.lblTransactionStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionStatus.Location = New System.Drawing.Point(4, 230)
        Me.lblTransactionStatus.Name = "lblTransactionStatus"
        Me.lblTransactionStatus.Size = New System.Drawing.Size(102, 15)
        Me.lblTransactionStatus.TabIndex = 33
        Me.lblTransactionStatus.Text = "Transaction Status"
        '
        'cmbTransactionStatus
        '
        Me.cmbTransactionStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransactionStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTransactionStatus.FormattingEnabled = True
        Me.cmbTransactionStatus.Location = New System.Drawing.Point(7, 247)
        Me.cmbTransactionStatus.Name = "cmbTransactionStatus"
        Me.cmbTransactionStatus.Size = New System.Drawing.Size(196, 23)
        Me.cmbTransactionStatus.TabIndex = 5
        '
        'lblArea
        '
        Me.lblArea.AutoSize = True
        Me.lblArea.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArea.Location = New System.Drawing.Point(8, 186)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(31, 15)
        Me.lblArea.TabIndex = 32
        Me.lblArea.Text = "Area"
        '
        'cmbMachineDowntimeStatus
        '
        Me.cmbMachineDowntimeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMachineDowntimeStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMachineDowntimeStatus.FormattingEnabled = True
        Me.cmbMachineDowntimeStatus.Location = New System.Drawing.Point(7, 291)
        Me.cmbMachineDowntimeStatus.Name = "cmbMachineDowntimeStatus"
        Me.cmbMachineDowntimeStatus.Size = New System.Drawing.Size(196, 23)
        Me.cmbMachineDowntimeStatus.TabIndex = 6
        '
        'lblMachineDowntimeStatus
        '
        Me.lblMachineDowntimeStatus.AutoSize = True
        Me.lblMachineDowntimeStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachineDowntimeStatus.Location = New System.Drawing.Point(4, 274)
        Me.lblMachineDowntimeStatus.Name = "lblMachineDowntimeStatus"
        Me.lblMachineDowntimeStatus.Size = New System.Drawing.Size(146, 15)
        Me.lblMachineDowntimeStatus.TabIndex = 31
        Me.lblMachineDowntimeStatus.Text = "Machine Downtime Status"
        '
        'lblShift
        '
        Me.lblShift.AutoSize = True
        Me.lblShift.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.Location = New System.Drawing.Point(4, 137)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(31, 15)
        Me.lblShift.TabIndex = 29
        Me.lblShift.Text = "Shift"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(4, 93)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(63, 15)
        Me.lblUserName.TabIndex = 26
        Me.lblUserName.Text = "Technician"
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndDate.Location = New System.Drawing.Point(4, 49)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(54, 15)
        Me.lblEndDate.TabIndex = 24
        Me.lblEndDate.Text = "End Date"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "  MMMM dd, yyyy"
        Me.dtpEndDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(7, 66)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(196, 23)
        Me.dtpEndDate.TabIndex = 1
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDate.Location = New System.Drawing.Point(4, 5)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(58, 15)
        Me.lblStartDate.TabIndex = 21
        Me.lblStartDate.Text = "Start Date"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "  MMMM dd, yyyy"
        Me.dtpStartDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(7, 22)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(196, 23)
        Me.dtpStartDate.TabIndex = 0
        '
        'grpShift
        '
        Me.grpShift.Controls.Add(Me.rdBoth)
        Me.grpShift.Controls.Add(Me.rdDay)
        Me.grpShift.Controls.Add(Me.rdNight)
        Me.grpShift.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpShift.Location = New System.Drawing.Point(7, 147)
        Me.grpShift.Name = "grpShift"
        Me.grpShift.Size = New System.Drawing.Size(196, 36)
        Me.grpShift.TabIndex = 3
        Me.grpShift.TabStop = False
        Me.grpShift.UseCompatibleTextRendering = True
        '
        'rdBoth
        '
        Me.rdBoth.AutoSize = True
        Me.rdBoth.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdBoth.Location = New System.Drawing.Point(6, 12)
        Me.rdBoth.Name = "rdBoth"
        Me.rdBoth.Size = New System.Drawing.Size(50, 19)
        Me.rdBoth.TabIndex = 0
        Me.rdBoth.TabStop = True
        Me.rdBoth.Text = "Both"
        Me.rdBoth.UseVisualStyleBackColor = True
        '
        'rdDay
        '
        Me.rdDay.AutoSize = True
        Me.rdDay.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDay.Location = New System.Drawing.Point(66, 12)
        Me.rdDay.Name = "rdDay"
        Me.rdDay.Size = New System.Drawing.Size(45, 19)
        Me.rdDay.TabIndex = 1
        Me.rdDay.TabStop = True
        Me.rdDay.Text = "Day"
        Me.rdDay.UseVisualStyleBackColor = True
        '
        'rdNight
        '
        Me.rdNight.AutoSize = True
        Me.rdNight.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdNight.Location = New System.Drawing.Point(125, 12)
        Me.rdNight.Name = "rdNight"
        Me.rdNight.Size = New System.Drawing.Size(55, 19)
        Me.rdNight.TabIndex = 2
        Me.rdNight.TabStop = True
        Me.rdNight.Text = "Night"
        Me.rdNight.UseVisualStyleBackColor = True
        '
        'rptViewer
        '
        Me.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptViewer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rptViewer.Location = New System.Drawing.Point(210, 0)
        Me.rptViewer.Name = "rptViewer"
        Me.rptViewer.Size = New System.Drawing.Size(1094, 586)
        Me.rptViewer.TabIndex = 156
        Me.rptViewer.TabStop = False
        '
        'MntActivityReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(1304, 586)
        Me.Controls.Add(Me.rptViewer)
        Me.Controls.Add(Me.pnlLeft)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "MntActivityReport"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activity Report"
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlLeft.PerformLayout()
        Me.grpShift.ResumeLayout(False)
        Me.grpShift.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents lblTransactionStatus As System.Windows.Forms.Label
    Friend WithEvents cmbTransactionStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents cmbMachineDowntimeStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblMachineDowntimeStatus As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpShift As System.Windows.Forms.GroupBox
    Friend WithEvents rdBoth As System.Windows.Forms.RadioButton
    Friend WithEvents rdDay As System.Windows.Forms.RadioButton
    Friend WithEvents rdNight As System.Windows.Forms.RadioButton
    Friend WithEvents btnReset As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnGenerate As PinkieControls.ButtonXP
    Friend WithEvents rptViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents cmbMachine As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblJig As System.Windows.Forms.Label
    Friend WithEvents cmbJig As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cmbJigDowntimeStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblJigDowntimeStatus As System.Windows.Forms.Label
    Friend WithEvents cmbArea As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cmbUserName As SergeUtils.EasyCompletionComboBox
End Class
