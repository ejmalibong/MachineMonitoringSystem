<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MntTrxPartsIssue
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MntTrxPartsIssue))
        Me.dgvSpareParts = New System.Windows.Forms.DataGridView()
        Me.ColIsSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPartName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSearch = New Be.Windows.Forms.RichTextBoxEx()
        Me.lblMasterlist = New System.Windows.Forms.Label()
        Me.btnAdd = New PinkieControls.ButtonXP()
        Me.lblIssuance = New System.Windows.Forms.Label()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.dgvIssue = New System.Windows.Forms.DataGridView()
        Me.ColIssIsSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColIssPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIssPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIssPartName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIssStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIssQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.bindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.txtTotalPageNumber = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.txtPageNumber = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGo = New System.Windows.Forms.ToolStripButton()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.btnClearSearch = New PinkieControls.ButtonXP()
        Me.lblTechnician = New System.Windows.Forms.Label()
        Me.cmbTechnician = New SergeUtils.EasyCompletionComboBox()
        CType(Me.dgvSpareParts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvSpareParts
        '
        Me.dgvSpareParts.AllowUserToAddRows = False
        Me.dgvSpareParts.AllowUserToDeleteRows = False
        Me.dgvSpareParts.AllowUserToResizeColumns = False
        Me.dgvSpareParts.AllowUserToResizeRows = False
        Me.dgvSpareParts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSpareParts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSpareParts.ColumnHeadersHeight = 22
        Me.dgvSpareParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSpareParts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIsSelected, Me.ColPartId, Me.ColPartNo, Me.ColPartName, Me.ColStock})
        Me.dgvSpareParts.Location = New System.Drawing.Point(3, 91)
        Me.dgvSpareParts.MultiSelect = False
        Me.dgvSpareParts.Name = "dgvSpareParts"
        Me.dgvSpareParts.RowHeadersVisible = False
        Me.dgvSpareParts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvSpareParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSpareParts.Size = New System.Drawing.Size(777, 250)
        Me.dgvSpareParts.TabIndex = 12
        Me.dgvSpareParts.TabStop = False
        '
        'ColIsSelected
        '
        Me.ColIsSelected.HeaderText = "*"
        Me.ColIsSelected.Name = "ColIsSelected"
        Me.ColIsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColIsSelected.Width = 25
        '
        'ColPartId
        '
        Me.ColPartId.DataPropertyName = "PartId"
        Me.ColPartId.HeaderText = "Part ID"
        Me.ColPartId.Name = "ColPartId"
        Me.ColPartId.Visible = False
        '
        'ColPartNo
        '
        Me.ColPartNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColPartNo.DataPropertyName = "PartNo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColPartNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColPartNo.HeaderText = "Part No"
        Me.ColPartNo.Name = "ColPartNo"
        Me.ColPartNo.ReadOnly = True
        '
        'ColPartName
        '
        Me.ColPartName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColPartName.DataPropertyName = "PartName"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColPartName.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColPartName.HeaderText = "Part Name"
        Me.ColPartName.Name = "ColPartName"
        Me.ColPartName.ReadOnly = True
        '
        'ColStock
        '
        Me.ColStock.DataPropertyName = "ActualStock"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColStock.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColStock.HeaderText = "Stock"
        Me.ColStock.Name = "ColStock"
        Me.ColStock.ReadOnly = True
        Me.ColStock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColStock.Width = 45
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(132, 62)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.txtSearch.Size = New System.Drawing.Size(620, 26)
        Me.txtSearch.TabIndex = 563
        Me.txtSearch.Text = ""
        Me.txtSearch.WordWrap = False
        '
        'lblMasterlist
        '
        Me.lblMasterlist.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMasterlist.BackColor = System.Drawing.SystemColors.Control
        Me.lblMasterlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMasterlist.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMasterlist.ForeColor = System.Drawing.Color.Black
        Me.lblMasterlist.Location = New System.Drawing.Point(3, 32)
        Me.lblMasterlist.Name = "lblMasterlist"
        Me.lblMasterlist.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblMasterlist.Size = New System.Drawing.Size(777, 26)
        Me.lblMasterlist.TabIndex = 564
        Me.lblMasterlist.Text = "Current Stock"
        Me.lblMasterlist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdd.DefaultScheme = False
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnAdd.Hint = "Add selected item(s)"
        Me.btnAdd.Location = New System.Drawing.Point(582, 343)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(99, 30)
        Me.btnAdd.TabIndex = 565
        Me.btnAdd.TabStop = False
        Me.btnAdd.Text = "Add"
        '
        'lblIssuance
        '
        Me.lblIssuance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIssuance.BackColor = System.Drawing.SystemColors.Control
        Me.lblIssuance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIssuance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIssuance.ForeColor = System.Drawing.Color.Black
        Me.lblIssuance.Location = New System.Drawing.Point(3, 375)
        Me.lblIssuance.Name = "lblIssuance"
        Me.lblIssuance.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblIssuance.Size = New System.Drawing.Size(777, 26)
        Me.lblIssuance.TabIndex = 566
        Me.lblIssuance.Text = "Stock Out"
        Me.lblIssuance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemove.DefaultScheme = False
        Me.btnRemove.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnRemove.Hint = "Remove item(s)"
        Me.btnRemove.Location = New System.Drawing.Point(682, 343)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove.Size = New System.Drawing.Size(99, 30)
        Me.btnRemove.TabIndex = 568
        Me.btnRemove.TabStop = False
        Me.btnRemove.Text = "Remove"
        '
        'dgvIssue
        '
        Me.dgvIssue.AllowUserToAddRows = False
        Me.dgvIssue.AllowUserToDeleteRows = False
        Me.dgvIssue.AllowUserToResizeColumns = False
        Me.dgvIssue.AllowUserToResizeRows = False
        Me.dgvIssue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIssue.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvIssue.ColumnHeadersHeight = 22
        Me.dgvIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvIssue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIssIsSelected, Me.ColIssPartId, Me.ColIssPartNo, Me.ColIssPartName, Me.ColIssStock, Me.ColIssQty})
        Me.dgvIssue.Location = New System.Drawing.Point(3, 403)
        Me.dgvIssue.MultiSelect = False
        Me.dgvIssue.Name = "dgvIssue"
        Me.dgvIssue.RowHeadersVisible = False
        Me.dgvIssue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvIssue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIssue.Size = New System.Drawing.Size(777, 170)
        Me.dgvIssue.TabIndex = 569
        Me.dgvIssue.TabStop = False
        '
        'ColIssIsSelected
        '
        Me.ColIssIsSelected.HeaderText = "*"
        Me.ColIssIsSelected.Name = "ColIssIsSelected"
        Me.ColIssIsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColIssIsSelected.Width = 25
        '
        'ColIssPartId
        '
        Me.ColIssPartId.DataPropertyName = "PartId"
        Me.ColIssPartId.HeaderText = "Part ID"
        Me.ColIssPartId.Name = "ColIssPartId"
        Me.ColIssPartId.Visible = False
        '
        'ColIssPartNo
        '
        Me.ColIssPartNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColIssPartNo.DataPropertyName = "PartNo"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColIssPartNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColIssPartNo.HeaderText = "Part No"
        Me.ColIssPartNo.Name = "ColIssPartNo"
        Me.ColIssPartNo.ReadOnly = True
        Me.ColIssPartNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColIssPartName
        '
        Me.ColIssPartName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColIssPartName.DataPropertyName = "PartName"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColIssPartName.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColIssPartName.HeaderText = "Part Name"
        Me.ColIssPartName.Name = "ColIssPartName"
        Me.ColIssPartName.ReadOnly = True
        Me.ColIssPartName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColIssStock
        '
        Me.ColIssStock.DataPropertyName = "ActualStock"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColIssStock.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColIssStock.HeaderText = "Stock"
        Me.ColIssStock.Name = "ColIssStock"
        Me.ColIssStock.ReadOnly = True
        Me.ColIssStock.Width = 45
        '
        'ColIssQty
        '
        Me.ColIssQty.DataPropertyName = "Qty"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColIssQty.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColIssQty.HeaderText = "Qty"
        Me.ColIssQty.Name = "ColIssQty"
        Me.ColIssQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColIssQty.Width = 45
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
        Me.btnClose.Location = New System.Drawing.Point(690, 576)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 573
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
        Me.btnDelete.Location = New System.Drawing.Point(596, 576)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 572
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
        Me.btnCancel.Location = New System.Drawing.Point(502, 576)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(90, 32)
        Me.btnCancel.TabIndex = 571
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
        Me.btnSave.Location = New System.Drawing.Point(408, 576)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 570
        Me.btnSave.TabStop = False
        Me.btnSave.Text = " Save"
        '
        'bindingNavigator
        '
        Me.bindingNavigator.AddNewItem = Nothing
        Me.bindingNavigator.BackColor = System.Drawing.Color.Transparent
        Me.bindingNavigator.CountItem = Me.txtTotalPageNumber
        Me.bindingNavigator.CountItemFormat = "of "
        Me.bindingNavigator.DeleteItem = Nothing
        Me.bindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.bindingNavigator.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.bindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.txtPageNumber, Me.txtTotalPageNumber, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.ToolStripSeparator, Me.btnGo})
        Me.bindingNavigator.Location = New System.Drawing.Point(2, 346)
        Me.bindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bindingNavigator.Name = "bindingNavigator"
        Me.bindingNavigator.PositionItem = Me.txtPageNumber
        Me.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.bindingNavigator.Size = New System.Drawing.Size(205, 25)
        Me.bindingNavigator.TabIndex = 574
        '
        'txtTotalPageNumber
        '
        Me.txtTotalPageNumber.Name = "txtTotalPageNumber"
        Me.txtTotalPageNumber.Size = New System.Drawing.Size(21, 22)
        Me.txtTotalPageNumber.Text = "of "
        Me.txtTotalPageNumber.ToolTipText = "Total number of pages"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'txtPageNumber
        '
        Me.txtPageNumber.AccessibleName = "Position"
        Me.txtPageNumber.AutoSize = False
        Me.txtPageNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPageNumber.Name = "txtPageNumber"
        Me.txtPageNumber.Size = New System.Drawing.Size(34, 23)
        Me.txtPageNumber.Text = "0"
        Me.txtPageNumber.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPageNumber.ToolTipText = "Current page"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'ToolStripSeparator
        '
        Me.ToolStripSeparator.Name = "ToolStripSeparator"
        Me.ToolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'btnGo
        '
        Me.btnGo.AutoSize = False
        Me.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(35, 22)
        Me.btnGo.Text = "Go"
        Me.btnGo.ToolTipText = "Go to page number specified"
        '
        'lblSearch
        '
        Me.lblSearch.BackColor = System.Drawing.SystemColors.Control
        Me.lblSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSearch.ForeColor = System.Drawing.Color.Black
        Me.lblSearch.Location = New System.Drawing.Point(3, 62)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblSearch.Size = New System.Drawing.Size(130, 26)
        Me.lblSearch.TabIndex = 575
        Me.lblSearch.Text = "Part No / Part Name"
        Me.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClearSearch
        '
        Me.btnClearSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClearSearch.DefaultScheme = False
        Me.btnClearSearch.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnClearSearch.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSearch.Hint = "View image"
        Me.btnClearSearch.Image = CType(resources.GetObject("btnClearSearch.Image"), System.Drawing.Image)
        Me.btnClearSearch.Location = New System.Drawing.Point(753, 61)
        Me.btnClearSearch.Name = "btnClearSearch"
        Me.btnClearSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClearSearch.Size = New System.Drawing.Size(28, 28)
        Me.btnClearSearch.TabIndex = 576
        Me.btnClearSearch.TabStop = False
        '
        'lblTechnician
        '
        Me.lblTechnician.BackColor = System.Drawing.SystemColors.Control
        Me.lblTechnician.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTechnician.ForeColor = System.Drawing.Color.Black
        Me.lblTechnician.Location = New System.Drawing.Point(2, 3)
        Me.lblTechnician.Name = "lblTechnician"
        Me.lblTechnician.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblTechnician.Size = New System.Drawing.Size(130, 27)
        Me.lblTechnician.TabIndex = 578
        Me.lblTechnician.Text = "Technician"
        Me.lblTechnician.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTechnician
        '
        Me.cmbTechnician.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.cmbTechnician.FormattingEnabled = True
        Me.cmbTechnician.Location = New System.Drawing.Point(131, 3)
        Me.cmbTechnician.Name = "cmbTechnician"
        Me.cmbTechnician.Size = New System.Drawing.Size(649, 27)
        Me.cmbTechnician.TabIndex = 577
        '
        'MntTrxPartsIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 611)
        Me.Controls.Add(Me.lblTechnician)
        Me.Controls.Add(Me.cmbTechnician)
        Me.Controls.Add(Me.btnClearSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.bindingNavigator)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgvIssue)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.lblIssuance)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblMasterlist)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.dgvSpareParts)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntTrxPartsIssue"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Parts Issuance"
        CType(Me.dgvSpareParts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator.ResumeLayout(False)
        Me.bindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvSpareParts As DataGridView
    Friend WithEvents txtSearch As Be.Windows.Forms.RichTextBoxEx
    Friend WithEvents lblMasterlist As Label
    Friend WithEvents btnAdd As PinkieControls.ButtonXP
    Friend WithEvents lblIssuance As Label
    Friend WithEvents btnRemove As PinkieControls.ButtonXP
    Friend WithEvents dgvIssue As DataGridView
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents bindingNavigator As BindingNavigator
    Friend WithEvents txtTotalPageNumber As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents txtPageNumber As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents ToolStripSeparator As ToolStripSeparator
    Friend WithEvents btnGo As ToolStripButton
    Friend WithEvents lblSearch As Label
    Friend WithEvents ColIsSelected As DataGridViewCheckBoxColumn
    Friend WithEvents ColPartId As DataGridViewTextBoxColumn
    Friend WithEvents ColPartNo As DataGridViewTextBoxColumn
    Friend WithEvents ColPartName As DataGridViewTextBoxColumn
    Friend WithEvents ColStock As DataGridViewTextBoxColumn
    Friend WithEvents ColIssIsSelected As DataGridViewCheckBoxColumn
    Friend WithEvents ColIssPartId As DataGridViewTextBoxColumn
    Friend WithEvents ColIssPartNo As DataGridViewTextBoxColumn
    Friend WithEvents ColIssPartName As DataGridViewTextBoxColumn
    Friend WithEvents ColIssStock As DataGridViewTextBoxColumn
    Friend WithEvents ColIssQty As DataGridViewTextBoxColumn
    Friend WithEvents btnClearSearch As PinkieControls.ButtonXP
    Friend WithEvents lblTechnician As Label
    Friend WithEvents cmbTechnician As SergeUtils.EasyCompletionComboBox
End Class
