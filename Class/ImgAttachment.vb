Public Class ImgAttachment
    Public FileName As String
    Public SafeName As String
    Public ExtensionName As String
    Public TrxId As Integer

    Public Sub New(_filename As String, _safename As String, _extensionName As String, Optional _trxId As Integer = 0)
        FileName = _filename
        SafeName = _safename
        ExtensionName = _extensionName
        TrxId = TrxId
    End Sub

End Class