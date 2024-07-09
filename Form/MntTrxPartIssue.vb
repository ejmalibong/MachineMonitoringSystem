Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports BlackCoffeeLibrary

Public Class MntTrxPartIssue
    Public bsTrxPartDetail As New BindingSource
    Public bsTrxPartDetailFloat As New BindingSource

    Public dtTrxPartDetail As New DataTable
    Public dtTrxPartDetailFloat As New DataTable

    Private adpTrxPartDetail As New SqlDataAdapter
    Private adpTrxPartDetailFloat As New SqlDataAdapter

    Private bite As Byte() 'the word `byte` is not a valid identifier
    Private bsSparePart As New BindingSource
    Private dbConnection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)
    Private dicPartSelection As New Dictionary(Of String, Integer)
    Private dtSparePart As New DataTable
    Private dtTrxPartHeader As New DataTable
    Private dtTrxPartHeaderFloat As New DataTable
    Private isActive As Boolean = False
    Private mStream As New MemoryStream
    Private partTrxId As Integer = 0
    Private userId As Integer = 0
    Private isFloat As Boolean = False

    Public Sub New(_userId As Integer, Optional _partTrxId As Integer = 0, Optional _isFloat As Boolean = False)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        partTrxId = _partTrxId
        isFloat = _isFloat

        dbMain.EnableDoubleBuffered(dgvPartDetail)

        Dim isClosed As Boolean = False

        If partTrxId = 0 Then
            Dim prmUser(1) As SqlParameter
            prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmUser(0).Value = 2
            prmUser(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
            prmUser(1).Value = 1
            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbTechnician, "", prmUser)

            dtTrxPartDetail = CreateMntTransactionPartDetail()
            dtTrxPartDetailFloat = CreateMntTransactionPartDetailFloat()

            ActiveControl = cmbTechnician
        Else
            If isFloat Then
                Dim prmUser(0) As SqlParameter
                prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
                prmUser(0).Value = 2
                dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbTechnician, "", prmUser)

                Dim prmHeader(0) As SqlParameter
                prmHeader(0) = New SqlParameter("PartTrxId", SqlDbType.Int)
                prmHeader(0).Value = partTrxId

                dtTrxPartHeaderFloat = dbMethod.FillDataTable("RdMntTransactionPartHeaderFloatByPartTrxId", CommandType.StoredProcedure, prmHeader)

                Dim prmDetail(0) As SqlParameter
                prmDetail(0) = New SqlParameter("PartTrxId", SqlDbType.Int)
                prmDetail(0).Value = partTrxId

                dtTrxPartDetailFloat = dbMethod.FillDataTable("RdMntTransactionPartDetailFloatByPartTrxId", CommandType.StoredProcedure, prmDetail)

                For Each row As DataRow In dtTrxPartHeaderFloat.Rows
                    dtpDateReceived.Value = row("CreatedDate")
                    cmbTechnician.SelectedValue = row("CreatedBy")

                    If Not row("ReferenceNo") Is DBNull.Value Then
                        txtReferenceNo.Text = row("ReferenceNo").ToString.Trim
                    End If

                    If Not row("Remarks") Is DBNull.Value Then
                        txtRemarks.Text = row("Remarks").ToString.Trim
                    End If

                    isClosed = row("IsClosed")
                Next

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

                btnCloseRecord.Visible = False
            End If

            If isClosed = True Then
                Me.Text = "Transaction No. " & partTrxId & " (CLOSED)"
                btnCloseRecord.Enabled = False
            Else
                Me.Text = "Transaction No. " & partTrxId
            End If

            Me.ActiveControl = btnClose
        End If

        Dim prmPart(0) As SqlParameter
        prmPart(0) = New SqlParameter("@IsActive", SqlDbType.Bit)
        prmPart(0).Value = 1
        dtSparePart = dbMethod.FillDataTable("SELECT PartId, TRIM(PartNo) AS PartNo, TRIM(PartName) AS PartName FROM dbo.MntSparePart WHERE IsActive = @IsActive AND ActualStock > 0", CommandType.Text, prmPart)

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
        dgvPartDetail.Columns.Insert(1, colPartNo)

        Dim colPartName As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colPartName.Name = "ColPartName"
        colPartName.DataPropertyName = "PartId"
        colPartName.HeaderText = "Part Name"
        colPartName.DataSource = Me.bsSparePart
        colPartName.ValueMember = "PartId"
        colPartName.DisplayMember = "PartName"
        colPartName.Width = 450
        colPartName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colPartName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colPartName.SortMode = DataGridViewColumnSortMode.Automatic
        dgvPartDetail.Columns.Insert(2, colPartName)

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

            If CInt(txtQty.Text.Trim) > CInt(txtActualStock.Text.Trim) Then
                MessageBox.Show("Quantity to issue is greater than to remaining stock.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            If chkFloat.Checked Then
                Me.bsTrxPartDetailFloat.AddNew()
                Me.bsTrxPartDetailFloat.MoveLast()
                Me.bsTrxPartDetailFloat.Current("CreatedBy") = cmbTechnician.SelectedValue
                Me.bsTrxPartDetailFloat.Current("CreatedDate") = dbMethod.GetServerDate
                Me.bsTrxPartDetailFloat.Current("IssuedTo") = cmbTechnician.SelectedValue
                Me.bsTrxPartDetailFloat.Current("PartId") = cmbPart.SelectedValue
                Me.bsTrxPartDetailFloat.Current("IssuedQty") = txtQty.Text.Trim
                Me.bsTrxPartDetailFloat.Current("ConsumedQty") = 0
                Me.bsTrxPartDetailFloat.Current("RemainingQty") = txtQty.Text.Trim
                Me.bsTrxPartDetailFloat.EndEdit()
            Else
                Me.bsTrxPartDetail.AddNew()
                Me.bsTrxPartDetail.MoveLast()
                Me.bsTrxPartDetail.Current("CreatedBy") = cmbTechnician.SelectedValue
                Me.bsTrxPartDetail.Current("CreatedDate") = dbMethod.GetServerDate
                Me.bsTrxPartDetail.Current("UserId") = cmbTechnician.SelectedValue
                Me.bsTrxPartDetail.Current("PartId") = cmbPart.SelectedValue
                Me.bsTrxPartDetail.Current("Qty") = txtQty.Text.Trim
                Me.bsTrxPartDetail.EndEdit()
            End If

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

            If chkFloat.Checked Then
                Dim prmPrHeaderFloat(6) As SqlParameter
                prmPrHeaderFloat(0) = New SqlParameter("@PartTrxId", SqlDbType.Int)
                prmPrHeaderFloat(0).Direction = ParameterDirection.Output
                prmPrHeaderFloat(1) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                prmPrHeaderFloat(1).Value = userId
                prmPrHeaderFloat(2) = New SqlParameter("@CreatedDate", SqlDbType.DateTime)
                prmPrHeaderFloat(2).Value = dbMethod.GetServerDate
                prmPrHeaderFloat(3) = New SqlParameter("@TransactionTypeId", SqlDbType.Int)
                prmPrHeaderFloat(3).Value = 2
                prmPrHeaderFloat(4) = New SqlParameter("@ReferenceNo", SqlDbType.Char)
                prmPrHeaderFloat(4).Value = IIf(String.IsNullOrEmpty(txtReferenceNo.Text.Trim), Nothing, txtReferenceNo.Text.Trim)
                prmPrHeaderFloat(5) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                prmPrHeaderFloat(5).Value = IIf(String.IsNullOrEmpty(txtRemarks.Text.Trim), Nothing, txtRemarks.Text.Trim)
                prmPrHeaderFloat(6) = New SqlParameter("@IsClosed", SqlDbType.Bit)
                prmPrHeaderFloat(6).Value = 0
                dbMethod.ExecuteNonQuery("InsMntTransactionPartHeaderFloat", CommandType.StoredProcedure, prmPrHeaderFloat)

                Dim rowCount As Integer = 0
                For Each dataRowView As DataRowView In Me.bsTrxPartDetailFloat
                    rowCount = rowCount + 1

                    Dim row = dataRowView.Row
                    row.Item("PartTrxId") = prmPrHeaderFloat(0).Value
                    row.Item("SeqId") = rowCount
                Next
                Me.bsTrxPartDetailFloat.EndEdit()
                adpTrxPartDetailFloat.Update(dtTrxPartDetailFloat)

            Else
                Dim prmPrHeader(7) As SqlParameter
                prmPrHeader(0) = New SqlParameter("@PartTrxId", SqlDbType.Int)
                prmPrHeader(0).Direction = ParameterDirection.Output
                prmPrHeader(1) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                prmPrHeader(1).Value = userId
                prmPrHeader(2) = New SqlParameter("@CreatedDate", SqlDbType.DateTime)
                prmPrHeader(2).Value = dbMethod.GetServerDate
                prmPrHeader(3) = New SqlParameter("@TrxId", SqlDbType.Int)
                prmPrHeader(3).Value = Nothing
                prmPrHeader(4) = New SqlParameter("@TransactionTypeId", SqlDbType.Int)
                prmPrHeader(4).Value = 2
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

                    dbMethod.ExecuteNonQuery("UpdMntSparePartIss", CommandType.StoredProcedure, prmIss)
                Next
            End If

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
                            txtActualStock.Text = rdr.Item("ActualStock") - rdr.Item("FloatQty")
                            txtFloatQty.Text = rdr.Item("FloatQty")
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
                            txtActualStock.Text = rdr.Item("ActualStock") - rdr.Item("FloatQty")
                            txtFloatQty.Text = rdr.Item("FloatQty")
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

    Private Sub cmbPart_Validated(sender As Object, e As EventArgs) Handles cmbPart.Validated
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

                dbMethod.FillCmbWithCaption("SELECT PartId, TRIM(PartName) + ' ' + TRIM(PartNo) AS PartName FROM dbo.MntSparePart WHERE ActualStock > 0 AND IsActive = 1",
                                            CommandType.Text, "PartId", "PartName", cmbPart, "")

                lblPartDescription.Text = "Part No"
            Else
                cmbPart.DisplayMember = "PartNo"
                cmbPart.ValueMember = "PartId"

                dbMethod.FillCmbWithCaption("SELECT PartId, TRIM(PartNo) AS PartNo FROM dbo.MntSparePart WHERE ActualStock > 0 AND IsActive = 1",
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
        e.Cancel = sender.FindStringExact(sender.text) < 0 AndAlso String.IsNullOrEmpty(cmbTechnician.Text)
        If e.Cancel Then Beep()
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

    Private Function CreateMntTransactionPartDetailFloat() As DataTable
        Dim dtMntTrxPartDetailFloat As New DataTable
        Dim con As New SqlConnection(dbConnection.GetConnectionString)

        Try
            Dim query As String = String.Empty

            query = "SELECT PartTrxDetailId, PartTrxId, SeqId, CreatedBy, CreatedDate, IssuedTo, PartId, IssuedQty, ConsumedQty, RemainingQty, ModifiedBy, ModifiedDate FROM dbo.MntTransactionPartDetailFloat"

            Dim cmd As New SqlCommand(query, con)
            adpTrxPartDetailFloat = New SqlDataAdapter(cmd)
            Dim cbTrxDetail As New SqlCommandBuilder(adpTrxPartDetailFloat)

            Dim colPartTrxDetailId As DataColumn = New DataColumn("PartTrxDetailId")
            colPartTrxDetailId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetailFloat.Columns.Add(colPartTrxDetailId)

            Dim colPartTrxId As DataColumn = New DataColumn("PartTrxId")
            colPartTrxId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetailFloat.Columns.Add(colPartTrxId)

            Dim colSeqId As DataColumn = New DataColumn("SeqId")
            colSeqId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetailFloat.Columns.Add(colSeqId)

            Dim colCreatedBy As DataColumn = New DataColumn("CreatedBy")
            colCreatedBy.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetailFloat.Columns.Add(colCreatedBy)

            Dim colCreateDate As DataColumn = New DataColumn("CreatedDate")
            colCreateDate.DataType = System.Type.GetType("System.DateTime")
            dtMntTrxPartDetailFloat.Columns.Add(colCreateDate)

            Dim colIssuedTo As DataColumn = New DataColumn("IssuedTo")
            colIssuedTo.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetailFloat.Columns.Add(colIssuedTo)

            Dim colPartId As DataColumn = New DataColumn("PartId")
            colPartId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetailFloat.Columns.Add(colPartId)

            Dim colIssuedQty As DataColumn = New DataColumn("IssuedQty")
            colIssuedQty.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetailFloat.Columns.Add(colIssuedQty)

            Dim colConsumed As DataColumn = New DataColumn("ConsumedQty")
            colConsumed.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetailFloat.Columns.Add(colConsumed)

            Dim colRemaining As DataColumn = New DataColumn("RemainingQty")
            colRemaining.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetailFloat.Columns.Add(colRemaining)

            Dim colModifiedBy As DataColumn = New DataColumn("ModifiedBy")
            colModifiedBy.DataType = System.Type.GetType("System.Int32")
            colModifiedBy.AllowDBNull = True
            dtMntTrxPartDetailFloat.Columns.Add(colModifiedBy)

            Dim colModifiedDate As DataColumn = New DataColumn("ModifiedDate")
            colModifiedDate.DataType = System.Type.GetType("System.DateTime")
            colModifiedDate.AllowDBNull = True
            dtMntTrxPartDetailFloat.Columns.Add(colModifiedDate)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtMntTrxPartDetailFloat
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

    Private Sub MntTrxPartIssue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPartSelection()
        dgvPartDetail.AutoGenerateColumns = False

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
            chkFloat.Enabled = False
            dgvPartDetail.Enabled = False
            btnDelete.Enabled = False
            btnCancel.Enabled = False
            btnSave.Enabled = False
        End If

        Dim colIssuedQty As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        colIssuedQty.Name = "ColIssuedQty"
        colIssuedQty.DataPropertyName = "IssuedQty"
        colIssuedQty.HeaderText = "Issued"
        colIssuedQty.Width = 60
        colIssuedQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colIssuedQty.SortMode = DataGridViewColumnSortMode.Automatic
        dgvPartDetail.Columns.Insert(3, colIssuedQty)

        Dim colConsumedQty As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        colConsumedQty.Name = "ColConsumedQty"
        colConsumedQty.DataPropertyName = "ConsumedQty"
        colConsumedQty.HeaderText = "Consumed"
        colConsumedQty.Width = 70
        colConsumedQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colConsumedQty.SortMode = DataGridViewColumnSortMode.Automatic
        dgvPartDetail.Columns.Insert(4, colConsumedQty)

        Me.bsTrxPartDetailFloat.DataSource = dtTrxPartDetailFloat
        dgvPartDetail.DataSource = Me.bsTrxPartDetailFloat

        AddHandler chkFloat.CheckedChanged, AddressOf chkFloat_CheckedChanged

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

    Private Sub MntTrxPartIssue_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            If partTrxId <> 0 Then
                cmbTechnician.SelectionLength = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkFloat_CheckedChanged(sender As Object, e As EventArgs)
        Try
            'Cancel CheckChanged event of CheckBox
            'https://bytes.com/topic/visual-basic-net/answers/689321-how-cancel-checkchanged-click-event-checkbox
            If dgvPartDetail.Rows.Count > 0 Then
                If MessageBox.Show("All items below will be cleared. Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) =
                        DialogResult.No Then

                    Dim cb As CheckBox = DirectCast(sender, CheckBox)
                    RemoveHandler cb.CheckedChanged, AddressOf chkFloat_CheckedChanged
                    cb.Checked = Not cb.Checked
                    AddHandler cb.CheckedChanged, AddressOf chkFloat_CheckedChanged
                    Exit Sub
                End If
            End If

            If chkFloat.Checked Then
                dtTrxPartDetail.Clear()
                dgvPartDetail.Columns.RemoveAt(3)

                Dim colIssuedQty As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
                colIssuedQty.Name = "ColIssuedQty"
                colIssuedQty.DataPropertyName = "IssuedQty"
                colIssuedQty.HeaderText = "Qty"
                colIssuedQty.Width = 60
                colIssuedQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                colIssuedQty.SortMode = DataGridViewColumnSortMode.Automatic
                dgvPartDetail.Columns.Insert(3, colIssuedQty)

                Me.bsTrxPartDetailFloat.DataSource = dtTrxPartDetailFloat
                dgvPartDetail.DataSource = Me.bsTrxPartDetailFloat
            Else
                dtTrxPartDetailFloat.Clear()
                dgvPartDetail.Columns.RemoveAt(3)

                Dim colQty As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
                colQty.Name = "ColIssuedQty"
                colQty.DataPropertyName = "Qty"
                colQty.HeaderText = "Qty"
                colQty.Width = 60
                colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                colQty.SortMode = DataGridViewColumnSortMode.Automatic
                dgvPartDetail.Columns.Insert(3, colQty)

                Me.bsTrxPartDetail.DataSource = dtTrxPartDetail
                dgvPartDetail.DataSource = Me.bsTrxPartDetail
            End If

            Me.ActiveControl = cmbPart
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTechnician_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTechnician.SelectedValueChanged
        Try
            If partTrxId = 0 Then
                If dgvPartDetail.Rows.Count > 0 Then
                    Dim techName As String = cmbTechnician.Text
                    Dim question As String = String.Format("All the items below will be transferred to {0}." & Environment.NewLine & "Do you want to contiue?", techName)
                    If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        If chkFloat.Checked Then
                            For Each dataRowView As DataRowView In Me.bsTrxPartDetailFloat
                                Dim row = dataRowView.Row
                                row.Item("CreatedBy") = cmbTechnician.SelectedValue
                                row.Item("IssuedTo") = cmbTechnician.SelectedValue
                            Next
                        Else
                            For Each dataRowView As DataRowView In Me.bsTrxPartDetail
                                Dim row = dataRowView.Row
                                row.Item("UserId") = cmbTechnician.SelectedValue
                            Next
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCloseRecord_Click(sender As Object, e As EventArgs) Handles btnCloseRecord.Click
        Try
            If partTrxId <> 0 AndAlso isFloat Then
                Dim isTrxClosed As Boolean = False
                Dim dtPartTrxHeaderFloat As New DataTable
                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@PartTrxId", SqlDbType.Int)
                prm(0).Value = partTrxId

                dtPartTrxHeaderFloat = dbMethod.FillDataTable("RdMntTransactionPartHeaderFloatByPartTrxId", CommandType.StoredProcedure, prm)

                For Each row As DataRow In dtPartTrxHeaderFloat.Rows
                    isTrxClosed = row("IsClosed")
                Next

                If isTrxClosed Then
                    Exit Sub
                End If

                Dim question = "Are you sure all remaining items were returned by technician?"
                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    For Each row As DataRowView In Me.bsTrxPartDetailFloat
                        If row("RemainingQty") > 0 Then
                            Dim prmLog(4) As SqlParameter
                            prmLog(0) = New SqlParameter("@PartTrxDetailId", SqlDbType.Int)
                            prmLog(0).Value = row("PartTrxDetailId")
                            prmLog(1) = New SqlParameter("@TrxId", SqlDbType.Int)
                            prmLog(1).Value = Nothing
                            prmLog(2) = New SqlParameter("@TransactionTypeId", SqlDbType.Int)
                            prmLog(2).Value = 3
                            prmLog(3) = New SqlParameter("@PartId", SqlDbType.Int)
                            prmLog(3).Value = row("PartId")
                            prmLog(4) = New SqlParameter("@Qty", SqlDbType.Int)
                            prmLog(4).Value = row("RemainingQty")
                            dbMethod.ExecuteNonQuery("InsMntTransactionPartDetailLogFloat", CommandType.StoredProcedure, prmLog)

                            Dim prmDetailFloat(3) As SqlParameter
                            prmDetailFloat(0) = New SqlParameter("@PartTrxDetailId", SqlDbType.Int)
                            prmDetailFloat(0).Value = row("PartTrxDetailId")
                            prmDetailFloat(1) = New SqlParameter("@RemainingQty", SqlDbType.Int)
                            prmDetailFloat(1).Value = row("RemainingQty")
                            prmDetailFloat(2) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                            prmDetailFloat(2).Value = userId
                            prmDetailFloat(3) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime)
                            prmDetailFloat(3).Value = CDate(dbMethod.GetServerDate).Date
                            Dim updDtlQry = "UPDATE dbo.MntTransactionPartDetailFloat SET ConsumedQty = ConsumedQty + @RemainingQty, RemainingQty = 0, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate WHERE PartTrxDetailId = @PartTrxDetailId"
                            dbMethod.ExecuteNonQuery(updDtlQry, CommandType.Text, prmDetailFloat)

                            Dim prmHeaderFloat(2) As SqlParameter
                            prmHeaderFloat(0) = New SqlParameter("@PartTrxId", SqlDbType.Int)
                            prmHeaderFloat(0).Value = partTrxId
                            prmHeaderFloat(1) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                            prmHeaderFloat(1).Value = userId
                            prmHeaderFloat(2) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime)
                            prmHeaderFloat(2).Value = CDate(dbMethod.GetServerDate).Date
                            Dim updHdrQry = "UPDATE dbo.MntTransactionPartHeaderFloat SET IsClosed = 1, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate WHERE PartTrxId = @PartTrxId"
                            dbMethod.ExecuteNonQuery(updHdrQry, CommandType.Text, prmHeaderFloat)
                        End If
                    Next
                End If

                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class