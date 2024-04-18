<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MntTrxActvityLog
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.grpShift = New System.Windows.Forms.GroupBox()
        Me.rdNight = New System.Windows.Forms.RadioButton()
        Me.rdDay = New System.Windows.Forms.RadioButton()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblTechnician = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.cmbTechnician = New SergeUtils.EasyCompletionComboBox()
        Me.lblPartIssuance = New System.Windows.Forms.Label()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.cmbPart = New SergeUtils.EasyCompletionComboBox()
        Me.lblActivityLog = New System.Windows.Forms.Label()
        Me.lblIssuedQty = New System.Windows.Forms.Label()
        Me.txtIssuedQty = New System.Windows.Forms.Label()
        Me.lblConsumedQty = New System.Windows.Forms.Label()
        Me.txtConsumedQty = New System.Windows.Forms.TextBox()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.Label()
        Me.btnAdd = New PinkieControls.ButtonXP()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.dgvPartDetail = New System.Windows.Forms.DataGridView()
        Me.ColPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblPartDescription = New System.Windows.Forms.Label()
        Me.txtPartDescription = New System.Windows.Forms.Label()
        Me.txtElapsedTime = New System.Windows.Forms.Label()
        Me.lblElapsedTime = New System.Windows.Forms.Label()
        Me.txtRemainingQty = New System.Windows.Forms.Label()
        Me.lblRemainingQty = New System.Windows.Forms.Label()
        Me.lblItemList = New System.Windows.Forms.Label()
        Me.cmbPartSelection = New System.Windows.Forms.ComboBox()
        Me.txtIssuedDate = New System.Windows.Forms.Label()
        Me.lblIssuedBy = New System.Windows.Forms.Label()
        Me.txtIssuedBy = New System.Windows.Forms.Label()
        Me.lblIssuedDate = New System.Windows.Forms.Label()
        Me.grpShift.SuspendLayout()
        CType(Me.dgvPartDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "MMMM dd, yyyy  -  hh:mm tt"
        Me.dtpFrom.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(122, 82)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(235, 25)
        Me.dtpFrom.TabIndex = 2
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "MMMM dd, yyyy  -  hh:mm tt"
        Me.dtpTo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(122, 109)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(235, 25)
        Me.dtpTo.TabIndex = 2
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.SystemColors.Control
        Me.lblShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblShift.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblShift.ForeColor = System.Drawing.Color.Black
        Me.lblShift.Location = New System.Drawing.Point(3, 55)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblShift.Size = New System.Drawing.Size(120, 25)
        Me.lblShift.TabIndex = 13
        Me.lblShift.Text = " Shift"
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpShift
        '
        Me.grpShift.Controls.Add(Me.rdNight)
        Me.grpShift.Controls.Add(Me.rdDay)
        Me.grpShift.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.grpShift.Location = New System.Drawing.Point(122, 47)
        Me.grpShift.Name = "grpShift"
        Me.grpShift.Size = New System.Drawing.Size(235, 34)
        Me.grpShift.TabIndex = 1
        Me.grpShift.TabStop = False
        '
        'rdNight
        '
        Me.rdNight.AutoSize = True
        Me.rdNight.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.rdNight.Location = New System.Drawing.Point(123, 10)
        Me.rdNight.Name = "rdNight"
        Me.rdNight.Size = New System.Drawing.Size(87, 21)
        Me.rdNight.TabIndex = 1
        Me.rdNight.TabStop = True
        Me.rdNight.Text = "Night Shift"
        Me.rdNight.UseVisualStyleBackColor = True
        '
        'rdDay
        '
        Me.rdDay.AutoSize = True
        Me.rdDay.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.rdDay.Location = New System.Drawing.Point(24, 10)
        Me.rdDay.Name = "rdDay"
        Me.rdDay.Size = New System.Drawing.Size(77, 21)
        Me.rdDay.TabIndex = 0
        Me.rdDay.TabStop = True
        Me.rdDay.Text = "Day Shift"
        Me.rdDay.UseVisualStyleBackColor = True
        '
        'lblFrom
        '
        Me.lblFrom.BackColor = System.Drawing.SystemColors.Control
        Me.lblFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFrom.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFrom.ForeColor = System.Drawing.Color.Black
        Me.lblFrom.Location = New System.Drawing.Point(3, 82)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblFrom.Size = New System.Drawing.Size(120, 25)
        Me.lblFrom.TabIndex = 12
        Me.lblFrom.Text = " From"
        Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTechnician
        '
        Me.lblTechnician.BackColor = System.Drawing.SystemColors.Control
        Me.lblTechnician.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTechnician.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTechnician.ForeColor = System.Drawing.Color.Black
        Me.lblTechnician.Location = New System.Drawing.Point(3, 28)
        Me.lblTechnician.Name = "lblTechnician"
        Me.lblTechnician.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblTechnician.Size = New System.Drawing.Size(120, 25)
        Me.lblTechnician.TabIndex = 14
        Me.lblTechnician.Text = " Technician"
        Me.lblTechnician.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTo
        '
        Me.lblTo.BackColor = System.Drawing.SystemColors.Control
        Me.lblTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTo.ForeColor = System.Drawing.Color.Black
        Me.lblTo.Location = New System.Drawing.Point(3, 109)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblTo.Size = New System.Drawing.Size(120, 25)
        Me.lblTo.TabIndex = 11
        Me.lblTo.Text = " To"
        Me.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTechnician
        '
        Me.cmbTechnician.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbTechnician.FormattingEnabled = True
        Me.cmbTechnician.Location = New System.Drawing.Point(122, 28)
        Me.cmbTechnician.Name = "cmbTechnician"
        Me.cmbTechnician.Size = New System.Drawing.Size(235, 25)
        Me.cmbTechnician.TabIndex = 0
        '
        'lblPartIssuance
        '
        Me.lblPartIssuance.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartIssuance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartIssuance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPartIssuance.ForeColor = System.Drawing.Color.Black
        Me.lblPartIssuance.Location = New System.Drawing.Point(360, 2)
        Me.lblPartIssuance.Name = "lblPartIssuance"
        Me.lblPartIssuance.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblPartIssuance.Size = New System.Drawing.Size(751, 24)
        Me.lblPartIssuance.TabIndex = 565
        Me.lblPartIssuance.Text = "Parts Consumption Log"
        Me.lblPartIssuance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.CausesValidation = False
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(1021, 351)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 589
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = False
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnDelete.Hint = "Delete record"
        Me.btnDelete.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Erase_16_x_16
        Me.btnDelete.Location = New System.Drawing.Point(927, 351)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 588
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.DefaultScheme = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnCancel.Hint = "Cancel changes"
        Me.btnCancel.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Undo_16_x_16
        Me.btnCancel.Location = New System.Drawing.Point(833, 351)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(90, 32)
        Me.btnCancel.TabIndex = 587
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.DefaultScheme = False
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnSave.Hint = "Save record"
        Me.btnSave.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Save_16_x_16
        Me.btnSave.Location = New System.Drawing.Point(739, 351)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 586
        Me.btnSave.TabStop = False
        Me.btnSave.Text = " Save"
        '
        'cmbPart
        '
        Me.cmbPart.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPart.FormattingEnabled = True
        Me.cmbPart.Location = New System.Drawing.Point(479, 28)
        Me.cmbPart.Name = "cmbPart"
        Me.cmbPart.Size = New System.Drawing.Size(632, 25)
        Me.cmbPart.TabIndex = 3
        '
        'lblActivityLog
        '
        Me.lblActivityLog.BackColor = System.Drawing.SystemColors.Control
        Me.lblActivityLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActivityLog.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblActivityLog.ForeColor = System.Drawing.Color.Black
        Me.lblActivityLog.Location = New System.Drawing.Point(3, 2)
        Me.lblActivityLog.Name = "lblActivityLog"
        Me.lblActivityLog.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblActivityLog.Size = New System.Drawing.Size(354, 24)
        Me.lblActivityLog.TabIndex = 591
        Me.lblActivityLog.Text = "Activity Log"
        Me.lblActivityLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIssuedQty
        '
        Me.lblIssuedQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblIssuedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIssuedQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIssuedQty.ForeColor = System.Drawing.Color.Black
        Me.lblIssuedQty.Location = New System.Drawing.Point(360, 82)
        Me.lblIssuedQty.Name = "lblIssuedQty"
        Me.lblIssuedQty.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblIssuedQty.Size = New System.Drawing.Size(120, 25)
        Me.lblIssuedQty.TabIndex = 593
        Me.lblIssuedQty.Text = "Total Issued Qty"
        Me.lblIssuedQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIssuedQty
        '
        Me.txtIssuedQty.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtIssuedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIssuedQty.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtIssuedQty.ForeColor = System.Drawing.Color.Black
        Me.txtIssuedQty.Location = New System.Drawing.Point(479, 82)
        Me.txtIssuedQty.Name = "txtIssuedQty"
        Me.txtIssuedQty.Size = New System.Drawing.Size(100, 25)
        Me.txtIssuedQty.TabIndex = 592
        Me.txtIssuedQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtIssuedQty.UseCompatibleTextRendering = True
        '
        'lblConsumedQty
        '
        Me.lblConsumedQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblConsumedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblConsumedQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblConsumedQty.ForeColor = System.Drawing.Color.Black
        Me.lblConsumedQty.Location = New System.Drawing.Point(360, 109)
        Me.lblConsumedQty.Name = "lblConsumedQty"
        Me.lblConsumedQty.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblConsumedQty.Size = New System.Drawing.Size(120, 25)
        Me.lblConsumedQty.TabIndex = 595
        Me.lblConsumedQty.Text = "Consumed Qty"
        Me.lblConsumedQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtConsumedQty
        '
        Me.txtConsumedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConsumedQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConsumedQty.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtConsumedQty.Location = New System.Drawing.Point(479, 109)
        Me.txtConsumedQty.MaxLength = 15
        Me.txtConsumedQty.Name = "txtConsumedQty"
        Me.txtConsumedQty.Size = New System.Drawing.Size(100, 25)
        Me.txtConsumedQty.TabIndex = 4
        Me.txtConsumedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblUnit
        '
        Me.lblUnit.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnit.ForeColor = System.Drawing.Color.Black
        Me.lblUnit.Location = New System.Drawing.Point(844, 82)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblUnit.Size = New System.Drawing.Size(71, 25)
        Me.lblUnit.TabIndex = 598
        Me.lblUnit.Text = "UOM"
        Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnit
        '
        Me.txtUnit.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtUnit.ForeColor = System.Drawing.Color.Black
        Me.txtUnit.Location = New System.Drawing.Point(913, 82)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(198, 25)
        Me.txtUnit.TabIndex = 597
        Me.txtUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtUnit.UseCompatibleTextRendering = True
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdd.DefaultScheme = False
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnAdd.Hint = ""
        Me.btnAdd.Location = New System.Drawing.Point(930, 136)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(90, 32)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.TabStop = False
        Me.btnAdd.Text = "Add"
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemove.DefaultScheme = False
        Me.btnRemove.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnRemove.Hint = "Remove selected items"
        Me.btnRemove.Location = New System.Drawing.Point(1022, 136)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove.Size = New System.Drawing.Size(90, 32)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.TabStop = False
        Me.btnRemove.Text = "Remove"
        '
        'dgvPartDetail
        '
        Me.dgvPartDetail.AllowUserToAddRows = False
        Me.dgvPartDetail.AllowUserToDeleteRows = False
        Me.dgvPartDetail.AllowUserToResizeColumns = False
        Me.dgvPartDetail.AllowUserToResizeRows = False
        Me.dgvPartDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPartDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPartDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPartId, Me.ColQty})
        Me.dgvPartDetail.Location = New System.Drawing.Point(3, 193)
        Me.dgvPartDetail.MultiSelect = False
        Me.dgvPartDetail.Name = "dgvPartDetail"
        Me.dgvPartDetail.ReadOnly = True
        Me.dgvPartDetail.RowHeadersVisible = False
        Me.dgvPartDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPartDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartDetail.Size = New System.Drawing.Size(1108, 150)
        Me.dgvPartDetail.TabIndex = 603
        Me.dgvPartDetail.TabStop = False
        '
        'ColPartId
        '
        Me.ColPartId.DataPropertyName = "PartId"
        Me.ColPartId.HeaderText = "Part ID"
        Me.ColPartId.Name = "ColPartId"
        Me.ColPartId.ReadOnly = True
        Me.ColPartId.Visible = False
        '
        'ColQty
        '
        Me.ColQty.DataPropertyName = "Qty"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColQty.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColQty.HeaderText = "Qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.ReadOnly = True
        Me.ColQty.Width = 60
        '
        'lblPartDescription
        '
        Me.lblPartDescription.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPartDescription.ForeColor = System.Drawing.Color.Black
        Me.lblPartDescription.Location = New System.Drawing.Point(360, 55)
        Me.lblPartDescription.Name = "lblPartDescription"
        Me.lblPartDescription.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblPartDescription.Size = New System.Drawing.Size(120, 25)
        Me.lblPartDescription.TabIndex = 604
        Me.lblPartDescription.Text = "Part Name"
        Me.lblPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartDescription
        '
        Me.txtPartDescription.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartDescription.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtPartDescription.ForeColor = System.Drawing.Color.Black
        Me.txtPartDescription.Location = New System.Drawing.Point(479, 55)
        Me.txtPartDescription.Name = "txtPartDescription"
        Me.txtPartDescription.Size = New System.Drawing.Size(632, 25)
        Me.txtPartDescription.TabIndex = 605
        Me.txtPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtPartDescription.UseCompatibleTextRendering = True
        '
        'txtElapsedTime
        '
        Me.txtElapsedTime.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtElapsedTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtElapsedTime.Location = New System.Drawing.Point(122, 136)
        Me.txtElapsedTime.Name = "txtElapsedTime"
        Me.txtElapsedTime.Size = New System.Drawing.Size(235, 25)
        Me.txtElapsedTime.TabIndex = 614
        Me.txtElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblElapsedTime
        '
        Me.lblElapsedTime.BackColor = System.Drawing.SystemColors.Control
        Me.lblElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblElapsedTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblElapsedTime.Location = New System.Drawing.Point(3, 136)
        Me.lblElapsedTime.Name = "lblElapsedTime"
        Me.lblElapsedTime.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblElapsedTime.Size = New System.Drawing.Size(120, 25)
        Me.lblElapsedTime.TabIndex = 615
        Me.lblElapsedTime.Text = "Elapsed Time"
        Me.lblElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRemainingQty
        '
        Me.txtRemainingQty.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtRemainingQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemainingQty.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtRemainingQty.ForeColor = System.Drawing.Color.Black
        Me.txtRemainingQty.Location = New System.Drawing.Point(681, 82)
        Me.txtRemainingQty.Name = "txtRemainingQty"
        Me.txtRemainingQty.Size = New System.Drawing.Size(160, 25)
        Me.txtRemainingQty.TabIndex = 599
        Me.txtRemainingQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtRemainingQty.UseCompatibleTextRendering = True
        '
        'lblRemainingQty
        '
        Me.lblRemainingQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemainingQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemainingQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRemainingQty.ForeColor = System.Drawing.Color.Black
        Me.lblRemainingQty.Location = New System.Drawing.Point(582, 82)
        Me.lblRemainingQty.Name = "lblRemainingQty"
        Me.lblRemainingQty.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblRemainingQty.Size = New System.Drawing.Size(100, 25)
        Me.lblRemainingQty.TabIndex = 600
        Me.lblRemainingQty.Text = "Remaining Qty"
        Me.lblRemainingQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItemList
        '
        Me.lblItemList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblItemList.BackColor = System.Drawing.SystemColors.Control
        Me.lblItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblItemList.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblItemList.ForeColor = System.Drawing.Color.Black
        Me.lblItemList.Location = New System.Drawing.Point(3, 170)
        Me.lblItemList.Name = "lblItemList"
        Me.lblItemList.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblItemList.Size = New System.Drawing.Size(1108, 24)
        Me.lblItemList.TabIndex = 616
        Me.lblItemList.Text = "Item List"
        Me.lblItemList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPartSelection
        '
        Me.cmbPartSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPartSelection.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbPartSelection.FormattingEnabled = True
        Me.cmbPartSelection.Location = New System.Drawing.Point(360, 28)
        Me.cmbPartSelection.Name = "cmbPartSelection"
        Me.cmbPartSelection.Size = New System.Drawing.Size(120, 25)
        Me.cmbPartSelection.TabIndex = 619
        '
        'txtIssuedDate
        '
        Me.txtIssuedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIssuedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtIssuedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIssuedDate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtIssuedDate.ForeColor = System.Drawing.Color.Black
        Me.txtIssuedDate.Location = New System.Drawing.Point(681, 109)
        Me.txtIssuedDate.Name = "txtIssuedDate"
        Me.txtIssuedDate.Size = New System.Drawing.Size(160, 25)
        Me.txtIssuedDate.TabIndex = 643
        Me.txtIssuedDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtIssuedDate.UseCompatibleTextRendering = True
        '
        'lblIssuedBy
        '
        Me.lblIssuedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIssuedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblIssuedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIssuedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIssuedBy.ForeColor = System.Drawing.Color.Black
        Me.lblIssuedBy.Location = New System.Drawing.Point(844, 109)
        Me.lblIssuedBy.Name = "lblIssuedBy"
        Me.lblIssuedBy.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblIssuedBy.Size = New System.Drawing.Size(71, 25)
        Me.lblIssuedBy.TabIndex = 642
        Me.lblIssuedBy.Text = "Issued By"
        Me.lblIssuedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIssuedBy
        '
        Me.txtIssuedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIssuedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtIssuedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIssuedBy.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtIssuedBy.ForeColor = System.Drawing.Color.Black
        Me.txtIssuedBy.Location = New System.Drawing.Point(913, 109)
        Me.txtIssuedBy.Name = "txtIssuedBy"
        Me.txtIssuedBy.Size = New System.Drawing.Size(198, 25)
        Me.txtIssuedBy.TabIndex = 645
        Me.txtIssuedBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtIssuedBy.UseCompatibleTextRendering = True
        '
        'lblIssuedDate
        '
        Me.lblIssuedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIssuedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblIssuedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIssuedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIssuedDate.ForeColor = System.Drawing.Color.Black
        Me.lblIssuedDate.Location = New System.Drawing.Point(582, 109)
        Me.lblIssuedDate.Name = "lblIssuedDate"
        Me.lblIssuedDate.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblIssuedDate.Size = New System.Drawing.Size(100, 25)
        Me.lblIssuedDate.TabIndex = 644
        Me.lblIssuedDate.Text = "Issued Date"
        Me.lblIssuedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MntTrxActvityLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1114, 386)
        Me.Controls.Add(Me.txtIssuedBy)
        Me.Controls.Add(Me.lblIssuedDate)
        Me.Controls.Add(Me.txtIssuedDate)
        Me.Controls.Add(Me.lblIssuedBy)
        Me.Controls.Add(Me.cmbPart)
        Me.Controls.Add(Me.cmbPartSelection)
        Me.Controls.Add(Me.lblItemList)
        Me.Controls.Add(Me.lblElapsedTime)
        Me.Controls.Add(Me.txtElapsedTime)
        Me.Controls.Add(Me.txtPartDescription)
        Me.Controls.Add(Me.lblPartDescription)
        Me.Controls.Add(Me.dgvPartDetail)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblRemainingQty)
        Me.Controls.Add(Me.txtRemainingQty)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.txtConsumedQty)
        Me.Controls.Add(Me.lblConsumedQty)
        Me.Controls.Add(Me.lblIssuedQty)
        Me.Controls.Add(Me.txtIssuedQty)
        Me.Controls.Add(Me.lblActivityLog)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblPartIssuance)
        Me.Controls.Add(Me.lblTechnician)
        Me.Controls.Add(Me.cmbTechnician)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblShift)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.grpShift)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntTrxActvityLog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.grpShift.ResumeLayout(False)
        Me.grpShift.PerformLayout()
        CType(Me.dgvPartDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents lblTechnician As System.Windows.Forms.Label
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Public WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Public WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Public WithEvents grpShift As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTechnician As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblPartIssuance As Label
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents cmbPart As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblActivityLog As Label
    Friend WithEvents lblIssuedQty As Label
    Public WithEvents txtIssuedQty As Label
    Friend WithEvents lblConsumedQty As Label
    Friend WithEvents txtConsumedQty As TextBox
    Friend WithEvents lblUnit As Label
    Public WithEvents txtUnit As Label
    Friend WithEvents btnAdd As PinkieControls.ButtonXP
    Friend WithEvents btnRemove As PinkieControls.ButtonXP
    Friend WithEvents lblPartDescription As Label
    Public WithEvents txtPartDescription As Label
    Friend WithEvents txtElapsedTime As Label
    Friend WithEvents lblElapsedTime As Label
    Public WithEvents txtRemainingQty As Label
    Friend WithEvents lblRemainingQty As Label
    Public WithEvents dgvPartDetail As DataGridView
    Public WithEvents rdNight As RadioButton
    Public WithEvents rdDay As RadioButton
    Friend WithEvents lblItemList As Label
    Friend WithEvents cmbPartSelection As ComboBox
    Public WithEvents txtIssuedDate As Label
    Friend WithEvents lblIssuedBy As Label
    Public WithEvents txtIssuedBy As Label
    Friend WithEvents lblIssuedDate As Label
    Friend WithEvents ColPartId As DataGridViewTextBoxColumn
    Friend WithEvents ColQty As DataGridViewTextBoxColumn
End Class
