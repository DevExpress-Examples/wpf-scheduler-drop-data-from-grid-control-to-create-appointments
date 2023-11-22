Imports DevExpress.Xpf.Scheduling
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Input

Namespace DragDropFromGridExample

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits DevExpress.Xpf.Core.ThemedWindow

        Private startDrag As Boolean

        Private startPoint As Point

        Public Sub New()
            Me.InitializeComponent()
            AddHandler Me.grdPatients.View.PreviewMouseDown, AddressOf Me.View_PreviewMouseDown
            AddHandler Me.grdPatients.View.PreviewMouseMove, AddressOf Me.View_PreviewMouseMove
        End Sub

        Private Function GetSchedulerData(ByVal rowHandler As Integer) As DataObject
            Dim appointments As List(Of AppointmentItem) = New List(Of AppointmentItem)()
            Dim patient As Patient = TryCast(Me.grdPatients.GetRow(rowHandler), Patient)
            Dim appointment As AppointmentItem = New AppointmentItem()
            appointment.Subject = patient.Name
            appointment.LabelId = Me.scheduler.LabelItems(0).Id
            appointment.StatusId = Me.scheduler.StatusItems(1).Id
            appointments.Add(appointment)
            Return New DataObject(GetType(IEnumerable(Of AppointmentItem)), appointments)
        End Function

        Private Function IsGridRowAvailable(ByVal rowHandler As Integer) As Boolean
            Return Me.grdPatients.GetRow(rowHandler) IsNot Nothing
        End Function

        Private Sub View_PreviewMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            If e.LeftButton <> MouseButtonState.Pressed Then Return
            startPoint = e.GetPosition(Nothing)
            startDrag = Me.IsGridRowAvailable(Me.grdPatients.View.GetRowHandleByMouseEventArgs(e))
        End Sub

        Private Sub View_PreviewMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim position As Point = e.GetPosition(Nothing)
            If startDrag AndAlso e.LeftButton = MouseButtonState.Pressed Then
                Dim rowHandler As Integer = Me.grdPatients.View.GetRowHandleByMouseEventArgs(e)
                If IsGridRowAvailable(rowHandler) Then
                    startDrag = False
                    Dim de As DragDropEffects = DragDrop.DoDragDrop(Me.grdPatients, GetSchedulerData(rowHandler), DragDropEffects.All)
                End If
            End If

            startPoint = position
        End Sub
    End Class
End Namespace
