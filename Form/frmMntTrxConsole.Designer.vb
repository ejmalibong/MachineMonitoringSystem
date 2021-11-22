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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMntTrxConsole))
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnEdit = New PinkieControls.ButtonXP()
        Me.btnCreate = New PinkieControls.ButtonXP()
        Me.dgvMachine = New System.Windows.Forms.DataGridView()
        Me.ColMachineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMachineName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAreaName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMachineStatusId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMachineLastTransaction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMachineElapsedTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.ColTrxId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTechnician = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColShiftId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMachineName2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDatetimeStarted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActivity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDatetimeEnded = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTotalAccumulatedTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRoutingStatusName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRefresh = New PinkieControls.ButtonXP()
        Me.lblSearchCriteria = New System.Windows.Forms.Label()
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
        Me.tabCtrl = New System.Windows.Forms.TabControl()
        Me.pgMachine = New System.Windows.Forms.TabPage()
        Me.pgJig = New System.Windows.Forms.TabPage()
        Me.dgvJig = New System.Windows.Forms.DataGridView()
        Me.ColJig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJigCompleteName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJigAreaName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJigStatusId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJigModelId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJigExtensionId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJigLastTransaction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJigElapsedTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.cmbSearchCriteria = New System.Windows.Forms.ComboBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.btnSearch = New PinkieControls.ButtonXP()
        Me.btnReset = New PinkieControls.ButtonXP()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblSearchStartDate = New System.Windows.Forms.Label()
        Me.lblSearchEndDate = New System.Windows.Forms.Label()
        Me.pnlSearchByDate = New System.Windows.Forms.Panel()
        Me.pnlSearchByCmb = New System.Windows.Forms.Panel()
        Me.cmbCommonCmb = New SergeUtils.EasyCompletionComboBox()
        Me.tmrElapsedTime = New System.Windows.Forms.Timer(Me.components)
        Me.pnlSearchByText = New System.Windows.Forms.Panel()
        Me.txtCommonTxt = New System.Windows.Forms.TextBox()
        CType(Me.dgvMachine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator.SuspendLayout()
        Me.tabCtrl.SuspendLayout()
        Me.pgMachine.SuspendLayout()
        Me.pgJig.SuspendLayout()
        CType(Me.dgvJig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearchByDate.SuspendLayout()
        Me.pnlSearchByCmb.SuspendLayout()
        Me.pnlSearchByText.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Hint = "Close transaction console"
        Me.btnClose.Location = New System.Drawing.Point(1304, 564)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 155
        Me.btnClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = False
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnDelete.Hint = "Delete record"
        Me.btnDelete.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Erase_16_x_16
        Me.btnDelete.Location = New System.Drawing.Point(1210, 564)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 154
        Me.btnDelete.Text = "Delete"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEdit.DefaultScheme = False
        Me.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnEdit.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnEdit.Hint = "Modify record"
        Me.btnEdit.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Modify_16_x_16
        Me.btnEdit.Location = New System.Drawing.Point(1116, 564)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnEdit.Size = New System.Drawing.Size(90, 32)
        Me.btnEdit.TabIndex = 153
        Me.btnEdit.Text = " Edit"
        '
        'btnCreate
        '
        Me.btnCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreate.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCreate.DefaultScheme = False
        Me.btnCreate.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnCreate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnCreate.Hint = "Add new record"
        Me.btnCreate.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Create_16_x_16
        Me.btnCreate.Location = New System.Drawing.Point(967, 564)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCreate.Size = New System.Drawing.Size(145, 32)
        Me.btnCreate.TabIndex = 152
        Me.btnCreate.Text = " Create Activity"
        '
        'dgvMachine
        '
        Me.dgvMachine.AllowUserToAddRows = False
        Me.dgvMachine.AllowUserToDeleteRows = False
        Me.dgvMachine.AllowUserToResizeColumns = False
        Me.dgvMachine.AllowUserToResizeRows = False
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvMachine.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvMachine.ColumnHeadersHeight = 25
        Me.dgvMachine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvMachine.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColMachineId, Me.ColMachineName, Me.ColAreaName, Me.ColMachineStatusId, Me.ColMachineLastTransaction, Me.ColMachineElapsedTime})
        Me.dgvMachine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMachine.Location = New System.Drawing.Point(3, 3)
        Me.dgvMachine.MultiSelect = False
        Me.dgvMachine.Name = "dgvMachine"
        Me.dgvMachine.ReadOnly = True
        Me.dgvMachine.RowHeadersVisible = False
        Me.dgvMachine.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvMachine.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvMachine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvMachine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMachine.Size = New System.Drawing.Size(336, 567)
        Me.dgvMachine.TabIndex = 156
        '
        'ColMachineId
        '
        Me.ColMachineId.DataPropertyName = "MachineId"
        Me.ColMachineId.HeaderText = "MachineId"
        Me.ColMachineId.Name = "ColMachineId"
        Me.ColMachineId.ReadOnly = True
        Me.ColMachineId.Visible = False
        '
        'ColMachineName
        '
        Me.ColMachineName.DataPropertyName = "MachineName"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColMachineName.DefaultCellStyle = DataGridViewCellStyle26
        Me.ColMachineName.HeaderText = "Machine"
        Me.ColMachineName.Name = "ColMachineName"
        Me.ColMachineName.ReadOnly = True
        Me.ColMachineName.Width = 140
        '
        'ColAreaName
        '
        Me.ColAreaName.DataPropertyName = "AreaName"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColAreaName.DefaultCellStyle = DataGridViewCellStyle27
        Me.ColAreaName.HeaderText = "Area"
        Me.ColAreaName.Name = "ColAreaName"
        Me.ColAreaName.ReadOnly = True
        '
        'ColMachineStatusId
        '
        Me.ColMachineStatusId.DataPropertyName = "MachineStatusId"
        Me.ColMachineStatusId.HeaderText = "MachineStatusId"
        Me.ColMachineStatusId.Name = "ColMachineStatusId"
        Me.ColMachineStatusId.ReadOnly = True
        Me.ColMachineStatusId.Visible = False
        '
        'ColMachineLastTransaction
        '
        Me.ColMachineLastTransaction.DataPropertyName = "TrxFrom"
        DataGridViewCellStyle28.Format = "G"
        DataGridViewCellStyle28.NullValue = Nothing
        Me.ColMachineLastTransaction.DefaultCellStyle = DataGridViewCellStyle28
        Me.ColMachineLastTransaction.HeaderText = "Last Transaction"
        Me.ColMachineLastTransaction.Name = "ColMachineLastTransaction"
        Me.ColMachineLastTransaction.ReadOnly = True
        Me.ColMachineLastTransaction.Visible = False
        '
        'ColMachineElapsedTime
        '
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle29.NullValue = Nothing
        Me.ColMachineElapsedTime.DefaultCellStyle = DataGridViewCellStyle29
        Me.ColMachineElapsedTime.HeaderText = "Time"
        Me.ColMachineElapsedTime.Name = "ColMachineElapsedTime"
        Me.ColMachineElapsedTime.ReadOnly = True
        Me.ColMachineElapsedTime.Width = 75
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeRows = False
        Me.dgvList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle30
        Me.dgvList.ColumnHeadersHeight = 25
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColTrxId, Me.ColTechnician, Me.ColShiftId, Me.ColMachineName2, Me.ColDatetimeStarted, Me.ColActivity, Me.ColDatetimeEnded, Me.ColTotalAccumulatedTime, Me.ColRoutingStatusName})
        Me.dgvList.Location = New System.Drawing.Point(346, 33)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvList.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(1048, 527)
        Me.dgvList.TabIndex = 158
        '
        'ColTrxId
        '
        Me.ColTrxId.DataPropertyName = "TrxId"
        Me.ColTrxId.HeaderText = "#"
        Me.ColTrxId.Name = "ColTrxId"
        Me.ColTrxId.ReadOnly = True
        Me.ColTrxId.Width = 50
        '
        'ColTechnician
        '
        Me.ColTechnician.DataPropertyName = "Nickname"
        Me.ColTechnician.HeaderText = "Technician"
        Me.ColTechnician.Name = "ColTechnician"
        Me.ColTechnician.ReadOnly = True
        '
        'ColShiftId
        '
        Me.ColShiftId.DataPropertyName = "ShiftId"
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColShiftId.DefaultCellStyle = DataGridViewCellStyle31
        Me.ColShiftId.HeaderText = "Shift"
        Me.ColShiftId.Name = "ColShiftId"
        Me.ColShiftId.ReadOnly = True
        Me.ColShiftId.Width = 50
        '
        'ColMachineName2
        '
        Me.ColMachineName2.DataPropertyName = "SubjectName"
        Me.ColMachineName2.HeaderText = "Machine / Jig"
        Me.ColMachineName2.Name = "ColMachineName2"
        Me.ColMachineName2.ReadOnly = True
        Me.ColMachineName2.Width = 200
        '
        'ColDatetimeStarted
        '
        Me.ColDatetimeStarted.DataPropertyName = "DatetimeStarted"
        DataGridViewCellStyle32.Format = "g"
        Me.ColDatetimeStarted.DefaultCellStyle = DataGridViewCellStyle32
        Me.ColDatetimeStarted.HeaderText = "Start"
        Me.ColDatetimeStarted.Name = "ColDatetimeStarted"
        Me.ColDatetimeStarted.ReadOnly = True
        Me.ColDatetimeStarted.Width = 120
        '
        'ColActivity
        '
        Me.ColActivity.DataPropertyName = "ActionTaken"
        Me.ColActivity.HeaderText = "Activity"
        Me.ColActivity.Name = "ColActivity"
        Me.ColActivity.ReadOnly = True
        '
        'ColDatetimeEnded
        '
        Me.ColDatetimeEnded.DataPropertyName = "DatetimeEnded"
        DataGridViewCellStyle33.Format = "g"
        DataGridViewCellStyle33.NullValue = Nothing
        Me.ColDatetimeEnded.DefaultCellStyle = DataGridViewCellStyle33
        Me.ColDatetimeEnded.HeaderText = "End"
        Me.ColDatetimeEnded.Name = "ColDatetimeEnded"
        Me.ColDatetimeEnded.ReadOnly = True
        Me.ColDatetimeEnded.Width = 120
        '
        'ColTotalAccumulatedTime
        '
        Me.ColTotalAccumulatedTime.DataPropertyName = "TotalAccumulatedDowntime"
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColTotalAccumulatedTime.DefaultCellStyle = DataGridViewCellStyle34
        Me.ColTotalAccumulatedTime.HeaderText = "Minutes"
        Me.ColTotalAccumulatedTime.Name = "ColTotalAccumulatedTime"
        Me.ColTotalAccumulatedTime.ReadOnly = True
        Me.ColTotalAccumulatedTime.Width = 65
        '
        'ColRoutingStatusName
        '
        Me.ColRoutingStatusName.DataPropertyName = "RoutingStatusName"
        Me.ColRoutingStatusName.HeaderText = "Status"
        Me.ColRoutingStatusName.Name = "ColRoutingStatusName"
        Me.ColRoutingStatusName.ReadOnly = True
        Me.ColRoutingStatusName.Width = 200
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRefresh.DefaultScheme = False
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRefresh.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnRefresh.Hint = "Refresh lists"
        Me.btnRefresh.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Refresh_16_x_16
        Me.btnRefresh.Location = New System.Drawing.Point(650, 564)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRefresh.Size = New System.Drawing.Size(90, 32)
        Me.btnRefresh.TabIndex = 160
        Me.btnRefresh.Text = "Refresh"
        '
        'lblSearchCriteria
        '
        Me.lblSearchCriteria.BackColor = System.Drawing.SystemColors.Control
        Me.lblSearchCriteria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSearchCriteria.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblSearchCriteria.ForeColor = System.Drawing.Color.Black
        Me.lblSearchCriteria.Location = New System.Drawing.Point(346, 6)
        Me.lblSearchCriteria.Name = "lblSearchCriteria"
        Me.lblSearchCriteria.Size = New System.Drawing.Size(65, 22)
        Me.lblSearchCriteria.TabIndex = 534
        Me.lblSearchCriteria.Text = "Criteria"
        Me.lblSearchCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bindingNavigator
        '
        Me.bindingNavigator.AddNewItem = Nothing
        Me.bindingNavigator.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bindingNavigator.BackColor = System.Drawing.Color.Transparent
        Me.bindingNavigator.CountItem = Me.txtTotalPageNumber
        Me.bindingNavigator.CountItemFormat = "of "
        Me.bindingNavigator.DeleteItem = Nothing
        Me.bindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.bindingNavigator.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.bindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.bindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.txtPageNumber, Me.txtTotalPageNumber, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.ToolStripSeparator, Me.btnGo})
        Me.bindingNavigator.Location = New System.Drawing.Point(1192, 3)
        Me.bindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bindingNavigator.Name = "bindingNavigator"
        Me.bindingNavigator.PositionItem = Me.txtPageNumber
        Me.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.bindingNavigator.Size = New System.Drawing.Size(202, 25)
        Me.bindingNavigator.TabIndex = 537
        '
        'txtTotalPageNumber
        '
        Me.txtTotalPageNumber.Name = "txtTotalPageNumber"
        Me.txtTotalPageNumber.Size = New System.Drawing.Size(22, 22)
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
        Me.txtPageNumber.Name = "txtPageNumber"
        Me.txtPageNumber.Size = New System.Drawing.Size(30, 23)
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
        'tabCtrl
        '
        Me.tabCtrl.Controls.Add(Me.pgMachine)
        Me.tabCtrl.Controls.Add(Me.pgJig)
        Me.tabCtrl.Dock = System.Windows.Forms.DockStyle.Left
        Me.tabCtrl.Location = New System.Drawing.Point(0, 0)
        Me.tabCtrl.Margin = New System.Windows.Forms.Padding(0)
        Me.tabCtrl.Name = "tabCtrl"
        Me.tabCtrl.Padding = New System.Drawing.Point(0, 0)
        Me.tabCtrl.SelectedIndex = 0
        Me.tabCtrl.ShowToolTips = True
        Me.tabCtrl.Size = New System.Drawing.Size(350, 600)
        Me.tabCtrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabCtrl.TabIndex = 540
        '
        'pgMachine
        '
        Me.pgMachine.Controls.Add(Me.dgvMachine)
        Me.pgMachine.Location = New System.Drawing.Point(4, 23)
        Me.pgMachine.Name = "pgMachine"
        Me.pgMachine.Padding = New System.Windows.Forms.Padding(3)
        Me.pgMachine.Size = New System.Drawing.Size(342, 573)
        Me.pgMachine.TabIndex = 0
        Me.pgMachine.Text = "Machines"
        Me.pgMachine.UseVisualStyleBackColor = True
        '
        'pgJig
        '
        Me.pgJig.Controls.Add(Me.dgvJig)
        Me.pgJig.Location = New System.Drawing.Point(4, 23)
        Me.pgJig.Name = "pgJig"
        Me.pgJig.Padding = New System.Windows.Forms.Padding(3)
        Me.pgJig.Size = New System.Drawing.Size(342, 573)
        Me.pgJig.TabIndex = 1
        Me.pgJig.Text = "Jig"
        Me.pgJig.UseVisualStyleBackColor = True
        '
        'dgvJig
        '
        Me.dgvJig.AllowUserToAddRows = False
        Me.dgvJig.AllowUserToDeleteRows = False
        Me.dgvJig.AllowUserToResizeColumns = False
        Me.dgvJig.AllowUserToResizeRows = False
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvJig.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle35
        Me.dgvJig.ColumnHeadersHeight = 25
        Me.dgvJig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvJig.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColJig, Me.ColJigCompleteName, Me.ColJigAreaName, Me.ColJigStatusId, Me.ColJigModelId, Me.ColJigExtensionId, Me.ColJigLastTransaction, Me.ColJigElapsedTime})
        Me.dgvJig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvJig.Location = New System.Drawing.Point(3, 3)
        Me.dgvJig.MultiSelect = False
        Me.dgvJig.Name = "dgvJig"
        Me.dgvJig.ReadOnly = True
        Me.dgvJig.RowHeadersVisible = False
        Me.dgvJig.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.dgvJig.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvJig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJig.Size = New System.Drawing.Size(336, 567)
        Me.dgvJig.TabIndex = 0
        '
        'ColJig
        '
        Me.ColJig.DataPropertyName = "JigId"
        Me.ColJig.HeaderText = "JigId"
        Me.ColJig.Name = "ColJig"
        Me.ColJig.ReadOnly = True
        Me.ColJig.Visible = False
        '
        'ColJigCompleteName
        '
        Me.ColJigCompleteName.DataPropertyName = "JigCompleteName"
        Me.ColJigCompleteName.HeaderText = "Jig Name"
        Me.ColJigCompleteName.Name = "ColJigCompleteName"
        Me.ColJigCompleteName.ReadOnly = True
        Me.ColJigCompleteName.Width = 205
        '
        'ColJigAreaName
        '
        Me.ColJigAreaName.DataPropertyName = "AreaName"
        Me.ColJigAreaName.HeaderText = "Area"
        Me.ColJigAreaName.Name = "ColJigAreaName"
        Me.ColJigAreaName.ReadOnly = True
        Me.ColJigAreaName.Width = 90
        '
        'ColJigStatusId
        '
        Me.ColJigStatusId.DataPropertyName = "JigStatusId"
        Me.ColJigStatusId.HeaderText = "JigStatusId"
        Me.ColJigStatusId.Name = "ColJigStatusId"
        Me.ColJigStatusId.ReadOnly = True
        Me.ColJigStatusId.Visible = False
        '
        'ColJigModelId
        '
        Me.ColJigModelId.DataPropertyName = "ModelId"
        Me.ColJigModelId.HeaderText = "JigModelId"
        Me.ColJigModelId.Name = "ColJigModelId"
        Me.ColJigModelId.ReadOnly = True
        Me.ColJigModelId.Visible = False
        '
        'ColJigExtensionId
        '
        Me.ColJigExtensionId.DataPropertyName = "ExtensionId"
        Me.ColJigExtensionId.HeaderText = "JigExtensionId"
        Me.ColJigExtensionId.Name = "ColJigExtensionId"
        Me.ColJigExtensionId.ReadOnly = True
        Me.ColJigExtensionId.Visible = False
        '
        'ColJigLastTransaction
        '
        Me.ColJigLastTransaction.DataPropertyName = "TrxFrom"
        Me.ColJigLastTransaction.HeaderText = "LastTransaction"
        Me.ColJigLastTransaction.Name = "ColJigLastTransaction"
        Me.ColJigLastTransaction.ReadOnly = True
        Me.ColJigLastTransaction.Visible = False
        '
        'ColJigElapsedTime
        '
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColJigElapsedTime.DefaultCellStyle = DataGridViewCellStyle36
        Me.ColJigElapsedTime.HeaderText = "Time"
        Me.ColJigElapsedTime.Name = "ColJigElapsedTime"
        Me.ColJigElapsedTime.ReadOnly = True
        Me.ColJigElapsedTime.Width = 70
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(346, 568)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(60, 24)
        Me.lblStatus.TabIndex = 541
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbStatus
        '
        Me.cmbStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.IntegralHeight = False
        Me.cmbStatus.Location = New System.Drawing.Point(405, 568)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(240, 24)
        Me.cmbStatus.TabIndex = 542
        '
        'cmbSearchCriteria
        '
        Me.cmbSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchCriteria.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchCriteria.FormattingEnabled = True
        Me.cmbSearchCriteria.Location = New System.Drawing.Point(410, 6)
        Me.cmbSearchCriteria.Name = "cmbSearchCriteria"
        Me.cmbSearchCriteria.Size = New System.Drawing.Size(165, 22)
        Me.cmbSearchCriteria.TabIndex = 535
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "  MMM dd, yyyy"
        Me.dtpEndDate.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(197, 5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(125, 21)
        Me.dtpEndDate.TabIndex = 21
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearch.DefaultScheme = False
        Me.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnSearch.Hint = "Search"
        Me.btnSearch.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Find_16_x_16
        Me.btnSearch.Location = New System.Drawing.Point(906, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSearch.Size = New System.Drawing.Size(80, 25)
        Me.btnSearch.TabIndex = 538
        Me.btnSearch.TabStop = False
        Me.btnSearch.Text = "Search"
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReset.DefaultScheme = False
        Me.btnReset.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnReset.Hint = "Reset search filter"
        Me.btnReset.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Undo_16_x_16
        Me.btnReset.Location = New System.Drawing.Point(988, 4)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnReset.Size = New System.Drawing.Size(80, 25)
        Me.btnReset.TabIndex = 539
        Me.btnReset.TabStop = False
        Me.btnReset.Text = "Reset"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "  MMM dd, yyyy"
        Me.dtpStartDate.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(44, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(125, 21)
        Me.dtpStartDate.TabIndex = 20
        '
        'lblSearchStartDate
        '
        Me.lblSearchStartDate.AutoSize = True
        Me.lblSearchStartDate.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblSearchStartDate.Location = New System.Drawing.Point(4, 10)
        Me.lblSearchStartDate.Name = "lblSearchStartDate"
        Me.lblSearchStartDate.Size = New System.Drawing.Size(36, 13)
        Me.lblSearchStartDate.TabIndex = 24
        Me.lblSearchStartDate.Text = "From"
        '
        'lblSearchEndDate
        '
        Me.lblSearchEndDate.AutoSize = True
        Me.lblSearchEndDate.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblSearchEndDate.Location = New System.Drawing.Point(173, 10)
        Me.lblSearchEndDate.Name = "lblSearchEndDate"
        Me.lblSearchEndDate.Size = New System.Drawing.Size(20, 13)
        Me.lblSearchEndDate.TabIndex = 25
        Me.lblSearchEndDate.Text = "To"
        '
        'pnlSearchByDate
        '
        Me.pnlSearchByDate.BackColor = System.Drawing.Color.White
        Me.pnlSearchByDate.Controls.Add(Me.dtpEndDate)
        Me.pnlSearchByDate.Controls.Add(Me.lblSearchEndDate)
        Me.pnlSearchByDate.Controls.Add(Me.lblSearchStartDate)
        Me.pnlSearchByDate.Controls.Add(Me.dtpStartDate)
        Me.pnlSearchByDate.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.pnlSearchByDate.Location = New System.Drawing.Point(576, 1)
        Me.pnlSearchByDate.Name = "pnlSearchByDate"
        Me.pnlSearchByDate.Size = New System.Drawing.Size(328, 31)
        Me.pnlSearchByDate.TabIndex = 536
        '
        'pnlSearchByCmb
        '
        Me.pnlSearchByCmb.BackColor = System.Drawing.Color.White
        Me.pnlSearchByCmb.Controls.Add(Me.cmbCommonCmb)
        Me.pnlSearchByCmb.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.pnlSearchByCmb.Location = New System.Drawing.Point(576, 1)
        Me.pnlSearchByCmb.Name = "pnlSearchByCmb"
        Me.pnlSearchByCmb.Size = New System.Drawing.Size(328, 31)
        Me.pnlSearchByCmb.TabIndex = 537
        '
        'cmbCommonCmb
        '
        Me.cmbCommonCmb.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.cmbCommonCmb.FormattingEnabled = True
        Me.cmbCommonCmb.Location = New System.Drawing.Point(6, 5)
        Me.cmbCommonCmb.Name = "cmbCommonCmb"
        Me.cmbCommonCmb.Size = New System.Drawing.Size(316, 21)
        Me.cmbCommonCmb.TabIndex = 25
        '
        'tmrElapsedTime
        '
        Me.tmrElapsedTime.Interval = 1000
        '
        'pnlSearchByText
        '
        Me.pnlSearchByText.BackColor = System.Drawing.Color.White
        Me.pnlSearchByText.Controls.Add(Me.txtCommonTxt)
        Me.pnlSearchByText.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.pnlSearchByText.Location = New System.Drawing.Point(576, 1)
        Me.pnlSearchByText.Name = "pnlSearchByText"
        Me.pnlSearchByText.Size = New System.Drawing.Size(328, 31)
        Me.pnlSearchByText.TabIndex = 538
        '
        'txtCommonTxt
        '
        Me.txtCommonTxt.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.txtCommonTxt.Location = New System.Drawing.Point(6, 5)
        Me.txtCommonTxt.Name = "txtCommonTxt"
        Me.txtCommonTxt.Size = New System.Drawing.Size(316, 21)
        Me.txtCommonTxt.TabIndex = 543
        '
        'frmMntTrxConsole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1400, 600)
        Me.Controls.Add(Me.pnlSearchByCmb)
        Me.Controls.Add(Me.pnlSearchByDate)
        Me.Controls.Add(Me.pnlSearchByText)
        Me.Controls.Add(Me.lblSearchCriteria)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.bindingNavigator)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.tabCtrl)
        Me.Controls.Add(Me.cmbSearchCriteria)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Name = "frmMntTrxConsole"
        Me.Text = "Transaction Console"
        CType(Me.dgvMachine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator.ResumeLayout(False)
        Me.bindingNavigator.PerformLayout()
        Me.tabCtrl.ResumeLayout(False)
        Me.pgMachine.ResumeLayout(False)
        Me.pgJig.ResumeLayout(False)
        CType(Me.dgvJig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearchByDate.ResumeLayout(False)
        Me.pnlSearchByDate.PerformLayout()
        Me.pnlSearchByCmb.ResumeLayout(False)
        Me.pnlSearchByText.ResumeLayout(False)
        Me.pnlSearchByText.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnEdit As PinkieControls.ButtonXP
    Friend WithEvents btnCreate As PinkieControls.ButtonXP
    Friend WithEvents dgvMachine As System.Windows.Forms.DataGridView
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents btnRefresh As PinkieControls.ButtonXP
    Friend WithEvents lblSearchCriteria As System.Windows.Forms.Label
    Friend WithEvents bindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents txtTotalPageNumber As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtPageNumber As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabCtrl As System.Windows.Forms.TabControl
    Friend WithEvents pgMachine As System.Windows.Forms.TabPage
    Friend WithEvents pgJig As System.Windows.Forms.TabPage
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSearchCriteria As System.Windows.Forms.ComboBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSearch As PinkieControls.ButtonXP
    Friend WithEvents btnReset As PinkieControls.ButtonXP
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSearchStartDate As System.Windows.Forms.Label
    Friend WithEvents lblSearchEndDate As System.Windows.Forms.Label
    Friend WithEvents pnlSearchByDate As System.Windows.Forms.Panel
    Friend WithEvents tmrElapsedTime As System.Windows.Forms.Timer
    Friend WithEvents dgvJig As System.Windows.Forms.DataGridView
    Friend WithEvents ColMachineId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMachineName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAreaName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMachineStatusId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMachineLastTransaction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMachineElapsedTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJigCompleteName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJigAreaName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJigStatusId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJigModelId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJigExtensionId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJigLastTransaction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJigElapsedTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTrxId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTechnician As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColShiftId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMachineName2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDatetimeStarted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColActivity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDatetimeEnded As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTotalAccumulatedTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRoutingStatusName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlSearchByCmb As System.Windows.Forms.Panel
    Friend WithEvents cmbCommonCmb As SergeUtils.EasyCompletionComboBox
    Friend WithEvents pnlSearchByText As System.Windows.Forms.Panel
    Friend WithEvents txtCommonTxt As System.Windows.Forms.TextBox
End Class
