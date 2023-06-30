Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports BlackCoffeeLibrary

Public Class MntTrxPartReceive
    Private dbConnection As New Connection
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private userId As Integer = 0
    Private trxId As Integer = 0
    Private partTrxId As Integer = 0

    Private dtSparePart As New DataTable
    Public dtTrxPartDetail As New DataTable

    Private bsSparePart As New BindingSource
    Public bsTrxPartDetail As New BindingSource

    Private mStream As New MemoryStream
    Private bite As Byte() 'the word `byte` is not a valid identifier

    Private adpTrxPartDetail As New SqlDataAdapter

    Public Sub New(_userId As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId

        dbMain.EnableDoubleBuffered(dgvPartDetail)

        dtTrxPartDetail = CreateMntTransactionPartDetail()

        Dim prmPart(1) As SqlParameter
        prmPart(0) = New SqlParameter("@IsNoStock", SqlDbType.Bit)
        prmPart(0).Value = 0
        prmPart(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
        prmPart(1).Value = 1
        dtSparePart = dbMethod.FillDataTable("RdMntSparePart", CommandType.StoredProcedure, prmPart)

        Me.bsSparePart.DataSource = dtSparePart

        'transaction part detail table
        Dim colPartNo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colPartNo.Name = "ColPartNo"
        colPartNo.DataPropertyName = "PartId"
        colPartNo.HeaderText = "Part No"
        colPartNo.DataSource = Me.bsSparePart
        colPartNo.ValueMember = "PartId"
        colPartNo.DisplayMember = "PartNo"
        colPartNo.Width = 415
        colPartNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colPartNo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colPartNo.SortMode = DataGridViewColumnSortMode.Automatic
        dgvPartDetail.Columns.Insert(2, colPartNo)

        Dim colPartName As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colPartName.Name = "ColPartName"
        colPartName.DataPropertyName = "PartId"
        colPartName.HeaderText = "Part Name"
        colPartName.DataSource = Me.bsSparePart
        colPartName.ValueMember = "PartId"
        colPartName.DisplayMember = "PartName"
        colPartName.Width = 415
        colPartName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colPartName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colPartName.SortMode = DataGridViewColumnSortMode.Automatic
        dgvPartDetail.Columns.Insert(3, colPartName)

        Dim prmUser(1) As SqlParameter
        prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
        prmUser(0).Value = 2
        prmUser(1) = New SqlParameter("@IsActive", SqlDbType.BigInt)
        prmUser(1).Value = 1
        dbMethod.FillCmb("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbTechnician, prmUser)

        cmbPartNo.DisplayMember = "PartNo"
        cmbPartNo.ValueMember = "PartId"

        dbMethod.FillCmbWithCaption("SELECT PartId, TRIM(PartNo) AS PartNo FROM dbo.MntSparePart WHERE IsActive = 1",
                                    CommandType.Text, "PartId", "PartNo", cmbPartNo, "")

        AddHandler cmbPartNo.SelectedValueChanged, AddressOf cmbPartNo_SelectedValueChanged
        AddHandler cmbPartNo.Validated, AddressOf cmbPartNo_Validated
    End Sub

    Private Sub MntTrxActvityLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.bsTrxPartDetail.DataSource = dtTrxPartDetail
        dgvPartDetail.AutoGenerateColumns = False
        dgvPartDetail.DataSource = Me.bsTrxPartDetail

        lblQty2.Text = dgvPartDetail.Rows.Count

        Me.ActiveControl = cmbTechnician
    End Sub

    Private Sub MntTrxActvityLog_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub cmbTechnician_Validating(sender As Object, e As CancelEventArgs)
        e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbTechnician.Text)
        If e.Cancel Then Beep()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If dgvPartDetail.Rows.Count = 0 Then
                MessageBox.Show("Please select items to receive.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbPartNo.Focus()
                Exit Sub
            End If

            Dim prmPrHeader(6) As SqlParameter
            prmPrHeader(0) = New SqlParameter("@PartTrxId", SqlDbType.Int)
            prmPrHeader(0).Direction = ParameterDirection.Output
            prmPrHeader(1) = New SqlParameter("@CreatedBy", SqlDbType.Int)
            prmPrHeader(1).Value = cmbTechnician.SelectedValue
            prmPrHeader(2) = New SqlParameter("@CreatedDate", SqlDbType.DateTime)
            prmPrHeader(2).Value = dbMethod.GetServerDate
            prmPrHeader(3) = New SqlParameter("@TrxId", SqlDbType.Int)
            prmPrHeader(3).Value = Nothing
            prmPrHeader(4) = New SqlParameter("@TransactionTypeId", SqlDbType.Int)
            prmPrHeader(4).Value = 1
            prmPrHeader(5) = New SqlParameter("@ReferenceNo", SqlDbType.Char)
            prmPrHeader(5).Value = IIf(String.IsNullOrEmpty(txtReferenceNo.Text.Trim), Nothing, txtReferenceNo.Text.Trim)
            prmPrHeader(6) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
            prmPrHeader(6).Value = IIf(String.IsNullOrEmpty(txtReferenceNo.Text.Trim), Nothing, txtReferenceNo.Text.Trim)
            dbMethod.ExecuteNonQuery("InsMntTransactionPartHeader", CommandType.StoredProcedure, prmPrHeader)

            For Each dataRowView As DataRowView In Me.bsTrxPartDetail
                Dim row = dataRowView.Row
                row.Item("PartTrxId") = prmPrHeader(0).Value
            Next
            Me.bsTrxPartDetail.EndEdit()
            adpTrxPartDetail.Update(dtTrxPartDetail)

            For Each row As DataGridViewRow In dgvPartDetail.Rows
                Dim prmIss(1) As SqlParameter
                prmIss(0) = New SqlParameter("@PartId", SqlDbType.Int)
                prmIss(0).Value = row.Cells("ColPartId").Value
                prmIss(1) = New SqlParameter("@Qty", SqlDbType.Int)
                prmIss(1).Value = row.Cells("ColQty").Value

                dbMethod.ExecuteNonQuery("UpdMntSparePartRec", CommandType.StoredProcedure, prmIss)
            Next

            Me.DialogResult = Windows.Forms.DialogResult.OK
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

    Private Sub cmbTechnician_Enter(sender As Object, e As EventArgs) Handles cmbTechnician.Enter
        lblTechnician.ForeColor = Color.White
        lblTechnician.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbTechnician_Leave(sender As Object, e As EventArgs) Handles cmbTechnician.Leave
        lblTechnician.ForeColor = Color.Black
        lblTechnician.BackColor = SystemColors.Control
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cmbPartNo.Text = ""
        cmbPartNo.SelectedValue = 0
        cmbPartNo.Focus()
    End Sub

    Private Function CreateMntTransactionPartDetail() As DataTable
        Dim dtMntTrxPartDetail As New DataTable
        Dim con As New SqlConnection(dbConnection.GetConnectionString)

        Try
            Dim query As String = "SELECT PartTrxDetailId, PartTrxId, SeqId, CreatedBy, CreatedDate, UserId, PartId, Qty, ModifiedBy, ModifiedDate FROM dbo.MntTransactionPartDetail"
            Dim cmd As New SqlCommand(query, con)
            adpTrxPartDetail = New SqlDataAdapter(cmd)
            Dim cbTrxDetail As New SqlCommandBuilder(adpTrxPartDetail)

            Dim colPartTrxDetailId As DataColumn = New DataColumn("PartTrxDetailId")
            colPartTrxDetailId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colPartTrxDetailId)

            Dim colPartTrxId As DataColumn = New DataColumn("PartTrxId")
            colPartTrxId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colPartTrxId)

            Dim colSeqId As DataColumn = New DataColumn("SeqId")
            colSeqId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colSeqId)

            Dim colCreatedBy As DataColumn = New DataColumn("CreatedBy")
            colCreatedBy.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colCreatedBy)

            Dim colCreateDate As DataColumn = New DataColumn("CreatedDate")
            colCreateDate.DataType = System.Type.GetType("System.DateTime")
            dtMntTrxPartDetail.Columns.Add(colCreateDate)

            Dim colUserId As DataColumn = New DataColumn("UserId")
            colUserId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colUserId)

            Dim colPartId As DataColumn = New DataColumn("PartId")
            colPartId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colPartId)

            Dim colQty As DataColumn = New DataColumn("Qty")
            colQty.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colQty)

            Dim colModifiedBy As DataColumn = New DataColumn("ModifiedBy")
            colModifiedBy.DataType = System.Type.GetType("System.Int32")
            colModifiedBy.AllowDBNull = True
            dtMntTrxPartDetail.Columns.Add(colModifiedBy)

            Dim colModifiedDate As DataColumn = New DataColumn("ModifiedDate")
            colModifiedDate.DataType = System.Type.GetType("System.DateTime")
            colModifiedDate.AllowDBNull = True
            dtMntTrxPartDetail.Columns.Add(colModifiedDate)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtMntTrxPartDetail
    End Function

    Private Sub cmbPartNo_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbPartNo.SelectedValue <> 0 Then
                If Not picImage.Image Is Nothing Then
                    picImage.Image.Dispose()
                    picImage.Image = Nothing
                End If

                Dim prmPartNo(0) As SqlParameter
                prmPartNo(0) = New SqlParameter("@PartId", SqlDbType.Int)
                prmPartNo(0).Value = cmbPartNo.SelectedValue

                Using rdr As IDataReader = dbMethod.ExecuteReader("RdMntSparePart", CommandType.StoredProcedure, prmPartNo)
                    While rdr.Read
                        txtPartName.Text = rdr.Item("PartName").ToString.Trim
                        txtActualStock.Text = rdr.Item("ActualStock")
                        txtOrderingPoint.Text = rdr.Item("OrderingPoint")
                        txtUnit.Text = rdr.Item("UnitCode")

                        If Not rdr.Item("Image") Is DBNull.Value Then
                            bite = rdr.Item("Image")
                            Using ms As New MemoryStream(bite)
                                picImage.Image = Image.FromStream(ms)
                            End Using
                        End If
                    End While
                    rdr.Close()
                End Using

                If CInt(txtActualStock.Text) <= CInt(txtOrderingPoint.Text) Then
                    txtActualStock.ForeColor = Color.Red
                Else
                    txtActualStock.ForeColor = Color.Black
                End If

            Else
                txtPartName.Text = ""
                txtActualStock.Text = ""
                txtOrderingPoint.Text = ""
                txtUnit.Text = ""
                txtQty.Clear()

                If Not picImage.Image Is Nothing Then
                    picImage.Image.Dispose()
                    picImage.Image = Nothing
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If cmbPartNo.SelectedValue = 0 Then
                MessageBox.Show("Please select an item.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbPartNo.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtQty.Text) OrElse CInt(txtQty.Text.Trim) = 0 Then
                MessageBox.Show("Please input quantity to receive.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtQty.Focus()
                Exit Sub
            End If

            Dim cnt As Integer = 0
            For Each row As DataGridViewRow In dgvPartDetail.Rows
                If row.Cells("ColPartId").Value = cmbPartNo.SelectedValue Then
                    cnt += 1
                End If
            Next

            If cnt > 0 Then
                MessageBox.Show("The selected item is already on the list.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbPartNo.Focus()
                Exit Sub
            End If

            Me.bsTrxPartDetail.AddNew()
            Me.bsTrxPartDetail.MoveLast()
            Me.bsTrxPartDetail.Current("CreatedBy") = cmbTechnician.SelectedValue
            Me.bsTrxPartDetail.Current("CreatedDate") = dbMethod.GetServerDate
            Me.bsTrxPartDetail.Current("UserId") = cmbTechnician.SelectedValue
            Me.bsTrxPartDetail.Current("PartId") = cmbPartNo.SelectedValue
            Me.bsTrxPartDetail.Current("Qty") = txtQty.Text.Trim
            Me.bsTrxPartDetail.EndEdit()

            cmbPartNo.SelectedValue = 0

            txtPartName.Text = ""
            txtActualStock.Text = ""
            txtOrderingPoint.Text = ""
            txtUnit.Text = ""
            txtQty.Clear()

            cmbPartNo.Focus()

            lblQty2.Text = dgvPartDetail.Rows.Count
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPartNo_Validated(sender As Object, e As EventArgs)
        Try
            If cmbPartNo.SelectedValue = 0 Then
                txtPartName.Text = ""
                txtActualStock.Text = ""
                txtOrderingPoint.Text = ""
                txtUnit.Text = ""

                If Not picImage.Image Is Nothing Then
                    picImage.Dispose()
                    picImage.Image = Nothing
                End If

                txtQty.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        Try
            If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            If dgvPartDetail.Rows.Count > 0 Then
                Dim question As String = "Are you sure you want to remove this item?"

                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Dim currentRow = CType(Me.bsTrxPartDetail.Current, DataRowView).Row
                    Dim rowState = currentRow.RowState

                    Select Case rowState
                        Case DataRowState.Added
                            Me.bsTrxPartDetail.RemoveCurrent()

                        Case DataRowState.Detached
                            Me.bsTrxPartDetail.CancelEdit()

                        Case DataRowState.Modified, DataRowState.Unchanged
                            If dgvPartDetail.SelectedCells.Count > 0 AndAlso dgvPartDetail.SelectedCells(0).RowIndex = dgvPartDetail.NewRowIndex Then
                                Me.bsTrxPartDetail.CancelEdit()
                                Exit Sub
                            End If

                            Me.bsTrxPartDetail.RemoveCurrent()

                        Case Else
                            Me.bsTrxPartDetail.RemoveCurrent()
                    End Select
                End If
            End If

            lblQty2.Text = dgvPartDetail.Rows.Count
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvPartDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvPartDetail.DataError
        e.Cancel = False
    End Sub

End Class