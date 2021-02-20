Imports MachineMonitoringSystem.dsMonitoringTableAdapters
Imports MachineMonitoringSystem.dsMonitoring
Imports System.Reflection
Imports System.ComponentModel

Public Class frmMntTrxConsole
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
    'for columns of dgvmachine
    Private dtMachine As New MntMachineDataTable
    Private dtAreaName As New MntAreaDataTable
    'for columns of dgvheader
    Private dtTransactionHeader As New MntTransactionHeaderDataTable
    Private dtNickname As New SecUserDataTable
    Private dtMachineName As New MntMachineDataTable
    Private dtTransactionStatusName As New GenTransactionStatusDataTable
    Private rowWorkgroup As SecWorkgroupRow
    'for activity column
    Private dtLastDetail As New DataTable

    Public Sub New(ByVal _userId As Integer, ByVal _workgroupId As Integer, ByVal _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        workgroupId = _workgroupId
        isAdmin = _isAdmin

        Me.adpMachine.Fill(Me.myDataset.MntMachine)
        Me.adpAreaName.Fill(Me.myDataset.MntArea)

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

    Private Sub frmMntTrxConsole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rowWorkgroup = Me.myDataset.SecWorkgroup.FindByWorkgroupId(workgroupId)

        If Not isAdmin Then
            isTechnicianManual = rowWorkgroup.IsTechnicianManual
            isDatetimeManual = rowWorkgroup.IsDatetimeManual
            isImageRequired = rowWorkgroup.IsImageRequired
            isAllowEdit = rowWorkgroup.IsAllowEdit
            isAllowDelete = rowWorkgroup.IsAllowDelete
        End If

        btnDelete.Enabled = isAllowDelete

        Me.bsMachine.DataSource = Me.myDataset
        Me.bsMachine.DataMember = dtMachine.TableName
        Me.bsMachine.Filter = "IsActive = 1"
        Me.bsMachine.Sort = "MachineStatusId DESC, MachineName ASC"

        Me.bsAreaName.DataSource = Me.myDataset
        Me.bsAreaName.DataMember = dtAreaName.TableName

        'dgvmachine - areaname column
        Dim _colAreaName As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        _colAreaName.DataPropertyName = "AreaId"
        _colAreaName.HeaderText = "Area"
        _colAreaName.DataSource = Me.bsAreaName
        _colAreaName.ValueMember = "AreaId"
        _colAreaName.DisplayMember = "AreaName"
        _colAreaName.Width = 100
        _colAreaName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        _colAreaName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        _colAreaName.SortMode = DataGridViewColumnSortMode.Automatic
        dgvMachine.Columns.Insert(2, _colAreaName)

        dgvMachine.AutoGenerateColumns = False
        dgvMachine.DataSource = Me.bsMachine

        Me.bsTransactionHeader.DataSource = Me.myDataset
        Me.bsTransactionHeader.DataMember = dtTransactionHeader.TableName
        Me.bsTransactionHeader.Sort = "TrxId DESC, DatetimeEnded DESC"

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
        dgvTransactionHeader.Columns.Insert(1, _colNickname)

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
        dgvTransactionHeader.Columns.Insert(3, _colMachineName)

        Me.bsTransactionStatusName.DataSource = Me.myDataset
        Me.bsTransactionStatusName.DataMember = dtTransactionStatusName.TableName

        Dim _colTransactionStatusName As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        _colTransactionStatusName.DataPropertyName = "TrxStatusId"
        _colTransactionStatusName.HeaderText = "Status"
        _colTransactionStatusName.DataSource = Me.bsTransactionStatusName
        _colTransactionStatusName.ValueMember = "TrxStatusId"
        _colTransactionStatusName.DisplayMember = "TrxStatusName"
        _colTransactionStatusName.Width = 70
        _colTransactionStatusName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        _colTransactionStatusName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        _colTransactionStatusName.SortMode = DataGridViewColumnSortMode.Automatic
        dgvTransactionHeader.Columns.Insert(8, _colTransactionStatusName)

        dgvTransactionHeader.AutoGenerateColumns = False
        dgvTransactionHeader.DataSource = Me.bsTransactionHeader
        'Me.SetPagedDataSource(Me.myDataset.MntTransactionHeader, bindingNavigator)

        SearchCriteria()

        rdDone.Checked = True

        method.EnableDoubleBuffered(dgvMachine)
        method.EnableDoubleBuffered(dgvTransactionHeader)
    End Sub

    'Public Sub SetPagedDataSource(ByVal _dataTable As DataTable, ByVal _bindingNavigator As BindingNavigator)
    '    If _dataTable Is Nothing OrElse _bindingNavigator Is Nothing Then
    '        Return
    '    End If

    '    Dim _dt As DataTable = Nothing
    '    Dim _counter As Integer = 1
    '    bsPagedTransactionHeader = New BindingSource()
    '    myDatatable = New BindingList(Of DataTable)()

    '    _dataTable.DefaultView.Sort = "TrxId DESC, DatetimeEnded DESC"
    '    'If Not _transactionStatusId = 3 Then
    '    '    _dataTable.DefaultView.RowFilter = String.Format("TrxStatusId = '{0}'", _transactionStatusId)
    '    'End If
    '    _dataTable = _dataTable.DefaultView.ToTable

    '    For Each _dataRow As DataRow In _dataTable.Rows
    '        If _counter = 1 Then
    '            _dt = _dataTable.Clone()

    '            myDatatable.Add(_dt)
    '        End If

    '        _dt.Rows.Add(_dataRow.ItemArray)

    '        If pageSize < System.Threading.Interlocked.Increment(_counter) Then
    '            _counter = 1
    '        End If
    '    Next

    '    _bindingNavigator.BindingSource = bsPagedTransactionHeader
    '    bsPagedTransactionHeader.DataSource = myDatatable
    'End Sub

    'Private Sub bs_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles bsPagedTransactionHeader.PositionChanged
    '    Try
    '        dgvTransactionHeader.DataSource = myDatatable(Me.bsPagedTransactionHeader.Position)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Shared Function ConvertListToDataTable(ByVal list As BindingList(Of String())) As DataTable
    '    Dim table As DataTable = New DataTable()
    '    Dim columns As Integer = 0

    '    For Each array In list

    '        If array.Length > columns Then
    '            columns = array.Length
    '        End If
    '    Next

    '    For i As Integer = 0 To columns - 1
    '        table.Columns.Add()
    '    Next

    '    For Each array In list
    '        table.Rows.Add(array)
    '    Next

    '    Return table
    'End Function

    Private Sub frmMntTrxConsole_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        method.FormTrap(Me)
    End Sub

    Private Sub frmMntTrxConsole_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F2) Then
            btnCreate.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F5) Then
            btnRefresh.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F8) Then
            If isAllowDelete Then
                btnDelete.PerformClick()
            End If
        End If
    End Sub

    Private Sub frmMntTrxConsole_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvMachine.Dispose()
        dgvTransactionHeader.Dispose()
        tmrElapsedTime.Stop()
    End Sub

    Private Sub dgvMachine_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvMachine.CellFormatting
        Try
            'for loop was used to access hidden column unlike DataGridViewCellFormattingEventArgs
            For i As Integer = 0 To dgvMachine.Rows.Count - 1
                machineStatusId = dgvMachine.Rows(i).Cells("MachineStatusIdColumn").Value

                If machineStatusId = 1 Then
                    dgvMachine.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen 'productive
                ElseIf machineStatusId = 2 Then
                    dgvMachine.Rows(i).DefaultCellStyle.BackColor = Color.Orange 'pm
                Else
                    dgvMachine.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral 'repair
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvMachine_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvMachine.DataBindingComplete
        Try
            dtMachineLastTransaction = Me.adpMachine.GetLastTransactionByMachineid(Nothing)

            For Each _row As DataRow In dtMachineLastTransaction.Rows
                For _i As Integer = 0 To dgvMachine.Rows.Count - 1
                    If Not _row("MachineId") Is DBNull.Value Then
                        If dgvMachine.Rows(_i).Cells("MachineIdColumn").Value = _row("MachineId") Then
                            dgvMachine.Rows(_i).Cells("LastTransactionColumn").Value = _row("TrxTo").ToString.Trim()
                        End If
                    End If
                Next
            Next

            tmrElapsedTime.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tmrElapsed_Tick(sender As Object, e As EventArgs) Handles tmrElapsedTime.Tick
        Try
            For i As Integer = 0 To dgvMachine.Rows.Count - 1
                If Not dgvMachine.Rows(i).Cells("LastTransactionColumn").Value = "" Then
                    tmrLastTransaction = dgvMachine.Rows(i).Cells("LastTransactionColumn").Value

                    If Not tmrLastTransaction = "01/01/0001 12:00:00 AM" Then
                        tmrSpan = (tmrLastTransaction - DateTime.Now).Duration()
                        tmrMinutes = tmrSpan.Minutes
                        tmrHours = tmrSpan.Hours
                        tmrDays = tmrSpan.Days

                        dgvMachine.Rows(i).Cells("ElapsedTimeColumn").Value = tmrDays.ToString("00") & ":" & tmrHours.ToString("00") & ":" & tmrMinutes.ToString("00")
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvMachine_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMachine.SelectionChanged
        dgvMachine.ClearSelection()
    End Sub

    Private Sub dgvTransactionHeader_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTransactionHeader.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    '2/19
    Private Sub dgvTransactionHeader_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvTransactionHeader.DataBindingComplete
        Try
            dtLastDetail = Me.adpTransactionHeader.GetLastDetailByMachineId(Nothing)

            For Each _row As DataRow In dtLastDetail.Rows
                For _i As Integer = 0 To dgvTransactionHeader.Rows.Count - 1
                    If dgvTransactionHeader.Rows(_i).Cells(0).Value = _row("TrxId") Then
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

        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Try
            Using frmDetail As New frmMntTrxDetail(userId, workgroupId, isAdmin, isTechnicianManual, isImageRequired, isAllowEdit, isAllowDelete, Me.myDataset)
                frmDetail.ShowDialog(Me)

                Me.bsTransactionHeader.EndEdit()
                Me.bsMachine.EndEdit()

                If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                    If Me.myDataset.HasChanges() Then
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

                    Me.bsTransactionHeader.MoveFirst()
                Else
                    Me.bsTransactionHeader.CancelEdit()
                End If
            End Using

            'Me.SetPagedDataSource(Me.myDataset.MntTransactionHeader, bindingNavigator)
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbSearchCriteria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSearchCriteria.SelectedValueChanged

    End Sub

    Private Sub btnStartSearch_Click(sender As Object, e As EventArgs) 'Handles btnStartSearch.Click

    End Sub

    Private Sub btnStartReset_Click(sender As Object, e As EventArgs) 'Handles btnStartReset.Click

    End Sub

    Private Sub btnEndSearch_Click(sender As Object, e As EventArgs) 'Handles btnEndSearch.Click

    End Sub

    Private Sub btnEndReset_Click(sender As Object, e As EventArgs) 'Handles btnEndReset.Click

    End Sub

    Private Sub cmbSearchMachineName_SelectedValueChanged(sender As Object, e As EventArgs) 'Handles cmbSearchMachineName.SelectedValueChanged

    End Sub

    Private Sub btnMachineReset_Click(sender As Object, e As EventArgs) 'Handles btnMachineReset.Click

    End Sub

    Private Sub cmbSearchMachineStatus_SelectedValueChanged(sender As Object, e As EventArgs) 'Handles cmbSearchMachineStatus.SelectedValueChanged

    End Sub

    Private Sub btnMachineStatusReset_Click(sender As Object, e As EventArgs) 'Handles btnMachineStatusReset.Click

    End Sub

    Private Sub cmbSearchUser_SelectedValueChanged(sender As Object, e As EventArgs) 'Handles cmbSearchUser.SelectedValueChanged

    End Sub

    Private Sub btnUserReset_Click(sender As Object, e As EventArgs) 'Handles btnUserReset.Click

    End Sub

    Private Sub trxStatus_CheckedChanged(sender As Object, e As EventArgs) Handles rdAll.CheckedChanged, rdDone.CheckedChanged, rdOngoing.CheckedChanged
        If rdAll.Checked = True Then
            'Me.SetPagedDataSource(Me.myDataset.MntTransactionHeader, bindingNavigator, 3)
            transactionStatusId = 3
        ElseIf rdDone.Checked = True Then
            Me.bsTransactionHeader.Filter = String.Format("TrxStatusId = 1")
            transactionStatusId = 1
            'Me.SetPagedDataSource(Me.myDataset.MntTransactionHeader, bindingNavigator, 1)
        Else
            Me.bsTransactionHeader.Filter = String.Format("TrxStatusId = 2")
            transactionStatusId = 2
            'Me.SetPagedDataSource(Me.myDataset.MntTransactionHeader, bindingNavigator, 2)
        End If
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

    'Private Sub cmbSearchTechnician_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbSearchTechnician.SelectionChangeCommitted
    '    Me.bsPagedTransactionHeader.Filter = String.Format("UserId = '{0}'", cmbSearchTechnician.SelectedValue)
    '    'Me.bsPagedTransactionHeader.ResetBindings(False)
    '    Me.SetPagedDataSource(Me.myDataset.MntTransactionHeader, bindingNavigator)
    'End Sub

End Class