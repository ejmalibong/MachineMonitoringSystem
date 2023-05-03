Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class MntTrxPartsIssuance
    Private dbConnection As New Connection
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private WithEvents bsMntSpareParts As New BindingSource
    Private WithEvents bsMntTrxParts As New BindingSource

    Private dtMntSpareParts As New DataTable
    Private dtTrxParts As New DataTable

    Private pageIndex As Integer
    Private pageSize As Integer
    Private pageCount As Integer
    Private totalCount As Integer

    Private lstPartId As New List(Of Integer)

    Public Sub New()


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dbMain.EnableDoubleBuffered(dgvSpareParts)


    End Sub

    Private Sub MntTrxPartsIssuance_Load(sender As Object, e As EventArgs) Handles Me.Load
        lstPartId.Clear()

        pageIndex = 0
        pageSize = 100
        LoadSpareParts()

        'dgvSpareParts.Rows(0).Cells("ColIsSelected").Value = True

        Me.ActiveControl = txtSearch
    End Sub

    Private Sub txtChecksheet_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            LoadSpareParts()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSpareParts()
        Try
            totalCount = 0

            If String.IsNullOrEmpty(txtSearch.Text.Trim) Then
                Dim prmParts(2) As SqlParameter
                prmParts(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmParts(0).Value = pageIndex
                prmParts(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmParts(1).Value = pageSize
                prmParts(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmParts(2).Direction = ParameterDirection.Output
                prmParts(2).Value = totalCount

                dtMntSpareParts = dbMethod.FillDataTable("RdMntSpareParts", CommandType.StoredProcedure, prmParts)
                totalCount = prmParts(2).Value
            Else
                Dim prmParts(3) As SqlParameter
                prmParts(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmParts(0).Value = pageIndex
                prmParts(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmParts(1).Value = pageSize
                prmParts(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmParts(2).Direction = ParameterDirection.Output
                prmParts(2).Value = totalCount
                prmParts(3) = New SqlParameter("@Name", SqlDbType.NVarChar)
                prmParts(3).Value = txtSearch.Text.Trim

                dtMntSpareParts = dbMethod.FillDataTable("RdMntSparePartsByName", CommandType.StoredProcedure, prmParts)
                totalCount = prmParts(2).Value
                pageIndex = 0
            End If

            Me.bsMntSpareParts.DataSource = dtMntSpareParts
            Me.bsMntSpareParts.ResetBindings(True)
            dgvSpareParts.AutoGenerateColumns = False
            dgvSpareParts.DataSource = Me.bsMntSpareParts

            If totalCount Mod pageSize = 0 Then
                If totalCount = 0 Then
                    pageCount = (totalCount / pageSize) + 1
                Else
                    pageCount = totalCount / pageSize
                End If
            Else
                pageCount = Math.Truncate(totalCount / pageSize) + 1
            End If

            txtPageNumber.Enabled = True
            txtTotalPageNumber.Enabled = True
            txtPageNumber.Text = pageIndex + 1
            txtTotalPageNumber.Text = "of " & CInt(pageCount) & " Page(s)"

            BindingNavigatorMoveFirstItem.Enabled = True
            BindingNavigatorMovePreviousItem.Enabled = True
            BindingNavigatorMoveNextItem.Enabled = True
            BindingNavigatorMoveLastItem.Enabled = True
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        LoadSpareParts()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If

        LoadSpareParts()
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If

        LoadSpareParts()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        LoadSpareParts()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
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
            LoadSpareParts()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvSpareParts_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvSpareParts.CurrentCellDirtyStateChanged
        If dgvSpareParts.IsCurrentCellDirty Then
            dgvSpareParts.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvSpareParts_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSpareParts.CellValueChanged
        If e.ColumnIndex = 0 AndAlso e.RowIndex > -1 Then
            'reference the gridview row
            Dim row As DataGridViewRow = dgvSpareParts.Rows(e.RowIndex)

            'set the checkbox selection
            row.Cells("ColIsSelected").Value = Convert.ToBoolean(row.Cells("ColIsSelected").Value)

            'if checkbox is checked, add to temp list
            If Convert.ToBoolean(row.Cells("ColIsSelected").Value) Then
                If Not lstPartId.Contains(row.Cells("ColPartId").Value) Then
                    lstPartId.Add(row.Cells("ColPartId").Value)
                End If
            Else
                If lstPartId.Contains(row.Cells("ColPartId").Value) Then
                    lstPartId.Remove(row.Cells("ColPartId").Value)
                End If
            End If
        End If
    End Sub

    Private Sub dgvSpareParts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSpareParts.CellContentClick

    End Sub

    Private Sub dgvSpareParts_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvSpareParts.DataBindingComplete
        dgvSpareParts.EndEdit()

        If lstPartId.Count > 0 Then
            For Each ids As Integer In lstPartId
                For i As Integer = 0 To dgvSpareParts.Rows.Count - 1
                    If dgvSpareParts.Rows(i).Cells("ColPartId").Value = ids Then
                        dgvSpareParts.Rows(i).Cells("ColIsSelected").Value = True
                    End If
                Next
            Next

        End If
    End Sub

    Private Sub dgvSpareParts_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvSpareParts.DataError
        e.Cancel = False
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        txtSearch.Clear()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If lstPartId.Count > 0 Then 'means there are checked items
                For Each row As DataGridViewRow In dgvSpareParts.Rows
                    Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("ColIsSelected").Value)
                    If isSelected Then

                    End If
                Next
            Else 'no checked items, evaluate the current item

            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try

        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class