Imports BlackCoffeeLibrary
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class MntTrxDetailJig
    Private dbConnection As New Connection
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)
    Private dbMain As New BlackCoffeeLibrary.Main
    Private directory As New Directory
    Private impersonation As New UserImpersonation.UserImpersonation

    Private adpTrxDetail As New SqlDataAdapter

    Private dtRoutingStatus As New DataTable
    Private dtSecUserLog As New DataTable
    Private dtSecUserPic As New DataTable

    Private dtTrxHeader As New DataTable
    Private dtTrxDetail As New DataTable
    Private dtTrxSparePart As New DataTable
    Private dtTrxUser As New DataTable

    Private WithEvents bsTrxDetail As New BindingSource
    Private WithEvents bsTrxUser As New BindingSource
    Private WithEvents bsSecUserLog As New BindingSource

    Private mStream As New MemoryStream
    Private bite As Byte() 'the word `byte` is not a valid identifier

    Private userId As Integer
    Private workgroupId As Integer = 0
    Private isAdmin As Boolean = True
    Private trxId As Integer = 0

    Private jigId As Integer = 0
    Private areaId As Integer = 0

    Private scheduleId As Integer = 0
    Private monthId As Integer = 0
    Private weekId As Integer = 0

    Private trxCount As Integer = 0

    Private imgTmp As String = String.Empty

    Private orgJigId As Integer = 0
    Private orgJigSubStatusId As Integer = 0
    Private orgScheduleId As Integer = 0

    Private serverNetUserName As String = String.Empty
    Private serverNetUserPassword As String = String.Empty

    Private imgDirectory As String = directory.ImageInitialDirectory

    Private lstImgAttachment As New List(Of ImgAttachment)

    Private superiorWorkgroupId As New List(Of Integer) From {29, 30, 35, 2} 'asv, sv, asm, smngr

    Public Property fromPmCalendar As Boolean = False

    Public Sub New(_userId As Integer, _workgroupId As Integer, _isAdmin As Boolean, Optional _trxId As Integer = 0)

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

        dtTrxDetail = CreateTrxDetail()
        dtRoutingStatus = dbMethod.FillDataTable("RdGenRoutingStatus", CommandType.StoredProcedure)
        dtSecUserLog = dbMethod.FillDataTable("RdSecUser", CommandType.StoredProcedure)
        dtSecUserPic = dbMethod.FillDataTable("RdSecUser", CommandType.StoredProcedure)

        Me.bsSecUserLog.DataSource = dtSecUserLog

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

        'pic table
        Me.bsTrxUser.DataSource = dtSecUserPic
        Me.bsTrxUser.Filter = String.Format("SectionId = 2")
        dgvPic.AutoGenerateColumns = False
        dgvPic.DataSource = Me.bsTrxUser

        LoadTransactionStatus()
        LoadJig()
        GetSetting(My.Settings.SettingsId)
        impersonation.ImpersonateUser(serverNetUserName, "", serverNetUserPassword)

        If trxId = 0 Then
            Me.bsTrxDetail.DataSource = dtTrxDetail
            Me.bsTrxDetail.Filter = String.Format("TrxId IS NULL")
            dgvDetail.AutoGenerateColumns = False
            dgvDetail.DataSource = Me.bsTrxDetail
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
            Me.bsTrxDetail.Position = Me.bsTrxDetail.Find("TrxId", trxId)
            Me.bsTrxDetail.Sort = "TrxFrom"
            dgvDetail.AutoGenerateColumns = False
            dgvDetail.DataSource = Me.bsTrxDetail

            'transaction spare part
            Dim prmSparePart(0) As SqlParameter
            prmSparePart(0) = New SqlParameter("@TrxId", SqlDbType.Int)
            prmSparePart(0).Value = trxId
            dtTrxSparePart = dbMethod.FillDataTable("RdMntTransactionSparePartByTrxId", CommandType.StoredProcedure, prmSparePart)

            'transaction user
            Dim prmUser(0) As SqlParameter
            prmUser(0) = New SqlParameter("@TrxId", SqlDbType.Int)
            prmUser(0).Value = trxId
            dtTrxUser = dbMethod.FillDataTable("RdMntTransactionUserByTrxId", CommandType.StoredProcedure, prmUser)

            FilterPicTable()
        End If
    End Sub

    Private Sub frmMntTrxDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If trxId = 0 Then
                Me.Text = "New Activity Entry"

                txtTransactionDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", dbMethod.GetServerDate)

                Dim dRow As DataRow = dtRoutingStatus.Select("RoutingStatusId = 5")(0)
                txtRoutingStatus.Text = dRow("RoutingStatusName").ToString.Trim

                btnDelete.Enabled = False

                DisableForm(True)
                Me.ActiveControl = cmbJigName
            Else
                Me.Text = "Activity No. " & trxId & ""

                For Each row As DataRow In dtTrxHeader.Rows
                    orgJigId = row("JigId")
                    orgJigSubStatusId = row("DowntimeJigSubStatusId")

                    'transaction header
                    Dim dRow As DataRow = dtRoutingStatus.Select("RoutingStatusId = " & row("RoutingStatusId") & "")(0)
                    txtRoutingStatus.Text = dRow("RoutingStatusName").ToString.Trim

                    txtTransactionDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("TrxDate"))
                    cmbTransactionStatus.SelectedValue = row("TrxStatusId")
                    cmbJigName.SelectedValue = row("JigId")
                    cmbDowntimeStatus.SelectedValue = row("DowntimeJigStatusId")
                    cmbDowntimeSubStatus.SelectedValue = row("DowntimeJigSubStatusId")

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
                        txtJoNumber.Text = row("JoNumber")
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
                Next

                For Each row As DataRow In dtTrxSparePart.Rows
                    If Not row("SparePartName") Is DBNull.Value AndAlso Not row("SparePartNo") Is DBNull.Value Then
                        txtPartsReplaced.Text = row("SparePartName")
                        txtPartsNo.Text = row("SparePartNo")
                    End If
                Next

                btnDelete.Enabled = True

                imgTmp = Path.Combine(IO.Path.GetTempPath, "tmpImg." & Path.GetExtension(txtImageName.Text))

                Me.ActiveControl = txtProblem
                txtProblem.Select(txtProblem.Text.ToString.Trim.Length, 0)
            End If

            If fromPmCalendar = True Then
                cmbTransactionStatus.Enabled = False
                cmbJigName.Enabled = False
                pnlJigPart.Enabled = False
                cmbDowntimeStatus.Enabled = False
                cmbDowntimeSubStatus.Enabled = False
                txtScheduleMonth.Enabled = False
                txtScheduleWeek.Enabled = False
                txtProblem.Enabled = False
                txtRootCause.Enabled = False
                txtActionTaken.Enabled = False
                txtPartsReplaced.Enabled = False
                txtPartsNo.Enabled = False
                txtJoNumber.Enabled = False
                txtJoRequestor.Enabled = False
                txtChecksheet.Enabled = False
                txt4M.Enabled = False

                btnViewImage.Enabled = False

                btnAddRow.Enabled = False
                btnRemoveRow.Enabled = False
                btnBrowseImage.Enabled = False
                btnRemoveImage.Enabled = False
                btnRemoveChecksheet.Enabled = False
                btnRemove4M.Enabled = False

                dgvPic.Enabled = False
                dgvDetail.Enabled = False

                btnSave.Enabled = False
                btnCancel.Enabled = False
                btnDelete.Enabled = False
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

    Private Sub frmMntTrxDetailJig_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        impersonation.UndoImpersonateUser()
    End Sub

    Private Sub cmbJigName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbJigName.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbJigName_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbJigName.SelectedValue = 0 Then
                DisableForm(True)
            Else
                DisableForm(False)
                GetJigArea(cmbJigName.SelectedValue)
                GetTotalRuntime(cmbJigName.SelectedValue)
                LoadDowntimeStatus()
                LoadDowntimeSubStatus(cmbDowntimeStatus.SelectedValue)

                If trxId = 0 Then
                    cmbDowntimeStatus.SelectedValue = 3
                    cmbDowntimeSubStatus.SelectedValue = 4
                End If

                If orgJigId = cmbJigName.SelectedValue AndAlso trxId <> 0 Then
                    If Not dtTrxHeader.Rows(0).Item("TotalAccumulatedRuntime") Is DBNull.Value Then
                        txtRuntimeAccumulated.Text = dtTrxHeader.Rows(0).Item("TotalAccumulatedRuntime")
                    End If

                Else
                    GetTotalRuntime(cmbJigName.SelectedValue)
                End If
            End If
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
                LoadDowntimeSubStatus(cmbDowntimeStatus.SelectedValue)
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

                scheduleId = 0
                monthId = 0
                weekId = 0
            Else
                If cmbDowntimeSubStatus.SelectedValue = 2 Then 'preventive maintenance
                    If orgJigId = cmbJigName.SelectedValue Then
                        GetJigSchedule(cmbJigName.SelectedValue, trxId)
                    Else
                        GetJigSchedule(cmbJigName.SelectedValue)
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
        For Each row As DataRow In dtTrxUser.Rows
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

    Private Sub dgvPic_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvPic.DataError
        e.Cancel = False
    End Sub

    Private Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        Try
            If trxId = 0 Then
                Using frmDetailLog As New MntTrxActvityLog(userId)
                    If frmDetailLog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Me.bsTrxDetail.AddNew()
                        Me.bsTrxDetail.MoveLast()
                        Me.bsTrxDetail.Current("TrxId") = DBNull.Value
                        Me.bsTrxDetail.Current("TrxDate") = CDate(dbMethod.GetServerDate).Date
                        Me.bsTrxDetail.Current("TrxFrom") = frmDetailLog.dtpFrom.Value
                        Me.bsTrxDetail.Current("TrxTo") = frmDetailLog.dtpTo.Value
                        Me.bsTrxDetail.Current("ElapsedTime") = frmDetailLog.txtElapsedTime.Text.Trim
                        Me.bsTrxDetail.Current("UserId") = frmDetailLog.cmbTechnician.SelectedValue
                        Me.bsTrxDetail.Current("ShiftId") = IIf(frmDetailLog.rdDay.Checked = True, "D", "N")
                        Me.bsTrxDetail.Sort = "TrxFrom"
                        Me.bsTrxDetail.EndEdit()
                    Else
                        Me.bsTrxDetail.CancelEdit()
                    End If
                End Using
            Else
                Using frmDetailLog As New MntTrxActvityLog(userId, trxId)
                    If frmDetailLog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Me.bsTrxDetail.AddNew()
                        Me.bsTrxDetail.MoveLast()
                        Me.bsTrxDetail.Current("TrxId") = trxId
                        Me.bsTrxDetail.Current("TrxDate") = DateTime.Now
                        Me.bsTrxDetail.Current("TrxFrom") = frmDetailLog.dtpFrom.Value
                        Me.bsTrxDetail.Current("TrxTo") = frmDetailLog.dtpTo.Value
                        Me.bsTrxDetail.Current("ElapsedTime") = frmDetailLog.txtElapsedTime.Text.Trim
                        Me.bsTrxDetail.Current("UserId") = frmDetailLog.cmbTechnician.SelectedValue
                        Me.bsTrxDetail.Current("ShiftId") = IIf(frmDetailLog.rdDay.Checked = True, "D", "N")
                        Me.bsTrxDetail.Sort = "TrxFrom"
                        Me.bsTrxDetail.EndEdit()
                    Else
                        Me.bsTrxDetail.CancelEdit()
                    End If
                End Using
            End If

            FilterPicTable()
            GetTotalDowntime()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveRow_Click(sender As Object, e As EventArgs) Handles btnRemoveRow.Click
        Try
            If dgvDetail.Rows.Count > 0 Then
                Dim currentRow = CType(Me.bsTrxDetail.Current, DataRowView).Row
                Dim rowState = currentRow.RowState


                Select Case rowState
                    Case DataRowState.Added
                        Dim message = String.Format("Are you sure you want to delete this log?")
                        If MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Me.bsTrxDetail.RemoveCurrent()
                        End If

                    Case DataRowState.Detached
                        Dim message = String.Format("Are you sure you want to delete this log?")
                        If MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Me.bsTrxDetail.CancelEdit()
                        End If

                    Case DataRowState.Modified, DataRowState.Unchanged
                        If dgvDetail.SelectedCells.Count > 0 AndAlso dgvDetail.SelectedCells(0).RowIndex = dgvDetail.NewRowIndex Then
                            Me.bsTrxDetail.CancelEdit()
                            Exit Sub
                        End If

                        Dim message = String.Format("Are you sure you want to delete this log?")
                        If MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Me.bsTrxDetail.RemoveCurrent()
                        End If

                    Case Else

                End Select
            End If

            Me.bsTrxDetail.Sort = "TrxFrom"

            FilterPicTable()
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

            Dim attachment As New ImgAttachment(ofdImage.FileName, ofdImage.SafeFileName, Path.GetExtension(ofdImage.SafeFileName).ToLower)
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
            If Not String.IsNullOrEmpty(txtChecksheet.Text.Trim) Then
                Process.Start(txtChecksheet.Text)
            End If
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

    Private Sub btnRemoveChecksheet_Click(sender As Object, e As EventArgs)
        Try
            txtChecksheet.Text = String.Empty
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
            If cmbJigName.SelectedValue = 0 Then
                MessageBox.Show("Please select a jig.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbJigName.Focus()
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

            If cmbDowntimeSubStatus.SelectedValue = 2 AndAlso (String.IsNullOrEmpty(txtScheduleMonth.Text) Or String.IsNullOrEmpty(txtScheduleWeek.Text)) Then
                If String.IsNullOrEmpty(txtScheduleMonth.Text) Then
                    MessageBox.Show("Please input the PM month schedule", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtScheduleMonth.Focus()
                    Return
                End If

                If String.IsNullOrEmpty(txtScheduleWeek.Text) Then
                    MessageBox.Show("Please input the PM week schedule.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtScheduleWeek.Focus()
                    Return
                End If
            End If

            If Not String.IsNullOrEmpty(txtPartsReplaced.Text) AndAlso String.IsNullOrEmpty(txtPartsNo.Text) Then
                MessageBox.Show("Please input the spare parts number.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPartsNo.Focus()
                Return
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
                prmHeader(3).Value = Nothing
                prmHeader(4) = New SqlParameter("@DowntimeMachineStatusId", SqlDbType.Int)
                prmHeader(4).Value = Nothing
                prmHeader(5) = New SqlParameter("@DowntimeMachineSubStatusId", SqlDbType.Int)
                prmHeader(5).Value = Nothing
                prmHeader(6) = New SqlParameter("@JigId", SqlDbType.Int)
                prmHeader(6).Value = cmbJigName.SelectedValue
                prmHeader(7) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
                prmHeader(7).Value = cmbDowntimeStatus.SelectedValue
                prmHeader(8) = New SqlParameter("@DowntimeJigSubStatusId", SqlDbType.Int)
                prmHeader(8).Value = cmbDowntimeSubStatus.SelectedValue
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

                prmHeader(14) = New SqlParameter("@ApproverIsApproved1", SqlDbType.Bit)
                prmHeader(14).Value = 0
                prmHeader(15) = New SqlParameter("@ApproverId1", SqlDbType.Int)
                prmHeader(15).Value = 6
                prmHeader(16) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                prmHeader(16).Value = Nothing
                prmHeader(17) = New SqlParameter("@ApproverRemarks1", SqlDbType.NVarChar)
                prmHeader(17).Value = Nothing
                prmHeader(18) = New SqlParameter("@ApproverIsApproved2", SqlDbType.Bit)
                prmHeader(18).Value = 0
                prmHeader(19) = New SqlParameter("@ApproverId2", SqlDbType.Int)
                prmHeader(19).Value = 5
                prmHeader(20) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                prmHeader(20).Value = Nothing
                prmHeader(21) = New SqlParameter("@ApproverRemarks2", SqlDbType.NVarChar)
                prmHeader(21).Value = Nothing
                prmHeader(22) = New SqlParameter("@ApproverIsApproved3", SqlDbType.Bit)
                prmHeader(22).Value = 0
                prmHeader(23) = New SqlParameter("@ApproverId3", SqlDbType.Int)
                prmHeader(23).Value = 2
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

                If cmbTransactionStatus.SelectedValue = 1 Then 'transaction status - done
                    If dgvDetail.Rows.Count = 0 Then
                        MessageBox.Show("Please input activity logs.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        btnAddRow.Focus()
                        Return
                    End If

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
                    prmHeader(35) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmHeader(35).Value = 1

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
                    If dgvDetail.Rows.Count > 0 Then 'save record (on-going activity) even no activity log yet
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

                        If DateTime.Now.Hour >= 7 And DateTime.Now.Hour <= 17 Then
                            prmHeader(33) = New SqlParameter("@ShiftId", SqlDbType.Char)
                            prmHeader(33).Value = "D"
                        Else
                            prmHeader(33) = New SqlParameter("@ShiftId", SqlDbType.Char)
                            prmHeader(33).Value = "N"
                        End If

                        prmHeader(34) = New SqlParameter("@TotalAccumulatedDowntime", SqlDbType.Int)
                        prmHeader(34).Value = Nothing
                    End If

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

                    'set jig status to downtime
                    Dim prmJigStatus(2) As SqlParameter
                    prmJigStatus(0) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmJigStatus(0).Value = cmbJigName.SelectedValue
                    prmJigStatus(1) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                    prmJigStatus(1).Value = cmbDowntimeStatus.SelectedValue
                    prmJigStatus(2) = New SqlParameter("@JigSubStatusId", SqlDbType.Int)
                    prmJigStatus(2).Value = cmbDowntimeSubStatus.SelectedValue

                    dbMethod.ExecuteNonQuery("UpdMntJigByJigStatusId", CommandType.StoredProcedure, prmJigStatus)
                End If

                dbMethod.ExecuteNonQuery("InsMntTransactionHeader", CommandType.StoredProcedure, prmHeader)

                'transaction details
                If dgvDetail.Rows.Count > 0 Then
                    For Each dataRowView As DataRowView In Me.bsTrxDetail
                        Dim row = dataRowView.Row
                        row.Item("TrxId") = prmHeader(0).Value

                        Dim prmUser(1) As SqlParameter
                        prmUser(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmUser(0).Value = prmHeader(0).Value
                        prmUser(1) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmUser(1).Value = row.Item("UserId")
                        dbMethod.ExecuteNonQuery("InsMntTransactionUser", CommandType.StoredProcedure, prmUser)
                    Next
                    adpTrxDetail.Update(dtTrxDetail)
                End If

                'transaction spare part
                Dim prmSparePart(2) As SqlParameter
                prmSparePart(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                prmSparePart(0).Value = prmHeader(0).Value

                If String.IsNullOrEmpty(txtPartsReplaced.Text.Trim) Then
                    prmSparePart(1) = New SqlParameter("@SparePartName", SqlDbType.NVarChar)
                    prmSparePart(1).Value = Nothing
                    prmSparePart(2) = New SqlParameter("@SparePartNo", SqlDbType.NVarChar)
                    prmSparePart(2).Value = Nothing
                Else
                    prmSparePart(1) = New SqlParameter("@SparePartName", SqlDbType.NVarChar)
                    prmSparePart(1).Value = txtPartsReplaced.Text.Trim
                    prmSparePart(2) = New SqlParameter("@SparePartNo", SqlDbType.NVarChar)
                    prmSparePart(2).Value = txtPartsNo.Text.Trim
                End If
                dbMethod.ExecuteNonQuery("InsMntTransactionSparePart", CommandType.StoredProcedure, prmSparePart)

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

                'fill the pm schedule slot
                If scheduleId > 0 AndAlso cmbDowntimeSubStatus.SelectedValue = 2 Then
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

                    prmMchSchd(4) = New SqlParameter("@ActivityDate", SqlDbType.Date)
                    If dgvDetail.Rows.Count > 0 Then
                        prmMchSchd(4).Value = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                    Else
                        prmMchSchd(4).Value = dbMethod.GetServerDate
                    End If

                    prmMchSchd(5) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                    prmMchSchd(5).Value = scheduleId

                    dbMethod.ExecuteNonQuery("UpdMntJigScheduleByScheduleId", CommandType.StoredProcedure, prmMchSchd)
                End If

                'existing transaction
            Else
                'transaction header
                Dim prmHeader(40) As SqlParameter
                prmHeader(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                prmHeader(0).Value = trxId
                prmHeader(1) = New SqlParameter("@MachineId", SqlDbType.Int)
                prmHeader(1).Value = Nothing
                prmHeader(2) = New SqlParameter("@DowntimeMachineStatusId", SqlDbType.Int)
                prmHeader(2).Value = Nothing
                prmHeader(3) = New SqlParameter("@DowntimeMachineSubStatusId", SqlDbType.Int)
                prmHeader(3).Value = Nothing
                prmHeader(4) = New SqlParameter("@JigId", SqlDbType.Int)
                prmHeader(4).Value = cmbJigName.SelectedValue
                prmHeader(5) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
                prmHeader(5).Value = cmbDowntimeStatus.SelectedValue
                prmHeader(6) = New SqlParameter("@DowntimeJigSubStatusId", SqlDbType.Int)
                prmHeader(6).Value = cmbDowntimeSubStatus.SelectedValue
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

                prmHeader(11) = New SqlParameter("@ApproverIsApproved1", SqlDbType.Bit)
                prmHeader(11).Value = 0
                prmHeader(12) = New SqlParameter("@ApproverId1", SqlDbType.Int)
                prmHeader(12).Value = 6
                prmHeader(13) = New SqlParameter("@ApproverDate1", SqlDbType.DateTime2)
                prmHeader(13).Value = Nothing
                prmHeader(14) = New SqlParameter("@ApproverRemarks1", SqlDbType.NVarChar)
                prmHeader(14).Value = Nothing
                prmHeader(15) = New SqlParameter("@ApproverIsApproved2", SqlDbType.Bit)
                prmHeader(15).Value = 0
                prmHeader(16) = New SqlParameter("@ApproverId2", SqlDbType.Int)
                prmHeader(16).Value = 5
                prmHeader(17) = New SqlParameter("@ApproverDate2", SqlDbType.DateTime2)
                prmHeader(17).Value = Nothing
                prmHeader(18) = New SqlParameter("@ApproverRemarks2", SqlDbType.NVarChar)
                prmHeader(18).Value = Nothing
                prmHeader(19) = New SqlParameter("@ApproverIsApproved3", SqlDbType.Bit)
                prmHeader(19).Value = 0
                prmHeader(20) = New SqlParameter("@ApproverId3", SqlDbType.Int)
                prmHeader(20).Value = 2
                prmHeader(21) = New SqlParameter("@ApproverDate3", SqlDbType.DateTime2)
                prmHeader(21).Value = Nothing
                prmHeader(22) = New SqlParameter("@ApproverRemarks3", SqlDbType.NVarChar)
                prmHeader(22).Value = Nothing
                prmHeader(23) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                prmHeader(23).Value = userId
                prmHeader(24) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime2)
                prmHeader(24).Value = dbMethod.GetServerDate
                prmHeader(25) = New SqlParameter("@FileAttachment", SqlDbType.VarBinary)
                prmHeader(25).Value = Nothing
                prmHeader(26) = New SqlParameter("@FileName", SqlDbType.NVarChar)
                prmHeader(26).Value = Nothing

                If cmbTransactionStatus.SelectedValue = 1 Then 'transaction status - done
                    If dgvDetail.Rows.Count = 0 Then
                        MessageBox.Show("Please input activity logs.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        btnAddRow.Focus()
                        Return
                    End If

                    prmHeader(27) = New SqlParameter("@TrxStatusId", SqlDbType.Int)
                    prmHeader(27).Value = 1
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
                    prmHeader(33) = New SqlParameter("@RoutingStatusId", SqlDbType.Int)
                    prmHeader(33).Value = 1

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

                    'set jig to operational
                    Dim prmJigStatus(2) As SqlParameter
                    prmJigStatus(0) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmJigStatus(0).Value = cmbJigName.SelectedValue
                    prmJigStatus(1) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                    prmJigStatus(1).Value = 1
                    prmJigStatus(2) = New SqlParameter("@JigSubStatusId", SqlDbType.Int)
                    prmJigStatus(2).Value = 1

                    dbMethod.ExecuteNonQuery("UpdMntJigByJigStatusId", CommandType.StoredProcedure, prmJigStatus)

                Else 'transaction status - on-going
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

                        If DateTime.Now.Hour >= 7 And DateTime.Now.Hour <= 17 Then
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
                    prmHeader(33).Value = 5

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

                    'set jig status to downtime
                    Dim prmJigStatus(2) As SqlParameter
                    prmJigStatus(0) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmJigStatus(0).Value = cmbJigName.SelectedValue
                    prmJigStatus(1) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                    prmJigStatus(1).Value = cmbDowntimeStatus.SelectedValue
                    prmJigStatus(2) = New SqlParameter("@JigSubStatusId", SqlDbType.Int)
                    prmJigStatus(2).Value = cmbDowntimeSubStatus.SelectedValue

                    dbMethod.ExecuteNonQuery("UpdMntJigByJigStatusId", CommandType.StoredProcedure, prmJigStatus)
                End If
                dbMethod.ExecuteNonQuery("UpdMntTransactionHeader", CommandType.StoredProcedure, prmHeader)

                'transaction details
                For Each dataRowView As DataRowView In Me.bsTrxDetail
                    Dim row = dataRowView.Row
                    row.Item("TrxId") = trxId
                Next
                Me.bsTrxDetail.EndEdit()
                Me.adpTrxDetail.Update(dtTrxDetail)

                'transaction spare part
                If String.IsNullOrEmpty(txtPartsReplaced.Text.Trim) Then
                    Dim prmSparePart(2) As SqlParameter
                    prmSparePart(0) = New SqlParameter("@SparePartName", SqlDbType.NVarChar)
                    prmSparePart(0).Value = Nothing
                    prmSparePart(1) = New SqlParameter("@SparePartNo", SqlDbType.NVarChar)
                    prmSparePart(1).Value = Nothing
                    prmSparePart(2) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmSparePart(2).Value = trxId

                    dbMethod.ExecuteNonQuery("UpdMntTransactionSparePart", CommandType.StoredProcedure, prmSparePart)
                Else
                    If String.IsNullOrEmpty(txtPartsNo.Text.Trim) Then
                        MessageBox.Show("Please indicate the part number.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtPartsNo.Focus()
                        Return
                    End If

                    Dim prmSparePart(2) As SqlParameter
                    prmSparePart(0) = New SqlParameter("@SparePartName", SqlDbType.NVarChar)
                    prmSparePart(0).Value = txtPartsReplaced.Text.Trim
                    prmSparePart(1) = New SqlParameter("@SparePartNo", SqlDbType.NVarChar)
                    prmSparePart(1).Value = txtPartsNo.Text.Trim
                    prmSparePart(2) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmSparePart(2).Value = trxId

                    dbMethod.ExecuteNonQuery("UpdMntTransactionSparePart", CommandType.StoredProcedure, prmSparePart)
                End If

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

                'transaction user - insert from technician log
                For Each row As DataRowView In Me.bsTrxDetail
                    Dim prmIns1(1) As SqlParameter
                    prmIns1(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmIns1(0).Value = trxId
                    prmIns1(1) = New SqlParameter("@UserId", SqlDbType.Int)
                    prmIns1(1).Value = row.Item("UserId")

                    trxCount = dbMethod.ExecuteScalar("CntMntTransactionUser", CommandType.StoredProcedure, prmIns1)

                    If Not trxCount > 0 Then
                        Dim prmIns2(1) As SqlParameter
                        prmIns2(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmIns2(0).Value = trxId
                        prmIns2(1) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmIns2(1).Value = row.Item("UserId")

                        dbMethod.ExecuteNonQuery("InsMntTransactionUser", CommandType.StoredProcedure, prmIns2)
                    End If
                Next

                'set the orig jig to operational if jig was changed
                If orgJigId <> cmbJigName.SelectedValue Then
                    Dim prmJigStatusOrg(2) As SqlParameter
                    prmJigStatusOrg(0) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmJigStatusOrg(0).Value = orgJigId
                    prmJigStatusOrg(1) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                    prmJigStatusOrg(1).Value = 1
                    prmJigStatusOrg(2) = New SqlParameter("@JigSubStatusId", SqlDbType.Int)
                    prmJigStatusOrg(2).Value = 1

                    dbMethod.ExecuteNonQuery("UpdMntJigByJigStatusId", CommandType.StoredProcedure, prmJigStatusOrg)

                    Dim prmJigStatusNew(2) As SqlParameter
                    prmJigStatusNew(0) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmJigStatusNew(0).Value = cmbJigName.SelectedValue
                    prmJigStatusNew(1) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                    prmJigStatusNew(1).Value = cmbDowntimeStatus.SelectedValue
                    prmJigStatusNew(2) = New SqlParameter("@JigSubStatusId", SqlDbType.Int)
                    prmJigStatusNew(2).Value = cmbDowntimeSubStatus.SelectedValue

                    dbMethod.ExecuteNonQuery("UpdMntJigByJigStatusId", CommandType.StoredProcedure, prmJigStatusNew)
                End If

                If scheduleId > 0 AndAlso cmbDowntimeSubStatus.SelectedValue = 3 Then
                    If orgScheduleId <> scheduleId Then 'clear up the orig pm schedule slot
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

                        dbMethod.ExecuteNonQuery("UpdMntJigScheduleByScheduleId", CommandType.StoredProcedure, prmMchSchdOrg)
                    End If

                    Dim prmJigSchd(5) As SqlParameter
                    prmJigSchd(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmJigSchd(0).Value = trxId

                    prmJigSchd(1) = New SqlParameter("@IsDone", SqlDbType.Bit)
                    If cmbTransactionStatus.SelectedValue = 1 Then prmJigSchd(1).Value = True Else prmJigSchd(1).Value = False

                    prmJigSchd(2) = New SqlParameter("@IsChecklistCompleted", SqlDbType.Bit)
                    prmJigSchd(2).Value = False

                    prmJigSchd(3) = New SqlParameter("@ActivityBy", SqlDbType.Int)
                    If dgvDetail.Rows.Count > 0 Then
                        prmJigSchd(3).Value = dgvDetail.Rows(rowCount - 1).Cells("ColUserIdLog").Value
                    Else
                        prmJigSchd(3).Value = userId
                    End If

                    prmJigSchd(4) = New SqlParameter("@ActivityDate", SqlDbType.Date)
                    If dgvDetail.Rows.Count > 0 Then
                        prmJigSchd(4).Value = dgvDetail.Rows(rowCount - 1).Cells("ColTrxTo").Value
                    Else
                        prmJigSchd(4).Value = dbMethod.GetServerDate
                    End If

                    prmJigSchd(5) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                    prmJigSchd(5).Value = scheduleId

                    dbMethod.ExecuteNonQuery("UpdMntJigScheduleByScheduleId", CommandType.StoredProcedure, prmJigSchd)
                End If
            End If

            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If cmbJigName.SelectedValue = 0 Then
                DisableForm(True)
                Exit Sub
            End If

            If btnDelete.Enabled = False Then
                Exit Sub
            End If

            If trxId > 0 Then
                Dim question As String = String.Format("Are you sure you want to delete this record?")
                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    If scheduleId > 0 AndAlso dtTrxHeader.Rows(0).Item("DowntimeJigSubStatusId") = 2 Then
                        'orgSchedule was used because it deletes the actual data from the database, not from the ui
                        Dim prmJigSchdOrg(5) As SqlParameter
                        prmJigSchdOrg(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmJigSchdOrg(0).Value = DBNull.Value
                        prmJigSchdOrg(1) = New SqlParameter("@IsDone", SqlDbType.Bit)
                        prmJigSchdOrg(1).Value = False
                        prmJigSchdOrg(2) = New SqlParameter("@IsChecklistCompleted", SqlDbType.Bit)
                        prmJigSchdOrg(2).Value = False
                        prmJigSchdOrg(3) = New SqlParameter("@ActivityBy", SqlDbType.Int)
                        prmJigSchdOrg(3).Value = DBNull.Value
                        prmJigSchdOrg(4) = New SqlParameter("@ActivityDate", SqlDbType.Date)
                        prmJigSchdOrg(4).Value = DBNull.Value
                        prmJigSchdOrg(5) = New SqlParameter("@ScheduleId", SqlDbType.Int)
                        prmJigSchdOrg(5).Value = orgScheduleId

                        dbMethod.ExecuteNonQuery("UpdMntJigScheduleByScheduleId", CommandType.StoredProcedure, prmJigSchdOrg)
                    End If

                    'set the jig to operational state if trx is on-going status and also last trx
                    Dim prmIsLast(0) As SqlParameter
                    prmIsLast(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmIsLast(0).Value = trxId

                    If trxId = dbMethod.ExecuteScalar("SELECT TOP 1 TrxId FROM dbo.MntTransactionHeader ORDER BY TrxId DESC", CommandType.Text, prmIsLast) AndAlso
                       dtTrxHeader.Rows(0).Item("TrxStatusId") = 2 Then

                        Dim prmJigStatus(2) As SqlParameter
                        prmJigStatus(0) = New SqlParameter("@JigId", SqlDbType.Int)
                        prmJigStatus(0).Value = dtTrxHeader.Rows(0).Item("JigId")
                        prmJigStatus(1) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                        prmJigStatus(1).Value = 1
                        prmJigStatus(2) = New SqlParameter("@JigSubStatusId", SqlDbType.Int)
                        prmJigStatus(2).Value = 1

                        dbMethod.ExecuteNonQuery("UpdMntJigByJigStatusId", CommandType.StoredProcedure, prmJigStatus)
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

    Private Sub LoadTransactionStatus()
        Try
            cmbTransactionStatus.DisplayMember = "TrxStatusName"
            cmbTransactionStatus.ValueMember = "TrxStatusId"
            dbMethod.FillCmb("RdGenTransactionStatus", CommandType.StoredProcedure, "TrxStatusId", "TrxStatusName", cmbTransactionStatus)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadJig()
        Try
            cmbJigName.DisplayMember = "JigCompleteName"
            cmbJigName.ValueMember = "JigId"

            If trxId = 0 Then
                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                prm(0).Value = 1

                dbMethod.FillCmbWithCaption("RdMntJig", CommandType.StoredProcedure, "JigId", "JigCompleteName", cmbJigName, "", prm)
            Else
                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                prm(0).Value = Nothing

                dbMethod.FillCmbWithCaption("RdMntJig", CommandType.StoredProcedure, "JigId", "JigCompleteName", cmbJigName, "", prm)
            End If

            AddHandler cmbJigName.Validating, AddressOf cmbJigName_Validating
            AddHandler cmbJigName.SelectedValueChanged, AddressOf cmbJigName_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetJigArea(jigId As Integer)
        Try
            Dim prmJigId(0) As SqlParameter
            prmJigId(0) = New SqlParameter("@JigId", SqlDbType.Int)
            prmJigId(0).Value = jigId

            Dim rdrJig As IDataReader = dbMethod.ExecuteReader("RdMntJig", CommandType.StoredProcedure, prmJigId)

            While rdrJig.Read
                areaId = rdrJig.Item("AreaId")
                txtArea.Text = rdrJig.Item("AreaName").ToString.Replace("&", "&&")
            End While
            rdrJig.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDowntimeStatus()
        Try
            cmbDowntimeStatus.DisplayMember = "JigStatusName"
            cmbDowntimeStatus.ValueMember = "JigStatusId"

            Dim prmJigStatus(0) As SqlParameter
            prmJigStatus(0) = New SqlParameter("@JigStatusId", SqlDbType.Int)
            prmJigStatus(0).Value = Nothing

            dbMethod.FillCmbWithCaption("RdMntJigStatus", CommandType.StoredProcedure, "JigStatusId", "JigStatusName", cmbDowntimeStatus, "< Select Jig Status >",
                                        prmJigStatus)

            AddHandler cmbDowntimeStatus.SelectedValueChanged, AddressOf cmbDowntimeStatus_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDowntimeSubStatus(jigStatusId As Integer)
        Try
            cmbDowntimeSubStatus.DisplayMember = "JigSubStatusName"
            cmbDowntimeSubStatus.ValueMember = "JigSubStatusId"

            cmbDowntimeSubStatus.DataSource = Nothing
            cmbDowntimeSubStatus.Items.Clear()

            Dim prmJigSubStatus(0) As SqlParameter
            prmJigSubStatus(0) = New SqlParameter("@JigStatusId", SqlDbType.Int)
            prmJigSubStatus(0).Value = jigStatusId

            dbMethod.FillCmbWithCaption("RdMntJigSubStatus", CommandType.StoredProcedure, "JigSubStatusId", "JigSubStatusName",
                                        cmbDowntimeSubStatus, "< Select Sub-Status >", prmJigSubStatus)

            AddHandler cmbDowntimeSubStatus.SelectedValueChanged, AddressOf cmbDowntimeSubStatus_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetJigSchedule(jigId As Integer, Optional trxId As Integer = 0)
        Try
            If trxId = 0 Then
                Dim prmSchedule(0) As SqlParameter
                prmSchedule(0) = New SqlParameter("@JigId", SqlDbType.Int)
                prmSchedule(0).Value = jigId

                Dim query As String = "SELECT TOP 1 ScheduleId, MonthId, WeekId FROM VwMntJigSchedule WHERE JigId = @JigId AND ActivityDate IS NULL AND IsDone = 0"
                Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSchedule)

                If rdrSchedule.Read Then
                    scheduleId = rdrSchedule.Item("ScheduleId")
                    monthId = rdrSchedule.Item("MonthId")
                    weekId = rdrSchedule.Item("WeekId")
                    txtScheduleMonth.Text = MonthName(monthId)
                    txtScheduleWeek.Text = weekId
                Else
                    MessageBox.Show("No PM schedule found for this jig.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbDowntimeSubStatus.SelectedValue = 0
                    txtScheduleMonth.Text = String.Empty
                    txtScheduleWeek.Text = String.Empty

                    scheduleId = 0
                    monthId = 0
                    weekId = 0
                End If
                rdrSchedule.Close()
            Else
                If orgJigId = jigId Then
                    If orgJigSubStatusId = cmbDowntimeSubStatus.SelectedValue Then
                        Dim prmSchedule(1) As SqlParameter
                        prmSchedule(0) = New SqlParameter("@JigId", SqlDbType.Int)
                        prmSchedule(0).Value = jigId
                        prmSchedule(1) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmSchedule(1).Value = trxId

                        Dim query As String = "SELECT ScheduleId, MonthId, WeekId FROM VwMntJigSchedule WHERE JigId = @JigId AND TrxId = @TrxId"
                        Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSchedule)

                        If rdrSchedule.Read Then
                            scheduleId = rdrSchedule.Item("ScheduleId")
                            orgScheduleId = rdrSchedule.Item("ScheduleId")
                            monthId = rdrSchedule.Item("MonthId")
                            weekId = rdrSchedule.Item("WeekId")
                            txtScheduleMonth.Text = MonthName(monthId)
                            txtScheduleWeek.Text = weekId
                        End If
                        rdrSchedule.Close()
                    Else
                        Dim prmSchedule(0) As SqlParameter
                        prmSchedule(0) = New SqlParameter("@JigId", SqlDbType.Int)
                        prmSchedule(0).Value = jigId

                        Dim query As String = "SELECT TOP 1 ScheduleId, MonthId, WeekId FROM VwMntJigSchedule WHERE JigId = @JigId AND ActivityDate IS NULL AND IsDone = 0"
                        Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSchedule)

                        If rdrSchedule.Read Then
                            scheduleId = rdrSchedule.Item("ScheduleId")
                            orgScheduleId = rdrSchedule.Item("ScheduleId")
                            monthId = rdrSchedule.Item("MonthId")
                            weekId = rdrSchedule.Item("WeekId")
                            txtScheduleMonth.Text = MonthName(monthId)
                            txtScheduleWeek.Text = weekId
                        Else
                            MessageBox.Show("No PM schedule found for this jig.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            cmbDowntimeSubStatus.SelectedValue = 0
                            txtScheduleMonth.Text = String.Empty
                            txtScheduleWeek.Text = String.Empty

                            scheduleId = 0
                            monthId = 0
                            weekId = 0
                        End If
                        rdrSchedule.Close()
                    End If
                Else
                    Dim prmSchedule(0) As SqlParameter
                    prmSchedule(0) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmSchedule(0).Value = jigId

                    Dim query As String = "SELECT TOP 1 ScheduleId, MonthId, WeekId FROM VwMntJigSchedule WHERE JigId = @JigId AND ActivityDate IS NULL AND IsDone = 0"
                    Dim rdrSchedule As IDataReader = dbMethod.ExecuteReader(query, CommandType.Text, prmSchedule)

                    If rdrSchedule.Read Then
                        scheduleId = rdrSchedule.Item("ScheduleId")
                        orgScheduleId = rdrSchedule.Item("ScheduleId")
                        monthId = rdrSchedule.Item("MonthId")
                        weekId = rdrSchedule.Item("WeekId")
                        txtScheduleMonth.Text = MonthName(monthId)
                        txtScheduleWeek.Text = weekId
                    Else
                        MessageBox.Show("No PM schedule found for this jig.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub FilterPicTable()
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

                Me.bsTrxUser.Filter = filterBuilder.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetTotalRuntime(jigId As Integer)
        Try
            Dim lastDatetime As DateTime = Nothing
            Dim span As TimeSpan = Nothing
            Dim spanMinutes As Integer = 0
            Dim spanHours As Integer = 0
            Dim spanDays As Integer = 0
            Dim totalMinutes As Integer = 0

            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@JigId", SqlDbType.Int)
            prm(0).Value = jigId

            Dim reader As IDataReader = dbMethod.ExecuteReader("RdMntJigAccumulatedTime", CommandType.StoredProcedure, prm)

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

            txtChecksheet.ReadOnly = True
            txt4M.ReadOnly = True

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

            txtChecksheet.ReadOnly = False
            txt4M.ReadOnly = False

            btnAddRow.Enabled = True
            btnRemoveRow.Enabled = True
            btnViewImage.Enabled = True
            btnBrowseImage.Enabled = True
            btnRemoveImage.Enabled = True
            btnViewChecksheet.Enabled = True
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

    Private Function CreateTrxDetail() As DataTable
        Dim dtTrxDetail As New DataTable

        Try
            Dim con As New SqlConnection(dbConnection.GetConnectionString)
            Dim query As String = "SELECT TrxDetailId, TrxId, TrxDate, TrxFrom, TrxTo, ElapsedTime, UserId, ShiftId FROM dbo.MntTransactionDetail"
            Dim cmd As New SqlCommand(query, con)
            adpTrxDetail = New SqlDataAdapter(cmd)
            Dim cbTrxDetail As New SqlCommandBuilder(adpTrxDetail)

            Dim colTrxDetailId As DataColumn = New DataColumn("TrxDetailId")
            colTrxDetailId.DataType = System.Type.GetType("System.Int32")
            colTrxDetailId.AllowDBNull = True
            dtTrxDetail.Columns.Add(colTrxDetailId)

            Dim colTrxDate As DataColumn = New DataColumn("TrxDate")
            colTrxDate.DataType = System.Type.GetType("System.DateTime")
            dtTrxDetail.Columns.Add(colTrxDate)

            Dim colTrxId As DataColumn = New DataColumn("TrxId")
            colTrxId.DataType = System.Type.GetType("System.Int32")
            colTrxId.AllowDBNull = True
            dtTrxDetail.Columns.Add(colTrxId)

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
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtTrxDetail
    End Function

    Private Sub cmbTransactionStatus_Enter(sender As Object, e As EventArgs) Handles cmbTransactionStatus.Enter
        lblTransactionStatus.ForeColor = Color.White
        lblTransactionStatus.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbTransactionStatus_Leave(sender As Object, e As EventArgs) Handles cmbTransactionStatus.Leave
        lblTransactionStatus.ForeColor = Color.Black
        lblTransactionStatus.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbJigName_Enter(sender As Object, e As EventArgs) Handles cmbJigName.Enter
        lblJigName.ForeColor = Color.White
        lblJigName.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbJigName_Leave(sender As Object, e As EventArgs) Handles cmbJigName.Leave
        lblJigName.ForeColor = Color.Black
        lblJigName.BackColor = SystemColors.Control
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

End Class