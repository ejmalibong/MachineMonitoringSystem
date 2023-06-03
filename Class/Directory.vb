Public Class Directory

    Public Function ImgIniDirectoryMt() As String
        If MachineMonitoringSystem.My.MySettings.Default.IsDebug = True Then
            If Environment.MachineName.ToString.ToString = "NBCP-DT-032" Then
                Return "B:\Users BACKUP\NBCP-DT-032\OneDrive (it1@nbcphilippines.onmicrosoft.com)\OneDrive - NBC (Philippines) Car Technology Corporation\Machine Monitoring System\Attachments\ImgAttachmentMt"
            Else
                Return "C:\Users\NBCP-LT-043\OneDrive 2\OneDrive - NBC (Philippines) Car Technology Corporation\Machine Monitoring System\Attachments\CsAttachmentMt"
            End If
        Else
            Return "\\192.168.20.11\Engineering\IT System\Machine Monitoring System\Attachments\ImgAttachmentMt"
        End If
    End Function

    Public Function AtchIniDirectoryMt() As String
        If MachineMonitoringSystem.My.MySettings.Default.IsDebug = True Then
            If Environment.MachineName.ToString.ToString = "NBCP-DT-032" Then
                Return "B:\Users BACKUP\NBCP-DT-032\OneDrive (it1@nbcphilippines.onmicrosoft.com)\OneDrive - NBC (Philippines) Car Technology Corporation\Machine Monitoring System\Attachments\CsAttachmentMt"
            Else
                Return "C:\Users\NBCP-LT-043\OneDrive 2\OneDrive - NBC (Philippines) Car Technology Corporation\Machine Monitoring System\Attachments\ImgAttachmentMt"
            End If
        Else
            Return "\\192.168.20.11\Engineering\IT System\Machine Monitoring System\Attachments\CsAttachmentMt"
        End If
    End Function

    Public Function ImgIniDirectoryFc() As String
        If MachineMonitoringSystem.My.MySettings.Default.IsDebug = True Then
            If Environment.MachineName.ToString.ToString = "NBCP-DT-032" Then
                Return "B:\Users BACKUP\NBCP-DT-032\OneDrive (it1@nbcphilippines.onmicrosoft.com)\OneDrive - NBC (Philippines) Car Technology Corporation\Machine Monitoring System\Attachments\ImgAttachmentFc"
            Else
                Return "C:\Users\NBCP-LT-043\OneDrive 2\OneDrive - NBC (Philippines) Car Technology Corporation\Machine Monitoring System\Attachments\ImgAttachmentFc"
            End If
        Else
            Return "\\192.168.20.11\Engineering\IT System\Machine Monitoring System\Attachments\ImgAttachmentFc"
        End If
    End Function

    Public Function AtchIniDirectoryFc() As String
        If MachineMonitoringSystem.My.MySettings.Default.IsDebug = True Then
            If Environment.MachineName.ToString.ToString = "NBCP-DT-032" Then
                Return "B:\Users BACKUP\NBCP-DT-032\OneDrive (it1@nbcphilippines.onmicrosoft.com)\OneDrive - NBC (Philippines) Car Technology Corporation\Machine Monitoring System\Attachments\CsAttachmentFc"
            Else
                Return "C:\Users\NBCP-LT-043\OneDrive 2\OneDrive - NBC (Philippines) Car Technology Corporation\Machine Monitoring System\Attachments\CsAttachmentFc"
            End If
        Else
            Return "\\192.168.20.11\Engineering\IT System\Machine Monitoring System\Attachments\CsAttachmentFc"
        End If
    End Function

End Class