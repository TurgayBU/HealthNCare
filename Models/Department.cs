using HealthNCare.Areas.Identity.Data;

namespace HealthNCare.Models
{
    public class Department
    {
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public List<Doctor> Doctors { get; set; }
        public ICollection<AppointmentRecord> AppointmentRecords { get; set; }

    }
}