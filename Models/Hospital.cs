using HealthNCare.Models;

public class Hospital
{
    public string HospitalId { get; set; }
    public string Name { get; set; }
    public string LocationId { get; set; }
    public Location Location { get; set; }
    public List<Department> Departments { get; set; }
}