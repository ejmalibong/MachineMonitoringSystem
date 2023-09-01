Imports System.ComponentModel
Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class MntTrxActvityLog
    Public bsTrxPartDetail As New BindingSource
    Public dtTrxPartDetail As New DataTable
    Private adpTrxPartDetail As New SqlDataAdapter
    Private bsSparePart As New BindingSource
    Private bsTrxDetail As New BindingSource
    Private dbConnection As New Connection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)
    Private dicPartSelection As New Dictionary(Of String, Integer)
    Private dtSparePart As New DataTable
    Private isActive As Boolean = False
    Private partTrxId As Integer = 0
    Private trxId As Integer = 0
    Private userId As Integer = 0
    Public Sub New(Optional _trxId As Integer = 0, Optional _userId As Integer = 0)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        trxId = _trxId

        dbMain.EnableDoubleBuffered(dgvPartDetail)

        dtTrxPartDetail = CreateMntTransactionPartDetail()

        If userId = 0 Then
            Dim prmUser(1) As SqlParameter
            prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmUser(0).Value = 2
            prmUser(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
            prmUser(1).Value = 1
            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbTechnician, "", prmUser)

            Me.ActiveControl = cmbTechnician
        Else
            Dim prmUser(0) As SqlParameter
            prmUser(0) = New SqlParameter("@SectionId", SqlDbType.Int)
            prmUser(0).Value = 2
            dbMethod.FillCmbWithCaption("RdSecUser", CommandType.StoredProcedure, "UserId", "UserName", cmbTechnician, "", prmUser)

            Me.ActiveControl = btnAdd
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
        colPartNo.Width = 450
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
        colPartName.Width = 450
        colPartName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colPartName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colPartName.SortMode = DataGridViewColumnSortMode.Automatic
        dgvPartDetail.Columns.Insert(3, colPartName)
    End Sub

    Public Property childBsTrxDetail() As BindingSource
        Get
            Return bsTrxDetail
        End Get
        Set(value As BindingSource)
            bsTrxDetail = value
        End Set
    End Property

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If cmbPart.SelectedValue = 0 Then
                MessageBox.Show("Please select an item.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbPart.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtQty.Text) OrElse CInt(txtQty.Text.Trim) = 0 Then
                MessageBox.Show("Please input quantity to be issued.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtQty.Focus()
                Exit Sub
            End If

            If CInt(txtQty.Text.Trim) > CInt(txtActualStock.Text.Trim) Then
                MessageBox.Show("Quantity to issue is greater than to stock quantity.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            txtActualStock.Text = ""
            txtOrderingPoint.Text = ""
            txtUnit.Text = ""
            txtQty.Clear()

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
                    Dim msg As String = String.Format("Date and time already exist in the activity log." & Environment.NewLine & "NOTE: Tick the name from Included PIC if more than 1 technician worked at the same time.")
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

            AddHandler cmbPart.SelectedValueChanged, AddressOf cmbPart_SelectedValueChanged
            AddHandler cmbPart.Validated, AddressOf cmbPart_Validated
            AddHandler cmbPart.Validating, AddressOf cmbPart_Validating
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
        If trxId = 0 Then
            If userId = 0 Then 'add
                GetCurrentShift()
                dtpFrom.Value = CDate(dbMethod.GetServerDate).Date
                dtpTo.Value = CDate(dbMethod.GetServerDate).Date
            Else 'edit

            End If
        Else
            If userId = 0 Then
                cmbPart.Enabled = True
                txtQty.Enabled = True
                btnAdd.Enabled = True
                btnRemove.Enabled = True
                dgvPartDetail.Enabled = True
            Else
                cmbPart.Enabled = False
                txtQty.Enabled = False
                btnAdd.Enabled = False
                btnRemove.Enabled = False
                dgvPartDetail.Enabled = False
            End If
        End If

        LoadPartSelection()
        cmbPartSelection.SelectedValue = 1

        Me.bsTrxPartDetail.DataSource = dtTrxPartDetail
        dgvPartDetail.AutoGenerateColumns = False
        dgvPartDetail.DataSource = Me.bsTrxPartDetail

        Me.ActiveControl = cmbTechnician
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
End Class