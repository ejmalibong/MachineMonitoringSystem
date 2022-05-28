<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MntMchSchedule
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MntMchSchedule))
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
        Me.dgvList = New System.Windows.Forms.DataGridView()
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
        Me.btnAdd = New PinkieControls.ButtonXP()
        Me.btnEdit = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.pnlSearchByFlag = New System.Windows.Forms.Panel()
        Me.rdNo = New System.Windows.Forms.RadioButton()
        Me.rdYes = New System.Windows.Forms.RadioButton()
        Me.ColScheduleId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMachineName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWeek = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActivityBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActivityDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColModifiedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColModifiedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIsChecklistCompleted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColIsDone = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlSearchByText.SuspendLayout()
        Me.pnlSearchByCmb.SuspendLayout()
        Me.pnlSearchByDate.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator.SuspendLayout()
        Me.pnlSearchByFlag.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbSearchCriteria
        '
        Me.cmbSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchCriteria.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbSearchCriteria.FormattingEnabled = True
        Me.cmbSearchCriteria.Location = New System.Drawing.Point(4, 5)
        Me.cmbSearchCriteria.Name = "cmbSearchCriteria"
        Me.cmbSearchCriteria.Size = New System.Drawing.Size(160, 25)
        Me.cmbSearchCriteria.TabIndex = 545
        '
        'pnlSearchByText
        '
        Me.pnlSearchByText.Controls.Add(Me.txtCommon)
        Me.pnlSearchByText.Location = New System.Drawing.Point(167, 2)
        Me.pnlSearchByText.Name = "pnlSearchByText"
        Me.pnlSearchByText.Size = New System.Drawing.Size(350, 31)
        Me.pnlSearchByText.TabIndex = 548
        '
        'txtCommon
        '
        Me.txtCommon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCommon.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommon.Location = New System.Drawing.Point(3, 3)
        Me.txtCommon.Name = "txtCommon"
        Me.txtCommon.Size = New System.Drawing.Size(344, 25)
        Me.txtCommon.TabIndex = 0
        '
        'pnlSearchByCmb
        '
        Me.pnlSearchByCmb.Controls.Add(Me.cmbCommon)
        Me.pnlSearchByCmb.Location = New System.Drawing.Point(167, 2)
        Me.pnlSearchByCmb.Name = "pnlSearchByCmb"
        Me.pnlSearchByCmb.Size = New System.Drawing.Size(350, 31)
        Me.pnlSearchByCmb.TabIndex = 549
        '
        'cmbCommon
        '
        Me.cmbCommon.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbCommon.FormattingEnabled = True
        Me.cmbCommon.Location = New System.Drawing.Point(3, 3)
        Me.cmbCommon.Name = "cmbCommon"
        Me.cmbCommon.Size = New System.Drawing.Size(344, 25)
        Me.cmbCommon.TabIndex = 546
        '
        'pnlSearchByDate
        '
        Me.pnlSearchByDate.BackColor = System.Drawing.Color.White
        Me.pnlSearchByDate.Controls.Add(Me.dtpEndDate)
        Me.pnlSearchByDate.Controls.Add(Me.lblSearchEndDate)
        Me.pnlSearchByDate.Controls.Add(Me.lblSearchStartDate)
        Me.pnlSearchByDate.Controls.Add(Me.dtpStartDate)
        Me.pnlSearchByDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pnlSearchByDate.Location = New System.Drawing.Point(167, 2)
        Me.pnlSearchByDate.Name = "pnlSearchByDate"
        Me.pnlSearchByDate.Size = New System.Drawing.Size(350, 31)
        Me.pnlSearchByDate.TabIndex = 550
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "  MMM dd, yyyy"
        Me.dtpEndDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(212, 4)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(135, 23)
        Me.dtpEndDate.TabIndex = 27
        '
        'lblSearchEndDate
        '
        Me.lblSearchEndDate.AutoSize = True
        Me.lblSearchEndDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSearchEndDate.Location = New System.Drawing.Point(188, 8)
        Me.lblSearchEndDate.Name = "lblSearchEndDate"
        Me.lblSearchEndDate.Size = New System.Drawing.Size(19, 15)
        Me.lblSearchEndDate.TabIndex = 29
        Me.lblSearchEndDate.Text = "To"
        '
        'lblSearchStartDate
        '
        Me.lblSearchStartDate.AutoSize = True
        Me.lblSearchStartDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSearchStartDate.Location = New System.Drawing.Point(6, 8)
        Me.lblSearchStartDate.Name = "lblSearchStartDate"
        Me.lblSearchStartDate.Size = New System.Drawing.Size(35, 15)
        Me.lblSearchStartDate.TabIndex = 28
        Me.lblSearchStartDate.Text = "From"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "  MMM dd, yyyy"
        Me.dtpStartDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(46, 4)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(135, 23)
        Me.dtpStartDate.TabIndex = 26
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReset.DefaultScheme = True
        Me.btnReset.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnReset.Hint = "Remove filter"
        Me.btnReset.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Undo_16_x_16
        Me.btnReset.Location = New System.Drawing.Point(609, 3)
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
        Me.btnSearch.DefaultScheme = True
        Me.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSearch.Hint = "Search"
        Me.btnSearch.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Find_16_x_16
        Me.btnSearch.Location = New System.Drawing.Point(520, 3)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSearch.Size = New System.Drawing.Size(85, 29)
        Me.btnSearch.TabIndex = 551
        Me.btnSearch.Text = "Search"
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeRows = False
        Me.dgvList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeight = 24
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColScheduleId, Me.ColMachineName, Me.ColMonth, Me.ColWeek, Me.ColCreatedBy, Me.ColActivityBy, Me.ColActivityDate, Me.ColModifiedBy, Me.ColModifiedDate, Me.ColIsChecklistCompleted, Me.ColIsDone})
        Me.dgvList.Location = New System.Drawing.Point(0, 35)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvList.Size = New System.Drawing.Size(1184, 377)
        Me.dgvList.TabIndex = 553
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
        Me.bindingNavigator.Location = New System.Drawing.Point(2, 418)
        Me.bindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bindingNavigator.Name = "bindingNavigator"
        Me.bindingNavigator.PositionItem = Me.txtPageNumber
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
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdd.DefaultScheme = True
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnAdd.Hint = ""
        Me.btnAdd.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Create_16_x_16
        Me.btnAdd.Location = New System.Drawing.Point(808, 415)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(90, 32)
        Me.btnAdd.TabIndex = 558
        Me.btnAdd.Text = " Add"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEdit.DefaultScheme = True
        Me.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnEdit.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnEdit.Hint = "Modify record"
        Me.btnEdit.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Modify_16_x_16
        Me.btnEdit.Location = New System.Drawing.Point(902, 415)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnEdit.Size = New System.Drawing.Size(90, 32)
        Me.btnEdit.TabIndex = 557
        Me.btnEdit.Text = " Edit"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = True
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnDelete.Hint = "Delete the selected record"
        Me.btnDelete.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Erase_16_x_16
        Me.btnDelete.Location = New System.Drawing.Point(996, 415)
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
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(1090, 415)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 555
        Me.btnClose.Text = "Close"
        '
        'txtYear
        '
        Me.txtYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtYear.Location = New System.Drawing.Point(1100, 6)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(80, 23)
        Me.txtYear.TabIndex = 559
        Me.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblYear
        '
        Me.lblYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblYear.BackColor = System.Drawing.SystemColors.Control
        Me.lblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.Black
        Me.lblYear.Location = New System.Drawing.Point(1041, 6)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(60, 23)
        Me.lblYear.TabIndex = 560
        Me.lblYear.Text = "Year"
        Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlSearchByFlag
        '
        Me.pnlSearchByFlag.BackColor = System.Drawing.Color.White
        Me.pnlSearchByFlag.Controls.Add(Me.rdNo)
        Me.pnlSearchByFlag.Controls.Add(Me.rdYes)
        Me.pnlSearchByFlag.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pnlSearchByFlag.Location = New System.Drawing.Point(167, 2)
        Me.pnlSearchByFlag.Name = "pnlSearchByFlag"
        Me.pnlSearchByFlag.Size = New System.Drawing.Size(350, 31)
        Me.pnlSearchByFlag.TabIndex = 561
        '
        'rdNo
        '
        Me.rdNo.AutoSize = True
        Me.rdNo.Location = New System.Drawing.Point(187, 6)
        Me.rdNo.Name = "rdNo"
        Me.rdNo.Size = New System.Drawing.Size(41, 19)
        Me.rdNo.TabIndex = 3
        Me.rdNo.TabStop = True
        Me.rdNo.Text = "No"
        Me.rdNo.UseVisualStyleBackColor = True
        '
        'rdYes
        '
        Me.rdYes.AutoSize = True
        Me.rdYes.Location = New System.Drawing.Point(52, 6)
        Me.rdYes.Name = "rdYes"
        Me.rdYes.Size = New System.Drawing.Size(42, 19)
        Me.rdYes.TabIndex = 2
        Me.rdYes.TabStop = True
        Me.rdYes.Text = "Yes"
        Me.rdYes.UseVisualStyleBackColor = True
        '
        'ColScheduleId
        '
        Me.ColScheduleId.DataPropertyName = "ScheduleId"
        Me.ColScheduleId.HeaderText = "Schedule ID"
        Me.ColScheduleId.Name = "ColScheduleId"
        Me.ColScheduleId.ReadOnly = True
        Me.ColScheduleId.Visible = False
        '
        'ColMachineName
        '
        Me.ColMachineName.DataPropertyName = "MachineName"
        Me.ColMachineName.HeaderText = "Machine"
        Me.ColMachineName.Name = "ColMachineName"
        Me.ColMachineName.ReadOnly = True
        '
        'ColMonth
        '
        Me.ColMonth.DataPropertyName = "MonthShortName"
        Me.ColMonth.HeaderText = "Month"
        Me.ColMonth.Name = "ColMonth"
        Me.ColMonth.ReadOnly = True
        '
        'ColWeek
        '
        Me.ColWeek.DataPropertyName = "WeekId"
        Me.ColWeek.HeaderText = "Week"
        Me.ColWeek.Name = "ColWeek"
        Me.ColWeek.ReadOnly = True
        '
        'ColCreatedBy
        '
        Me.ColCreatedBy.DataPropertyName = "CreatedByName"
        Me.ColCreatedBy.HeaderText = "Created By"
        Me.ColCreatedBy.Name = "ColCreatedBy"
        Me.ColCreatedBy.ReadOnly = True
        '
        'ColActivityBy
        '
        Me.ColActivityBy.DataPropertyName = "ActivityByName"
        Me.ColActivityBy.HeaderText = "Activity By"
        Me.ColActivityBy.Name = "ColActivityBy"
        Me.ColActivityBy.ReadOnly = True
        '
        'ColActivityDate
        '
        Me.ColActivityDate.DataPropertyName = "ActivityDate"
        Me.ColActivityDate.HeaderText = "Activity Date"
        Me.ColActivityDate.Name = "ColActivityDate"
        Me.ColActivityDate.ReadOnly = True
        '
        'ColModifiedBy
        '
        Me.ColModifiedBy.DataPropertyName = "ModifiedByName"
        Me.ColModifiedBy.HeaderText = "Modified By"
        Me.ColModifiedBy.Name = "ColModifiedBy"
        Me.ColModifiedBy.ReadOnly = True
        '
        'ColModifiedDate
        '
        Me.ColModifiedDate.DataPropertyName = "ModifiedDate"
        Me.ColModifiedDate.HeaderText = "Modified Date"
        Me.ColModifiedDate.Name = "ColModifiedDate"
        Me.ColModifiedDate.ReadOnly = True
        '
        'ColIsChecklistCompleted
        '
        Me.ColIsChecklistCompleted.DataPropertyName = "IsChecklistCompleted"
        Me.ColIsChecklistCompleted.HeaderText = "CS"
        Me.ColIsChecklistCompleted.Name = "ColIsChecklistCompleted"
        Me.ColIsChecklistCompleted.ReadOnly = True
        '
        'ColIsDone
        '
        Me.ColIsDone.DataPropertyName = "IsDone"
        Me.ColIsDone.HeaderText = "Done"
        Me.ColIsDone.Name = "ColIsDone"
        Me.ColIsDone.ReadOnly = True
        '
        'MntMchSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1184, 450)
        Me.Controls.Add(Me.pnlSearchByFlag)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.bindingNavigator)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cmbSearchCriteria)
        Me.Controls.Add(Me.pnlSearchByDate)
        Me.Controls.Add(Me.pnlSearchByCmb)
        Me.Controls.Add(Me.pnlSearchByText)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntMchSchedule"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Machine PM Schedule"
        Me.pnlSearchByText.ResumeLayout(False)
        Me.pnlSearchByText.PerformLayout()
        Me.pnlSearchByCmb.ResumeLayout(False)
        Me.pnlSearchByDate.ResumeLayout(False)
        Me.pnlSearchByDate.PerformLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator.ResumeLayout(False)
        Me.bindingNavigator.PerformLayout()
        Me.pnlSearchByFlag.ResumeLayout(False)
        Me.pnlSearchByFlag.PerformLayout()
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
    Friend WithEvents dgvList As DataGridView
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
    Friend WithEvents txtYear As TextBox
    Friend WithEvents lblYear As Label
    Friend WithEvents pnlSearchByFlag As Panel
    Friend WithEvents rdNo As RadioButton
    Friend WithEvents rdYes As RadioButton
    Friend WithEvents ColScheduleId As DataGridViewTextBoxColumn
    Friend WithEvents ColMachineName As DataGridViewTextBoxColumn
    Friend WithEvents ColMonth As DataGridViewTextBoxColumn
    Friend WithEvents ColWeek As DataGridViewTextBoxColumn
    Friend WithEvents ColCreatedBy As DataGridViewTextBoxColumn
    Friend WithEvents ColActivityBy As DataGridViewTextBoxColumn
    Friend WithEvents ColActivityDate As DataGridViewTextBoxColumn
    Friend WithEvents ColModifiedBy As DataGridViewTextBoxColumn
    Friend WithEvents ColModifiedDate As DataGridViewTextBoxColumn
    Friend WithEvents ColIsChecklistCompleted As DataGridViewCheckBoxColumn
    Friend WithEvents ColIsDone As DataGridViewCheckBoxColumn
End Class
