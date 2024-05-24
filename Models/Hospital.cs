using HealthNCare.Areas.Identity.Data;

namespace HealthNCare.Models
{
    public class Hospital
    {
        public string HospitalId { get; set; }
        public string Name { get; set; }
        public string LocationId { get; set; }
        public Location Location { get; set; }
        public List<Department> Departments { get; set; }
        public ICollection<AppointmentRecord> AppointmentRecords { get; set; }
        
    }
}