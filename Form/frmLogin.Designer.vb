<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.txtEmployeeId = New System.Windows.Forms.TextBox()
        Me.btnLogin = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtEmployeeId
        '
        Me.txtEmployeeId.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtEmployeeId.Location = New System.Drawing.Point(230, 56)
        Me.txtEmployeeId.Name = "txtEmployeeId"
        Me.txtEmployeeId.Size = New System.Drawing.Size(243, 29)
        Me.txtEmployeeId.TabIndex = 0
        Me.txtEmployeeId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLogin.DefaultScheme = True
        Me.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnLogin.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Hint = "Login"
        Me.btnLogin.Location = New System.Drawing.Point(270, 103)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnLogin.Size = New System.Drawing.Size(100, 28)
        Me.btnLogin.TabIndex = 91
        Me.btnLogin.TabStop = False
        Me.btnLogin.Text = "  Login"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Hint = "Login"
        Me.btnClose.Location = New System.Drawing.Point(373, 103)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(100, 28)
        Me.btnClose.TabIndex = 92
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "  Close"
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Location = New System.Drawing.Point(226, 34)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(86, 19)
        Me.lblCaption.TabIndex = 93
        Me.lblCaption.Text = "Employee ID"
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(484, 211)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtEmployeeId)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Machine Monitoring System"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtEmployeeId As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents lblCaption As System.Windows.Forms.Label
End Class
