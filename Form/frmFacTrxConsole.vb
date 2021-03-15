Imports MachineMonitoringSystem.dsMonitoring
Imports MachineMonitoringSystem.dsMonitoringTableAdapters
Imports System.Reflection
Imports System.ComponentModel

Public Class frmFacTrxConsole
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
    Private indexScroll As Integer = 0
    Private indexPosition As Integer = 0
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
    Private WithEvents bsFloor As New BindingSource

    Private WithEvents bsTransactionHeader As New BindingSource
    Private WithEvents bsNickname As New BindingSource
    Private WithEvents bsMachineName As New BindingSource
    Private WithEvents bsTransactionStatusName As New BindingSource

    Private WithEvents bsTransactionDetail As New BindingSource
    Private WithEvents bsTransactionUser As New BindingSource
    Private WithEvents bsArea As New BindingSource
    Private WithEvents bsMntMachinePart As New BindingSource
    Private WithEvents bsTechnician As New BindingSource

    Private adpMachine As New FacMachineTableAdapter
    Private adpFloor As New FacFloorTableAdapter

    Private adpTransactionHeader As New FacTransactionHeaderTableAdapter
    Private adpNickname As New SecUserTableAdapter
    Private adpMachineName As New FacMachineTableAdapter
    Private adpTransactionStatusName As New GenTransactionStatusTableAdapter

    Private adpTransactionDetail As New FacTransactionDetailTableAdapter
    Private adpTransactionUser As New FacTransactionUserTableAdapter
    Private adpUser As New SecUserTableAdapter
    Private adpWorkgroup As New SecWorkgroupTableAdapter
    Private adpTransactionStatus As New GenTransactionStatusTableAdapter
    Private adpRoutingStatus As New GenRoutingStatusTableAdapter
    Private adpMachineStatus As New FacMachineStatusTableAdapter
    Private adpTechnician As New SecUserTableAdapter

    'for columns of dgvmachine
    Private dtMachine As New FacMachineDataTable
    Private dtFloor As New FacFloorDataTable
    'for columns of dgvheader
    Private dtTransactionHeader As New FacTransactionHeaderDataTable
    Private dtNickname As New SecUserDataTable
    Private dtMachineName As New FacMachineDataTable
    Private dtTransactionStatusName As New GenTransactionStatusDataTable
    Private rowWorkgroup As SecWorkgroupRow
    'for activity column
    Private dtLastDetail As New DataTable
    'for updating status of each dgv
    Private adpTransactionHeaderActivity As New FacTransactionHeaderTableAdapter
    Private adpMachineStatusColumn As New FacMachineTableAdapter

    Private counter As Integer = 0

    Public Sub New(ByVal _userId As Integer, ByVal _workgroupId As Integer, ByVal _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        workgroupId = _workgroupId
        isAdmin = _isAdmin

        'RefreshValues()

        Me.myDataset.EnforceConstraints = False
        Me.adpMachine.Fill(Me.myDataset.FacMachine)
        Me.adpFloor.Fill(Me.myDataset.FacFloor)

        Me.adpTransactionHeader.Fill(Me.myDataset.FacTransactionHeader)
        Me.adpNickname.Fill(Me.myDataset.SecUser)
        Me.adpMachineName.Fill(Me.myDataset.FacMachine)
        Me.adpTransactionStatusName.Fill(Me.myDataset.GenTransactionStatus)

        Me.adpTransactionDetail.Fill(Me.myDataset.FacTransactionDetail)
        Me.adpTransactionUser.Fill(Me.myDataset.FacTransactionUser)
        Me.adpWorkgroup.Fill(Me.myDataset.SecWorkgroup)
        Me.adpUser.Fill(Me.myDataset.SecUser)
        Me.adpTransactionStatus.Fill(Me.myDataset.GenTransactionStatus)
        Me.adpRoutingStatus.Fill(Me.myDataset.GenRoutingStatus)
        Me.adpMachineStatus.Fill(Me.myDataset.FacMachineStatus)
        Me.myDataset.EnforceConstraints = True
    End Sub

    Private Sub frmFacTrxConsole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Me.bsFloor.DataSource = Me.myDataset
        Me.bsFloor.DataMember = dtFloor.TableName

        'dgvmachine - areaname column
        Dim _colFloor As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        _colFloor.DataPropertyName = "FloorId"
        _colFloor.HeaderText = "Flr"
        _colFloor.DataSource = Me.bsFloor
        _colFloor.ValueMember = "FloorId"
        _colFloor.DisplayMember = "ShortName"
        _colFloor.Width = 65
        _colFloor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        _colFloor.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        _colFloor.SortMode = DataGridViewColumnSortMode.Automatic
        dgvMachine.Columns.Insert(2, _colFloor)

        dgvMachine.AutoGenerateColumns = False
        dgvMachine.DataSource = Me.bsMachine

        Me.bsTransactionHeader.DataSource = Me.myDataset
        Me.bsTransactionHeader.DataMember = dtTransactionHeader.TableName
        Me.bsTransactionHeader.Sort = "DatetimeStarted DESC, TrxId DESC"

        Me.bsNickname.DataSource = Me.myDataset
        Me.bsNickname.DataMember = dtNickname.TableName

        Dim _colNickname As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        _colNickname.DataPropertyName = "UserId"
        _colNickname.HeaderText = "Technician"
        _colNickname.DataSource = Me.bsNickname
        _colNickname.ValueMember = "UserId"
        _colNickname.DisplayMember = "Nickname"
        _colNickname.Width = 100
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
        _colMachineName.DisplayMember = "MachineCode"
        _colMachineName.Width = 84
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

        SearchCriteria()

        rdOngoing.Checked = True

        method.EnableDoubleBuffered(dgvMachine)
        method.EnableDoubleBuffered(dgvTransactionHeader)

        tmrElapsedTime.Interval = 1000 '1 second
    End Sub

    Private Sub frmFacTrxConsole_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        method.FormTrap(Me)
    End Sub

    Private Sub frmFacTrxConsole_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F2) Then
            btnCreate.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F3) Then
            btnEdit.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F5) Then
            btnRefresh.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F8) Then
            If isAllowDelete Then
                btnDelete.PerformClick()
            End If
        End If
    End Sub

    Private Sub frmFacTrxConsole_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
            dtMachineLastTransaction = Me.adpMachineStatusColumn.GetLastTransactionByMachineId(Nothing)

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

            'counter = counter + 1

            ''5 minutes
            'If counter = 300 Then
            '    RefreshValues()
            '    counter = 0
            'End If
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
            dtLastDetail = Me.adpTransactionHeaderActivity.GetLastDetailByMachineId(Nothing)

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
            RefreshValues()
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Try
            Using frmDetail As New frmFacTrxDetail(userId, workgroupId, isAdmin, isTechnicianManual, isImageRequired, isAllowEdit, isAllowDelete, Me.myDataset)
                frmDetail.ShowDialog(Me)

                If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                    If Me.myDataset.HasChanges() Then
                        Me.adpTransactionHeader.Update(Me.myDataset.FacTransactionHeader)
                        Me.adpTransactionDetail.Update(Me.myDataset.FacTransactionDetail)
                        Me.adpTransactionUser.Update(Me.myDataset.FacTransactionUser)
                        Me.adpMachine.Update(Me.myDataset.FacMachine)
                        Me.myDataset.AcceptChanges()
                    End If
                Else
                    Me.bsTransactionHeader.CancelEdit()
                    Me.bsMachine.CancelEdit()
                    Me.myDataset.RejectChanges()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If Me.dgvTransactionHeader.SelectedRows.Count > 0 Then
                Dim _trxId As Integer = CType(Me.bsTransactionHeader.Current, DataRowView).Item("TrxId")

                Using frmDetail As New frmFacTrxDetail(userId, workgroupId, isAdmin, isTechnicianManual, isImageRequired, isAllowEdit, isAllowDelete, Me.myDataset, _trxId)
                    frmDetail.ShowDialog(Me)

                    Me.bsTransactionHeader.EndEdit()
                    Me.bsMachine.EndEdit()

                    If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
                        If Me.myDataset.HasChanges Then
                            Me.adpTransactionHeader.Update(Me.myDataset.FacTransactionHeader)
                            Me.adpTransactionDetail.Update(Me.myDataset.FacTransactionDetail)
                            Me.adpTransactionUser.Update(Me.myDataset.FacTransactionUser)
                            Me.adpMachine.Update(Me.myDataset.FacMachine)
                            Me.myDataset.AcceptChanges()
                        End If

                        'Me.bsMachine.ResetBindings(False)
                        'Me.bsTransactionHeader.ResetBindings(False)
                        'Me.bsTransactionHeader.MoveFirst()
                    Else
                        Me.bsTransactionHeader.CancelEdit()
                        Me.bsMachine.CancelEdit()
                        Me.myDataset.RejectChanges()
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If dgvTransactionHeader.Rows.Count > 0 Then
                Dim _currentRow = CType(Me.bsTransactionHeader.Current, DataRowView).Row
                Dim _rowState = _currentRow.RowState

                Select Case _rowState
                    Case DataRowState.Added
                        Me.bsTransactionHeader.RemoveCurrent()
                    Case DataRowState.Detached
                        Me.bsTransactionHeader.CancelEdit()
                    Case DataRowState.Modified, DataRowState.Unchanged
                        If dgvTransactionHeader.SelectedCells.Count > 0 AndAlso dgvTransactionHeader.SelectedCells(0).RowIndex = dgvTransactionHeader.NewRowIndex Then
                            Me.bsTransactionHeader.CancelEdit()
                            Exit Sub
                        End If

                        Dim message = String.Format("Delete this transaction?")
                        If MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Me.bsTransactionHeader.RemoveCurrent()
                        End If
                    Case Else
                End Select

                Me.adpTransactionHeader.Update(Me.myDataset.FacTransactionHeader)
                Me.adpMachine.Update(Me.myDataset.FacMachine)
                Me.myDataset.AcceptChanges()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbSearchCriteria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSearchCriteria.SelectedValueChanged

    End Sub

    Private Sub trxStatus_CheckedChanged(sender As Object, e As EventArgs) Handles rdAll.CheckedChanged, rdDone.CheckedChanged, rdOngoing.CheckedChanged
        If rdAll.Checked = True Then
            Me.bsTransactionHeader.Filter = String.Format("TrxStatusId IN (1,2)")
            transactionStatusId = 3
        ElseIf rdDone.Checked = True Then
            Me.bsTransactionHeader.Filter = String.Format("TrxStatusId = 1")
            transactionStatusId = 1
        Else
            Me.bsTransactionHeader.Filter = String.Format("TrxStatusId = 2")
            transactionStatusId = 2
        End If
    End Sub

    Public Sub RefreshValues()
        If dgvTransactionHeader IsNot Nothing AndAlso dgvTransactionHeader.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))

        Me.myDataset.EnforceConstraints = False
        Me.adpMachine.Fill(Me.myDataset.FacMachine)
        Me.adpFloor.Fill(Me.myDataset.FacFloor)

        Me.adpTransactionHeader.Fill(Me.myDataset.FacTransactionHeader)
        Me.adpNickname.Fill(Me.myDataset.SecUser)
        Me.adpMachineName.Fill(Me.myDataset.FacMachine)
        Me.adpTransactionStatusName.Fill(Me.myDataset.GenTransactionStatus)

        Me.adpTransactionDetail.Fill(Me.myDataset.FacTransactionDetail)
        Me.adpTransactionUser.Fill(Me.myDataset.FacTransactionUser)
        Me.adpWorkgroup.Fill(Me.myDataset.SecWorkgroup)
        Me.adpUser.Fill(Me.myDataset.SecUser)
        Me.adpTransactionStatus.Fill(Me.myDataset.GenTransactionStatus)
        Me.adpRoutingStatus.Fill(Me.myDataset.GenRoutingStatus)
        Me.adpMachineStatus.Fill(Me.myDataset.FacMachineStatus)
        Me.myDataset.EnforceConstraints = True

        If dgvTransactionHeader IsNot Nothing AndAlso dgvTransactionHeader.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub GetScrollingIndex()
        indexScroll = dgvTransactionHeader.FirstDisplayedCell.RowIndex
        indexPosition = dgvTransactionHeader.CurrentRow.Index
    End Sub

    Private Sub SetScrollingIndex()
        dgvTransactionHeader.FirstDisplayedScrollingRowIndex = indexScroll
        dgvTransactionHeader.Rows(indexPosition).Selected = True
    End Sub

    Private Sub SearchCriteria()
        dictionary.Add(" Start Date", 1)
        'dictionary.Add(" End Date", 2)
        'dictionary.Add(" Technician", 3)
        'dictionary.Add(" Machine Name", 4)
        'dictionary.Add(" Downtime Status", 5)

        cmbSearchCriteria.DisplayMember = "Key"
        cmbSearchCriteria.ValueMember = "Value"

        cmbSearchCriteria.DataSource = New BindingSource(dictionary, Nothing)
    End Sub

    'Private Sub cmbSearchTechnician_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbSearchTechnician.SelectionChangeCommitted
    '    Me.bsPagedTransactionHeader.Filter = String.Format("UserId = '{0}'", cmbSearchTechnician.SelectedValue)
    '    Me.bsPagedTransactionHeader.ResetBindings(False)
    '    Me.SetPagedDataSource(Me.myDataset.MntTransactionHeader, bindingNavigator)
    'End Sub

    Private Sub btnSearchDate_Click(sender As Object, e As EventArgs) Handles btnSearchDate.Click
        Try
            If dtpFrom.Value > dtpTo.Value Then
                MessageBox.Show("Invalid date range.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dtpFrom.Value.Equals(dtpTo.Value) Then
                If transactionStatusId = 3 Then
                    Me.bsTransactionHeader.Filter = String.Format("DatetimeStarted >= '" + method.FormatDate(dtpFrom.Value, True) + "' AND DatetimeStarted < '" + method.FormatDate(dtpFrom.Value, False) + "' AND TrxStatusId IN (1,2)")
                Else
                    Me.bsTransactionHeader.Filter = String.Format("DatetimeStarted >= '" + method.FormatDate(dtpFrom.Value, True) + "' AND DatetimeStarted < '" + method.FormatDate(dtpFrom.Value, False) + "' AND TrxStatusId = '{0}'", transactionStatusId)
                End If
            Else
                If transactionStatusId = 3 Then
                    Me.bsTransactionHeader.Filter = String.Format("DatetimeStarted >= '" + method.FormatDate(dtpFrom.Value, True) + "' AND DatetimeStarted < '" + method.FormatDate(dtpTo.Value, False) + "' AND TrxStatusId IN (1,2)")
                Else
                    Me.bsTransactionHeader.Filter = String.Format("DatetimeStarted >= '" + method.FormatDate(dtpFrom.Value, True) + "' AND DatetimeStarted < '" + method.FormatDate(dtpTo.Value, False) + "' AND TrxStatusId = '{0}'", transactionStatusId)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnResetDate_Click(sender As Object, e As EventArgs) Handles btnResetDate.Click
        Try
            Me.bsTransactionHeader.Filter = String.Format("TrxStatusId = '{0}'", transactionStatusId)
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class