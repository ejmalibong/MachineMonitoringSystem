<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MntTrxActvityLog
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
        Me.rdDay = New System.Windows.Forms.RadioButton()
        Me.rdNight = New System.Windows.Forms.RadioButton()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.txtElapsedTime = New System.Windows.Forms.Label()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.grpShift = New System.Windows.Forms.GroupBox()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblTechnician = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblElapsedTime = New System.Windows.Forms.Label()
        Me.lblTrxDate = New System.Windows.Forms.Label()
        Me.txtTrxDate = New System.Windows.Forms.Label()
        Me.cmbTechnician = New SergeUtils.EasyCompletionComboBox()
        Me.grpShift.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdDay
        '
        Me.rdDay.AutoSize = True
        Me.rdDay.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdDay.Location = New System.Drawing.Point(36, 10)
        Me.rdDay.Name = "rdDay"
        Me.rdDay.Size = New System.Drawing.Size(72, 19)
        Me.rdDay.TabIndex = 0
        Me.rdDay.TabStop = True
        Me.rdDay.Text = "Day Shift"
        Me.rdDay.UseVisualStyleBackColor = True
        '
        'rdNight
        '
        Me.rdNight.AutoSize = True
        Me.rdNight.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdNight.Location = New System.Drawing.Point(135, 10)
        Me.rdNight.Name = "rdNight"
        Me.rdNight.Size = New System.Drawing.Size(82, 19)
        Me.rdNight.TabIndex = 1
        Me.rdNight.TabStop = True
        Me.rdNight.Text = "Night Shift"
        Me.rdNight.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "MMMM dd, yyyy  -  hh:mm tt"
        Me.dtpFrom.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(132, 78)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(250, 23)
        Me.dtpFrom.TabIndex = 2
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "MMMM dd, yyyy  -  hh:mm tt"
        Me.dtpTo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(132, 103)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(250, 23)
        Me.dtpTo.TabIndex = 3
        '
        'txtElapsedTime
        '
        Me.txtElapsedTime.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtElapsedTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtElapsedTime.ForeColor = System.Drawing.Color.Black
        Me.txtElapsedTime.Location = New System.Drawing.Point(132, 128)
        Me.txtElapsedTime.Name = "txtElapsedTime"
        Me.txtElapsedTime.Size = New System.Drawing.Size(250, 23)
        Me.txtElapsedTime.TabIndex = 4
        Me.txtElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtElapsedTime.UseCompatibleTextRendering = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnClose.Hint = ""
        Me.btnClose.Location = New System.Drawing.Point(291, 161)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 6
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.DefaultScheme = False
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnSave.Hint = "Save activity log"
        Me.btnSave.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Save_16_x_16
        Me.btnSave.Location = New System.Drawing.Point(197, 161)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 5
        Me.btnSave.TabStop = False
        Me.btnSave.Text = " Save"
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.SystemColors.Control
        Me.lblShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblShift.ForeColor = System.Drawing.Color.Black
        Me.lblShift.Location = New System.Drawing.Point(3, 53)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(130, 23)
        Me.lblShift.TabIndex = 13
        Me.lblShift.Text = " Shift"
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpShift
        '
        Me.grpShift.Controls.Add(Me.rdNight)
        Me.grpShift.Controls.Add(Me.rdDay)
        Me.grpShift.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.grpShift.Location = New System.Drawing.Point(132, 45)
        Me.grpShift.Name = "grpShift"
        Me.grpShift.Size = New System.Drawing.Size(250, 32)
        Me.grpShift.TabIndex = 1
        Me.grpShift.TabStop = False
        '
        'lblFrom
        '
        Me.lblFrom.BackColor = System.Drawing.SystemColors.Control
        Me.lblFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFrom.ForeColor = System.Drawing.Color.Black
        Me.lblFrom.Location = New System.Drawing.Point(3, 78)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(130, 23)
        Me.lblFrom.TabIndex = 12
        Me.lblFrom.Text = " From"
        Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTechnician
        '
        Me.lblTechnician.BackColor = System.Drawing.SystemColors.Control
        Me.lblTechnician.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTechnician.ForeColor = System.Drawing.Color.Black
        Me.lblTechnician.Location = New System.Drawing.Point(3, 28)
        Me.lblTechnician.Name = "lblTechnician"
        Me.lblTechnician.Size = New System.Drawing.Size(130, 23)
        Me.lblTechnician.TabIndex = 14
        Me.lblTechnician.Text = " Technician"
        Me.lblTechnician.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTo
        '
        Me.lblTo.BackColor = System.Drawing.SystemColors.Control
        Me.lblTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTo.ForeColor = System.Drawing.Color.Black
        Me.lblTo.Location = New System.Drawing.Point(3, 103)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(130, 23)
        Me.lblTo.TabIndex = 11
        Me.lblTo.Text = " To"
        Me.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblElapsedTime
        '
        Me.lblElapsedTime.BackColor = System.Drawing.SystemColors.Control
        Me.lblElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblElapsedTime.ForeColor = System.Drawing.Color.Black
        Me.lblElapsedTime.Location = New System.Drawing.Point(3, 128)
        Me.lblElapsedTime.Name = "lblElapsedTime"
        Me.lblElapsedTime.Size = New System.Drawing.Size(130, 23)
        Me.lblElapsedTime.TabIndex = 10
        Me.lblElapsedTime.Text = " Elapsed Time"
        Me.lblElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrxDate
        '
        Me.lblTrxDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblTrxDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTrxDate.ForeColor = System.Drawing.Color.Black
        Me.lblTrxDate.Location = New System.Drawing.Point(3, 2)
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
        Me.txtTrxDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTrxDate.ForeColor = System.Drawing.Color.Black
        Me.txtTrxDate.Location = New System.Drawing.Point(132, 2)
        Me.txtTrxDate.Name = "txtTrxDate"
        Me.txtTrxDate.Size = New System.Drawing.Size(250, 24)
        Me.txtTrxDate.TabIndex = 1
        Me.txtTrxDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtTrxDate.UseCompatibleTextRendering = True
        '
        'cmbTechnician
        '
        Me.cmbTechnician.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbTechnician.FormattingEnabled = True
        Me.cmbTechnician.Location = New System.Drawing.Point(132, 28)
        Me.cmbTechnician.Name = "cmbTechnician"
        Me.cmbTechnician.Size = New System.Drawing.Size(250, 23)
        Me.cmbTechnician.TabIndex = 0
        '
        'MntTrxActvityLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(385, 196)
        Me.Controls.Add(Me.cmbTechnician)
        Me.Controls.Add(Me.lblTrxDate)
        Me.Controls.Add(Me.txtTrxDate)
        Me.Controls.Add(Me.lblElapsedTime)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblTechnician)
        Me.Controls.Add(Me.lblShift)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtElapsedTime)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.grpShift)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntTrxActvityLog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Log Details"
        Me.grpShift.ResumeLayout(False)
        Me.grpShift.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents lblTechnician As System.Windows.Forms.Label
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents lblElapsedTime As System.Windows.Forms.Label
    Public WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Public WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Public WithEvents txtElapsedTime As System.Windows.Forms.Label
    Public WithEvents grpShift As System.Windows.Forms.GroupBox
    Public WithEvents rdDay As System.Windows.Forms.RadioButton
    Public WithEvents rdNight As System.Windows.Forms.RadioButton
    Friend WithEvents lblTrxDate As System.Windows.Forms.Label
    Public WithEvents txtTrxDate As System.Windows.Forms.Label
    Friend WithEvents cmbTechnician As SergeUtils.EasyCompletionComboBox
End Class
