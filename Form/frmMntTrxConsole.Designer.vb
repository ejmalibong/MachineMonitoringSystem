<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMntTrxConsole
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMntTrxConsole))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnEdit = New PinkieControls.ButtonXP()
        Me.btnCreate = New PinkieControls.ButtonXP()
        Me.dgvMachine = New System.Windows.Forms.DataGridView()
        Me.MachineIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MachineNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MachineStatusIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastTransactionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ElapsedTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpCriteria = New System.Windows.Forms.GroupBox()
        Me.bindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.pnlDateSearch = New System.Windows.Forms.Panel()
        Me.lblStartFrom = New System.Windows.Forms.Label()
        Me.btnResetDate = New System.Windows.Forms.Button()
        Me.btnSearchDate = New System.Windows.Forms.Button()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.lblStartTo = New System.Windows.Forms.Label()
        Me.lblCriteria = New System.Windows.Forms.Label()
        Me.cmbSearchCriteria = New System.Windows.Forms.ComboBox()
        Me.dgvTransactionHeader = New System.Windows.Forms.DataGridView()
        Me.TrxIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShiftIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatetimeStartedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActivityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatetimeEndedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAccumulatedTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SeniorEngineerIsApprovedColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.rdOngoing = New System.Windows.Forms.RadioButton()
        Me.rdDone = New System.Windows.Forms.RadioButton()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.btnRefresh = New PinkieControls.ButtonXP()
        CType(Me.dgvMachine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCriteria.SuspendLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator.SuspendLayout()
        Me.pnlDateSearch.SuspendLayout()
        CType(Me.dgvTransactionHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnClose.Hint = ""
        Me.btnClose.Location = New System.Drawing.Point(1209, 565)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(100, 30)
        Me.btnClose.TabIndex = 155
        Me.btnClose.Text = "  Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = False
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnDelete.Hint = ""
        Me.btnDelete.Location = New System.Drawing.Point(1108, 565)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(100, 30)
        Me.btnDelete.TabIndex = 154
        Me.btnDelete.Text = "  Delete"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEdit.DefaultScheme = False
        Me.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnEdit.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnEdit.Hint = ""
        Me.btnEdit.Location = New System.Drawing.Point(1007, 565)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 153
        Me.btnEdit.Text = "  Edit"
        '
        'btnCreate
        '
        Me.btnCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreate.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCreate.DefaultScheme = False
        Me.btnCreate.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnCreate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnCreate.Hint = ""
        Me.btnCreate.Location = New System.Drawing.Point(906, 565)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCreate.Size = New System.Drawing.Size(100, 30)
        Me.btnCreate.TabIndex = 152
        Me.btnCreate.Text = " Create"
        '
        'dgvMachine
        '
        Me.dgvMachine.AllowUserToAddRows = False
        Me.dgvMachine.AllowUserToDeleteRows = False
        Me.dgvMachine.AllowUserToResizeColumns = False
        Me.dgvMachine.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.5!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvMachine.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMachine.ColumnHeadersHeight = 25
        Me.dgvMachine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvMachine.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MachineIdColumn, Me.MachineNameColumn, Me.MachineStatusIdColumn, Me.LastTransactionColumn, Me.ElapsedTimeColumn})
        Me.dgvMachine.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvMachine.Location = New System.Drawing.Point(0, 0)
        Me.dgvMachine.MultiSelect = False
        Me.dgvMachine.Name = "dgvMachine"
        Me.dgvMachine.ReadOnly = True
        Me.dgvMachine.RowHeadersVisible = False
        Me.dgvMachine.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvMachine.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvMachine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvMachine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMachine.Size = New System.Drawing.Size(336, 601)
        Me.dgvMachine.TabIndex = 156
        '
        'MachineIdColumn
        '
        Me.MachineIdColumn.DataPropertyName = "MachineId"
        Me.MachineIdColumn.HeaderText = "MachineId"
        Me.MachineIdColumn.Name = "MachineIdColumn"
        Me.MachineIdColumn.ReadOnly = True
        Me.MachineIdColumn.Visible = False
        '
        'MachineNameColumn
        '
        Me.MachineNameColumn.DataPropertyName = "MachineName"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.MachineNameColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.MachineNameColumn.HeaderText = "Machine"
        Me.MachineNameColumn.Name = "MachineNameColumn"
        Me.MachineNameColumn.ReadOnly = True
        Me.MachineNameColumn.Width = 140
        '
        'MachineStatusIdColumn
        '
        Me.MachineStatusIdColumn.DataPropertyName = "MachineStatusId"
        Me.MachineStatusIdColumn.HeaderText = "MachineStatusId"
        Me.MachineStatusIdColumn.Name = "MachineStatusIdColumn"
        Me.MachineStatusIdColumn.ReadOnly = True
        Me.MachineStatusIdColumn.Visible = False
        '
        'LastTransactionColumn
        '
        DataGridViewCellStyle3.Format = "G"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.LastTransactionColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.LastTransactionColumn.HeaderText = "LastTransaction"
        Me.LastTransactionColumn.Name = "LastTransactionColumn"
        Me.LastTransactionColumn.ReadOnly = True
        Me.LastTransactionColumn.Visible = False
        '
        'ElapsedTimeColumn
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.NullValue = Nothing
        Me.ElapsedTimeColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ElapsedTimeColumn.HeaderText = "RT / DT"
        Me.ElapsedTimeColumn.Name = "ElapsedTimeColumn"
        Me.ElapsedTimeColumn.ReadOnly = True
        Me.ElapsedTimeColumn.Width = 75
        '
        'grpCriteria
        '
        Me.grpCriteria.Controls.Add(Me.bindingNavigator)
        Me.grpCriteria.Controls.Add(Me.pnlDateSearch)
        Me.grpCriteria.Controls.Add(Me.lblCriteria)
        Me.grpCriteria.Controls.Add(Me.cmbSearchCriteria)
        Me.grpCriteria.Location = New System.Drawing.Point(339, -6)
        Me.grpCriteria.Margin = New System.Windows.Forms.Padding(0)
        Me.grpCriteria.Name = "grpCriteria"
        Me.grpCriteria.Size = New System.Drawing.Size(974, 40)
        Me.grpCriteria.TabIndex = 157
        Me.grpCriteria.TabStop = False
        '
        'bindingNavigator
        '
        Me.bindingNavigator.AddNewItem = Nothing
        Me.bindingNavigator.BackColor = System.Drawing.Color.White
        Me.bindingNavigator.CountItem = Nothing
        Me.bindingNavigator.DeleteItem = Nothing
        Me.bindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.bindingNavigator.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.bindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem})
        Me.bindingNavigator.Location = New System.Drawing.Point(873, 9)
        Me.bindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bindingNavigator.Name = "bindingNavigator"
        Me.bindingNavigator.PositionItem = Nothing
        Me.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.bindingNavigator.Size = New System.Drawing.Size(101, 25)
        Me.bindingNavigator.TabIndex = 161
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
        'pnlDateSearch
        '
        Me.pnlDateSearch.Controls.Add(Me.lblStartFrom)
        Me.pnlDateSearch.Controls.Add(Me.btnResetDate)
        Me.pnlDateSearch.Controls.Add(Me.btnSearchDate)
        Me.pnlDateSearch.Controls.Add(Me.dtpFrom)
        Me.pnlDateSearch.Controls.Add(Me.dtpTo)
        Me.pnlDateSearch.Controls.Add(Me.lblStartTo)
        Me.pnlDateSearch.Location = New System.Drawing.Point(265, 9)
        Me.pnlDateSearch.Name = "pnlDateSearch"
        Me.pnlDateSearch.Size = New System.Drawing.Size(520, 28)
        Me.pnlDateSearch.TabIndex = 6
        '
        'lblStartFrom
        '
        Me.lblStartFrom.AutoSize = True
        Me.lblStartFrom.Location = New System.Drawing.Point(3, 7)
        Me.lblStartFrom.Name = "lblStartFrom"
        Me.lblStartFrom.Size = New System.Drawing.Size(38, 14)
        Me.lblStartFrom.TabIndex = 18
        Me.lblStartFrom.Text = "From"
        '
        'btnResetDate
        '
        Me.btnResetDate.Location = New System.Drawing.Point(433, 2)
        Me.btnResetDate.Name = "btnResetDate"
        Me.btnResetDate.Size = New System.Drawing.Size(85, 24)
        Me.btnResetDate.TabIndex = 5
        Me.btnResetDate.Text = "Reset"
        Me.btnResetDate.UseVisualStyleBackColor = True
        '
        'btnSearchDate
        '
        Me.btnSearchDate.Location = New System.Drawing.Point(346, 2)
        Me.btnSearchDate.Name = "btnSearchDate"
        Me.btnSearchDate.Size = New System.Drawing.Size(85, 24)
        Me.btnSearchDate.TabIndex = 4
        Me.btnSearchDate.Text = "Search"
        Me.btnSearchDate.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "MMM dd, yyyy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(47, 3)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(130, 21)
        Me.dtpFrom.TabIndex = 2
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "MMM dd, yyyy"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(210, 3)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(130, 21)
        Me.dtpTo.TabIndex = 3
        '
        'lblStartTo
        '
        Me.lblStartTo.AutoSize = True
        Me.lblStartTo.Location = New System.Drawing.Point(183, 7)
        Me.lblStartTo.Name = "lblStartTo"
        Me.lblStartTo.Size = New System.Drawing.Size(21, 14)
        Me.lblStartTo.TabIndex = 19
        Me.lblStartTo.Text = "To"
        '
        'lblCriteria
        '
        Me.lblCriteria.BackColor = System.Drawing.SystemColors.Control
        Me.lblCriteria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCriteria.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCriteria.ForeColor = System.Drawing.Color.Black
        Me.lblCriteria.Location = New System.Drawing.Point(6, 12)
        Me.lblCriteria.Name = "lblCriteria"
        Me.lblCriteria.Size = New System.Drawing.Size(62, 22)
        Me.lblCriteria.TabIndex = 7
        Me.lblCriteria.Text = " Criteria"
        Me.lblCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSearchCriteria
        '
        Me.cmbSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchCriteria.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchCriteria.FormattingEnabled = True
        Me.cmbSearchCriteria.Location = New System.Drawing.Point(67, 12)
        Me.cmbSearchCriteria.Name = "cmbSearchCriteria"
        Me.cmbSearchCriteria.Size = New System.Drawing.Size(194, 22)
        Me.cmbSearchCriteria.TabIndex = 8
        '
        'dgvTransactionHeader
        '
        Me.dgvTransactionHeader.AllowUserToAddRows = False
        Me.dgvTransactionHeader.AllowUserToDeleteRows = False
        Me.dgvTransactionHeader.AllowUserToResizeColumns = False
        Me.dgvTransactionHeader.AllowUserToResizeRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.5!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvTransactionHeader.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTransactionHeader.ColumnHeadersHeight = 25
        Me.dgvTransactionHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTransactionHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TrxIdColumn, Me.ShiftIdColumn, Me.DatetimeStartedColumn, Me.ActivityColumn, Me.DatetimeEndedColumn, Me.TotalAccumulatedTimeColumn, Me.SeniorEngineerIsApprovedColumn})
        Me.dgvTransactionHeader.Location = New System.Drawing.Point(339, 37)
        Me.dgvTransactionHeader.MultiSelect = False
        Me.dgvTransactionHeader.Name = "dgvTransactionHeader"
        Me.dgvTransactionHeader.ReadOnly = True
        Me.dgvTransactionHeader.RowHeadersVisible = False
        Me.dgvTransactionHeader.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvTransactionHeader.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTransactionHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvTransactionHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransactionHeader.Size = New System.Drawing.Size(975, 520)
        Me.dgvTransactionHeader.TabIndex = 158
        '
        'TrxIdColumn
        '
        Me.TrxIdColumn.DataPropertyName = "TrxId"
        Me.TrxIdColumn.HeaderText = "TrxId"
        Me.TrxIdColumn.Name = "TrxIdColumn"
        Me.TrxIdColumn.ReadOnly = True
        Me.TrxIdColumn.Visible = False
        '
        'ShiftIdColumn
        '
        Me.ShiftIdColumn.DataPropertyName = "ShiftId"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ShiftIdColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.ShiftIdColumn.HeaderText = "Shift"
        Me.ShiftIdColumn.Name = "ShiftIdColumn"
        Me.ShiftIdColumn.ReadOnly = True
        Me.ShiftIdColumn.Width = 50
        '
        'DatetimeStartedColumn
        '
        Me.DatetimeStartedColumn.DataPropertyName = "DatetimeStarted"
        DataGridViewCellStyle7.Format = "g"
        Me.DatetimeStartedColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.DatetimeStartedColumn.HeaderText = "Start"
        Me.DatetimeStartedColumn.Name = "DatetimeStartedColumn"
        Me.DatetimeStartedColumn.ReadOnly = True
        Me.DatetimeStartedColumn.Width = 120
        '
        'ActivityColumn
        '
        Me.ActivityColumn.DataPropertyName = "Activity"
        Me.ActivityColumn.HeaderText = "Downtime Status / Activity"
        Me.ActivityColumn.Name = "ActivityColumn"
        Me.ActivityColumn.ReadOnly = True
        Me.ActivityColumn.Width = 285
        '
        'DatetimeEndedColumn
        '
        Me.DatetimeEndedColumn.DataPropertyName = "DatetimeEnded"
        DataGridViewCellStyle8.Format = "g"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DatetimeEndedColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.DatetimeEndedColumn.HeaderText = "End"
        Me.DatetimeEndedColumn.Name = "DatetimeEndedColumn"
        Me.DatetimeEndedColumn.ReadOnly = True
        Me.DatetimeEndedColumn.Width = 120
        '
        'TotalAccumulatedTimeColumn
        '
        Me.TotalAccumulatedTimeColumn.DataPropertyName = "TotalAccumulatedDowntime"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TotalAccumulatedTimeColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.TotalAccumulatedTimeColumn.HeaderText = "Time"
        Me.TotalAccumulatedTimeColumn.Name = "TotalAccumulatedTimeColumn"
        Me.TotalAccumulatedTimeColumn.ReadOnly = True
        Me.TotalAccumulatedTimeColumn.Width = 60
        '
        'SeniorEngineerIsApprovedColumn
        '
        Me.SeniorEngineerIsApprovedColumn.DataPropertyName = "SeniorEngineerIsApproved"
        Me.SeniorEngineerIsApprovedColumn.HeaderText = "*"
        Me.SeniorEngineerIsApprovedColumn.Name = "SeniorEngineerIsApprovedColumn"
        Me.SeniorEngineerIsApprovedColumn.ReadOnly = True
        Me.SeniorEngineerIsApprovedColumn.Width = 25
        '
        'grpStatus
        '
        Me.grpStatus.BackColor = System.Drawing.Color.White
        Me.grpStatus.Controls.Add(Me.rdOngoing)
        Me.grpStatus.Controls.Add(Me.rdDone)
        Me.grpStatus.Controls.Add(Me.rdAll)
        Me.grpStatus.Location = New System.Drawing.Point(339, 559)
        Me.grpStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Padding = New System.Windows.Forms.Padding(0)
        Me.grpStatus.Size = New System.Drawing.Size(197, 36)
        Me.grpStatus.TabIndex = 159
        Me.grpStatus.TabStop = False
        '
        'rdOngoing
        '
        Me.rdOngoing.AutoSize = True
        Me.rdOngoing.Location = New System.Drawing.Point(114, 12)
        Me.rdOngoing.Name = "rdOngoing"
        Me.rdOngoing.Size = New System.Drawing.Size(78, 18)
        Me.rdOngoing.TabIndex = 2
        Me.rdOngoing.TabStop = True
        Me.rdOngoing.Text = "Ongoing"
        Me.rdOngoing.UseVisualStyleBackColor = True
        '
        'rdDone
        '
        Me.rdDone.AutoSize = True
        Me.rdDone.Location = New System.Drawing.Point(50, 12)
        Me.rdDone.Name = "rdDone"
        Me.rdDone.Size = New System.Drawing.Size(58, 18)
        Me.rdDone.TabIndex = 1
        Me.rdDone.TabStop = True
        Me.rdDone.Text = "Done"
        Me.rdDone.UseVisualStyleBackColor = True
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.Location = New System.Drawing.Point(5, 12)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(39, 18)
        Me.rdAll.TabIndex = 0
        Me.rdAll.TabStop = True
        Me.rdAll.Text = "All"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRefresh.DefaultScheme = False
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRefresh.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnRefresh.Hint = ""
        Me.btnRefresh.Location = New System.Drawing.Point(538, 565)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRefresh.Size = New System.Drawing.Size(100, 30)
        Me.btnRefresh.TabIndex = 160
        Me.btnRefresh.Text = "  Refresh"
        '
        'frmMntTrxConsole
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1314, 601)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.grpStatus)
        Me.Controls.Add(Me.dgvTransactionHeader)
        Me.Controls.Add(Me.grpCriteria)
        Me.Controls.Add(Me.dgvMachine)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnCreate)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMntTrxConsole"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaction Console"
        CType(Me.dgvMachine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCriteria.ResumeLayout(False)
        Me.grpCriteria.PerformLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator.ResumeLayout(False)
        Me.bindingNavigator.PerformLayout()
        Me.pnlDateSearch.ResumeLayout(False)
        Me.pnlDateSearch.PerformLayout()
        CType(Me.dgvTransactionHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnEdit As PinkieControls.ButtonXP
    Friend WithEvents btnCreate As PinkieControls.ButtonXP
    Friend WithEvents dgvMachine As System.Windows.Forms.DataGridView
    Friend WithEvents grpCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents pnlDateSearch As System.Windows.Forms.Panel
    Friend WithEvents lblStartFrom As System.Windows.Forms.Label
    Friend WithEvents btnResetDate As System.Windows.Forms.Button
    Friend WithEvents btnSearchDate As System.Windows.Forms.Button
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartTo As System.Windows.Forms.Label
    Friend WithEvents lblCriteria As System.Windows.Forms.Label
    Friend WithEvents cmbSearchCriteria As System.Windows.Forms.ComboBox
    Friend WithEvents dgvTransactionHeader As System.Windows.Forms.DataGridView
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents rdOngoing As System.Windows.Forms.RadioButton
    Friend WithEvents rdDone As System.Windows.Forms.RadioButton
    Friend WithEvents rdAll As System.Windows.Forms.RadioButton
    Friend WithEvents btnRefresh As PinkieControls.ButtonXP
    Friend WithEvents MachineIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineStatusIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastTransactionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ElapsedTimeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents TrxIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatetimeStartedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatetimeEndedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAccumulatedTimeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeniorEngineerIsApprovedColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
