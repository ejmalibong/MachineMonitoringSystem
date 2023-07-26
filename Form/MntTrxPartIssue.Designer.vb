<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MntTrxPartIssue
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
        Me.lblPartsReceiving = New System.Windows.Forms.Label()
        Me.btnClear = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.cmbPart = New SergeUtils.EasyCompletionComboBox()
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
        Me.txtOrderingPoint = New System.Windows.Forms.Label()
        Me.lblOrderingPoint = New System.Windows.Forms.Label()
        Me.lblStockIn = New System.Windows.Forms.Label()
        Me.lblItemQty1 = New System.Windows.Forms.Label()
        Me.lblQty2 = New System.Windows.Forms.Label()
        Me.pnlImage = New System.Windows.Forms.Panel()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.lblTechnician = New System.Windows.Forms.Label()
        Me.cmbTechnician = New SergeUtils.EasyCompletionComboBox()
        Me.txtReferenceNo = New System.Windows.Forms.TextBox()
        Me.lblReferenceNo = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.cmbPartSelection = New System.Windows.Forms.ComboBox()
        CType(Me.dgvPartDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlImage.SuspendLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPartsReceiving
        '
        Me.lblPartsReceiving.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPartsReceiving.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartsReceiving.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartsReceiving.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPartsReceiving.ForeColor = System.Drawing.Color.Black
        Me.lblPartsReceiving.Location = New System.Drawing.Point(3, 2)
        Me.lblPartsReceiving.Name = "lblPartsReceiving"
        Me.lblPartsReceiving.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblPartsReceiving.Size = New System.Drawing.Size(1034, 24)
        Me.lblPartsReceiving.TabIndex = 565
        Me.lblPartsReceiving.Text = "Parts Issue"
        Me.lblPartsReceiving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClear.DefaultScheme = False
        Me.btnClear.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnClear.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnClear.Hint = "Clear"
        Me.btnClear.Location = New System.Drawing.Point(1008, 54)
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
        Me.btnClose.Location = New System.Drawing.Point(947, 466)
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
        Me.btnDelete.Location = New System.Drawing.Point(853, 466)
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
        Me.btnCancel.Location = New System.Drawing.Point(759, 466)
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
        Me.btnSave.Location = New System.Drawing.Point(665, 466)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 586
        Me.btnSave.TabStop = False
        Me.btnSave.Text = " Save"
        '
        'cmbPart
        '
        Me.cmbPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPart.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPart.FormattingEnabled = True
        Me.cmbPart.Location = New System.Drawing.Point(405, 55)
        Me.cmbPart.Name = "cmbPart"
        Me.cmbPart.Size = New System.Drawing.Size(601, 25)
        Me.cmbPart.TabIndex = 1
        '
        'lblActualStock
        '
        Me.lblActualStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActualStock.BackColor = System.Drawing.SystemColors.Control
        Me.lblActualStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActualStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblActualStock.ForeColor = System.Drawing.Color.Black
        Me.lblActualStock.Location = New System.Drawing.Point(478, 109)
        Me.lblActualStock.Name = "lblActualStock"
        Me.lblActualStock.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblActualStock.Size = New System.Drawing.Size(90, 25)
        Me.lblActualStock.TabIndex = 593
        Me.lblActualStock.Text = "Actual Stock"
        Me.lblActualStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtActualStock
        '
        Me.txtActualStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtActualStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtActualStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualStock.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtActualStock.ForeColor = System.Drawing.Color.Black
        Me.txtActualStock.Location = New System.Drawing.Point(567, 109)
        Me.txtActualStock.Name = "txtActualStock"
        Me.txtActualStock.Size = New System.Drawing.Size(80, 25)
        Me.txtActualStock.TabIndex = 592
        Me.txtActualStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtActualStock.UseCompatibleTextRendering = True
        '
        'lblQty
        '
        Me.lblQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblQty.ForeColor = System.Drawing.Color.Black
        Me.lblQty.Location = New System.Drawing.Point(286, 109)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblQty.Size = New System.Drawing.Size(120, 25)
        Me.lblQty.TabIndex = 595
        Me.lblQty.Text = "Quantity"
        Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQty
        '
        Me.txtQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQty.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtQty.Location = New System.Drawing.Point(405, 109)
        Me.txtQty.MaxLength = 15
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(70, 25)
        Me.txtQty.TabIndex = 2
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblUnit
        '
        Me.lblUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUnit.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnit.ForeColor = System.Drawing.Color.Black
        Me.lblUnit.Location = New System.Drawing.Point(832, 109)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblUnit.Size = New System.Drawing.Size(50, 25)
        Me.lblUnit.TabIndex = 598
        Me.lblUnit.Text = "UOM"
        Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnit
        '
        Me.txtUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUnit.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtUnit.ForeColor = System.Drawing.Color.Black
        Me.txtUnit.Location = New System.Drawing.Point(881, 109)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(156, 25)
        Me.txtUnit.TabIndex = 597
        Me.txtUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtUnit.UseCompatibleTextRendering = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdd.DefaultScheme = False
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnAdd.Hint = ""
        Me.btnAdd.Location = New System.Drawing.Point(855, 250)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(90, 32)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemove.DefaultScheme = False
        Me.btnRemove.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnRemove.Hint = "Remove selected items"
        Me.btnRemove.Location = New System.Drawing.Point(947, 250)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove.Size = New System.Drawing.Size(90, 32)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "Remove"
        '
        'dgvPartDetail
        '
        Me.dgvPartDetail.AllowUserToAddRows = False
        Me.dgvPartDetail.AllowUserToDeleteRows = False
        Me.dgvPartDetail.AllowUserToResizeColumns = False
        Me.dgvPartDetail.AllowUserToResizeRows = False
        Me.dgvPartDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.dgvPartDetail.Location = New System.Drawing.Point(3, 308)
        Me.dgvPartDetail.MultiSelect = False
        Me.dgvPartDetail.Name = "dgvPartDetail"
        Me.dgvPartDetail.ReadOnly = True
        Me.dgvPartDetail.RowHeadersVisible = False
        Me.dgvPartDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPartDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartDetail.Size = New System.Drawing.Size(1034, 150)
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
        Me.ColCreatedDate.HeaderText = "Date Received"
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
        Me.lblPartDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPartDescription.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPartDescription.ForeColor = System.Drawing.Color.Black
        Me.lblPartDescription.Location = New System.Drawing.Point(286, 82)
        Me.lblPartDescription.Name = "lblPartDescription"
        Me.lblPartDescription.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblPartDescription.Size = New System.Drawing.Size(120, 25)
        Me.lblPartDescription.TabIndex = 604
        Me.lblPartDescription.Text = "Part Name"
        Me.lblPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartDescription
        '
        Me.txtPartDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartDescription.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartDescription.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtPartDescription.ForeColor = System.Drawing.Color.Black
        Me.txtPartDescription.Location = New System.Drawing.Point(405, 82)
        Me.txtPartDescription.Name = "txtPartDescription"
        Me.txtPartDescription.Size = New System.Drawing.Size(632, 25)
        Me.txtPartDescription.TabIndex = 605
        Me.txtPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtPartDescription.UseCompatibleTextRendering = True
        '
        'txtOrderingPoint
        '
        Me.txtOrderingPoint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrderingPoint.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtOrderingPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderingPoint.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtOrderingPoint.ForeColor = System.Drawing.Color.Black
        Me.txtOrderingPoint.Location = New System.Drawing.Point(749, 109)
        Me.txtOrderingPoint.Name = "txtOrderingPoint"
        Me.txtOrderingPoint.Size = New System.Drawing.Size(80, 25)
        Me.txtOrderingPoint.TabIndex = 599
        Me.txtOrderingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtOrderingPoint.UseCompatibleTextRendering = True
        '
        'lblOrderingPoint
        '
        Me.lblOrderingPoint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOrderingPoint.BackColor = System.Drawing.SystemColors.Control
        Me.lblOrderingPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrderingPoint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblOrderingPoint.ForeColor = System.Drawing.Color.Black
        Me.lblOrderingPoint.Location = New System.Drawing.Point(650, 109)
        Me.lblOrderingPoint.Name = "lblOrderingPoint"
        Me.lblOrderingPoint.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblOrderingPoint.Size = New System.Drawing.Size(100, 25)
        Me.lblOrderingPoint.TabIndex = 600
        Me.lblOrderingPoint.Text = "Ordering Point"
        Me.lblOrderingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStockIn
        '
        Me.lblStockIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStockIn.BackColor = System.Drawing.SystemColors.Control
        Me.lblStockIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStockIn.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStockIn.ForeColor = System.Drawing.Color.Black
        Me.lblStockIn.Location = New System.Drawing.Point(3, 285)
        Me.lblStockIn.Name = "lblStockIn"
        Me.lblStockIn.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblStockIn.Size = New System.Drawing.Size(1034, 24)
        Me.lblStockIn.TabIndex = 616
        Me.lblStockIn.Text = "Stock Out"
        Me.lblStockIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblItemQty1
        '
        Me.lblItemQty1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblItemQty1.AutoSize = True
        Me.lblItemQty1.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblItemQty1.Location = New System.Drawing.Point(4, 475)
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
        Me.lblQty2.Location = New System.Drawing.Point(65, 475)
        Me.lblQty2.Name = "lblQty2"
        Me.lblQty2.Size = New System.Drawing.Size(15, 17)
        Me.lblQty2.TabIndex = 618
        Me.lblQty2.Text = "0"
        '
        'pnlImage
        '
        Me.pnlImage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlImage.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImage.Controls.Add(Me.picImage)
        Me.pnlImage.Location = New System.Drawing.Point(3, 25)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(280, 257)
        Me.pnlImage.TabIndex = 624
        '
        'picImage
        '
        Me.picImage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picImage.BackColor = System.Drawing.Color.White
        Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImage.ErrorImage = Nothing
        Me.picImage.InitialImage = Nothing
        Me.picImage.Location = New System.Drawing.Point(3, 3)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(272, 249)
        Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage.TabIndex = 0
        Me.picImage.TabStop = False
        '
        'lblTechnician
        '
        Me.lblTechnician.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTechnician.BackColor = System.Drawing.SystemColors.Control
        Me.lblTechnician.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTechnician.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTechnician.ForeColor = System.Drawing.Color.Black
        Me.lblTechnician.Location = New System.Drawing.Point(286, 28)
        Me.lblTechnician.Name = "lblTechnician"
        Me.lblTechnician.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblTechnician.Size = New System.Drawing.Size(120, 25)
        Me.lblTechnician.TabIndex = 627
        Me.lblTechnician.Text = "Issued To"
        Me.lblTechnician.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTechnician
        '
        Me.cmbTechnician.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTechnician.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTechnician.FormattingEnabled = True
        Me.cmbTechnician.Location = New System.Drawing.Point(405, 28)
        Me.cmbTechnician.Name = "cmbTechnician"
        Me.cmbTechnician.Size = New System.Drawing.Size(632, 25)
        Me.cmbTechnician.TabIndex = 0
        '
        'txtReferenceNo
        '
        Me.txtReferenceNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenceNo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtReferenceNo.Location = New System.Drawing.Point(405, 136)
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.Size = New System.Drawing.Size(632, 25)
        Me.txtReferenceNo.TabIndex = 3
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReferenceNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReferenceNo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblReferenceNo.ForeColor = System.Drawing.Color.Black
        Me.lblReferenceNo.Location = New System.Drawing.Point(286, 136)
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblReferenceNo.Size = New System.Drawing.Size(120, 25)
        Me.lblReferenceNo.TabIndex = 629
        Me.lblReferenceNo.Text = "Reference No"
        Me.lblReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemarks
        '
        Me.lblRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(286, 163)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblRemarks.Size = New System.Drawing.Size(751, 23)
        Me.lblRemarks.TabIndex = 631
        Me.lblRemarks.Text = "Remarks"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRemarks
        '
        Me.txtRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRemarks.Location = New System.Drawing.Point(286, 185)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(751, 62)
        Me.txtRemarks.TabIndex = 4
        '
        'cmbPartSelection
        '
        Me.cmbPartSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPartSelection.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbPartSelection.FormattingEnabled = True
        Me.cmbPartSelection.Location = New System.Drawing.Point(286, 55)
        Me.cmbPartSelection.Name = "cmbPartSelection"
        Me.cmbPartSelection.Size = New System.Drawing.Size(120, 25)
        Me.cmbPartSelection.TabIndex = 632
        '
        'MntTrxPartIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1040, 501)
        Me.Controls.Add(Me.cmbPart)
        Me.Controls.Add(Me.cmbPartSelection)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.txtReferenceNo)
        Me.Controls.Add(Me.lblReferenceNo)
        Me.Controls.Add(Me.lblTechnician)
        Me.Controls.Add(Me.cmbTechnician)
        Me.Controls.Add(Me.pnlImage)
        Me.Controls.Add(Me.lblQty2)
        Me.Controls.Add(Me.lblItemQty1)
        Me.Controls.Add(Me.lblStockIn)
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
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.lblPartsReceiving)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntTrxPartIssue"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dgvPartDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlImage.ResumeLayout(False)
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPartsReceiving As Label
    Friend WithEvents btnClear As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents cmbPart As SergeUtils.EasyCompletionComboBox
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
    Public WithEvents txtOrderingPoint As Label
    Friend WithEvents lblOrderingPoint As Label
    Public WithEvents dgvPartDetail As DataGridView
    Friend WithEvents lblStockIn As Label
    Friend WithEvents lblItemQty1 As Label
    Friend WithEvents lblQty2 As Label
    Friend WithEvents pnlImage As Panel
    Friend WithEvents picImage As PictureBox
    Friend WithEvents lblTechnician As Label
    Friend WithEvents cmbTechnician As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtReferenceNo As TextBox
    Friend WithEvents lblReferenceNo As Label
    Friend WithEvents lblRemarks As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents ColPartId As DataGridViewTextBoxColumn
    Friend WithEvents ColCreatedDate As DataGridViewTextBoxColumn
    Friend WithEvents ColQty As DataGridViewTextBoxColumn
    Friend WithEvents cmbPartSelection As ComboBox
End Class
