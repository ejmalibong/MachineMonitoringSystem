<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMntTrxApproval
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnView = New PinkieControls.ButtonXP()
        Me.btnReturn = New PinkieControls.ButtonXP()
        Me.btnApprove = New PinkieControls.ButtonXP()
        Me.dgvTransactionHeader = New System.Windows.Forms.DataGridView()
        Me.IsSelectedColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TrxIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProblemColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActivityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatetimeStartedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatetimeEndedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAccumulatedTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShiftIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SeniorEngineerApprovalDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SeniorEngineerIsApprovedColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.rdPending = New System.Windows.Forms.RadioButton()
        Me.rdApproved = New System.Windows.Forms.RadioButton()
        Me.btnRefresh = New PinkieControls.ButtonXP()
        CType(Me.dgvTransactionHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnClose.Hint = ""
        Me.btnClose.Location = New System.Drawing.Point(1209, 565)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(100, 30)
        Me.btnClose.TabIndex = 155
        Me.btnClose.Text = "Close"
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnView.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnView.DefaultScheme = False
        Me.btnView.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnView.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnView.Hint = ""
        Me.btnView.Location = New System.Drawing.Point(1108, 565)
        Me.btnView.Name = "btnView"
        Me.btnView.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnView.Size = New System.Drawing.Size(100, 30)
        Me.btnView.TabIndex = 154
        Me.btnView.Text = "View"
        '
        'btnReturn
        '
        Me.btnReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReturn.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReturn.DefaultScheme = False
        Me.btnReturn.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnReturn.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnReturn.Hint = ""
        Me.btnReturn.Location = New System.Drawing.Point(1007, 565)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnReturn.Size = New System.Drawing.Size(100, 30)
        Me.btnReturn.TabIndex = 153
        Me.btnReturn.Text = "Return"
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnApprove.DefaultScheme = False
        Me.btnApprove.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnApprove.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnApprove.Hint = ""
        Me.btnApprove.Location = New System.Drawing.Point(906, 565)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnApprove.Size = New System.Drawing.Size(100, 30)
        Me.btnApprove.TabIndex = 152
        Me.btnApprove.Text = "Approve"
        '
        'dgvTransactionHeader
        '
        Me.dgvTransactionHeader.AllowUserToAddRows = False
        Me.dgvTransactionHeader.AllowUserToDeleteRows = False
        Me.dgvTransactionHeader.AllowUserToResizeColumns = False
        Me.dgvTransactionHeader.AllowUserToResizeRows = False
        Me.dgvTransactionHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvTransactionHeader.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTransactionHeader.ColumnHeadersHeight = 25
        Me.dgvTransactionHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTransactionHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IsSelectedColumn, Me.TrxIdColumn, Me.ProblemColumn, Me.ActivityColumn, Me.DatetimeStartedColumn, Me.DatetimeEndedColumn, Me.TotalAccumulatedTimeColumn, Me.ShiftIdColumn, Me.SeniorEngineerApprovalDateColumn, Me.SeniorEngineerIsApprovedColumn})
        Me.dgvTransactionHeader.Location = New System.Drawing.Point(0, 37)
        Me.dgvTransactionHeader.MultiSelect = False
        Me.dgvTransactionHeader.Name = "dgvTransactionHeader"
        Me.dgvTransactionHeader.RowHeadersVisible = False
        Me.dgvTransactionHeader.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvTransactionHeader.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTransactionHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvTransactionHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransactionHeader.Size = New System.Drawing.Size(1314, 520)
        Me.dgvTransactionHeader.TabIndex = 158
        '
        'IsSelectedColumn
        '
        Me.IsSelectedColumn.HeaderText = ""
        Me.IsSelectedColumn.Name = "IsSelectedColumn"
        Me.IsSelectedColumn.Width = 25
        '
        'TrxIdColumn
        '
        Me.TrxIdColumn.DataPropertyName = "TrxId"
        Me.TrxIdColumn.HeaderText = "#"
        Me.TrxIdColumn.Name = "TrxIdColumn"
        Me.TrxIdColumn.ReadOnly = True
        Me.TrxIdColumn.Width = 50
        '
        'ProblemColumn
        '
        Me.ProblemColumn.DataPropertyName = "Problem"
        Me.ProblemColumn.HeaderText = "Problem"
        Me.ProblemColumn.Name = "ProblemColumn"
        Me.ProblemColumn.ReadOnly = True
        Me.ProblemColumn.Width = 145
        '
        'ActivityColumn
        '
        Me.ActivityColumn.DataPropertyName = "Activity"
        Me.ActivityColumn.HeaderText = "Downtime Status / Activity"
        Me.ActivityColumn.Name = "ActivityColumn"
        Me.ActivityColumn.ReadOnly = True
        Me.ActivityColumn.Width = 255
        '
        'DatetimeStartedColumn
        '
        Me.DatetimeStartedColumn.DataPropertyName = "DatetimeStarted"
        DataGridViewCellStyle2.Format = "g"
        Me.DatetimeStartedColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.DatetimeStartedColumn.HeaderText = "Start"
        Me.DatetimeStartedColumn.Name = "DatetimeStartedColumn"
        Me.DatetimeStartedColumn.ReadOnly = True
        Me.DatetimeStartedColumn.Width = 120
        '
        'DatetimeEndedColumn
        '
        Me.DatetimeEndedColumn.DataPropertyName = "DatetimeEnded"
        DataGridViewCellStyle3.Format = "g"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DatetimeEndedColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.DatetimeEndedColumn.HeaderText = "End"
        Me.DatetimeEndedColumn.Name = "DatetimeEndedColumn"
        Me.DatetimeEndedColumn.ReadOnly = True
        Me.DatetimeEndedColumn.Width = 120
        '
        'TotalAccumulatedTimeColumn
        '
        Me.TotalAccumulatedTimeColumn.DataPropertyName = "TotalAccumulatedDowntime"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TotalAccumulatedTimeColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.TotalAccumulatedTimeColumn.HeaderText = "Time"
        Me.TotalAccumulatedTimeColumn.Name = "TotalAccumulatedTimeColumn"
        Me.TotalAccumulatedTimeColumn.ReadOnly = True
        Me.TotalAccumulatedTimeColumn.Width = 60
        '
        'ShiftIdColumn
        '
        Me.ShiftIdColumn.DataPropertyName = "ShiftId"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ShiftIdColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.ShiftIdColumn.HeaderText = "Shift"
        Me.ShiftIdColumn.Name = "ShiftIdColumn"
        Me.ShiftIdColumn.ReadOnly = True
        Me.ShiftIdColumn.Width = 50
        '
        'SeniorEngineerApprovalDateColumn
        '
        Me.SeniorEngineerApprovalDateColumn.DataPropertyName = "SeniorEngineerApprovalDate"
        Me.SeniorEngineerApprovalDateColumn.HeaderText = "Date Approved"
        Me.SeniorEngineerApprovalDateColumn.Name = "SeniorEngineerApprovalDateColumn"
        Me.SeniorEngineerApprovalDateColumn.ReadOnly = True
        Me.SeniorEngineerApprovalDateColumn.Width = 120
        '
        'SeniorEngineerIsApprovedColumn
        '
        Me.SeniorEngineerIsApprovedColumn.DataPropertyName = "SeniorManagerIsApproved"
        Me.SeniorEngineerIsApprovedColumn.HeaderText = "*"
        Me.SeniorEngineerIsApprovedColumn.Name = "SeniorEngineerIsApprovedColumn"
        Me.SeniorEngineerIsApprovedColumn.ReadOnly = True
        Me.SeniorEngineerIsApprovedColumn.Width = 25
        '
        'grpStatus
        '
        Me.grpStatus.BackColor = System.Drawing.Color.White
        Me.grpStatus.Controls.Add(Me.rdPending)
        Me.grpStatus.Controls.Add(Me.rdApproved)
        Me.grpStatus.Location = New System.Drawing.Point(1, 559)
        Me.grpStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Padding = New System.Windows.Forms.Padding(0)
        Me.grpStatus.Size = New System.Drawing.Size(197, 36)
        Me.grpStatus.TabIndex = 159
        Me.grpStatus.TabStop = False
        '
        'rdPending
        '
        Me.rdPending.AutoSize = True
        Me.rdPending.Location = New System.Drawing.Point(101, 12)
        Me.rdPending.Name = "rdPending"
        Me.rdPending.Size = New System.Drawing.Size(76, 18)
        Me.rdPending.TabIndex = 2
        Me.rdPending.TabStop = True
        Me.rdPending.Text = "Pending"
        Me.rdPending.UseVisualStyleBackColor = True
        '
        'rdApproved
        '
        Me.rdApproved.AutoSize = True
        Me.rdApproved.Location = New System.Drawing.Point(10, 12)
        Me.rdApproved.Name = "rdApproved"
        Me.rdApproved.Size = New System.Drawing.Size(85, 18)
        Me.rdApproved.TabIndex = 1
        Me.rdApproved.TabStop = True
        Me.rdApproved.Text = "Approved"
        Me.rdApproved.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRefresh.DefaultScheme = False
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRefresh.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnRefresh.Hint = ""
        Me.btnRefresh.Location = New System.Drawing.Point(201, 565)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRefresh.Size = New System.Drawing.Size(100, 30)
        Me.btnRefresh.TabIndex = 160
        Me.btnRefresh.Text = "Refresh"
        '
        'frmMntTrxApproval
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1314, 601)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.grpStatus)
        Me.Controls.Add(Me.dgvTransactionHeader)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnReturn)
        Me.Controls.Add(Me.btnApprove)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMntTrxApproval"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaction Approval"
        CType(Me.dgvTransactionHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnView As PinkieControls.ButtonXP
    Friend WithEvents btnReturn As PinkieControls.ButtonXP
    Friend WithEvents btnApprove As PinkieControls.ButtonXP
    Friend WithEvents dgvTransactionHeader As System.Windows.Forms.DataGridView
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents rdPending As System.Windows.Forms.RadioButton
    Friend WithEvents rdApproved As System.Windows.Forms.RadioButton
    Friend WithEvents btnRefresh As PinkieControls.ButtonXP
    Friend WithEvents IsSelectedColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TrxIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProblemColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatetimeStartedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatetimeEndedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAccumulatedTimeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeniorEngineerApprovalDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeniorEngineerIsApprovedColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
