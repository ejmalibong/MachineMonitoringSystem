Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class MntJigModel
    Private WithEvents bsModel As New BindingSource
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)

    Private dictSearchCriteria As New Dictionary(Of String, Integer)
    Private dtUser As New DataTable
    Private indexPosition As Integer = 0
    Private indexScroll As Integer = 0

    Private isFilterByModelName As Boolean = False
    Private isFilterByExtensionId As Boolean = False
    Private pageCount As Integer
    Private pageIndex As Integer
    Private pageSize As Integer

    Private totalCount As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub Reload()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Invoke(New Action(AddressOf GetScrollingIndex))
        pageIndex = 0
        LoadData()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Invoke(New Action(AddressOf SetScrollingIndex))
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
            Using frm As New MntJigModelDetail()
                frm.ShowDialog(Me)
                If frm.DialogResult = DialogResult.OK Then
                    Reload()
                    bsModel.Position = bsModel.Find("ModelId", frm.pKey)
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
                Dim modelId As Integer = CType(Me.bsModel.Current, DataRowView).Item("ModelId")

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

                        dbMethod.ExecuteNonQuery("DELETE FROM dbo.MntJigModel WHERE ModelId = @ModelId", CommandType.Text, prmDel)
                    Else
                        Exit Sub
                    End If
                End If

                Reload()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If dgvList.Rows.Count > 0 Then
                Dim modelId As Integer = CType(Me.bsModel.Current, DataRowView).Item("ModelId")
                Dim frm As New MntJigModelDetail(modelId)

                frm.txtModelName.Text = CType(Me.bsModel.Current, DataRowView).Item("ModelName")

                If CType(Me.bsModel.Current, DataRowView).Item("ExtensionId") Is DBNull.Value Then
                    frm.cmbExtension.SelectedValue = 0
                Else
                    frm.cmbExtension.SelectedValue = CType(Me.bsModel.Current, DataRowView).Item("ExtensionId")
                End If

                If CType(Me.bsModel.Current, DataRowView).Item("IsActive") = True Then
                    frm.rdActive.Checked = True
                Else
                    frm.rdInactive.Checked = True
                End If

                If frm.ShowDialog() = DialogResult.OK Then
                    Reload()
                    If frm.pKey <> 0 Then
                        bsModel.Position = bsModel.Find("ModelId", frm.pKey)
                    End If
                End If
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
        LoadData()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            isFilterByModelName = False
            isFilterByExtensionId = False

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
                    isFilterByModelName = True
                    isFilterByExtensionId = False
                Case 2
                    isFilterByModelName = False
                    isFilterByExtensionId = True
            End Select

            pageIndex = 0
            LoadData()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCommon_Validated(sender As Object, e As EventArgs) Handles cmbCommon.Validated
        If cmbCommon.SelectedValue = 0 Then
            cmbCommon.SelectedValue = 0
        End If

        If cmbCommon.SelectedValue Is Nothing Then
            cmbCommon.SelectedValue = 0
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
                    FillSearchByExtensionName()

                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False
            End Select

            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    ActiveControl = txtCommon
                    txtCommon.Text = String.Empty
                Case 2
                    ActiveControl = cmbCommon
                    cmbCommon.SelectedValue = 0
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    Private Sub dgvList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvList.DataError
        e.Cancel = False
    End Sub

    Private Sub FillSearchByExtensionName()
        dbMethod.FillCmbWithCaption("RdMntModelExtension", CommandType.StoredProcedure, "ExtensionId", "ExtensionName", cmbCommon, "< All >")
    End Sub

    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                e.Handled = True
                btnAdd.PerformClick()
            Case Keys.F3
                e.Handled = True
                btnEdit.PerformClick()
            Case Keys.F5
                e.Handled = True
                btnRefresh.PerformClick()
            Case Keys.F8
                e.Handled = True
                btnDelete.PerformClick()
        End Select
    End Sub

    Private Sub frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSearchCriteria()

        pageIndex = 0
        pageSize = 100
        LoadData()

        dbMain.EnableDoubleBuffered(dgvList)
        ActiveControl = dgvList

        Me.dgvList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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

            If isFilterByModelName = True Then
                Dim prmMasterlist(3) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@ModelName", SqlDbType.NVarChar)
                prmMasterlist(3).Value = txtCommon.Text.Trim

                dtUser = dbMethod.FillDataTable("RdMntJigModelMasterlistByModelName", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value

            ElseIf isFilterByExtensionId = True Then
                Dim prmMasterlist(3) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@ExtensionId", SqlDbType.Int)
                prmMasterlist(3).Value = cmbCommon.SelectedValue

                dtUser = dbMethod.FillDataTable("RdMntJigModelMasterlistByExtensionId", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value

            Else
                Dim prmMasterlist(2) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount

                dtUser = dbMethod.FillDataTable("RdMntJigModelMasterlist", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value
            End If

            Me.Text = String.Empty
            If CInt(totalCount) = 0 Or CInt(totalCount) = 1 Then
                Me.Text = "Model Masterlist - " & totalCount & " item"
            Else
                Me.Text = "Model Masterlist - " & totalCount & " items"
            End If

            bsModel.DataSource = dtUser
            bsModel.ResetBindings(True)
            dgvList.AutoGenerateColumns = False
            dgvList.DataSource = bsModel

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
            dictSearchCriteria.Add(" Model Name", 1)
            dictSearchCriteria.Add(" Extension Name", 2)

            cmbSearchCriteria.DisplayMember = "Key"
            cmbSearchCriteria.ValueMember = "Value"
            cmbSearchCriteria.DataSource = New BindingSource(dictSearchCriteria, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmMntJigModel_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvList.Dispose()
    End Sub

    Private Sub SetScrollingIndex()
        dgvList.FirstDisplayedScrollingRowIndex = indexScroll
        If dgvList.Rows.Count > indexPosition Then
            dgvList.Rows(indexPosition).Selected = True
        Else
            dgvList.Rows(indexPosition - 1).Selected = True
        End If
        bsModel.Position = dgvList.SelectedCells(0).RowIndex
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