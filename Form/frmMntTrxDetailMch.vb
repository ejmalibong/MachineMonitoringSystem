Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports BlackCoffeeLibrary
Imports MachineMonitoringSystem.dsMonitoring
Imports MachineMonitoringSystem.dsMonitoringTableAdapters

Public Class frmMntTrxDetailMch
    Private connection As New clsConnection
    Private directories As New clsDirectory
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbMain As New Main
    Private impersonation As New UserImpersonation.UserImpersonation

    Private dsMonitoring As New dsMonitoring
    Private adpRoutingStatus As New GenRoutingStatusTableAdapter
    Private adpTransactionHeader As New MntTransactionHeaderTableAdapter
    Private adpTransactionDetail As New MntTransactionDetailTableAdapter
    Private adpTransactionMachinePart As New MntTransactionMachinePartTableAdapter
    Private adpTransactionSparePart As New MntTransactionSparePartTableAdapter
    Private adpTransactionUser As New MntTransactionUserTableAdapter
    Private adpSecUserLog As New VwSecUserTableAdapter
    Private adpSecUserPic As New VwSecUserTableAdapter

    Private dtSecUserLog As New VwSecUserDataTable
    Private dtSecUserPic As New VwSecUserDataTable
    Private dtTransactionHeader As New MntTransactionHeaderDataTable
    Private dtTransactionDetail As New MntTransactionDetailDataTable
    Private dtTransactionMachinePart As New MntTransactionMachinePartDataTable
    Private dtTransactionSparePart As New MntTransactionSparePartDataTable
    Private dtTransactionUser As New MntTransactionUserDataTable
    Private dtMachineSchedule As New MntMachineScheduleDataTable

    Private dtTrxHeader As New MntTransactionHeaderDataTable

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
    Private mStream As New MemoryStream
    Private bite As Byte() 'the word `byte` is not a valid identifier

    Private userId As Integer
    Private workgroupId As Integer = 0
    Private trxId As Integer = 0
    Private machineId As Integer = 0
    Private areaId As Integer = 0
    Private scheduleId As Integer = 0
    Private monthId As Integer = 0
    Private weekId As Integer = 0
    Private machinePartGroupId As Integer = 0
    Private orgScheduleId As Integer = 0
    Private orgMachineId As Integer = 0
    Private orgMachineSubStatusId As Integer = 0
    Private orgMachineGroupId As Integer = 0
    Private orgMachinePartId As Integer = 0
    Private trxCount As Integer = 0

    Private isAdmin As Boolean = True
    Private isValidate As Boolean = True

    Private imgTmp As String = String.Empty
    Private serverNetUserName As String = String.Empty
    Private serverNetUserPassword As String = String.Empty

    Private imgDirectory As String = directories.ImageInitialDirectory

    Private lstImgAttachment As New List(Of clsImgAttachment)
    Private superiorWorkgroupId As New List(Of Integer) From {29, 30, 35, 2} 'asv, sv, asm, smngr

    Public Sub New(_userId As Integer, _workgroupId As Integer, _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        workgroupId = _workgroupId
        isAdmin = _isAdmin

        InitializeContructor()
    End Sub

    Public Sub New(_userId As Integer, _workgroupId As Integer, _isAdmin As Boolean, _trxId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        workgroupId = _workgroupId
        isAdmin = _isAdmin
        trxId = _trxId

        InitializeContructor()
    End Sub

    Public Sub InitializeContructor()
        dbMain.EnableDoubleBuffered(dgvDetail)
        dbMain.EnableDoubleBuffered(dgvPic)

        Me.adpRoutingStatus.Fill(Me.dsMonitoring.GenRoutingStatus)
        Me.adpSecUserLog.Fill(Me.dsMonitoring.VwSecUser)
        Me.adpSecUserPic.Fill(Me.dsMonitoring.VwSecUser)

        'activity log table
        Dim colNickname As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colNickname.Name = "ColNickname"
        colNickname.DataPropertyName = "UserId"
        colNickname.HeaderText = "Technician"
        colNickname.DataSource = Me.bsSecUserLog
        colNickname.ValueMember = "UserId"
        colNickname.DisplayMember = "Nickname"
        colNickname.Width = 100
        colNickname.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colNickname.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colNickname.SortMode = DataGridViewColumnSortMode.NotSortable
        dgvDetail.Columns.Insert(3, colNickname)

        Me.bsSecUserLog.DataMember = dtSecUserLog.TableName
        Me.bsSecUserLog.DataSource = Me.dsMonitoring

        'pic table
        Me.bsTransactionUser.DataSource = Me.dsMonitoring
        Me.bsTransactionUser.DataMember = dtSecUserPic.TableName
        Me.bsTransactionUser.Filter = String.Format("SectionId = 2")
        Me.bsTransactionUser.Sort = "UserName ASC"
        dgvPic.AutoGenerateColumns = False
        dgvPic.DataSource = Me.bsTransactionUser

        FillTransactionStatus()
        FillMachine()
        GetSetting(My.Settings.SettingsId)
        impersonation.ImpersonateUser(serverNetUserName, "", serverNetUserPassword)

        If trxId = 0 Then
            Me.Text = "New Activity Entry"

            txtTransactionDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", dbMethod.GetServerDate)

            rowRoutingStatus = Me.dsMonitoring.GenRoutingStatus.FindByRoutingStatusId(5)
            txtRoutingStatus.Text = rowRoutingStatus.RoutingStatusName.ToString.Trim

            Me.bsTransactionDetail.DataSource = Me.dsMonitoring
            Me.bsTransactionDetail.DataMember = dtTransactionDetail.TableName
            Me.bsTransactionDetail.Filter = String.Format("TrxId IS NULL")
            dgvDetail.AutoGenerateColumns = False
            dgvDetail.DataSource = Me.bsTransactionDetail

            btnDelete.Enabled = False
        Else
            Me.Text = "Activity No. " & trxId & ""

            'transaction header
            Me.adpTransactionHeader.FillMntTransactionHeaderByTrxId(Me.dsMonitoring.MntTransactionHeader, trxId)
            Me.bsTransactionHeader.DataSource = Me.dsMonitoring
            Me.bsTransactionHeader.DataMember = dtTransactionHeader.TableName
            Me.bsTransactionHeader.Position = Me.bsTransactionHeader.Find("TrxId", trxId)

            rowRoutingStatus = Me.dsMonitoring.GenRoutingStatus.FindByRoutingStatusId(CType(Me.bsTransactionHeader.Current, DataRowView).Item("RoutingStatusId"))
            txtRoutingStatus.Text = rowRoutingStatus.RoutingStatusName.ToString.Trim

            'transaction detail
            Me.adpTransactionDetail.FillMntTransactionDetailByTrxId(Me.dsMonitoring.MntTransactionDetail, trxId)
            Me.bsTransactionDetail.DataSource = Me.dsMonitoring
            Me.bsTransactionDetail.DataMember = dtTransactionDetail.TableName
            Me.bsTransactionDetail.Position = Me.bsTransactionDetail.Find("TrxId", trxId)
            Me.bsTransactionDetail.Sort = "TrxFrom"
            dgvDetail.AutoGenerateColumns = False
            dgvDetail.DataSource = Me.bsTransactionDetail

            'transaction machine part
            Me.adpTransactionMachinePart.Fill(Me.dsMonitoring.MntTransactionMachinePart)
            Me.bsTransactionMachinePart.DataSource = Me.dsMonitoring
            Me.bsTransactionMachinePart.DataMember = dtTransactionMachinePart.TableName
            Me.bsTransactionMachinePart.Position = Me.bsTransactionMachinePart.Find("TrxId", trxId)

            'transaction spare part
            Me.adpTransactionSparePart.Fill(Me.dsMonitoring.MntTransactionSparePart)
            Me.bsTransactionSparePart.DataSource = Me.dsMonitoring
            Me.bsTransactionSparePart.DataMember = dtTransactionSparePart.TableName
            Me.bsTransactionSparePart.Position = Me.bsTransactionSparePart.Find("TrxId", trxId)

            'transaction user
            dtTransactionUser = Me.adpTransactionUser.GetDataByTrxId(trxId)

            FillPic()

            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub frmMntTrxDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If trxId = 0 Then
                DisableForm(True)
                Me.ActiveControl = cmbMachineName
            Else
                trxDate = New Binding("Text", Me.bsTransactionHeader.Current, "TrxDate")
                txtTransactionDate.DataBindings.Add(trxDate)

                cmbTransactionStatus.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "TrxStatusId"))

                orgMachineId = CInt(CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId"))
                cmbMachineName.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "MachineId"))
                cmbDowntimeStatus.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "DowntimeMachineStatusId"))
                orgMachineSubStatusId = CInt(CType(Me.bsTransactionHeader.Current, DataRowView).Item("DowntimeMachineSubStatusId"))
                cmbDowntimeSubStatus.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "DowntimeMachineSubStatusId"))

                If CType(Me.bsTransactionHeader.Current, DataRowView).Item("TotalAccumulatedRuntime") Is DBNull.Value Then
                    txtRuntimeAccumulated.Text = String.Empty
                Else
                    txtRuntimeAccumulated.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "TotalAccumulatedRuntime"))
                End If

                If CType(Me.bsTransactionHeader.Current, DataRowView).Item("TotalAccumulatedDowntime") Is DBNull.Value Then
                    txtDowntimeAccumulated.Text = String.Empty
                Else
                    txtDowntimeAccumulated.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "TotalAccumulatedDowntime"))
                End If

                txtProblem.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "Problem"))
                txtRootCause.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "RootCause"))
                txtActionTaken.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "ActionTaken"))
                txtJoNumber.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "JoNumber"))
                txtJoRequestor.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "JoRequestor"))

                picImage.DataBindings.Add(New Binding("Image", Me.bsTransactionHeader.Current, "Image", True))
                txtImageName.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "ImageName"))

                cmbMachinePart.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionMachinePart.Current, "MachinePartId"))

                txtPartsReplaced.DataBindings.Add(New Binding("Text", Me.bsTransactionSparePart.Current, "SparePartName"))
                txtPartsNo.DataBindings.Add(New Binding("Text", Me.bsTransactionSparePart.Current, "SparePartNo"))

                txtChecksheet.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "LinkChecksheet"))
                txt4M.DataBindings.Add(New Binding("Text", Me.bsTransactionHeader.Current, "Link4M"))

                Dim prmMachineId(0) As SqlParameter
                prmMachineId(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmMachineId(0).Value = orgMachineId

                Dim rdrPartGroup As IDataReader = dbMethod.ExecuteReader("RdMntMachine", CommandType.StoredProcedure, prmMachineId)

                While rdrPartGroup.Read
                    If rdrPartGroup.Item("GroupId") Is DBNull.Value Then
                        orgMachineGroupId = 0
                    Else
                        orgMachineGroupId = rdrPartGroup.Item("GroupId")
                    End If
                End While
                rdrPartGroup.Close()
                orgMachinePartId = CType(Me.bsTransactionMachinePart.Current, DataRowView).Item("MachinePartId")

                Dim prmSchedule(1) As SqlParameter
                prmSchedule(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmSchedule(0).Value = machineId
                prmSchedule(1) = New SqlParameter("@TrxId", SqlDbType.Int)
                prmSchedule(1).Value = trxId

                Dim query As String = "SELECT ScheduleId, MonthId, WeekId FROM VwMntMachineSchedule WHERE MachineId = @MachineId AND TrxId = @TrxId"
                Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSchedule)

                If rdrSchedule.Read Then
                    scheduleId = rdrSchedule.Item("ScheduleId")
                End If
                rdrSchedule.Close()
                orgScheduleId = scheduleId

                imgTmp = Path.Combine(IO.Path.GetTempPath, "tmpImg." & Path.GetExtension(txtImageName.Text))

                Me.ActiveControl = txtProblem
                txtProblem.Select(txtProblem.Text.ToString.Trim.Length, 0)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMntTrxDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode.Equals(Keys.F8) Then 'delete
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

        ElseIf e.KeyCode.Equals(Keys.F10) Then 'save
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

    Private Sub frmMntTrxDetailMch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        impersonation.UndoImpersonateUser()
    End Sub

    Private Sub cmbMachineName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbMachineName.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachineName_Validated(sender As Object, e As EventArgs)
        Try
            If orgMachineId = cmbMachineName.SelectedValue AndAlso trxId <> 0 Then
                txtRuntimeAccumulated.Text = CType(Me.bsTransactionHeader.Current, DataRowView).Item("TotalAccumulatedRuntime")
            Else
                GetTotalRuntime(cmbMachineName.SelectedValue)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
                FillDowntimeStatus()
                FillDowntimeSubStatus()

                cmbDowntimeStatus.SelectedValue = 3
                cmbDowntimeSubStatus.SelectedValue = 5
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub cmbDowntimeStatus_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbDowntimeStatus.SelectedValue = 0 Then
                cmbDowntimeSubStatus.DataSource = Nothing
                cmbDowntimeSubStatus.Items.Clear()
                cmbDowntimeSubStatus.Enabled = False
            Else
                FillDowntimeSubStatus()
                cmbDowntimeSubStatus.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbDowntimeSubStatus_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbDowntimeSubStatus.SelectedValue = 0 Then
                txtScheduleMonth.Text = String.Empty
                txtScheduleWeek.Text = String.Empty
                txtScheduleMonth.Enabled = False
                txtScheduleWeek.Enabled = False
            Else
                If cmbDowntimeSubStatus.SelectedValue = 3 Then 'preventive maintenance
                    If orgMachineId = cmbMachineName.SelectedValue Then
                        GetMachineSchedule(cmbMachineName.SelectedValue, trxId)
                    Else
                        GetMachineSchedule(cmbMachineName.SelectedValue)
                    End If
                Else
                    txtScheduleMonth.Text = String.Empty
                    txtScheduleWeek.Text = String.Empty
                    txtScheduleMonth.Enabled = False
                    txtScheduleWeek.Enabled = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtPartsReplaced_TextChanged(sender As Object, e As EventArgs) Handles txtPartsReplaced.TextChanged
        If txtPartsReplaced.Text.Trim.Length > 0 Then
            txtPartsNo.Enabled = True
        Else
            txtPartsNo.Enabled = False
        End If
    End Sub

    Private Sub dgvPic_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvPic.DataBindingComplete
        For Each row As DataRow In dtTransactionUser.Rows
            For i As Integer = 0 To dgvPic.Rows.Count - 1
                If dgvPic.Rows(i).Cells("ColUserId").Value = row("UserId") Then
                    dgvPic.Rows(i).Cells("ColIsSelected").Value = True
                End If
            Next
        Next
    End Sub

    Private Sub dgvDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetail.DataError
        e.Cancel = False
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
                Dim currentRow = CType(Me.bsTransactionDetail.Current, DataRowView).Row
                Dim rowState = currentRow.RowState

                Select Case rowState
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

    Private Sub dgvPic_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPic.SelectionChanged
        dgvPic.ClearSelection()
    End Sub

    Private Sub btnViewImage_Click(sender As Object, e As EventArgs) Handles btnViewImage.Click
        Try
            If lstImgAttachment.Count > 0 Then
                Process.Start(lstImgAttachment(0).FileName)
            Else
                If Not picImage.Image Is Nothing Then
                    Dim img As Image = picImage.Image
                    img.Save(imgTmp)
                    OpenImage(imgTmp, 30000) '30 seconds
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    <DllImport("shell32.dll")>
    Private Shared Function FindExecutable(ByVal lpFile As String, ByVal lpDirectory As String, <Out> ByVal lpResult As StringBuilder) As Integer
    End Function

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

    Private Sub DeleteTempImg(ByVal sender As Object, ByVal e As System.EventArgs)
        If File.Exists(imgTmp) Then
            File.Delete(imgTmp)
        End If
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

    Private Sub ofdImage_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdImage.FileOk
        Try
            If Not picImage.Image Is Nothing Then
                If lstImgAttachment.Count > 0 Then lstImgAttachment.RemoveAt(0)
                picImage.Image.Dispose()
                picImage.Image = Nothing
                txtImageName.Text = String.Empty
            End If

            Dim imgAttachment As New clsImgAttachment(ofdImage.FileName, ofdImage.SafeFileName, Path.GetExtension(ofdImage.SafeFileName).ToLower)
            lstImgAttachment.Add(imgAttachment)

            Using ms As New MemoryStream
                Using bmp As New Bitmap(lstImgAttachment(0).FileName)
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

            txtImageName.Text = lstImgAttachment(0).SafeName
            ofdImage.InitialDirectory = Path.GetDirectoryName(lstImgAttachment(0).FileName)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveImage_Click(sender As Object, e As EventArgs) Handles btnRemoveImage.Click
        Try
            If Not picImage.Image Is Nothing Then
                If lstImgAttachment.Count > 0 Then lstImgAttachment.RemoveAt(0)
                picImage.Image.Dispose()
                picImage.Image = Nothing
                txtImageName.Text = String.Empty
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

    Private Sub btnRemoveChecksheet_Click(sender As Object, e As EventArgs) Handles btnRemoveChecksheet.Click
        Try
            txtChecksheet.Text = String.Empty
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

    Private Sub btnRemove4M_Click(sender As Object, e As EventArgs) Handles btnRemove4M.Click
        Try
            txt4M.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub txt4M_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles txt4M.LinkClicked
        Try
            If Not String.IsNullOrEmpty(txt4M.Text.Trim) Then
                Process.Start(e.LinkText)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
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
                    MessageBox.Show("No PM Schedule selected.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtScheduleMonth.Focus()
                    Return
                End If

                If String.IsNullOrEmpty(txtScheduleWeek.Text) Then
                    MessageBox.Show("Please enter the PM week schedule.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtScheduleWeek.Focus()
                    Return
                End If
            End If

            If Not String.IsNullOrEmpty(txtPartsReplaced.Text) AndAlso String.IsNullOrEmpty(txtPartsNo.Text) Then
                MessageBox.Show("Please enter the spare parts number.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPartsNo.Focus()
                Return
            End If

            Dim rowCount As Integer = dgvDetail.RowCount

            If trxId = 0 Then 'new transaction
                Dim newRowHeader As MntTransactionHeaderRow = Me.dsMonitoring.MntTransactionHeader.NewMntTransactionHeaderRow
                Dim newRowDetail As MntTransactionDetailRow = Me.dsMonitoring.MntTransactionDetail.NewMntTransactionDetailRow
                Dim newRowMachinePart As MntTransactionMachinePartRow = Me.dsMonitoring.MntTransactionMachinePart.NewMntTransactionMachinePartRow
                Dim newRowSparePart As MntTransactionSparePartRow = Me.dsMonitoring.MntTransactionSparePart.NewMntTransactionSparePartRow
                Dim newRowUser As MntTransactionUserRow = Me.dsMonitoring.MntTransactionUser.NewMntTransactionUserRow

                'transaction header
                With newRowHeader
                    .TrxDate = dbMethod.GetServerDate
                    .TrxStatusId = cmbTransactionStatus.SelectedValue
                    .MachineId = cmbMachineName.SelectedValue
                    .DowntimeMachineStatusId = cmbDowntimeStatus.SelectedValue
                    .DowntimeMachineSubStatusId = cmbDowntimeSubStatus.SelectedValue
                    .SetJigIdNull()
                    .SetDowntimeJigStatusIdNull()
                    .AreaId = areaId
                    .EncodeUserId = userId
                    If String.IsNullOrEmpty(txtRuntimeAccumulated.Text.Trim) Then .SetTotalAccumulatedRuntimeNull() Else .TotalAccumulatedRuntime = txtRuntimeAccumulated.Text.Trim
                    If String.IsNullOrEmpty(txtJoNumber.Text.Trim) Then .SetJoNumberNull() Else .JoNumber = txtJoNumber.Text.Trim
                    If String.IsNullOrEmpty(txtJoRequestor.Text.Trim) Then .SetJoRequestorNull() Else .JoRequestor = txtJoRequestor.Text.Trim

                    .ApproverIsApproved1 = 0
                    .ApproverId1 = 6
                    .SetApproverDate1Null()
                    .SetApproverRemarks1Null()

                    .ApproverIsApproved2 = 0
                    .ApproverId2 = 5
                    .SetApproverDate2Null()
                    .SetApproverRemarks2Null()

                    .ApproverIsApproved3 = 0
                    .ApproverId3 = 2
                    .SetApproverDate3Null()
                    .SetApproverRemarks3Null()

                    .SetModifiedByNull()
                    .SetModifiedDateNull()

                    .SetFileNameNull()
                    .SetFileAttachmentNull()

                    If cmbTransactionStatus.SelectedValue = 1 Then 'transaction status - done
                        If dgvDetail.Rows.Count = 0 Then
                            MessageBox.Show("Please input activity logs.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            btnAddRow.Focus()
                            Return
                        End If

                        .DatetimeStarted = dgvDetail.Rows(0).Cells("ColTrxFrom").Value
                        .DatetimeEnded = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                        .UserId = dgvDetail.Rows(rowCount - 1).Cells("ColUserIdLog").Value
                        .ShiftId = dgvDetail.Rows(rowCount - 1).Cells("ColShiftId").Value
                        .TotalAccumulatedDowntime = txtDowntimeAccumulated.Text.Trim
                        .RoutingStatusId = 1

                        If cmbDowntimeStatus.SelectedValue = 2 Then 'scheduled
                            If String.IsNullOrEmpty(txtProblem.Text.Trim) Then .SetProblemNull() Else .Problem = txtProblem.Text.Trim
                            If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then .SetRootCauseNull() Else .RootCause = txtRootCause.Text.Trim
                            If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then .SetActionTakenNull() Else .ActionTaken = txtActionTaken.Text.Trim

                            If picImage.Image Is Nothing Then
                                .SetImageNull()
                                .SetImageNameNull()
                            Else
                                Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                                resImg.Save(mStream, ImageFormat.Jpeg)
                                bite = mStream.GetBuffer
                                .Image = bite
                                .ImageName = txtImageName.Text.ToString.Trim
                            End If

                            If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                                MessageBox.Show("Please input the link of Check Sheet.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtChecksheet.Focus()
                                Return
                            Else
                                .LinkChecksheet = txtChecksheet.Text
                            End If

                            If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                                MessageBox.Show("Please input the link of 4M Change.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txt4M.Focus()
                                Return
                            Else
                                .Link4M = txt4M.Text
                            End If

                        ElseIf cmbDowntimeStatus.SelectedValue = 3 Then 'unscheduled
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

                            If picImage.Image Is Nothing Then
                                MessageBox.Show("Please attach an image for this activity.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                btnBrowseImage.Focus()
                                Return
                            End If

                            Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                            resImg.Save(mStream, ImageFormat.Jpeg)
                            bite = mStream.GetBuffer
                            .Image = bite
                            .ImageName = txtImageName.Text.ToString.Trim

                            If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                                .SetLinkChecksheetNull()
                            Else
                                .LinkChecksheet = txtChecksheet.Text
                            End If

                            If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                                .SetLink4MNull()
                            Else
                                .Link4M = txt4M.Text
                            End If
                        End If
                    Else 'transaction status - on-going
                        If dgvDetail.Rows.Count > 0 Then 'save record (on-going activity) even no activity log yet
                            .DatetimeStarted = dgvDetail.Rows(0).Cells("ColTrxFrom").Value
                            .DatetimeEnded = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                            .UserId = dgvDetail.Rows(rowCount - 1).Cells("ColUserIdLog").Value
                            .ShiftId = dgvDetail.Rows(rowCount - 1).Cells("ColShiftId").Value
                            .TotalAccumulatedDowntime = txtDowntimeAccumulated.Text.Trim
                        Else
                            .DatetimeStarted = dbMethod.GetServerDate
                            .SetDatetimeEndedNull()
                            .UserId = userId
                            .SetTotalAccumulatedDowntimeNull()

                            If DateTime.Now.Hour >= 7 And DateTime.Now.Hour <= 17 Then
                                .ShiftId = "D"
                            Else
                                .ShiftId = "N"
                            End If
                        End If

                        .RoutingStatusId = 5

                        Dim prmMchStatus(2) As SqlParameter
                        prmMchStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prmMchStatus(0).Value = cmbMachineName.SelectedValue
                        prmMchStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                        prmMchStatus(1).Value = cmbDowntimeStatus.SelectedValue
                        prmMchStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                        prmMchStatus(2).Value = cmbDowntimeSubStatus.SelectedValue

                        dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMchStatus)

                        If String.IsNullOrEmpty(txtProblem.Text.Trim) Then .SetProblemNull() Else .Problem = txtProblem.Text.Trim
                        If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then .SetRootCauseNull() Else .RootCause = txtRootCause.Text.Trim
                        If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then .SetActionTakenNull() Else .ActionTaken = txtActionTaken.Text.Trim

                        If picImage.Image Is Nothing Then
                            .SetImageNull()
                            .SetImageNameNull()
                        Else
                            Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                            resImg.Save(mStream, ImageFormat.Jpeg)
                            bite = mStream.GetBuffer
                            .Image = bite
                            .ImageName = txtImageName.Text.ToString.Trim
                        End If

                        If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                            .SetLinkChecksheetNull()
                        Else
                            .LinkChecksheet = txtChecksheet.Text
                        End If

                        If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                            .SetLink4MNull()
                        Else
                            .Link4M = txt4M.Text
                        End If
                    End If
                End With
                Me.dsMonitoring.MntTransactionHeader.AddMntTransactionHeaderRow(newRowHeader)
                Me.adpTransactionHeader.Update(Me.dsMonitoring.MntTransactionHeader)

                'machine schedule (pm)
                If scheduleId > 0 AndAlso cmbDowntimeSubStatus.SelectedValue = 3 Then
                    Dim prmMchSchd(5) As SqlParameter
                    prmMchSchd(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmMchSchd(0).Value = newRowHeader.TrxId

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

                    prmMchSchd(4) = New SqlParameter("@ActivityDate", SqlDbType.Date)
                    If dgvDetail.Rows.Count > 0 Then
                        prmMchSchd(4).Value = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                    Else
                        prmMchSchd(4).Value = dbMethod.GetServerDate
                    End If

                    prmMchSchd(5) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                    prmMchSchd(5).Value = scheduleId

                    dbMethod.ExecuteNonQuery("UpdMntMachineScheduleByScheduleId", CommandType.StoredProcedure, prmMchSchd)
                End If

                'transaction details
                If dgvDetail.Rows.Count > 0 Then
                    For Each dataRowView As DataRowView In Me.bsTransactionDetail
                        Dim row = dataRowView.Row
                        row.Item("TrxId") = newRowHeader.TrxId
                        Me.adpTransactionUser.Insert(newRowHeader.TrxId, row("UserId"))
                    Next
                    Me.Validate()
                    Me.adpTransactionDetail.Update(Me.dsMonitoring.MntTransactionDetail)
                End If

                'transaction machine part
                With newRowMachinePart
                    .TrxId = newRowHeader.TrxId
                    If cmbMachinePart.SelectedValue = 0 AndAlso Not cmbMachinePart.Enabled Then .SetMachinePartIdNull() Else .MachinePartId = cmbMachinePart.SelectedValue
                End With
                Me.dsMonitoring.MntTransactionMachinePart.AddMntTransactionMachinePartRow(newRowMachinePart)
                Me.adpTransactionMachinePart.Update(Me.dsMonitoring.MntTransactionMachinePart)

                'transaction spare part
                With newRowSparePart
                    .TrxId = newRowHeader.TrxId
                    If String.IsNullOrEmpty(txtPartsReplaced.Text.Trim) Then
                        .SetSparePartNameNull()
                        .SetSparePartNoNull()
                    Else
                        .SparePartName = txtPartsReplaced.Text.Trim
                        .SparePartNo = txtPartsNo.Text.Trim
                    End If
                End With
                Me.dsMonitoring.MntTransactionSparePart.AddMntTransactionSparePartRow(newRowSparePart)
                Me.adpTransactionSparePart.Update(Me.dsMonitoring.MntTransactionSparePart)

                'transaction user
                For Each row As DataGridViewRow In dgvPic.Rows
                    Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("ColIsSelected").Value)
                    If isSelected Then
                        Me.adpTransactionUser.Insert(newRowHeader.TrxId, row.Cells("ColUserId").Value)
                    End If
                Next
            Else 'existing transaction
                Dim rowHeader As MntTransactionHeaderRow = Me.dsMonitoring.MntTransactionHeader.FindByTrxId(trxId)

                With rowHeader 'transaction header
                    .MachineId = cmbMachineName.SelectedValue
                    .AreaId = areaId
                    .DowntimeMachineStatusId = cmbDowntimeStatus.SelectedValue
                    .DowntimeMachineSubStatusId = cmbDowntimeSubStatus.SelectedValue
                    .TrxStatusId = cmbTransactionStatus.SelectedValue
                    .ModifiedBy = userId
                    .ModifiedDate = dbMethod.GetServerDate
                    If String.IsNullOrEmpty(txtRuntimeAccumulated.Text.Trim) Then .SetTotalAccumulatedRuntimeNull() Else .TotalAccumulatedRuntime = txtRuntimeAccumulated.Text.Trim
                    If String.IsNullOrEmpty(txtJoNumber.Text.Trim) Then .SetJoNumberNull() Else .JoNumber = txtJoNumber.Text.Trim
                    If String.IsNullOrEmpty(txtJoRequestor.Text.Trim) Then .SetJoRequestorNull() Else .JoRequestor = txtJoRequestor.Text.Trim

                    .SetFileNameNull()
                    .SetFileAttachmentNull()

                    If cmbTransactionStatus.SelectedValue = 1 Then 'transaction status - done
                        If dgvDetail.Rows.Count = 0 Then
                            MessageBox.Show("Please input activity logs.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            btnAddRow.Focus()
                            Return
                        End If

                        .DatetimeStarted = dgvDetail.Rows(0).Cells("ColTrxFrom").Value
                        .DatetimeEnded = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                        .UserId = dgvDetail.Rows(rowCount - 1).Cells("ColUserIdLog").Value
                        .ShiftId = dgvDetail.Rows(rowCount - 1).Cells("ColShiftId").Value
                        .TotalAccumulatedDowntime = txtDowntimeAccumulated.Text.Trim
                        .RoutingStatusId = 1

                        If cmbDowntimeStatus.SelectedValue = 2 Then 'scheduled
                            If String.IsNullOrEmpty(txtProblem.Text.Trim) Then .SetProblemNull() Else .Problem = txtProblem.Text.Trim
                            If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then .SetRootCauseNull() Else .RootCause = txtRootCause.Text.Trim
                            If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then .SetActionTakenNull() Else .ActionTaken = txtActionTaken.Text.Trim

                            If picImage.Image Is Nothing Then
                                .SetImageNull()
                                .SetImageNameNull()
                            Else
                                If lstImgAttachment.Count > 0 Then
                                    Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                                    resImg.Save(mStream, ImageFormat.Jpeg)
                                    bite = mStream.GetBuffer
                                    .Image = bite
                                    .ImageName = txtImageName.Text.ToString.Trim
                                End If
                            End If

                            If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                                MessageBox.Show("Please input the link of Check Sheet.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txtChecksheet.Focus()
                                Return
                            Else
                                .LinkChecksheet = txtChecksheet.Text
                            End If

                            If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                                MessageBox.Show("Please input the link of 4M Change.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                txt4M.Focus()
                                Return
                            Else
                                .Link4M = txt4M.Text
                            End If

                        ElseIf cmbDowntimeStatus.SelectedValue = 3 Then 'unscheduled
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

                            If picImage.Image Is Nothing Then
                                MessageBox.Show("Please attach an image.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                btnBrowseImage.Focus()
                                Return
                            End If

                            If lstImgAttachment.Count > 0 Then
                                Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                                resImg.Save(mStream, ImageFormat.Jpeg)
                                bite = mStream.GetBuffer
                                .Image = bite
                                .ImageName = txtImageName.Text.ToString.Trim
                            End If

                            If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                                .SetLinkChecksheetNull()
                            Else
                                .LinkChecksheet = txtChecksheet.Text
                            End If

                            If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                                .SetLink4MNull()
                            Else
                                .Link4M = txt4M.Text
                            End If
                        End If

                        Dim prmMachineStatus(2) As SqlParameter
                        prmMachineStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prmMachineStatus(0).Value = cmbMachineName.SelectedValue
                        prmMachineStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                        prmMachineStatus(1).Value = 1
                        prmMachineStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                        prmMachineStatus(2).Value = 1

                        dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMachineStatus)
                    Else 'transaction status - on-going
                        .RoutingStatusId = 5

                        If String.IsNullOrEmpty(txtProblem.Text.Trim) Then .SetProblemNull() Else .Problem = txtProblem.Text.Trim
                        If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then .SetRootCauseNull() Else .RootCause = txtRootCause.Text.Trim
                        If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then .SetActionTakenNull() Else .ActionTaken = txtActionTaken.Text.Trim

                        If picImage.Image Is Nothing Then
                            .SetImageNull()
                            .SetImageNameNull()
                        Else
                            If lstImgAttachment.Count > 0 Then
                                Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                                resImg.Save(mStream, ImageFormat.Jpeg)
                                bite = mStream.GetBuffer
                                .Image = bite
                                .ImageName = txtImageName.Text.ToString.Trim
                            End If
                        End If

                        If String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                            .SetLinkChecksheetNull()
                        Else
                            .LinkChecksheet = txtChecksheet.Text
                        End If

                        If String.IsNullOrEmpty(txt4M.Text.Trim) Then
                            .SetLink4MNull()
                        Else
                            .Link4M = txt4M.Text
                        End If
                    End If
                End With
                Me.bsTransactionHeader.EndEdit()
                Me.adpTransactionHeader.Update(Me.dsMonitoring.MntTransactionHeader)

                'transaction details
                For Each dataRowView As DataRowView In Me.bsTransactionDetail
                    Dim row = dataRowView.Row
                    row.Item("TrxId") = trxId
                Next
                Me.Validate()
                Me.adpTransactionDetail.Update(Me.dsMonitoring.MntTransactionDetail)

                'transaction machine part
                With Me.bsTransactionMachinePart
                    If cmbMachinePart.SelectedValue = 0 AndAlso Not cmbMachinePart.Enabled Then
                        .Current("MachinePartId") = DBNull.Value
                    Else
                        .Current("MachinePartId") = cmbMachinePart.SelectedValue
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
                        If String.IsNullOrEmpty(txtPartsNo.Text.Trim) Then
                            MessageBox.Show("Please indicate the part number.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtPartsNo.Focus()
                            Return
                        End If

                        .Current("SparePartName") = txtPartsReplaced.Text.Trim
                        .Current("SparePartNo") = txtPartsNo.Text.Trim
                    End If
                End With
                Me.bsTransactionSparePart.EndEdit()
                Me.adpTransactionSparePart.Update(Me.dsMonitoring.MntTransactionSparePart)

                'transaction user - insert from pic gridview
                For Each row As DataGridViewRow In dgvPic.Rows
                    Dim userId As Integer = row.Cells("ColUserId").Value
                    Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("ColIsSelected").Value)

                    trxCount = Me.adpTransactionUser.CntMntTransactionUser(trxId, userId)

                    If trxCount > 0 Then
                        If isSelected Then
                            'already on pic table - do nothing
                        Else
                            'previously selected as pic - delete from pic table
                            Me.adpTransactionUser.DelMntTransactionUserByUserId(trxId, userId)
                        End If
                    Else
                        If isSelected Then
                            'selected - add to pic table
                            Me.adpTransactionUser.Insert(trxId, row.Cells("ColUserId").Value)
                        Else
                            'not selected - do nothing
                        End If
                    End If
                Next

                'transaction user - insert from technician log
                For Each row As DataRowView In Me.bsTransactionDetail
                    trxCount = Me.adpTransactionUser.CntMntTransactionUser(trxId, row.Item("UserId"))
                    If Not trxCount > 0 Then
                        adpTransactionUser.Insert(trxId, row.Item("UserId"))
                    End If
                Next

                If orgMachineId <> cmbMachineName.SelectedValue Then
                    Dim prmMachineStatusOrg(2) As SqlParameter
                    prmMachineStatusOrg(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmMachineStatusOrg(0).Value = orgMachineId
                    prmMachineStatusOrg(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                    prmMachineStatusOrg(1).Value = 1
                    prmMachineStatusOrg(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                    prmMachineStatusOrg(2).Value = 1

                    dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMachineStatusOrg)

                    Dim prmMachineStatusNew(2) As SqlParameter
                    prmMachineStatusOrg(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmMachineStatusOrg(0).Value = cmbMachineName.SelectedValue
                    prmMachineStatusOrg(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                    prmMachineStatusOrg(1).Value = cmbDowntimeStatus.SelectedValue
                    prmMachineStatusOrg(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                    prmMachineStatusOrg(2).Value = cmbDowntimeSubStatus.SelectedValue

                    dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMachineStatusOrg)
                End If

                If scheduleId > 0 AndAlso cmbDowntimeSubStatus.SelectedValue = 3 Then
                    If orgScheduleId <> scheduleId Then
                        Dim prmMchSchdOrg(5) As SqlParameter
                        prmMchSchdOrg(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmMchSchdOrg(0).Value = DBNull.Value
                        prmMchSchdOrg(1) = New SqlParameter("@IsDone", SqlDbType.Bit)
                        prmMchSchdOrg(1).Value = False
                        prmMchSchdOrg(2) = New SqlParameter("@IsChecklistCompleted", SqlDbType.Bit)
                        prmMchSchdOrg(2).Value = False
                        prmMchSchdOrg(3) = New SqlParameter("@ActivityBy", SqlDbType.Int)
                        prmMchSchdOrg(3).Value = DBNull.Value
                        prmMchSchdOrg(4) = New SqlParameter("@ActivityDate", SqlDbType.Date)
                        prmMchSchdOrg(4).Value = DBNull.Value
                        prmMchSchdOrg(5) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                        prmMchSchdOrg(5).Value = orgScheduleId
                        dbMethod.ExecuteNonQuery("UpdMntMachineScheduleByScheduleId", CommandType.StoredProcedure, prmMchSchdOrg)
                    End If

                    Dim prmMchSchd(5) As SqlParameter
                    prmMchSchd(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmMchSchd(0).Value = trxId

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

                    prmMchSchd(4) = New SqlParameter("@ActivityDate", SqlDbType.Date)
                    If dgvDetail.Rows.Count > 0 Then
                        prmMchSchd(4).Value = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                    Else
                        prmMchSchd(4).Value = dbMethod.GetServerDate
                    End If

                    prmMchSchd(5) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                    prmMchSchd(5).Value = scheduleId

                    dbMethod.ExecuteNonQuery("UpdMntMachineScheduleByScheduleId", CommandType.StoredProcedure, prmMchSchd)
                End If
            End If

            Me.dsMonitoring.AcceptChanges()
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If cmbMachineName.SelectedValue = 0 Then
                DisableForm(True)
                Exit Sub
            End If

            If btnDelete.Enabled = False Then
                Exit Sub
            End If

            If trxId > 0 Then
                Dim question As String = String.Format("Are you sure you want to delete this record?")

                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    If scheduleId > 0 AndAlso cmbDowntimeSubStatus.SelectedValue = 3 Then
                        'orgSchedule was used because it deletes the actual data from the database, not from the ui
                        Dim prmMchSchdOrg(5) As SqlParameter
                        prmMchSchdOrg(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmMchSchdOrg(0).Value = DBNull.Value
                        prmMchSchdOrg(1) = New SqlParameter("@IsDone", SqlDbType.Bit)
                        prmMchSchdOrg(1).Value = False
                        prmMchSchdOrg(2) = New SqlParameter("@IsChecklistCompleted", SqlDbType.Bit)
                        prmMchSchdOrg(2).Value = False
                        prmMchSchdOrg(3) = New SqlParameter("@ActivityBy", SqlDbType.Int)
                        prmMchSchdOrg(3).Value = DBNull.Value
                        prmMchSchdOrg(4) = New SqlParameter("@ActivityDate", SqlDbType.Date)
                        prmMchSchdOrg(4).Value = DBNull.Value
                        prmMchSchdOrg(5) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                        prmMchSchdOrg(5).Value = orgScheduleId
                        dbMethod.ExecuteNonQuery("UpdMntMachineScheduleByScheduleId", CommandType.StoredProcedure, prmMchSchdOrg)
                    End If

                    If cmbTransactionStatus.SelectedValue = 2 Then
                        Dim prmMachineStatus(2) As SqlParameter
                        prmMachineStatus(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prmMachineStatus(0).Value = CType(Me.bsTransactionHeader.Current, DataRowView).Item("MachineId")
                        prmMachineStatus(1) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                        prmMachineStatus(1).Value = 1
                        prmMachineStatus(2) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
                        prmMachineStatus(2).Value = 1

                        dbMethod.ExecuteNonQuery("UpdMntMachineByMachineStatusId", CommandType.StoredProcedure, prmMachineStatus)
                    End If

                    Me.bsTransactionHeader.RemoveCurrent()
                    Me.adpTransactionHeader.Update(Me.dsMonitoring.MntTransactionHeader)
                    Me.dsMonitoring.AcceptChanges()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        btnCancel.PerformClick()
    End Sub

    Private Sub FillTransactionStatus()
        Try
            cmbTransactionStatus.DisplayMember = "TrxStatusName"
            cmbTransactionStatus.ValueMember = "TrxStatusId"
            dbMethod.FillCmb("RdGenTransactionStatus", CommandType.StoredProcedure, "TrxStatusId", "TrxStatusName", cmbTransactionStatus)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillMachine()
        Try
            cmbMachineName.DisplayMember = "MachineName"
            cmbMachineName.ValueMember = "MachineId"

            If trxId = 0 Then
                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                prm(0).Value = 1

                dbMethod.FillCmbWithCaption("RdMntMachine", CommandType.StoredProcedure, "MachineId", "MachineName", cmbMachineName, "", prm)
            Else
                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
                prm(0).Value = Nothing

                dbMethod.FillCmbWithCaption("RdMntMachine", CommandType.StoredProcedure, "MachineId", "MachineName", cmbMachineName, "", prm)
            End If

            AddHandler cmbMachineName.Validating, AddressOf cmbMachineName_Validating
            AddHandler cmbMachineName.Validated, AddressOf cmbMachineName_Validated
            AddHandler cmbMachineName.SelectedValueChanged, AddressOf cmbMachineName_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

            If orgMachineGroupId = machinePartGroupId Then
                cmbMachinePart.SelectedValue = orgMachinePartId
            End If

            AddHandler cmbMachinePart.Validating, AddressOf cmbMachinePart_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillDowntimeStatus()
        Try
            cmbDowntimeStatus.DisplayMember = "MachineStatusName"
            cmbDowntimeStatus.ValueMember = "MachineStatusId"

            Dim prmMachineStatus(0) As SqlParameter
            prmMachineStatus(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
            prmMachineStatus(0).Value = Nothing

            dbMethod.FillCmbWithCaption("RdMntMachineStatus", CommandType.StoredProcedure, "MachineStatusId", "MachineStatusName", cmbDowntimeStatus, "< Select Machine Status >",
                                        prmMachineStatus)

            AddHandler cmbDowntimeStatus.SelectedValueChanged, AddressOf cmbDowntimeStatus_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillDowntimeSubStatus()
        Try
            cmbDowntimeSubStatus.DisplayMember = "MachineSubStatusName"
            cmbDowntimeSubStatus.ValueMember = "MachineSubStatusId"

            cmbDowntimeSubStatus.DataSource = Nothing
            cmbDowntimeSubStatus.Items.Clear()

            Dim prmMachineSubStatus(0) As SqlParameter
            prmMachineSubStatus(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
            prmMachineSubStatus(0).Value = cmbDowntimeStatus.SelectedValue

            dbMethod.FillCmbWithCaption("RdMntMachineSubStatus", CommandType.StoredProcedure, "MachineSubStatusId", "MachineSubStatusName",
                                        cmbDowntimeSubStatus, "< Select Sub-Status >", prmMachineSubStatus)

            AddHandler cmbDowntimeSubStatus.SelectedValueChanged, AddressOf cmbDowntimeSubStatus_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetMachineSchedule(machineId As Integer, Optional trxId As Integer = 0)
        Try
            If trxId = 0 Then
                Dim prmSchedule(0) As SqlParameter
                prmSchedule(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmSchedule(0).Value = machineId

                Dim query As String = "SELECT TOP 1 ScheduleId, MonthId, WeekId FROM VwMntMachineSchedule WHERE MachineId = @MachineId AND ActivityDate IS NULL AND IsDone = 0"
                Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSchedule)

                If rdrSchedule.Read Then
                    scheduleId = rdrSchedule.Item("ScheduleId")
                    monthId = rdrSchedule.Item("MonthId")
                    weekId = rdrSchedule.Item("WeekId")
                    txtScheduleMonth.Text = MonthName(monthId)
                    txtScheduleWeek.Text = weekId
                Else
                    cmbDowntimeSubStatus.SelectedValue = 0
                    MessageBox.Show("No PM schedule found for this machine.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                rdrSchedule.Close()
            Else
                If orgMachineId = machineId Then
                    If orgMachineSubStatusId = cmbDowntimeSubStatus.SelectedValue Then
                        Dim prmSchedule(1) As SqlParameter
                        prmSchedule(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prmSchedule(0).Value = machineId
                        prmSchedule(1) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmSchedule(1).Value = trxId

                        Dim query As String = "SELECT ScheduleId, MonthId, WeekId FROM VwMntMachineSchedule WHERE MachineId = @MachineId AND TrxId = @TrxId"
                        Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSchedule)

                        If rdrSchedule.Read Then
                            scheduleId = rdrSchedule.Item("ScheduleId")
                            txtScheduleMonth.Text = MonthName(rdrSchedule.Item("MonthId"))
                            txtScheduleWeek.Text = rdrSchedule.Item("WeekId")
                        End If
                        rdrSchedule.Close()
                    Else
                        Dim prmSchedule(0) As SqlParameter
                        prmSchedule(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                        prmSchedule(0).Value = machineId

                        Dim query As String = "SELECT TOP 1 ScheduleId, MonthId, WeekId FROM VwMntMachineSchedule WHERE MachineId = @MachineId AND ActivityDate IS NULL AND IsDone = 0"
                        Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSchedule)

                        If rdrSchedule.Read Then
                            scheduleId = rdrSchedule.Item("ScheduleId")
                            monthId = rdrSchedule.Item("MonthId")
                            weekId = rdrSchedule.Item("WeekId")
                            txtScheduleMonth.Text = MonthName(monthId)
                            txtScheduleWeek.Text = weekId
                        Else
                            cmbDowntimeSubStatus.SelectedValue = 0
                            MessageBox.Show("No PM schedule found for this machine.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        rdrSchedule.Close()
                    End If
                Else
                    Dim prmSchedule(0) As SqlParameter
                    prmSchedule(0) = New SqlParameter("@MachineId", SqlDbType.Int)
                    prmSchedule(0).Value = machineId

                    Dim query As String = "SELECT TOP 1 ScheduleId, MonthId, WeekId FROM VwMntMachineSchedule WHERE MachineId = @MachineId AND ActivityDate IS NULL AND IsDone = 0"
                    Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSchedule)

                    If rdrSchedule.Read Then
                        scheduleId = rdrSchedule.Item("ScheduleId")
                        monthId = rdrSchedule.Item("MonthId")
                        weekId = rdrSchedule.Item("WeekId")
                        txtScheduleMonth.Text = MonthName(monthId)
                        txtScheduleWeek.Text = weekId
                    Else
                        cmbDowntimeSubStatus.SelectedValue = 0
                        MessageBox.Show("No PM schedule found for this machine.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    rdrSchedule.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillPic()
        Try
            If dgvDetail.Rows.Count > 0 Then
                Dim filterBuilder As New System.Text.StringBuilder("SectionId = 2 AND UserId NOT IN (")

                For i As Integer = 0 To dgvDetail.Rows.Count - 1
                    If i > 0 Then
                        filterBuilder.Append(",")
                    End If
                    filterBuilder.Append(dgvDetail.Rows(i).Cells("ColNickname").Value)
                Next

                filterBuilder.Append(")")

                Me.bsTransactionUser.Filter = filterBuilder.ToString
            Else
                Me.bsTransactionUser.Filter = String.Format("SectionId = 2")
            End If
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
            txtPartsReplaced.Enabled = False
            txtPartsNo.Enabled = False
            txtJoNumber.Enabled = False
            txtJoRequestor.Enabled = False

            txtScheduleMonth.Text = String.Empty
            txtScheduleMonth.Enabled = False
            txtScheduleWeek.Text = String.Empty
            txtScheduleWeek.Enabled = False

            btnAddRow.Enabled = False
            btnRemoveRow.Enabled = False
            btnViewImage.Enabled = False
            btnBrowseImage.Enabled = False
            btnRemoveImage.Enabled = False
            btnViewChecksheet.Enabled = False
            btnRemoveChecksheet.Enabled = False
            btnView4M.Enabled = False
            btnRemove4M.Enabled = False

        Else
            cmbTransactionStatus.Enabled = True
            cmbDowntimeStatus.Enabled = True

            txtProblem.Enabled = True
            txtRootCause.Enabled = True
            txtActionTaken.Enabled = True
            txtPartsReplaced.Enabled = True
            txtJoNumber.Enabled = True
            txtJoRequestor.Enabled = True

            btnAddRow.Enabled = True
            btnRemoveRow.Enabled = True
            btnViewImage.Enabled = True
            btnBrowseImage.Enabled = True
            btnRemoveImage.Enabled = True
            btnViewChecksheet.Enabled = True
            btnRemoveChecksheet.Enabled = True
            btnView4M.Enabled = True
            btnRemove4M.Enabled = True
        End If
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

    Private Sub trxDate_Format(sender As Object, e As ConvertEventArgs) Handles trxDate.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy  HH:mm")
        Else
            e.Value = CDate(dbMethod.GetServerDate).ToString("MMMM dd, yyyy  HH:mm")
        End If
    End Sub

    Private Sub cmbTransactionStatus_Enter(sender As Object, e As EventArgs) Handles cmbTransactionStatus.Enter
        lblTransactionStatus.ForeColor = Color.White
        lblTransactionStatus.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbTransactionStatus_Leave(sender As Object, e As EventArgs) Handles cmbTransactionStatus.Leave
        lblTransactionStatus.ForeColor = Color.Black
        lblTransactionStatus.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbMachineName_Enter(sender As Object, e As EventArgs) Handles cmbMachineName.Enter
        lblMachineName.ForeColor = Color.White
        lblMachineName.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbMachineName_Leave(sender As Object, e As EventArgs) Handles cmbMachineName.Leave
        lblMachineName.ForeColor = Color.Black
        lblMachineName.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbMachinePart_Enter(sender As Object, e As EventArgs) Handles cmbMachinePart.Enter
        lblMachinePart.ForeColor = Color.White
        lblMachinePart.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbMachinePart_Leave(sender As Object, e As EventArgs) Handles cmbMachinePart.Leave
        lblMachinePart.ForeColor = Color.Black
        lblMachinePart.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbDowntimeStatus_Enter(sender As Object, e As EventArgs) Handles cmbDowntimeStatus.Enter
        lblDowntimeStatus.ForeColor = Color.White
        lblDowntimeStatus.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbDowntimeStatus_Leave(sender As Object, e As EventArgs) Handles cmbDowntimeStatus.Leave
        lblDowntimeStatus.ForeColor = Color.Black
        lblDowntimeStatus.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbDowntimeSubStatus_Enter(sender As Object, e As EventArgs) Handles cmbDowntimeSubStatus.Enter
        lblDowntimeSubStatus.ForeColor = Color.White
        lblDowntimeSubStatus.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbDowntimeSubStatus_Leave(sender As Object, e As EventArgs) Handles cmbDowntimeSubStatus.Leave
        lblDowntimeSubStatus.ForeColor = Color.Black
        lblDowntimeSubStatus.BackColor = SystemColors.Control
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

    Private Sub txtPartsNo_Enter(sender As Object, e As EventArgs) Handles txtPartsNo.Enter
        lblPartsNo.ForeColor = Color.White
        lblPartsNo.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtPartsNo_Leave(sender As Object, e As EventArgs) Handles txtPartsNo.Leave
        lblPartsNo.ForeColor = Color.Black
        lblPartsNo.BackColor = SystemColors.Control
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

    Private Sub dgvDetail_Enter(sender As Object, e As EventArgs) Handles dgvDetail.Enter
        lblActivityLog.ForeColor = Color.White
        lblActivityLog.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub dgvDetail_Leave(sender As Object, e As EventArgs) Handles dgvDetail.Leave
        lblActivityLog.ForeColor = Color.Black
        lblActivityLog.BackColor = SystemColors.Control
    End Sub

    Private Sub btnAddRow_Enter(sender As Object, e As EventArgs) Handles btnAddRow.Enter
        lblActivityLog.ForeColor = Color.White
        lblActivityLog.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub btnAddRow_Leave(sender As Object, e As EventArgs) Handles btnAddRow.Leave
        lblActivityLog.ForeColor = Color.Black
        lblActivityLog.BackColor = SystemColors.Control
    End Sub

    Private Sub btnRemoveRow_Enter(sender As Object, e As EventArgs) Handles btnRemoveRow.Enter
        lblActivityLog.ForeColor = Color.White
        lblActivityLog.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub btnRemoveRow_Leave(sender As Object, e As EventArgs) Handles btnRemoveRow.Leave
        lblActivityLog.ForeColor = Color.Black
        lblActivityLog.BackColor = SystemColors.Control
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

    Private Sub txtChecksheet_Enter(sender As Object, e As EventArgs) Handles txtChecksheet.Enter
        lblChecksheet.ForeColor = Color.White
        lblChecksheet.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtChecksheet_Leave(sender As Object, e As EventArgs) Handles txtChecksheet.Leave
        lblChecksheet.ForeColor = Color.Black
        lblChecksheet.BackColor = SystemColors.Control
    End Sub
    Private Sub txt4M_Enter(sender As Object, e As EventArgs) Handles txt4M.Enter
        lbl4M.ForeColor = Color.White
        lbl4M.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txt4M_Leave(sender As Object, e As EventArgs) Handles txt4M.Leave
        lbl4M.ForeColor = Color.Black
        lbl4M.BackColor = SystemColors.Control
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

End Class