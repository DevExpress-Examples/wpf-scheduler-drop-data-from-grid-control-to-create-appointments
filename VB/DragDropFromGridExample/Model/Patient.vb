Imports DevExpress.Mvvm.POCO

Namespace DragDropFromGridExample

    Public Class Patient

        Public Shared Function Create() As Patient
            Return ViewModelSource.Create(Function() New Patient())
        End Function

        Protected Sub New()
        End Sub

        Public Overridable Property Id As Integer

        Public Overridable Property Name As String

        Public Overridable Property BirthDate As Date

        Public Overridable Property Phone As String

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class
End Namespace
