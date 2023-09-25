Imports System.Data.SqlClient
Imports System.IO
Imports BlackCoffeeLibrary

Public Class MntJigModelDetail
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)

    Private modelId As Integer = 0
    Private orgModelName As String = String.Empty

    Private currentIndex As Integer

    Private attachmentDirectories As New Directory
    Private fileDirectory As String = attachmentDirectories.DrwIniDirectoryMt
    Private lstAttachment As New List(Of FileAttachment)
    Private lstAttachmentForCopy As New List(Of FileAttachment)
    Private lstAttachmentForDelete As New List(Of FileAttachment)
    Private lstDocumentFiles As New List(Of String)(New String() {".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt"})
    Private lstImageFiles As New List(Of String)(New String() {".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tif", ".tiff"})
    Private lstPdfFiles As New List(Of String)(New String() {".pdf"})

    Private dtModelAttachment As New DataTable

    Public Sub New(Optional _modelId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        modelId = _modelId

        LoadExtension()
    End Sub

    Public Property pKey As Integer = 0

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If modelId > 0 Then
                Dim prmCnt(0) As SqlParameter
                prmCnt(0) = New SqlParameter("@ModelId", SqlDbType.Int)
                prmCnt(0).Value = modelId

                Dim count As Integer = dbMethod.ExecuteScalar("CntMntJigByModel", CommandType.StoredProcedure, prmCnt)
                Dim msg As String = String.Empty

                If count > 0 Then
                    If count = 1 Then
                        msg = String.Format("{0} jig is using this model. Mark this as inactive?", count)
                    Else
                        msg = String.Format("{0} jigs are using this model. Mark this as inactive?", count)
                    End If

                    If MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim prmUpd(0) As SqlParameter
                        prmUpd(0) = New SqlParameter("@ModelId", SqlDbType.Int)
                        prmUpd(0).Value = modelId

                        dbMethod.ExecuteNonQuery("UPDATE dbo.MntJigModel SET IsActive = 0 WHERE ModelId = @ModelId", CommandType.Text, prmUpd)
                    Else
                        Exit Sub
                    End If
                Else
                    msg = "Are you sure you want to delete this model?"
                    If MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim prmDel(0) As SqlParameter
                        prmDel(0) = New SqlParameter("@ModelId", SqlDbType.Int)
                        prmDel(0).Value = modelId

                        dbMethod.ExecuteNonQuery("DelMntJigModel", CommandType.StoredProcedure, prmDel)
                    Else
                        Exit Sub
                    End If
                End If

                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(txtModelName.Text.Trim) Then
                MessageBox.Show("Model name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtModelName.Focus()
                Return
            End If

            If modelId = 0 Then 'new record
                If IsModelExist(txtModelName.Text.Trim) = True Then
                    MessageBox.Show("Model name is already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtModelName.Focus()
                    Return
                End If

                Dim prmModel(3) As SqlParameter
                prmModel(0) = New SqlParameter("@ModelId", SqlDbType.Int)
                prmModel(0).Direction = ParameterDirection.Output
                prmModel(1) = New SqlParameter("@ModelName", SqlDbType.NVarChar)
                prmModel(1).Value = txtModelName.Text.Trim
                prmModel(2) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                prmModel(2).Value = IIf(cmbExtension.SelectedValue = 0, Nothing, cmbExtension.SelectedValue)
                prmModel(3) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmModel(3).Value = IIf(rdActive.Checked = True, True, False)

                dbMethod.ExecuteNonQuery("InsMntJigModel", CommandType.StoredProcedure, prmModel)
                pKey = prmModel(0).Value

                If lstAttachment.Count > 0 Then
                    For i As Integer = 0 To lstAttachment.Count - 1
                        If lstAttachment(i).attachmentId = 0 Then
                            Dim prmAttachment(2) As SqlParameter
                            prmAttachment(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                            prmAttachment(0).Direction = ParameterDirection.Output
                            prmAttachment(1) = New SqlParameter("@ModelId", SqlDbType.Int)
                            prmAttachment(1).Value = prmModel(0).Value
                            prmAttachment(2) = New SqlParameter("@Filename", SqlDbType.NVarChar)
                            prmAttachment(2).Value = ""

                            dbMethod.ExecuteNonQuery("InsMntJigModelAttachment", CommandType.StoredProcedure, prmAttachment)

                            Dim ext As String = String.Empty
                            Dim newName As String = String.Empty
                            ext = Path.GetExtension(lstAttachment(i).fileName).ToLower

                            newName = prmModel(0).Value & "-" & prmAttachment(0).Value & ext

                            Dim prmUpd(2) As SqlParameter
                            prmUpd(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                            prmUpd(0).Value = prmAttachment(0).Value
                            prmUpd(1) = New SqlParameter("@ModelId", SqlDbType.Int)
                            prmUpd(1).Value = prmModel(0).Value
                            prmUpd(2) = New SqlParameter("@Filename", SqlDbType.NVarChar)
                            prmUpd(2).Value = newName

                            dbMethod.ExecuteNonQuery("UpdMntJigModelAttachment", CommandType.StoredProcedure, prmUpd)

                            pbAttachment.Visible = True
                            lblProgress.Visible = True

                            Dim copyAttachment As New FileAttachment(lstAttachment(i).fileName, newName, lstAttachment(i).fileName)
                            lstAttachmentForCopy.Add(copyAttachment)
                        End If
                    Next
                End If

            Else 'old record
                If Not txtModelName.Text.Trim.Equals(orgModelName) Then
                    If IsModelExist(txtModelName.Text.Trim) = True Then
                        MessageBox.Show("Model name is already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtModelName.Focus()
                        Return
                    End If
                End If

                Dim prmModel(3) As SqlParameter
                prmModel(0) = New SqlParameter("@ModelId", SqlDbType.Int)
                prmModel(0).Value = modelId
                prmModel(1) = New SqlParameter("@ModelName", SqlDbType.NVarChar)
                prmModel(1).Value = txtModelName.Text.Trim
                prmModel(2) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                prmModel(2).Value = IIf(cmbExtension.SelectedValue = 0, Nothing, cmbExtension.SelectedValue)
                prmModel(3) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmModel(3).Value = IIf(rdActive.Checked = True, True, False)

                dbMethod.ExecuteNonQuery("UpdMntJigModel", CommandType.StoredProcedure, prmModel)
                pKey = modelId

                If lstAttachmentForDelete.Count > 0 Then
                    For i As Integer = 0 To lstAttachmentForDelete.Count - 1
                        Dim ext As String = String.Empty
                        Dim newName As String = String.Empty
                        ext = Path.GetExtension(lstAttachmentForDelete(i).fileName).ToLower

                        newName = modelId & "-" & lstAttachmentForDelete(i).attachmentId & ext

                        File.Delete(fileDirectory & "\" & newName)
                        Dim prmDel(0) As SqlParameter
                        prmDel(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                        prmDel(0).Value = lstAttachmentForDelete(i).attachmentId

                        dbMethod.ExecuteNonQuery("DelMntJigModelAttachmentByAttachmentId", CommandType.StoredProcedure, prmDel)
                    Next
                End If

                If lstAttachment.Count > 0 Then
                    For i As Integer = 0 To lstAttachment.Count - 1
                        If lstAttachment(i).attachmentId = 0 Then
                            Dim prmAttachment(2) As SqlParameter
                            prmAttachment(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                            prmAttachment(0).Direction = ParameterDirection.Output
                            prmAttachment(1) = New SqlParameter("@ModelId", SqlDbType.Int)
                            prmAttachment(1).Value = modelId
                            prmAttachment(2) = New SqlParameter("@Filename", SqlDbType.NVarChar)
                            prmAttachment(2).Value = ""

                            dbMethod.ExecuteNonQuery("InsMntJigModelAttachment", CommandType.StoredProcedure, prmAttachment)

                            Dim ext As String = String.Empty
                            Dim newName As String = String.Empty
                            ext = Path.GetExtension(lstAttachment(i).fileName).ToLower

                            newName = modelId & "-" & prmAttachment(0).Value & ext

                            Dim prmUpd(2) As SqlParameter
                            prmUpd(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                            prmUpd(0).Value = prmAttachment(0).Value
                            prmUpd(1) = New SqlParameter("@ModelId", SqlDbType.Int)
                            prmUpd(1).Value = modelId
                            prmUpd(2) = New SqlParameter("@Filename", SqlDbType.NVarChar)
                            prmUpd(2).Value = newName

                            dbMethod.ExecuteNonQuery("UpdMntJigModelAttachment", CommandType.StoredProcedure, prmUpd)

                            pbAttachment.Visible = True
                            lblProgress.Visible = True

                            Dim copyAttachment As New FileAttachment(lstAttachment(i).fileName, newName, lstAttachment(i).fileName)
                            lstAttachmentForCopy.Add(copyAttachment)
                        End If
                    Next
                End If
            End If

            btnBrowse.Enabled = False
            btnClose.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = False
            btnPrevious.Enabled = False
            btnRemove.Enabled = False
            btnSave.Enabled = False
            btnView.Enabled = False
            Me.ControlBox = False

            bgWorker.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbExtension_Enter(sender As Object, e As EventArgs) Handles cmbExtension.Enter
        lblExtension.ForeColor = Color.White
        lblExtension.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbExtension_Leave(sender As Object, e As EventArgs) Handles cmbExtension.Leave
        lblExtension.ForeColor = Color.Black
        lblExtension.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbExtension_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbExtension.SelectedValue = 0 Then
                cmbExtension.SelectedValue = 0
            End If

            If cmbExtension.SelectedValue Is Nothing Then
                cmbExtension.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbExtension_Validated(sender As Object, e As EventArgs)
        Try
            If cmbExtension.SelectedValue = 0 Then
                cmbExtension.SelectedValue = 0
            End If

            If cmbExtension.SelectedValue Is Nothing Then
                cmbExtension.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F8) Then
            e.Handled = True
            btnDelete.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub bgWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork
        Try
            If lstAttachmentForCopy.Count > 0 Then
                Dim streamRead As System.IO.FileStream
                Dim streamWrite As System.IO.FileStream

                For i As Integer = 0 To lstAttachmentForCopy.Count - 1
                    streamRead = New System.IO.FileStream(lstAttachmentForCopy(i).fileName, System.IO.FileMode.Open)
                    streamWrite = New System.IO.FileStream(fileDirectory & "\" & lstAttachmentForCopy(i).safeName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)

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
                        ShowProgress("Uploading files : (" + CInt(streamRead.Position).ToString + "/" + (lngLen * 100).ToString + ")", lblProgress)
                        intBytesRead = (streamRead.Read(byteBuffer, 0, 4096))

                        streamWrite.Write(byteBuffer, 0, intBytesRead)
                    End While

                    streamRead.Dispose()
                    streamWrite.Dispose()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        If e.Cancelled = True Then 'unused, supportscancellation is disabled
            pbAttachment.Visible = False
            txtAttachmentName.Visible = False

            btnBrowse.Enabled = True
            btnRemove.Enabled = True
            btnView.Enabled = True

            btnNext.Enabled = False
            btnPrevious.Enabled = False

            btnSave.Enabled = True
            btnDelete.Enabled = True
            btnClose.Enabled = True
        Else
            Me.DialogResult = DialogResult.OK
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
        pbAttachment.Value = e.ProgressPercentage
    End Sub

    Private Sub frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If modelId = 0 Then
            Me.Text = "New Model Entry"

            txtModelName.Clear()
            cmbExtension.SelectedValue = 0
            rdActive.Checked = True
        Else
            Me.Text = "Model No. " & modelId
            orgModelName = txtModelName.Text.Trim

            Dim attachmentCount As Integer = 0
            Dim prmCnt(0) As SqlParameter
            prmCnt(0) = New SqlParameter("@ModelId", SqlDbType.Int)
            prmCnt(0).Value = modelId

            attachmentCount = dbMethod.ExecuteScalar("CntMntJigModelAttachmentByModelId", CommandType.StoredProcedure, prmCnt)

            If attachmentCount > 0 Then
                Dim prmAttachment(0) As SqlParameter
                prmAttachment(0) = New SqlParameter("@ModelId", SqlDbType.Int)
                prmAttachment(0).Value = modelId

                dtModelAttachment = dbMethod.FillDataTable("RdMntJigModelAttachmentByModelId", CommandType.StoredProcedure, prmAttachment)

                For i As Integer = 0 To dtModelAttachment.Rows.Count - 1
                    Dim attachment As New FileAttachment(Path.Combine(fileDirectory, dtModelAttachment.Rows(i).Item("Filename").ToString),
                                                         dtModelAttachment.Rows(i).Item("Filename").ToString,
                                                         Path.GetExtension(Path.Combine(fileDirectory, dtModelAttachment.Rows(i).Item("Filename").ToString)),
                                                         dtModelAttachment.Rows(i).Item("AttachmentId"))
                    lstAttachment.Add(attachment)
                    currentIndex = 0
                Next
                ShowAttachment()

                lblAttachmentCount.Text = String.Format("{0}/{1}", currentIndex + 1, attachmentCount)

            Else
                AxAcroPDF.LoadFile("Empty")
                picImage.Image = Nothing
                picImage.Visible = True
                AxAcroPDF.Visible = False
                txtAttachmentName.Text = String.Empty
                lblAttachmentCount.Text = ""
                lstAttachment.Clear()
            End If
        End If

        Me.ActiveControl = txtModelName
        txtModelName.Select(txtModelName.Text.Trim.Length, 0)
    End Sub

    Private Sub ShowAttachment()
        Try
            If lstAttachment.Count = 0 Then
                picImage.Image = Nothing
                AxAcroPDF.Visible = False
                AxAcroPDF.LoadFile("Empty")
                picImage.Visible = True
                txtAttachmentName.Text = String.Empty
                lblAttachmentCount.Text = ""
                Exit Sub
            Else
                txtAttachmentName.Text = lstAttachment(currentIndex).safeName
                lblAttachmentCount.Text = String.Format("{0}/{1}", currentIndex + 1, lstAttachment.Count)
            End If

            If lstImageFiles.Contains(lstAttachment(currentIndex).extensionName.ToString.Trim.ToLower) Then
                picImage.Visible = True
                AxAcroPDF.Visible = False

                Using img As Image = Image.FromFile(lstAttachment(currentIndex).fileName)
                    picImage.Image = New Bitmap(img)
                End Using

            ElseIf lstDocumentFiles.Contains(lstAttachment(currentIndex).extensionName.ToString.Trim.ToLower) Then
                picImage.Visible = True
                AxAcroPDF.Visible = False

                Select Case lstAttachment(currentIndex).extensionName.ToString.Trim.ToLower
                    Case ".doc", ".docx"
                        picImage.Image = My.Resources.file_type_doc_512px

                    Case ".xls", ".xlsx"
                        picImage.Image = My.Resources.file_type_xls_512px

                    Case ".ppt", ".pptx"
                        picImage.Image = My.Resources.file_type_ppt_512px

                    Case ".txt"
                        picImage.Image = My.Resources.file_type_txt_512px
                End Select

            ElseIf lstPdfFiles.Contains(lstAttachment(currentIndex).extensionName.ToString.Trim.ToLower) Then
                picImage.Visible = False
                AxAcroPDF.Visible = True
                AxAcroPDF.src = lstAttachment(currentIndex).fileName + "#toolbar=0&scrollbar=0&navpanes=0"
                AxAcroPDF.setShowToolbar(False)
                AxAcroPDF.setShowScrollbars(False)
                AxAcroPDF.setView("Fit")
                AxAcroPDF.setLayoutMode("SinglePage")

            Else
                picImage.Visible = True
                AxAcroPDF.Visible = False
                picImage.Image = My.Resources.file_type_unknown_512px
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NextImage(val As Integer)
        Try
            currentIndex += val
            If currentIndex < 0 Then currentIndex = lstAttachment.Count - 1
            If currentIndex > lstAttachment.Count - 1 Then currentIndex = 0
            If currentIndex = lstAttachment.Count - 1 Then currentIndex = lstAttachment.Count - 1
            ShowAttachment()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsModelExist(modelName As String) As Boolean
        Dim count As Integer = 0

        Try
            Dim prmCnt(0) As SqlParameter
            prmCnt(0) = New SqlParameter("@ModelName", SqlDbType.NVarChar)
            prmCnt(0).Value = modelName

            count = dbMethod.ExecuteScalar("SELECT COUNT(ModelId) FROM dbo.MntJigModel WHERE TRIM(ModelName) = @ModelName", CommandType.Text, prmCnt)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub LoadExtension()
        Try
            cmbExtension.DisplayMember = "ExtensioName"
            cmbExtension.ValueMember = "ExtensionId"
            dbMethod.FillCmbWithCaption("RdMntModelExtension", CommandType.StoredProcedure, "ExtensionId", "ExtensionName", cmbExtension, "< None >")

            AddHandler cmbExtension.Validated, AddressOf cmbExtension_Validated
            AddHandler cmbExtension.SelectedValueChanged, AddressOf cmbExtension_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pnlStatus_Enter(sender As Object, e As EventArgs) Handles pnlRemarks.Enter
        lblRemarks.ForeColor = Color.White
        lblRemarks.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub pnlStatus_Leave(sender As Object, e As EventArgs) Handles pnlRemarks.Leave
        lblRemarks.ForeColor = Color.Black
        lblRemarks.BackColor = SystemColors.Control
    End Sub

    Private Sub txtMachineName_Enter(sender As Object, e As EventArgs) Handles txtModelName.Enter
        lblModelName.ForeColor = Color.White
        lblModelName.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtMachineName_Leave(sender As Object, e As EventArgs) Handles txtModelName.Leave
        lblModelName.ForeColor = Color.Black
        lblModelName.BackColor = SystemColors.Control
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            NextImage(1)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        Try
            NextImage(-1)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try
            If lstAttachment.Count > 0 Then
                Process.Start(lstAttachment(currentIndex).fileName)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
            ofdRecDetail.Filter = "Image Files (*.jpeg, *.png) | *.jpg; *.jpeg; *.png; *.bmp; *.gif; *.tif; *.tiff; |" &
                                  "Word Documents (*.doc) | *.doc; *.docx; |" &
                                  "Excel Worksheets (*.xls, *.xlsx) | *.xls; *.xlsx |" &
                                  "Presentation Files (*.ppt, *pptx) | *.ppt; *.pptx; *.odp; |" &
                                  "PDF Files (*.pdf) | *.pdf; |" &
                                  "Text Files (*.txt) | *.txt |" &
                                  "All Files (*.*) | *.*"
            ofdRecDetail.FilterIndex = 7
            ofdRecDetail.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ofdRecDetail_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdRecDetail.FileOk
        Try
            For i As Integer = 0 To ofdRecDetail.FileNames.Length - 1
                Dim newAttachment As New FileAttachment(ofdRecDetail.FileNames(i), ofdRecDetail.SafeFileNames(i), Path.GetExtension(ofdRecDetail.SafeFileNames(i)).ToLower)
                lstAttachment.Add(newAttachment)
                currentIndex = lstAttachment.Count - 1
            Next
            ShowAttachment()

            ofdRecDetail.InitialDirectory = Path.GetDirectoryName(lstAttachment(currentIndex).fileName)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            If lstAttachment.Count = 0 Then Exit Sub

            If modelId = 0 Then
                lstAttachment.RemoveAt(currentIndex)
            Else
                If Not lstAttachment(currentIndex).attachmentId = 0 Then
                    Dim forDeleteItem As New FileAttachment(fileDirectory & "\" & lstAttachment(currentIndex).fileName,
                                                            lstAttachment(currentIndex).safeName,
                                                            Path.GetExtension(lstAttachment(currentIndex).safeName),
                                                            lstAttachment(currentIndex).attachmentId)
                    lstAttachmentForDelete.Add(forDeleteItem)
                    lstAttachment.RemoveAt(currentIndex)
                Else
                    lstAttachment.RemoveAt(currentIndex)
                End If
            End If

            NextImage(-1)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MntJigModelDetail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AxAcroPDF.Dispose()
    End Sub

End Class