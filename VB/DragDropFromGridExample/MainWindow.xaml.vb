Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Scheduling
Imports System.Linq

Namespace DragDropFromGridExample

    Public Partial Class MainWindow
        Inherits ThemedWindow

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub scheduler_StartAppointmentDragFromOutside(ByVal sender As Object, ByVal e As StartAppointmentDragFromOutsideEventArgs)
            If e.Data.GetDataPresent(GetType(RecordDragDropData)) Then
                Dim data = CType(e.Data.GetData(GetType(RecordDragDropData)), RecordDragDropData)
                For Each x In data.Records.OfType(Of Patient)()
                    e.DragAppointments.Add(New AppointmentItem With {.Subject = x.Name, .LabelId = Me.scheduler.LabelItems.FirstOrDefault()?.Id, .StatusId = Me.scheduler.StatusItems.FirstOrDefault()?.Id})
                Next
            End If
        End Sub
    End Class
End Namespace
