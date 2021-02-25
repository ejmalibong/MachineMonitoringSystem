Imports MachineMonitoringSystem.dsMonitoring
Imports MachineMonitoringSystem.dsMonitoringTableAdapters
Imports System.Reflection
Imports System.ComponentModel

Public Class frmMntTrxApproval
    Private method As New clsMethod
    Private dictionary As New Dictionary(Of String, Integer)
    'access control
    Private isAdmin As Boolean = True
    Private userId As Integer = 0
    Private workgroupId As Integer = 0
    Private isTechnicianManual As Boolean = True
    Private isDatetimeManual As Boolean = True
    Private isImageRequired As Boolean = True
    Private isAllowEdit As Boolean = True
    Private isAllowDelete As Boolean = True
    'constants
    Private machineStatusId As Integer = 1 'default to productive
    Private transactionStatusId As Integer = 1 'default to ongoing
    'elapsed time computation
    Private WithEvents tmrElapsedTime As New Timer
    Private tmrLastTransaction As New DateTime
    Private tmrSpan As TimeSpan = Nothing
    Private tmrMinutes As Integer = 0
    Private tmrHours As Integer = 0
    Private tmrDays As Integer = 0
    Private dtMachineLastTransaction As New DataTable
    'paginate the transactionheader
    Private pageSize As Integer = 50
    Private WithEvents bsPagedTransactionHeader As BindingSource
    Private WithEvents myDatatable As BindingList(Of DataTable)
    'access dataset
    Private myDataset As New dsMonitoring

    Private WithEvents bsMachine As New BindingSource
    Private WithEvents bsAreaName As New BindingSource

    Private WithEvents bsTransactionHeader As New BindingSource
    Private WithEvents bsNickname As New BindingSource
    Private WithEvents bsMachineName As New BindingSource
    Private WithEvents bsTransactionStatusName As New BindingSource

    Private WithEvents bsApproverName As New BindingSource

    Private WithEvents bsTransactionDetail As New BindingSource
    Private WithEvents bsTransactionMachinePart As New BindingSource
    Private WithEvents bsTransactionSparePart As New BindingSource
    Private WithEvents bsTransactionUser As New BindingSource
    Private WithEvents bsArea As New BindingSource
    Private WithEvents bsMntMachinePart As New BindingSource
    Private WithEvents bsTechnician As New BindingSource

    Private adpMachine As New MntMachineTableAdapter
    Private adpAreaName As New MntAreaTableAdapter

    Private adpTransactionHeader As New MntTransactionHeaderTableAdapter
    Private adpNickname As New SecUserTableAdapter
    Private adpMachineName As New MntMachineTableAdapter
    Private adpTransactionStatusName As New GenTransactionStatusTableAdapter

    Private adpApproverName As New SecUserTableAdapter

    Private adpTransactionDetail As New MntTransactionDetailTableAdapter
    Private adpTransactionMachinePart As New MntTransactionMachinePartTableAdapter
    Private adpTransactionSparePart As New MntTransactionSparePartTableAdapter
    Private adpTransactionUser As New MntTransactionUserTableAdapter
    Private adpUser As New SecUserTableAdapter
    Private adpWorkgroup As New SecWorkgroupTableAdapter
    Private adpArea As New MntAreaTableAdapter
    Private adpTransactionStatus As New GenTransactionStatusTableAdapter
    Private adpRoutingStatus As New GenRoutingStatusTableAdapter
    Private adpMachineStatus As New MntMachineStatusTableAdapter
    Private adpMachinePart As New MntMachinePartTableAdapter
    Private adpTechnician As New SecUserTableAdapter
    'additional objects
    'for columns of dgvmachine
    Private dtMachine As New MntMachineDataTable
    Private dtAreaName As New MntAreaDataTable
    'for columns of dgvheader
    Private dtTransactionHeader As New MntTransactionHeaderDataTable
    Private dtApprover As New SecUserDataTable
    Private dtNickname As New SecUserDataTable
    Private dtMachineName As New MntMachineDataTable
    Private dtTransactionStatusName As New GenTransactionStatusDataTable
    Private rowWorkgroup As SecWorkgroupRow
    'for activity column
    Private dtLastDetail As New DataTable
    'for updating status of each dgv
    Private adpTransactionHeaderActivity As New MntTransactionHeaderTableAdapter
    Private adpMachineStatusColumn As New MntMachineTableAdapter
    'check all column
    Private chkSelectAll As New CheckBox

    Public Sub New(ByVal _userId As Integer, ByVal _workgroupId As Integer, ByVal _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        workgroupId = _workgroupId
        isAdmin = _isAdmin

        Me.adpMachine.Fill(Me.myDataset.MntMachine)
        Me.adpAreaName.Fill(Me.myDataset.MntArea)

        Me.adpApproverName.Fill(Me.myDataset.SecUser)

        Me.adpTransactionHeader.Fill(Me.myDataset.MntTransactionHeader)
        Me.adpNickname.Fill(Me.myDataset.SecUser)
        Me.adpMachineName.Fill(Me.myDataset.MntMachine)
        Me.adpTransactionStatusName.Fill(Me.myDataset.GenTransactionStatus)

        Me.adpTransactionDetail.Fill(Me.myDataset.MntTransactionDetail)
        Me.adpTransactionMachinePart.Fill(Me.myDataset.MntTransactionMachinePart)
        Me.adpTransactionSparePart.Fill(Me.myDataset.MntTransactionSparePart)
        Me.adpTransactionUser.Fill(Me.myDataset.MntTransactionUser)
        Me.adpWorkgroup.Fill(Me.myDataset.SecWorkgroup)
        Me.adpUser.Fill(Me.myDataset.SecUser)
        Me.adpArea.Fill(Me.myDataset.MntArea)
        Me.adpTransactionStatus.Fill(Me.myDataset.GenTransactionStatus)
        Me.adpRoutingStatus.Fill(Me.myDataset.GenRoutingStatus)
        Me.adpMachineStatus.Fill(Me.myDataset.MntMachineStatus)
        Me.adpMachinePart.Fill(Me.myDataset.MntMachinePart)
    End Sub

    Private Sub frmMntTrxApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rowWorkgroup = Me.myDataset.SecWorkgroup.FindByWorkgroupId(workgroupId)

        If Not isAdmin Then
            isTechnicianManual = rowWorkgroup.IsTechnicianManual
            isDatetimeManual = rowWorkgroup.IsDatetimeManual
            isImageRequired = rowWorkgroup.IsImageRequired
            isAllowEdit = rowWorkgroup.IsAllowEdit
            isAllowDelete = rowWorkgroup.IsAllowDelete
        End If

        btnView.Enabled = isAllowDelete

        Me.bsTransactionHeader.DataSource = Me.myDataset
        Me.bsTransactionHeader.DataMember = dtTransactionHeader.TableName
        Me.bsTransactionHeader.Sort = "DatetimeEnded DESC, TrxId DESC"

        chkSelectAll = New CheckBox()
        Dim _rect As Rectangle = Me.dgvTransactionHeader.GetCellDisplayRectangle(0, -1, True)
        chkSelectAll.Size = New Size(18, 18)
        _rect.Offset(5, 5)
        chkSelectAll.Location = _rect.Location
        Me.dgvTransactionHeader.Controls.Add(chkSelectAll)
        AddHandler chkSelectAll.CheckedChanged, AddressOf CheckAll

        Me.bsMachineName.DataSource = Me.myDataset
        Me.bsMachineName.DataMember = dtMachineName.TableName

        Dim _colMachineName As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        _colMachineName.DataPropertyName = "MachineId"
        _colMachineName.HeaderText = "Machine"
        _colMachineName.DataSource = Me.bsMachineName
        _colMachineName.ValueMember = "MachineId"
        _colMachineName.DisplayMember = "MachineName"
        _colMachineName.Width = 125
        _colMachineName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        _colMachineName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        _colMachineName.SortMode = DataGridViewColumnSortMode.Automatic
        dgvTransactionHeader.Columns.Insert(2, _colMachineName)

        Me.bsNickname.DataSource = Me.myDataset
        Me.bsNickname.DataMember = dtNickname.TableName

        Dim _colNickname As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        _colNickname.DataPropertyName = "UserId"
        _colNickname.HeaderText = "Technician"
        _colNickname.DataSource = Me.bsNickname
        _colNickname.ValueMember = "UserId"
        _colNickname.DisplayMember = "Nickname"
        _colNickname.Width = 99
        _colNickname.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        _colNickname.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        _colNickname.SortMode = DataGridViewColumnSortMode.Automatic
        dgvTransactionHeader.Columns.Insert(8, _colNickname)

        Me.bsApproverName.DataSource = Me.myDataset
        Me.bsApproverName.DataMember = dtApprover.TableName

        Dim _colApproverName As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        _colApproverName.DataPropertyName = "SeniorEngineerId"
        _colApproverName.HeaderText = "Approved By"
        _colApproverName.DataSource = Me.bsApproverName
        _colApproverName.ValueMember = "UserId"
        _colApproverName.DisplayMember = "Nickname"
        _colApproverName.Width = 99
        _colApproverName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        _colApproverName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        _colApproverName.SortMode = DataGridViewColumnSortMode.Automatic
        dgvTransactionHeader.Columns.Insert(10, _colApproverName)

        dgvTransactionHeader.AutoGenerateColumns = False
        dgvTransactionHeader.DataSource = Me.bsTransactionHeader

        SearchCriteria()

        rdPending.Checked = True

        method.EnableDoubleBuffered(dgvTransactionHeader)
    End Sub

    Private Sub frmMntTrxConsole_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        method.FormTrap(Me)
    End Sub

    Private Sub frmMntTrxConsole_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F2) Then
            btnApprove.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F3) Then
            btnReturn.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F5) Then
            btnRefresh.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F8) Then
            If isAllowDelete Then
                btnView.PerformClick()
            End If
        End If
    End Sub

    Private Sub frmMntTrxConsole_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvTransactionHeader.Dispose()
        tmrElapsedTime.Stop()
    End Sub

    Private Sub dgvTransactionHeader_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTransactionHeader.CellDoubleClick
        btnReturn.PerformClick()
    End Sub

    Private Sub dgvTransactionHeader_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvTransactionHeader.DataBindingComplete
        Try
            dtLastDetail = Me.adpTransactionHeaderActivity.GetLastDetailByMachineId(Nothing)

            For Each _row As DataRow In dtLastDetail.Rows
                For _i As Integer = 0 To dgvTransactionHeader.Rows.Count - 1
                    If dgvTransactionHeader.Rows(_i).Cells(1).Value = _row("TrxId") Then
                        dgvTransactionHeader.Rows(_i).Cells("ActivityColumn").Value = _row("Activity")
                    End If
                Next
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            Me.bsMachine.ResetBindings(False)
            Me.bsTransactionHeader.ResetBindings(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Try
            If dgvTransactionHeader.Rows.Count > 0 Then
                Dim _lstChkRow As New List(Of Integer)

                For _i = 0 To dgvTransactionHeader.RowCount - 1
                    If dgvTransactionHeader.Rows(_i).Cells("IsSelectedColumn").Value = True Then
                        _lstChkRow.Add(_i)
                    End If
                Next

                If Not _lstChkRow.Count = 0 Then
                    For Each _row As DataGridViewRow In dgvTransactionHeader.Rows
                        Dim _isSelected As Boolean = Convert.ToBoolean(_row.Cells("IsSelectedColumn").Value)
                        
                        If _isSelected Then
                            Dim _trxId As Integer = _row.Cells("TrxIdColumn").Value
                            Dim _transactionRow As MntTransactionHeaderRow = Me.myDataset.MntTransactionHeader.FindByTrxId(_trxId)
                            _transactionRow.SeniorEngineerIsApproved = 1
                            _transactionRow.SeniorEngineerApprovalDate = DateTime.Now
                            _transactionRow.SeniorEngineerId = userId
                            _transactionRow.RoutingStatusId = 3
                        End If
                    Next
                End If

                Me.adpTransactionHeader.Update(Me.myDataset.MntTransactionHeader)
                Me.myDataset.AcceptChanges()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Try
            If dgvTransactionHeader.Rows.Count > 0 Then

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try
            If Me.dgvTransactionHeader.SelectedRows.Count > 0 Then
                Dim _trxId As Integer = CType(Me.bsTransactionHeader.Current, DataRowView).Item("TrxId")

                Using frmDetail As New frmMntTrxDetail(userId, workgroupId, isAdmin, isTechnicianManual, isImageRequired, isAllowEdit, isAllowDelete, Me.myDataset, _trxId)
                    frmDetail.ShowDialog(Me)

                    Me.bsTransactionHeader.EndEdit()
                    Me.bsMachine.EndEdit()

                    If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                        If Me.myDataset.HasChanges Then
                            Me.adpTransactionHeader.Update(Me.myDataset.MntTransactionHeader)
                            Me.adpTransactionDetail.Update(Me.myDataset.MntTransactionDetail)
                            Me.adpTransactionMachinePart.Update(Me.myDataset.MntTransactionMachinePart)
                            Me.adpTransactionSparePart.Update(Me.myDataset.MntTransactionSparePart)
                            Me.adpTransactionUser.Update(Me.myDataset.MntTransactionUser)
                            Me.adpMachine.Update(Me.myDataset.MntMachine)
                            Me.myDataset.AcceptChanges()
                        End If

                        Me.bsMachine.ResetBindings(False)
                        Me.bsTransactionHeader.ResetBindings(False)
                    Else
                        Me.bsTransactionHeader.CancelEdit()
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub trxStatus_CheckedChanged(sender As Object, e As EventArgs) Handles rdApproved.CheckedChanged, rdPending.CheckedChanged
        If rdApproved.Checked = True Then
            Me.bsTransactionHeader.Filter = String.Format("SeniorEngineerIsApproved = 1")
            transactionStatusId = 1
        Else
            Me.bsTransactionHeader.Filter = String.Format("SeniorEngineerIsApproved = 0")
            transactionStatusId = 2
        End If
    End Sub

    Private Sub CheckAll(ByVal sender As Object, ByVal e As EventArgs)
        For k As Integer = 0 To Me.dgvTransactionHeader.RowCount - 1
            Me.dgvTransactionHeader(0, k).Value = Me.chkSelectAll.Checked
        Next
        Me.dgvTransactionHeader.EndEdit()
    End Sub

    Private Sub SearchCriteria()
        dictionary.Add(" Start Date", 1)
        dictionary.Add(" End Date", 2)
        dictionary.Add(" Technician", 3)
        dictionary.Add(" Machine Name", 4)
        dictionary.Add(" Downtime Status", 5)

        cmbSearchCriteria.DisplayMember = "Key"
        cmbSearchCriteria.ValueMember = "Value"

        cmbSearchCriteria.DataSource = New BindingSource(dictionary, Nothing)
    End Sub

End Class