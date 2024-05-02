<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MntSparePartLogFloat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MntSparePartLogFloat))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.btnExport = New PinkieControls.ButtonXP()
        Me.btnView = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.pnlSearchByCmb2 = New System.Windows.Forms.Panel()
        Me.cmbCommon2 = New SergeUtils.EasyCompletionComboBox()
        Me.cmsExport = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BelowOrderingPointToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSortBy = New System.Windows.Forms.Label()
        Me.cmbSortCriteria = New System.Windows.Forms.ComboBox()
        Me.grpSortMode = New System.Windows.Forms.GroupBox()
        Me.rdDesc = New System.Windows.Forms.RadioButton()
        Me.rdAsc = New System.Windows.Forms.RadioButton()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.ColCreatedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTransactionCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPartName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIssuedQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColConsumedQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRemainingQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTrxId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalIssued = New System.Windows.Forms.Label()
        Me.grpTrxType = New System.Windows.Forms.GroupBox()
        Me.rdIssue = New System.Windows.Forms.RadioButton()
        Me.rdReceive = New System.Windows.Forms.RadioButton()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.txtTotalConsumed = New System.Windows.Forms.Label()
        Me.txtTotalRemaining = New System.Windows.Forms.Label()
        Me.lblTotalIssued = New System.Windows.Forms.Label()
        Me.lblTotalConsumed = New System.Windows.Forms.Label()
        Me.lblTotalRemaining = New System.Windows.Forms.Label()
        Me.pnlSearchByText.SuspendLayout()
        Me.pnlSearchByCmb.SuspendLayout()
        Me.pnlSearchByDate.SuspendLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator.SuspendLayout()
        Me.pnlSearchByCmb2.SuspendLayout()
        Me.cmsExport.SuspendLayout()
        Me.grpSortMode.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTrxType.SuspendLayout()
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
        Me.bindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator1, Me.txtPageNumber, Me.txtTotalPageNumber, Me.BindingNavigatorSeparator2, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator3, Me.btnGo, Me.BindingNavigatorSeparator4, Me.btnRefresh})
        Me.bindingNavigator.Location = New System.Drawing.Point(4, 547)
        Me.bindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bindingNavigator.Name = "bindingNavigator"
        Me.bindingNavigator.PositionItem = Me.txtPageNumber
        Me.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.bindingNavigator.Size = New System.Drawing.Size(260, 25)
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
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExport.CausesValidation = False
        Me.btnExport.DefaultScheme = True
        Me.btnExport.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnExport.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnExport.Hint = "Export selected data"
        Me.btnExport.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Download_16_x_16
        Me.btnExport.Location = New System.Drawing.Point(937, 546)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnExport.Size = New System.Drawing.Size(90, 32)
        Me.btnExport.TabIndex = 557
        Me.btnExport.Text = "Export"
        Me.btnExport.Visible = False
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnView.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnView.CausesValidation = False
        Me.btnView.DefaultScheme = True
        Me.btnView.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnView.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnView.Hint = "View transaction details"
        Me.btnView.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Text_preview_16_x_16
        Me.btnView.Location = New System.Drawing.Point(1031, 546)
        Me.btnView.Margin = New System.Windows.Forms.Padding(2)
        Me.btnView.Name = "btnView"
        Me.btnView.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnView.Size = New System.Drawing.Size(140, 32)
        Me.btnView.TabIndex = 556
        Me.btnView.Text = "View Transaction"
        Me.btnView.Visible = False
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
        Me.btnClose.Location = New System.Drawing.Point(1175, 546)
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
        'cmsExport
        '
        Me.cmsExport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllToolStripMenuItem, Me.BelowOrderingPointToolStripMenuItem})
        Me.cmsExport.Name = "cmsConsole"
        Me.cmsExport.Size = New System.Drawing.Size(188, 48)
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
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCreatedDate, Me.ColTransactionCode, Me.ColUserName, Me.ColPartNo, Me.ColPartName, Me.ColIssuedQty, Me.ColConsumedQty, Me.ColRemainingQty, Me.ColTrxId, Me.ColReferenceNo})
        Me.dgvList.Location = New System.Drawing.Point(0, 33)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(1269, 480)
        Me.dgvList.TabIndex = 553
        '
        'ColCreatedDate
        '
        Me.ColCreatedDate.DataPropertyName = "CreatedDate"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "MM/dd/yyyy"
        Me.ColCreatedDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColCreatedDate.HeaderText = "Transaction Date"
        Me.ColCreatedDate.Name = "ColCreatedDate"
        Me.ColCreatedDate.ReadOnly = True
        Me.ColCreatedDate.Width = 120
        '
        'ColTransactionCode
        '
        Me.ColTransactionCode.DataPropertyName = "TransactionCode"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColTransactionCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColTransactionCode.HeaderText = "Type"
        Me.ColTransactionCode.Name = "ColTransactionCode"
        Me.ColTransactionCode.ReadOnly = True
        Me.ColTransactionCode.Width = 50
        '
        'ColUserName
        '
        Me.ColUserName.DataPropertyName = "UserName"
        Me.ColUserName.HeaderText = "User"
        Me.ColUserName.Name = "ColUserName"
        Me.ColUserName.ReadOnly = True
        Me.ColUserName.Width = 180
        '
        'ColPartNo
        '
        Me.ColPartNo.DataPropertyName = "PartNo"
        Me.ColPartNo.HeaderText = "Part No"
        Me.ColPartNo.Name = "ColPartNo"
        Me.ColPartNo.ReadOnly = True
        Me.ColPartNo.Width = 280
        '
        'ColPartName
        '
        Me.ColPartName.DataPropertyName = "PartName"
        Me.ColPartName.HeaderText = "Part Name"
        Me.ColPartName.Name = "ColPartName"
        Me.ColPartName.ReadOnly = True
        Me.ColPartName.Width = 280
        '
        'ColIssuedQty
        '
        Me.ColIssuedQty.DataPropertyName = "IssuedQty"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColIssuedQty.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColIssuedQty.HeaderText = "Issued"
        Me.ColIssuedQty.Name = "ColIssuedQty"
        Me.ColIssuedQty.ReadOnly = True
        Me.ColIssuedQty.Width = 80
        '
        'ColConsumedQty
        '
        Me.ColConsumedQty.DataPropertyName = "ConsumedQty"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColConsumedQty.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColConsumedQty.HeaderText = "Consumed"
        Me.ColConsumedQty.Name = "ColConsumedQty"
        Me.ColConsumedQty.ReadOnly = True
        Me.ColConsumedQty.Width = 80
        '
        'ColRemainingQty
        '
        Me.ColRemainingQty.DataPropertyName = "RemainingQty"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColRemainingQty.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColRemainingQty.HeaderText = "Remaining"
        Me.ColRemainingQty.Name = "ColRemainingQty"
        Me.ColRemainingQty.ReadOnly = True
        Me.ColRemainingQty.Width = 80
        '
        'ColTrxId
        '
        Me.ColTrxId.DataPropertyName = "TrxId"
        Me.ColTrxId.HeaderText = "TrxId"
        Me.ColTrxId.Name = "ColTrxId"
        Me.ColTrxId.ReadOnly = True
        Me.ColTrxId.Visible = False
        '
        'ColReferenceNo
        '
        Me.ColReferenceNo.DataPropertyName = "ReferenceNo"
        Me.ColReferenceNo.HeaderText = "Ref No"
        Me.ColReferenceNo.Name = "ColReferenceNo"
        Me.ColReferenceNo.ReadOnly = True
        Me.ColReferenceNo.Width = 90
        '
        'txtTotalIssued
        '
        Me.txtTotalIssued.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalIssued.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtTotalIssued.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalIssued.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtTotalIssued.ForeColor = System.Drawing.Color.Black
        Me.txtTotalIssued.Location = New System.Drawing.Point(832, 512)
        Me.txtTotalIssued.Name = "txtTotalIssued"
        Me.txtTotalIssued.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.txtTotalIssued.Size = New System.Drawing.Size(77, 25)
        Me.txtTotalIssued.TabIndex = 568
        Me.txtTotalIssued.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpTrxType
        '
        Me.grpTrxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpTrxType.CausesValidation = False
        Me.grpTrxType.Controls.Add(Me.rdIssue)
        Me.grpTrxType.Controls.Add(Me.rdReceive)
        Me.grpTrxType.Controls.Add(Me.rdAll)
        Me.grpTrxType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.grpTrxType.Location = New System.Drawing.Point(10, 509)
        Me.grpTrxType.Name = "grpTrxType"
        Me.grpTrxType.Size = New System.Drawing.Size(209, 34)
        Me.grpTrxType.TabIndex = 569
        Me.grpTrxType.TabStop = False
        '
        'rdIssue
        '
        Me.rdIssue.AutoSize = True
        Me.rdIssue.CausesValidation = False
        Me.rdIssue.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.rdIssue.Location = New System.Drawing.Point(152, 10)
        Me.rdIssue.Name = "rdIssue"
        Me.rdIssue.Size = New System.Drawing.Size(55, 21)
        Me.rdIssue.TabIndex = 5
        Me.rdIssue.TabStop = True
        Me.rdIssue.Text = "Issue"
        Me.rdIssue.UseVisualStyleBackColor = True
        '
        'rdReceive
        '
        Me.rdReceive.AutoSize = True
        Me.rdReceive.CausesValidation = False
        Me.rdReceive.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.rdReceive.Location = New System.Drawing.Point(67, 10)
        Me.rdReceive.Name = "rdReceive"
        Me.rdReceive.Size = New System.Drawing.Size(70, 21)
        Me.rdReceive.TabIndex = 3
        Me.rdReceive.TabStop = True
        Me.rdReceive.Text = "Receive"
        Me.rdReceive.UseVisualStyleBackColor = True
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.CausesValidation = False
        Me.rdAll.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.rdAll.Location = New System.Drawing.Point(10, 10)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(40, 21)
        Me.rdAll.TabIndex = 2
        Me.rdAll.TabStop = True
        Me.rdAll.Text = "All"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'txtTotalConsumed
        '
        Me.txtTotalConsumed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalConsumed.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtTotalConsumed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalConsumed.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtTotalConsumed.ForeColor = System.Drawing.Color.Black
        Me.txtTotalConsumed.Location = New System.Drawing.Point(1012, 512)
        Me.txtTotalConsumed.Name = "txtTotalConsumed"
        Me.txtTotalConsumed.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.txtTotalConsumed.Size = New System.Drawing.Size(77, 25)
        Me.txtTotalConsumed.TabIndex = 570
        Me.txtTotalConsumed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalRemaining
        '
        Me.txtTotalRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalRemaining.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtTotalRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalRemaining.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtTotalRemaining.ForeColor = System.Drawing.Color.Black
        Me.txtTotalRemaining.Location = New System.Drawing.Point(1192, 512)
        Me.txtTotalRemaining.Name = "txtTotalRemaining"
        Me.txtTotalRemaining.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.txtTotalRemaining.Size = New System.Drawing.Size(77, 25)
        Me.txtTotalRemaining.TabIndex = 571
        Me.txtTotalRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalIssued
        '
        Me.lblTotalIssued.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalIssued.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotalIssued.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalIssued.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotalIssued.ForeColor = System.Drawing.Color.Black
        Me.lblTotalIssued.Location = New System.Drawing.Point(748, 512)
        Me.lblTotalIssued.Name = "lblTotalIssued"
        Me.lblTotalIssued.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblTotalIssued.Size = New System.Drawing.Size(85, 25)
        Me.lblTotalIssued.TabIndex = 572
        Me.lblTotalIssued.Text = "Total Issued"
        Me.lblTotalIssued.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalConsumed
        '
        Me.lblTotalConsumed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalConsumed.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotalConsumed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalConsumed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotalConsumed.ForeColor = System.Drawing.Color.Black
        Me.lblTotalConsumed.Location = New System.Drawing.Point(908, 512)
        Me.lblTotalConsumed.Name = "lblTotalConsumed"
        Me.lblTotalConsumed.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblTotalConsumed.Size = New System.Drawing.Size(105, 25)
        Me.lblTotalConsumed.TabIndex = 573
        Me.lblTotalConsumed.Text = "Total Consumed"
        Me.lblTotalConsumed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalRemaining
        '
        Me.lblTotalRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalRemaining.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotalRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalRemaining.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotalRemaining.ForeColor = System.Drawing.Color.Black
        Me.lblTotalRemaining.Location = New System.Drawing.Point(1088, 512)
        Me.lblTotalRemaining.Name = "lblTotalRemaining"
        Me.lblTotalRemaining.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblTotalRemaining.Size = New System.Drawing.Size(105, 25)
        Me.lblTotalRemaining.TabIndex = 574
        Me.lblTotalRemaining.Text = "Total Remaining"
        Me.lblTotalRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MntSparePartLogFloat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1269, 581)
        Me.Controls.Add(Me.grpSortMode)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cmbSearchCriteria)
        Me.Controls.Add(Me.lblSortBy)
        Me.Controls.Add(Me.cmbSortCriteria)
        Me.Controls.Add(Me.pnlSearchByCmb2)
        Me.Controls.Add(Me.pnlSearchByText)
        Me.Controls.Add(Me.pnlSearchByCmb)
        Me.Controls.Add(Me.pnlSearchByDate)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.bindingNavigator)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.txtTotalIssued)
        Me.Controls.Add(Me.grpTrxType)
        Me.Controls.Add(Me.txtTotalConsumed)
        Me.Controls.Add(Me.txtTotalRemaining)
        Me.Controls.Add(Me.lblTotalIssued)
        Me.Controls.Add(Me.lblTotalConsumed)
        Me.Controls.Add(Me.lblTotalRemaining)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntSparePartLogFloat"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Float Transaction Logs"
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
        Me.grpTrxType.ResumeLayout(False)
        Me.grpTrxType.PerformLayout()
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
    Friend WithEvents btnExport As PinkieControls.ButtonXP
    Friend WithEvents btnView As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents pnlSearchByCmb2 As Panel
    Friend WithEvents cmbCommon2 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cmsExport As ContextMenuStrip
    Friend WithEvents AllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblSortBy As Label
    Friend WithEvents cmbSortCriteria As ComboBox
    Friend WithEvents BelowOrderingPointToolStripMenuItem As ToolStripMenuItem
    Public WithEvents grpSortMode As GroupBox
    Public WithEvents rdDesc As RadioButton
    Public WithEvents rdAsc As RadioButton
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents txtTotalIssued As Label
    Public WithEvents grpTrxType As GroupBox
    Public WithEvents rdReceive As RadioButton
    Public WithEvents rdAll As RadioButton
    Public WithEvents rdIssue As RadioButton
    Friend WithEvents ColCreatedDate As DataGridViewTextBoxColumn
    Friend WithEvents ColTransactionCode As DataGridViewTextBoxColumn
    Friend WithEvents ColUserName As DataGridViewTextBoxColumn
    Friend WithEvents ColPartNo As DataGridViewTextBoxColumn
    Friend WithEvents ColPartName As DataGridViewTextBoxColumn
    Friend WithEvents ColIssuedQty As DataGridViewTextBoxColumn
    Friend WithEvents ColConsumedQty As DataGridViewTextBoxColumn
    Friend WithEvents ColRemainingQty As DataGridViewTextBoxColumn
    Friend WithEvents ColTrxId As DataGridViewTextBoxColumn
    Friend WithEvents ColReferenceNo As DataGridViewTextBoxColumn
    Friend WithEvents txtTotalConsumed As Label
    Friend WithEvents txtTotalRemaining As Label
    Friend WithEvents lblTotalIssued As Label
    Friend WithEvents lblTotalConsumed As Label
    Friend WithEvents lblTotalRemaining As Label
End Class
