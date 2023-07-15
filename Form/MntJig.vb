Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class MntJig
    Public WithEvents bsJig As New BindingSource
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dicSearchCriteria As New Dictionary(Of String, Integer)
    Private dicRemarks As New Dictionary(Of String, Object)
    Private dtJig As New DataTable
    Private indexPosition As Integer = 0
    Private indexScroll As Integer = 0
    Private isFilterByJigName As Boolean = False
    Private isFilterByArea As Boolean = False
    Private isFilterByModel As Boolean = False
    Private isFilterByExtension As Boolean = False
    Private isFilterByJigStatus As Boolean = False
    Private isFilterByJigSubStatus As Boolean = False
    Private isFilterByFrequency As Boolean = False
    Private isFilterByJigType As Boolean = False
    Private isFilterByRemarks As Boolean = False
    Private pageCount As Integer
    Private pageIndex As Integer
    Private pageSize As Integer
    Private totalCount As Integer
    Private userId As Integer = 0

    Public Sub New(_userId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
    End Sub

    Public Sub Reload()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
        pageIndex = 0
        LoadData()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        LoadData()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        LoadData()
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If

        LoadData()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If

        LoadData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Using frm As New MntJigDetail()
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Reload()
                    bsJig.Position = bsJig.Find("JigId", frm.pKey)
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
            If Me.dgvList.Rows.Count > 0 Then
                Dim jigId As Integer = CType(Me.bsJig.Current, DataRowView).Item("JigId")

                Dim prmCnt(0) As SqlParameter
                prmCnt(0) = New SqlParameter("@JigId", SqlDbType.Int)
                prmCnt(0).Value = jigId

                Dim count As Integer = dbMethod.ExecuteScalar("CntMntJigByTrx", CommandType.StoredProcedure, prmCnt)

                If count > 0 Then
                    MessageBox.Show("This jig contains activities. Set to inactive instead.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim question = String.Format("Are you sure you want to delete this jig?")
                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Dim prmDel(0) As SqlParameter
                    prmDel(0) = New SqlParameter("@JigId", SqlDbType.Int)
                    prmDel(0).Value = jigId

                    dbMethod.ExecuteNonQuery("DelMntJig", CommandType.StoredProcedure, prmDel)

                    Me.DialogResult = DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If Me.dgvList.Rows.Count > 0 Then
                Dim jigId As Integer = CType(Me.bsJig.Current, DataRowView).Item("JigId")

                Using frm As New MntJigDetail(jigId)
                    If frm.ShowDialog(Me) = DialogResult.OK Then
                        Reload()
                        bsJig.Position = bsJig.Find("JigId", frm.pKey)
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Invoke(New Action(AddressOf GetScrollingIndex))
        pageIndex = 0
        LoadData()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            isFilterByJigName = False
            isFilterByArea = False
            isFilterByModel = False
            isFilterByExtension = False
            isFilterByJigStatus = False
            isFilterByJigSubStatus = False
            isFilterByFrequency = False
            isFilterByJigType = False

            cmbSearchCriteria.SelectedValue = 1

            pageIndex = 0
            LoadData()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    isFilterByJigName = True
                    isFilterByArea = False
                    isFilterByModel = False
                    isFilterByExtension = False
                    isFilterByJigStatus = False
                    isFilterByJigSubStatus = False
                    isFilterByFrequency = False
                    isFilterByJigType = False
                    isFilterByRemarks = False

                Case 2
                    isFilterByJigName = False
                    isFilterByArea = True
                    isFilterByModel = False
                    isFilterByExtension = False
                    isFilterByJigStatus = False
                    isFilterByJigSubStatus = False
                    isFilterByFrequency = False
                    isFilterByJigType = False
                    isFilterByRemarks = False

                Case 3
                    isFilterByJigName = False
                    isFilterByArea = False
                    isFilterByModel = True
                    isFilterByExtension = False
                    isFilterByJigStatus = False
                    isFilterByJigSubStatus = False
                    isFilterByFrequency = False
                    isFilterByJigType = False
                    isFilterByRemarks = False

                Case 4
                    isFilterByJigName = False
                    isFilterByArea = False
                    isFilterByModel = False
                    isFilterByExtension = True
                    isFilterByJigStatus = False
                    isFilterByJigSubStatus = False
                    isFilterByFrequency = False
                    isFilterByJigType = False
                    isFilterByRemarks = False

                Case 5
                    isFilterByJigName = False
                    isFilterByArea = False
                    isFilterByModel = False
                    isFilterByExtension = False
                    isFilterByJigStatus = True
                    isFilterByJigSubStatus = False
                    isFilterByFrequency = False
                    isFilterByJigType = False
                    isFilterByRemarks = False

                Case 6
                    isFilterByJigName = False
                    isFilterByArea = False
                    isFilterByModel = False
                    isFilterByExtension = False
                    isFilterByJigStatus = False
                    isFilterByJigSubStatus = True
                    isFilterByFrequency = False
                    isFilterByJigType = False
                    isFilterByRemarks = False

                Case 7
                    isFilterByJigName = False
                    isFilterByArea = False
                    isFilterByModel = False
                    isFilterByExtension = False
                    isFilterByJigStatus = False
                    isFilterByJigSubStatus = False
                    isFilterByFrequency = True
                    isFilterByJigType = False
                    isFilterByRemarks = False

                Case 8
                    isFilterByJigName = False
                    isFilterByArea = False
                    isFilterByModel = False
                    isFilterByExtension = False
                    isFilterByJigStatus = False
                    isFilterByJigSubStatus = False
                    isFilterByFrequency = False
                    isFilterByJigType = True
                    isFilterByRemarks = False

                Case 9
                    isFilterByJigName = False
                    isFilterByArea = False
                    isFilterByModel = False
                    isFilterByExtension = False
                    isFilterByJigStatus = False
                    isFilterByJigSubStatus = False
                    isFilterByFrequency = False
                    isFilterByJigType = False
                    isFilterByRemarks = True
            End Select

            pageIndex = 0
            LoadData()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCommon_Validated(sender As Object, e As EventArgs) Handles cmbCommon.Validated
        If cmbSearchCriteria.SelectedValue = 7 Then
            If cmbCommon.SelectedValue = CStr(0) Then
                cmbCommon.SelectedValue = CStr(0)
            End If
        Else
            If cmbCommon.SelectedValue = 0 Then
                cmbCommon.SelectedValue = 0
            End If

            If cmbCommon.SelectedValue Is Nothing Then
                cmbCommon.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub cmbSearchCriteria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSearchCriteria.SelectedValueChanged
        Try
            cmbCommon.SelectedValue = 0
            cmbCommon.DataSource = Nothing
            cmbCommon.Items.Clear()

            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    txtCommon.Text = String.Empty

                    pnlSearchByCmb.Visible = False
                    pnlSearchByText.Visible = True

                Case 2
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadArea()

                Case 3
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadModel()

                Case 4
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadExtension()

                Case 5
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadJigStatus()

                Case 6
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadJigSubsStatusId()

                Case 7
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadFrequency()

                Case 8
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadJigType()

                Case 9
                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False

                    LoadRemarks()
            End Select

            Select Case cmbSearchCriteria.SelectedValue
                Case 2, 3, 4, 5, 6
                    ActiveControl = cmbCommon
                    cmbCommon.SelectedValue = 0
                Case 9
                    ActiveControl = cmbCommon
                    cmbCommon.SelectedIndex = 0
                Case 1
                    ActiveControl = txtCommon
                    txtCommon.Clear()
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            LoadData()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadData()
        Try
            totalCount = 0

            If isFilterByJigName = True Then
                Dim prmJigMasterlist(3) As SqlParameter
                prmJigMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmJigMasterlist(0).Value = pageIndex
                prmJigMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmJigMasterlist(1).Value = pageSize
                prmJigMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmJigMasterlist(2).Direction = ParameterDirection.Output
                prmJigMasterlist(2).Value = totalCount
                prmJigMasterlist(3) = New SqlParameter("@JigName", SqlDbType.NVarChar)
                prmJigMasterlist(3).Value = txtCommon.Text.Trim

                dtJig = dbMethod.FillDataTable("RdMntJigMasterlistByJigName", CommandType.StoredProcedure, prmJigMasterlist)
                totalCount = prmJigMasterlist(2).Value

            ElseIf isFilterByArea = True Then
                Dim prmJigMasterlist(3) As SqlParameter
                prmJigMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmJigMasterlist(0).Value = pageIndex
                prmJigMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmJigMasterlist(1).Value = pageSize
                prmJigMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmJigMasterlist(2).Direction = ParameterDirection.Output
                prmJigMasterlist(2).Value = totalCount
                prmJigMasterlist(3) = New SqlParameter("@AreaId", SqlDbType.Int)
                prmJigMasterlist(3).Value = IIf(cmbCommon.SelectedValue = CStr(0), Nothing, cmbCommon.SelectedValue)

                dtJig = dbMethod.FillDataTable("RdMntJigMasterlistByAreaId", CommandType.StoredProcedure, prmJigMasterlist)
                totalCount = prmJigMasterlist(2).Value

            ElseIf isFilterByModel = True Then
                Dim prmJigMasterlist(3) As SqlParameter
                prmJigMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmJigMasterlist(0).Value = pageIndex
                prmJigMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmJigMasterlist(1).Value = pageSize
                prmJigMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmJigMasterlist(2).Direction = ParameterDirection.Output
                prmJigMasterlist(2).Value = totalCount
                prmJigMasterlist(3) = New SqlParameter("@ModelId", SqlDbType.Int)
                prmJigMasterlist(3).Value = IIf(cmbCommon.SelectedValue = CStr(0), Nothing, cmbCommon.SelectedValue)

                dtJig = dbMethod.FillDataTable("RdMntJigMasterlistByModelId", CommandType.StoredProcedure, prmJigMasterlist)
                totalCount = prmJigMasterlist(2).Value

            ElseIf isFilterByExtension = True Then
                Dim prmJigMasterlist(3) As SqlParameter
                prmJigMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmJigMasterlist(0).Value = pageIndex
                prmJigMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmJigMasterlist(1).Value = pageSize
                prmJigMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmJigMasterlist(2).Direction = ParameterDirection.Output
                prmJigMasterlist(2).Value = totalCount
                prmJigMasterlist(3) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                prmJigMasterlist(3).Value = IIf(cmbCommon.SelectedValue = CStr(0), Nothing, cmbCommon.SelectedValue)

                dtJig = dbMethod.FillDataTable("RdMntJigMasterlistByExtensionId", CommandType.StoredProcedure, prmJigMasterlist)
                totalCount = prmJigMasterlist(2).Value

            ElseIf isFilterByJigStatus = True Then
                Dim prmJigMasterlist(3) As SqlParameter
                prmJigMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmJigMasterlist(0).Value = pageIndex
                prmJigMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmJigMasterlist(1).Value = pageSize
                prmJigMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmJigMasterlist(2).Direction = ParameterDirection.Output
                prmJigMasterlist(2).Value = totalCount
                prmJigMasterlist(3) = New SqlParameter("@JigStatusId", SqlDbType.Int)
                prmJigMasterlist(3).Value = IIf(cmbCommon.SelectedValue = CStr(0), Nothing, cmbCommon.SelectedValue)

                dtJig = dbMethod.FillDataTable("RdMntJigMasterlistByJigStatusId", CommandType.StoredProcedure, prmJigMasterlist)
                totalCount = prmJigMasterlist(2).Value

            ElseIf isFilterByJigSubStatus = True Then
                Dim prmJigMasterlist(3) As SqlParameter
                prmJigMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmJigMasterlist(0).Value = pageIndex
                prmJigMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmJigMasterlist(1).Value = pageSize
                prmJigMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmJigMasterlist(2).Direction = ParameterDirection.Output
                prmJigMasterlist(2).Value = totalCount
                prmJigMasterlist(3) = New SqlParameter("@JigSubStatusId", SqlDbType.Int)
                prmJigMasterlist(3).Value = IIf(cmbCommon.SelectedValue = CStr(0), Nothing, cmbCommon.SelectedValue)

                dtJig = dbMethod.FillDataTable("RdMntJigMasterlistByJigSubStatusId", CommandType.StoredProcedure, prmJigMasterlist)
                totalCount = prmJigMasterlist(2).Value

            ElseIf isFilterByFrequency = True Then
                Dim prmJigMasterlist(3) As SqlParameter
                prmJigMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmJigMasterlist(0).Value = pageIndex
                prmJigMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmJigMasterlist(1).Value = pageSize
                prmJigMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmJigMasterlist(2).Direction = ParameterDirection.Output
                prmJigMasterlist(2).Value = totalCount
                prmJigMasterlist(3) = New SqlParameter("@PmFrequencyId", SqlDbType.Char)
                prmJigMasterlist(3).Value = IIf(cmbCommon.SelectedValue = CStr(0), Nothing, cmbCommon.SelectedValue)

                dtJig = dbMethod.FillDataTable("RdMntJigMasterlistByPmFrequencyId", CommandType.StoredProcedure, prmJigMasterlist)
                totalCount = prmJigMasterlist(2).Value

            ElseIf isFilterByJigType = True Then
                Dim prmJigMasterlist(3) As SqlParameter
                prmJigMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmJigMasterlist(0).Value = pageIndex
                prmJigMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmJigMasterlist(1).Value = pageSize
                prmJigMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmJigMasterlist(2).Direction = ParameterDirection.Output
                prmJigMasterlist(2).Value = totalCount
                prmJigMasterlist(3) = New SqlParameter("@JigTypeId", SqlDbType.Int)
                prmJigMasterlist(3).Value = IIf(cmbCommon.SelectedValue = CStr(0), Nothing, cmbCommon.SelectedValue)

                dtJig = dbMethod.FillDataTable("RdMntJigMasterlistByJigTypeId", CommandType.StoredProcedure, prmJigMasterlist)
                totalCount = prmJigMasterlist(2).Value

            ElseIf isFilterByRemarks = True Then
                Dim prmJigMasterlist(3) As SqlParameter
                prmJigMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmJigMasterlist(0).Value = pageIndex
                prmJigMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmJigMasterlist(1).Value = pageSize
                prmJigMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmJigMasterlist(2).Direction = ParameterDirection.Output
                prmJigMasterlist(2).Value = totalCount
                prmJigMasterlist(3) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prmJigMasterlist(3).Value = IIf(cmbCommon.SelectedValue Is Nothing, Nothing, IIf(cmbCommon.SelectedValue = 1, 1, 0))

                dtJig = dbMethod.FillDataTable("RdMntJigMasterlistByIsActive", CommandType.StoredProcedure, prmJigMasterlist)
                totalCount = prmJigMasterlist(2).Value
            Else
                Dim prmJigMasterlist(2) As SqlParameter
                prmJigMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmJigMasterlist(0).Value = pageIndex
                prmJigMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmJigMasterlist(1).Value = pageSize
                prmJigMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmJigMasterlist(2).Direction = ParameterDirection.Output
                prmJigMasterlist(2).Value = totalCount

                dtJig = dbMethod.FillDataTable("RdMntJigMasterlist", CommandType.StoredProcedure, prmJigMasterlist)
                totalCount = prmJigMasterlist(2).Value
            End If

            Me.Text = String.Empty
            If CInt(totalCount) = 0 Or CInt(totalCount) = 1 Then
                Me.Text = "Jig Masterlist - " & totalCount & " item"
            Else
                Me.Text = "Jig Masterlist - " & totalCount & " items"
            End If

            bsJig.DataSource = dtJig
            bsJig.ResetBindings(True)
            dgvList.AutoGenerateColumns = False
            dgvList.DataSource = bsJig

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

    Private Sub LoadArea()
        cmbCommon.DisplayMember = "AreaName"
        cmbCommon.ValueMember = "AreaId"

        dbMethod.FillCmbWithCaption("RdMntArea", CommandType.StoredProcedure, "AreaId", "AreaName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadModel()
        cmbCommon.DisplayMember = "ModelName"
        cmbCommon.ValueMember = "ModelId"

        dbMethod.FillCmbWithCaption("RdMntJigModel", CommandType.StoredProcedure, "ModelId", "ModelName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadExtension()
        cmbCommon.DisplayMember = "ExtensionName"
        cmbCommon.ValueMember = "ExtensionId"

        dbMethod.FillCmbWithCaption("RdMntModelExtension", CommandType.StoredProcedure, "ExtensionId", "ExtensionName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadJigStatus()
        cmbCommon.DisplayMember = "JigStatusName"
        cmbCommon.ValueMember = "JigStatusId"

        dbMethod.FillCmbWithCaption("RdMntJigStatus", CommandType.StoredProcedure, "JigStatusId", "JigStatusName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadJigSubsStatusId()
        cmbCommon.DisplayMember = "JigSubStatusName"
        cmbCommon.ValueMember = "JigSubStatusId"

        dbMethod.FillCmbWithCaption("RdMntJigSubStatus", CommandType.StoredProcedure, "JigSubStatusId", "JigSubStatusName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadFrequency()
        cmbCommon.DisplayMember = "FrequencyName"
        cmbCommon.ValueMember = "FrequencyId"

        dbMethod.FillCmbWithCaption("RdGenFrequency", CommandType.StoredProcedure, "FrequencyId", "FrequencyName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadJigType()
        cmbCommon.DisplayMember = "JigTypeName"
        cmbCommon.ValueMember = "JigId"

        dbMethod.FillCmbWithCaption("RdMntJigType", CommandType.StoredProcedure, "JigTypeId", "JigTypeName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadRemarks()
        Try
            dicRemarks.Clear()

            dicRemarks.Add("< All >", Nothing)
            dicRemarks.Add(" Active", 1)
            dicRemarks.Add(" Inactive", 2)
            cmbCommon.DisplayMember = "Key"
            cmbCommon.ValueMember = "Value"
            cmbCommon.DataSource = New BindingSource(dicRemarks, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSearchCriteria()
        Try
            dicSearchCriteria.Add(" Jig Name", 1)
            dicSearchCriteria.Add(" Area", 2)
            dicSearchCriteria.Add(" Model", 3)
            dicSearchCriteria.Add(" Extension", 4)
            dicSearchCriteria.Add(" Status", 5)
            dicSearchCriteria.Add(" Sub-Status", 6)
            dicSearchCriteria.Add(" PM Frequency", 7)
            dicSearchCriteria.Add(" Jig Type", 8)
            dicSearchCriteria.Add(" Remarks", 9)

            cmbSearchCriteria.DisplayMember = "Key"
            cmbSearchCriteria.ValueMember = "Value"
            cmbSearchCriteria.DataSource = New BindingSource(dicSearchCriteria, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MntMch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvList.Dispose()
    End Sub

    Private Sub MntMch_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub MntMch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSearchCriteria()

        pageIndex = 0
        pageSize = 100
        LoadData()

        dbMain.EnableDoubleBuffered(dgvList)
        Me.ActiveControl = dgvList

        Me.dgvList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub SetScrollingIndex()
        dgvList.FirstDisplayedScrollingRowIndex = indexScroll
        If dgvList.Rows.Count > indexPosition Then
            dgvList.Rows(indexPosition).Selected = True
        Else
            dgvList.Rows(indexPosition - 1).Selected = True
        End If
        Me.bsJig.Position = dgvList.SelectedCells(0).RowIndex
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