Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports BlackCoffeeLibrary

Public Class MntTrxPartReceive
    Public bsTrxPartDetail As New BindingSource
    Private dtTrxPartHeader As New DataTable
    Public dtTrxPartDetail As New DataTable
    Private adpTrxPartDetail As New SqlDataAdapter
    Private bite As Byte()
    Private bsSparePart As New BindingSource
    Private dbConnection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)
    Private dicPartSelection As New Dictionary(Of String, Integer)
    Private dtSparePart As New DataTable
    Private isActive As Boolean = False
    Private mStream As New MemoryStream
    Private partTrxId As Integer = 0
    Private userId As Integer = 0
    'the word `byte` is not a valid identifier
    Public Sub New(Optional _userId As Integer = 0, Optional _partTrxId As Integer = 0)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        partTrxId = _partTrxId

        dbMain.EnableDoubleBuffered(dgvPartDetail)

        If partTrxId = 0 Then
            Dim prmUser(1) As SqlParameter
            prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmUser(0).Value = 2
            prmUser(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
            prmUser(1).Value = 1
            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbTechnician, "", prmUser)

            dtTrxPartDetail = CreateMntTransactionPartDetail()

            ActiveControl = cmbTechnician

        Else
            Dim prmUser(0) As SqlParameter
            prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmUser(0).Value = 2
            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbTechnician, "", prmUser)

            Dim prmHeader(0) As SqlParameter
            prmHeader(0) = New SqlParameter("PartTrxId", SqlDbType.Int)
            prmHeader(0).Value = partTrxId

            dtTrxPartHeader = dbMethod.FillDataTable("RdMntTransactionPartHeaderByPartTrxId", CommandType.StoredProcedure, prmHeader)

            Dim prmDetail(0) As SqlParameter
            prmDetail(0) = New SqlParameter("PartTrxId", SqlDbType.Int)
            prmDetail(0).Value = partTrxId

            dtTrxPartDetail = dbMethod.FillDataTable("RdMntTransactionPartDetailByPartTrxId", CommandType.StoredProcedure, prmDetail)

            Me.Text = "Transaction No. " & partTrxId

            For Each row As DataRow In dtTrxPartHeader.Rows
                dtpDateReceived.Value = row("TrxDate")
                cmbTechnician.SelectedValue = row("CreatedBy")

                If Not row("ReferenceNo") Is DBNull.Value Then
                    txtReferenceNo.Text = row("ReferenceNo").ToString.Trim
                End If

                If Not row("Remarks") Is DBNull.Value Then
                    txtRemarks.Text = row("Remarks").ToString.Trim
                End If
            Next

            Me.ActiveControl = btnClose
        End If

        Dim prmPart(0) As SqlParameter
        prmPart(0) = New SqlParameter("@IsActive", SqlDbType.Bit)
        prmPart(0).Value = 1
        dtSparePart = dbMethod.FillDataTable("SELECT PartId, TRIM(PartNo) AS PartNo, TRIM(PartName) AS PartName FROM dbo.MntSparePart WHERE IsActive = @IsActive", CommandType.Text, prmPart)

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

        AddHandler cmbTechnician.Validating, AddressOf cmbTechnician_Validating
        AddHandler cmbTechnician.Validated, AddressOf cmbTechnician_Validated
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If cmbPart.SelectedValue = 0 Then
                MessageBox.Show("Please select an item.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbPart.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtQty.Text) OrElse CInt(txtQty.Text.Trim) = 0 Then
                MessageBox.Show("Please input quantity to receive.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtQty.Focus()
                Exit Sub
            End If

            Dim cnt As Integer = 0
            For Each row As DataGridViewRow In dgvPartDetail.Rows
                If row.Cells("ColPartId").Value = cmbPart.SelectedValue Then
                    cnt += 1
                End If
            Next

            If cnt > 0 Then
                MessageBox.Show("The selected item is already on the list.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbPart.Focus()
                Exit Sub
            End If

            Me.bsTrxPartDetail.AddNew()
            Me.bsTrxPartDetail.MoveLast()
            Me.bsTrxPartDetail.Current("CreatedBy") = cmbTechnician.SelectedValue
            Me.bsTrxPartDetail.Current("CreatedDate") = dbMethod.GetServerDate
            Me.bsTrxPartDetail.Current("UserId") = cmbTechnician.SelectedValue
            Me.bsTrxPartDetail.Current("PartId") = cmbPart.SelectedValue
            Me.bsTrxPartDetail.Current("Qty") = txtQty.Text.Trim
            Me.bsTrxPartDetail.EndEdit()

            cmbPart.SelectedValue = 0

            txtPartDescription.Text = ""
            txtLocation.Text = ""
            txtActualStock.Text = ""
            txtOrderingPoint.Text = ""
            txtUnit.Text = ""
            txtQty.Clear()

            Me.ActiveControl = cmbTechnician
            Me.ActiveControl = cmbPart
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
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If btnSave.Enabled = False Then
                Exit Sub
            End If

            If cmbTechnician.SelectedValue = 0 Then
                MessageBox.Show("Please select receiver of items.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbTechnician.Focus()
                Exit Sub
            End If

            If dgvPartDetail.Rows.Count = 0 Then
                MessageBox.Show("Please select items to receive.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbPart.Focus()
                Exit Sub
            End If

            Dim prmPrHeader(7) As SqlParameter
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
            prmPrHeader(6).Value = IIf(String.IsNullOrEmpty(txtRemarks.Text.Trim), Nothing, txtRemarks.Text.Trim)
            prmPrHeader(7) = New SqlParameter("@TrxDate", SqlDbType.Date)
            prmPrHeader(7).Value = CDate(dbMethod.GetServerDate).Date
            dbMethod.ExecuteNonQuery("InsMntTransactionPartHeader", CommandType.StoredProcedure, prmPrHeader)

            Dim rowCount As Integer = 0
            For Each dataRowView As DataRowView In Me.bsTrxPartDetail
                rowCount = rowCount + 1

                Dim row = dataRowView.Row
                row.Item("PartTrxId") = prmPrHeader(0).Value
                row.Item("SeqId") = rowCount
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

    Private Sub cmbPart_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbPart.SelectedValue <> 0 Then
                If Not picImage.Image Is Nothing Then
                    picImage.Image.Dispose()
                    picImage.Image = Nothing
                End If

                If cmbPartSelection.SelectedValue = 1 Then
                    Dim prmPartNo(0) As SqlParameter
                    prmPartNo(0) = New SqlParameter("@PartId", SqlDbType.Int)
                    prmPartNo(0).Value = cmbPart.SelectedValue

                    Using rdr As IDataReader = dbMethod.ExecuteReader("RdMntSparePart", CommandType.StoredProcedure, prmPartNo)
                        While rdr.Read
                            txtPartDescription.Text = rdr.Item("PartNo").ToString.Trim
                            txtActualStock.Text = rdr.Item("ActualStock")
                            txtOrderingPoint.Text = rdr.Item("OrderingPoint")
                            txtUnit.Text = rdr.Item("UnitCode")
                            txtLocation.Text = rdr.Item("LocationName")

                            If Not rdr.Item("Image") Is DBNull.Value Then
                                bite = rdr.Item("Image")
                                Using ms As New MemoryStream(bite)
                                    picImage.Image = Image.FromStream(ms)
                                End Using
                            End If
                        End While
                        rdr.Close()
                    End Using

                Else
                    Dim prmPartNo(0) As SqlParameter
                    prmPartNo(0) = New SqlParameter("@PartId", SqlDbType.Int)
                    prmPartNo(0).Value = cmbPart.SelectedValue

                    Using rdr As IDataReader = dbMethod.ExecuteReader("RdMntSparePart", CommandType.StoredProcedure, prmPartNo)
                        While rdr.Read
                            txtPartDescription.Text = rdr.Item("PartName").ToString.Trim
                            txtActualStock.Text = rdr.Item("ActualStock")
                            txtOrderingPoint.Text = rdr.Item("OrderingPoint")
                            txtUnit.Text = rdr.Item("UnitCode")
                            txtLocation.Text = rdr.Item("LocationName")

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

                If CInt(txtActualStock.Text) <= CInt(txtOrderingPoint.Text) Then
                    txtActualStock.ForeColor = Color.Red
                Else
                    txtActualStock.ForeColor = Color.Black
                End If
            Else
                txtPartDescription.Text = ""
                txtLocation.Text = ""
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

    Private Sub cmbPart_Validated(sender As Object, e As EventArgs)
        Try
            If cmbPart.SelectedValue = 0 Then
                txtPartDescription.Text = ""
                txtLocation.Text = ""
                txtActualStock.Text = ""
                txtOrderingPoint.Text = ""
                txtUnit.Text = ""
                txtQty.Clear()

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

    Private Sub cmbPartSelection_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPartSelection.SelectedValueChanged
        Try
            cmbPart.DataSource = Nothing

            If cmbPartSelection.SelectedValue = 1 Then
                cmbPart.DisplayMember = "PartName"
                cmbPart.ValueMember = "PartId"

                dbMethod.FillCmbWithCaption("SELECT PartId, TRIM(PartName) + ' ' + TRIM(PartNo) AS PartName FROM dbo.MntSparePart WHERE IsActive = 1",
                                            CommandType.Text, "PartId", "PartName", cmbPart, "")

                lblPartDescription.Text = "Part No"
            Else
                cmbPart.DisplayMember = "PartNo"
                cmbPart.ValueMember = "PartId"

                dbMethod.FillCmbWithCaption("SELECT PartId, TRIM(PartNo) AS PartNo FROM dbo.MntSparePart WHERE IsActive = 1",
                                            CommandType.Text, "PartId", "PartNo", cmbPart, "")

                lblPartDescription.Text = "Part Name"
            End If

            AddHandler cmbPart.Validated, AddressOf cmbPart_Validated
            AddHandler cmbPart.SelectedValueChanged, AddressOf cmbPart_SelectedValueChanged
            AddHandler cmbPart.Validating, AddressOf cmbPart_Validating
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

    Private Sub cmbTechnician_Validated(sender As Object, e As EventArgs)
        Try
            If cmbTechnician.SelectedValue = 0 Then
                cmbTechnician.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbTechnician_Validating(sender As Object, e As CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 AndAlso String.IsNullOrEmpty(cmbTechnician.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CreateMntTransactionPartDetail() As DataTable
        Dim dtMntTrxPartDetail As New DataTable
        Dim con As New SqlConnection(dbConnection.GetConnectionString)

        Try
            Dim query As String = String.Empty

            query = "SELECT PartTrxDetailId, PartTrxId, SeqId, CreatedBy, CreatedDate, UserId, PartId, Qty, ModifiedBy, ModifiedDate FROM dbo.MntTransactionPartDetail"

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

    Private Sub dgvPartDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvPartDetail.DataError
        e.Cancel = False
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

    Private Sub MntTrxActvityLog_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub MntTrxActvityLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPartSelection()

        If partTrxId = 0 Then
            cmbPartSelection.SelectedValue = 1
        Else
            dtpDateReceived.Enabled = False
            txtReferenceNo.Enabled = False
            cmbTechnician.Enabled = False
            cmbPartSelection.Enabled = False
            cmbPart.Enabled = False
            txtQty.Enabled = False
            txtRemarks.Enabled = False
            btnAdd.Enabled = False
            btnRemove.Enabled = False
            dgvPartDetail.Enabled = False
            btnDelete.Enabled = False
            btnCancel.Enabled = False
            btnSave.Enabled = False
        End If

        Me.bsTrxPartDetail.DataSource = dtTrxPartDetail
        dgvPartDetail.AutoGenerateColumns = False
        dgvPartDetail.DataSource = Me.bsTrxPartDetail

        If partTrxId <> 0 Then
            dgvPartDetail.ClearSelection()
        End If
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

    Private Sub MntTrxPartReceive_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            If partTrxId <> 0 Then
                cmbTechnician.SelectionLength = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class