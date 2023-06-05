<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FacMchSched
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FacMchSched))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.lblYear = New System.Windows.Forms.Label()
        Me.txtYearId = New System.Windows.Forms.MaskedTextBox()
        Me.ColScheduleId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWeek = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMachineName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPmFrequency = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.dgvList.ColumnHeadersHeight = 25
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColScheduleId, Me.ColMonth, Me.ColWeek, Me.ColMachineName, Me.ColPmFrequency, Me.ColCreatedBy, Me.ColActivityBy, Me.ColActivityDate, Me.ColModifiedBy, Me.ColModifiedDate, Me.ColIsChecklistCompleted, Me.ColIsDone})
        Me.dgvList.Location = New System.Drawing.Point(0, 33)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(1014, 490)
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
        Me.bindingNavigator.Location = New System.Drawing.Point(4, 527)
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
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdd.DefaultScheme = True
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnAdd.Hint = ""
        Me.btnAdd.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Create_16_x_16
        Me.btnAdd.Location = New System.Drawing.Point(638, 526)
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
        Me.btnEdit.DefaultScheme = True
        Me.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnEdit.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnEdit.Hint = "Modify record"
        Me.btnEdit.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Modify_16_x_16
        Me.btnEdit.Location = New System.Drawing.Point(732, 526)
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
        Me.btnDelete.DefaultScheme = True
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnDelete.Hint = "Delete the selected record"
        Me.btnDelete.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Erase_16_x_16
        Me.btnDelete.Location = New System.Drawing.Point(826, 526)
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
        Me.btnClose.Location = New System.Drawing.Point(920, 526)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 555
        Me.btnClose.Text = "Close"
        '
        'lblYear
        '
        Me.lblYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblYear.BackColor = System.Drawing.SystemColors.Control
        Me.lblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.Black
        Me.lblYear.Location = New System.Drawing.Point(871, 5)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(60, 24)
        Me.lblYear.TabIndex = 560
        Me.lblYear.Text = "Year"
        Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtYearId
        '
        Me.txtYearId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtYearId.BeepOnError = True
        Me.txtYearId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYearId.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYearId.Location = New System.Drawing.Point(930, 5)
        Me.txtYearId.Mask = "0000"
        Me.txtYearId.Name = "txtYearId"
        Me.txtYearId.ResetOnSpace = False
        Me.txtYearId.Size = New System.Drawing.Size(80, 24)
        Me.txtYearId.TabIndex = 579
        Me.txtYearId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColScheduleId
        '
        Me.ColScheduleId.DataPropertyName = "ScheduleId"
        Me.ColScheduleId.HeaderText = "Schedule ID"
        Me.ColScheduleId.Name = "ColScheduleId"
        Me.ColScheduleId.ReadOnly = True
        Me.ColScheduleId.Visible = False
        '
        'ColMonth
        '
        Me.ColMonth.DataPropertyName = "MonthShortName"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColMonth.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColMonth.HeaderText = "Month"
        Me.ColMonth.Name = "ColMonth"
        Me.ColMonth.ReadOnly = True
        Me.ColMonth.Width = 60
        '
        'ColWeek
        '
        Me.ColWeek.DataPropertyName = "WeekId"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColWeek.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColWeek.HeaderText = "Week"
        Me.ColWeek.Name = "ColWeek"
        Me.ColWeek.ReadOnly = True
        Me.ColWeek.Width = 50
        '
        'ColMachineName
        '
        Me.ColMachineName.DataPropertyName = "MachineCode"
        Me.ColMachineName.HeaderText = "Machine"
        Me.ColMachineName.Name = "ColMachineName"
        Me.ColMachineName.ReadOnly = True
        Me.ColMachineName.Width = 150
        '
        'ColPmFrequency
        '
        Me.ColPmFrequency.DataPropertyName = "PmFrequencyId"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColPmFrequency.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColPmFrequency.HeaderText = "Freq"
        Me.ColPmFrequency.Name = "ColPmFrequency"
        Me.ColPmFrequency.ReadOnly = True
        Me.ColPmFrequency.Width = 50
        '
        'ColCreatedBy
        '
        Me.ColCreatedBy.DataPropertyName = "CreatedByNickname"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColCreatedBy.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColCreatedBy.HeaderText = "Created By"
        Me.ColCreatedBy.Name = "ColCreatedBy"
        Me.ColCreatedBy.ReadOnly = True
        '
        'ColActivityBy
        '
        Me.ColActivityBy.DataPropertyName = "ActivityByNickname"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColActivityBy.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColActivityBy.HeaderText = "Activity By"
        Me.ColActivityBy.Name = "ColActivityBy"
        Me.ColActivityBy.ReadOnly = True
        Me.ColActivityBy.Width = 120
        '
        'ColActivityDate
        '
        Me.ColActivityDate.DataPropertyName = "ActivityDate"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "MM/dd/yyyy hh:mm tt"
        Me.ColActivityDate.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColActivityDate.HeaderText = "Activity Date"
        Me.ColActivityDate.Name = "ColActivityDate"
        Me.ColActivityDate.ReadOnly = True
        Me.ColActivityDate.Width = 120
        '
        'ColModifiedBy
        '
        Me.ColModifiedBy.DataPropertyName = "ModifiedByNickname"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColModifiedBy.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColModifiedBy.HeaderText = "Modified By"
        Me.ColModifiedBy.Name = "ColModifiedBy"
        Me.ColModifiedBy.ReadOnly = True
        '
        'ColModifiedDate
        '
        Me.ColModifiedDate.DataPropertyName = "ModifiedDate"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Format = "MM/dd/yyyy hh:mm tt"
        Me.ColModifiedDate.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColModifiedDate.HeaderText = "Modified Date"
        Me.ColModifiedDate.Name = "ColModifiedDate"
        Me.ColModifiedDate.ReadOnly = True
        Me.ColModifiedDate.Width = 120
        '
        'ColIsChecklistCompleted
        '
        Me.ColIsChecklistCompleted.DataPropertyName = "IsChecklistCompleted"
        Me.ColIsChecklistCompleted.HeaderText = "CS"
        Me.ColIsChecklistCompleted.Name = "ColIsChecklistCompleted"
        Me.ColIsChecklistCompleted.ReadOnly = True
        Me.ColIsChecklistCompleted.Visible = False
        Me.ColIsChecklistCompleted.Width = 50
        '
        'ColIsDone
        '
        Me.ColIsDone.DataPropertyName = "IsDone"
        Me.ColIsDone.HeaderText = "Done"
        Me.ColIsDone.Name = "ColIsDone"
        Me.ColIsDone.ReadOnly = True
        Me.ColIsDone.Width = 50
        '
        'FacMchSched
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(1014, 561)
        Me.Controls.Add(Me.pnlSearchByText)
        Me.Controls.Add(Me.pnlSearchByCmb)
        Me.Controls.Add(Me.pnlSearchByDate)
        Me.Controls.Add(Me.txtYearId)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.bindingNavigator)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cmbSearchCriteria)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FacMchSched"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
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
    Friend WithEvents lblYear As Label
    Friend WithEvents txtYearId As MaskedTextBox
    Friend WithEvents ColScheduleId As DataGridViewTextBoxColumn
    Friend WithEvents ColMonth As DataGridViewTextBoxColumn
    Friend WithEvents ColWeek As DataGridViewTextBoxColumn
    Friend WithEvents ColMachineName As DataGridViewTextBoxColumn
    Friend WithEvents ColPmFrequency As DataGridViewTextBoxColumn
    Friend WithEvents ColCreatedBy As DataGridViewTextBoxColumn
    Friend WithEvents ColActivityBy As DataGridViewTextBoxColumn
    Friend WithEvents ColActivityDate As DataGridViewTextBoxColumn
    Friend WithEvents ColModifiedBy As DataGridViewTextBoxColumn
    Friend WithEvents ColModifiedDate As DataGridViewTextBoxColumn
    Friend WithEvents ColIsChecklistCompleted As DataGridViewCheckBoxColumn
    Friend WithEvents ColIsDone As DataGridViewCheckBoxColumn
End Class
