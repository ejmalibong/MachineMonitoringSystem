<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMntActivityReport
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
        Me.btnClear = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnGenerate = New PinkieControls.ButtonXP()
        Me.lblTrxStatus = New System.Windows.Forms.Label()
        Me.cmbTrxStatus = New System.Windows.Forms.ComboBox()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.cmbTechnician = New System.Windows.Forms.ComboBox()
        Me.lblTechnician = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblTrxDate = New System.Windows.Forms.Label()
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
        Me.pnlLeft.Controls.Add(Me.btnClear)
        Me.pnlLeft.Controls.Add(Me.btnClose)
        Me.pnlLeft.Controls.Add(Me.btnGenerate)
        Me.pnlLeft.Controls.Add(Me.lblTrxStatus)
        Me.pnlLeft.Controls.Add(Me.cmbTrxStatus)
        Me.pnlLeft.Controls.Add(Me.cmbArea)
        Me.pnlLeft.Controls.Add(Me.lblProcess)
        Me.pnlLeft.Controls.Add(Me.cmbStatus)
        Me.pnlLeft.Controls.Add(Me.lblStatus)
        Me.pnlLeft.Controls.Add(Me.lblShift)
        Me.pnlLeft.Controls.Add(Me.cmbTechnician)
        Me.pnlLeft.Controls.Add(Me.lblTechnician)
        Me.pnlLeft.Controls.Add(Me.lblEndDate)
        Me.pnlLeft.Controls.Add(Me.dtpEndDate)
        Me.pnlLeft.Controls.Add(Me.lblStartDate)
        Me.pnlLeft.Controls.Add(Me.lblTrxDate)
        Me.pnlLeft.Controls.Add(Me.dtpStartDate)
        Me.pnlLeft.Controls.Add(Me.grpShift)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(210, 601)
        Me.pnlLeft.TabIndex = 0
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnClear.DefaultScheme = False
        Me.btnClear.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnClear.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnClear.Hint = ""
        Me.btnClear.Location = New System.Drawing.Point(11, 450)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClear.Size = New System.Drawing.Size(187, 35)
        Me.btnClear.TabIndex = 155
        Me.btnClear.TabStop = False
        Me.btnClear.Text = "Clear Filter"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnClose.Hint = ""
        Me.btnClose.Location = New System.Drawing.Point(11, 496)
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
        Me.btnGenerate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnGenerate.Hint = ""
        Me.btnGenerate.Location = New System.Drawing.Point(11, 405)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnGenerate.Size = New System.Drawing.Size(187, 35)
        Me.btnGenerate.TabIndex = 153
        Me.btnGenerate.TabStop = False
        Me.btnGenerate.Text = "Generate"
        '
        'lblTrxStatus
        '
        Me.lblTrxStatus.AutoSize = True
        Me.lblTrxStatus.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblTrxStatus.Location = New System.Drawing.Point(6, 315)
        Me.lblTrxStatus.Name = "lblTrxStatus"
        Me.lblTrxStatus.Size = New System.Drawing.Size(124, 14)
        Me.lblTrxStatus.TabIndex = 33
        Me.lblTrxStatus.Text = "Transaction Status"
        '
        'cmbTrxStatus
        '
        Me.cmbTrxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTrxStatus.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.cmbTrxStatus.FormattingEnabled = True
        Me.cmbTrxStatus.Location = New System.Drawing.Point(9, 332)
        Me.cmbTrxStatus.Name = "cmbTrxStatus"
        Me.cmbTrxStatus.Size = New System.Drawing.Size(191, 24)
        Me.cmbTrxStatus.TabIndex = 6
        '
        'cmbArea
        '
        Me.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArea.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(9, 286)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(191, 24)
        Me.cmbArea.TabIndex = 5
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblProcess.Location = New System.Drawing.Point(6, 269)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(98, 14)
        Me.lblProcess.TabIndex = 32
        Me.lblProcess.Text = "Process / Area"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(9, 240)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(191, 24)
        Me.cmbStatus.TabIndex = 4
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblStatus.Location = New System.Drawing.Point(6, 223)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(103, 14)
        Me.lblStatus.TabIndex = 31
        Me.lblStatus.Text = "Machine Status"
        '
        'lblShift
        '
        Me.lblShift.AutoSize = True
        Me.lblShift.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblShift.Location = New System.Drawing.Point(6, 170)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(35, 14)
        Me.lblShift.TabIndex = 29
        Me.lblShift.Text = "Shift"
        '
        'cmbTechnician
        '
        Me.cmbTechnician.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTechnician.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.cmbTechnician.FormattingEnabled = True
        Me.cmbTechnician.Location = New System.Drawing.Point(9, 143)
        Me.cmbTechnician.Name = "cmbTechnician"
        Me.cmbTechnician.Size = New System.Drawing.Size(191, 24)
        Me.cmbTechnician.TabIndex = 2
        '
        'lblTechnician
        '
        Me.lblTechnician.AutoSize = True
        Me.lblTechnician.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblTechnician.Location = New System.Drawing.Point(6, 126)
        Me.lblTechnician.Name = "lblTechnician"
        Me.lblTechnician.Size = New System.Drawing.Size(71, 14)
        Me.lblTechnician.TabIndex = 26
        Me.lblTechnician.Text = "Technician"
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblEndDate.Location = New System.Drawing.Point(20, 78)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(65, 14)
        Me.lblEndDate.TabIndex = 24
        Me.lblEndDate.Text = "End Date"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpEndDate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(9, 95)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(191, 22)
        Me.dtpEndDate.TabIndex = 1
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblStartDate.Location = New System.Drawing.Point(13, 31)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(72, 14)
        Me.lblStartDate.TabIndex = 21
        Me.lblStartDate.Text = "Start Date"
        '
        'lblTrxDate
        '
        Me.lblTrxDate.AutoSize = True
        Me.lblTrxDate.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblTrxDate.Location = New System.Drawing.Point(6, 9)
        Me.lblTrxDate.Name = "lblTrxDate"
        Me.lblTrxDate.Size = New System.Drawing.Size(113, 14)
        Me.lblTrxDate.TabIndex = 18
        Me.lblTrxDate.Text = "Transaction Date"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpStartDate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(9, 48)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(191, 22)
        Me.dtpStartDate.TabIndex = 0
        '
        'grpShift
        '
        Me.grpShift.Controls.Add(Me.rdBoth)
        Me.grpShift.Controls.Add(Me.rdDay)
        Me.grpShift.Controls.Add(Me.rdNight)
        Me.grpShift.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.grpShift.Location = New System.Drawing.Point(9, 181)
        Me.grpShift.Name = "grpShift"
        Me.grpShift.Size = New System.Drawing.Size(191, 36)
        Me.grpShift.TabIndex = 3
        Me.grpShift.TabStop = False
        Me.grpShift.UseCompatibleTextRendering = True
        '
        'rdBoth
        '
        Me.rdBoth.AutoSize = True
        Me.rdBoth.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.rdBoth.Location = New System.Drawing.Point(6, 12)
        Me.rdBoth.Name = "rdBoth"
        Me.rdBoth.Size = New System.Drawing.Size(54, 18)
        Me.rdBoth.TabIndex = 0
        Me.rdBoth.TabStop = True
        Me.rdBoth.Text = "Both"
        Me.rdBoth.UseVisualStyleBackColor = True
        '
        'rdDay
        '
        Me.rdDay.AutoSize = True
        Me.rdDay.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.rdDay.Location = New System.Drawing.Point(66, 12)
        Me.rdDay.Name = "rdDay"
        Me.rdDay.Size = New System.Drawing.Size(49, 18)
        Me.rdDay.TabIndex = 1
        Me.rdDay.TabStop = True
        Me.rdDay.Text = "Day"
        Me.rdDay.UseVisualStyleBackColor = True
        '
        'rdNight
        '
        Me.rdNight.AutoSize = True
        Me.rdNight.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.rdNight.Location = New System.Drawing.Point(125, 12)
        Me.rdNight.Name = "rdNight"
        Me.rdNight.Size = New System.Drawing.Size(58, 18)
        Me.rdNight.TabIndex = 2
        Me.rdNight.TabStop = True
        Me.rdNight.Text = "Night"
        Me.rdNight.UseVisualStyleBackColor = True
        '
        'rptViewer
        '
        Me.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptViewer.Location = New System.Drawing.Point(210, 0)
        Me.rptViewer.Name = "rptViewer"
        Me.rptViewer.Size = New System.Drawing.Size(1104, 601)
        Me.rptViewer.TabIndex = 156
        Me.rptViewer.TabStop = False
        '
        'frmMntActivityReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(1314, 601)
        Me.Controls.Add(Me.rptViewer)
        Me.Controls.Add(Me.pnlLeft)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMntActivityReport"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activity Report"
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlLeft.PerformLayout()
        Me.grpShift.ResumeLayout(False)
        Me.grpShift.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents lblTrxStatus As System.Windows.Forms.Label
    Friend WithEvents cmbTrxStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents cmbTechnician As System.Windows.Forms.ComboBox
    Friend WithEvents lblTechnician As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblTrxDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpShift As System.Windows.Forms.GroupBox
    Friend WithEvents rdBoth As System.Windows.Forms.RadioButton
    Friend WithEvents rdDay As System.Windows.Forms.RadioButton
    Friend WithEvents rdNight As System.Windows.Forms.RadioButton
    Friend WithEvents btnClear As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnGenerate As PinkieControls.ButtonXP
    Friend WithEvents rptViewer As Microsoft.Reporting.WinForms.ReportViewer
End Class
