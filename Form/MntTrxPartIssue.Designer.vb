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
        Me.lblPartsReceiving = New System.Windows.Forms.Label()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.cmbPart = New SergeUtils.EasyCompletionComboBox()
        Me.lblCurrentStock = New System.Windows.Forms.Label()
        Me.txtActualStock = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.Label()
        Me.btnAdd = New PinkieControls.ButtonXP()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.dgvPartDetail = New System.Windows.Forms.DataGridView()
        Me.ColPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblPartDescription = New System.Windows.Forms.Label()
        Me.txtPartDescription = New System.Windows.Forms.Label()
        Me.txtOrderingPoint = New System.Windows.Forms.Label()
        Me.lblOrderingPoint = New System.Windows.Forms.Label()
        Me.lblItemList = New System.Windows.Forms.Label()
        Me.pnlImage = New System.Windows.Forms.Panel()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.lblTechnician = New System.Windows.Forms.Label()
        Me.cmbTechnician = New SergeUtils.EasyCompletionComboBox()
        Me.lblReferenceNo = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.cmbPartSelection = New System.Windows.Forms.ComboBox()
        Me.lblDateReceived = New System.Windows.Forms.Label()
        Me.dtpDateReceived = New System.Windows.Forms.DateTimePicker()
        Me.txtReferenceNo = New System.Windows.Forms.TextBox()
        Me.txtLocation = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.chkFloat = New System.Windows.Forms.CheckBox()
        Me.lblFloatQty = New System.Windows.Forms.Label()
        Me.txtFloatQty = New System.Windows.Forms.Label()
        Me.btnCloseRecord = New PinkieControls.ButtonXP()
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
        Me.lblPartsReceiving.Text = "Parts Issuance Form"
        Me.lblPartsReceiving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.btnClose.Location = New System.Drawing.Point(947, 493)
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
        Me.btnDelete.Location = New System.Drawing.Point(853, 493)
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
        Me.btnCancel.Location = New System.Drawing.Point(759, 493)
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
        Me.btnSave.Location = New System.Drawing.Point(665, 493)
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
        Me.cmbPart.Location = New System.Drawing.Point(405, 82)
        Me.cmbPart.Name = "cmbPart"
        Me.cmbPart.Size = New System.Drawing.Size(632, 25)
        Me.cmbPart.TabIndex = 3
        '
        'lblCurrentStock
        '
        Me.lblCurrentStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentStock.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCurrentStock.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentStock.Location = New System.Drawing.Point(480, 163)
        Me.lblCurrentStock.Name = "lblCurrentStock"
        Me.lblCurrentStock.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblCurrentStock.Size = New System.Drawing.Size(90, 25)
        Me.lblCurrentStock.TabIndex = 593
        Me.lblCurrentStock.Text = "Current Stock"
        Me.lblCurrentStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtActualStock
        '
        Me.txtActualStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtActualStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtActualStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualStock.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtActualStock.ForeColor = System.Drawing.Color.Black
        Me.txtActualStock.Location = New System.Drawing.Point(569, 163)
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
        Me.lblQty.Location = New System.Drawing.Point(286, 163)
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
        Me.txtQty.Location = New System.Drawing.Point(405, 163)
        Me.txtQty.MaxLength = 15
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(73, 25)
        Me.txtQty.TabIndex = 4
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblUnit
        '
        Me.lblUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUnit.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnit.ForeColor = System.Drawing.Color.Black
        Me.lblUnit.Location = New System.Drawing.Point(834, 163)
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
        Me.txtUnit.Location = New System.Drawing.Point(883, 163)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(154, 25)
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
        Me.btnAdd.Location = New System.Drawing.Point(855, 277)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(90, 32)
        Me.btnAdd.TabIndex = 6
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
        Me.btnRemove.Location = New System.Drawing.Point(947, 277)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove.Size = New System.Drawing.Size(90, 32)
        Me.btnRemove.TabIndex = 7
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
        Me.dgvPartDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPartId})
        Me.dgvPartDetail.Location = New System.Drawing.Point(3, 335)
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
        'lblPartDescription
        '
        Me.lblPartDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPartDescription.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPartDescription.ForeColor = System.Drawing.Color.Black
        Me.lblPartDescription.Location = New System.Drawing.Point(286, 109)
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
        Me.txtPartDescription.Location = New System.Drawing.Point(405, 109)
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
        Me.txtOrderingPoint.Location = New System.Drawing.Point(751, 163)
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
        Me.lblOrderingPoint.Location = New System.Drawing.Point(652, 163)
        Me.lblOrderingPoint.Name = "lblOrderingPoint"
        Me.lblOrderingPoint.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblOrderingPoint.Size = New System.Drawing.Size(100, 25)
        Me.lblOrderingPoint.TabIndex = 600
        Me.lblOrderingPoint.Text = "Ordering Point"
        Me.lblOrderingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItemList
        '
        Me.lblItemList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblItemList.BackColor = System.Drawing.SystemColors.Control
        Me.lblItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblItemList.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblItemList.ForeColor = System.Drawing.Color.Black
        Me.lblItemList.Location = New System.Drawing.Point(3, 312)
        Me.lblItemList.Name = "lblItemList"
        Me.lblItemList.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblItemList.Size = New System.Drawing.Size(1034, 24)
        Me.lblItemList.TabIndex = 616
        Me.lblItemList.Text = "Item List"
        Me.lblItemList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.pnlImage.Size = New System.Drawing.Size(280, 284)
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
        Me.picImage.Size = New System.Drawing.Size(272, 276)
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
        Me.lblTechnician.Location = New System.Drawing.Point(286, 55)
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
        Me.cmbTechnician.Location = New System.Drawing.Point(405, 55)
        Me.cmbTechnician.Name = "cmbTechnician"
        Me.cmbTechnician.Size = New System.Drawing.Size(632, 25)
        Me.cmbTechnician.TabIndex = 2
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReferenceNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReferenceNo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblReferenceNo.ForeColor = System.Drawing.Color.Black
        Me.lblReferenceNo.Location = New System.Drawing.Point(563, 28)
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
        Me.lblRemarks.Location = New System.Drawing.Point(286, 190)
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
        Me.txtRemarks.Location = New System.Drawing.Point(286, 212)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(751, 62)
        Me.txtRemarks.TabIndex = 5
        '
        'cmbPartSelection
        '
        Me.cmbPartSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPartSelection.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbPartSelection.FormattingEnabled = True
        Me.cmbPartSelection.Location = New System.Drawing.Point(286, 82)
        Me.cmbPartSelection.Name = "cmbPartSelection"
        Me.cmbPartSelection.Size = New System.Drawing.Size(120, 25)
        Me.cmbPartSelection.TabIndex = 632
        '
        'lblDateReceived
        '
        Me.lblDateReceived.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDateReceived.BackColor = System.Drawing.SystemColors.Control
        Me.lblDateReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDateReceived.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDateReceived.ForeColor = System.Drawing.Color.Black
        Me.lblDateReceived.Location = New System.Drawing.Point(286, 28)
        Me.lblDateReceived.Name = "lblDateReceived"
        Me.lblDateReceived.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblDateReceived.Size = New System.Drawing.Size(120, 25)
        Me.lblDateReceived.TabIndex = 637
        Me.lblDateReceived.Text = "Date Issued"
        Me.lblDateReceived.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpDateReceived
        '
        Me.dtpDateReceived.CustomFormat = "MMMM dd, yyyy"
        Me.dtpDateReceived.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dtpDateReceived.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateReceived.Location = New System.Drawing.Point(405, 28)
        Me.dtpDateReceived.Name = "dtpDateReceived"
        Me.dtpDateReceived.Size = New System.Drawing.Size(156, 25)
        Me.dtpDateReceived.TabIndex = 0
        '
        'txtReferenceNo
        '
        Me.txtReferenceNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenceNo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtReferenceNo.Location = New System.Drawing.Point(682, 28)
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.Size = New System.Drawing.Size(355, 25)
        Me.txtReferenceNo.TabIndex = 1
        '
        'txtLocation
        '
        Me.txtLocation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocation.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocation.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtLocation.ForeColor = System.Drawing.Color.Black
        Me.txtLocation.Location = New System.Drawing.Point(405, 136)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(426, 25)
        Me.txtLocation.TabIndex = 641
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
        Me.lblLocation.Location = New System.Drawing.Point(286, 136)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblLocation.Size = New System.Drawing.Size(120, 25)
        Me.lblLocation.TabIndex = 640
        Me.lblLocation.Text = "Location"
        Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkFloat
        '
        Me.chkFloat.AutoSize = True
        Me.chkFloat.Checked = True
        Me.chkFloat.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFloat.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.chkFloat.Location = New System.Drawing.Point(289, 282)
        Me.chkFloat.Name = "chkFloat"
        Me.chkFloat.Size = New System.Drawing.Size(139, 23)
        Me.chkFloat.TabIndex = 642
        Me.chkFloat.Text = "Float Issued Items"
        Me.chkFloat.UseVisualStyleBackColor = True
        '
        'lblFloatQty
        '
        Me.lblFloatQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFloatQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblFloatQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFloatQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFloatQty.ForeColor = System.Drawing.Color.Black
        Me.lblFloatQty.Location = New System.Drawing.Point(834, 136)
        Me.lblFloatQty.Name = "lblFloatQty"
        Me.lblFloatQty.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblFloatQty.Size = New System.Drawing.Size(50, 25)
        Me.lblFloatQty.TabIndex = 645
        Me.lblFloatQty.Text = "Float"
        Me.lblFloatQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFloatQty
        '
        Me.txtFloatQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFloatQty.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtFloatQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFloatQty.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtFloatQty.ForeColor = System.Drawing.Color.Black
        Me.txtFloatQty.Location = New System.Drawing.Point(883, 136)
        Me.txtFloatQty.Name = "txtFloatQty"
        Me.txtFloatQty.Size = New System.Drawing.Size(154, 25)
        Me.txtFloatQty.TabIndex = 644
        Me.txtFloatQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtFloatQty.UseCompatibleTextRendering = True
        '
        'btnCloseRecord
        '
        Me.btnCloseRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCloseRecord.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCloseRecord.DefaultScheme = False
        Me.btnCloseRecord.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnCloseRecord.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnCloseRecord.Hint = "Remaining items returned by technician"
        Me.btnCloseRecord.Location = New System.Drawing.Point(3, 493)
        Me.btnCloseRecord.Name = "btnCloseRecord"
        Me.btnCloseRecord.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCloseRecord.Size = New System.Drawing.Size(150, 32)
        Me.btnCloseRecord.TabIndex = 646
        Me.btnCloseRecord.TabStop = False
        Me.btnCloseRecord.Text = "Close Record"
        '
        'MntTrxPartIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1040, 528)
        Me.Controls.Add(Me.btnCloseRecord)
        Me.Controls.Add(Me.txtReferenceNo)
        Me.Controls.Add(Me.lblFloatQty)
        Me.Controls.Add(Me.txtFloatQty)
        Me.Controls.Add(Me.chkFloat)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.lblDateReceived)
        Me.Controls.Add(Me.dtpDateReceived)
        Me.Controls.Add(Me.cmbPart)
        Me.Controls.Add(Me.cmbPartSelection)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.lblReferenceNo)
        Me.Controls.Add(Me.lblTechnician)
        Me.Controls.Add(Me.cmbTechnician)
        Me.Controls.Add(Me.pnlImage)
        Me.Controls.Add(Me.lblItemList)
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
        Me.Controls.Add(Me.lblCurrentStock)
        Me.Controls.Add(Me.txtActualStock)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
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
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents cmbPart As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblCurrentStock As Label
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
    Friend WithEvents lblItemList As Label
    Friend WithEvents pnlImage As Panel
    Friend WithEvents picImage As PictureBox
    Friend WithEvents lblTechnician As Label
    Friend WithEvents cmbTechnician As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblReferenceNo As Label
    Friend WithEvents lblRemarks As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents cmbPartSelection As ComboBox
    Friend WithEvents lblDateReceived As Label
    Friend WithEvents dtpDateReceived As DateTimePicker
    Friend WithEvents txtReferenceNo As TextBox
    Public WithEvents txtLocation As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents chkFloat As CheckBox
    Friend WithEvents lblFloatQty As Label
    Public WithEvents txtFloatQty As Label
    Friend WithEvents ColPartId As DataGridViewTextBoxColumn
    Friend WithEvents btnCloseRecord As PinkieControls.ButtonXP
End Class
