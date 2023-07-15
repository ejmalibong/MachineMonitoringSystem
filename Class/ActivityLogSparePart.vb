'Imports System.Data.SqlClient
'Imports BlackCoffeeLibrary

Public Class ActivityLogSparePart
    'Private dbConnection As New Connection
    'Private dbMain As New BlackCoffeeLibrary.Main
    'Private dbMethod As New SqlDbMethod(dbConnection.GetConnectionString)

    Public userId As Integer = 0
    Public shiftId As Char
    Public dtpFrom As DateTime
    Public dtpTo As DateTime

    Public createdDate As DateTime
    Public modifiedBy As Integer = 0
    Public modifiedDate As DateTime
    Public elapsedTime As Integer

    Public datatable As New DataTable
    'Public con As New SqlConnection(dbConnection.GetConnectionString)

    Public Sub New(_userId As Integer, _shiftId As String, _dtpFrom As DateTime, _dtpto As DateTime, _createdDate As DateTime, _modifiedBy As Integer, _modifiedDate As DateTime, _elapsedTime As Integer, _datatable As DataTable)
        userId = _userId
        shiftId = _shiftId
        dtpFrom = _dtpFrom
        dtpTo = _dtpto
        createdDate = _createdDate
        modifiedBy = _modifiedBy
        modifiedDate = _modifiedDate
        elapsedTime = _elapsedTime

        datatable = _datatable

        Dim colPartTrxDetailId As DataColumn = New DataColumn("PartTrxDetailId")
        colPartTrxDetailId.DataType = System.Type.GetType("System.Int32")
        datatable.Columns.Add(colPartTrxDetailId)

        Dim colPartTrxId As DataColumn = New DataColumn("PartTrxId")
        colPartTrxId.DataType = System.Type.GetType("System.Int32")
        datatable.Columns.Add(colPartTrxId)

        Dim colCreatedBy As DataColumn = New DataColumn("CreatedBy")
        colCreatedBy.DataType = System.Type.GetType("System.Int32")
        datatable.Columns.Add(colCreatedBy)

        Dim colCreateDate As DataColumn = New DataColumn("CreatedDate")
        colCreateDate.DataType = System.Type.GetType("System.DateTime")
        datatable.Columns.Add(colCreateDate)

        Dim colUserId As DataColumn = New DataColumn("UserId")
        colUserId.DataType = System.Type.GetType("System.Int32")
        datatable.Columns.Add(colUserId)

        Dim colPartId As DataColumn = New DataColumn("PartId")
        colPartId.DataType = System.Type.GetType("System.Int32")
        datatable.Columns.Add(colPartId)

        Dim colQty As DataColumn = New DataColumn("Qty")
        colQty.DataType = System.Type.GetType("System.Int32")
        datatable.Columns.Add(colQty)

        Dim colModifiedBy As DataColumn = New DataColumn("ModifiedBy")
        colModifiedBy.DataType = System.Type.GetType("System.Int32")
        colModifiedBy.AllowDBNull = True
        datatable.Columns.Add(colModifiedBy)

        Dim colModifiedDate As DataColumn = New DataColumn("ModifiedDate")
        colModifiedDate.DataType = System.Type.GetType("System.DateTime")
        colModifiedDate.AllowDBNull = True
        datatable.Columns.Add(colModifiedDate)
    End Sub

End Class