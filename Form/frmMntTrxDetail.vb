Imports MachineMonitoringSystem.dsMonitoringTableAdapters
Imports MachineMonitoringSystem.dsMonitoring
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.Threading

Public Class frmMntTrxDetail
    Private method As New clsMethod

    'access control
    Private isAdmin As Boolean = True

    Private userId As Integer = 0
    Private workgroupId As Integer = 0
    Private isTechnicianManual As Boolean = True
    Private isImageRequired As Boolean = True
    Private isAllowEdit As Boolean = True
    Private isAllowDelete As Boolean = True
    Private isApprovedByEngineer As Boolean = True

    'checking if new or exising record
    Private trxId As Integer = 0

    'checking if already in pic table
    Private trxCount As Integer = 0

    'image processing
    Private WithEvents opdTrxDetail As New OpenFileDialog

    Private memoStream As New MemoryStream
    Private bite As Byte() 'byte is not valid identifier

    'enable/disable validation
    Private isValidate As Boolean = True

    'custom binding
    Private WithEvents datetimeBinding As Binding

    'fetching / access dataset
    Private myDataset As New dsMonitoring

    'binding sources
    Private WithEvents bsRoutingStatus As New BindingSource
    Private WithEvents bsTransactionStatus As New BindingSource
    Private WithEvents bsMachine As New BindingSource
    Private WithEvents bsArea As New BindingSource
    Private WithEvents bsMachineStatus As New BindingSource
    Private WithEvents bsTransactionHeader As New BindingSource
    Private WithEvents bsTransactionDetail As New BindingSource
    Private WithEvents bsTransactionMachinePart As New BindingSource
    Private WithEvents bsTransactionSparePart As New BindingSource
    Private WithEvents bsTransactionUser As New BindingSource
    Private WithEvents bsMachinePart As New BindingSource
    Private WithEvents bsTechnician As New BindingSource

    'adapters
    Private adpTransactionHeader As New MntTransactionHeaderTableAdapter
    Private adpTransactionDetail As New MntTransactionDetailTableAdapter
    Private adpTransactionMachinePart As New MntTransactionMachinePartTableAdapter
    Private adpTransactionSparePart As New MntTransactionSparePartTableAdapter
    Private adpTransactionUser As New MntTransactionUserTableAdapter
    Private adpTechnician As New SecUserTableAdapter

    'datatables
    Private dtSecUserPic As New SecUserDataTable
    Private dtRoutingStatus As New GenRoutingStatusDataTable
    Private dtTransactionStatus As New GenTransactionStatusDataTable
    Private dtMachine As New MntMachineDataTable
    Private dtArea As New MntAreaDataTable
    Private dtMachineStatus As New MntMachineStatusDataTable
    Private dtTransactionHeader As New MntTransactionHeaderDataTable
    Private dtTransactionDetail As New MntTransactionDetailDataTable
    Private dtTransactionMachinePart As New MntTransactionMachinePartDataTable
    Private dtTransactionSparePart As New MntTransactionSparePartDataTable
    Private dtTransactionUser As New MntTransactionUserDataTable
    Private dtMachinePart As New MntMachinePartDataTable
    Private dtTechnicianColumn As New SecUserDataTable

    Private rowEngineer As SecUserRow 'senior engineer
    Private rowManager As SecUserRow ' senior manager

    Public Sub New(ByVal _userId As Integer, ByVal _workgroupId As Integer, ByVal _isAdmin As Boolean, ByVal _isTechnicianManual As Boolean, ByVal _isImageRequired As Boolean, ByVal _isAllowEdit As Boolean, ByVal _isAllowDelete As Boolean, ByVal _myDataset As DataSet, Optional _trxId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        workgroupId = _workgroupId
        isAdmin = _isAdmin
        trxId = _trxId

        If Not isAdmin Then
            isTechnicianManual = _isTechnicianManual
            isImageRequired = _isImageRequired
            isAllowEdit = _isAllowEdit
            isAllowDelete = _isAllowDelete
        End If

        Me.adpTechnician.Fill(Me.myDataset.SecUser)

        method.EnableDoubleBuffered(dgvPic)
        method.EnableDoubleBuffered(dgvDetail)

        Dim _colNickname As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        _colNickname.Name = "TechnicianColumn"
        _colNickname.DataPropertyName = "UserId"
        _colNickname.HeaderText = "Technician"
        _colNickname.DataSource = Me.bsTechnician
        _colNickname.ValueMember = "UserId"
        _colNickname.DisplayMember = "Nickname"
        _colNickname.Width = 103
        _colNickname.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        _colNickname.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        _colNickname.SortMode = DataGridViewColumnSortMode.NotSortable
        dgvDetail.Columns.Insert(3, _colNickname)

        Me.bsTechnician.DataSource = Me.myDataset
        Me.bsTechnician.DataMember = dtTechnicianColumn.TableName

        Me.myDataset = _myDataset
        Me.myDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema

        Me.bsRoutingStatus.DataSource = Me.myDataset
        Me.bsRoutingStatus.DataMember = dtRoutingStatus.TableName
        cmbRoutingStatus.Enabled = False
        cmbRoutingStatus.DataSource = Me.bsRoutingStatus

        Me.bsTransactionStatus.DataSource = Me.myDataset
        Me.bsTransactionStatus.DataMember = dtTransactionStatus.TableName
        cmbTrxStatus.DataSource = Me.bsTransactionStatus

        Me.bsMachine.DataSource = Me.myDataset
        Me.bsMachine.DataMember = dtMachine.TableName
        cmbMachineName.DataSource = Me.bsMachine
        cmbMachineName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbMachineName.AutoCompleteSource = AutoCompleteSource.ListItems

        Me.bsArea.DataSource = Me.myDataset
        Me.bsArea.DataMember = dtArea.TableName
        cmbArea.DataSource = Me.bsArea
        cmbArea.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbArea.AutoCompleteSource = AutoCompleteSource.ListItems

        Me.bsMachineStatus.DataSource = Me.myDataset
        Me.bsMachineStatus.DataMember = dtMachineStatus.TableName
        Me.bsMachineStatus.Filter = "MachineStatusId <> 1"
        cmbMachineStatus.DataSource = Me.bsMachineStatus

        Me.bsTransactionHeader.DataSource = Me.myDataset
        Me.bsTransactionHeader.DataMember = dtTransactionHeader.TableName

        Me.bsMachinePart.DataSource = Me.myDataset
        Me.bsMachinePart.DataMember = dtMachinePart.TableName
        cmbMachinePart.DataSource = Me.bsMachinePart

        Me.bsTransactionUser.DataSource = Me.myDataset
        Me.bsTransactionUser.DataMember = dtSecUserPic.TableName
        Me.bsTransactionUser.Filter = String.Format("WorkgroupId IN (4,5,6,28)")
        dgvPic.AutoGenerateColumns = False
        dgvPic.DataSource = Me.bsTransactionUser

        If trxId = 0 Then
            Me.bsTransactionDetail.DataSource = Me.myDataset
            Me.bsTransactionDetail.DataMember = dtTransactionDetail.TableName
            Me.bsTransactionDetail.Sort = "TrxFrom"
            Me.bsTransactionDetail.Filter = String.Format("TrxId IS NULL")
            dgvDetail.AutoGenerateColumns = False
            dgvDetail.DataSource = Me.bsTransactionDetail
        Else
            Me.bsTransactionHeader.Position = Me.bsTransactionHeader.Find("TrxId", _trxId)

            txtTransactionId.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "TrxId", False, DataSourceUpdateMode.Never))
            datetimeBinding = New Binding("Text", Me.bsTransactionHeader.Current, "TrxDate")
            txtTransactionDate.DataBindings.Add(datetimeBinding)
            cmbMachineName.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "MachineId"))
            cmbArea.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "AreaId", True, DataSourceUpdateMode.OnPropertyChanged))
            txtRuntimeAccumulated.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "TotalAccumulatedRuntime"))
            cmbMachineStatus.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "DowntimeMachineStatusId"))
            txtDowntimeAccumulated.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "TotalAccumulatedDowntime"))
            txtProblem.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "Problem"))
            txtActionTaken.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "ActionTaken"))
            txtFileAttachment.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "FileAttachment"))
            txtFileName.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "FileName"))
            txtJoNumber.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "JoNumber"))
            txtJoRequestor.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "JoRequestor"))
            picImgAttachment.DataBindings.Add(New Binding("Image", Me.bsTransactionHeader.Current, "Image", True))
            txtImageName.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "ImageName"))
            txtManagerDateApproved.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "SeniorManagerApprovalDate", True, DataSourceUpdateMode.Never))
            'txtManagerId.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "SeniorManagerId"))
            txtManagerRemarks.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "SeniorManagerRemarks"))
            txtEngineerDateApproved.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "SeniorEngineerApprovalDate", True, DataSourceUpdateMode.Never))
            'txtEngineerId.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "SeniorEngineerId"))
            txtEngineerRemarks.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "SeniorEngineerRemarks"))
            cmbTrxStatus.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "TrxStatusId"))
            cmbRoutingStatus.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "RoutingStatusId"))

            Me.bsTransactionDetail.DataMember = "FK_MntTransactionDetail_MntTransactionHeader"
            Me.bsTransactionDetail.DataSource = Me.bsTransactionHeader
            dgvDetail.AutoGenerateColumns = False
            dgvDetail.DataSource = Me.bsTransactionDetail

            If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId") Is DBNull.Value Then
                cmbArea.Enabled = False
                cmbMachinePart.Enabled = True
                cmbMachineStatus.Enabled = True

                Me.adpTransactionMachinePart.Fill(Me.myDataset.MntTransactionMachinePart)
                Me.bsTransactionMachinePart.DataSource = Me.myDataset
                Me.bsTransactionMachinePart.DataMember = dtTransactionMachinePart.TableName

                Me.bsTransactionMachinePart.Position = Me.bsTransactionMachinePart.Find("TrxId", trxId)

                cmbMachinePart.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionMachinePart.Current, "MachinePartId"))

                If CType(Me.bsTransactionMachinePart.Current, DataRowView).Item("MachinePartId") Is DBNull.Value Then
                    cmbMachinePart.Enabled = False
                End If
            Else
                cmbArea.Enabled = True
                cmbMachinePart.Enabled = False
                cmbMachinePart.SelectedValue = 0
                cmbMachineStatus.Enabled = False
                cmbMachineStatus.SelectedValue = 0
            End If

            Me.adpTransactionSparePart.Fill(Me.myDataset.MntTransactionSparePart)
            Me.bsTransactionSparePart.DataSource = Me.myDataset
            Me.bsTransactionSparePart.DataMember = dtTransactionSparePart.TableName

            Me.bsTransactionSparePart.Position = Me.bsTransactionSparePart.Find("TrxId", trxId)

            txtPartsReplaced.DataBindings.Add(New Binding("Text", Me.bsTransactionSparePart.Current, "SparePartName"))
            txtPartNo.DataBindings.Add(New Binding("Text", Me.bsTransactionSparePart.Current, "SparePartNo"))

            If CType(Me.bsTransactionSparePart.Current, DataRowView).Item("SparePartName") Is DBNull.Value Then
                txtPartNo.Enabled = False
            Else
                txtPartNo.Enabled = True
            End If

            dtTransactionUser = Me.adpTransactionUser.GetDataByTrxId(trxId)

            GetPic()
        End If

        'show approvers information if not null
        If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("SeniorEngineerId") Is DBNull.Value Then
            rowEngineer = Me.myDataset.SecUser.FindByUserId(CType(Me.bsTransactionHeader.Current, DataRowView).Item("SeniorEngineerId").ToString)
            txtEngineerId.Text = rowEngineer.UserName.ToString
            txtEngineerItem.Text = rowEngineer.UserItem.ToString
        End If

        If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("SeniorManagerId") Is DBNull.Value Then
            rowManager = Me.myDataset.SecUser.FindByUserId(CType(Me.bsTransactionHeader.Current, DataRowView).Item("SeniorManagerId").ToString)
            txtManagerId.Text = rowManager.UserName.ToString
            txtManagerItem.Text = rowManager.UserItem.ToString
        End If

        'if approved by senior engineer or senior manager - don't allow editing
        If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("SeniorEngineerId") Is DBNull.Value Or Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("SeniorManagerId") Is DBNull.Value Then
            cmbTrxStatus.Enabled = False
            cmbArea.Enabled = False
            cmbMachinePart.Enabled = False
            cmbMachineStatus.Enabled = False
            btnAddRow.Enabled = False
            btnRemoveRow.Enabled = False
            btnBrowse.Enabled = False
            btnRemove.Enabled = False
            btnAttachFile.Enabled = False
            btnRemoveFile.Enabled = False
            dgvPic.ReadOnly = True
        End If

        'senior manager, manager or senior engineer
        If workgroupId = 2 Or workgroupId = 3 Or workgroupId = 4 Then
            If workgroupId = 2 Or workgroupId = 3 Then
                txtEngineerRemarks.ReadOnly = True
            ElseIf workgroupId = 4 Then
                txtManagerRemarks.ReadOnly = True
            End If
        Else
            txtManagerRemarks.ReadOnly = True
            txtEngineerRemarks.ReadOnly = True
            btnApprove.Enabled = False
            btnReturn.Enabled = False
            Me.ActiveControl = txtActionTaken
        End If
    End Sub

    Private Sub frmMntTrxDetail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        dgvPic.Dispose()
    End Sub

    Private Sub frmMntTrxDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        ElseIf e.KeyCode.Equals(Keys.F10) Then
            btnSave.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F8) Then
            If isAllowDelete And btnDelete.Enabled = True Then
                btnDelete.PerformClick()
            End If
        End If
    End Sub

    Private Sub frmMntTrxDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If trxId = 0 Then
                cmbRoutingStatus.SelectedValue = 5
                txtRoutingStatus.Text = cmbRoutingStatus.Text
                cmbTrxStatus.SelectedValue = 1
                txtTransactionId.Text = "(new)"
                txtTransactionDate.Text = DateTime.Now.ToString("MMMM dd, yyyy   HH:mm")
                Me.bsMachine.Filter = "MachineStatusId = 1"
                cmbMachineName.SelectedValue = 0
                cmbArea.SelectedValue = 0
                cmbMachinePart.SelectedValue = 0
                cmbMachinePart.Enabled = False
                cmbMachineStatus.SelectedValue = 0
                cmbMachineStatus.Enabled = False
                txtPartsReplaced.Enabled = False
                txtPartNo.Enabled = False
                GetPic()
                btnDelete.Enabled = False
                Me.ActiveControl = cmbMachineName
            Else
                txtRoutingStatus.Text = cmbRoutingStatus.Text
                cmbMachineName.Enabled = False

                txtActionTaken.Select(txtActionTaken.TextLength, 0)

                '2/25 don't allow deleting of transaction if already approved
                If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("SeniorEngineerId") Is DBNull.Value Or Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("SeniorManagerId") Is DBNull.Value Then
                    btnDelete.Enabled = False
                Else
                    btnDelete.Enabled = isAllowDelete
                End If

                If workgroupId = 2 Or workgroupId = 3 Then
                    txtManagerRemarks.Select(txtManagerRemarks.TextLength, 0)
                    Me.ActiveControl = txtManagerRemarks
                ElseIf workgroupId = 4 Then
                    txtEngineerRemarks.Select(txtEngineerRemarks.TextLength, 0)
                    Me.ActiveControl = txtEngineerRemarks
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachineName_Validated(sender As Object, e As EventArgs) Handles cmbMachineName.Validated
        'not machine-related entry
        If cmbMachineName.SelectedValue = 0 Then
            cmbMachineName.Text = String.Empty

            Me.bsArea.RemoveFilter()
            cmbArea.Enabled = True
            cmbArea.SelectedValue = 0
            cmbMachineName.SelectedValue = 0

            Me.bsMachinePart.RemoveFilter()
            cmbMachinePart.Enabled = False
            cmbMachinePart.SelectedValue = 0
            cmbMachineName.SelectedValue = 0

            cmbMachineStatus.Enabled = False
            cmbMachineStatus.SelectedValue = 0

            'txtPartsReplaced.Enabled = False
            'txtPartNo.Enabled = False

            '2/20 allow entry of spare parts replace even not machine entry
            txtPartsReplaced.Enabled = True
            Me.ActiveControl = cmbArea

            'machine entry
        Else
            '2/13 - use filter instead of refilling again the control
            Dim _areaId As Integer = CType(Me.bsMachine.Current, DataRowView).Item("AreaId")
            Me.bsArea.Filter = String.Format("AreaId = '{0}'", _areaId)
            cmbArea.Enabled = False

            If CType(Me.bsMachine.Current, DataRowView).Item("GroupId") Is DBNull.Value Then
                Me.bsMachinePart.RemoveFilter()
                cmbMachinePart.Enabled = False
                cmbMachinePart.SelectedValue = 0
            Else
                Dim _groupId As Integer = CType(Me.bsMachine.Current, DataRowView).Item("GroupId")
                Me.bsMachinePart.Filter = String.Format("GroupId = '{0}'", _groupId)
                cmbMachinePart.Enabled = True
            End If

            txtPartsReplaced.Enabled = True
            txtPartsReplaced.Clear()

            cmbMachineStatus.Enabled = True
            If trxId = 0 Then
                cmbMachineStatus.SelectedValue = 3
            End If
        End If

        GetTotalRuntime()
    End Sub

    Private Sub dgvPic_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvPic.DataBindingComplete
        For Each _row As DataRow In dtTransactionUser.Rows
            For _i As Integer = 0 To dgvPic.Rows.Count - 1
                If dgvPic.Rows(_i).Cells("UserIdColumn").Value = _row("UserId") Then
                    dgvPic.Rows(_i).Cells("IsSelectedColumn").Value = True
                End If
            Next
        Next
    End Sub

    Private Sub txtPartsReplaced_TextChanged(sender As Object, e As EventArgs) Handles txtPartsReplaced.TextChanged
        If txtPartsReplaced.Text.Trim.Length > 0 Then
            txtPartNo.Enabled = True
        Else
            txtPartNo.Enabled = False
        End If
    End Sub

    Private Sub dgvPic_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPic.SelectionChanged
        dgvPic.ClearSelection()
    End Sub

    Private Sub datetimeBinding_Format(sender As Object, e As ConvertEventArgs) Handles datetimeBinding.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy  HH:mm")
        Else
            e.Value = DateTime.Now.ToString("MMMM dd, yyyy  HH:mm")
        End If
    End Sub

    Private Sub btnCancel_MouseEnter(sender As Object, e As EventArgs) Handles btnCancel.MouseEnter
        isValidate = False
    End Sub

    Private Sub btnCancel_MouseLeave(sender As Object, e As EventArgs) Handles btnCancel.MouseLeave
        isValidate = True
    End Sub

    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        isValidate = False
    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        isValidate = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim _rowCount As Integer = dgvDetail.RowCount

            If cmbArea.SelectedValue = 0 Then
                MessageBox.Show("Please select area.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbArea.Focus()
                Return
            End If

            'force user to encode immediately the first log
            If Not dgvDetail.Rows.Count > 0 Then
                MessageBox.Show("Please input technician log.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btnAddRow.Focus()
                Return
            End If

            '2/19
            'new transaction
            If trxId = 0 Then
                Dim _newRowHeader As MntTransactionHeaderRow = Me.myDataset.MntTransactionHeader.NewMntTransactionHeaderRow
                Dim _newRowDetail As MntTransactionDetailRow = Me.myDataset.MntTransactionDetail.NewMntTransactionDetailRow
                Dim _newRowMachinePart As MntTransactionMachinePartRow = Me.myDataset.MntTransactionMachinePart.NewMntTransactionMachinePartRow
                Dim _newRowSparePart As MntTransactionSparePartRow = Me.myDataset.MntTransactionSparePart.NewMntTransactionSparePartRow
                Dim _newRowUser As MntTransactionUserRow = Me.myDataset.MntTransactionUser.NewMntTransactionUserRow

                'transaction header
                With _newRowHeader
                    'selected done
                    If cmbTrxStatus.SelectedValue = 1 Then
                        'machine entry
                        If Not cmbMachineName.SelectedValue = 0 Then
                            .MachineId = cmbMachineName.SelectedValue
                            If String.IsNullOrWhiteSpace(txtRuntimeAccumulated.Text.Trim) Then
                                .SetTotalAccumulatedRuntimeNull()
                            Else
                                .TotalAccumulatedRuntime = txtRuntimeAccumulated.Text.Trim
                            End If
                            .DowntimeMachineStatusId = cmbMachineStatus.SelectedValue

                            'preventive maintenance
                            If cmbMachineStatus.SelectedValue = 2 Then
                                If Not String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    .Problem = txtProblem.Text.Trim
                                Else
                                    .SetProblemNull()
                                End If

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If
                                'under repair
                            Else
                                If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtProblem.Focus()
                                    Return
                                End If
                                .Problem = txtProblem.Text.Trim

                                If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    MessageBox.Show("Please indicate the action taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtActionTaken.Focus()
                                    Return
                                End If
                                .ActionTaken = txtActionTaken.Text.Trim
                            End If
                            'not machine-related entry
                        Else
                            .SetMachineIdNull()
                            .SetTotalAccumulatedRuntimeNull()
                            .SetDowntimeMachineStatusIdNull()

                            If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtProblem.Focus()
                                Return
                            End If
                            .Problem = txtProblem.Text.Trim

                            If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                MessageBox.Show("Please indicate the action taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtActionTaken.Focus()
                                Return
                            End If
                            .ActionTaken = txtActionTaken.Text.Trim
                        End If

                        If picImgAttachment.Image Is Nothing Then
                            MessageBox.Show("Please attach image.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            btnBrowse.Focus()
                            Return
                        End If

                        Dim _resized As Image = method.ResizeImage(picImgAttachment.Image, New Size(250, 250))
                        _resized.Save(memoStream, ImageFormat.Jpeg)
                        bite = memoStream.GetBuffer()
                        .Image = bite
                        .ImageName = txtImageName.Text.Trim

                        .DatetimeEnded = dgvDetail.Rows(_rowCount - 1).Cells("TrxToColumn").Value
                        .TrxStatusId = 1
                        .RoutingStatusId = 4

                        'selected ongoing
                    Else
                        'machine entry
                        If Not cmbMachineName.SelectedValue = 0 Then
                            .MachineId = cmbMachineName.SelectedValue
                            If String.IsNullOrWhiteSpace(txtRuntimeAccumulated.Text.Trim) Then
                                .SetTotalAccumulatedRuntimeNull()
                            Else
                                .TotalAccumulatedRuntime = txtRuntimeAccumulated.Text.Trim
                            End If
                            .DowntimeMachineStatusId = cmbMachineStatus.SelectedValue

                            'preventive maintenance
                            If cmbMachineStatus.SelectedValue = 2 Then
                                If Not String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    .Problem = txtProblem.Text.Trim
                                Else
                                    .SetProblemNull()
                                End If

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If
                                'under repair
                            Else
                                If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtProblem.Focus()
                                    Return
                                End If
                                .Problem = txtProblem.Text.Trim

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If
                            End If

                            'not machine-related entry
                        Else
                            .SetMachineIdNull()
                            .SetTotalAccumulatedRuntimeNull()
                            .SetDowntimeMachineStatusIdNull()

                            If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtProblem.Focus()
                                Return
                            End If
                            .Problem = txtProblem.Text.Trim

                            If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                .ActionTaken = txtActionTaken.Text.Trim
                            Else
                                .SetActionTakenNull()
                            End If
                        End If

                        If picImgAttachment.Image Is Nothing Then
                            .SetImageNameNull()
                            .SetImageNameNull()
                        Else
                            Dim _resized As Image = method.ResizeImage(picImgAttachment.Image, New Size(250, 250))
                            _resized.Save(memoStream, ImageFormat.Jpeg)
                            bite = memoStream.GetBuffer()
                            .Image = bite
                            .ImageName = txtImageName.Text.Trim
                        End If

                        .SetDatetimeEndedNull()
                        .TrxStatusId = 2
                        .RoutingStatusId = 5

                        If Not cmbMachineName.SelectedValue = 0 Then
                            Dim _rowMachine As MntMachineRow = Me.myDataset.MntMachine.FindByMachineId(cmbMachineName.SelectedValue)
                            _rowMachine.MachineStatusId = cmbMachineStatus.SelectedValue
                        End If
                    End If

                    .TrxDate = DateTime.Now
                    .AreaId = cmbArea.SelectedValue
                    .DatetimeStarted = dgvDetail.Rows(0).Cells("TrxFromColumn").Value
                    .TotalAccumulatedDowntime = txtDowntimeAccumulated.Text.Trim

                    .SetFileAttachmentNull()
                    .SetFileNameNull()

                    If String.IsNullOrEmpty(txtJoNumber.Text.Trim) Then
                        .SetJoNumberNull()
                    Else
                        .JoNumber = txtJoNumber.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtJoRequestor.Text.Trim) Then
                        .SetJoRequestorNull()
                    Else
                        .JoRequestor = txtJoRequestor.Text.Trim
                    End If

                    .SeniorManagerIsApproved = 0
                    .SetSeniorEngineerApprovalDateNull()
                    .SetSeniorManagerIdNull()
                    .SetSeniorManagerRemarksNull()

                    .SeniorEngineerIsApproved = 0
                    .SetSeniorEngineerApprovalDateNull()
                    .SetSeniorEngineerIdNull()
                    .SetSeniorEngineerRemarksNull()

                    .UserId = dgvDetail.Rows(_rowCount - 1).Cells("TechnicianColumn").Value
                    .ShiftId = dgvDetail.Rows(_rowCount - 1).Cells("ShiftIdColumn").Value
                    .EncodeUserId = userId
                End With
                Me.myDataset.MntTransactionHeader.AddMntTransactionHeaderRow(_newRowHeader)
                Me.adpTransactionHeader.Update(Me.myDataset.MntTransactionHeader)

                'transaction details
                'set first the trxid of each rows from technician logs
                For Each _dataRowView As DataRowView In Me.bsTransactionDetail
                    Dim _row = _dataRowView.Row
                    _row.Item("TrxId") = _newRowHeader.TrxId

                    '2/21
                    'transaction user (db direct)
                    'include start technician and end technician to transaction user table
                    Me.adpTransactionUser.Insert(_newRowHeader.TrxId, _row("UserId"))
                Next

                'transaction machine part
                With _newRowMachinePart
                    .TrxId = _newRowHeader.TrxId
                    If Not cmbMachinePart.SelectedValue = 0 Then
                        .MachinePartId = cmbMachinePart.SelectedValue
                    Else
                        .SetMachinePartIdNull()
                    End If
                End With
                Me.myDataset.MntTransactionMachinePart.AddMntTransactionMachinePartRow(_newRowMachinePart)

                'transaction spare part
                '2/21
                With _newRowSparePart
                    .TrxId = _newRowHeader.TrxId
                    If String.IsNullOrEmpty(txtPartsReplaced.Text.Trim) Then
                        .SetSparePartNameNull()
                        .SetSparePartNoNull()
                    Else
                        .SparePartName = txtPartsReplaced.Text.Trim
                        If String.IsNullOrEmpty(txtPartNo.Text.Trim) Then
                            MessageBox.Show("Please indicate the spare part number.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtPartNo.Focus()
                            Return
                        End If
                        .SparePartNo = txtPartNo.Text.Trim
                    End If
                End With
                Me.myDataset.MntTransactionSparePart.AddMntTransactionSparePartRow(_newRowSparePart)

                'insert selected pic from dgvPic
                For Each _row As DataGridViewRow In dgvPic.Rows
                    Dim _isSelected As Boolean = Convert.ToBoolean(_row.Cells("IsSelectedColumn").Value)
                    If _isSelected Then
                        Me.adpTransactionUser.Insert(_newRowHeader.TrxId, _row.Cells("UserIdColumn").Value)
                    End If
                Next

                '2/22
                'existing transaction
            Else
                Dim _rowHeader As MntTransactionHeaderRow = Me.myDataset.MntTransactionHeader.FindByTrxId(trxId)
                Dim _rowMachine As MntMachineRow = Me.myDataset.MntMachine.FindByMachineId(cmbMachineName.SelectedValue)

                'existing transaction (done)
                If cmbTrxStatus.SelectedValue = 1 Then
                    'transaction header
                    With _rowHeader
                        'machine entry
                        If Not cmbMachineName.SelectedValue = 0 Then
                            'preventive maintenance
                            If cmbMachineStatus.SelectedValue = 2 Then
                                If Not String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    .Problem = txtProblem.Text.Trim
                                Else
                                    .SetProblemNull()
                                End If

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If
                                'under repair
                            Else
                                If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtProblem.Focus()
                                    Return
                                End If
                                .Problem = txtProblem.Text.Trim

                                If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    MessageBox.Show("Please indicate the action taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtActionTaken.Focus()
                                    Return
                                End If
                                .ActionTaken = txtActionTaken.Text.Trim
                            End If

                            'not machine-related entry
                        Else
                            .AreaId = cmbArea.SelectedValue

                            If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtProblem.Focus()
                                Return
                            End If
                            .Problem = txtProblem.Text.Trim

                            If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                MessageBox.Show("Please indicate the action taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtActionTaken.Focus()
                                Return
                            End If
                            .ActionTaken = txtActionTaken.Text.Trim
                        End If

                        .DatetimeStarted = dgvDetail.Rows(0).Cells("TrxFromColumn").Value
                        .TotalAccumulatedDowntime = txtDowntimeAccumulated.Text.Trim

                        If String.IsNullOrEmpty(txtJoNumber.Text.Trim) Then
                            .SetJoNumberNull()
                        Else
                            .JoNumber = txtJoNumber.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txtJoRequestor.Text.Trim) Then
                            .SetJoRequestorNull()
                        Else
                            .JoRequestor = txtJoRequestor.Text.Trim
                        End If

                        If picImgAttachment.Image Is Nothing Then
                            MessageBox.Show("Please attach image.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            btnBrowse.Focus()
                            Return
                        End If

                        Dim _resized As Image = method.ResizeImage(picImgAttachment.Image, New Size(250, 250))
                        _resized.Save(memoStream, ImageFormat.Jpeg)
                        bite = memoStream.GetBuffer()
                        .Image = bite
                        .ImageName = txtImageName.Text.Trim

                        .UserId = dgvDetail.Rows(_rowCount - 1).Cells("TechnicianColumn").Value
                        .ShiftId = dgvDetail.Rows(_rowCount - 1).Cells("ShiftIdColumn").Value

                        .DatetimeEnded = dgvDetail.Rows(_rowCount - 1).Cells("TrxToColumn").Value
                        .TrxStatusId = 1
                        .RoutingStatusId = 4
                    End With
                    Me.bsTransactionHeader.EndEdit()

                    'transaction details
                    'set first the trxid of each rows from technician logs
                    For Each _dataRowView As DataRowView In Me.bsTransactionDetail
                        Dim _row = _dataRowView.Row
                        _row.Item("TrxId") = trxId
                    Next
                    Me.Validate()
                    Me.adpTransactionDetail.Update(Me.myDataset.MntTransactionDetail)

                    'transaction machine part
                    With Me.bsTransactionMachinePart
                        If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId") Is DBNull.Value Then
                            If cmbMachinePart.SelectedValue = 0 And cmbMachinePart.Enabled = False Then
                                .Current("MachinePartId") = DBNull.Value
                            Else
                                .Current("MachinePartId") = cmbMachinePart.SelectedValue
                            End If
                        End If
                    End With
                    Me.bsTransactionMachinePart.EndEdit()

                    'transaction spare part
                    With Me.bsTransactionSparePart
                        If String.IsNullOrEmpty(txtPartsReplaced.Text.Trim) Then
                            .Current("SparePartName") = DBNull.Value
                            .Current("SparePartNo") = DBNull.Value
                        Else
                            If String.IsNullOrEmpty(txtPartNo.Text.Trim) Then
                                MessageBox.Show("Please indicate the part number.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtPartNo.Focus()
                                Return
                            End If

                            .Current("SparePartName") = txtPartsReplaced.Text.Trim
                            .Current("SparePartNo") = txtPartNo.Text.Trim
                        End If
                    End With
                    Me.bsTransactionSparePart.EndEdit()

                    'transaction user
                    For Each _row As DataGridViewRow In dgvPic.Rows
                        Dim _userId As Integer = _row.Cells("UserIdColumn").Value
                        Dim _isSelected As Boolean = Convert.ToBoolean(_row.Cells("IsSelectedColumn").Value)

                        trxCount = Me.adpTransactionUser.CntMntTransactionUser(trxId, _userId)

                        If trxCount > 0 Then
                            If _isSelected Then
                                'already on pic table - do nothing
                            Else
                                'not selected as pic - delete existing record of this technician
                                Me.adpTransactionUser.DelMntTransactionUserByUserId(trxId, _userId)
                            End If
                        Else
                            If _isSelected Then
                                'selected as pic - add to pic table
                                Me.adpTransactionUser.Insert(trxId, _row.Cells("UserIdColumn").Value)
                            Else
                                'not selected - do nothing
                            End If
                        End If
                    Next

                    For Each _row As DataRowView In Me.bsTransactionDetail
                        trxCount = Me.adpTransactionUser.CntMntTransactionUser(trxId, _row.Item("UserId"))
                        If Not trxCount > 0 Then
                            adpTransactionUser.Insert(trxId, _row.Item("UserId"))
                        End If
                    Next

                    'set machine to running state
                    If Not cmbMachineName.SelectedValue = 0 Then
                        _rowMachine.MachineStatusId = 1
                    End If
                    Me.bsMachine.EndEdit()

                    'existing transaction (ongoing)
                Else
                    'transaction header
                    With _rowHeader
                        'machine entry
                        If Not cmbMachineName.SelectedValue = 0 Then
                            'preventive maintenance
                            If cmbMachineStatus.SelectedValue = 2 Then
                                If Not String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    .Problem = txtProblem.Text.Trim
                                Else
                                    .SetProblemNull()
                                End If

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If
                                'under repair
                            Else
                                If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtProblem.Focus()
                                    Return
                                End If
                                .Problem = txtProblem.Text.Trim

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If
                            End If

                            'not machine-related entry
                        Else
                            .AreaId = cmbArea.SelectedValue

                            If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtProblem.Focus()
                                Return
                            End If
                            .Problem = txtProblem.Text.Trim

                            If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                .ActionTaken = txtActionTaken.Text.Trim
                            Else
                                .SetActionTakenNull()
                            End If
                        End If

                        .DatetimeStarted = dgvDetail.Rows(0).Cells("TrxFromColumn").Value
                        .TotalAccumulatedDowntime = txtDowntimeAccumulated.Text.Trim

                        If String.IsNullOrEmpty(txtJoNumber.Text.Trim) Then
                            .SetJoNumberNull()
                        Else
                            .JoNumber = txtJoNumber.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txtJoRequestor.Text.Trim) Then
                            .SetJoRequestorNull()
                        Else
                            .JoRequestor = txtJoRequestor.Text.Trim
                        End If

                        If picImgAttachment.Image Is Nothing Then
                            .SetImageNameNull()
                            .SetImageNameNull()
                        Else
                            Dim _resized As Image = method.ResizeImage(picImgAttachment.Image, New Size(250, 250))
                            _resized.Save(memoStream, ImageFormat.Jpeg)
                            bite = memoStream.GetBuffer()
                            .Image = bite
                            .ImageName = txtImageName.Text.Trim
                        End If

                        .UserId = dgvDetail.Rows(_rowCount - 1).Cells("TechnicianColumn").Value
                        .ShiftId = dgvDetail.Rows(_rowCount - 1).Cells("ShiftIdColumn").Value

                        .DatetimeEnded = dgvDetail.Rows(_rowCount - 1).Cells("TrxToColumn").Value
                        .TrxStatusId = 2
                        .RoutingStatusId = 5
                    End With
                    Me.bsTransactionHeader.EndEdit()

                    'transaction details
                    'set first the trxid of each rows from technician logs
                    For Each _dataRowView As DataRowView In Me.bsTransactionDetail
                        Dim _row = _dataRowView.Row
                        _row.Item("TrxId") = trxId
                    Next
                    Me.Validate()
                    Me.adpTransactionDetail.Update(Me.myDataset.MntTransactionDetail)

                    'transaction machine part
                    With Me.bsTransactionMachinePart
                        If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId") Is DBNull.Value Then
                            If cmbMachinePart.SelectedValue = 0 And cmbMachinePart.Enabled = False Then
                                .Current("MachinePartId") = DBNull.Value
                            Else
                                .Current("MachinePartId") = cmbMachinePart.SelectedValue
                            End If
                        End If
                    End With
                    Me.bsTransactionMachinePart.EndEdit()

                    'transaction spare part
                    With Me.bsTransactionSparePart
                        If String.IsNullOrEmpty(txtPartsReplaced.Text.Trim) Then
                            .Current("SparePartName") = DBNull.Value
                            .Current("SparePartNo") = DBNull.Value
                        Else
                            If String.IsNullOrEmpty(txtPartNo.Text.Trim) Then
                                MessageBox.Show("Please indicate the part number.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtPartNo.Focus()
                                Return
                            End If

                            .Current("SparePartName") = txtPartsReplaced.Text.Trim
                            .Current("SparePartNo") = txtPartNo.Text.Trim
                        End If
                    End With
                    Me.bsTransactionSparePart.EndEdit()

                    'transaction user
                    For Each _row As DataGridViewRow In dgvPic.Rows
                        Dim _userId As Integer = _row.Cells("UserIdColumn").Value
                        Dim _isSelected As Boolean = Convert.ToBoolean(_row.Cells("IsSelectedColumn").Value)

                        trxCount = Me.adpTransactionUser.CntMntTransactionUser(trxId, _userId)

                        If trxCount > 0 Then
                            If _isSelected Then
                                'already on pic table - do nothing
                            Else
                                'not selected as pic - delete existing record of this technician
                                Me.adpTransactionUser.DelMntTransactionUserByUserId(trxId, _userId)
                            End If
                        Else
                            If _isSelected Then
                                'selected as pic - add to pic table
                                Me.adpTransactionUser.Insert(trxId, _row.Cells("UserIdColumn").Value)
                            Else
                                'not selected - do nothing
                            End If
                        End If
                    Next

                    For Each _row As DataRowView In Me.bsTransactionDetail
                        trxCount = Me.adpTransactionUser.CntMntTransactionUser(trxId, _row.Item("UserId"))
                        If Not trxCount > 0 Then
                            adpTransactionUser.Insert(trxId, _row.Item("UserId"))
                        End If
                    Next

                    'set machine to downtime
                    If Not cmbMachineName.SelectedValue = 0 Then
                        _rowMachine.MachineStatusId = cmbMachineStatus.SelectedValue
                    End If
                    Me.bsMachine.EndEdit()
                End If
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Me.bsTransactionHeader.CancelEdit()
        'Me.bsTransactionDetail.CancelEdit()

        'If Me.myDataset.HasChanges Then
        '    Me.myDataset.RejectChanges()
        'End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If trxId > 0 Then
                Dim _currentRow = CType(Me.bsTransactionHeader.Current, DataRowView).Row
                Dim _rowState = _currentRow.RowState

                Select Case _rowState
                    Case DataRowState.Added
                        Me.bsTransactionHeader.RemoveCurrent()
                    Case DataRowState.Detached
                        Me.bsTransactionHeader.CancelEdit()
                    Case DataRowState.Modified, DataRowState.Unchanged
                        If dgvDetail.SelectedCells.Count > 0 AndAlso dgvDetail.SelectedCells(0).RowIndex = dgvDetail.NewRowIndex Then
                            Me.bsTransactionHeader.CancelEdit()
                            Exit Sub
                        End If

                        Dim message = String.Format("Delete this transaction?")
                        If MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Me.bsTransactionHeader.RemoveCurrent()
                        End If
                    Case Else
                End Select
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        btnCancel.PerformClick()
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Try
            'senior manager
            If workgroupId = 2 Or workgroupId = 3 Then
                Dim _transactionRow As MntTransactionHeaderRow = Me.myDataset.MntTransactionHeader.FindByTrxId(trxId)
                _transactionRow.SeniorManagerId = 1
                _transactionRow.SeniorManagerApprovalDate = DateTime.Now
                _transactionRow.SeniorManagerId = userId
                _transactionRow.RoutingStatusId = 1

                If String.IsNullOrEmpty(txtManagerRemarks.Text.Trim) Then
                    _transactionRow.SetSeniorManagerRemarksNull()
                Else
                    _transactionRow.SeniorManagerRemarks = txtManagerRemarks.Text.Trim
                End If
                'senior engineer
            ElseIf workgroupId = 4 Then
                Dim _transactionRow As MntTransactionHeaderRow = Me.myDataset.MntTransactionHeader.FindByTrxId(trxId)
                _transactionRow.SeniorEngineerIsApproved = 1
                _transactionRow.SeniorEngineerApprovalDate = DateTime.Now
                _transactionRow.SeniorEngineerId = userId
                _transactionRow.RoutingStatusId = 3

                If String.IsNullOrEmpty(txtEngineerRemarks.Text.Trim) Then
                    _transactionRow.SetSeniorEngineerRemarksNull()
                Else
                    _transactionRow.SeniorEngineerRemarks = txtEngineerRemarks.Text.Trim
                End If
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Try
            If workgroupId = 2 Or workgroupId = 3 Then
                Dim _transactionRow As MntTransactionHeaderRow = Me.myDataset.MntTransactionHeader.FindByTrxId(trxId)
                _transactionRow.SeniorManagerId = 0
                _transactionRow.SetSeniorManagerApprovalDateNull()
                _transactionRow.SetSeniorManagerIdNull()
                _transactionRow.RoutingStatusId = 4

                If String.IsNullOrEmpty(txtManagerRemarks.Text.Trim) Then
                    _transactionRow.SetSeniorManagerRemarksNull()
                Else
                    _transactionRow.SeniorManagerRemarks = txtManagerRemarks.Text.Trim
                End If
            ElseIf workgroupId = 4 Then
                Dim _transactionRow As MntTransactionHeaderRow = Me.myDataset.MntTransactionHeader.FindByTrxId(trxId)
                _transactionRow.SeniorEngineerIsApproved = 0
                _transactionRow.SetSeniorEngineerApprovalDateNull()
                _transactionRow.SetSeniorEngineerIdNull()
                _transactionRow.RoutingStatusId = 5
                _transactionRow.TrxStatusId = 2

                If String.IsNullOrEmpty(txtEngineerRemarks.Text.Trim) Then
                    _transactionRow.SetSeniorEngineerRemarksNull()
                Else
                    _transactionRow.SeniorEngineerRemarks = txtEngineerRemarks.Text.Trim
                End If
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
            opdTrxDetail.Filter = "JPEGs (*.jpg, *.jpeg) | *.jpg; *.jpeg |GIFs (*.gif) | *.gif |Bitmaps (*.bmp) | *.bmp |All Images (*.*) | *.jpg; *.jpeg; *.gif; *.bmp; *.png; *.tif; *.tiff"
            opdTrxDetail.FilterIndex = 4
            opdTrxDetail.Title = "Select Image"
            opdTrxDetail.FileName = String.Empty
            Dim _mStream As New MemoryStream

            If opdTrxDetail.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtImageName.Text = opdTrxDetail.SafeFileName

                '1/25
                Using bmp As New Bitmap(opdTrxDetail.FileName)
                    Dim _jpgEncoder As ImageCodecInfo = method.GetEncoder(ImageFormat.Jpeg)
                    Dim _myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality

                    'create an encoderparameters object
                    'an encoderparameters object has an array of encoderparameter objects; in this case, there is only one encoderparameter object in the array.
                    Dim _myEncoderParameters As New EncoderParameters(1)

                    'save the bitmap as a JPG file with zero quality level compression
                    Dim _myEncoderParameter = New EncoderParameter(_myEncoder, 10L)
                    _myEncoderParameters.Param(0) = _myEncoderParameter
                    bmp.Save(_mStream, _jpgEncoder, _myEncoderParameters)

                    'shows file size after compression
                    'lblFileSize.Visible = True
                    'lblFileSize.Text = method.ReadableFileSize(mStream.Length)

                    picImgAttachment.Image = Image.FromStream(_mStream)
                End Using
            End If

            _mStream.Dispose()
            opdTrxDetail.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        txtImageName.Text = String.Empty
        picImgAttachment.Image = Nothing
    End Sub

    Private Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        Try
            If trxId = 0 Then
                Using frmDetailLog As New frmMntTrxDetailLog(Me.myDataset, userId)
                    frmDetailLog.ShowDialog(Me)

                    If frmDetailLog.DialogResult = Windows.Forms.DialogResult.OK Then
                        Me.bsTransactionDetail.AddNew()
                        Me.bsTransactionDetail.MoveLast()
                        Me.bsTransactionDetail.Current("TrxId") = DBNull.Value
                        Me.bsTransactionDetail.Current("TrxDate") = DateTime.Now
                        Me.bsTransactionDetail.Current("TrxFrom") = frmDetailLog.dtpFrom.Value
                        Me.bsTransactionDetail.Current("TrxTo") = frmDetailLog.dtpTo.Value
                        Me.bsTransactionDetail.Current("ElapsedTime") = frmDetailLog.txtElapsedTime.Text.Trim
                        Me.bsTransactionDetail.Current("UserId") = frmDetailLog.cmbUser.SelectedValue
                        Me.bsTransactionDetail.Current("ShiftId") = IIf(frmDetailLog.rdDay.Checked = True, "D", "N")
                        Me.bsTransactionDetail.EndEdit()
                    Else
                        Me.bsTransactionDetail.CancelEdit()
                    End If
                End Using
            Else
                Using frmDetailLog As New frmMntTrxDetailLog(Me.myDataset, userId, trxId)
                    frmDetailLog.ShowDialog(Me)

                    If frmDetailLog.DialogResult = Windows.Forms.DialogResult.OK Then
                        Me.bsTransactionDetail.AddNew()
                        Me.bsTransactionDetail.MoveLast()
                        Me.bsTransactionDetail.Current("TrxId") = trxId
                        Me.bsTransactionDetail.Current("TrxDate") = DateTime.Now
                        Me.bsTransactionDetail.Current("TrxFrom") = frmDetailLog.dtpFrom.Value
                        Me.bsTransactionDetail.Current("TrxTo") = frmDetailLog.dtpTo.Value
                        Me.bsTransactionDetail.Current("ElapsedTime") = frmDetailLog.txtElapsedTime.Text.Trim
                        Me.bsTransactionDetail.Current("UserId") = frmDetailLog.cmbUser.SelectedValue
                        Me.bsTransactionDetail.Current("ShiftId") = IIf(frmDetailLog.rdDay.Checked = True, "D", "N")
                        Me.bsTransactionDetail.EndEdit()
                    Else
                        Me.bsTransactionDetail.CancelEdit()
                    End If
                End Using
            End If

            GetPic()
            GetTotalDowntime()
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveRow_Click(sender As Object, e As EventArgs) Handles btnRemoveRow.Click
        Try
            If dgvDetail.Rows.Count > 0 Then
                Dim _currentRow = CType(Me.bsTransactionDetail.Current, DataRowView).Row
                Dim _rowState = _currentRow.RowState

                Select Case _rowState
                    Case DataRowState.Added
                        Me.bsTransactionDetail.RemoveCurrent()
                    Case DataRowState.Detached
                        Me.bsTransactionDetail.CancelEdit()
                    Case DataRowState.Modified, DataRowState.Unchanged
                        If dgvDetail.SelectedCells.Count > 0 AndAlso dgvDetail.SelectedCells(0).RowIndex = dgvDetail.NewRowIndex Then
                            Me.bsTransactionDetail.CancelEdit()
                            Exit Sub
                        End If

                        Dim message = String.Format("Delete selected log entry?")
                        If MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Me.bsTransactionDetail.RemoveCurrent()
                        End If
                    Case Else
                End Select
            End If

            GetPic()
            GetTotalDowntime()
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetail.DataError
        e.Cancel = False
    End Sub

#Region "Subs"

    '2/19
    Private Sub GetTotalRuntime()
        Try
            Dim _dtLastTrxTo As MntTransactionDetailDataTable
            Dim _lastDatetime As DateTime = Nothing
            Dim _span As TimeSpan = Nothing
            Dim _minutes As Integer = 0
            Dim _hours As Integer = 0
            Dim _days As Integer = 0
            Dim _rowCount As Integer = 0

            _dtLastTrxTo = Me.adpTransactionDetail.GetLastDetailByMachineId(cmbMachineName.SelectedValue)

            If _dtLastTrxTo.Rows.Count > 0 Then
                _lastDatetime = _dtLastTrxTo.Rows(0).Item("TrxTo").ToString.Trim
            End If

            If Not _lastDatetime = "01/01/0001 12:00:00 AM" Then
                _span = (_lastDatetime - DateTime.Now).Duration()
                _minutes = _span.Minutes
                _hours = _span.Hours
                _days = _span.Days
                txtRuntimeAccumulated.Text = _days.ToString("00") & ":" & _hours.ToString("00") & ":" & _minutes.ToString("00")
            Else
                txtRuntimeAccumulated.Text = "00:00:00"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetTotalDowntime()
        Try
            Dim _elapsedTime As String
            Dim _totalTimeSpan As TimeSpan = TimeSpan.Zero
            Dim _timeSpan As TimeSpan = Nothing

            For Each _row As DataGridViewRow In dgvDetail.Rows
                _elapsedTime = _row.Cells("ElapsedTimeColumn").Value
                _timeSpan = New TimeSpan(CInt(_elapsedTime.Split(":")(0)), CInt(_elapsedTime.Split(":")(1)), CInt(_elapsedTime.Split(":")(2)), "00")
                _totalTimeSpan = _totalTimeSpan + _timeSpan
            Next

            txtDowntimeAccumulated.Text = String.Join(":", _totalTimeSpan.Days.ToString("00"), _totalTimeSpan.Hours.ToString("00"), _totalTimeSpan.Minutes.ToString("00"))
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetPic()
        Try
            '2/19
            If dgvDetail.Rows.Count > 0 Then
                Dim filterBuilder As New System.Text.StringBuilder("WorkgroupId IN (4,5,6,28) AND UserId NOT IN (")

                For _i As Integer = 0 To dgvDetail.Rows.Count - 1
                    If _i > 0 Then
                        filterBuilder.Append(",")
                    End If
                    filterBuilder.Append(dgvDetail.Rows(_i).Cells("TechnicianColumn").Value)
                Next
                filterBuilder.Append(")")
                Me.bsTransactionUser.Filter = filterBuilder.ToString
            Else
                Me.bsTransactionUser.Filter = String.Format("WorkgroupId IN (4,5,6,28)")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "UI"

    Private Sub cmbTrxStatus_Enter(sender As Object, e As EventArgs) Handles cmbTrxStatus.Enter
        lblTrxStatus.ForeColor = Color.White
        lblTrxStatus.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbTrxStatus_Leave(sender As Object, e As EventArgs) Handles cmbTrxStatus.Leave
        lblTrxStatus.ForeColor = Color.Black
        lblTrxStatus.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbMachineName_Enter(sender As Object, e As EventArgs) Handles cmbMachineName.Enter
        lblMachineName.ForeColor = Color.White
        lblMachineName.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbMachineName_Leave(sender As Object, e As EventArgs) Handles cmbMachineName.Leave
        lblMachineName.ForeColor = Color.Black
        lblMachineName.BackColor = SystemColors.Control
        GetTotalRuntime()

        AddHandler cmbMachineName.Validated, AddressOf cmbMachineName_Validated
    End Sub

    Private Sub cmbArea_Enter(sender As Object, e As EventArgs) Handles cmbArea.Enter
        lblArea.ForeColor = Color.White
        lblArea.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbArea_Leave(sender As Object, e As EventArgs) Handles cmbArea.Leave
        lblArea.ForeColor = Color.Black
        lblArea.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbMachinePart_Enter(sender As Object, e As EventArgs) Handles cmbMachinePart.Enter
        lblMachinePart.ForeColor = Color.White
        lblMachinePart.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbMachinePart_Leave(sender As Object, e As EventArgs) Handles cmbMachinePart.Leave
        lblMachinePart.ForeColor = Color.Black
        lblMachinePart.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbMachineStatus_Enter(sender As Object, e As EventArgs) Handles cmbMachineStatus.Enter
        lblMachineStatus.ForeColor = Color.White
        lblMachineStatus.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbMachineStatus_Leave(sender As Object, e As EventArgs) Handles cmbMachineStatus.Leave
        lblMachineStatus.ForeColor = Color.Black
        lblMachineStatus.BackColor = SystemColors.Control
    End Sub

    Private Sub txtProblem_Enter(sender As Object, e As EventArgs) Handles txtProblem.Enter
        lblProblem.ForeColor = Color.White
        lblProblem.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtProblem_Leave(sender As Object, e As EventArgs) Handles txtProblem.Leave
        lblProblem.ForeColor = Color.Black
        lblProblem.BackColor = SystemColors.Control
    End Sub

    Private Sub txtActionTaken_Enter(sender As Object, e As EventArgs) Handles txtActionTaken.Enter
        lblActionTaken.ForeColor = Color.White
        lblActionTaken.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtActionTaken_Leave(sender As Object, e As EventArgs) Handles txtActionTaken.Leave
        lblActionTaken.ForeColor = Color.Black
        lblActionTaken.BackColor = SystemColors.Control
    End Sub

    Private Sub txtPartsReplaced_Enter(sender As Object, e As EventArgs) Handles txtPartsReplaced.Enter
        lblPartsReplaced.ForeColor = Color.White
        lblPartsReplaced.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtPartsReplaced_Leave(sender As Object, e As EventArgs) Handles txtPartsReplaced.Leave
        lblPartsReplaced.ForeColor = Color.Black
        lblPartsReplaced.BackColor = SystemColors.Control
    End Sub

    Private Sub txtPartNo_Enter(sender As Object, e As EventArgs) Handles txtPartNo.Enter
        lblPartNo.ForeColor = Color.White
        lblPartNo.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtPartNo_Leave(sender As Object, e As EventArgs) Handles txtPartNo.Leave
        lblPartNo.ForeColor = Color.Black
        lblPartNo.BackColor = SystemColors.Control
    End Sub

    Private Sub txtJoNumber_Enter(sender As Object, e As EventArgs) Handles txtJoNumber.Enter
        lblJoNumber.ForeColor = Color.White
        lblJoNumber.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtJoNumber_Leave(sender As Object, e As EventArgs) Handles txtJoNumber.Leave
        lblJoNumber.ForeColor = Color.Black
        lblJoNumber.BackColor = SystemColors.Control
    End Sub

    Private Sub txtRequestorName_Enter(sender As Object, e As EventArgs) Handles txtJoRequestor.Enter
        lblJoRequestor.ForeColor = Color.White
        lblJoRequestor.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtRequestorName_Leave(sender As Object, e As EventArgs) Handles txtJoRequestor.Leave
        lblJoRequestor.ForeColor = Color.Black
        lblJoRequestor.BackColor = SystemColors.Control
    End Sub

    Private Sub pnlImage_Enter(sender As Object, e As EventArgs) Handles pnlImage.Enter
        lblImageAttachment.ForeColor = Color.White
        lblImageAttachment.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub pnlImage_Leave(sender As Object, e As EventArgs) Handles pnlImage.Leave
        lblImageAttachment.ForeColor = Color.Black
        lblImageAttachment.BackColor = SystemColors.Control
    End Sub

    Private Sub dgvPic_Enter(sender As Object, e As EventArgs) Handles dgvPic.Enter
        lblPic.ForeColor = Color.White
        lblPic.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub dgvPic_Leave(sender As Object, e As EventArgs) Handles dgvPic.Leave
        lblPic.ForeColor = Color.Black
        lblPic.BackColor = SystemColors.Control
    End Sub

    Private Sub dgvDetail_Enter(sender As Object, e As EventArgs) Handles dgvDetail.Enter
        lblActivityLogs.ForeColor = Color.White
        lblActivityLogs.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub dgvDetail_Leave(sender As Object, e As EventArgs) Handles dgvDetail.Leave
        lblActivityLogs.ForeColor = Color.Black
        lblActivityLogs.BackColor = SystemColors.Control
    End Sub

    Private Sub btnAddRow_Enter(sender As Object, e As EventArgs) Handles btnAddRow.Enter
        lblActivityLogs.ForeColor = Color.White
        lblActivityLogs.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub btnAddRow_Leave(sender As Object, e As EventArgs) Handles btnAddRow.Leave
        lblActivityLogs.ForeColor = Color.Black
        lblActivityLogs.BackColor = SystemColors.Control
    End Sub

    Private Sub btnRemoveRow_Enter(sender As Object, e As EventArgs) Handles btnRemoveRow.Enter
        lblActivityLogs.ForeColor = Color.White
        lblActivityLogs.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub btnRemoveRow_Leave(sender As Object, e As EventArgs) Handles btnRemoveRow.Leave
        lblActivityLogs.ForeColor = Color.Black
        lblActivityLogs.BackColor = SystemColors.Control
    End Sub

    Private Sub txtManagerRemarks_Enter(sender As Object, e As EventArgs)
        lblManagerRemarks.ForeColor = Color.White
        lblManagerRemarks.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtManagerRemarks_Leave(sender As Object, e As EventArgs)
        lblManagerRemarks.ForeColor = Color.Black
        lblManagerRemarks.BackColor = SystemColors.Control
    End Sub

    Private Sub txtEngineerRemarks_Enter(sender As Object, e As EventArgs)
        lblEngineerRemarks.ForeColor = Color.White
        lblEngineerRemarks.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtEngineerRemarks_Leave(sender As Object, e As EventArgs)
        lblEngineerRemarks.ForeColor = Color.Black
        lblEngineerRemarks.BackColor = SystemColors.Control
    End Sub

#End Region

End Class