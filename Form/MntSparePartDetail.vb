Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports BlackCoffeeLibrary

Public Class MntSparePartDetail
    Private accessLevelId As Integer = 0
    Private bite As Byte()
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private accessLevel As New AccessLevel

    Private dtPart As New DataTable
    Private imgTmp As String = String.Empty
    Private isAdmin As Integer = 0
    Private lstImgAttachment As New List(Of ImgAttachment)
    Private mStream As New MemoryStream
    Private orgPartNo As String = String.Empty
    Private partId As Integer = 0
    Private userId As Integer = 0
    Private workgroupId As Integer = 0
    'the word `byte` is not a valid identifier

    Public Sub New(_userId As Integer, _workgroupId As Integer, _isAdmin As Boolean, Optional _partId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        partId = _partId
        userId = _userId

        LoadLocation()
        LoadMachineType()
        LoadItemType()
        LoadUnit()
        LoadVendor()

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

    End Sub

    Public Property pKey As Integer = 0

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
            'allow delete function from senior technician and above only
            If accessLevelId >= 4 Then 'technician and below
                MessageBox.Show("You do not have permission to delete a record.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If partId > 0 Then
                Dim prmCnt(0) As SqlParameter
                prmCnt(0) = New SqlParameter("@PartId", SqlDbType.Int)
                prmCnt(0).Value = partId

                Dim count As Integer = dbMethod.ExecuteScalar("CntMntSparePartByPartId", CommandType.StoredProcedure, prmCnt)

                If count > 0 Then
                    MessageBox.Show("This item contains records. Set to inactive instead.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim question = String.Format("Are you sure you want to delete this item?")
                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Dim prmDel(0) As SqlParameter
                    prmDel(0) = New SqlParameter("@PartId", SqlDbType.Int)
                    prmDel(0).Value = partId

                    dbMethod.ExecuteNonQuery("DelMntSparePart", CommandType.StoredProcedure, prmDel)

                    Me.DialogResult = DialogResult.OK
                End If
            End If
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
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(txtPartNo.Text.Trim) Then
                MessageBox.Show("Part no is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPartNo.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtPartName.Text.Trim) Then
                MessageBox.Show("Part name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPartName.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtOrderingPoint.Text.Trim) Then
                MessageBox.Show("Ordering point is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtOrderingPoint.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtMaxStock.Text.Trim) Then
                MessageBox.Show("Maximum stock is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMaxStock.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtMinStock.Text.Trim) Then
                MessageBox.Show("Minimum stock is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMinStock.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtUnitPrice.Text.Trim) Then
                MessageBox.Show("Unit price is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUnitPrice.Focus()
                Return
            End If

            If cmbUnit.SelectedValue = 0 Then
                MessageBox.Show("Unit of measurement is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbUnit.Focus()
                Return
            End If

            If cmbLocation.SelectedValue = 0 Then
                MessageBox.Show("Part storage location is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbLocation.Focus()
                Return
            End If

            If cmbItemType.SelectedValue = 0 Then
                MessageBox.Show("Item type required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbItemType.Focus()
                Return
            End If

            If cmbMachineType.SelectedValue = 0 Then
                MessageBox.Show("Machine type is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbMachineType.Focus()
                Return
            End If

            If partId = 0 Then 'new record
                If IsPartExist(txtPartNo.Text.Trim) = True Then
                    MessageBox.Show("Spare part already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtPartNo.Focus()
                    Return
                End If

                Dim prmPart(19) As SqlParameter
                prmPart(0) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                prmPart(0).Value = userId
                prmPart(1) = New SqlParameter("@CreatedDate", SqlDbType.DateTime)
                prmPart(1).Value = dbMethod.GetServerDate
                prmPart(2) = New SqlParameter("@PartNo", SqlDbType.NVarChar)
                prmPart(2).Value = txtPartNo.Text.Trim
                prmPart(3) = New SqlParameter("@PartName", SqlDbType.NVarChar)
                prmPart(3).Value = txtPartName.Text.Trim
                prmPart(4) = New SqlParameter("@UnitId", SqlDbType.Int)
                prmPart(4).Value = cmbUnit.SelectedValue
                prmPart(5) = New SqlParameter("@ActualStock", SqlDbType.Int)
                prmPart(5).Value = 0
                prmPart(6) = New SqlParameter("@OrderingPoint", SqlDbType.Int)
                prmPart(6).Value = txtOrderingPoint.Text.Trim
                prmPart(7) = New SqlParameter("@MaxStock", SqlDbType.Int)
                prmPart(7).Value = txtMaxStock.Text.Trim
                prmPart(8) = New SqlParameter("@MinStock", SqlDbType.Int)
                prmPart(8).Value = txtMinStock.Text.Trim
                prmPart(9) = New SqlParameter("@LocationId", SqlDbType.Int)
                prmPart(9).Value = cmbLocation.SelectedValue
                prmPart(10) = New SqlParameter("@ItemTypeId", SqlDbType.Int)
                prmPart(10).Value = cmbItemType.SelectedValue
                prmPart(11) = New SqlParameter("@MachineTypeId", SqlDbType.Int)
                prmPart(11).Value = cmbMachineType.SelectedValue
                prmPart(12) = New SqlParameter("@VendorId", SqlDbType.Int)
                prmPart(12).Value = IIf(cmbVendor.SelectedValue = 0, Nothing, cmbVendor.SelectedValue)

                If picImage.Image Is Nothing Then
                    prmPart(13) = New SqlParameter("@Image", SqlDbType.Image)
                    prmPart(13).Value = Nothing
                Else
                    Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                    resImg.Save(mStream, ImageFormat.Jpeg)
                    bite = mStream.GetBuffer
                    prmPart(13) = New SqlParameter("@Image", SqlDbType.Image)
                    prmPart(13).Value = bite
                End If

                prmPart(14) = New SqlParameter("@ItemCode", SqlDbType.Char)
                prmPart(14).Value = IIf(String.IsNullOrEmpty(txtItemCode.Text.Trim), Nothing, txtItemCode.Text.Trim)
                prmPart(15) = New SqlParameter("@Barcode", SqlDbType.Char)
                prmPart(15).Value = IIf(String.IsNullOrEmpty(txtBarcode.Text.Trim), Nothing, txtBarcode.Text.Trim)
                prmPart(16) = New SqlParameter("@QrCode", SqlDbType.Char)
                prmPart(16).Value = IIf(String.IsNullOrEmpty(txtQrCode.Text.Trim), Nothing, txtQrCode.Text.Trim)
                prmPart(17) = New SqlParameter("@Rfid", SqlDbType.Char)
                prmPart(17).Value = IIf(String.IsNullOrEmpty(txtRfid.Text.Trim), Nothing, txtRfid.Text.Trim)
                prmPart(18) = New SqlParameter("@UnitPrice", SqlDbType.Decimal)
                prmPart(18).Value = IIf(String.IsNullOrEmpty(txtUnitPrice.Text.Trim), Nothing, CDec(txtUnitPrice.Text))
                prmPart(19) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmPart(19).Value = IIf(rdActive.Checked = True, True, False)

                dbMethod.ExecuteNonQuery("InsMntSparePart", CommandType.StoredProcedure, prmPart)
                pKey = prmPart(0).Value
            Else 'old record
                If Not txtPartNo.Text.Trim.Equals(orgPartNo) Then
                    If IsPartExist(txtPartNo.Text.Trim) = True Then
                        MessageBox.Show("Spare part already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtPartNo.Focus()
                        Return
                    End If
                End If

                Dim prmPart(19) As SqlParameter
                prmPart(0) = New SqlParameter("@PartId", SqlDbType.Int)
                prmPart(0).Value = partId
                prmPart(1) = New SqlParameter("@PartNo", SqlDbType.NVarChar)
                prmPart(1).Value = txtPartNo.Text.Trim
                prmPart(2) = New SqlParameter("@PartName", SqlDbType.NVarChar)
                prmPart(2).Value = txtPartName.Text.Trim
                prmPart(3) = New SqlParameter("@UnitId", SqlDbType.Int)
                prmPart(3).Value = cmbUnit.SelectedValue
                prmPart(4) = New SqlParameter("@OrderingPoint", SqlDbType.Int)
                prmPart(4).Value = txtOrderingPoint.Text.Trim
                prmPart(5) = New SqlParameter("@MaxStock", SqlDbType.Int)
                prmPart(5).Value = txtMaxStock.Text.Trim
                prmPart(6) = New SqlParameter("@MinStock", SqlDbType.Int)
                prmPart(6).Value = txtMinStock.Text.Trim
                prmPart(7) = New SqlParameter("@LocationId", SqlDbType.Int)
                prmPart(7).Value = cmbLocation.SelectedValue
                prmPart(8) = New SqlParameter("@ItemTypeId", SqlDbType.Int)
                prmPart(8).Value = cmbItemType.SelectedValue
                prmPart(9) = New SqlParameter("@MachineTypeId", SqlDbType.Int)
                prmPart(9).Value = cmbMachineType.SelectedValue
                prmPart(10) = New SqlParameter("@VendorId", SqlDbType.Int)
                prmPart(10).Value = IIf(cmbVendor.SelectedValue = 0, Nothing, cmbVendor.SelectedValue)

                If picImage.Image Is Nothing Then
                    prmPart(11) = New SqlParameter("@Image", SqlDbType.Image)
                    prmPart(11).Value = Nothing
                Else
                    Dim resImg As Image = dbMain.ResizeImage(picImage.Image, New Size(1024, 768))
                    resImg.Save(mStream, ImageFormat.Jpeg)
                    bite = mStream.GetBuffer
                    prmPart(11) = New SqlParameter("@Image", SqlDbType.Image)
                    prmPart(11).Value = bite
                End If

                prmPart(12) = New SqlParameter("@ItemCode", SqlDbType.Char)
                prmPart(12).Value = IIf(String.IsNullOrEmpty(txtItemCode.Text.Trim), Nothing, txtItemCode.Text.Trim)
                prmPart(13) = New SqlParameter("@Barcode", SqlDbType.Char)
                prmPart(13).Value = IIf(String.IsNullOrEmpty(txtBarcode.Text.Trim), Nothing, txtBarcode.Text.Trim)
                prmPart(14) = New SqlParameter("@QrCode", SqlDbType.Char)
                prmPart(14).Value = IIf(String.IsNullOrEmpty(txtQrCode.Text.Trim), Nothing, txtQrCode.Text.Trim)
                prmPart(15) = New SqlParameter("@Rfid", SqlDbType.Char)
                prmPart(15).Value = IIf(String.IsNullOrEmpty(txtRfid.Text.Trim), Nothing, txtRfid.Text.Trim)
                prmPart(16) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                prmPart(16).Value = userId
                prmPart(17) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime)
                prmPart(17).Value = dbMethod.GetServerDate

                If String.IsNullOrWhiteSpace(txtUnitPrice.Text.Trim) Then
                    prmPart(18) = New SqlParameter("@UnitPrice", SqlDbType.Decimal)
                    prmPart(18).Value = 0
                Else
                    prmPart(18) = New SqlParameter("@UnitPrice", SqlDbType.Decimal)
                    prmPart(18).Value = CDec(txtUnitPrice.Text)
                End If

                prmPart(19) = New SqlParameter("@IsActive", SqlDbType.Bit)
                    prmPart(19).Value = IIf(rdActive.Checked = True, True, False)

                    dbMethod.ExecuteNonQuery("UpdMntSparePart", CommandType.StoredProcedure, prmPart)
                    pKey = partId
                End If

                Me.DialogResult = DialogResult.OK
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

    Private Sub cmbArea_Enter(sender As Object, e As EventArgs) Handles cmbLocation.Enter
        lblLocation.ForeColor = Color.White
        lblLocation.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbArea_Leave(sender As Object, e As EventArgs) Handles cmbLocation.Leave
        lblLocation.ForeColor = Color.Black
        lblLocation.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbItemType_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbItemType.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbLocation_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbLocation.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMachineType_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbMachineType.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbUnit_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbUnit.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbVendor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbVendor.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteTempImg(ByVal sender As Object, ByVal e As System.EventArgs)
        If File.Exists(imgTmp) Then
            File.Delete(imgTmp)
        End If
    End Sub

    Private Function GetMachineStatus(machineStatusId As Integer) As String
        Dim status As String = String.Empty

        Try
            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
            prm(0).Value = machineStatusId

            Dim rdr As IDataReader = dbMethod.ExecuteReader("RdMntMachineStatus", CommandType.StoredProcedure, prm)

            While rdr.Read
                status = rdr("MachineStatusName").ToString
            End While
            rdr.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return status
    End Function

    Private Function GetMachineSubStatus(machineSubStatusId As Integer) As String
        Dim status As String = String.Empty

        Try
            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@MachineSubStatusId", SqlDbType.Int)
            prm(0).Value = machineSubStatusId

            Dim rdr As IDataReader = dbMethod.ExecuteReader("RdMntMachineSubStatus", CommandType.StoredProcedure, prm)

            While rdr.Read
                status = rdr("MachineSubStatusName").ToString
            End While
            rdr.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return status
    End Function

    Private Function IsPartExist(partNo As String) As Boolean
        Dim count As Integer = 0

        Try
            Dim prmCnt(0) As SqlParameter
            prmCnt(0) = New SqlParameter("@PartNo", SqlDbType.NVarChar)
            prmCnt(0).Value = partNo

            count = dbMethod.ExecuteScalar("SELECT COUNT(PartId) FROM dbo.MntSparePart WHERE TRIM(PartNo) = @PartNo", CommandType.Text, prmCnt)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub LoadItemType()
        Try
            dbMethod.FillCmbWithCaption("RdMntSparePartItemType", CommandType.StoredProcedure, "ItemTypeId", "ItemTypeName", cmbItemType, "< Select Item Type >")

            AddHandler cmbItemType.Validating, AddressOf cmbItemType_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadLocation()
        Try
            dbMethod.FillCmbWithCaption("RdMntSparePartLocation", CommandType.StoredProcedure, "LocationId", "LocationName", cmbLocation, "< Select Location >")

            AddHandler cmbLocation.Validating, AddressOf cmbLocation_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMachineType()
        Try
            dbMethod.FillCmbWithCaption("RdMntSparePartMachineType", CommandType.StoredProcedure, "MachineTypeId", "MachineTypeName", cmbMachineType, "< Select Machine Type >")

            AddHandler cmbMachineType.Validating, AddressOf cmbMachineType_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUnit()
        Try
            dbMethod.FillCmbWithCaption("RdMntSparePartUnit", CommandType.StoredProcedure, "UnitId", "UnitName", cmbUnit, "< Select Unit >")

            AddHandler cmbUnit.Validating, AddressOf cmbUnit_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadVendor()
        Try
            dbMethod.FillCmbWithCaption("RdMntSparePartVendor", CommandType.StoredProcedure, "VendorId", "VendorName", cmbVendor, "< Select Vendor >")

            AddHandler cmbVendor.Validating, AddressOf cmbVendor_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MntMchSchedDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F8) Then
            e.Handled = True
            btnDelete.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub MntMchSchedDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If partId = 0 Then
                Me.Text = "New Part Entry"

                rdActive.Checked = True
            Else
                Me.Text = "Part No. " & partId

                Dim prmPart(0) As SqlParameter
                prmPart(0) = New SqlParameter("@PartId", SqlDbType.Int)
                prmPart(0).Value = partId

                dtPart = dbMethod.FillDataTable("RdMntSparePart", CommandType.StoredProcedure, prmPart)

                For Each row As DataRow In dtPart.Rows
                    txtCreatedBy.Text = row("CreatedBy")
                    txtCreatedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("CreatedDate"))

                    If Not row("ModifiedBy") Is DBNull.Value Then
                        txtModifiedBy.Text = row("ModifiedBy")
                    End If

                    If Not row("ModifiedDate") Is DBNull.Value Then
                        txtModifiedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("ModifiedDate"))
                    End If

                    txtPartNo.Text = row("PartNo")
                    orgPartNo = row("PartNo")
                    txtPartName.Text = row("PartName")
                    txtOrderingPoint.Text = row("OrderingPoint")
                    txtMaxStock.Text = row("MaxStock")
                    txtMinStock.Text = row("MinStock")
                    txtUnitPrice.Text = row("UnitPrice")

                    cmbUnit.SelectedValue = row("UnitId")
                    cmbLocation.SelectedValue = row("LocationId")
                    cmbItemType.SelectedValue = row("ItemTypeId")
                    cmbMachineType.SelectedValue = row("MachineTypeId")

                    If Not row("VendorId") Is DBNull.Value Then
                        cmbVendor.SelectedValue = row("VendorId")
                    End If

                    If Not row("Barcode") Is DBNull.Value Then
                        txtBarcode.Text = row("Barcode")
                    End If

                    If Not row("QrCode") Is DBNull.Value Then
                        txtQrCode.Text = row("QrCode")
                    End If

                    If Not row("Rfid") Is DBNull.Value Then
                        txtRfid.Text = row("Rfid")
                    End If

                    If row("IsActive") = True Then
                        rdActive.Checked = True
                    Else
                        rdInactive.Checked = True
                    End If

                    If Not row("Image") Is DBNull.Value Then
                        bite = row("Image")
                        Using ms As New MemoryStream(bite)
                            picImage.Image = Image.FromStream(ms)
                        End Using
                    End If

                    If Not row("ItemCode") Is DBNull.Value Then
                        txtItemCode.Text = row("ItemCode")
                    End If
                Next
            End If

            Me.ActiveControl = txtPartNo
            txtPartNo.Select(txtPartNo.Text.Trim.Length, 0)

            imgTmp = Path.Combine(IO.Path.GetTempPath, "tmpImg.jpeg")
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ofdImage_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdImage.FileOk
        Try
            If lstImgAttachment.Count > 0 Then lstImgAttachment.RemoveAt(0)

            If Not picImage.Image Is Nothing Then
                picImage.Image.Dispose()
                picImage.Image = Nothing
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

            ofdImage.InitialDirectory = Path.GetDirectoryName(lstImgAttachment(0).fileName)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pnlStatus_Enter(sender As Object, e As EventArgs) Handles pnlStatus.Enter
        lblIsActive.ForeColor = Color.White
        lblIsActive.BackColor = Color.DarkSlateGray
    End Sub

    'Private Sub cmbFrequency_Leave(sender As Object, e As EventArgs)
    '    lblFrequency.ForeColor = Color.Black
    '    lblFrequency.BackColor = SystemColors.Control
    'End Sub
    Private Sub pnlStatus_Leave(sender As Object, e As EventArgs) Handles pnlStatus.Leave
        lblIsActive.ForeColor = Color.Black
        lblIsActive.BackColor = SystemColors.Control
    End Sub

    Private Sub ResetForm()
        Try
            txtPartNo.Clear()
            txtPartName.Clear()
            txtBarcode.Clear()
            txtQrCode.Clear()
            txtRfid.Clear()

            txtOrderingPoint.Text = 0
            txtMaxStock.Text = 0
            txtMinStock.Text = 0

            cmbUnit.SelectedValue = 0
            cmbVendor.SelectedValue = 0
            cmbLocation.SelectedValue = 0
            cmbItemType.SelectedValue = 0
            cmbMachineType.SelectedValue = 0

            rdActive.Checked = True

            picImage.Image = Nothing

            Me.ActiveControl = txtPartNo
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub cmbFrequency_Enter(sender As Object, e As EventArgs)
    '    lblFrequency.ForeColor = Color.White
    '    lblFrequency.BackColor = Color.DarkSlateGray
    'End Sub
    Private Sub txtKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrderingPoint.KeyPress, txtMaxStock.KeyPress, txtMinStock.KeyPress
        Try
            If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMachineName_Enter(sender As Object, e As EventArgs) Handles txtPartNo.Enter
        lblPartNo.ForeColor = Color.White
        lblPartNo.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtMachineName_Leave(sender As Object, e As EventArgs) Handles txtPartNo.Leave
        lblPartNo.ForeColor = Color.Black
        lblPartNo.BackColor = SystemColors.Control
    End Sub

    Private Sub txtUnitPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnitPrice.KeyPress
        Try
            If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtUnitPrice_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtUnitPrice.Validating
        Try
            Dim res As Decimal = 0.00
            If Decimal.TryParse(txtUnitPrice.Text, res) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class