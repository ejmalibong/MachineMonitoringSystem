<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MntSparePartInvDetail
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.btnAdd = New PinkieControls.ButtonXP()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.dgvInventoryDetail = New System.Windows.Forms.DataGridView()
        Me.ColRecordDetailId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRecordId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCreatedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActualStockQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSystemStockQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDiscrepancyQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblCreatedDate = New System.Windows.Forms.Label()
        Me.txtCreatedDate = New System.Windows.Forms.Label()
        Me.lblItemList = New System.Windows.Forms.Label()
        Me.pnlImage = New System.Windows.Forms.Panel()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.cmbCreatedBy = New SergeUtils.EasyCompletionComboBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.lblMonthId = New System.Windows.Forms.Label()
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.txtModifiedDate = New System.Windows.Forms.Label()
        Me.lblModifiedDate = New System.Windows.Forms.Label()
        Me.txtModifiedBy = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.txtLocation = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.cmbPart = New SergeUtils.EasyCompletionComboBox()
        Me.cmbProcedure = New System.Windows.Forms.ComboBox()
        Me.txtPartDescription = New System.Windows.Forms.Label()
        Me.lblPartDescription = New System.Windows.Forms.Label()
        Me.txtActualQty = New System.Windows.Forms.TextBox()
        Me.lblActualQty = New System.Windows.Forms.Label()
        Me.btnClearAll = New PinkieControls.ButtonXP()
        Me.txtTotalSystem = New System.Windows.Forms.Label()
        Me.txtItemQty = New System.Windows.Forms.Label()
        Me.lblItemQty = New System.Windows.Forms.Label()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.txtPart = New System.Windows.Forms.TextBox()
        Me.lblSystemQty = New System.Windows.Forms.Label()
        Me.txtSystemQty = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.Label()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New System.Windows.Forms.Label()
        Me.txtTotalActual = New System.Windows.Forms.Label()
        Me.txtTotalDiscrepancy = New System.Windows.Forms.Label()
        Me.lblTotalQty = New System.Windows.Forms.Label()
        Me.btnReflect = New PinkieControls.ButtonXP()
        Me.btnSearchFilter = New PinkieControls.ButtonXP()
        Me.btnClearFilter = New PinkieControls.ButtonXP()
        Me.cmbPartSearch = New SergeUtils.EasyCompletionComboBox()
        Me.cmbPartSelection = New System.Windows.Forms.ComboBox()
        Me.btnExport = New PinkieControls.ButtonXP()
        CType(Me.dgvInventoryDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlImage.SuspendLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.btnClose.Location = New System.Drawing.Point(1010, 626)
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
        Me.btnDelete.Location = New System.Drawing.Point(916, 626)
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
        Me.btnCancel.Location = New System.Drawing.Point(822, 626)
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
        Me.btnSave.Location = New System.Drawing.Point(728, 626)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 586
        Me.btnSave.TabStop = False
        Me.btnSave.Text = " Save"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdd.DefaultScheme = False
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnAdd.Hint = ""
        Me.btnAdd.Location = New System.Drawing.Point(919, 288)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(90, 32)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Add"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemove.DefaultScheme = False
        Me.btnRemove.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnRemove.Hint = "Remove selected items"
        Me.btnRemove.Location = New System.Drawing.Point(1011, 288)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove.Size = New System.Drawing.Size(90, 32)
        Me.btnRemove.TabIndex = 8
        Me.btnRemove.Text = "Remove"
        '
        'dgvInventoryDetail
        '
        Me.dgvInventoryDetail.AllowUserToAddRows = False
        Me.dgvInventoryDetail.AllowUserToDeleteRows = False
        Me.dgvInventoryDetail.AllowUserToResizeColumns = False
        Me.dgvInventoryDetail.AllowUserToResizeRows = False
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvInventoryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvInventoryDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColRecordDetailId, Me.ColRecordId, Me.ColPartId, Me.ColCreatedDate, Me.ColActualStockQty, Me.ColSystemStockQty, Me.ColDiscrepancyQty})
        Me.dgvInventoryDetail.Location = New System.Drawing.Point(3, 345)
        Me.dgvInventoryDetail.MultiSelect = False
        Me.dgvInventoryDetail.Name = "dgvInventoryDetail"
        Me.dgvInventoryDetail.ReadOnly = True
        Me.dgvInventoryDetail.RowHeadersVisible = False
        Me.dgvInventoryDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvInventoryDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInventoryDetail.Size = New System.Drawing.Size(1097, 240)
        Me.dgvInventoryDetail.TabIndex = 603
        Me.dgvInventoryDetail.TabStop = False
        '
        'ColRecordDetailId
        '
        Me.ColRecordDetailId.DataPropertyName = "RecordDetailId"
        Me.ColRecordDetailId.HeaderText = "RecordDetailId"
        Me.ColRecordDetailId.Name = "ColRecordDetailId"
        Me.ColRecordDetailId.ReadOnly = True
        Me.ColRecordDetailId.Visible = False
        '
        'ColRecordId
        '
        Me.ColRecordId.DataPropertyName = "RecordId"
        Me.ColRecordId.HeaderText = "RecordId"
        Me.ColRecordId.Name = "ColRecordId"
        Me.ColRecordId.ReadOnly = True
        Me.ColRecordId.Visible = False
        '
        'ColPartId
        '
        Me.ColPartId.DataPropertyName = "PartId"
        Me.ColPartId.HeaderText = "PartId"
        Me.ColPartId.Name = "ColPartId"
        Me.ColPartId.ReadOnly = True
        Me.ColPartId.Visible = False
        '
        'ColCreatedDate
        '
        Me.ColCreatedDate.DataPropertyName = "CreatedDate"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColCreatedDate.DefaultCellStyle = DataGridViewCellStyle12
        Me.ColCreatedDate.HeaderText = "Created Date"
        Me.ColCreatedDate.Name = "ColCreatedDate"
        Me.ColCreatedDate.ReadOnly = True
        Me.ColCreatedDate.Width = 120
        '
        'ColActualStockQty
        '
        Me.ColActualStockQty.DataPropertyName = "ActualStockQty"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColActualStockQty.DefaultCellStyle = DataGridViewCellStyle13
        Me.ColActualStockQty.HeaderText = "Actual"
        Me.ColActualStockQty.Name = "ColActualStockQty"
        Me.ColActualStockQty.ReadOnly = True
        Me.ColActualStockQty.Width = 95
        '
        'ColSystemStockQty
        '
        Me.ColSystemStockQty.DataPropertyName = "SystemStockQty"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColSystemStockQty.DefaultCellStyle = DataGridViewCellStyle14
        Me.ColSystemStockQty.HeaderText = "System"
        Me.ColSystemStockQty.Name = "ColSystemStockQty"
        Me.ColSystemStockQty.ReadOnly = True
        Me.ColSystemStockQty.Width = 95
        '
        'ColDiscrepancyQty
        '
        Me.ColDiscrepancyQty.DataPropertyName = "DiscrepancyQty"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColDiscrepancyQty.DefaultCellStyle = DataGridViewCellStyle15
        Me.ColDiscrepancyQty.HeaderText = "Discrepancy"
        Me.ColDiscrepancyQty.Name = "ColDiscrepancyQty"
        Me.ColDiscrepancyQty.ReadOnly = True
        Me.ColDiscrepancyQty.Width = 85
        '
        'lblCreatedDate
        '
        Me.lblCreatedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCreatedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedDate.Location = New System.Drawing.Point(305, 2)
        Me.lblCreatedDate.Name = "lblCreatedDate"
        Me.lblCreatedDate.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblCreatedDate.Size = New System.Drawing.Size(120, 25)
        Me.lblCreatedDate.TabIndex = 604
        Me.lblCreatedDate.Text = "Created Date"
        Me.lblCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreatedDate
        '
        Me.txtCreatedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCreatedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedDate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedDate.Location = New System.Drawing.Point(424, 2)
        Me.txtCreatedDate.Name = "txtCreatedDate"
        Me.txtCreatedDate.Size = New System.Drawing.Size(278, 25)
        Me.txtCreatedDate.TabIndex = 605
        Me.txtCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtCreatedDate.UseCompatibleTextRendering = True
        '
        'lblItemList
        '
        Me.lblItemList.BackColor = System.Drawing.SystemColors.Control
        Me.lblItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblItemList.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblItemList.ForeColor = System.Drawing.Color.Black
        Me.lblItemList.Location = New System.Drawing.Point(3, 322)
        Me.lblItemList.Name = "lblItemList"
        Me.lblItemList.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblItemList.Size = New System.Drawing.Size(1097, 24)
        Me.lblItemList.TabIndex = 616
        Me.lblItemList.Text = "Item List"
        Me.lblItemList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlImage
        '
        Me.pnlImage.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImage.Controls.Add(Me.picImage)
        Me.pnlImage.Location = New System.Drawing.Point(3, 2)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(300, 317)
        Me.pnlImage.TabIndex = 624
        '
        'picImage
        '
        Me.picImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picImage.BackColor = System.Drawing.Color.White
        Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImage.ErrorImage = Nothing
        Me.picImage.InitialImage = Nothing
        Me.picImage.Location = New System.Drawing.Point(3, 3)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(292, 309)
        Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage.TabIndex = 0
        Me.picImage.TabStop = False
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCreatedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedBy.Location = New System.Drawing.Point(305, 29)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblCreatedBy.Size = New System.Drawing.Size(120, 25)
        Me.lblCreatedBy.TabIndex = 627
        Me.lblCreatedBy.Text = "Created By"
        Me.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCreatedBy
        '
        Me.cmbCreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCreatedBy.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCreatedBy.FormattingEnabled = True
        Me.cmbCreatedBy.Location = New System.Drawing.Point(424, 29)
        Me.cmbCreatedBy.Name = "cmbCreatedBy"
        Me.cmbCreatedBy.Size = New System.Drawing.Size(278, 25)
        Me.cmbCreatedBy.TabIndex = 0
        '
        'lblYear
        '
        Me.lblYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblYear.BackColor = System.Drawing.SystemColors.Control
        Me.lblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYear.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblYear.ForeColor = System.Drawing.Color.Black
        Me.lblYear.Location = New System.Drawing.Point(704, 56)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblYear.Size = New System.Drawing.Size(120, 25)
        Me.lblYear.TabIndex = 629
        Me.lblYear.Text = "Year"
        Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemarks
        '
        Me.lblRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(305, 83)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblRemarks.Size = New System.Drawing.Size(796, 23)
        Me.lblRemarks.TabIndex = 631
        Me.lblRemarks.Text = "Remarks"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRemarks
        '
        Me.txtRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRemarks.Location = New System.Drawing.Point(305, 105)
        Me.txtRemarks.MaxLength = 200
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(796, 73)
        Me.txtRemarks.TabIndex = 3
        '
        'lblMonthId
        '
        Me.lblMonthId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMonthId.BackColor = System.Drawing.SystemColors.Control
        Me.lblMonthId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMonthId.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMonthId.ForeColor = System.Drawing.Color.Black
        Me.lblMonthId.Location = New System.Drawing.Point(305, 56)
        Me.lblMonthId.Name = "lblMonthId"
        Me.lblMonthId.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblMonthId.Size = New System.Drawing.Size(120, 25)
        Me.lblMonthId.TabIndex = 637
        Me.lblMonthId.Text = "Month"
        Me.lblMonthId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModifiedBy
        '
        Me.lblModifiedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModifiedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedBy.Location = New System.Drawing.Point(704, 29)
        Me.lblModifiedBy.Name = "lblModifiedBy"
        Me.lblModifiedBy.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblModifiedBy.Size = New System.Drawing.Size(120, 25)
        Me.lblModifiedBy.TabIndex = 645
        Me.lblModifiedBy.Text = "Modified By"
        Me.lblModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModifiedDate
        '
        Me.txtModifiedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModifiedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedDate.Location = New System.Drawing.Point(823, 2)
        Me.txtModifiedDate.Name = "txtModifiedDate"
        Me.txtModifiedDate.Size = New System.Drawing.Size(278, 25)
        Me.txtModifiedDate.TabIndex = 644
        Me.txtModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedDate.UseCompatibleTextRendering = True
        '
        'lblModifiedDate
        '
        Me.lblModifiedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModifiedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedDate.Location = New System.Drawing.Point(704, 2)
        Me.lblModifiedDate.Name = "lblModifiedDate"
        Me.lblModifiedDate.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblModifiedDate.Size = New System.Drawing.Size(120, 25)
        Me.lblModifiedDate.TabIndex = 643
        Me.lblModifiedDate.Text = "Modified Date"
        Me.lblModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModifiedBy
        '
        Me.txtModifiedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModifiedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedBy.Location = New System.Drawing.Point(823, 29)
        Me.txtModifiedBy.Name = "txtModifiedBy"
        Me.txtModifiedBy.Size = New System.Drawing.Size(278, 25)
        Me.txtModifiedBy.TabIndex = 646
        Me.txtModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedBy.UseCompatibleTextRendering = True
        '
        'txtYear
        '
        Me.txtYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYear.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtYear.Location = New System.Drawing.Point(823, 56)
        Me.txtYear.MaxLength = 4
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(278, 25)
        Me.txtYear.TabIndex = 2
        Me.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLocation
        '
        Me.txtLocation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocation.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocation.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtLocation.ForeColor = System.Drawing.Color.Black
        Me.txtLocation.Location = New System.Drawing.Point(424, 234)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(472, 25)
        Me.txtLocation.TabIndex = 655
        Me.txtLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtLocation.UseCompatibleTextRendering = True
        '
        'lblLocation
        '
        Me.lblLocation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLocation.BackColor = System.Drawing.SystemColors.Control
        Me.lblLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLocation.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLocation.ForeColor = System.Drawing.Color.Black
        Me.lblLocation.Location = New System.Drawing.Point(305, 234)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblLocation.Size = New System.Drawing.Size(120, 25)
        Me.lblLocation.TabIndex = 654
        Me.lblLocation.Text = "Location"
        Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPart
        '
        Me.cmbPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPart.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPart.FormattingEnabled = True
        Me.cmbPart.Location = New System.Drawing.Point(424, 180)
        Me.cmbPart.Name = "cmbPart"
        Me.cmbPart.Size = New System.Drawing.Size(677, 25)
        Me.cmbPart.TabIndex = 4
        '
        'cmbProcedure
        '
        Me.cmbProcedure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbProcedure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProcedure.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbProcedure.FormattingEnabled = True
        Me.cmbProcedure.Location = New System.Drawing.Point(305, 180)
        Me.cmbProcedure.Name = "cmbProcedure"
        Me.cmbProcedure.Size = New System.Drawing.Size(120, 25)
        Me.cmbProcedure.TabIndex = 653
        '
        'txtPartDescription
        '
        Me.txtPartDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartDescription.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartDescription.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtPartDescription.ForeColor = System.Drawing.Color.Black
        Me.txtPartDescription.Location = New System.Drawing.Point(424, 207)
        Me.txtPartDescription.Name = "txtPartDescription"
        Me.txtPartDescription.Size = New System.Drawing.Size(677, 25)
        Me.txtPartDescription.TabIndex = 652
        Me.txtPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtPartDescription.UseCompatibleTextRendering = True
        '
        'lblPartDescription
        '
        Me.lblPartDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPartDescription.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPartDescription.ForeColor = System.Drawing.Color.Black
        Me.lblPartDescription.Location = New System.Drawing.Point(305, 207)
        Me.lblPartDescription.Name = "lblPartDescription"
        Me.lblPartDescription.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblPartDescription.Size = New System.Drawing.Size(120, 25)
        Me.lblPartDescription.TabIndex = 651
        Me.lblPartDescription.Text = "Part Name"
        Me.lblPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtActualQty
        '
        Me.txtActualQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtActualQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActualQty.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtActualQty.Location = New System.Drawing.Point(424, 261)
        Me.txtActualQty.Name = "txtActualQty"
        Me.txtActualQty.Size = New System.Drawing.Size(180, 25)
        Me.txtActualQty.TabIndex = 5
        '
        'lblActualQty
        '
        Me.lblActualQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActualQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblActualQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActualQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblActualQty.ForeColor = System.Drawing.Color.Black
        Me.lblActualQty.Location = New System.Drawing.Point(305, 261)
        Me.lblActualQty.Name = "lblActualQty"
        Me.lblActualQty.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblActualQty.Size = New System.Drawing.Size(120, 25)
        Me.lblActualQty.TabIndex = 650
        Me.lblActualQty.Text = "Quantity"
        Me.lblActualQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClearAll
        '
        Me.btnClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClearAll.DefaultScheme = False
        Me.btnClearAll.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnClearAll.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnClearAll.Hint = ""
        Me.btnClearAll.Location = New System.Drawing.Point(305, 288)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClearAll.Size = New System.Drawing.Size(120, 32)
        Me.btnClearAll.TabIndex = 656
        Me.btnClearAll.Text = "Clear All Items"
        '
        'txtTotalSystem
        '
        Me.txtTotalSystem.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtTotalSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalSystem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalSystem.ForeColor = System.Drawing.Color.Black
        Me.txtTotalSystem.Location = New System.Drawing.Point(921, 584)
        Me.txtTotalSystem.Name = "txtTotalSystem"
        Me.txtTotalSystem.Size = New System.Drawing.Size(95, 25)
        Me.txtTotalSystem.TabIndex = 657
        Me.txtTotalSystem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtTotalSystem.UseCompatibleTextRendering = True
        '
        'txtItemQty
        '
        Me.txtItemQty.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtItemQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemQty.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtItemQty.ForeColor = System.Drawing.Color.Black
        Me.txtItemQty.Location = New System.Drawing.Point(603, 584)
        Me.txtItemQty.Name = "txtItemQty"
        Me.txtItemQty.Size = New System.Drawing.Size(150, 25)
        Me.txtItemQty.TabIndex = 659
        Me.txtItemQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtItemQty.UseCompatibleTextRendering = True
        '
        'lblItemQty
        '
        Me.lblItemQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblItemQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblItemQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblItemQty.ForeColor = System.Drawing.Color.Black
        Me.lblItemQty.Location = New System.Drawing.Point(544, 584)
        Me.lblItemQty.Name = "lblItemQty"
        Me.lblItemQty.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblItemQty.Size = New System.Drawing.Size(60, 25)
        Me.lblItemQty.TabIndex = 658
        Me.lblItemQty.Text = "Item(s):"
        Me.lblItemQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMonth
        '
        Me.cmbMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(424, 56)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(278, 25)
        Me.cmbMonth.TabIndex = 1
        '
        'txtPart
        '
        Me.txtPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPart.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtPart.Location = New System.Drawing.Point(424, 180)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.Size = New System.Drawing.Size(677, 25)
        Me.txtPart.TabIndex = 6
        '
        'lblSystemQty
        '
        Me.lblSystemQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSystemQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblSystemQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSystemQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSystemQty.ForeColor = System.Drawing.Color.Black
        Me.lblSystemQty.Location = New System.Drawing.Point(606, 261)
        Me.lblSystemQty.Name = "lblSystemQty"
        Me.lblSystemQty.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblSystemQty.Size = New System.Drawing.Size(90, 25)
        Me.lblSystemQty.TabIndex = 663
        Me.lblSystemQty.Text = "Stock Qty"
        Me.lblSystemQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSystemQty
        '
        Me.txtSystemQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSystemQty.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtSystemQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSystemQty.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtSystemQty.ForeColor = System.Drawing.Color.Black
        Me.txtSystemQty.Location = New System.Drawing.Point(695, 261)
        Me.txtSystemQty.Name = "txtSystemQty"
        Me.txtSystemQty.Size = New System.Drawing.Size(128, 25)
        Me.txtSystemQty.TabIndex = 662
        Me.txtSystemQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtSystemQty.UseCompatibleTextRendering = True
        '
        'lblUnit
        '
        Me.lblUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUnit.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnit.ForeColor = System.Drawing.Color.Black
        Me.lblUnit.Location = New System.Drawing.Point(898, 234)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblUnit.Size = New System.Drawing.Size(50, 25)
        Me.lblUnit.TabIndex = 665
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
        Me.txtUnit.Location = New System.Drawing.Point(947, 234)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(154, 25)
        Me.txtUnit.TabIndex = 664
        Me.txtUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtUnit.UseCompatibleTextRendering = True
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUnitPrice.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnitPrice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnitPrice.ForeColor = System.Drawing.Color.Black
        Me.lblUnitPrice.Location = New System.Drawing.Point(825, 261)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblUnitPrice.Size = New System.Drawing.Size(90, 25)
        Me.lblUnitPrice.TabIndex = 667
        Me.lblUnitPrice.Text = "Unit Price"
        Me.lblUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUnitPrice.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitPrice.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtUnitPrice.ForeColor = System.Drawing.Color.Black
        Me.txtUnitPrice.Location = New System.Drawing.Point(914, 261)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(187, 25)
        Me.txtUnitPrice.TabIndex = 666
        Me.txtUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtUnitPrice.UseCompatibleTextRendering = True
        '
        'txtTotalActual
        '
        Me.txtTotalActual.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtTotalActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalActual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalActual.ForeColor = System.Drawing.Color.Black
        Me.txtTotalActual.Location = New System.Drawing.Point(827, 584)
        Me.txtTotalActual.Name = "txtTotalActual"
        Me.txtTotalActual.Size = New System.Drawing.Size(95, 25)
        Me.txtTotalActual.TabIndex = 668
        Me.txtTotalActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtTotalActual.UseCompatibleTextRendering = True
        '
        'txtTotalDiscrepancy
        '
        Me.txtTotalDiscrepancy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtTotalDiscrepancy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDiscrepancy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalDiscrepancy.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDiscrepancy.Location = New System.Drawing.Point(1015, 584)
        Me.txtTotalDiscrepancy.Name = "txtTotalDiscrepancy"
        Me.txtTotalDiscrepancy.Size = New System.Drawing.Size(85, 25)
        Me.txtTotalDiscrepancy.TabIndex = 669
        Me.txtTotalDiscrepancy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtTotalDiscrepancy.UseCompatibleTextRendering = True
        '
        'lblTotalQty
        '
        Me.lblTotalQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalQty.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTotalQty.ForeColor = System.Drawing.Color.Black
        Me.lblTotalQty.Location = New System.Drawing.Point(758, 584)
        Me.lblTotalQty.Name = "lblTotalQty"
        Me.lblTotalQty.Size = New System.Drawing.Size(70, 25)
        Me.lblTotalQty.TabIndex = 672
        Me.lblTotalQty.Text = "Total Qty"
        Me.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnReflect
        '
        Me.btnReflect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReflect.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReflect.DefaultScheme = False
        Me.btnReflect.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnReflect.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnReflect.Hint = ""
        Me.btnReflect.Location = New System.Drawing.Point(3, 626)
        Me.btnReflect.Name = "btnReflect"
        Me.btnReflect.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnReflect.Size = New System.Drawing.Size(120, 32)
        Me.btnReflect.TabIndex = 673
        Me.btnReflect.TabStop = False
        Me.btnReflect.Text = "Reflect Inventory"
        '
        'btnSearchFilter
        '
        Me.btnSearchFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchFilter.CausesValidation = False
        Me.btnSearchFilter.DefaultScheme = True
        Me.btnSearchFilter.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSearchFilter.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSearchFilter.Hint = "Search"
        Me.btnSearchFilter.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Find_16_x_16
        Me.btnSearchFilter.Location = New System.Drawing.Point(2, 583)
        Me.btnSearchFilter.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearchFilter.Name = "btnSearchFilter"
        Me.btnSearchFilter.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSearchFilter.Size = New System.Drawing.Size(30, 27)
        Me.btnSearchFilter.TabIndex = 675
        '
        'btnClearFilter
        '
        Me.btnClearFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClearFilter.CausesValidation = False
        Me.btnClearFilter.DefaultScheme = True
        Me.btnClearFilter.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnClearFilter.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClearFilter.Hint = "Search"
        Me.btnClearFilter.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Erase_16_x_16
        Me.btnClearFilter.Location = New System.Drawing.Point(32, 583)
        Me.btnClearFilter.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClearFilter.Size = New System.Drawing.Size(30, 27)
        Me.btnClearFilter.TabIndex = 677
        '
        'cmbPartSearch
        '
        Me.cmbPartSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPartSearch.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPartSearch.FormattingEnabled = True
        Me.cmbPartSearch.Location = New System.Drawing.Point(165, 584)
        Me.cmbPartSearch.Name = "cmbPartSearch"
        Me.cmbPartSearch.Size = New System.Drawing.Size(250, 25)
        Me.cmbPartSearch.TabIndex = 678
        '
        'cmbPartSelection
        '
        Me.cmbPartSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPartSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPartSelection.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbPartSelection.FormattingEnabled = True
        Me.cmbPartSelection.Location = New System.Drawing.Point(63, 584)
        Me.cmbPartSelection.Name = "cmbPartSelection"
        Me.cmbPartSelection.Size = New System.Drawing.Size(100, 25)
        Me.cmbPartSelection.TabIndex = 679
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExport.DefaultScheme = False
        Me.btnExport.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnExport.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnExport.Hint = "Export"
        Me.btnExport.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Download_16_x_16
        Me.btnExport.Location = New System.Drawing.Point(127, 626)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnExport.Size = New System.Drawing.Size(90, 32)
        Me.btnExport.TabIndex = 680
        Me.btnExport.TabStop = False
        Me.btnExport.Text = "Export"
        '
        'MntSparePartInvDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1103, 661)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnReflect)
        Me.Controls.Add(Me.dgvInventoryDetail)
        Me.Controls.Add(Me.lblTotalQty)
        Me.Controls.Add(Me.txtTotalSystem)
        Me.Controls.Add(Me.txtTotalDiscrepancy)
        Me.Controls.Add(Me.txtTotalActual)
        Me.Controls.Add(Me.txtUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.lblSystemQty)
        Me.Controls.Add(Me.txtSystemQty)
        Me.Controls.Add(Me.txtPart)
        Me.Controls.Add(Me.cmbPart)
        Me.Controls.Add(Me.cmbProcedure)
        Me.Controls.Add(Me.lblMonthId)
        Me.Controls.Add(Me.cmbMonth)
        Me.Controls.Add(Me.lblItemQty)
        Me.Controls.Add(Me.txtItemQty)
        Me.Controls.Add(Me.btnClearAll)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.txtPartDescription)
        Me.Controls.Add(Me.lblPartDescription)
        Me.Controls.Add(Me.txtActualQty)
        Me.Controls.Add(Me.lblActualQty)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.txtModifiedBy)
        Me.Controls.Add(Me.lblModifiedBy)
        Me.Controls.Add(Me.txtModifiedDate)
        Me.Controls.Add(Me.lblModifiedDate)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.cmbCreatedBy)
        Me.Controls.Add(Me.pnlImage)
        Me.Controls.Add(Me.lblItemList)
        Me.Controls.Add(Me.txtCreatedDate)
        Me.Controls.Add(Me.lblCreatedDate)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnSearchFilter)
        Me.Controls.Add(Me.btnClearFilter)
        Me.Controls.Add(Me.cmbPartSearch)
        Me.Controls.Add(Me.cmbPartSelection)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntSparePartInvDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dgvInventoryDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlImage.ResumeLayout(False)
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents btnAdd As PinkieControls.ButtonXP
    Friend WithEvents btnRemove As PinkieControls.ButtonXP
    Friend WithEvents lblCreatedDate As Label
    Public WithEvents txtCreatedDate As Label
    Public WithEvents dgvInventoryDetail As DataGridView
    Friend WithEvents lblItemList As Label
    Friend WithEvents pnlImage As Panel
    Friend WithEvents picImage As PictureBox
    Friend WithEvents lblCreatedBy As Label
    Friend WithEvents cmbCreatedBy As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblYear As Label
    Friend WithEvents lblRemarks As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents lblMonthId As Label
    Friend WithEvents lblModifiedBy As Label
    Public WithEvents txtModifiedDate As Label
    Friend WithEvents lblModifiedDate As Label
    Public WithEvents txtModifiedBy As Label
    Friend WithEvents txtYear As TextBox
    Public WithEvents txtLocation As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents cmbPart As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cmbProcedure As ComboBox
    Public WithEvents txtPartDescription As Label
    Friend WithEvents lblPartDescription As Label
    Friend WithEvents txtActualQty As TextBox
    Friend WithEvents lblActualQty As Label
    Friend WithEvents btnClearAll As PinkieControls.ButtonXP
    Public WithEvents txtTotalSystem As Label
    Public WithEvents txtItemQty As Label
    Friend WithEvents lblItemQty As Label
    Friend WithEvents cmbMonth As ComboBox
    Friend WithEvents txtPart As TextBox
    Friend WithEvents lblSystemQty As Label
    Public WithEvents txtSystemQty As Label
    Friend WithEvents lblUnit As Label
    Public WithEvents txtUnit As Label
    Friend WithEvents lblUnitPrice As Label
    Public WithEvents txtUnitPrice As Label
    Public WithEvents txtTotalActual As Label
    Public WithEvents txtTotalDiscrepancy As Label
    Friend WithEvents lblTotalQty As Label
    Friend WithEvents btnReflect As PinkieControls.ButtonXP
    Friend WithEvents ColRecordDetailId As DataGridViewTextBoxColumn
    Friend WithEvents ColRecordId As DataGridViewTextBoxColumn
    Friend WithEvents ColPartId As DataGridViewTextBoxColumn
    Friend WithEvents ColCreatedDate As DataGridViewTextBoxColumn
    Friend WithEvents ColActualStockQty As DataGridViewTextBoxColumn
    Friend WithEvents ColSystemStockQty As DataGridViewTextBoxColumn
    Friend WithEvents ColDiscrepancyQty As DataGridViewTextBoxColumn
    Friend WithEvents btnSearchFilter As PinkieControls.ButtonXP
    Friend WithEvents btnClearFilter As PinkieControls.ButtonXP
    Friend WithEvents cmbPartSearch As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cmbPartSelection As ComboBox
    Friend WithEvents btnExport As PinkieControls.ButtonXP
End Class
