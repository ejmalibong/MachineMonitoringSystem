<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FacMchSchedDetail
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
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.lblYearId = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblWeekNo = New System.Windows.Forms.Label()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.lblActivityDate = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.lblChecklist = New System.Windows.Forms.Label()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.lblActivityBy = New System.Windows.Forms.Label()
        Me.pnlChecklist = New System.Windows.Forms.Panel()
        Me.rdIncomplete = New System.Windows.Forms.RadioButton()
        Me.rdComplete = New System.Windows.Forms.RadioButton()
        Me.pnlRemarks = New System.Windows.Forms.Panel()
        Me.rdPending = New System.Windows.Forms.RadioButton()
        Me.rdDone = New System.Windows.Forms.RadioButton()
        Me.lblModifiedDate = New System.Windows.Forms.Label()
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.cmbMonth = New SergeUtils.EasyCompletionComboBox()
        Me.cmbMachineName = New SergeUtils.EasyCompletionComboBox()
        Me.txtActivityDate = New System.Windows.Forms.Label()
        Me.txtActivityBy = New System.Windows.Forms.Label()
        Me.txtModifiedBy = New System.Windows.Forms.Label()
        Me.txtModifiedDate = New System.Windows.Forms.Label()
        Me.txtCreatedBy = New System.Windows.Forms.Label()
        Me.txtYearId = New System.Windows.Forms.MaskedTextBox()
        Me.cmbWeekNo = New SergeUtils.EasyCompletionComboBox()
        Me.txtPmFrequency = New System.Windows.Forms.Label()
        Me.lblPmFrequency = New System.Windows.Forms.Label()
        Me.pnlChecklist.SuspendLayout()
        Me.pnlRemarks.SuspendLayout()
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
        Me.btnClose.Location = New System.Drawing.Point(230, 315)
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
        Me.btnDelete.Location = New System.Drawing.Point(136, 315)
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
        Me.btnSave.Location = New System.Drawing.Point(42, 315)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 9
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "  Save"
        '
        'lblYearId
        '
        Me.lblYearId.BackColor = System.Drawing.SystemColors.Control
        Me.lblYearId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYearId.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblYearId.ForeColor = System.Drawing.Color.Black
        Me.lblYearId.Location = New System.Drawing.Point(4, 4)
        Me.lblYearId.Name = "lblYearId"
        Me.lblYearId.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblYearId.Size = New System.Drawing.Size(100, 23)
        Me.lblYearId.TabIndex = 555
        Me.lblYearId.Text = "Year ID"
        Me.lblYearId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMonth
        '
        Me.lblMonth.BackColor = System.Drawing.SystemColors.Control
        Me.lblMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMonth.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMonth.ForeColor = System.Drawing.Color.Black
        Me.lblMonth.Location = New System.Drawing.Point(4, 29)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblMonth.Size = New System.Drawing.Size(100, 23)
        Me.lblMonth.TabIndex = 557
        Me.lblMonth.Text = "Month"
        Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeekNo
        '
        Me.lblWeekNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblWeekNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWeekNo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblWeekNo.ForeColor = System.Drawing.Color.Black
        Me.lblWeekNo.Location = New System.Drawing.Point(4, 54)
        Me.lblWeekNo.Name = "lblWeekNo"
        Me.lblWeekNo.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblWeekNo.Size = New System.Drawing.Size(100, 23)
        Me.lblWeekNo.TabIndex = 559
        Me.lblWeekNo.Text = "Week No"
        Me.lblWeekNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachineName
        '
        Me.lblMachineName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMachineName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMachineName.ForeColor = System.Drawing.Color.Black
        Me.lblMachineName.Location = New System.Drawing.Point(4, 79)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblMachineName.Size = New System.Drawing.Size(100, 23)
        Me.lblMachineName.TabIndex = 561
        Me.lblMachineName.Text = "Machine Name"
        Me.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblActivityDate
        '
        Me.lblActivityDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblActivityDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActivityDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblActivityDate.ForeColor = System.Drawing.Color.Black
        Me.lblActivityDate.Location = New System.Drawing.Point(4, 179)
        Me.lblActivityDate.Name = "lblActivityDate"
        Me.lblActivityDate.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblActivityDate.Size = New System.Drawing.Size(100, 23)
        Me.lblActivityDate.TabIndex = 563
        Me.lblActivityDate.Text = "Activity Date"
        Me.lblActivityDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(4, 279)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblRemarks.Size = New System.Drawing.Size(100, 23)
        Me.lblRemarks.TabIndex = 567
        Me.lblRemarks.Text = "Remarks"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChecklist
        '
        Me.lblChecklist.BackColor = System.Drawing.SystemColors.Control
        Me.lblChecklist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChecklist.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblChecklist.ForeColor = System.Drawing.Color.Black
        Me.lblChecklist.Location = New System.Drawing.Point(4, 254)
        Me.lblChecklist.Name = "lblChecklist"
        Me.lblChecklist.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblChecklist.Size = New System.Drawing.Size(100, 23)
        Me.lblChecklist.TabIndex = 568
        Me.lblChecklist.Text = "Checklist"
        Me.lblChecklist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedBy.Location = New System.Drawing.Point(4, 129)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblCreatedBy.Size = New System.Drawing.Size(100, 23)
        Me.lblCreatedBy.TabIndex = 572
        Me.lblCreatedBy.Text = "Created By"
        Me.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblActivityBy
        '
        Me.lblActivityBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblActivityBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActivityBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblActivityBy.ForeColor = System.Drawing.Color.Black
        Me.lblActivityBy.Location = New System.Drawing.Point(4, 154)
        Me.lblActivityBy.Name = "lblActivityBy"
        Me.lblActivityBy.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblActivityBy.Size = New System.Drawing.Size(100, 23)
        Me.lblActivityBy.TabIndex = 573
        Me.lblActivityBy.Text = "Activity By"
        Me.lblActivityBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlChecklist
        '
        Me.pnlChecklist.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlChecklist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlChecklist.Controls.Add(Me.rdIncomplete)
        Me.pnlChecklist.Controls.Add(Me.rdComplete)
        Me.pnlChecklist.Location = New System.Drawing.Point(103, 254)
        Me.pnlChecklist.Name = "pnlChecklist"
        Me.pnlChecklist.Size = New System.Drawing.Size(217, 23)
        Me.pnlChecklist.TabIndex = 10
        '
        'rdIncomplete
        '
        Me.rdIncomplete.AutoSize = True
        Me.rdIncomplete.Location = New System.Drawing.Point(109, 1)
        Me.rdIncomplete.Name = "rdIncomplete"
        Me.rdIncomplete.Size = New System.Drawing.Size(85, 19)
        Me.rdIncomplete.TabIndex = 1
        Me.rdIncomplete.TabStop = True
        Me.rdIncomplete.Text = "Incomplete"
        Me.rdIncomplete.UseVisualStyleBackColor = True
        '
        'rdComplete
        '
        Me.rdComplete.AutoSize = True
        Me.rdComplete.Location = New System.Drawing.Point(22, 1)
        Me.rdComplete.Name = "rdComplete"
        Me.rdComplete.Size = New System.Drawing.Size(77, 19)
        Me.rdComplete.TabIndex = 0
        Me.rdComplete.TabStop = True
        Me.rdComplete.Text = "Complete"
        Me.rdComplete.UseVisualStyleBackColor = True
        '
        'pnlRemarks
        '
        Me.pnlRemarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRemarks.Controls.Add(Me.rdPending)
        Me.pnlRemarks.Controls.Add(Me.rdDone)
        Me.pnlRemarks.Location = New System.Drawing.Point(103, 279)
        Me.pnlRemarks.Name = "pnlRemarks"
        Me.pnlRemarks.Size = New System.Drawing.Size(217, 23)
        Me.pnlRemarks.TabIndex = 11
        '
        'rdPending
        '
        Me.rdPending.AutoSize = True
        Me.rdPending.Location = New System.Drawing.Point(109, 1)
        Me.rdPending.Name = "rdPending"
        Me.rdPending.Size = New System.Drawing.Size(69, 19)
        Me.rdPending.TabIndex = 1
        Me.rdPending.TabStop = True
        Me.rdPending.Text = "Pending"
        Me.rdPending.UseVisualStyleBackColor = True
        '
        'rdDone
        '
        Me.rdDone.AutoSize = True
        Me.rdDone.Location = New System.Drawing.Point(22, 1)
        Me.rdDone.Name = "rdDone"
        Me.rdDone.Size = New System.Drawing.Size(53, 19)
        Me.rdDone.TabIndex = 0
        Me.rdDone.TabStop = True
        Me.rdDone.Text = "Done"
        Me.rdDone.UseVisualStyleBackColor = True
        '
        'lblModifiedDate
        '
        Me.lblModifiedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedDate.Location = New System.Drawing.Point(4, 229)
        Me.lblModifiedDate.Name = "lblModifiedDate"
        Me.lblModifiedDate.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblModifiedDate.Size = New System.Drawing.Size(100, 23)
        Me.lblModifiedDate.TabIndex = 576
        Me.lblModifiedDate.Text = "Modified Date"
        Me.lblModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModifiedBy
        '
        Me.lblModifiedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedBy.Location = New System.Drawing.Point(4, 204)
        Me.lblModifiedBy.Name = "lblModifiedBy"
        Me.lblModifiedBy.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblModifiedBy.Size = New System.Drawing.Size(100, 23)
        Me.lblModifiedBy.TabIndex = 577
        Me.lblModifiedBy.Text = "Modified By"
        Me.lblModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMonth
        '
        Me.cmbMonth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMonth.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(103, 29)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(217, 23)
        Me.cmbMonth.TabIndex = 1
        '
        'cmbMachineName
        '
        Me.cmbMachineName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMachineName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbMachineName.FormattingEnabled = True
        Me.cmbMachineName.Location = New System.Drawing.Point(103, 79)
        Me.cmbMachineName.Name = "cmbMachineName"
        Me.cmbMachineName.Size = New System.Drawing.Size(217, 23)
        Me.cmbMachineName.TabIndex = 3
        '
        'txtActivityDate
        '
        Me.txtActivityDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtActivityDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActivityDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtActivityDate.ForeColor = System.Drawing.Color.Black
        Me.txtActivityDate.Location = New System.Drawing.Point(103, 179)
        Me.txtActivityDate.Name = "txtActivityDate"
        Me.txtActivityDate.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtActivityDate.Size = New System.Drawing.Size(217, 23)
        Me.txtActivityDate.TabIndex = 7
        Me.txtActivityDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtActivityDate.UseCompatibleTextRendering = True
        '
        'txtActivityBy
        '
        Me.txtActivityBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtActivityBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActivityBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtActivityBy.ForeColor = System.Drawing.Color.Black
        Me.txtActivityBy.Location = New System.Drawing.Point(103, 154)
        Me.txtActivityBy.Name = "txtActivityBy"
        Me.txtActivityBy.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtActivityBy.Size = New System.Drawing.Size(217, 23)
        Me.txtActivityBy.TabIndex = 6
        Me.txtActivityBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtActivityBy.UseCompatibleTextRendering = True
        '
        'txtModifiedBy
        '
        Me.txtModifiedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedBy.Location = New System.Drawing.Point(103, 204)
        Me.txtModifiedBy.Name = "txtModifiedBy"
        Me.txtModifiedBy.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtModifiedBy.Size = New System.Drawing.Size(217, 23)
        Me.txtModifiedBy.TabIndex = 8
        Me.txtModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedBy.UseCompatibleTextRendering = True
        '
        'txtModifiedDate
        '
        Me.txtModifiedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedDate.Location = New System.Drawing.Point(103, 229)
        Me.txtModifiedDate.Name = "txtModifiedDate"
        Me.txtModifiedDate.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtModifiedDate.Size = New System.Drawing.Size(217, 23)
        Me.txtModifiedDate.TabIndex = 9
        Me.txtModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedDate.UseCompatibleTextRendering = True
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedBy.Location = New System.Drawing.Point(103, 129)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtCreatedBy.Size = New System.Drawing.Size(217, 23)
        Me.txtCreatedBy.TabIndex = 5
        Me.txtCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtCreatedBy.UseCompatibleTextRendering = True
        '
        'txtYearId
        '
        Me.txtYearId.BeepOnError = True
        Me.txtYearId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYearId.Location = New System.Drawing.Point(103, 4)
        Me.txtYearId.Mask = "0000"
        Me.txtYearId.Name = "txtYearId"
        Me.txtYearId.ResetOnSpace = False
        Me.txtYearId.Size = New System.Drawing.Size(217, 23)
        Me.txtYearId.TabIndex = 0
        '
        'cmbWeekNo
        '
        Me.cmbWeekNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbWeekNo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbWeekNo.FormattingEnabled = True
        Me.cmbWeekNo.Location = New System.Drawing.Point(103, 54)
        Me.cmbWeekNo.Name = "cmbWeekNo"
        Me.cmbWeekNo.Size = New System.Drawing.Size(217, 23)
        Me.cmbWeekNo.TabIndex = 2
        '
        'txtPmFrequency
        '
        Me.txtPmFrequency.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtPmFrequency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPmFrequency.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPmFrequency.ForeColor = System.Drawing.Color.Black
        Me.txtPmFrequency.Location = New System.Drawing.Point(103, 104)
        Me.txtPmFrequency.Name = "txtPmFrequency"
        Me.txtPmFrequency.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtPmFrequency.Size = New System.Drawing.Size(217, 23)
        Me.txtPmFrequency.TabIndex = 4
        Me.txtPmFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtPmFrequency.UseCompatibleTextRendering = True
        '
        'lblPmFrequency
        '
        Me.lblPmFrequency.BackColor = System.Drawing.SystemColors.Control
        Me.lblPmFrequency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPmFrequency.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPmFrequency.ForeColor = System.Drawing.Color.Black
        Me.lblPmFrequency.Location = New System.Drawing.Point(4, 104)
        Me.lblPmFrequency.Name = "lblPmFrequency"
        Me.lblPmFrequency.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblPmFrequency.Size = New System.Drawing.Size(100, 23)
        Me.lblPmFrequency.TabIndex = 579
        Me.lblPmFrequency.Text = "Frequency"
        Me.lblPmFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MntMchSchedDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(324, 351)
        Me.Controls.Add(Me.txtPmFrequency)
        Me.Controls.Add(Me.lblPmFrequency)
        Me.Controls.Add(Me.lblWeekNo)
        Me.Controls.Add(Me.cmbWeekNo)
        Me.Controls.Add(Me.lblYearId)
        Me.Controls.Add(Me.txtYearId)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.lblMachineName)
        Me.Controls.Add(Me.txtModifiedDate)
        Me.Controls.Add(Me.txtModifiedBy)
        Me.Controls.Add(Me.txtActivityBy)
        Me.Controls.Add(Me.txtActivityDate)
        Me.Controls.Add(Me.cmbMachineName)
        Me.Controls.Add(Me.cmbMonth)
        Me.Controls.Add(Me.lblModifiedDate)
        Me.Controls.Add(Me.lblModifiedBy)
        Me.Controls.Add(Me.pnlRemarks)
        Me.Controls.Add(Me.pnlChecklist)
        Me.Controls.Add(Me.lblActivityDate)
        Me.Controls.Add(Me.lblActivityBy)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.lblChecklist)
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
        Me.Name = "MntMchSchedDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Schedule Editor"
        Me.pnlChecklist.ResumeLayout(False)
        Me.pnlChecklist.PerformLayout()
        Me.pnlRemarks.ResumeLayout(False)
        Me.pnlRemarks.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents lblYearId As Label
    Friend WithEvents lblMonth As Label
    Friend WithEvents lblWeekNo As Label
    Friend WithEvents lblMachineName As Label
    Friend WithEvents lblActivityDate As Label
    Friend WithEvents lblRemarks As Label
    Friend WithEvents lblChecklist As Label
    Friend WithEvents lblCreatedBy As Label
    Friend WithEvents lblActivityBy As Label
    Friend WithEvents pnlChecklist As Panel
    Friend WithEvents pnlRemarks As Panel
    Friend WithEvents rdIncomplete As RadioButton
    Friend WithEvents rdComplete As RadioButton
    Friend WithEvents rdPending As RadioButton
    Friend WithEvents rdDone As RadioButton
    Friend WithEvents lblModifiedDate As Label
    Friend WithEvents lblModifiedBy As Label
    Friend WithEvents cmbMonth As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cmbMachineName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtActivityDate As Label
    Friend WithEvents txtActivityBy As Label
    Friend WithEvents txtModifiedBy As Label
    Friend WithEvents txtModifiedDate As Label
    Friend WithEvents txtCreatedBy As Label
    Friend WithEvents txtYearId As MaskedTextBox
    Friend WithEvents cmbWeekNo As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtPmFrequency As Label
    Friend WithEvents lblPmFrequency As Label
End Class
