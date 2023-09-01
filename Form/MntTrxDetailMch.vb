Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports BlackCoffeeLibrary

Public Class MntTrxDetailMch
    Private WithEvents bsSparePart As New BindingSource
    Private WithEvents bsTrxDetail As New BindingSource
    Private WithEvents bsTrxPartDetail As New BindingSource
    Private WithEvents bsTrxPartHeader As New BindingSource
    Private WithEvents bsTrxUser As New BindingSource
    Private WithEvents bsUserLog As New BindingSource
    Private accessLevel As New AccessLevel
    Private accessLevelId As Integer = 0
    Private adpTrxDetail As New SqlDataAdapter
    Private adpTrxPartDetail As New SqlDataAdapter
    Private adpTrxPartHeader As New SqlDataAdapter
    Private areaId As Integer = 0
    Private bite As Byte() 'the word `byte` is not a valid identifier
    Private cntPartTrxHeader As Integer = 0
    Private dbConnection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)
    Private dicApp1Action As New Dictionary(Of String, Integer)
    Private dicApp2Action As New Dictionary(Of String, Integer)
    Private dicApp3Action As New Dictionary(Of String, Integer)

    Private directory As New Directory
    Private dtRoutingStatus As New DataTable
    Private dtSparePart As New DataTable
    Private dtTrxDetail As New DataTable
    Private dtTrxHeader As New DataTable
    Private dtTrxMachinePart As New DataTable
    Private dtTrxPartDetail As New DataTable

    'Private dtTrxSparePart As New DataTable
    Private dtTrxPartHeader As New DataTable

    Private dtTrxUser As New DataTable
    Private dtUserLog As New DataTable
    Private dtUserPic As New DataTable
    Private imgDirectory As String = directory.ImgIniDirectoryMt
    Private imgTmp As String = String.Empty
    'Private impersonation As New UserImpersonation.UserImpersonation
    Private isAdmin As Boolean = True
    Private lstImgAttachment As New List(Of ImgAttachment)
    Private machineId As Integer = 0
    Private machinePartGroupId As Integer = 0
    Private monthId As Integer = 0
    Private mStream As New MemoryStream
    Private orgApp1Status As Integer = 0
    Private orgApp2Status As Integer = 0
    Private orgApp3Status As Integer = 0
    Private orgMachineGroupId As Integer = 0
    Private orgMachineId As Integer = 0
    Private orgMachineSubStatusId As Integer = 0
    Private orgModifiedBy As Nullable(Of Integer)
    Private orgModifiedDate As Nullable(Of Date)
    Private orgRoutingStatusId As Integer = 0
    Private orgScheduleId As Integer = 0
    Private scheduleId As Integer = 0
    Private serverNetUserName As String = String.Empty
    Private serverNetUserPassword As String = String.Empty
    Private trxCount As Integer = 0
    Private trxId As Integer = 0
    Private userId As Integer
    Private weekId As Integer = 0
    Private workgroupId As Integer = 0

    Public Sub New(_userId As Integer, _workgroupId As Integer, _isAdmin As Boolean, Optional _trxId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        workgroupId = _workgroupId
        isAdmin = _isAdmin
        trxId = _trxId

        'accessLevelId = accessLevel.GetAccessLevel(workgroupId)

        Select Case workgroupId
            Case 1, 2, 3 Or isAdmin 'sys admin, sr mngr, mngr
                accessLevelId = 1
            Case 35, 40 'mngr, asst mngr
                accessLevelId = 2
            Case 29, 30 'sv, asv
                accessLevelId = 3
            Case 5 'sr tech
                accessLevelId = 4
            Case Else
                accessLevelId = 99
        End Select

        InitializeContructor()
    End Sub

    'sr mngr action
    Public Property fromPmCalendar As Boolean = False

    Public Sub DisableForm(isDisable As Boolean)
        If isDisable Then
            cmbTransactionStatus.Enabled = False
            txtArea.Text = String.Empty

            cmbMachinePart.Enabled = False
            cmbDowntimeStatus.Enabled = False
            cmbDowntimeSubStatus.Enabled = False
            txtProblem.Enabled = False
            txtRootCause.Enabled = False
            txtActionTaken.Enabled = False

            txtJoNumber.Enabled = False
            txtJoRequestor.Enabled = False

            txtScheduleMonth.Text = String.Empty
            txtScheduleMonth.Enabled = False
            txtScheduleWeek.Text = String.Empty
            txtScheduleWeek.Enabled = False

            txtChecksheet.ReadOnly = True
            txt4M.ReadOnly = True

            btnAddLog.Enabled = False
            btnEditLog.Enabled = False
            btnDeleteLog.Enabled = False

            btnViewImage.Enabled = False
            btnBrowseImage.Enabled = False
            btnRemoveImage.Enabled = False

            btnViewChecksheet.Enabled = False
            btnRemoveChecksheet.Enabled = False

            btnView4M.Enabled = False
            btnRemove4M.Enabled = False

            dgvDetail.ClearSelection()
            dgvDetail.ReadOnly = True

            dgvPic.Enabled = False

            If trxId = 0 Then
                cmbApp3Status.Enabled = False
                cmbApp3Name.Enabled = False
                txtApp3Remarks.Enabled = False

                cmbApp2Status.Enabled = False
                cmbApp2Name.Enabled = False
                txtApp2Remarks.Enabled = False

                cmbApp1Status.Enabled = False
                cmbApp1Name.Enabled = False
                txtApp1Remarks.Enabled = False
            End If
        Else 'contains machine, enable form
            btnViewImage.Enabled = True
            btnViewChecksheet.Enabled = True
            btnView4M.Enabled = True

            If trxId = 0 Then 'new transaction, enable all controls, enable approvers controls based on accesslevel
                cmbTransactionStatus.Enabled = True

                If cmbMachinePart.Items.Count > 0 Then
                    cmbMachinePart.Enabled = True
                Else
                    cmbMachinePart.Enabled = False
                End If

                cmbDowntimeStatus.Enabled = True
                cmbDowntimeSubStatus.Enabled = True
                txtProblem.Enabled = True
                txtRootCause.Enabled = True
                txtActionTaken.Enabled = True

                txtJoNumber.Enabled = True
                txtJoRequestor.Enabled = True

                txtChecksheet.ReadOnly = False
                txt4M.ReadOnly = False

                btnAddLog.Enabled = True
                btnEditLog.Enabled = True
                btnDeleteLog.Enabled = True
                btnBrowseImage.Enabled = True
                btnRemoveImage.Enabled = True
                btnRemoveChecksheet.Enabled = True
                btnRemove4M.Enabled = True

                dgvDetail.ClearSelection()
                dgvDetail.Enabled = True

                dgvPic.Enabled = True

                If isAdmin Or accessLevelId = 1 Then
                    cmbApp3Status.Enabled = False
                    cmbApp3Name.Enabled = False
                    txtApp3Remarks.Enabled = False

                    cmbApp2Status.Enabled = False
                    cmbApp2Name.Enabled = False
                    txtApp2Remarks.Enabled = False

                    cmbApp1Status.Enabled = False
                    cmbApp1Name.Enabled = False
                    txtApp1Remarks.Enabled = False
                Else
                    Select Case accessLevelId
                        Case 2 'mngr, asm
                            cmbApp3Status.Enabled = False
                            cmbApp3Name.Enabled = True
                            txtApp3Remarks.Enabled = False

                            cmbApp2Status.Enabled = False
                            cmbApp2Name.Enabled = False
                            txtApp1Remarks.Enabled = False

                            cmbApp1Status.Enabled = False
                            cmbApp1Name.Enabled = False
                            txtApp1Remarks.Enabled = False

                        Case 3
                            cmbApp3Status.Enabled = False
                            cmbApp3Name.Enabled = True
                            txtApp3Remarks.Enabled = False

                            cmbApp2Status.Enabled = False
                            cmbApp2Name.Enabled = True
                            txtApp2Remarks.Enabled = False

                            cmbApp1Status.Enabled = False
                            cmbApp1Name.Enabled = False
                            txtApp1Remarks.Enabled = False

                        Case Else 'others
                            cmbApp3Status.Enabled = False
                            cmbApp3Name.Enabled = True
                            txtApp3Remarks.Enabled = False

                            cmbApp2Status.Enabled = False
                            cmbApp2Name.Enabled = True
                            txtApp2Remarks.Enabled = False

                            cmbApp1Status.Enabled = False
                            cmbApp1Name.Enabled = True
                            txtApp1Remarks.Enabled = False
                    End Select
                End If
            Else 'existing transaction
                If isAdmin Or accessLevelId = 1 Then
                    cmbTransactionStatus.Enabled = False
                    cmbMachineName.Enabled = True

                    cmbDowntimeStatus.Enabled = True
                    cmbDowntimeSubStatus.Enabled = True
                    txtProblem.Enabled = True
                    txtRootCause.Enabled = True
                    txtActionTaken.Enabled = True

                    txtJoNumber.Enabled = True
                    txtJoRequestor.Enabled = True
                    txtChecksheet.ReadOnly = False
                    txt4M.ReadOnly = False
                    btnAddLog.Enabled = True
                    btnEditLog.Enabled = True
                    btnDeleteLog.Enabled = True
                    btnBrowseImage.Enabled = True
                    btnRemoveImage.Enabled = True
                    btnRemoveChecksheet.Enabled = True
                    btnRemove4M.Enabled = True

                    dgvDetail.ClearSelection()
                    dgvDetail.Enabled = True

                    dgvPic.Enabled = True

                    cmbApp3Status.Enabled = True
                    cmbApp3Name.Enabled = True
                    txtApp3Remarks.Enabled = True

                    cmbApp2Status.Enabled = False
                    cmbApp2Name.Enabled = False
                    txtApp2Remarks.Enabled = False

                    cmbApp1Status.Enabled = False
                    cmbApp1Name.Enabled = False
                    txtApp1Remarks.Enabled = False
                Else 'other access level
                    Select Case accessLevelId
                        Case 2 'mngr, asm
                            Select Case orgRoutingStatusId
                                Case 1, 2 'from `for approval of approver 3` and `completed`, disable the form
                                    cmbTransactionStatus.Enabled = False
                                    cmbMachineName.Enabled = False

                                    cmbDowntimeStatus.Enabled = False
                                    cmbDowntimeSubStatus.Enabled = False
                                    txtProblem.Enabled = False
                                    txtRootCause.Enabled = False
                                    txtActionTaken.Enabled = False

                                    txtJoNumber.Enabled = False
                                    txtJoRequestor.Enabled = False

                                    txtChecksheet.ReadOnly = True
                                    txt4M.ReadOnly = True

                                    btnAddLog.Enabled = False
                                    btnEditLog.Enabled = False
                                    btnDeleteLog.Enabled = False
                                    btnBrowseImage.Enabled = False
                                    btnRemoveImage.Enabled = False
                                    btnRemoveChecksheet.Enabled = False
                                    btnRemove4M.Enabled = False

                                    dgvDetail.ClearSelection()
                                    dgvDetail.Enabled = False

                                    dgvPic.Enabled = False

                                    cmbApp3Status.Enabled = False
                                    cmbApp3Name.Enabled = False
                                    txtApp3Remarks.Enabled = False

                                    cmbApp2Status.Enabled = False
                                    cmbApp2Name.Enabled = False
                                    txtApp2Remarks.Enabled = False

                                    cmbApp1Status.Enabled = False
                                    cmbApp1Name.Enabled = False
                                    txtApp1Remarks.Enabled = False

                                    btnSave.Enabled = False
                                    btnCancel.Enabled = False
                                    btnDelete.Enabled = False

                                Case Else
                                    cmbMachineName.Enabled = True

                                    cmbDowntimeStatus.Enabled = True
                                    cmbDowntimeSubStatus.Enabled = True
                                    txtProblem.Enabled = True
                                    txtRootCause.Enabled = True
                                    txtActionTaken.Enabled = True

                                    txtJoNumber.Enabled = True
                                    txtJoRequestor.Enabled = True

                                    txtChecksheet.ReadOnly = False
                                    txt4M.ReadOnly = False

                                    btnAddLog.Enabled = True
                                    btnEditLog.Enabled = True
                                    btnDeleteLog.Enabled = True
                                    btnBrowseImage.Enabled = True
                                    btnRemoveImage.Enabled = True
                                    btnRemoveChecksheet.Enabled = True
                                    btnRemove4M.Enabled = True

                                    cmbApp3Status.Enabled = False
                                    txtApp3Remarks.Enabled = False

                                    If String.IsNullOrEmpty(txtApp3Date.Text.Trim) Then
                                        cmbApp3Name.Enabled = True
                                    Else
                                        cmbApp3Name.Enabled = False
                                    End If

                                    btnSave.Enabled = True
                                    btnCancel.Enabled = True
                                    btnDelete.Enabled = True

                                    Select Case orgRoutingStatusId
                                        Case 6, 5 'from `returned to revision` to `on-going`
                                            cmbTransactionStatus.Enabled = True

                                            cmbApp2Status.SelectedValue = 0
                                            cmbApp2Name.SelectedValue = 0
                                            txtApp2Remarks.Clear()

                                            cmbApp2Status.Enabled = False
                                            cmbApp2Name.Enabled = False
                                            txtApp2Remarks.Enabled = False

                                            cmbApp1Status.SelectedValue = 0
                                            cmbApp1Name.SelectedValue = 0
                                            txtApp1Remarks.Clear()

                                            cmbApp1Status.Enabled = False
                                            cmbApp1Name.Enabled = False
                                            txtApp1Remarks.Enabled = False

                                        Case 4 'for approval of approver 1
                                            cmbTransactionStatus.Enabled = False

                                            cmbApp2Status.Enabled = False
                                            cmbApp2Name.Enabled = False
                                            txtApp2Remarks.Enabled = False

                                            cmbApp1Status.Enabled = False
                                            cmbApp1Name.Enabled = False
                                            txtApp1Remarks.Enabled = False

                                        Case 3 'for approval of approver 2
                                            cmbTransactionStatus.Enabled = False

                                            cmbApp2Status.Enabled = True
                                            cmbApp2Name.Enabled = False
                                            txtApp2Remarks.Enabled = True

                                            cmbApp1Status.Enabled = False
                                            cmbApp1Name.Enabled = False
                                            txtApp1Remarks.Enabled = False

                                        Case Else
                                            cmbTransactionStatus.Enabled = False

                                            cmbApp2Status.Enabled = False
                                            cmbApp2Name.Enabled = False
                                            txtApp2Remarks.Enabled = False

                                            cmbApp1Status.Enabled = False
                                            cmbApp1Name.Enabled = False
                                            txtApp1Remarks.Enabled = False
                                    End Select
                            End Select

                        Case 3 'sv, asv
                            Select Case orgRoutingStatusId
                                Case 1, 2 'from `for approval of approver 2` to `completed`, disable the form
                                    cmbTransactionStatus.Enabled = False
                                    cmbMachineName.Enabled = False

                                    cmbDowntimeStatus.Enabled = False
                                    cmbDowntimeSubStatus.Enabled = False
                                    txtProblem.Enabled = False
                                    txtRootCause.Enabled = False
                                    txtActionTaken.Enabled = False

                                    txtJoNumber.Enabled = False
                                    txtJoRequestor.Enabled = False

                                    txtChecksheet.ReadOnly = True
                                    txt4M.ReadOnly = True

                                    btnAddLog.Enabled = False
                                    btnEditLog.Enabled = False
                                    btnDeleteLog.Enabled = False
                                    btnBrowseImage.Enabled = False
                                    btnRemoveImage.Enabled = False
                                    btnRemoveChecksheet.Enabled = False
                                    btnRemove4M.Enabled = False

                                    dgvDetail.ClearSelection()
                                    dgvDetail.Enabled = False

                                    dgvPic.Enabled = False

                                    cmbApp3Status.Enabled = False
                                    cmbApp3Name.Enabled = False
                                    txtApp3Remarks.Enabled = False

                                    cmbApp2Status.Enabled = False
                                    cmbApp2Name.Enabled = False
                                    txtApp2Remarks.Enabled = False

                                    cmbApp1Status.Enabled = False
                                    cmbApp1Name.Enabled = False
                                    txtApp1Remarks.Enabled = False

                                    btnSave.Enabled = False
                                    btnCancel.Enabled = False
                                    btnDelete.Enabled = False

                                Case Else
                                    cmbMachineName.Enabled = True

                                    cmbDowntimeStatus.Enabled = True
                                    cmbDowntimeSubStatus.Enabled = True
                                    txtProblem.Enabled = True
                                    txtRootCause.Enabled = True
                                    txtActionTaken.Enabled = True

                                    txtJoNumber.Enabled = True
                                    txtJoRequestor.Enabled = True

                                    txtChecksheet.ReadOnly = False
                                    txt4M.ReadOnly = False

                                    btnAddLog.Enabled = True
                                    btnEditLog.Enabled = True
                                    btnDeleteLog.Enabled = True
                                    btnBrowseImage.Enabled = True
                                    btnRemoveImage.Enabled = True
                                    btnRemoveChecksheet.Enabled = True
                                    btnRemove4M.Enabled = True

                                    cmbApp3Status.Enabled = False
                                    txtApp3Remarks.Enabled = False

                                    If String.IsNullOrEmpty(txtApp3Date.Text.Trim) Then
                                        cmbApp3Name.Enabled = True
                                    Else
                                        cmbApp3Name.Enabled = False
                                    End If

                                    btnSave.Enabled = True
                                    btnCancel.Enabled = True
                                    btnDelete.Enabled = True

                                    Select Case orgRoutingStatusId
                                        Case 6, 5 'from `returned to revision` to `on-going`
                                            cmbTransactionStatus.Enabled = True

                                            cmbApp2Status.Enabled = False
                                            txtApp2Remarks.Enabled = False

                                            If String.IsNullOrWhiteSpace(txtApp2Date.Text.Trim) Then
                                                cmbApp2Name.Enabled = True
                                            Else
                                                cmbApp2Name.Enabled = False
                                            End If

                                            cmbApp1Status.SelectedValue = 0
                                            cmbApp1Name.SelectedValue = 0
                                            txtApp1Remarks.Clear()

                                            cmbApp1Status.Enabled = False
                                            cmbApp1Name.Enabled = False
                                            txtApp1Remarks.Enabled = False

                                        Case 4
                                            cmbTransactionStatus.Enabled = False

                                            cmbApp2Status.Enabled = False
                                            txtApp2Remarks.Enabled = False

                                            If String.IsNullOrWhiteSpace(txtApp2Date.Text.Trim) Then
                                                cmbApp2Name.Enabled = True
                                            Else
                                                cmbApp2Name.Enabled = False
                                            End If

                                            cmbApp1Status.Enabled = True
                                            cmbApp1Name.Enabled = False
                                            txtApp1Remarks.Enabled = True

                                        Case Else
                                            cmbTransactionStatus.Enabled = False

                                            cmbApp2Status.Enabled = False
                                            cmbApp2Name.Enabled = False
                                            txtApp2Remarks.Enabled = False

                                            cmbApp1Status.Enabled = False
                                            cmbApp1Name.Enabled = False
                                            txtApp1Remarks.Enabled = False
                                    End Select
                            End Select

                        Case Else 'technician
                            Select Case orgRoutingStatusId
                                Case 6, 5 'from `returned to revision` to `on-going activity`
                                    cmbTransactionStatus.Enabled = True
                                    cmbMachineName.Enabled = True

                                    cmbDowntimeStatus.Enabled = True
                                    cmbDowntimeSubStatus.Enabled = True
                                    txtProblem.Enabled = True
                                    txtRootCause.Enabled = True
                                    txtActionTaken.Enabled = True

                                    txtJoNumber.Enabled = True
                                    txtJoRequestor.Enabled = True

                                    txtChecksheet.ReadOnly = False
                                    txt4M.ReadOnly = False

                                    btnAddLog.Enabled = True
                                    btnEditLog.Enabled = True
                                    btnDeleteLog.Enabled = True
                                    btnBrowseImage.Enabled = True
                                    btnRemoveImage.Enabled = True
                                    btnRemoveChecksheet.Enabled = True
                                    btnRemove4M.Enabled = True

                                    dgvDetail.ClearSelection()
                                    dgvDetail.Enabled = True

                                    dgvPic.Enabled = True

                                    cmbApp3Status.Enabled = False
                                    txtApp3Remarks.Enabled = False

                                    If String.IsNullOrWhiteSpace(txtApp3Date.Text.Trim) Then
                                        cmbApp3Name.Enabled = True
                                    Else
                                        cmbApp3Name.Enabled = False
                                    End If

                                    cmbApp2Status.Enabled = False
                                    txtApp2Remarks.Enabled = False

                                    If String.IsNullOrWhiteSpace(txtApp2Date.Text.Trim) Then
                                        cmbApp2Name.Enabled = True
                                    Else
                                        cmbApp2Name.Enabled = False
                                    End If

                                    cmbApp1Status.Enabled = False
                                    txtApp1Remarks.Enabled = False

                                    If String.IsNullOrWhiteSpace(txtApp1Date.Text.Trim) Then
                                        cmbApp1Name.Enabled = True
                                    Else
                                        cmbApp1Name.Enabled = False
                                    End If

                                    btnSave.Enabled = True
                                    btnCancel.Enabled = True
                                    btnDelete.Enabled = True

                                Case Else 'from `for approval of approver 1` to `completed`, disable the form once the activity is already on approvers
                                    cmbTransactionStatus.Enabled = False
                                    cmbMachineName.Enabled = False

                                    cmbDowntimeStatus.Enabled = False
                                    cmbDowntimeSubStatus.Enabled = False
                                    txtProblem.Enabled = False
                                    txtRootCause.Enabled = False
                                    txtActionTaken.Enabled = False

                                    txtJoNumber.Enabled = False
                                    txtJoRequestor.Enabled = False

                                    txtChecksheet.ReadOnly = True
                                    txt4M.ReadOnly = True

                                    btnAddLog.Enabled = False
                                    btnEditLog.Enabled = False
                                    btnDeleteLog.Enabled = False
                                    btnBrowseImage.Enabled = False
                                    btnRemoveImage.Enabled = False
                                    btnRemoveChecksheet.Enabled = False
                                    btnRemove4M.Enabled = False

                                    dgvDetail.ClearSelection()
                                    dgvDetail.Enabled = False

                                    dgvPic.Enabled = False

                                    cmbApp3Status.Enabled = False
                                    cmbApp3Name.Enabled = False
                                    txtApp3Remarks.Enabled = False

                                    cmbApp2Status.Enabled = False
                                    cmbApp2Name.Enabled = False
                                    txtApp2Remarks.Enabled = False

                                    cmbApp1Status.Enabled = False
                                    cmbApp1Name.Enabled = False
                                    txtApp1Remarks.Enabled = False

                                    btnSave.Enabled = False
                                    btnCancel.Enabled = False
                                    btnDelete.Enabled = False
                            End Select
                    End Select
                End If
            End If
        End If
    End Sub

    Public Sub InitializeContructor()
        dbMain.EnableDoubleBuffered(dgvDetail)
        dbMain.EnableDoubleBuffered(dgvPic)
        dbMain.EnableDoubleBuffered(dgvPartDetail)

        dtTrxDetail = CreateTrxDetail()
        dtTrxPartDetail = CreateTrxPartDetail()
        dtRoutingStatus = dbMethod.FillDataTable("RdGenRoutingStatus", CommandType.StoredProcedure)
        dtUserLog = dbMethod.FillDataTable("RdSecUser", CommandType.StoredProcedure)
        dtUserPic = dbMethod.FillDataTable("RdSecUser", CommandType.StoredProcedure)

        Me.bsUserLog.DataSource = dtUserLog

        'activity log table
        Dim colNickname As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colNickname.Name = "ColNickname"
        colNickname.DataPropertyName = "UserId"
        colNickname.HeaderText = "Technician"
        colNickname.DataSource = Me.bsUserLog
        colNickname.ValueMember = "UserId"
        colNickname.DisplayMember = "Nickname"
        colNickname.Width = 103
        colNickname.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colNickname.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colNickname.SortMode = DataGridViewColumnSortMode.NotSortable
        dgvDetail.Columns.Insert(3, colNickname)

        Dim prmPart(1) As SqlParameter
        prmPart(0) = New SqlParameter("@IsNoStock", SqlDbType.Bit)
        prmPart(0).Value = 0
        prmPart(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
        prmPart(1).Value = 1
        dtSparePart = dbMethod.FillDataTable("RdMntSparePart", CommandType.StoredProcedure, prmPart)

        Me.bsSparePart.DataSource = dtSparePart

        'transaction part detail table
        Dim colPartNo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colPartNo.Name = "ColPartNo"
        colPartNo.DataPropertyName = "PartId"
        colPartNo.HeaderText = "Part No"
        colPartNo.DataSource = Me.bsSparePart
        colPartNo.ValueMember = "PartId"
        colPartNo.DisplayMember = "PartNo"
        colPartNo.Width = 195
        colPartNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colPartNo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colPartNo.SortMode = DataGridViewColumnSortMode.Automatic
        dgvPartDetail.Columns.Insert(1, colPartNo)

        Dim colPartName As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colPartName.Name = "ColPartName"
        colPartName.DataPropertyName = "PartId"
        colPartName.HeaderText = "Part Name"
        colPartName.DataSource = Me.bsSparePart
        colPartName.ValueMember = "PartId"
        colPartName.DisplayMember = "PartName"
        colPartName.Width = 195
        colPartName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colPartName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colPartName.SortMode = DataGridViewColumnSortMode.Automatic
        dgvPartDetail.Columns.Insert(2, colPartName)

        Dim colPartNickname As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colPartNickname.Name = "ColUserIdPart"
        colPartNickname.DataPropertyName = "UserId"
        colPartNickname.HeaderText = "Technician"
        colPartNickname.DataSource = Me.bsUserLog
        colPartNickname.ValueMember = "UserId"
        colPartNickname.DisplayMember = "Nickname"
        colPartNickname.Width = 93
        colPartNickname.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colPartNickname.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colPartNickname.SortMode = DataGridViewColumnSortMode.NotSortable
        dgvPartDetail.Columns.Insert(4, colPartNickname)

        'pic table
        Me.bsTrxUser.DataSource = dtUserPic
        Me.bsTrxUser.Filter = String.Format("SectionId = 2 AND IsActive = 1")
        dgvPic.AutoGenerateColumns = False
        dgvPic.DataSource = Me.bsTrxUser

        LoadTransactionStatus()
        LoadMachine()
        'GetSetting(My.Settings.SettingsId)
        'impersonation.ImpersonateUser(serverNetUserName, "", serverNetUserPassword)

        LoadApproverAction()
        LoadApprovers()

        If trxId = 0 Then
            Me.bsTrxDetail.DataSource = dtTrxDetail
            dgvDetail.AutoGenerateColumns = False
            dgvDetail.DataSource = Me.bsTrxDetail

            Me.bsTrxPartDetail.DataSource = dtTrxPartDetail
            dgvPartDetail.AutoGenerateColumns = False
            dgvPartDetail.DataSource = Me.bsTrxPartDetail
        Else
            'transaction header
            Dim prmHeader(0) As SqlParameter
            prmHeader(0) = New SqlParameter("@TrxId", SqlDbType.Int)
            prmHeader(0).Value = trxId
            dtTrxHeader = dbMethod.FillDataTable("RdMntTransactionHeaderByTrxId", CommandType.StoredProcedure, prmHeader)

            'transaction detail
            Dim prmDetail(0) As SqlParameter
            prmDetail(0) = New SqlParameter("@TrxId", SqlDbType.Int)
            prmDetail(0).Value = trxId
            dtTrxDetail = dbMethod.FillDataTable("RdMntTransactionDetailByTrxId", CommandType.StoredProcedure, prmDetail)

            Me.bsTrxDetail.DataSource = dtTrxDetail
            Me.bsTrxDetail.Sort = "TrxFrom"
            dgvDetail.AutoGenerateColumns = False
            dgvDetail.DataSource = Me.bsTrxDetail

            'transaction machine part
            Dim prmMchPart(0) As SqlParameter
            prmMchPart(0) = New SqlParameter("@TrxId", SqlDbType.Int)
            prmMchPart(0).Value = trxId
            dtTrxMachinePart = dbMethod.FillDataTable("RdMntTransactionMachinePartByTrxId", CommandType.StoredProcedure, prmMchPart)

            Dim prmPrHeader1(0) As SqlParameter
            prmPrHeader1(0) = New SqlParameter("@TrxId", SqlDbType.Int)
            prmPrHeader1(0).Value = trxId
            cntPartTrxHeader = dbMethod.ExecuteScalar("CntMntTransactionPartHeaderByTrxId", CommandType.StoredProcedure, prmPrHeader1)

            If cntPartTrxHeader > 0 Then
                'transaction part header
                Dim prmPrHeader2(0) As SqlParameter
                prmPrHeader2(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                prmPrHeader2(0).Value = trxId
                dtTrxPartHeader = dbMethod.FillDataTable("RdMntTransactionPartHeaderByTrxId", CommandType.StoredProcedure, prmPrHeader2)

                'transaction part detail
                Dim prmPrDetail(0) As SqlParameter
                prmPrDetail(0) = New SqlParameter("@PartTrxId", SqlDbType.Int)
                prmPrDetail(0).Value = dtTrxPartHeader.Rows(0).Item("PartTrxId")
                dtTrxPartDetail = dbMethod.FillDataTable("RdMntTransactionPartDetailByPartTrxId", CommandType.StoredProcedure, prmPrDetail)

                Me.bsTrxPartDetail.DataSource = dtTrxPartDetail
                Me.bsTrxPartDetail.Sort = "CreatedDate, SeqId"
                dgvPartDetail.AutoGenerateColumns = False
                dgvPartDetail.DataSource = Me.bsTrxPartDetail
            End If

            'transaction user
            Dim prmUser(0) As SqlParameter
            prmUser(0) = New SqlParameter("@TrxId", SqlDbType.Int)
            prmUser(0).Value = trxId
            dtTrxUser = dbMethod.FillDataTable("RdMntTransactionUserByTrxId", CommandType.StoredProcedure, prmUser)

            FilterPicTable()
        End If
    End Sub

    Public Async Sub OpenImage(ByVal imagePath As String, ByVal time As Integer)
        Try
            Dim exePathReturnValue = New StringBuilder()
            FindExecutable(Path.GetFileName(imagePath), Path.GetDirectoryName(imagePath), exePathReturnValue)
            Dim exePath = exePathReturnValue.ToString()
            Dim arguments = """" & imagePath & """"

            If Path.GetFileName(exePath).Equals("photoviewer.dll", StringComparison.InvariantCultureIgnoreCase) Then
                arguments = """" & exePath & """, ImageView_Fullscreen " & imagePath
                exePath = "rundll32"
            End If

            Dim process = New Process()
            process.StartInfo.FileName = exePath
            process.StartInfo.Arguments = arguments
            process.EnableRaisingEvents = True
            AddHandler process.Exited, New EventHandler(AddressOf DeleteTempImg)
            process.Start()

            Await Task.Delay(time)

            If Not process.HasExited Then
                process.Kill()
            End If

            process.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    <DllImport("shell32.dll")>
    Private Shared Function FindExecutable(ByVal lpFile As String, ByVal lpDirectory As String, <Out> ByVal lpResult As StringBuilder) As Integer
    End Function

    Private Sub btnAddLog_Click(sender As Object, e As EventArgs) Handles btnAddLog.Click
        Try
            If trxId = 0 Then
                Using frmDetailLog As New MntTrxActvityLog()
                    frmDetailLog.childBsTrxDetail = Me.bsTrxDetail

                    If frmDetailLog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Me.bsTrxDetail.AddNew()
                        Me.bsTrxDetail.MoveLast()
                        Me.bsTrxDetail.Current("TrxDetailId") = DBNull.Value
                        Me.bsTrxDetail.Current("TrxId") = DBNull.Value
                        Me.bsTrxDetail.Current("TrxDate") = dbMethod.GetServerDate
                        Me.bsTrxDetail.Current("TrxFrom") = frmDetailLog.dtpFrom.Value
                        Me.bsTrxDetail.Current("TrxTo") = frmDetailLog.dtpTo.Value
                        Me.bsTrxDetail.Current("ElapsedTime") = frmDetailLog.txtElapsedTime.Text.Trim
                        Me.bsTrxDetail.Current("UserId") = frmDetailLog.cmbTechnician.SelectedValue
                        Me.bsTrxDetail.Current("ShiftId") = IIf(frmDetailLog.rdDay.Checked = True, "D", "N")
                        Me.bsTrxDetail.Current("SeqId") = dgvDetail.Rows.Count
                        Me.bsTrxDetail.EndEdit()

                        For Each dr As DataRow In frmDetailLog.dtTrxPartDetail.Rows
                            Me.bsTrxPartDetail.AddNew()
                            Me.bsTrxPartDetail.MoveLast()
                            Me.bsTrxPartDetail.Current("PartTrxDetailId") = DBNull.Value
                            Me.bsTrxPartDetail.Current("PartTrxId") = DBNull.Value
                            Me.bsTrxPartDetail.Current("SeqId") = dgvDetail.Rows.Count
                            Me.bsTrxPartDetail.Current("CreatedBy") = frmDetailLog.cmbTechnician.SelectedValue
                            Me.bsTrxPartDetail.Current("CreatedDate") = dbMethod.GetServerDate
                            Me.bsTrxPartDetail.Current("UserId") = frmDetailLog.cmbTechnician.SelectedValue
                            Me.bsTrxPartDetail.Current("PartId") = dr("PartId")
                            Me.bsTrxPartDetail.Current("Qty") = dr("Qty")
                            Me.bsTrxPartDetail.EndEdit()
                        Next
                    Else
                        Me.bsTrxDetail.CancelEdit()
                    End If
                End Using

            Else
                Using frmDetailLog As New MntTrxActvityLog(trxId, 0)
                    frmDetailLog.childBsTrxDetail = Me.bsTrxDetail

                    If frmDetailLog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Me.bsTrxDetail.AddNew()
                        Me.bsTrxDetail.MoveLast()
                        Me.bsTrxDetail.Current("TrxDetailId") = DBNull.Value
                        Me.bsTrxDetail.Current("TrxId") = trxId
                        Me.bsTrxDetail.Current("TrxDate") = dbMethod.GetServerDate
                        Me.bsTrxDetail.Current("TrxFrom") = frmDetailLog.dtpFrom.Value
                        Me.bsTrxDetail.Current("TrxTo") = frmDetailLog.dtpTo.Value
                        Me.bsTrxDetail.Current("ElapsedTime") = frmDetailLog.txtElapsedTime.Text.Trim
                        Me.bsTrxDetail.Current("UserId") = frmDetailLog.cmbTechnician.SelectedValue
                        Me.bsTrxDetail.Current("ShiftId") = IIf(frmDetailLog.rdDay.Checked = True, "D", "N")
                        Me.bsTrxDetail.Current("SeqId") = dgvDetail.Rows.Count
                        Me.bsTrxDetail.EndEdit()

                        For Each dr As DataRow In frmDetailLog.dtTrxPartDetail.Rows
                            Me.bsTrxPartDetail.AddNew()
                            Me.bsTrxPartDetail.MoveLast()
                            Me.bsTrxPartDetail.Current("PartTrxDetailId") = DBNull.Value
                            Me.bsTrxPartDetail.Current("PartTrxId") = dtTrxPartHeader.Rows(0).Item("PartTrxId")
                            Me.bsTrxPartDetail.Current("SeqId") = dgvDetail.Rows.Count
                            Me.bsTrxPartDetail.Current("CreatedBy") = frmDetailLog.cmbTechnician.SelectedValue
                            Me.bsTrxPartDetail.Current("CreatedDate") = dbMethod.GetServerDate
                            Me.bsTrxPartDetail.Current("UserId") = frmDetailLog.cmbTechnician.SelectedValue
                            Me.bsTrxPartDetail.Current("PartId") = dr("PartId")
                            Me.bsTrxPartDetail.Current("Qty") = dr("Qty")
                            Me.bsTrxPartDetail.EndEdit()
                        Next
                    Else
                        Me.bsTrxDetail.CancelEdit()
                    End If
                End Using
            End If

            Me.bsTrxDetail.Sort = "TrxFrom"

            FilterPicTable()
            GetTotalDowntime()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddRow_Enter(sender As Object, e As EventArgs) Handles btnAddLog.Enter
        lblActivityLog.ForeColor = Color.White
        lblActivityLog.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub btnAddRow_Leave(sender As Object, e As EventArgs) Handles btnAddLog.Leave
        lblActivityLog.ForeColor = Color.Black
        lblActivityLog.BackColor = SystemColors.Control
    End Sub

    Private Sub btnBrowseImage_Click(sender As Object, e As EventArgs) Handles btnBrowseImage.Click
        Try
            ofdImage.Filter = "JPEGs (*.jpg, *.jpeg) | *.jpg; *.jpeg |GIFs (*.gif) | *.gif |Bitmaps (*.bmp) | *.bmp | All Images (*.*) | *.jpg; *.jpeg; *.gif; *.bmp; *.png; *.tif; *.tiff"
            ofdImage.FilterIndex = 7
            ofdImage.ShowDialog()
            ofdImage.RestoreDirectory = True
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If btnDelete.Enabled = False Then
                Exit Sub
            End If

            If accessLevelId >= 4 Then 'technician and below
                MessageBox.Show("You do not have permission to delete a record.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If trxId > 0 Then
                Dim question As String = String.Format("Are you sure you want to delete this record?")
                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    If scheduleId > 0 AndAlso dtTrxHeader.Rows(0).Item("DowntimeMachineSubStatusId") = 3 Then 'clear the pm schedule slot
                        Dim prmMchSchdOrg(8) As SqlParameter
                        prmMchSchdOrg(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmMchSchdOrg(0).Value = Nothing
                        prmMchSchdOrg(1) = New SqlParameter("@IsDone", SqlDbType.Bit)
                        prmMchSchdOrg(1).Value = False
                        prmMchSchdOrg(2) = New SqlParameter("@IsChecklistCompleted", SqlDbType.Bit)
                        prmMchSchdOrg(2).Value = False
                        prmMchSchdOrg(3) = New SqlParameter("@ActivityBy", SqlDbType.Int)
                        prmMchSchdOrg(3).Value = Nothing
                        prmMchSchdOrg(4) = New SqlParameter("@ActivityDate", SqlDbType.Date)
                        prmMchSchdOrg(4).Value = Nothing
                        prmMchSchdOrg(5) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                        prmMchSchdOrg(5).Value = Nothing
                        prmMchSchdOrg(6) = New SqlParameter("@ModifiedDate", SqlDbType.Date)
                        prmMchSchdOrg(6).Value = Nothing
                        prmMchSchdOrg(7) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                        prmMchSchdOrg(7).Value = Nothing
                        prmMchSchdOrg(8) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                        prmMchSchdOrg(8).Value = orgScheduleId

                        dbMethod.ExecuteNonQuery("UpdMntMachineScheduleByScheduleId", CommandType.StoredProcedure, prmMchSchdOrg)
                    End If

                    'if this is the last on-going transaction, revert the machine to operational status
                    Dim prmIsLast(0) As SqlParameter
                    prmIsLast(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmIsLast(0).Value = orgMachineId

                    If trxId = dbMethod.ExecuteScalar("SELECT TOP 1 TrxId FROM dbo.MntTransactionHeader WHERE MachineId = @MachineId AND TrxStatusId = 2 ORDER BY TrxId DESC", CommandType.Text, prmIsLast) Then

                        Dim prmMachineStatus(2) As SqlParameter
                        prmMachineStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prmMachineStatus(0).Value = dtTrxHeader.Rows(0).Item("MachineId")
                        prmMachineStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                        prmMachineStatus(1).Value = 1
                        prmMachineStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                        prmMachineStatus(2).Value = 1

                        dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMachineStatus)
                    End If

                    Dim prmDel(0) As SqlParameter
                    prmDel(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmDel(0).Value = trxId

                    dbMethod.ExecuteNonQuery("DelMntTransactionHeader", CommandType.StoredProcedure, prmDel)

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDeleteLog_Click(sender As Object, e As EventArgs) Handles btnDeleteLog.Click
        Try
            If dgvDetail.Rows.Count > 0 Then
                Dim question As String = String.Empty

                If dgvPartDetail.Rows.Count > 0 And trxId = 0 Then
                    question = String.Format("Are you sure you want to delete this activity log?" & Environment.NewLine & "NOTE: Record of parts issued will be deleted.")

                ElseIf dgvPartDetail.Rows.Count > 0 AndAlso trxId <> 0 Then
                    question = String.Format("Are you sure you want to delete this activity log?" & Environment.NewLine & "NOTE: Record of parts issued will not be deleted.")
                Else
                    question = "Are you sure you want to delete this activity log?"
                End If

                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim seqId As Integer = CType(Me.bsTrxDetail.Current, DataRowView).Item("SeqId")
                    Dim currentRow = CType(Me.bsTrxDetail.Current, DataRowView).Row
                    Dim rowState = currentRow.RowState

                    Select Case rowState
                        Case DataRowState.Added
                            Me.bsTrxDetail.RemoveCurrent()

                        Case DataRowState.Detached
                            Me.bsTrxDetail.CancelEdit()

                        Case DataRowState.Modified, DataRowState.Unchanged
                            If dgvDetail.SelectedCells.Count > 0 AndAlso dgvDetail.SelectedCells(0).RowIndex = dgvDetail.NewRowIndex Then
                                Me.bsTrxDetail.CancelEdit()
                                Exit Sub
                            End If

                            Me.bsTrxDetail.RemoveCurrent()

                        Case Else

                    End Select

                    'parts for issuance not yet saved
                    If dgvPartDetail.Rows.Count > 0 AndAlso trxId = 0 Then
                        For Each row As DataRowView In Me.bsTrxPartDetail
                            If row("SeqId") = seqId Then
                                Me.bsTrxPartDetail.Remove(row)
                            End If
                        Next
                    End If
                End If

                Me.bsTrxDetail.Sort = "TrxFrom"

                FilterPicTable()
                GetTotalDowntime()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEditLog_Click(sender As Object, e As EventArgs) Handles btnEditLog.Click
        Try
            If dgvDetail.Rows.Count > 0 Then
                If trxId = 0 Then
                    Dim seqId As Integer = CType(Me.bsTrxDetail.Current, DataRowView).Item("SeqId")
                    Dim userId As Integer = CType(Me.bsTrxDetail.Current, DataRowView).Item("UserId")

                    Using frmDetailLog As New MntTrxActvityLog(0, userId)
                        frmDetailLog.childBsTrxDetail = Me.bsTrxDetail

                        frmDetailLog.cmbTechnician.SelectedValue = userId
                        frmDetailLog.dtpFrom.Value = CType(Me.bsTrxDetail.Current, DataRowView).Item("TrxFrom")
                        frmDetailLog.dtpTo.Value = CType(Me.bsTrxDetail.Current, DataRowView).Item("TrxTo")

                        If CType(Me.bsTrxDetail.Current, DataRowView).Item("ShiftId").ToString = "D" Then
                            frmDetailLog.rdDay.Checked = True
                        Else
                            frmDetailLog.rdNight.Checked = True
                        End If

                        If dgvPartDetail.Rows.Count > 0 Then
                            For Each dr As DataRow In dtTrxPartDetail.Rows
                                If dr("SeqId") = seqId Then
                                    Dim row As DataRow = frmDetailLog.dtTrxPartDetail.NewRow

                                    row("PartTrxDetailId") = DBNull.Value
                                    row("PartTrxId") = DBNull.Value
                                    row("SeqId") = seqId
                                    row("CreatedBy") = dr("CreatedBy")
                                    row("CreatedDate") = dr("CreatedDate")
                                    row("UserId") = dr("UserId")
                                    row("PartId") = dr("PartId")
                                    row("Qty") = dr("Qty")
                                    frmDetailLog.dtTrxPartDetail.Rows.Add(row)
                                End If
                            Next
                        End If

                        If frmDetailLog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                            Me.bsTrxDetail.Current("TrxId") = DBNull.Value
                            Me.bsTrxDetail.Current("TrxDate") = dbMethod.GetServerDate
                            Me.bsTrxDetail.Current("TrxFrom") = frmDetailLog.dtpFrom.Value
                            Me.bsTrxDetail.Current("TrxTo") = frmDetailLog.dtpTo.Value
                            Me.bsTrxDetail.Current("ElapsedTime") = frmDetailLog.txtElapsedTime.Text.Trim
                            Me.bsTrxDetail.Current("UserId") = frmDetailLog.cmbTechnician.SelectedValue
                            Me.bsTrxDetail.Current("ShiftId") = IIf(frmDetailLog.rdDay.Checked = True, "D", "N")
                            Me.bsTrxDetail.EndEdit()

                            If frmDetailLog.dgvPartDetail.Rows.Count > 0 Then
                                For Each row As DataRowView In Me.bsTrxPartDetail
                                    If row("SeqId") = seqId Then
                                        Me.bsTrxPartDetail.Remove(row)
                                    End If
                                Next

                                For Each dr As DataRow In frmDetailLog.dtTrxPartDetail.Rows
                                    Me.bsTrxPartDetail.AddNew()
                                    Me.bsTrxPartDetail.MoveLast()
                                    Me.bsTrxPartDetail.Current("PartTrxDetailId") = DBNull.Value
                                    Me.bsTrxPartDetail.Current("PartTrxId") = DBNull.Value
                                    Me.bsTrxPartDetail.Current("SeqId") = seqId
                                    Me.bsTrxPartDetail.Current("CreatedBy") = frmDetailLog.cmbTechnician.SelectedValue
                                    Me.bsTrxPartDetail.Current("CreatedDate") = dbMethod.GetServerDate
                                    Me.bsTrxPartDetail.Current("UserId") = frmDetailLog.cmbTechnician.SelectedValue
                                    Me.bsTrxPartDetail.Current("PartId") = dr("PartId")
                                    Me.bsTrxPartDetail.Current("Qty") = dr("Qty")
                                    Me.bsTrxPartDetail.EndEdit()
                                Next
                            End If
                        Else
                            Me.bsTrxDetail.CancelEdit()
                        End If
                    End Using

                Else
                    Dim seqId As Integer = CType(Me.bsTrxDetail.Current, DataRowView).Item("SeqId")
                    Dim userId As Integer = CType(Me.bsTrxDetail.Current, DataRowView).Item("UserId")

                    Using frmDetailLog As New MntTrxActvityLog(trxId, userId)
                        frmDetailLog.childBsTrxDetail = Me.bsTrxDetail

                        frmDetailLog.dtpFrom.Value = CType(Me.bsTrxDetail.Current, DataRowView).Item("TrxFrom")
                        frmDetailLog.dtpTo.Value = CType(Me.bsTrxDetail.Current, DataRowView).Item("TrxTo")
                        frmDetailLog.cmbTechnician.SelectedValue = userId

                        If CType(Me.bsTrxDetail.Current, DataRowView).Item("ShiftId").ToString = "D" Then
                            frmDetailLog.rdDay.Checked = True
                        Else
                            frmDetailLog.rdNight.Checked = True
                        End If

                        If dgvPartDetail.Rows.Count > 0 Then
                            For Each dr As DataRow In dtTrxPartDetail.Rows
                                If dr("SeqId") = seqId Then
                                    Dim row As DataRow = frmDetailLog.dtTrxPartDetail.NewRow

                                    row("PartTrxDetailId") = DBNull.Value
                                    row("PartTrxId") = dtTrxPartHeader.Rows(0).Item("PartTrxId")
                                    row("SeqId") = seqId
                                    row("CreatedBy") = dr("CreatedBy")
                                    row("CreatedDate") = dr("CreatedDate")
                                    row("UserId") = dr("UserId")
                                    row("PartId") = dr("PartId")
                                    row("Qty") = dr("Qty")
                                    frmDetailLog.dtTrxPartDetail.Rows.Add(row)
                                End If
                            Next
                        End If

                        If frmDetailLog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                            Me.bsTrxDetail.Current("TrxId") = trxId
                            Me.bsTrxDetail.Current("TrxFrom") = frmDetailLog.dtpFrom.Value
                            Me.bsTrxDetail.Current("TrxTo") = frmDetailLog.dtpTo.Value
                            Me.bsTrxDetail.Current("ElapsedTime") = frmDetailLog.txtElapsedTime.Text.Trim
                            Me.bsTrxDetail.Current("UserId") = frmDetailLog.cmbTechnician.SelectedValue
                            Me.bsTrxDetail.Current("ShiftId") = IIf(frmDetailLog.rdDay.Checked = True, "D", "N")
                            Me.bsTrxDetail.Current("ModifiedBy") = frmDetailLog.cmbTechnician.SelectedValue
                            Me.bsTrxDetail.Current("ModifiedDate") = dbMethod.GetServerDate
                            Me.bsTrxDetail.EndEdit()

                            If frmDetailLog.dgvPartDetail.Rows.Count > 0 Then
                                For Each row As DataRowView In Me.bsTrxPartDetail
                                    If row("SeqId") = seqId Then
                                        Me.bsTrxPartDetail.Remove(row)
                                    End If
                                Next

                                For Each dr As DataRow In frmDetailLog.dtTrxPartDetail.Rows
                                    Me.bsTrxPartDetail.AddNew()
                                    Me.bsTrxPartDetail.MoveLast()
                                    Me.bsTrxPartDetail.Current("PartTrxDetailId") = DBNull.Value
                                    Me.bsTrxPartDetail.Current("PartTrxId") = dtTrxPartHeader.Rows(0).Item("PartTrxId")
                                    Me.bsTrxPartDetail.Current("SeqId") = seqId
                                    Me.bsTrxPartDetail.Current("CreatedBy") = dr("CreatedBy")
                                    Me.bsTrxPartDetail.Current("CreatedDate") = dr("CreatedDate")
                                    Me.bsTrxPartDetail.Current("UserId") = frmDetailLog.cmbTechnician.SelectedValue
                                    Me.bsTrxPartDetail.Current("PartId") = dr("PartId")
                                    Me.bsTrxPartDetail.Current("Qty") = dr("Qty")
                                    Me.bsTrxPartDetail.Current("ModifiedBy") = dr("ModifiedBy")
                                    Me.bsTrxPartDetail.Current("ModifiedDate") = dr("ModifiedDate")
                                    Me.bsTrxPartDetail.EndEdit()
                                Next
                            End If
                        Else
                            Me.bsTrxDetail.CancelEdit()
                        End If
                    End Using

                End If

                Me.bsTrxDetail.Sort = "TrxFrom"

                FilterPicTable()
                GetTotalDowntime()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove4M_Click(sender As Object, e As EventArgs) Handles btnRemove4M.Click
        Try
            txt4M.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveChecksheet_Click(sender As Object, e As EventArgs) Handles btnRemoveChecksheet.Click
        Try
            txtChecksheet.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveImage_Click(sender As Object, e As EventArgs) Handles btnRemoveImage.Click
        Try
            If lstImgAttachment.Count > 0 Then lstImgAttachment.RemoveAt(0)

            If Not picImage.Image Is Nothing Then
                picImage.Image.Dispose()
                picImage.Image = Nothing
                txtImageName.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveRow_Enter(sender As Object, e As EventArgs) Handles btnDeleteLog.Enter
        lblActivityLog.ForeColor = Color.White
        lblActivityLog.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub btnRemoveRow_Leave(sender As Object, e As EventArgs) Handles btnDeleteLog.Leave
        lblActivityLog.ForeColor = Color.Black
        lblActivityLog.BackColor = SystemColors.Control
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If btnSave.Enabled = False Then
                Exit Sub
            End If

            If cmbMachineName.SelectedValue = 0 Then
                MessageBox.Show("Please select a machine.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbMachineName.Focus()
                Return
            End If

            If cmbMachinePart.SelectedValue = 0 AndAlso Not machinePartGroupId = 0 Then
                MessageBox.Show("Please select a machine part.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbMachinePart.Focus()
                Return
            End If

            If cmbDowntimeStatus.SelectedValue = 0 Then
                MessageBox.Show("Please select a downtime status.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbDowntimeStatus.Focus()
                Return
            End If

            If cmbDowntimeSubStatus.SelectedValue = 0 Then
                MessageBox.Show("Please select a downtime sub-status.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbDowntimeSubStatus.Focus()
                Return
            End If

            If cmbDowntimeSubStatus.SelectedValue = 3 AndAlso (String.IsNullOrEmpty(txtScheduleMonth.Text) Or String.IsNullOrEmpty(txtScheduleWeek.Text)) Then
                If String.IsNullOrEmpty(txtScheduleMonth.Text) Then
                    MessageBox.Show("Please input the PM month schedule.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtScheduleMonth.Focus()
                    Return
                End If

                If String.IsNullOrEmpty(txtScheduleWeek.Text) Then
                    MessageBox.Show("Please input the PM week schedule.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtScheduleWeek.Focus()
                    Return
                End If
            End If

            Dim rowCount As Integer = dgvDetail.RowCount

            'new transaction
            If trxId = 0 Then
                'transaction header
                Dim prmHeader(42) As SqlParameter
                prmHeader(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                prmHeader(0).Direction = ParameterDirection.Output
                prmHeader(1) = New SqlParameter("@TrxDate", SqlDbType.DateTime2)
                prmHeader(1).Value = dbMethod.GetServerDate
                prmHeader(2) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
                prmHeader(2).Value = cmbTransactionStatus.SelectedValue
                prmHeader(3) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmHeader(3).Value = cmbMachineName.SelectedValue
                prmHeader(4) = New SqlParameter("@DowntimeMachineStatusId", SqlDbType.Int)
                prmHeader(4).Value = cmbDowntimeStatus.SelectedValue
                prmHeader(5) = New SqlParameter("@DowntimeMachineSubStatusId", SqlDbType.Int)
                prmHeader(5).Value = cmbDowntimeSubStatus.SelectedValue
                prmHeader(6) = New SqlParameter("@JigId", SqlDbType.Int)
                prmHeader(6).Value = Nothing
                prmHeader(7) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
                prmHeader(7).Value = Nothing
                prmHeader(8) = New SqlParameter("@DowntimeJigSubStatusId", SqlDbType.Int)
                prmHeader(8).Value = Nothing
                prmHeader(9) = New SqlParameter("@AreaId", SqlDbType.Int)
                prmHeader(9).Value = areaId
                prmHeader(10) = New SqlParameter("@EncodeUserId", SqlDbType.Int)
                prmHeader(10).Value = userId

                If String.IsNullOrEmpty(txtRuntimeAccumulated.Text.Trim) Then
                    prmHeader(11) = New SqlParameter("@TotalAccumulatedRuntime", SqlDbType.Int)
                    prmHeader(11).Value = Nothing
                Else
                    prmHeader(11) = New SqlParameter("@TotalAccumulatedRuntime", SqlDbType.Int)
                    prmHeader(11).Value = txtRuntimeAccumulated.Text.Trim
                End If

                If String.IsNullOrEmpty(txtJoNumber.Text.Trim) Then
                    prmHeader(12) = New SqlParameter("@JoNumber", SqlDbType.NChar)
                    prmHeader(12).Value = Nothing
                Else
                    prmHeader(12) = New SqlParameter("@JoNumber", SqlDbType.NChar)
                    prmHeader(12).Value = txtJoNumber.Text.Trim
                End If

                If String.IsNullOrEmpty(txtJoRequestor.Text.Trim) Then
                    prmHeader(13) = New SqlParameter("@JoRequestor", SqlDbType.NVarChar)
                    prmHeader(13).Value = Nothing
                Else
                    prmHeader(13) = New SqlParameter("@JoRequestor", SqlDbType.NVarChar)
                    prmHeader(13).Value = txtJoRequestor.Text.Trim
                End If

                If cmbTransactionStatus.SelectedValue = 1 Then 'transaction status - done
                    If dgvDetail.Rows.Count = 0 Then
                        MessageBox.Show("Please input the activity logs.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        btnAddLog.Focus()
                        Return
                    End If

                    'approvers
                    prmHeader(14) = New SqlParameter("@ApproverIsApproved1", SqlDbType.Bit)
                    prmHeader(14).Value = 0
                    prmHeader(15) = New SqlParameter("@ApproverId1", SqlDbType.Int)
                    prmHeader(15).Value = IIf(cmbApp1Name.SelectedValue = 0, Nothing, cmbApp1Name.SelectedValue)
                    prmHeader(16) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                    prmHeader(16).Value = Nothing
                    prmHeader(17) = New SqlParameter("@ApproverRemarks1", SqlDbType.NVarChar)
                    prmHeader(17).Value = Nothing

                    prmHeader(18) = New SqlParameter("@ApproverIsApproved2", SqlDbType.Bit)
                    prmHeader(18).Value = 0
                    prmHeader(19) = New SqlParameter("@ApproverId2", SqlDbType.Int)
                    prmHeader(19).Value = IIf(cmbApp2Name.SelectedValue = 0, Nothing, cmbApp2Name.SelectedValue)
                    prmHeader(20) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                    prmHeader(20).Value = Nothing
                    prmHeader(21) = New SqlParameter("@ApproverRemarks2", SqlDbType.NVarChar)
                    prmHeader(21).Value = Nothing

                    prmHeader(22) = New SqlParameter("@ApproverIsApproved3", SqlDbType.Bit)
                    prmHeader(22).Value = 0

                    If cmbApp3Name.SelectedValue = 0 Then
                        MessageBox.Show("Please select one from approver 3.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    Else
                        prmHeader(23) = New SqlParameter("@ApproverId3", SqlDbType.Int)
                        prmHeader(23).Value = cmbApp3Name.SelectedValue
                    End If

                    If isAdmin Or accessLevelId = 1 Then
                        prmHeader(24) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                        prmHeader(24).Value = dbMethod.GetServerDate
                    Else
                        prmHeader(24) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                        prmHeader(24).Value = Nothing
                    End If

                    prmHeader(25) = New SqlParameter("@ApproverRemarks3", SqlDbType.NVarChar)
                    prmHeader(25).Value = Nothing

                    prmHeader(26) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                    prmHeader(26).Value = Nothing
                    prmHeader(27) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime2)
                    prmHeader(27).Value = Nothing
                    prmHeader(28) = New SqlParameter("@FileName", SqlDbType.NVarChar)
                    prmHeader(28).Value = Nothing
                    prmHeader(29) = New SqlParameter("@FileAttachment", SqlDbType.VarBinary)
                    prmHeader(29).Value = Nothing

                    prmHeader(30) = New SqlParameter("@DatetimeStarted", SqlDbType.DateTime2)
                    prmHeader(30).Value = dgvDetail.Rows(0).Cells("ColTrxFrom").Value
                    prmHeader(31) = New SqlParameter("@DatetimeEnded", SqlDbType.DateTime2)
                    prmHeader(31).Value = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                    prmHeader(32) = New SqlParameter("@UserId", SqlDbType.Int)
                    prmHeader(32).Value = dgvDetail.Rows(rowCount - 1).Cells("ColUserIdLog").Value
                    prmHeader(33) = New SqlParameter("@ShiftId", SqlDbType.Char)
                    prmHeader(33).Value = dgvDetail.Rows(rowCount - 1).Cells("ColShiftId").Value
                    prmHeader(34) = New SqlParameter("@TotalAccumulatedDowntime", SqlDbType.Int)
                    prmHeader(34).Value = txtDowntimeAccumulated.Text.Trim

                    'routing status
                    If cmbApp1Name.SelectedValue = 0 Then
                        If cmbApp2Name.SelectedValue = 0 Then
                            If isAdmin Or accessLevelId = 1 Then
                                prmHeader(35) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                prmHeader(35).Value = 1
                            Else
                                prmHeader(35) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                prmHeader(35).Value = 2
                            End If
                        Else
                            prmHeader(35) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                            prmHeader(35).Value = 3
                        End If
                    Else
                        prmHeader(35) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                        prmHeader(35).Value = 4
                    End If

                    If cmbDowntimeStatus.SelectedValue = 2 Then 'scheduled
                        If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                            prmHeader(36) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                            prmHeader(36).Value = Nothing
                        Else
                            prmHeader(36) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                            prmHeader(36).Value = txtProblem.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                            prmHeader(37) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                            prmHeader(37).Value = Nothing
                        Else
                            prmHeader(37) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                            prmHeader(37).Value = txtRootCause.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                            prmHeader(38) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                            prmHeader(38).Value = Nothing
                        Else
                            prmHeader(38) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                            prmHeader(38).Value = txtActionTaken.Text.Trim
                        End If

                        If picImage.Image Is Nothing Then
                            prmHeader(39) = New SqlParameter("@Image", SqlDbType.Image)
                            prmHeader(39).Value = Nothing
                            prmHeader(40) = New SqlParameter("@ImageName", SqlDbType.NVarChar)
                            prmHeader(40).Value = Nothing
                        Else
                            Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                            resImg.Save(mStream, ImageFormat.Jpeg)
                            bite = mStream.GetBuffer
                            prmHeader(39) = New SqlParameter("@Image", SqlDbType.Image)
                            prmHeader(39).Value = bite
                            prmHeader(40) = New SqlParameter("@ImageName", SqlDbType.NVarChar)
                            prmHeader(40).Value = txtImageName.Text.ToString.Trim
                        End If

                        If cmbDowntimeSubStatus.SelectedValue = 3 Then 'pm
                            If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                                MessageBox.Show("Please input the link of Check Sheet.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtChecksheet.Focus()
                                Return
                            Else
                                prmHeader(41) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                                prmHeader(41).Value = txtChecksheet.Text.Trim
                            End If

                            If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                                MessageBox.Show("Please input the link of 4M Change.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txt4M.Focus()
                                Return
                            Else
                                prmHeader(42) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                                prmHeader(42).Value = txt4M.Text.Trim
                            End If
                        Else 'scheduled but not pm
                            If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                                prmHeader(41) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                                prmHeader(41).Value = Nothing
                            Else
                                prmHeader(41) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                                prmHeader(41).Value = txtChecksheet.Text.Trim
                            End If

                            If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                                prmHeader(42) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                                prmHeader(42).Value = Nothing
                            Else
                                prmHeader(42) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                                prmHeader(42).Value = txt4M.Text.Trim
                            End If
                        End If

                    ElseIf cmbDowntimeStatus.SelectedValue = 3 Then 'unscheduled
                        If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                            MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtProblem.Focus()
                            Return
                        Else
                            prmHeader(36) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                            prmHeader(36).Value = txtProblem.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                            MessageBox.Show("Please indicate the root cause.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtRootCause.Focus()
                            Return
                        Else
                            prmHeader(37) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                            prmHeader(37).Value = txtRootCause.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                            MessageBox.Show("Please indicate the action taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtActionTaken.Focus()
                            Return
                        Else
                            prmHeader(38) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                            prmHeader(38).Value = txtActionTaken.Text.Trim
                        End If

                        If picImage.Image Is Nothing Then
                            MessageBox.Show("Please attach the image for this activity.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            btnBrowseImage.Focus()
                            Return
                        End If

                        Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                        resImg.Save(mStream, ImageFormat.Jpeg)
                        bite = mStream.GetBuffer
                        prmHeader(39) = New SqlParameter("@Image", SqlDbType.Image)
                        prmHeader(39).Value = bite
                        prmHeader(40) = New SqlParameter("@ImageName", SqlDbType.NVarChar)
                        prmHeader(40).Value = txtImageName.Text.ToString.Trim

                        If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                            prmHeader(41) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                            prmHeader(41).Value = Nothing
                        Else
                            prmHeader(41) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                            prmHeader(41).Value = txtChecksheet.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                            prmHeader(42) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                            prmHeader(42).Value = Nothing
                        Else
                            prmHeader(42) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                            prmHeader(42).Value = txt4M.Text.Trim
                        End If
                    End If
                Else 'transaction status - on-going
                    'approvers
                    prmHeader(14) = New SqlParameter("@ApproverIsApproved1", SqlDbType.Bit)
                    prmHeader(14).Value = 0
                    prmHeader(15) = New SqlParameter("@ApproverId1", SqlDbType.Int)
                    prmHeader(15).Value = IIf(cmbApp1Name.SelectedValue = 0, Nothing, cmbApp1Name.SelectedValue)
                    prmHeader(16) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                    prmHeader(16).Value = Nothing
                    prmHeader(17) = New SqlParameter("@ApproverRemarks1", SqlDbType.NVarChar)
                    prmHeader(17).Value = Nothing

                    prmHeader(18) = New SqlParameter("@ApproverIsApproved2", SqlDbType.Bit)
                    prmHeader(18).Value = 0
                    prmHeader(19) = New SqlParameter("@ApproverId2", SqlDbType.Int)
                    prmHeader(19).Value = IIf(cmbApp2Name.SelectedValue = 0, Nothing, cmbApp2Name.SelectedValue)
                    prmHeader(20) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                    prmHeader(20).Value = Nothing
                    prmHeader(21) = New SqlParameter("@ApproverRemarks2", SqlDbType.NVarChar)
                    prmHeader(21).Value = Nothing

                    prmHeader(22) = New SqlParameter("@ApproverIsApproved3", SqlDbType.Bit)
                    prmHeader(22).Value = 0

                    If cmbApp3Name.SelectedValue = 3 Then
                        MessageBox.Show("Please select one for approver 3.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        cmbApp3Name.Focus()
                        Return
                    Else
                        prmHeader(23) = New SqlParameter("@ApproverId3", SqlDbType.Int)
                        prmHeader(23).Value = cmbApp3Name.SelectedValue
                    End If

                    prmHeader(24) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                    prmHeader(24).Value = Nothing
                    prmHeader(25) = New SqlParameter("@ApproverRemarks3", SqlDbType.NVarChar)
                    prmHeader(25).Value = Nothing

                    prmHeader(26) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                    prmHeader(26).Value = Nothing
                    prmHeader(27) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime2)
                    prmHeader(27).Value = Nothing
                    prmHeader(28) = New SqlParameter("@FileName", SqlDbType.NVarChar)
                    prmHeader(28).Value = Nothing
                    prmHeader(29) = New SqlParameter("@FileAttachment", SqlDbType.VarBinary)
                    prmHeader(29).Value = Nothing

                    If dgvDetail.Rows.Count > 0 Then
                        prmHeader(30) = New SqlParameter("@DatetimeStarted", SqlDbType.DateTime2)
                        prmHeader(30).Value = dgvDetail.Rows(0).Cells("ColTrxFrom").Value
                        prmHeader(31) = New SqlParameter("@DatetimeEnded", SqlDbType.DateTime2)
                        prmHeader(31).Value = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                        prmHeader(32) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmHeader(32).Value = dgvDetail.Rows(rowCount - 1).Cells("ColUserIdLog").Value
                        prmHeader(33) = New SqlParameter("@ShiftId", SqlDbType.Char)
                        prmHeader(33).Value = dgvDetail.Rows(rowCount - 1).Cells("ColShiftId").Value
                        prmHeader(34) = New SqlParameter("@TotalAccumulatedDowntime", SqlDbType.Int)
                        prmHeader(34).Value = txtDowntimeAccumulated.Text.Trim
                    Else 'no activity log yet - use current datetime as datetimestarted, logged in user as trx owner
                        prmHeader(30) = New SqlParameter("@DatetimeStarted", SqlDbType.DateTime2)
                        prmHeader(30).Value = dbMethod.GetServerDate
                        prmHeader(31) = New SqlParameter("@DatetimeEnded", SqlDbType.DateTime2)
                        prmHeader(31).Value = Nothing
                        prmHeader(32) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmHeader(32).Value = userId

                        If DateTime.Now.Hour >= 7 And DateTime.Now.Hour <= 19 Then
                            prmHeader(33) = New SqlParameter("@ShiftId", SqlDbType.Char)
                            prmHeader(33).Value = "D"
                        Else
                            prmHeader(33) = New SqlParameter("@ShiftId", SqlDbType.Char)
                            prmHeader(33).Value = "N"
                        End If

                        prmHeader(34) = New SqlParameter("@TotalAccumulatedDowntime", SqlDbType.Int)
                        prmHeader(34).Value = Nothing
                    End If

                    'routing status
                    prmHeader(35) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmHeader(35).Value = 5

                    If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                        prmHeader(36) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                        prmHeader(36).Value = Nothing
                    Else
                        prmHeader(36) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                        prmHeader(36).Value = txtProblem.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                        prmHeader(37) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                        prmHeader(37).Value = Nothing
                    Else
                        prmHeader(37) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                        prmHeader(37).Value = txtRootCause.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                        prmHeader(38) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                        prmHeader(38).Value = Nothing
                    Else
                        prmHeader(38) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                        prmHeader(38).Value = txtActionTaken.Text.Trim
                    End If

                    If picImage.Image Is Nothing Then
                        prmHeader(39) = New SqlParameter("@Image", SqlDbType.Image)
                        prmHeader(39).Value = Nothing
                        prmHeader(40) = New SqlParameter("@ImageName", SqlDbType.NVarChar)
                        prmHeader(40).Value = Nothing
                    Else
                        Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                        resImg.Save(mStream, ImageFormat.Jpeg)
                        bite = mStream.GetBuffer
                        prmHeader(39) = New SqlParameter("@Image", SqlDbType.Image)
                        prmHeader(39).Value = bite
                        prmHeader(40) = New SqlParameter("@ImageName", SqlDbType.NVarChar)
                        prmHeader(40).Value = txtImageName.Text.ToString.Trim
                    End If

                    If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                        prmHeader(41) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                        prmHeader(41).Value = Nothing
                    Else
                        prmHeader(41) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                        prmHeader(41).Value = txtChecksheet.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                        prmHeader(42) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                        prmHeader(42).Value = Nothing
                    Else
                        prmHeader(42) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                        prmHeader(42).Value = txt4M.Text.Trim
                    End If

                    'set machine status to downtime
                    Dim prmMchStatus(2) As SqlParameter
                    prmMchStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmMchStatus(0).Value = cmbMachineName.SelectedValue
                    prmMchStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                    prmMchStatus(1).Value = cmbDowntimeStatus.SelectedValue
                    prmMchStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                    prmMchStatus(2).Value = cmbDowntimeSubStatus.SelectedValue

                    dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMchStatus)
                End If

                dbMethod.ExecuteNonQuery("InsMntTransactionHeader", CommandType.StoredProcedure, prmHeader)

                'fill the pm schedule slot
                'should be place here, before the update of dtTrxDetail so dgvDetail still have the data
                If scheduleId > 0 AndAlso cmbDowntimeSubStatus.SelectedValue = 3 Then
                    Dim prmMchSchd(5) As SqlParameter
                    prmMchSchd(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmMchSchd(0).Value = prmHeader(0).Value

                    prmMchSchd(1) = New SqlParameter("@IsDone", SqlDbType.Bit)
                    If cmbTransactionStatus.SelectedValue = 1 Then prmMchSchd(1).Value = True Else prmMchSchd(1).Value = False

                    prmMchSchd(2) = New SqlParameter("@IsChecklistCompleted", SqlDbType.Bit)
                    prmMchSchd(2).Value = False

                    prmMchSchd(3) = New SqlParameter("@ActivityBy", SqlDbType.Int)
                    If dgvDetail.Rows.Count > 0 Then
                        prmMchSchd(3).Value = dgvDetail.Rows(rowCount - 1).Cells("ColUserIdLog").Value
                    Else
                        prmMchSchd(3).Value = userId
                    End If

                    prmMchSchd(4) = New SqlParameter("@ActivityDate", SqlDbType.DateTime2)
                    If dgvDetail.Rows.Count > 0 Then
                        prmMchSchd(4).Value = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                    Else
                        prmMchSchd(4).Value = dbMethod.GetServerDate
                    End If

                    prmMchSchd(5) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                    prmMchSchd(5).Value = scheduleId

                    dbMethod.ExecuteNonQuery("UpdMntMachineSchedule", CommandType.StoredProcedure, prmMchSchd)
                End If

                'transaction details
                If dgvDetail.Rows.Count > 0 Then
                    For Each dataRowView As DataRowView In Me.bsTrxDetail
                        Dim row = dataRowView.Row
                        row.Item("TrxId") = prmHeader(0).Value
                    Next
                    adpTrxDetail.Update(dtTrxDetail)

                    'insert to transaction user
                    For Each row As DataGridViewRow In dgvDetail.Rows
                        Dim prmUserCnt(1) As SqlParameter
                        prmUserCnt(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmUserCnt(0).Value = prmHeader(0).Value
                        prmUserCnt(1) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmUserCnt(1).Value = row.Cells("ColUserIdLog").Value

                        If dbMethod.ExecuteScalar("CntMntTransactionUser", CommandType.StoredProcedure, prmUserCnt) = 0 Then
                            Dim prmUserIns(1) As SqlParameter
                            prmUserIns(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                            prmUserIns(0).Value = prmHeader(0).Value
                            prmUserIns(1) = New SqlParameter("@UserId", SqlDbType.Int)
                            prmUserIns(1).Value = row.Cells("ColUserIdLog").Value
                            dbMethod.ExecuteNonQuery("InsMntTransactionUser", CommandType.StoredProcedure, prmUserIns)
                        End If
                    Next
                End If

                'transaction spare part
                If dgvPartDetail.Rows.Count > 0 Then
                    Dim prmPrHeader(7) As SqlParameter
                    prmPrHeader(0) = New SqlParameter("@PartTrxId", SqlDbType.Int)
                    prmPrHeader(0).Direction = ParameterDirection.Output
                    prmPrHeader(1) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                    prmPrHeader(1).Value = dgvDetail.Rows(0).Cells("ColUserIdLog").Value
                    prmPrHeader(2) = New SqlParameter("@CreatedDate", SqlDbType.DateTime)
                    prmPrHeader(2).Value = dbMethod.GetServerDate
                    prmPrHeader(3) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmPrHeader(3).Value = prmHeader(0).Value
                    prmPrHeader(4) = New SqlParameter("@TransactionTypeId", SqlDbType.Int)
                    prmPrHeader(4).Value = 2
                    prmPrHeader(5) = New SqlParameter("@ReferenceNo", SqlDbType.Char)
                    prmPrHeader(5).Value = Nothing
                    prmPrHeader(6) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                    prmPrHeader(6).Value = Nothing
                    prmPrHeader(7) = New SqlParameter("@TrxDate", SqlDbType.Date)
                    prmPrHeader(7).Value = CDate(dbMethod.GetServerDate).Date
                    dbMethod.ExecuteNonQuery("InsMntTransactionPartHeader", CommandType.StoredProcedure, prmPrHeader)

                    Dim partIssRowCount As Integer = 0
                    For Each dataRowView As DataRowView In Me.bsTrxPartDetail
                        partIssRowCount = partIssRowCount + 1

                        Dim row = dataRowView.Row
                        row.Item("PartTrxId") = prmPrHeader(0).Value
                        row.Item("SeqId") = partIssRowCount
                    Next
                    Me.bsTrxPartDetail.EndEdit()
                    adpTrxPartDetail.Update(dtTrxPartDetail)

                    For Each row As DataGridViewRow In dgvPartDetail.Rows
                        Dim prmIss(1) As SqlParameter
                        prmIss(0) = New SqlParameter("@PartId", SqlDbType.Int)
                        prmIss(0).Value = row.Cells("ColPartId").Value
                        prmIss(1) = New SqlParameter("@Qty", SqlDbType.Int)
                        prmIss(1).Value = row.Cells("ColQty").Value
                        dbMethod.ExecuteNonQuery("UpdMntSparePartIss", CommandType.StoredProcedure, prmIss)
                    Next
                End If

                'transaction machine part
                Dim prmMchPart(1) As SqlParameter
                prmMchPart(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                prmMchPart(0).Value = prmHeader(0).Value

                If cmbMachinePart.SelectedValue = 0 AndAlso cmbMachinePart.Enabled Then
                    prmMchPart(1) = New SqlParameter("@MachinePartId", SqlDbType.Int)
                    prmMchPart(1).Value = Nothing
                Else
                    prmMchPart(1) = New SqlParameter("@MachinePartId", SqlDbType.Int)
                    prmMchPart(1).Value = cmbMachinePart.SelectedValue
                End If
                dbMethod.ExecuteNonQuery("InsMntTransactionMachinePart", CommandType.StoredProcedure, prmMchPart)

                'transaction user
                For Each row As DataGridViewRow In dgvPic.Rows
                    Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("ColIsSelected").Value)
                    If isSelected Then
                        Dim prmUser(1) As SqlParameter
                        prmUser(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmUser(0).Value = prmHeader(0).Value
                        prmUser(1) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmUser(1).Value = row.Cells("ColUserId").Value
                        dbMethod.ExecuteNonQuery("InsMntTransactionUser", CommandType.StoredProcedure, prmUser)
                    End If
                Next

                'existing transaction
            Else
                'transaction header
                Dim prmHeader(40) As SqlParameter
                prmHeader(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                prmHeader(0).Value = trxId
                prmHeader(1) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmHeader(1).Value = cmbMachineName.SelectedValue
                prmHeader(2) = New SqlParameter("@DowntimeMachineStatusId", SqlDbType.Int)
                prmHeader(2).Value = cmbDowntimeStatus.SelectedValue
                prmHeader(3) = New SqlParameter("@DowntimeMachineSubStatusId", SqlDbType.Int)
                prmHeader(3).Value = cmbDowntimeSubStatus.SelectedValue
                prmHeader(4) = New SqlParameter("@JigId", SqlDbType.Int)
                prmHeader(4).Value = Nothing
                prmHeader(5) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
                prmHeader(5).Value = Nothing
                prmHeader(6) = New SqlParameter("@DowntimeJigSubStatusId", SqlDbType.Int)
                prmHeader(6).Value = Nothing
                prmHeader(7) = New SqlParameter("@AreaId", SqlDbType.Int)
                prmHeader(7).Value = areaId

                If String.IsNullOrEmpty(txtRuntimeAccumulated.Text.Trim) Then
                    prmHeader(8) = New SqlParameter("@TotalAccumulatedRuntime", SqlDbType.Int)
                    prmHeader(8).Value = Nothing
                Else
                    prmHeader(8) = New SqlParameter("@TotalAccumulatedRuntime", SqlDbType.Int)
                    prmHeader(8).Value = txtRuntimeAccumulated.Text.Trim
                End If

                If String.IsNullOrEmpty(txtJoNumber.Text.Trim) Then
                    prmHeader(9) = New SqlParameter("@JoNumber", SqlDbType.NChar)
                    prmHeader(9).Value = Nothing
                Else
                    prmHeader(9) = New SqlParameter("@JoNumber", SqlDbType.NChar)
                    prmHeader(9).Value = txtJoNumber.Text.Trim
                End If

                If String.IsNullOrEmpty(txtJoRequestor.Text.Trim) Then
                    prmHeader(10) = New SqlParameter("@JoRequestor", SqlDbType.NVarChar)
                    prmHeader(10).Value = Nothing
                Else
                    prmHeader(10) = New SqlParameter("@JoRequestor", SqlDbType.NVarChar)
                    prmHeader(10).Value = txtJoRequestor.Text.Trim
                End If

                If cmbTransactionStatus.SelectedValue = 1 Then 'transaction status - done
                    If dgvDetail.Rows.Count = 0 Then
                        MessageBox.Show("Please input activity logs.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        btnAddLog.Focus()
                        Return
                    End If

                    'approvers
                    If isAdmin Or accessLevelId = 1 Then
                        If cmbApp1Name.SelectedValue = 0 Then
                            prmHeader(11) = New SqlParameter("@ApproverIsApproved1", SqlDbType.Bit)
                            prmHeader(11).Value = 0
                            prmHeader(12) = New SqlParameter("@ApproverId1", SqlDbType.Int)
                            prmHeader(12).Value = Nothing
                            prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                            prmHeader(13).Value = Nothing
                            prmHeader(14) = New SqlParameter("@ApproverRemarks1", SqlDbType.NVarChar)
                            prmHeader(14).Value = Nothing
                        Else
                            prmHeader(11) = New SqlParameter("@ApproverIsApproved1", SqlDbType.Bit)
                            prmHeader(11).Value = IIf(cmbApp1Status.SelectedValue = 1, 1, 0)
                            prmHeader(12) = New SqlParameter("@ApproverId1", SqlDbType.Int)
                            prmHeader(12).Value = cmbApp1Name.SelectedValue

                            If cmbApp1Status.SelectedValue = 0 Then
                                prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                prmHeader(13).Value = Nothing
                            Else
                                If cmbApp1Status.SelectedValue = orgApp1Status Then
                                    If String.IsNullOrWhiteSpace(txtApp1Date.Text.Trim) Then
                                        prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                        prmHeader(13).Value = Nothing
                                    Else
                                        prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                        prmHeader(13).Value = Convert.ToDateTime(txtApp1Date.Text.Trim)
                                    End If
                                Else
                                    prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                    prmHeader(13).Value = dbMethod.GetServerDate
                                End If
                            End If

                            prmHeader(14) = New SqlParameter("@ApproverRemarks1", SqlDbType.NVarChar)
                            prmHeader(14).Value = IIf(String.IsNullOrEmpty(txtApp1Remarks.Text.Trim), Nothing, txtApp1Remarks.Text.Trim)
                        End If

                        If cmbApp2Name.SelectedValue = 0 Then
                            prmHeader(15) = New SqlParameter("@ApproverIsApproved2", SqlDbType.Bit)
                            prmHeader(15).Value = 0
                            prmHeader(16) = New SqlParameter("@ApproverId2", SqlDbType.Int)
                            prmHeader(16).Value = Nothing
                            prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                            prmHeader(17).Value = Nothing
                            prmHeader(18) = New SqlParameter("@ApproverRemarks2", SqlDbType.NVarChar)
                            prmHeader(18).Value = Nothing
                        Else
                            prmHeader(15) = New SqlParameter("@ApproverIsApproved2", SqlDbType.Bit)
                            prmHeader(15).Value = IIf(cmbApp2Status.SelectedValue = 1, 1, 0)
                            prmHeader(16) = New SqlParameter("@ApproverId2", SqlDbType.Int)
                            prmHeader(16).Value = IIf(cmbApp2Name.SelectedValue = 0, Nothing, cmbApp2Name.SelectedValue)

                            If cmbApp2Status.SelectedValue = 0 Then
                                prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                prmHeader(17).Value = Nothing
                            Else
                                If cmbApp2Status.SelectedValue = orgApp2Status Then
                                    If String.IsNullOrWhiteSpace(txtApp2Date.Text.Trim) Then
                                        prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                        prmHeader(17).Value = Nothing
                                    Else
                                        prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                        prmHeader(17).Value = Convert.ToDateTime(txtApp2Date.Text.Trim)
                                    End If
                                Else
                                    prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                    prmHeader(17).Value = dbMethod.GetServerDate
                                End If
                            End If

                            prmHeader(18) = New SqlParameter("@ApproverRemarks2", SqlDbType.NVarChar)
                            prmHeader(18).Value = IIf(String.IsNullOrEmpty(txtApp2Remarks.Text.Trim), Nothing, txtApp2Remarks.Text.Trim)
                        End If

                        prmHeader(19) = New SqlParameter("@ApproverIsApproved3", SqlDbType.Bit)
                        prmHeader(19).Value = IIf(cmbApp3Status.SelectedValue = 1, 1, 0)
                        prmHeader(20) = New SqlParameter("@ApproverId3", SqlDbType.Int)
                        prmHeader(20).Value = cmbApp3Name.SelectedValue

                        If cmbApp3Status.SelectedValue = 0 Then
                            prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                            prmHeader(21).Value = Nothing
                        Else
                            If cmbApp3Status.SelectedValue = orgApp3Status Then
                                If String.IsNullOrWhiteSpace(txtApp3Date.Text.Trim) Then
                                    prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                    prmHeader(21).Value = Nothing
                                Else
                                    prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                    prmHeader(21).Value = Convert.ToDateTime(txtApp3Date.Text.Trim)
                                End If
                            Else
                                prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                prmHeader(21).Value = dbMethod.GetServerDate
                            End If
                        End If

                        prmHeader(22) = New SqlParameter("@ApproverRemarks3", SqlDbType.NVarChar)
                        prmHeader(22).Value = IIf(String.IsNullOrEmpty(txtApp3Remarks.Text.Trim), Nothing, txtApp3Remarks.Text.Trim)
                    Else 'other access level
                        Select Case accessLevelId
                            Case 2 'mngr, asm
                                If cmbApp1Name.SelectedValue = 0 Then
                                    prmHeader(11) = New SqlParameter("@ApproverIsApproved1", SqlDbType.Bit)
                                    prmHeader(11).Value = 0
                                    prmHeader(12) = New SqlParameter("@ApproverId1", SqlDbType.Int)
                                    prmHeader(12).Value = Nothing
                                    prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                    prmHeader(13).Value = Nothing
                                    prmHeader(14) = New SqlParameter("@ApproverRemarks1", SqlDbType.NVarChar)
                                    prmHeader(14).Value = Nothing
                                Else
                                    prmHeader(11) = New SqlParameter("@ApproverIsApproved1", SqlDbType.Bit)
                                    prmHeader(11).Value = IIf(cmbApp1Status.SelectedValue = 1, 1, 0)
                                    prmHeader(12) = New SqlParameter("@ApproverId1", SqlDbType.Int)
                                    prmHeader(12).Value = cmbApp1Name.SelectedValue

                                    If cmbApp1Status.SelectedValue = 0 Then
                                        prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                        prmHeader(13).Value = Nothing
                                    Else
                                        If cmbApp1Status.SelectedValue = orgApp1Status Then
                                            If String.IsNullOrWhiteSpace(txtApp1Date.Text.Trim) Then
                                                prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                                prmHeader(13).Value = Nothing
                                            Else
                                                prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                                prmHeader(13).Value = Convert.ToDateTime(txtApp1Date.Text.Trim)
                                            End If
                                        Else
                                            prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                            prmHeader(13).Value = dbMethod.GetServerDate
                                        End If
                                    End If

                                    prmHeader(14) = New SqlParameter("@ApproverRemarks1", SqlDbType.NVarChar)
                                    prmHeader(14).Value = IIf(String.IsNullOrEmpty(txtApp1Remarks.Text.Trim), Nothing, txtApp1Remarks.Text.Trim)
                                End If

                                prmHeader(15) = New SqlParameter("@ApproverIsApproved2", SqlDbType.Bit)
                                prmHeader(15).Value = IIf(cmbApp2Status.SelectedValue = 1, 1, 0)
                                prmHeader(16) = New SqlParameter("@ApproverId2", SqlDbType.Int)
                                prmHeader(16).Value = IIf(cmbApp2Name.SelectedValue = 0, Nothing, cmbApp2Name.SelectedValue)

                                If cmbApp2Status.SelectedValue = 0 Then
                                    prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                    prmHeader(17).Value = Nothing
                                Else
                                    If cmbApp2Status.SelectedValue = orgApp2Status Then
                                        If String.IsNullOrWhiteSpace(txtApp2Date.Text.Trim) Then
                                            prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                            prmHeader(17).Value = Nothing
                                        Else
                                            prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                            prmHeader(17).Value = Convert.ToDateTime(txtApp2Date.Text.Trim)
                                        End If
                                    Else
                                        prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                        prmHeader(17).Value = dbMethod.GetServerDate
                                    End If
                                End If

                                prmHeader(18) = New SqlParameter("@ApproverRemarks2", SqlDbType.NVarChar)
                                prmHeader(18).Value = IIf(String.IsNullOrEmpty(txtApp2Remarks.Text.Trim), Nothing, txtApp2Remarks.Text.Trim)

                                prmHeader(19) = New SqlParameter("@ApproverIsApproved3", SqlDbType.Bit)
                                prmHeader(19).Value = IIf(cmbApp3Status.SelectedValue = 1, 1, 0)
                                prmHeader(20) = New SqlParameter("@ApproverId3", SqlDbType.Int)
                                prmHeader(20).Value = cmbApp3Name.SelectedValue

                                If cmbApp3Status.SelectedValue = 0 Then
                                    prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                    prmHeader(21).Value = Nothing
                                Else
                                    If cmbApp3Status.SelectedValue = orgApp3Status Then
                                        If String.IsNullOrWhiteSpace(txtApp3Date.Text.Trim) Then
                                            prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                            prmHeader(21).Value = Nothing
                                        Else
                                            prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                            prmHeader(21).Value = Convert.ToDateTime(txtApp3Date.Text.Trim)
                                        End If
                                    Else
                                        prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                        prmHeader(21).Value = dbMethod.GetServerDate
                                    End If
                                End If

                                prmHeader(22) = New SqlParameter("@ApproverRemarks3", SqlDbType.NVarChar)
                                prmHeader(22).Value = If(String.IsNullOrEmpty(txtApp3Remarks.Text.Trim), Nothing, txtApp3Remarks.Text.Trim)

                            Case 3 'sv, asv
                                prmHeader(11) = New SqlParameter("@ApproverIsApproved1", SqlDbType.Bit)
                                prmHeader(11).Value = IIf(cmbApp1Status.SelectedValue = 1, 1, 0)
                                prmHeader(12) = New SqlParameter("@ApproverId1", SqlDbType.Int)
                                prmHeader(12).Value = IIf(cmbApp1Name.SelectedValue = 0, Nothing, cmbApp1Name.SelectedValue)

                                If cmbApp1Status.SelectedValue = 0 Then 'no action selected
                                    prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                    prmHeader(13).Value = Nothing
                                Else
                                    If cmbApp1Status.SelectedValue = orgApp1Status Then 'did not change action
                                        If String.IsNullOrWhiteSpace(txtApp1Date.Text.Trim) Then
                                            prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                            prmHeader(13).Value = Nothing
                                        Else
                                            prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                            prmHeader(13).Value = Convert.ToDateTime(txtApp1Date.Text.Trim)
                                        End If
                                    Else 'change an action
                                        prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                        prmHeader(13).Value = dbMethod.GetServerDate
                                    End If
                                End If

                                prmHeader(14) = New SqlParameter("@ApproverRemarks1", SqlDbType.NVarChar)
                                prmHeader(14).Value = IIf(String.IsNullOrEmpty(txtApp1Remarks.Text.Trim), Nothing, txtApp1Remarks.Text.Trim)

                                If cmbApp2Name.SelectedValue = 0 Then
                                    prmHeader(15) = New SqlParameter("@ApproverIsApproved2", SqlDbType.Bit)
                                    prmHeader(15).Value = 0
                                    prmHeader(16) = New SqlParameter("@ApproverId2", SqlDbType.Int)
                                    prmHeader(16).Value = Nothing
                                    prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                    prmHeader(17).Value = Nothing
                                    prmHeader(18) = New SqlParameter("@ApproverRemarks2", SqlDbType.NVarChar)
                                    prmHeader(18).Value = Nothing
                                Else
                                    prmHeader(15) = New SqlParameter("@ApproverIsApproved2", SqlDbType.Bit)
                                    prmHeader(15).Value = IIf(cmbApp2Status.SelectedValue = 1, 1, 0)
                                    prmHeader(16) = New SqlParameter("@ApproverId2", SqlDbType.Int)
                                    prmHeader(16).Value = IIf(cmbApp2Name.SelectedValue = 0, Nothing, cmbApp2Name.SelectedValue)

                                    If cmbApp2Status.SelectedValue = 0 Then 'no action selected
                                        prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                        prmHeader(17).Value = Nothing
                                    Else
                                        If cmbApp2Status.SelectedValue = orgApp2Status Then 'did not change action
                                            If String.IsNullOrWhiteSpace(txtApp2Date.Text.Trim) Then
                                                prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                                prmHeader(17).Value = Nothing
                                            Else
                                                prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                                prmHeader(17).Value = Convert.ToDateTime(txtApp2Date.Text.Trim)
                                            End If
                                        Else 'change an action
                                            prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                            prmHeader(17).Value = dbMethod.GetServerDate
                                        End If
                                    End If

                                    prmHeader(18) = New SqlParameter("@ApproverRemarks2", SqlDbType.NVarChar)
                                    prmHeader(18).Value = IIf(String.IsNullOrEmpty(txtApp2Remarks.Text.Trim), Nothing, txtApp2Remarks.Text.Trim)
                                End If

                                prmHeader(19) = New SqlParameter("@ApproverIsApproved3", SqlDbType.Bit)
                                prmHeader(19).Value = IIf(cmbApp3Status.SelectedValue = 1, 1, 0)
                                prmHeader(20) = New SqlParameter("@ApproverId3", SqlDbType.Int)
                                prmHeader(20).Value = cmbApp3Name.SelectedValue

                                If cmbApp3Status.SelectedValue = 0 Then 'no action selected
                                    prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                    prmHeader(21).Value = Nothing
                                Else
                                    If cmbApp3Status.SelectedValue = orgApp3Status Then 'did not change action
                                        If String.IsNullOrWhiteSpace(txtApp3Date.Text.Trim) Then
                                            prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                            prmHeader(21).Value = Nothing
                                        Else
                                            prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                            prmHeader(21).Value = Convert.ToDateTime(txtApp3Date.Text.Trim)
                                        End If
                                    Else 'change an action
                                        prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                        prmHeader(21).Value = dbMethod.GetServerDate
                                    End If
                                End If

                                prmHeader(22) = New SqlParameter("@ApproverRemarks3", SqlDbType.NVarChar)
                                prmHeader(22).Value = If(String.IsNullOrEmpty(txtApp3Remarks.Text.Trim), Nothing, txtApp3Remarks.Text.Trim)

                            Case Else 'technician
                                If cmbApp1Name.SelectedValue = 0 Then
                                    prmHeader(11) = New SqlParameter("@ApproverIsApproved1", SqlDbType.Bit)
                                    prmHeader(11).Value = 0
                                    prmHeader(12) = New SqlParameter("@ApproverId1", SqlDbType.Int)
                                    prmHeader(12).Value = Nothing
                                    prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                    prmHeader(13).Value = Nothing
                                    prmHeader(14) = New SqlParameter("@ApproverRemarks1", SqlDbType.NVarChar)
                                    prmHeader(14).Value = Nothing
                                Else
                                    prmHeader(11) = New SqlParameter("@ApproverIsApproved1", SqlDbType.Bit)
                                    prmHeader(11).Value = IIf(cmbApp1Status.SelectedValue = 1, 1, 0)
                                    prmHeader(12) = New SqlParameter("@ApproverId1", SqlDbType.Int)
                                    prmHeader(12).Value = cmbApp1Name.SelectedValue

                                    If cmbApp1Status.SelectedValue = 0 Then
                                        prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                        prmHeader(13).Value = Nothing
                                    Else
                                        If cmbApp1Status.SelectedValue = orgApp1Status Then
                                            If String.IsNullOrWhiteSpace(txtApp1Date.Text.Trim) Then
                                                prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                                prmHeader(13).Value = Nothing
                                            Else
                                                prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                                prmHeader(13).Value = Convert.ToDateTime(txtApp1Date.Text.Trim)
                                            End If
                                        Else
                                            prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                                            prmHeader(13).Value = dbMethod.GetServerDate
                                        End If
                                    End If

                                    prmHeader(14) = New SqlParameter("@ApproverRemarks1", SqlDbType.NVarChar)
                                    prmHeader(14).Value = IIf(String.IsNullOrEmpty(txtApp1Remarks.Text.Trim), Nothing, txtApp1Remarks.Text.Trim)
                                End If

                                If cmbApp2Name.SelectedValue = 0 Then
                                    prmHeader(15) = New SqlParameter("@ApproverIsApproved2", SqlDbType.Bit)
                                    prmHeader(15).Value = 0
                                    prmHeader(16) = New SqlParameter("@ApproverId2", SqlDbType.Int)
                                    prmHeader(16).Value = Nothing
                                    prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                    prmHeader(17).Value = Nothing
                                    prmHeader(18) = New SqlParameter("@ApproverRemarks2", SqlDbType.NVarChar)
                                    prmHeader(18).Value = Nothing
                                Else
                                    prmHeader(15) = New SqlParameter("@ApproverIsApproved2", SqlDbType.Bit)
                                    prmHeader(15).Value = IIf(cmbApp2Status.SelectedValue = 1, 1, 0)
                                    prmHeader(16) = New SqlParameter("@ApproverId2", SqlDbType.Int)
                                    prmHeader(16).Value = IIf(cmbApp2Name.SelectedValue = 0, Nothing, cmbApp2Name.SelectedValue)

                                    If cmbApp2Status.SelectedValue = 0 Then
                                        prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                        prmHeader(17).Value = Nothing
                                    Else
                                        If cmbApp2Status.SelectedValue = orgApp2Status Then
                                            If String.IsNullOrWhiteSpace(txtApp2Date.Text.Trim) Then
                                                prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                                prmHeader(17).Value = Nothing
                                            Else
                                                prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                                prmHeader(17).Value = Convert.ToDateTime(txtApp2Date.Text.Trim)
                                            End If
                                        Else
                                            prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                                            prmHeader(17).Value = dbMethod.GetServerDate
                                        End If
                                    End If

                                    prmHeader(18) = New SqlParameter("@ApproverRemarks2", SqlDbType.NVarChar)
                                    prmHeader(18).Value = IIf(String.IsNullOrEmpty(txtApp2Remarks.Text.Trim), Nothing, txtApp2Remarks.Text.Trim)
                                End If

                                prmHeader(19) = New SqlParameter("@ApproverIsApproved3", SqlDbType.Bit)
                                prmHeader(19).Value = IIf(cmbApp3Status.SelectedValue = 1, 1, 0)
                                prmHeader(20) = New SqlParameter("@ApproverId3", SqlDbType.Int)
                                prmHeader(20).Value = cmbApp3Name.SelectedValue

                                If cmbApp3Status.SelectedValue = 0 Then
                                    prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                    prmHeader(21).Value = Nothing
                                Else
                                    If cmbApp3Status.SelectedValue = orgApp3Status Then
                                        If String.IsNullOrWhiteSpace(txtApp3Date.Text.Trim) Then
                                            prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                            prmHeader(21).Value = Nothing
                                        Else
                                            prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                            prmHeader(21).Value = Convert.ToDateTime(txtApp3Date.Text.Trim)
                                        End If
                                    Else
                                        prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                                        prmHeader(21).Value = dbMethod.GetServerDate
                                    End If
                                End If

                                prmHeader(22) = New SqlParameter("@ApproverRemarks3", SqlDbType.NVarChar)
                                prmHeader(22).Value = If(String.IsNullOrEmpty(txtApp3Remarks.Text.Trim), Nothing, txtApp3Remarks.Text.Trim)
                        End Select
                    End If

                    prmHeader(23) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                    prmHeader(23).Value = userId
                    prmHeader(24) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime2)
                    prmHeader(24).Value = dbMethod.GetServerDate

                    prmHeader(25) = New SqlParameter("@FileAttachment", SqlDbType.VarBinary)
                    prmHeader(25).Value = Nothing
                    prmHeader(26) = New SqlParameter("@FileName", SqlDbType.NVarChar)
                    prmHeader(26).Value = Nothing

                    'trx status
                    If isAdmin Or accessLevelId = 1 Then 'will be based on routing status
                        prmHeader(27) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
                        prmHeader(27).Value = cmbTransactionStatus.SelectedValue
                    Else
                        Select Case accessLevelId
                            Case 2
                                Select Case cmbApp2Status.SelectedValue
                                    Case 0 'no selected action
                                        prmHeader(27) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
                                        prmHeader(27).Value = cmbTransactionStatus.SelectedValue
                                    Case 1 'selected approve
                                        prmHeader(27) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
                                        prmHeader(27).Value = 1
                                    Case 2 'selected `returned for revision`
                                        prmHeader(27) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
                                        prmHeader(27).Value = 2
                                End Select

                            Case 3
                                Select Case cmbApp1Status.SelectedValue
                                    Case 0 'no selected action
                                        prmHeader(27) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
                                        prmHeader(27).Value = cmbTransactionStatus.SelectedValue
                                    Case 1 'selected approve
                                        prmHeader(27) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
                                        prmHeader(27).Value = 1
                                    Case 2 'selected `returned for revision`
                                        prmHeader(27) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
                                        prmHeader(27).Value = 2
                                End Select

                            Case Else
                                prmHeader(27) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
                                prmHeader(27).Value = 1 'selected done
                        End Select
                    End If

                    prmHeader(28) = New SqlParameter("@DatetimeStarted", SqlDbType.DateTime2)
                    prmHeader(28).Value = dgvDetail.Rows(0).Cells("ColTrxFrom").Value
                    prmHeader(29) = New SqlParameter("@DatetimeEnded", SqlDbType.DateTime2)
                    prmHeader(29).Value = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                    prmHeader(30) = New SqlParameter("@UserId", SqlDbType.Int)
                    prmHeader(30).Value = dgvDetail.Rows(rowCount - 1).Cells("ColUserIdLog").Value
                    prmHeader(31) = New SqlParameter("@ShiftId", SqlDbType.Char)
                    prmHeader(31).Value = dgvDetail.Rows(rowCount - 1).Cells("ColShiftId").Value
                    prmHeader(32) = New SqlParameter("@TotalAccumulatedDowntime", SqlDbType.Int)
                    prmHeader(32).Value = txtDowntimeAccumulated.Text.Trim

                    'routingstatus
                    If isAdmin Or accessLevelId = 1 Then
                        If orgRoutingStatusId = 2 Then 'for approval of approver 3
                            If cmbRoutingStatus.SelectedValue = 2 Then 'for approval of approver 3
                                Select Case cmbApp3Status.SelectedValue
                                    Case 0
                                        prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                        prmHeader(33).Value = orgRoutingStatusId
                                    Case 1
                                        prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                        prmHeader(33).Value = 1
                                    Case 2
                                        prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                        prmHeader(33).Value = 6
                                End Select
                            Else
                                prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                prmHeader(33).Value = cmbRoutingStatus.SelectedValue
                            End If
                        Else
                            prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                            prmHeader(33).Value = cmbRoutingStatus.SelectedValue
                        End If
                    Else
                        Select Case accessLevelId
                            Case 2
                                If orgRoutingStatusId = 3 Then
                                    Select Case cmbApp2Status.SelectedValue
                                        Case 0
                                            prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                            prmHeader(33).Value = orgRoutingStatusId
                                        Case 1
                                            prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                            prmHeader(33).Value = 2
                                        Case 2
                                            prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                            prmHeader(33).Value = 6
                                    End Select
                                ElseIf orgRoutingStatusId = 5 Or orgRoutingStatusId = 6 Then
                                    prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                    prmHeader(33).Value = 2
                                Else
                                    prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                    prmHeader(33).Value = orgRoutingStatusId
                                End If

                            Case 3
                                If orgRoutingStatusId = 4 Then 'for approval of approver 1
                                    Select Case cmbApp1Status.SelectedValue
                                        Case 0
                                            prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                            prmHeader(33).Value = orgRoutingStatusId
                                        Case 1
                                            If cmbApp2Name.SelectedValue = 0 Then
                                                prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                                prmHeader(33).Value = 2
                                            Else
                                                prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                                prmHeader(33).Value = 3
                                            End If
                                        Case 2
                                            prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                            prmHeader(33).Value = 6
                                    End Select
                                ElseIf orgRoutingStatusId = 5 Or orgRoutingStatusId = 6 Then 'on-going or returned for revision
                                    If cmbApp2Name.SelectedValue = 0 Then 'no approver 2, directed to approver 3
                                        prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                        prmHeader(33).Value = 2
                                    Else 'with approver 2
                                        prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                        prmHeader(33).Value = 3
                                    End If
                                Else 'other routing status
                                    prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                    prmHeader(33).Value = orgRoutingStatusId
                                End If

                            Case Else
                                If orgRoutingStatusId = 5 Or orgRoutingStatusId = 6 Then 'on-going or returned for revision
                                    If cmbApp1Name.SelectedValue = 0 Then 'no approver 1
                                        If cmbApp2Name.SelectedValue = 0 Then 'no approver 2, directed to approver 3
                                            prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                            prmHeader(33).Value = 2
                                        Else 'with approver 2
                                            prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                            prmHeader(33).Value = 3
                                        End If
                                    Else 'with approver 1
                                        prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                        prmHeader(33).Value = 4
                                    End If
                                Else 'other routing status
                                    prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                                    prmHeader(33).Value = orgRoutingStatusId
                                End If
                        End Select
                    End If

                    If cmbDowntimeStatus.SelectedValue = 2 Then 'scheduled
                        If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                            prmHeader(34) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                            prmHeader(34).Value = Nothing
                        Else
                            prmHeader(34) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                            prmHeader(34).Value = txtProblem.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                            prmHeader(35) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                            prmHeader(35).Value = Nothing
                        Else
                            prmHeader(35) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                            prmHeader(35).Value = txtRootCause.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                            prmHeader(36) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                            prmHeader(36).Value = Nothing
                        Else
                            prmHeader(36) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                            prmHeader(36).Value = txtActionTaken.Text.Trim
                        End If

                        If picImage.Image Is Nothing Then
                            prmHeader(37) = New SqlParameter("@Image", SqlDbType.Image)
                            prmHeader(37).Value = Nothing
                            prmHeader(38) = New SqlParameter("@ImageName", SqlDbType.NVarChar)
                            prmHeader(38).Value = Nothing
                        Else
                            Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                            resImg.Save(mStream, ImageFormat.Jpeg)
                            bite = mStream.GetBuffer
                            prmHeader(37) = New SqlParameter("@Image", SqlDbType.Image)
                            prmHeader(37).Value = bite
                            prmHeader(38) = New SqlParameter("@ImageName", SqlDbType.NVarChar)
                            prmHeader(38).Value = txtImageName.Text.Trim
                        End If

                        If cmbDowntimeSubStatus.SelectedValue = 3 Then 'pm
                            If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                                MessageBox.Show("Please input the link of Check Sheet.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtChecksheet.Focus()
                                Return
                            Else
                                prmHeader(39) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                                prmHeader(39).Value = txtChecksheet.Text.Trim
                            End If

                            If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                                MessageBox.Show("Please input the link of 4M Change.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txt4M.Focus()
                                Return
                            Else
                                prmHeader(40) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                                prmHeader(40).Value = txt4M.Text.Trim
                            End If
                        Else 'scheduled but no pm
                            If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                                prmHeader(39) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                                prmHeader(39).Value = Nothing
                            Else
                                prmHeader(39) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                                prmHeader(39).Value = txtChecksheet.Text.Trim
                            End If

                            If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                                prmHeader(40) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                                prmHeader(40).Value = Nothing
                            Else
                                prmHeader(40) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                                prmHeader(40).Value = txt4M.Text.Trim
                            End If
                        End If

                    ElseIf cmbDowntimeStatus.SelectedValue = 3 Then 'unscheduled
                        If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                            MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtProblem.Focus()
                            Return
                        Else
                            prmHeader(34) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                            prmHeader(34).Value = txtProblem.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                            MessageBox.Show("Please indicate the root cause.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtRootCause.Focus()
                            Return
                        Else
                            prmHeader(35) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                            prmHeader(35).Value = txtRootCause.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                            MessageBox.Show("Please indicate the action taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtActionTaken.Focus()
                            Return
                        Else
                            prmHeader(36) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                            prmHeader(36).Value = txtActionTaken.Text.Trim
                        End If

                        If picImage.Image Is Nothing Then
                            MessageBox.Show("Please attach an image.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            btnBrowseImage.Focus()
                            Return
                        End If

                        Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                        resImg.Save(mStream, ImageFormat.Jpeg)
                        bite = mStream.GetBuffer
                        prmHeader(37) = New SqlParameter("@Image", SqlDbType.Image)
                        prmHeader(37).Value = bite
                        prmHeader(38) = New SqlParameter("@ImageName", SqlDbType.NVarChar)
                        prmHeader(38).Value = txtImageName.Text.Trim

                        If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                            prmHeader(39) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                            prmHeader(39).Value = Nothing
                        Else
                            prmHeader(39) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                            prmHeader(39).Value = txtChecksheet.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                            prmHeader(40) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                            prmHeader(40).Value = Nothing
                        Else
                            prmHeader(40) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                            prmHeader(40).Value = txt4M.Text.Trim
                        End If
                    End If

                    'prev status is on-going then mark as done
                    'set machine to operational
                    Dim prmMachineStatus(2) As SqlParameter
                    prmMachineStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmMachineStatus(0).Value = cmbMachineName.SelectedValue
                    prmMachineStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                    prmMachineStatus(1).Value = 1
                    prmMachineStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                    prmMachineStatus(2).Value = 1

                    dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMachineStatus)

                    'if orig selected machine is different to the current selected machine
                    If orgMachineId <> cmbMachineName.SelectedValue Then
                        Dim prmMachineStatusOrg(2) As SqlParameter
                        prmMachineStatusOrg(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prmMachineStatusOrg(0).Value = orgMachineId
                        prmMachineStatusOrg(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                        prmMachineStatusOrg(1).Value = 1
                        prmMachineStatusOrg(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                        prmMachineStatusOrg(2).Value = 1

                        dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMachineStatusOrg)
                    End If
                Else 'transaction status - on-going
                    'approvers
                    prmHeader(11) = New SqlParameter("@ApproverIsApproved1", SqlDbType.Bit)
                    prmHeader(11).Value = If(cmbApp1Status.SelectedValue = 1, 1, 0)
                    prmHeader(12) = New SqlParameter("@ApproverId1", SqlDbType.Int)
                    prmHeader(12).Value = IIf(cmbApp1Name.SelectedValue = 0, Nothing, cmbApp1Name.SelectedValue)

                    If String.IsNullOrWhiteSpace(txtApp1Date.Text.Trim) Then
                        prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                        prmHeader(13).Value = Nothing
                    Else
                        prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                        prmHeader(13).Value = Convert.ToDateTime(txtApp1Date.Text.Trim)
                    End If

                    prmHeader(14) = New SqlParameter("@ApproverRemarks1", SqlDbType.NVarChar)
                    prmHeader(14).Value = If(String.IsNullOrWhiteSpace(txtApp1Remarks.Text.Trim), Nothing, txtApp1Remarks.Text.Trim)

                    prmHeader(15) = New SqlParameter("@ApproverIsApproved2", SqlDbType.Bit)
                    prmHeader(15).Value = If(cmbApp2Status.SelectedValue = 1, 1, 0)
                    prmHeader(16) = New SqlParameter("@ApproverId2", SqlDbType.Int)
                    prmHeader(16).Value = IIf(cmbApp2Name.SelectedValue = 0, Nothing, cmbApp2Name.SelectedValue)

                    If String.IsNullOrEmpty(txtApp2Date.Text.Trim) Then
                        prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                        prmHeader(17).Value = Nothing
                    Else
                        prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                        prmHeader(17).Value = Convert.ToDateTime(txtApp2Date.Text.Trim)
                    End If

                    prmHeader(18) = New SqlParameter("@ApproverRemarks2", SqlDbType.NVarChar)
                    prmHeader(18).Value = If(String.IsNullOrWhiteSpace(txtApp2Remarks.Text.Trim), Nothing, txtApp2Remarks.Text.Trim)

                    prmHeader(19) = New SqlParameter("@ApproverIsApproved3", SqlDbType.Bit)
                    prmHeader(19).Value = If(cmbApp3Status.SelectedValue = 1, 1, 0)
                    prmHeader(20) = New SqlParameter("@ApproverId3", SqlDbType.Int)
                    prmHeader(20).Value = cmbApp3Name.SelectedValue

                    If String.IsNullOrWhiteSpace(txtApp3Date.Text.Trim) Then
                        prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                        prmHeader(21).Value = Nothing
                    Else
                        prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                        prmHeader(21).Value = Convert.ToDateTime(txtApp3Date.Text.Trim)
                    End If

                    prmHeader(22) = New SqlParameter("@ApproverRemarks3", SqlDbType.NVarChar)
                    prmHeader(22).Value = If(String.IsNullOrWhiteSpace(txtApp3Remarks.Text.Trim), Nothing, txtApp3Remarks.Text.Trim)

                    prmHeader(23) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                    prmHeader(23).Value = userId
                    prmHeader(24) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime2)
                    prmHeader(24).Value = dbMethod.GetServerDate
                    prmHeader(25) = New SqlParameter("@FileAttachment", SqlDbType.VarBinary)
                    prmHeader(25).Value = Nothing
                    prmHeader(26) = New SqlParameter("@FileName", SqlDbType.NVarChar)
                    prmHeader(26).Value = Nothing

                    prmHeader(27) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
                    prmHeader(27).Value = 2

                    If dgvDetail.Rows.Count > 0 Then
                        prmHeader(28) = New SqlParameter("@DatetimeStarted", SqlDbType.DateTime2)
                        prmHeader(28).Value = dgvDetail.Rows(0).Cells("ColTrxFrom").Value
                        prmHeader(29) = New SqlParameter("@DatetimeEnded", SqlDbType.DateTime2)
                        prmHeader(29).Value = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                        prmHeader(30) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmHeader(30).Value = dgvDetail.Rows(rowCount - 1).Cells("ColUserIdLog").Value
                        prmHeader(31) = New SqlParameter("@ShiftId", SqlDbType.Char)
                        prmHeader(31).Value = dgvDetail.Rows(rowCount - 1).Cells("ColShiftId").Value
                        prmHeader(32) = New SqlParameter("@TotalAccumulatedDowntime", SqlDbType.Int)
                        prmHeader(32).Value = txtDowntimeAccumulated.Text.Trim
                    Else
                        prmHeader(28) = New SqlParameter("@DatetimeStarted", SqlDbType.DateTime2)
                        prmHeader(28).Value = dtTrxHeader.Rows(0).Item("DatetimeStarted")
                        prmHeader(29) = New SqlParameter("@DatetimeEnded", SqlDbType.DateTime2)
                        prmHeader(29).Value = Nothing
                        prmHeader(30) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmHeader(30).Value = userId

                        If DateTime.Now.Hour >= 7 And DateTime.Now.Hour <= 19 Then
                            prmHeader(31) = New SqlParameter("@ShiftId", SqlDbType.Char)
                            prmHeader(31).Value = "D"
                        Else
                            prmHeader(31) = New SqlParameter("@ShiftId", SqlDbType.Char)
                            prmHeader(31).Value = "N"
                        End If

                        prmHeader(32) = New SqlParameter("@TotalAccumulatedDowntime", SqlDbType.Int)
                        prmHeader(32).Value = Nothing
                    End If

                    prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmHeader(33).Value = orgRoutingStatusId

                    If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                        prmHeader(34) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                        prmHeader(34).Value = Nothing
                    Else
                        prmHeader(34) = New SqlParameter("@Problem", SqlDbType.NVarChar)
                        prmHeader(34).Value = txtProblem.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                        prmHeader(35) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                        prmHeader(35).Value = Nothing
                    Else
                        prmHeader(35) = New SqlParameter("@RootCause", SqlDbType.NVarChar)
                        prmHeader(35).Value = txtRootCause.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                        prmHeader(36) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                        prmHeader(36).Value = Nothing
                    Else
                        prmHeader(36) = New SqlParameter("@ActionTaken", SqlDbType.NVarChar)
                        prmHeader(36).Value = txtActionTaken.Text.Trim
                    End If

                    If picImage.Image Is Nothing Then
                        prmHeader(37) = New SqlParameter("@Image", SqlDbType.Image)
                        prmHeader(37).Value = Nothing
                        prmHeader(38) = New SqlParameter("@ImageName", SqlDbType.NVarChar)
                        prmHeader(38).Value = Nothing
                    Else
                        Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                        resImg.Save(mStream, ImageFormat.Jpeg)
                        bite = mStream.GetBuffer
                        prmHeader(37) = New SqlParameter("@Image", SqlDbType.Image)
                        prmHeader(37).Value = bite
                        prmHeader(38) = New SqlParameter("@ImageName", SqlDbType.NVarChar)
                        prmHeader(38).Value = txtImageName.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                        prmHeader(39) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                        prmHeader(39).Value = Nothing
                    Else
                        prmHeader(39) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                        prmHeader(39).Value = txtChecksheet.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                        prmHeader(40) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                        prmHeader(40).Value = Nothing
                    Else
                        prmHeader(40) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                        prmHeader(40).Value = txt4M.Text.Trim
                    End If

                    'set machine status to downtime
                    Dim prmMchStatus(2) As SqlParameter
                    prmMchStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmMchStatus(0).Value = cmbMachineName.SelectedValue
                    prmMchStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                    prmMchStatus(1).Value = cmbDowntimeStatus.SelectedValue
                    prmMchStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                    prmMchStatus(2).Value = cmbDowntimeSubStatus.SelectedValue

                    dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMchStatus)

                    'selected machine was changed, set original machine to operational
                    If orgMachineId <> cmbMachineName.SelectedValue Then
                        Dim prmMachineStatusOrg(2) As SqlParameter
                        prmMachineStatusOrg(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prmMachineStatusOrg(0).Value = orgMachineId
                        prmMachineStatusOrg(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                        prmMachineStatusOrg(1).Value = 1
                        prmMachineStatusOrg(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                        prmMachineStatusOrg(2).Value = 1

                        dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMachineStatusOrg)
                    End If
                End If

                dbMethod.ExecuteNonQuery("UpdMntTransactionHeader", CommandType.StoredProcedure, prmHeader)

                If orgScheduleId > 0 Then 'clear up the orig pm schedule slot
                    Dim prmOrgSchedule(8) As SqlParameter
                    prmOrgSchedule(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmOrgSchedule(0).Value = Nothing
                    prmOrgSchedule(1) = New SqlParameter("@IsDone", SqlDbType.Bit)
                    prmOrgSchedule(1).Value = False
                    prmOrgSchedule(2) = New SqlParameter("@IsChecklistCompleted", SqlDbType.Bit)
                    prmOrgSchedule(2).Value = False
                    prmOrgSchedule(3) = New SqlParameter("@ActivityBy", SqlDbType.Int)
                    prmOrgSchedule(3).Value = Nothing
                    prmOrgSchedule(4) = New SqlParameter("@ActivityDate", SqlDbType.DateTime2)
                    prmOrgSchedule(4).Value = Nothing
                    prmOrgSchedule(5) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                    prmOrgSchedule(5).Value = Nothing
                    prmOrgSchedule(6) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime2)
                    prmOrgSchedule(6).Value = Nothing
                    prmOrgSchedule(7) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                    prmOrgSchedule(7).Value = orgScheduleId
                    prmOrgSchedule(8) = New SqlParameter("@Remarks", SqlDbType.Int)
                    prmOrgSchedule(8).Value = Nothing

                    dbMethod.ExecuteNonQuery("UpdMntMachineScheduleByScheduleId", CommandType.StoredProcedure, prmOrgSchedule)
                End If

                If scheduleId > 0 AndAlso cmbDowntimeSubStatus.SelectedValue = 3 Then
                    Dim prmNewSchedule(5) As SqlParameter
                    prmNewSchedule(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmNewSchedule(0).Value = trxId

                    prmNewSchedule(1) = New SqlParameter("@IsDone", SqlDbType.Bit)
                    If cmbTransactionStatus.SelectedValue = 1 Then prmNewSchedule(1).Value = True Else prmNewSchedule(1).Value = False

                    prmNewSchedule(2) = New SqlParameter("@IsChecklistCompleted", SqlDbType.Bit)
                    prmNewSchedule(2).Value = False

                    prmNewSchedule(3) = New SqlParameter("@ActivityBy", SqlDbType.Int)
                    If dgvDetail.Rows.Count > 0 Then
                        prmNewSchedule(3).Value = dgvDetail.Rows(rowCount - 1).Cells("ColUserIdLog").Value
                    Else
                        prmNewSchedule(3).Value = userId
                    End If

                    prmNewSchedule(4) = New SqlParameter("@ActivityDate", SqlDbType.DateTime)
                    If dgvDetail.Rows.Count > 0 Then
                        prmNewSchedule(4).Value = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                    Else
                        prmNewSchedule(4).Value = dbMethod.GetServerDate
                    End If

                    prmNewSchedule(5) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                    prmNewSchedule(5).Value = scheduleId

                    dbMethod.ExecuteNonQuery("UpdMntMachineSchedule", CommandType.StoredProcedure, prmNewSchedule)
                End If

                'transaction details
                If dgvDetail.Rows.Count > 0 Then
                    For Each dataRowView As DataRowView In Me.bsTrxDetail
                        Dim row = dataRowView.Row
                        row.Item("TrxId") = prmHeader(0).Value
                    Next
                    adpTrxDetail.Update(dtTrxDetail)
                End If

                For Each dataRowView As DataRowView In Me.bsTrxDetail
                    Dim row = dataRowView.Row
                    row.Item("TrxId") = trxId
                Next
                Me.bsTrxDetail.EndEdit()
                Me.adpTrxDetail.Update(dtTrxDetail)

                If dgvDetail.Rows.Count > 0 Then
                    'insert to transaction user
                    For Each row As DataGridViewRow In dgvDetail.Rows
                        Dim prmUserCnt(1) As SqlParameter
                        prmUserCnt(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmUserCnt(0).Value = prmHeader(0).Value
                        prmUserCnt(1) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmUserCnt(1).Value = row.Cells("ColUserIdLog").Value

                        If dbMethod.ExecuteScalar("CntMntTransactionUser", CommandType.StoredProcedure, prmUserCnt) = 0 Then
                            Dim prmUserIns(1) As SqlParameter
                            prmUserIns(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                            prmUserIns(0).Value = prmHeader(0).Value
                            prmUserIns(1) = New SqlParameter("@UserId", SqlDbType.Int)
                            prmUserIns(1).Value = row.Cells("ColUserIdLog").Value
                            dbMethod.ExecuteNonQuery("InsMntTransactionUser", CommandType.StoredProcedure, prmUserIns)
                        End If
                    Next
                End If

                'transaction machine part
                If cmbMachinePart.SelectedValue = 0 AndAlso Not cmbMachinePart.Enabled Then
                    Dim prmMchPart(1) As SqlParameter
                    prmMchPart(0) = New SqlParameter("@MachinePartId", SqlDbType.Int)
                    prmMchPart(0).Value = Nothing
                    prmMchPart(1) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmMchPart(1).Value = trxId

                    dbMethod.ExecuteNonQuery("UpdMntTransactionMachinePart", CommandType.StoredProcedure, prmMchPart)
                Else
                    Dim prmMchPart(1) As SqlParameter
                    prmMchPart(0) = New SqlParameter("@MachinePartId", SqlDbType.Int)
                    prmMchPart(0).Value = cmbMachinePart.SelectedValue
                    prmMchPart(1) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmMchPart(1).Value = trxId

                    dbMethod.ExecuteNonQuery("UpdMntTransactionMachinePart", CommandType.StoredProcedure, prmMchPart)
                End If

                ''''
                '''' do not allow modification of spare part issuance record
                ''''

                'transaction user - insert from pic gridview
                For Each row As DataGridViewRow In dgvPic.Rows
                    Dim userId As Integer = row.Cells("ColUserId").Value
                    Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("ColIsSelected").Value)

                    Dim prmCount(1) As SqlParameter
                    prmCount(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmCount(0).Value = trxId
                    prmCount(1) = New SqlParameter("@UserId", SqlDbType.Int)
                    prmCount(1).Value = userId

                    trxCount = dbMethod.ExecuteScalar("CntMntTransactionUser", CommandType.StoredProcedure, prmCount)

                    If trxCount > 0 Then
                        If isSelected Then
                            'already on pic table - do nothing
                        Else
                            'previously selected as pic - delete from pic table
                            Dim prmDel(1) As SqlParameter
                            prmDel(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                            prmDel(0).Value = trxId
                            prmDel(1) = New SqlParameter("@UserId", SqlDbType.Int)
                            prmDel(1).Value = userId

                            dbMethod.ExecuteNonQuery("DelMntTransactionUserByUserId", CommandType.StoredProcedure, prmDel)
                        End If
                    Else
                        If isSelected Then
                            'selected - add to pic table
                            Dim prmIns(1) As SqlParameter
                            prmIns(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                            prmIns(0).Value = trxId
                            prmIns(1) = New SqlParameter("@UserId", SqlDbType.Int)
                            prmIns(1).Value = userId

                            dbMethod.ExecuteNonQuery("InsMntTransactionUser", CommandType.StoredProcedure, prmIns)
                        Else
                            'not selected - do nothing
                        End If
                    End If
                Next
            End If

            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnView4M_Click(sender As Object, e As EventArgs) Handles btnView4M.Click
        Try
            If Not String.IsNullOrEmpty(txt4M.Text.Trim) Then
                Process.Start(txt4M.Text)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnViewChecksheet_Click(sender As Object, e As EventArgs) Handles btnViewChecksheet.Click
        Try
            If Not String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                Process.Start(txtChecksheet.Text)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnViewImage_Click(sender As Object, e As EventArgs) Handles btnViewImage.Click
        Try
            If lstImgAttachment.Count > 0 Then
                Process.Start(lstImgAttachment(0).fileName)
            Else
                'https://stackoverflow.com/questions/14866603/a-generic-error-occurred-in-gdi-when-attempting-to-use-image-save
                If Not picImage.Image Is Nothing Then
                    Dim bmp As Bitmap = New Bitmap(picImage.Image)
                    bmp.Save(imgTmp)
                    Process.Start(imgTmp)

                    'OpenImage(imgTmp, 30000) '30 seconds
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbApp1Name_Enter(sender As Object, e As EventArgs) Handles cmbApp1Name.Enter
        lblApp1Name.ForeColor = Color.White
        lblApp1Name.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbApp1Name_Leave(sender As Object, e As EventArgs) Handles cmbApp1Name.Leave
        lblApp1Name.ForeColor = Color.Black
        lblApp1Name.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbApp1Name_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbApp1Name.SelectedValueChanged
        Try
            If Not cmbApp1Name.SelectedValue = 0 Then
                Dim prmUser(0) As SqlParameter
                prmUser(0) = New SqlParameter("UserId", SqlDbType.NVarChar)
                prmUser(0).Value = cmbApp1Name.SelectedValue

                Dim rdrUser As IDataReader = dbMethod.ExecuteReader("RdSecUser", CommandType.StoredProcedure, prmUser)

                While rdrUser.Read
                    txtApp1Position.Text = rdrUser("WorkgroupName").ToString.Trim
                End While
                rdrUser.Close()
            Else
                txtApp1Position.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbApp1Name_Validated(sender As Object, e As EventArgs) Handles cmbApp1Name.Validated
        If cmbApp1Name.Text.Trim.Length = 0 Or cmbApp1Name.SelectedValue = 0 Then
            cmbApp1Name.SelectedValue = 0
        End If
    End Sub

    Private Sub cmbApp1Name_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            If cmbApp1Name.Text.Trim.Length = 0 Then
                cmbApp1Name.SelectedValue = 0
                e.Cancel = False
            Else
                e.Cancel = sender.FindStringExact(sender.text) < 0
            End If

            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbApp1Status_Enter(sender As Object, e As EventArgs) Handles cmbApp1Status.Enter
        lblApp1Status.ForeColor = Color.White
        lblApp1Status.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbApp1Status_Leave(sender As Object, e As EventArgs) Handles cmbApp1Status.Leave
        lblApp1Status.ForeColor = Color.Black
        lblApp1Status.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbApp2Name_Enter(sender As Object, e As EventArgs) Handles cmbApp2Name.Enter
        lblApp2Name.ForeColor = Color.White
        lblApp2Name.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbApp2Name_Leave(sender As Object, e As EventArgs) Handles cmbApp2Name.Leave
        lblApp2Name.ForeColor = Color.Black
        lblApp2Name.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbApp2Name_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbApp2Name.SelectedValueChanged
        Try
            If Not cmbApp2Name.SelectedIndex = 0 Then
                Dim prmUser(0) As SqlParameter
                prmUser(0) = New SqlParameter("UserId", SqlDbType.NVarChar)
                prmUser(0).Value = cmbApp2Name.SelectedValue

                Dim rdrUser As IDataReader = dbMethod.ExecuteReader("RdSecUser", CommandType.StoredProcedure, prmUser)

                While rdrUser.Read
                    txtApp2Position.Text = rdrUser("WorkgroupName").ToString.Trim
                End While
                rdrUser.Close()
            Else
                txtApp2Position.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbApp2Name_Validated(sender As Object, e As EventArgs) Handles cmbApp2Name.Validated
        If cmbApp2Name.Text.Trim.Length = 0 Or cmbApp2Name.SelectedValue = 0 Then
            cmbApp2Name.SelectedValue = 0
        End If
    End Sub

    Private Sub cmbApp2Name_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            If cmbApp2Name.Text.Trim.Length = 0 Then
                cmbApp2Name.SelectedValue = 0
                e.Cancel = False
            Else
                e.Cancel = sender.FindStringExact(sender.text) < 0
            End If

            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbApp2Status_Enter(sender As Object, e As EventArgs) Handles cmbApp2Status.Enter
        lblApp2Status.ForeColor = Color.White
        lblApp2Status.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbApp2Status_Leave(sender As Object, e As EventArgs) Handles cmbApp2Status.Leave
        lblApp2Status.ForeColor = Color.Black
        lblApp2Status.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbApp3Name_Enter(sender As Object, e As EventArgs) Handles cmbApp3Name.Enter
        lblApp3Name.ForeColor = Color.White
        lblApp3Name.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbApp3Name_Leave(sender As Object, e As EventArgs) Handles cmbApp3Name.Leave
        lblApp3Name.ForeColor = Color.Black
        lblApp3Name.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbApp3Name_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbApp3Name.SelectedValueChanged
        Try
            If Not cmbApp3Name.SelectedValue = 0 Then
                Dim prmUser(0) As SqlParameter
                prmUser(0) = New SqlParameter("UserId", SqlDbType.NVarChar)
                prmUser(0).Value = cmbApp3Name.SelectedValue

                Dim rdrUser As IDataReader = dbMethod.ExecuteReader("RdSecUser", CommandType.StoredProcedure, prmUser)

                While rdrUser.Read
                    txtApp3Position.Text = rdrUser("WorkgroupName").ToString.Trim
                End While
                rdrUser.Close()
            Else
                txtApp3Position.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbApp3Name_Validated(sender As Object, e As EventArgs) Handles cmbApp3Name.Validated
        If cmbApp3Name.Text.Trim.Length = 0 Or cmbApp3Name.SelectedValue = 0 Then
            cmbApp3Name.SelectedValue = 0
        End If
    End Sub

    Private Sub cmbApp3Name_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            If cmbApp3Name.Text.Trim.Length = 0 Then
                cmbApp3Name.SelectedValue = 0
                e.Cancel = False
            Else
                e.Cancel = sender.FindStringExact(sender.text) < 0
            End If

            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbApp3Status_Enter(sender As Object, e As EventArgs) Handles cmbApp3Status.Enter
        lblApp3Status.ForeColor = Color.White
        lblApp3Status.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbApp3Status_Leave(sender As Object, e As EventArgs) Handles cmbApp3Status.Leave
        lblApp3Status.ForeColor = Color.Black
        lblApp3Status.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbDowntimeStatus_Enter(sender As Object, e As EventArgs) Handles cmbDowntimeStatus.Enter
        lblDowntimeStatus.ForeColor = Color.White
        lblDowntimeStatus.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbDowntimeStatus_Leave(sender As Object, e As EventArgs) Handles cmbDowntimeStatus.Leave
        lblDowntimeStatus.ForeColor = Color.Black
        lblDowntimeStatus.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbDowntimeStatus_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbDowntimeStatus.SelectedValue = 0 Then
                cmbDowntimeSubStatus.DataSource = Nothing
                cmbDowntimeSubStatus.Items.Clear()
                cmbDowntimeSubStatus.Enabled = False
            Else
                LoadDowntimeSubStatus(cmbDowntimeStatus.SelectedValue)
                If trxId = 0 Then
                    cmbDowntimeSubStatus.Enabled = True
                Else
                    If isAdmin Or accessLevelId = 1 Then
                        cmbDowntimeSubStatus.Enabled = True
                    Else
                        Select Case accessLevelId
                            Case 2, 3
                                If orgRoutingStatusId = 3 Or orgRoutingStatusId = 4 Then
                                    cmbDowntimeSubStatus.Enabled = True
                                End If
                            Case Else
                                If orgRoutingStatusId = 5 Or orgRoutingStatusId = 6 Then
                                    cmbDowntimeSubStatus.Enabled = True
                                End If
                        End Select
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbDowntimeSubStatus_Enter(sender As Object, e As EventArgs) Handles cmbDowntimeSubStatus.Enter
        lblDowntimeSubStatus.ForeColor = Color.White
        lblDowntimeSubStatus.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbDowntimeSubStatus_Leave(sender As Object, e As EventArgs) Handles cmbDowntimeSubStatus.Leave
        lblDowntimeSubStatus.ForeColor = Color.Black
        lblDowntimeSubStatus.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbDowntimeSubStatus_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbDowntimeSubStatus.SelectedValue = 0 Then
                txtScheduleMonth.Text = String.Empty
                txtScheduleWeek.Text = String.Empty
                txtScheduleMonth.Enabled = False
                txtScheduleWeek.Enabled = False

                scheduleId = 0
                monthId = 0
                weekId = 0
            Else
                If cmbDowntimeSubStatus.SelectedValue = 3 Then 'preventive maintenance
                    GetMachineSchedule(cmbMachineName.SelectedValue)
                Else
                    txtScheduleMonth.Text = String.Empty
                    txtScheduleWeek.Text = String.Empty
                    txtScheduleMonth.Enabled = False
                    txtScheduleWeek.Enabled = False

                    If orgMachineSubStatusId = 3 Then
                        Dim prmSched(1) As SqlParameter
                        prmSched(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prmSched(0).Value = cmbMachineName.SelectedValue
                        prmSched(1) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmSched(1).Value = trxId

                        Dim query As String = "SELECT TOP 1 ScheduleId, MonthId, WeekId FROM VwMntMachineSchedule WHERE MachineId = @MachineId AND TrxId = @TrxId"
                        Dim rdrSched As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSched)

                        If rdrSched.Read Then
                            orgScheduleId = rdrSched.Item("ScheduleId")
                        End If
                        rdrSched.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachineName_Enter(sender As Object, e As EventArgs) Handles cmbMachineName.Enter
        lblMachineName.ForeColor = Color.White
        lblMachineName.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbMachineName_Leave(sender As Object, e As EventArgs) Handles cmbMachineName.Leave
        lblMachineName.ForeColor = Color.Black
        lblMachineName.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbMachineName_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbMachineName.SelectedValue = 0 Then
                DisableForm(True)
            Else
                DisableForm(False)
                GetMachineArea(cmbMachineName.SelectedValue)
                GetMachinePartGroup(cmbMachineName.SelectedValue)
                GetTotalRuntime(cmbMachineName.SelectedValue)
                LoadDowntimeStatus()
                LoadDowntimeSubStatus(cmbDowntimeStatus.SelectedValue)

                If trxId = 0 Then
                    cmbDowntimeStatus.SelectedValue = 3
                    cmbDowntimeSubStatus.SelectedValue = 5
                Else
                    If isAdmin Or accessLevelId = 1 Then
                        If cmbMachinePart.Items.Count > 0 Then
                            cmbMachinePart.Enabled = True
                        Else
                            cmbMachinePart.Enabled = False
                        End If
                    Else
                        Select Case accessLevelId
                            Case 2
                                Select Case orgRoutingStatusId
                                    Case 1, 2
                                        cmbMachinePart.Enabled = False
                                    Case Else
                                        If cmbMachinePart.Items.Count > 0 Then
                                            cmbMachinePart.Enabled = True
                                        Else
                                            cmbMachinePart.Enabled = False
                                        End If
                                End Select

                            Case 3
                                Select Case orgRoutingStatusId
                                    Case 1, 2
                                        cmbMachinePart.Enabled = False
                                    Case Else
                                        If cmbMachinePart.Items.Count > 0 Then
                                            cmbMachinePart.Enabled = True
                                        Else
                                            cmbMachinePart.Enabled = False
                                        End If
                                End Select

                            Case Else
                                Select Case orgRoutingStatusId
                                    Case 5, 6
                                        If cmbMachinePart.Items.Count > 0 Then
                                            cmbMachinePart.Enabled = True
                                        Else
                                            cmbMachinePart.Enabled = False
                                        End If
                                    Case Else
                                        cmbMachinePart.Enabled = False
                                End Select
                        End Select
                    End If
                End If

                'selected another machine then select again the orig machine
                If orgMachineId = cmbMachineName.SelectedValue AndAlso trxId <> 0 Then
                    If Not dtTrxHeader.Rows(0).Item("TotalAccumulatedRuntime") Is DBNull.Value Then
                        txtRuntimeAccumulated.Text = dtTrxHeader.Rows(0).Item("TotalAccumulatedRuntime")
                    End If
                Else
                    GetTotalRuntime(cmbMachineName.SelectedValue)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachineName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbMachineName.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachinePart_Enter(sender As Object, e As EventArgs) Handles cmbMachinePart.Enter
        lblMachinePart.ForeColor = Color.White
        lblMachinePart.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbMachinePart_Leave(sender As Object, e As EventArgs) Handles cmbMachinePart.Leave
        lblMachinePart.ForeColor = Color.Black
        lblMachinePart.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbMachinePart_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            If cmbMachinePart.Text.Trim.Length = 0 Then
                cmbMachinePart.SelectedValue = 0
                e.Cancel = False
            Else
                e.Cancel = sender.FindStringExact(sender.text) < 0
            End If

            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbRoutingStatus_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            Select Case cmbRoutingStatus.SelectedValue
                Case 7 'disapproved
                    MessageBox.Show("Disapproved status is inactive. Please select another status.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    LoadRoutingStatus(orgRoutingStatusId)
                    Me.ActiveControl = cmbRoutingStatus

                Case 6 'returned for revision
                    cmbTransactionStatus.SelectedValue = 2 'set to on-going

                    If orgRoutingStatusId = 2 Then
                        cmbApp3Status.SelectedValue = 2
                    Else
                        cmbApp3Status.SelectedValue = 0
                    End If

                    cmbApp2Status.SelectedValue = 0
                    cmbApp1Status.SelectedValue = 0

                Case 5 'on-going
                    cmbTransactionStatus.SelectedValue = 2 'set to on-going
                    cmbApp3Status.SelectedValue = 0
                    cmbApp2Status.SelectedValue = 0
                    cmbApp1Status.SelectedValue = 0

                Case 4 'for approval of approver 1
                    If cmbApp1Name.SelectedValue = 0 Then
                        MessageBox.Show("No selected approver 1.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        LoadRoutingStatus(orgRoutingStatusId)
                        Me.ActiveControl = cmbApp1Name
                    End If

                    cmbTransactionStatus.SelectedValue = 1
                    cmbApp3Status.SelectedValue = 0
                    cmbApp2Status.SelectedValue = 0
                    cmbApp1Status.SelectedValue = 0

                Case 3 'for approval of approver 2
                    If cmbApp2Name.SelectedValue = 0 Then
                        MessageBox.Show("No selected approver 2.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        LoadRoutingStatus(orgRoutingStatusId)
                        Me.ActiveControl = cmbApp2Name
                    End If

                    cmbTransactionStatus.SelectedValue = 1
                    cmbApp3Status.SelectedValue = 0
                    cmbApp2Status.SelectedValue = 0

                    cmbApp1Status.SelectedValue = orgApp1Status

                Case 2 'for approval of approver 3
                    cmbTransactionStatus.SelectedValue = 1
                    cmbApp3Status.SelectedValue = 0

                    cmbApp2Status.SelectedValue = orgApp2Status
                    cmbApp1Status.SelectedValue = orgApp1Status

                Case 1
                    cmbTransactionStatus.SelectedValue = 1
                    cmbApp3Status.SelectedValue = 1

                    cmbApp2Status.SelectedValue = orgApp2Status
                    cmbApp1Status.SelectedValue = orgApp1Status
            End Select

            If cmbRoutingStatus.SelectedValue <> orgRoutingStatusId Then
                cmbApp3Status.Enabled = False
            Else
                cmbApp3Status.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTransactionStatus_Enter(sender As Object, e As EventArgs) Handles cmbTransactionStatus.Enter
        lblTransactionStatus.ForeColor = Color.White
        lblTransactionStatus.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbTransactionStatus_Leave(sender As Object, e As EventArgs) Handles cmbTransactionStatus.Leave
        lblTransactionStatus.ForeColor = Color.Black
        lblTransactionStatus.BackColor = SystemColors.Control
    End Sub

    Private Function CreateTrxDetail() As DataTable
        Dim dtTrxDetail As New DataTable

        Try
            Dim con As New SqlConnection(dbConnection.GetConnectionString)
            Dim query As String = "SELECT TrxDetailId, TrxId, TrxDate, TrxFrom, TrxTo, ElapsedTime, UserId, ShiftId, ModifiedBy, ModifiedDate, SeqId FROM dbo.MntTransactionDetail WHERE TrxId IS NULL"
            Dim cmd As New SqlCommand(query, con)
            adpTrxDetail = New SqlDataAdapter(cmd)
            Dim cbTrxDetail As New SqlCommandBuilder(adpTrxDetail)

            Dim colTrxDetailId As DataColumn = New DataColumn("TrxDetailId")
            colTrxDetailId.DataType = System.Type.GetType("System.Int32")
            colTrxDetailId.AllowDBNull = True
            dtTrxDetail.Columns.Add(colTrxDetailId)

            Dim colTrxId As DataColumn = New DataColumn("TrxId")
            colTrxId.DataType = System.Type.GetType("System.Int32")
            colTrxId.AllowDBNull = True
            dtTrxDetail.Columns.Add(colTrxId)

            Dim colTrxDate As DataColumn = New DataColumn("TrxDate")
            colTrxDate.DataType = System.Type.GetType("System.DateTime")
            dtTrxDetail.Columns.Add(colTrxDate)

            Dim colTrxFrom As DataColumn = New DataColumn("TrxFrom")
            colTrxFrom.DataType = System.Type.GetType("System.DateTime")
            dtTrxDetail.Columns.Add(colTrxFrom)

            Dim colTrxTo As DataColumn = New DataColumn("TrxTo")
            colTrxTo.DataType = System.Type.GetType("System.DateTime")
            dtTrxDetail.Columns.Add(colTrxTo)

            Dim colElapsedTime As DataColumn = New DataColumn("ElapsedTime")
            colElapsedTime.DataType = System.Type.GetType("System.Int32")
            dtTrxDetail.Columns.Add(colElapsedTime)

            Dim colUserId As DataColumn = New DataColumn("UserId")
            colUserId.DataType = System.Type.GetType("System.Int32")
            dtTrxDetail.Columns.Add(colUserId)

            Dim colShiftId As DataColumn = New DataColumn("ShiftId")
            colShiftId.DataType = System.Type.GetType("System.String")
            dtTrxDetail.Columns.Add(colShiftId)

            Dim colModifiedBy As DataColumn = New DataColumn("ModifiedBy")
            colModifiedBy.DataType = System.Type.GetType("System.Int32")
            dtTrxDetail.Columns.Add(colModifiedBy)

            Dim colModifiedDate As DataColumn = New DataColumn("ModifiedDate")
            colModifiedDate.DataType = System.Type.GetType("System.DateTime")
            dtTrxDetail.Columns.Add(colModifiedDate)

            Dim colSeqId As DataColumn = New DataColumn("SeqId")
            colSeqId.DataType = System.Type.GetType("System.Int32")
            dtTrxDetail.Columns.Add(colSeqId)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtTrxDetail
    End Function

    Private Function CreateTrxPartDetail() As DataTable
        Dim dtMntTrxPartDetail As New DataTable
        Dim con As New SqlConnection(dbConnection.GetConnectionString)

        Try

            Dim query As String = "SELECT PartTrxDetailId, PartTrxId, SeqId, CreatedBy, CreatedDate, UserId, PartId, Qty, ModifiedBy, ModifiedDate FROM dbo.MntTransactionPartDetail WHERE PartTrxId IS NULL"
            Dim cmd As New SqlCommand(query, con)
            adpTrxPartDetail = New SqlDataAdapter(cmd)
            Dim cbTrxDetail As New SqlCommandBuilder(adpTrxPartDetail)

            Dim colPartTrxDetailId As DataColumn = New DataColumn("PartTrxDetailId")
            colPartTrxDetailId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colPartTrxDetailId)

            Dim colPartTrxId As DataColumn = New DataColumn("PartTrxId")
            colPartTrxId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colPartTrxId)

            Dim colSeqId As DataColumn = New DataColumn("SeqId")
            colSeqId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colSeqId)

            Dim colCreatedBy As DataColumn = New DataColumn("CreatedBy")
            colCreatedBy.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colCreatedBy)

            Dim colCreateDate As DataColumn = New DataColumn("CreatedDate")
            colCreateDate.DataType = System.Type.GetType("System.DateTime")
            dtMntTrxPartDetail.Columns.Add(colCreateDate)

            Dim colUserId As DataColumn = New DataColumn("UserId")
            colUserId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colUserId)

            Dim colPartId As DataColumn = New DataColumn("PartId")
            colPartId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colPartId)

            Dim colQty As DataColumn = New DataColumn("Qty")
            colQty.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colQty)

            Dim colModifiedBy As DataColumn = New DataColumn("ModifiedBy")
            colModifiedBy.DataType = System.Type.GetType("System.Int32")
            colModifiedBy.AllowDBNull = True
            dtMntTrxPartDetail.Columns.Add(colModifiedBy)

            Dim colModifiedDate As DataColumn = New DataColumn("ModifiedDate")
            colModifiedDate.DataType = System.Type.GetType("System.DateTime")
            colModifiedDate.AllowDBNull = True
            dtMntTrxPartDetail.Columns.Add(colModifiedDate)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtMntTrxPartDetail
    End Function

    Private Sub DeleteTempImg(ByVal sender As Object, ByVal e As System.EventArgs)
        If File.Exists(imgTmp) Then
            File.Delete(imgTmp)
        End If
    End Sub

    Private Sub dgvDetail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellDoubleClick
        Try
            btnEditLog.PerformClick()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetail.DataError
        e.Cancel = False
    End Sub

    Private Sub dgvDetail_Enter(sender As Object, e As EventArgs) Handles dgvDetail.Enter
        lblActivityLog.ForeColor = Color.White
        lblActivityLog.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub dgvDetail_Leave(sender As Object, e As EventArgs) Handles dgvDetail.Leave
        lblActivityLog.ForeColor = Color.Black
        lblActivityLog.BackColor = SystemColors.Control
    End Sub

    Private Sub dgvPartDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvPartDetail.DataError
        e.Cancel = False
    End Sub

    Private Sub dgvPartDetail_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPartDetail.SelectionChanged
        dgvPartDetail.ClearSelection()
    End Sub

    Private Sub dgvPic_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvPic.DataBindingComplete
        For Each row As DataRow In dtTrxUser.Rows
            For i As Integer = 0 To dgvPic.Rows.Count - 1
                If dgvPic.Rows(i).Cells("ColUserId").Value = row("UserId") Then
                    dgvPic.Rows(i).Cells("ColIsSelected").Value = True
                End If
            Next
        Next
    End Sub

    Private Sub dgvPic_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvPic.DataError
        e.Cancel = False
    End Sub

    Private Sub dgvPic_Enter(sender As Object, e As EventArgs) Handles dgvPic.Enter
        lblPic.ForeColor = Color.White
        lblPic.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub dgvPic_Leave(sender As Object, e As EventArgs) Handles dgvPic.Leave
        lblPic.ForeColor = Color.Black
        lblPic.BackColor = SystemColors.Control
    End Sub

    Private Sub dgvPic_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPic.SelectionChanged
        dgvPic.ClearSelection()
    End Sub

    Private Sub FilterPicTable()
        Try
            If dgvDetail.Rows.Count > 0 Then
                Dim filterBuilder As New System.Text.StringBuilder("SectionId = 2 AND IsActive = 1 AND UserId NOT IN (")

                For i As Integer = 0 To dgvDetail.Rows.Count - 1
                    If i > 0 Then
                        filterBuilder.Append(",")
                    End If
                    filterBuilder.Append(dgvDetail.Rows(i).Cells("ColNickname").Value)
                Next

                filterBuilder.Append(")")

                Me.bsTrxUser.Filter = filterBuilder.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMntTrxDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If fromPmCalendar = False Then
            If e.KeyCode.Equals(Keys.F8) Then 'delete
                e.Handled = True
                If btnDelete.Enabled = True Then
                    btnDelete.PerformClick()
                End If
            ElseIf e.KeyCode.Equals(Keys.F10) Then 'save
                e.Handled = True
                If btnSave.Enabled = True Then
                    btnSave.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub frmMntTrxDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If trxId = 0 Then
                Me.Text = "New Activity Entry"

                txtCreatedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", dbMethod.GetServerDate)

                LoadRoutingStatus(5)

                cmbTransactionStatus.SelectedValue = 1

                btnDelete.Enabled = False

                DisableForm(True)
                Me.ActiveControl = cmbMachineName
            Else
                Me.Text = "Activity No. " & trxId

                For Each row As DataRow In dtTrxHeader.Rows
                    orgMachineId = row("MachineId")
                    orgMachineSubStatusId = row("DowntimeMachineSubStatusId")

                    LoadRoutingStatus(row("RoutingStatusId"))
                    orgRoutingStatusId = row("RoutingStatusId")

                    If isAdmin Or accessLevelId = 1 Then
                        txtRoutingStatus.Visible = False
                        cmbRoutingStatus.Visible = True
                    End If

                    txtCreatedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("TrxDate"))
                    cmbTransactionStatus.SelectedValue = row("TrxStatusId")
                    cmbMachineName.SelectedValue = row("MachineId")
                    cmbDowntimeStatus.SelectedValue = row("DowntimeMachineStatusId")
                    cmbDowntimeSubStatus.SelectedValue = row("DowntimeMachineSubStatusId")

                    If Not row("TotalAccumulatedRuntime") Is DBNull.Value Then
                        txtRuntimeAccumulated.Text = row("TotalAccumulatedRuntime")
                    End If

                    If Not row("TotalAccumulatedDowntime") Is DBNull.Value Then
                        txtDowntimeAccumulated.Text = row("TotalAccumulatedDowntime")
                    End If

                    If Not row("Problem") Is DBNull.Value Then
                        txtProblem.Text = row("Problem")
                    End If

                    If Not row("RootCause") Is DBNull.Value Then
                        txtRootCause.Text = row("RootCause")
                    End If

                    If Not row("ActionTaken") Is DBNull.Value Then
                        txtActionTaken.Text = row("ActionTaken")
                    End If

                    If Not row("JoNumber") Is DBNull.Value Then
                        txtJoNumber.Text = row("JoNumber").ToString.Trim
                    End If

                    If Not row("JoRequestor") Is DBNull.Value Then
                        txtJoRequestor.Text = row("JoRequestor")
                    End If

                    If Not row("Image") Is DBNull.Value Then
                        bite = row("Image")
                        Using ms As New MemoryStream(bite)
                            picImage.Image = Image.FromStream(ms)
                        End Using
                    End If

                    If Not row("ImageName") Is DBNull.Value Then
                        txtImageName.Text = row("ImageName")
                    End If

                    If Not row("LinkChecksheet") Is DBNull.Value Then
                        txtChecksheet.Text = row("LinkChecksheet")
                    End If

                    If Not row("Link4M") Is DBNull.Value Then
                        txt4M.Text = row("Link4M")
                    End If

                    If Not row("ModifiedBy") Is DBNull.Value Then
                        orgModifiedBy = row("ModifiedBy")
                    Else
                        orgModifiedBy = Nothing
                    End If

                    If Not row("ModifiedDate") Is DBNull.Value Then
                        orgModifiedDate = row("ModifiedDate")
                    Else
                        orgModifiedDate = Nothing
                    End If

                    orgApp3Status = IIf(row("ApproverIsApproved3") = True, 1, 0)
                    orgApp2Status = IIf(row("ApproverIsApproved2") = True, 1, 0)
                    orgApp1Status = IIf(row("ApproverIsApproved1") = True, 1, 0)

                    If row("ApproverIsApproved3") = True Then
                        cmbApp3Status.SelectedValue = 1
                    Else
                        If Not row("ApproverDate3") Is DBNull.Value Then 'returned
                            cmbApp3Status.SelectedValue = 2
                        Else
                            cmbApp3Status.SelectedValue = 0
                        End If
                    End If

                    If row("ApproverIsApproved2") = True Then
                        cmbApp2Status.SelectedValue = 1
                    Else
                        If Not row("ApproverDate2") Is DBNull.Value Then 'returned
                            cmbApp2Status.SelectedValue = 2
                        Else
                            cmbApp2Status.SelectedValue = 0
                        End If
                    End If

                    If row("ApproverIsApproved1") = True Then
                        cmbApp1Status.SelectedValue = 1
                    Else
                        If Not row("ApproverDate1") Is DBNull.Value Then 'returned
                            cmbApp1Status.SelectedValue = 2
                        Else
                            cmbApp1Status.SelectedValue = 0
                        End If
                    End If

                    cmbApp3Name.SelectedValue = row("ApproverId3")

                    If row("ApproverId2") Is DBNull.Value Then
                        cmbApp2Name.SelectedValue = 0
                    Else
                        cmbApp2Name.SelectedValue = row("ApproverId2")
                    End If

                    If row("ApproverId1") Is DBNull.Value Then
                        cmbApp1Name.SelectedValue = 0
                    Else
                        cmbApp1Name.SelectedValue = row("ApproverId1")
                    End If

                    If Not row("ApproverDate3") Is DBNull.Value Then
                        txtApp3Date.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("ApproverDate3"))
                    End If

                    If Not row("ApproverDate2") Is DBNull.Value Then
                        txtApp2Date.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("ApproverDate2"))
                    End If

                    If Not row("ApproverDate1") Is DBNull.Value Then
                        txtApp1Date.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("ApproverDate1"))
                    End If

                    If Not row("ApproverRemarks3") Is DBNull.Value Then
                        txtApp3Remarks.Text = row("ApproverRemarks3").ToString.Trim
                    End If

                    If Not row("ApproverRemarks2") Is DBNull.Value Then
                        txtApp2Remarks.Text = row("ApproverRemarks2").ToString.Trim
                    End If

                    If Not row("ApproverRemarks1") Is DBNull.Value Then
                        txtApp1Remarks.Text = row("ApproverRemarks1").ToString.Trim
                    End If

                    If Not row("ModifiedBy") Is DBNull.Value Then
                        lblModifiedBy.Visible = True
                        txtModifiedBy.Visible = True
                        txtModifiedBy.Text = GetUserName(CInt(row("ModifiedBy")))
                    End If

                    If Not row("ModifiedDate") Is DBNull.Value Then
                        lblModifiedDate.Visible = True
                        txtModifiedDate.Visible = True
                        txtModifiedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("ModifiedDate"))
                    End If
                Next

                For Each row As DataRow In dtTrxMachinePart.Rows
                    If Not row("MachinePartId") Is DBNull.Value Then
                        cmbMachinePart.SelectedValue = row("MachinePartId")
                        orgMachineGroupId = row("MachinePartId")
                    Else
                        orgMachineGroupId = 0
                    End If
                Next

                imgTmp = Path.Combine(IO.Path.GetTempPath, "tmpImg." & Path.GetExtension(txtImageName.Text))

                'decide what control should receive focus
                If isAdmin Or accessLevelId = 1 Then
                    If cmbApp3Name.SelectedValue = userId AndAlso orgRoutingStatusId = 2 Then
                        Me.ActiveControl = txtApp3Remarks
                        txtApp3Remarks.Select(txtApp3Remarks.Text.ToString.Trim.Length, 0)
                    Else
                        Me.ActiveControl = txtProblem
                        txtProblem.Select(txtProblem.Text.ToString.Trim.Length, 0)
                    End If
                Else
                    Select Case accessLevelId
                        Case 2
                            If orgRoutingStatusId = 3 AndAlso cmbApp2Name.SelectedValue = userId Then
                                Me.ActiveControl = txtApp2Remarks
                                txtApp2Remarks.Select(txtApp2Remarks.Text.ToString.Trim.Length, 0)
                            ElseIf orgRoutingStatusId = 5 Or orgRoutingStatusId = 6 Then
                                Me.ActiveControl = txtProblem
                                txtProblem.Select(txtProblem.Text.ToString.Trim.Length, 0)
                            Else
                                Me.ActiveControl = txtChecksheet
                            End If

                        Case 3
                            If orgRoutingStatusId = 4 AndAlso cmbApp1Name.SelectedValue = userId Then
                                Me.ActiveControl = txtApp1Remarks
                                txtApp1Remarks.Select(txtApp1Remarks.Text.ToString.Trim.Length, 0)
                            ElseIf orgRoutingStatusId = 5 Or orgRoutingStatusId = 6 Then
                                Me.ActiveControl = txtProblem
                                txtProblem.Select(txtProblem.Text.ToString.Trim.Length, 0)
                            Else
                                Me.ActiveControl = txtChecksheet
                            End If

                        Case Else
                            If orgRoutingStatusId = 5 Or orgRoutingStatusId = 6 Then
                                Me.ActiveControl = txtProblem
                                txtProblem.Select(txtProblem.Text.ToString.Trim.Length, 0)
                            Else
                                Me.ActiveControl = txtChecksheet
                            End If
                    End Select
                End If
            End If

            If fromPmCalendar = True Then
                cmbTransactionStatus.Enabled = False
                cmbMachineName.Enabled = False
                cmbMachinePart.Enabled = False
                cmbDowntimeStatus.Enabled = False
                cmbDowntimeSubStatus.Enabled = False
                txtScheduleMonth.Enabled = False
                txtScheduleWeek.Enabled = False
                txtProblem.Enabled = False
                txtRootCause.Enabled = False
                txtActionTaken.Enabled = False

                txtJoNumber.Enabled = False
                txtJoRequestor.Enabled = False
                txtChecksheet.Enabled = False
                txt4M.Enabled = False

                btnAddLog.Enabled = False
                btnEditLog.Enabled = False
                btnDeleteLog.Enabled = False
                btnBrowseImage.Enabled = False
                btnRemoveImage.Enabled = False
                btnRemoveChecksheet.Enabled = False
                btnRemove4M.Enabled = False

                btnViewChecksheet.Enabled = True
                btnView4M.Enabled = True
                btnViewImage.Enabled = True

                dgvPic.ReadOnly = True
                dgvDetail.ReadOnly = True

                btnSave.Enabled = False
                btnCancel.Enabled = False
                btnDelete.Enabled = False

                cmbApp3Status.Enabled = False
                cmbApp3Name.Enabled = False
                txtApp3Remarks.Enabled = False

                cmbApp2Status.Enabled = False
                cmbApp2Name.Enabled = False
                txtApp2Remarks.Enabled = False

                cmbApp1Status.Enabled = False
                cmbApp1Name.Enabled = False
                txtApp1Remarks.Enabled = False
            End If

            If btnCancel.Enabled = True Then
                Me.CancelButton = btnCancel
            Else
                Me.CancelButton = btnClose
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMntTrxDetailMch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'impersonation.UndoImpersonateUser()
    End Sub

    Private Sub GetMachineArea(machineId As Integer)
        Try
            Dim prmMachineId(0) As SqlParameter
            prmMachineId(0) = New SqlParameter("@MachineId", SqlDbType.Int)
            prmMachineId(0).Value = machineId

            Dim rdrMachine As IDataReader = dbMethod.ExecuteReader("RdMntMachine", CommandType.StoredProcedure, prmMachineId)

            While rdrMachine.Read
                areaId = rdrMachine.Item("AreaId")
                txtArea.Text = rdrMachine.Item("AreaName").ToString.Replace("&", "&&")
            End While
            rdrMachine.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetMachinePartGroup(machineId As Integer)
        Try
            cmbMachinePart.DisplayMember = "MachinePartName"
            cmbMachinePart.ValueMember = "MachinePartId"

            cmbMachinePart.DataSource = Nothing
            cmbMachinePart.Items.Clear()

            Dim prmMachineId(0) As SqlParameter
            prmMachineId(0) = New SqlParameter("@MachineId", SqlDbType.Int)
            prmMachineId(0).Value = machineId

            Dim rdrPartGroup As IDataReader = dbMethod.ExecuteReader("RdMntMachine", CommandType.StoredProcedure, prmMachineId)

            While rdrPartGroup.Read
                If rdrPartGroup.Item("GroupId") Is DBNull.Value Then
                    machinePartGroupId = 0
                    cmbMachinePart.Enabled = False
                Else
                    machinePartGroupId = rdrPartGroup.Item("GroupId")
                    cmbMachinePart.Enabled = True

                    Dim prmGroupId(0) As SqlParameter
                    prmGroupId(0) = New SqlParameter("@GroupId", SqlDbType.Int)
                    prmGroupId(0).Value = machinePartGroupId

                    dbMethod.FillCmbWithCaption("RdMntMachinePart", CommandType.StoredProcedure, "MachinePartId", "MachinePartName", cmbMachinePart, "< Select Machine Part >",
                                                prmGroupId)
                End If
            End While
            rdrPartGroup.Close()

            AddHandler cmbMachinePart.Validating, AddressOf cmbMachinePart_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetMachineSchedule(machineId As Integer)
        Try
            If trxId = 0 Then
                Dim prmSchedule(0) As SqlParameter
                prmSchedule(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmSchedule(0).Value = machineId

                Dim query As String = "SELECT TOP 1 ScheduleId, MonthId, WeekId FROM VwMntMachineSchedule WHERE MachineId = @MachineId AND ActivityDate IS NULL AND IsDone = 0 ORDER BY YearId, MonthId, WeekId"
                Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSchedule)

                If rdrSchedule.Read Then
                    scheduleId = rdrSchedule.Item("ScheduleId")
                    monthId = rdrSchedule.Item("MonthId")
                    weekId = rdrSchedule.Item("WeekId")
                    txtScheduleMonth.Text = MonthName(monthId)
                    txtScheduleWeek.Text = weekId
                Else
                    MessageBox.Show("No PM schedule found for this machine.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbDowntimeSubStatus.SelectedValue = 0
                    txtScheduleMonth.Text = String.Empty
                    txtScheduleWeek.Text = String.Empty

                    scheduleId = 0
                    monthId = 0
                    weekId = 0
                End If
                rdrSchedule.Close()
            Else
                If orgMachineId = machineId Then 'same machine
                    If orgMachineSubStatusId = cmbDowntimeSubStatus.SelectedValue Then 'pm to pm
                        Dim prmSchedule(1) As SqlParameter
                        prmSchedule(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prmSchedule(0).Value = machineId
                        prmSchedule(1) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmSchedule(1).Value = trxId

                        Dim query As String = "SELECT TOP 1 ScheduleId, MonthId, WeekId FROM VwMntMachineSchedule WHERE MachineId = @MachineId AND TrxId = @TrxId ORDER BY YearId, MonthId, WeekId"
                        Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSchedule)

                        If rdrSchedule.Read Then
                            scheduleId = rdrSchedule.Item("ScheduleId")
                            monthId = rdrSchedule.Item("MonthId")
                            weekId = rdrSchedule.Item("WeekId")
                            txtScheduleMonth.Text = MonthName(monthId)
                            txtScheduleWeek.Text = weekId
                        End If
                        rdrSchedule.Close()
                    Else 'non-pm to pm
                        Dim prmSchedule(0) As SqlParameter
                        prmSchedule(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prmSchedule(0).Value = machineId

                        Dim query As String = "SELECT TOP 1 ScheduleId, MonthId, WeekId FROM VwMntMachineSchedule WHERE MachineId = @MachineId AND " &
                                              "ActivityDate IS NULL AND IsDone = 0 ORDER BY YearId, MonthId, WeekId"
                        Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSchedule)

                        If rdrSchedule.Read Then
                            scheduleId = rdrSchedule.Item("ScheduleId")
                            monthId = rdrSchedule.Item("MonthId")
                            weekId = rdrSchedule.Item("WeekId")
                            txtScheduleMonth.Text = MonthName(monthId)
                            txtScheduleWeek.Text = weekId
                        End If
                    End If
                Else 'selected machine was changed
                    Dim prmNewSched(0) As SqlParameter
                    prmNewSched(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmNewSched(0).Value = machineId

                    Dim query As String = "SELECT TOP 1 ScheduleId, MonthId, WeekId FROM VwMntMachineSchedule WHERE MachineId = @MachineId AND ActivityDate IS NULL AND IsDone = 0 ORDER BY YearId, MonthId, WeekId"
                    Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmNewSched)

                    If rdrSchedule.Read Then 'non-pm to pm
                        scheduleId = rdrSchedule.Item("ScheduleId")
                        monthId = rdrSchedule.Item("MonthId")
                        weekId = rdrSchedule.Item("WeekId")
                        txtScheduleMonth.Text = MonthName(monthId)
                        txtScheduleWeek.Text = weekId

                        Dim prmOrgSched(0) As SqlParameter 'pm to pm
                        prmOrgSched(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmOrgSched(0).Value = trxId

                        Dim query2 As String = "SELECT ScheduleId FROM dbo.MntMachineSchedule WHERE TrxId = @TrxId"
                        Dim rdrOrgSched As IDataReader = dbMethod.ExecuteReader(query2, CommandType.Text, prmOrgSched)

                        While rdrOrgSched.Read
                            orgScheduleId = rdrOrgSched.Item("ScheduleId")
                        End While
                        rdrOrgSched.Close()
                    Else
                        MessageBox.Show("No PM schedule found for this machine.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbDowntimeSubStatus.SelectedValue = 0
                        txtScheduleMonth.Text = String.Empty
                        txtScheduleWeek.Text = String.Empty

                        scheduleId = 0
                        monthId = 0
                        weekId = 0
                    End If
                    rdrSchedule.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetSetting(settingsId As Integer)
        Try
            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@SettingsId", SqlDbType.Int)
            prm(0).Value = settingsId

            Using rdrSetting As IDataReader = dbMethod.ExecuteReader("SELECT * FROM dbo.SysSetting WHERE SettingsId = @SettingsId", CommandType.Text, prm)
                While rdrSetting.Read

                    If Not rdrSetting.Item("ServerNetUserName") Is DBNull.Value Then
                        serverNetUserName = rdrSetting.Item("ServerNetUserName").ToString.Trim
                    End If

                    If Not rdrSetting.Item("ServerNetUserPassword") Is DBNull.Value Then
                        serverNetUserPassword = rdrSetting.Item("ServerNetUserPassword").ToString.Trim
                    End If
                End While
                rdrSetting.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetTotalDowntime()
        Try
            Dim minutes As String
            Dim totalMinutes As Integer = 0

            For Each row As DataGridViewRow In dgvDetail.Rows
                minutes = row.Cells("ColElapsedTime").Value
                totalMinutes = totalMinutes + minutes
            Next

            txtDowntimeAccumulated.Text = totalMinutes
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetTotalRuntime(machineId As Integer)
        Try
            Dim lastDatetime As DateTime = Nothing
            Dim span As TimeSpan = Nothing
            Dim spanMinutes As Integer = 0
            Dim spanHours As Integer = 0
            Dim spanDays As Integer = 0
            Dim totalMinutes As Integer = 0

            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@MachineId", SqlDbType.Int)
            prm(0).Value = machineId

            Dim reader As IDataReader = dbMethod.ExecuteReader("RdMntMachineAccumulatedTime", CommandType.StoredProcedure, prm)

            While reader.Read
                If Not reader.Item("TrxFrom") Is DBNull.Value Then
                    lastDatetime = reader.Item("TrxFrom").ToString
                End If
            End While
            reader.Close()

            If Not lastDatetime = "01/01/0001 12:00:00 AM" Then
                span = (lastDatetime - CDate(dbMethod.GetServerDate).Date).Duration()
                txtRuntimeAccumulated.Text = Math.Truncate(span.TotalMinutes)
            Else
                txtRuntimeAccumulated.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetUserName(userId As Integer) As String
        Dim username As String = String.Empty

        Try
            Dim prmUser(0) As SqlParameter
            prmUser(0) = New SqlParameter("@UserId", SqlDbType.Int)
            prmUser(0).Value = userId
            username = dbMethod.ExecuteScalar("SELECT TRIM(UserName) AS UserName FROM dbo.SecUser WHERE UserId = @UserId", CommandType.Text, prmUser)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return username
    End Function

    Private Sub LoadApproverAction()
        Try
            dicApp3Action.Add(" < Select Action > ", 0)
            dicApp3Action.Add("Approved", 1)
            dicApp3Action.Add("Return for revision", 2)
            cmbApp3Status.DisplayMember = "Key"
            cmbApp3Status.ValueMember = "Value"
            cmbApp3Status.DataSource = New BindingSource(dicApp3Action, Nothing)

            dicApp2Action.Add(" < Select Action > ", 0)
            dicApp2Action.Add("Approved", 1)
            dicApp2Action.Add("Return for revision", 2)
            cmbApp2Status.DisplayMember = "Key"
            cmbApp2Status.ValueMember = "Value"
            cmbApp2Status.DataSource = New BindingSource(dicApp2Action, Nothing)

            dicApp1Action.Add(" < Select Action > ", 0)
            dicApp1Action.Add("Approved", 1)
            dicApp1Action.Add("Return for revision", 2)
            cmbApp1Status.DisplayMember = "Key"
            cmbApp1Status.ValueMember = "Value"
            cmbApp1Status.DataSource = New BindingSource(dicApp1Action, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadApprovers()
        Try
            Dim prmApp3(0) As SqlParameter
            prmApp3(0) = New SqlParameter("@WorkgroupIdLevel", SqlDbType.Int)
            prmApp3(0).Value = 1

            dbMethod.FillCmb("RdSecUserApprover", CommandType.StoredProcedure, "UserId", "UserName", cmbApp3Name, prmApp3)

            Dim prmApp2(1) As SqlParameter
            prmApp2(0) = New SqlParameter("@WorkgroupIdLevel", SqlDbType.Int)
            prmApp2(0).Value = 2
            prmApp2(1) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmApp2(1).Value = 2

            dbMethod.FillCmbWithCaption("RdSecUserApprover", CommandType.StoredProcedure, "UserId", "UserName", cmbApp2Name, "< All Approver 2 >", prmApp2)

            Dim prmApp1(1) As SqlParameter
            prmApp1(0) = New SqlParameter("@WorkgroupIdLevel", SqlDbType.Int)
            prmApp1(0).Value = 3
            prmApp1(1) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmApp1(1).Value = 2

            dbMethod.FillCmbWithCaption("RdSecUserApprover", CommandType.StoredProcedure, "UserId", "UserName", cmbApp1Name, "< All Approver 1 >", prmApp1)

            If cmbApp3Name.Items.Count = 1 Then
                cmbApp3Name.SelectedIndex = 0
            Else
                cmbApp3Name.SelectedIndex = 1
            End If

            If cmbApp2Name.Items.Count = 2 Then
                cmbApp2Name.SelectedIndex = 1
            ElseIf cmbApp2Name.Items.Count > 2 Then
                cmbApp2Name.SelectedValue = 0
            End If

            If cmbApp1Name.Items.Count = 2 Then
                cmbApp1Name.SelectedIndex = 1
            ElseIf cmbApp1Name.Items.Count > 2 Then
                cmbApp1Name.SelectedValue = 0
            End If

            AddHandler cmbApp3Name.Validating, AddressOf cmbApp3Name_Validating
            AddHandler cmbApp2Name.Validating, AddressOf cmbApp2Name_Validating
            AddHandler cmbApp1Name.Validating, AddressOf cmbApp1Name_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDowntimeStatus()
        Try
            cmbDowntimeStatus.DisplayMember = "MachineStatusName"
            cmbDowntimeStatus.ValueMember = "MachineStatusId"

            Dim prmMachineStatus(0) As SqlParameter
            prmMachineStatus(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
            prmMachineStatus(0).Value = Nothing

            dbMethod.FillCmbWithCaption("RdMntMachineStatus", CommandType.StoredProcedure, "MachineStatusId", "MachineStatusName", cmbDowntimeStatus,
                                        "< Select Machine Status >", prmMachineStatus)

            AddHandler cmbDowntimeStatus.SelectedValueChanged, AddressOf cmbDowntimeStatus_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDowntimeSubStatus(downtimeStatusId As Integer)
        Try
            cmbDowntimeSubStatus.DisplayMember = "MachineSubStatusName"
            cmbDowntimeSubStatus.ValueMember = "MachineSubStatusId"

            cmbDowntimeSubStatus.DataSource = Nothing
            cmbDowntimeSubStatus.Items.Clear()

            Dim prmMachineSubStatus(0) As SqlParameter
            prmMachineSubStatus(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
            prmMachineSubStatus(0).Value = downtimeStatusId

            dbMethod.FillCmbWithCaption("RdMntMachineSubStatus", CommandType.StoredProcedure, "MachineSubStatusId", "MachineSubStatusName",
                                        cmbDowntimeSubStatus, "< Select Sub-Status >", prmMachineSubStatus)

            AddHandler cmbDowntimeSubStatus.SelectedValueChanged, AddressOf cmbDowntimeSubStatus_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMachine()
        Try
            cmbMachineName.DisplayMember = "MachineName"
            cmbMachineName.ValueMember = "MachineId"

            If trxId = 0 Then
                Dim prm(1) As SqlParameter
                prm(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                prm(0).Value = 1
                prm(1) = New SqlParameter("@IsActive", SqlDbType.Int)
                prm(1).Value = 1

                dbMethod.FillCmbWithCaption("RdMntMachine", CommandType.StoredProcedure, "MachineId", "MachineName", cmbMachineName, "", prm)
            Else
                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                prm(0).Value = Nothing

                dbMethod.FillCmbWithCaption("RdMntMachine", CommandType.StoredProcedure, "MachineId", "MachineName", cmbMachineName, "", prm)
            End If

            AddHandler cmbMachineName.Validating, AddressOf cmbMachineName_Validating
            AddHandler cmbMachineName.SelectedValueChanged, AddressOf cmbMachineName_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadRoutingStatus(Optional routingStatusId As Integer = 0)
        Try
            dbMethod.FillCmb("RdGenRoutingStatus", CommandType.StoredProcedure, "RoutingStatusId", "RoutingStatusName", cmbRoutingStatus)

            If Not routingStatusId = 0 Then
                cmbRoutingStatus.SelectedValue = routingStatusId
                txtRoutingStatus.Text = cmbRoutingStatus.Text
            End If

            AddHandler cmbRoutingStatus.SelectedValueChanged, AddressOf cmbRoutingStatus_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadTransactionStatus()
        Try
            cmbTransactionStatus.DisplayMember = "TrxStatusName"
            cmbTransactionStatus.ValueMember = "TrxStatusId"

            dbMethod.FillCmb("RdGenTransactionStatus", CommandType.StoredProcedure, "TrxStatusId", "TrxStatusName", cmbTransactionStatus)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ofdImage_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdImage.FileOk
        Try
            If lstImgAttachment.Count > 0 Then lstImgAttachment.RemoveAt(0)

            If Not picImage.Image Is Nothing Then
                lstImgAttachment.RemoveAt(0)
                picImage.Image.Dispose()
                picImage.Image = Nothing
                txtImageName.Text = String.Empty
            End If

            Dim imgAttachment As New ImgAttachment(ofdImage.FileName, ofdImage.SafeFileName, Path.GetExtension(ofdImage.SafeFileName).ToLower)
            lstImgAttachment.Add(imgAttachment)

            Using ms As New MemoryStream
                Using bmp As New Bitmap(lstImgAttachment(0).fileName)
                    Dim jpgEncoder As ImageCodecInfo = dbMain.GetEncoder(ImageFormat.Jpeg)
                    Dim myEncoder As Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality

                    'create an encoder parameters object
                    'an encoder parameters object has an array of encoderparameter objects; in this case, there is only one encoderparameter object in the array.
                    Dim myEncoderParameters As New EncoderParameters(1)
                    'save the bitmap as a JPG file with quality level compression
                    Dim myEncoderParameter = New EncoderParameter(myEncoder, 500L)
                    myEncoderParameters.Param(0) = myEncoderParameter
                    bmp.Save(ms, jpgEncoder, myEncoderParameters)
                End Using

                picImage.Image = Image.FromStream(ms)
            End Using

            txtImageName.Text = lstImgAttachment(0).safeName
            ofdImage.InitialDirectory = Path.GetDirectoryName(lstImgAttachment(0).fileName)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pnlImage_Enter(sender As Object, e As EventArgs) Handles pnlImage.Enter
        lblImageAttachment.ForeColor = Color.White
        lblImageAttachment.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub pnlImage_Leave(sender As Object, e As EventArgs) Handles pnlImage.Leave
        lblImageAttachment.ForeColor = Color.Black
        lblImageAttachment.BackColor = SystemColors.Control
    End Sub

    Private Sub txt4M_Enter(sender As Object, e As EventArgs) Handles txt4M.Enter
        lbl4M.ForeColor = Color.White
        lbl4M.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txt4M_Leave(sender As Object, e As EventArgs) Handles txt4M.Leave
        lbl4M.ForeColor = Color.Black
        lbl4M.BackColor = SystemColors.Control
    End Sub

    Private Sub txt4M_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles txt4M.LinkClicked
        Try
            If Not String.IsNullOrEmpty(txt4M.Text.Trim) Then
                Process.Start(e.LinkText)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtActionTaken_Enter(sender As Object, e As EventArgs) Handles txtActionTaken.Enter
        lblActionTaken.ForeColor = Color.White
        lblActionTaken.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtActionTaken_Leave(sender As Object, e As EventArgs) Handles txtActionTaken.Leave
        lblActionTaken.ForeColor = Color.Black
        lblActionTaken.BackColor = SystemColors.Control
    End Sub

    Private Sub txtApp1Remarks_Enter(sender As Object, e As EventArgs) Handles txtApp1Remarks.Enter
        lblApp1Remarks.ForeColor = Color.White
        lblApp1Remarks.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtApp1Remarks_Leave(sender As Object, e As EventArgs) Handles txtApp1Remarks.Leave
        lblApp1Remarks.ForeColor = Color.Black
        lblApp1Remarks.BackColor = SystemColors.Control
    End Sub

    Private Sub txtApp2Remarks_Enter(sender As Object, e As EventArgs) Handles txtApp2Remarks.Enter
        lblApp2Remarks.ForeColor = Color.White
        lblApp2Remarks.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtApp2Remarks_Leave(sender As Object, e As EventArgs) Handles txtApp2Remarks.Leave
        lblApp2Remarks.ForeColor = Color.Black
        lblApp2Remarks.BackColor = SystemColors.Control
    End Sub

    Private Sub txtApp3Remarks_Enter(sender As Object, e As EventArgs) Handles txtApp3Remarks.Enter
        lblApp3Remarks.ForeColor = Color.White
        lblApp3Remarks.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtApp3Remarks_Leave(sender As Object, e As EventArgs) Handles txtApp3Remarks.Leave
        lblApp3Remarks.ForeColor = Color.Black
        lblApp3Remarks.BackColor = SystemColors.Control
    End Sub

    Private Sub txtChecksheet_Enter(sender As Object, e As EventArgs) Handles txtChecksheet.Enter
        lblChecksheet.ForeColor = Color.White
        lblChecksheet.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtChecksheet_Leave(sender As Object, e As EventArgs) Handles txtChecksheet.Leave
        lblChecksheet.ForeColor = Color.Black
        lblChecksheet.BackColor = SystemColors.Control
    End Sub

    Private Sub txtChecksheet_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles txtChecksheet.LinkClicked
        Try
            If Not String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                Process.Start(e.LinkText)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtJoNumber_Enter(sender As Object, e As EventArgs) Handles txtJoNumber.Enter
        lblJoNumber.ForeColor = Color.White
        lblJoNumber.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtJoNumber_Leave(sender As Object, e As EventArgs) Handles txtJoNumber.Leave
        lblJoNumber.ForeColor = Color.Black
        lblJoNumber.BackColor = SystemColors.Control
    End Sub

    Private Sub txtJoRequestor_Enter(sender As Object, e As EventArgs) Handles txtJoRequestor.Enter
        lblJoRequestor.ForeColor = Color.White
        lblJoRequestor.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtJoRequestor_Leave(sender As Object, e As EventArgs) Handles txtJoRequestor.Leave
        lblJoRequestor.ForeColor = Color.Black
        lblJoRequestor.BackColor = SystemColors.Control
    End Sub

    Private Sub txtProblem_Enter(sender As Object, e As EventArgs) Handles txtProblem.Enter
        lblProblem.ForeColor = Color.White
        lblProblem.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtProblem_Leave(sender As Object, e As EventArgs) Handles txtProblem.Leave
        lblProblem.ForeColor = Color.Black
        lblProblem.BackColor = SystemColors.Control
    End Sub

    Private Sub txtRootCause_Enter(sender As Object, e As EventArgs) Handles txtRootCause.Enter
        lblRootCause.ForeColor = Color.White
        lblRootCause.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtRootCause_Leave(sender As Object, e As EventArgs) Handles txtRootCause.Leave
        lblRootCause.ForeColor = Color.Black
        lblRootCause.BackColor = SystemColors.Control
    End Sub

    Private Sub txtScheduleMonth_Enter(sender As Object, e As EventArgs) Handles txtScheduleMonth.Enter
        lblScheduleMonth.ForeColor = Color.White
        lblScheduleMonth.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtScheduleMonth_Leave(sender As Object, e As EventArgs) Handles txtScheduleMonth.Leave
        lblScheduleMonth.ForeColor = Color.Black
        lblScheduleMonth.BackColor = SystemColors.Control
    End Sub

    Private Sub txtScheduleWeek_Enter(sender As Object, e As EventArgs) Handles txtScheduleWeek.Enter
        lblScheduleWeek.ForeColor = Color.White
        lblScheduleWeek.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtScheduleWeek_Leave(sender As Object, e As EventArgs) Handles txtScheduleWeek.Leave
        lblScheduleWeek.ForeColor = Color.Black
        lblScheduleWeek.BackColor = SystemColors.Control
    End Sub

End Class