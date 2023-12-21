<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MntSparePart
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MntSparePart))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbSearchCriteria = New System.Windows.Forms.ComboBox()
        Me.pnlSearchByText = New System.Windows.Forms.Panel()
        Me.txtCommon = New System.Windows.Forms.TextBox()
        Me.pnlSearchByCmb = New System.Windows.Forms.Panel()
        Me.cmbCommon = New SergeUtils.EasyCompletionComboBox()
        Me.pnlSearchByDate = New System.Windows.Forms.Panel()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblSearchEndDate = New System.Windows.Forms.Label()
        Me.lblSearchStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.btnReset = New PinkieControls.ButtonXP()
        Me.btnSearch = New PinkieControls.ButtonXP()
        Me.bindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.txtTotalPageNumber = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtPageNumber = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGo = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.btnAdd = New PinkieControls.ButtonXP()
        Me.btnEdit = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.pnlSearchByCmb2 = New System.Windows.Forms.Panel()
        Me.cmbCommon2 = New SergeUtils.EasyCompletionComboBox()
        Me.btnViewLogs = New PinkieControls.ButtonXP()
        Me.btnReceiveStock = New PinkieControls.ButtonXP()
        Me.btnIncomingStocks = New PinkieControls.ButtonXP()
        Me.cmsExport = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BelowOrderingPointToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BelowMinStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSortBy = New System.Windows.Forms.Label()
        Me.cmbSortCriteria = New System.Windows.Forms.ComboBox()
        Me.btnIssueStock = New PinkieControls.ButtonXP()
        Me.grpSortMode = New System.Windows.Forms.GroupBox()
        Me.rdDesc = New System.Windows.Forms.RadioButton()
        Me.rdAsc = New System.Windows.Forms.RadioButton()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.ColPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPartName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColImage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ColItemType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActualStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActualStockAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOrderingPoint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMinStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMaxStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColForPr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColExpectedStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLocatioName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMachineType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIsActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlSearchByText.SuspendLayout()
        Me.pnlSearchByCmb.SuspendLayout()
        Me.pnlSearchByDate.SuspendLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator.SuspendLayout()
        Me.pnlSearchByCmb2.SuspendLayout()
        Me.cmsExport.SuspendLayout()
        Me.grpSortMode.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbSearchCriteria
        '
        Me.cmbSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchCriteria.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbSearchCriteria.FormattingEnabled = True
        Me.cmbSearchCriteria.Location = New System.Drawing.Point(4, 4)
        Me.cmbSearchCriteria.Name = "cmbSearchCriteria"
        Me.cmbSearchCriteria.Size = New System.Drawing.Size(160, 25)
        Me.cmbSearchCriteria.TabIndex = 545
        '
        'pnlSearchByText
        '
        Me.pnlSearchByText.Controls.Add(Me.txtCommon)
        Me.pnlSearchByText.Location = New System.Drawing.Point(165, 1)
        Me.pnlSearchByText.Name = "pnlSearchByText"
        Me.pnlSearchByText.Size = New System.Drawing.Size(322, 31)
        Me.pnlSearchByText.TabIndex = 548
        '
        'txtCommon
        '
        Me.txtCommon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCommon.CausesValidation = False
        Me.txtCommon.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommon.Location = New System.Drawing.Point(3, 3)
        Me.txtCommon.Name = "txtCommon"
        Me.txtCommon.Size = New System.Drawing.Size(316, 25)
        Me.txtCommon.TabIndex = 0
        '
        'pnlSearchByCmb
        '
        Me.pnlSearchByCmb.Controls.Add(Me.cmbCommon)
        Me.pnlSearchByCmb.Location = New System.Drawing.Point(165, 1)
        Me.pnlSearchByCmb.Name = "pnlSearchByCmb"
        Me.pnlSearchByCmb.Size = New System.Drawing.Size(322, 31)
        Me.pnlSearchByCmb.TabIndex = 549
        '
        'cmbCommon
        '
        Me.cmbCommon.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbCommon.FormattingEnabled = True
        Me.cmbCommon.Location = New System.Drawing.Point(3, 3)
        Me.cmbCommon.Name = "cmbCommon"
        Me.cmbCommon.Size = New System.Drawing.Size(316, 25)
        Me.cmbCommon.TabIndex = 546
        '
        'pnlSearchByDate
        '
        Me.pnlSearchByDate.BackColor = System.Drawing.Color.White
        Me.pnlSearchByDate.Controls.Add(Me.dtpEndDate)
        Me.pnlSearchByDate.Controls.Add(Me.lblSearchEndDate)
        Me.pnlSearchByDate.Controls.Add(Me.lblSearchStartDate)
        Me.pnlSearchByDate.Controls.Add(Me.dtpStartDate)
        Me.pnlSearchByDate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.pnlSearchByDate.Location = New System.Drawing.Point(165, 1)
        Me.pnlSearchByDate.Name = "pnlSearchByDate"
        Me.pnlSearchByDate.Size = New System.Drawing.Size(322, 31)
        Me.pnlSearchByDate.TabIndex = 550
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "  MMM dd, yyyy"
        Me.dtpEndDate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(194, 4)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(125, 24)
        Me.dtpEndDate.TabIndex = 27
        '
        'lblSearchEndDate
        '
        Me.lblSearchEndDate.AutoSize = True
        Me.lblSearchEndDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSearchEndDate.Location = New System.Drawing.Point(173, 8)
        Me.lblSearchEndDate.Name = "lblSearchEndDate"
        Me.lblSearchEndDate.Size = New System.Drawing.Size(19, 15)
        Me.lblSearchEndDate.TabIndex = 29
        Me.lblSearchEndDate.Text = "To"
        '
        'lblSearchStartDate
        '
        Me.lblSearchStartDate.AutoSize = True
        Me.lblSearchStartDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSearchStartDate.Location = New System.Drawing.Point(5, 8)
        Me.lblSearchStartDate.Name = "lblSearchStartDate"
        Me.lblSearchStartDate.Size = New System.Drawing.Size(35, 15)
        Me.lblSearchStartDate.TabIndex = 28
        Me.lblSearchStartDate.Text = "From"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "  MMM dd, yyyy"
        Me.dtpStartDate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(44, 4)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(125, 24)
        Me.dtpStartDate.TabIndex = 26
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReset.CausesValidation = False
        Me.btnReset.DefaultScheme = True
        Me.btnReset.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnReset.Hint = "Remove filter"
        Me.btnReset.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Undo_16_x_16
        Me.btnReset.Location = New System.Drawing.Point(577, 2)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnReset.Size = New System.Drawing.Size(85, 29)
        Me.btnReset.TabIndex = 552
        Me.btnReset.Text = "Reset"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearch.CausesValidation = False
        Me.btnSearch.DefaultScheme = True
        Me.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSearch.Hint = "Search"
        Me.btnSearch.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Find_16_x_16
        Me.btnSearch.Location = New System.Drawing.Point(488, 2)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSearch.Size = New System.Drawing.Size(85, 29)
        Me.btnSearch.TabIndex = 551
        Me.btnSearch.Text = "Search"
        '
        'bindingNavigator
        '
        Me.bindingNavigator.AddNewItem = Nothing
        Me.bindingNavigator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bindingNavigator.BackColor = System.Drawing.Color.White
        Me.bindingNavigator.CountItem = Me.txtTotalPageNumber
        Me.bindingNavigator.CountItemFormat = "of "
        Me.bindingNavigator.DeleteItem = Nothing
        Me.bindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.bindingNavigator.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.bindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator1, Me.txtPageNumber, Me.txtTotalPageNumber, Me.BindingNavigatorSeparator2, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator3, Me.btnGo, Me.BindingNavigatorSeparator4, Me.btnRefresh, Me.BindingNavigatorSeparator5, Me.btnExport})
        Me.bindingNavigator.Location = New System.Drawing.Point(4, 529)
        Me.bindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bindingNavigator.Name = "bindingNavigator"
        Me.bindingNavigator.PositionItem = Me.txtPageNumber
        Me.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.bindingNavigator.Size = New System.Drawing.Size(311, 25)
        Me.bindingNavigator.TabIndex = 554
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
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'txtPageNumber
        '
        Me.txtPageNumber.AccessibleName = "Position"
        Me.txtPageNumber.AutoSize = False
        Me.txtPageNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPageNumber.Name = "txtPageNumber"
        Me.txtPageNumber.Size = New System.Drawing.Size(30, 23)
        Me.txtPageNumber.Text = "0"
        Me.txtPageNumber.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPageNumber.ToolTipText = "Current page"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'BindingNavigatorSeparator3
        '
        Me.BindingNavigatorSeparator3.Name = "BindingNavigatorSeparator3"
        Me.BindingNavigatorSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'BindingNavigatorSeparator4
        '
        Me.BindingNavigatorSeparator4.Name = "BindingNavigatorSeparator4"
        Me.BindingNavigatorSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnRefresh
        '
        Me.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnRefresh.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Refresh_16_x_16
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(53, 22)
        Me.btnRefresh.Text = " Refresh"
        Me.btnRefresh.ToolTipText = "Refresh list"
        '
        'BindingNavigatorSeparator5
        '
        Me.BindingNavigatorSeparator5.Name = "BindingNavigatorSeparator5"
        Me.BindingNavigatorSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnExport
        '
        Me.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(45, 22)
        Me.btnExport.Text = "Export"
        Me.btnExport.ToolTipText = "Export selected records"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdd.CausesValidation = False
        Me.btnAdd.DefaultScheme = True
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnAdd.Hint = ""
        Me.btnAdd.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Create_16_x_16
        Me.btnAdd.Location = New System.Drawing.Point(756, 526)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(90, 32)
        Me.btnAdd.TabIndex = 558
        Me.btnAdd.Text = "  Add"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEdit.CausesValidation = False
        Me.btnEdit.DefaultScheme = True
        Me.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnEdit.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnEdit.Hint = "Modify record"
        Me.btnEdit.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Modify_16_x_16
        Me.btnEdit.Location = New System.Drawing.Point(850, 526)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnEdit.Size = New System.Drawing.Size(90, 32)
        Me.btnEdit.TabIndex = 557
        Me.btnEdit.Text = "  Edit"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.CausesValidation = False
        Me.btnDelete.DefaultScheme = True
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnDelete.Hint = "Delete the selected record"
        Me.btnDelete.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Erase_16_x_16
        Me.btnDelete.Location = New System.Drawing.Point(944, 526)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 556
        Me.btnDelete.Text = "Delete"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.CausesValidation = False
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(1038, 526)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 555
        Me.btnClose.Text = "Close"
        '
        'pnlSearchByCmb2
        '
        Me.pnlSearchByCmb2.Controls.Add(Me.cmbCommon2)
        Me.pnlSearchByCmb2.Location = New System.Drawing.Point(165, 1)
        Me.pnlSearchByCmb2.Name = "pnlSearchByCmb2"
        Me.pnlSearchByCmb2.Size = New System.Drawing.Size(322, 31)
        Me.pnlSearchByCmb2.TabIndex = 549
        '
        'cmbCommon2
        '
        Me.cmbCommon2.CausesValidation = False
        Me.cmbCommon2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCommon2.FormattingEnabled = True
        Me.cmbCommon2.Location = New System.Drawing.Point(3, 3)
        Me.cmbCommon2.Name = "cmbCommon2"
        Me.cmbCommon2.Size = New System.Drawing.Size(316, 25)
        Me.cmbCommon2.TabIndex = 592
        '
        'btnViewLogs
        '
        Me.btnViewLogs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewLogs.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnViewLogs.CausesValidation = False
        Me.btnViewLogs.DefaultScheme = True
        Me.btnViewLogs.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnViewLogs.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnViewLogs.Hint = "View transaction history"
        Me.btnViewLogs.Location = New System.Drawing.Point(464, 526)
        Me.btnViewLogs.Margin = New System.Windows.Forms.Padding(2)
        Me.btnViewLogs.Name = "btnViewLogs"
        Me.btnViewLogs.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnViewLogs.Size = New System.Drawing.Size(90, 32)
        Me.btnViewLogs.TabIndex = 560
        Me.btnViewLogs.Text = "View Logs"
        '
        'btnReceiveStock
        '
        Me.btnReceiveStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReceiveStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReceiveStock.CausesValidation = False
        Me.btnReceiveStock.DefaultScheme = True
        Me.btnReceiveStock.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnReceiveStock.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnReceiveStock.Hint = "Modify record"
        Me.btnReceiveStock.Location = New System.Drawing.Point(657, 526)
        Me.btnReceiveStock.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReceiveStock.Name = "btnReceiveStock"
        Me.btnReceiveStock.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnReceiveStock.Size = New System.Drawing.Size(95, 32)
        Me.btnReceiveStock.TabIndex = 559
        Me.btnReceiveStock.Text = "Receive Stock"
        '
        'btnIncomingStocks
        '
        Me.btnIncomingStocks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIncomingStocks.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnIncomingStocks.CausesValidation = False
        Me.btnIncomingStocks.DefaultScheme = True
        Me.btnIncomingStocks.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnIncomingStocks.Enabled = False
        Me.btnIncomingStocks.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnIncomingStocks.Hint = "Export to excel"
        Me.btnIncomingStocks.Location = New System.Drawing.Point(340, 526)
        Me.btnIncomingStocks.Margin = New System.Windows.Forms.Padding(2)
        Me.btnIncomingStocks.Name = "btnIncomingStocks"
        Me.btnIncomingStocks.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnIncomingStocks.Size = New System.Drawing.Size(120, 32)
        Me.btnIncomingStocks.TabIndex = 561
        Me.btnIncomingStocks.Text = "Incoming Stocks"
        '
        'cmsExport
        '
        Me.cmsExport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllToolStripMenuItem, Me.BelowOrderingPointToolStripMenuItem, Me.BelowMinStockToolStripMenuItem})
        Me.cmsExport.Name = "cmsConsole"
        Me.cmsExport.Size = New System.Drawing.Size(188, 70)
        '
        'AllToolStripMenuItem
        '
        Me.AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        Me.AllToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.AllToolStripMenuItem.Text = "All"
        '
        'BelowOrderingPointToolStripMenuItem
        '
        Me.BelowOrderingPointToolStripMenuItem.Name = "BelowOrderingPointToolStripMenuItem"
        Me.BelowOrderingPointToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.BelowOrderingPointToolStripMenuItem.Text = "Below Ordering Point"
        '
        'BelowMinStockToolStripMenuItem
        '
        Me.BelowMinStockToolStripMenuItem.Name = "BelowMinStockToolStripMenuItem"
        Me.BelowMinStockToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.BelowMinStockToolStripMenuItem.Text = "Below Min Stock"
        '
        'lblSortBy
        '
        Me.lblSortBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblSortBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSortBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSortBy.ForeColor = System.Drawing.Color.Black
        Me.lblSortBy.Location = New System.Drawing.Point(666, 4)
        Me.lblSortBy.Name = "lblSortBy"
        Me.lblSortBy.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblSortBy.Size = New System.Drawing.Size(55, 25)
        Me.lblSortBy.TabIndex = 563
        Me.lblSortBy.Text = "Sort by"
        Me.lblSortBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSortCriteria
        '
        Me.cmbSortCriteria.CausesValidation = False
        Me.cmbSortCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSortCriteria.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbSortCriteria.FormattingEnabled = True
        Me.cmbSortCriteria.Location = New System.Drawing.Point(720, 4)
        Me.cmbSortCriteria.Name = "cmbSortCriteria"
        Me.cmbSortCriteria.Size = New System.Drawing.Size(160, 25)
        Me.cmbSortCriteria.TabIndex = 564
        '
        'btnIssueStock
        '
        Me.btnIssueStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIssueStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnIssueStock.CausesValidation = False
        Me.btnIssueStock.DefaultScheme = True
        Me.btnIssueStock.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnIssueStock.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnIssueStock.Hint = "Modify record"
        Me.btnIssueStock.Location = New System.Drawing.Point(558, 526)
        Me.btnIssueStock.Margin = New System.Windows.Forms.Padding(2)
        Me.btnIssueStock.Name = "btnIssueStock"
        Me.btnIssueStock.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnIssueStock.Size = New System.Drawing.Size(95, 32)
        Me.btnIssueStock.TabIndex = 565
        Me.btnIssueStock.Text = "Issue Stock"
        '
        'grpSortMode
        '
        Me.grpSortMode.CausesValidation = False
        Me.grpSortMode.Controls.Add(Me.rdDesc)
        Me.grpSortMode.Controls.Add(Me.rdAsc)
        Me.grpSortMode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.grpSortMode.Location = New System.Drawing.Point(883, -4)
        Me.grpSortMode.Name = "grpSortMode"
        Me.grpSortMode.Size = New System.Drawing.Size(123, 34)
        Me.grpSortMode.TabIndex = 566
        Me.grpSortMode.TabStop = False
        '
        'rdDesc
        '
        Me.rdDesc.AutoSize = True
        Me.rdDesc.CausesValidation = False
        Me.rdDesc.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.rdDesc.Location = New System.Drawing.Point(65, 10)
        Me.rdDesc.Name = "rdDesc"
        Me.rdDesc.Size = New System.Drawing.Size(54, 21)
        Me.rdDesc.TabIndex = 3
        Me.rdDesc.TabStop = True
        Me.rdDesc.Text = "Desc"
        Me.rdDesc.UseVisualStyleBackColor = True
        '
        'rdAsc
        '
        Me.rdAsc.AutoSize = True
        Me.rdAsc.CausesValidation = False
        Me.rdAsc.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.rdAsc.Location = New System.Drawing.Point(10, 10)
        Me.rdAsc.Name = "rdAsc"
        Me.rdAsc.Size = New System.Drawing.Size(46, 21)
        Me.rdAsc.TabIndex = 2
        Me.rdAsc.TabStop = True
        Me.rdAsc.Text = "Asc"
        Me.rdAsc.UseVisualStyleBackColor = True
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeRows = False
        Me.dgvList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeight = 25
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPartId, Me.ColPartNo, Me.ColPartName, Me.ColImage, Me.ColItemType, Me.ColUnitPrice, Me.ColActualStock, Me.ColActualStockAmount, Me.ColOrderingPoint, Me.ColMinStock, Me.ColMaxStock, Me.ColForPr, Me.ColExpectedStock, Me.ColLocatioName, Me.ColMachineType, Me.ColItemCode, Me.ColRemarks, Me.ColIsActive})
        Me.dgvList.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgvList.Location = New System.Drawing.Point(0, 33)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvList.RowTemplate.Height = 100
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(1132, 490)
        Me.dgvList.TabIndex = 553
        '
        'ColPartId
        '
        Me.ColPartId.DataPropertyName = "PartId"
        Me.ColPartId.Frozen = True
        Me.ColPartId.HeaderText = "Part Id"
        Me.ColPartId.Name = "ColPartId"
        Me.ColPartId.ReadOnly = True
        Me.ColPartId.Visible = False
        '
        'ColPartNo
        '
        Me.ColPartNo.DataPropertyName = "PartNo"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColPartNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColPartNo.Frozen = True
        Me.ColPartNo.HeaderText = "Part No"
        Me.ColPartNo.Name = "ColPartNo"
        Me.ColPartNo.ReadOnly = True
        Me.ColPartNo.Width = 300
        '
        'ColPartName
        '
        Me.ColPartName.DataPropertyName = "PartName"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColPartName.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColPartName.Frozen = True
        Me.ColPartName.HeaderText = "Part Name"
        Me.ColPartName.Name = "ColPartName"
        Me.ColPartName.ReadOnly = True
        Me.ColPartName.Width = 300
        '
        'ColImage
        '
        Me.ColImage.DataPropertyName = "Image"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.NullValue = Nothing
        Me.ColImage.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColImage.HeaderText = "Image"
        Me.ColImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.ColImage.Name = "ColImage"
        Me.ColImage.ReadOnly = True
        Me.ColImage.Width = 200
        '
        'ColItemType
        '
        Me.ColItemType.DataPropertyName = "ItemTypeName"
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColItemType.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColItemType.HeaderText = "Item Type"
        Me.ColItemType.Name = "ColItemType"
        Me.ColItemType.ReadOnly = True
        '
        'ColUnitPrice
        '
        Me.ColUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ColUnitPrice.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColUnitPrice.HeaderText = "Unit Price"
        Me.ColUnitPrice.Name = "ColUnitPrice"
        Me.ColUnitPrice.ReadOnly = True
        '
        'ColActualStock
        '
        Me.ColActualStock.DataPropertyName = "ActualStock"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColActualStock.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColActualStock.HeaderText = "Act Stock"
        Me.ColActualStock.Name = "ColActualStock"
        Me.ColActualStock.ReadOnly = True
        Me.ColActualStock.Width = 65
        '
        'ColActualStockAmount
        '
        Me.ColActualStockAmount.DataPropertyName = "ActualStockAmount"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColActualStockAmount.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColActualStockAmount.HeaderText = "Stock Amount"
        Me.ColActualStockAmount.Name = "ColActualStockAmount"
        Me.ColActualStockAmount.ReadOnly = True
        '
        'ColOrderingPoint
        '
        Me.ColOrderingPoint.DataPropertyName = "OrderingPoint"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColOrderingPoint.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColOrderingPoint.HeaderText = "Ord Point"
        Me.ColOrderingPoint.Name = "ColOrderingPoint"
        Me.ColOrderingPoint.ReadOnly = True
        Me.ColOrderingPoint.Width = 65
        '
        'ColMinStock
        '
        Me.ColMinStock.DataPropertyName = "MinStock"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColMinStock.DefaultCellStyle = DataGridViewCellStyle10
        Me.ColMinStock.HeaderText = "Min Stock"
        Me.ColMinStock.Name = "ColMinStock"
        Me.ColMinStock.ReadOnly = True
        Me.ColMinStock.Width = 70
        '
        'ColMaxStock
        '
        Me.ColMaxStock.DataPropertyName = "MaxStock"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColMaxStock.DefaultCellStyle = DataGridViewCellStyle11
        Me.ColMaxStock.HeaderText = "Max Stock"
        Me.ColMaxStock.Name = "ColMaxStock"
        Me.ColMaxStock.ReadOnly = True
        Me.ColMaxStock.Width = 70
        '
        'ColForPr
        '
        Me.ColForPr.DataPropertyName = "ForPr"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColForPr.DefaultCellStyle = DataGridViewCellStyle12
        Me.ColForPr.HeaderText = "For PR"
        Me.ColForPr.Name = "ColForPr"
        Me.ColForPr.ReadOnly = True
        Me.ColForPr.Width = 65
        '
        'ColExpectedStock
        '
        Me.ColExpectedStock.DataPropertyName = "ExpectedStock"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColExpectedStock.DefaultCellStyle = DataGridViewCellStyle13
        Me.ColExpectedStock.HeaderText = "Exp Stock"
        Me.ColExpectedStock.Name = "ColExpectedStock"
        Me.ColExpectedStock.ReadOnly = True
        Me.ColExpectedStock.Width = 65
        '
        'ColLocatioName
        '
        Me.ColLocatioName.DataPropertyName = "LocationName"
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColLocatioName.DefaultCellStyle = DataGridViewCellStyle14
        Me.ColLocatioName.HeaderText = "Location"
        Me.ColLocatioName.Name = "ColLocatioName"
        Me.ColLocatioName.ReadOnly = True
        '
        'ColMachineType
        '
        Me.ColMachineType.DataPropertyName = "MachineTypeName"
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColMachineType.DefaultCellStyle = DataGridViewCellStyle15
        Me.ColMachineType.HeaderText = "Machine Type"
        Me.ColMachineType.Name = "ColMachineType"
        Me.ColMachineType.ReadOnly = True
        '
        'ColItemCode
        '
        Me.ColItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColItemCode.DefaultCellStyle = DataGridViewCellStyle16
        Me.ColItemCode.HeaderText = "Item Code"
        Me.ColItemCode.Name = "ColItemCode"
        Me.ColItemCode.ReadOnly = True
        '
        'ColRemarks
        '
        Me.ColRemarks.DataPropertyName = "Remarks"
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColRemarks.DefaultCellStyle = DataGridViewCellStyle17
        Me.ColRemarks.HeaderText = "Remarks"
        Me.ColRemarks.Name = "ColRemarks"
        Me.ColRemarks.ReadOnly = True
        '
        'ColIsActive
        '
        Me.ColIsActive.DataPropertyName = "IsActive"
        Me.ColIsActive.HeaderText = "Active"
        Me.ColIsActive.Name = "ColIsActive"
        Me.ColIsActive.ReadOnly = True
        Me.ColIsActive.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColIsActive.Width = 50
        '
        'MntSparePart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1132, 561)
        Me.Controls.Add(Me.grpSortMode)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cmbSearchCriteria)
        Me.Controls.Add(Me.btnIssueStock)
        Me.Controls.Add(Me.lblSortBy)
        Me.Controls.Add(Me.cmbSortCriteria)
        Me.Controls.Add(Me.btnIncomingStocks)
        Me.Controls.Add(Me.btnViewLogs)
        Me.Controls.Add(Me.btnReceiveStock)
        Me.Controls.Add(Me.pnlSearchByCmb2)
        Me.Controls.Add(Me.pnlSearchByText)
        Me.Controls.Add(Me.pnlSearchByCmb)
        Me.Controls.Add(Me.pnlSearchByDate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.bindingNavigator)
        Me.Controls.Add(Me.dgvList)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntSparePart"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Spare Parts Masterlist"
        Me.pnlSearchByText.ResumeLayout(False)
        Me.pnlSearchByText.PerformLayout()
        Me.pnlSearchByCmb.ResumeLayout(False)
        Me.pnlSearchByDate.ResumeLayout(False)
        Me.pnlSearchByDate.PerformLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator.ResumeLayout(False)
        Me.bindingNavigator.PerformLayout()
        Me.pnlSearchByCmb2.ResumeLayout(False)
        Me.cmsExport.ResumeLayout(False)
        Me.grpSortMode.ResumeLayout(False)
        Me.grpSortMode.PerformLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbSearchCriteria As ComboBox
    Friend WithEvents pnlSearchByText As Panel
    Friend WithEvents txtCommon As TextBox
    Friend WithEvents pnlSearchByCmb As Panel
    Friend WithEvents cmbCommon As SergeUtils.EasyCompletionComboBox
    Friend WithEvents pnlSearchByDate As Panel
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents lblSearchEndDate As Label
    Friend WithEvents lblSearchStartDate As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents btnReset As PinkieControls.ButtonXP
    Friend WithEvents btnSearch As PinkieControls.ButtonXP
    Private WithEvents bindingNavigator As BindingNavigator
    Friend WithEvents txtTotalPageNumber As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents txtPageNumber As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator3 As ToolStripSeparator
    Friend WithEvents btnGo As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator4 As ToolStripSeparator
    Friend WithEvents btnRefresh As ToolStripButton
    Friend WithEvents btnAdd As PinkieControls.ButtonXP
    Friend WithEvents btnEdit As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents pnlSearchByCmb2 As Panel
    Friend WithEvents cmbCommon2 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents btnViewLogs As PinkieControls.ButtonXP
    Friend WithEvents btnReceiveStock As PinkieControls.ButtonXP
    Friend WithEvents btnIncomingStocks As PinkieControls.ButtonXP
    Friend WithEvents cmsExport As ContextMenuStrip
    Friend WithEvents AllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblSortBy As Label
    Friend WithEvents cmbSortCriteria As ComboBox
    Friend WithEvents BelowOrderingPointToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnIssueStock As PinkieControls.ButtonXP
    Public WithEvents grpSortMode As GroupBox
    Public WithEvents rdDesc As RadioButton
    Public WithEvents rdAsc As RadioButton
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents BelowMinStockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColPartId As DataGridViewTextBoxColumn
    Friend WithEvents ColPartNo As DataGridViewTextBoxColumn
    Friend WithEvents ColPartName As DataGridViewTextBoxColumn
    Friend WithEvents ColImage As DataGridViewImageColumn
    Friend WithEvents ColItemType As DataGridViewTextBoxColumn
    Friend WithEvents ColUnitPrice As DataGridViewTextBoxColumn
    Friend WithEvents ColActualStock As DataGridViewTextBoxColumn
    Friend WithEvents ColActualStockAmount As DataGridViewTextBoxColumn
    Friend WithEvents ColOrderingPoint As DataGridViewTextBoxColumn
    Friend WithEvents ColMinStock As DataGridViewTextBoxColumn
    Friend WithEvents ColMaxStock As DataGridViewTextBoxColumn
    Friend WithEvents ColForPr As DataGridViewTextBoxColumn
    Friend WithEvents ColExpectedStock As DataGridViewTextBoxColumn
    Friend WithEvents ColLocatioName As DataGridViewTextBoxColumn
    Friend WithEvents ColMachineType As DataGridViewTextBoxColumn
    Friend WithEvents ColItemCode As DataGridViewTextBoxColumn
    Friend WithEvents ColRemarks As DataGridViewTextBoxColumn
    Friend WithEvents ColIsActive As DataGridViewCheckBoxColumn
    Friend WithEvents BindingNavigatorSeparator5 As ToolStripSeparator
    Friend WithEvents btnExport As ToolStripButton
End Class
