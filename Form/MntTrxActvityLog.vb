Imports System.ComponentModel
Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class MntTrxActvityLog
    Public bsTrxPartDetail As New BindingSource
    Public bsTrxPartDetailFloat As New BindingSource

    Public dtTrxPartDetail As New DataTable
    Public dtTrxPartDetailFloat As New DataTable

    Private adpTrxPartDetail As New SqlDataAdapter
    Private adpTrxPartDetailFloat As New SqlDataAdapter

    Private bsSparePart As New BindingSource

    Private bsTrxDetail As New BindingSource
    Private bsTrxDetailFloat As New BindingSource

    Private dbConnection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)
    Private dicPartSelection As New Dictionary(Of String, Integer)
    Private dtSparePart As New DataTable
    Private isActive As Boolean = False
    Private partTrxId As Integer = 0
    Private trxId As Integer = 0
    Private userId As Integer = 0
    Private isEditMode As Boolean = False

    Public Sub New(Optional _trxId As Integer = 0, Optional _userId As Integer = 0, Optional _isEditMode As Boolean = False)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        trxId = _trxId
        isEditMode = _isEditMode

        dbMain.EnableDoubleBuffered(dgvPartDetail)

        dtTrxPartDetail = CreateMntTransactionPartDetail()
        dtTrxPartDetailFloat = CreateMntTransactionPartDetailFloat()

        Dim prmUser(1) As SqlParameter
        prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
        prmUser(0).Value = 2
        prmUser(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
        prmUser(1).Value = 1
        dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbTechnician, "", prmUser)

        dtSparePart = dbMethod.FillDataTable("SELECT PartId, TRIM(PartNo) AS PartNo, TRIM(PartName) AS PartName FROM dbo.MntSparePart", CommandType.Text)
        Me.bsSparePart.DataSource = dtSparePart

        'transaction part detail table
        Dim colPartNo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colPartNo.Name = "ColPartNo"
        colPartNo.DataPropertyName = "PartId"
        colPartNo.HeaderText = "Part No"
        colPartNo.DataSource = Me.bsSparePart
        colPartNo.ValueMember = "PartId"
        colPartNo.DisplayMember = "PartNo"
        colPartNo.Width = 450
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
    End Sub

    Public Property childBsTrxDetail() As BindingSource
        Get
            Return bsTrxDetail
        End Get
        Set(value As BindingSource)
            bsTrxDetail = value
        End Set
    End Property

    Public Property childBsTrxDetailFloat() As BindingSource
        Get
            Return bsTrxDetailFloat
        End Get
        Set(value As BindingSource)
            bsTrxDetailFloat = value
        End Set
    End Property

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If cmbPart.SelectedValue = 0 Then
                MessageBox.Show("Please select an item.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbPart.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtConsumedQty.Text) OrElse CInt(txtConsumedQty.Text.Trim) = 0 Then
                MessageBox.Show("Please input the consumed quantity.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsumedQty.Focus()
                Exit Sub
            End If

            If CInt(txtConsumedQty.Text.Trim) > CInt(txtRemainingQty.Text.Trim) Then
                MessageBox.Show("Consumed quantity is greater than to remaining quantity.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsumedQty.Focus()
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

            If childBsTrxDetailFloat.Count > 0 Then
                For Each view As DataRowView In childBsTrxDetailFloat
                    Dim row = view.Row
                    If row.Item("PartTrxDetailId") Is DBNull.Value AndAlso
                            row.Item("PartTrxId") Is DBNull.Value Then

                        If row.Item("IssuedTo").Equals(cmbTechnician.SelectedValue) AndAlso
                                row.Item("PartId").Equals(cmbPart.SelectedValue) Then
                            MessageBox.Show("The selected item is already on the list.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            cmbPart.Focus()
                            Exit Sub
                        End If
                    End If
                Next
            End If

            Me.bsTrxPartDetail.AddNew()
            Me.bsTrxPartDetail.MoveLast()
            Me.bsTrxPartDetail.Current("CreatedBy") = cmbTechnician.SelectedValue
            Me.bsTrxPartDetail.Current("CreatedDate") = dbMethod.GetServerDate
            Me.bsTrxPartDetail.Current("UserId") = cmbTechnician.SelectedValue
            Me.bsTrxPartDetail.Current("PartId") = cmbPart.SelectedValue
            Me.bsTrxPartDetail.Current("Qty") = txtConsumedQty.Text.Trim
            Me.bsTrxPartDetail.EndEdit()

            Me.bsTrxPartDetailFloat.AddNew()
            Me.bsTrxPartDetailFloat.MoveLast()
            Me.bsTrxPartDetailFloat.Current("CreatedBy") = cmbTechnician.SelectedValue
            Me.bsTrxPartDetailFloat.Current("CreatedDate") = dbMethod.GetServerDate
            Me.bsTrxPartDetailFloat.Current("IssuedTo") = cmbTechnician.SelectedValue
            Me.bsTrxPartDetailFloat.Current("PartId") = cmbPart.SelectedValue
            Me.bsTrxPartDetailFloat.Current("IssuedQty") = CInt(txtIssuedQty.Text)
            Me.bsTrxPartDetailFloat.Current("ConsumedQty") = CInt(txtConsumedQty.Text)
            Me.bsTrxPartDetailFloat.Current("RemainingQty") = CInt(txtIssuedQty.Text) - CInt(txtConsumedQty.Text)
            Me.bsTrxPartDetailFloat.EndEdit()

            cmbPart.SelectedValue = 0

            txtPartDescription.Text = ""
            txtIssuedQty.Text = ""
            txtRemainingQty.Text = ""
            txtUnit.Text = ""
            txtConsumedQty.Clear()

            cmbPart.Focus()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        cmbPart.Text = ""
        cmbPart.SelectedValue = 0
        cmbPart.Focus()
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
            Dim datetimeStarted As New DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, dtpFrom.Value.Hour, dtpFrom.Value.Minute, 0)
            Dim datetimeEnded As New DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, dtpTo.Value.Hour, dtpTo.Value.Minute, 0)

            GetElapsedTime()

            If cmbTechnician.SelectedValue = 0 Then
                MessageBox.Show("Please select technician.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbTechnician.Focus()
                Return
            End If

            If dtpFrom.Value.Equals(dtpTo.Value) Or txtElapsedTime.Text.Trim = "0" Then
                MessageBox.Show("Datetime started should not be equals to datetime ended.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpTo.Focus()
                Return
            End If

            If dtpFrom.Value > dbMethod.GetServerDate Then
                MessageBox.Show("Start time is later than current time. Advanced encoding is not allowed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Else
                If dtpFrom.Value > dtpTo.Value Then
                    MessageBox.Show("Start time is later than end time. Advanced encoding is not allowed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            If bsTrxDetail.Count > 0 Then
                Dim drow As DataRow = Nothing
                Dim hit As Integer = 0

                For Each dataRowView As DataRowView In bsTrxDetail
                    Dim row = dataRowView.Row

                    If ((dtpFrom.Value >= row("TrxFrom")) And (dtpFrom.Value <= row("TrxTo"))) Then
                        hit += 1
                    End If

                    If ((dtpTo.Value >= row("TrxFrom")) And (dtpTo.Value <= row("TrxTo"))) Then
                        hit += 1
                    End If
                Next

                If hit > 0 Then
                    Dim msg As String = String.Format("Date or time already exists in the activity log.")
                    MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPart_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbPart.SelectedValue <> 0 Then
                If cmbPartSelection.SelectedValue = 1 Then
                    Dim prmDetail(1) As SqlParameter
                    prmDetail(0) = New SqlParameter("@PartId", SqlDbType.Int)
                    prmDetail(0).Value = cmbPart.SelectedValue
                    prmDetail(1) = New SqlParameter("@IssuedTo", SqlDbType.Int)
                    prmDetail(1).Value = cmbTechnician.SelectedValue

                    Using rdr As IDataReader = dbMethod.ExecuteReader("RdMntTransactionPartDetailFloatPartCount", CommandType.StoredProcedure, prmDetail)
                        While rdr.Read
                            txtPartDescription.Text = rdr.Item("PartNo").ToString.Trim
                            txtIssuedQty.Text = rdr.Item("IssuedQty")
                            txtRemainingQty.Text = rdr.Item("RemainingQty")
                            txtUnit.Text = rdr.Item("UnitCode")
                        End While
                        rdr.Close()
                    End Using

                    Dim prmHeader(1) As SqlParameter
                    prmHeader(0) = New SqlParameter("@PartId", SqlDbType.Int)
                    prmHeader(0).Value = cmbPart.SelectedValue
                    prmHeader(1) = New SqlParameter("@IssuedTo", SqlDbType.Int)
                    prmHeader(1).Value = cmbTechnician.SelectedValue

                    Using rdr As IDataReader = dbMethod.ExecuteReader("RdMntTransactionPartHeaderFloat", CommandType.StoredProcedure, prmHeader)
                        While rdr.Read
                            txtIssuedDate.Text = String.Format("{0:MMM dd, yyyy HH:mm}", rdr.Item("CreatedDate"))
                            txtIssuedBy.Text = rdr.Item("CreatedBy")
                        End While
                        rdr.Close()
                    End Using

                Else
                    Dim prmDetail(1) As SqlParameter
                    prmDetail(0) = New SqlParameter("@PartId", SqlDbType.Int)
                    prmDetail(0).Value = cmbPart.SelectedValue
                    prmDetail(1) = New SqlParameter("@IssuedTo", SqlDbType.Int)
                    prmDetail(1).Value = cmbTechnician.SelectedValue

                    Using rdr As IDataReader = dbMethod.ExecuteReader("RdMntTransactionPartDetailFloatPartCount", CommandType.StoredProcedure, prmDetail)
                        While rdr.Read
                            txtPartDescription.Text = rdr.Item("PartName").ToString.Trim
                            txtIssuedQty.Text = rdr.Item("IssuedQty")
                            txtRemainingQty.Text = rdr.Item("RemainingQty")
                            txtUnit.Text = rdr.Item("UnitCode")
                        End While
                        rdr.Close()
                    End Using

                    Dim prmHeader(1) As SqlParameter
                    prmHeader(0) = New SqlParameter("@PartId", SqlDbType.Int)
                    prmHeader(0).Value = cmbPart.SelectedValue
                    prmHeader(1) = New SqlParameter("@IssuedTo", SqlDbType.Int)
                    prmHeader(1).Value = cmbTechnician.SelectedValue

                    Using rdr As IDataReader = dbMethod.ExecuteReader("RdMntTransactionPartHeaderFloat", CommandType.StoredProcedure, prmHeader)
                        While rdr.Read
                            txtIssuedDate.Text = String.Format("{0:MMM dd, yyyy HH:mm}", rdr.Item("CreatedDate"))
                            txtIssuedBy.Text = rdr.Item("CreatedBy")
                        End While
                        rdr.Close()
                    End Using
                End If

            Else
                txtPartDescription.Text = ""
                txtIssuedQty.Text = ""
                txtIssuedDate.Text = ""
                txtIssuedBy.Text = ""
                txtRemainingQty.Text = ""
                txtUnit.Text = ""
                txtConsumedQty.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPart_Validated(sender As Object, e As EventArgs)
        Try
            If cmbPart.SelectedValue = 0 Then
                txtPartDescription.Text = ""
                txtIssuedDate.Text = ""
                txtIssuedQty.Text = ""
                txtRemainingQty.Text = ""
                txtUnit.Text = ""
                txtConsumedQty.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPart_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            If cmbPart.Items.Count > 1 Then
                e.Cancel = sender.FindStringExact(sender.text) < 0
                If e.Cancel Then Beep()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPartSelection_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPartSelection.SelectedValueChanged
        LoadIssuedParts()
    End Sub

    Private Sub LoadIssuedParts()
        Try
            cmbPart.DataSource = Nothing

            If cmbPartSelection.SelectedValue = 1 Then
                cmbPart.DisplayMember = "PartName"
                cmbPart.ValueMember = "PartId"

                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@IssuedTo", SqlDbType.Int)
                prm(0).Value = cmbTechnician.SelectedValue

                dbMethod.FillCmbWithCaption("RdMntTransactionPartDetailFloat", CommandType.StoredProcedure, "PartId", "PartName", cmbPart, "", prm)

                lblPartDescription.Text = "Part No"

            Else
                cmbPart.DisplayMember = "PartNo"
                cmbPart.ValueMember = "PartId"

                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@IssuedTo", SqlDbType.Int)
                prm(0).Value = cmbTechnician.SelectedValue

                dbMethod.FillCmbWithCaption("RdMntTransactionPartDetailFloat", CommandType.StoredProcedure, "PartId", "PartNo", cmbPart, "", prm)

                lblPartDescription.Text = "Part Name"
            End If

            cmbPart.SelectedValue = 0
            If cmbPart.Items.Count > 0 Then
                cmbPartSelection.Enabled = True
                cmbPart.Enabled = True
                txtConsumedQty.Enabled = True
                btnAdd.Enabled = True
                btnRemove.Enabled = True
            Else
                cmbPartSelection.Enabled = False
                cmbPart.Enabled = False
                txtConsumedQty.Enabled = False
                btnAdd.Enabled = False
                btnRemove.Enabled = False
            End If

            txtPartDescription.Text = ""
            txtIssuedQty.Text = ""
            txtRemainingQty.Text = ""
            txtUnit.Text = ""
            txtConsumedQty.Clear()
            txtIssuedDate.Text = ""
            txtIssuedBy.Text = ""

            AddHandler cmbPart.SelectedValueChanged, AddressOf cmbPart_SelectedValueChanged
            AddHandler cmbPart.Validated, AddressOf cmbPart_Validated
            AddHandler cmbPart.Validating, AddressOf cmbPart_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTechnician_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If dgvPartDetail.Rows.Count > 0 Then
                If MessageBox.Show("All items below will be cleared. Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) =
                         DialogResult.No Then
                    Exit Sub
                End If
            End If

            dtTrxPartDetail.Clear()

            If cmbTechnician.SelectedValue = 0 Then
                cmbPartSelection.Enabled = False
                cmbPart.Enabled = False
                txtConsumedQty.Enabled = False
                btnAdd.Enabled = False
                btnRemove.Enabled = False

                Me.ActiveControl = cmbTechnician
            Else
                cmbPartSelection.Enabled = True
                cmbPart.Enabled = True
                txtConsumedQty.Enabled = True
                btnAdd.Enabled = True
                btnRemove.Enabled = True

                Me.ActiveControl = cmbPart
            End If

            LoadIssuedParts()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTechnician_Validated(sender As Object, e As EventArgs) Handles cmbTechnician.Validated
        Try
            If cmbTechnician.SelectedValue = 0 Then
                cmbTechnician.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTechnician_Validating(sender As Object, e As CancelEventArgs) Handles cmbTechnician.Validating
        e.Cancel = sender.FindStringExact(sender.text) < 0 AndAlso String.IsNullOrEmpty(cmbTechnician.Text)
        If e.Cancel Then Beep()
    End Sub
    Private Sub cmbUser_Enter(sender As Object, e As EventArgs) Handles cmbTechnician.Enter
        lblTechnician.ForeColor = Color.White
        lblTechnician.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbUser_Leave(sender As Object, e As EventArgs) Handles cmbTechnician.Leave
        lblTechnician.ForeColor = Color.Black
        lblTechnician.BackColor = SystemColors.Control
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

    Private Function CreateMntTransactionPartDetailFloat() As DataTable
        Dim dtMntTrxPartDetailFloat As New DataTable
        Dim con As New SqlConnection(dbConnection.GetConnectionString)

        Try
            Dim query As String = "SELECT PartTrxDetailId, PartTrxId, SeqId, CreatedBy, CreatedDate, IssuedTo, PartId, IssuedQty, ConsumedQty, RemainingQty, ModifiedBy, ModifiedDate FROM dbo.MntTransactionPartDetailFloat"
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

            Dim colConsumedQty As DataColumn = New DataColumn("ConsumedQty")
            colConsumedQty.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetailFloat.Columns.Add(colConsumedQty)

            Dim colRemainingQty As DataColumn = New DataColumn("RemainingQty")
            colRemainingQty.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetailFloat.Columns.Add(colRemainingQty)

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

    Private Sub dgvPartDetail_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPartDetail.SelectionChanged
        If trxId <> 0 AndAlso userId <> 0 Then
            dgvPartDetail.ClearSelection()
        End If
    End Sub

    Private Sub dgvSpareParts_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        e.Cancel = False
    End Sub

    Private Sub dtpFrom_Enter(sender As Object, e As EventArgs) Handles dtpFrom.Enter
        lblFrom.ForeColor = Color.White
        lblFrom.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub dtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        lblFrom.ForeColor = Color.Black
        lblFrom.BackColor = SystemColors.Control
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        GetElapsedTime()
    End Sub

    Private Sub dtpTo_Enter(sender As Object, e As EventArgs) Handles dtpTo.Enter
        lblTo.ForeColor = Color.White
        lblTo.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub dtpTo_Leave(sender As Object, e As EventArgs) Handles dtpTo.Leave
        lblTo.ForeColor = Color.Black
        lblTo.BackColor = SystemColors.Control
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        GetElapsedTime()
    End Sub

    'set the default value of shift based on the current hour
    Private Sub GetCurrentShift()
        Try
            If DateTime.Now.Hour >= 7 And DateTime.Now.Hour <= 19 Then
                rdDay.Checked = True
            Else
                rdNight.Checked = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'get the elapsed time between the two datetime
    Private Sub GetElapsedTime()
        Try
            Dim datetimeStarted As New DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, dtpFrom.Value.Hour, dtpFrom.Value.Minute, 0)
            Dim datetimeEnded As New DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, dtpTo.Value.Hour, dtpTo.Value.Minute, 0)
            Dim lastDatetime As DateTime = Nothing
            Dim span As TimeSpan = Nothing
            Dim minutes As Integer = 0
            Dim hours As Integer = 0
            Dim days As Integer = 0

            span = (datetimeStarted - datetimeEnded).Duration()
            txtElapsedTime.Text = span.TotalMinutes.ToString.Trim
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub grpShift_Enter(sender As Object, e As EventArgs) Handles grpShift.Enter
        lblShift.ForeColor = Color.White
        lblShift.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub grpShift_Leave(sender As Object, e As EventArgs) Handles grpShift.Leave
        lblShift.ForeColor = Color.Black
        lblShift.BackColor = SystemColors.Control
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
        cmbPartSelection.Enabled = False
        cmbPart.Enabled = False
        txtConsumedQty.Enabled = False
        btnAdd.Enabled = False
        btnRemove.Enabled = False

        LoadPartSelection()

        AddHandler cmbTechnician.SelectedValueChanged, AddressOf cmbTechnician_SelectedValueChanged

        If trxId = 0 Then
            If isEditMode Then

            Else
                GetCurrentShift()
                dtpFrom.Value = CDate(dbMethod.GetServerDate).Date
                dtpTo.Value = CDate(dbMethod.GetServerDate).Date

                Me.ActiveControl = cmbTechnician
            End If

        Else
            If isEditMode Then

            Else
                GetCurrentShift()
                dtpFrom.Value = CDate(dbMethod.GetServerDate).Date
                dtpTo.Value = CDate(dbMethod.GetServerDate).Date
            End If
        End If

        Me.bsTrxPartDetailFloat.DataSource = dtTrxPartDetailFloat

        Me.bsTrxPartDetail.DataSource = dtTrxPartDetail
        dgvPartDetail.AutoGenerateColumns = False
        dgvPartDetail.DataSource = Me.bsTrxPartDetail

        Me.dgvPartDetail.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvPartDetail.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConsumedQty.KeyPress
        Try
            If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class