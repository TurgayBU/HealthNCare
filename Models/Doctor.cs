namespace HealthNCare.Models
{
     public class Location
{
    public int LocationId { get; set; }
    public string Name { get; set; }
    // Other properties...
}
public class Hospital
{
    public int HospitalId { get; set; }
    public string Name { get; set; }
    // Other properties...
      public ICollection<Location> Locations{get; set;}
}

    public class Department
{
    public int DepartmentId { get; set; }
    public string NameEnglish { get; set; }
    public string NameTurkish{get;set;}
    public int LocationId { get;set;}
  public ICollection<Hospital>Hospitals{get;set;}
    // Other properties...
}


public class Doctor
{
    public int DoctorId { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public int HospitalId { get; set; }
    public int LocationId { get; set; }
    public Department Department { get; set;}
    // Other properties...
}

public class Appointment
{
    public int AppointmentId { get; set; }
    public DateTime Date { get; set; }

    // Foreign key
    public int DepartmentId { get; set; }

    // Navigation property
    public Department Department { get; set; }
}
}