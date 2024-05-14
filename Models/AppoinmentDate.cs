namespace HealthNCare.Models
{
    public class AppointmentDate
    {
        public string AppointmentDateId { get; set; }
        public DateTime Date { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public List<AppointmentTime> AppointmentTimes { get; set; }
    }
}