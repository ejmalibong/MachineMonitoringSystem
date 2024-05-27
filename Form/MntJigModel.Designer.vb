<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MntJigModel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MntJigModel))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnEdit = New PinkieControls.ButtonXP()
        Me.btnAdd = New PinkieControls.ButtonXP()
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
        Me.cmbSearchCriteria = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New PinkieControls.ButtonXP()
        Me.btnReset = New PinkieControls.ButtonXP()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.ColModelId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColModelName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColExtensionId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColExtensionName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIsActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColIsDrawing = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlSearchByCmb = New System.Windows.Forms.Panel()
        Me.cmbCommon = New SergeUtils.EasyCompletionComboBox()
        Me.pnlSearchByText = New System.Windows.Forms.Panel()
        Me.txtCommon = New System.Windows.Forms.TextBox()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.pnlImage = New System.Windows.Forms.Panel()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.AxAcroPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.lblAttachmentCount = New System.Windows.Forms.Label()
        Me.txtAttachmentName = New System.Windows.Forms.Label()
        Me.btnView = New PinkieControls.ButtonXP()
        Me.btnNext = New PinkieControls.ButtonXP()
        Me.btnPrevious = New PinkieControls.ButtonXP()
        Me.BindingNavigatorSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.CountToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearchByCmb.SuspendLayout()
        Me.pnlSearchByText.SuspendLayout()
        Me.pnlImage.SuspendLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxAcroPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(891, 526)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 539
        Me.btnClose.Text = "Close"
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
        Me.btnDelete.Location = New System.Drawing.Point(797, 526)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 540
        Me.btnDelete.Text = "Delete"
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
        Me.btnEdit.Location = New System.Drawing.Point(703, 526)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnEdit.Size = New System.Drawing.Size(90, 32)
        Me.btnEdit.TabIndex = 541
        Me.btnEdit.Text = " Edit"
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
        Me.btnAdd.Location = New System.Drawing.Point(609, 526)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(90, 32)
        Me.btnAdd.TabIndex = 542
        Me.btnAdd.Text = " Add"
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
        Me.bindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator1, Me.txtPageNumber, Me.txtTotalPageNumber, Me.BindingNavigatorSeparator2, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator3, Me.btnGo, Me.BindingNavigatorSeparator4, Me.btnRefresh, Me.BindingNavigatorSeparator5, Me.CountToolStripLabel})
        Me.bindingNavigator.Location = New System.Drawing.Point(0, 530)
        Me.bindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bindingNavigator.Name = "bindingNavigator"
        Me.bindingNavigator.PositionItem = Me.txtPageNumber
        Me.bindingNavigator.Size = New System.Drawing.Size(266, 25)
        Me.bindingNavigator.TabIndex = 543
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
        'cmbSearchCriteria
        '
        Me.cmbSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchCriteria.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchCriteria.FormattingEnabled = True
        Me.cmbSearchCriteria.Location = New System.Drawing.Point(4, 4)
        Me.cmbSearchCriteria.Name = "cmbSearchCriteria"
        Me.cmbSearchCriteria.Size = New System.Drawing.Size(160, 25)
        Me.cmbSearchCriteria.TabIndex = 544
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearch.DefaultScheme = True
        Me.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSearch.Hint = "Search"
        Me.btnSearch.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Find_16_x_16
        Me.btnSearch.Location = New System.Drawing.Point(514, 2)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSearch.Size = New System.Drawing.Size(85, 29)
        Me.btnSearch.TabIndex = 546
        Me.btnSearch.Text = "Search"
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReset.DefaultScheme = True
        Me.btnReset.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnReset.Hint = "Remove filter"
        Me.btnReset.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Undo_16_x_16
        Me.btnReset.Location = New System.Drawing.Point(602, 2)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnReset.Size = New System.Drawing.Size(85, 29)
        Me.btnReset.TabIndex = 547
        Me.btnReset.Text = "Reset"
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeRows = False
        Me.dgvList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeight = 24
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColModelId, Me.ColModelName, Me.ColExtensionId, Me.ColExtensionName, Me.ColIsActive, Me.ColIsDrawing})
        Me.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvList.Location = New System.Drawing.Point(0, 33)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(523, 490)
        Me.dgvList.TabIndex = 549
        Me.dgvList.TabStop = False
        '
        'ColModelId
        '
        Me.ColModelId.DataPropertyName = "ModelId"
        Me.ColModelId.HeaderText = "ModelId"
        Me.ColModelId.Name = "ColModelId"
        Me.ColModelId.ReadOnly = True
        Me.ColModelId.Visible = False
        '
        'ColModelName
        '
        Me.ColModelName.DataPropertyName = "ModelName"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ColModelName.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColModelName.HeaderText = "Model Name"
        Me.ColModelName.Name = "ColModelName"
        Me.ColModelName.ReadOnly = True
        Me.ColModelName.Width = 250
        '
        'ColExtensionId
        '
        Me.ColExtensionId.DataPropertyName = "ExtensionId"
        Me.ColExtensionId.HeaderText = "ExtensionId"
        Me.ColExtensionId.Name = "ColExtensionId"
        Me.ColExtensionId.ReadOnly = True
        Me.ColExtensionId.Visible = False
        '
        'ColExtensionName
        '
        Me.ColExtensionName.DataPropertyName = "ExtensionName"
        Me.ColExtensionName.HeaderText = "Extension Name"
        Me.ColExtensionName.Name = "ColExtensionName"
        Me.ColExtensionName.ReadOnly = True
        Me.ColExtensionName.Width = 150
        '
        'ColIsActive
        '
        Me.ColIsActive.DataPropertyName = "IsActive"
        Me.ColIsActive.HeaderText = "Active"
        Me.ColIsActive.Name = "ColIsActive"
        Me.ColIsActive.ReadOnly = True
        Me.ColIsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColIsActive.Width = 55
        '
        'ColIsDrawing
        '
        Me.ColIsDrawing.DataPropertyName = "IsDrawing"
        Me.ColIsDrawing.HeaderText = "Drwg"
        Me.ColIsDrawing.Name = "ColIsDrawing"
        Me.ColIsDrawing.ReadOnly = True
        Me.ColIsDrawing.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColIsDrawing.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColIsDrawing.Width = 55
        '
        'pnlSearchByCmb
        '
        Me.pnlSearchByCmb.Controls.Add(Me.cmbCommon)
        Me.pnlSearchByCmb.Location = New System.Drawing.Point(164, 3)
        Me.pnlSearchByCmb.Name = "pnlSearchByCmb"
        Me.pnlSearchByCmb.Size = New System.Drawing.Size(350, 27)
        Me.pnlSearchByCmb.TabIndex = 545
        '
        'cmbCommon
        '
        Me.cmbCommon.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCommon.FormattingEnabled = True
        Me.cmbCommon.Location = New System.Drawing.Point(3, 2)
        Me.cmbCommon.Name = "cmbCommon"
        Me.cmbCommon.Size = New System.Drawing.Size(344, 23)
        Me.cmbCommon.TabIndex = 546
        '
        'pnlSearchByText
        '
        Me.pnlSearchByText.Controls.Add(Me.txtCommon)
        Me.pnlSearchByText.Location = New System.Drawing.Point(164, 3)
        Me.pnlSearchByText.Name = "pnlSearchByText"
        Me.pnlSearchByText.Size = New System.Drawing.Size(350, 27)
        Me.pnlSearchByText.TabIndex = 547
        '
        'txtCommon
        '
        Me.txtCommon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCommon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommon.Location = New System.Drawing.Point(3, 2)
        Me.txtCommon.Name = "txtCommon"
        Me.txtCommon.Size = New System.Drawing.Size(344, 23)
        Me.txtCommon.TabIndex = 0
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DataPropertyName = "AreaId"
        Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DataGridViewComboBoxColumn1.HeaderText = "Area"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.ReadOnly = True
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn1.Width = 120
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.DataPropertyName = "MachineStatusId"
        Me.DataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DataGridViewComboBoxColumn2.HeaderText = "Machine Status"
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.ReadOnly = True
        Me.DataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn2.Width = 120
        '
        'DataGridViewComboBoxColumn3
        '
        Me.DataGridViewComboBoxColumn3.DataPropertyName = "MachineSubStatusId"
        Me.DataGridViewComboBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DataGridViewComboBoxColumn3.HeaderText = ""
        Me.DataGridViewComboBoxColumn3.Name = "DataGridViewComboBoxColumn3"
        Me.DataGridViewComboBoxColumn3.ReadOnly = True
        Me.DataGridViewComboBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn3.Width = 120
        '
        'pnlImage
        '
        Me.pnlImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlImage.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImage.Controls.Add(Me.picImage)
        Me.pnlImage.Controls.Add(Me.AxAcroPDF)
        Me.pnlImage.Controls.Add(Me.lblAttachmentCount)
        Me.pnlImage.Controls.Add(Me.txtAttachmentName)
        Me.pnlImage.Controls.Add(Me.btnView)
        Me.pnlImage.Controls.Add(Me.btnNext)
        Me.pnlImage.Controls.Add(Me.btnPrevious)
        Me.pnlImage.Location = New System.Drawing.Point(526, 33)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(455, 490)
        Me.pnlImage.TabIndex = 550
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
        Me.picImage.Location = New System.Drawing.Point(3, 20)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(447, 438)
        Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage.TabIndex = 0
        Me.picImage.TabStop = False
        '
        'AxAcroPDF
        '
        Me.AxAcroPDF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxAcroPDF.Enabled = True
        Me.AxAcroPDF.Location = New System.Drawing.Point(3, 20)
        Me.AxAcroPDF.Name = "AxAcroPDF"
        Me.AxAcroPDF.OcxState = CType(resources.GetObject("AxAcroPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF.Size = New System.Drawing.Size(447, 438)
        Me.AxAcroPDF.TabIndex = 578
        '
        'lblAttachmentCount
        '
        Me.lblAttachmentCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAttachmentCount.AutoSize = True
        Me.lblAttachmentCount.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblAttachmentCount.Location = New System.Drawing.Point(261, 466)
        Me.lblAttachmentCount.Name = "lblAttachmentCount"
        Me.lblAttachmentCount.Size = New System.Drawing.Size(24, 15)
        Me.lblAttachmentCount.TabIndex = 577
        Me.lblAttachmentCount.Text = "0/0"
        '
        'txtAttachmentName
        '
        Me.txtAttachmentName.AutoSize = True
        Me.txtAttachmentName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAttachmentName.Location = New System.Drawing.Point(3, 2)
        Me.txtAttachmentName.Name = "txtAttachmentName"
        Me.txtAttachmentName.Size = New System.Drawing.Size(55, 15)
        Me.txtAttachmentName.TabIndex = 576
        Me.txtAttachmentName.Text = "Filename"
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnView.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnView.DefaultScheme = False
        Me.btnView.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnView.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Hint = "View"
        Me.btnView.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Expand_16_x_16
        Me.btnView.Location = New System.Drawing.Point(66, 460)
        Me.btnView.Name = "btnView"
        Me.btnView.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnView.Size = New System.Drawing.Size(28, 26)
        Me.btnView.TabIndex = 575
        Me.btnView.TabStop = False
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnNext.DefaultScheme = False
        Me.btnNext.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnNext.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Hint = "Next"
        Me.btnNext.Location = New System.Drawing.Point(34, 460)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnNext.Size = New System.Drawing.Size(28, 26)
        Me.btnNext.TabIndex = 574
        Me.btnNext.TabStop = False
        Me.btnNext.Text = ">"
        '
        'btnPrevious
        '
        Me.btnPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrevious.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnPrevious.DefaultScheme = False
        Me.btnPrevious.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnPrevious.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.Hint = "Previous"
        Me.btnPrevious.Location = New System.Drawing.Point(2, 460)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnPrevious.Size = New System.Drawing.Size(28, 26)
        Me.btnPrevious.TabIndex = 573
        Me.btnPrevious.TabStop = False
        Me.btnPrevious.Text = "<"
        '
        'BindingNavigatorSeparator5
        '
        Me.BindingNavigatorSeparator5.Name = "BindingNavigatorSeparator5"
        Me.BindingNavigatorSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'CountToolStripLabel
        '
        Me.CountToolStripLabel.Name = "CountToolStripLabel"
        Me.CountToolStripLabel.Size = New System.Drawing.Size(0, 22)
        '
        'MntJigModel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.pnlImage)
        Me.Controls.Add(Me.pnlSearchByText)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.pnlSearchByCmb)
        Me.Controls.Add(Me.cmbSearchCriteria)
        Me.Controls.Add(Me.bindingNavigator)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnClose)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntJigModel"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Model Masterlist"
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator.ResumeLayout(False)
        Me.bindingNavigator.PerformLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearchByCmb.ResumeLayout(False)
        Me.pnlSearchByText.ResumeLayout(False)
        Me.pnlSearchByText.PerformLayout()
        Me.pnlImage.ResumeLayout(False)
        Me.pnlImage.PerformLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxAcroPDF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnEdit As PinkieControls.ButtonXP
    Friend WithEvents btnAdd As PinkieControls.ButtonXP
    Friend WithEvents txtTotalPageNumber As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtPageNumber As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGo As System.Windows.Forms.ToolStripButton
    Private WithEvents bindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents cmbSearchCriteria As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As PinkieControls.ButtonXP
    Friend WithEvents btnReset As PinkieControls.ButtonXP
    Friend WithEvents BindingNavigatorSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlSearchByCmb As System.Windows.Forms.Panel
    Friend WithEvents cmbCommon As SergeUtils.EasyCompletionComboBox
    Private WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewNullableComboBoxColumn1 As MachineMonitoringSystem.DataGridViewNullableComboBoxColumn
    Friend WithEvents DataGridViewNullableComboBoxColumn2 As MachineMonitoringSystem.DataGridViewNullableComboBoxColumn
    Friend WithEvents pnlSearchByText As System.Windows.Forms.Panel
    Friend WithEvents txtCommon As System.Windows.Forms.TextBox
    Friend WithEvents pnlImage As Panel
    Friend WithEvents picImage As PictureBox
    Friend WithEvents btnView As PinkieControls.ButtonXP
    Friend WithEvents btnNext As PinkieControls.ButtonXP
    Friend WithEvents btnPrevious As PinkieControls.ButtonXP
    Friend WithEvents lblAttachmentCount As Label
    Friend WithEvents txtAttachmentName As Label
    Friend WithEvents AxAcroPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents ColModelId As DataGridViewTextBoxColumn
    Friend WithEvents ColModelName As DataGridViewTextBoxColumn
    Friend WithEvents ColExtensionId As DataGridViewTextBoxColumn
    Friend WithEvents ColExtensionName As DataGridViewTextBoxColumn
    Friend WithEvents ColIsActive As DataGridViewCheckBoxColumn
    Friend WithEvents ColIsDrawing As DataGridViewCheckBoxColumn
    Friend WithEvents BindingNavigatorSeparator5 As ToolStripSeparator
    Friend WithEvents CountToolStripLabel As ToolStripLabel
End Class
