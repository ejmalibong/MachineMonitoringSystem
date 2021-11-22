Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.Threading
Imports BlackCoffeeLibrary
Imports MachineMonitoringSystem.dsMonitoring
Imports MachineMonitoringSystem.dsMonitoringTableAdapters

Public Class frmMntTrxDetail
    Private connection As New clsConnection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbMain As New Main

    Private dsMonitoring As New dsMonitoring
    Private adpRoutingStatus As New GenRoutingStatusTableAdapter
    Private adpTransactionHeader As New MntTransactionHeaderTableAdapter
    Private adpTransactionDetail As New MntTransactionDetailTableAdapter
    Private adpTransactionMachinePart As New MntTransactionMachinePartTableAdapter
    Private adpTransactionSparePart As New MntTransactionSparePartTableAdapter
    Private adpTransactionUser As New MntTransactionUserTableAdapter
    Private adpSecUserPic As New SecUserTableAdapter

    Private dtSecUserLog As New SecUserDataTable
    Private dtSecUserPic As New SecUserDataTable
    Private dtTransactionHeader As New MntTransactionHeaderDataTable
    Private dtTransactionDetail As New MntTransactionDetailDataTable
    Private dtTransactionMachinePart As New MntTransactionMachinePartDataTable
    Private dtTransactionSparePart As New MntTransactionSparePartDataTable
    Private dtTransactionUser As New MntTransactionUserDataTable

    Private WithEvents bsTransactionHeader As New BindingSource
    Private WithEvents bsTransactionDetail As New BindingSource
    Private WithEvents bsTransactionMachinePart As New BindingSource
    Private WithEvents bsTransactionSparePart As New BindingSource
    Private WithEvents bsTransactionUser As New BindingSource
    Private WithEvents bsSecUserLog As New BindingSource

    Private WithEvents bsMachine As New BindingSource
    Private WithEvents bsJig As New BindingSource

    Private rowRoutingStatus As GenRoutingStatusRow

    Private WithEvents trxDate As Binding
    Private WithEvents approverDate1 As Binding
    Private WithEvents approverDate2 As Binding
    Private WithEvents approverDate3 As Binding

    Private dicApprover1 As New Dictionary(Of String, Integer) 'asv action
    Private dicApprover2 As New Dictionary(Of String, Integer) 'sv action
    Private dicApprover3 As New Dictionary(Of String, Integer) 'sr mngr action

    Private userId As Integer = 0
    Private workgroupId As Integer = 0
    Private isAdmin As Boolean = True
    Private trxId As Integer = 0

    Private areaId As Integer = 0
    Private machinePartGroupId As Integer = 0

    Private memoStream As New MemoryStream
    Private bite As Byte() 'the word `byte` is not a valid identifier

    Private trxCount As Integer = 0
    Private isValidate As Boolean = True

    Private origMachineId As Integer = 0
    Private origJigId As Integer = 0

    Private superiorWorkgroupId As New List(Of Integer) From {29, 30, 2} 'sv, asv, sr mngr

    Public Sub New(ByVal _dataset As DataSet, ByVal _userId As Integer, ByVal _workgroupId As Integer, ByVal _isAdmin As Boolean, Optional _trxId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        workgroupId = _workgroupId
        isAdmin = _isAdmin
        trxId = _trxId

        Me.adpRoutingStatus.Fill(Me.dsMonitoring.GenRoutingStatus)
        Me.adpSecUserPic.Fill(Me.dsMonitoring.SecUser)

        Dim _colNickname As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        _colNickname.Name = "ColNickname"
        _colNickname.DataPropertyName = "UserId"
        _colNickname.HeaderText = "Technician"
        _colNickname.DataSource = Me.bsSecUserLog
        _colNickname.ValueMember = "UserId"
        _colNickname.DisplayMember = "Nickname"
        _colNickname.Width = 100
        _colNickname.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        _colNickname.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        _colNickname.SortMode = DataGridViewColumnSortMode.NotSortable
        dgvDetail.Columns.Insert(3, _colNickname)

        Me.bsSecUserLog.DataSource = Me.dsMonitoring
        Me.bsSecUserLog.DataMember = dtSecUserLog.TableName

        'pic table
        Me.bsTransactionUser.DataSource = Me.dsMonitoring
        Me.bsTransactionUser.DataMember = dtSecUserPic.TableName
        Me.bsTransactionUser.Filter = String.Format("WorkgroupId IN (6, 5, 4, 28, 29, 30, 33)") 'technician, sr technician, sr engineer, OJT, asv, sv, assistant
        dgvPic.AutoGenerateColumns = False
        dgvPic.DataSource = Me.bsTransactionUser

        FillTransactionStatus()
        FillArea()
        FillApprovers()
        FillApproversAction()

        If trxId = 0 Then
            Me.Text = "New Activity Entry"

            rowRoutingStatus = Me.dsMonitoring.GenRoutingStatus.FindByRoutingStatusId(5)
            txtRoutingStatus.Text = rowRoutingStatus.RoutingStatusName.ToString.Trim

            cmbTransactionStatus.SelectedValue = 1
            txtTransactionId.Text = "(new)"
            txtTransactionDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", dbMethod.GetServerDate)
            FillMachine(True)
            FillJig(True)

            Me.bsTransactionDetail.DataSource = Me.dsMonitoring
            Me.bsTransactionDetail.DataMember = dtTransactionDetail.TableName
            Me.bsTransactionDetail.Filter = String.Format("TrxId IS NULL")
            dgvDetail.AutoGenerateColumns = False
            dgvDetail.DataSource = Me.bsTransactionDetail

            btnDelete.Enabled = False
            Me.ActiveControl = cmbMachineName

        Else
            If superiorWorkgroupId.Contains(workgroupId) Then
                btnDelete.Enabled = True
            Else
                btnDelete.Enabled = False
            End If

            FillMachine(False)
            FillJig(False)

            'transaction header
            Me.adpTransactionHeader.FillMntTransactionHeaderByTrxId(Me.dsMonitoring.MntTransactionHeader, trxId)
            Me.bsTransactionHeader.DataSource = Me.dsMonitoring
            Me.bsTransactionHeader.DataMember = dtTransactionHeader.TableName
            Me.bsTransactionHeader.Position = Me.bsTransactionHeader.Find("TrxId", _trxId)

            rowRoutingStatus = Me.dsMonitoring.GenRoutingStatus.FindByRoutingStatusId(CType(Me.bsTransactionHeader.Current, DataRowView).Item("RoutingStatusId"))
            txtRoutingStatus.Text = rowRoutingStatus.RoutingStatusName.ToString.Trim

            cmbTransactionStatus.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "TrxStatusId"))
            txtTransactionId.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "TrxId", False))
            trxDate = New Binding("Text", Me.bsTransactionHeader.Current, "TrxDate")
            txtTransactionDate.DataBindings.Add(trxDate)

            If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId") Is DBNull.Value Then
                origMachineId = CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId")
                cmbDowntimeStatus.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "DowntimeMachineStatusId"))
                cmbDowntimeSubStatus.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "DowntimeMachineSubStatusId"))
            End If

            If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("JigId") Is DBNull.Value Then
                origJigId = CType(Me.bsTransactionHeader.Current, DataRowView).Item("JigId")
                cmbDowntimeStatus.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "DowntimeJigStatusId"))
            End If

            cmbMachineName.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "MachineId"))
            cmbJigName.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "JigId"))
            cmbArea.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "AreaId"))

            txtProblem.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "Problem"))
            txtRootCause.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "RootCause"))
            txtActionTaken.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "ActionTaken"))

            If CType(Me.bsTransactionHeader.Current, DataRowView).Item("TotalAccumulatedRuntime") Is DBNull.Value Then
                txtRuntimeAccumulated.Text = String.Empty
            Else
                txtRuntimeAccumulated.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "TotalAccumulatedRuntime"))
            End If

            txtDowntimeAccumulated.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "TotalAccumulatedDowntime"))
            txtJoNumber.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "JoNumber"))
            txtJoRequestor.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "JoRequestor"))
            picImage.DataBindings.Add(New Binding("Image", Me.bsTransactionHeader.Current, "Image", True))
            txtImageName.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "ImageName"))

            If CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverIsApproved1") = True Then
                cmbApproverStatus1.SelectedValue = 1
            Else
                If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverDate1") Is DBNull.Value Then
                    cmbApproverStatus1.SelectedValue = 2
                Else
                    cmbApproverStatus1.SelectedValue = 0
                End If
            End If

            If CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverIsApproved2") = True Then
                cmbApproverStatus2.SelectedValue = 1
            Else
                If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverDate2") Is DBNull.Value Then
                    cmbApproverStatus2.SelectedValue = 2
                Else
                    cmbApproverStatus2.SelectedValue = 0
                End If
            End If

            If CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverIsApproved3") = True Then
                cmbApproverStatus3.SelectedValue = 1
            Else
                If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverDate3") Is DBNull.Value Then
                    cmbApproverStatus3.SelectedValue = 2
                Else
                    cmbApproverStatus3.SelectedValue = 0
                End If
            End If

            cmbApproverName1.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "ApproverId1"))
            approverDate1 = New Binding("Text", Me.bsTransactionHeader.Current, "ApproverDate1")
            txtApproverDateApproved1.DataBindings.Add(approverDate1)
            txtApproverRemarks1.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "ApproverRemarks1"))

            cmbApproverName2.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "ApproverId2"))
            approverDate2 = New Binding("Text", Me.bsTransactionHeader.Current, "ApproverDate2")
            txtApproverDateApproved2.DataBindings.Add(approverDate2)
            txtApproverRemarks2.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "ApproverRemarks2"))

            cmbApproverName3.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "ApproverId3"))
            approverDate3 = New Binding("Text", Me.bsTransactionHeader.Current, "ApproverDate3")
            txtApproverDateApproved3.DataBindings.Add(approverDate3)
            txtApproverRemarks3.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "ApproverRemarks3"))

            'transaction detail
            Me.adpTransactionDetail.FillMntTransactionDetailByTrxId(Me.dsMonitoring.MntTransactionDetail, trxId)
            Me.bsTransactionDetail.DataSource = Me.dsMonitoring
            Me.bsTransactionDetail.DataMember = dtTransactionDetail.TableName
            Me.bsTransactionDetail.Position = Me.bsTransactionDetail.Find("TrxId", _trxId)
            Me.bsTransactionDetail.Sort = "TrxFrom"
            dgvDetail.AutoGenerateColumns = False
            dgvDetail.DataSource = Me.bsTransactionDetail

            'transaction machine part
            Me.adpTransactionMachinePart.Fill(Me.dsMonitoring.MntTransactionMachinePart)
            Me.bsTransactionMachinePart.DataSource = Me.dsMonitoring
            Me.bsTransactionMachinePart.DataMember = dtTransactionMachinePart.TableName
            Me.bsTransactionMachinePart.Position = Me.bsTransactionMachinePart.Find("TrxId", trxId)

            If Not CType(Me.bsTransactionMachinePart.Current, DataRowView).Item("MachinePartId") Is DBNull.Value Then
                cmbMachinePart.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionMachinePart.Current, "MachinePartId"))
            End If

            'transaction spare part
            Me.adpTransactionSparePart.Fill(Me.dsMonitoring.MntTransactionSparePart)
            Me.bsTransactionSparePart.DataSource = Me.dsMonitoring
            Me.bsTransactionSparePart.DataMember = dtTransactionSparePart.TableName
            Me.bsTransactionSparePart.Position = Me.bsTransactionSparePart.Find("TrxId", trxId)

            txtPartsReplaced.DataBindings.Add(New Binding("Text", Me.bsTransactionSparePart.Current, "SparePartName"))
            txtPartNo.DataBindings.Add(New Binding("Text", Me.bsTransactionSparePart.Current, "SparePartNo"))

            'transaction user
            dtTransactionUser = Me.adpTransactionUser.GetDataByTrxId(trxId)

            FillPic()
        End If
    End Sub

    Private Sub frmMntTrxDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dbMain.EnableDoubleBuffered(dgvDetail)
            dbMain.EnableDoubleBuffered(dgvPic)

            If trxId = 0 Then
                ResetForm()
            Else
                Me.Text = "Activity No. " & txtTransactionId.Text

                If CType(Me.bsTransactionHeader.Current, DataRowView).Item("TrxStatusId") = 1 Then 'existing done
                    If isAdmin Then
                        cmbApproverStatus1.Enabled = True
                        cmbApproverName1.Enabled = True
                        txtApproverRemarks1.ReadOnly = False

                        cmbApproverStatus2.Enabled = True
                        cmbApproverName2.Enabled = True
                        txtApproverRemarks2.ReadOnly = False

                        cmbApproverStatus3.Enabled = True
                        cmbApproverName3.Enabled = True
                        txtApproverRemarks3.ReadOnly = False

                        Me.ActiveControl = txtActionTaken
                        txtActionTaken.Select(txtActionTaken.Text.Trim.Length, 0)

                    ElseIf superiorWorkgroupId.Contains(workgroupId) Then
                        If userId.Equals(cmbApproverName1.SelectedValue) AndAlso rowRoutingStatus.RoutingStatusId = 4 Then 'opened by asv
                            cmbApproverStatus1.Enabled = True
                            cmbApproverName1.Enabled = False
                            txtApproverRemarks1.ReadOnly = False

                            cmbApproverStatus2.Enabled = False
                            cmbApproverName2.Enabled = False
                            txtApproverRemarks2.ReadOnly = True

                            cmbApproverStatus3.Enabled = False
                            cmbApproverName3.Enabled = False
                            txtApproverRemarks3.ReadOnly = True

                            Me.ActiveControl = txtApproverRemarks1
                            txtApproverRemarks1.Select(txtApproverRemarks1.Text.Trim.Length, 0)

                        ElseIf userId.Equals(cmbApproverName2.SelectedValue) AndAlso rowRoutingStatus.RoutingStatusId = 3 Then 'opened by sv
                            cmbApproverStatus1.Enabled = False
                            cmbApproverName1.Enabled = False
                            txtApproverRemarks1.ReadOnly = True

                            cmbApproverStatus2.Enabled = True
                            cmbApproverName2.Enabled = False
                            txtApproverRemarks2.ReadOnly = False

                            cmbApproverStatus3.Enabled = False
                            cmbApproverName3.Enabled = False
                            txtApproverRemarks3.ReadOnly = True

                            Me.ActiveControl = txtApproverRemarks2
                            txtApproverRemarks2.Select(txtApproverRemarks2.Text.Trim.Length, 0)

                        ElseIf userId.Equals(cmbApproverName3.SelectedValue) AndAlso rowRoutingStatus.RoutingStatusId = 2 Then 'opened by sr mngr
                            cmbApproverStatus1.Enabled = False
                            cmbApproverName1.Enabled = False
                            txtApproverRemarks1.ReadOnly = True

                            cmbApproverStatus2.Enabled = False
                            cmbApproverName2.Enabled = False
                            txtApproverRemarks2.ReadOnly = True

                            cmbApproverStatus3.Enabled = True
                            cmbApproverName3.Enabled = False
                            txtApproverRemarks3.ReadOnly = False

                            Me.ActiveControl = txtApproverRemarks3
                            txtApproverRemarks3.Select(txtApproverRemarks3.Text.Trim.Length, 0)

                        Else
                            cmbApproverStatus1.Enabled = False
                            cmbApproverName1.Enabled = False
                            txtApproverRemarks1.ReadOnly = True

                            cmbApproverStatus2.Enabled = False
                            cmbApproverName2.Enabled = False
                            txtApproverRemarks2.ReadOnly = True

                            cmbApproverStatus3.Enabled = False
                            cmbApproverName3.Enabled = False
                            txtApproverRemarks3.ReadOnly = True

                            Me.ActiveControl = txtActionTaken
                            txtActionTaken.Select(txtActionTaken.Text.Trim.Length, 0)
                        End If

                    Else 'opened by technicians or others
                        cmbApproverStatus1.Enabled = False
                        cmbApproverName1.Enabled = False
                        txtApproverRemarks1.ReadOnly = True

                        cmbApproverStatus2.Enabled = False
                        cmbApproverName2.Enabled = False
                        txtApproverRemarks2.ReadOnly = True

                        cmbApproverStatus3.Enabled = False
                        cmbApproverName3.Enabled = False
                        txtApproverRemarks3.ReadOnly = True

                        If CType(Me.bsTransactionHeader.Current, DataRowView).Item("RoutingStatusId") < 2 Then
                            cmbTransactionStatus.Enabled = False
                            cmbMachineName.Enabled = False
                            cmbJigName.Enabled = False
                            cmbArea.Enabled = False
                            cmbMachinePart.Enabled = False
                            cmbDowntimeStatus.Enabled = False
                            txtProblem.ReadOnly = True
                            txtRootCause.ReadOnly = True
                            txtActionTaken.ReadOnly = True
                            txtPartsReplaced.ReadOnly = True
                            txtPartNo.ReadOnly = True
                            txtJoNumber.ReadOnly = True
                            txtJoRequestor.ReadOnly = True

                            dgvPic.Enabled = False

                            btnAddRow.Enabled = False
                            btnRemoveRow.Enabled = False
                            btnBrowse.Enabled = False
                            btnRemove.Enabled = False
                        End If

                        Me.ActiveControl = txtActionTaken
                        txtActionTaken.Select(txtActionTaken.Text.Trim.Length, 0)
                    End If

                Else 'existing on-going
                    If CType(Me.bsTransactionSparePart.Current, DataRowView).Item("SparePartName") Is DBNull.Value Then
                        txtPartNo.Enabled = False
                    Else
                        txtPartNo.Enabled = True
                    End If

                    If isAdmin Then
                        cmbApproverStatus1.Enabled = True
                        cmbApproverName1.Enabled = True
                        txtApproverRemarks1.ReadOnly = False

                        cmbApproverStatus2.Enabled = True
                        cmbApproverName2.Enabled = True
                        txtApproverRemarks2.ReadOnly = False

                        cmbApproverStatus3.Enabled = True
                        cmbApproverName3.Enabled = True
                        txtApproverRemarks3.ReadOnly = False

                        Me.ActiveControl = txtActionTaken
                        txtActionTaken.Select(txtActionTaken.Text.Trim.Length, 0)

                    ElseIf superiorWorkgroupId.Contains(workgroupId) Then
                        If userId.Equals(cmbApproverName1.SelectedValue) AndAlso rowRoutingStatus.RoutingStatusId = 4 Then 'opened by asv
                            cmbApproverStatus1.Enabled = True
                            cmbApproverName1.Enabled = False
                            txtApproverRemarks1.ReadOnly = False

                            cmbApproverStatus2.Enabled = False
                            cmbApproverName2.Enabled = False
                            txtApproverRemarks2.ReadOnly = True

                            cmbApproverStatus3.Enabled = False
                            cmbApproverName3.Enabled = False
                            txtApproverRemarks3.ReadOnly = True

                            Me.ActiveControl = txtApproverRemarks1
                            txtApproverRemarks1.Select(txtApproverRemarks1.Text.Trim.Length, 0)

                        ElseIf userId.Equals(cmbApproverName2.SelectedValue) AndAlso rowRoutingStatus.RoutingStatusId = 3 Then 'opened by sv
                            cmbApproverStatus1.Enabled = False
                            cmbApproverName1.Enabled = False
                            txtApproverRemarks1.ReadOnly = True

                            cmbApproverStatus2.Enabled = True
                            cmbApproverName2.Enabled = False
                            txtApproverRemarks2.ReadOnly = False

                            cmbApproverStatus3.Enabled = False
                            cmbApproverName3.Enabled = False
                            txtApproverRemarks3.ReadOnly = True

                            Me.ActiveControl = txtApproverRemarks2
                            txtApproverRemarks2.Select(txtApproverRemarks2.Text.Trim.Length, 0)

                        ElseIf userId.Equals(cmbApproverName2.SelectedValue) AndAlso rowRoutingStatus.RoutingStatusId = 2 Then 'opened by sr mngr
                            cmbApproverStatus1.Enabled = False
                            cmbApproverName1.Enabled = False
                            txtApproverRemarks1.ReadOnly = True

                            cmbApproverStatus2.Enabled = False
                            cmbApproverName2.Enabled = False
                            txtApproverRemarks2.ReadOnly = True

                            cmbApproverStatus3.Enabled = True
                            cmbApproverName3.Enabled = False
                            txtApproverRemarks3.ReadOnly = False

                            Me.ActiveControl = txtApproverRemarks3
                            txtApproverRemarks3.Select(txtApproverRemarks3.Text.Trim.Length, 0)
                        End If

                    Else 'opened by technicians
                        cmbApproverStatus1.Enabled = False
                        cmbApproverName1.Enabled = True
                        txtApproverRemarks1.ReadOnly = True

                        cmbApproverStatus2.Enabled = False
                        cmbApproverName2.Enabled = True
                        txtApproverRemarks2.ReadOnly = True

                        cmbApproverStatus3.Enabled = False
                        cmbApproverName3.Enabled = True
                        txtApproverRemarks3.ReadOnly = True

                        Me.ActiveControl = txtActionTaken
                        txtActionTaken.Select(txtActionTaken.Text.Trim.Length, 0)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMntTrxDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            e.Handled = True
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)

        ElseIf e.KeyCode.Equals(Keys.F8) Then
            e.Handled = True
            If isAdmin Or superiorWorkgroupId.Contains(workgroupId) Then
                If btnDelete.Enabled = True Then
                    btnDelete.PerformClick()
                End If
            Else
                If btnDelete.Enabled = True Then
                    btnDelete.PerformClick()
                End If
            End If

        ElseIf e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            If isAdmin Or superiorWorkgroupId.Contains(workgroupId) Then
                If btnSave.Enabled = True Then
                    btnSave.PerformClick()
                End If
            Else
                If btnSave.Enabled = True Then
                    btnSave.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub cmbMachineName_TextChanged(sender As Object, e As EventArgs) Handles cmbMachineName.TextChanged
        Try
            If cmbMachineName.Text.Trim.Length > 0 Then
                cmbJigName.Enabled = False
                cmbJigName.SelectedValue = 0
            Else
                cmbJigName.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachineName_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMachineName.SelectedValueChanged
        Try
            If trxId = 0 Then
                If Not cmbMachineName.SelectedValue = 0 Then
                    GetMachineInformation(cmbMachineName.SelectedValue)
                    FillDowntimeStatus()
                    FillDowntimeSubStatus()

                    If trxId = 0 Then
                        cmbDowntimeStatus.SelectedValue = 3
                    End If

                    txtPartsReplaced.Enabled = True
                Else
                    cmbArea.SelectedValue = 0

                    cmbMachinePart.DataSource = Nothing
                    cmbMachinePart.Items.Clear()
                    cmbMachinePart.Enabled = False

                    cmbDowntimeStatus.DataSource = Nothing
                    cmbDowntimeStatus.Items.Clear()
                    cmbDowntimeStatus.Enabled = False

                    cmbDowntimeSubStatus.DataSource = Nothing
                    cmbDowntimeSubStatus.Items.Clear()
                    cmbDowntimeSubStatus.Enabled = False

                    txtPartsReplaced.Enabled = False
                End If
            Else
                If Not cmbMachineName.SelectedValue = 0 Then
                    GetMachineInformation(cmbMachineName.SelectedValue)
                    FillDowntimeStatus()
                    FillDowntimeSubStatus()
                Else
                    If Not cmbJigName.SelectedValue = 0 Then
                        cmbArea.Enabled = False
                    Else
                        cmbArea.Enabled = True
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachineName_Validated(sender As Object, e As EventArgs) Handles cmbMachineName.Validated
        Try
            If trxId = 0 Then
                If Not cmbMachineName.SelectedValue = 0 Then
                    GetMachineInformation(cmbMachineName.SelectedValue)
                    GetTotalRuntime(cmbMachineName.SelectedValue)

                    cmbDowntimeStatus.SelectedValue = 3

                    txtPartsReplaced.Enabled = True
                Else
                    cmbMachineName.SelectedValue = 0
                    cmbMachineName.Text = String.Empty

                    If Not cmbJigName.SelectedValue = 0 Then
                        cmbArea.Enabled = False
                    Else
                        cmbArea.Enabled = True
                    End If

                    cmbMachinePart.DataSource = Nothing
                    cmbMachinePart.Items.Clear()
                    cmbMachinePart.Enabled = False

                    cmbDowntimeStatus.DataSource = Nothing
                    cmbDowntimeStatus.Items.Clear()
                    cmbDowntimeStatus.Enabled = False

                    cmbDowntimeSubStatus.DataSource = Nothing
                    cmbDowntimeSubStatus.Items.Clear()
                    cmbDowntimeSubStatus.Enabled = False

                    txtPartsReplaced.Enabled = False
                End If
            Else
                If Not cmbMachineName.SelectedValue = origMachineId Then
                    GetTotalRuntime(cmbMachineName.SelectedValue)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbJigName_TextChanged(sender As Object, e As EventArgs) Handles cmbJigName.TextChanged
        Try
            If cmbJigName.Text.Trim.Length > 0 Then
                cmbMachineName.Enabled = False
                cmbMachineName.SelectedValue = 0
            Else
                cmbMachineName.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbJigName_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbJigName.SelectedValueChanged
        Try
            If trxId = 0 Then
                If Not cmbJigName.SelectedValue = 0 Then
                    GetJigInformation(cmbJigName.SelectedValue)
                    FillDowntimeStatus()

                    If trxId = 0 Then
                        cmbDowntimeStatus.SelectedValue = 3
                    End If

                    cmbMachinePart.DataSource = Nothing
                    cmbMachinePart.Items.Clear()
                    cmbMachinePart.Enabled = False

                    cmbDowntimeSubStatus.DataSource = Nothing
                    cmbDowntimeSubStatus.Items.Clear()
                    cmbDowntimeSubStatus.Enabled = False

                    txtPartsReplaced.Enabled = True
                Else
                    If Not cmbMachineName.SelectedValue = 0 Then
                        cmbArea.Enabled = False
                    Else
                        cmbArea.Enabled = True
                    End If

                    cmbMachinePart.DataSource = Nothing
                    cmbMachinePart.Items.Clear()
                    cmbMachinePart.Enabled = False

                    cmbDowntimeStatus.DataSource = Nothing
                    cmbDowntimeStatus.Items.Clear()
                    cmbDowntimeStatus.Enabled = False

                    cmbDowntimeSubStatus.DataSource = Nothing
                    cmbDowntimeSubStatus.Items.Clear()
                    cmbDowntimeSubStatus.Enabled = False

                    txtPartsReplaced.Enabled = False
                End If

            Else
                If Not cmbJigName.SelectedValue = 0 Then
                    GetJigInformation(cmbJigName.SelectedValue)
                    FillDowntimeStatus()

                    cmbMachinePart.DataSource = Nothing
                    cmbMachinePart.Items.Clear()
                    cmbMachinePart.Enabled = False

                    cmbDowntimeSubStatus.DataSource = Nothing
                    cmbDowntimeSubStatus.Items.Clear()
                    cmbDowntimeSubStatus.Enabled = False
                Else
                    If Not cmbMachineName.SelectedValue = 0 Then
                        cmbArea.Enabled = False
                    Else
                        cmbArea.Enabled = True
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbJigName_Validated(sender As Object, e As EventArgs) Handles cmbJigName.Validated
        Try
            If trxId = 0 Then
                If Not cmbJigName.SelectedValue = 0 Then
                    GetJigInformation(cmbJigName.SelectedValue)
                    GetTotalRuntime(cmbJigName.SelectedValue)

                    cmbMachinePart.DataSource = Nothing
                    cmbMachinePart.Items.Clear()
                    cmbMachinePart.Enabled = False

                    cmbDowntimeSubStatus.DataSource = Nothing
                    cmbDowntimeSubStatus.Items.Clear()
                    cmbDowntimeSubStatus.Enabled = False

                    cmbDowntimeStatus.SelectedValue = 3

                    txtPartsReplaced.Enabled = True
                Else
                    cmbJigName.SelectedValue = 0
                    cmbJigName.Text = String.Empty

                    If Not cmbMachineName.SelectedValue = 0 Then
                        cmbMachineName.Enabled = False
                    Else
                        cmbArea.Enabled = True
                    End If

                    cmbMachinePart.DataSource = Nothing
                    cmbMachinePart.Items.Clear()
                    cmbMachinePart.Enabled = False

                    cmbDowntimeStatus.DataSource = Nothing
                    cmbDowntimeStatus.Items.Clear()
                    cmbDowntimeStatus.Enabled = False

                    cmbDowntimeSubStatus.DataSource = Nothing
                    cmbDowntimeSubStatus.Items.Clear()
                    cmbDowntimeSubStatus.Enabled = False

                    txtPartsReplaced.Enabled = False
                End If

            Else
                If Not cmbJigName.SelectedValue = origMachineId Then
                    GetTotalRuntime(cmbJigName.SelectedValue)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachinePart_Validated(sender As Object, e As EventArgs) Handles cmbMachinePart.Validated
        Try
            If cmbMachinePart.SelectedValue = 0 Then
                cmbMachinePart.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbDowntimeStatus_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDowntimeStatus.SelectedValueChanged
        Try
            If Not cmbMachineName.SelectedValue = 0 Then
                FillDowntimeSubStatus()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvPic_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvPic.DataBindingComplete
        For Each _row As DataRow In dtTransactionUser.Rows
            For _i As Integer = 0 To dgvPic.Rows.Count - 1
                If dgvPic.Rows(_i).Cells("ColUserId").Value = _row("UserId") Then
                    dgvPic.Rows(_i).Cells("ColIsSelected").Value = True
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

            If Not cmbMachineName.SelectedValue = 0 AndAlso cmbMachinePart.SelectedValue = 0 AndAlso cmbMachinePart.Enabled = True Then
                MessageBox.Show("Please select machine part.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbMachinePart.Focus()
                Return
            End If

            If (Not cmbMachineName.SelectedValue = 0 Or Not cmbJigName.SelectedValue = 0) AndAlso cmbDowntimeStatus.SelectedValue = 0 Then
                MessageBox.Show("Please select downtime status.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbDowntimeStatus.Focus()
                Return
            End If

            If (Not cmbMachineName.SelectedValue = 0) AndAlso cmbDowntimeSubStatus.SelectedValue = 0 Then
                MessageBox.Show("Please select downtime sub-status.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbDowntimeSubStatus.Focus()
                Return
            End If

            If Not String.IsNullOrEmpty(txtPartsReplaced.Text.Trim) AndAlso String.IsNullOrEmpty(txtPartNo.Text.Trim) Then
                MessageBox.Show("Please indicate spare part number.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPartNo.Focus()
                Return
            End If

            If Not dgvDetail.Rows.Count > 0 Then
                MessageBox.Show("Please input technician log.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btnAddRow.Focus()
                Return
            End If

            If cmbApproverName3.SelectedValue = 0 Then
                MessageBox.Show("Please select last approver.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbApproverName3.Focus()
                Return
            End If

            'new transaction
            If trxId = 0 Then
                Dim _newRowHeader As MntTransactionHeaderRow = Me.dsMonitoring.MntTransactionHeader.NewMntTransactionHeaderRow
                Dim _newRowDetail As MntTransactionDetailRow = Me.dsMonitoring.MntTransactionDetail.NewMntTransactionDetailRow
                Dim _newRowMachinePart As MntTransactionMachinePartRow = Me.dsMonitoring.MntTransactionMachinePart.NewMntTransactionMachinePartRow
                Dim _newRowSparePart As MntTransactionSparePartRow = Me.dsMonitoring.MntTransactionSparePart.NewMntTransactionSparePartRow
                Dim _newRowUser As MntTransactionUserRow = Me.dsMonitoring.MntTransactionUser.NewMntTransactionUserRow

                'transaction header
                With _newRowHeader
                    'common columns to machine, jig and other activity - disregarding transaction status
                    .TrxDate = dbMethod.GetServerDate

                    If Not cmbMachineName.SelectedValue = 0 Then
                        .MachineId = cmbMachineName.SelectedValue
                        .DowntimeMachineStatusId = cmbDowntimeStatus.SelectedValue
                        .DowntimeMachineSubStatusId = cmbDowntimeSubStatus.SelectedValue
                        .SetJigIdNull()
                        .SetDowntimeJigStatusIdNull()
                    End If

                    If Not cmbJigName.SelectedValue = 0 Then
                        .JigId = cmbJigName.SelectedValue
                        .DowntimeJigStatusId = cmbDowntimeStatus.SelectedValue
                        .SetMachineIdNull()
                        .SetDowntimeMachineStatusIdNull()
                        .SetDowntimeMachineSubStatusIdNull()
                    End If

                    If cmbMachineName.SelectedValue = 0 AndAlso cmbJigName.SelectedValue = 0 Then
                        .SetMachineIdNull()
                        .SetJigIdNull()
                        .SetDowntimeMachineStatusIdNull()
                        .SetDowntimeMachineSubStatusIdNull()
                        .SetDowntimeJigStatusIdNull()
                    End If

                    .AreaId = cmbArea.SelectedValue

                    If txtRuntimeAccumulated.Text.Trim = "" Then
                        .SetTotalAccumulatedRuntimeNull()
                    Else
                        .TotalAccumulatedRuntime = txtRuntimeAccumulated.Text.Trim
                    End If

                    .TotalAccumulatedDowntime = txtDowntimeAccumulated.Text.Trim
                    .DatetimeStarted = dgvDetail.Rows(0).Cells("ColTrxFrom").Value
                    .DatetimeEnded = dgvDetail.Rows(_rowCount - 1).Cells("ColTrxTo").Value
                    .EncodeUserId = userId
                    .UserId = dgvDetail.Rows(_rowCount - 1).Cells("ColUserIdLog").Value
                    .ShiftId = dgvDetail.Rows(_rowCount - 1).Cells("ColShiftId").Value
                    .ApproverIsApproved1 = 0
                    .ApproverIsApproved2 = 0
                    .ApproverIsApproved3 = 0

                    If cmbApproverName1.SelectedValue = 0 Then
                        .SetApproverId1Null()
                    Else
                        If workgroupId.Equals(29) Then
                            cmbApproverName1.SelectedValue = 0
                        Else
                            .ApproverId1 = cmbApproverName1.SelectedValue
                        End If
                    End If

                    If cmbApproverName2.SelectedValue = 0 Then
                        .SetApproverId2Null()
                    Else
                        If workgroupId.Equals(30) Then
                            cmbApproverName1.SelectedValue = 0
                            cmbApproverName2.SelectedValue = 0
                        Else
                            .ApproverId2 = cmbApproverName2.SelectedValue
                        End If
                    End If

                    .ApproverId3 = cmbApproverName3.SelectedValue

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

                    .SetFileAttachmentNull()
                    .SetFileNameNull()
                    .ModifiedBy = userId
                    .ModifiedDate = dbMethod.GetServerDate

                    'transaction status - done
                    If cmbTransactionStatus.SelectedValue = 1 Then
                        .TrxStatusId = 1

                        If cmbApproverName1.SelectedValue = 0 Then
                            If cmbApproverName2.SelectedValue = 0 Then
                                .RoutingStatusId = 2
                            Else
                                .RoutingStatusId = 3
                            End If
                        Else
                            .RoutingStatusId = 4
                        End If

                        If Not cmbMachineName.SelectedValue = 0 Then
                            'scheduled
                            If cmbDowntimeStatus.SelectedValue = 2 Then
                                If Not String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    .Problem = txtProblem.Text.Trim
                                Else
                                    .SetProblemNull()
                                End If

                                If Not String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                    .RootCause = txtRootCause.Text.Trim
                                Else
                                    .SetRootCauseNull()
                                End If

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If

                                'unscheduled
                            ElseIf cmbDowntimeStatus.SelectedValue = 3 Then
                                If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtProblem.Focus()
                                    Return
                                Else
                                    .Problem = txtProblem.Text.Trim
                                End If

                                If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                    MessageBox.Show("Please indicate the root cause.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtRootCause.Focus()
                                    Return
                                Else
                                    .RootCause = txtRootCause.Text.Trim
                                End If

                                If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    MessageBox.Show("Please indicate the action taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtActionTaken.Focus()
                                    Return
                                Else
                                    .ActionTaken = txtActionTaken.Text.Trim
                                End If
                            End If

                            .DowntimeMachineStatusId = cmbDowntimeStatus.SelectedValue
                            .DowntimeMachineSubStatusId = cmbDowntimeSubStatus.SelectedValue
                        End If

                        If Not cmbJigName.SelectedValue = 0 Then
                            'scheduled
                            If cmbDowntimeStatus.SelectedValue = 2 Then
                                If Not String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    .Problem = txtProblem.Text.Trim
                                Else
                                    .SetProblemNull()
                                End If

                                If Not String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                    .RootCause = txtRootCause.Text.Trim
                                Else
                                    .SetRootCauseNull()
                                End If

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If

                                'unscheduled
                            ElseIf cmbDowntimeStatus.SelectedValue = 3 Or cmbDowntimeStatus.SelectedValue = 4 Then
                                If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtProblem.Focus()
                                    Return
                                Else
                                    .Problem = txtProblem.Text.Trim
                                End If

                                If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                    MessageBox.Show("Please indicate the root cause.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtRootCause.Focus()
                                    Return
                                Else
                                    .RootCause = txtRootCause.Text.Trim
                                End If

                                If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    MessageBox.Show("Please indicate the action taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtActionTaken.Focus()
                                    Return
                                Else
                                    .ActionTaken = txtActionTaken.Text.Trim
                                End If
                            End If

                            .DowntimeJigStatusId = cmbDowntimeStatus.SelectedValue
                            .SetDowntimeMachineSubStatusIdNull()
                        End If

                        If cmbMachineName.SelectedValue = 0 AndAlso cmbJigName.SelectedValue = 0 Then
                            If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtProblem.Focus()
                                Return
                            Else
                                .Problem = txtProblem.Text.Trim
                            End If

                            If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                MessageBox.Show("Please indicate the root cause.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtRootCause.Focus()
                                Return
                            Else
                                .RootCause = txtRootCause.Text.Trim
                            End If

                            If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                MessageBox.Show("Please indicate the action taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtActionTaken.Focus()
                                Return
                            Else
                                .ActionTaken = txtActionTaken.Text.Trim
                            End If
                        End If

                        If picImage.Image Is Nothing Then
                            MessageBox.Show("Please attach an image.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            btnBrowse.Focus()
                            Return
                        End If

                        Dim _resized As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                        _resized.Save(memoStream, ImageFormat.Jpeg)
                        bite = memoStream.GetBuffer()
                        .Image = bite
                        .ImageName = txtImageName.Text.Trim

                        'transaction status - on-going
                    Else
                        .TrxStatusId = 2
                        .RoutingStatusId = 5

                        If Not cmbMachineName.SelectedValue = 0 Then
                            Dim _prmMachineStatus(2) As SqlParameter
                            _prmMachineStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                            _prmMachineStatus(0).Value = cmbMachineName.SelectedValue
                            _prmMachineStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                            _prmMachineStatus(1).Value = cmbDowntimeStatus.SelectedValue
                            _prmMachineStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                            _prmMachineStatus(2).Value = cmbDowntimeSubStatus.SelectedValue

                            dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, _prmMachineStatus)

                            'scheduled
                            If cmbDowntimeStatus.SelectedValue = 2 Then
                                If Not String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    .Problem = txtProblem.Text.Trim
                                Else
                                    .SetProblemNull()
                                End If

                                If Not String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                    .RootCause = txtRootCause.Text.Trim
                                Else
                                    .SetRootCauseNull()
                                End If

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If

                                'unscheduled
                            ElseIf cmbDowntimeStatus.SelectedValue = 3 Then
                                If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtProblem.Focus()
                                    Return
                                Else
                                    .Problem = txtProblem.Text.Trim
                                End If

                                If Not String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                    .RootCause = txtRootCause.Text.Trim
                                Else
                                    .SetRootCauseNull()
                                End If

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If
                            End If
                        End If

                        If Not cmbJigName.SelectedValue = 0 Then
                            Dim _prmJigStatus(1) As SqlParameter
                            _prmJigStatus(0) = New SqlParameter("@JigId", SqlDbType.Int)
                            _prmJigStatus(0).Value = cmbJigName.SelectedValue
                            _prmJigStatus(1) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                            _prmJigStatus(1).Value = cmbDowntimeStatus.SelectedValue

                            dbMethod.ExecuteNonQuery("UpdMntJigByJigStatusId", CommandType.StoredProcedure, _prmJigStatus)

                            'scheduled
                            If cmbDowntimeStatus.SelectedValue = 2 Then
                                If Not String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    .Problem = txtProblem.Text.Trim
                                Else
                                    .SetProblemNull()
                                End If

                                If Not String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                    .RootCause = txtRootCause.Text.Trim
                                Else
                                    .SetRootCauseNull()
                                End If

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If

                                'unscheduled
                            ElseIf cmbDowntimeStatus.SelectedValue = 3 Or cmbDowntimeStatus.SelectedValue = 4 Then
                                If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtProblem.Focus()
                                    Return
                                Else
                                    .Problem = txtProblem.Text.Trim
                                End If

                                If Not String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                    .RootCause = txtRootCause.Text.Trim
                                Else
                                    .SetRootCauseNull()
                                End If

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If
                            End If
                        End If

                        If cmbMachineName.SelectedValue = 0 AndAlso cmbJigName.SelectedValue = 0 Then
                            If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtProblem.Focus()
                                Return
                            Else
                                .Problem = txtProblem.Text.Trim
                            End If

                            If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                .SetRootCauseNull()
                            Else
                                .RootCause = txtRootCause.Text.Trim
                            End If

                            If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                .SetActionTakenNull()
                            Else
                                .ActionTaken = txtActionTaken.Text.Trim
                            End If
                        End If

                        If picImage.Image Is Nothing Then
                            .SetImageNull()
                            .SetImageNameNull()
                        Else
                            Dim _resized As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                            _resized.Save(memoStream, ImageFormat.Jpeg)
                            bite = memoStream.GetBuffer()
                            .Image = bite
                            .ImageName = txtImageName.Text.Trim
                        End If
                    End If
                End With
                Me.dsMonitoring.MntTransactionHeader.AddMntTransactionHeaderRow(_newRowHeader)
                Me.adpTransactionHeader.Update(Me.dsMonitoring.MntTransactionHeader)

                'transaction details
                For Each _dataRowView As DataRowView In Me.bsTransactionDetail
                    Dim _row = _dataRowView.Row
                    _row.Item("TrxId") = _newRowHeader.TrxId
                    'insert technicians from technician log to transaction user
                    Me.adpTransactionUser.Insert(_newRowHeader.TrxId, _row("UserId"))
                Next
                Me.Validate()
                Me.adpTransactionDetail.Update(Me.dsMonitoring.MntTransactionDetail)

                'transaction machine part
                With _newRowMachinePart
                    .TrxId = _newRowHeader.TrxId
                    If Not cmbMachineName.SelectedValue = 0 AndAlso Not cmbMachinePart.SelectedValue = 0 Then
                        .MachinePartId = cmbMachinePart.SelectedValue
                    Else
                        .SetMachinePartIdNull()
                    End If
                End With
                Me.dsMonitoring.MntTransactionMachinePart.AddMntTransactionMachinePartRow(_newRowMachinePart)
                Me.adpTransactionMachinePart.Update(Me.dsMonitoring.MntTransactionMachinePart)

                'transaction spare part
                With _newRowSparePart
                    .TrxId = _newRowHeader.TrxId
                    If String.IsNullOrEmpty(txtPartsReplaced.Text.Trim) Then
                        .SetSparePartNameNull()
                        .SetSparePartNoNull()
                    Else
                        .SparePartName = txtPartsReplaced.Text.Trim
                        .SparePartNo = txtPartNo.Text.Trim
                    End If
                End With
                Me.dsMonitoring.MntTransactionSparePart.AddMntTransactionSparePartRow(_newRowSparePart)
                Me.adpTransactionSparePart.Update(Me.dsMonitoring.MntTransactionSparePart)

                'transaction user
                'insert technicians from pic gridview to transaction user 
                For Each _row As DataGridViewRow In dgvPic.Rows
                    Dim _isSelected As Boolean = Convert.ToBoolean(_row.Cells("ColIsSelected").Value)
                    If _isSelected Then
                        Me.adpTransactionUser.Insert(_newRowHeader.TrxId, _row.Cells("ColUserId").Value)
                    End If
                Next

                'existing transaction
            Else
                Dim _rowHeader As MntTransactionHeaderRow = Me.dsMonitoring.MntTransactionHeader.FindByTrxId(trxId)

                With _rowHeader
                    If .RoutingStatusId = 5 Then 'on-going activity
                        If cmbApproverName1.SelectedValue = 0 Then
                            .SetApproverId1Null()
                        Else
                            .ApproverId1 = cmbApproverName1.SelectedValue
                        End If

                        If cmbApproverName2.SelectedValue = 0 Then
                            .SetApproverId2Null()
                        Else
                            .ApproverId2 = cmbApproverName2.SelectedValue
                        End If

                        .ApproverId3 = cmbApproverName3.SelectedValue
                    End If

                    If Not cmbMachineName.SelectedValue = 0 Then
                        .MachineId = cmbMachineName.SelectedValue
                        .DowntimeMachineStatusId = cmbDowntimeStatus.SelectedValue
                        .DowntimeMachineSubStatusId = cmbDowntimeSubStatus.SelectedValue
                        .SetJigIdNull()
                        .SetDowntimeJigStatusIdNull()
                    End If

                    If Not cmbJigName.SelectedValue = 0 Then
                        .JigId = cmbJigName.SelectedValue
                        .DowntimeJigStatusId = cmbDowntimeStatus.SelectedValue
                        .SetDowntimeMachineSubStatusIdNull()
                        .SetMachineIdNull()
                        .SetDowntimeMachineStatusIdNull()
                    End If

                    If cmbMachineName.SelectedValue = 0 AndAlso cmbJigName.SelectedValue = 0 Then
                        .SetMachineIdNull()
                        .SetJigIdNull()
                        .SetDowntimeMachineStatusIdNull()
                        .SetDowntimeMachineSubStatusIdNull()
                        .SetDowntimeJigStatusIdNull()
                    End If

                    .AreaId = cmbArea.SelectedValue

                    If String.IsNullOrEmpty(txtRuntimeAccumulated.Text.Trim) Then
                        .SetTotalAccumulatedRuntimeNull()
                    Else
                        .TotalAccumulatedRuntime = txtRuntimeAccumulated.Text.Trim
                    End If

                    .TotalAccumulatedDowntime = txtDowntimeAccumulated.Text.Trim
                    .DatetimeStarted = dgvDetail.Rows(0).Cells("ColTrxFrom").Value
                    .DatetimeEnded = dgvDetail.Rows(_rowCount - 1).Cells("ColTrxTo").Value
                    .UserId = dgvDetail.Rows(_rowCount - 1).Cells("ColUserIdLog").Value
                    .ShiftId = dgvDetail.Rows(_rowCount - 1).Cells("ColShiftId").Value

                    .ModifiedBy = userId
                    .ModifiedDate = dbMethod.GetServerDate

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

                    'existing transaction - done
                    If cmbTransactionStatus.SelectedValue = 1 Then
                        .TrxStatusId = 1

                        If Not cmbMachineName.SelectedValue = 0 Then
                            'preventive maintenance
                            If cmbDowntimeStatus.SelectedValue = 2 Then
                                If Not String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    .Problem = txtProblem.Text.Trim
                                Else
                                    .SetProblemNull()
                                End If

                                If Not String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                    .RootCause = txtRootCause.Text.Trim
                                Else
                                    .SetRootCauseNull()
                                End If

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If

                                'under repair
                            ElseIf cmbDowntimeStatus.SelectedValue = 3 Then
                                If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtProblem.Focus()
                                    Return
                                Else
                                    .Problem = txtProblem.Text.Trim
                                End If

                                If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                    MessageBox.Show("Please indicate the root cause.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtRootCause.Focus()
                                    Return
                                Else
                                    .RootCause = txtRootCause.Text.Trim
                                End If

                                If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    MessageBox.Show("Please indicate the action taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtActionTaken.Focus()
                                    Return
                                Else
                                    .ActionTaken = txtActionTaken.Text.Trim
                                End If

                            End If
                        End If

                        If Not cmbJigName.SelectedValue = 0 Then
                            'preventive maintenance
                            If cmbDowntimeStatus.SelectedValue = 2 Then
                                If Not String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    .Problem = txtProblem.Text.Trim
                                Else
                                    .SetProblemNull()
                                End If

                                If Not String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                    .RootCause = txtRootCause.Text.Trim
                                Else
                                    .SetRootCauseNull()
                                End If

                                If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    .ActionTaken = txtActionTaken.Text.Trim
                                Else
                                    .SetActionTakenNull()
                                End If

                                'under repair or under modification
                            ElseIf cmbDowntimeStatus.SelectedValue = 3 Or cmbDowntimeStatus.SelectedValue = 4 Then
                                If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                    MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtProblem.Focus()
                                    Return
                                Else
                                    .Problem = txtProblem.Text.Trim
                                End If

                                If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                    MessageBox.Show("Please indicate the root cause.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtRootCause.Focus()
                                    Return
                                Else
                                    .RootCause = txtRootCause.Text.Trim
                                End If

                                If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                    MessageBox.Show("Please indicate the action taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    txtActionTaken.Focus()
                                    Return
                                Else
                                    .ActionTaken = txtActionTaken.Text.Trim
                                End If

                            End If
                        End If

                        If cmbMachineName.SelectedValue = 0 AndAlso cmbJigName.SelectedValue = 0 Then
                            If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtProblem.Focus()
                                Return
                            Else
                                .Problem = txtProblem.Text.Trim
                            End If

                            If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                MessageBox.Show("Please indicate the root cause.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtRootCause.Focus()
                                Return
                            Else
                                .RootCause = txtRootCause.Text.Trim
                            End If

                            If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                MessageBox.Show("Please indicate the action taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtActionTaken.Focus()
                                Return
                            Else
                                .ActionTaken = txtActionTaken.Text.Trim
                            End If
                        End If

                        If picImage.Image Is Nothing Then
                            MessageBox.Show("Please attach an image.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            btnBrowse.Focus()
                            Return
                        End If

                        Dim _resized As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                        _resized.Save(memoStream, ImageFormat.Jpeg)
                        bite = memoStream.GetBuffer()
                        .Image = bite
                        .ImageName = txtImageName.Text.Trim

                        If Not cmbMachineName.SelectedValue = 0 Then
                            Dim _prmMachineStatus(2) As SqlParameter
                            _prmMachineStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                            _prmMachineStatus(0).Value = cmbMachineName.SelectedValue
                            _prmMachineStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                            _prmMachineStatus(1).Value = 1
                            _prmMachineStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                            _prmMachineStatus(2).Value = 1

                            dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, _prmMachineStatus)
                        End If

                        If Not cmbJigName.SelectedValue = 0 Then
                            Dim _prmJigStatus(1) As SqlParameter
                            _prmJigStatus(0) = New SqlParameter("@JigId", SqlDbType.Int)
                            _prmJigStatus(0).Value = cmbJigName.SelectedValue
                            _prmJigStatus(1) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                            _prmJigStatus(1).Value = 1

                            dbMethod.ExecuteNonQuery("UpdMntJigByJigStatusId", CommandType.StoredProcedure, _prmJigStatus)
                        End If

                        'approver's action/routing
                        With _rowHeader
                            If userId.Equals(CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverId1")) AndAlso .RoutingStatusId = 4 Then
                                Select Case cmbApproverStatus1.SelectedValue
                                    Case 0

                                    Case 1
                                        .ApproverIsApproved1 = True

                                        If Not cmbApproverName2.SelectedValue = 0 Then
                                            .RoutingStatusId = 3
                                        Else
                                            .RoutingStatusId = 2
                                        End If

                                        .ApproverDate1 = dbMethod.GetServerDate

                                    Case 2
                                        .ApproverIsApproved1 = False
                                        .RoutingStatusId = 5
                                        .TrxStatusId = 2
                                        .ApproverDate1 = dbMethod.GetServerDate

                                End Select

                                If Not String.IsNullOrEmpty(txtApproverRemarks1.Text.Trim) Then
                                    .ApproverRemarks1 = txtApproverRemarks1.Text.Trim
                                Else
                                    .SetApproverRemarks1Null()
                                End If

                            ElseIf userId.Equals(CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverId2")) AndAlso .RoutingStatusId = 3 Then
                                Select Case cmbApproverStatus2.SelectedValue
                                    Case 0

                                    Case 1
                                        .ApproverIsApproved2 = True
                                        .RoutingStatusId = 2
                                        .ApproverDate2 = dbMethod.GetServerDate

                                    Case 2
                                        .ApproverIsApproved2 = False
                                        .RoutingStatusId = 5
                                        .TrxStatusId = 2
                                        .ApproverDate2 = dbMethod.GetServerDate

                                End Select

                                If Not String.IsNullOrEmpty(txtApproverRemarks2.Text.Trim) Then
                                    .ApproverRemarks2 = txtApproverRemarks2.Text.Trim
                                Else
                                    .SetApproverRemarks2Null()
                                End If

                            ElseIf userId.Equals(CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverId3")) AndAlso .RoutingStatusId = 2 Then
                                Select Case cmbApproverStatus3.SelectedValue
                                    Case 0

                                    Case 1
                                        .ApproverIsApproved3 = True
                                        .RoutingStatusId = 1
                                        .ApproverDate3 = dbMethod.GetServerDate

                                    Case 2
                                        .ApproverIsApproved3 = False
                                        .ApproverDate3 = dbMethod.GetServerDate
                                        .RoutingStatusId = 5
                                        .TrxStatusId = 2

                                End Select

                                If Not String.IsNullOrEmpty(txtApproverRemarks3.Text.Trim) Then
                                    .ApproverRemarks3 = txtApproverRemarks3.Text.Trim
                                Else
                                    .SetApproverRemarks3Null()
                                End If

                            ElseIf .RoutingStatusId = 5 Then
                                If Not cmbApproverName1.SelectedValue = 0 Then
                                    If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverDate1") Is DBNull.Value Then
                                        If CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverIsApproved1") = True Then
                                            If Not cmbApproverName2.SelectedValue = 0 Then
                                                If CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverIsApproved2") = True Then
                                                    .RoutingStatusId = 2
                                                Else
                                                    .RoutingStatusId = 3
                                                End If
                                            Else
                                                .RoutingStatusId = 2
                                            End If
                                        ElseIf CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverIsApproved1") = False Then
                                            .RoutingStatusId = 4
                                        End If
                                    Else
                                        .RoutingStatusId = 4
                                    End If
                                Else
                                    If Not cmbApproverName2.SelectedValue = 0 Then
                                        If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverDate2") Is DBNull.Value Then
                                            If CType(Me.bsTransactionHeader.Current, DataRowView).Item("ApproverIsApproved2") = True Then
                                                .RoutingStatusId = 2
                                            Else
                                                .RoutingStatusId = 3
                                            End If
                                        Else
                                            .RoutingStatusId = 3
                                        End If
                                    Else
                                        .RoutingStatusId = 2
                                    End If
                                End If
                            End If
                        End With

                        'existing transaction - on-going
                    Else
                        .TrxStatusId = 2
                        .RoutingStatusId = 5

                        If Not cmbMachineName.SelectedValue = 0 Then
                            Dim _prmMachineStatus(2) As SqlParameter
                            _prmMachineStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                            _prmMachineStatus(0).Value = cmbMachineName.SelectedValue
                            _prmMachineStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                            _prmMachineStatus(1).Value = cmbDowntimeStatus.SelectedValue
                            _prmMachineStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                            _prmMachineStatus(2).Value = cmbDowntimeSubStatus.SelectedValue

                            dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, _prmMachineStatus)
                        End If

                        If Not cmbJigName.SelectedValue = 0 Then
                            Dim _prmJigStatus(1) As SqlParameter
                            _prmJigStatus(0) = New SqlParameter("@JigId", SqlDbType.Int)
                            _prmJigStatus(0).Value = cmbJigName.SelectedValue
                            _prmJigStatus(1) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                            _prmJigStatus(1).Value = cmbDowntimeStatus.SelectedValue

                            dbMethod.ExecuteNonQuery("UpdMntJigByJigStatusId", CommandType.StoredProcedure, _prmJigStatus)
                        End If

                        'preventive maintenance of machine or jig
                        If cmbDowntimeStatus.SelectedValue = 2 Then
                            If Not String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                .Problem = txtProblem.Text.Trim
                            Else
                                .SetProblemNull()
                            End If

                            If Not String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                .RootCause = txtRootCause.Text.Trim
                            Else
                                .SetRootCauseNull()
                            End If

                            If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                .ActionTaken = txtActionTaken.Text.Trim
                            Else
                                .SetActionTakenNull()
                            End If

                            'under repair of machine or jig
                        ElseIf cmbDowntimeStatus.SelectedValue = 3 Or cmbDowntimeStatus.SelectedValue = 4 Then
                            If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtProblem.Focus()
                                Return
                            Else
                                .Problem = txtProblem.Text.Trim
                            End If

                            If Not String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                .RootCause = txtRootCause.Text.Trim
                            Else
                                .SetRootCauseNull()
                            End If

                            If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                .ActionTaken = txtActionTaken.Text.Trim
                            Else
                                .SetActionTakenNull()
                            End If

                            'other activities - still need to specify the problem first
                        Else
                            If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtProblem.Focus()
                                Return
                            Else
                                .Problem = txtProblem.Text.Trim
                            End If

                            If Not String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                .RootCause = txtRootCause.Text.Trim
                            Else
                                .SetRootCauseNull()
                            End If

                            If Not String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                .ActionTaken = txtActionTaken.Text.Trim
                            Else
                                .SetActionTakenNull()
                            End If

                        End If

                        If cmbMachineName.SelectedValue = 0 AndAlso cmbJigName.SelectedValue = 0 Then
                            If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                                MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtProblem.Focus()
                                Return
                            Else
                                .Problem = txtProblem.Text.Trim
                            End If

                            If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then
                                .SetRootCauseNull()
                            Else
                                .RootCause = txtRootCause.Text.Trim
                            End If

                            If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then
                                .SetActionTakenNull()
                            Else
                                .ActionTaken = txtActionTaken.Text.Trim
                            End If
                        End If

                        If picImage.Image Is Nothing Then
                            .SetImageNull()
                            .SetImageNameNull()
                        Else
                            Dim _resized As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                            _resized.Save(memoStream, ImageFormat.Jpeg)
                            bite = memoStream.GetBuffer()
                            .Image = bite
                            .ImageName = txtImageName.Text.Trim
                        End If
                    End If

                    .ModifiedBy = userId
                    .ModifiedDate = dbMethod.GetServerDate
                End With
                Me.bsTransactionHeader.EndEdit()
                Me.adpTransactionHeader.Update(Me.dsMonitoring.MntTransactionHeader)

                'transaction details
                'set first the trxid of each rows from technician logs
                For Each _dataRowView As DataRowView In Me.bsTransactionDetail
                    Dim _row = _dataRowView.Row
                    _row.Item("TrxId") = trxId
                Next
                Me.Validate()
                Me.adpTransactionDetail.Update(Me.dsMonitoring.MntTransactionDetail)

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
                Me.adpTransactionMachinePart.Update(Me.dsMonitoring.MntTransactionMachinePart)

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
                Me.adpTransactionSparePart.Update(Me.dsMonitoring.MntTransactionSparePart)

                'transaction user - insert from pic gridview
                For Each _row As DataGridViewRow In dgvPic.Rows
                    Dim _userId As Integer = _row.Cells("ColUserId").Value
                    Dim _isSelected As Boolean = Convert.ToBoolean(_row.Cells("ColIsSelected").Value)

                    trxCount = Me.adpTransactionUser.CntMntTransactionUser(trxId, _userId)

                    If trxCount > 0 Then
                        If _isSelected Then
                            'already on pic table - do nothing
                        Else
                            'previously selected as pic - delete from pic table
                            Me.adpTransactionUser.DelMntTransactionUserByUserId(trxId, _userId)
                        End If
                    Else
                        If _isSelected Then
                            'selected as pic - add to pic table
                            Me.adpTransactionUser.Insert(trxId, _row.Cells("ColUserId").Value)
                        Else
                            'not selected - do nothing
                        End If
                    End If
                Next

                'transaction user insert from technician log
                For Each _row As DataRowView In Me.bsTransactionDetail
                    trxCount = Me.adpTransactionUser.CntMntTransactionUser(trxId, _row.Item("UserId"))
                    If Not trxCount > 0 Then
                        adpTransactionUser.Insert(trxId, _row.Item("UserId"))
                    End If
                Next
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If trxId > 0 AndAlso (isAdmin Or superiorWorkgroupId.Contains(workgroupId)) Then
                Dim _question As String = String.Format("Are you sure you want to delete this record?")
                Dim _trxStatusId As Integer = CType(Me.bsTransactionHeader.Current, DataRowView).Item("TrxStatusId")

                If MessageBox.Show(_question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    If _trxStatusId = 2 Then
                        If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId") Is DBNull.Value Then
                            Dim _prmMachineStatus(2) As SqlParameter
                            _prmMachineStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                            _prmMachineStatus(0).Value = CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId")
                            _prmMachineStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                            _prmMachineStatus(1).Value = 1
                            _prmMachineStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                            _prmMachineStatus(2).Value = 1

                            dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, _prmMachineStatus)
                        End If

                        If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("JigId") Is DBNull.Value Then
                            Dim _prmJigStatus(1) As SqlParameter
                            _prmJigStatus(0) = New SqlParameter("@JigId", SqlDbType.Int)
                            _prmJigStatus(0).Value = CType(Me.bsTransactionHeader.Current, DataRowView).Item("JigId")
                            _prmJigStatus(1) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                            _prmJigStatus(1).Value = 1

                            dbMethod.ExecuteNonQuery("UpdMntJigByJigStatusId", CommandType.StoredProcedure, _prmJigStatus)
                        End If
                    End If

                    Me.bsTransactionHeader.RemoveCurrent()
                    Me.adpTransactionHeader.Update(Me.dsMonitoring.MntTransactionHeader)
                    Me.dsMonitoring.AcceptChanges()
                End If
            Else
                MessageBox.Show("You do not have permission to delete record.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        btnCancel.PerformClick()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
            opdTrxDetail.Filter = "JPEGs (*.jpg, *.jpeg) | *.jpg; *.jpeg |GIFs (*.gif) | *.gif |Bitmaps (*.bmp) | *.bmp |All Images (*.*) | *.jpg; *.jpeg; *.gif; *.bmp; *.png; *.tif; *.tiff"
            opdTrxDetail.FilterIndex = 4
            opdTrxDetail.Title = "Select Image"
            opdTrxDetail.FileName = String.Empty
            picImage.Image = Nothing
            Dim _mStream As New MemoryStream

            If opdTrxDetail.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtImageName.Text = opdTrxDetail.SafeFileName

                Using bmp As New Bitmap(opdTrxDetail.FileName)
                    Dim _jpgEncoder As ImageCodecInfo = dbMain.GetEncoder(ImageFormat.Jpeg)
                    Dim _myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality

                    'create an encoder parameters object
                    'an encoder parameters object has an array of encoderparameter objects; in this case, there is only one encoderparameter object in the array.
                    Dim _myEncoderParameters As New EncoderParameters(1)

                    'save the bitmap as a JPG file with quality level compression
                    Dim _myEncoderParameter = New EncoderParameter(_myEncoder, 500L)
                    _myEncoderParameters.Param(0) = _myEncoderParameter
                    bmp.Save(_mStream, _jpgEncoder, _myEncoderParameters)

                    picImage.Image = Image.FromStream(_mStream)
                End Using
            End If

            _mStream.Dispose()
            opdTrxDetail.Dispose()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        txtImageName.Text = String.Empty
        picImage.Image = Nothing
    End Sub

    Private Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        Try
            If trxId = 0 Then
                Using frmDetailLog As New frmMntTrxDetailLog(Me.dsMonitoring, userId)
                    frmDetailLog.ShowDialog(Me)

                    If frmDetailLog.DialogResult = Windows.Forms.DialogResult.OK Then
                        Me.bsTransactionDetail.AddNew()
                        Me.bsTransactionDetail.MoveLast()
                        Me.bsTransactionDetail.Current("TrxId") = DBNull.Value
                        Me.bsTransactionDetail.Current("TrxDate") = dbMethod.GetServerDate
                        Me.bsTransactionDetail.Current("TrxFrom") = frmDetailLog.dtpFrom.Value
                        Me.bsTransactionDetail.Current("TrxTo") = frmDetailLog.dtpTo.Value
                        Me.bsTransactionDetail.Current("ElapsedTime") = frmDetailLog.txtElapsedTime.Text.Trim
                        Me.bsTransactionDetail.Current("UserId") = frmDetailLog.cmbTechnician.SelectedValue
                        Me.bsTransactionDetail.Current("ShiftId") = IIf(frmDetailLog.rdDay.Checked = True, "D", "N")
                        Me.bsTransactionDetail.Sort = "TrxFrom"
                        Me.bsTransactionDetail.EndEdit()
                    Else
                        Me.bsTransactionDetail.CancelEdit()
                    End If
                End Using
            Else
                Using frmDetailLog As New frmMntTrxDetailLog(Me.dsMonitoring, userId, trxId)
                    frmDetailLog.ShowDialog(Me)

                    If frmDetailLog.DialogResult = Windows.Forms.DialogResult.OK Then
                        Me.bsTransactionDetail.AddNew()
                        Me.bsTransactionDetail.MoveLast()
                        Me.bsTransactionDetail.Current("TrxId") = trxId
                        Me.bsTransactionDetail.Current("TrxDate") = DateTime.Now
                        Me.bsTransactionDetail.Current("TrxFrom") = frmDetailLog.dtpFrom.Value
                        Me.bsTransactionDetail.Current("TrxTo") = frmDetailLog.dtpTo.Value
                        Me.bsTransactionDetail.Current("ElapsedTime") = frmDetailLog.txtElapsedTime.Text.Trim
                        Me.bsTransactionDetail.Current("UserId") = frmDetailLog.cmbTechnician.SelectedValue
                        Me.bsTransactionDetail.Current("ShiftId") = IIf(frmDetailLog.rdDay.Checked = True, "D", "N")
                        Me.bsTransactionDetail.Sort = "TrxFrom"
                        Me.bsTransactionDetail.EndEdit()
                    Else
                        Me.bsTransactionDetail.CancelEdit()
                    End If
                End Using
            End If

            FillPic()
            GetTotalDowntime()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

                        Dim message = String.Format("Delete selected row?")
                        If MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Me.bsTransactionDetail.RemoveCurrent()
                        End If
                    Case Else
                End Select
            End If

            Me.bsTransactionDetail.Sort = "TrxFrom"

            FillPic()
            GetTotalDowntime()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetail.DataError
        e.Cancel = False
    End Sub

    Private Sub cmbApproverName1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbApproverName1.SelectedValueChanged
        Try
            If Not cmbApproverName1.SelectedValue = 0 Then
                Dim _prm(0) As SqlParameter
                _prm(0) = New SqlParameter("@UserId", SqlDbType.Int)
                _prm(0).Value = cmbApproverName1.SelectedValue
                txtApproverItem1.Text = dbMethod.ExecuteScalar("SELECT TRIM(UserItem) AS UserItem FROM dbo.SecUser WHERE UserId = @UserId", CommandType.Text, _prm)
            Else
                txtApproverItem1.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbApproverName1_Validated(sender As Object, e As EventArgs) Handles cmbApproverName1.Validated
        If cmbApproverName1.Text.Trim.Length = 0 Then
            cmbApproverName1.SelectedValue = 0
        End If

        If cmbApproverName1.SelectedValue = 0 Then
            cmbApproverName1.SelectedValue = 0
        End If
    End Sub

    Private Sub cmbApproverName2_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbApproverName2.SelectedValueChanged
        Try
            If Not cmbApproverName2.SelectedValue = 0 Then
                Dim _prm(0) As SqlParameter
                _prm(0) = New SqlParameter("@UserId", SqlDbType.Int)
                _prm(0).Value = cmbApproverName2.SelectedValue
                txtApproverItem2.Text = dbMethod.ExecuteScalar("SELECT TRIM(UserItem) AS UserItem FROM dbo.SecUser WHERE UserId = @UserId", CommandType.Text, _prm)
            Else
                txtApproverItem2.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbApproverName2_Validated(sender As Object, e As EventArgs) Handles cmbApproverName2.Validated
        If cmbApproverName2.Text.Trim.Length = 0 Then
            cmbApproverName2.SelectedValue = 0
        End If

        If cmbApproverName2.SelectedValue = 0 Then
            cmbApproverName2.SelectedValue = 0
        End If
    End Sub

    Private Sub cmbApproverName3_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbApproverName3.SelectedValueChanged
        Try
            If Not cmbApproverName3.SelectedValue = 0 Then
                Dim _prm(0) As SqlParameter
                _prm(0) = New SqlParameter("@UserId", SqlDbType.Int)
                _prm(0).Value = cmbApproverName3.SelectedValue
                txtApproverItem3.Text = dbMethod.ExecuteScalar("SELECT TRIM(UserItem) AS UserItem FROM dbo.SecUser WHERE UserId = @UserId", CommandType.Text, _prm)
            Else
                txtApproverItem3.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbApproverName3_Validated(sender As Object, e As EventArgs) Handles cmbApproverName3.Validated
        If cmbApproverName3.Text.Trim.Length = 0 Then
            cmbApproverName3.SelectedValue = 0
        End If

        If cmbApproverName3.SelectedValue = 0 Then
            cmbApproverName3.SelectedValue = 0
        End If
    End Sub

    Private Sub txtProblem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProblem.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtRootCause_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRootCause.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtActionTaken_KeyDown(sender As Object, e As KeyEventArgs) Handles txtActionTaken.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub trxDate_Format(sender As Object, e As ConvertEventArgs) Handles trxDate.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy  HH:mm")
        Else
            e.Value = CDate(dbMethod.GetServerDate).ToString("MMMM dd, yyyy  HH:mm")
        End If
    End Sub

    Private Sub approverDate1_Format(sender As Object, e As ConvertEventArgs) Handles approverDate1.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy  HH:mm")
        Else
            e.Value = ""
        End If
    End Sub

    Private Sub approverDate2_Format(sender As Object, e As ConvertEventArgs) Handles approverDate2.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy  HH:mm")
        Else
            e.Value = ""
        End If
    End Sub

    Private Sub approverDate3_Format(sender As Object, e As ConvertEventArgs) Handles approverDate3.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy  HH:mm")
        Else
            e.Value = ""
        End If
    End Sub

    Private Sub ResetForm()
        cmbMachinePart.Enabled = False
        cmbDowntimeStatus.Enabled = False
        cmbDowntimeSubStatus.Enabled = False

        txtPartsReplaced.Enabled = False
        txtPartNo.Enabled = False

        If superiorWorkgroupId.Contains(workgroupId) Then
            If workgroupId = 29 Then 'asv
                cmbApproverStatus2.Enabled = False
                txtApproverRemarks2.Enabled = False
                cmbApproverStatus3.Enabled = False
                txtApproverRemarks3.Enabled = False

            ElseIf workgroupId = 30 Then 'sv
                cmbApproverStatus1.Enabled = False
                txtApproverRemarks1.Enabled = False
                cmbApproverStatus3.Enabled = False
                txtApproverRemarks3.Enabled = False

            ElseIf workgroupId = 2 Then 'sr mngr
                cmbApproverStatus2.Enabled = False
                txtApproverRemarks2.Enabled = False
                cmbApproverStatus3.Enabled = False
                txtApproverRemarks3.Enabled = False
            End If
        Else
            cmbApproverStatus1.Enabled = False
            txtApproverRemarks1.Enabled = False
            cmbApproverStatus2.Enabled = False
            txtApproverRemarks2.Enabled = False
            cmbApproverStatus3.Enabled = False
            txtApproverRemarks3.Enabled = False
        End If
    End Sub

    Private Sub FillTransactionStatus()
        Try
            dbMethod.FillCmb("RdGenTransactionStatus", CommandType.StoredProcedure, "TrxStatusId", "TrxStatusName", cmbTransactionStatus)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillMachine(ByVal _isNewEntry As Boolean)
        Try
            If _isNewEntry = True Then
                Dim _prm(0) As SqlParameter
                _prm(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                _prm(0).Value = 1

                dbMethod.FillCmbWithCaption("RdMntMachine", CommandType.StoredProcedure, "MachineId", "MachineName", cmbMachineName, "", _prm)
            Else
                Dim _prm(0) As SqlParameter
                _prm(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                _prm(0).Value = Nothing

                dbMethod.FillCmbWithCaption("RdMntMachine", CommandType.StoredProcedure, "MachineId", "MachineName", cmbMachineName, "", _prm)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillJig(ByVal _isNewEntry As Boolean)
        Try
            If _isNewEntry = True Then
                Dim _prm(0) As SqlParameter
                _prm(0) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                _prm(0).Value = 1

                dbMethod.FillCmbWithCaption("RdMntJig", CommandType.StoredProcedure, "JigId", "JigCompleteName", cmbJigName, "", _prm)
            Else
                Dim _prm(0) As SqlParameter
                _prm(0) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                _prm(0).Value = Nothing

                dbMethod.FillCmbWithCaption("RdMntJig", CommandType.StoredProcedure, "JigId", "JigCompleteName", cmbJigName, "", _prm)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillArea()
        Try
            dbMethod.FillCmbWithCaption("RdMntArea", CommandType.StoredProcedure, "AreaId", "AreaName", cmbArea, "< Select Area >")
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillDowntimeStatus()
        Try
            If Not cmbMachineName.SelectedValue = 0 Then
                cmbDowntimeStatus.DataSource = Nothing
                cmbDowntimeStatus.Items.Clear()

                Dim _prmMachineStatus(0) As SqlParameter
                _prmMachineStatus(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                _prmMachineStatus(0).Value = Nothing

                dbMethod.FillCmbWithCaption("RdMntMachineStatus", CommandType.StoredProcedure, "MachineStatusId", "MachineStatusName", cmbDowntimeStatus, "< Select Machine Status >", _prmMachineStatus)
            End If

            If Not cmbJigName.SelectedValue = 0 Then
                cmbDowntimeStatus.DataSource = Nothing
                cmbDowntimeStatus.Items.Clear()

                cmbDowntimeSubStatus.DataSource = Nothing
                cmbDowntimeSubStatus.Items.Clear()

                Dim _prmJigStatus(0) As SqlParameter
                _prmJigStatus(0) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                _prmJigStatus(0).Value = Nothing

                dbMethod.FillCmbWithCaption("RdMntJigStatus", CommandType.StoredProcedure, "JigStatusId", "JigStatusName", cmbDowntimeStatus, "< Select Jig Status >", _prmJigStatus)
            End If

            cmbDowntimeStatus.Enabled = True
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillDowntimeSubStatus()
        Try
            If Not cmbDowntimeStatus.SelectedValue = 0 Then
                cmbDowntimeSubStatus.DataSource = Nothing
                cmbDowntimeSubStatus.Items.Clear()

                Dim _prmMachineSubStatus(0) As SqlParameter
                _prmMachineSubStatus(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                _prmMachineSubStatus(0).Value = cmbDowntimeStatus.SelectedValue

                dbMethod.FillCmbWithCaption("RdMntMachineSubStatus", CommandType.StoredProcedure, "MachineSubStatusId", "MachineSubStatusName", cmbDowntimeSubStatus, "< Select Sub-Status >", _prmMachineSubStatus)

                If Not trxId = 0 Then
                    cmbDowntimeSubStatus.SelectedValue = CType(Me.bsTransactionHeader.Current, DataRowView).Item("DowntimeMachineSubStatusId")
                End If
            End If

            cmbDowntimeSubStatus.Enabled = True
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetMachineInformation(ByVal _machineId As Integer)
        Try
            Dim _prmMachineId(0) As SqlParameter
            _prmMachineId(0) = New SqlParameter("@MachineId", SqlDbType.Int)
            _prmMachineId(0).Value = _machineId

            Dim _reader As IDataReader = dbMethod.ExecuteReader("RdMntMachine", CommandType.StoredProcedure, _prmMachineId)

            While _reader.Read
                cmbArea.SelectedValue = _reader.Item("AreaId")

                If _reader.Item("GroupId") Is DBNull.Value Then
                    machinePartGroupId = 0
                    cmbMachinePart.SelectedValue = 0
                    cmbMachinePart.Enabled = False
                Else
                    machinePartGroupId = _reader.Item("GroupId")
                    cmbMachinePart.Enabled = True

                    Dim _prmGroupId(0) As SqlParameter
                    _prmGroupId(0) = New SqlParameter("@GroupId", SqlDbType.Int)
                    _prmGroupId(0).Value = machinePartGroupId

                    dbMethod.FillCmbWithCaption("RdMntMachinePart", CommandType.StoredProcedure, "MachinePartId", "MachinePartName", cmbMachinePart, "< Select Machine Part >", _prmGroupId)

                    If Not trxId = 0 Then
                        cmbMachinePart.SelectedValue = CType(Me.bsTransactionMachinePart.Current, DataRowView).Item("MachinePartId")
                    End If
                End If
            End While
            _reader.Close()

            cmbArea.Enabled = False
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetJigInformation(ByVal _jigId As Integer)
        Try
            Dim _prmJigId(0) As SqlParameter
            _prmJigId(0) = New SqlParameter("@JigId", SqlDbType.Int)
            _prmJigId(0).Value = _jigId

            Dim _reader As IDataReader = dbMethod.ExecuteReader("RdMntJig", CommandType.StoredProcedure, _prmJigId)

            While _reader.Read
                cmbArea.SelectedValue = _reader.Item("AreaId")
            End While
            _reader.Close()

            cmbArea.Enabled = False
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetTotalRuntime(ByVal _subjectId As Integer)
        Try
            Dim _lastDatetime As DateTime = Nothing
            Dim _span As TimeSpan = Nothing
            Dim _spanMinutes As Integer = 0
            Dim _spanHours As Integer = 0
            Dim _spanDays As Integer = 0
            Dim _totalMinutes As Integer = 0

            If Not cmbMachineName.SelectedValue = 0 Then
                Dim _prm(0) As SqlParameter
                _prm(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                _prm(0).Value = _subjectId

                Dim _reader As IDataReader = dbMethod.ExecuteReader("RdMntMachineAccumulatedTime", CommandType.StoredProcedure, _prm)

                While _reader.Read
                    If Not _reader.Item("TrxFrom") Is DBNull.Value Then
                        _lastDatetime = _reader.Item("TrxFrom").ToString
                    End If
                End While
                _reader.Close()
            End If

            If Not cmbJigName.SelectedValue = 0 Then
                Dim _prm(0) As SqlParameter
                _prm(0) = New SqlParameter("@JigId", SqlDbType.Int)
                _prm(0).Value = _subjectId

                Dim _reader As IDataReader = dbMethod.ExecuteReader("RdMntJigAccumulatedTime", CommandType.StoredProcedure, _prm)

                While _reader.Read
                    If Not _reader.Item("TrxFrom") Is DBNull.Value Then
                        _lastDatetime = _reader.Item("TrxFrom").ToString
                    End If
                End While
                _reader.Close()
            End If

            If Not _lastDatetime = "01/01/0001 12:00:00 AM" Then
                _span = (_lastDatetime - CDate(dbMethod.GetServerDate).Date).Duration()
                txtRuntimeAccumulated.Text = Math.Truncate(_span.TotalMinutes)
            Else
                txtRuntimeAccumulated.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetTotalDowntime()
        Try
            Dim _minutes As String
            Dim _totalMinutes As Integer = 0

            For Each _row As DataGridViewRow In dgvDetail.Rows
                _minutes = _row.Cells("ColElapsedTime").Value
                _totalMinutes = _totalMinutes + _minutes
            Next

            txtDowntimeAccumulated.Text = _totalMinutes
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillPic()
        Try
            If dgvDetail.Rows.Count > 0 Then
                Dim filterBuilder As New System.Text.StringBuilder("WorkgroupId IN (6, 29, 30, 33, 5) AND UserId NOT IN (")

                For _i As Integer = 0 To dgvDetail.Rows.Count - 1
                    If _i > 0 Then
                        filterBuilder.Append(",")
                    End If
                    filterBuilder.Append(dgvDetail.Rows(_i).Cells("ColNickname").Value)
                Next

                filterBuilder.Append(")")

                Me.bsTransactionUser.Filter = filterBuilder.ToString
            Else
                Me.bsTransactionUser.Filter = String.Format("WorkgroupId IN (6, 29, 30, 33, 5)")
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillApprovers()
        Try
            Dim _prmSup1(0) As SqlParameter
            _prmSup1(0) = New SqlParameter("@WorkgroupId", SqlDbType.Int)
            _prmSup1(0).Value = 29 'maintenance asst supervisor

            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbApproverName1, "< None >", _prmSup1)

            Dim _prmSup2(0) As SqlParameter
            _prmSup2(0) = New SqlParameter("@WorkgroupId", SqlDbType.Int)
            _prmSup2(0).Value = 30 'maintenance supervisor

            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbApproverName2, "< None >", _prmSup2)

            Dim _prmMngr(0) As SqlParameter
            _prmMngr(0) = New SqlParameter("@WorkgroupId", SqlDbType.Int)
            _prmMngr(0).Value = 2 'engineering sr mngr

            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbApproverName3, "< None >", _prmMngr)

            If cmbApproverName1.Items.Count = 2 Then
                cmbApproverName1.SelectedIndex = 1
            ElseIf cmbApproverName1.Items.Count < 2 Then
                cmbApproverName1.SelectedValue = 0
                cmbApproverName1.Enabled = False
            End If

            If cmbApproverName2.Items.Count = 2 Then
                cmbApproverName2.SelectedIndex = 1
            ElseIf cmbApproverName2.Items.Count < 2 Then
                cmbApproverName2.SelectedValue = 0
                cmbApproverName2.Enabled = False
            End If

            If cmbApproverName3.Items.Count = 2 Then
                cmbApproverName3.SelectedIndex = 1
            ElseIf cmbApproverName3.Items.Count < 2 Then
                cmbApproverName3.SelectedValue = 0
                cmbApproverName3.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillApproversAction()
        Try
            dicApprover1.Add(" < Select Status > ", 0)
            dicApprover1.Add("Approved", 1)
            dicApprover1.Add("Return for revision", 2)
            cmbApproverStatus1.DisplayMember = "Key"
            cmbApproverStatus1.ValueMember = "Value"
            cmbApproverStatus1.DataSource = New BindingSource(dicApprover1, Nothing)

            dicApprover2.Add(" < Select Status > ", 0)
            dicApprover2.Add("Approved", 1)
            dicApprover2.Add("Return for revision", 2)
            cmbApproverStatus2.DisplayMember = "Key"
            cmbApproverStatus2.ValueMember = "Value"
            cmbApproverStatus2.DataSource = New BindingSource(dicApprover2, Nothing)

            dicApprover3.Add(" < Select Status > ", 0)
            dicApprover3.Add("Approved", 1)
            dicApprover3.Add("Return for revision", 2)
            cmbApproverStatus3.DisplayMember = "Key"
            cmbApproverStatus3.ValueMember = "Value"
            cmbApproverStatus3.DataSource = New BindingSource(dicApprover3, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTrxStatus_Enter(sender As Object, e As EventArgs) Handles cmbTransactionStatus.Enter
        lblTransactionStatus.ForeColor = Color.White
        lblTransactionStatus.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbTrxStatus_Leave(sender As Object, e As EventArgs) Handles cmbTransactionStatus.Leave
        lblTransactionStatus.ForeColor = Color.Black
        lblTransactionStatus.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbMachineName_Enter(sender As Object, e As EventArgs)
        lblMachineName.ForeColor = Color.White
        lblMachineName.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbMachineName_Leave(sender As Object, e As EventArgs)
        lblMachineName.ForeColor = Color.Black
        lblMachineName.BackColor = SystemColors.Control
        GetTotalRuntime(cmbMachineName.SelectedValue)
    End Sub

    Private Sub cmbArea_Enter(sender As Object, e As EventArgs)
        lblArea.ForeColor = Color.White
        lblArea.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbArea_Leave(sender As Object, e As EventArgs)
        lblArea.ForeColor = Color.Black
        lblArea.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbMachinePart_Enter(sender As Object, e As EventArgs)
        lblMachinePart.ForeColor = Color.White
        lblMachinePart.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbMachinePart_Leave(sender As Object, e As EventArgs)
        lblMachinePart.ForeColor = Color.Black
        lblMachinePart.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbMachineStatus_Enter(sender As Object, e As EventArgs) Handles cmbDowntimeStatus.Enter
        lblDowntimeStatus.ForeColor = Color.White
        lblDowntimeStatus.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbMachineStatus_Leave(sender As Object, e As EventArgs) Handles cmbDowntimeStatus.Leave
        lblDowntimeStatus.ForeColor = Color.Black
        lblDowntimeStatus.BackColor = SystemColors.Control
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

    Private Sub cmbApproverStatus1_Enter(sender As Object, e As EventArgs) Handles cmbApproverStatus1.Enter
        lblApproverStatus1.ForeColor = Color.White
        lblApproverStatus1.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbApproverStatus1_Leave(sender As Object, e As EventArgs) Handles cmbApproverStatus1.Leave
        lblApproverStatus1.ForeColor = Color.Black
        lblApproverStatus1.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbApproverName1_Enter(sender As Object, e As EventArgs) Handles cmbApproverName1.Enter
        lblApproverId1.ForeColor = Color.White
        lblApproverId1.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbApproverName1_Leave(sender As Object, e As EventArgs) Handles cmbApproverName1.Leave
        lblApproverId1.ForeColor = Color.Black
        lblApproverId1.BackColor = SystemColors.Control
    End Sub

    Private Sub txtApproverRemarks1_Enter(sender As Object, e As EventArgs) Handles txtApproverRemarks1.Enter
        lblApproverRemarks1.ForeColor = Color.White
        lblApproverRemarks1.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtApproverRemarks1_Leave(sender As Object, e As EventArgs) Handles txtApproverRemarks1.Leave
        lblApproverRemarks1.ForeColor = Color.Black
        lblApproverRemarks1.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbApproverStatus2_Enter(sender As Object, e As EventArgs) Handles cmbApproverStatus2.Enter
        lblApproverStatus2.ForeColor = Color.White
        lblApproverStatus2.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbApproverStatus2_Leave(sender As Object, e As EventArgs) Handles cmbApproverStatus2.Leave
        lblApproverStatus2.ForeColor = Color.Black
        lblApproverStatus2.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbApproverName2_Enter(sender As Object, e As EventArgs) Handles cmbApproverName2.Enter
        lblApproverId2.ForeColor = Color.White
        lblApproverId2.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbApproverName2_Leave(sender As Object, e As EventArgs) Handles cmbApproverName2.Leave
        lblApproverId2.ForeColor = Color.Black
        lblApproverId2.BackColor = SystemColors.Control
    End Sub

    Private Sub txtApproverRemarks2_Enter(sender As Object, e As EventArgs) Handles txtApproverRemarks2.Enter
        lblApproverRemarks2.ForeColor = Color.White
        lblApproverRemarks2.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtApproverRemarks2_Enter_Leave(sender As Object, e As EventArgs) Handles txtApproverRemarks2.Leave
        lblApproverRemarks2.ForeColor = Color.Black
        lblApproverRemarks2.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbApproverStatus3_Enter(sender As Object, e As EventArgs) Handles cmbApproverStatus3.Enter
        lblApproverStatus3.ForeColor = Color.White
        lblApproverStatus3.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbApproverStatus3_Leave(sender As Object, e As EventArgs) Handles cmbApproverStatus3.Leave
        lblApproverStatus3.ForeColor = Color.Black
        lblApproverStatus3.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbApproverName3_Enter(sender As Object, e As EventArgs) Handles cmbApproverName3.Enter
        lblApproverId3.ForeColor = Color.White
        lblApproverId3.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbApproverName3_Leave(sender As Object, e As EventArgs) Handles cmbApproverName3.Leave
        lblApproverId3.ForeColor = Color.Black
        lblApproverId3.BackColor = SystemColors.Control
    End Sub

    Private Sub txtApproverRemarks3_Enter(sender As Object, e As EventArgs) Handles txtApproverRemarks3.Enter
        lblApproverRemarks3.ForeColor = Color.White
        lblApproverRemarks3.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtApproverRemarks3_Leave(sender As Object, e As EventArgs) Handles txtApproverRemarks3.Leave
        lblApproverRemarks3.ForeColor = Color.Black
        lblApproverRemarks3.BackColor = SystemColors.Control
    End Sub

End Class