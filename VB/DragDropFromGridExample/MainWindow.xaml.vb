Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Scheduling

Namespace DragDropFromGridExample
    Partial Public Class MainWindow
        Inherits ThemedWindow

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub scheduler_StartAppointmentDragFromOutside(sender As Object, e As StartAppointmentDragFromOutsideEventArgs)
            If e.Data.GetDataPresent(GetType(RecordDragDropData)) Then
                Dim Data = CType(e.Data.GetData(GetType(RecordDragDropData)), RecordDragDropData)
                For Each x In Data.Records.OfType(Of Patient)
                    e.DragAppointments.Add(New AppointmentItem() With {
                        .Subject = x.Name,
                        .LabelId = scheduler.LabelItems.FirstOrDefault()?.Id,
                        .StatusId = scheduler.StatusItems.FirstOrDefault()?.Id
                    })
                Next
            End If
        End Sub
    End Class
End Namespace
