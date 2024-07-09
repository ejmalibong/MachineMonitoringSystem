Imports System.Data.SqlClient
Imports BlackCoffeeLibrary
Imports ClosedXML.Excel

Public Class MntSparePartLogFloat
    Public bsTransactionPartDetailFloat As New BindingSource
    Private connection As New Connection

    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dicSearchCriteria As New Dictionary(Of String, Integer)
    Private dicSortCriteria As New Dictionary(Of String, String)
    Private dtSparePart As New DataTable

    Private indexPosition As Integer = 0
    Private indexScroll As Integer = 0

    Private isFilterByPartName As Boolean = False
    Private isFilterByPartNo As Boolean = False
    Private isFilterByTrxDate As Boolean = False
    Private isFilterByUsername As Boolean = False
    Private pageCount As Integer
    Private pageIndex As Integer
    Private pageSize As Integer
    Private totalCount As Integer
    Private issuedQty As Integer
    Private consumedQty As Integer
    Private remainingQty As Integer

    Private userId As Integer = 0

    Public Sub New(_userId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        userId = _userId

        ' Add any initialization after the InitializeComponent() call.
        dbMain.EnableDoubleBuffered(dgvList)
    End Sub

    Public Sub Reload()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
        pageIndex = 0
        LoadLogs()
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

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        LoadLogs()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        LoadLogs()
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If

        LoadLogs()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If

        LoadLogs()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Exit Sub

            'Dim dt As DataTable = New DataTable()
            'Dim dtReport As DataTable = New DataTable()

            'Dim query As String = "SELECT TrxId, TrxDate, TransactionCode, UserName, PartNo, PartName, Qty, ReferenceNo, ParticularName, AreaName, MachinePartName, MachineStatusName, MachineSubStatusName, Problem, RootCause, ActionTaken, Remarks FROM dbo.VwMntTransactionPartLogs WHERE "

            'Select Case cmbSearchCriteria.SelectedValue
            '    Case 1
            '        query += " CAST(TrxDate AS DATE) BETWEEN '" & dtpStartDate.Value.Date & "' AND '" & dtpEndDate.Value.Date & "'"

            '    Case 2
            '        query += " UserId = '" & cmbCommon2.SelectedValue & "'"

            '    Case 3
            '        query += " PartId = '" & cmbCommon2.SelectedValue & "'"

            '    Case 4
            '        query += " PartId = '" & cmbCommon2.SelectedValue & "'"
            'End Select

            'Select Case GetTrxType()
            '    Case 1, 2
            '        query += " AND TransactionTypeId = '" & GetTrxType() & "'"
            'End Select

            'query += " ORDER BY " & cmbSortCriteria.SelectedValue & " " & GetSortMode() & " "

            'dt = dbMethod.FillDataTable(query, CommandType.Text)

            'If dt.Rows.Count = 0 Then
            '    MessageBox.Show("No records found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If

            'Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"
            'Dim imgDir As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Temp"
            'Dim expFilename As String = folderPath & Convert.ToString(CDate(dbMethod.GetServerDate).Date.ToString("yyyyMMdd") & " Spare Parts Logs.xlsx")

            'If dtReport.Rows.Count > 0 Then
            '    dtReport.Clear()
            'End If

            'BuildContainerTable(dtReport)

            'If Not System.IO.Directory.Exists(imgDir) Then
            '    System.IO.Directory.CreateDirectory(imgDir)
            'End If

            'For i As Integer = 0 To dt.Rows.Count - 1
            '    Dim newRow As DataRow = dtReport.NewRow
            '    newRow("TrxDate") = dt.Rows(i).Item("TrxDate")
            '    newRow("TransactionCode") = dt.Rows(i).Item("TransactionCode")
            '    newRow("UserName") = dt.Rows(i).Item("UserName")
            '    newRow("PartNo") = dt.Rows(i).Item("PartNo")
            '    newRow("PartName") = dt.Rows(i).Item("PartName")
            '    newRow("Qty") = dt.Rows(i).Item("Qty")
            '    newRow("ReferenceNo") = dt.Rows(i).Item("ReferenceNo")
            '    newRow("ParticularName") = dt.Rows(i).Item("ParticularName")
            '    newRow("AreaName") = dt.Rows(i).Item("AreaName")
            '    newRow("MachinePartName") = dt.Rows(i).Item("MachinePartName")
            '    newRow("MachineStatusName") = dt.Rows(i).Item("MachineStatusName")
            '    newRow("MachineSubStatusName") = dt.Rows(i).Item("MachineSubStatusName")
            '    newRow("Problem") = dt.Rows(i).Item("Problem")
            '    newRow("RootCause") = dt.Rows(i).Item("RootCause")
            '    newRow("ActionTaken") = dt.Rows(i).Item("ActionTaken")
            '    newRow("Remarks") = dt.Rows(i).Item("Remarks")

            '    'bite = dt.Rows(i).Item("Image")

            '    'Using ms As New MemoryStream(bite)
            '    '    Dim img As Image = Image.FromStream(ms)
            '    '    img.Save(IO.Path.Combine(imgDir, dt.Rows(i).Item("ImageName")))
            '    'End Using

            '    dtReport.Rows.Add(newRow)
            'Next

            'Using wb As New XLWorkbook()
            '    Dim ws = wb.Worksheets.Add(dtReport, "Spare Parts Logs")

            '    'adding header column
            '    For column As Integer = 0 To dtReport.Columns.Count - 1
            '        ws.Cell(1, column + 1).Value = dtReport.Columns(column).ColumnName
            '    Next

            '    'adding rows in cell
            '    For row As Integer = 0 To dtReport.Rows.Count - 1
            '        For column As Integer = 0 To dtReport.Columns.Count - 1 - 1
            '            ws.Cell(row + 2, column + 1).Value = dtReport.Rows(row)(column)
            '        Next
            '    Next

            '    ''adding image in cell
            '    'For row As Integer = 0 To dtReport.Rows.Count - 1
            '    '    For column As Integer = dtReport.Columns.Count - 1 To dtReport.Columns.Count - 1
            '    '        Dim image = ws.AddPicture(dtReport.Rows(row)(column).ToString()).MoveTo(ws.Cell(row + 2, column + 1))
            '    '        image.Width = 50
            '    '        Image.Height = 50
            '    '    Next
            '    'Next

            '    Dim directoryInfo As DirectoryInfo = New DirectoryInfo(imgDir)
            '    For Each file As FileInfo In directoryInfo.GetFiles()
            '        file.Delete()
            '    Next

            '    directoryInfo.Delete()

            '    wb.SaveAs(expFilename)
            'End Using

            'Process.Start(expFilename)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Reload()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            isFilterByTrxDate = False
            isFilterByUsername = False
            isFilterByPartNo = False
            isFilterByPartName = False

            cmbSearchCriteria.SelectedValue = 1

            txtCommon.Clear()
            cmbCommon.SelectedValue = 0
            cmbCommon2.SelectedValue = 0
            dtpStartDate.Value = CDate(dbMethod.GetServerDate).Date
            dtpEndDate.Value = CDate(dbMethod.GetServerDate).Date

            pageIndex = 0
            LoadLogs()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    If dtpStartDate.Value.Date > dtpEndDate.Value.Date Then
                        MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    isFilterByTrxDate = True
                    isFilterByUsername = False
                    isFilterByPartNo = False
                    isFilterByPartName = False

                Case 2
                    isFilterByTrxDate = False
                    isFilterByUsername = True
                    isFilterByPartNo = False
                    isFilterByPartName = False

                Case 3
                    isFilterByTrxDate = False
                    isFilterByUsername = False
                    isFilterByPartNo = True
                    isFilterByPartName = False

                Case 4
                    isFilterByTrxDate = False
                    isFilterByUsername = False
                    isFilterByPartNo = False
                    isFilterByPartName = True
            End Select

            pageIndex = 0
            LoadLogs()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try
            If Me.dgvList.Rows.Count > 0 Then
                Dim partTrxId As Integer = 0

                partTrxId = CType(Me.bsTransactionPartDetailFloat.Current, DataRowView).Item("PartTrxId")

                If CType(Me.bsTransactionPartDetailFloat.Current, DataRowView).Item("TransactionTypeId") = 1 Then
                    Using frmReceive As New MntTrxPartReceive(userId, partTrxId, True)
                        If frmReceive.ShowDialog() = DialogResult.OK Then
                            Reload()
                        End If
                    End Using
                Else
                    Using frmIssue As New MntTrxPartIssue(userId, partTrxId, True)
                        If frmIssue.ShowDialog() = DialogResult.OK Then
                            Reload()
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

                    pnlSearchByDate.Visible = True
                    pnlSearchByCmb.Visible = False
                    pnlSearchByCmb2.Visible = False
                    pnlSearchByText.Visible = False

                Case 2
                    LoadUser()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = False
                    pnlSearchByCmb2.Visible = True
                    pnlSearchByText.Visible = False

                Case 3
                    LoadPartNo()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = False
                    pnlSearchByCmb2.Visible = True
                    pnlSearchByText.Visible = False

                Case 4
                    LoadPartName()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = False
                    pnlSearchByCmb2.Visible = True
                    pnlSearchByText.Visible = False
            End Select

            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    ActiveControl = dtpStartDate
                Case 2, 3, 4
                    ActiveControl = cmbCommon2
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbSortCriteria_SelectedValueChanged(sender As Object, e As EventArgs)
        Reload()
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        btnView.PerformClick()
    End Sub

    Private Sub dgvList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvList.DataError
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

    Private Function GetTrxType() As Integer
        Dim trxTypeId As Integer = 0

        Try
            If rdReceive.Checked = True Then
                trxTypeId = 1
            ElseIf rdIssue.Checked = True Then
                trxTypeId = 2
            Else
                trxTypeId = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return trxTypeId
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
            LoadLogs()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadLogs()
        Try
            totalCount = 0
            issuedQty = 0
            consumedQty = 0
            remainingQty = 0

            If isFilterByTrxDate = True Then
                Dim prmPart(10) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@IssuedQty", SqlDbType.Int)
                prmPart(3).Direction = ParameterDirection.Output
                prmPart(3).Value = issuedQty
                prmPart(4) = New SqlParameter("@ConsumedQty", SqlDbType.Int)
                prmPart(4).Direction = ParameterDirection.Output
                prmPart(4).Value = consumedQty
                prmPart(5) = New SqlParameter("@RemainingQty", SqlDbType.Int)
                prmPart(5).Direction = ParameterDirection.Output
                prmPart(5).Value = remainingQty
                prmPart(6) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                prmPart(6).Value = IIf(GetTrxType() = 0, Nothing, GetTrxType)
                prmPart(7) = New SqlParameter("@SortingCol", SqlDbType.VarChar)
                prmPart(7).Value = cmbSortCriteria.SelectedValue
                prmPart(8) = New SqlParameter("@SortType", SqlDbType.VarChar)
                prmPart(8).Value = GetSortMode()
                prmPart(9) = New SqlParameter("@StartDate", SqlDbType.Date)
                prmPart(9).Value = CDate(dtpStartDate.Value)
                prmPart(10) = New SqlParameter("@EndDate", SqlDbType.Date)
                prmPart(10).Value = CDate(dtpEndDate.Value)

                dtSparePart = dbMethod.FillDataTable("RdMntTransactionPartFloatLogCreatedDate", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value
                issuedQty = prmPart(3).Value
                consumedQty = prmPart(4).Value
                remainingQty = prmPart(5).Value

            ElseIf isFilterByUsername = True Then
                Dim prmPart(9) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@IssuedQty", SqlDbType.Int)
                prmPart(3).Direction = ParameterDirection.Output
                prmPart(3).Value = issuedQty
                prmPart(4) = New SqlParameter("@ConsumedQty", SqlDbType.Int)
                prmPart(4).Direction = ParameterDirection.Output
                prmPart(4).Value = consumedQty
                prmPart(5) = New SqlParameter("@RemainingQty", SqlDbType.Int)
                prmPart(5).Direction = ParameterDirection.Output
                prmPart(5).Value = remainingQty
                prmPart(6) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                prmPart(6).Value = IIf(GetTrxType() = 0, Nothing, GetTrxType)
                prmPart(7) = New SqlParameter("@SortingCol", SqlDbType.VarChar)
                prmPart(7).Value = cmbSortCriteria.SelectedValue
                prmPart(8) = New SqlParameter("@SortType", SqlDbType.VarChar)
                prmPart(8).Value = GetSortMode()
                prmPart(9) = New SqlParameter("@UserId", SqlDbType.Int)
                prmPart(9).Value = cmbCommon2.SelectedValue

                dtSparePart = dbMethod.FillDataTable("RdMntTransactionPartFloatLogUserId", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value
                issuedQty = prmPart(3).Value
                consumedQty = prmPart(4).Value
                remainingQty = prmPart(5).Value

            ElseIf isFilterByPartNo = True Or isFilterByPartName = True Then
                Dim prmPart(9) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@IssuedQty", SqlDbType.Int)
                prmPart(3).Direction = ParameterDirection.Output
                prmPart(3).Value = issuedQty
                prmPart(4) = New SqlParameter("@ConsumedQty", SqlDbType.Int)
                prmPart(4).Direction = ParameterDirection.Output
                prmPart(4).Value = consumedQty
                prmPart(5) = New SqlParameter("@RemainingQty", SqlDbType.Int)
                prmPart(5).Direction = ParameterDirection.Output
                prmPart(5).Value = remainingQty
                prmPart(6) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                prmPart(6).Value = IIf(GetTrxType() = 0, Nothing, GetTrxType)
                prmPart(7) = New SqlParameter("@SortingCol", SqlDbType.VarChar)
                prmPart(7).Value = cmbSortCriteria.SelectedValue
                prmPart(8) = New SqlParameter("@SortType", SqlDbType.VarChar)
                prmPart(8).Value = GetSortMode()
                prmPart(9) = New SqlParameter("@PartId", SqlDbType.Int)
                prmPart(9).Value = cmbCommon2.SelectedValue

                dtSparePart = dbMethod.FillDataTable("RdMntTransactionPartFloatLogPartId", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value
                issuedQty = prmPart(3).Value
                consumedQty = prmPart(4).Value
                remainingQty = prmPart(5).Value

            Else
                Dim prmPart(8) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@IssuedQty", SqlDbType.Int)
                prmPart(3).Direction = ParameterDirection.Output
                prmPart(3).Value = issuedQty
                prmPart(4) = New SqlParameter("@ConsumedQty", SqlDbType.Int)
                prmPart(4).Direction = ParameterDirection.Output
                prmPart(4).Value = consumedQty
                prmPart(5) = New SqlParameter("@RemainingQty", SqlDbType.Int)
                prmPart(5).Direction = ParameterDirection.Output
                prmPart(5).Value = remainingQty
                prmPart(6) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                prmPart(6).Value = IIf(GetTrxType() = 0, Nothing, GetTrxType)
                prmPart(7) = New SqlParameter("@SortingCol", SqlDbType.VarChar)
                prmPart(7).Value = cmbSortCriteria.SelectedValue
                prmPart(8) = New SqlParameter("@SortType", SqlDbType.VarChar)
                prmPart(8).Value = GetSortMode()

                dtSparePart = dbMethod.FillDataTable("RdMntTransactionPartFloatLog", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value
                issuedQty = prmPart(3).Value
                consumedQty = prmPart(4).Value
                remainingQty = prmPart(5).Value
            End If

            If totalCount = 0 Then
                CountToolStripLabel.Text = totalCount & " item"
            ElseIf totalCount = 1 Then
                CountToolStripLabel.Text = totalCount & " item"
            Else
                CountToolStripLabel.Text = totalCount & " items"
            End If

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
            If pageIndex > pageCount Then
                pageIndex = 0
                txtPageNumber.Text = pageIndex + 1
            Else
                txtPageNumber.Text = pageIndex + 1
            End If

            bsTransactionPartDetailFloat.DataSource = dtSparePart
            bsTransactionPartDetailFloat.ResetBindings(True)
            dgvList.AutoGenerateColumns = False
            dgvList.DataSource = bsTransactionPartDetailFloat

            txtTotalPageNumber.Text = "of " & CInt(pageCount) & " Page(s)"

            txtTotalIssued.Text = issuedQty.ToString("N0")
            txtTotalConsumed.Text = consumedQty.ToString("N0")
            txtTotalRemaining.Text = remainingQty.ToString("N0")

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

    Private Sub LoadPartName()
        dbMethod.FillCmbWithCaption("SELECT PartId, TRIM(PartName) + ' ' + TRIM(PartNo) AS PartName FROM dbo.MntSparePart", CommandType.Text, "PartId", "PartName", cmbCommon2, "< All >")
    End Sub

    Private Sub LoadPartNo()
        dbMethod.FillCmbWithCaption("SELECT PartId, TRIM(PartNo) AS PartNo FROM dbo.MntSparePart", CommandType.Text, "PartId", "PartNo", cmbCommon2, "< All >")
    End Sub

    Private Sub LoadSearchCriteria()
        Try
            dicSearchCriteria.Add(" Transaction Date", 1)
            dicSearchCriteria.Add(" Username", 2)
            dicSearchCriteria.Add(" Part No", 3)
            dicSearchCriteria.Add(" Part Name", 4)

            cmbSearchCriteria.DisplayMember = "Key"
            cmbSearchCriteria.ValueMember = "Value"
            cmbSearchCriteria.DataSource = New BindingSource(dicSearchCriteria, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSortCriteria()
        Try
            dicSortCriteria.Add(" Transaction Date", "CreatedDate")
            dicSortCriteria.Add(" Transaction", "TransactionCode")
            dicSortCriteria.Add(" Username", "UserName")
            dicSortCriteria.Add(" Part Number", "PartNo")
            dicSortCriteria.Add(" Part Name", "PartName")

            cmbSortCriteria.DisplayMember = "Key"
            cmbSortCriteria.ValueMember = "Value"
            cmbSortCriteria.DataSource = New BindingSource(dicSortCriteria, Nothing)

            AddHandler cmbSortCriteria.SelectedValueChanged, AddressOf cmbSortCriteria_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUser()
        Dim prm(1) As SqlParameter
        prm(0) = New SqlParameter("@SectionId", SqlDbType.Int)
        prm(0).Value = 2
        prm(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
        prm(1).Value = 1

        dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbCommon2, "< All >", prm)
    End Sub

    Private Sub MntSpare_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvList.Dispose()
    End Sub

    Private Sub MntSpare_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F3) Then
            e.Handled = True
            btnView.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F5) Then
            e.Handled = True
            btnRefresh.PerformClick()
        End If
    End Sub

    Private Sub MntSparePartLogFloat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSearchCriteria()
        LoadSortCriteria()

        cmbSortCriteria.SelectedValue = "CreatedDate"
        rdDesc.Checked = True
        rdAll.Checked = True

        pageIndex = 0
        pageSize = 100
        LoadLogs()

        AddHandler rdAsc.CheckedChanged, AddressOf SortChanged
        AddHandler rdDesc.CheckedChanged, AddressOf SortChanged

        AddHandler rdAll.CheckedChanged, AddressOf TrxTypeChanged
        AddHandler rdReceive.CheckedChanged, AddressOf TrxTypeChanged
        AddHandler rdIssue.CheckedChanged, AddressOf TrxTypeChanged

        Me.dgvList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Me.ActiveControl = dgvList
    End Sub

    Private Sub SetScrollingIndex()
        dgvList.FirstDisplayedScrollingRowIndex = indexScroll
        If dgvList.Rows.Count > indexPosition Then
            dgvList.Rows(indexPosition).Selected = True
        Else
            dgvList.Rows(indexPosition - 1).Selected = True
        End If
        Me.bsTransactionPartDetailFloat.Position = dgvList.SelectedCells(0).RowIndex
    End Sub

    Private Sub SortChanged(sender As Object, e As EventArgs)
        Reload()
    End Sub

    Private Sub TrxTypeChanged(sender As Object, e As EventArgs)
        Reload()
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

    Private Sub dgvList_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvList.DataBindingComplete
        Try
            'https://www.daniweb.com/programming/software-development/threads/21784/datagrid-no-value-at-index-error-when-scroll-and-sort
            dgvList.CurrentCell = Nothing
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BuildContainerTable(table As DataTable, Optional _trxTypeId As Integer = 0)
        Try
            Dim column As DataColumn

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "TransactionCode"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.DateTime")
            column.ColumnName = "TrxDate"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "UserName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "PartNo"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "PartName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.Int32")
            column.ColumnName = "Qty"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "ReferenceNo"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "ParticularName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "AreaName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "MachinePartName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "MachineStatusName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "MachineSubStatusName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "Problem"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "RootCause"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "ActionTaken"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "Remarks"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class