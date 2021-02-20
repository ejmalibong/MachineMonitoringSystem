Imports System.Configuration
Imports System.Data.SqlClient

Public Class clsConnection
    Private con As SqlConnection

    Public Function ConnectDb() As SqlConnection
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("MachineMonitoringSystem.My.MySettings.MDMonitoringConnectionString").ConnectionString)
        con.Open()
        Return con
    End Function

    Public Function GetConnectionString() As String
        Return ConfigurationManager.ConnectionStrings("MachineMonitoringSystem.My.MySettings.MDMonitoringConnectionString").ConnectionString
    End Function

End Class