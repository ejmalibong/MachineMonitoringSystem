<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FacTrxDetailOth
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.lblArea = New System.Windows.Forms.Label()
        Me.txtProblem = New System.Windows.Forms.TextBox()
        Me.lblProblem = New System.Windows.Forms.Label()
        Me.txtActionTaken = New System.Windows.Forms.TextBox()
        Me.lblActionTaken = New System.Windows.Forms.Label()
        Me.lblPartsReplaced = New System.Windows.Forms.Label()
        Me.txtPartsReplaced = New System.Windows.Forms.TextBox()
        Me.txtPartsNo = New System.Windows.Forms.TextBox()
        Me.lblPartsNo = New System.Windows.Forms.Label()
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
        Me.lblAttachment = New System.Windows.Forms.Label()
        Me.btnRemoveChecksheet = New PinkieControls.ButtonXP()
        Me.btnBrowseChecksheet = New PinkieControls.ButtonXP()
        Me.btnViewChecksheet = New PinkieControls.ButtonXP()
        Me.txtAttachment = New System.Windows.Forms.Label()
        Me.progBar = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.cmbArea = New SergeUtils.EasyCompletionComboBox()
        Me.ofdAttachment = New System.Windows.Forms.OpenFileDialog()
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.txtModifiedBy = New System.Windows.Forms.Label()
        Me.txtModifiedDate = New System.Windows.Forms.Label()
        Me.lblModifiedDate = New System.Windows.Forms.Label()
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.cmbRoutingStatus = New System.Windows.Forms.ComboBox()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlImage.SuspendLayout()
        CType(Me.dgvPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlApprovers.SuspendLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRuntimeAccumulated
        '
        Me.txtRuntimeAccumulated.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtRuntimeAccumulated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuntimeAccumulated.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRuntimeAccumulated.ForeColor = System.Drawing.Color.Black
        Me.txtRuntimeAccumulated.Location = New System.Drawing.Point(782, 173)
        Me.txtRuntimeAccumulated.Name = "txtRuntimeAccumulated"
        Me.txtRuntimeAccumulated.Size = New System.Drawing.Size(181, 25)
        Me.txtRuntimeAccumulated.TabIndex = 215
        Me.txtRuntimeAccumulated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtRuntimeAccumulated.UseCompatibleTextRendering = True
        '
        'lblRuntimeAccumulated
        '
        Me.lblRuntimeAccumulated.BackColor = System.Drawing.SystemColors.Control
        Me.lblRuntimeAccumulated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRuntimeAccumulated.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRuntimeAccumulated.ForeColor = System.Drawing.Color.Black
        Me.lblRuntimeAccumulated.Location = New System.Drawing.Point(683, 173)
        Me.lblRuntimeAccumulated.Name = "lblRuntimeAccumulated"
        Me.lblRuntimeAccumulated.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblRuntimeAccumulated.Size = New System.Drawing.Size(100, 25)
        Me.lblRuntimeAccumulated.TabIndex = 214
        Me.lblRuntimeAccumulated.Text = "Total Runtime"
        Me.lblRuntimeAccumulated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDowntimeAccumulated
        '
        Me.txtDowntimeAccumulated.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtDowntimeAccumulated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDowntimeAccumulated.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDowntimeAccumulated.ForeColor = System.Drawing.Color.Black
        Me.txtDowntimeAccumulated.Location = New System.Drawing.Point(1081, 173)
        Me.txtDowntimeAccumulated.Name = "txtDowntimeAccumulated"
        Me.txtDowntimeAccumulated.Size = New System.Drawing.Size(157, 25)
        Me.txtDowntimeAccumulated.TabIndex = 217
        Me.txtDowntimeAccumulated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtDowntimeAccumulated.UseCompatibleTextRendering = True
        '
        'lblDowntimeAccumulated
        '
        Me.lblDowntimeAccumulated.BackColor = System.Drawing.SystemColors.Control
        Me.lblDowntimeAccumulated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDowntimeAccumulated.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDowntimeAccumulated.ForeColor = System.Drawing.Color.Black
        Me.lblDowntimeAccumulated.Location = New System.Drawing.Point(962, 173)
        Me.lblDowntimeAccumulated.Name = "lblDowntimeAccumulated"
        Me.lblDowntimeAccumulated.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblDowntimeAccumulated.Size = New System.Drawing.Size(120, 25)
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
        Me.txtTransactionDate.Location = New System.Drawing.Point(431, 50)
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
        Me.lblTransactionDate.Location = New System.Drawing.Point(302, 50)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblTransactionDate.Size = New System.Drawing.Size(130, 23)
        Me.lblTransactionDate.TabIndex = 241
        Me.lblTransactionDate.Text = "Activity Date"
        Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtImageName
        '
        Me.txtImageName.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtImageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImageName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtImageName.ForeColor = System.Drawing.Color.Black
        Me.txtImageName.Location = New System.Drawing.Point(683, 509)
        Me.txtImageName.Name = "txtImageName"
        Me.txtImageName.Size = New System.Drawing.Size(280, 23)
        Me.txtImageName.TabIndex = 245
        Me.txtImageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtImageName.UseCompatibleTextRendering = True
        '
        'cmbTransactionStatus
        '
        Me.cmbTransactionStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTransactionStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransactionStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbTransactionStatus.Location = New System.Drawing.Point(431, 25)
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
        Me.lblTransactionStatus.Location = New System.Drawing.Point(302, 25)
        Me.lblTransactionStatus.Name = "lblTransactionStatus"
        Me.lblTransactionStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblTransactionStatus.Size = New System.Drawing.Size(130, 23)
        Me.lblTransactionStatus.TabIndex = 211
        Me.lblTransactionStatus.Text = "Activity Status *"
        Me.lblTransactionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRoutingStatus
        '
        Me.lblRoutingStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblRoutingStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRoutingStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRoutingStatus.ForeColor = System.Drawing.Color.Black
        Me.lblRoutingStatus.Location = New System.Drawing.Point(302, 0)
        Me.lblRoutingStatus.Name = "lblRoutingStatus"
        Me.lblRoutingStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblRoutingStatus.Size = New System.Drawing.Size(130, 23)
        Me.lblRoutingStatus.TabIndex = 213
        Me.lblRoutingStatus.Text = "Routing Status"
        Me.lblRoutingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblArea
        '
        Me.lblArea.BackColor = System.Drawing.SystemColors.Control
        Me.lblArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblArea.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblArea.ForeColor = System.Drawing.Color.Black
        Me.lblArea.Location = New System.Drawing.Point(302, 75)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblArea.Size = New System.Drawing.Size(130, 23)
        Me.lblArea.TabIndex = 221
        Me.lblArea.Text = "Area *"
        Me.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProblem
        '
        Me.txtProblem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProblem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtProblem.Location = New System.Drawing.Point(302, 122)
        Me.txtProblem.Multiline = True
        Me.txtProblem.Name = "txtProblem"
        Me.txtProblem.Size = New System.Drawing.Size(379, 95)
        Me.txtProblem.TabIndex = 7
        '
        'lblProblem
        '
        Me.lblProblem.BackColor = System.Drawing.SystemColors.Control
        Me.lblProblem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProblem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblProblem.ForeColor = System.Drawing.Color.Black
        Me.lblProblem.Location = New System.Drawing.Point(302, 100)
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
        Me.txtActionTaken.Location = New System.Drawing.Point(302, 360)
        Me.txtActionTaken.Multiline = True
        Me.txtActionTaken.Name = "txtActionTaken"
        Me.txtActionTaken.Size = New System.Drawing.Size(379, 97)
        Me.txtActionTaken.TabIndex = 9
        '
        'lblActionTaken
        '
        Me.lblActionTaken.BackColor = System.Drawing.SystemColors.Control
        Me.lblActionTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActionTaken.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblActionTaken.ForeColor = System.Drawing.Color.Black
        Me.lblActionTaken.Location = New System.Drawing.Point(302, 338)
        Me.lblActionTaken.Name = "lblActionTaken"
        Me.lblActionTaken.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblActionTaken.Size = New System.Drawing.Size(379, 23)
        Me.lblActionTaken.TabIndex = 229
        Me.lblActionTaken.Text = "Action Taken *"
        Me.lblActionTaken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPartsReplaced
        '
        Me.lblPartsReplaced.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartsReplaced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartsReplaced.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPartsReplaced.ForeColor = System.Drawing.Color.Black
        Me.lblPartsReplaced.Location = New System.Drawing.Point(302, 459)
        Me.lblPartsReplaced.Name = "lblPartsReplaced"
        Me.lblPartsReplaced.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblPartsReplaced.Size = New System.Drawing.Size(130, 23)
        Me.lblPartsReplaced.TabIndex = 231
        Me.lblPartsReplaced.Text = "Parts Replaced"
        Me.lblPartsReplaced.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartsReplaced
        '
        Me.txtPartsReplaced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartsReplaced.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartsReplaced.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPartsReplaced.Location = New System.Drawing.Point(431, 459)
        Me.txtPartsReplaced.Name = "txtPartsReplaced"
        Me.txtPartsReplaced.Size = New System.Drawing.Size(250, 23)
        Me.txtPartsReplaced.TabIndex = 10
        '
        'txtPartsNo
        '
        Me.txtPartsNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartsNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartsNo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPartsNo.Location = New System.Drawing.Point(431, 484)
        Me.txtPartsNo.Name = "txtPartsNo"
        Me.txtPartsNo.Size = New System.Drawing.Size(250, 23)
        Me.txtPartsNo.TabIndex = 11
        '
        'lblPartsNo
        '
        Me.lblPartsNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblPartsNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartsNo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPartsNo.ForeColor = System.Drawing.Color.Black
        Me.lblPartsNo.Location = New System.Drawing.Point(302, 484)
        Me.lblPartsNo.Name = "lblPartsNo"
        Me.lblPartsNo.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblPartsNo.Size = New System.Drawing.Size(130, 23)
        Me.lblPartsNo.TabIndex = 233
        Me.lblPartsNo.Text = "Parts No"
        Me.lblPartsNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblJoNumber
        '
        Me.lblJoNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblJoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJoNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJoNumber.ForeColor = System.Drawing.Color.Black
        Me.lblJoNumber.Location = New System.Drawing.Point(302, 509)
        Me.lblJoNumber.Name = "lblJoNumber"
        Me.lblJoNumber.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblJoNumber.Size = New System.Drawing.Size(130, 23)
        Me.lblJoNumber.TabIndex = 235
        Me.lblJoNumber.Text = "Job Order No"
        Me.lblJoNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtJoNumber
        '
        Me.txtJoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJoNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJoNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtJoNumber.Location = New System.Drawing.Point(431, 509)
        Me.txtJoNumber.MaxLength = 15
        Me.txtJoNumber.Name = "txtJoNumber"
        Me.txtJoNumber.Size = New System.Drawing.Size(250, 23)
        Me.txtJoNumber.TabIndex = 12
        '
        'lblJoRequestor
        '
        Me.lblJoRequestor.BackColor = System.Drawing.SystemColors.Control
        Me.lblJoRequestor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJoRequestor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblJoRequestor.ForeColor = System.Drawing.Color.Black
        Me.lblJoRequestor.Location = New System.Drawing.Point(302, 534)
        Me.lblJoRequestor.Name = "lblJoRequestor"
        Me.lblJoRequestor.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblJoRequestor.Size = New System.Drawing.Size(130, 23)
        Me.lblJoRequestor.TabIndex = 237
        Me.lblJoRequestor.Text = "Job Order Requestor"
        Me.lblJoRequestor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtJoRequestor
        '
        Me.txtJoRequestor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJoRequestor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJoRequestor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtJoRequestor.Location = New System.Drawing.Point(431, 534)
        Me.txtJoRequestor.Name = "txtJoRequestor"
        Me.txtJoRequestor.Size = New System.Drawing.Size(250, 23)
        Me.txtJoRequestor.TabIndex = 13
        '
        'btnRemoveRow
        '
        Me.btnRemoveRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemoveRow.DefaultScheme = False
        Me.btnRemoveRow.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemoveRow.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnRemoveRow.Hint = "Delete selected activity log"
        Me.btnRemoveRow.Location = New System.Drawing.Point(1150, 2)
        Me.btnRemoveRow.Name = "btnRemoveRow"
        Me.btnRemoveRow.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemoveRow.Size = New System.Drawing.Size(85, 28)
        Me.btnRemoveRow.TabIndex = 15
        Me.btnRemoveRow.TabStop = False
        Me.btnRemoveRow.Text = "Delete Row"
        '
        'btnAddRow
        '
        Me.btnAddRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAddRow.DefaultScheme = False
        Me.btnAddRow.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAddRow.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnAddRow.Hint = "Add activity log"
        Me.btnAddRow.Location = New System.Drawing.Point(1064, 2)
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAddRow.Size = New System.Drawing.Size(85, 28)
        Me.btnAddRow.TabIndex = 14
        Me.btnAddRow.TabStop = False
        Me.btnAddRow.Text = "Add Row"
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
        Me.btnClose.Location = New System.Drawing.Point(1147, 599)
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
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnDelete.Hint = "Delete record"
        Me.btnDelete.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Erase_16_x_16
        Me.btnDelete.Location = New System.Drawing.Point(1053, 599)
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
        Me.btnCancel.Location = New System.Drawing.Point(959, 599)
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
        Me.btnSave.Location = New System.Drawing.Point(864, 599)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 250
        Me.btnSave.TabStop = False
        Me.btnSave.Text = " Save"
        '
        'lblImageAttachment
        '
        Me.lblImageAttachment.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImageAttachment.ForeColor = System.Drawing.Color.Black
        Me.lblImageAttachment.Location = New System.Drawing.Point(683, 200)
        Me.lblImageAttachment.Name = "lblImageAttachment"
        Me.lblImageAttachment.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblImageAttachment.Size = New System.Drawing.Size(280, 24)
        Me.lblImageAttachment.TabIndex = 243
        Me.lblImageAttachment.Text = "Image *"
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
        Me.picImage.Size = New System.Drawing.Size(272, 249)
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
        Me.btnBrowseImage.Location = New System.Drawing.Point(115, 253)
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
        Me.btnRemoveImage.Location = New System.Drawing.Point(196, 253)
        Me.btnRemoveImage.Name = "btnRemoveImage"
        Me.btnRemoveImage.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemoveImage.Size = New System.Drawing.Size(80, 28)
        Me.btnRemoveImage.TabIndex = 2
        Me.btnRemoveImage.TabStop = False
        Me.btnRemoveImage.Text = "Remove"
        '
        'pnlImage
        '
        Me.pnlImage.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImage.Controls.Add(Me.btnViewImage)
        Me.pnlImage.Controls.Add(Me.btnRemoveImage)
        Me.pnlImage.Controls.Add(Me.btnBrowseImage)
        Me.pnlImage.Controls.Add(Me.picImage)
        Me.pnlImage.Location = New System.Drawing.Point(683, 223)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(280, 284)
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
        Me.btnViewImage.Location = New System.Drawing.Point(2, 253)
        Me.btnViewImage.Name = "btnViewImage"
        Me.btnViewImage.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnViewImage.Size = New System.Drawing.Size(28, 28)
        Me.btnViewImage.TabIndex = 0
        Me.btnViewImage.TabStop = False
        '
        'lblPic
        '
        Me.lblPic.BackColor = System.Drawing.SystemColors.Control
        Me.lblPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPic.ForeColor = System.Drawing.Color.Black
        Me.lblPic.Location = New System.Drawing.Point(965, 200)
        Me.lblPic.Name = "lblPic"
        Me.lblPic.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblPic.Size = New System.Drawing.Size(273, 24)
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
        Me.dgvPic.ColumnHeadersHeight = 22
        Me.dgvPic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPic.ColumnHeadersVisible = False
        Me.dgvPic.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIsSelected, Me.ColUserId, Me.ColUserName})
        Me.dgvPic.Location = New System.Drawing.Point(965, 223)
        Me.dgvPic.MultiSelect = False
        Me.dgvPic.Name = "dgvPic"
        Me.dgvPic.RowHeadersVisible = False
        Me.dgvPic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPic.Size = New System.Drawing.Size(273, 309)
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
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColUserName.DefaultCellStyle = DataGridViewCellStyle13
        Me.ColUserName.HeaderText = "NickName"
        Me.ColUserName.Name = "ColUserName"
        Me.ColUserName.ReadOnly = True
        Me.ColUserName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'lblActivityLog
        '
        Me.lblActivityLog.BackColor = System.Drawing.SystemColors.Control
        Me.lblActivityLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActivityLog.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblActivityLog.ForeColor = System.Drawing.Color.Black
        Me.lblActivityLog.Location = New System.Drawing.Point(683, 0)
        Me.lblActivityLog.Name = "lblActivityLog"
        Me.lblActivityLog.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblActivityLog.Size = New System.Drawing.Size(555, 32)
        Me.lblActivityLog.TabIndex = 279
        Me.lblActivityLog.Text = "Activity Log *"
        Me.lblActivityLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.pnlApprovers.Size = New System.Drawing.Size(300, 634)
        Me.pnlApprovers.TabIndex = 281
        '
        'txtApp1Remarks
        '
        Me.txtApp1Remarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApp1Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp1Remarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp1Remarks.Location = New System.Drawing.Point(2, 546)
        Me.txtApp1Remarks.Multiline = True
        Me.txtApp1Remarks.Name = "txtApp1Remarks"
        Me.txtApp1Remarks.Size = New System.Drawing.Size(294, 84)
        Me.txtApp1Remarks.TabIndex = 297
        '
        'lblApp1Remarks
        '
        Me.lblApp1Remarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp1Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp1Remarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp1Remarks.ForeColor = System.Drawing.Color.Black
        Me.lblApp1Remarks.Location = New System.Drawing.Point(2, 524)
        Me.lblApp1Remarks.Name = "lblApp1Remarks"
        Me.lblApp1Remarks.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp1Remarks.Size = New System.Drawing.Size(294, 23)
        Me.lblApp1Remarks.TabIndex = 296
        Me.lblApp1Remarks.Text = "Remarks"
        Me.lblApp1Remarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApp1Position
        '
        Me.txtApp1Position.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApp1Position.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApp1Position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp1Position.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp1Position.ForeColor = System.Drawing.Color.Black
        Me.txtApp1Position.Location = New System.Drawing.Point(61, 499)
        Me.txtApp1Position.Name = "txtApp1Position"
        Me.txtApp1Position.Size = New System.Drawing.Size(235, 23)
        Me.txtApp1Position.TabIndex = 295
        Me.txtApp1Position.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApp1Position.UseCompatibleTextRendering = True
        '
        'lblApp1Name
        '
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
        Me.cmbApp1Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbApp1Name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbApp1Name.FormattingEnabled = True
        Me.cmbApp1Name.Location = New System.Drawing.Point(61, 474)
        Me.cmbApp1Name.Name = "cmbApp1Name"
        Me.cmbApp1Name.Size = New System.Drawing.Size(235, 23)
        Me.cmbApp1Name.TabIndex = 294
        '
        'txtApp1Date
        '
        Me.txtApp1Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApp1Date.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApp1Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp1Date.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp1Date.ForeColor = System.Drawing.Color.Black
        Me.txtApp1Date.Location = New System.Drawing.Point(61, 449)
        Me.txtApp1Date.Name = "txtApp1Date"
        Me.txtApp1Date.Size = New System.Drawing.Size(235, 23)
        Me.txtApp1Date.TabIndex = 293
        Me.txtApp1Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApp1Date.UseCompatibleTextRendering = True
        '
        'lblApp1Position
        '
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
        Me.cmbApp1Status.BackColor = System.Drawing.SystemColors.Window
        Me.cmbApp1Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbApp1Status.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbApp1Status.Location = New System.Drawing.Point(61, 424)
        Me.cmbApp1Status.Name = "cmbApp1Status"
        Me.cmbApp1Status.Size = New System.Drawing.Size(235, 23)
        Me.cmbApp1Status.TabIndex = 288
        '
        'txtApp2Remarks
        '
        Me.txtApp2Remarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApp2Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp2Remarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp2Remarks.Location = New System.Drawing.Point(2, 336)
        Me.txtApp2Remarks.Multiline = True
        Me.txtApp2Remarks.Name = "txtApp2Remarks"
        Me.txtApp2Remarks.Size = New System.Drawing.Size(294, 86)
        Me.txtApp2Remarks.TabIndex = 287
        '
        'lblApp2Remarks
        '
        Me.lblApp2Remarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp2Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp2Remarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp2Remarks.ForeColor = System.Drawing.Color.Black
        Me.lblApp2Remarks.Location = New System.Drawing.Point(2, 314)
        Me.lblApp2Remarks.Name = "lblApp2Remarks"
        Me.lblApp2Remarks.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp2Remarks.Size = New System.Drawing.Size(294, 23)
        Me.lblApp2Remarks.TabIndex = 286
        Me.lblApp2Remarks.Text = "Remarks"
        Me.lblApp2Remarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApp2Position
        '
        Me.txtApp2Position.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApp2Position.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApp2Position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp2Position.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp2Position.ForeColor = System.Drawing.Color.Black
        Me.txtApp2Position.Location = New System.Drawing.Point(61, 289)
        Me.txtApp2Position.Name = "txtApp2Position"
        Me.txtApp2Position.Size = New System.Drawing.Size(235, 23)
        Me.txtApp2Position.TabIndex = 285
        Me.txtApp2Position.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApp2Position.UseCompatibleTextRendering = True
        '
        'lblApp2Name
        '
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
        Me.cmbApp2Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbApp2Name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbApp2Name.FormattingEnabled = True
        Me.cmbApp2Name.Location = New System.Drawing.Point(61, 264)
        Me.cmbApp2Name.Name = "cmbApp2Name"
        Me.cmbApp2Name.Size = New System.Drawing.Size(235, 23)
        Me.cmbApp2Name.TabIndex = 284
        '
        'txtApp2Date
        '
        Me.txtApp2Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApp2Date.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApp2Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp2Date.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp2Date.ForeColor = System.Drawing.Color.Black
        Me.txtApp2Date.Location = New System.Drawing.Point(61, 239)
        Me.txtApp2Date.Name = "txtApp2Date"
        Me.txtApp2Date.Size = New System.Drawing.Size(235, 23)
        Me.txtApp2Date.TabIndex = 283
        Me.txtApp2Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApp2Date.UseCompatibleTextRendering = True
        '
        'lblApp2Position
        '
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
        Me.cmbApp2Status.BackColor = System.Drawing.SystemColors.Window
        Me.cmbApp2Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbApp2Status.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbApp2Status.Location = New System.Drawing.Point(61, 214)
        Me.cmbApp2Status.Name = "cmbApp2Status"
        Me.cmbApp2Status.Size = New System.Drawing.Size(235, 23)
        Me.cmbApp2Status.TabIndex = 278
        '
        'txtApp3Remarks
        '
        Me.txtApp3Remarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApp3Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp3Remarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp3Remarks.Location = New System.Drawing.Point(2, 124)
        Me.txtApp3Remarks.Multiline = True
        Me.txtApp3Remarks.Name = "txtApp3Remarks"
        Me.txtApp3Remarks.Size = New System.Drawing.Size(294, 88)
        Me.txtApp3Remarks.TabIndex = 277
        '
        'lblApp3Remarks
        '
        Me.lblApp3Remarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblApp3Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApp3Remarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApp3Remarks.ForeColor = System.Drawing.Color.Black
        Me.lblApp3Remarks.Location = New System.Drawing.Point(2, 102)
        Me.lblApp3Remarks.Name = "lblApp3Remarks"
        Me.lblApp3Remarks.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblApp3Remarks.Size = New System.Drawing.Size(294, 23)
        Me.lblApp3Remarks.TabIndex = 276
        Me.lblApp3Remarks.Text = "Remarks"
        Me.lblApp3Remarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApp3Position
        '
        Me.txtApp3Position.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApp3Position.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApp3Position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp3Position.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp3Position.ForeColor = System.Drawing.Color.Black
        Me.txtApp3Position.Location = New System.Drawing.Point(61, 77)
        Me.txtApp3Position.Name = "txtApp3Position"
        Me.txtApp3Position.Size = New System.Drawing.Size(235, 23)
        Me.txtApp3Position.TabIndex = 275
        Me.txtApp3Position.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApp3Position.UseCompatibleTextRendering = True
        '
        'lblApp3Name
        '
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
        Me.cmbApp3Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbApp3Name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbApp3Name.FormattingEnabled = True
        Me.cmbApp3Name.Location = New System.Drawing.Point(61, 52)
        Me.cmbApp3Name.Name = "cmbApp3Name"
        Me.cmbApp3Name.Size = New System.Drawing.Size(235, 23)
        Me.cmbApp3Name.TabIndex = 274
        '
        'txtApp3Date
        '
        Me.txtApp3Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApp3Date.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtApp3Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApp3Date.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApp3Date.ForeColor = System.Drawing.Color.Black
        Me.txtApp3Date.Location = New System.Drawing.Point(61, 27)
        Me.txtApp3Date.Name = "txtApp3Date"
        Me.txtApp3Date.Size = New System.Drawing.Size(235, 23)
        Me.txtApp3Date.TabIndex = 273
        Me.txtApp3Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtApp3Date.UseCompatibleTextRendering = True
        '
        'lblApp3Position
        '
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
        Me.cmbApp3Status.BackColor = System.Drawing.SystemColors.Window
        Me.cmbApp3Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbApp3Status.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbApp3Status.Location = New System.Drawing.Point(61, 2)
        Me.cmbApp3Status.Name = "cmbApp3Status"
        Me.cmbApp3Status.Size = New System.Drawing.Size(235, 23)
        Me.cmbApp3Status.TabIndex = 268
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.AllowUserToResizeColumns = False
        Me.dgvDetail.AllowUserToResizeRows = False
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvDetail.ColumnHeadersHeight = 22
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColTrxDetailId, Me.ColTrxId, Me.ColTrxDate, Me.ColUserIdLog, Me.ColShiftId, Me.ColTrxFrom, Me.ColTrxTo, Me.ColElapsedTime})
        Me.dgvDetail.Location = New System.Drawing.Point(683, 31)
        Me.dgvDetail.MultiSelect = False
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.ReadOnly = True
        Me.dgvDetail.RowHeadersVisible = False
        Me.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetail.Size = New System.Drawing.Size(555, 143)
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
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColShiftId.DefaultCellStyle = DataGridViewCellStyle15
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
        DataGridViewCellStyle16.Format = "MM/dd/yyyy hh:mm tt"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.ColTrxFrom.DefaultCellStyle = DataGridViewCellStyle16
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
        DataGridViewCellStyle17.Format = "MM/dd/yyyy hh:mm tt"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.ColTrxTo.DefaultCellStyle = DataGridViewCellStyle17
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
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColElapsedTime.DefaultCellStyle = DataGridViewCellStyle18
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
        Me.txtRoutingStatus.Location = New System.Drawing.Point(431, 0)
        Me.txtRoutingStatus.Name = "txtRoutingStatus"
        Me.txtRoutingStatus.Size = New System.Drawing.Size(250, 23)
        Me.txtRoutingStatus.TabIndex = 296
        Me.txtRoutingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtRoutingStatus.UseCompatibleTextRendering = True
        '
        'ofdImage
        '
        Me.ofdImage.RestoreDirectory = True
        '
        'lblRootCause
        '
        Me.lblRootCause.BackColor = System.Drawing.SystemColors.Control
        Me.lblRootCause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRootCause.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRootCause.ForeColor = System.Drawing.Color.Black
        Me.lblRootCause.Location = New System.Drawing.Point(302, 219)
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
        Me.txtRootCause.Location = New System.Drawing.Point(302, 241)
        Me.txtRootCause.Multiline = True
        Me.txtRootCause.Name = "txtRootCause"
        Me.txtRootCause.Size = New System.Drawing.Size(379, 95)
        Me.txtRootCause.TabIndex = 8
        '
        'lblAttachment
        '
        Me.lblAttachment.BackColor = System.Drawing.SystemColors.Control
        Me.lblAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAttachment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAttachment.ForeColor = System.Drawing.Color.Black
        Me.lblAttachment.Location = New System.Drawing.Point(683, 534)
        Me.lblAttachment.Name = "lblAttachment"
        Me.lblAttachment.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblAttachment.Size = New System.Drawing.Size(100, 23)
        Me.lblAttachment.TabIndex = 551
        Me.lblAttachment.Text = "Attachment"
        Me.lblAttachment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRemoveChecksheet
        '
        Me.btnRemoveChecksheet.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemoveChecksheet.DefaultScheme = False
        Me.btnRemoveChecksheet.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemoveChecksheet.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnRemoveChecksheet.Hint = "Remove checksheet"
        Me.btnRemoveChecksheet.Location = New System.Drawing.Point(1165, 533)
        Me.btnRemoveChecksheet.Name = "btnRemoveChecksheet"
        Me.btnRemoveChecksheet.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemoveChecksheet.Size = New System.Drawing.Size(74, 25)
        Me.btnRemoveChecksheet.TabIndex = 18
        Me.btnRemoveChecksheet.TabStop = False
        Me.btnRemoveChecksheet.Text = "Remove"
        '
        'btnBrowseChecksheet
        '
        Me.btnBrowseChecksheet.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBrowseChecksheet.DefaultScheme = False
        Me.btnBrowseChecksheet.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnBrowseChecksheet.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnBrowseChecksheet.Hint = "Attach checksheet"
        Me.btnBrowseChecksheet.Location = New System.Drawing.Point(1090, 533)
        Me.btnBrowseChecksheet.Name = "btnBrowseChecksheet"
        Me.btnBrowseChecksheet.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnBrowseChecksheet.Size = New System.Drawing.Size(74, 25)
        Me.btnBrowseChecksheet.TabIndex = 17
        Me.btnBrowseChecksheet.TabStop = False
        Me.btnBrowseChecksheet.Text = "Browse"
        '
        'btnViewChecksheet
        '
        Me.btnViewChecksheet.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnViewChecksheet.DefaultScheme = False
        Me.btnViewChecksheet.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnViewChecksheet.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewChecksheet.Hint = "Open checksheet"
        Me.btnViewChecksheet.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Expand_16_x_16
        Me.btnViewChecksheet.Location = New System.Drawing.Point(1061, 533)
        Me.btnViewChecksheet.Name = "btnViewChecksheet"
        Me.btnViewChecksheet.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnViewChecksheet.Size = New System.Drawing.Size(28, 25)
        Me.btnViewChecksheet.TabIndex = 16
        Me.btnViewChecksheet.TabStop = False
        '
        'txtAttachment
        '
        Me.txtAttachment.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAttachment.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtAttachment.ForeColor = System.Drawing.Color.Black
        Me.txtAttachment.Location = New System.Drawing.Point(782, 534)
        Me.txtAttachment.Name = "txtAttachment"
        Me.txtAttachment.Size = New System.Drawing.Size(276, 23)
        Me.txtAttachment.TabIndex = 561
        Me.txtAttachment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtAttachment.UseCompatibleTextRendering = True
        '
        'progBar
        '
        Me.progBar.Location = New System.Drawing.Point(782, 534)
        Me.progBar.Name = "progBar"
        Me.progBar.Size = New System.Drawing.Size(277, 23)
        Me.progBar.TabIndex = 562
        Me.progBar.Visible = False
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.BackColor = System.Drawing.Color.Gainsboro
        Me.lblProgress.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblProgress.Location = New System.Drawing.Point(795, 538)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(26, 13)
        Me.lblProgress.TabIndex = 578
        Me.lblProgress.Text = "0/0"
        Me.lblProgress.Visible = False
        '
        'cmbArea
        '
        Me.cmbArea.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(431, 75)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(250, 23)
        Me.cmbArea.TabIndex = 1
        '
        'ofdAttachment
        '
        Me.ofdAttachment.RestoreDirectory = True
        '
        'bgWorker
        '
        Me.bgWorker.WorkerReportsProgress = True
        Me.bgWorker.WorkerSupportsCancellation = True
        '
        'txtModifiedBy
        '
        Me.txtModifiedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModifiedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedBy.Location = New System.Drawing.Point(431, 559)
        Me.txtModifiedBy.Name = "txtModifiedBy"
        Me.txtModifiedBy.Size = New System.Drawing.Size(250, 23)
        Me.txtModifiedBy.TabIndex = 582
        Me.txtModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedBy.UseCompatibleTextRendering = True
        Me.txtModifiedBy.Visible = False
        '
        'txtModifiedDate
        '
        Me.txtModifiedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModifiedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedDate.Location = New System.Drawing.Point(431, 584)
        Me.txtModifiedDate.Name = "txtModifiedDate"
        Me.txtModifiedDate.Size = New System.Drawing.Size(250, 23)
        Me.txtModifiedDate.TabIndex = 581
        Me.txtModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedDate.UseCompatibleTextRendering = True
        Me.txtModifiedDate.Visible = False
        '
        'lblModifiedDate
        '
        Me.lblModifiedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModifiedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedDate.Location = New System.Drawing.Point(302, 584)
        Me.lblModifiedDate.Name = "lblModifiedDate"
        Me.lblModifiedDate.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblModifiedDate.Size = New System.Drawing.Size(130, 23)
        Me.lblModifiedDate.TabIndex = 580
        Me.lblModifiedDate.Text = "Modified Date"
        Me.lblModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblModifiedDate.Visible = False
        '
        'lblModifiedBy
        '
        Me.lblModifiedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModifiedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedBy.Location = New System.Drawing.Point(302, 559)
        Me.lblModifiedBy.Name = "lblModifiedBy"
        Me.lblModifiedBy.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblModifiedBy.Size = New System.Drawing.Size(130, 23)
        Me.lblModifiedBy.TabIndex = 579
        Me.lblModifiedBy.Text = "Modified By"
        Me.lblModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblModifiedBy.Visible = False
        '
        'cmbRoutingStatus
        '
        Me.cmbRoutingStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRoutingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRoutingStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbRoutingStatus.FormattingEnabled = True
        Me.cmbRoutingStatus.Location = New System.Drawing.Point(431, 0)
        Me.cmbRoutingStatus.Name = "cmbRoutingStatus"
        Me.cmbRoutingStatus.Size = New System.Drawing.Size(250, 23)
        Me.cmbRoutingStatus.TabIndex = 583
        Me.cmbRoutingStatus.Visible = False
        '
        'FacTrxDetailOth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1241, 634)
        Me.Controls.Add(Me.lblRoutingStatus)
        Me.Controls.Add(Me.txtModifiedBy)
        Me.Controls.Add(Me.txtModifiedDate)
        Me.Controls.Add(Me.lblModifiedDate)
        Me.Controls.Add(Me.lblModifiedBy)
        Me.Controls.Add(Me.cmbArea)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.lblAttachment)
        Me.Controls.Add(Me.btnViewChecksheet)
        Me.Controls.Add(Me.btnRemoveChecksheet)
        Me.Controls.Add(Me.btnBrowseChecksheet)
        Me.Controls.Add(Me.lblPic)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.lblRootCause)
        Me.Controls.Add(Me.txtRootCause)
        Me.Controls.Add(Me.txtRoutingStatus)
        Me.Controls.Add(Me.btnRemoveRow)
        Me.Controls.Add(Me.btnAddRow)
        Me.Controls.Add(Me.lblActivityLog)
        Me.Controls.Add(Me.txtRuntimeAccumulated)
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
        Me.Controls.Add(Me.lblPartsNo)
        Me.Controls.Add(Me.txtPartsNo)
        Me.Controls.Add(Me.txtPartsReplaced)
        Me.Controls.Add(Me.lblPartsReplaced)
        Me.Controls.Add(Me.lblActionTaken)
        Me.Controls.Add(Me.txtActionTaken)
        Me.Controls.Add(Me.lblProblem)
        Me.Controls.Add(Me.txtProblem)
        Me.Controls.Add(Me.txtDowntimeAccumulated)
        Me.Controls.Add(Me.lblDowntimeAccumulated)
        Me.Controls.Add(Me.lblRuntimeAccumulated)
        Me.Controls.Add(Me.lblTransactionStatus)
        Me.Controls.Add(Me.cmbTransactionStatus)
        Me.Controls.Add(Me.dgvDetail)
        Me.Controls.Add(Me.pnlApprovers)
        Me.Controls.Add(Me.progBar)
        Me.Controls.Add(Me.txtAttachment)
        Me.Controls.Add(Me.cmbRoutingStatus)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FacTrxDetailOth"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Activity Details"
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
    Friend WithEvents txtImageName As System.Windows.Forms.Label
    Friend WithEvents cmbTransactionStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblTransactionStatus As System.Windows.Forms.Label
    Friend WithEvents lblRoutingStatus As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents txtProblem As System.Windows.Forms.TextBox
    Friend WithEvents lblProblem As System.Windows.Forms.Label
    Friend WithEvents txtActionTaken As System.Windows.Forms.TextBox
    Friend WithEvents lblActionTaken As System.Windows.Forms.Label
    Friend WithEvents lblPartsReplaced As System.Windows.Forms.Label
    Friend WithEvents txtPartsReplaced As System.Windows.Forms.TextBox
    Friend WithEvents txtPartsNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPartsNo As System.Windows.Forms.Label
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
    Friend WithEvents btnBrowseImage As PinkieControls.ButtonXP
    Friend WithEvents btnRemoveImage As PinkieControls.ButtonXP
    Friend WithEvents pnlImage As System.Windows.Forms.Panel
    Friend WithEvents lblPic As System.Windows.Forms.Label
    Friend WithEvents dgvPic As System.Windows.Forms.DataGridView
    Friend WithEvents lblActivityLog As System.Windows.Forms.Label
    Friend WithEvents pnlApprovers As System.Windows.Forms.Panel
    Friend WithEvents dgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents txtRoutingStatus As System.Windows.Forms.Label
    Friend WithEvents ofdImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblRootCause As System.Windows.Forms.Label
    Friend WithEvents txtRootCause As System.Windows.Forms.TextBox
    Friend WithEvents ColIsSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblAttachment As Label
    Friend WithEvents btnRemoveChecksheet As PinkieControls.ButtonXP
    Friend WithEvents btnBrowseChecksheet As PinkieControls.ButtonXP
    Friend WithEvents btnViewChecksheet As PinkieControls.ButtonXP
    Friend WithEvents btnViewImage As PinkieControls.ButtonXP
    Friend WithEvents txtAttachment As Label
    Friend WithEvents progBar As ProgressBar
    Friend WithEvents lblProgress As Label
    Friend WithEvents cmbArea As SergeUtils.EasyCompletionComboBox
    Friend WithEvents ofdAttachment As OpenFileDialog
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ColTrxDetailId As DataGridViewTextBoxColumn
    Friend WithEvents ColTrxId As DataGridViewTextBoxColumn
    Friend WithEvents ColTrxDate As DataGridViewTextBoxColumn
    Friend WithEvents ColUserIdLog As DataGridViewTextBoxColumn
    Friend WithEvents ColShiftId As DataGridViewTextBoxColumn
    Friend WithEvents ColTrxFrom As DataGridViewTextBoxColumn
    Friend WithEvents ColTrxTo As DataGridViewTextBoxColumn
    Friend WithEvents ColElapsedTime As DataGridViewTextBoxColumn
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
    Friend WithEvents txtModifiedBy As Label
    Friend WithEvents txtModifiedDate As Label
    Friend WithEvents lblModifiedDate As Label
    Friend WithEvents lblModifiedBy As Label
    Friend WithEvents cmbRoutingStatus As ComboBox
End Class
