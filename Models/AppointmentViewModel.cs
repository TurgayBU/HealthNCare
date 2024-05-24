namespace HealthNCare.Models;
public class AppointmentViewModel
{
    public List<AppointmentDate> AppointmentDates { get; set; }
    public List<AppointmentTime> AppointmentTimes { get; set; }
    public string SelectedDateId { get; set; }
    public string SelectedTimeId { get; set; }
    public string SelectedDate { get; set; }
    public string SelectedTime { get; set; }
    public string SelectedDoctor { get; set; }
    public string SelectedDepartment { get; set; }
    public string SelectedHospital { get; set; }
    public string SelectedLocation { get; set; }
}
