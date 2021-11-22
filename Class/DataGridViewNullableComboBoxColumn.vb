Public Class DataGridViewNullableComboBoxColumn
    Inherits DataGridViewComboBoxColumn

    Public Sub New()
        MyBase.New()
        MyBase.CellTemplate = New DataGridViewComboboxWithNullCell
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            If (value IsNot Nothing) AndAlso Not value.GetType().IsAssignableFrom(GetType(DataGridViewComboboxWithNullCell)) Then
                Throw New InvalidCastException("Must be a DataGridViewComboboxWithNullCell")
            End If

            MyBase.CellTemplate = value
        End Set
    End Property

End Class

Public Class DataGridViewComboboxWithNullCell
    Inherits DataGridViewComboBoxCell

    Protected Overrides Function SetValue(ByVal rowIndex As Integer, ByVal value As Object) As Boolean
        If IsDBNull(value) = False AndAlso value IsNot Nothing AndAlso (CStr(value) = " " Or CStr(value) = "0" Or CStr(value) = "N/A") Then
            value = DBNull.Value
        End If

        Return MyBase.SetValue(rowIndex, value)
    End Function

End Class
