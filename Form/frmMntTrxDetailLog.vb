Imports MachineMonitoringSystem.dsMonitoringTableAdapters
Imports MachineMonitoringSystem.dsMonitoring
Imports System.Data.SqlClient

Public Class frmMntTrxDetailLog
    Private method As New clsMethod
    'access control
    Private userId As Integer = 0
    Private trxId As Integer = 0
    Private trxDetailId As Integer = 0
    Private machineId As Integer = 0
    'fetching / access dataset
    Private myDataset As New dsMonitoring
    'adapter
    Private adpDetail As New MntTransactionDetailTableAdapter
    'binding sources
    Private WithEvents bsTransactionDetail As New BindingSource
    Private WithEvents bsUser As New BindingSource
    'datatables
    Private dtTransactionDetail As New MntTransactionDetailDataTable
    Private dtUser As New SecUserDataTable
    'custom binding
    Private WithEvents datetimeBinding As Binding
    Private WithEvents radioButtonBinding As Binding
    'constants
    Private shift As Char

    Public Sub New(ByVal _myDataset As DataSet, ByVal _bs As BindingSource, ByVal _userId As Integer, Optional _trxId As Integer = 0, Optional ByVal _trxDetailId As Integer = 0)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        trxId = _trxId
        trxDetailId = _trxDetailId

        Me.myDataset = _myDataset

        Me.bsUser.DataSource = Me.myDataset
        Me.bsUser.DataMember = dtUser.TableName
        Me.bsUser.Filter = String.Format("WorkgroupId IN (4,5,6)")
        cmbUser.DataSource = Me.bsUser

        'Me.bsTransactionDetail.DataSource = _bs
    End Sub

    Private Sub frmMntTrxDetailLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If trxDetailId = 0 Then
            cmbUser.SelectedValue = userId
            GetShift()
            dtpFrom.Value = DateTime.Now
            dtpTo.Value = DateTime.Now
        Else

        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim _datetimeStarted As New DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, dtpFrom.Value.Hour, dtpFrom.Value.Minute, 0)
            Dim _datetimeEnded As New DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, dtpTo.Value.Hour, dtpTo.Value.Minute, 0)

            'compute elapsedtime in case of using F10 when saving
            ComputeElapsedTime()

            'validation
            If dtpFrom.Value.Equals(dtpTo.Value) Or txtElapsedTime.Text.Trim = "00:00:00" Then
                MessageBox.Show("Datetime started should not be equals to datetime ended.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpTo.Focus()
                Return
            End If

            If dtpFrom.Value > DateTime.Now Then
                MessageBox.Show("Start datetime is later than current datetime. Advance encoding is not allowed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Else
                If dtpFrom.Value > dtpTo.Value Then
                    MessageBox.Show("Start datetime is later than end datetime.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            'Me.bsTransactionDetail.AllowNew = True
            'Me.bsTransactionDetail.AddNew()
            ''Me.bsTransactionDetail.MoveLast()
            'Me.bsTransactionDetail.Current("TrxId") = DBNull.Value
            'Me.bsTransactionDetail.Current("TrxDate") = DateTime.Now
            'Me.bsTransactionDetail.Current("TrxFrom") = dtpFrom.Value
            'Me.bsTransactionDetail.Current("TrxTo") = dtpTo.Value
            'Me.bsTransactionDetail.Current("ElapsedTime") = txtElapsedTime.Text.Trim
            'Me.bsTransactionDetail.Current("UserId") = cmbUser.SelectedValue
            'Me.bsTransactionDetail.Current("ShiftId") = IIf(rdDay.Checked = True, "D", "N")

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        ComputeElapsedTime()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        ComputeElapsedTime()
    End Sub

    Private Sub datetimeBinding_Format(sender As Object, e As ConvertEventArgs) Handles datetimeBinding.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy  HH:mm")
        Else
            e.Value = DateTime.Now.ToString("MMMM dd, yyyy  HH:mm")
        End If
    End Sub

    Public Property ShiftMode() As String
        Get
            If rdDay.Checked = True Then
                Return "D"
            Else
                Return "N"
            End If
        End Get

        Set(ByVal value As String)
            shift = value
            If shift = "D" Then
                rdDay.Checked = True
            Else
                rdDay.Checked = True
            End If
        End Set
    End Property

#Region "Sub"

    Private Sub GetShift()
        If DateTime.Now.Hour >= 7 And DateTime.Now.Hour <= 16 Then
            rdDay.Checked = True
        Else
            rdNight.Checked = True
        End If
    End Sub

    Private Sub ComputeElapsedTime()
        Try
            Dim _datetimeStarted As New DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, dtpFrom.Value.Hour, dtpFrom.Value.Minute, 0)
            Dim _datetimeEnded As New DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, dtpTo.Value.Hour, dtpTo.Value.Minute, 0)
            Dim _lastDatetime As DateTime = Nothing
            Dim _span As TimeSpan = Nothing
            Dim _minutes As Integer = 0
            Dim _hours As Integer = 0
            Dim _days As Integer = 0

            _span = (_datetimeStarted - _datetimeEnded).Duration()
            _minutes = _span.Minutes
            _hours = _span.Hours
            _days = _span.Days
            txtElapsedTime.Text = _days.ToString("00") & ":" & _hours.ToString("00") & ":" & _minutes.ToString("00")
        Catch ex As Exception
            MessageBox.Show(ex.Message, method.SetExcpTitle(ex), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class