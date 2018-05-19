Imports DevExpress.Xpf.Scheduling
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Input

Namespace DragDropFromGridExample
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits DevExpress.Xpf.Core.ThemedWindow

        Private startDrag As Boolean
        Private startPoint As Point

        Public Sub New()
            InitializeComponent()
            AddHandler grdPatients.View.PreviewMouseDown, AddressOf View_PreviewMouseDown
            AddHandler grdPatients.View.PreviewMouseMove, AddressOf View_PreviewMouseMove
        End Sub

        Private Function GetSchedulerData(ByVal rowHandler As Integer) As DataObject
            Dim appointments As New List(Of AppointmentItem)()

            Dim patient_Renamed As Patient = TryCast(grdPatients.GetRow(rowHandler), Patient)
            Dim appointment As New AppointmentItem()
            appointment.Subject = patient_Renamed.Name
            appointment.LabelKey = scheduler.LabelItems(0).Id
            appointment.StatusKey = scheduler.StatusItems(1).Id
            appointments.Add(appointment)
            Return New DataObject(GetType(IEnumerable(Of AppointmentItem)), appointments)
        End Function

        Private Function IsGridRowAvailable(ByVal rowHandler As Integer) As Boolean
            Return grdPatients.GetRow(rowHandler) IsNot Nothing
        End Function

        Private Sub View_PreviewMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            If e.LeftButton <> MouseButtonState.Pressed Then
                Return
            End If
            startPoint = e.GetPosition(Nothing)
            startDrag = IsGridRowAvailable(grdPatients.View.GetRowHandleByMouseEventArgs(e))
        End Sub

        Private Sub View_PreviewMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim position As Point = e.GetPosition(Nothing)
            If startDrag AndAlso e.LeftButton = MouseButtonState.Pressed Then
                Dim rowHandler As Integer = grdPatients.View.GetRowHandleByMouseEventArgs(e)
                If IsGridRowAvailable(rowHandler) Then
                    startDrag = False
                    Dim de As DragDropEffects = DragDrop.DoDragDrop(grdPatients, GetSchedulerData(rowHandler), DragDropEffects.All)
                End If
            End If
            Me.startPoint = position
        End Sub
    End Class
End Namespace
