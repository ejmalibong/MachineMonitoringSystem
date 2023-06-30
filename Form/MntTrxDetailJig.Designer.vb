<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MntTrxDetailJig
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtRuntimeAccumulated = New System.Windows.Forms.Label()
        Me.lblRuntimeAccumulated = New System.Windows.Forms.Label()
        Me.txtDowntimeAccumulated = New System.Windows.Forms.Label()
        Me.lblDowntimeAccumulated = New System.Windows.Forms.Label()
        Me.txtTransactionDate = New System.Windows.Forms.Label()
        Me.lblTransactionDate = New System.Windows.Forms.Label()
        Me.txtImageName = New System.Windows.Forms.Label()
        Me.cmbTransactionStatus = New System.Windows.Forms.ComboBox()
        Me.lblTransactionStatus = New System.Windows.Forms.Label()
        Me.lblRoutingStatus = New System.Windows.Forms.Label()
        Me.lblJigName = New System.Windows.Forms.Label()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.cmbDowntimeStatus = New System.Windows.Forms.ComboBox()
        Me.lblDowntimeStatus = New System.Windows.Forms.Label()
        Me.txtProblem = New System.Windows.Forms.TextBox()
        Me.lblProblem = New System.Windows.Forms.Label()
        Me.txtActionTaken = New System.Windows.Forms.TextBox()
        Me.lblActionTaken = New System.Windows.Forms.Label()
        Me.lblJoNumber = New System.Windows.Forms.Label()
        Me.txtJoNumber = New System.Windows.Forms.TextBox()
        Me.lblJoRequestor = New System.Windows.Forms.Label()
        Me.txtJoRequestor = New System.Windows.Forms.TextBox()
        Me.btnDeleteLog = New PinkieControls.ButtonXP()
        Me.btnAddLog = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.lblImageAttachment = New System.Windows.Forms.Label()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.btnBrowseImage = New PinkieControls.ButtonXP()
        Me.btnRemoveImage = New PinkieControls.ButtonXP()
        Me.pnlImage = New System.Windows.Forms.Panel()
        Me.btnViewImage = New PinkieControls.ButtonXP()
        Me.lblPic = New System.Windows.Forms.Label()
        Me.dgvPic = New System.Windows.Forms.DataGridView()
        Me.ColIsSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblActivityLog = New System.Windows.Forms.Label()
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
        Me.ofdImage = New System.Windows.Forms.OpenFileDialog()
        Me.lblRootCause = New System.Windows.Forms.Label()
        Me.txtRootCause = New System.Windows.Forms.TextBox()
        Me.lblChecksheet = New System.Windows.Forms.Label()
        Me.lblScheduleMonth = New System.Windows.Forms.Label()
        Me.lblScheduleWeek = New System.Windows.Forms.Label()
        Me.btnViewChecksheet = New PinkieControls.ButtonXP()
        Me.txtArea = New System.Windows.Forms.Label()
        Me.txtScheduleMonth = New System.Windows.Forms.TextBox()
        Me.txtScheduleWeek = New System.Windows.Forms.TextBox()
        Me.cmbJigName = New SergeUtils.EasyCompletionComboBox()
        Me.lblJigPart = New System.Windows.Forms.Label()
        Me.rdWithChecker = New System.Windows.Forms.RadioButton()
        Me.rdWithoutChecker = New System.Windows.Forms.RadioButton()
        Me.pnlJigPart = New System.Windows.Forms.Panel()
        Me.cmbDowntimeSubStatus = New System.Windows.Forms.ComboBox()
        Me.lblDowntimeSubStatus = New System.Windows.Forms.Label()
        Me.txtChecksheet = New Be.Windows.Forms.RichTextBoxEx()
        Me.lbl4M = New System.Windows.Forms.Label()
        Me.txt4M = New Be.Windows.Forms.RichTextBoxEx()
        Me.btnRemoveChecksheet = New PinkieControls.ButtonXP()
        Me.btnRemove4M = New PinkieControls.ButtonXP()
        Me.btnView4M = New PinkieControls.ButtonXP()
        Me.pnlApprovers = New System.Windows.Forms.Panel()
        Me.txtApp1Remarks = New System.Windows.Forms.TextBox()
        Me.lblApp1Remarks = New System.Windows.Forms.Label()
        Me.txtApp1Position = New System.Windows.Forms.Label()
        Me.lblApp1Name = New System.Windows.Forms.Label()
        Me.cmbApp1Name = New SergeUtils.EasyCompletionComboBox()
        Me.txtApp1Date = New System.Windows.Forms.Label()
        Me.lblApp1Position = New System.Windows.Forms.Label()
        Me.lblApp1Date = New System.Windows.Forms.Label()
        Me.lblApp1Status = New System.Windows.Forms.Label()
        Me.cmbApp1Status = New System.Windows.Forms.ComboBox()
        Me.txtApp2Remarks = New System.Windows.Forms.TextBox()
        Me.lblApp2Remarks = New System.Windows.Forms.Label()
        Me.txtApp2Position = New System.Windows.Forms.Label()
        Me.lblApp2Name = New System.Windows.Forms.Label()
        Me.cmbApp2Name = New SergeUtils.EasyCompletionComboBox()
        Me.txtApp2Date = New System.Windows.Forms.Label()
        Me.lblApp2Position = New System.Windows.Forms.Label()
        Me.lblApp2Date = New System.Windows.Forms.Label()
        Me.lblApp2Status = New System.Windows.Forms.Label()
        Me.cmbApp2Status = New System.Windows.Forms.ComboBox()
        Me.txtApp3Remarks = New System.Windows.Forms.TextBox()
        Me.lblApp3Remarks = New System.Windows.Forms.Label()
        Me.txtApp3Position = New System.Windows.Forms.Label()
        Me.lblApp3Name = New System.Windows.Forms.Label()
        Me.cmbApp3Name = New SergeUtils.EasyCompletionComboBox()
        Me.txtApp3Date = New System.Windows.Forms.Label()
        Me.lblApp3Position = New System.Windows.Forms.Label()
        Me.lblApp3Date = New System.Windows.Forms.Label()
        Me.lblApp3Status = New System.Windows.Forms.Label()
        Me.cmbApp3Status = New System.Windows.Forms.ComboBox()
        Me.cmbRoutingStatus = New System.Windows.Forms.ComboBox()
        Me.txtModifiedBy = New System.Windows.Forms.Label()
        Me.txtModifiedDate = New System.Windows.Forms.Label()
        Me.lblModifiedDate = New System.Windows.Forms.Label()
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.lblSpareParts = New System.Windows.Forms.Label()
        Me.dgvPartDetail = New System.Windows.Forms.DataGridView()
        Me.ColPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEditLog = New PinkieControls.ButtonXP()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlImage.SuspendLayout()
        CType(Me.dgvPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlApprovers.SuspendLayout()
        CType(Me.dgvPartDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRuntimeAccumulated
        '
        Me.txtRuntimeAccumulated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRuntimeAccumulated.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtRuntimeAccumulated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuntimeAccumulated.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRuntimeAccumulated.ForeColor = System.Drawing.Color.Black
        Me.txtRuntimeAccumulated.Location = New System.Drawing.Point(771, 108)
        Me.txtRuntimeAccumulated.Name = "txtRuntimeAccumulated"
        Me.txtRuntimeAccumulated.Size = New System.Drawing.Size(181, 20)
        Me.txtRuntimeAccumulated.TabIndex = 215
        Me.txtRuntimeAccumulated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtRuntimeAccumulated.UseCompatibleTextRendering = True
        '
        'lblRuntimeAccumulated
        '
        Me.lblRuntimeAccumulated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRuntimeAccumulated.BackColor = System.Drawing.SystemColors.Control
        Me.lblRuntimeAccumulated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRuntimeAccumulated.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRuntimeAccumulated.ForeColor = System.Drawing.Color.Black
        Me.lblRuntimeAccumulated.Location = New System.Drawing.Point(672, 108)
        Me.lblRuntimeAccumulated.Name = "lblRuntimeAccumulated"
        Me.lblRuntimeAccumulated.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblRuntimeAccumulated.Size = New System.Drawing.Size(100, 20)
        Me.lblRuntimeAccumulated.TabIndex = 214
        Me.lblRuntimeAccumulated.Text = "Total Runtime"
        Me.lblRuntimeAccumulated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDowntimeAccumulated
        '
        Me.txtDowntimeAccumulated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDowntimeAccumulated.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtDowntimeAccumulated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDowntimeAccumulated.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDowntimeAccumulated.ForeColor = System.Drawing.Color.Black
        Me.txtDowntimeAccumulated.Location = New System.Drawing.Point(1070, 108)
        Me.txtDowntimeAccumulated.Name = "txtDowntimeAccumulated"
        Me.txtDowntimeAccumulated.Size = New System.Drawing.Size(156, 20)
        Me.txtDowntimeAccumulated.TabIndex = 217
        Me.txtDowntimeAccumulated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtDowntimeAccumulated.UseCompatibleTextRendering = True
        '
        'lblDowntimeAccumulated
        '
        Me.lblDowntimeAccumulated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDowntimeAccumulated.BackColor = System.Drawing.SystemColors.Control
        Me.lblDowntimeAccumulated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDowntimeAccumulated.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDowntimeAccumulated.ForeColor = System.Drawing.Color.Black
        Me.lblDowntimeAccumulated.Location = New System.Drawing.Point(951, 108)
        Me.lblDowntimeAccumulated.Name = "lblDowntimeAccumulated"
        Me.lblDowntimeAccumulated.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblDowntimeAccumulated.Size = New System.Drawing.Size(120, 20)
        Me.lblDowntimeAccumulated.TabIndex = 216
        Me.lblDowntimeAccumulated.Text = "Total Downtime"
        Me.lblDowntimeAccumulated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransactionDate
        '
        Me.txtTransactionDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtTransactionDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransactionDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTransactionDate.ForeColor = System.Drawing.Color.Black
        Me.txtTransactionDate.Location = New System.Drawing.Point(420, 50)
        Me.txtTransactionDate.Name = "txtTransactionDate"
        Me.txtTransactionDate.Size = New System.Drawing.Size(250, 23)
        Me.txtTransactionDate.TabIndex = 242
        Me.txtTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtTransactionDate.UseCompatibleTextRendering = True
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblTransactionDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransactionDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTransactionDate.ForeColor = System.Drawing.Color.Black
        Me.lblTransactionDate.Location = New System.Drawing.Point(291, 50)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblTransactionDate.Size = New System.Drawing.Size(130, 23)
        Me.lblTransactionDate.TabIndex = 241
        Me.lblTransactionDate.Text = "Activity Date"
        Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtImageName
        '
        Me.txtImageName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImageName.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtImageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImageName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtImageName.ForeColor = System.Drawing.Color.Black
        Me.txtImageName.Location = New System.Drawing.Point(672, 555)
        Me.txtImageName.Name = "txtImageName"
        Me.txtImageName.Size = New System.Drawing.Size(281, 23)
        Me.txtImageName.TabIndex = 245
        Me.txtImageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtImageName.UseCompatibleTextRendering = True
        '
        'cmbTransactionStatus
        '
        Me.cmbTransactionStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTransactionStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransactionStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbTransactionStatus.Location = New System.Drawing.Point(420, 25)
        Me.cmbTransactionStatus.Name = "cmbTransactionStatus"
        Me.cmbTransactionStatus.Size = New System.Drawing.Size(250, 23)
        Me.cmbTransactionStatus.TabIndex = 0
        '
        'lblTransactionStatus
        '
        Me.lblTransactionStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblTransactionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransactionStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTransactionStatus.ForeColor = System.Drawing.Color.Black
        Me.lblTransactionStatus.Location = New System.Drawing.Point(291, 25)
        Me.lblTransactionStatus.Name = "lblTransactionStatus"
        Me.lblTransactionStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblTransactionStatus.Size = New System.Drawing.Size(130, 23)
        Me.lblTransactionStatus.TabIndex = 211
        Me.lblTransactionStatus.Text = "Activity Status"
        Me.lblTransactionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRoutingStatus
        '
        Me.lblRoutingStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblRoutingStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRoutingStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRoutingStatus.ForeColor = System.Drawing.Color.Black
        Me.lblRoutingStatus.Location = New System.Drawing.Point(291, 0)
        Me.lblRoutingStatus.Name = "lblRoutingStatus"
        Me.lblRoutingStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblRoutingStatus.Size = New System.Drawing.Size(130, 23)
        Me.lblRoutingStatus.TabIndex = 213
        Me.lblRoutingStatus.Text = "Routing Status"
        Me.lblRoutingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblJigName
        '
        Me.lblJigName.BackColor = System.Drawing.SystemColors.Control
        Me.lblJigName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJigName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJigName.ForeColor = System.Drawing.Color.Black
        Me.lblJigName.Location = New System.Drawing.Point(291, 75)
        Me.lblJigName.Name = "lblJigName"
        Me.lblJigName.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblJigName.Size = New System.Drawing.Size(130, 23)
        Me.lblJigName.TabIndex = 220
        Me.lblJigName.Text = "Jig Name"
        Me.lblJigName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblArea
        '
        Me.lblArea.BackColor = System.Drawing.SystemColors.Control
        Me.lblArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblArea.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblArea.ForeColor = System.Drawing.Color.Black
        Me.lblArea.Location = New System.Drawing.Point(291, 100)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblArea.Size = New System.Drawing.Size(130, 23)
        Me.lblArea.TabIndex = 221
        Me.lblArea.Text = "Area"
        Me.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDowntimeStatus
        '
        Me.cmbDowntimeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDowntimeStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbDowntimeStatus.FormattingEnabled = True
        Me.cmbDowntimeStatus.Location = New System.Drawing.Point(420, 150)
        Me.cmbDowntimeStatus.Name = "cmbDowntimeStatus"
        Me.cmbDowntimeStatus.Size = New System.Drawing.Size(250, 23)
        Me.cmbDowntimeStatus.TabIndex = 3
        '
        'lblDowntimeStatus
        '
        Me.lblDowntimeStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblDowntimeStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDowntimeStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDowntimeStatus.ForeColor = System.Drawing.Color.Black
        Me.lblDowntimeStatus.Location = New System.Drawing.Point(291, 150)
        Me.lblDowntimeStatus.Name = "lblDowntimeStatus"
        Me.lblDowntimeStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblDowntimeStatus.Size = New System.Drawing.Size(130, 23)
        Me.lblDowntimeStatus.TabIndex = 225
        Me.lblDowntimeStatus.Text = "Downtime Status"
        Me.lblDowntimeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProblem
        '
        Me.txtProblem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProblem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtProblem.Location = New System.Drawing.Point(291, 247)
        Me.txtProblem.Multiline = True
        Me.txtProblem.Name = "txtProblem"
        Me.txtProblem.Size = New System.Drawing.Size(379, 62)
        Me.txtProblem.TabIndex = 7
        '
        'lblProblem
        '
        Me.lblProblem.BackColor = System.Drawing.SystemColors.Control
        Me.lblProblem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProblem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblProblem.ForeColor = System.Drawing.Color.Black
        Me.lblProblem.Location = New System.Drawing.Point(291, 225)
        Me.lblProblem.Name = "lblProblem"
        Me.lblProblem.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblProblem.Size = New System.Drawing.Size(379, 23)
        Me.lblProblem.TabIndex = 227
        Me.lblProblem.Text = "Problem"
        Me.lblProblem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtActionTaken
        '
        Me.txtActionTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActionTaken.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtActionTaken.Location = New System.Drawing.Point(291, 417)
        Me.txtActionTaken.Multiline = True
        Me.txtActionTaken.Name = "txtActionTaken"
        Me.txtActionTaken.Size = New System.Drawing.Size(379, 61)
        Me.txtActionTaken.TabIndex = 9
        '
        'lblActionTaken
        '
        Me.lblActionTaken.BackColor = System.Drawing.SystemColors.Control
        Me.lblActionTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActionTaken.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblActionTaken.ForeColor = System.Drawing.Color.Black
        Me.lblActionTaken.Location = New System.Drawing.Point(291, 395)
        Me.lblActionTaken.Name = "lblActionTaken"
        Me.lblActionTaken.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblActionTaken.Size = New System.Drawing.Size(379, 23)
        Me.lblActionTaken.TabIndex = 229
        Me.lblActionTaken.Text = "Action Taken"
        Me.lblActionTaken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblJoNumber
        '
        Me.lblJoNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblJoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJoNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJoNumber.ForeColor = System.Drawing.Color.Black
        Me.lblJoNumber.Location = New System.Drawing.Point(291, 530)
        Me.lblJoNumber.Name = "lblJoNumber"
        Me.lblJoNumber.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblJoNumber.Size = New System.Drawing.Size(100, 23)
        Me.lblJoNumber.TabIndex = 235
        Me.lblJoNumber.Text = "JO No."
        Me.lblJoNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtJoNumber
        '
        Me.txtJoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJoNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJoNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtJoNumber.Location = New System.Drawing.Point(390, 530)
        Me.txtJoNumber.MaxLength = 15
        Me.txtJoNumber.Name = "txtJoNumber"
        Me.txtJoNumber.Size = New System.Drawing.Size(280, 23)
        Me.txtJoNumber.TabIndex = 12
        '
        'lblJoRequestor
        '
        Me.lblJoRequestor.BackColor = System.Drawing.SystemColors.Control
        Me.lblJoRequestor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJoRequestor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJoRequestor.ForeColor = System.Drawing.Color.Black
        Me.lblJoRequestor.Location = New System.Drawing.Point(291, 555)
        Me.lblJoRequestor.Name = "lblJoRequestor"
        Me.lblJoRequestor.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblJoRequestor.Size = New System.Drawing.Size(100, 23)
        Me.lblJoRequestor.TabIndex = 237
        Me.lblJoRequestor.Text = "JO Requestor"
        Me.lblJoRequestor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtJoRequestor
        '
        Me.txtJoRequestor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJoRequestor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJoRequestor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtJoRequestor.Location = New System.Drawing.Point(390, 555)
        Me.txtJoRequestor.Name = "txtJoRequestor"
        Me.txtJoRequestor.Size = New System.Drawing.Size(280, 23)
        Me.txtJoRequestor.TabIndex = 13
        '
        'btnDeleteLog
        '
        Me.btnDeleteLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDeleteLog.DefaultScheme = False
        Me.btnDeleteLog.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDeleteLog.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnDeleteLog.Hint = "Delete selected activity log"
        Me.btnDeleteLog.Location = New System.Drawing.Point(1143, 2)
        Me.btnDeleteLog.Name = "btnDeleteLog"
        Me.btnDeleteLog.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDeleteLog.Size = New System.Drawing.Size(80, 26)
        Me.btnDeleteLog.TabIndex = 15
        Me.btnDeleteLog.TabStop = False
        Me.btnDeleteLog.Text = "Delete"
        '
        'btnAddLog
        '
        Me.btnAddLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAddLog.DefaultScheme = False
        Me.btnAddLog.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAddLog.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnAddLog.Hint = "Add activity log"
        Me.btnAddLog.Location = New System.Drawing.Point(981, 2)
        Me.btnAddLog.Name = "btnAddLog"
        Me.btnAddLog.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAddLog.Size = New System.Drawing.Size(80, 26)
        Me.btnAddLog.TabIndex = 14
        Me.btnAddLog.TabStop = False
        Me.btnAddLog.Text = "Add"
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
        Me.btnClose.Location = New System.Drawing.Point(1136, 593)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 253
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = False
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnDelete.Hint = "Delete record"
        Me.btnDelete.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Erase_16_x_16
        Me.btnDelete.Location = New System.Drawing.Point(1042, 593)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 252
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
        Me.btnCancel.Location = New System.Drawing.Point(948, 593)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(90, 32)
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
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnSave.Hint = "Save record"
        Me.btnSave.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Save_16_x_16
        Me.btnSave.Location = New System.Drawing.Point(854, 593)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 250
        Me.btnSave.TabStop = False
        Me.btnSave.Text = " Save"
        '
        'lblImageAttachment
        '
        Me.lblImageAttachment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImageAttachment.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImageAttachment.ForeColor = System.Drawing.Color.Black
        Me.lblImageAttachment.Location = New System.Drawing.Point(672, 251)
        Me.lblImageAttachment.Name = "lblImageAttachment"
        Me.lblImageAttachment.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblImageAttachment.Size = New System.Drawing.Size(281, 24)
        Me.lblImageAttachment.TabIndex = 243
        Me.lblImageAttachment.Text = "Image"
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
        Me.picImage.Location = New System.Drawing.Point(3, 3)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(273, 244)
        Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage.TabIndex = 0
        Me.picImage.TabStop = False
        '
        'btnBrowseImage
        '
        Me.btnBrowseImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnBrowseImage.DefaultScheme = False
        Me.btnBrowseImage.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnBrowseImage.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnBrowseImage.Hint = "Attach image"
        Me.btnBrowseImage.Location = New System.Drawing.Point(116, 248)
        Me.btnBrowseImage.Name = "btnBrowseImage"
        Me.btnBrowseImage.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnBrowseImage.Size = New System.Drawing.Size(80, 28)
        Me.btnBrowseImage.TabIndex = 1
        Me.btnBrowseImage.TabStop = False
        Me.btnBrowseImage.Text = "Browse"
        '
        'btnRemoveImage
        '
        Me.btnRemoveImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnRemoveImage.DefaultScheme = False
        Me.btnRemoveImage.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemoveImage.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnRemoveImage.Hint = "Remove image"
        Me.btnRemoveImage.Location = New System.Drawing.Point(197, 248)
        Me.btnRemoveImage.Name = "btnRemoveImage"
        Me.btnRemoveImage.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemoveImage.Size = New System.Drawing.Size(80, 28)
        Me.btnRemoveImage.TabIndex = 2
        Me.btnRemoveImage.TabStop = False
        Me.btnRemoveImage.Text = "Remove"
        '
        'pnlImage
        '
        Me.pnlImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlImage.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImage.Controls.Add(Me.btnViewImage)
        Me.pnlImage.Controls.Add(Me.btnRemoveImage)
        Me.pnlImage.Controls.Add(Me.btnBrowseImage)
        Me.pnlImage.Controls.Add(Me.picImage)
        Me.pnlImage.Location = New System.Drawing.Point(672, 274)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(281, 279)
        Me.pnlImage.TabIndex = 244
        '
        'btnViewImage
        '
        Me.btnViewImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnViewImage.DefaultScheme = False
        Me.btnViewImage.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnViewImage.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewImage.Hint = "Open image"
        Me.btnViewImage.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Expand_16_x_16
        Me.btnViewImage.Location = New System.Drawing.Point(2, 248)
        Me.btnViewImage.Name = "btnViewImage"
        Me.btnViewImage.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnViewImage.Size = New System.Drawing.Size(28, 28)
        Me.btnViewImage.TabIndex = 0
        Me.btnViewImage.TabStop = False
        '
        'lblPic
        '
        Me.lblPic.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPic.BackColor = System.Drawing.SystemColors.Control
        Me.lblPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPic.ForeColor = System.Drawing.Color.Black
        Me.lblPic.Location = New System.Drawing.Point(955, 251)
        Me.lblPic.Name = "lblPic"
        Me.lblPic.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblPic.Size = New System.Drawing.Size(271, 24)
        Me.lblPic.TabIndex = 246
        Me.lblPic.Text = "Included PIC"
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
        Me.dgvPic.Location = New System.Drawing.Point(955, 274)
        Me.dgvPic.MultiSelect = False
        Me.dgvPic.Name = "dgvPic"
        Me.dgvPic.RowHeadersVisible = False
        Me.dgvPic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPic.Size = New System.Drawing.Size(271, 304)
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColUserName.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColUserName.HeaderText = "NickName"
        Me.ColUserName.Name = "ColUserName"
        Me.ColUserName.ReadOnly = True
        Me.ColUserName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'lblActivityLog
        '
        Me.lblActivityLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActivityLog.BackColor = System.Drawing.SystemColors.Control
        Me.lblActivityLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActivityLog.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblActivityLog.ForeColor = System.Drawing.Color.Black
        Me.lblActivityLog.Location = New System.Drawing.Point(672, 0)
        Me.lblActivityLog.Name = "lblActivityLog"
        Me.lblActivityLog.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblActivityLog.Size = New System.Drawing.Size(554, 30)
        Me.lblActivityLog.TabIndex = 279
        Me.lblActivityLog.Text = "Activity Log"
        Me.lblActivityLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.AllowUserToResizeColumns = False
        Me.dgvDetail.AllowUserToResizeRows = False
        Me.dgvDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvDetail.ColumnHeadersHeight = 22
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColTrxDetailId, Me.ColTrxId, Me.ColTrxDate, Me.ColUserIdLog, Me.ColShiftId, Me.ColTrxFrom, Me.ColTrxTo, Me.ColElapsedTime})
        Me.dgvDetail.Location = New System.Drawing.Point(672, 29)
        Me.dgvDetail.MultiSelect = False
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.ReadOnly = True
        Me.dgvDetail.RowHeadersVisible = False
        Me.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetail.Size = New System.Drawing.Size(554, 80)
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
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColShiftId.DefaultCellStyle = DataGridViewCellStyle11
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
        DataGridViewCellStyle12.Format = "MM/dd/yyyy hh:mm tt"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.ColTrxFrom.DefaultCellStyle = DataGridViewCellStyle12
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
        DataGridViewCellStyle13.Format = "MM/dd/yyyy hh:mm tt"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.ColTrxTo.DefaultCellStyle = DataGridViewCellStyle13
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
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColElapsedTime.DefaultCellStyle = DataGridViewCellStyle14
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
        Me.txtRoutingStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRoutingStatus.ForeColor = System.Drawing.Color.Black
        Me.txtRoutingStatus.Location = New System.Drawing.Point(420, 0)
        Me.txtRoutingStatus.Name = "txtRoutingStatus"
        Me.txtRoutingStatus.Size = New System.Drawing.Size(250, 23)
        Me.txtRoutingStatus.TabIndex = 296
        Me.txtRoutingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtRoutingStatus.UseCompatibleTextRendering = True
        '
        'ofdImage
        '
        '
        'lblRootCause
        '
        Me.lblRootCause.BackColor = System.Drawing.SystemColors.Control
        Me.lblRootCause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRootCause.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRootCause.ForeColor = System.Drawing.Color.Black
        Me.lblRootCause.Location = New System.Drawing.Point(291, 311)
        Me.lblRootCause.Name = "lblRootCause"
        Me.lblRootCause.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblRootCause.Size = New System.Drawing.Size(379, 23)
        Me.lblRootCause.TabIndex = 544
        Me.lblRootCause.Text = "Root Cause"
        Me.lblRootCause.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRootCause
        '
        Me.txtRootCause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRootCause.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRootCause.Location = New System.Drawing.Point(291, 333)
        Me.txtRootCause.Multiline = True
        Me.txtRootCause.Name = "txtRootCause"
        Me.txtRootCause.Size = New System.Drawing.Size(379, 60)
        Me.txtRootCause.TabIndex = 8
        '
        'lblChecksheet
        '
        Me.lblChecksheet.BackColor = System.Drawing.SystemColors.Control
        Me.lblChecksheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChecksheet.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblChecksheet.ForeColor = System.Drawing.Color.Black
        Me.lblChecksheet.Location = New System.Drawing.Point(291, 480)
        Me.lblChecksheet.Name = "lblChecksheet"
        Me.lblChecksheet.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblChecksheet.Size = New System.Drawing.Size(100, 23)
        Me.lblChecksheet.TabIndex = 551
        Me.lblChecksheet.Text = "Check Sheet"
        Me.lblChecksheet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScheduleMonth
        '
        Me.lblScheduleMonth.BackColor = System.Drawing.SystemColors.Control
        Me.lblScheduleMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScheduleMonth.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblScheduleMonth.ForeColor = System.Drawing.Color.Black
        Me.lblScheduleMonth.Location = New System.Drawing.Point(291, 200)
        Me.lblScheduleMonth.Name = "lblScheduleMonth"
        Me.lblScheduleMonth.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblScheduleMonth.Size = New System.Drawing.Size(130, 23)
        Me.lblScheduleMonth.TabIndex = 553
        Me.lblScheduleMonth.Text = "Month Scheduled"
        Me.lblScheduleMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScheduleWeek
        '
        Me.lblScheduleWeek.BackColor = System.Drawing.SystemColors.Control
        Me.lblScheduleWeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScheduleWeek.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblScheduleWeek.ForeColor = System.Drawing.Color.Black
        Me.lblScheduleWeek.Location = New System.Drawing.Point(541, 200)
        Me.lblScheduleWeek.Name = "lblScheduleWeek"
        Me.lblScheduleWeek.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblScheduleWeek.Size = New System.Drawing.Size(70, 23)
        Me.lblScheduleWeek.TabIndex = 555
        Me.lblScheduleWeek.Text = "Week No"
        Me.lblScheduleWeek.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnViewChecksheet
        '
        Me.btnViewChecksheet.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnViewChecksheet.DefaultScheme = False
        Me.btnViewChecksheet.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnViewChecksheet.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewChecksheet.Hint = "Open checksheet"
        Me.btnViewChecksheet.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Expand_16_x_16
        Me.btnViewChecksheet.Location = New System.Drawing.Point(614, 479)
        Me.btnViewChecksheet.Name = "btnViewChecksheet"
        Me.btnViewChecksheet.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnViewChecksheet.Size = New System.Drawing.Size(28, 25)
        Me.btnViewChecksheet.TabIndex = 16
        Me.btnViewChecksheet.TabStop = False
        '
        'txtArea
        '
        Me.txtArea.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtArea.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtArea.ForeColor = System.Drawing.Color.Black
        Me.txtArea.Location = New System.Drawing.Point(420, 100)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(250, 23)
        Me.txtArea.TabIndex = 560
        Me.txtArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtArea.UseCompatibleTextRendering = True
        '
        'txtScheduleMonth
        '
        Me.txtScheduleMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScheduleMonth.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtScheduleMonth.Location = New System.Drawing.Point(420, 200)
        Me.txtScheduleMonth.Name = "txtScheduleMonth"
        Me.txtScheduleMonth.Size = New System.Drawing.Size(122, 23)
        Me.txtScheduleMonth.TabIndex = 5
        Me.txtScheduleMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtScheduleWeek
        '
        Me.txtScheduleWeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScheduleWeek.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtScheduleWeek.Location = New System.Drawing.Point(610, 200)
        Me.txtScheduleWeek.Name = "txtScheduleWeek"
        Me.txtScheduleWeek.Size = New System.Drawing.Size(60, 23)
        Me.txtScheduleWeek.TabIndex = 6
        Me.txtScheduleWeek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbJigName
        '
        Me.cmbJigName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbJigName.FormattingEnabled = True
        Me.cmbJigName.Location = New System.Drawing.Point(420, 75)
        Me.cmbJigName.Name = "cmbJigName"
        Me.cmbJigName.Size = New System.Drawing.Size(250, 23)
        Me.cmbJigName.TabIndex = 1
        '
        'lblJigPart
        '
        Me.lblJigPart.BackColor = System.Drawing.SystemColors.Control
        Me.lblJigPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJigPart.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJigPart.ForeColor = System.Drawing.Color.Black
        Me.lblJigPart.Location = New System.Drawing.Point(291, 125)
        Me.lblJigPart.Name = "lblJigPart"
        Me.lblJigPart.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblJigPart.Size = New System.Drawing.Size(130, 23)
        Me.lblJigPart.TabIndex = 224
        Me.lblJigPart.Text = "Jig Part"
        Me.lblJigPart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdWithChecker
        '
        Me.rdWithChecker.Enabled = False
        Me.rdWithChecker.Location = New System.Drawing.Point(442, 127)
        Me.rdWithChecker.Name = "rdWithChecker"
        Me.rdWithChecker.Size = New System.Drawing.Size(96, 19)
        Me.rdWithChecker.TabIndex = 579
        Me.rdWithChecker.TabStop = True
        Me.rdWithChecker.Text = "With Checker"
        Me.rdWithChecker.UseVisualStyleBackColor = True
        '
        'rdWithoutChecker
        '
        Me.rdWithoutChecker.Enabled = False
        Me.rdWithoutChecker.Location = New System.Drawing.Point(552, 127)
        Me.rdWithoutChecker.Name = "rdWithoutChecker"
        Me.rdWithoutChecker.Size = New System.Drawing.Size(114, 19)
        Me.rdWithoutChecker.TabIndex = 580
        Me.rdWithoutChecker.TabStop = True
        Me.rdWithoutChecker.Text = "Without Checker"
        Me.rdWithoutChecker.UseVisualStyleBackColor = True
        '
        'pnlJigPart
        '
        Me.pnlJigPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlJigPart.Enabled = False
        Me.pnlJigPart.Location = New System.Drawing.Point(420, 125)
        Me.pnlJigPart.Name = "pnlJigPart"
        Me.pnlJigPart.Size = New System.Drawing.Size(250, 23)
        Me.pnlJigPart.TabIndex = 581
        '
        'cmbDowntimeSubStatus
        '
        Me.cmbDowntimeSubStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDowntimeSubStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbDowntimeSubStatus.FormattingEnabled = True
        Me.cmbDowntimeSubStatus.Location = New System.Drawing.Point(420, 175)
        Me.cmbDowntimeSubStatus.Name = "cmbDowntimeSubStatus"
        Me.cmbDowntimeSubStatus.Size = New System.Drawing.Size(250, 23)
        Me.cmbDowntimeSubStatus.TabIndex = 4
        '
        'lblDowntimeSubStatus
        '
        Me.lblDowntimeSubStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblDowntimeSubStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDowntimeSubStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDowntimeSubStatus.ForeColor = System.Drawing.Color.Black
        Me.lblDowntimeSubStatus.Location = New System.Drawing.Point(291, 175)
        Me.lblDowntimeSubStatus.Name = "lblDowntimeSubStatus"
        Me.lblDowntimeSubStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblDowntimeSubStatus.Size = New System.Drawing.Size(130, 23)
        Me.lblDowntimeSubStatus.TabIndex = 549
        Me.lblDowntimeSubStatus.Text = "Sub-Status"
        Me.lblDowntimeSubStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChecksheet
        '
        Me.txtChecksheet.Location = New System.Drawing.Point(390, 480)
        Me.txtChecksheet.Multiline = False
        Me.txtChecksheet.Name = "txtChecksheet"
        Me.txtChecksheet.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.txtChecksheet.Size = New System.Drawing.Size(221, 23)
        Me.txtChecksheet.TabIndex = 582
        Me.txtChecksheet.Text = ""
        Me.txtChecksheet.WordWrap = False
        '
        'lbl4M
        '
        Me.lbl4M.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4M.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl4M.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl4M.ForeColor = System.Drawing.Color.Black
        Me.lbl4M.Location = New System.Drawing.Point(291, 505)
        Me.lbl4M.Name = "lbl4M"
        Me.lbl4M.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lbl4M.Size = New System.Drawing.Size(100, 23)
        Me.lbl4M.TabIndex = 583
        Me.lbl4M.Text = "4M Change"
        Me.lbl4M.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt4M
        '
        Me.txt4M.Location = New System.Drawing.Point(390, 505)
        Me.txt4M.Multiline = False
        Me.txt4M.Name = "txt4M"
        Me.txt4M.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.txt4M.Size = New System.Drawing.Size(221, 23)
        Me.txt4M.TabIndex = 584
        Me.txt4M.Text = ""
        Me.txt4M.WordWrap = False
        '
        'btnRemoveChecksheet
        '
        Me.btnRemoveChecksheet.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemoveChecksheet.DefaultScheme = False
        Me.btnRemoveChecksheet.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemoveChecksheet.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRemoveChecksheet.Hint = "Remove checksheet link"
        Me.btnRemoveChecksheet.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Remove_16_x_16
        Me.btnRemoveChecksheet.Location = New System.Drawing.Point(643, 479)
        Me.btnRemoveChecksheet.Name = "btnRemoveChecksheet"
        Me.btnRemoveChecksheet.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemoveChecksheet.Size = New System.Drawing.Size(28, 25)
        Me.btnRemoveChecksheet.TabIndex = 585
        Me.btnRemoveChecksheet.TabStop = False
        '
        'btnRemove4M
        '
        Me.btnRemove4M.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemove4M.DefaultScheme = False
        Me.btnRemove4M.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemove4M.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRemove4M.Hint = "Remove checksheet link"
        Me.btnRemove4M.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Remove_16_x_16
        Me.btnRemove4M.Location = New System.Drawing.Point(643, 504)
        Me.btnRemove4M.Name = "btnRemove4M"
        Me.btnRemove4M.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove4M.Size = New System.Drawing.Size(28, 25)
        Me.btnRemove4M.TabIndex = 587
        Me.btnRemove4M.TabStop = False
        '
        'btnView4M
        '
        Me.btnView4M.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnView4M.DefaultScheme = False
        Me.btnView4M.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnView4M.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView4M.Hint = "Open checksheet"
        Me.btnView4M.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Expand_16_x_16
        Me.btnView4M.Location = New System.Drawing.Point(614, 504)
        Me.btnView4M.Name = "btnView4M"
        Me.btnView4M.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnView4M.Size = New System.Drawing.Size(28, 25)
        Me.btnView4M.TabIndex = 586
        Me.btnView4M.TabStop = False
        '
        'pnlApprovers
        '
        Me.pnlApprovers.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlApprovers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlApprovers.Controls.Add(Me.txtApp1Remarks)
        Me.pnlApprovers.Controls.Add(Me.lblApp1Remarks)
        Me.pnlApprovers.Controls.Add(Me.txtApp1Position)
        Me.pnlApprovers.Controls.Add(Me.lblApp1Name)
        Me.pnlApprovers.Controls.Add(Me.cmbApp1Name)
        Me.pnlApprovers.Controls.Add(Me.txtApp1Date)
        Me.pnlApprovers.Controls.Add(Me.lblApp1Position)
        Me.pnlApprovers.Controls.Add(Me.lblApp1Date)
        Me.pnlApprovers.Controls.Add(Me.lblApp1Status)
        Me.pnlApprovers.Controls.Add(Me.cmbApp1Status)
        Me.pnlApprovers.Controls.Add(Me.txtApp2Remarks)
        Me.pnlApprovers.Controls.Add(Me.lblApp2Remarks)
        Me.pnlApprovers.Controls.Add(Me.txtApp2Position)
        Me.pnlApprovers.Controls.Add(Me.lblApp2Name)
        Me.pnlApprovers.Controls.Add(Me.cmbApp2Name)
        Me.pnlApprovers.Controls.Add(Me.txtApp2Date)
        Me.pnlApprovers.Controls.Add(Me.lblApp2Position)
        Me.pnlApprovers.Controls.Add(Me.lblApp2Date)
        Me.pnlApprovers.Controls.Add(Me.lblApp2Status)
        Me.pnlApprovers.Controls.Add(Me.cmbApp2Status)
        Me.pnlApprovers.Controls.Add(Me.txtApp3Remarks)
        Me.pnlApprovers.Controls.Add(Me.lblApp3Remarks)
        Me.pnlApprovers.Controls.Add(Me.txtApp3Position)
        Me.pnlApprovers.Controls.Add(Me.lblApp3Name)
        Me.pnlApprovers.Controls.Add(Me.cmbApp3Name)
        Me.pnlApprovers.Controls.Add(Me.txtApp3Date)
        Me.pnlApprovers.Controls.Add(Me.lblApp3Position)
        Me.pnlApprovers.Controls.Add(Me.lblApp3Date)
        Me.pnlApprovers.Controls.Add(Me.lblApp3Status)
        Me.pnlApprovers.Controls.Add(Me.cmbApp3Status)
        Me.pnlApprovers.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlApprovers.Location = New System.Drawing.Point(0, 0)
        Me.pnlApprovers.Name = "pnlApprovers"
        Me.pnlApprovers.Size = New System.Drawing.Size(290, 628)
        Me.pnlApprovers.TabIndex = 281
        '
        'txtApp1Remarks
        '
        Me.txtApp1Remarks.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtApp1Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp1Remarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp1Remarks.Location = New System.Drawing.Point(2, 546)
        Me.txtApp1Remarks.Multiline = True
        Me.txtApp1Remarks.Name = "txtApp1Remarks"
        Me.txtApp1Remarks.Size = New System.Drawing.Size(284, 78)
        Me.txtApp1Remarks.TabIndex = 297
        '
        'lblApp1Remarks
        '
        Me.lblApp1Remarks.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp1Remarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp1Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp1Remarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp1Remarks.ForeColor = System.Drawing.Color.Black
        Me.lblApp1Remarks.Location = New System.Drawing.Point(2, 524)
        Me.lblApp1Remarks.Name = "lblApp1Remarks"
        Me.lblApp1Remarks.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp1Remarks.Size = New System.Drawing.Size(284, 23)
        Me.lblApp1Remarks.TabIndex = 296
        Me.lblApp1Remarks.Text = "Remarks"
        Me.lblApp1Remarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApp1Position
        '
        Me.txtApp1Position.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtApp1Position.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApp1Position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp1Position.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp1Position.ForeColor = System.Drawing.Color.Black
        Me.txtApp1Position.Location = New System.Drawing.Point(61, 499)
        Me.txtApp1Position.Name = "txtApp1Position"
        Me.txtApp1Position.Size = New System.Drawing.Size(225, 23)
        Me.txtApp1Position.TabIndex = 295
        Me.txtApp1Position.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApp1Position.UseCompatibleTextRendering = True
        '
        'lblApp1Name
        '
        Me.lblApp1Name.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp1Name.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp1Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp1Name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp1Name.ForeColor = System.Drawing.Color.Black
        Me.lblApp1Name.Location = New System.Drawing.Point(2, 474)
        Me.lblApp1Name.Name = "lblApp1Name"
        Me.lblApp1Name.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp1Name.Size = New System.Drawing.Size(60, 23)
        Me.lblApp1Name.TabIndex = 292
        Me.lblApp1Name.Text = "Name"
        Me.lblApp1Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbApp1Name
        '
        Me.cmbApp1Name.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbApp1Name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbApp1Name.FormattingEnabled = True
        Me.cmbApp1Name.Location = New System.Drawing.Point(61, 474)
        Me.cmbApp1Name.Name = "cmbApp1Name"
        Me.cmbApp1Name.Size = New System.Drawing.Size(225, 23)
        Me.cmbApp1Name.TabIndex = 294
        '
        'txtApp1Date
        '
        Me.txtApp1Date.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtApp1Date.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApp1Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp1Date.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp1Date.ForeColor = System.Drawing.Color.Black
        Me.txtApp1Date.Location = New System.Drawing.Point(61, 449)
        Me.txtApp1Date.Name = "txtApp1Date"
        Me.txtApp1Date.Size = New System.Drawing.Size(225, 23)
        Me.txtApp1Date.TabIndex = 293
        Me.txtApp1Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApp1Date.UseCompatibleTextRendering = True
        '
        'lblApp1Position
        '
        Me.lblApp1Position.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp1Position.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp1Position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp1Position.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp1Position.ForeColor = System.Drawing.Color.Black
        Me.lblApp1Position.Location = New System.Drawing.Point(2, 499)
        Me.lblApp1Position.Name = "lblApp1Position"
        Me.lblApp1Position.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp1Position.Size = New System.Drawing.Size(60, 23)
        Me.lblApp1Position.TabIndex = 291
        Me.lblApp1Position.Text = "Position"
        Me.lblApp1Position.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApp1Date
        '
        Me.lblApp1Date.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp1Date.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp1Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp1Date.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp1Date.ForeColor = System.Drawing.Color.Black
        Me.lblApp1Date.Location = New System.Drawing.Point(2, 449)
        Me.lblApp1Date.Name = "lblApp1Date"
        Me.lblApp1Date.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp1Date.Size = New System.Drawing.Size(60, 23)
        Me.lblApp1Date.TabIndex = 290
        Me.lblApp1Date.Text = "Date"
        Me.lblApp1Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApp1Status
        '
        Me.lblApp1Status.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp1Status.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp1Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp1Status.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp1Status.ForeColor = System.Drawing.Color.Black
        Me.lblApp1Status.Location = New System.Drawing.Point(2, 424)
        Me.lblApp1Status.Name = "lblApp1Status"
        Me.lblApp1Status.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp1Status.Size = New System.Drawing.Size(60, 23)
        Me.lblApp1Status.TabIndex = 289
        Me.lblApp1Status.Text = "Status"
        Me.lblApp1Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbApp1Status
        '
        Me.cmbApp1Status.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbApp1Status.BackColor = System.Drawing.SystemColors.Window
        Me.cmbApp1Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbApp1Status.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbApp1Status.Location = New System.Drawing.Point(61, 424)
        Me.cmbApp1Status.Name = "cmbApp1Status"
        Me.cmbApp1Status.Size = New System.Drawing.Size(225, 23)
        Me.cmbApp1Status.TabIndex = 288
        '
        'txtApp2Remarks
        '
        Me.txtApp2Remarks.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtApp2Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp2Remarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp2Remarks.Location = New System.Drawing.Point(2, 336)
        Me.txtApp2Remarks.Multiline = True
        Me.txtApp2Remarks.Name = "txtApp2Remarks"
        Me.txtApp2Remarks.Size = New System.Drawing.Size(284, 86)
        Me.txtApp2Remarks.TabIndex = 287
        '
        'lblApp2Remarks
        '
        Me.lblApp2Remarks.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp2Remarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp2Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp2Remarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp2Remarks.ForeColor = System.Drawing.Color.Black
        Me.lblApp2Remarks.Location = New System.Drawing.Point(2, 314)
        Me.lblApp2Remarks.Name = "lblApp2Remarks"
        Me.lblApp2Remarks.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp2Remarks.Size = New System.Drawing.Size(284, 23)
        Me.lblApp2Remarks.TabIndex = 286
        Me.lblApp2Remarks.Text = "Remarks"
        Me.lblApp2Remarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApp2Position
        '
        Me.txtApp2Position.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtApp2Position.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApp2Position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp2Position.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp2Position.ForeColor = System.Drawing.Color.Black
        Me.txtApp2Position.Location = New System.Drawing.Point(61, 289)
        Me.txtApp2Position.Name = "txtApp2Position"
        Me.txtApp2Position.Size = New System.Drawing.Size(225, 23)
        Me.txtApp2Position.TabIndex = 285
        Me.txtApp2Position.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApp2Position.UseCompatibleTextRendering = True
        '
        'lblApp2Name
        '
        Me.lblApp2Name.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp2Name.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp2Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp2Name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp2Name.ForeColor = System.Drawing.Color.Black
        Me.lblApp2Name.Location = New System.Drawing.Point(2, 264)
        Me.lblApp2Name.Name = "lblApp2Name"
        Me.lblApp2Name.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp2Name.Size = New System.Drawing.Size(60, 23)
        Me.lblApp2Name.TabIndex = 282
        Me.lblApp2Name.Text = "Name"
        Me.lblApp2Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbApp2Name
        '
        Me.cmbApp2Name.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbApp2Name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbApp2Name.FormattingEnabled = True
        Me.cmbApp2Name.Location = New System.Drawing.Point(61, 264)
        Me.cmbApp2Name.Name = "cmbApp2Name"
        Me.cmbApp2Name.Size = New System.Drawing.Size(225, 23)
        Me.cmbApp2Name.TabIndex = 284
        '
        'txtApp2Date
        '
        Me.txtApp2Date.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtApp2Date.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApp2Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp2Date.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp2Date.ForeColor = System.Drawing.Color.Black
        Me.txtApp2Date.Location = New System.Drawing.Point(61, 239)
        Me.txtApp2Date.Name = "txtApp2Date"
        Me.txtApp2Date.Size = New System.Drawing.Size(225, 23)
        Me.txtApp2Date.TabIndex = 283
        Me.txtApp2Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApp2Date.UseCompatibleTextRendering = True
        '
        'lblApp2Position
        '
        Me.lblApp2Position.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp2Position.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp2Position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp2Position.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp2Position.ForeColor = System.Drawing.Color.Black
        Me.lblApp2Position.Location = New System.Drawing.Point(2, 289)
        Me.lblApp2Position.Name = "lblApp2Position"
        Me.lblApp2Position.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp2Position.Size = New System.Drawing.Size(60, 23)
        Me.lblApp2Position.TabIndex = 281
        Me.lblApp2Position.Text = "Position"
        Me.lblApp2Position.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApp2Date
        '
        Me.lblApp2Date.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp2Date.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp2Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp2Date.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp2Date.ForeColor = System.Drawing.Color.Black
        Me.lblApp2Date.Location = New System.Drawing.Point(2, 239)
        Me.lblApp2Date.Name = "lblApp2Date"
        Me.lblApp2Date.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp2Date.Size = New System.Drawing.Size(60, 23)
        Me.lblApp2Date.TabIndex = 280
        Me.lblApp2Date.Text = "Date"
        Me.lblApp2Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApp2Status
        '
        Me.lblApp2Status.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp2Status.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp2Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp2Status.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp2Status.ForeColor = System.Drawing.Color.Black
        Me.lblApp2Status.Location = New System.Drawing.Point(2, 214)
        Me.lblApp2Status.Name = "lblApp2Status"
        Me.lblApp2Status.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp2Status.Size = New System.Drawing.Size(60, 23)
        Me.lblApp2Status.TabIndex = 279
        Me.lblApp2Status.Text = "Status"
        Me.lblApp2Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbApp2Status
        '
        Me.cmbApp2Status.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbApp2Status.BackColor = System.Drawing.SystemColors.Window
        Me.cmbApp2Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbApp2Status.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbApp2Status.Location = New System.Drawing.Point(61, 214)
        Me.cmbApp2Status.Name = "cmbApp2Status"
        Me.cmbApp2Status.Size = New System.Drawing.Size(225, 23)
        Me.cmbApp2Status.TabIndex = 278
        '
        'txtApp3Remarks
        '
        Me.txtApp3Remarks.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtApp3Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp3Remarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp3Remarks.Location = New System.Drawing.Point(2, 124)
        Me.txtApp3Remarks.Multiline = True
        Me.txtApp3Remarks.Name = "txtApp3Remarks"
        Me.txtApp3Remarks.Size = New System.Drawing.Size(284, 88)
        Me.txtApp3Remarks.TabIndex = 277
        '
        'lblApp3Remarks
        '
        Me.lblApp3Remarks.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp3Remarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp3Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp3Remarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp3Remarks.ForeColor = System.Drawing.Color.Black
        Me.lblApp3Remarks.Location = New System.Drawing.Point(2, 102)
        Me.lblApp3Remarks.Name = "lblApp3Remarks"
        Me.lblApp3Remarks.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp3Remarks.Size = New System.Drawing.Size(284, 23)
        Me.lblApp3Remarks.TabIndex = 276
        Me.lblApp3Remarks.Text = "Remarks"
        Me.lblApp3Remarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApp3Position
        '
        Me.txtApp3Position.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtApp3Position.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApp3Position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp3Position.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp3Position.ForeColor = System.Drawing.Color.Black
        Me.txtApp3Position.Location = New System.Drawing.Point(61, 77)
        Me.txtApp3Position.Name = "txtApp3Position"
        Me.txtApp3Position.Size = New System.Drawing.Size(225, 23)
        Me.txtApp3Position.TabIndex = 275
        Me.txtApp3Position.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApp3Position.UseCompatibleTextRendering = True
        '
        'lblApp3Name
        '
        Me.lblApp3Name.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp3Name.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp3Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp3Name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp3Name.ForeColor = System.Drawing.Color.Black
        Me.lblApp3Name.Location = New System.Drawing.Point(2, 52)
        Me.lblApp3Name.Name = "lblApp3Name"
        Me.lblApp3Name.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp3Name.Size = New System.Drawing.Size(60, 23)
        Me.lblApp3Name.TabIndex = 272
        Me.lblApp3Name.Text = "Name"
        Me.lblApp3Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbApp3Name
        '
        Me.cmbApp3Name.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbApp3Name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbApp3Name.FormattingEnabled = True
        Me.cmbApp3Name.Location = New System.Drawing.Point(61, 52)
        Me.cmbApp3Name.Name = "cmbApp3Name"
        Me.cmbApp3Name.Size = New System.Drawing.Size(225, 23)
        Me.cmbApp3Name.TabIndex = 274
        '
        'txtApp3Date
        '
        Me.txtApp3Date.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtApp3Date.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApp3Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp3Date.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp3Date.ForeColor = System.Drawing.Color.Black
        Me.txtApp3Date.Location = New System.Drawing.Point(61, 27)
        Me.txtApp3Date.Name = "txtApp3Date"
        Me.txtApp3Date.Size = New System.Drawing.Size(225, 23)
        Me.txtApp3Date.TabIndex = 273
        Me.txtApp3Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApp3Date.UseCompatibleTextRendering = True
        '
        'lblApp3Position
        '
        Me.lblApp3Position.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp3Position.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp3Position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp3Position.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp3Position.ForeColor = System.Drawing.Color.Black
        Me.lblApp3Position.Location = New System.Drawing.Point(2, 77)
        Me.lblApp3Position.Name = "lblApp3Position"
        Me.lblApp3Position.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp3Position.Size = New System.Drawing.Size(60, 23)
        Me.lblApp3Position.TabIndex = 271
        Me.lblApp3Position.Text = "Position"
        Me.lblApp3Position.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApp3Date
        '
        Me.lblApp3Date.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp3Date.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp3Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp3Date.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp3Date.ForeColor = System.Drawing.Color.Black
        Me.lblApp3Date.Location = New System.Drawing.Point(2, 27)
        Me.lblApp3Date.Name = "lblApp3Date"
        Me.lblApp3Date.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp3Date.Size = New System.Drawing.Size(60, 23)
        Me.lblApp3Date.TabIndex = 270
        Me.lblApp3Date.Text = "Date"
        Me.lblApp3Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApp3Status
        '
        Me.lblApp3Status.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblApp3Status.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp3Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp3Status.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp3Status.ForeColor = System.Drawing.Color.Black
        Me.lblApp3Status.Location = New System.Drawing.Point(2, 2)
        Me.lblApp3Status.Name = "lblApp3Status"
        Me.lblApp3Status.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp3Status.Size = New System.Drawing.Size(60, 23)
        Me.lblApp3Status.TabIndex = 269
        Me.lblApp3Status.Text = "Status"
        Me.lblApp3Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbApp3Status
        '
        Me.cmbApp3Status.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbApp3Status.BackColor = System.Drawing.SystemColors.Window
        Me.cmbApp3Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbApp3Status.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbApp3Status.Location = New System.Drawing.Point(61, 2)
        Me.cmbApp3Status.Name = "cmbApp3Status"
        Me.cmbApp3Status.Size = New System.Drawing.Size(225, 23)
        Me.cmbApp3Status.TabIndex = 268
        '
        'cmbRoutingStatus
        '
        Me.cmbRoutingStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRoutingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRoutingStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbRoutingStatus.FormattingEnabled = True
        Me.cmbRoutingStatus.Location = New System.Drawing.Point(409, 0)
        Me.cmbRoutingStatus.Name = "cmbRoutingStatus"
        Me.cmbRoutingStatus.Size = New System.Drawing.Size(250, 23)
        Me.cmbRoutingStatus.TabIndex = 588
        Me.cmbRoutingStatus.Visible = False
        '
        'txtModifiedBy
        '
        Me.txtModifiedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedBy.Location = New System.Drawing.Point(390, 580)
        Me.txtModifiedBy.Name = "txtModifiedBy"
        Me.txtModifiedBy.Size = New System.Drawing.Size(280, 23)
        Me.txtModifiedBy.TabIndex = 592
        Me.txtModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedBy.UseCompatibleTextRendering = True
        Me.txtModifiedBy.Visible = False
        '
        'txtModifiedDate
        '
        Me.txtModifiedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedDate.Location = New System.Drawing.Point(390, 605)
        Me.txtModifiedDate.Name = "txtModifiedDate"
        Me.txtModifiedDate.Size = New System.Drawing.Size(280, 23)
        Me.txtModifiedDate.TabIndex = 591
        Me.txtModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedDate.UseCompatibleTextRendering = True
        Me.txtModifiedDate.Visible = False
        '
        'lblModifiedDate
        '
        Me.lblModifiedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedDate.Location = New System.Drawing.Point(291, 605)
        Me.lblModifiedDate.Name = "lblModifiedDate"
        Me.lblModifiedDate.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblModifiedDate.Size = New System.Drawing.Size(100, 23)
        Me.lblModifiedDate.TabIndex = 590
        Me.lblModifiedDate.Text = "Modified Date"
        Me.lblModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblModifiedDate.Visible = False
        '
        'lblModifiedBy
        '
        Me.lblModifiedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedBy.Location = New System.Drawing.Point(291, 580)
        Me.lblModifiedBy.Name = "lblModifiedBy"
        Me.lblModifiedBy.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblModifiedBy.Size = New System.Drawing.Size(100, 23)
        Me.lblModifiedBy.TabIndex = 589
        Me.lblModifiedBy.Text = "Modified By"
        Me.lblModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblModifiedBy.Visible = False
        '
        'lblSpareParts
        '
        Me.lblSpareParts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSpareParts.BackColor = System.Drawing.SystemColors.Control
        Me.lblSpareParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSpareParts.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSpareParts.ForeColor = System.Drawing.Color.Black
        Me.lblSpareParts.Location = New System.Drawing.Point(672, 130)
        Me.lblSpareParts.Name = "lblSpareParts"
        Me.lblSpareParts.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblSpareParts.Size = New System.Drawing.Size(554, 24)
        Me.lblSpareParts.TabIndex = 605
        Me.lblSpareParts.Text = "Parts Issued"
        Me.lblSpareParts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvPartDetail
        '
        Me.dgvPartDetail.AllowUserToAddRows = False
        Me.dgvPartDetail.AllowUserToDeleteRows = False
        Me.dgvPartDetail.AllowUserToResizeColumns = False
        Me.dgvPartDetail.AllowUserToResizeRows = False
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvPartDetail.ColumnHeadersHeight = 22
        Me.dgvPartDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPartDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPartId, Me.ColQty})
        Me.dgvPartDetail.Location = New System.Drawing.Point(672, 153)
        Me.dgvPartDetail.MultiSelect = False
        Me.dgvPartDetail.Name = "dgvPartDetail"
        Me.dgvPartDetail.ReadOnly = True
        Me.dgvPartDetail.RowHeadersVisible = False
        Me.dgvPartDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPartDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartDetail.Size = New System.Drawing.Size(554, 96)
        Me.dgvPartDetail.TabIndex = 606
        Me.dgvPartDetail.TabStop = False
        '
        'ColPartId
        '
        Me.ColPartId.DataPropertyName = "PartId"
        Me.ColPartId.HeaderText = "Part ID"
        Me.ColPartId.Name = "ColPartId"
        Me.ColPartId.ReadOnly = True
        Me.ColPartId.Visible = False
        '
        'ColQty
        '
        Me.ColQty.DataPropertyName = "Qty"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColQty.DefaultCellStyle = DataGridViewCellStyle16
        Me.ColQty.HeaderText = "Qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.ReadOnly = True
        Me.ColQty.Width = 50
        '
        'btnEditLog
        '
        Me.btnEditLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEditLog.DefaultScheme = False
        Me.btnEditLog.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnEditLog.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnEditLog.Hint = "Add activity log"
        Me.btnEditLog.Location = New System.Drawing.Point(1062, 2)
        Me.btnEditLog.Name = "btnEditLog"
        Me.btnEditLog.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnEditLog.Size = New System.Drawing.Size(80, 26)
        Me.btnEditLog.TabIndex = 607
        Me.btnEditLog.TabStop = False
        Me.btnEditLog.Text = "Edit"
        '
        'MntTrxDetailJig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1230, 628)
        Me.Controls.Add(Me.btnEditLog)
        Me.Controls.Add(Me.lblSpareParts)
        Me.Controls.Add(Me.dgvPartDetail)
        Me.Controls.Add(Me.lbl4M)
        Me.Controls.Add(Me.lblChecksheet)
        Me.Controls.Add(Me.btnRemove4M)
        Me.Controls.Add(Me.btnView4M)
        Me.Controls.Add(Me.btnRemoveChecksheet)
        Me.Controls.Add(Me.txt4M)
        Me.Controls.Add(Me.txtChecksheet)
        Me.Controls.Add(Me.btnViewChecksheet)
        Me.Controls.Add(Me.txtModifiedBy)
        Me.Controls.Add(Me.txtModifiedDate)
        Me.Controls.Add(Me.lblModifiedDate)
        Me.Controls.Add(Me.lblModifiedBy)
        Me.Controls.Add(Me.rdWithoutChecker)
        Me.Controls.Add(Me.rdWithChecker)
        Me.Controls.Add(Me.lblJigName)
        Me.Controls.Add(Me.cmbJigName)
        Me.Controls.Add(Me.txtScheduleWeek)
        Me.Controls.Add(Me.lblScheduleWeek)
        Me.Controls.Add(Me.lblScheduleMonth)
        Me.Controls.Add(Me.txtScheduleMonth)
        Me.Controls.Add(Me.txtArea)
        Me.Controls.Add(Me.lblPic)
        Me.Controls.Add(Me.lblJigPart)
        Me.Controls.Add(Me.lblDowntimeSubStatus)
        Me.Controls.Add(Me.cmbDowntimeSubStatus)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.lblDowntimeStatus)
        Me.Controls.Add(Me.lblRootCause)
        Me.Controls.Add(Me.txtRootCause)
        Me.Controls.Add(Me.txtRoutingStatus)
        Me.Controls.Add(Me.btnDeleteLog)
        Me.Controls.Add(Me.btnAddLog)
        Me.Controls.Add(Me.lblActivityLog)
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
        Me.Controls.Add(Me.txtJoRequestor)
        Me.Controls.Add(Me.lblJoRequestor)
        Me.Controls.Add(Me.txtJoNumber)
        Me.Controls.Add(Me.lblJoNumber)
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
        Me.Controls.Add(Me.pnlApprovers)
        Me.Controls.Add(Me.pnlJigPart)
        Me.Controls.Add(Me.cmbRoutingStatus)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntTrxDetailJig"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Activity Details"
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlImage.ResumeLayout(False)
        CType(Me.dgvPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlApprovers.ResumeLayout(False)
        Me.pnlApprovers.PerformLayout()
        CType(Me.dgvPartDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRuntimeAccumulated As System.Windows.Forms.Label
    Friend WithEvents lblRuntimeAccumulated As System.Windows.Forms.Label
    Friend WithEvents txtDowntimeAccumulated As System.Windows.Forms.Label
    Friend WithEvents lblDowntimeAccumulated As System.Windows.Forms.Label
    Friend WithEvents txtTransactionDate As System.Windows.Forms.Label
    Friend WithEvents lblTransactionDate As System.Windows.Forms.Label
    Friend WithEvents txtImageName As System.Windows.Forms.Label
    Friend WithEvents cmbTransactionStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblTransactionStatus As System.Windows.Forms.Label
    Friend WithEvents lblRoutingStatus As System.Windows.Forms.Label
    Friend WithEvents lblJigName As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents cmbDowntimeStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblDowntimeStatus As System.Windows.Forms.Label
    Friend WithEvents txtProblem As System.Windows.Forms.TextBox
    Friend WithEvents lblProblem As System.Windows.Forms.Label
    Friend WithEvents txtActionTaken As System.Windows.Forms.TextBox
    Friend WithEvents lblActionTaken As System.Windows.Forms.Label
    Friend WithEvents lblJoNumber As System.Windows.Forms.Label
    Friend WithEvents txtJoNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblJoRequestor As System.Windows.Forms.Label
    Friend WithEvents txtJoRequestor As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteLog As PinkieControls.ButtonXP
    Friend WithEvents btnAddLog As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents lblImageAttachment As System.Windows.Forms.Label
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Friend WithEvents btnBrowseImage As PinkieControls.ButtonXP
    Friend WithEvents btnRemoveImage As PinkieControls.ButtonXP
    Friend WithEvents pnlImage As System.Windows.Forms.Panel
    Friend WithEvents lblPic As System.Windows.Forms.Label
    Friend WithEvents dgvPic As System.Windows.Forms.DataGridView
    Friend WithEvents lblActivityLog As System.Windows.Forms.Label
    Friend WithEvents dgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents txtRoutingStatus As System.Windows.Forms.Label
    Friend WithEvents ofdImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblRootCause As System.Windows.Forms.Label
    Friend WithEvents txtRootCause As System.Windows.Forms.TextBox
    Friend WithEvents ColIsSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblChecksheet As Label
    Friend WithEvents lblScheduleMonth As Label
    Friend WithEvents lblScheduleWeek As Label
    Friend WithEvents btnViewChecksheet As PinkieControls.ButtonXP
    Friend WithEvents btnViewImage As PinkieControls.ButtonXP
    Friend WithEvents txtArea As Label
    Friend WithEvents txtScheduleMonth As TextBox
    Friend WithEvents txtScheduleWeek As TextBox
    Friend WithEvents cmbJigName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblJigPart As Label
    Friend WithEvents rdWithChecker As RadioButton
    Friend WithEvents rdWithoutChecker As RadioButton
    Friend WithEvents pnlJigPart As Panel
    Friend WithEvents cmbDowntimeSubStatus As ComboBox
    Friend WithEvents lblDowntimeSubStatus As Label
    Friend WithEvents txtChecksheet As Be.Windows.Forms.RichTextBoxEx
    Friend WithEvents lbl4M As Label
    Friend WithEvents txt4M As Be.Windows.Forms.RichTextBoxEx
    Friend WithEvents btnRemoveChecksheet As PinkieControls.ButtonXP
    Friend WithEvents btnRemove4M As PinkieControls.ButtonXP
    Friend WithEvents btnView4M As PinkieControls.ButtonXP
    Friend WithEvents ColTrxDetailId As DataGridViewTextBoxColumn
    Friend WithEvents ColTrxId As DataGridViewTextBoxColumn
    Friend WithEvents ColTrxDate As DataGridViewTextBoxColumn
    Friend WithEvents ColUserIdLog As DataGridViewTextBoxColumn
    Friend WithEvents ColShiftId As DataGridViewTextBoxColumn
    Friend WithEvents ColTrxFrom As DataGridViewTextBoxColumn
    Friend WithEvents ColTrxTo As DataGridViewTextBoxColumn
    Friend WithEvents ColElapsedTime As DataGridViewTextBoxColumn
    Friend WithEvents pnlApprovers As Panel
    Friend WithEvents txtApp1Remarks As TextBox
    Friend WithEvents lblApp1Remarks As Label
    Friend WithEvents txtApp1Position As Label
    Friend WithEvents lblApp1Name As Label
    Friend WithEvents cmbApp1Name As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtApp1Date As Label
    Friend WithEvents lblApp1Position As Label
    Friend WithEvents lblApp1Date As Label
    Friend WithEvents lblApp1Status As Label
    Friend WithEvents cmbApp1Status As ComboBox
    Friend WithEvents txtApp2Remarks As TextBox
    Friend WithEvents lblApp2Remarks As Label
    Friend WithEvents txtApp2Position As Label
    Friend WithEvents lblApp2Name As Label
    Friend WithEvents cmbApp2Name As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtApp2Date As Label
    Friend WithEvents lblApp2Position As Label
    Friend WithEvents lblApp2Date As Label
    Friend WithEvents lblApp2Status As Label
    Friend WithEvents cmbApp2Status As ComboBox
    Friend WithEvents txtApp3Remarks As TextBox
    Friend WithEvents lblApp3Remarks As Label
    Friend WithEvents txtApp3Position As Label
    Friend WithEvents lblApp3Name As Label
    Friend WithEvents cmbApp3Name As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtApp3Date As Label
    Friend WithEvents lblApp3Position As Label
    Friend WithEvents lblApp3Date As Label
    Friend WithEvents lblApp3Status As Label
    Friend WithEvents cmbApp3Status As ComboBox
    Friend WithEvents cmbRoutingStatus As ComboBox
    Friend WithEvents txtModifiedBy As Label
    Friend WithEvents txtModifiedDate As Label
    Friend WithEvents lblModifiedDate As Label
    Friend WithEvents lblModifiedBy As Label
    Friend WithEvents lblSpareParts As Label
    Friend WithEvents dgvPartDetail As DataGridView
    Friend WithEvents ColPartId As DataGridViewTextBoxColumn
    Friend WithEvents ColQty As DataGridViewTextBoxColumn
    Friend WithEvents btnEditLog As PinkieControls.ButtonXP
End Class
