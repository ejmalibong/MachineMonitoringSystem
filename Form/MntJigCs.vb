Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class MntJigCs
    Public WithEvents bsChecksheet As New BindingSource
    Private connection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dicRemarks As New Dictionary(Of String, Object)
    Private dicSearchCriteria As New Dictionary(Of String, Integer)
    Private dtChecksheet As New DataTable
    Private jigId As Integer = 0

    Public Sub New(Optional _machineId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        jigId = _machineId
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            cmbJigName.SelectedValue = 0
            txtYearId.Text = Year(dbMethod.GetServerDate)

            LoadData()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            If cmbJigName.SelectedValue = 0 Then
                MessageBox.Show("No jig selected.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            LoadData()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbJigName_Validated(sender As Object, e As EventArgs)
        If cmbJigName.Text.Trim.Length = 0 Or cmbJigName.SelectedValue = 0 Then
            cmbJigName.SelectedValue = 0
        End If
    End Sub

    Private Sub dgvTransactionHeader_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        btnRefresh.PerformClick()
    End Sub

    Private Sub dgvTransactionHeader_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvList.DataError
        e.Cancel = False
    End Sub

    Private Sub frm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvList.Dispose()
    End Sub

    Private Sub LoadData()
        Try
            Dim prmMasterlist(2) As SqlParameter
            prmMasterlist(0) = New SqlParameter("@JigId", SqlDbType.Int)
            prmMasterlist(0).Value = cmbJigName.SelectedValue
            prmMasterlist(1) = New SqlParameter("@YearId", SqlDbType.Int)
            prmMasterlist(1).Value = txtYearId.Text.Trim
            prmMasterlist(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
            prmMasterlist(2).Direction = ParameterDirection.Output

            dtChecksheet = dbMethod.FillDataTable("RdMntJigChecksheet", CommandType.StoredProcedure, prmMasterlist)

            If prmMasterlist(2).Value = 0 Then
                MessageBox.Show("No records found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                bsChecksheet.DataSource = dtChecksheet
                bsChecksheet.ResetBindings(True)
                dgvList.AutoGenerateColumns = False
                dgvList.DataSource = bsChecksheet

                Dim monthName As String = String.Empty
                For i As Integer = 0 To dgvList.Rows.Count - 1
                    monthName = Microsoft.VisualBasic.MonthName(dgvList.Rows(i).Cells("ColMonthId").Value, True)
                    dgvList.Rows(i).Cells("ColMonthName").Value = monthName
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadJig()
        Try
            cmbJigName.DisplayMember = "JigName"
            cmbJigName.ValueMember = "JigId"

            dbMethod.FillCmbWithCaption("RdMntJig", CommandType.StoredProcedure, "JigId", "JigCompleteName", cmbJigName, "< Select Jig >")

            AddHandler cmbJigName.Validated, AddressOf cmbJigName_Validated
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MntMch_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F4) Then
            e.Handled = True
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadJig()

        dbMain.EnableDoubleBuffered(dgvList)
        Me.ActiveControl = dgvList

        txtYearId.Text = Year(dbMethod.GetServerDate)

        Me.dgvList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub dgvList_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentDoubleClick
        Try
            If Me.dgvList.Rows.Count > 0 Then
                If Not CType(Me.bsChecksheet.Current, DataRowView).Item("LinkChecksheet") Is DBNull.Value AndAlso
                Not (e.ColumnIndex = 6 Or e.ColumnIndex = 7) Then
                    Dim link As String = CType(Me.bsChecksheet.Current, DataRowView).Item("LinkChecksheet")
                    If link.ToString.Substring(0, 2) = "\\" OrElse link.ToString.ToUpper.Substring(0, 4) = "HTTP" Then
                        Process.Start(link.ToString)
                    ElseIf Not link.ToString.ToUpper.Substring(0, 4) = "HTTP" Then
                        Process.Start("http://" & link.ToString)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvList_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvList.CellPainting
        Try
            If dgvList.Columns(e.ColumnIndex).Name = "ColViewChecksheet" AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(My.Resources.List_16_x_16,
                                     CInt((e.CellBounds.Width / 2) - (My.Resources.List_16_x_16.Width / 2)) + e.CellBounds.X,
                                     CInt((e.CellBounds.Height / 2) - (My.Resources.List_16_x_16.Height / 2)) + e.CellBounds.Y)
                e.Handled = True

            ElseIf dgvList.Columns(e.ColumnIndex).Name = "ColViewActivity" AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(My.Resources.Green_tag_16_x_16,
                                     CInt((e.CellBounds.Width / 2) - (My.Resources.Green_tag_16_x_16.Width / 2)) + e.CellBounds.X,
                                     CInt((e.CellBounds.Height / 2) - (My.Resources.Green_tag_16_x_16.Height / 2)) + e.CellBounds.Y)
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        Try
            If Me.dgvList.Rows.Count > 0 Then
                If Not CType(Me.bsChecksheet.Current, DataRowView).Item("LinkChecksheet") Is DBNull.Value Then
                    If e.ColumnIndex = 6 Then 'view checksheet
                        Dim link As String = CType(Me.bsChecksheet.Current, DataRowView).Item("LinkChecksheet")
                        If link.ToString.Substring(0, 2) = "\\" OrElse link.ToString.ToUpper.Substring(0, 4) = "HTTP" Then
                            Process.Start(link.ToString)
                        ElseIf Not link.ToString.ToUpper.Substring(0, 4) = "HTTP" Then
                            Process.Start("http://" & link.ToString)
                        End If

                    ElseIf e.ColumnIndex = 7 Then 'view activity
                        Dim trxId As String = CType(Me.bsChecksheet.Current, DataRowView).Item("TrxId")
                        Dim frmDetail As New MntTrxDetailJig(0, 0, 0, trxId)
                        frmDetail.fromPmCalendar = True
                        frmDetail.ShowDialog()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class