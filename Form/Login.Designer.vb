<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.txtEmployeeId = New System.Windows.Forms.TextBox()
        Me.btnLogin = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lblEmployeeId = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.picPassword = New System.Windows.Forms.PictureBox()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEmployeeId
        '
        Me.txtEmployeeId.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmployeeId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeId.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeId.Location = New System.Drawing.Point(204, 31)
        Me.txtEmployeeId.MaxLength = 8
        Me.txtEmployeeId.Name = "txtEmployeeId"
        Me.txtEmployeeId.Size = New System.Drawing.Size(218, 27)
        Me.txtEmployeeId.TabIndex = 0
        Me.txtEmployeeId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLogin.DefaultScheme = True
        Me.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnLogin.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnLogin.Hint = "Login"
        Me.btnLogin.Location = New System.Drawing.Point(236, 137)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnLogin.Size = New System.Drawing.Size(90, 32)
        Me.btnLogin.TabIndex = 2
        Me.btnLogin.Text = "Login"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnClose.Hint = "Login"
        Me.btnClose.Location = New System.Drawing.Point(332, 137)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(204, 84)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(179, 27)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'picLogo
        '
        Me.picLogo.Image = Global.MachineMonitoringSystem.My.Resources.Resources.SysIcon21
        Me.picLogo.Location = New System.Drawing.Point(-6, -29)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(200, 174)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 4
        Me.picLogo.TabStop = False
        '
        'lblEmployeeId
        '
        Me.lblEmployeeId.AutoSize = True
        Me.lblEmployeeId.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeId.Location = New System.Drawing.Point(200, 8)
        Me.lblEmployeeId.Name = "lblEmployeeId"
        Me.lblEmployeeId.Size = New System.Drawing.Size(86, 19)
        Me.lblEmployeeId.TabIndex = 5
        Me.lblEmployeeId.Text = "Employee ID"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(200, 61)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(67, 19)
        Me.lblPassword.TabIndex = 6
        Me.lblPassword.Text = "Password"
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblVersion.Location = New System.Drawing.Point(6, 163)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(44, 13)
        Me.lblVersion.TabIndex = 7
        Me.lblVersion.Text = "version"
        '
        'picPassword
        '
        Me.picPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPassword.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Password_Hide
        Me.picPassword.Location = New System.Drawing.Point(382, 84)
        Me.picPassword.Name = "picPassword"
        Me.picPassword.Size = New System.Drawing.Size(40, 27)
        Me.picPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPassword.TabIndex = 8
        Me.picPassword.TabStop = False
        '
        'Login
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(434, 181)
        Me.Controls.Add(Me.picPassword)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblEmployeeId)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtEmployeeId)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Login"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Machine Monitoring System"
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtEmployeeId As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblEmployeeId As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents picPassword As System.Windows.Forms.PictureBox
End Class
