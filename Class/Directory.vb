Public Class Directory

    Public Function ImageInitialDirectory() As String
        If MachineMonitoringSystem.My.MySettings.Default.IsDebug = True Then
            Return ""
        Else
            Return ""
        End If
    End Function

    Public Function AttachmentInitialDirectory() As String
        If MachineMonitoringSystem.My.MySettings.Default.IsDebug = True Then
            Return "B:\Users BACKUP\NBCP-LT-043\Desktop\Machine Monitoring System\Attachments"
        Else
            Return "\\192.168.20.11\Engineering\IT System\Machine Monitoring System\Attachments"
        End If
    End Function


End Class