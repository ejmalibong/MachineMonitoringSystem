Imports System.Data.SqlClient
Imports BlackCoffeeLibrary
Imports ClosedXML.Excel

Public Class MntSparePart
    Public bsSparePart As New BindingSource
    Private accessLevelId As Integer = 0
    Private actStock As Integer = 0
    Private connection As New Connection

    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dicSearchCriteria As New Dictionary(Of String, Integer)
    Private dicSortCriteria As New Dictionary(Of String, String)
    Private dtSparePart As New DataTable

    Private indexPosition As Integer = 0
    Private indexScroll As Integer = 0

    Private isAdmin As Integer = 0
    Private isFilterByBelowOrderingPoint As Boolean = False
    Private isFilterByItemTypeId As Boolean = False
    Private isFilterByLocationId As Boolean = False
    Private isFilterByMachineTypeId As Boolean = False
    Private isFilterByMinStock As Boolean = False
    Private isFilterByPartName As Boolean = False
    Private isFilterByPartNo As Boolean = False
    Private minStock As Integer = 0

    Private ordPoint As Integer = 0

    Private pageCount As Integer
    Private pageIndex As Integer
    Private pageSize As Integer
    Private totalCount As Integer
    Private userId As Integer = 0
    Private workgroupId As Integer = 0
    Public Sub New(_userId As Integer, _workgroupId As Integer, _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        workgroupId = _workgroupId
        isAdmin = _isAdmin

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

        'uncomment to use peso sign in currency columns
        'Me.dgvList.Columns("ColUnitPrice").DefaultCellStyle.Format = "C"
        'Me.dgvList.Columns("ColUnitPrice").DefaultCellStyle.FormatProvider = Globalization.CultureInfo.GetCultureInfo("en-PH")

        Me.dgvList.Columns("ColUnitPrice").DefaultCellStyle.Format = "N"
        Me.dgvList.Columns("ColUnitPrice").DefaultCellStyle.FormatProvider = Globalization.CultureInfo.GetCultureInfo("en-US")
        Me.dgvList.Columns("ColActualStockAmount").DefaultCellStyle.Format = "N"
        Me.dgvList.Columns("ColActualStockAmount").DefaultCellStyle.FormatProvider = Globalization.CultureInfo.GetCultureInfo("en-US")
    End Sub

    Public Sub Reload()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
        LoadPart()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        Try
            Dim dt As New DataTable

            dt = dbMethod.FillDataTable("SELECT * FROM dbo.VwMntSparePart", CommandType.Text)

            Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"
            Dim fileName As String = folderPath & Convert.ToString(CDate(dbMethod.GetServerDate).Date.ToString("yyyyMMdd") & " Spare Parts Inventory.xlsx")

            If Not System.IO.Directory.Exists(folderPath) Then
                System.IO.Directory.CreateDirectory(folderPath)
            End If

            Using wb As New XLWorkbook()
                wb.Worksheets.Add(dt, "Sheet1")
                wb.SaveAs(fileName)
            End Using

            Process.Start(fileName)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BelowOrderingPointToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BelowOrderingPointToolStripMenuItem.Click
        Try

        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        LoadPart()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        LoadPart()
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If

        LoadPart()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If

        LoadPart()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Using frm As New MntSparePartDetail(userId, workgroupId, isAdmin)
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Reload()
                    bsSparePart.Position = bsSparePart.Find("PartId", frm.pKey)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

            'allow delete function from senior technician and above only
            If accessLevelId >= CInt(4) Then 'technician and below)
                Me.BringToFront()
                MessageBox.Show("You do not have permission to delete a record.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If Me.dgvList.Rows.Count > 0 Then
                Dim partId As Integer = CType(Me.bsSparePart.Current, DataRowView).Item("PartId")

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
                End If

                btnRefresh.PerformClick()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If Me.dgvList.Rows.Count > 0 Then
                Dim partId As Integer = CType(Me.bsSparePart.Current, DataRowView).Item("PartId")

                Using frm As New MntSparePartDetail(userId, workgroupId, isAdmin, partId)
                    If frm.ShowDialog(Me) = DialogResult.OK Then
                        Reload()
                        bsSparePart.Position = bsSparePart.Find("PartId", frm.pKey)
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            cmsExport.Show(btnExport, New Point(0, 0))
            AllToolStripMenuItem.Select()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
    End Sub

    Private Sub btnIssueStock_Click(sender As Object, e As EventArgs) Handles btnIssueStock.Click
        Try
            Using frm As New MntTrxPartIssue(userId)
                If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Reload()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReceiveStock_Click(sender As Object, e As EventArgs) Handles btnReceiveStock.Click
        Try
            Using frm As New MntTrxPartReceive(userId)
                If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Reload()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Reload()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            isFilterByPartNo = False
            isFilterByPartName = False
            isFilterByLocationId = False
            isFilterByItemTypeId = False
            isFilterByMachineTypeId = False

            cmbSearchCriteria.SelectedValue = 1

            txtCommon.Clear()
            cmbCommon.SelectedValue = 0
            cmbCommon2.SelectedValue = 0
            dtpStartDate.Value = CDate(dbMethod.GetServerDate).Date
            dtpEndDate.Value = CDate(dbMethod.GetServerDate).Date

            pageIndex = 0
            LoadPart()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    isFilterByPartNo = True
                    isFilterByPartName = False
                    isFilterByLocationId = False
                    isFilterByItemTypeId = False
                    isFilterByMachineTypeId = False

                Case 2
                    isFilterByPartNo = False
                    isFilterByPartName = True
                    isFilterByLocationId = False
                    isFilterByItemTypeId = False
                    isFilterByMachineTypeId = False

                Case 3
                    isFilterByPartNo = False
                    isFilterByPartName = False
                    isFilterByLocationId = True
                    isFilterByItemTypeId = False
                    isFilterByMachineTypeId = False

                Case 4
                    isFilterByPartNo = False
                    isFilterByPartName = False
                    isFilterByLocationId = False
                    isFilterByItemTypeId = True
                    isFilterByMachineTypeId = False

                Case 5
                    isFilterByPartNo = False
                    isFilterByPartName = False
                    isFilterByLocationId = False
                    isFilterByItemTypeId = False
                    isFilterByMachineTypeId = True
            End Select

            pageIndex = 0
            LoadPart()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnViewLogs_Click(sender As Object, e As EventArgs) Handles btnViewLogs.Click
        Try

        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckedChanged(sender As Object, e As EventArgs)
        Reload()
    End Sub

    Private Sub cmbCommon_Validated(sender As Object, e As EventArgs) Handles cmbCommon.Validated
        If cmbCommon.SelectedValue = 0 Then
            cmbCommon.SelectedValue = 0
        End If
    End Sub

    Private Sub cmbSearchCriteria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSearchCriteria.SelectedValueChanged
        Try
            cmbCommon.SelectedValue = 0
            cmbCommon.DataSource = Nothing
            cmbCommon.Items.Clear()

            cmbCommon2.SelectedValue = 0
            cmbCommon2.DataSource = Nothing
            cmbCommon2.Items.Clear()

            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    txtCommon.Clear()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = False
                    pnlSearchByCmb2.Visible = False
                    pnlSearchByText.Visible = True

                Case 2
                    txtCommon.Clear()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = False
                    pnlSearchByCmb2.Visible = False
                    pnlSearchByText.Visible = True

                Case 3
                    LoadLocation()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = False
                    pnlSearchByCmb2.Visible = True
                    pnlSearchByText.Visible = False

                Case 4
                    LoadItemType()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = False
                    pnlSearchByCmb2.Visible = True
                    pnlSearchByText.Visible = False

                Case 5
                    LoadMachineType()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = False
                    pnlSearchByCmb2.Visible = True
                    pnlSearchByText.Visible = False
            End Select

            Select Case cmbSearchCriteria.SelectedValue
                Case 3, 4, 5
                    ActiveControl = cmbCommon
                Case 1, 2
                    ActiveControl = txtCommon
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbSortCriteria_SelectedValueChanged(sender As Object, e As EventArgs)
        Reload()
    End Sub

    Private Sub dgvList_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        For i As Integer = 0 To dgvList.Rows.Count - 1
            actStock = dgvList.Rows(i).Cells("ColActualStock").Value
            minStock = dgvList.Rows(i).Cells("ColMinStock").Value
            ordPoint = dgvList.Rows(i).Cells("ColOrderingPoint").Value

            If actStock < ordPoint Then
                dgvList.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If

            If actStock < minStock Then
                dgvList.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral
            End If
        Next
    End Sub

    Private Sub dgvTransactionHeader_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    Private Sub dgvTransactionHeader_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvList.DataError
        e.Cancel = False
    End Sub

    Private Sub GetScrollingIndex()
        indexScroll = dgvList.FirstDisplayedCell.RowIndex
        indexPosition = dgvList.CurrentRow.Index
    End Sub

    Private Function GetSortMode() As String
        Dim sortMode As String = String.Empty

        Try
            If rdAsc.Checked = True Then
                sortMode = "ASC"
            ElseIf rdDesc.Checked = True Then
                sortMode = "DESC"
            Else
                sortMode = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return sortMode
    End Function

    Private Sub Go()
        Try
            If String.IsNullOrEmpty(txtPageNumber.Text) Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPageNumber.Focus()
                Return
            End If

            If CInt(txtPageNumber.Text) > pageCount Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPageNumber.Focus()
                Return
            End If

            If CInt(txtPageNumber.Text) = 0 Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPageNumber.Focus()
                Return
            End If

            pageIndex = CInt(txtPageNumber.Text) - 1
            LoadPart()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadItemType()
        dbMethod.FillCmbWithCaption("RdMntSparePartItemType", CommandType.StoredProcedure, "ItemTypeId", "ItemTypeName", cmbCommon2, "< All >")
    End Sub

    Private Sub LoadLocation()
        dbMethod.FillCmbWithCaption("RdMntSparePartLocation", CommandType.StoredProcedure, "LocationId", "LocationName", cmbCommon2, "< All >")
    End Sub

    Private Sub LoadMachineType()
        dbMethod.FillCmbWithCaption("RdMntSparePartMachineType", CommandType.StoredProcedure, "MachineTypeId", "MachineTypeName", cmbCommon2, "< All >")
    End Sub

    Private Sub LoadPart()
        Try
            totalCount = 0

            If isFilterByPartNo = True Then
                Dim prmPart(5) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@SortingCol", SqlDbType.VarChar)
                prmPart(3).Value = cmbSortCriteria.SelectedValue
                prmPart(4) = New SqlParameter("@SortType", SqlDbType.VarChar)
                prmPart(4).Value = GetSortMode()
                prmPart(5) = New SqlParameter("@PartNo", SqlDbType.NVarChar)
                prmPart(5).Value = txtCommon.Text.Trim

                dtSparePart = dbMethod.FillDataTable("RdMntSparePartMasterlistByPartNo", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value

            ElseIf isFilterByPartName = True Then
                Dim prmPart(5) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@SortingCol", SqlDbType.VarChar)
                prmPart(3).Value = cmbSortCriteria.SelectedValue
                prmPart(4) = New SqlParameter("@SortType", SqlDbType.VarChar)
                prmPart(4).Value = GetSortMode()
                prmPart(5) = New SqlParameter("@PartName", SqlDbType.NVarChar)
                prmPart(5).Value = txtCommon.Text.Trim

                dtSparePart = dbMethod.FillDataTable("RdMntSparePartMasterlistByPartName", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value

            ElseIf isFilterByLocationId = True Then
                Dim prmPart(5) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@SortingCol", SqlDbType.VarChar)
                prmPart(3).Value = cmbSortCriteria.SelectedValue
                prmPart(4) = New SqlParameter("@SortType", SqlDbType.VarChar)
                prmPart(4).Value = GetSortMode()
                prmPart(5) = New SqlParameter("@LocationId", SqlDbType.Int)
                prmPart(5).Value = IIf(cmbCommon2.SelectedValue = 0, Nothing, cmbCommon2.SelectedValue)

                dtSparePart = dbMethod.FillDataTable("RdMntSparePartMasterlistByLocationId", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value

            ElseIf isFilterByItemTypeId = True Then
                Dim prmPart(5) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@SortingCol", SqlDbType.VarChar)
                prmPart(3).Value = cmbSortCriteria.SelectedValue
                prmPart(4) = New SqlParameter("@SortType", SqlDbType.VarChar)
                prmPart(4).Value = GetSortMode()
                prmPart(5) = New SqlParameter("@ItemTypeId", SqlDbType.Int)
                prmPart(5).Value = IIf(cmbCommon2.SelectedValue = 0, Nothing, cmbCommon2.SelectedValue)

                dtSparePart = dbMethod.FillDataTable("RdMntSparePartMasterlistByItemTypeId", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value

            ElseIf isFilterByMachineTypeId = True Then
                Dim prmPart(5) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@SortingCol", SqlDbType.VarChar)
                prmPart(3).Value = cmbSortCriteria.SelectedValue
                prmPart(4) = New SqlParameter("@SortType", SqlDbType.VarChar)
                prmPart(4).Value = GetSortMode()
                prmPart(5) = New SqlParameter("@MachineTypeId", SqlDbType.Int)
                prmPart(5).Value = IIf(cmbCommon2.SelectedValue = 0, Nothing, cmbCommon2.SelectedValue)

                dtSparePart = dbMethod.FillDataTable("RdMntSparePartMasterlistByMachineTypeId", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value
            Else
                Dim prmPart(4) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@SortingCol", SqlDbType.VarChar)
                prmPart(3).Value = cmbSortCriteria.SelectedValue
                prmPart(4) = New SqlParameter("@SortType", SqlDbType.VarChar)
                prmPart(4).Value = GetSortMode()

                dtSparePart = dbMethod.FillDataTable("RdMntSparePartMasterlist", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value
            End If

            bsSparePart.DataSource = dtSparePart
            bsSparePart.ResetBindings(True)
            dgvList.AutoGenerateColumns = False
            dgvList.DataSource = bsSparePart

            If totalCount Mod pageSize = 0 Then
                If totalCount = 0 Then
                    pageCount = (totalCount / pageSize) + 1
                Else
                    pageCount = totalCount / pageSize
                End If
            Else
                pageCount = Math.Truncate(totalCount / pageSize) + 1
            End If

            'current page index and total number of pages
            txtPageNumber.Text = pageIndex + 1
            txtTotalPageNumber.Text = "of " & CInt(pageCount) & " Page(s)"

            'enables pager
            txtPageNumber.Enabled = True
            txtTotalPageNumber.Enabled = True
            BindingNavigatorMoveFirstItem.Enabled = True
            BindingNavigatorMovePreviousItem.Enabled = True
            BindingNavigatorMoveNextItem.Enabled = True
            BindingNavigatorMoveLastItem.Enabled = True
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSearchCriteria()
        Try
            dicSearchCriteria.Add(" Part Number", 1)
            dicSearchCriteria.Add(" Part Name", 2)
            dicSearchCriteria.Add(" Location", 3)
            dicSearchCriteria.Add(" Item Type", 4)
            dicSearchCriteria.Add(" Machine Type", 5)

            cmbSearchCriteria.DisplayMember = "Key"
            cmbSearchCriteria.ValueMember = "Value"
            cmbSearchCriteria.DataSource = New BindingSource(dicSearchCriteria, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSortCriteria()
        Try
            dicSortCriteria.Add(" Part Number", "PartNo")
            dicSortCriteria.Add(" Part Name", "PartName")
            dicSortCriteria.Add(" Location", "LocationName")
            dicSortCriteria.Add(" Item Type", "ItemTypeName")
            dicSortCriteria.Add(" Machine Type", "MachineTypeName")

            cmbSortCriteria.DisplayMember = "Key"
            cmbSortCriteria.ValueMember = "Value"
            cmbSortCriteria.DataSource = New BindingSource(dicSortCriteria, Nothing)

            AddHandler cmbSortCriteria.SelectedValueChanged, AddressOf cmbSortCriteria_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MntSpare_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvList.Dispose()
    End Sub

    Private Sub MntSpare_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F2) Then
            e.Handled = True
            btnAdd.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F3) Then
            e.Handled = True
            btnEdit.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F5) Then
            e.Handled = True
            btnRefresh.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F8) Then
            e.Handled = True
            btnDelete.PerformClick()
        End If
    End Sub

    Private Sub MntSpare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSearchCriteria()
        LoadSortCriteria()

        cmbSortCriteria.SelectedValue = "PartNo"
        rdAsc.Checked = True

        pageIndex = 0
        pageSize = 100
        LoadPart()

        AddHandler rdAsc.CheckedChanged, AddressOf CheckedChanged
        AddHandler rdDesc.CheckedChanged, AddressOf CheckedChanged
        'AddHandler dgvList.CellFormatting, AddressOf dgvList_CellFormatting

        dbMain.EnableDoubleBuffered(dgvList)
        Me.ActiveControl = dgvList
    End Sub
    Private Sub SetScrollingIndex()
        dgvList.FirstDisplayedScrollingRowIndex = indexScroll
        If dgvList.Rows.Count > indexPosition Then
            dgvList.Rows(indexPosition).Selected = True
        Else
            dgvList.Rows(indexPosition - 1).Selected = True
        End If
        Me.bsSparePart.Position = dgvList.SelectedCells(0).RowIndex
    End Sub

    Private Sub txtPageNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPageNumber.KeyPress
        If ((Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57) OrElse Asc(e.KeyChar) = 8 OrElse Asc(e.KeyChar) = 13 OrElse Asc(e.KeyChar) = 127) Then
            e.Handled = False
            If Asc(e.KeyChar) = 13 Then
                Go()
            End If
        Else
            e.Handled = True
        End If
    End Sub

End Class