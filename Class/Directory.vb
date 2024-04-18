Public Class Directory

    Private isDebug As Boolean = My.Settings.IsDebug

    Public Function ImgIniDirectoryMt() As String
        If isDebug = True Then
            If Environment.MachineName.ToString.ToString = "NBCP-DT-032" Then
                Return "B:\Users BACKUP\NBCP-DT-032\Desktop\Attachments\ImgAttachmentMt"
            Else
                Return "B:\Users BACKUP\NBCP-LT-144\Desktop\Attachments\ImgAttachmentMt"
            End If
        Else
            Return "\\192.168.20.11\Engineering\IT System\Machine Monitoring System\Attachments\ImgAttachmentMt"
        End If
    End Function

    Public Function AtchIniDirectoryMt() As String
        If isDebug = True Then
            If Environment.MachineName.ToString.ToString = "NBCP-DT-032" Then
                Return "B:\Users BACKUP\NBCP-DT-032\Desktop\Attachments\CsAttachmentMt"
            Else
                Return "B:\Users BACKUP\NBCP-LT-144\Desktop\Attachments\CsAttachmentMt"
            End If
        Else
            Return "\\192.168.20.11\Engineering\IT System\Machine Monitoring System\Attachments\CsAttachmentMt"
        End If
    End Function

    Public Function DrwIniDirectoryMt() As String
        If isDebug = True Then
            If Environment.MachineName.ToString.ToString = "NBCP-DT-032" Then
                Return "B:\Users BACKUP\NBCP-DT-032\Desktop\Attachments\DrwAttachmentMt"
            Else
                Return "B:\Users BACKUP\NBCP-LT-144\Desktop\Attachments\DrwAttachmentMt"
            End If
        Else
            Return "\\192.168.20.11\Engineering\IT System\Machine Monitoring System\Attachments\DrwAttachmentMt"
        End If
    End Function

    Public Function ImgIniDirectoryFc() As String
        If isDebug = True Then
            If Environment.MachineName.ToString.ToString = "NBCP-DT-032" Then
                Return "B:\Users BACKUP\NBCP-DT-032\Desktop\Attachments\ImgAttachmentFc"
            Else
                Return "B:\Users BACKUP\NBCP-LT-144\Desktop\Attachments\ImgAttachmentFc"
            End If
        Else
            Return "\\192.168.20.11\Engineering\IT System\Machine Monitoring System\Attachments\ImgAttachmentFc"
        End If
    End Function

    Public Function AtchIniDirectoryFc() As String
        If isDebug = True Then
            If Environment.MachineName.ToString.ToString = "NBCP-DT-032" Then
                Return "B:\Users BACKUP\NBCP-DT-032\Desktop\Attachments\CsAttachmentFc"
            Else
                Return "B:\Users BACKUP\NBCP-LT-144\Desktop\Attachments\CsAttachmentFc"
            End If
        Else
            Return "\\192.168.20.11\Engineering\IT System\Machine Monitoring System\Attachments\CsAttachmentFc"
        End If
    End Function

End Class