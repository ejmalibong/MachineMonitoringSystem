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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtRuntimeAccumulated = New System.Windows.Forms.Label()
        Me.lblRuntimeAccumulated = New System.Windows.Forms.Label()
        Me.txtDowntimeAccumulated = New System.Windows.Forms.Label()
        Me.lblDowntimeAccumulated = New System.Windows.Forms.Label()
        Me.txtTransactionDate = New System.Windows.Forms.Label()
        Me.lblTransactionDate = New System.Windows.Forms.Label()
        Me.txtTransactionId = New System.Windows.Forms.Label()
        Me.lblTransactionId = New System.Windows.Forms.Label()
        Me.txtImageName = New System.Windows.Forms.Label()
        Me.cmbTransactionStatus = New System.Windows.Forms.ComboBox()
        Me.lblTransactionStatus = New System.Windows.Forms.Label()
        Me.lblRoutingStatus = New System.Windows.Forms.Label()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.cmbDowntimeStatus = New System.Windows.Forms.ComboBox()
        Me.lblDowntimeStatus = New System.Windows.Forms.Label()
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
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.btnBrowse = New PinkieControls.ButtonXP()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.pnlImage = New System.Windows.Forms.Panel()
        Me.lblPic = New System.Windows.Forms.Label()
        Me.dgvPic = New System.Windows.Forms.DataGridView()
        Me.ColIsSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblActivityLogs = New System.Windows.Forms.Label()
        Me.pnlApprovers = New System.Windows.Forms.Panel()
        Me.lblApproverId3 = New System.Windows.Forms.Label()
        Me.lblApproverId2 = New System.Windows.Forms.Label()
        Me.lblApproverId1 = New System.Windows.Forms.Label()
        Me.lblApproverStatus3 = New System.Windows.Forms.Label()
        Me.cmbApproverStatus3 = New System.Windows.Forms.ComboBox()
        Me.lblApproverStatus2 = New System.Windows.Forms.Label()
        Me.cmbApproverStatus2 = New System.Windows.Forms.ComboBox()
        Me.lblApproverStatus1 = New System.Windows.Forms.Label()
        Me.cmbApproverStatus1 = New System.Windows.Forms.ComboBox()
        Me.cmbApproverName1 = New SergeUtils.EasyCompletionComboBox()
        Me.cmbApproverName2 = New SergeUtils.EasyCompletionComboBox()
        Me.cmbApproverName3 = New SergeUtils.EasyCompletionComboBox()
        Me.txtApproverItem1 = New System.Windows.Forms.Label()
        Me.txtApproverDateApproved1 = New System.Windows.Forms.Label()
        Me.lblApproverDateApproved1 = New System.Windows.Forms.Label()
        Me.lblApproverRemarks1 = New System.Windows.Forms.Label()
        Me.txtApproverRemarks1 = New System.Windows.Forms.TextBox()
        Me.lblApproverItem1 = New System.Windows.Forms.Label()
        Me.lblApprovers = New System.Windows.Forms.Label()
        Me.txtApproverItem2 = New System.Windows.Forms.Label()
        Me.txtApproverDateApproved2 = New System.Windows.Forms.Label()
        Me.txtApproverItem3 = New System.Windows.Forms.Label()
        Me.lblApproverDateApproved2 = New System.Windows.Forms.Label()
        Me.lblApproverDateApproved3 = New System.Windows.Forms.Label()
        Me.lblApproverRemarks2 = New System.Windows.Forms.Label()
        Me.txtApproverRemarks2 = New System.Windows.Forms.TextBox()
        Me.lblApproverItem2 = New System.Windows.Forms.Label()
        Me.lblApproverRemarks3 = New System.Windows.Forms.Label()
        Me.txtApproverRemarks3 = New System.Windows.Forms.TextBox()
        Me.txtApproverDateApproved3 = New System.Windows.Forms.Label()
        Me.lblApproverItem3 = New System.Windows.Forms.Label()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.ColTrxDetailId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTrxId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTrxDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColUserIdLog = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColShiftId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTrxFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTrxTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColElapsedTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtRoutingStatus = New System.Windows.Forms.Label()
        Me.opdTrxDetail = New System.Windows.Forms.OpenFileDialog()
        Me.cmbMachineName = New SergeUtils.EasyCompletionComboBox()
        Me.lblRootCause = New System.Windows.Forms.Label()
        Me.txtRootCause = New System.Windows.Forms.TextBox()
        Me.lblJigName = New System.Windows.Forms.Label()
        Me.cmbJigName = New SergeUtils.EasyCompletionComboBox()
        Me.cmbArea = New SergeUtils.EasyCompletionComboBox()
        Me.lblDowntimeSubStatus = New System.Windows.Forms.Label()
        Me.cmbDowntimeSubStatus = New System.Windows.Forms.ComboBox()
        Me.cmbMachinePart = New SergeUtils.EasyCompletionComboBox()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.txtRuntimeAccumulated.Location = New System.Drawing.Point(870, 179)
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
        Me.lblRuntimeAccumulated.Location = New System.Drawing.Point(771, 179)
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
        Me.txtDowntimeAccumulated.Location = New System.Drawing.Point(1169, 179)
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
        Me.lblDowntimeAccumulated.Location = New System.Drawing.Point(1050, 179)
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
        Me.txtTransactionDate.Location = New System.Drawing.Point(518, 78)
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
        Me.lblTransactionDate.Location = New System.Drawing.Point(389, 78)
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
        Me.txtTransactionId.Location = New System.Drawing.Point(518, 52)
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
        Me.lblTransactionId.Location = New System.Drawing.Point(389, 52)
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
        Me.txtImageName.Location = New System.Drawing.Point(771, 497)
        Me.txtImageName.Name = "txtImageName"
        Me.txtImageName.Size = New System.Drawing.Size(280, 24)
        Me.txtImageName.TabIndex = 245
        Me.txtImageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtImageName.UseCompatibleTextRendering = True
        '
        'cmbTransactionStatus
        '
        Me.cmbTransactionStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTransactionStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTransactionStatus.DisplayMember = "TrxStatusName"
        Me.cmbTransactionStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransactionStatus.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTransactionStatus.Location = New System.Drawing.Point(518, 26)
        Me.cmbTransactionStatus.Name = "cmbTransactionStatus"
        Me.cmbTransactionStatus.Size = New System.Drawing.Size(250, 24)
        Me.cmbTransactionStatus.TabIndex = 0
        Me.cmbTransactionStatus.TabStop = False
        Me.cmbTransactionStatus.ValueMember = "TrxStatusId"
        '
        'lblTransactionStatus
        '
        Me.lblTransactionStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTransactionStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblTransactionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransactionStatus.ForeColor = System.Drawing.Color.Black
        Me.lblTransactionStatus.Location = New System.Drawing.Point(389, 26)
        Me.lblTransactionStatus.Name = "lblTransactionStatus"
        Me.lblTransactionStatus.Size = New System.Drawing.Size(130, 24)
        Me.lblTransactionStatus.TabIndex = 211
        Me.lblTransactionStatus.Text = " Transaction Status"
        Me.lblTransactionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRoutingStatus
        '
        Me.lblRoutingStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRoutingStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblRoutingStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRoutingStatus.ForeColor = System.Drawing.Color.Black
        Me.lblRoutingStatus.Location = New System.Drawing.Point(389, 0)
        Me.lblRoutingStatus.Name = "lblRoutingStatus"
        Me.lblRoutingStatus.Size = New System.Drawing.Size(130, 24)
        Me.lblRoutingStatus.TabIndex = 213
        Me.lblRoutingStatus.Text = " Routing Status"
        Me.lblRoutingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachineName
        '
        Me.lblMachineName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMachineName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMachineName.ForeColor = System.Drawing.Color.Black
        Me.lblMachineName.Location = New System.Drawing.Point(389, 104)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Size = New System.Drawing.Size(130, 24)
        Me.lblMachineName.TabIndex = 220
        Me.lblMachineName.Text = " Machine Name"
        Me.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblArea
        '
        Me.lblArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblArea.BackColor = System.Drawing.SystemColors.Control
        Me.lblArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblArea.ForeColor = System.Drawing.Color.Black
        Me.lblArea.Location = New System.Drawing.Point(389, 156)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(130, 24)
        Me.lblArea.TabIndex = 221
        Me.lblArea.Text = " Area"
        Me.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDowntimeStatus
        '
        Me.cmbDowntimeStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDowntimeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDowntimeStatus.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDowntimeStatus.FormattingEnabled = True
        Me.cmbDowntimeStatus.Location = New System.Drawing.Point(518, 208)
        Me.cmbDowntimeStatus.Name = "cmbDowntimeStatus"
        Me.cmbDowntimeStatus.Size = New System.Drawing.Size(250, 24)
        Me.cmbDowntimeStatus.TabIndex = 4
        '
        'lblDowntimeStatus
        '
        Me.lblDowntimeStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDowntimeStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblDowntimeStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDowntimeStatus.ForeColor = System.Drawing.Color.Black
        Me.lblDowntimeStatus.Location = New System.Drawing.Point(389, 208)
        Me.lblDowntimeStatus.Name = "lblDowntimeStatus"
        Me.lblDowntimeStatus.Size = New System.Drawing.Size(130, 24)
        Me.lblDowntimeStatus.TabIndex = 225
        Me.lblDowntimeStatus.Text = " Downtime Status"
        Me.lblDowntimeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachinePart
        '
        Me.lblMachinePart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMachinePart.BackColor = System.Drawing.SystemColors.Control
        Me.lblMachinePart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMachinePart.ForeColor = System.Drawing.Color.Black
        Me.lblMachinePart.Location = New System.Drawing.Point(389, 182)
        Me.lblMachinePart.Name = "lblMachinePart"
        Me.lblMachinePart.Size = New System.Drawing.Size(130, 24)
        Me.lblMachinePart.TabIndex = 224
        Me.lblMachinePart.Text = " Machine Parts"
        Me.lblMachinePart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProblem
        '
        Me.txtProblem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProblem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProblem.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtProblem.Location = New System.Drawing.Point(389, 283)
        Me.txtProblem.Multiline = True
        Me.txtProblem.Name = "txtProblem"
        Me.txtProblem.Size = New System.Drawing.Size(379, 54)
        Me.txtProblem.TabIndex = 6
        '
        'lblProblem
        '
        Me.lblProblem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProblem.BackColor = System.Drawing.SystemColors.Control
        Me.lblProblem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProblem.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProblem.ForeColor = System.Drawing.Color.Black
        Me.lblProblem.Location = New System.Drawing.Point(389, 260)
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
        Me.txtActionTaken.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtActionTaken.Location = New System.Drawing.Point(389, 441)
        Me.txtActionTaken.Multiline = True
        Me.txtActionTaken.Name = "txtActionTaken"
        Me.txtActionTaken.Size = New System.Drawing.Size(379, 54)
        Me.txtActionTaken.TabIndex = 8
        '
        'lblActionTaken
        '
        Me.lblActionTaken.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActionTaken.BackColor = System.Drawing.SystemColors.Control
        Me.lblActionTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActionTaken.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActionTaken.ForeColor = System.Drawing.Color.Black
        Me.lblActionTaken.Location = New System.Drawing.Point(389, 418)
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
        Me.lblPartsReplaced.Location = New System.Drawing.Point(389, 497)
        Me.lblPartsReplaced.Name = "lblPartsReplaced"
        Me.lblPartsReplaced.Size = New System.Drawing.Size(130, 24)
        Me.lblPartsReplaced.TabIndex = 231
        Me.lblPartsReplaced.Text = " Parts Replaced"
        Me.lblPartsReplaced.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartsReplaced
        '
        Me.txtPartsReplaced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartsReplaced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartsReplaced.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartsReplaced.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtPartsReplaced.Location = New System.Drawing.Point(518, 497)
        Me.txtPartsReplaced.Name = "txtPartsReplaced"
        Me.txtPartsReplaced.Size = New System.Drawing.Size(250, 24)
        Me.txtPartsReplaced.TabIndex = 9
        '
        'txtPartNo
        '
        Me.txtPartNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNo.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartNo.Location = New System.Drawing.Point(518, 523)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(250, 24)
        Me.txtPartNo.TabIndex = 10
        '
        'lblPartNo
        '
        Me.lblPartNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPartNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartNo.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNo.ForeColor = System.Drawing.Color.Black
        Me.lblPartNo.Location = New System.Drawing.Point(389, 523)
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
        Me.lblJoNumber.Location = New System.Drawing.Point(389, 549)
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
        Me.txtJoNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJoNumber.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJoNumber.Location = New System.Drawing.Point(518, 549)
        Me.txtJoNumber.MaxLength = 15
        Me.txtJoNumber.Name = "txtJoNumber"
        Me.txtJoNumber.Size = New System.Drawing.Size(250, 24)
        Me.txtJoNumber.TabIndex = 11
        '
        'lblJoRequestor
        '
        Me.lblJoRequestor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblJoRequestor.BackColor = System.Drawing.SystemColors.Control
        Me.lblJoRequestor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJoRequestor.ForeColor = System.Drawing.Color.Black
        Me.lblJoRequestor.Location = New System.Drawing.Point(389, 575)
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
        Me.txtJoRequestor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJoRequestor.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJoRequestor.Location = New System.Drawing.Point(518, 575)
        Me.txtJoRequestor.Name = "txtJoRequestor"
        Me.txtJoRequestor.Size = New System.Drawing.Size(250, 24)
        Me.txtJoRequestor.TabIndex = 12
        '
        'btnRemoveRow
        '
        Me.btnRemoveRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemoveRow.DefaultScheme = False
        Me.btnRemoveRow.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemoveRow.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnRemoveRow.Hint = "Delete selected activity log"
        Me.btnRemoveRow.Location = New System.Drawing.Point(1222, 2)
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
        Me.btnAddRow.Hint = "Add activity log"
        Me.btnAddRow.Location = New System.Drawing.Point(1119, 2)
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
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(1230, 569)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(95, 30)
        Me.btnClose.TabIndex = 253
        Me.btnClose.TabStop = False
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
        Me.btnDelete.Location = New System.Drawing.Point(1131, 569)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(95, 30)
        Me.btnDelete.TabIndex = 252
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.DefaultScheme = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnCancel.Hint = "Cancel changes"
        Me.btnCancel.Location = New System.Drawing.Point(1032, 569)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(95, 30)
        Me.btnCancel.TabIndex = 251
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.DefaultScheme = False
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnSave.Hint = "Save record"
        Me.btnSave.Location = New System.Drawing.Point(933, 569)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(95, 30)
        Me.btnSave.TabIndex = 250
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "Save"
        '
        'lblImageAttachment
        '
        Me.lblImageAttachment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImageAttachment.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImageAttachment.ForeColor = System.Drawing.Color.Black
        Me.lblImageAttachment.Location = New System.Drawing.Point(771, 208)
        Me.lblImageAttachment.Name = "lblImageAttachment"
        Me.lblImageAttachment.Size = New System.Drawing.Size(280, 24)
        Me.lblImageAttachment.TabIndex = 243
        Me.lblImageAttachment.Text = " Image"
        Me.lblImageAttachment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.picImage.Location = New System.Drawing.Point(4, 2)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(270, 230)
        Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage.TabIndex = 0
        Me.picImage.TabStop = False
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnBrowse.DefaultScheme = False
        Me.btnBrowse.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnBrowse.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnBrowse.Hint = "Browse for image attachment"
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
        Me.btnRemove.Hint = "Remove attached image"
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
        Me.pnlImage.Controls.Add(Me.picImage)
        Me.pnlImage.Location = New System.Drawing.Point(771, 231)
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
        Me.lblPic.Location = New System.Drawing.Point(1053, 208)
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
        Me.dgvPic.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIsSelected, Me.ColUserId, Me.ColUserName})
        Me.dgvPic.Location = New System.Drawing.Point(1053, 231)
        Me.dgvPic.MultiSelect = False
        Me.dgvPic.Name = "dgvPic"
        Me.dgvPic.RowHeadersVisible = False
        Me.dgvPic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPic.Size = New System.Drawing.Size(272, 290)
        Me.dgvPic.TabIndex = 11
        Me.dgvPic.TabStop = False
        '
        'ColIsSelected
        '
        Me.ColIsSelected.HeaderText = "*"
        Me.ColIsSelected.Name = "ColIsSelected"
        Me.ColIsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColIsSelected.Width = 25
        '
        'ColUserId
        '
        Me.ColUserId.DataPropertyName = "UserId"
        Me.ColUserId.HeaderText = "UserId"
        Me.ColUserId.Name = "ColUserId"
        Me.ColUserId.ReadOnly = True
        Me.ColUserId.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColUserId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColUserId.Visible = False
        '
        'ColUserName
        '
        Me.ColUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColUserName.DataPropertyName = "UserName"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColUserName.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColUserName.HeaderText = "NickName"
        Me.ColUserName.Name = "ColUserName"
        Me.ColUserName.ReadOnly = True
        Me.ColUserName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'lblActivityLogs
        '
        Me.lblActivityLogs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActivityLogs.BackColor = System.Drawing.SystemColors.Control
        Me.lblActivityLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActivityLogs.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivityLogs.ForeColor = System.Drawing.Color.Black
        Me.lblActivityLogs.Location = New System.Drawing.Point(771, 0)
        Me.lblActivityLogs.Name = "lblActivityLogs"
        Me.lblActivityLogs.Size = New System.Drawing.Size(554, 29)
        Me.lblActivityLogs.TabIndex = 279
        Me.lblActivityLogs.Text = " Activity Logs"
        Me.lblActivityLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlApprovers
        '
        Me.pnlApprovers.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlApprovers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlApprovers.Controls.Add(Me.lblApproverId3)
        Me.pnlApprovers.Controls.Add(Me.lblApproverId2)
        Me.pnlApprovers.Controls.Add(Me.lblApproverId1)
        Me.pnlApprovers.Controls.Add(Me.lblApproverStatus3)
        Me.pnlApprovers.Controls.Add(Me.cmbApproverStatus3)
        Me.pnlApprovers.Controls.Add(Me.lblApproverStatus2)
        Me.pnlApprovers.Controls.Add(Me.cmbApproverStatus2)
        Me.pnlApprovers.Controls.Add(Me.lblApproverStatus1)
        Me.pnlApprovers.Controls.Add(Me.cmbApproverStatus1)
        Me.pnlApprovers.Controls.Add(Me.cmbApproverName1)
        Me.pnlApprovers.Controls.Add(Me.cmbApproverName2)
        Me.pnlApprovers.Controls.Add(Me.cmbApproverName3)
        Me.pnlApprovers.Controls.Add(Me.txtApproverItem1)
        Me.pnlApprovers.Controls.Add(Me.txtApproverDateApproved1)
        Me.pnlApprovers.Controls.Add(Me.lblApproverDateApproved1)
        Me.pnlApprovers.Controls.Add(Me.lblApproverRemarks1)
        Me.pnlApprovers.Controls.Add(Me.txtApproverRemarks1)
        Me.pnlApprovers.Controls.Add(Me.lblApproverItem1)
        Me.pnlApprovers.Controls.Add(Me.lblApprovers)
        Me.pnlApprovers.Controls.Add(Me.txtApproverItem2)
        Me.pnlApprovers.Controls.Add(Me.txtApproverDateApproved2)
        Me.pnlApprovers.Controls.Add(Me.txtApproverItem3)
        Me.pnlApprovers.Controls.Add(Me.lblApproverDateApproved2)
        Me.pnlApprovers.Controls.Add(Me.lblApproverDateApproved3)
        Me.pnlApprovers.Controls.Add(Me.lblApproverRemarks2)
        Me.pnlApprovers.Controls.Add(Me.txtApproverRemarks2)
        Me.pnlApprovers.Controls.Add(Me.lblApproverItem2)
        Me.pnlApprovers.Controls.Add(Me.lblApproverRemarks3)
        Me.pnlApprovers.Controls.Add(Me.txtApproverRemarks3)
        Me.pnlApprovers.Controls.Add(Me.txtApproverDateApproved3)
        Me.pnlApprovers.Controls.Add(Me.lblApproverItem3)
        Me.pnlApprovers.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlApprovers.Location = New System.Drawing.Point(0, 0)
        Me.pnlApprovers.Name = "pnlApprovers"
        Me.pnlApprovers.Size = New System.Drawing.Size(387, 601)
        Me.pnlApprovers.TabIndex = 281
        '
        'lblApproverId3
        '
        Me.lblApproverId3.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverId3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverId3.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverId3.ForeColor = System.Drawing.Color.Black
        Me.lblApproverId3.Location = New System.Drawing.Point(3, 81)
        Me.lblApproverId3.Name = "lblApproverId3"
        Me.lblApproverId3.Size = New System.Drawing.Size(91, 24)
        Me.lblApproverId3.TabIndex = 276
        Me.lblApproverId3.Text = " Approver 3"
        Me.lblApproverId3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApproverId2
        '
        Me.lblApproverId2.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverId2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverId2.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverId2.ForeColor = System.Drawing.Color.Black
        Me.lblApproverId2.Location = New System.Drawing.Point(3, 260)
        Me.lblApproverId2.Name = "lblApproverId2"
        Me.lblApproverId2.Size = New System.Drawing.Size(91, 24)
        Me.lblApproverId2.TabIndex = 281
        Me.lblApproverId2.Text = " Approver 2"
        Me.lblApproverId2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApproverId1
        '
        Me.lblApproverId1.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverId1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverId1.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverId1.ForeColor = System.Drawing.Color.Black
        Me.lblApproverId1.Location = New System.Drawing.Point(3, 439)
        Me.lblApproverId1.Name = "lblApproverId1"
        Me.lblApproverId1.Size = New System.Drawing.Size(91, 24)
        Me.lblApproverId1.TabIndex = 293
        Me.lblApproverId1.Text = " Approver 1"
        Me.lblApproverId1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApproverStatus3
        '
        Me.lblApproverStatus3.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverStatus3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverStatus3.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverStatus3.ForeColor = System.Drawing.Color.Black
        Me.lblApproverStatus3.Location = New System.Drawing.Point(3, 29)
        Me.lblApproverStatus3.Name = "lblApproverStatus3"
        Me.lblApproverStatus3.Size = New System.Drawing.Size(91, 24)
        Me.lblApproverStatus3.TabIndex = 545
        Me.lblApproverStatus3.Text = " Status"
        Me.lblApproverStatus3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbApproverStatus3
        '
        Me.cmbApproverStatus3.DisplayMember = "Name"
        Me.cmbApproverStatus3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbApproverStatus3.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.cmbApproverStatus3.FormattingEnabled = True
        Me.cmbApproverStatus3.Location = New System.Drawing.Point(93, 29)
        Me.cmbApproverStatus3.Name = "cmbApproverStatus3"
        Me.cmbApproverStatus3.Size = New System.Drawing.Size(289, 24)
        Me.cmbApproverStatus3.TabIndex = 544
        Me.cmbApproverStatus3.ValueMember = "Id"
        '
        'lblApproverStatus2
        '
        Me.lblApproverStatus2.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverStatus2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverStatus2.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverStatus2.ForeColor = System.Drawing.Color.Black
        Me.lblApproverStatus2.Location = New System.Drawing.Point(3, 208)
        Me.lblApproverStatus2.Name = "lblApproverStatus2"
        Me.lblApproverStatus2.Size = New System.Drawing.Size(91, 24)
        Me.lblApproverStatus2.TabIndex = 543
        Me.lblApproverStatus2.Text = " Status"
        Me.lblApproverStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbApproverStatus2
        '
        Me.cmbApproverStatus2.DisplayMember = "Name"
        Me.cmbApproverStatus2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbApproverStatus2.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.cmbApproverStatus2.FormattingEnabled = True
        Me.cmbApproverStatus2.Location = New System.Drawing.Point(93, 208)
        Me.cmbApproverStatus2.Name = "cmbApproverStatus2"
        Me.cmbApproverStatus2.Size = New System.Drawing.Size(289, 24)
        Me.cmbApproverStatus2.TabIndex = 542
        Me.cmbApproverStatus2.ValueMember = "Id"
        '
        'lblApproverStatus1
        '
        Me.lblApproverStatus1.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverStatus1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverStatus1.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverStatus1.ForeColor = System.Drawing.Color.Black
        Me.lblApproverStatus1.Location = New System.Drawing.Point(3, 387)
        Me.lblApproverStatus1.Name = "lblApproverStatus1"
        Me.lblApproverStatus1.Size = New System.Drawing.Size(91, 24)
        Me.lblApproverStatus1.TabIndex = 541
        Me.lblApproverStatus1.Text = " Status"
        Me.lblApproverStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbApproverStatus1
        '
        Me.cmbApproverStatus1.DisplayMember = "Name"
        Me.cmbApproverStatus1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbApproverStatus1.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.cmbApproverStatus1.FormattingEnabled = True
        Me.cmbApproverStatus1.Location = New System.Drawing.Point(93, 387)
        Me.cmbApproverStatus1.Name = "cmbApproverStatus1"
        Me.cmbApproverStatus1.Size = New System.Drawing.Size(289, 24)
        Me.cmbApproverStatus1.TabIndex = 540
        Me.cmbApproverStatus1.ValueMember = "Id"
        '
        'cmbApproverName1
        '
        Me.cmbApproverName1.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.cmbApproverName1.FormattingEnabled = True
        Me.cmbApproverName1.Location = New System.Drawing.Point(93, 439)
        Me.cmbApproverName1.Name = "cmbApproverName1"
        Me.cmbApproverName1.Size = New System.Drawing.Size(289, 24)
        Me.cmbApproverName1.TabIndex = 4
        Me.cmbApproverName1.TabStop = False
        '
        'cmbApproverName2
        '
        Me.cmbApproverName2.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.cmbApproverName2.FormattingEnabled = True
        Me.cmbApproverName2.Location = New System.Drawing.Point(93, 260)
        Me.cmbApproverName2.Name = "cmbApproverName2"
        Me.cmbApproverName2.Size = New System.Drawing.Size(289, 24)
        Me.cmbApproverName2.TabIndex = 2
        Me.cmbApproverName2.TabStop = False
        '
        'cmbApproverName3
        '
        Me.cmbApproverName3.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.cmbApproverName3.FormattingEnabled = True
        Me.cmbApproverName3.Location = New System.Drawing.Point(93, 81)
        Me.cmbApproverName3.Name = "cmbApproverName3"
        Me.cmbApproverName3.Size = New System.Drawing.Size(289, 24)
        Me.cmbApproverName3.TabIndex = 0
        Me.cmbApproverName3.TabStop = False
        '
        'txtApproverItem1
        '
        Me.txtApproverItem1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApproverItem1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApproverItem1.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtApproverItem1.ForeColor = System.Drawing.Color.Black
        Me.txtApproverItem1.Location = New System.Drawing.Point(93, 465)
        Me.txtApproverItem1.Name = "txtApproverItem1"
        Me.txtApproverItem1.Size = New System.Drawing.Size(289, 24)
        Me.txtApproverItem1.TabIndex = 300
        Me.txtApproverItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApproverItem1.UseCompatibleTextRendering = True
        '
        'txtApproverDateApproved1
        '
        Me.txtApproverDateApproved1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApproverDateApproved1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApproverDateApproved1.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtApproverDateApproved1.ForeColor = System.Drawing.Color.Black
        Me.txtApproverDateApproved1.Location = New System.Drawing.Point(93, 413)
        Me.txtApproverDateApproved1.Name = "txtApproverDateApproved1"
        Me.txtApproverDateApproved1.Size = New System.Drawing.Size(289, 24)
        Me.txtApproverDateApproved1.TabIndex = 298
        Me.txtApproverDateApproved1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApproverDateApproved1.UseCompatibleTextRendering = True
        '
        'lblApproverDateApproved1
        '
        Me.lblApproverDateApproved1.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverDateApproved1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverDateApproved1.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverDateApproved1.ForeColor = System.Drawing.Color.Black
        Me.lblApproverDateApproved1.Location = New System.Drawing.Point(3, 413)
        Me.lblApproverDateApproved1.Name = "lblApproverDateApproved1"
        Me.lblApproverDateApproved1.Size = New System.Drawing.Size(91, 24)
        Me.lblApproverDateApproved1.TabIndex = 297
        Me.lblApproverDateApproved1.Text = " Date"
        Me.lblApproverDateApproved1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApproverRemarks1
        '
        Me.lblApproverRemarks1.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverRemarks1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverRemarks1.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverRemarks1.ForeColor = System.Drawing.Color.Black
        Me.lblApproverRemarks1.Location = New System.Drawing.Point(3, 491)
        Me.lblApproverRemarks1.Name = "lblApproverRemarks1"
        Me.lblApproverRemarks1.Size = New System.Drawing.Size(379, 24)
        Me.lblApproverRemarks1.TabIndex = 296
        Me.lblApproverRemarks1.Text = " Remarks"
        Me.lblApproverRemarks1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApproverRemarks1
        '
        Me.txtApproverRemarks1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApproverRemarks1.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtApproverRemarks1.Location = New System.Drawing.Point(3, 514)
        Me.txtApproverRemarks1.Multiline = True
        Me.txtApproverRemarks1.Name = "txtApproverRemarks1"
        Me.txtApproverRemarks1.Size = New System.Drawing.Size(379, 50)
        Me.txtApproverRemarks1.TabIndex = 5
        Me.txtApproverRemarks1.TabStop = False
        '
        'lblApproverItem1
        '
        Me.lblApproverItem1.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverItem1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverItem1.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverItem1.ForeColor = System.Drawing.Color.Black
        Me.lblApproverItem1.Location = New System.Drawing.Point(3, 465)
        Me.lblApproverItem1.Name = "lblApproverItem1"
        Me.lblApproverItem1.Size = New System.Drawing.Size(91, 24)
        Me.lblApproverItem1.TabIndex = 294
        Me.lblApproverItem1.Text = " Position"
        Me.lblApproverItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'txtApproverItem2
        '
        Me.txtApproverItem2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApproverItem2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApproverItem2.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtApproverItem2.ForeColor = System.Drawing.Color.Black
        Me.txtApproverItem2.Location = New System.Drawing.Point(93, 286)
        Me.txtApproverItem2.Name = "txtApproverItem2"
        Me.txtApproverItem2.Size = New System.Drawing.Size(289, 24)
        Me.txtApproverItem2.TabIndex = 291
        Me.txtApproverItem2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApproverItem2.UseCompatibleTextRendering = True
        '
        'txtApproverDateApproved2
        '
        Me.txtApproverDateApproved2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApproverDateApproved2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApproverDateApproved2.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtApproverDateApproved2.ForeColor = System.Drawing.Color.Black
        Me.txtApproverDateApproved2.Location = New System.Drawing.Point(93, 234)
        Me.txtApproverDateApproved2.Name = "txtApproverDateApproved2"
        Me.txtApproverDateApproved2.Size = New System.Drawing.Size(289, 24)
        Me.txtApproverDateApproved2.TabIndex = 289
        Me.txtApproverDateApproved2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApproverDateApproved2.UseCompatibleTextRendering = True
        '
        'txtApproverItem3
        '
        Me.txtApproverItem3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApproverItem3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApproverItem3.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtApproverItem3.ForeColor = System.Drawing.Color.Black
        Me.txtApproverItem3.Location = New System.Drawing.Point(93, 107)
        Me.txtApproverItem3.Name = "txtApproverItem3"
        Me.txtApproverItem3.Size = New System.Drawing.Size(289, 24)
        Me.txtApproverItem3.TabIndex = 288
        Me.txtApproverItem3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApproverItem3.UseCompatibleTextRendering = True
        '
        'lblApproverDateApproved2
        '
        Me.lblApproverDateApproved2.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverDateApproved2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverDateApproved2.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverDateApproved2.ForeColor = System.Drawing.Color.Black
        Me.lblApproverDateApproved2.Location = New System.Drawing.Point(3, 234)
        Me.lblApproverDateApproved2.Name = "lblApproverDateApproved2"
        Me.lblApproverDateApproved2.Size = New System.Drawing.Size(91, 24)
        Me.lblApproverDateApproved2.TabIndex = 286
        Me.lblApproverDateApproved2.Text = " Date"
        Me.lblApproverDateApproved2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApproverDateApproved3
        '
        Me.lblApproverDateApproved3.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverDateApproved3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverDateApproved3.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverDateApproved3.ForeColor = System.Drawing.Color.Black
        Me.lblApproverDateApproved3.Location = New System.Drawing.Point(3, 55)
        Me.lblApproverDateApproved3.Name = "lblApproverDateApproved3"
        Me.lblApproverDateApproved3.Size = New System.Drawing.Size(91, 24)
        Me.lblApproverDateApproved3.TabIndex = 285
        Me.lblApproverDateApproved3.Text = " Date"
        Me.lblApproverDateApproved3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApproverRemarks2
        '
        Me.lblApproverRemarks2.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverRemarks2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverRemarks2.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverRemarks2.ForeColor = System.Drawing.Color.Black
        Me.lblApproverRemarks2.Location = New System.Drawing.Point(3, 312)
        Me.lblApproverRemarks2.Name = "lblApproverRemarks2"
        Me.lblApproverRemarks2.Size = New System.Drawing.Size(379, 24)
        Me.lblApproverRemarks2.TabIndex = 284
        Me.lblApproverRemarks2.Text = " Remarks"
        Me.lblApproverRemarks2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApproverRemarks2
        '
        Me.txtApproverRemarks2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApproverRemarks2.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtApproverRemarks2.Location = New System.Drawing.Point(3, 335)
        Me.txtApproverRemarks2.Multiline = True
        Me.txtApproverRemarks2.Name = "txtApproverRemarks2"
        Me.txtApproverRemarks2.Size = New System.Drawing.Size(379, 50)
        Me.txtApproverRemarks2.TabIndex = 3
        Me.txtApproverRemarks2.TabStop = False
        '
        'lblApproverItem2
        '
        Me.lblApproverItem2.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverItem2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverItem2.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverItem2.ForeColor = System.Drawing.Color.Black
        Me.lblApproverItem2.Location = New System.Drawing.Point(3, 286)
        Me.lblApproverItem2.Name = "lblApproverItem2"
        Me.lblApproverItem2.Size = New System.Drawing.Size(91, 24)
        Me.lblApproverItem2.TabIndex = 282
        Me.lblApproverItem2.Text = " Position"
        Me.lblApproverItem2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApproverRemarks3
        '
        Me.lblApproverRemarks3.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverRemarks3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverRemarks3.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverRemarks3.ForeColor = System.Drawing.Color.Black
        Me.lblApproverRemarks3.Location = New System.Drawing.Point(3, 133)
        Me.lblApproverRemarks3.Name = "lblApproverRemarks3"
        Me.lblApproverRemarks3.Size = New System.Drawing.Size(379, 24)
        Me.lblApproverRemarks3.TabIndex = 280
        Me.lblApproverRemarks3.Text = " Remarks"
        Me.lblApproverRemarks3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApproverRemarks3
        '
        Me.txtApproverRemarks3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApproverRemarks3.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtApproverRemarks3.Location = New System.Drawing.Point(3, 156)
        Me.txtApproverRemarks3.Multiline = True
        Me.txtApproverRemarks3.Name = "txtApproverRemarks3"
        Me.txtApproverRemarks3.Size = New System.Drawing.Size(379, 50)
        Me.txtApproverRemarks3.TabIndex = 1
        Me.txtApproverRemarks3.TabStop = False
        '
        'txtApproverDateApproved3
        '
        Me.txtApproverDateApproved3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApproverDateApproved3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApproverDateApproved3.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtApproverDateApproved3.ForeColor = System.Drawing.Color.Black
        Me.txtApproverDateApproved3.Location = New System.Drawing.Point(93, 55)
        Me.txtApproverDateApproved3.Name = "txtApproverDateApproved3"
        Me.txtApproverDateApproved3.Size = New System.Drawing.Size(289, 24)
        Me.txtApproverDateApproved3.TabIndex = 278
        Me.txtApproverDateApproved3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApproverDateApproved3.UseCompatibleTextRendering = True
        '
        'lblApproverItem3
        '
        Me.lblApproverItem3.BackColor = System.Drawing.SystemColors.Control
        Me.lblApproverItem3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApproverItem3.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproverItem3.ForeColor = System.Drawing.Color.Black
        Me.lblApproverItem3.Location = New System.Drawing.Point(3, 107)
        Me.lblApproverItem3.Name = "lblApproverItem3"
        Me.lblApproverItem3.Size = New System.Drawing.Size(91, 24)
        Me.lblApproverItem3.TabIndex = 277
        Me.lblApproverItem3.Text = " Position"
        Me.lblApproverItem3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.AllowUserToResizeColumns = False
        Me.dgvDetail.AllowUserToResizeRows = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.5!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDetail.ColumnHeadersHeight = 22
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColTrxDetailId, Me.ColTrxId, Me.ColTrxDate, Me.ColUserIdLog, Me.ColShiftId, Me.ColTrxFrom, Me.ColTrxTo, Me.ColElapsedTime})
        Me.dgvDetail.Location = New System.Drawing.Point(771, 28)
        Me.dgvDetail.MultiSelect = False
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.ReadOnly = True
        Me.dgvDetail.RowHeadersVisible = False
        Me.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetail.Size = New System.Drawing.Size(554, 152)
        Me.dgvDetail.TabIndex = 295
        Me.dgvDetail.TabStop = False
        '
        'ColTrxDetailId
        '
        Me.ColTrxDetailId.DataPropertyName = "TrxDetailId"
        Me.ColTrxDetailId.HeaderText = "TrxDetailId"
        Me.ColTrxDetailId.Name = "ColTrxDetailId"
        Me.ColTrxDetailId.ReadOnly = True
        Me.ColTrxDetailId.Visible = False
        '
        'ColTrxId
        '
        Me.ColTrxId.DataPropertyName = "TrxId"
        Me.ColTrxId.HeaderText = "TrxId"
        Me.ColTrxId.Name = "ColTrxId"
        Me.ColTrxId.ReadOnly = True
        Me.ColTrxId.Visible = False
        '
        'ColTrxDate
        '
        Me.ColTrxDate.DataPropertyName = "TrxDate"
        Me.ColTrxDate.HeaderText = "TrxDate"
        Me.ColTrxDate.Name = "ColTrxDate"
        Me.ColTrxDate.ReadOnly = True
        Me.ColTrxDate.Visible = False
        '
        'ColUserIdLog
        '
        Me.ColUserIdLog.DataPropertyName = "UserId"
        Me.ColUserIdLog.HeaderText = "UserId"
        Me.ColUserIdLog.Name = "ColUserIdLog"
        Me.ColUserIdLog.ReadOnly = True
        Me.ColUserIdLog.Visible = False
        '
        'ColShiftId
        '
        Me.ColShiftId.DataPropertyName = "ShiftId"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColShiftId.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColShiftId.HeaderText = "Shift"
        Me.ColShiftId.Name = "ColShiftId"
        Me.ColShiftId.ReadOnly = True
        Me.ColShiftId.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColShiftId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColShiftId.Width = 50
        '
        'ColTrxFrom
        '
        Me.ColTrxFrom.DataPropertyName = "TrxFrom"
        Me.ColTrxFrom.HeaderText = "From"
        Me.ColTrxFrom.Name = "ColTrxFrom"
        Me.ColTrxFrom.ReadOnly = True
        Me.ColTrxFrom.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColTrxFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColTrxFrom.Width = 150
        '
        'ColTrxTo
        '
        Me.ColTrxTo.DataPropertyName = "TrxTo"
        Me.ColTrxTo.HeaderText = "To"
        Me.ColTrxTo.Name = "ColTrxTo"
        Me.ColTrxTo.ReadOnly = True
        Me.ColTrxTo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColTrxTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColTrxTo.Width = 150
        '
        'ColElapsedTime
        '
        Me.ColElapsedTime.DataPropertyName = "ElapsedTime"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColElapsedTime.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColElapsedTime.HeaderText = "Minutes"
        Me.ColElapsedTime.Name = "ColElapsedTime"
        Me.ColElapsedTime.ReadOnly = True
        Me.ColElapsedTime.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColElapsedTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColElapsedTime.Width = 80
        '
        'txtRoutingStatus
        '
        Me.txtRoutingStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtRoutingStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRoutingStatus.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtRoutingStatus.ForeColor = System.Drawing.Color.Black
        Me.txtRoutingStatus.Location = New System.Drawing.Point(518, 0)
        Me.txtRoutingStatus.Name = "txtRoutingStatus"
        Me.txtRoutingStatus.Size = New System.Drawing.Size(250, 24)
        Me.txtRoutingStatus.TabIndex = 296
        Me.txtRoutingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtRoutingStatus.UseCompatibleTextRendering = True
        '
        'cmbMachineName
        '
        Me.cmbMachineName.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.cmbMachineName.FormattingEnabled = True
        Me.cmbMachineName.Location = New System.Drawing.Point(518, 104)
        Me.cmbMachineName.Name = "cmbMachineName"
        Me.cmbMachineName.Size = New System.Drawing.Size(250, 24)
        Me.cmbMachineName.TabIndex = 0
        '
        'lblRootCause
        '
        Me.lblRootCause.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRootCause.BackColor = System.Drawing.SystemColors.Control
        Me.lblRootCause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRootCause.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRootCause.ForeColor = System.Drawing.Color.Black
        Me.lblRootCause.Location = New System.Drawing.Point(389, 339)
        Me.lblRootCause.Name = "lblRootCause"
        Me.lblRootCause.Size = New System.Drawing.Size(379, 24)
        Me.lblRootCause.TabIndex = 544
        Me.lblRootCause.Text = " Root Cause"
        Me.lblRootCause.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRootCause
        '
        Me.txtRootCause.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRootCause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRootCause.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtRootCause.Location = New System.Drawing.Point(389, 362)
        Me.txtRootCause.Multiline = True
        Me.txtRootCause.Name = "txtRootCause"
        Me.txtRootCause.Size = New System.Drawing.Size(379, 54)
        Me.txtRootCause.TabIndex = 7
        '
        'lblJigName
        '
        Me.lblJigName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblJigName.BackColor = System.Drawing.SystemColors.Control
        Me.lblJigName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJigName.ForeColor = System.Drawing.Color.Black
        Me.lblJigName.Location = New System.Drawing.Point(389, 130)
        Me.lblJigName.Name = "lblJigName"
        Me.lblJigName.Size = New System.Drawing.Size(130, 24)
        Me.lblJigName.TabIndex = 547
        Me.lblJigName.Text = " Jig Name"
        Me.lblJigName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbJigName
        '
        Me.cmbJigName.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.cmbJigName.FormattingEnabled = True
        Me.cmbJigName.Location = New System.Drawing.Point(518, 130)
        Me.cmbJigName.Name = "cmbJigName"
        Me.cmbJigName.Size = New System.Drawing.Size(250, 24)
        Me.cmbJigName.TabIndex = 1
        '
        'cmbArea
        '
        Me.cmbArea.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(518, 156)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(250, 24)
        Me.cmbArea.TabIndex = 2
        '
        'lblDowntimeSubStatus
        '
        Me.lblDowntimeSubStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDowntimeSubStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblDowntimeSubStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDowntimeSubStatus.ForeColor = System.Drawing.Color.Black
        Me.lblDowntimeSubStatus.Location = New System.Drawing.Point(389, 234)
        Me.lblDowntimeSubStatus.Name = "lblDowntimeSubStatus"
        Me.lblDowntimeSubStatus.Size = New System.Drawing.Size(130, 24)
        Me.lblDowntimeSubStatus.TabIndex = 549
        Me.lblDowntimeSubStatus.Text = " Sub-Status"
        Me.lblDowntimeSubStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDowntimeSubStatus
        '
        Me.cmbDowntimeSubStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDowntimeSubStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDowntimeSubStatus.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDowntimeSubStatus.FormattingEnabled = True
        Me.cmbDowntimeSubStatus.Location = New System.Drawing.Point(518, 234)
        Me.cmbDowntimeSubStatus.Name = "cmbDowntimeSubStatus"
        Me.cmbDowntimeSubStatus.Size = New System.Drawing.Size(250, 24)
        Me.cmbDowntimeSubStatus.TabIndex = 5
        '
        'cmbMachinePart
        '
        Me.cmbMachinePart.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.cmbMachinePart.FormattingEnabled = True
        Me.cmbMachinePart.Location = New System.Drawing.Point(518, 182)
        Me.cmbMachinePart.Name = "cmbMachinePart"
        Me.cmbMachinePart.Size = New System.Drawing.Size(250, 24)
        Me.cmbMachinePart.TabIndex = 3
        '
        'frmMntTrxDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1330, 601)
        Me.Controls.Add(Me.lblPic)
        Me.Controls.Add(Me.lblMachinePart)
        Me.Controls.Add(Me.cmbMachinePart)
        Me.Controls.Add(Me.lblDowntimeSubStatus)
        Me.Controls.Add(Me.cmbDowntimeSubStatus)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.cmbArea)
        Me.Controls.Add(Me.lblJigName)
        Me.Controls.Add(Me.cmbJigName)
        Me.Controls.Add(Me.lblDowntimeStatus)
        Me.Controls.Add(Me.lblMachineName)
        Me.Controls.Add(Me.lblRootCause)
        Me.Controls.Add(Me.txtRootCause)
        Me.Controls.Add(Me.cmbMachineName)
        Me.Controls.Add(Me.txtRoutingStatus)
        Me.Controls.Add(Me.pnlApprovers)
        Me.Controls.Add(Me.btnRemoveRow)
        Me.Controls.Add(Me.btnAddRow)
        Me.Controls.Add(Me.lblActivityLogs)
        Me.Controls.Add(Me.txtRuntimeAccumulated)
        Me.Controls.Add(Me.lblRoutingStatus)
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
        Me.Controls.Add(Me.cmbDowntimeStatus)
        Me.Controls.Add(Me.txtDowntimeAccumulated)
        Me.Controls.Add(Me.lblDowntimeAccumulated)
        Me.Controls.Add(Me.lblRuntimeAccumulated)
        Me.Controls.Add(Me.lblTransactionStatus)
        Me.Controls.Add(Me.cmbTransactionStatus)
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
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmbTransactionStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblTransactionStatus As System.Windows.Forms.Label
    Friend WithEvents lblRoutingStatus As System.Windows.Forms.Label
    Friend WithEvents lblMachineName As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents cmbDowntimeStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblDowntimeStatus As System.Windows.Forms.Label
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
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Friend WithEvents btnBrowse As PinkieControls.ButtonXP
    Friend WithEvents btnRemove As PinkieControls.ButtonXP
    Friend WithEvents pnlImage As System.Windows.Forms.Panel
    Friend WithEvents lblPic As System.Windows.Forms.Label
    Friend WithEvents dgvPic As System.Windows.Forms.DataGridView
    Friend WithEvents lblActivityLogs As System.Windows.Forms.Label
    Friend WithEvents pnlApprovers As System.Windows.Forms.Panel
    Friend WithEvents txtApproverItem2 As System.Windows.Forms.Label
    Friend WithEvents txtApproverDateApproved2 As System.Windows.Forms.Label
    Friend WithEvents txtApproverItem3 As System.Windows.Forms.Label
    Friend WithEvents lblApproverDateApproved2 As System.Windows.Forms.Label
    Friend WithEvents lblApproverDateApproved3 As System.Windows.Forms.Label
    Friend WithEvents lblApproverRemarks2 As System.Windows.Forms.Label
    Friend WithEvents txtApproverRemarks2 As System.Windows.Forms.TextBox
    Friend WithEvents lblApproverItem2 As System.Windows.Forms.Label
    Friend WithEvents lblApproverId2 As System.Windows.Forms.Label
    Friend WithEvents lblApproverRemarks3 As System.Windows.Forms.Label
    Friend WithEvents txtApproverRemarks3 As System.Windows.Forms.TextBox
    Friend WithEvents txtApproverDateApproved3 As System.Windows.Forms.Label
    Friend WithEvents lblApproverItem3 As System.Windows.Forms.Label
    Friend WithEvents lblApproverId3 As System.Windows.Forms.Label
    Friend WithEvents lblApprovers As System.Windows.Forms.Label
    Friend WithEvents dgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents txtRoutingStatus As System.Windows.Forms.Label
    Friend WithEvents txtApproverItem1 As System.Windows.Forms.Label
    Friend WithEvents txtApproverDateApproved1 As System.Windows.Forms.Label
    Friend WithEvents lblApproverDateApproved1 As System.Windows.Forms.Label
    Friend WithEvents lblApproverRemarks1 As System.Windows.Forms.Label
    Friend WithEvents txtApproverRemarks1 As System.Windows.Forms.TextBox
    Friend WithEvents lblApproverItem1 As System.Windows.Forms.Label
    Friend WithEvents lblApproverId1 As System.Windows.Forms.Label
    Friend WithEvents cmbApproverName1 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cmbApproverName2 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cmbApproverName3 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents opdTrxDetail As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmbMachineName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblRootCause As System.Windows.Forms.Label
    Friend WithEvents txtRootCause As System.Windows.Forms.TextBox
    Friend WithEvents lblApproverStatus3 As System.Windows.Forms.Label
    Friend WithEvents cmbApproverStatus3 As System.Windows.Forms.ComboBox
    Friend WithEvents lblApproverStatus2 As System.Windows.Forms.Label
    Friend WithEvents cmbApproverStatus2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblApproverStatus1 As System.Windows.Forms.Label
    Friend WithEvents cmbApproverStatus1 As System.Windows.Forms.ComboBox
    Friend WithEvents ColIsSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTrxDetailId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTrxId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTrxDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUserIdLog As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColShiftId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTrxFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTrxTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColElapsedTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblJigName As System.Windows.Forms.Label
    Friend WithEvents cmbJigName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cmbArea As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblDowntimeSubStatus As System.Windows.Forms.Label
    Friend WithEvents cmbDowntimeSubStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMachinePart As SergeUtils.EasyCompletionComboBox
End Class
