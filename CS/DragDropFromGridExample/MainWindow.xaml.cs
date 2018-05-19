using DevExpress.Xpf.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DragDropFromGridExample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DevExpress.Xpf.Core.ThemedWindow {
        private bool startDrag;
        private Point startPoint;

        public MainWindow() {
            InitializeComponent();
            grdPatients.View.PreviewMouseDown += View_PreviewMouseDown;
            grdPatients.View.PreviewMouseMove += View_PreviewMouseMove;
        }

        DataObject GetSchedulerData(int rowHandler) {
            List<AppointmentItem> appointments = new List<AppointmentItem>();
            Patient patient = grdPatients.GetRow(rowHandler) as Patient;
            AppointmentItem appointment = new AppointmentItem();
            appointment.Subject = patient.Name;
            appointment.LabelId = scheduler.LabelItems[0].Id;
            appointment.StatusId = scheduler.StatusItems[1].Id;
            appointments.Add(appointment);
            return new DataObject(typeof(IEnumerable<AppointmentItem>), appointments);
        }

        bool IsGridRowAvailable(int rowHandler) {
            return grdPatients.GetRow(rowHandler) != null;
        }

        void View_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            startPoint = e.GetPosition(null);
            startDrag = IsGridRowAvailable(grdPatients.View.GetRowHandleByMouseEventArgs(e));
        }

        void View_PreviewMouseMove(object sender, MouseEventArgs e) {
            Point position = e.GetPosition(null);
            if (startDrag && e.LeftButton == MouseButtonState.Pressed) {
                int rowHandler = grdPatients.View.GetRowHandleByMouseEventArgs(e);
                if (IsGridRowAvailable(rowHandler)) {
                    startDrag = false;
                    DragDropEffects de = DragDrop.DoDragDrop(grdPatients, GetSchedulerData(rowHandler), DragDropEffects.All);
                }
            }
            this.startPoint = position;
        }
    }
}
