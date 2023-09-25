<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MntJigModelDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MntJigModelDetail))
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.lblExtension = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.pnlRemarks = New System.Windows.Forms.Panel()
        Me.rdInactive = New System.Windows.Forms.RadioButton()
        Me.rdActive = New System.Windows.Forms.RadioButton()
        Me.cmbExtension = New SergeUtils.EasyCompletionComboBox()
        Me.lblModelName = New System.Windows.Forms.Label()
        Me.txtModelName = New System.Windows.Forms.TextBox()
        Me.pnlAttachment = New System.Windows.Forms.Panel()
        Me.lblAttachmentCount = New System.Windows.Forms.Label()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.pbAttachment = New System.Windows.Forms.ProgressBar()
        Me.btnView = New PinkieControls.ButtonXP()
        Me.txtAttachmentName = New System.Windows.Forms.Label()
        Me.btnNext = New PinkieControls.ButtonXP()
        Me.btnPrevious = New PinkieControls.ButtonXP()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.btnBrowse = New PinkieControls.ButtonXP()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.ofdRecDetail = New System.Windows.Forms.OpenFileDialog()
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.AxAcroPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.pnlRemarks.SuspendLayout()
        Me.pnlAttachment.SuspendLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxAcroPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(250, 425)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 11
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = False
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDelete.Hint = "Delete record"
        Me.btnDelete.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Erase_16_x_16
        Me.btnDelete.Location = New System.Drawing.Point(156, 425)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = " Delete"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.DefaultScheme = False
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSave.Hint = "Save record"
        Me.btnSave.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Save_16_x_16
        Me.btnSave.Location = New System.Drawing.Point(62, 425)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 9
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "  Save"
        '
        'lblExtension
        '
        Me.lblExtension.BackColor = System.Drawing.SystemColors.Control
        Me.lblExtension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExtension.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblExtension.ForeColor = System.Drawing.Color.Black
        Me.lblExtension.Location = New System.Drawing.Point(4, 29)
        Me.lblExtension.Name = "lblExtension"
        Me.lblExtension.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblExtension.Size = New System.Drawing.Size(100, 23)
        Me.lblExtension.TabIndex = 557
        Me.lblExtension.Text = "Extension"
        Me.lblExtension.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(4, 54)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblRemarks.Size = New System.Drawing.Size(100, 23)
        Me.lblRemarks.TabIndex = 568
        Me.lblRemarks.Text = "Remarks"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlRemarks
        '
        Me.pnlRemarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRemarks.Controls.Add(Me.rdInactive)
        Me.pnlRemarks.Controls.Add(Me.rdActive)
        Me.pnlRemarks.Location = New System.Drawing.Point(103, 54)
        Me.pnlRemarks.Name = "pnlRemarks"
        Me.pnlRemarks.Size = New System.Drawing.Size(237, 23)
        Me.pnlRemarks.TabIndex = 6
        '
        'rdInactive
        '
        Me.rdInactive.AutoSize = True
        Me.rdInactive.Location = New System.Drawing.Point(118, 0)
        Me.rdInactive.Name = "rdInactive"
        Me.rdInactive.Size = New System.Drawing.Size(66, 19)
        Me.rdInactive.TabIndex = 1
        Me.rdInactive.TabStop = True
        Me.rdInactive.Text = "Inactive"
        Me.rdInactive.UseVisualStyleBackColor = True
        '
        'rdActive
        '
        Me.rdActive.AutoSize = True
        Me.rdActive.Location = New System.Drawing.Point(31, 0)
        Me.rdActive.Name = "rdActive"
        Me.rdActive.Size = New System.Drawing.Size(58, 19)
        Me.rdActive.TabIndex = 0
        Me.rdActive.TabStop = True
        Me.rdActive.Text = "Active"
        Me.rdActive.UseVisualStyleBackColor = True
        '
        'cmbExtension
        '
        Me.cmbExtension.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbExtension.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbExtension.FormattingEnabled = True
        Me.cmbExtension.Location = New System.Drawing.Point(103, 29)
        Me.cmbExtension.Name = "cmbExtension"
        Me.cmbExtension.Size = New System.Drawing.Size(237, 23)
        Me.cmbExtension.TabIndex = 1
        '
        'lblModelName
        '
        Me.lblModelName.BackColor = System.Drawing.SystemColors.Control
        Me.lblModelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModelName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModelName.ForeColor = System.Drawing.Color.Black
        Me.lblModelName.Location = New System.Drawing.Point(4, 4)
        Me.lblModelName.Name = "lblModelName"
        Me.lblModelName.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblModelName.Size = New System.Drawing.Size(100, 23)
        Me.lblModelName.TabIndex = 555
        Me.lblModelName.Text = "Model Name"
        Me.lblModelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModelName
        '
        Me.txtModelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModelName.Location = New System.Drawing.Point(103, 4)
        Me.txtModelName.MaxLength = 50
        Me.txtModelName.Name = "txtModelName"
        Me.txtModelName.Size = New System.Drawing.Size(237, 23)
        Me.txtModelName.TabIndex = 0
        '
        'pnlAttachment
        '
        Me.pnlAttachment.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAttachment.Controls.Add(Me.lblAttachmentCount)
        Me.pnlAttachment.Controls.Add(Me.lblProgress)
        Me.pnlAttachment.Controls.Add(Me.pbAttachment)
        Me.pnlAttachment.Controls.Add(Me.btnView)
        Me.pnlAttachment.Controls.Add(Me.txtAttachmentName)
        Me.pnlAttachment.Controls.Add(Me.btnNext)
        Me.pnlAttachment.Controls.Add(Me.btnPrevious)
        Me.pnlAttachment.Controls.Add(Me.btnRemove)
        Me.pnlAttachment.Controls.Add(Me.btnBrowse)
        Me.pnlAttachment.Controls.Add(Me.picImage)
        Me.pnlAttachment.Controls.Add(Me.AxAcroPDF)
        Me.pnlAttachment.Location = New System.Drawing.Point(4, 79)
        Me.pnlAttachment.Name = "pnlAttachment"
        Me.pnlAttachment.Size = New System.Drawing.Size(336, 340)
        Me.pnlAttachment.TabIndex = 569
        '
        'lblAttachmentCount
        '
        Me.lblAttachmentCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAttachmentCount.AutoSize = True
        Me.lblAttachmentCount.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblAttachmentCount.Location = New System.Drawing.Point(114, 315)
        Me.lblAttachmentCount.Name = "lblAttachmentCount"
        Me.lblAttachmentCount.Size = New System.Drawing.Size(24, 15)
        Me.lblAttachmentCount.TabIndex = 578
        Me.lblAttachmentCount.Text = "0/0"
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblProgress.AutoSize = True
        Me.lblProgress.BackColor = System.Drawing.Color.Gainsboro
        Me.lblProgress.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblProgress.Location = New System.Drawing.Point(11, 285)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(24, 15)
        Me.lblProgress.TabIndex = 575
        Me.lblProgress.Text = "0/0"
        Me.lblProgress.Visible = False
        '
        'pbAttachment
        '
        Me.pbAttachment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbAttachment.Location = New System.Drawing.Point(6, 280)
        Me.pbAttachment.Name = "pbAttachment"
        Me.pbAttachment.Size = New System.Drawing.Size(322, 23)
        Me.pbAttachment.TabIndex = 574
        Me.pbAttachment.Visible = False
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
        Me.btnView.Location = New System.Drawing.Point(59, 309)
        Me.btnView.Name = "btnView"
        Me.btnView.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnView.Size = New System.Drawing.Size(26, 26)
        Me.btnView.TabIndex = 572
        Me.btnView.TabStop = False
        '
        'txtAttachmentName
        '
        Me.txtAttachmentName.AutoSize = True
        Me.txtAttachmentName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAttachmentName.Location = New System.Drawing.Point(2, 3)
        Me.txtAttachmentName.Name = "txtAttachmentName"
        Me.txtAttachmentName.Size = New System.Drawing.Size(55, 15)
        Me.txtAttachmentName.TabIndex = 571
        Me.txtAttachmentName.Text = "Filename"
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnNext.DefaultScheme = False
        Me.btnNext.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnNext.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Hint = "Next"
        Me.btnNext.Location = New System.Drawing.Point(30, 309)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnNext.Size = New System.Drawing.Size(26, 26)
        Me.btnNext.TabIndex = 1
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
        Me.btnPrevious.Location = New System.Drawing.Point(2, 309)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnPrevious.Size = New System.Drawing.Size(26, 26)
        Me.btnPrevious.TabIndex = 0
        Me.btnPrevious.TabStop = False
        Me.btnPrevious.Text = "<"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnRemove.DefaultScheme = False
        Me.btnRemove.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnRemove.Hint = "Remove"
        Me.btnRemove.Location = New System.Drawing.Point(255, 309)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove.Size = New System.Drawing.Size(76, 26)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.TabStop = False
        Me.btnRemove.Text = "Remove"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnBrowse.DefaultScheme = False
        Me.btnBrowse.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnBrowse.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnBrowse.Hint = "Browse files"
        Me.btnBrowse.Location = New System.Drawing.Point(175, 309)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnBrowse.Size = New System.Drawing.Size(76, 26)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.TabStop = False
        Me.btnBrowse.Text = "Browse"
        '
        'picImage
        '
        Me.picImage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picImage.BackColor = System.Drawing.Color.White
        Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImage.ErrorImage = Nothing
        Me.picImage.InitialImage = Nothing
        Me.picImage.Location = New System.Drawing.Point(4, 21)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(326, 284)
        Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage.TabIndex = 576
        Me.picImage.TabStop = False
        '
        'ofdRecDetail
        '
        Me.ofdRecDetail.Multiselect = True
        '
        'bgWorker
        '
        Me.bgWorker.WorkerReportsProgress = True
        Me.bgWorker.WorkerSupportsCancellation = True
        '
        'AxAcroPDF
        '
        Me.AxAcroPDF.Enabled = True
        Me.AxAcroPDF.Location = New System.Drawing.Point(4, 21)
        Me.AxAcroPDF.Name = "AxAcroPDF"
        Me.AxAcroPDF.OcxState = CType(resources.GetObject("AxAcroPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF.Size = New System.Drawing.Size(326, 284)
        Me.AxAcroPDF.TabIndex = 579
        '
        'MntJigModelDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(344, 461)
        Me.Controls.Add(Me.pnlAttachment)
        Me.Controls.Add(Me.txtModelName)
        Me.Controls.Add(Me.lblModelName)
        Me.Controls.Add(Me.lblExtension)
        Me.Controls.Add(Me.cmbExtension)
        Me.Controls.Add(Me.pnlRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntJigModelDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Model Editor"
        Me.pnlRemarks.ResumeLayout(False)
        Me.pnlRemarks.PerformLayout()
        Me.pnlAttachment.ResumeLayout(False)
        Me.pnlAttachment.PerformLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxAcroPDF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents lblExtension As Label
    Friend WithEvents lblModelName As Label
    Friend WithEvents lblRemarks As Label
    Friend WithEvents pnlRemarks As Panel
    Friend WithEvents rdInactive As RadioButton
    Friend WithEvents rdActive As RadioButton
    Friend WithEvents cmbExtension As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtModelName As TextBox
    Friend WithEvents pnlAttachment As Panel
    Friend WithEvents lblProgress As Label
    Friend WithEvents pbAttachment As ProgressBar
    Friend WithEvents btnView As PinkieControls.ButtonXP
    Friend WithEvents txtAttachmentName As Label
    Friend WithEvents btnNext As PinkieControls.ButtonXP
    Friend WithEvents btnPrevious As PinkieControls.ButtonXP
    Friend WithEvents btnRemove As PinkieControls.ButtonXP
    Friend WithEvents btnBrowse As PinkieControls.ButtonXP
    Friend WithEvents picImage As PictureBox
    Friend WithEvents lblAttachmentCount As Label
    Friend WithEvents ofdRecDetail As OpenFileDialog
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents AxAcroPDF As AxAcroPDFLib.AxAcroPDF
End Class
