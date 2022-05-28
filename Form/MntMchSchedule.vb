Imports System.Data.SqlClient
Imports BlackCoffeeLibrary
Imports MachineMonitoringSystem.dsMonitoring
Imports MachineMonitoringSystem.dsMonitoringTableAdapters

Public Class MntMchSchedule
    Private connection As New Connection
    Private dbMethod As New SqlDbMethod(connection.GetConnectionString)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private dsMonitoring As New Monitoring
    Private adpSchedule As New MntMachineScheduleTableAdapter

    Private dtSchedule As New MntMachineDataTable

    Private WithEvents bsSchedule As New BindingSource

    Private pageSize As Integer
    Private pageIndex As Integer
    Private totalCount As Integer
    Private pageCount As Integer
    Private indexScroll As Integer = 0
    Private indexPosition As Integer = 0

    Private dictSearchCriteria As New Dictionary(Of String, Integer)

    Private isFilterByMachine As Boolean = False
    Private isFilterByMonth As Boolean = False
    Private isFilterByWeek As Boolean = False
    Private isFilterByCreatedBy As Boolean = False
    Private isFilterByActivityBy As Boolean = False
    Private isFilterByActivityDate As Boolean = False
    Private isFilterByChecklist As Boolean = False
    Private isFilterByDone As Boolean = False

    Private userId As Integer = 0
    Public Sub New(_userId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
    End Sub

    Private Sub MntMchSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pageIndex = 0
        pageSize = 100
        BindPage()

        txtYear.Text = Year(dbMethod.GetServerDate)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click

    End Sub

    Private Sub BindPage()
        Try
            totalCount = 0

            If isFilterByMachine = True Then

            ElseIf isFilterByMonth = True Then

            ElseIf isFilterByWeek = True Then

            ElseIf isFilterByCreatedBy = True Then

            ElseIf isFilterByActivityBy = True Then

            ElseIf isFilterByActivityDate = True Then

            ElseIf isFilterByChecklist = True Then

            ElseIf isFilterByDone = True Then

            Else

            End If

            bsSchedule.DataSource = dsMonitoring
            bsSchedule.DataMember = dtSchedule.TableName
            bsSchedule.ResetBindings(True)
            dgvList.AutoGenerateColumns = False
            dgvList.DataSource = bsSchedule

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

            For Each column As DataGridViewColumn In dgvList.Columns
                column.DefaultCellStyle.SelectionBackColor = Color.White
                column.DefaultCellStyle.SelectionBackColor = Color.Black
            Next
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class