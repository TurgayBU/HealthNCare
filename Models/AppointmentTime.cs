namespace HealthNCare.Models
{
    public class AppointmentTime
    {
        public string AppointmentTimeId { get; set; }
        public TimeSpan Time { get; set; }
        public string AppointmentDateId { get; set; }
        public AppointmentDate AppointmentDate { get; set; }
    }
}