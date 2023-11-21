using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.ObjectModel;

namespace DragDropFromGridExample {
    [POCOViewModel]
    public class MainViewModel {
        public virtual ObservableCollection<Doctor> Doctors { get; set; }
        public virtual ObservableCollection<MedicalAppointment> Appointments { get; set; }
        public virtual ObservableCollection<Patient> Patients { get; set; }

        public static string[] PatientNames = { "Andrew Glover", "Mark Oliver", "Taylor Riley", "Addison Davis", "Benjamin Hughes", "Lucas Smith",
                                                "Robert King", "Laura Callahan", "Miguel Simmons", "Isabella Carter", "Andrew Fuller", "Madeleine Russell",
                                                "Steven Buchanan", "Nancy Davolio", "Michael Suyama", "Margaret Peacock", "Janet Leverling", "Ariana Alexander",
                                                "Brad Farkus", "Bart Arnaz", "Arnie Schwartz", "Billy Zimmer", "Samantha Piper", "Maggie Boxter",
                                                "Terry Bradley", "Greta Sims", "Cindy Stanwick", "Marcus Orbison",
                                                "Sandy Bright", "Ken Samuelson", "Brett Wade", "Wally Hobbs", "Brad Jameson", "Karen Goodson",
                                                "Morgan Kennedy", "Violet Bailey", "John Heart", "Arthur Miller", "Robert Reagan",
                                                "Ed Holmes", "Sammy Hill", "Olivia Peyton", "Jim Packard", "Hannah Brookly", "Harv Mudd",
                                                "Todd Hoffman", "Kevin Carter","Mary Stern", "Robin Cosworth","Jenny Hobbs", "Dallas Lou"};

        static Random rnd = new Random();

        protected MainViewModel() {
            CreateDoctors();
            CreatePatients();
        }

        public static MainViewModel Create() {
            return ViewModelSource.Create(() => new MainViewModel());
        }

        private void CreateDoctors() {
            Doctors = new ObservableCollection<Doctor>();
            Doctors.Add(Doctor.Create(Id: 1, Name: "Stomatologist"));
            Doctors.Add(Doctor.Create(Id: 2, Name: "Ophthalmologist"));
            Doctors.Add(Doctor.Create(Id: 3, Name: "Surgeon"));
        }

        void CreatePatients() {
            ObservableCollection<Patient> result = new ObservableCollection<Patient>();
            int patientCount = PatientNames.Length;
            int patientId = 1;
            DateTime birthday = new DateTime(1975, 2, 5);
            for (int i = 0; i < patientCount; i++) {
                Patient patient = Patient.Create();
                patient.Id = patientId++;
                patient.Name = PatientNames[i];
                patient.BirthDate = birthday.AddMonths(rnd.Next(1, 12)).AddYears(rnd.Next(0, 20));
                patient.Phone = "(" + rnd.Next(10, 99) + ") " + rnd.Next(100, 999) + "-" + rnd.Next(1000, 9999);
                result.Add(patient);
            }
            Patients = result;
        }

        private string GenerateNineNumbers(Random rand) {
            string result = "";
            for (int i = 0; i < 9; i++) {
                result += rand.Next(9).ToString();
            }
            return result;
        }
    }
}
