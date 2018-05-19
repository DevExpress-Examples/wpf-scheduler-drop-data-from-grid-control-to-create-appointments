#Region "#usings"
Imports DevExpress.Mvvm.POCO
Imports System
#End Region ' #usings

Namespace DragDropFromGridExample
    Public Class Patient
        Public Shared Function Create() As Patient
            Return ViewModelSource.Create(Function() New Patient())
        End Function

        Protected Sub New()
        End Sub
        Public Overridable Property Id() As Integer
        Public Overridable Property Name() As String
        Public Overridable Property BirthDate() As Date
        Public Overridable Property Phone() As String
    End Class
End Namespace
