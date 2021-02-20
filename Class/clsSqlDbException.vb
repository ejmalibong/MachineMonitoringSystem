
'originated from
'https://www.developerfusion.com/code/5445/sql-data-provider-vbnet-class/

''' <summary>
''' Represents errors that occur during application execution.
''' </summary>
Public Class clsSqlDbException
    Inherits Exception

#Region " Constructor "
    ''' <summary>
    ''' Initializes a new instance of the ADO.SqlDatabaseException class.
    ''' </summary>
    Public Sub New()
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the ADO.SqlDatabaseException class with a specified error message.
    ''' </summary>
    ''' <param name="message">The message that describes the error.</param>
    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the ADO.SqlDatabaseException class with a specified error message and a reference to the inner exception that is the cause of this exception.
    ''' </summary>
    ''' <param name="message">The error message that explains the reason for the exception.</param>
    ''' <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    Public Sub New(ByVal message As String, ByVal innerException As Exception)
        MyBase.New(message, innerException)
    End Sub
#End Region

End Class