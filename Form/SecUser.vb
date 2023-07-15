Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class SecUser
    Private WithEvents bsUser As New BindingSource
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private departmentId As Integer = 0
    Private dictSearchCriteria As New Dictionary(Of String, Integer)
    Private dtUser As New DataTable
    Private indexPosition As Integer = 0
    Private indexScroll As Integer = 0
    Private isAdmin As Boolean = False
    Private isFilterBySection As Boolean = False
    Private isFilterByUserName As Boolean = False
    Private isFilterByWorkgroup As Boolean = False
    Private pageCount As Integer
    Private pageIndex As Integer
    Private pageSize As Integer
    Private sectionId As Integer = 0
    Private totalCount As Integer
    Private workgroupId As Integer = 0

    Public Sub New(_departmentId As Integer, _sectionId As Integer, _workgroupId As Integer, _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        departmentId = _departmentId
        sectionId = _sectionId
        workgroupId = _workgroupId
        isAdmin = _isAdmin
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
            Using frm As New SecUserDetail(0, departmentId, sectionId, workgroupId, isAdmin)
                If frm.ShowDialog() = DialogResult.OK Then
                    Reload()
                    bsUser.Position = bsUser.Find("UserId", frm.pKey)
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
                Dim userId As Integer = CType(Me.bsUser.Current, DataRowView).Item("UserId")

                Dim prmCnt(0) As SqlParameter
                prmCnt(0) = New SqlParameter("@UserId", SqlDbType.Int)
                prmCnt(0).Value = userId

                Dim count As Integer = dbMethod.ExecuteScalar("CntSecUserByTrx", CommandType.StoredProcedure, prmCnt)

                If count > 0 Then
                    Dim question = String.Format("This user contains activities. Mark as inactive instead?")
                    If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim prmInactive(0) As SqlParameter
                        prmInactive(0) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmInactive(0).Value = userId

                        dbMethod.ExecuteNonQuery("UPDATE dbo.SecUser SET IsActive = 0 WHERE UserId = @UserId", CommandType.Text, prmInactive)
                    End If
                Else
                    Dim question = String.Format("Are you sure you want to delete this user?")
                    If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim prmDelete(0) As SqlParameter
                        prmDelete(0) = New SqlParameter("@UserId", SqlDbType.Int)
                        prmDelete(0).Value = userId

                        dbMethod.ExecuteNonQuery("DELETE FROM dbo.SecUser WHERE UserId = @UserId", CommandType.StoredProcedure, prmDelete)
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
                Dim userId As Integer = CType(Me.bsUser.Current, DataRowView).Item("UserId")
                Dim frm As New SecUserDetail(userId, departmentId, sectionId, workgroupId, isAdmin)

                frm.txtEmployeeId.Text = CType(Me.bsUser.Current, DataRowView).Item("EmployeeId")
                frm.txtUserName.Text = CType(Me.bsUser.Current, DataRowView).Item("UserName")
                frm.txtPassword.Text = CType(Me.bsUser.Current, DataRowView).Item("Password")
                frm.txtNickname.Text = CType(Me.bsUser.Current, DataRowView).Item("Nickname")
                frm.txtUserItem.Text = CType(Me.bsUser.Current, DataRowView).Item("UserItem")
                frm.cmbSection.SelectedValue = CType(Me.bsUser.Current, DataRowView).Item("SectionId")
                frm.cmbWorkgroup.SelectedValue = CType(Me.bsUser.Current, DataRowView).Item("WorkgroupId")

                If CType(Me.bsUser.Current, DataRowView).Item("IsAdmin") = True Then
                    frm.rdAdminYes.Checked = True
                Else
                    frm.rdAdminNo.Checked = True
                End If

                If CType(Me.bsUser.Current, DataRowView).Item("IsActive") = True Then
                    frm.rdActive.Checked = True
                Else
                    frm.rdInactive.Checked = True
                End If

                If frm.ShowDialog() = DialogResult.OK Then
                    Reload()

                    If frm.pKey <> 0 Then
                        bsUser.Position = bsUser.Find("UserId", frm.pKey)
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
            isFilterByUserName = False
            isFilterBySection = False
            isFilterByWorkgroup = False

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
                    isFilterByUserName = True
                    isFilterBySection = False
                    isFilterByWorkgroup = False
                Case 2
                    isFilterByUserName = False
                    isFilterByWorkgroup = True
                    isFilterBySection = False
                Case 3
                    isFilterByUserName = False
                    isFilterByWorkgroup = False
                    isFilterBySection = True
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
                    FillSearchByWorkgroup()

                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False
                Case 3
                    FillSearchBySection()

                    pnlSearchByCmb.Visible = True
                    pnlSearchByText.Visible = False
            End Select

            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    ActiveControl = txtCommon
                    txtCommon.Text = String.Empty
                Case 2, 3
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

    Private Sub FillSearchBySection()
        If isAdmin = 0 AndAlso Not (sectionId = 1 Or sectionId = 4) Then
            Dim prmSection(0) As SqlParameter
            prmSection(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmSection(0).Value = sectionId

            dbMethod.FillCmbWithCaption("RdSecSection", CommandType.StoredProcedure, "SectionId", "SectionName", cmbCommon, "< All > ", prmSection)
        Else
            dbMethod.FillCmbWithCaption("RdSecSection", CommandType.StoredProcedure, "SectionId", "SectionName", cmbCommon, "< All > ")
        End If
    End Sub

    Private Sub FillSearchByWorkgroup()
        If isAdmin = 0 AndAlso Not (sectionId = 1 Or sectionId = 4) Then
            Dim prmWorkgroup(0) As SqlParameter
            prmWorkgroup(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmWorkgroup(0).Value = sectionId

            dbMethod.FillCmbWithCaption("RdSecWorkgroup", CommandType.StoredProcedure, "WorkgroupId", "WorkgroupName", cmbCommon, "< All > ", prmWorkgroup)
        Else
            dbMethod.FillCmbWithCaption("RdSecWorkgroup", CommandType.StoredProcedure, "WorkgroupId", "WorkgroupCompleteName", cmbCommon, "< All >")
        End If
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

        Me.dgvList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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

            If isFilterByUserName = True Then
                Dim prmMasterlist(5) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@IsAdmin", SqlDbType.Bit)
                prmMasterlist(3).Value = isAdmin
                prmMasterlist(4) = New SqlParameter("@SectionId", SqlDbType.Int)
                prmMasterlist(4).Value = sectionId
                prmMasterlist(5) = New SqlParameter("@UserName", SqlDbType.VarChar)
                prmMasterlist(5).Value = txtCommon.Text.Trim

                dtUser = dbMethod.FillDataTable("RdSecUserMasterlistByUserName", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value

            ElseIf isFilterByWorkgroup = True Then
                Dim prmMasterlist(5) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@IsAdmin", SqlDbType.Bit)
                prmMasterlist(3).Value = isAdmin
                prmMasterlist(4) = New SqlParameter("@SectionId", SqlDbType.Int)
                prmMasterlist(4).Value = sectionId
                prmMasterlist(5) = New SqlParameter("@WorkgroupId", SqlDbType.Int)
                prmMasterlist(5).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                dtUser = dbMethod.FillDataTable("RdSecUserMasterlistByWorkgroupId", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value

            ElseIf isFilterBySection = True Then
                Dim prmMasterlist(4) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@IsAdmin", SqlDbType.Bit)
                prmMasterlist(3).Value = isAdmin
                prmMasterlist(4) = New SqlParameter("@SectionId", SqlDbType.Int)

                If isAdmin = 0 AndAlso Not (sectionId = 1 Or sectionId = 4) Then
                    prmMasterlist(4).Value = sectionId
                Else
                    prmMasterlist(4).Value = IIf(cmbCommon.SelectedValue = 0, sectionId, cmbCommon.SelectedValue)
                End If

                dtUser = dbMethod.FillDataTable("RdSecUserMasterlistBySectionId", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value
            Else
                Dim prmMasterlist(4) As SqlParameter
                prmMasterlist(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmMasterlist(0).Value = pageIndex
                prmMasterlist(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmMasterlist(1).Value = pageSize
                prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmMasterlist(2).Direction = ParameterDirection.Output
                prmMasterlist(2).Value = totalCount
                prmMasterlist(3) = New SqlParameter("@IsAdmin", SqlDbType.Bit)
                prmMasterlist(3).Value = isAdmin
                prmMasterlist(4) = New SqlParameter("@SectionId", SqlDbType.Int)
                prmMasterlist(4).Value = sectionId

                dtUser = dbMethod.FillDataTable("RdSecUserMasterlist", CommandType.StoredProcedure, prmMasterlist)
                totalCount = prmMasterlist(2).Value
            End If

            Me.Text = String.Empty
            If CInt(totalCount) = 0 Or CInt(totalCount) = 1 Then
                Me.Text = "User Masterlist - " & totalCount & " item"
            Else
                Me.Text = "User Masterlist - " & totalCount & " items"
            End If

            bsUser.DataSource = dtUser
            bsUser.ResetBindings(True)
            dgvList.AutoGenerateColumns = False
            dgvList.DataSource = bsUser

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
            dictSearchCriteria.Add(" User Name", 1)
            dictSearchCriteria.Add(" Workgroup", 2)

            If isAdmin Or (sectionId = 1 Or sectionId = 4) Then
                dictSearchCriteria.Add(" Section", 3)
            End If

            cmbSearchCriteria.DisplayMember = "Key"
            cmbSearchCriteria.ValueMember = "Value"
            cmbSearchCriteria.DataSource = New BindingSource(dictSearchCriteria, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvList.Dispose()
    End Sub

    Private Sub SetScrollingIndex()
        dgvList.FirstDisplayedScrollingRowIndex = indexScroll
        If dgvList.Rows.Count > indexPosition Then
            dgvList.Rows(indexPosition).Selected = True
        Else
            dgvList.Rows(indexPosition - 1).Selected = True
        End If
        bsUser.Position = dgvList.SelectedCells(0).RowIndex
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