Public Class clsConnection

    Public Function GetConnectionString() As String
        If MachineMonitoringSystem.My.MySettings.Default.IsDebug = True Then
            Return "Data Source=NBCP-LT-058\SQLEXPRESS;Initial Catalog=MachineMonitoring;Persist Security Info=False;User ID=sa;Password=Nbc12#"
        Else
            Return "Data Source=LENOVO-AX3RONG2;Initial Catalog=MachineMonitoring;Persist Security Info=False;User ID=sa;Password=Nbc12#"
        End If
    End Function

End Class