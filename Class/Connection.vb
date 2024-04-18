Public Class Connection

    Public Function GetConnectionString() As String
        If MachineMonitoringSystem.My.Settings.IsDebug = True Then
            If Environment.MachineName.ToString.Trim = "NBCP-DT-032" Then
                Return "Data Source=NBCP-DT-032\SQLEXPRESS;Initial Catalog=MachineMonitoring;Persist Security Info=False;User ID=sa;Password=Nbc12#"
            Else
                Return "Data Source=NBCP-LT-144\SQLEXPRESS;Initial Catalog=MachineMonitoring;Persist Security Info=False;User ID=sa;Password=Nbc12#"
            End If
        Else
            Return "Data Source=LENOVO-AX3RONG2;Initial Catalog=MachineMonitoring;Persist Security Info=False;User ID=sa;Password=Nbc12#"
        End If
    End Function

End Class