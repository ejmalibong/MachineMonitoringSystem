Public Class FileAttachment
    Public FileName As String
    Public SafeName As String
    Public ExtensionName As String
    Public AttachmentId As Integer

    Public Sub New(_filename As String, _safename As String, _extensionName As String, Optional _attachmentId As Integer = 0)
        FileName = _filename
        SafeName = _safename
        ExtensionName = _extensionName
        AttachmentId = _attachmentId
    End Sub

End Class