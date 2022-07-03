Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class SecUser
    Private connection As New Connection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbMain As New BlackCoffeeLibrary.Main

    'Private dsMonitoring As New Monitoring
    'Private adpUser As New SecUserTableAdapter
    'Private adpSection As New SecSectionTableAdapter
    'Private adpWorkgroup As New SecWorkgroupTableAdapter

    'Private dtUser As New SecUserDataTable
    'Private dtSection As New SecSectionDataTable
    'Private dtWorkgroup As New SecWorkgroupDataTable

    Private WithEvents bsUser As New BindingSource
    Private WithEvents bsSection As New BindingSource
    Private WithEvents bsWorkgroup As New BindingSource

    Private pageSize As Integer
    Private pageIndex As Integer
    Private totalCount As Integer
    Private pageCount As Integer
    Private indexScroll As Integer = 0
    Private indexPosition As Integer = 0

    Private dictSearchCriteria As New Dictionary(Of String, Integer)

    Private isFilterByUserName As Boolean = False
    Private isFilterBySection As Boolean = False
    Private isFilterByWorkgroup As Boolean = False

    Private departmentId As Integer = 0
    Private sectionId As Integer = 0
    Private workgroupId As Integer = 0
    Private isAdmin As Boolean = False

    Public Sub New(_departmentId As Integer, _sectionId As Integer, _workgroupId As Integer, _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        departmentId = _departmentId
        sectionId = _sectionId
        workgroupId = _workgroupId
        isAdmin = _isAdmin
    End Sub

    Private Sub frmMntMachine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pageIndex = 0
        pageSize = 100
        BindPage()
        SetupDgv()

        FillSearchCriteria()

        dbMain.EnableDoubleBuffered(dgvList)
        ActiveControl = dgvList
    End Sub

    Private Sub frmMntMachine_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            Case Keys.F10
                e.Handled = True
                btnAdd.PerformClick()
        End Select
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        btnEdit.PerformClick()
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

            ActiveControl = cmbCommon
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
            BindPage()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            isFilterByUserName = False
            isFilterBySection = False
            isFilterByWorkgroup = False

            cmbCommon.SelectedValue = 0

            pageIndex = 0
            BindPage()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Using frm As New SecUserDetail(0, departmentId, sectionId, workgroupId, isAdmin)
                If frm.ShowDialog() = DialogResult.OK Then
                    RefreshList()
                    bsUser.Position = bsUser.Find("UserId", frm.SubjectId)
                End If
            End Using
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
                    frm.rdActiveYes.Checked = True
                Else
                    frm.rdActiveNo.Checked = True
                End If

                If frm.ShowDialog() = DialogResult.OK Then
                    RefreshList()

                    If frm.SubjectId <> 0 Then
                        bsUser.Position = bsUser.Find("UserId", frm.SubjectId)
                    End If

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            'If bsUser.Current Is Nothing Then
            '    Exit Sub
            'End If

            'Dim currentRow = CType(bsUser.Current, DataRowView).Row
            'Dim state = currentRow.RowState

            'Select Case state
            '    Case DataRowState.Added
            '        bsUser.RemoveCurrent()
            '    Case DataRowState.Deleted
            '        MessageBox.Show("Item is already deleted.", "")
            '    Case DataRowState.Detached
            '        bsUser.CancelEdit()
            '    Case DataRowState.Modified, DataRowState.Unchanged
            '        If dgvList.SelectedCells.Count > 0 AndAlso dgvList.SelectedCells(0).RowIndex = dgvList.NewRowIndex Then
            '            bsUser.CancelEdit()
            '            Exit Sub
            '        End If

            '        Dim prmCount(0) As SqlParameter
            '        prmCount(0) = New SqlParameter("@UserId", SqlDbType.Int)
            '        prmCount(0).Value = CInt(bsUser.Current("UserId"))

            '        Dim count As Integer = 0
            '        count = dbMethod.ExecuteScalar("SELECT COUNT(TrxDetailId) FROM dbo.MntTransactionDetail WHERE UserId = @UserId", CommandType.Text, prmCount)

            '        If count > 0 Then
            '            Dim message1 = String.Format("{0} is already included in activities." & Environment.NewLine &
            '                                         "Mark this user as inactive instead?", bsUser.Current("UserName"))
            '            If MessageBox.Show(message1, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            '                currentRow.Item("IsActive") = False
            '                adpUser.Update(dsMonitoring.SecUser)
            '            End If
            '        Else
            '            Dim message2 = String.Format("Are you sure you want to delete {0}?", bsUser.Current("UserName"))
            '            If MessageBox.Show(message2, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            '                bsUser.RemoveCurrent()
            '                adpUser.Update(dsMonitoring.SecUser)
            '            End If
            '        End If
            '    Case Else
            'End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshList()
    End Sub

    Private Sub dgvList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvList.DataError
        e.Cancel = False
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If
        BindPage()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If
        BindPage()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        BindPage()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        BindPage()
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

    Private Sub FillSearchCriteria()
        Try
            dictSearchCriteria.Add(" User Name", 1)
            dictSearchCriteria.Add(" Workgroup", 2)

            If isAdmin Or sectionId = 1 Then
                dictSearchCriteria.Add(" Section", 3)
            End If

            cmbSearchCriteria.DisplayMember = "Key"
            cmbSearchCriteria.ValueMember = "Value"
            cmbSearchCriteria.DataSource = New BindingSource(dictSearchCriteria, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillSearchBySection()
        If isAdmin = 0 AndAlso sectionId <> 1 Then
            Dim prmSection(1) As SqlParameter
            prmSection(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmSection(0).Value = sectionId
            prmSection(1) = New SqlParameter("@DepartmentId", SqlDbType.Int)
            prmSection(1).Value = departmentId

            dbMethod.FillCmbWithCaption("RdSecSection", CommandType.StoredProcedure, "SectionId", "SectionName", cmbCommon, "< All > ", prmSection)
        Else
            dbMethod.FillCmbWithCaption("RdSecSection", CommandType.StoredProcedure, "SectionId", "SectionName", cmbCommon, "< All > ")
        End If
    End Sub

    Private Sub FillSearchByWorkgroup()
        If isAdmin = 0 AndAlso sectionId <> 1 Then
            Dim prmWorkgroup(0) As SqlParameter
            prmWorkgroup(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmWorkgroup(0).Value = sectionId

            dbMethod.FillCmbWithCaption("RdSecWorkgroup", CommandType.StoredProcedure, "WorkgroupId", "WorkgroupName", cmbCommon, "< All > ", prmWorkgroup)
        Else
            dbMethod.FillCmbWithCaption("RdSecWorkgroup", CommandType.StoredProcedure, "WorkgroupId", "WorkgroupCompleteName", cmbCommon, "< All >")
        End If
    End Sub

    Private Sub BindPage()
        Try
            totalCount = 0

            'If isFilterByUserName = True Then
            '    adpUser.FillSecUserMasterlistByUserName(dsMonitoring.SecUser, pageIndex, pageSize, totalCount, sectionId, isAdmin, txtCommon.Text.Trim)
            'ElseIf isFilterBySection = True Then
            '    adpUser.FillSecUserMasterlistBySectionId(dsMonitoring.SecUser, pageIndex, pageSize, totalCount, IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue), isAdmin)
            'ElseIf isFilterByWorkgroup = True Then
            '    adpUser.FillSecUserMasterlistByWorkgroupId(dsMonitoring.SecUser, pageIndex, pageSize, totalCount, sectionId, isAdmin, cmbCommon.SelectedValue)
            'Else
            '    adpUser.FillSecUserMasterlist(dsMonitoring.SecUser, pageIndex, pageSize, totalCount, sectionId, isAdmin)
            'End If

            'bsUser.DataSource = dsMonitoring
            'bsUser.DataMember = dtUser.TableName
            'bsUser.ResetBindings(True)
            'dgvList.AutoGenerateColumns = False
            'dgvList.DataSource = bsUser

            'If totalCount Mod pageSize = 0 Then
            '    If totalCount = 0 Then
            '        pageCount = (totalCount / pageSize) + 1
            '    Else
            '        pageCount = totalCount / pageSize
            '    End If
            'Else
            '    pageCount = Math.Truncate(totalCount / pageSize) + 1
            'End If

            ''current page index and total number of pages
            'txtPageNumber.Text = pageIndex + 1
            'txtTotalPageNumber.Text = "of " & CInt(pageCount) & " Page(s)"

            ''enables pager
            'txtPageNumber.Enabled = True
            'txtTotalPageNumber.Enabled = True
            'BindingNavigatorMoveFirstItem.Enabled = True
            'BindingNavigatorMovePreviousItem.Enabled = True
            'BindingNavigatorMoveNextItem.Enabled = True
            'BindingNavigatorMoveLastItem.Enabled = True

            'For Each column As DataGridViewColumn In dgvList.Columns
            '    column.DefaultCellStyle.SelectionBackColor = Color.White
            '    column.DefaultCellStyle.SelectionBackColor = Color.Black
            'Next
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            BindPage()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub RefreshList()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Invoke(New Action(AddressOf GetScrollingIndex))
        pageIndex = 0
        BindPage()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub GetScrollingIndex()
        indexScroll = dgvList.FirstDisplayedCell.RowIndex
        indexPosition = dgvList.CurrentRow.Index
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

    Private Sub SetupDgv()
        Try
            'adpSection.Fill(dsMonitoring.SecSection)
            'bsSection.DataSource = dsMonitoring
            'bsSection.DataMember = dtSection.TableName
            'bsSection.ResetBindings(True)

            'Dim colSection As DataGridViewComboBoxColumn = DirectCast(dgvList.Columns("ColSection"), DataGridViewComboBoxColumn)
            'colSection.ValueMember = "SectionId"
            'colSection.DisplayMember = "SectionName"
            'colSection.DataSource = bsSection
            'colSection.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            'colSection.DisplayStyleForCurrentCellOnly = False

            'adpWorkgroup.Fill(dsMonitoring.SecWorkgroup)
            'bsWorkgroup.DataSource = dsMonitoring
            'bsWorkgroup.DataMember = dtWorkgroup.TableName
            'bsWorkgroup.ResetBindings(True)

            'Dim colWorkgroup As DataGridViewComboBoxColumn = DirectCast(dgvList.Columns("ColWorkgroup"), DataGridViewComboBoxColumn)
            'colWorkgroup.ValueMember = "WorkgroupId"
            'colWorkgroup.DisplayMember = "WorkgroupName"
            'colWorkgroup.DataSource = bsWorkgroup
            'colWorkgroup.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            'colWorkgroup.DisplayStyleForCurrentCellOnly = False

            'dgvList.Columns("ColUserName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'dgvList.Columns("ColWorkgroup").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            'For Each column As DataGridViewColumn In dgvList.Columns
            '    column.DefaultCellStyle.SelectionBackColor = Color.White
            '    column.DefaultCellStyle.SelectionBackColor = Color.Black
            'Next
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmSecUser_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.Focus()
    End Sub

End Class