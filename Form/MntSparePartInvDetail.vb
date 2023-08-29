Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports BlackCoffeeLibrary
Imports ClosedXML.Excel

Public Class MntSparePartInvDetail
    Private adpInventoryDetail As New SqlDataAdapter
    Private bite As Byte()
    Private bsInventoryDetail As New BindingSource
    Private bsPart As New BindingSource
    Private dbConnection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)
    Private dicPartSelection As New Dictionary(Of String, Integer)
    Private dicProcedure As New Dictionary(Of String, Integer)
    Private dtInventoryDetail As New DataTable
    Private dtInventoryHeader As New DataTable
    Private dtPart As New DataTable
    Private isActive As Boolean = False
    Private isLocked As Boolean = False
    Private lstPartIds As New List(Of Integer)
    Private mStream As New MemoryStream
    Private recordId As Integer = 0
    Private userId As Integer = 0
    Public Sub New(_userId As Integer, Optional _recordId As Integer = 0)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        recordId = _recordId

        dbMain.EnableDoubleBuffered(dgvInventoryDetail)

        dbMethod.FillCmb("RdGenMonth", CommandType.StoredProcedure, "MonthId", "MonthName", cmbMonth)

        If recordId = 0 Then
            cmbMonth.SelectedValue = CDate(dbMethod.GetServerDate).Month
            txtYear.Text = CDate(dbMethod.GetServerDate).Year

            Dim prmUser(1) As SqlParameter
            prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmUser(0).Value = 2
            prmUser(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
            prmUser(1).Value = 1
            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbCreatedBy, "", prmUser)

            Dim prmLogId(0) As SqlParameter
            prmLogId(0) = New SqlParameter("@UserId", SqlDbType.Int)
            prmLogId(0).Value = userId

            If dbMethod.ExecuteScalar("SELECT IsActive FROM dbo.SecUser WHERE UserId = @UserId", CommandType.Text, prmLogId) = True Then
                cmbCreatedBy.SelectedValue = userId
            End If

            dtInventoryDetail = CreateInventoryDetail()

            Me.Text = "New Inventory Entry"

            ActiveControl = txtPart
        Else
            Dim prmUser(0) As SqlParameter
            prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmUser(0).Value = 2
            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbCreatedBy, "", prmUser)

            Dim prmHeader(0) As SqlParameter
            prmHeader(0) = New SqlParameter("@RecordId", SqlDbType.Int)
            prmHeader(0).Value = recordId

            dtInventoryHeader = dbMethod.FillDataTable("RdMntSparePartInventoryHeaderByRecordId", CommandType.StoredProcedure, prmHeader)

            dtInventoryDetail = CreateInventoryDetail(recordId)

            Me.Text = "Record No. " & recordId

            For Each row As DataRow In dtInventoryHeader.Rows
                txtCreatedDate.Text = CDate(row("CreatedDate")).ToString("MMMM dd, yyyy   HH:mm")
                cmbCreatedBy.SelectedValue = row("CreatedBy")
                cmbMonth.SelectedValue = row("MonthId")
                txtYear.Text = row("YearId")

                If Not row("ModifiedDate") Is DBNull.Value Then
                    txtModifiedDate.Text = CDate(row("ModifiedDate")).ToString("MMMM dd, yyyy   HH:mm")
                End If

                If Not row("ModifiedByName") Is DBNull.Value Then
                    txtModifiedBy.Text = row("ModifiedByName").ToString.Trim
                End If

                If Not row("Remarks") Is DBNull.Value Then
                    txtRemarks.Text = row("Remarks").ToString.Trim
                End If

                txtTotalActual.Text = row("TotalActualStockQty")
                txtTotalSystem.Text = row("TotalSystemStockQty")
                txtTotalDiscrepancy.Text = row("TotalDiscrepancyQty")
                txtItemQty.Text = row("TotalItemQty")

                isLocked = row("IsLocked")
            Next
        End If

        Dim prmPart(0) As SqlParameter
        prmPart(0) = New SqlParameter("@IsActive", SqlDbType.Bit)
        prmPart(0).Value = 1

        dtPart = dbMethod.FillDataTable("Select PartId, TRIM(PartNo) As PartNo, TRIM(PartName) As PartName FROM dbo.MntSparePart", CommandType.Text, prmPart)

        Me.bsPart.DataSource = dtPart

        'transaction part detail table
        Dim colPartNo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colPartNo.Name = "ColPartNo"
        colPartNo.DataPropertyName = "PartId"
        colPartNo.HeaderText = "Part No"
        colPartNo.DataSource = Me.bsPart
        colPartNo.ValueMember = "PartId"
        colPartNo.DisplayMember = "PartNo"
        colPartNo.Width = 350
        colPartNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colPartNo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colPartNo.SortMode = DataGridViewColumnSortMode.Automatic
        dgvInventoryDetail.Columns.Insert(2, colPartNo)

        Dim colPartName As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colPartName.Name = "ColPartName"
        colPartName.DataPropertyName = "PartId"
        colPartName.HeaderText = "Part Name"
        colPartName.DataSource = Me.bsPart
        colPartName.ValueMember = "PartId"
        colPartName.DisplayMember = "PartName"
        colPartName.Width = 350
        colPartName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colPartName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colPartName.SortMode = DataGridViewColumnSortMode.Automatic
        dgvInventoryDetail.Columns.Insert(3, colPartName)

        AddHandler cmbCreatedBy.Validating, AddressOf cmbTechnician_Validating
        AddHandler cmbCreatedBy.Validated, AddressOf cmbTechnician_Validated
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim partId As Integer = 0

            If cmbProcedure.SelectedValue = 2 Or cmbProcedure.SelectedValue = 3 Then
                If cmbPart.SelectedValue = 0 Then
                    MessageBox.Show("Please select an item.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    cmbPart.Focus()
                    Exit Sub
                End If

                partId = cmbPart.SelectedValue
            Else
                If String.IsNullOrEmpty(txtPart.Text.Trim) Then
                    MessageBox.Show("Please scan an item.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtPart.Focus()
                    Exit Sub
                End If

                Dim prmCount(0) As SqlParameter
                prmCount(0) = New SqlParameter("@PartNo", SqlDbType.NVarChar)
                prmCount(0).Value = txtPart.Text.Trim

                Dim count = dbMethod.ExecuteScalar("Select COUNT(PartId) FROM dbo.MntSparePart WHERE IsActive = 1 And TRIM(PartNo) = @PartNo", CommandType.Text, prmCount)

                If count = 0 Then
                    MessageBox.Show("The code is invalid or item is inactive.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtPart.Clear()
                    txtPart.Focus()
                    Exit Sub
                End If

                Dim prmSelect(0) As SqlParameter
                prmSelect(0) = New SqlParameter("@PartNo", SqlDbType.NVarChar)
                prmSelect(0).Value = txtPart.Text.Trim

                partId = dbMethod.ExecuteScalar("Select PartId FROM dbo.MntSparePart WHERE TRIM(PartNo) = @PartNo", CommandType.Text, prmSelect)
            End If

            Dim qty As Integer = 0
            For Each row As DataGridViewRow In dgvInventoryDetail.Rows
                If row.Cells("ColPartId").Value = partId Then
                    qty += 1
                End If
            Next

            If qty > 0 Then
                MessageBox.Show("The selected item Is already On the list.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

                If cmbProcedure.SelectedValue = 2 Or cmbProcedure.SelectedValue = 3 Then
                    cmbPart.Focus()
                Else
                    txtPart.Focus()
                End If

                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtActualQty.Text) Then
                MessageBox.Show("Please input quantity.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtActualQty.Focus()
                Exit Sub
            End If

            Dim actStockAmount, sysStockAmount As Double

            actStockAmount = CInt(txtActualQty.Text) * CDbl(txtUnitPrice.Text)
            sysStockAmount = CInt(txtSystemQty.Text) * CDbl(txtUnitPrice.Text)

            Me.bsInventoryDetail.AddNew()
            Me.bsInventoryDetail.MoveLast()
            Me.bsInventoryDetail.Current("CreatedBy") = cmbCreatedBy.SelectedValue
            Me.bsInventoryDetail.Current("CreatedDate") = dbMethod.GetServerDate
            Me.bsInventoryDetail.Current("PartId") = partId
            Me.bsInventoryDetail.Current("ActualStockQty") = txtActualQty.Text.Trim
            Me.bsInventoryDetail.Current("ActualStockAmount") = Format(actStockAmount, "0,000.00")
            Me.bsInventoryDetail.Current("SystemStockQty") = txtSystemQty.Text
            Me.bsInventoryDetail.Current("SystemStockAmount") = Format(0, "0,000.00")
            Me.bsInventoryDetail.Current("DiscrepancyQty") = CInt(txtActualQty.Text) - CInt(txtSystemQty.Text)
            Me.bsInventoryDetail.Current("DiscrepancyAmount") = Format(actStockAmount - sysStockAmount, "0,000.00")

            If (CInt(txtActualQty.Text) = CInt(txtSystemQty.Text)) Then
                Me.bsInventoryDetail.Current("IsTally") = True
            Else
                Me.bsInventoryDetail.Current("IsTally") = False
            End If

            Me.bsInventoryDetail.EndEdit()

            If cmbProcedure.SelectedValue = 2 Or cmbProcedure.SelectedValue = 3 Then
                cmbPart.SelectedValue = 0
            Else
                txtPart.Clear()
            End If

            SetTotalQtys()

            txtPartDescription.Text = ""
            txtLocation.Text = ""
            txtSystemQty.Text = ""
            txtUnit.Text = ""
            txtUnitPrice.Text = ""
            txtActualQty.Clear()

            If Not picImage.Image Is Nothing Then
                picImage.Image.Dispose()
                picImage.Image = Nothing
            End If

            If cmbProcedure.SelectedValue = 2 Or cmbProcedure.SelectedValue = 3 Then
                Me.ActiveControl = cmbPart
            Else
                Me.ActiveControl = txtPart
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        Try
            Dim question = "Are you sure you want clear all the items?"
            If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                dtInventoryDetail.Rows.Clear()
            End If

            If cmbProcedure.Enabled = True Then
                If cmbProcedure.SelectedValue = 2 Or cmbProcedure.SelectedValue = 3 Then
                    Me.ActiveControl = cmbPart
                Else
                    Me.ActiveControl = txtPart
                End If
            Else
                ActiveControl = btnClose
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        Try
            Me.bsInventoryDetail.RemoveFilter()
            cmbPartSearch.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Dim dt As DataTable = New DataTable()

            Dim query As String = "SELECT * FROM VwMntSparePartInventory WHERE RecordId = @RecordId"

            Dim prmExport(0) As SqlParameter
            prmExport(0) = New SqlParameter("@RecordId", SqlDbType.Int)
            prmExport(0).Value = recordId

            dt = dbMethod.FillDataTable(query, CommandType.Text, prmExport)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No records found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"
            Dim imgDir As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Temp"
            Dim expFilename As String = folderPath & Convert.ToString(CDate(dbMethod.GetServerDate).Date.ToString("yyyyMMdd") & " Spare Parts Inventory.xlsx")

            If Not System.IO.Directory.Exists(imgDir) Then
                System.IO.Directory.CreateDirectory(imgDir)
            End If

            Using wb As New XLWorkbook()
                Dim ws = wb.Worksheets.Add(dt, "Spare Parts Inventory")

                'adding header column
                For column As Integer = 0 To dt.Columns.Count - 1
                    ws.Cell(1, column + 1).Value = dt.Columns(column).ColumnName
                Next

                'adding rows in cell
                For row As Integer = 0 To dt.Rows.Count - 1
                    For column As Integer = 0 To dt.Columns.Count - 1 - 1
                        ws.Cell(row + 2, column + 1).Value = dt.Rows(row)(column)
                    Next
                Next

                Dim directoryInfo As DirectoryInfo = New DirectoryInfo(imgDir)
                For Each file As FileInfo In directoryInfo.GetFiles()
                    file.Delete()
                Next

                directoryInfo.Delete()

                wb.SaveAs(expFilename)
            End Using

            Process.Start(expFilename)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReflect_Click(sender As Object, e As EventArgs) Handles btnReflect.Click
        Try
            If btnReflect.Enabled = False Then
                Exit Sub
            End If

            If dgvInventoryDetail.Rows.Count > 0 AndAlso recordId <> 0 Then
                Dim question As String = String.Format("Do you want to reflect inventory data to actual stock?" & Environment.NewLine & "NOTE: This cannot be undone.")
                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    For Each dataRowView As DataRowView In bsInventoryDetail
                        Dim row = dataRowView.Row
                        Dim prmUpd(1) As SqlParameter
                        prmUpd(0) = New SqlParameter("@PartId", SqlDbType.Int)
                        prmUpd(0).Value = row("PartId")
                        prmUpd(1) = New SqlParameter("@ActualStockQty", SqlDbType.Int)
                        prmUpd(1).Value = row("ActualStockQty")

                        dbMethod.ExecuteNonQuery("UPDATE dbo.MntSparePart SET ActualStock = @ActualStockQty WHERE PartId = @PartId", CommandType.Text, prmUpd)
                    Next

                    Dim prmReflect(0) As SqlParameter
                    prmReflect(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                    prmReflect(0).Value = recordId

                    dbMethod.ExecuteNonQuery("UPDATE dbo.MntSparePartInventoryHeader SET IsLocked = 1 WHERE RecordId = @RecordId", CommandType.Text, prmReflect)

                    Me.DialogResult = DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            If dgvInventoryDetail.Rows.Count > 0 Then
                Dim question As String = "Are you sure you want to remove this item?"

                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Dim currentRow = CType(Me.bsInventoryDetail.Current, DataRowView).Row
                    Dim rowState = currentRow.RowState

                    Select Case rowState
                        Case DataRowState.Added
                            Me.bsInventoryDetail.RemoveCurrent()

                        Case DataRowState.Detached
                            Me.bsInventoryDetail.CancelEdit()

                        Case DataRowState.Modified, DataRowState.Unchanged
                            If dgvInventoryDetail.SelectedCells.Count > 0 AndAlso dgvInventoryDetail.SelectedCells(0).RowIndex = dgvInventoryDetail.NewRowIndex Then
                                Me.bsInventoryDetail.CancelEdit()
                                Exit Sub
                            End If

                            Me.bsInventoryDetail.RemoveCurrent()

                        Case Else
                            Me.bsInventoryDetail.RemoveCurrent()
                    End Select
                End If
            End If

            If dgvInventoryDetail.Rows.Count > 0 Then
                bsInventoryDetail.MoveLast()
            End If

            SetTotalQtys()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If btnSave.Enabled = False Then
                Exit Sub
            End If

            If cmbCreatedBy.SelectedValue = 0 Then
                MessageBox.Show("Please the inventory in-charge.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbCreatedBy.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtYear.Text.Trim) Then
                MessageBox.Show("Please indicate year of inventory.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtYear.Focus()
                Exit Sub
            End If

            If dgvInventoryDetail.Rows.Count = 0 Then
                MessageBox.Show("Please add item(s) in inventory list.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbPart.Focus()
                Exit Sub
            End If

            If recordId = 0 Then
                Dim prmPrHeader(15) As SqlParameter
                prmPrHeader(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                prmPrHeader(0).Direction = ParameterDirection.Output
                prmPrHeader(1) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                prmPrHeader(1).Value = cmbCreatedBy.SelectedValue
                prmPrHeader(2) = New SqlParameter("@CreatedDate", SqlDbType.DateTime)
                prmPrHeader(2).Value = dbMethod.GetServerDate
                prmPrHeader(3) = New SqlParameter("@YearId", SqlDbType.Int)
                prmPrHeader(3).Value = txtYear.Text
                prmPrHeader(4) = New SqlParameter("@MonthId", SqlDbType.Int)
                prmPrHeader(4).Value = cmbMonth.SelectedValue
                prmPrHeader(5) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                prmPrHeader(5).Value = IIf(String.IsNullOrWhiteSpace(txtRemarks.Text.Trim), Nothing, txtRemarks.Text.Trim)
                prmPrHeader(6) = New SqlParameter("@TotalActualStockQty", SqlDbType.Int)
                prmPrHeader(6).Value = dtInventoryDetail.Compute("SUM(ActualStockQty)", String.Empty)
                prmPrHeader(7) = New SqlParameter("@TotalActualStockAmount", SqlDbType.Decimal)
                prmPrHeader(7).Value = dtInventoryDetail.Compute("SUM(ActualStockAmount)", String.Empty)
                prmPrHeader(8) = New SqlParameter("@TotalSystemStockQty", SqlDbType.Int)
                prmPrHeader(8).Value = dtInventoryDetail.Compute("SUM(SystemStockQty)", String.Empty)
                prmPrHeader(9) = New SqlParameter("@TotalSystemStockAmount", SqlDbType.Decimal)
                prmPrHeader(9).Value = dtInventoryDetail.Compute("SUM(SystemStockAmount)", String.Empty)
                prmPrHeader(10) = New SqlParameter("@TotalDiscrepancyQty", SqlDbType.Int)
                prmPrHeader(10).Value = dtInventoryDetail.Compute("SUM(DiscrepancyQty)", String.Empty)
                prmPrHeader(11) = New SqlParameter("@TotalDiscrepancyAmount", SqlDbType.Decimal)
                prmPrHeader(11).Value = dtInventoryDetail.Compute("SUM(DiscrepancyAmount)", String.Empty)
                prmPrHeader(12) = New SqlParameter("@TotalItemTallyQty", SqlDbType.Int)
                prmPrHeader(12).Value = dtInventoryDetail.Compute("COUNT(PartId)", "IsTally = 1")
                prmPrHeader(13) = New SqlParameter("@TotalItemNotTallyQty", SqlDbType.Int)
                prmPrHeader(13).Value = dtInventoryDetail.Compute("COUNT(PartId)", "IsTally = 0")
                prmPrHeader(14) = New SqlParameter("@TotalItemQty", SqlDbType.Int)
                prmPrHeader(14).Value = dtInventoryDetail.Compute("COUNT(PartId)", String.Empty)
                prmPrHeader(15) = New SqlParameter("@IsLocked", SqlDbType.Bit)
                prmPrHeader(15).Value = 0

                dbMethod.ExecuteNonQuery("InsMntSparePartInventoryHeader", CommandType.StoredProcedure, prmPrHeader)

                For Each dataRowView As DataRowView In Me.bsInventoryDetail
                    Dim row = dataRowView.Row
                    row.Item("RecordId") = prmPrHeader(0).Value
                Next
                Me.bsInventoryDetail.EndEdit()
                adpInventoryDetail.Update(dtInventoryDetail)

            Else
                Dim prmPrHeader(14) As SqlParameter
                prmPrHeader(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                prmPrHeader(0).Value = recordId
                prmPrHeader(1) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                prmPrHeader(1).Value = userId
                prmPrHeader(2) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime)
                prmPrHeader(2).Value = dbMethod.GetServerDate
                prmPrHeader(3) = New SqlParameter("@YearId", SqlDbType.Int)
                prmPrHeader(3).Value = txtYear.Text
                prmPrHeader(4) = New SqlParameter("@MonthId", SqlDbType.Int)
                prmPrHeader(4).Value = cmbMonth.SelectedValue
                prmPrHeader(5) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                prmPrHeader(5).Value = IIf(String.IsNullOrWhiteSpace(txtRemarks.Text.Trim), Nothing, txtRemarks.Text.Trim)
                prmPrHeader(6) = New SqlParameter("@TotalActualStockQty", SqlDbType.Int)
                prmPrHeader(6).Value = dtInventoryDetail.Compute("SUM(ActualStockQty)", String.Empty)
                prmPrHeader(7) = New SqlParameter("@TotalActualStockAmount", SqlDbType.Decimal)
                prmPrHeader(7).Value = dtInventoryDetail.Compute("SUM(ActualStockAmount)", String.Empty)
                prmPrHeader(8) = New SqlParameter("@TotalSystemStockQty", SqlDbType.Int)
                prmPrHeader(8).Value = dtInventoryDetail.Compute("SUM(SystemStockQty)", String.Empty)
                prmPrHeader(9) = New SqlParameter("@TotalSystemStockAmount", SqlDbType.Decimal)
                prmPrHeader(9).Value = dtInventoryDetail.Compute("SUM(SystemStockAmount)", String.Empty)
                prmPrHeader(10) = New SqlParameter("@TotalDiscrepancyQty", SqlDbType.Int)
                prmPrHeader(10).Value = dtInventoryDetail.Compute("SUM(DiscrepancyQty)", String.Empty)
                prmPrHeader(11) = New SqlParameter("@TotalDiscrepancyAmount", SqlDbType.Decimal)
                prmPrHeader(11).Value = dtInventoryDetail.Compute("SUM(DiscrepancyAmount)", String.Empty)
                prmPrHeader(12) = New SqlParameter("@TotalItemTallyQty", SqlDbType.Int)
                prmPrHeader(12).Value = dtInventoryDetail.Compute("COUNT(PartId)", "IsTally = 1")
                prmPrHeader(13) = New SqlParameter("@TotalItemNotTallyQty", SqlDbType.Int)
                prmPrHeader(13).Value = dtInventoryDetail.Compute("COUNT(PartId)", "IsTally = 0")
                prmPrHeader(14) = New SqlParameter("@TotalItemQty", SqlDbType.Int)
                prmPrHeader(14).Value = dtInventoryDetail.Compute("COUNT(PartId)", String.Empty)

                dbMethod.ExecuteNonQuery("UpdMntSparePartInventoryHeader", CommandType.StoredProcedure, prmPrHeader)

                For Each dataRowView As DataRowView In Me.bsInventoryDetail
                    Dim row = dataRowView.Row
                    row.Item("RecordId") = recordId
                Next
                adpInventoryDetail.Update(dtInventoryDetail)
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearchFilter.Click
        Try
            Me.bsInventoryDetail.Filter = "PartId = " & cmbPartSearch.SelectedValue & ""
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPart_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbPart.SelectedValue <> 0 Then
                If Not picImage.Image Is Nothing Then
                    picImage.Image.Dispose()
                    picImage.Image = Nothing
                End If

                If cmbProcedure.SelectedValue = 2 Then
                    Dim prmPartNo(0) As SqlParameter
                    prmPartNo(0) = New SqlParameter("@PartId", SqlDbType.Int)
                    prmPartNo(0).Value = cmbPart.SelectedValue

                    Using rdr As IDataReader = dbMethod.ExecuteReader("RdMntSparePart", CommandType.StoredProcedure, prmPartNo)
                        While rdr.Read
                            txtPartDescription.Text = rdr.Item("PartNo").ToString.Trim
                            txtSystemQty.Text = rdr.Item("ActualStock")
                            txtActualQty.Text = rdr.Item("ActualStock")
                            txtUnit.Text = rdr.Item("UnitCode")
                            txtLocation.Text = rdr.Item("LocationName")
                            txtUnitPrice.Text = Math.Round(rdr.Item("UnitPrice"), 2)

                            If Not rdr.Item("Image") Is DBNull.Value Then
                                bite = rdr.Item("Image")
                                Using ms As New MemoryStream(bite)
                                    picImage.Image = Image.FromStream(ms)
                                End Using
                            End If
                        End While
                        rdr.Close()
                    End Using

                ElseIf cmbProcedure.SelectedValue = 3 Then
                    Dim prmPartNo(0) As SqlParameter
                    prmPartNo(0) = New SqlParameter("@PartId", SqlDbType.Int)
                    prmPartNo(0).Value = cmbPart.SelectedValue

                    Using rdr As IDataReader = dbMethod.ExecuteReader("RdMntSparePart", CommandType.StoredProcedure, prmPartNo)
                        While rdr.Read
                            txtPartDescription.Text = rdr.Item("PartName").ToString.Trim
                            txtSystemQty.Text = rdr.Item("ActualStock")
                            txtActualQty.Text = rdr.Item("ActualStock")
                            txtUnit.Text = rdr.Item("UnitCode")
                            txtLocation.Text = rdr.Item("LocationName")
                            txtUnitPrice.Text = Math.Round(rdr.Item("UnitPrice"), 2)

                            If Not rdr.Item("Image") Is DBNull.Value Then
                                bite = rdr.Item("Image")
                                Using ms As New MemoryStream(bite)
                                    picImage.Image = Image.FromStream(ms)
                                End Using
                            End If
                        End While
                        rdr.Close()
                    End Using
                End If

            Else
                txtPartDescription.Text = ""
                txtLocation.Text = ""
                txtSystemQty.Text = ""
                txtUnit.Text = ""
                txtUnitPrice.Text = ""
                txtActualQty.Clear()

                If Not picImage.Image Is Nothing Then
                    picImage.Image.Dispose()
                    picImage.Image = Nothing
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPart_Validated(sender As Object, e As EventArgs)
        Try
            If cmbPart.SelectedValue = 0 Then
                txtPartDescription.Text = ""
                txtLocation.Text = ""
                txtSystemQty.Text = ""
                txtUnit.Text = ""
                txtUnitPrice.Text = ""
                txtActualQty.Clear()

                If Not picImage.Image Is Nothing Then
                    picImage.Dispose()
                    picImage.Image = Nothing
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPart_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPartSearch_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbPartSearch.SelectedValue = 0 Then
                bsInventoryDetail.RemoveFilter()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPartSearch_Validated(sender As Object, e As EventArgs) Handles cmbPartSearch.Validated
        Try
            If cmbPartSearch.SelectedValue = 0 Or cmbPartSearch.Text.Trim.Length = 0 Then
                cmbPartSearch.SelectedValue = 0
                bsInventoryDetail.RemoveFilter()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPartSearch_Validating(sender As Object, e As CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 AndAlso String.IsNullOrEmpty(cmbPartSearch.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPartSelection_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            cmbPartSearch.DataSource = Nothing

            If dgvInventoryDetail.Rows.Count > 0 Then
                If cmbPartSelection.SelectedValue = 1 Then
                    Dim query As New System.Text.StringBuilder("SELECT PartId, Trim(PartName) + ' ' + TRIM(PartNo) AS PartName FROM dbo.MntSparePart WHERE PartId IN (")

                    For i As Integer = 0 To dgvInventoryDetail.Rows.Count - 1
                        If i > 0 Then
                            query.Append(",")
                        End If
                        query.Append(dgvInventoryDetail.Rows(i).Cells("ColPartId").Value)
                    Next

                    query.Append(")")

                    dbMethod.FillCmbWithCaption(query.ToString, CommandType.Text, "PartId", "PartName", cmbPartSearch, "< All >")

                Else
                    Dim query As New System.Text.StringBuilder("SELECT PartId, TRIM(PartNo) AS PartNo FROM dbo.MntSparePart WHERE PartId IN (")

                    For i As Integer = 0 To dgvInventoryDetail.Rows.Count - 1
                        If i > 0 Then
                            query.Append(",")
                        End If
                        query.Append(dgvInventoryDetail.Rows(i).Cells("ColPartId").Value)
                    Next

                    query.Append(")")

                    dbMethod.FillCmbWithCaption(query.ToString, CommandType.Text, "PartId", "PartNo", cmbPartSearch, "< All >")
                End If

                AddHandler cmbPartSearch.Validating, AddressOf cmbPartSearch_Validating
                'AddHandler cmbPartSearch.Validated, AddressOf cmbPartSearch_Validated
                AddHandler cmbPartSearch.SelectedValueChanged, AddressOf cmbPartSearch_SelectedValueChanged
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbProcedure_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProcedure.SelectedValueChanged
        Try
            cmbPart.DataSource = Nothing

            Select Case cmbProcedure.SelectedValue
                Case 1 'qr code, bar code
                    lblPartDescription.Text = "Part Name"

                    cmbPart.Visible = False
                    txtPart.Visible = True
                    txtPart.BringToFront()

                    txtPart.Enabled = True
                    cmbPart.SelectedValue = 0
                    cmbPart.Enabled = False

                    AddHandler txtPart.KeyDown, AddressOf txtPart_KeyDown

                    RemoveHandler cmbPart.Validated, AddressOf cmbPart_Validated
                    RemoveHandler cmbPart.SelectedValueChanged, AddressOf cmbPart_SelectedValueChanged
                    RemoveHandler cmbPart.Validating, AddressOf cmbPart_Validating

                Case 2 'part nane
                    lblPartDescription.Text = "Part No"

                    cmbPart.DisplayMember = "PartName"
                    cmbPart.ValueMember = "PartId"

                    dbMethod.FillCmbWithCaption("Select PartId, Trim(PartName) + ' ' + TRIM(PartNo) AS PartName FROM dbo.MntSparePart WHERE IsActive = 1",
                                                CommandType.Text, "PartId", "PartName", cmbPart, "")

                    txtPart.Visible = False
                    cmbPart.Visible = True
                    cmbPart.BringToFront()

                    cmbPart.Enabled = True
                    txtPart.Clear()
                    txtPart.Enabled = False

                    RemoveHandler txtPart.KeyDown, AddressOf txtPart_KeyDown

                    AddHandler cmbPart.Validated, AddressOf cmbPart_Validated
                    AddHandler cmbPart.SelectedValueChanged, AddressOf cmbPart_SelectedValueChanged
                    AddHandler cmbPart.Validating, AddressOf cmbPart_Validating

                Case 3 'part no
                    lblPartDescription.Text = "Part Name"

                    cmbPart.DisplayMember = "PartNo"
                    cmbPart.ValueMember = "PartId"

                    dbMethod.FillCmbWithCaption("SELECT PartId, TRIM(PartNo) AS PartNo FROM dbo.MntSparePart WHERE IsActive = 1",
                                                CommandType.Text, "PartId", "PartNo", cmbPart, "")

                    cmbPart.Enabled = True
                    txtPart.Visible = False
                    cmbPart.Visible = True
                    cmbPart.BringToFront()

                    txtPart.Clear()
                    txtPart.Enabled = False

                    RemoveHandler txtPart.KeyDown, AddressOf txtPart_KeyDown

                    AddHandler cmbPart.Validated, AddressOf cmbPart_Validated
                    AddHandler cmbPart.SelectedValueChanged, AddressOf cmbPart_SelectedValueChanged
                    AddHandler cmbPart.Validating, AddressOf cmbPart_Validating
            End Select

            Me.ActiveControl = cmbCreatedBy
            Me.ActiveControl = cmbPart
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTechnician_Enter(sender As Object, e As EventArgs) Handles cmbCreatedBy.Enter
        lblCreatedBy.ForeColor = Color.White
        lblCreatedBy.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbTechnician_Leave(sender As Object, e As EventArgs) Handles cmbCreatedBy.Leave
        lblCreatedBy.ForeColor = Color.Black
        lblCreatedBy.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbTechnician_Validated(sender As Object, e As EventArgs)
        Try
            If cmbCreatedBy.SelectedValue = 0 Then
                cmbCreatedBy.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTechnician_Validating(sender As Object, e As CancelEventArgs)
        e.Cancel = sender.FindStringExact(sender.text) < 0 AndAlso String.IsNullOrEmpty(cmbCreatedBy.Text)
        If e.Cancel Then Beep()
    End Sub

    Private Function CreateInventoryDetail(Optional _recordId As Integer = 0) As DataTable
        Dim dtInventoryDetail As New DataTable
        Dim con As New SqlConnection(dbConnection.GetConnectionString)

        Try
            Dim query As String = String.Empty

            If _recordId = 0 Then
                query = "SELECT * FROM dbo.MntSparePartInventoryDetail"

                Dim cmd As New SqlCommand(query, con)
                adpInventoryDetail = New SqlDataAdapter(cmd)
                Dim cbTrxDetail As New SqlCommandBuilder(adpInventoryDetail)

                Dim colRecordDetailId As DataColumn = New DataColumn("RecordDetailId")
                colRecordDetailId.DataType = System.Type.GetType("System.Int32")
                dtInventoryDetail.Columns.Add(colRecordDetailId)

                Dim colRecordId As DataColumn = New DataColumn("RecordId")
                colRecordId.DataType = System.Type.GetType("System.Int32")
                dtInventoryDetail.Columns.Add(colRecordId)

                Dim colCreatedBy As DataColumn = New DataColumn("CreatedBy")
                colCreatedBy.DataType = System.Type.GetType("System.Int32")
                dtInventoryDetail.Columns.Add(colCreatedBy)

                Dim colCreateDate As DataColumn = New DataColumn("CreatedDate")
                colCreateDate.DataType = System.Type.GetType("System.DateTime")
                dtInventoryDetail.Columns.Add(colCreateDate)

                Dim colPartId As DataColumn = New DataColumn("PartId")
                colPartId.DataType = System.Type.GetType("System.Int32")
                dtInventoryDetail.Columns.Add(colPartId)

                Dim colSystemStockQty As DataColumn = New DataColumn("SystemStockQty")
                colSystemStockQty.DataType = System.Type.GetType("System.Int32")
                dtInventoryDetail.Columns.Add(colSystemStockQty)

                Dim colSystemStockAmount As DataColumn = New DataColumn("SystemStockAmount")
                colSystemStockAmount.DataType = System.Type.GetType("System.Decimal")
                dtInventoryDetail.Columns.Add(colSystemStockAmount)

                Dim colActualStockQty As DataColumn = New DataColumn("ActualStockQty")
                colActualStockQty.DataType = System.Type.GetType("System.Int32")
                dtInventoryDetail.Columns.Add(colActualStockQty)

                Dim colActualStockAmount As DataColumn = New DataColumn("ActualStockAmount")
                colActualStockAmount.DataType = System.Type.GetType("System.Decimal")
                dtInventoryDetail.Columns.Add(colActualStockAmount)

                Dim colDiscrepancyQty As DataColumn = New DataColumn("DiscrepancyQty")
                colDiscrepancyQty.DataType = System.Type.GetType("System.Int32")
                dtInventoryDetail.Columns.Add(colDiscrepancyQty)

                Dim colDiscrepancyAmount As DataColumn = New DataColumn("DiscrepancyAmount")
                colDiscrepancyAmount.DataType = System.Type.GetType("System.Decimal")
                dtInventoryDetail.Columns.Add(colDiscrepancyAmount)

                Dim colModifiedBy As DataColumn = New DataColumn("ModifiedBy")
                colModifiedBy.DataType = System.Type.GetType("System.Int32")
                colModifiedBy.AllowDBNull = True
                dtInventoryDetail.Columns.Add(colModifiedBy)

                Dim colModifiedDate As DataColumn = New DataColumn("ModifiedDate")
                colModifiedDate.DataType = System.Type.GetType("System.DateTime")
                colModifiedDate.AllowDBNull = True
                dtInventoryDetail.Columns.Add(colModifiedDate)

                Dim colIsTally As DataColumn = New DataColumn("IsTally")
                colIsTally.DataType = System.Type.GetType("System.Boolean")
                dtInventoryDetail.Columns.Add(colIsTally)

            Else
                query = "SELECT * FROM dbo.MntSparePartInventoryDetail WHERE RecordId = " & recordId & ""

                Dim cmd As New SqlCommand(query, con)
                adpInventoryDetail = New SqlDataAdapter(cmd)
                Dim cbTrxDetail As New SqlCommandBuilder(adpInventoryDetail)

                adpInventoryDetail.Fill(dtInventoryDetail)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtInventoryDetail
    End Function

    Private Sub dgvPartDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvInventoryDetail.DataError
        e.Cancel = False
    End Sub

    Private Sub LoadItems()
        Try

        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadPartSelection()
        Try
            dicPartSelection.Add(" Part Name", 1)
            dicPartSelection.Add(" Part No", 2)

            cmbPartSelection.DisplayMember = "Key"
            cmbPartSelection.ValueMember = "Value"
            cmbPartSelection.DataSource = New BindingSource(dicPartSelection, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadProcedure()
        Try
            dicProcedure.Add(" Scan Code", 1)
            dicProcedure.Add(" Part Name", 2)
            dicProcedure.Add(" Part No", 3)

            cmbProcedure.DisplayMember = "Key"
            cmbProcedure.ValueMember = "Value"
            cmbProcedure.DataSource = New BindingSource(dicProcedure, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub MntSparePartInvDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub MntSparePartInvDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProcedure()
        LoadPartSelection()

        If recordId = 0 Then
            btnReflect.Enabled = False
        Else
            If isLocked = False Then 'false
                cmbCreatedBy.Enabled = True
                cmbMonth.Enabled = True
                txtYear.Enabled = True
                txtRemarks.Enabled = True
                cmbProcedure.Enabled = True
                cmbPart.Enabled = True
                txtPart.Enabled = True
                txtActualQty.Enabled = True

                btnClearAll.Enabled = True
                btnAdd.Enabled = True
                btnRemove.Enabled = True
                btnSave.Enabled = True
                btnCancel.Enabled = True
                btnDelete.Enabled = True
                btnReflect.Enabled = True
            Else
                cmbCreatedBy.Enabled = False
                cmbMonth.Enabled = False
                txtYear.Enabled = False
                txtRemarks.Enabled = False
                cmbProcedure.Enabled = False
                cmbPart.Enabled = False
                txtPart.Enabled = False
                txtActualQty.Enabled = False

                btnClearAll.Enabled = False
                btnAdd.Enabled = False
                btnRemove.Enabled = False
                btnSave.Enabled = False
                btnCancel.Enabled = False
                btnDelete.Enabled = False
                btnReflect.Enabled = False
            End If
        End If

        Me.bsInventoryDetail.DataSource = dtInventoryDetail
        dgvInventoryDetail.AutoGenerateColumns = False
        dgvInventoryDetail.DataSource = Me.bsInventoryDetail

        If isLocked = False Then
            ActiveControl = txtPart
        Else
            ActiveControl = btnClose
        End If

        If dgvInventoryDetail.Rows.Count > 0 Then
            Dim query As New System.Text.StringBuilder("SELECT PartId, Trim(PartName) + ' ' + TRIM(PartNo) AS PartName FROM dbo.MntSparePart WHERE PartId IN (")

            For i As Integer = 0 To dgvInventoryDetail.Rows.Count - 1
                If i > 0 Then
                    query.Append(",")
                End If
                query.Append(dgvInventoryDetail.Rows(i).Cells("ColPartId").Value)
            Next

            query.Append(")")

            dbMethod.FillCmbWithCaption(query.ToString, CommandType.Text, "PartId", "PartName", cmbPartSearch, "< All >")
        End If

        If recordId <> 0 AndAlso dgvInventoryDetail.Rows.Count > 0 Then
            dgvInventoryDetail.ClearSelection()
        End If

        cmbPartSelection.SelectedValue = 1
    End Sub

    Private Sub MntSparePartInvDetail_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            If recordId = 0 Then
                If cmbCreatedBy.SelectedValue <> 0 Then
                    cmbCreatedBy.SelectionLength = 0
                End If
            Else
                cmbCreatedBy.SelectionLength = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub NumberOnly_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtActualQty.KeyPress, txtYear.KeyPress
        Try
            If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetTotalQtys()
        Try
            If dgvInventoryDetail.Rows.Count > 0 Then
                txtItemQty.Text = dtInventoryDetail.Rows.Count
                txtTotalActual.Text = dtInventoryDetail.Compute("SUM(ActualStockQty)", "ActualStockQty <> 0")
                txtTotalSystem.Text = dtInventoryDetail.Compute("SUM(SystemStockQty)", "SystemStockQty <> 0")
                txtTotalDiscrepancy.Text = dtInventoryDetail.Compute("SUM(DiscrepancyQty)", String.Empty)
            Else
                txtItemQty.Text = ""
                txtTotalActual.Text = ""
                txtTotalSystem.Text = ""
                txtTotalDiscrepancy.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtActualQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtActualQty.KeyDown
        Try
            If e.KeyCode = Keys.Return AndAlso Not String.IsNullOrWhiteSpace(txtActualQty.Text.Trim) Then
                btnAdd.PerformClick()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtPart_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Return AndAlso Not String.IsNullOrWhiteSpace(txtPart.Text.Trim) Then
                Dim prmCount(0) As SqlParameter
                prmCount(0) = New SqlParameter("@PartNo", SqlDbType.NVarChar)
                prmCount(0).Value = txtPart.Text.Trim

                Dim count = dbMethod.ExecuteScalar("SELECT COUNT(PartId) FROM dbo.MntSparePart WHERE IsActive = 1 AND TRIM(PartNo) = @PartNo", CommandType.Text, prmCount)

                If count = 0 Then
                    MessageBox.Show("The code is invalid or item is inactive.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtPart.Clear()
                    txtPart.Focus()
                    Exit Sub
                End If

                Dim prmSelect(0) As SqlParameter
                prmSelect(0) = New SqlParameter("@PartNo", SqlDbType.NVarChar)
                prmSelect(0).Value = txtPart.Text.Trim

                Dim partId = dbMethod.ExecuteScalar("SELECT PartId FROM dbo.MntSparePart WHERE TRIM(PartNo) = @PartNo", CommandType.Text, prmSelect)

                Dim qty As Integer = 0
                For Each row As DataGridViewRow In dgvInventoryDetail.Rows
                    If row.Cells("ColPartId").Value = partId Then
                        qty += 1
                    End If
                Next

                If qty > 0 Then
                    MessageBox.Show("The selected item is already on the list.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtPart.Clear()
                    txtPart.Focus()
                    Exit Sub
                End If

                If Not picImage.Image Is Nothing Then
                    picImage.Image.Dispose()
                    picImage.Image = Nothing
                End If

                Dim prmPartNo(0) As SqlParameter
                prmPartNo(0) = New SqlParameter("@PartId", SqlDbType.Int)
                prmPartNo(0).Value = partId

                Using rdr As IDataReader = dbMethod.ExecuteReader("RdMntSparePart", CommandType.StoredProcedure, prmPartNo)
                    While rdr.Read
                        txtPartDescription.Text = rdr.Item("PartName").ToString.Trim
                        txtLocation.Text = rdr.Item("LocationName")
                        txtActualQty.Text = rdr.Item("ActualStock")
                        txtSystemQty.Text = rdr.Item("ActualStock")
                        txtUnit.Text = rdr.Item("UnitCode")
                        txtUnitPrice.Text = Math.Round(rdr.Item("UnitPrice"), 2)

                        If Not rdr.Item("Image") Is DBNull.Value Then
                            bite = rdr.Item("Image")
                            Using ms As New MemoryStream(bite)
                                picImage.Image = Image.FromStream(ms)
                            End Using
                        End If
                    End While
                    rdr.Close()
                End Using

                txtActualQty.Focus()
                txtActualQty.SelectionLength = Len(txtActualQty.Text.Trim)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class