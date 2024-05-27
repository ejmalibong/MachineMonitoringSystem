<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FacMchDetail
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
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.pnlStatus = New System.Windows.Forms.Panel()
        Me.rdInactive = New System.Windows.Forms.RadioButton()
        Me.rdActive = New System.Windows.Forms.RadioButton()
        Me.cmbArea = New SergeUtils.EasyCompletionComboBox()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.txtMachineName = New System.Windows.Forms.TextBox()
        Me.txtMachineStatus = New System.Windows.Forms.Label()
        Me.txtMachineSubStatus = New System.Windows.Forms.Label()
        Me.lblSubStatus = New System.Windows.Forms.Label()
        Me.lblPartGroup = New System.Windows.Forms.Label()
        Me.cmbPartGroup = New SergeUtils.EasyCompletionComboBox()
        Me.lblFrequency = New System.Windows.Forms.Label()
        Me.cmbFrequency = New SergeUtils.EasyCompletionComboBox()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.txtMachineCode = New System.Windows.Forms.TextBox()
        Me.lblMachineCode = New System.Windows.Forms.Label()
        Me.txtMachineDescription = New System.Windows.Forms.TextBox()
        Me.lblMachineDescription = New System.Windows.Forms.Label()
        Me.lblFloor = New System.Windows.Forms.Label()
        Me.cmbFloor = New SergeUtils.EasyCompletionComboBox()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.cmbBrand = New SergeUtils.EasyCompletionComboBox()
        Me.pnlStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(230, 321)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 12
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = False
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDelete.Hint = "Delete record"
        Me.btnDelete.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Erase_16_x_16
        Me.btnDelete.Location = New System.Drawing.Point(136, 321)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = " Delete"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.DefaultScheme = False
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSave.Hint = "Save record"
        Me.btnSave.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Save_16_x_16
        Me.btnSave.Location = New System.Drawing.Point(42, 321)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 10
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "  Save"
        '
        'lblArea
        '
        Me.lblArea.BackColor = System.Drawing.SystemColors.Control
        Me.lblArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblArea.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblArea.ForeColor = System.Drawing.Color.Black
        Me.lblArea.Location = New System.Drawing.Point(4, 79)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblArea.Size = New System.Drawing.Size(100, 23)
        Me.lblArea.TabIndex = 557
        Me.lblArea.Text = "Area"
        Me.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(4, 268)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblStatus.Size = New System.Drawing.Size(100, 23)
        Me.lblStatus.TabIndex = 559
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(4, 154)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblRemarks.Size = New System.Drawing.Size(100, 23)
        Me.lblRemarks.TabIndex = 568
        Me.lblRemarks.Text = "Remarks"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlStatus
        '
        Me.pnlStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatus.Controls.Add(Me.rdInactive)
        Me.pnlStatus.Controls.Add(Me.rdActive)
        Me.pnlStatus.Location = New System.Drawing.Point(103, 154)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(217, 23)
        Me.pnlStatus.TabIndex = 6
        '
        'rdInactive
        '
        Me.rdInactive.AutoSize = True
        Me.rdInactive.Location = New System.Drawing.Point(118, 0)
        Me.rdInactive.Name = "rdInactive"
        Me.rdInactive.Size = New System.Drawing.Size(66, 19)
        Me.rdInactive.TabIndex = 1
        Me.rdInactive.TabStop = True
        Me.rdInactive.Text = "Inactive"
        Me.rdInactive.UseVisualStyleBackColor = True
        '
        'rdActive
        '
        Me.rdActive.AutoSize = True
        Me.rdActive.Location = New System.Drawing.Point(31, 0)
        Me.rdActive.Name = "rdActive"
        Me.rdActive.Size = New System.Drawing.Size(58, 19)
        Me.rdActive.TabIndex = 0
        Me.rdActive.TabStop = True
        Me.rdActive.Text = "Active"
        Me.rdActive.UseVisualStyleBackColor = True
        '
        'cmbArea
        '
        Me.cmbArea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbArea.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(103, 79)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(217, 23)
        Me.cmbArea.TabIndex = 3
        '
        'lblMachineName
        '
        Me.lblMachineName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMachineName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMachineName.ForeColor = System.Drawing.Color.Black
        Me.lblMachineName.Location = New System.Drawing.Point(4, 4)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblMachineName.Size = New System.Drawing.Size(100, 23)
        Me.lblMachineName.TabIndex = 555
        Me.lblMachineName.Text = "Machine Name"
        Me.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMachineName
        '
        Me.txtMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineName.Location = New System.Drawing.Point(103, 4)
        Me.txtMachineName.MaxLength = 50
        Me.txtMachineName.Name = "txtMachineName"
        Me.txtMachineName.Size = New System.Drawing.Size(217, 23)
        Me.txtMachineName.TabIndex = 0
        '
        'txtMachineStatus
        '
        Me.txtMachineStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtMachineStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMachineStatus.ForeColor = System.Drawing.Color.Black
        Me.txtMachineStatus.Location = New System.Drawing.Point(103, 268)
        Me.txtMachineStatus.Name = "txtMachineStatus"
        Me.txtMachineStatus.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtMachineStatus.Size = New System.Drawing.Size(217, 23)
        Me.txtMachineStatus.TabIndex = 4
        Me.txtMachineStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtMachineStatus.UseCompatibleTextRendering = True
        '
        'txtMachineSubStatus
        '
        Me.txtMachineSubStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtMachineSubStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineSubStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMachineSubStatus.ForeColor = System.Drawing.Color.Black
        Me.txtMachineSubStatus.Location = New System.Drawing.Point(103, 293)
        Me.txtMachineSubStatus.Name = "txtMachineSubStatus"
        Me.txtMachineSubStatus.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtMachineSubStatus.Size = New System.Drawing.Size(217, 23)
        Me.txtMachineSubStatus.TabIndex = 5
        Me.txtMachineSubStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtMachineSubStatus.UseCompatibleTextRendering = True
        '
        'lblSubStatus
        '
        Me.lblSubStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblSubStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSubStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSubStatus.ForeColor = System.Drawing.Color.Black
        Me.lblSubStatus.Location = New System.Drawing.Point(4, 293)
        Me.lblSubStatus.Name = "lblSubStatus"
        Me.lblSubStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblSubStatus.Size = New System.Drawing.Size(100, 23)
        Me.lblSubStatus.TabIndex = 583
        Me.lblSubStatus.Text = "Sub-Status"
        Me.lblSubStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPartGroup
        '
        Me.lblPartGroup.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartGroup.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPartGroup.ForeColor = System.Drawing.Color.Black
        Me.lblPartGroup.Location = New System.Drawing.Point(4, 193)
        Me.lblPartGroup.Name = "lblPartGroup"
        Me.lblPartGroup.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblPartGroup.Size = New System.Drawing.Size(100, 23)
        Me.lblPartGroup.TabIndex = 586
        Me.lblPartGroup.Text = "Part Group"
        Me.lblPartGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPartGroup
        '
        Me.cmbPartGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPartGroup.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbPartGroup.FormattingEnabled = True
        Me.cmbPartGroup.Location = New System.Drawing.Point(103, 193)
        Me.cmbPartGroup.Name = "cmbPartGroup"
        Me.cmbPartGroup.Size = New System.Drawing.Size(217, 23)
        Me.cmbPartGroup.TabIndex = 7
        '
        'lblFrequency
        '
        Me.lblFrequency.BackColor = System.Drawing.SystemColors.Control
        Me.lblFrequency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFrequency.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFrequency.ForeColor = System.Drawing.Color.Black
        Me.lblFrequency.Location = New System.Drawing.Point(4, 104)
        Me.lblFrequency.Name = "lblFrequency"
        Me.lblFrequency.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblFrequency.Size = New System.Drawing.Size(100, 23)
        Me.lblFrequency.TabIndex = 589
        Me.lblFrequency.Text = "PM Frequency"
        Me.lblFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFrequency
        '
        Me.cmbFrequency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFrequency.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbFrequency.FormattingEnabled = True
        Me.cmbFrequency.Location = New System.Drawing.Point(103, 104)
        Me.cmbFrequency.Name = "cmbFrequency"
        Me.cmbFrequency.Size = New System.Drawing.Size(217, 23)
        Me.cmbFrequency.TabIndex = 4
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSerialNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSerialNumber.ForeColor = System.Drawing.Color.Black
        Me.lblSerialNumber.Location = New System.Drawing.Point(4, 129)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblSerialNumber.Size = New System.Drawing.Size(100, 23)
        Me.lblSerialNumber.TabIndex = 591
        Me.lblSerialNumber.Text = "Serial Number"
        Me.lblSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerialNumber.Location = New System.Drawing.Point(103, 129)
        Me.txtSerialNumber.MaxLength = 50
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(217, 23)
        Me.txtSerialNumber.TabIndex = 5
        '
        'txtMachineCode
        '
        Me.txtMachineCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineCode.Location = New System.Drawing.Point(103, 29)
        Me.txtMachineCode.MaxLength = 50
        Me.txtMachineCode.Name = "txtMachineCode"
        Me.txtMachineCode.Size = New System.Drawing.Size(217, 23)
        Me.txtMachineCode.TabIndex = 1
        '
        'lblMachineCode
        '
        Me.lblMachineCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblMachineCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMachineCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMachineCode.ForeColor = System.Drawing.Color.Black
        Me.lblMachineCode.Location = New System.Drawing.Point(4, 29)
        Me.lblMachineCode.Name = "lblMachineCode"
        Me.lblMachineCode.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblMachineCode.Size = New System.Drawing.Size(100, 23)
        Me.lblMachineCode.TabIndex = 593
        Me.lblMachineCode.Text = "Code"
        Me.lblMachineCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMachineDescription
        '
        Me.txtMachineDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineDescription.Location = New System.Drawing.Point(103, 54)
        Me.txtMachineDescription.MaxLength = 50
        Me.txtMachineDescription.Name = "txtMachineDescription"
        Me.txtMachineDescription.Size = New System.Drawing.Size(217, 23)
        Me.txtMachineDescription.TabIndex = 2
        '
        'lblMachineDescription
        '
        Me.lblMachineDescription.BackColor = System.Drawing.SystemColors.Control
        Me.lblMachineDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMachineDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMachineDescription.ForeColor = System.Drawing.Color.Black
        Me.lblMachineDescription.Location = New System.Drawing.Point(4, 54)
        Me.lblMachineDescription.Name = "lblMachineDescription"
        Me.lblMachineDescription.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblMachineDescription.Size = New System.Drawing.Size(100, 23)
        Me.lblMachineDescription.TabIndex = 595
        Me.lblMachineDescription.Text = "Description"
        Me.lblMachineDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFloor
        '
        Me.lblFloor.BackColor = System.Drawing.SystemColors.Control
        Me.lblFloor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFloor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFloor.ForeColor = System.Drawing.Color.Black
        Me.lblFloor.Location = New System.Drawing.Point(4, 218)
        Me.lblFloor.Name = "lblFloor"
        Me.lblFloor.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblFloor.Size = New System.Drawing.Size(100, 23)
        Me.lblFloor.TabIndex = 597
        Me.lblFloor.Text = "Floor"
        Me.lblFloor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFloor
        '
        Me.cmbFloor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFloor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbFloor.FormattingEnabled = True
        Me.cmbFloor.Location = New System.Drawing.Point(103, 218)
        Me.cmbFloor.Name = "cmbFloor"
        Me.cmbFloor.Size = New System.Drawing.Size(217, 23)
        Me.cmbFloor.TabIndex = 8
        '
        'lblBrand
        '
        Me.lblBrand.BackColor = System.Drawing.SystemColors.Control
        Me.lblBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBrand.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBrand.ForeColor = System.Drawing.Color.Black
        Me.lblBrand.Location = New System.Drawing.Point(4, 243)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblBrand.Size = New System.Drawing.Size(100, 23)
        Me.lblBrand.TabIndex = 599
        Me.lblBrand.Text = "Brand"
        Me.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbBrand
        '
        Me.cmbBrand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBrand.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbBrand.FormattingEnabled = True
        Me.cmbBrand.Location = New System.Drawing.Point(103, 243)
        Me.cmbBrand.Name = "cmbBrand"
        Me.cmbBrand.Size = New System.Drawing.Size(217, 23)
        Me.cmbBrand.TabIndex = 9
        '
        'FacMchDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(324, 357)
        Me.Controls.Add(Me.lblBrand)
        Me.Controls.Add(Me.cmbBrand)
        Me.Controls.Add(Me.lblFloor)
        Me.Controls.Add(Me.cmbFloor)
        Me.Controls.Add(Me.txtMachineDescription)
        Me.Controls.Add(Me.lblMachineDescription)
        Me.Controls.Add(Me.txtMachineCode)
        Me.Controls.Add(Me.lblMachineCode)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.lblFrequency)
        Me.Controls.Add(Me.cmbFrequency)
        Me.Controls.Add(Me.lblPartGroup)
        Me.Controls.Add(Me.cmbPartGroup)
        Me.Controls.Add(Me.txtMachineSubStatus)
        Me.Controls.Add(Me.lblSubStatus)
        Me.Controls.Add(Me.txtMachineStatus)
        Me.Controls.Add(Me.txtMachineName)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblMachineName)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.cmbArea)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FacMchDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Machine Details"
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents lblArea As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblMachineName As Label
    Friend WithEvents lblRemarks As Label
    Friend WithEvents pnlStatus As Panel
    Friend WithEvents rdInactive As RadioButton
    Friend WithEvents rdActive As RadioButton
    Friend WithEvents cmbArea As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cmbMachineName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtMachineName As TextBox
    Friend WithEvents txtMachineStatus As Label
    Friend WithEvents txtMachineSubStatus As Label
    Friend WithEvents lblSubStatus As Label
    Friend WithEvents lblPartGroup As Label
    Friend WithEvents cmbPartGroup As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblFrequency As Label
    Friend WithEvents cmbFrequency As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents txtSerialNumber As TextBox
    Friend WithEvents txtMachineCode As TextBox
    Friend WithEvents lblMachineCode As Label
    Friend WithEvents txtMachineDescription As TextBox
    Friend WithEvents lblMachineDescription As Label
    Friend WithEvents lblFloor As Label
    Friend WithEvents cmbFloor As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblBrand As Label
    Friend WithEvents cmbBrand As SergeUtils.EasyCompletionComboBox
End Class
