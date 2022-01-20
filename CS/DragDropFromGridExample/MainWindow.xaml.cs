using DevExpress.Xpf.Core;
using DevExpress.Xpf.Scheduling;
using System.Linq;

namespace DragDropFromGridExample {
    public partial class MainWindow : ThemedWindow {
        public MainWindow() {
            InitializeComponent();
        }
        private void scheduler_StartAppointmentDragFromOutside(object sender, StartAppointmentDragFromOutsideEventArgs e) {
            if (e.Data.GetDataPresent(typeof(RecordDragDropData))) {
                var data = (RecordDragDropData)e.Data.GetData(typeof(RecordDragDropData));
                foreach (var x in data.Records.OfType<Patient>())
                    e.DragAppointments.Add(new AppointmentItem {
                        Subject = x.Name,
                        LabelId = scheduler.LabelItems.FirstOrDefault()?.Id,
                        StatusId = scheduler.StatusItems.FirstOrDefault()?.Id
                    });
            }
        }
    }
}