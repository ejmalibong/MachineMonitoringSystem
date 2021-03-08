<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMntTrxDetailLog
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
        Me.cmbUser = New System.Windows.Forms.ComboBox()
        Me.rdDay = New System.Windows.Forms.RadioButton()
        Me.rdNight = New System.Windows.Forms.RadioButton()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.txtElapsedTime = New System.Windows.Forms.Label()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.txtTrxDetailId = New System.Windows.Forms.Label()
        Me.txtTrxId = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.grpShift = New System.Windows.Forms.GroupBox()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblElapsedTime = New System.Windows.Forms.Label()
        Me.lblTrxDetailId = New System.Windows.Forms.Label()
        Me.lblTrxDate = New System.Windows.Forms.Label()
        Me.txtTrxDate = New System.Windows.Forms.Label()
        Me.grpShift.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbUser
        '
        Me.cmbUser.DisplayMember = "UserName"
        Me.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUser.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUser.FormattingEnabled = True
        Me.cmbUser.Location = New System.Drawing.Point(134, 57)
        Me.cmbUser.Name = "cmbUser"
        Me.cmbUser.Size = New System.Drawing.Size(250, 24)
        Me.cmbUser.TabIndex = 2
        Me.cmbUser.ValueMember = "UserId"
        '
        'rdDay
        '
        Me.rdDay.AutoSize = True
        Me.rdDay.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.rdDay.Location = New System.Drawing.Point(35, 10)
        Me.rdDay.Name = "rdDay"
        Me.rdDay.Size = New System.Drawing.Size(81, 18)
        Me.rdDay.TabIndex = 0
        Me.rdDay.TabStop = True
        Me.rdDay.Text = "Day Shift"
        Me.rdDay.UseVisualStyleBackColor = True
        '
        'rdNight
        '
        Me.rdNight.AutoSize = True
        Me.rdNight.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.rdNight.Location = New System.Drawing.Point(134, 10)
        Me.rdNight.Name = "rdNight"
        Me.rdNight.Size = New System.Drawing.Size(90, 18)
        Me.rdNight.TabIndex = 1
        Me.rdNight.TabStop = True
        Me.rdNight.Text = "Night Shift"
        Me.rdNight.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "MMMM dd, yyyy   -   HH:mm"
        Me.dtpFrom.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(134, 109)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(250, 24)
        Me.dtpFrom.TabIndex = 4
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "MMMM dd, yyyy   -   HH:mm"
        Me.dtpTo.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(134, 135)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(250, 24)
        Me.dtpTo.TabIndex = 5
        '
        'txtElapsedTime
        '
        Me.txtElapsedTime.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtElapsedTime.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtElapsedTime.ForeColor = System.Drawing.Color.Black
        Me.txtElapsedTime.Location = New System.Drawing.Point(134, 161)
        Me.txtElapsedTime.Name = "txtElapsedTime"
        Me.txtElapsedTime.Size = New System.Drawing.Size(250, 24)
        Me.txtElapsedTime.TabIndex = 6
        Me.txtElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtElapsedTime.UseCompatibleTextRendering = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.DefaultScheme = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnCancel.Hint = ""
        Me.btnCancel.Location = New System.Drawing.Point(283, 194)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 8
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
        Me.btnSave.Hint = ""
        Me.btnSave.Location = New System.Drawing.Point(181, 194)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(100, 30)
        Me.btnSave.TabIndex = 7
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "Save"
        '
        'txtTrxDetailId
        '
        Me.txtTrxDetailId.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtTrxDetailId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrxDetailId.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtTrxDetailId.ForeColor = System.Drawing.Color.Black
        Me.txtTrxDetailId.Location = New System.Drawing.Point(134, 5)
        Me.txtTrxDetailId.Name = "txtTrxDetailId"
        Me.txtTrxDetailId.Size = New System.Drawing.Size(250, 24)
        Me.txtTrxDetailId.TabIndex = 0
        Me.txtTrxDetailId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtTrxDetailId.UseCompatibleTextRendering = True
        '
        'txtTrxId
        '
        Me.txtTrxId.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTrxId.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtTrxId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrxId.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtTrxId.ForeColor = System.Drawing.Color.Black
        Me.txtTrxId.Location = New System.Drawing.Point(5, 200)
        Me.txtTrxId.Name = "txtTrxId"
        Me.txtTrxId.Size = New System.Drawing.Size(130, 24)
        Me.txtTrxId.TabIndex = 9
        Me.txtTrxId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtTrxId.UseCompatibleTextRendering = True
        Me.txtTrxId.Visible = False
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.SystemColors.Control
        Me.lblShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblShift.ForeColor = System.Drawing.Color.Black
        Me.lblShift.Location = New System.Drawing.Point(5, 83)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(130, 24)
        Me.lblShift.TabIndex = 13
        Me.lblShift.Text = " Shift"
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpShift
        '
        Me.grpShift.Controls.Add(Me.rdNight)
        Me.grpShift.Controls.Add(Me.rdDay)
        Me.grpShift.Location = New System.Drawing.Point(134, 76)
        Me.grpShift.Name = "grpShift"
        Me.grpShift.Size = New System.Drawing.Size(250, 32)
        Me.grpShift.TabIndex = 3
        Me.grpShift.TabStop = False
        '
        'lblFrom
        '
        Me.lblFrom.BackColor = System.Drawing.SystemColors.Control
        Me.lblFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFrom.ForeColor = System.Drawing.Color.Black
        Me.lblFrom.Location = New System.Drawing.Point(5, 109)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(130, 24)
        Me.lblFrom.TabIndex = 12
        Me.lblFrom.Text = " From"
        Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUser
        '
        Me.lblUser.BackColor = System.Drawing.SystemColors.Control
        Me.lblUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUser.ForeColor = System.Drawing.Color.Black
        Me.lblUser.Location = New System.Drawing.Point(5, 57)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(130, 24)
        Me.lblUser.TabIndex = 14
        Me.lblUser.Text = " Technician"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTo
        '
        Me.lblTo.BackColor = System.Drawing.SystemColors.Control
        Me.lblTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTo.ForeColor = System.Drawing.Color.Black
        Me.lblTo.Location = New System.Drawing.Point(5, 135)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(130, 24)
        Me.lblTo.TabIndex = 11
        Me.lblTo.Text = " To"
        Me.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblElapsedTime
        '
        Me.lblElapsedTime.BackColor = System.Drawing.SystemColors.Control
        Me.lblElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblElapsedTime.ForeColor = System.Drawing.Color.Black
        Me.lblElapsedTime.Location = New System.Drawing.Point(5, 161)
        Me.lblElapsedTime.Name = "lblElapsedTime"
        Me.lblElapsedTime.Size = New System.Drawing.Size(130, 24)
        Me.lblElapsedTime.TabIndex = 10
        Me.lblElapsedTime.Text = " Elapsed Time"
        Me.lblElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrxDetailId
        '
        Me.lblTrxDetailId.BackColor = System.Drawing.SystemColors.Control
        Me.lblTrxDetailId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTrxDetailId.ForeColor = System.Drawing.Color.Black
        Me.lblTrxDetailId.Location = New System.Drawing.Point(5, 5)
        Me.lblTrxDetailId.Name = "lblTrxDetailId"
        Me.lblTrxDetailId.Size = New System.Drawing.Size(130, 24)
        Me.lblTrxDetailId.TabIndex = 16
        Me.lblTrxDetailId.Text = " Log ID"
        Me.lblTrxDetailId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrxDate
        '
        Me.lblTrxDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblTrxDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTrxDate.ForeColor = System.Drawing.Color.Black
        Me.lblTrxDate.Location = New System.Drawing.Point(5, 31)
        Me.lblTrxDate.Name = "lblTrxDate"
        Me.lblTrxDate.Size = New System.Drawing.Size(130, 24)
        Me.lblTrxDate.TabIndex = 15
        Me.lblTrxDate.Text = " Entry Date"
        Me.lblTrxDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTrxDate
        '
        Me.txtTrxDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtTrxDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrxDate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtTrxDate.ForeColor = System.Drawing.Color.Black
        Me.txtTrxDate.Location = New System.Drawing.Point(134, 31)
        Me.txtTrxDate.Name = "txtTrxDate"
        Me.txtTrxDate.Size = New System.Drawing.Size(250, 24)
        Me.txtTrxDate.TabIndex = 1
        Me.txtTrxDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtTrxDate.UseCompatibleTextRendering = True
        '
        'frmMntTrxDetailLog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(389, 231)
        Me.Controls.Add(Me.lblTrxDate)
        Me.Controls.Add(Me.txtTrxDate)
        Me.Controls.Add(Me.lblTrxDetailId)
        Me.Controls.Add(Me.lblElapsedTime)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblShift)
        Me.Controls.Add(Me.txtTrxId)
        Me.Controls.Add(Me.txtTrxDetailId)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtElapsedTime)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.cmbUser)
        Me.Controls.Add(Me.grpShift)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMntTrxDetailLog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Log Details"
        Me.grpShift.ResumeLayout(False)
        Me.grpShift.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents txtTrxId As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents lblElapsedTime As System.Windows.Forms.Label
    Friend WithEvents lblTrxDetailId As System.Windows.Forms.Label
    Public WithEvents cmbUser As System.Windows.Forms.ComboBox
    Public WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Public WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Public WithEvents txtElapsedTime As System.Windows.Forms.Label
    Public WithEvents txtTrxDetailId As System.Windows.Forms.Label
    Public WithEvents grpShift As System.Windows.Forms.GroupBox
    Public WithEvents rdDay As System.Windows.Forms.RadioButton
    Public WithEvents rdNight As System.Windows.Forms.RadioButton
    Friend WithEvents lblTrxDate As System.Windows.Forms.Label
    Public WithEvents txtTrxDate As System.Windows.Forms.Label
End Class
