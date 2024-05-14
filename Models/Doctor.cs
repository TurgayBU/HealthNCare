using HealthNCare.Models;
    public class Doctor
    {
        public string DoctorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<AppointmentDate> AppointmentDates { get; set; }
    }
