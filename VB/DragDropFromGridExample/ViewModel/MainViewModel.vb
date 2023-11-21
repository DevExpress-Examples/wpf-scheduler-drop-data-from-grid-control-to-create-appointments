Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.POCO
Imports System
Imports System.Collections.ObjectModel

Namespace DragDropFromGridExample

    <POCOViewModel>
    Public Class MainViewModel

        Public Overridable Property Doctors As ObservableCollection(Of Doctor)

        Public Overridable Property Appointments As ObservableCollection(Of MedicalAppointment)

        Public Overridable Property Patients As ObservableCollection(Of Patient)

        Public Shared PatientNames As String() = {"Andrew Glover", "Mark Oliver", "Taylor Riley", "Addison Davis", "Benjamin Hughes", "Lucas Smith", "Robert King", "Laura Callahan", "Miguel Simmons", "Isabella Carter", "Andrew Fuller", "Madeleine Russell", "Steven Buchanan", "Nancy Davolio", "Michael Suyama", "Margaret Peacock", "Janet Leverling", "Ariana Alexander", "Brad Farkus", "Bart Arnaz", "Arnie Schwartz", "Billy Zimmer", "Samantha Piper", "Maggie Boxter", "Terry Bradley", "Greta Sims", "Cindy Stanwick", "Marcus Orbison", "Sandy Bright", "Ken Samuelson", "Brett Wade", "Wally Hobbs", "Brad Jameson", "Karen Goodson", "Morgan Kennedy", "Violet Bailey", "John Heart", "Arthur Miller", "Robert Reagan", "Ed Holmes", "Sammy Hill", "Olivia Peyton", "Jim Packard", "Hannah Brookly", "Harv Mudd", "Todd Hoffman", "Kevin Carter", "Mary Stern", "Robin Cosworth", "Jenny Hobbs", "Dallas Lou"}

        Private Shared rnd As Random = New Random()

        Protected Sub New()
            CreateDoctors()
            CreatePatients()
        End Sub

        Public Shared Function Create() As MainViewModel
            Return ViewModelSource.Create(Function() New MainViewModel())
        End Function

        Private Sub CreateDoctors()
            Doctors = New ObservableCollection(Of Doctor)()
            Doctors.Add(Doctor.Create(Id:=1, Name:="Stomatologist"))
            Doctors.Add(Doctor.Create(Id:=2, Name:="Ophthalmologist"))
            Doctors.Add(Doctor.Create(Id:=3, Name:="Surgeon"))
        End Sub

        Private Sub CreatePatients()
            Dim result As ObservableCollection(Of Patient) = New ObservableCollection(Of Patient)()
            Dim patientCount As Integer = PatientNames.Length
            Dim patientId As Integer = 1
            Dim birthday As Date = New DateTime(1975, 2, 5)
            For i As Integer = 0 To patientCount - 1
                Dim patient As Patient = Patient.Create()
                patient.Id = Math.Min(Threading.Interlocked.Increment(patientId), patientId - 1)
                patient.Name = PatientNames(i)
                patient.BirthDate = birthday.AddMonths(rnd.Next(1, 12)).AddYears(rnd.Next(0, 20))
                patient.Phone = "(" & rnd.Next(10, 99) & ") " & rnd.Next(100, 999) & "-" & rnd.Next(1000, 9999)
                result.Add(patient)
            Next

            Patients = result
        End Sub

        Private Function GenerateNineNumbers(ByVal rand As Random) As String
            Dim result As String = ""
            For i As Integer = 0 To 9 - 1
                result += rand.Next(9).ToString()
            Next

            Return result
        End Function
    End Class
End Namespace
