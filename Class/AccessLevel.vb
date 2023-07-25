Imports System.Data.SqlClient
Imports BlackCoffeeLibrary

Public Class AccessLevel
    Private dbMain As New BlackCoffeeLibrary.Main
    Private connection As New Connection
    Private dbMethod As New SqlDbMethod(Connection.GetConnectionString)

    Public Function GetAccessLevel(_workgroupId As Integer) As Integer
        Dim accessLevelId As Integer = 0

        Try
            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@WorkgroupId", SqlDbType.Int)
            prm(0).Value = _workgroupId

            accessLevelId = dbMethod.ExecuteScalar("SELECT COALESCE(SUM(AccessLevelId),99) AS AccessLevelId FROM dbo.SecWorkgroupAccessLevel WHERE WorkgroupId = @WorkgroupId",
                                                   CommandType.Text, prm)

        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return accessLevelId
    End Function

End Class
