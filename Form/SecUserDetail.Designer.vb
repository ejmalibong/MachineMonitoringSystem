<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SecUserDetail
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
        Me.lblEmployeeId = New System.Windows.Forms.Label()
        Me.txtEmployeeId = New System.Windows.Forms.TextBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblNickname = New System.Windows.Forms.Label()
        Me.txtNickname = New System.Windows.Forms.TextBox()
        Me.lblWorkgroup = New System.Windows.Forms.Label()
        Me.lblIsActive = New System.Windows.Forms.Label()
        Me.lblIsAdmin = New System.Windows.Forms.Label()
        Me.cmbWorkgroup = New SergeUtils.EasyCompletionComboBox()
        Me.lblUserItem = New System.Windows.Forms.Label()
        Me.txtUserItem = New System.Windows.Forms.TextBox()
        Me.cmbSection = New SergeUtils.EasyCompletionComboBox()
        Me.lblSection = New System.Windows.Forms.Label()
        Me.pnlIsAdmin = New System.Windows.Forms.Panel()
        Me.rdAdminNo = New System.Windows.Forms.RadioButton()
        Me.rdAdminYes = New System.Windows.Forms.RadioButton()
        Me.pnlIsActive = New System.Windows.Forms.Panel()
        Me.rdActiveNo = New System.Windows.Forms.RadioButton()
        Me.rdActiveYes = New System.Windows.Forms.RadioButton()
        Me.pnlIsAdmin.SuspendLayout()
        Me.pnlIsActive.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(230, 246)
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
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnDelete.DefaultScheme = False
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDelete.Hint = "Delete record"
        Me.btnDelete.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Erase_16_x_16
        Me.btnDelete.Location = New System.Drawing.Point(136, 246)
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
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnSave.DefaultScheme = False
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSave.Hint = "Save record"
        Me.btnSave.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Save_16_x_16
        Me.btnSave.Location = New System.Drawing.Point(42, 246)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 9
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "  Save"
        '
        'lblEmployeeId
        '
        Me.lblEmployeeId.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployeeId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployeeId.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmployeeId.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeId.Location = New System.Drawing.Point(4, 4)
        Me.lblEmployeeId.Name = "lblEmployeeId"
        Me.lblEmployeeId.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblEmployeeId.Size = New System.Drawing.Size(100, 23)
        Me.lblEmployeeId.TabIndex = 555
        Me.lblEmployeeId.Text = "Employee ID"
        Me.lblEmployeeId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeId
        '
        Me.txtEmployeeId.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmployeeId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeId.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmployeeId.Location = New System.Drawing.Point(103, 4)
        Me.txtEmployeeId.MaxLength = 8
        Me.txtEmployeeId.Name = "txtEmployeeId"
        Me.txtEmployeeId.Size = New System.Drawing.Size(217, 23)
        Me.txtEmployeeId.TabIndex = 0
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.SystemColors.Control
        Me.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUserName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUserName.ForeColor = System.Drawing.Color.Black
        Me.lblUserName.Location = New System.Drawing.Point(4, 29)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblUserName.Size = New System.Drawing.Size(100, 23)
        Me.lblUserName.TabIndex = 557
        Me.lblUserName.Text = "User Name"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUserName
        '
        Me.txtUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUserName.Location = New System.Drawing.Point(103, 29)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(217, 23)
        Me.txtUserName.TabIndex = 1
        '
        'lblPassword
        '
        Me.lblPassword.BackColor = System.Drawing.SystemColors.Control
        Me.lblPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPassword.ForeColor = System.Drawing.Color.Black
        Me.lblPassword.Location = New System.Drawing.Point(4, 54)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblPassword.Size = New System.Drawing.Size(100, 23)
        Me.lblPassword.TabIndex = 559
        Me.lblPassword.Text = "Password"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPassword.Location = New System.Drawing.Point(103, 54)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(217, 23)
        Me.txtPassword.TabIndex = 2
        '
        'lblNickname
        '
        Me.lblNickname.BackColor = System.Drawing.SystemColors.Control
        Me.lblNickname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNickname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNickname.ForeColor = System.Drawing.Color.Black
        Me.lblNickname.Location = New System.Drawing.Point(4, 79)
        Me.lblNickname.Name = "lblNickname"
        Me.lblNickname.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblNickname.Size = New System.Drawing.Size(100, 23)
        Me.lblNickname.TabIndex = 561
        Me.lblNickname.Text = "Nickname"
        Me.lblNickname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNickname
        '
        Me.txtNickname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNickname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNickname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNickname.Location = New System.Drawing.Point(103, 79)
        Me.txtNickname.Name = "txtNickname"
        Me.txtNickname.Size = New System.Drawing.Size(217, 23)
        Me.txtNickname.TabIndex = 3
        '
        'lblWorkgroup
        '
        Me.lblWorkgroup.BackColor = System.Drawing.SystemColors.Control
        Me.lblWorkgroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWorkgroup.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblWorkgroup.ForeColor = System.Drawing.Color.Black
        Me.lblWorkgroup.Location = New System.Drawing.Point(4, 154)
        Me.lblWorkgroup.Name = "lblWorkgroup"
        Me.lblWorkgroup.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblWorkgroup.Size = New System.Drawing.Size(100, 23)
        Me.lblWorkgroup.TabIndex = 563
        Me.lblWorkgroup.Text = "Workgroup"
        Me.lblWorkgroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIsActive
        '
        Me.lblIsActive.BackColor = System.Drawing.SystemColors.Control
        Me.lblIsActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIsActive.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIsActive.ForeColor = System.Drawing.Color.Black
        Me.lblIsActive.Location = New System.Drawing.Point(4, 204)
        Me.lblIsActive.Name = "lblIsActive"
        Me.lblIsActive.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblIsActive.Size = New System.Drawing.Size(100, 23)
        Me.lblIsActive.TabIndex = 567
        Me.lblIsActive.Text = "Active"
        Me.lblIsActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIsAdmin
        '
        Me.lblIsAdmin.BackColor = System.Drawing.SystemColors.Control
        Me.lblIsAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIsAdmin.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIsAdmin.ForeColor = System.Drawing.Color.Black
        Me.lblIsAdmin.Location = New System.Drawing.Point(4, 179)
        Me.lblIsAdmin.Name = "lblIsAdmin"
        Me.lblIsAdmin.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblIsAdmin.Size = New System.Drawing.Size(100, 23)
        Me.lblIsAdmin.TabIndex = 568
        Me.lblIsAdmin.Text = "Administrator"
        Me.lblIsAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbWorkgroup
        '
        Me.cmbWorkgroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbWorkgroup.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbWorkgroup.FormattingEnabled = True
        Me.cmbWorkgroup.Items.AddRange(New Object() {"Information Technology", "Manufacturing Technology"})
        Me.cmbWorkgroup.Location = New System.Drawing.Point(103, 154)
        Me.cmbWorkgroup.Name = "cmbWorkgroup"
        Me.cmbWorkgroup.Size = New System.Drawing.Size(217, 23)
        Me.cmbWorkgroup.TabIndex = 6
        '
        'lblUserItem
        '
        Me.lblUserItem.BackColor = System.Drawing.SystemColors.Control
        Me.lblUserItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUserItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUserItem.ForeColor = System.Drawing.Color.Black
        Me.lblUserItem.Location = New System.Drawing.Point(4, 104)
        Me.lblUserItem.Name = "lblUserItem"
        Me.lblUserItem.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblUserItem.Size = New System.Drawing.Size(100, 23)
        Me.lblUserItem.TabIndex = 572
        Me.lblUserItem.Text = "User Item"
        Me.lblUserItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUserItem
        '
        Me.txtUserItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUserItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUserItem.Location = New System.Drawing.Point(103, 104)
        Me.txtUserItem.Name = "txtUserItem"
        Me.txtUserItem.Size = New System.Drawing.Size(217, 23)
        Me.txtUserItem.TabIndex = 4
        '
        'cmbSection
        '
        Me.cmbSection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSection.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbSection.FormattingEnabled = True
        Me.cmbSection.Location = New System.Drawing.Point(103, 129)
        Me.cmbSection.Name = "cmbSection"
        Me.cmbSection.Size = New System.Drawing.Size(217, 23)
        Me.cmbSection.TabIndex = 5
        '
        'lblSection
        '
        Me.lblSection.BackColor = System.Drawing.SystemColors.Control
        Me.lblSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSection.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSection.ForeColor = System.Drawing.Color.Black
        Me.lblSection.Location = New System.Drawing.Point(4, 129)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblSection.Size = New System.Drawing.Size(100, 23)
        Me.lblSection.TabIndex = 573
        Me.lblSection.Text = "Section"
        Me.lblSection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlIsAdmin
        '
        Me.pnlIsAdmin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlIsAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlIsAdmin.Controls.Add(Me.rdAdminNo)
        Me.pnlIsAdmin.Controls.Add(Me.rdAdminYes)
        Me.pnlIsAdmin.Location = New System.Drawing.Point(103, 179)
        Me.pnlIsAdmin.Name = "pnlIsAdmin"
        Me.pnlIsAdmin.Size = New System.Drawing.Size(217, 23)
        Me.pnlIsAdmin.TabIndex = 7
        '
        'rdAdminNo
        '
        Me.rdAdminNo.AutoSize = True
        Me.rdAdminNo.Location = New System.Drawing.Point(126, 1)
        Me.rdAdminNo.Name = "rdAdminNo"
        Me.rdAdminNo.Size = New System.Drawing.Size(41, 19)
        Me.rdAdminNo.TabIndex = 1
        Me.rdAdminNo.TabStop = True
        Me.rdAdminNo.Text = "No"
        Me.rdAdminNo.UseVisualStyleBackColor = True
        '
        'rdAdminYes
        '
        Me.rdAdminYes.AutoSize = True
        Me.rdAdminYes.Location = New System.Drawing.Point(35, 1)
        Me.rdAdminYes.Name = "rdAdminYes"
        Me.rdAdminYes.Size = New System.Drawing.Size(42, 19)
        Me.rdAdminYes.TabIndex = 0
        Me.rdAdminYes.TabStop = True
        Me.rdAdminYes.Text = "Yes"
        Me.rdAdminYes.UseVisualStyleBackColor = True
        '
        'pnlIsActive
        '
        Me.pnlIsActive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlIsActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlIsActive.Controls.Add(Me.rdActiveNo)
        Me.pnlIsActive.Controls.Add(Me.rdActiveYes)
        Me.pnlIsActive.Location = New System.Drawing.Point(103, 204)
        Me.pnlIsActive.Name = "pnlIsActive"
        Me.pnlIsActive.Size = New System.Drawing.Size(217, 23)
        Me.pnlIsActive.TabIndex = 8
        '
        'rdActiveNo
        '
        Me.rdActiveNo.AutoSize = True
        Me.rdActiveNo.Location = New System.Drawing.Point(126, 1)
        Me.rdActiveNo.Name = "rdActiveNo"
        Me.rdActiveNo.Size = New System.Drawing.Size(41, 19)
        Me.rdActiveNo.TabIndex = 1
        Me.rdActiveNo.TabStop = True
        Me.rdActiveNo.Text = "No"
        Me.rdActiveNo.UseVisualStyleBackColor = True
        '
        'rdActiveYes
        '
        Me.rdActiveYes.AutoSize = True
        Me.rdActiveYes.Location = New System.Drawing.Point(35, 1)
        Me.rdActiveYes.Name = "rdActiveYes"
        Me.rdActiveYes.Size = New System.Drawing.Size(42, 19)
        Me.rdActiveYes.TabIndex = 0
        Me.rdActiveYes.TabStop = True
        Me.rdActiveYes.Text = "Yes"
        Me.rdActiveYes.UseVisualStyleBackColor = True
        '
        'SecUserDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(324, 281)
        Me.Controls.Add(Me.pnlIsActive)
        Me.Controls.Add(Me.pnlIsAdmin)
        Me.Controls.Add(Me.lblWorkgroup)
        Me.Controls.Add(Me.lblSection)
        Me.Controls.Add(Me.cmbSection)
        Me.Controls.Add(Me.lblUserItem)
        Me.Controls.Add(Me.txtUserItem)
        Me.Controls.Add(Me.cmbWorkgroup)
        Me.Controls.Add(Me.lblIsAdmin)
        Me.Controls.Add(Me.lblIsActive)
        Me.Controls.Add(Me.lblNickname)
        Me.Controls.Add(Me.txtNickname)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.lblEmployeeId)
        Me.Controls.Add(Me.txtEmployeeId)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SecUserDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Profile Editor"
        Me.pnlIsAdmin.ResumeLayout(False)
        Me.pnlIsAdmin.PerformLayout()
        Me.pnlIsActive.ResumeLayout(False)
        Me.pnlIsActive.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents lblEmployeeId As Label
    Friend WithEvents txtEmployeeId As TextBox
    Friend WithEvents lblUserName As Label
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblNickname As Label
    Friend WithEvents txtNickname As TextBox
    Friend WithEvents lblWorkgroup As Label
    Friend WithEvents lblIsActive As Label
    Friend WithEvents lblIsAdmin As Label
    Friend WithEvents cmbWorkgroup As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblUserItem As Label
    Friend WithEvents txtUserItem As TextBox
    Friend WithEvents cmbSection As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblSection As Label
    Friend WithEvents pnlIsAdmin As Panel
    Friend WithEvents pnlIsActive As Panel
    Friend WithEvents rdAdminNo As RadioButton
    Friend WithEvents rdAdminYes As RadioButton
    Friend WithEvents rdActiveNo As RadioButton
    Friend WithEvents rdActiveYes As RadioButton
End Class
