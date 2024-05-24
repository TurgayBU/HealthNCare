using HealthNCare.Areas.Identity.Data;

namespace HealthNCare.Models
{
    public class Doctor
    {
        public string DoctorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<AppointmentDate> AppointmentDates { get; set; }
        public ICollection<AppointmentRecord> AppointmentRecords { get; set; }

    }
}