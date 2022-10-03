<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MntMchCs
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnReset = New PinkieControls.ButtonXP()
        Me.btnSearch = New PinkieControls.ButtonXP()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.ColMonthId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMonthName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWeekId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNickname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTrxId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLinkChecksheet = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.ColViewChecksheet = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ColViewActivity = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnRefresh = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.cmbMachineName = New SergeUtils.EasyCompletionComboBox()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.lblYearId = New System.Windows.Forms.Label()
        Me.txtYearId = New System.Windows.Forms.MaskedTextBox()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReset.DefaultScheme = True
        Me.btnReset.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnReset.Hint = "Remove filter"
        Me.btnReset.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Undo_16_x_16
        Me.btnReset.Location = New System.Drawing.Point(615, 2)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnReset.Size = New System.Drawing.Size(85, 29)
        Me.btnReset.TabIndex = 552
        Me.btnReset.Text = "Reset"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearch.DefaultScheme = True
        Me.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSearch.Hint = "Search"
        Me.btnSearch.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Find_16_x_16
        Me.btnSearch.Location = New System.Drawing.Point(526, 2)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSearch.Size = New System.Drawing.Size(85, 29)
        Me.btnSearch.TabIndex = 551
        Me.btnSearch.Text = "Search"
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeRows = False
        Me.dgvList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeight = 25
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColMonthId, Me.ColMonthName, Me.ColWeekId, Me.ColNickname, Me.ColTrxId, Me.ColLinkChecksheet, Me.ColViewChecksheet, Me.ColViewActivity})
        Me.dgvList.Location = New System.Drawing.Point(0, 33)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(784, 490)
        Me.dgvList.TabIndex = 553
        '
        'ColMonthId
        '
        Me.ColMonthId.DataPropertyName = "MonthId"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColMonthId.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColMonthId.HeaderText = "MonthId"
        Me.ColMonthId.Name = "ColMonthId"
        Me.ColMonthId.ReadOnly = True
        Me.ColMonthId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColMonthId.Visible = False
        Me.ColMonthId.Width = 80
        '
        'ColMonthName
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColMonthName.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColMonthName.HeaderText = "Month"
        Me.ColMonthName.Name = "ColMonthName"
        Me.ColMonthName.ReadOnly = True
        Me.ColMonthName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColMonthName.Width = 60
        '
        'ColWeekId
        '
        Me.ColWeekId.DataPropertyName = "WeekId"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColWeekId.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColWeekId.HeaderText = "Week"
        Me.ColWeekId.Name = "ColWeekId"
        Me.ColWeekId.ReadOnly = True
        Me.ColWeekId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColWeekId.Width = 50
        '
        'ColNickname
        '
        Me.ColNickname.DataPropertyName = "Nickname"
        Me.ColNickname.HeaderText = "Activity By"
        Me.ColNickname.Name = "ColNickname"
        Me.ColNickname.ReadOnly = True
        Me.ColNickname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColNickname.Width = 75
        '
        'ColTrxId
        '
        Me.ColTrxId.DataPropertyName = "TrxId"
        Me.ColTrxId.HeaderText = "TrxId"
        Me.ColTrxId.Name = "ColTrxId"
        Me.ColTrxId.ReadOnly = True
        Me.ColTrxId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColTrxId.Visible = False
        '
        'ColLinkChecksheet
        '
        Me.ColLinkChecksheet.DataPropertyName = "LinkChecksheet"
        Me.ColLinkChecksheet.HeaderText = "Link"
        Me.ColLinkChecksheet.Name = "ColLinkChecksheet"
        Me.ColLinkChecksheet.ReadOnly = True
        Me.ColLinkChecksheet.TrackVisitedState = False
        '
        'ColViewChecksheet
        '
        Me.ColViewChecksheet.HeaderText = ""
        Me.ColViewChecksheet.Name = "ColViewChecksheet"
        Me.ColViewChecksheet.ReadOnly = True
        Me.ColViewChecksheet.ToolTipText = "View checksheet"
        Me.ColViewChecksheet.Width = 30
        '
        'ColViewActivity
        '
        Me.ColViewActivity.HeaderText = ""
        Me.ColViewActivity.Name = "ColViewActivity"
        Me.ColViewActivity.ReadOnly = True
        Me.ColViewActivity.ToolTipText = "View activity"
        Me.ColViewActivity.Width = 30
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRefresh.DefaultScheme = True
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRefresh.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnRefresh.Hint = "Refresh the data"
        Me.btnRefresh.Image = Global.MachineMonitoringSystem.My.Resources.Resources.Refresh_16_x_16
        Me.btnRefresh.Location = New System.Drawing.Point(596, 526)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRefresh.Size = New System.Drawing.Size(90, 32)
        Me.btnRefresh.TabIndex = 556
        Me.btnRefresh.Text = "Refresh"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(690, 526)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 555
        Me.btnClose.Text = "Close"
        '
        'cmbMachineName
        '
        Me.cmbMachineName.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbMachineName.FormattingEnabled = True
        Me.cmbMachineName.Location = New System.Drawing.Point(73, 4)
        Me.cmbMachineName.Name = "cmbMachineName"
        Me.cmbMachineName.Size = New System.Drawing.Size(316, 25)
        Me.cmbMachineName.TabIndex = 559
        '
        'lblMachineName
        '
        Me.lblMachineName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMachineName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMachineName.ForeColor = System.Drawing.Color.Black
        Me.lblMachineName.Location = New System.Drawing.Point(4, 4)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblMachineName.Size = New System.Drawing.Size(70, 25)
        Me.lblMachineName.TabIndex = 560
        Me.lblMachineName.Text = "Machine"
        Me.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblYearId
        '
        Me.lblYearId.BackColor = System.Drawing.SystemColors.Control
        Me.lblYearId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYearId.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblYearId.ForeColor = System.Drawing.Color.Black
        Me.lblYearId.Location = New System.Drawing.Point(392, 4)
        Me.lblYearId.Name = "lblYearId"
        Me.lblYearId.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblYearId.Size = New System.Drawing.Size(60, 25)
        Me.lblYearId.TabIndex = 561
        Me.lblYearId.Text = "Year"
        Me.lblYearId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtYearId
        '
        Me.txtYearId.BeepOnError = True
        Me.txtYearId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYearId.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYearId.Location = New System.Drawing.Point(451, 4)
        Me.txtYearId.Mask = "0000"
        Me.txtYearId.Name = "txtYearId"
        Me.txtYearId.ResetOnSpace = False
        Me.txtYearId.Size = New System.Drawing.Size(70, 25)
        Me.txtYearId.TabIndex = 562
        Me.txtYearId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MntMchCs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.txtYearId)
        Me.Controls.Add(Me.lblYearId)
        Me.Controls.Add(Me.lblMachineName)
        Me.Controls.Add(Me.cmbMachineName)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSearch)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MntMchCs"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Machine Checksheet"
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnReset As PinkieControls.ButtonXP
    Friend WithEvents btnSearch As PinkieControls.ButtonXP
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents btnRefresh As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents cmbMachineName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblMachineName As Label
    Friend WithEvents lblYearId As Label
    Friend WithEvents txtYearId As MaskedTextBox
    Friend WithEvents ColMonthId As DataGridViewTextBoxColumn
    Friend WithEvents ColMonthName As DataGridViewTextBoxColumn
    Friend WithEvents ColWeekId As DataGridViewTextBoxColumn
    Friend WithEvents ColNickname As DataGridViewTextBoxColumn
    Friend WithEvents ColTrxId As DataGridViewTextBoxColumn
    Friend WithEvents ColLinkChecksheet As DataGridViewLinkColumn
    Friend WithEvents ColViewChecksheet As DataGridViewButtonColumn
    Friend WithEvents ColViewActivity As DataGridViewButtonColumn
End Class
