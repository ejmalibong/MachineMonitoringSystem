Imports BlackCoffeeLibrary
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class MntTrxDetailOth
    Private dbConnection As New Connection
    Private directories As New Directory
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)
    Private dbMain As New BlackCoffeeLibrary.Main
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

    Private areaId As Integer = 0

    Private trxCount As Integer = 0

    Private imgTmp As String = String.Empty

    Private orgFilename As String = String.Empty

    Private serverNetUserName As String = String.Empty
    Private serverNetUserPassword As String = String.Empty

    Private imgDirectory As String = directories.ImageInitialDirectory
    Private attDirectory As String = directories.AttachmentInitialDirectory

    Private lstImgAttachment As New List(Of ImgAttachment)
    Private lstAttachment As New List(Of CsAttachment)
    Private lstAttachmentDelete As New List(Of CsAttachment)
    Private lstAttachmentCopy As New List(Of CsAttachment)

    Private superiorWorkgroupId As New List(Of Integer) From {29, 30, 35, 2} 'asv, sv, asm, smngr

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
        LoadArea()
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
                Me.ActiveControl = cmbArea
            Else
                Me.Text = "Activity No. " & trxId & ""

                For Each row As DataRow In dtTrxHeader.Rows
                    'transaction header
                    Dim dRow As DataRow = dtRoutingStatus.Select("RoutingStatusId = " & row("RoutingStatusId") & "")(0)
                    txtRoutingStatus.Text = dRow("RoutingStatusName").ToString.Trim

                    txtTransactionDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("TrxDate"))
                    cmbTransactionStatus.SelectedValue = row("TrxStatusId")
                    cmbArea.SelectedValue = row("AreaId")

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
                Next

                For Each row As DataRow In dtTrxSparePart.Rows
                    If Not row("SparePartName") Is DBNull.Value AndAlso Not row("SparePartNo") Is DBNull.Value Then
                        txtPartsReplaced.Text = row("SparePartName")
                        txtPartsNo.Text = row("SparePartNo")
                    End If
                Next

                If Not dtTrxHeader.Rows(0).Item("FileName") Is DBNull.Value Then
                    Dim fileName As String = dtTrxHeader.Rows(0).Item("FileName").ToString.Trim
                    Dim oldAttachment As New CsAttachment(Path.Combine(attDirectory, fileName), fileName, Path.GetExtension(Path.Combine(attDirectory, fileName)))
                    lstAttachment.Add(oldAttachment)
                    txtAttachment.Text = fileName
                    orgFilename = dtTrxHeader.Rows(0).Item("FileName").ToString.Trim
                End If

                btnDelete.Enabled = True

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
                    frmDetailLog.ShowDialog(Me)

                    If frmDetailLog.DialogResult = Windows.Forms.DialogResult.OK Then
                        Me.bsTrxDetail.AddNew()
                        Me.bsTrxDetail.MoveLast()
                        Me.bsTrxDetail.Current("TrxId") = DBNull.Value
                        Me.bsTrxDetail.Current("TrxDate") = dbMethod.GetServerDate
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
                    frmDetailLog.ShowDialog(Me)

                    If frmDetailLog.DialogResult = Windows.Forms.DialogResult.OK Then
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

            Dim checksheet As New CsAttachment(ofdAttachment.FileName, ofdAttachment.SafeFileName, Path.GetExtension(ofdAttachment.SafeFileName).ToLower)
            lstAttachment.Add(checksheet)

            txtAttachment.Text = Path.GetFileName(ofdAttachment.FileName)
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
                prmHeader(6).Value = Nothing
                prmHeader(7) = New SqlParameter("@DowntimeJigStatusId", SqlDbType.Int)
                prmHeader(7).Value = Nothing
                prmHeader(8) = New SqlParameter("@DowntimeJigSubStatusId", SqlDbType.Int)
                prmHeader(8).Value = Nothing
                prmHeader(9) = New SqlParameter("@AreaId", SqlDbType.Int)
                prmHeader(9).Value = cmbArea.SelectedValue
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

                    prmHeader(41) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                    prmHeader(41).Value = Nothing
                    prmHeader(42) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                    prmHeader(42).Value = Nothing

                Else 'transaction status - on-going
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

                    prmHeader(41) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                    prmHeader(41).Value = Nothing

                    prmHeader(42) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                    prmHeader(42).Value = Nothing
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

                If lstAttachment.Count > 0 AndAlso Not String.IsNullOrEmpty(txtAttachment.Text.Trim) Then
                    For i As Integer = 0 To lstAttachment.Count - 1
                        Dim extension As String = String.Empty
                        Dim filename As String = String.Empty
                        extension = Path.GetExtension(lstAttachment(i).FileName).ToLower
                        filename = prmHeader(0).Value & extension

                        Dim prmUpd(1) As SqlParameter
                        prmUpd(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmUpd(0).Value = prmHeader(0).Value
                        prmUpd(1) = New SqlParameter("@Filename", SqlDbType.NVarChar)
                        prmUpd(1).Value = filename

                        dbMethod.ExecuteNonQuery("UpdMntTransactionHeaderByFileName", CommandType.StoredProcedure, prmUpd)

                        progBar.Visible = True
                        lblProgress.Visible = True

                        Dim copyChecksheet As New CsAttachment(lstAttachment(i).FileName, filename, Path.GetExtension(lstAttachment(i).FileName).ToLower)
                        lstAttachmentCopy.Add(copyChecksheet)
                    Next
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

                    prmHeader(39) = New SqlParameter("@LinkChecksheet", SqlDbType.NVarChar)
                    prmHeader(39).Value = Nothing
                    prmHeader(40) = New SqlParameter("@Link4M", SqlDbType.NVarChar)
                    prmHeader(40).Value = Nothing

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
                End If

                'attachment list is not empty
                If lstAttachment.Count > 0 AndAlso Not String.IsNullOrEmpty(txtAttachment.Text.Trim) Then
                    If Not dtTrxHeader.Rows(0).Item("FileName") Is DBNull.Value Then 'originally contains attachment
                        If Not txtAttachment.Text.Trim.Equals(orgFilename.ToString.Trim) Then 'db version is not equals to current attachment name - new attachment
                            Dim extension As String = String.Empty
                            Dim filename As String = String.Empty
                            extension = Path.GetExtension(dtTrxHeader.Rows(0).Item("FileName").ToString.Trim).ToLower
                            filename = trxId & extension

                            Dim delChecksheet As New CsAttachment(attDirectory & "\" & dtTrxHeader.Rows(0).Item("FileName").ToString.Trim, filename, Path.GetExtension(Path.Combine(attDirectory, filename)))
                            lstAttachmentDelete.Add(delChecksheet)

                            For i As Integer = 0 To lstAttachment.Count - 1
                                Dim extension1 As String = String.Empty
                                Dim filename1 As String = String.Empty
                                extension1 = Path.GetExtension(lstAttachment(i).FileName).ToLower
                                filename1 = trxId & extension1

                                Dim prmUpd2(1) As SqlParameter
                                prmUpd2(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                                prmUpd2(0).Value = trxId
                                prmUpd2(1) = New SqlParameter("@FileName", SqlDbType.NVarChar)
                                prmUpd2(1).Value = filename1

                                dbMethod.ExecuteNonQuery("UpdMntTransactionHeaderByFileName", CommandType.StoredProcedure, prmUpd2)

                                progBar.Visible = True
                                lblProgress.Visible = True

                                Dim copyChecksheet As New CsAttachment(lstAttachment(i).FileName, filename1, Path.GetExtension(lstAttachment(i).FileName).ToLower)
                                lstAttachmentCopy.Add(copyChecksheet)
                            Next

                        Else 'db version is equals to current attachment name - means old attachment, do nothing

                        End If

                    Else 'originally do not have attachment
                        For i As Integer = 0 To lstAttachment.Count - 1
                            Dim extension2 As String = String.Empty
                            Dim filename2 As String = String.Empty
                            extension2 = Path.GetExtension(lstAttachment(i).FileName).ToLower
                            filename2 = trxId & extension2

                            Dim prmUpd2(1) As SqlParameter
                            prmUpd2(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                            prmUpd2(0).Value = trxId
                            prmUpd2(1) = New SqlParameter("@FileName", SqlDbType.NVarChar)
                            prmUpd2(1).Value = filename2

                            dbMethod.ExecuteNonQuery("UpdMntTransactionHeaderByFileName", CommandType.StoredProcedure, prmUpd2)

                            progBar.Visible = True
                            lblProgress.Visible = True

                            Dim copyChecksheet As New CsAttachment(lstAttachment(i).FileName, filename2, Path.GetExtension(lstAttachment(i).FileName).ToLower)
                            lstAttachmentCopy.Add(copyChecksheet)
                        Next
                    End If

                Else 'attachment list is empty
                    If Not dtTrxHeader.Rows(0).Item("FileName") Is DBNull.Value Then 'originally contains attachment
                        Dim extension As String = String.Empty
                        Dim filename As String = String.Empty
                        extension = Path.GetExtension(dtTrxHeader.Rows(0).Item("FileName").ToString.Trim).ToLower
                        filename = trxId & extension

                        Dim delChecksheet As New CsAttachment(attDirectory & "\" & dtTrxHeader.Rows(0).Item("FileName").ToString.Trim, filename, Path.GetExtension(Path.Combine(attDirectory, filename)))
                        lstAttachmentDelete.Add(delChecksheet)

                        Dim prmUpd(1) As SqlParameter
                        prmUpd(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmUpd(0).Value = prmHeader(0).Value
                        prmUpd(1) = New SqlParameter("@Filename", SqlDbType.NVarChar)
                        prmUpd(1).Value = Nothing

                        dbMethod.ExecuteNonQuery("UpdMntTransactionHeaderByFileName", CommandType.StoredProcedure, prmUpd)

                    Else 'originally do not have attachment

                    End If
                End If

                If lstAttachmentDelete.Count > 0 Then
                    If File.Exists(lstAttachmentDelete(0).FileName) Then File.Delete(lstAttachmentDelete(0).FileName)
                End If

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
            Else
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub LoadTransactionStatus()
        Try
            cmbTransactionStatus.DisplayMember = "TrxStatusName"
            cmbTransactionStatus.ValueMember = "TrxStatusId"
            dbMethod.FillCmb("RdGenTransactionStatus", CommandType.StoredProcedure, "TrxStatusId", "TrxStatusName", cmbTransactionStatus)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadArea()
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