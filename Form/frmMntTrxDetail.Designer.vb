<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMntTrxDetail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtRuntimeAccumulated = New System.Windows.Forms.Label()
        Me.lblRuntimeAccumulated = New System.Windows.Forms.Label()
        Me.txtDowntimeAccumulated = New System.Windows.Forms.Label()
        Me.lblDowntimeAccumulated = New System.Windows.Forms.Label()
        Me.txtTransactionDate = New System.Windows.Forms.Label()
        Me.lblTransactionDate = New System.Windows.Forms.Label()
        Me.txtTransactionId = New System.Windows.Forms.Label()
        Me.lblTransactionId = New System.Windows.Forms.Label()
        Me.txtImageName = New System.Windows.Forms.Label()
        Me.cmbTrxStatus = New System.Windows.Forms.ComboBox()
        Me.lblTrxStatus = New System.Windows.Forms.Label()
        Me.lblRoutingStatus = New System.Windows.Forms.Label()
        Me.cmbMachineName = New System.Windows.Forms.ComboBox()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.cmbMachinePart = New System.Windows.Forms.ComboBox()
        Me.cmbMachineStatus = New System.Windows.Forms.ComboBox()
        Me.lblMachineStatus = New System.Windows.Forms.Label()
        Me.lblMachinePart = New System.Windows.Forms.Label()
        Me.txtProblem = New System.Windows.Forms.TextBox()
        Me.lblProblem = New System.Windows.Forms.Label()
        Me.txtActionTaken = New System.Windows.Forms.TextBox()
        Me.lblActionTaken = New System.Windows.Forms.Label()
        Me.lblPartsReplaced = New System.Windows.Forms.Label()
        Me.txtPartsReplaced = New System.Windows.Forms.TextBox()
        Me.txtPartNo = New System.Windows.Forms.TextBox()
        Me.lblPartNo = New System.Windows.Forms.Label()
        Me.lblJoNumber = New System.Windows.Forms.Label()
        Me.txtJoNumber = New System.Windows.Forms.TextBox()
        Me.lblJoRequestor = New System.Windows.Forms.Label()
        Me.txtJoRequestor = New System.Windows.Forms.TextBox()
        Me.btnRemoveRow = New PinkieControls.ButtonXP()
        Me.btnAddRow = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.lblImageAttachment = New System.Windows.Forms.Label()
        Me.picImgAttachment = New System.Windows.Forms.PictureBox()
        Me.btnBrowse = New PinkieControls.ButtonXP()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.pnlImage = New System.Windows.Forms.Panel()
        Me.lblPic = New System.Windows.Forms.Label()
        Me.dgvPic = New System.Windows.Forms.DataGridView()
        Me.IsSelectedColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.UserIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnReturn = New PinkieControls.ButtonXP()
        Me.btnApprove = New PinkieControls.ButtonXP()
        Me.cmbRoutingStatus = New System.Windows.Forms.ComboBox()
        Me.lblActivityLogs = New System.Windows.Forms.Label()
        Me.btnEditRow = New PinkieControls.ButtonXP()
        Me.pnlApprovers = New System.Windows.Forms.Panel()
        Me.lblApprovers = New System.Windows.Forms.Label()
        Me.txtEngineerItem = New System.Windows.Forms.Label()
        Me.txtEngineerId = New System.Windows.Forms.Label()
        Me.txtEngineerDateApproved = New System.Windows.Forms.Label()
        Me.txtManagerItem = New System.Windows.Forms.Label()
        Me.txtManagerId = New System.Windows.Forms.Label()
        Me.lblEngineerDateApproved = New System.Windows.Forms.Label()
        Me.lblManagerDateApproved = New System.Windows.Forms.Label()
        Me.lblEngineerRemarks = New System.Windows.Forms.Label()
        Me.txtEngineerRemarks = New System.Windows.Forms.TextBox()
        Me.lblEngineerItem = New System.Windows.Forms.Label()
        Me.lblEngineerId = New System.Windows.Forms.Label()
        Me.lblManagerRemarks = New System.Windows.Forms.Label()
        Me.txtManagerRemarks = New System.Windows.Forms.TextBox()
        Me.txtManagerDateApproved = New System.Windows.Forms.Label()
        Me.lblManagerItem = New System.Windows.Forms.Label()
        Me.lblManagerId = New System.Windows.Forms.Label()
        Me.lblFileAttachment = New System.Windows.Forms.Label()
        Me.txtFileAttachment = New System.Windows.Forms.Label()
        Me.btnRemoveFile = New PinkieControls.ButtonXP()
        Me.btnAttachFile = New PinkieControls.ButtonXP()
        Me.txtFileName = New System.Windows.Forms.Label()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.TrxDetailIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrxIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrxDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShiftIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrxFromColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrxToColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ElapsedTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtRoutingStatus = New System.Windows.Forms.Label()
        CType(Me.picImgAttachment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlImage.SuspendLayout()
        CType(Me.dgvPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlApprovers.SuspendLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRuntimeAccumulated
        '
        Me.txtRuntimeAccumulated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRuntimeAccumulated.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtRuntimeAccumulated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuntimeAccumulated.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtRuntimeAccumulated.ForeColor = System.Drawing.Color.Black
        Me.txtRuntimeAccumulated.Location = New System.Drawing.Point(870, 182)
        Me.txtRuntimeAccumulated.Name = "txtRuntimeAccumulated"
        Me.txtRuntimeAccumulated.Size = New System.Drawing.Size(181, 27)
        Me.txtRuntimeAccumulated.TabIndex = 215
        Me.txtRuntimeAccumulated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtRuntimeAccumulated.UseCompatibleTextRendering = True
        '
        'lblRuntimeAccumulated
        '
        Me.lblRuntimeAccumulated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRuntimeAccumulated.BackColor = System.Drawing.SystemColors.Control
        Me.lblRuntimeAccumulated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRuntimeAccumulated.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuntimeAccumulated.ForeColor = System.Drawing.Color.Black
        Me.lblRuntimeAccumulated.Location = New System.Drawing.Point(771, 182)
        Me.lblRuntimeAccumulated.Name = "lblRuntimeAccumulated"
        Me.lblRuntimeAccumulated.Size = New System.Drawing.Size(100, 27)
        Me.lblRuntimeAccumulated.TabIndex = 214
        Me.lblRuntimeAccumulated.Text = " Total Runtime"
        Me.lblRuntimeAccumulated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDowntimeAccumulated
        '
        Me.txtDowntimeAccumulated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDowntimeAccumulated.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtDowntimeAccumulated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDowntimeAccumulated.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtDowntimeAccumulated.ForeColor = System.Drawing.Color.Black
        Me.txtDowntimeAccumulated.Location = New System.Drawing.Point(1169, 182)
        Me.txtDowntimeAccumulated.Name = "txtDowntimeAccumulated"
        Me.txtDowntimeAccumulated.Size = New System.Drawing.Size(156, 27)
        Me.txtDowntimeAccumulated.TabIndex = 217
        Me.txtDowntimeAccumulated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtDowntimeAccumulated.UseCompatibleTextRendering = True
        '
        'lblDowntimeAccumulated
        '
        Me.lblDowntimeAccumulated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDowntimeAccumulated.BackColor = System.Drawing.SystemColors.Control
        Me.lblDowntimeAccumulated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDowntimeAccumulated.ForeColor = System.Drawing.Color.Black
        Me.lblDowntimeAccumulated.Location = New System.Drawing.Point(1050, 182)
        Me.lblDowntimeAccumulated.Name = "lblDowntimeAccumulated"
        Me.lblDowntimeAccumulated.Size = New System.Drawing.Size(120, 27)
        Me.lblDowntimeAccumulated.TabIndex = 216
        Me.lblDowntimeAccumulated.Text = " Total Downtime"
        Me.lblDowntimeAccumulated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransactionDate
        '
        Me.txtTransactionDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTransactionDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtTransactionDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransactionDate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtTransactionDate.ForeColor = System.Drawing.Color.Black
        Me.txtTransactionDate.Location = New System.Drawing.Point(518, 81)
        Me.txtTransactionDate.Name = "txtTransactionDate"
        Me.txtTransactionDate.Size = New System.Drawing.Size(250, 24)
        Me.txtTransactionDate.TabIndex = 242
        Me.txtTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtTransactionDate.UseCompatibleTextRendering = True
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTransactionDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblTransactionDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransactionDate.ForeColor = System.Drawing.Color.Black
        Me.lblTransactionDate.Location = New System.Drawing.Point(389, 81)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(130, 24)
        Me.lblTransactionDate.TabIndex = 241
        Me.lblTransactionDate.Text = " Transaction Date"
        Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransactionId
        '
        Me.txtTransactionId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTransactionId.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtTransactionId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransactionId.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtTransactionId.ForeColor = System.Drawing.Color.Black
        Me.txtTransactionId.Location = New System.Drawing.Point(518, 55)
        Me.txtTransactionId.Name = "txtTransactionId"
        Me.txtTransactionId.Size = New System.Drawing.Size(250, 24)
        Me.txtTransactionId.TabIndex = 240
        Me.txtTransactionId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtTransactionId.UseCompatibleTextRendering = True
        '
        'lblTransactionId
        '
        Me.lblTransactionId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTransactionId.BackColor = System.Drawing.SystemColors.Control
        Me.lblTransactionId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransactionId.ForeColor = System.Drawing.Color.Black
        Me.lblTransactionId.Location = New System.Drawing.Point(389, 55)
        Me.lblTransactionId.Name = "lblTransactionId"
        Me.lblTransactionId.Size = New System.Drawing.Size(130, 24)
        Me.lblTransactionId.TabIndex = 239
        Me.lblTransactionId.Text = " Transaction ID"
        Me.lblTransactionId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtImageName
        '
        Me.txtImageName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImageName.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtImageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImageName.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageName.ForeColor = System.Drawing.Color.Black
        Me.txtImageName.Location = New System.Drawing.Point(771, 500)
        Me.txtImageName.Name = "txtImageName"
        Me.txtImageName.Size = New System.Drawing.Size(280, 24)
        Me.txtImageName.TabIndex = 245
        Me.txtImageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtImageName.UseCompatibleTextRendering = True
        '
        'cmbTrxStatus
        '
        Me.cmbTrxStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTrxStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTrxStatus.DisplayMember = "TrxStatusName"
        Me.cmbTrxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTrxStatus.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTrxStatus.Location = New System.Drawing.Point(518, 29)
        Me.cmbTrxStatus.Name = "cmbTrxStatus"
        Me.cmbTrxStatus.Size = New System.Drawing.Size(250, 24)
        Me.cmbTrxStatus.TabIndex = 210
        Me.cmbTrxStatus.TabStop = False
        Me.cmbTrxStatus.ValueMember = "TrxStatusId"
        '
        'lblTrxStatus
        '
        Me.lblTrxStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTrxStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblTrxStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTrxStatus.ForeColor = System.Drawing.Color.Black
        Me.lblTrxStatus.Location = New System.Drawing.Point(389, 29)
        Me.lblTrxStatus.Name = "lblTrxStatus"
        Me.lblTrxStatus.Size = New System.Drawing.Size(130, 24)
        Me.lblTrxStatus.TabIndex = 211
        Me.lblTrxStatus.Text = " Transaction Status"
        Me.lblTrxStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRoutingStatus
        '
        Me.lblRoutingStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRoutingStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblRoutingStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRoutingStatus.ForeColor = System.Drawing.Color.Black
        Me.lblRoutingStatus.Location = New System.Drawing.Point(389, 3)
        Me.lblRoutingStatus.Name = "lblRoutingStatus"
        Me.lblRoutingStatus.Size = New System.Drawing.Size(130, 24)
        Me.lblRoutingStatus.TabIndex = 213
        Me.lblRoutingStatus.Text = " Routing Status"
        Me.lblRoutingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMachineName
        '
        Me.cmbMachineName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMachineName.DisplayMember = "MachineName"
        Me.cmbMachineName.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMachineName.FormattingEnabled = True
        Me.cmbMachineName.Location = New System.Drawing.Point(518, 107)
        Me.cmbMachineName.Name = "cmbMachineName"
        Me.cmbMachineName.Size = New System.Drawing.Size(250, 24)
        Me.cmbMachineName.TabIndex = 0
        Me.cmbMachineName.ValueMember = "MachineId"
        '
        'lblMachineName
        '
        Me.lblMachineName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMachineName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMachineName.ForeColor = System.Drawing.Color.Black
        Me.lblMachineName.Location = New System.Drawing.Point(389, 107)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Size = New System.Drawing.Size(130, 24)
        Me.lblMachineName.TabIndex = 220
        Me.lblMachineName.Text = " Machine Name"
        Me.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbArea
        '
        Me.cmbArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbArea.DisplayMember = "AreaName"
        Me.cmbArea.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(518, 133)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(250, 24)
        Me.cmbArea.TabIndex = 1
        Me.cmbArea.ValueMember = "AreaId"
        '
        'lblArea
        '
        Me.lblArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblArea.BackColor = System.Drawing.SystemColors.Control
        Me.lblArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblArea.ForeColor = System.Drawing.Color.Black
        Me.lblArea.Location = New System.Drawing.Point(389, 133)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(130, 24)
        Me.lblArea.TabIndex = 221
        Me.lblArea.Text = " Area"
        Me.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMachinePart
        '
        Me.cmbMachinePart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMachinePart.DisplayMember = "MachinePartName"
        Me.cmbMachinePart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMachinePart.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMachinePart.FormattingEnabled = True
        Me.cmbMachinePart.Location = New System.Drawing.Point(518, 159)
        Me.cmbMachinePart.Name = "cmbMachinePart"
        Me.cmbMachinePart.Size = New System.Drawing.Size(250, 24)
        Me.cmbMachinePart.TabIndex = 2
        Me.cmbMachinePart.ValueMember = "MachinePartId"
        '
        'cmbMachineStatus
        '
        Me.cmbMachineStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMachineStatus.DisplayMember = "MachineStatusName"
        Me.cmbMachineStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMachineStatus.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMachineStatus.FormattingEnabled = True
        Me.cmbMachineStatus.Location = New System.Drawing.Point(518, 185)
        Me.cmbMachineStatus.Name = "cmbMachineStatus"
        Me.cmbMachineStatus.Size = New System.Drawing.Size(250, 24)
        Me.cmbMachineStatus.TabIndex = 3
        Me.cmbMachineStatus.ValueMember = "MachineStatusId"
        '
        'lblMachineStatus
        '
        Me.lblMachineStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMachineStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblMachineStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMachineStatus.ForeColor = System.Drawing.Color.Black
        Me.lblMachineStatus.Location = New System.Drawing.Point(389, 185)
        Me.lblMachineStatus.Name = "lblMachineStatus"
        Me.lblMachineStatus.Size = New System.Drawing.Size(130, 24)
        Me.lblMachineStatus.TabIndex = 225
        Me.lblMachineStatus.Text = " Machine Status"
        Me.lblMachineStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachinePart
        '
        Me.lblMachinePart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMachinePart.BackColor = System.Drawing.SystemColors.Control
        Me.lblMachinePart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMachinePart.ForeColor = System.Drawing.Color.Black
        Me.lblMachinePart.Location = New System.Drawing.Point(389, 159)
        Me.lblMachinePart.Name = "lblMachinePart"
        Me.lblMachinePart.Size = New System.Drawing.Size(130, 24)
        Me.lblMachinePart.TabIndex = 224
        Me.lblMachinePart.Text = " Machine Parts"
        Me.lblMachinePart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProblem
        '
        Me.txtProblem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProblem.Location = New System.Drawing.Point(389, 234)
        Me.txtProblem.Multiline = True
        Me.txtProblem.Name = "txtProblem"
        Me.txtProblem.Size = New System.Drawing.Size(379, 66)
        Me.txtProblem.TabIndex = 4
        '
        'lblProblem
        '
        Me.lblProblem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProblem.BackColor = System.Drawing.SystemColors.Control
        Me.lblProblem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProblem.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProblem.ForeColor = System.Drawing.Color.Black
        Me.lblProblem.Location = New System.Drawing.Point(389, 211)
        Me.lblProblem.Name = "lblProblem"
        Me.lblProblem.Size = New System.Drawing.Size(379, 24)
        Me.lblProblem.TabIndex = 227
        Me.lblProblem.Text = " Problem"
        Me.lblProblem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtActionTaken
        '
        Me.txtActionTaken.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtActionTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActionTaken.Location = New System.Drawing.Point(389, 325)
        Me.txtActionTaken.Multiline = True
        Me.txtActionTaken.Name = "txtActionTaken"
        Me.txtActionTaken.Size = New System.Drawing.Size(379, 65)
        Me.txtActionTaken.TabIndex = 5
        '
        'lblActionTaken
        '
        Me.lblActionTaken.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActionTaken.BackColor = System.Drawing.SystemColors.Control
        Me.lblActionTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActionTaken.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActionTaken.ForeColor = System.Drawing.Color.Black
        Me.lblActionTaken.Location = New System.Drawing.Point(389, 302)
        Me.lblActionTaken.Name = "lblActionTaken"
        Me.lblActionTaken.Size = New System.Drawing.Size(379, 24)
        Me.lblActionTaken.TabIndex = 229
        Me.lblActionTaken.Text = " Action Taken"
        Me.lblActionTaken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPartsReplaced
        '
        Me.lblPartsReplaced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPartsReplaced.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartsReplaced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartsReplaced.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartsReplaced.ForeColor = System.Drawing.Color.Black
        Me.lblPartsReplaced.Location = New System.Drawing.Point(389, 392)
        Me.lblPartsReplaced.Name = "lblPartsReplaced"
        Me.lblPartsReplaced.Size = New System.Drawing.Size(379, 24)
        Me.lblPartsReplaced.TabIndex = 231
        Me.lblPartsReplaced.Text = "Parts Replaced"
        Me.lblPartsReplaced.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartsReplaced
        '
        Me.txtPartsReplaced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartsReplaced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartsReplaced.Location = New System.Drawing.Point(389, 415)
        Me.txtPartsReplaced.Multiline = True
        Me.txtPartsReplaced.Name = "txtPartsReplaced"
        Me.txtPartsReplaced.Size = New System.Drawing.Size(379, 57)
        Me.txtPartsReplaced.TabIndex = 6
        '
        'txtPartNo
        '
        Me.txtPartNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNo.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartNo.Location = New System.Drawing.Point(518, 474)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(250, 24)
        Me.txtPartNo.TabIndex = 7
        '
        'lblPartNo
        '
        Me.lblPartNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPartNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartNo.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNo.ForeColor = System.Drawing.Color.Black
        Me.lblPartNo.Location = New System.Drawing.Point(389, 474)
        Me.lblPartNo.Name = "lblPartNo"
        Me.lblPartNo.Size = New System.Drawing.Size(130, 24)
        Me.lblPartNo.TabIndex = 233
        Me.lblPartNo.Text = " Part No."
        Me.lblPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblJoNumber
        '
        Me.lblJoNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblJoNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblJoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJoNumber.ForeColor = System.Drawing.Color.Black
        Me.lblJoNumber.Location = New System.Drawing.Point(389, 500)
        Me.lblJoNumber.Name = "lblJoNumber"
        Me.lblJoNumber.Size = New System.Drawing.Size(130, 24)
        Me.lblJoNumber.TabIndex = 235
        Me.lblJoNumber.Text = " Job Order No"
        Me.lblJoNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtJoNumber
        '
        Me.txtJoNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJoNumber.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJoNumber.Location = New System.Drawing.Point(518, 500)
        Me.txtJoNumber.MaxLength = 15
        Me.txtJoNumber.Name = "txtJoNumber"
        Me.txtJoNumber.Size = New System.Drawing.Size(250, 24)
        Me.txtJoNumber.TabIndex = 8
        '
        'lblJoRequestor
        '
        Me.lblJoRequestor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblJoRequestor.BackColor = System.Drawing.SystemColors.Control
        Me.lblJoRequestor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJoRequestor.ForeColor = System.Drawing.Color.Black
        Me.lblJoRequestor.Location = New System.Drawing.Point(389, 526)
        Me.lblJoRequestor.Name = "lblJoRequestor"
        Me.lblJoRequestor.Size = New System.Drawing.Size(130, 24)
        Me.lblJoRequestor.TabIndex = 237
        Me.lblJoRequestor.Text = " Requestor Name"
        Me.lblJoRequestor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtJoRequestor
        '
        Me.txtJoRequestor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJoRequestor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJoRequestor.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJoRequestor.Location = New System.Drawing.Point(518, 526)
        Me.txtJoRequestor.Name = "txtJoRequestor"
        Me.txtJoRequestor.Size = New System.Drawing.Size(250, 24)
        Me.txtJoRequestor.TabIndex = 9
        '
        'btnRemoveRow
        '
        Me.btnRemoveRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemoveRow.DefaultScheme = False
        Me.btnRemoveRow.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemoveRow.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnRemoveRow.Hint = ""
        Me.btnRemoveRow.Location = New System.Drawing.Point(1222, 5)
        Me.btnRemoveRow.Name = "btnRemoveRow"
        Me.btnRemoveRow.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemoveRow.Size = New System.Drawing.Size(100, 25)
        Me.btnRemoveRow.TabIndex = 249
        Me.btnRemoveRow.TabStop = False
        Me.btnRemoveRow.Text = "Delete Row"
        '
        'btnAddRow
        '
        Me.btnAddRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAddRow.DefaultScheme = False
        Me.btnAddRow.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAddRow.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnAddRow.Hint = ""
        Me.btnAddRow.Location = New System.Drawing.Point(1020, 5)
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAddRow.Size = New System.Drawing.Size(100, 25)
        Me.btnAddRow.TabIndex = 248
        Me.btnAddRow.TabStop = False
        Me.btnAddRow.Text = "Add Row"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnClose.Hint = ""
        Me.btnClose.Location = New System.Drawing.Point(1226, 566)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(100, 30)
        Me.btnClose.TabIndex = 253
        Me.btnClose.TabStop = False
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
        Me.btnDelete.Location = New System.Drawing.Point(1125, 566)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(100, 30)
        Me.btnDelete.TabIndex = 252
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "  Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.DefaultScheme = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnCancel.Hint = ""
        Me.btnCancel.Location = New System.Drawing.Point(1024, 566)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 251
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "  Cancel"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.DefaultScheme = False
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnSave.Hint = ""
        Me.btnSave.Location = New System.Drawing.Point(923, 566)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(100, 30)
        Me.btnSave.TabIndex = 250
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "  Save"
        '
        'lblImageAttachment
        '
        Me.lblImageAttachment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImageAttachment.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImageAttachment.ForeColor = System.Drawing.Color.Black
        Me.lblImageAttachment.Location = New System.Drawing.Point(771, 211)
        Me.lblImageAttachment.Name = "lblImageAttachment"
        Me.lblImageAttachment.Size = New System.Drawing.Size(280, 24)
        Me.lblImageAttachment.TabIndex = 243
        Me.lblImageAttachment.Text = " Image"
        Me.lblImageAttachment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picImgAttachment
        '
        Me.picImgAttachment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picImgAttachment.BackColor = System.Drawing.Color.White
        Me.picImgAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImgAttachment.ErrorImage = Nothing
        Me.picImgAttachment.InitialImage = Nothing
        Me.picImgAttachment.Location = New System.Drawing.Point(4, 2)
        Me.picImgAttachment.Name = "picImgAttachment"
        Me.picImgAttachment.Size = New System.Drawing.Size(270, 230)
        Me.picImgAttachment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImgAttachment.TabIndex = 0
        Me.picImgAttachment.TabStop = False
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnBrowse.DefaultScheme = False
        Me.btnBrowse.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnBrowse.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnBrowse.Hint = ""
        Me.btnBrowse.Location = New System.Drawing.Point(93, 234)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnBrowse.Size = New System.Drawing.Size(90, 26)
        Me.btnBrowse.TabIndex = 210
        Me.btnBrowse.TabStop = False
        Me.btnBrowse.Text = "Browse"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnRemove.DefaultScheme = False
        Me.btnRemove.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnRemove.Hint = ""
        Me.btnRemove.Location = New System.Drawing.Point(185, 234)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove.Size = New System.Drawing.Size(90, 26)
        Me.btnRemove.TabIndex = 211
        Me.btnRemove.TabStop = False
        Me.btnRemove.Text = "Remove"
        '
        'pnlImage
        '
        Me.pnlImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlImage.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImage.Controls.Add(Me.btnRemove)
        Me.pnlImage.Controls.Add(Me.btnBrowse)
        Me.pnlImage.Controls.Add(Me.picImgAttachment)
        Me.pnlImage.Location = New System.Drawing.Point(771, 234)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(280, 264)
        Me.pnlImage.TabIndex = 244
        '
        'lblPic
        '
        Me.lblPic.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPic.BackColor = System.Drawing.SystemColors.Control
        Me.lblPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPic.ForeColor = System.Drawing.Color.Black
        Me.lblPic.Location = New System.Drawing.Point(1053, 211)
        Me.lblPic.Name = "lblPic"
        Me.lblPic.Size = New System.Drawing.Size(272, 24)
        Me.lblPic.TabIndex = 246
        Me.lblPic.Text = " Included PIC"
        Me.lblPic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvPic
        '
        Me.dgvPic.AllowUserToAddRows = False
        Me.dgvPic.AllowUserToDeleteRows = False
        Me.dgvPic.AllowUserToResizeColumns = False
        Me.dgvPic.AllowUserToResizeRows = False
        Me.dgvPic.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPic.ColumnHeadersHeight = 22
        Me.dgvPic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPic.ColumnHeadersVisible = False
        Me.dgvPic.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IsSelectedColumn, Me.UserIdColumn, Me.UserNameColumn})
        Me.dgvPic.Location = New System.Drawing.Point(1053, 234)
        Me.dgvPic.MultiSelect = False
        Me.dgvPic.Name = "dgvPic"
        Me.dgvPic.RowHeadersVisible = False
        Me.dgvPic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPic.Size = New System.Drawing.Size(272, 290)
        Me.dgvPic.TabIndex = 11
        Me.dgvPic.TabStop = False
        '
        'IsSelectedColumn
        '
        Me.IsSelectedColumn.HeaderText = "*"
        Me.IsSelectedColumn.Name = "IsSelectedColumn"
        Me.IsSelectedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.IsSelectedColumn.Width = 25
        '
        'UserIdColumn
        '
        Me.UserIdColumn.DataPropertyName = "UserId"
        Me.UserIdColumn.HeaderText = "UserId"
        Me.UserIdColumn.Name = "UserIdColumn"
        Me.UserIdColumn.ReadOnly = True
        Me.UserIdColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UserIdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UserIdColumn.Visible = False
        '
        'UserNameColumn
        '
        Me.UserNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.UserNameColumn.DataPropertyName = "UserName"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.UserNameColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.UserNameColumn.HeaderText = "NickName"
        Me.UserNameColumn.Name = "UserNameColumn"
        Me.UserNameColumn.ReadOnly = True
        Me.UserNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UserNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'btnReturn
        '
        Me.btnReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReturn.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnReturn.DefaultScheme = False
        Me.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnReturn.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnReturn.Hint = ""
        Me.btnReturn.Location = New System.Drawing.Point(282, 562)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnReturn.Size = New System.Drawing.Size(100, 30)
        Me.btnReturn.TabIndex = 277
        Me.btnReturn.TabStop = False
        Me.btnReturn.Text = " Return"
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnApprove.DefaultScheme = False
        Me.btnApprove.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnApprove.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnApprove.Hint = ""
        Me.btnApprove.Location = New System.Drawing.Point(180, 562)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnApprove.Size = New System.Drawing.Size(100, 30)
        Me.btnApprove.TabIndex = 276
        Me.btnApprove.TabStop = False
        Me.btnApprove.Text = " Approve"
        '
        'cmbRoutingStatus
        '
        Me.cmbRoutingStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRoutingStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRoutingStatus.DisplayMember = "RoutingStatusName"
        Me.cmbRoutingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRoutingStatus.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRoutingStatus.Location = New System.Drawing.Point(518, 3)
        Me.cmbRoutingStatus.Name = "cmbRoutingStatus"
        Me.cmbRoutingStatus.Size = New System.Drawing.Size(250, 24)
        Me.cmbRoutingStatus.TabIndex = 278
        Me.cmbRoutingStatus.TabStop = False
        Me.cmbRoutingStatus.ValueMember = "RoutingStatusId"
        '
        'lblActivityLogs
        '
        Me.lblActivityLogs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActivityLogs.BackColor = System.Drawing.SystemColors.Control
        Me.lblActivityLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActivityLogs.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivityLogs.ForeColor = System.Drawing.Color.Black
        Me.lblActivityLogs.Location = New System.Drawing.Point(771, 3)
        Me.lblActivityLogs.Name = "lblActivityLogs"
        Me.lblActivityLogs.Size = New System.Drawing.Size(554, 29)
        Me.lblActivityLogs.TabIndex = 279
        Me.lblActivityLogs.Text = " Activity Logs"
        Me.lblActivityLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEditRow
        '
        Me.btnEditRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEditRow.DefaultScheme = False
        Me.btnEditRow.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnEditRow.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnEditRow.Hint = ""
        Me.btnEditRow.Location = New System.Drawing.Point(1121, 5)
        Me.btnEditRow.Name = "btnEditRow"
        Me.btnEditRow.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnEditRow.Size = New System.Drawing.Size(100, 25)
        Me.btnEditRow.TabIndex = 280
        Me.btnEditRow.TabStop = False
        Me.btnEditRow.Text = "Edit Row"
        '
        'pnlApprovers
        '
        Me.pnlApprovers.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlApprovers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlApprovers.Controls.Add(Me.lblApprovers)
        Me.pnlApprovers.Controls.Add(Me.txtEngineerItem)
        Me.pnlApprovers.Controls.Add(Me.txtEngineerId)
        Me.pnlApprovers.Controls.Add(Me.txtEngineerDateApproved)
        Me.pnlApprovers.Controls.Add(Me.txtManagerItem)
        Me.pnlApprovers.Controls.Add(Me.txtManagerId)
        Me.pnlApprovers.Controls.Add(Me.lblEngineerDateApproved)
        Me.pnlApprovers.Controls.Add(Me.lblManagerDateApproved)
        Me.pnlApprovers.Controls.Add(Me.lblEngineerRemarks)
        Me.pnlApprovers.Controls.Add(Me.txtEngineerRemarks)
        Me.pnlApprovers.Controls.Add(Me.lblEngineerItem)
        Me.pnlApprovers.Controls.Add(Me.lblEngineerId)
        Me.pnlApprovers.Controls.Add(Me.lblManagerRemarks)
        Me.pnlApprovers.Controls.Add(Me.txtManagerRemarks)
        Me.pnlApprovers.Controls.Add(Me.txtManagerDateApproved)
        Me.pnlApprovers.Controls.Add(Me.lblManagerItem)
        Me.pnlApprovers.Controls.Add(Me.lblManagerId)
        Me.pnlApprovers.Controls.Add(Me.btnApprove)
        Me.pnlApprovers.Controls.Add(Me.btnReturn)
        Me.pnlApprovers.Location = New System.Drawing.Point(0, 3)
        Me.pnlApprovers.Name = "pnlApprovers"
        Me.pnlApprovers.Size = New System.Drawing.Size(387, 598)
        Me.pnlApprovers.TabIndex = 281
        '
        'lblApprovers
        '
        Me.lblApprovers.AutoSize = True
        Me.lblApprovers.Location = New System.Drawing.Point(3, 7)
        Me.lblApprovers.Name = "lblApprovers"
        Me.lblApprovers.Size = New System.Drawing.Size(75, 14)
        Me.lblApprovers.TabIndex = 292
        Me.lblApprovers.Text = " Approvers"
        '
        'txtEngineerItem
        '
        Me.txtEngineerItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEngineerItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEngineerItem.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtEngineerItem.ForeColor = System.Drawing.Color.Black
        Me.txtEngineerItem.Location = New System.Drawing.Point(132, 327)
        Me.txtEngineerItem.Name = "txtEngineerItem"
        Me.txtEngineerItem.Size = New System.Drawing.Size(250, 24)
        Me.txtEngineerItem.TabIndex = 291
        Me.txtEngineerItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtEngineerItem.UseCompatibleTextRendering = True
        '
        'txtEngineerId
        '
        Me.txtEngineerId.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEngineerId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEngineerId.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtEngineerId.ForeColor = System.Drawing.Color.Black
        Me.txtEngineerId.Location = New System.Drawing.Point(132, 301)
        Me.txtEngineerId.Name = "txtEngineerId"
        Me.txtEngineerId.Size = New System.Drawing.Size(250, 24)
        Me.txtEngineerId.TabIndex = 290
        Me.txtEngineerId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtEngineerId.UseCompatibleTextRendering = True
        '
        'txtEngineerDateApproved
        '
        Me.txtEngineerDateApproved.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEngineerDateApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEngineerDateApproved.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtEngineerDateApproved.ForeColor = System.Drawing.Color.Black
        Me.txtEngineerDateApproved.Location = New System.Drawing.Point(132, 275)
        Me.txtEngineerDateApproved.Name = "txtEngineerDateApproved"
        Me.txtEngineerDateApproved.Size = New System.Drawing.Size(250, 24)
        Me.txtEngineerDateApproved.TabIndex = 289
        Me.txtEngineerDateApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtEngineerDateApproved.UseCompatibleTextRendering = True
        '
        'txtManagerItem
        '
        Me.txtManagerItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtManagerItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtManagerItem.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtManagerItem.ForeColor = System.Drawing.Color.Black
        Me.txtManagerItem.Location = New System.Drawing.Point(132, 80)
        Me.txtManagerItem.Name = "txtManagerItem"
        Me.txtManagerItem.Size = New System.Drawing.Size(250, 24)
        Me.txtManagerItem.TabIndex = 288
        Me.txtManagerItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtManagerItem.UseCompatibleTextRendering = True
        '
        'txtManagerId
        '
        Me.txtManagerId.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtManagerId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtManagerId.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtManagerId.ForeColor = System.Drawing.Color.Black
        Me.txtManagerId.Location = New System.Drawing.Point(132, 54)
        Me.txtManagerId.Name = "txtManagerId"
        Me.txtManagerId.Size = New System.Drawing.Size(250, 24)
        Me.txtManagerId.TabIndex = 287
        Me.txtManagerId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtManagerId.UseCompatibleTextRendering = True
        '
        'lblEngineerDateApproved
        '
        Me.lblEngineerDateApproved.BackColor = System.Drawing.SystemColors.Control
        Me.lblEngineerDateApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEngineerDateApproved.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEngineerDateApproved.ForeColor = System.Drawing.Color.Black
        Me.lblEngineerDateApproved.Location = New System.Drawing.Point(3, 275)
        Me.lblEngineerDateApproved.Name = "lblEngineerDateApproved"
        Me.lblEngineerDateApproved.Size = New System.Drawing.Size(130, 24)
        Me.lblEngineerDateApproved.TabIndex = 286
        Me.lblEngineerDateApproved.Text = " Date Approved"
        Me.lblEngineerDateApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblManagerDateApproved
        '
        Me.lblManagerDateApproved.BackColor = System.Drawing.SystemColors.Control
        Me.lblManagerDateApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblManagerDateApproved.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManagerDateApproved.ForeColor = System.Drawing.Color.Black
        Me.lblManagerDateApproved.Location = New System.Drawing.Point(3, 28)
        Me.lblManagerDateApproved.Name = "lblManagerDateApproved"
        Me.lblManagerDateApproved.Size = New System.Drawing.Size(130, 24)
        Me.lblManagerDateApproved.TabIndex = 285
        Me.lblManagerDateApproved.Text = " Date Approved"
        Me.lblManagerDateApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEngineerRemarks
        '
        Me.lblEngineerRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblEngineerRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEngineerRemarks.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEngineerRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblEngineerRemarks.Location = New System.Drawing.Point(3, 353)
        Me.lblEngineerRemarks.Name = "lblEngineerRemarks"
        Me.lblEngineerRemarks.Size = New System.Drawing.Size(379, 24)
        Me.lblEngineerRemarks.TabIndex = 284
        Me.lblEngineerRemarks.Text = " Remarks"
        Me.lblEngineerRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEngineerRemarks
        '
        Me.txtEngineerRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEngineerRemarks.Location = New System.Drawing.Point(3, 376)
        Me.txtEngineerRemarks.Multiline = True
        Me.txtEngineerRemarks.Name = "txtEngineerRemarks"
        Me.txtEngineerRemarks.Size = New System.Drawing.Size(379, 144)
        Me.txtEngineerRemarks.TabIndex = 283
        '
        'lblEngineerItem
        '
        Me.lblEngineerItem.BackColor = System.Drawing.SystemColors.Control
        Me.lblEngineerItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEngineerItem.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEngineerItem.ForeColor = System.Drawing.Color.Black
        Me.lblEngineerItem.Location = New System.Drawing.Point(3, 327)
        Me.lblEngineerItem.Name = "lblEngineerItem"
        Me.lblEngineerItem.Size = New System.Drawing.Size(130, 24)
        Me.lblEngineerItem.TabIndex = 282
        Me.lblEngineerItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEngineerId
        '
        Me.lblEngineerId.BackColor = System.Drawing.SystemColors.Control
        Me.lblEngineerId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEngineerId.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEngineerId.ForeColor = System.Drawing.Color.Black
        Me.lblEngineerId.Location = New System.Drawing.Point(3, 301)
        Me.lblEngineerId.Name = "lblEngineerId"
        Me.lblEngineerId.Size = New System.Drawing.Size(130, 24)
        Me.lblEngineerId.TabIndex = 281
        Me.lblEngineerId.Text = " Verified by"
        Me.lblEngineerId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblManagerRemarks
        '
        Me.lblManagerRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblManagerRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblManagerRemarks.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManagerRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblManagerRemarks.Location = New System.Drawing.Point(3, 106)
        Me.lblManagerRemarks.Name = "lblManagerRemarks"
        Me.lblManagerRemarks.Size = New System.Drawing.Size(379, 24)
        Me.lblManagerRemarks.TabIndex = 280
        Me.lblManagerRemarks.Text = " Remarks"
        Me.lblManagerRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtManagerRemarks
        '
        Me.txtManagerRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtManagerRemarks.Location = New System.Drawing.Point(3, 129)
        Me.txtManagerRemarks.Multiline = True
        Me.txtManagerRemarks.Name = "txtManagerRemarks"
        Me.txtManagerRemarks.Size = New System.Drawing.Size(379, 144)
        Me.txtManagerRemarks.TabIndex = 279
        '
        'txtManagerDateApproved
        '
        Me.txtManagerDateApproved.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtManagerDateApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtManagerDateApproved.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtManagerDateApproved.ForeColor = System.Drawing.Color.Black
        Me.txtManagerDateApproved.Location = New System.Drawing.Point(132, 28)
        Me.txtManagerDateApproved.Name = "txtManagerDateApproved"
        Me.txtManagerDateApproved.Size = New System.Drawing.Size(250, 24)
        Me.txtManagerDateApproved.TabIndex = 278
        Me.txtManagerDateApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtManagerDateApproved.UseCompatibleTextRendering = True
        '
        'lblManagerItem
        '
        Me.lblManagerItem.BackColor = System.Drawing.SystemColors.Control
        Me.lblManagerItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblManagerItem.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManagerItem.ForeColor = System.Drawing.Color.Black
        Me.lblManagerItem.Location = New System.Drawing.Point(3, 80)
        Me.lblManagerItem.Name = "lblManagerItem"
        Me.lblManagerItem.Size = New System.Drawing.Size(130, 24)
        Me.lblManagerItem.TabIndex = 277
        Me.lblManagerItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblManagerId
        '
        Me.lblManagerId.BackColor = System.Drawing.SystemColors.Control
        Me.lblManagerId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblManagerId.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManagerId.ForeColor = System.Drawing.Color.Black
        Me.lblManagerId.Location = New System.Drawing.Point(3, 54)
        Me.lblManagerId.Name = "lblManagerId"
        Me.lblManagerId.Size = New System.Drawing.Size(130, 24)
        Me.lblManagerId.TabIndex = 276
        Me.lblManagerId.Text = " Approved by"
        Me.lblManagerId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFileAttachment
        '
        Me.lblFileAttachment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFileAttachment.BackColor = System.Drawing.SystemColors.Control
        Me.lblFileAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFileAttachment.ForeColor = System.Drawing.Color.Black
        Me.lblFileAttachment.Location = New System.Drawing.Point(771, 526)
        Me.lblFileAttachment.Name = "lblFileAttachment"
        Me.lblFileAttachment.Size = New System.Drawing.Size(100, 24)
        Me.lblFileAttachment.TabIndex = 283
        Me.lblFileAttachment.Text = " File"
        Me.lblFileAttachment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFileAttachment
        '
        Me.txtFileAttachment.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtFileAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFileAttachment.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtFileAttachment.ForeColor = System.Drawing.Color.Black
        Me.txtFileAttachment.Location = New System.Drawing.Point(870, 526)
        Me.txtFileAttachment.Name = "txtFileAttachment"
        Me.txtFileAttachment.Size = New System.Drawing.Size(272, 24)
        Me.txtFileAttachment.TabIndex = 292
        Me.txtFileAttachment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtFileAttachment.UseCompatibleTextRendering = True
        '
        'btnRemoveFile
        '
        Me.btnRemoveFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemoveFile.DefaultScheme = False
        Me.btnRemoveFile.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemoveFile.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnRemoveFile.Hint = ""
        Me.btnRemoveFile.Location = New System.Drawing.Point(1235, 525)
        Me.btnRemoveFile.Name = "btnRemoveFile"
        Me.btnRemoveFile.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemoveFile.Size = New System.Drawing.Size(90, 26)
        Me.btnRemoveFile.TabIndex = 213
        Me.btnRemoveFile.TabStop = False
        Me.btnRemoveFile.Text = "Remove"
        '
        'btnAttachFile
        '
        Me.btnAttachFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAttachFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAttachFile.DefaultScheme = False
        Me.btnAttachFile.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAttachFile.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnAttachFile.Hint = ""
        Me.btnAttachFile.Location = New System.Drawing.Point(1144, 525)
        Me.btnAttachFile.Name = "btnAttachFile"
        Me.btnAttachFile.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAttachFile.Size = New System.Drawing.Size(90, 26)
        Me.btnAttachFile.TabIndex = 212
        Me.btnAttachFile.TabStop = False
        Me.btnAttachFile.Text = "Browse"
        '
        'txtFileName
        '
        Me.txtFileName.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFileName.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtFileName.ForeColor = System.Drawing.Color.Black
        Me.txtFileName.Location = New System.Drawing.Point(518, 552)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(250, 24)
        Me.txtFileName.TabIndex = 293
        Me.txtFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtFileName.UseCompatibleTextRendering = True
        Me.txtFileName.Visible = False
        '
        'lblFileName
        '
        Me.lblFileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFileName.BackColor = System.Drawing.SystemColors.Control
        Me.lblFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFileName.ForeColor = System.Drawing.Color.Black
        Me.lblFileName.Location = New System.Drawing.Point(389, 552)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(130, 24)
        Me.lblFileName.TabIndex = 294
        Me.lblFileName.Text = " Filename"
        Me.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFileName.Visible = False
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.AllowUserToResizeColumns = False
        Me.dgvDetail.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetail.ColumnHeadersHeight = 22
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TrxDetailIdColumn, Me.TrxIdColumn, Me.TrxDateColumn, Me.ShiftIdColumn, Me.TrxFromColumn, Me.TrxToColumn, Me.ElapsedTimeColumn})
        Me.dgvDetail.Location = New System.Drawing.Point(771, 31)
        Me.dgvDetail.MultiSelect = False
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.ReadOnly = True
        Me.dgvDetail.RowHeadersVisible = False
        Me.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetail.Size = New System.Drawing.Size(554, 152)
        Me.dgvDetail.TabIndex = 295
        '
        'TrxDetailIdColumn
        '
        Me.TrxDetailIdColumn.DataPropertyName = "TrxDetailId"
        Me.TrxDetailIdColumn.HeaderText = "TrxDetailId"
        Me.TrxDetailIdColumn.Name = "TrxDetailIdColumn"
        Me.TrxDetailIdColumn.ReadOnly = True
        Me.TrxDetailIdColumn.Visible = False
        '
        'TrxIdColumn
        '
        Me.TrxIdColumn.DataPropertyName = "TrxId"
        Me.TrxIdColumn.HeaderText = "TrxId"
        Me.TrxIdColumn.Name = "TrxIdColumn"
        Me.TrxIdColumn.ReadOnly = True
        Me.TrxIdColumn.Visible = False
        '
        'TrxDateColumn
        '
        Me.TrxDateColumn.DataPropertyName = "TrxDate"
        Me.TrxDateColumn.HeaderText = "TrxDate"
        Me.TrxDateColumn.Name = "TrxDateColumn"
        Me.TrxDateColumn.ReadOnly = True
        Me.TrxDateColumn.Visible = False
        '
        'ShiftIdColumn
        '
        Me.ShiftIdColumn.DataPropertyName = "ShiftId"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ShiftIdColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ShiftIdColumn.HeaderText = "Shift"
        Me.ShiftIdColumn.Name = "ShiftIdColumn"
        Me.ShiftIdColumn.ReadOnly = True
        Me.ShiftIdColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ShiftIdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ShiftIdColumn.Width = 50
        '
        'TrxFromColumn
        '
        Me.TrxFromColumn.DataPropertyName = "TrxFrom"
        Me.TrxFromColumn.HeaderText = "From"
        Me.TrxFromColumn.Name = "TrxFromColumn"
        Me.TrxFromColumn.ReadOnly = True
        Me.TrxFromColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TrxFromColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TrxFromColumn.Width = 150
        '
        'TrxToColumn
        '
        Me.TrxToColumn.DataPropertyName = "TrxTo"
        Me.TrxToColumn.HeaderText = "To"
        Me.TrxToColumn.Name = "TrxToColumn"
        Me.TrxToColumn.ReadOnly = True
        Me.TrxToColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TrxToColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TrxToColumn.Width = 150
        '
        'ElapsedTimeColumn
        '
        Me.ElapsedTimeColumn.DataPropertyName = "ElapsedTime"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ElapsedTimeColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ElapsedTimeColumn.HeaderText = "Downtime"
        Me.ElapsedTimeColumn.Name = "ElapsedTimeColumn"
        Me.ElapsedTimeColumn.ReadOnly = True
        Me.ElapsedTimeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ElapsedTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ElapsedTimeColumn.Width = 80
        '
        'txtRoutingStatus
        '
        Me.txtRoutingStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtRoutingStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRoutingStatus.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtRoutingStatus.ForeColor = System.Drawing.Color.Black
        Me.txtRoutingStatus.Location = New System.Drawing.Point(518, 3)
        Me.txtRoutingStatus.Name = "txtRoutingStatus"
        Me.txtRoutingStatus.Size = New System.Drawing.Size(250, 24)
        Me.txtRoutingStatus.TabIndex = 296
        Me.txtRoutingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtRoutingStatus.UseCompatibleTextRendering = True
        '
        'frmMntTrxDetail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1330, 601)
        Me.Controls.Add(Me.txtRoutingStatus)
        Me.Controls.Add(Me.lblPic)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.btnRemoveFile)
        Me.Controls.Add(Me.btnAttachFile)
        Me.Controls.Add(Me.txtFileAttachment)
        Me.Controls.Add(Me.lblFileAttachment)
        Me.Controls.Add(Me.pnlApprovers)
        Me.Controls.Add(Me.btnEditRow)
        Me.Controls.Add(Me.btnRemoveRow)
        Me.Controls.Add(Me.btnAddRow)
        Me.Controls.Add(Me.lblActivityLogs)
        Me.Controls.Add(Me.txtRuntimeAccumulated)
        Me.Controls.Add(Me.lblRoutingStatus)
        Me.Controls.Add(Me.cmbRoutingStatus)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgvPic)
        Me.Controls.Add(Me.txtImageName)
        Me.Controls.Add(Me.pnlImage)
        Me.Controls.Add(Me.lblImageAttachment)
        Me.Controls.Add(Me.txtTransactionDate)
        Me.Controls.Add(Me.lblTransactionDate)
        Me.Controls.Add(Me.txtTransactionId)
        Me.Controls.Add(Me.lblTransactionId)
        Me.Controls.Add(Me.txtJoRequestor)
        Me.Controls.Add(Me.lblJoRequestor)
        Me.Controls.Add(Me.txtJoNumber)
        Me.Controls.Add(Me.lblJoNumber)
        Me.Controls.Add(Me.lblPartNo)
        Me.Controls.Add(Me.txtPartNo)
        Me.Controls.Add(Me.txtPartsReplaced)
        Me.Controls.Add(Me.lblPartsReplaced)
        Me.Controls.Add(Me.lblActionTaken)
        Me.Controls.Add(Me.txtActionTaken)
        Me.Controls.Add(Me.lblProblem)
        Me.Controls.Add(Me.txtProblem)
        Me.Controls.Add(Me.lblMachinePart)
        Me.Controls.Add(Me.lblMachineStatus)
        Me.Controls.Add(Me.cmbMachineStatus)
        Me.Controls.Add(Me.cmbMachinePart)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.cmbArea)
        Me.Controls.Add(Me.lblMachineName)
        Me.Controls.Add(Me.cmbMachineName)
        Me.Controls.Add(Me.txtDowntimeAccumulated)
        Me.Controls.Add(Me.lblDowntimeAccumulated)
        Me.Controls.Add(Me.lblRuntimeAccumulated)
        Me.Controls.Add(Me.lblTrxStatus)
        Me.Controls.Add(Me.cmbTrxStatus)
        Me.Controls.Add(Me.dgvDetail)
        Me.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMntTrxDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " Transaction Details"
        CType(Me.picImgAttachment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlImage.ResumeLayout(False)
        CType(Me.dgvPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlApprovers.ResumeLayout(False)
        Me.pnlApprovers.PerformLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRuntimeAccumulated As System.Windows.Forms.Label
    Friend WithEvents lblRuntimeAccumulated As System.Windows.Forms.Label
    Friend WithEvents txtDowntimeAccumulated As System.Windows.Forms.Label
    Friend WithEvents lblDowntimeAccumulated As System.Windows.Forms.Label
    Friend WithEvents txtTransactionDate As System.Windows.Forms.Label
    Friend WithEvents lblTransactionDate As System.Windows.Forms.Label
    Friend WithEvents txtTransactionId As System.Windows.Forms.Label
    Friend WithEvents lblTransactionId As System.Windows.Forms.Label
    Friend WithEvents txtImageName As System.Windows.Forms.Label
    Friend WithEvents cmbTrxStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblTrxStatus As System.Windows.Forms.Label
    Friend WithEvents lblRoutingStatus As System.Windows.Forms.Label
    Friend WithEvents cmbMachineName As System.Windows.Forms.ComboBox
    Friend WithEvents lblMachineName As System.Windows.Forms.Label
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents cmbMachinePart As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMachineStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblMachineStatus As System.Windows.Forms.Label
    Friend WithEvents lblMachinePart As System.Windows.Forms.Label
    Friend WithEvents txtProblem As System.Windows.Forms.TextBox
    Friend WithEvents lblProblem As System.Windows.Forms.Label
    Friend WithEvents txtActionTaken As System.Windows.Forms.TextBox
    Friend WithEvents lblActionTaken As System.Windows.Forms.Label
    Friend WithEvents lblPartsReplaced As System.Windows.Forms.Label
    Friend WithEvents txtPartsReplaced As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPartNo As System.Windows.Forms.Label
    Friend WithEvents lblJoNumber As System.Windows.Forms.Label
    Friend WithEvents txtJoNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblJoRequestor As System.Windows.Forms.Label
    Friend WithEvents txtJoRequestor As System.Windows.Forms.TextBox
    Friend WithEvents btnRemoveRow As PinkieControls.ButtonXP
    Friend WithEvents btnAddRow As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents lblImageAttachment As System.Windows.Forms.Label
    Friend WithEvents picImgAttachment As System.Windows.Forms.PictureBox
    Friend WithEvents btnBrowse As PinkieControls.ButtonXP
    Friend WithEvents btnRemove As PinkieControls.ButtonXP
    Friend WithEvents pnlImage As System.Windows.Forms.Panel
    Friend WithEvents lblPic As System.Windows.Forms.Label
    Friend WithEvents dgvPic As System.Windows.Forms.DataGridView
    Friend WithEvents btnReturn As PinkieControls.ButtonXP
    Friend WithEvents btnApprove As PinkieControls.ButtonXP
    Friend WithEvents cmbRoutingStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblActivityLogs As System.Windows.Forms.Label
    Friend WithEvents btnEditRow As PinkieControls.ButtonXP
    Friend WithEvents pnlApprovers As System.Windows.Forms.Panel
    Friend WithEvents txtEngineerItem As System.Windows.Forms.Label
    Friend WithEvents txtEngineerId As System.Windows.Forms.Label
    Friend WithEvents txtEngineerDateApproved As System.Windows.Forms.Label
    Friend WithEvents txtManagerItem As System.Windows.Forms.Label
    Friend WithEvents txtManagerId As System.Windows.Forms.Label
    Friend WithEvents lblEngineerDateApproved As System.Windows.Forms.Label
    Friend WithEvents lblManagerDateApproved As System.Windows.Forms.Label
    Friend WithEvents lblEngineerRemarks As System.Windows.Forms.Label
    Friend WithEvents txtEngineerRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblEngineerItem As System.Windows.Forms.Label
    Friend WithEvents lblEngineerId As System.Windows.Forms.Label
    Friend WithEvents lblManagerRemarks As System.Windows.Forms.Label
    Friend WithEvents txtManagerRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtManagerDateApproved As System.Windows.Forms.Label
    Friend WithEvents lblManagerItem As System.Windows.Forms.Label
    Friend WithEvents lblManagerId As System.Windows.Forms.Label
    Friend WithEvents lblFileAttachment As System.Windows.Forms.Label
    Friend WithEvents txtFileAttachment As System.Windows.Forms.Label
    Friend WithEvents btnRemoveFile As PinkieControls.ButtonXP
    Friend WithEvents btnAttachFile As PinkieControls.ButtonXP
    Friend WithEvents lblApprovers As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.Label
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents dgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents TrxDetailIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrxIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrxDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrxFromColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrxToColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ElapsedTimeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsSelectedColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtRoutingStatus As System.Windows.Forms.Label
End Class
