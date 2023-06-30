<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MntSparePartDetail
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
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblIsActive = New System.Windows.Forms.Label()
        Me.pnlStatus = New System.Windows.Forms.Panel()
        Me.rdInactive = New System.Windows.Forms.RadioButton()
        Me.rdActive = New System.Windows.Forms.RadioButton()
        Me.cmbLocation = New SergeUtils.EasyCompletionComboBox()
        Me.lblPartNo = New System.Windows.Forms.Label()
        Me.txtPartNo = New System.Windows.Forms.TextBox()
        Me.txtCreatedDate = New System.Windows.Forms.Label()
        Me.lblCreatedDate = New System.Windows.Forms.Label()
        Me.txtCreatedBy = New System.Windows.Forms.Label()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.txtModifiedDate = New System.Windows.Forms.Label()
        Me.lblModifiedDate = New System.Windows.Forms.Label()
        Me.txtModifiedBy = New System.Windows.Forms.Label()
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.txtPartName = New System.Windows.Forms.TextBox()
        Me.lblPartName = New System.Windows.Forms.Label()
        Me.txtOrderingPoint = New System.Windows.Forms.TextBox()
        Me.lblOrderingPoint = New System.Windows.Forms.Label()
        Me.txtMinStock = New System.Windows.Forms.TextBox()
        Me.lblMinStock = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.lblItemType = New System.Windows.Forms.Label()
        Me.cmbItemType = New SergeUtils.EasyCompletionComboBox()
        Me.lblVendor = New System.Windows.Forms.Label()
        Me.cmbVendor = New SergeUtils.EasyCompletionComboBox()
        Me.lblMachineType = New System.Windows.Forms.Label()
        Me.cmbMachineType = New SergeUtils.EasyCompletionComboBox()
        Me.txtMaxStock = New System.Windows.Forms.TextBox()
        Me.lblMaxStock = New System.Windows.Forms.Label()
        Me.cmbUnit = New SergeUtils.EasyCompletionComboBox()
        Me.txtQrCode = New System.Windows.Forms.TextBox()
        Me.lblQrCode = New System.Windows.Forms.Label()
        Me.txtRfid = New System.Windows.Forms.TextBox()
        Me.lblRfid = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.lblBarcode = New System.Windows.Forms.Label()
        Me.pnlImage = New System.Windows.Forms.Panel()
        Me.btnViewImage = New PinkieControls.ButtonXP()
        Me.btnRemoveImage = New PinkieControls.ButtonXP()
        Me.btnBrowseImage = New PinkieControls.ButtonXP()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.lblImage = New System.Windows.Forms.Label()
        Me.ofdImage = New System.Windows.Forms.OpenFileDialog()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.pnlStatus.SuspendLayout()
        Me.pnlImage.SuspendLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnClose.Location = New System.Drawing.Point(475, 431)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 11
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
        Me.btnDelete.Location = New System.Drawing.Point(381, 431)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 10
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
        Me.btnSave.Location = New System.Drawing.Point(287, 431)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 9
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "  Save"
        '
        'lblLocation
        '
        Me.lblLocation.BackColor = System.Drawing.SystemColors.Control
        Me.lblLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLocation.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLocation.ForeColor = System.Drawing.Color.Black
        Me.lblLocation.Location = New System.Drawing.Point(4, 202)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblLocation.Size = New System.Drawing.Size(100, 23)
        Me.lblLocation.TabIndex = 557
        Me.lblLocation.Text = "Location"
        Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIsActive
        '
        Me.lblIsActive.BackColor = System.Drawing.SystemColors.Control
        Me.lblIsActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIsActive.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIsActive.ForeColor = System.Drawing.Color.Black
        Me.lblIsActive.Location = New System.Drawing.Point(4, 402)
        Me.lblIsActive.Name = "lblIsActive"
        Me.lblIsActive.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblIsActive.Size = New System.Drawing.Size(100, 23)
        Me.lblIsActive.TabIndex = 568
        Me.lblIsActive.Text = "Remarks"
        Me.lblIsActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlStatus
        '
        Me.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatus.Controls.Add(Me.rdInactive)
        Me.pnlStatus.Controls.Add(Me.rdActive)
        Me.pnlStatus.Location = New System.Drawing.Point(103, 402)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(180, 23)
        Me.pnlStatus.TabIndex = 14
        '
        'rdInactive
        '
        Me.rdInactive.AutoSize = True
        Me.rdInactive.Location = New System.Drawing.Point(100, 1)
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
        Me.rdActive.Location = New System.Drawing.Point(13, 1)
        Me.rdActive.Name = "rdActive"
        Me.rdActive.Size = New System.Drawing.Size(58, 19)
        Me.rdActive.TabIndex = 0
        Me.rdActive.TabStop = True
        Me.rdActive.Text = "Active"
        Me.rdActive.UseVisualStyleBackColor = True
        '
        'cmbLocation
        '
        Me.cmbLocation.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(103, 202)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(180, 23)
        Me.cmbLocation.TabIndex = 6
        '
        'lblPartNo
        '
        Me.lblPartNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartNo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPartNo.ForeColor = System.Drawing.Color.Black
        Me.lblPartNo.Location = New System.Drawing.Point(4, 52)
        Me.lblPartNo.Name = "lblPartNo"
        Me.lblPartNo.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblPartNo.Size = New System.Drawing.Size(100, 23)
        Me.lblPartNo.TabIndex = 555
        Me.lblPartNo.Text = "Part No"
        Me.lblPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartNo
        '
        Me.txtPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNo.Location = New System.Drawing.Point(103, 52)
        Me.txtPartNo.MaxLength = 50
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(462, 23)
        Me.txtPartNo.TabIndex = 0
        '
        'txtCreatedDate
        '
        Me.txtCreatedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedDate.Location = New System.Drawing.Point(103, 27)
        Me.txtCreatedDate.Name = "txtCreatedDate"
        Me.txtCreatedDate.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtCreatedDate.Size = New System.Drawing.Size(180, 23)
        Me.txtCreatedDate.TabIndex = 591
        Me.txtCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtCreatedDate.UseCompatibleTextRendering = True
        '
        'lblCreatedDate
        '
        Me.lblCreatedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedDate.Location = New System.Drawing.Point(4, 27)
        Me.lblCreatedDate.Name = "lblCreatedDate"
        Me.lblCreatedDate.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblCreatedDate.Size = New System.Drawing.Size(100, 23)
        Me.lblCreatedDate.TabIndex = 593
        Me.lblCreatedDate.Text = "Created Date"
        Me.lblCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedBy.Location = New System.Drawing.Point(103, 2)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtCreatedBy.Size = New System.Drawing.Size(180, 23)
        Me.txtCreatedBy.TabIndex = 590
        Me.txtCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtCreatedBy.UseCompatibleTextRendering = True
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedBy.Location = New System.Drawing.Point(4, 2)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblCreatedBy.Size = New System.Drawing.Size(100, 23)
        Me.lblCreatedBy.TabIndex = 592
        Me.lblCreatedBy.Text = "Created By"
        Me.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModifiedDate
        '
        Me.txtModifiedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedDate.Location = New System.Drawing.Point(385, 27)
        Me.txtModifiedDate.Name = "txtModifiedDate"
        Me.txtModifiedDate.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtModifiedDate.Size = New System.Drawing.Size(180, 23)
        Me.txtModifiedDate.TabIndex = 595
        Me.txtModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedDate.UseCompatibleTextRendering = True
        '
        'lblModifiedDate
        '
        Me.lblModifiedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedDate.Location = New System.Drawing.Point(286, 27)
        Me.lblModifiedDate.Name = "lblModifiedDate"
        Me.lblModifiedDate.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblModifiedDate.Size = New System.Drawing.Size(100, 23)
        Me.lblModifiedDate.TabIndex = 597
        Me.lblModifiedDate.Text = "Modified Date"
        Me.lblModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModifiedBy
        '
        Me.txtModifiedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedBy.Location = New System.Drawing.Point(385, 2)
        Me.txtModifiedBy.Name = "txtModifiedBy"
        Me.txtModifiedBy.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtModifiedBy.Size = New System.Drawing.Size(180, 23)
        Me.txtModifiedBy.TabIndex = 594
        Me.txtModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedBy.UseCompatibleTextRendering = True
        '
        'lblModifiedBy
        '
        Me.lblModifiedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedBy.Location = New System.Drawing.Point(286, 2)
        Me.lblModifiedBy.Name = "lblModifiedBy"
        Me.lblModifiedBy.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblModifiedBy.Size = New System.Drawing.Size(100, 23)
        Me.lblModifiedBy.TabIndex = 596
        Me.lblModifiedBy.Text = "Modified By"
        Me.lblModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartName
        '
        Me.txtPartName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartName.Location = New System.Drawing.Point(103, 77)
        Me.txtPartName.MaxLength = 50
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.Size = New System.Drawing.Size(462, 23)
        Me.txtPartName.TabIndex = 1
        '
        'lblPartName
        '
        Me.lblPartName.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPartName.ForeColor = System.Drawing.Color.Black
        Me.lblPartName.Location = New System.Drawing.Point(4, 77)
        Me.lblPartName.Name = "lblPartName"
        Me.lblPartName.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblPartName.Size = New System.Drawing.Size(100, 23)
        Me.lblPartName.TabIndex = 599
        Me.lblPartName.Text = "Part Name"
        Me.lblPartName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOrderingPoint
        '
        Me.txtOrderingPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderingPoint.Location = New System.Drawing.Point(103, 102)
        Me.txtOrderingPoint.MaxLength = 50
        Me.txtOrderingPoint.Name = "txtOrderingPoint"
        Me.txtOrderingPoint.Size = New System.Drawing.Size(180, 23)
        Me.txtOrderingPoint.TabIndex = 2
        Me.txtOrderingPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOrderingPoint
        '
        Me.lblOrderingPoint.BackColor = System.Drawing.SystemColors.Control
        Me.lblOrderingPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrderingPoint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblOrderingPoint.ForeColor = System.Drawing.Color.Black
        Me.lblOrderingPoint.Location = New System.Drawing.Point(4, 102)
        Me.lblOrderingPoint.Name = "lblOrderingPoint"
        Me.lblOrderingPoint.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblOrderingPoint.Size = New System.Drawing.Size(100, 23)
        Me.lblOrderingPoint.TabIndex = 601
        Me.lblOrderingPoint.Text = "Ordering Point"
        Me.lblOrderingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMinStock
        '
        Me.txtMinStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMinStock.Location = New System.Drawing.Point(103, 152)
        Me.txtMinStock.MaxLength = 50
        Me.txtMinStock.Name = "txtMinStock"
        Me.txtMinStock.Size = New System.Drawing.Size(180, 23)
        Me.txtMinStock.TabIndex = 4
        Me.txtMinStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMinStock
        '
        Me.lblMinStock.BackColor = System.Drawing.SystemColors.Control
        Me.lblMinStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMinStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMinStock.ForeColor = System.Drawing.Color.Black
        Me.lblMinStock.Location = New System.Drawing.Point(4, 152)
        Me.lblMinStock.Name = "lblMinStock"
        Me.lblMinStock.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblMinStock.Size = New System.Drawing.Size(100, 23)
        Me.lblMinStock.TabIndex = 603
        Me.lblMinStock.Text = "Min Stock"
        Me.lblMinStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnit
        '
        Me.lblUnit.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnit.ForeColor = System.Drawing.Color.Black
        Me.lblUnit.Location = New System.Drawing.Point(4, 177)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblUnit.Size = New System.Drawing.Size(100, 23)
        Me.lblUnit.TabIndex = 605
        Me.lblUnit.Text = "UOM"
        Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItemType
        '
        Me.lblItemType.BackColor = System.Drawing.SystemColors.Control
        Me.lblItemType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblItemType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblItemType.ForeColor = System.Drawing.Color.Black
        Me.lblItemType.Location = New System.Drawing.Point(4, 227)
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblItemType.Size = New System.Drawing.Size(100, 23)
        Me.lblItemType.TabIndex = 607
        Me.lblItemType.Text = "Item Type"
        Me.lblItemType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbItemType
        '
        Me.cmbItemType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbItemType.FormattingEnabled = True
        Me.cmbItemType.Location = New System.Drawing.Point(103, 227)
        Me.cmbItemType.Name = "cmbItemType"
        Me.cmbItemType.Size = New System.Drawing.Size(180, 23)
        Me.cmbItemType.TabIndex = 7
        '
        'lblVendor
        '
        Me.lblVendor.BackColor = System.Drawing.SystemColors.Control
        Me.lblVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVendor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblVendor.ForeColor = System.Drawing.Color.Black
        Me.lblVendor.Location = New System.Drawing.Point(4, 277)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblVendor.Size = New System.Drawing.Size(100, 23)
        Me.lblVendor.TabIndex = 611
        Me.lblVendor.Text = "Vendor"
        Me.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbVendor
        '
        Me.cmbVendor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbVendor.FormattingEnabled = True
        Me.cmbVendor.Location = New System.Drawing.Point(103, 277)
        Me.cmbVendor.Name = "cmbVendor"
        Me.cmbVendor.Size = New System.Drawing.Size(180, 23)
        Me.cmbVendor.TabIndex = 9
        '
        'lblMachineType
        '
        Me.lblMachineType.BackColor = System.Drawing.SystemColors.Control
        Me.lblMachineType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMachineType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMachineType.ForeColor = System.Drawing.Color.Black
        Me.lblMachineType.Location = New System.Drawing.Point(4, 252)
        Me.lblMachineType.Name = "lblMachineType"
        Me.lblMachineType.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblMachineType.Size = New System.Drawing.Size(100, 23)
        Me.lblMachineType.TabIndex = 609
        Me.lblMachineType.Text = "Machine Type"
        Me.lblMachineType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMachineType
        '
        Me.cmbMachineType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbMachineType.FormattingEnabled = True
        Me.cmbMachineType.Location = New System.Drawing.Point(103, 252)
        Me.cmbMachineType.Name = "cmbMachineType"
        Me.cmbMachineType.Size = New System.Drawing.Size(180, 23)
        Me.cmbMachineType.TabIndex = 8
        '
        'txtMaxStock
        '
        Me.txtMaxStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxStock.Location = New System.Drawing.Point(103, 127)
        Me.txtMaxStock.MaxLength = 50
        Me.txtMaxStock.Name = "txtMaxStock"
        Me.txtMaxStock.Size = New System.Drawing.Size(180, 23)
        Me.txtMaxStock.TabIndex = 3
        Me.txtMaxStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMaxStock
        '
        Me.lblMaxStock.BackColor = System.Drawing.SystemColors.Control
        Me.lblMaxStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMaxStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMaxStock.ForeColor = System.Drawing.Color.Black
        Me.lblMaxStock.Location = New System.Drawing.Point(4, 127)
        Me.lblMaxStock.Name = "lblMaxStock"
        Me.lblMaxStock.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblMaxStock.Size = New System.Drawing.Size(100, 23)
        Me.lblMaxStock.TabIndex = 613
        Me.lblMaxStock.Text = "Max Stock"
        Me.lblMaxStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbUnit
        '
        Me.cmbUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbUnit.FormattingEnabled = True
        Me.cmbUnit.Location = New System.Drawing.Point(103, 177)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(180, 23)
        Me.cmbUnit.TabIndex = 5
        '
        'txtQrCode
        '
        Me.txtQrCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQrCode.Location = New System.Drawing.Point(103, 352)
        Me.txtQrCode.MaxLength = 50
        Me.txtQrCode.Name = "txtQrCode"
        Me.txtQrCode.Size = New System.Drawing.Size(180, 23)
        Me.txtQrCode.TabIndex = 12
        '
        'lblQrCode
        '
        Me.lblQrCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblQrCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQrCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblQrCode.ForeColor = System.Drawing.Color.Black
        Me.lblQrCode.Location = New System.Drawing.Point(4, 352)
        Me.lblQrCode.Name = "lblQrCode"
        Me.lblQrCode.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblQrCode.Size = New System.Drawing.Size(100, 23)
        Me.lblQrCode.TabIndex = 620
        Me.lblQrCode.Text = "QR Code"
        Me.lblQrCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRfid
        '
        Me.txtRfid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRfid.Location = New System.Drawing.Point(103, 377)
        Me.txtRfid.MaxLength = 50
        Me.txtRfid.Name = "txtRfid"
        Me.txtRfid.Size = New System.Drawing.Size(180, 23)
        Me.txtRfid.TabIndex = 13
        '
        'lblRfid
        '
        Me.lblRfid.BackColor = System.Drawing.SystemColors.Control
        Me.lblRfid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRfid.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRfid.ForeColor = System.Drawing.Color.Black
        Me.lblRfid.Location = New System.Drawing.Point(4, 377)
        Me.lblRfid.Name = "lblRfid"
        Me.lblRfid.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblRfid.Size = New System.Drawing.Size(100, 23)
        Me.lblRfid.TabIndex = 618
        Me.lblRfid.Text = "RFID"
        Me.lblRfid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBarcode
        '
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.Location = New System.Drawing.Point(103, 327)
        Me.txtBarcode.MaxLength = 50
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(180, 23)
        Me.txtBarcode.TabIndex = 11
        '
        'lblBarcode
        '
        Me.lblBarcode.BackColor = System.Drawing.SystemColors.Control
        Me.lblBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBarcode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBarcode.ForeColor = System.Drawing.Color.Black
        Me.lblBarcode.Location = New System.Drawing.Point(4, 327)
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblBarcode.Size = New System.Drawing.Size(100, 23)
        Me.lblBarcode.TabIndex = 616
        Me.lblBarcode.Text = "Barcode"
        Me.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlImage
        '
        Me.pnlImage.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImage.Controls.Add(Me.btnViewImage)
        Me.pnlImage.Controls.Add(Me.btnRemoveImage)
        Me.pnlImage.Controls.Add(Me.btnBrowseImage)
        Me.pnlImage.Controls.Add(Me.picImage)
        Me.pnlImage.Location = New System.Drawing.Point(285, 125)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(280, 300)
        Me.pnlImage.TabIndex = 622
        '
        'btnViewImage
        '
        Me.btnViewImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnViewImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnViewImage.DefaultScheme = False
        Me.btnViewImage.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnViewImage.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewImage.Hint = "View image"
        Me.btnViewImage.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Expand_16_x_16
        Me.btnViewImage.Location = New System.Drawing.Point(2, 269)
        Me.btnViewImage.Name = "btnViewImage"
        Me.btnViewImage.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnViewImage.Size = New System.Drawing.Size(28, 28)
        Me.btnViewImage.TabIndex = 0
        Me.btnViewImage.TabStop = False
        '
        'btnRemoveImage
        '
        Me.btnRemoveImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnRemoveImage.DefaultScheme = False
        Me.btnRemoveImage.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemoveImage.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnRemoveImage.Hint = "Remove image"
        Me.btnRemoveImage.Location = New System.Drawing.Point(196, 269)
        Me.btnRemoveImage.Name = "btnRemoveImage"
        Me.btnRemoveImage.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemoveImage.Size = New System.Drawing.Size(80, 28)
        Me.btnRemoveImage.TabIndex = 2
        Me.btnRemoveImage.TabStop = False
        Me.btnRemoveImage.Text = "Remove"
        '
        'btnBrowseImage
        '
        Me.btnBrowseImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnBrowseImage.DefaultScheme = False
        Me.btnBrowseImage.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnBrowseImage.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnBrowseImage.Hint = "Browse image"
        Me.btnBrowseImage.Location = New System.Drawing.Point(115, 269)
        Me.btnBrowseImage.Name = "btnBrowseImage"
        Me.btnBrowseImage.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnBrowseImage.Size = New System.Drawing.Size(80, 28)
        Me.btnBrowseImage.TabIndex = 1
        Me.btnBrowseImage.TabStop = False
        Me.btnBrowseImage.Text = "Browse"
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
        Me.picImage.Size = New System.Drawing.Size(272, 265)
        Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage.TabIndex = 0
        Me.picImage.TabStop = False
        '
        'lblImage
        '
        Me.lblImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImage.BackColor = System.Drawing.SystemColors.Control
        Me.lblImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImage.ForeColor = System.Drawing.Color.Black
        Me.lblImage.Location = New System.Drawing.Point(285, 102)
        Me.lblImage.Name = "lblImage"
        Me.lblImage.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblImage.Size = New System.Drawing.Size(280, 24)
        Me.lblImage.TabIndex = 621
        Me.lblImage.Text = "Image"
        Me.lblImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ofdImage
        '
        '
        'txtItemCode
        '
        Me.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCode.Location = New System.Drawing.Point(103, 302)
        Me.txtItemCode.MaxLength = 50
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(180, 23)
        Me.txtItemCode.TabIndex = 10
        '
        'lblItemCode
        '
        Me.lblItemCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblItemCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblItemCode.ForeColor = System.Drawing.Color.Black
        Me.lblItemCode.Location = New System.Drawing.Point(4, 302)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblItemCode.Size = New System.Drawing.Size(100, 23)
        Me.lblItemCode.TabIndex = 624
        Me.lblItemCode.Text = "Item Code"
        Me.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MntSparePartDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(569, 467)
        Me.Controls.Add(Me.txtItemCode)
        Me.Controls.Add(Me.lblItemCode)
        Me.Controls.Add(Me.pnlImage)
        Me.Controls.Add(Me.lblImage)
        Me.Controls.Add(Me.txtQrCode)
        Me.Controls.Add(Me.lblQrCode)
        Me.Controls.Add(Me.txtRfid)
        Me.Controls.Add(Me.lblRfid)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.lblBarcode)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.cmbUnit)
        Me.Controls.Add(Me.txtMaxStock)
        Me.Controls.Add(Me.lblMaxStock)
        Me.Controls.Add(Me.lblVendor)
        Me.Controls.Add(Me.cmbVendor)
        Me.Controls.Add(Me.lblMachineType)
        Me.Controls.Add(Me.cmbMachineType)
        Me.Controls.Add(Me.lblItemType)
        Me.Controls.Add(Me.cmbItemType)
        Me.Controls.Add(Me.txtMinStock)
        Me.Controls.Add(Me.lblMinStock)
        Me.Controls.Add(Me.txtOrderingPoint)
        Me.Controls.Add(Me.lblOrderingPoint)
        Me.Controls.Add(Me.txtPartName)
        Me.Controls.Add(Me.lblPartName)
        Me.Controls.Add(Me.txtModifiedDate)
        Me.Controls.Add(Me.lblModifiedDate)
        Me.Controls.Add(Me.txtModifiedBy)
        Me.Controls.Add(Me.lblModifiedBy)
        Me.Controls.Add(Me.txtCreatedDate)
        Me.Controls.Add(Me.lblCreatedDate)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.txtPartNo)
        Me.Controls.Add(Me.lblPartNo)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.cmbLocation)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.lblIsActive)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntSparePartDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Spare Part Editor"
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlStatus.PerformLayout()
        Me.pnlImage.ResumeLayout(False)
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents lblLocation As Label
    Friend WithEvents lblPartNo As Label
    Friend WithEvents lblIsActive As Label
    Friend WithEvents pnlStatus As Panel
    Friend WithEvents cmbLocation As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtPartNo As TextBox
    Friend WithEvents txtCreatedDate As Label
    Friend WithEvents lblCreatedDate As Label
    Friend WithEvents txtCreatedBy As Label
    Friend WithEvents lblCreatedBy As Label
    Friend WithEvents txtModifiedDate As Label
    Friend WithEvents lblModifiedDate As Label
    Friend WithEvents txtModifiedBy As Label
    Friend WithEvents lblModifiedBy As Label
    Friend WithEvents txtPartName As TextBox
    Friend WithEvents lblPartName As Label
    Friend WithEvents txtOrderingPoint As TextBox
    Friend WithEvents lblOrderingPoint As Label
    Friend WithEvents txtMinStock As TextBox
    Friend WithEvents lblMinStock As Label
    Friend WithEvents lblUnit As Label
    Friend WithEvents lblItemType As Label
    Friend WithEvents cmbItemType As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblVendor As Label
    Friend WithEvents cmbVendor As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblMachineType As Label
    Friend WithEvents cmbMachineType As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtMaxStock As TextBox
    Friend WithEvents lblMaxStock As Label
    Friend WithEvents cmbUnit As SergeUtils.EasyCompletionComboBox
    Friend WithEvents rdInactive As RadioButton
    Friend WithEvents rdActive As RadioButton
    Friend WithEvents txtQrCode As TextBox
    Friend WithEvents lblQrCode As Label
    Friend WithEvents txtRfid As TextBox
    Friend WithEvents lblRfid As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents lblBarcode As Label
    Friend WithEvents pnlImage As Panel
    Friend WithEvents btnViewImage As PinkieControls.ButtonXP
    Friend WithEvents btnRemoveImage As PinkieControls.ButtonXP
    Friend WithEvents btnBrowseImage As PinkieControls.ButtonXP
    Friend WithEvents picImage As PictureBox
    Friend WithEvents lblImage As Label
    Friend WithEvents ofdImage As OpenFileDialog
    Friend WithEvents txtItemCode As TextBox
    Friend WithEvents lblItemCode As Label
End Class
