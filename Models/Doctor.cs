namespace HealthNCare.Models
{
     public class Location
{
    public int LocationId { get; set; }
    public string Name { get; set; }=String.Empty;
    // Other properties...
}
    public class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public int LocationId { get;set;}
    // Other properties...
}

public class Hospital
{
    public int HospitalId { get; set; }
    public string Name { get; set; }
    // Other properties...
}

public class Doctor
{
    public int DoctorId { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public int HospitalId { get; set; }
    // Other properties...
}

public class Appointment
{
    public int AppointmentId { get; set; }
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }
    // Other properties...
}

}