Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports BlackCoffeeLibrary
Imports MachineMonitoringSystem.dsMonitoring
Imports MachineMonitoringSystem.dsMonitoringTableAdapters

Public Class frmMntTrxDetailOth
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
    Private areaId As Integer = 0
    Private trxCount As Integer = 0

    Private isAdmin As Boolean = True
    Private isValidate As Boolean = True

    Private imgTmp As String = String.Empty
    Private orgFilename As String = String.Empty
    Private serverNetUserName As String = String.Empty
    Private serverNetUserPassword As String = String.Empty

    Private imgDirectory As String = directories.ImageInitialDirectory
    Private attDirectory As String = directories.AttachmentInitialDirectory

    Private lstImgAttachment As New List(Of clsImgAttachment)
    Private lstAttachment As New List(Of clsAttachment)
    Private lstAttachmentDelete As New List(Of clsAttachment)
    Private lstAttachmentCopy As New List(Of clsAttachment)
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
        FillArea()
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

            If Not CType(Me.bsTransactionHeader.Current, DataRowView).Item("FileName") Is DBNull.Value Then
                Dim fileName As String = CType(Me.bsTransactionHeader.Current, DataRowView).Item("FileName").ToString.Trim
                Dim oldAttachment As New clsAttachment(Path.Combine(attDirectory, fileName), fileName, Path.GetExtension(Path.Combine(attDirectory, fileName)))
                lstAttachment.Add(oldAttachment)
                txtAttachment.Text = fileName
                orgFilename = CType(Me.bsTransactionHeader.Current, DataRowView).Item("FileName").ToString.Trim
            End If

            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub frmMntTrxDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If trxId = 0 Then
                DisableForm(True)
                Me.ActiveControl = cmbArea
            Else
                trxDate = New Binding("Text", Me.bsTransactionHeader.Current, "TrxDate")
                txtTransactionDate.DataBindings.Add(trxDate)

                cmbTransactionStatus.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "TrxStatusId"))
                cmbArea.DataBindings.Add(New Binding("SelectedValue", Me.bsTransactionHeader.Current, "AreaId"))

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

                txtPartsReplaced.DataBindings.Add(New Binding("Text", Me.bsTransactionSparePart.Current, "SparePartName"))
                txtPartsNo.DataBindings.Add(New Binding("Text", Me.bsTransactionSparePart.Current, "SparePartNo"))

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

    Private Sub frmMntTrxDetailOth_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        impersonation.UndoImpersonateUser()
    End Sub

    Private Sub cmbArea_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbArea.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbArea_Validated(sender As Object, e As EventArgs)
        Try
            If cmbArea.SelectedValue = 0 Then
                DisableForm(True)
            Else
                DisableForm(False)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbArea_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbArea.SelectedValue = 0 Then
                DisableForm(True)
            Else
                DisableForm(False)
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

            Dim attachment As New clsImgAttachment(ofdImage.FileName, ofdImage.SafeFileName, Path.GetExtension(ofdImage.SafeFileName).ToLower)
            lstImgAttachment.Add(attachment)

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
            If lstAttachment.Count > 0 Then
                Process.Start(lstAttachment(0).FileName)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBrowseChecksheet_Click(sender As Object, e As EventArgs) Handles btnBrowseChecksheet.Click
        Try
            ofdAttachment.Filter = "Image Files (*.jpeg, *.png) | *.jpg; *.jpeg; *.png; *.bmp; *.gif; *.tif; *.tiff; |" &
                                   "Word Documents (*.doc) | *.doc; *.docx; |" &
                                   "Excel Worksheets (*.xls, *.xlsx) | *.xls; *.xlsx |" &
                                   "Presentation Files (*.ppt, *pptx) | *.ppt; *.pptx; *.odp; |" &
                                   "PDF Files (*.pdf) | *.pdf; |" &
                                   "Text Files (*.txt) | *.txt |" &
                                   "All Files (*.*) | *.*"
            ofdAttachment.FilterIndex = 7
            ofdAttachment.ShowDialog()
            ofdAttachment.RestoreDirectory = True
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ofdAttachment_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdAttachment.FileOk
        Try
            If Not String.IsNullOrEmpty(txtAttachment.Text.Trim) Then
                If lstAttachment.Count > 0 Then lstAttachment.RemoveAt(0)
                txtAttachment.Text = String.Empty
            End If

            Dim checksheet As New clsAttachment(ofdAttachment.FileName, ofdAttachment.SafeFileName, Path.GetExtension(ofdAttachment.SafeFileName).ToLower)
            lstAttachment.Add(checksheet)

            txtAttachment.Text = Path.GetFileName(ofdAttachment.FileName)
            ofdAttachment.InitialDirectory = Path.GetDirectoryName(lstAttachment(0).FileName)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveChecksheet_Click(sender As Object, e As EventArgs) Handles btnRemoveChecksheet.Click
        Try
            If Not String.IsNullOrEmpty(txtAttachment.Text.Trim) Then
                If lstAttachment.Count > 0 Then lstAttachment.RemoveAt(0)
                txtAttachment.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If cmbArea.SelectedValue = 0 Then
                MessageBox.Show("Please select an area.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbArea.Focus()
                Return
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
                    .SetMachineIdNull()
                    .SetDowntimeMachineStatusIdNull()
                    .SetDowntimeMachineSubStatusIdNull()
                    .SetJigIdNull()
                    .SetDowntimeJigStatusIdNull()
                    .AreaId = cmbArea.SelectedValue
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

                        If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                            MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtProblem.Focus()
                            Return
                        Else
                            .Problem = txtProblem.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then .SetRootCauseNull() Else .RootCause = txtRootCause.Text.Trim

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

                        Dim img As Image = Image.FromFile(lstImgAttachment(0).FileName)
                        Dim bite As Byte() = dbMain.ImageToByteArray(img)
                        .Image = bite
                        .ImageName = txtImageName.Text.ToString.Trim

                        If String.IsNullOrEmpty(txtAttachment.Text.Trim) Then
                            .SetFileAttachmentNull()
                            .SetFileNameNull()
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

                        If String.IsNullOrEmpty(txtProblem.Text.Trim) Then .SetProblemNull() Else .Problem = txtProblem.Text.Trim
                        If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then .SetRootCauseNull() Else .RootCause = txtRootCause.Text.Trim
                        If String.IsNullOrEmpty(txtActionTaken.Text.Trim) Then .SetActionTakenNull() Else .ActionTaken = txtActionTaken.Text.Trim

                        If picImage.Image Is Nothing Then
                            .SetImageNull()
                            .SetImageNameNull()
                        Else
                            Dim img As Image = Image.FromFile(lstImgAttachment(0).FileName)
                            Dim bite As Byte() = dbMain.ImageToByteArray(img)
                            .Image = bite
                            .ImageName = txtImageName.Text.ToString.Trim
                        End If

                        If String.IsNullOrEmpty(txtAttachment.Text.Trim) Then
                            .SetFileAttachmentNull()
                            .SetFileNameNull()
                        End If
                    End If
                End With
                Me.dsMonitoring.MntTransactionHeader.AddMntTransactionHeaderRow(newRowHeader)
                Me.adpTransactionHeader.Update(Me.dsMonitoring.MntTransactionHeader)

                If lstAttachment.Count > 0 AndAlso Not String.IsNullOrEmpty(txtAttachment.Text.Trim) Then
                    For i As Integer = 0 To lstAttachment.Count - 1
                        Dim extension As String = String.Empty
                        Dim filename As String = String.Empty
                        extension = Path.GetExtension(lstAttachment(i).FileName).ToLower
                        filename = newRowHeader.TrxId & extension

                        Me.adpTransactionHeader.UpdMntTransactionHeaderByFileName(newRowHeader.TrxId, filename)

                        progBar.Visible = True
                        lblProgress.Visible = True

                        Dim copyChecksheet As New clsAttachment(lstAttachment(i).FileName, filename, Path.GetExtension(lstAttachment(i).FileName).ToLower)
                        lstAttachmentCopy.Add(copyChecksheet)
                    Next
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
                    .AreaId = cmbArea.SelectedValue
                    .TrxStatusId = cmbTransactionStatus.SelectedValue
                    .ModifiedBy = userId
                    .ModifiedDate = dbMethod.GetServerDate
                    If String.IsNullOrEmpty(txtRuntimeAccumulated.Text.Trim) Then .SetTotalAccumulatedRuntimeNull() Else .TotalAccumulatedRuntime = txtRuntimeAccumulated.Text.Trim
                    If String.IsNullOrEmpty(txtJoNumber.Text.Trim) Then .SetJoNumberNull() Else .JoNumber = txtJoNumber.Text.Trim
                    If String.IsNullOrEmpty(txtJoRequestor.Text.Trim) Then .SetJoRequestorNull() Else .JoRequestor = txtJoRequestor.Text.Trim

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

                        If String.IsNullOrEmpty(txtProblem.Text.Trim) Then
                            MessageBox.Show("Please indicate the problem.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtProblem.Focus()
                            Return
                        Else
                            .Problem = txtProblem.Text.Trim
                        End If

                        If String.IsNullOrEmpty(txtRootCause.Text.Trim) Then .SetRootCauseNull() Else .RootCause = txtRootCause.Text.Trim

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
                            Dim img As Image = Image.FromFile(lstImgAttachment(0).FileName)
                            Dim bite As Byte() = dbMain.ImageToByteArray(img)
                            .Image = bite
                            .ImageName = txtImageName.Text.ToString.Trim
                        End If

                        If String.IsNullOrEmpty(txtAttachment.Text.Trim) Then
                            If Not .IsFileNameNull Then
                                Dim extension As String = String.Empty
                                Dim filename As String = String.Empty
                                extension = Path.GetExtension(.FileName.ToString.Trim).ToLower
                                filename = trxId & extension
                                Dim delChecksheet As New clsAttachment(attDirectory & "\" & .FileName.ToString.Trim, filename, Path.GetExtension(Path.Combine(attDirectory, filename)))
                                lstAttachmentDelete.Add(delChecksheet)
                            End If

                            .SetFileAttachmentNull()
                            .SetFileNameNull()
                        End If
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
                                Dim img As Image = Image.FromFile(lstImgAttachment(0).FileName)
                                Dim bite As Byte() = dbMain.ImageToByteArray(img)
                                .Image = bite
                                .ImageName = txtImageName.Text.ToString.Trim
                            End If
                        End If

                        If String.IsNullOrEmpty(txtAttachment.Text.Trim) Then
                            If Not .IsFileNameNull Then
                                Dim extension As String = String.Empty
                                Dim filename As String = String.Empty
                                extension = Path.GetExtension(.FileName.ToString.Trim).ToLower
                                filename = trxId & extension
                                Dim delChecksheet As New clsAttachment(attDirectory & "\" & .FileName.ToString.Trim, filename, Path.GetExtension(Path.Combine(attDirectory, filename)))
                                lstAttachmentDelete.Add(delChecksheet)
                            End If

                            .SetFileAttachmentNull()
                            .SetFileNameNull()
                        End If
                    End If

                    If Not .IsFileNameNull AndAlso orgFilename <> txtAttachment.Text.Trim Then
                        If File.Exists(Path.Combine(attDirectory, .FileName.ToString.Trim)) Then
                            File.Delete(Path.Combine(attDirectory, .FileName.ToString.Trim))
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

                If lstAttachmentDelete.Count > 0 Then
                    File.Delete(lstAttachmentDelete(0).FileName)
                End If

                If lstAttachment.Count > 0 AndAlso Not String.IsNullOrEmpty(txtAttachment.Text.Trim) Then
                    If orgFilename <> txtAttachment.Text.Trim Then
                        For i As Integer = 0 To lstAttachment.Count - 1
                            Dim extension As String = String.Empty
                            Dim filename As String = String.Empty
                            extension = Path.GetExtension(lstAttachment(i).FileName).ToLower
                            filename = trxId & extension

                            Me.adpTransactionHeader.UpdMntTransactionHeaderByFileName(trxId, filename)

                            progBar.Visible = True
                            lblProgress.Visible = True

                            Dim copyChecksheet As New clsAttachment(lstAttachment(i).FileName, filename, Path.GetExtension(lstAttachment(i).FileName).ToLower)
                            lstAttachmentCopy.Add(copyChecksheet)
                        Next
                    End If
                End If
            End If

            If lstAttachmentCopy.Count > 0 Then
                progBar.Visible = True
                lblProgress.Visible = True

                btnAddRow.Enabled = False
                btnDelete.Enabled = False
                btnViewImage.Enabled = False
                btnBrowseImage.Enabled = False
                btnRemoveImage.Enabled = False
                btnViewChecksheet.Enabled = False
                btnBrowseChecksheet.Enabled = False
                btnRemoveChecksheet.Enabled = False

                btnSave.Enabled = False
                btnCancel.Enabled = False
                btnDelete.Enabled = False
                btnClose.Enabled = False

                bgWorker.RunWorkerAsync()
                Me.dsMonitoring.AcceptChanges()
            Else
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If cmbArea.SelectedValue = 0 Then
                DisableForm(True)
                Exit Sub
            End If

            If btnDelete.Enabled = False Then
                Exit Sub
            End If

            If trxId > 0 Then
                Dim question As String = String.Format("Are you sure you want to delete this record?")

                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
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

    Private Sub bgWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork
        If lstAttachmentCopy.Count > 0 Then
            Dim streamRead As System.IO.FileStream
            Dim streamWrite As System.IO.FileStream

            For i As Integer = 0 To lstAttachmentCopy.Count - 1
                streamRead = New System.IO.FileStream(lstAttachmentCopy(i).FileName, System.IO.FileMode.Open)
                streamWrite = New System.IO.FileStream(attDirectory & "\" & lstAttachmentCopy(i).SafeName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)

                Dim lngLen As Long = streamRead.Length - 1
                Dim byteBuffer(4096) As Byte
                Dim intBytesRead As Integer

                ShowProgress("Uploading files : (0/" + (lngLen * 100).ToString + ")", lblProgress)

                While streamRead.Position < lngLen
                    If (bgWorker.CancellationPending = True) Then
                        e.Cancel = True
                        Exit While
                    End If

                    bgWorker.ReportProgress(CInt(streamRead.Position / lngLen * 100))
                    ShowProgress("Uploading attachment : (" + CInt(streamRead.Position).ToString + "/" + (lngLen * 100).ToString + ")", lblProgress)
                    intBytesRead = (streamRead.Read(byteBuffer, 0, 4096))

                    streamWrite.Write(byteBuffer, 0, intBytesRead)
                End While

                streamRead.Dispose()
                streamWrite.Dispose()
            Next
        End If
    End Sub

    Private Sub ShowProgress(ByVal text As String, ByVal lbl As Label)
        If lbl.InvokeRequired Then
            lbl.Invoke(New SetProgressInvoker(AddressOf ShowProgress), text, lbl)
        Else
            lbl.Text = text
        End If
    End Sub

    Private Delegate Sub SetProgressInvoker(textProgress As String, labelProgress As Label)

    Private Sub bgWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgWorker.ProgressChanged
        progBar.Value = e.ProgressPercentage
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        If e.Cancelled = True Then
            progBar.Visible = False
            lblProgress.Visible = False

            btnAddRow.Enabled = True
            btnDelete.Enabled = True
            btnViewImage.Enabled = True
            btnBrowseImage.Enabled = True
            btnRemoveImage.Enabled = True
            btnViewChecksheet.Enabled = True
            btnBrowseChecksheet.Enabled = True
            btnRemoveChecksheet.Enabled = True

            btnSave.Enabled = True
            btnCancel.Enabled = True
            btnDelete.Enabled = True
            btnClose.Enabled = True
        Else
            Me.DialogResult = DialogResult.OK
        End If
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

    Private Sub FillArea()
        Try
            cmbArea.DisplayMember = "AreaName"
            cmbArea.ValueMember = "AreaId"
            dbMethod.FillCmbWithCaption("RdMntArea", CommandType.StoredProcedure, "AreaId", "AreaName", cmbArea, "< Select Area >")
            AddHandler cmbArea.Validating, AddressOf cmbArea_Validating
            AddHandler cmbArea.Validated, AddressOf cmbArea_Validated
            AddHandler cmbArea.SelectedValueChanged, AddressOf cmbArea_SelectedValueChanged
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

            txtProblem.Enabled = False
            txtRootCause.Enabled = False
            txtActionTaken.Enabled = False
            txtPartsReplaced.Enabled = False
            txtPartsNo.Enabled = False
            txtJoNumber.Enabled = False
            txtJoRequestor.Enabled = False

            btnAddRow.Enabled = False
            btnRemoveRow.Enabled = False
            btnViewImage.Enabled = False
            btnBrowseImage.Enabled = False
            btnRemoveImage.Enabled = False
            btnViewChecksheet.Enabled = False
            btnBrowseChecksheet.Enabled = False
            btnRemoveChecksheet.Enabled = False
        Else
            cmbTransactionStatus.Enabled = True

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
            btnBrowseChecksheet.Enabled = True
            btnRemoveChecksheet.Enabled = True

            If Not String.IsNullOrEmpty(txtPartsReplaced.Text.Trim) Then
                txtPartsNo.Enabled = True
            Else
                txtPartsNo.Enabled = False
            End If
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