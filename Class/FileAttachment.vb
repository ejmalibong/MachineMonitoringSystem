Public Class FileAttachment
    Public fileName As String
    Public safeName As String
    Public extensionType As String
    Public attachmentId As Integer

    Public Sub New(_filename As String, _safename As String, _extensionName As String, Optional _attachmentId As Integer = 0)
        fileName = _filename
        safeName = _safename
        extensionType = _extensionName
        attachmentId = _attachmentId
    End Sub

End Class