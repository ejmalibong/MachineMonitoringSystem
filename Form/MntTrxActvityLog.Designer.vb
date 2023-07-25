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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.btnClear = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.cmbPart = New SergeUtils.EasyCompletionComboBox()
        Me.lblActivityLog = New System.Windows.Forms.Label()
        Me.lblActualStock = New System.Windows.Forms.Label()
        Me.txtActualStock = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.Label()
        Me.btnAdd = New PinkieControls.ButtonXP()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.dgvPartDetail = New System.Windows.Forms.DataGridView()
        Me.ColPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCreatedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblPartDescription = New System.Windows.Forms.Label()
        Me.txtPartDescription = New System.Windows.Forms.Label()
        Me.txtElapsedTime = New System.Windows.Forms.Label()
        Me.lblElapsedTime = New System.Windows.Forms.Label()
        Me.txtOrderingPoint = New System.Windows.Forms.Label()
        Me.lblOrderingPoint = New System.Windows.Forms.Label()
        Me.lblStockOut = New System.Windows.Forms.Label()
        Me.lblItemQty1 = New System.Windows.Forms.Label()
        Me.lblQty2 = New System.Windows.Forms.Label()
        Me.cmbPartSelection = New System.Windows.Forms.ComboBox()
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
        Me.dtpTo.TabIndex = 3
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
        Me.rdNight.TabIndex = 3
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
        Me.rdDay.TabIndex = 2
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
        Me.lblPartIssuance.Text = "Parts Issuance"
        Me.lblPartIssuance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClear.DefaultScheme = False
        Me.btnClear.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnClear.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnClear.Hint = "Clear"
        Me.btnClear.Location = New System.Drawing.Point(1082, 27)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClear.Size = New System.Drawing.Size(30, 27)
        Me.btnClear.TabIndex = 579
        Me.btnClear.TabStop = False
        Me.btnClear.Text = "X"
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
        Me.btnClose.Location = New System.Drawing.Point(1021, 344)
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
        Me.btnDelete.Location = New System.Drawing.Point(927, 344)
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
        Me.btnCancel.Location = New System.Drawing.Point(833, 344)
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
        Me.btnSave.Location = New System.Drawing.Point(739, 344)
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
        Me.cmbPart.Size = New System.Drawing.Size(601, 25)
        Me.cmbPart.TabIndex = 590
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
        'lblActualStock
        '
        Me.lblActualStock.BackColor = System.Drawing.SystemColors.Control
        Me.lblActualStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActualStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblActualStock.ForeColor = System.Drawing.Color.Black
        Me.lblActualStock.Location = New System.Drawing.Point(552, 82)
        Me.lblActualStock.Name = "lblActualStock"
        Me.lblActualStock.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblActualStock.Size = New System.Drawing.Size(90, 25)
        Me.lblActualStock.TabIndex = 593
        Me.lblActualStock.Text = "Actual Stock"
        Me.lblActualStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtActualStock
        '
        Me.txtActualStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtActualStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualStock.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtActualStock.ForeColor = System.Drawing.Color.Black
        Me.txtActualStock.Location = New System.Drawing.Point(641, 82)
        Me.txtActualStock.Name = "txtActualStock"
        Me.txtActualStock.Size = New System.Drawing.Size(80, 25)
        Me.txtActualStock.TabIndex = 592
        Me.txtActualStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtActualStock.UseCompatibleTextRendering = True
        '
        'lblQty
        '
        Me.lblQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblQty.ForeColor = System.Drawing.Color.Black
        Me.lblQty.Location = New System.Drawing.Point(360, 82)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblQty.Size = New System.Drawing.Size(120, 25)
        Me.lblQty.TabIndex = 595
        Me.lblQty.Text = "Quantity"
        Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQty
        '
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQty.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtQty.Location = New System.Drawing.Point(479, 82)
        Me.txtQty.MaxLength = 15
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(70, 25)
        Me.txtQty.TabIndex = 596
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblUnit
        '
        Me.lblUnit.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnit.ForeColor = System.Drawing.Color.Black
        Me.lblUnit.Location = New System.Drawing.Point(906, 82)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblUnit.Size = New System.Drawing.Size(50, 25)
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
        Me.txtUnit.Location = New System.Drawing.Point(955, 82)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(156, 25)
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
        Me.btnAdd.Location = New System.Drawing.Point(930, 109)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(90, 32)
        Me.btnAdd.TabIndex = 601
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
        Me.btnRemove.Location = New System.Drawing.Point(1022, 109)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove.Size = New System.Drawing.Size(90, 32)
        Me.btnRemove.TabIndex = 602
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
        Me.dgvPartDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPartId, Me.ColCreatedDate, Me.ColQty})
        Me.dgvPartDetail.Location = New System.Drawing.Point(3, 186)
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
        'ColCreatedDate
        '
        Me.ColCreatedDate.DataPropertyName = "CreatedDate"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColCreatedDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColCreatedDate.HeaderText = "Date Issued"
        Me.ColCreatedDate.Name = "ColCreatedDate"
        Me.ColCreatedDate.ReadOnly = True
        Me.ColCreatedDate.Width = 120
        '
        'ColQty
        '
        Me.ColQty.DataPropertyName = "Qty"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColQty.DefaultCellStyle = DataGridViewCellStyle3
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
        'txtOrderingPoint
        '
        Me.txtOrderingPoint.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtOrderingPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderingPoint.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtOrderingPoint.ForeColor = System.Drawing.Color.Black
        Me.txtOrderingPoint.Location = New System.Drawing.Point(823, 82)
        Me.txtOrderingPoint.Name = "txtOrderingPoint"
        Me.txtOrderingPoint.Size = New System.Drawing.Size(80, 25)
        Me.txtOrderingPoint.TabIndex = 599
        Me.txtOrderingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtOrderingPoint.UseCompatibleTextRendering = True
        '
        'lblOrderingPoint
        '
        Me.lblOrderingPoint.BackColor = System.Drawing.SystemColors.Control
        Me.lblOrderingPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrderingPoint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblOrderingPoint.ForeColor = System.Drawing.Color.Black
        Me.lblOrderingPoint.Location = New System.Drawing.Point(724, 82)
        Me.lblOrderingPoint.Name = "lblOrderingPoint"
        Me.lblOrderingPoint.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblOrderingPoint.Size = New System.Drawing.Size(100, 25)
        Me.lblOrderingPoint.TabIndex = 600
        Me.lblOrderingPoint.Text = "Ordering Point"
        Me.lblOrderingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStockOut
        '
        Me.lblStockOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStockOut.BackColor = System.Drawing.SystemColors.Control
        Me.lblStockOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStockOut.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStockOut.ForeColor = System.Drawing.Color.Black
        Me.lblStockOut.Location = New System.Drawing.Point(3, 163)
        Me.lblStockOut.Name = "lblStockOut"
        Me.lblStockOut.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblStockOut.Size = New System.Drawing.Size(1108, 24)
        Me.lblStockOut.TabIndex = 616
        Me.lblStockOut.Text = "Stock Out"
        Me.lblStockOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblItemQty1
        '
        Me.lblItemQty1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblItemQty1.AutoSize = True
        Me.lblItemQty1.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblItemQty1.Location = New System.Drawing.Point(4, 353)
        Me.lblItemQty1.Name = "lblItemQty1"
        Me.lblItemQty1.Size = New System.Drawing.Size(60, 17)
        Me.lblItemQty1.TabIndex = 617
        Me.lblItemQty1.Text = "Item Qty:"
        '
        'lblQty2
        '
        Me.lblQty2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblQty2.AutoSize = True
        Me.lblQty2.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblQty2.Location = New System.Drawing.Point(65, 353)
        Me.lblQty2.Name = "lblQty2"
        Me.lblQty2.Size = New System.Drawing.Size(15, 17)
        Me.lblQty2.TabIndex = 618
        Me.lblQty2.Text = "0"
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
        'MntTrxActvityLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1114, 379)
        Me.Controls.Add(Me.cmbPart)
        Me.Controls.Add(Me.cmbPartSelection)
        Me.Controls.Add(Me.lblQty2)
        Me.Controls.Add(Me.lblItemQty1)
        Me.Controls.Add(Me.lblStockOut)
        Me.Controls.Add(Me.lblElapsedTime)
        Me.Controls.Add(Me.txtElapsedTime)
        Me.Controls.Add(Me.txtPartDescription)
        Me.Controls.Add(Me.lblPartDescription)
        Me.Controls.Add(Me.dgvPartDetail)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblOrderingPoint)
        Me.Controls.Add(Me.txtOrderingPoint)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.lblQty)
        Me.Controls.Add(Me.lblActualStock)
        Me.Controls.Add(Me.txtActualStock)
        Me.Controls.Add(Me.lblActivityLog)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClear)
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
    Friend WithEvents btnClear As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents cmbPart As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblActivityLog As Label
    Friend WithEvents lblActualStock As Label
    Public WithEvents txtActualStock As Label
    Friend WithEvents lblQty As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents lblUnit As Label
    Public WithEvents txtUnit As Label
    Friend WithEvents btnAdd As PinkieControls.ButtonXP
    Friend WithEvents btnRemove As PinkieControls.ButtonXP
    Friend WithEvents lblPartDescription As Label
    Public WithEvents txtPartDescription As Label
    Friend WithEvents txtElapsedTime As Label
    Friend WithEvents lblElapsedTime As Label
    Public WithEvents txtOrderingPoint As Label
    Friend WithEvents lblOrderingPoint As Label
    Public WithEvents dgvPartDetail As DataGridView
    Public WithEvents rdNight As RadioButton
    Public WithEvents rdDay As RadioButton
    Friend WithEvents lblStockOut As Label
    Friend WithEvents lblItemQty1 As Label
    Friend WithEvents lblQty2 As Label
    Friend WithEvents ColPartId As DataGridViewTextBoxColumn
    Friend WithEvents ColCreatedDate As DataGridViewTextBoxColumn
    Friend WithEvents ColQty As DataGridViewTextBoxColumn
    Friend WithEvents cmbPartSelection As ComboBox
End Class
