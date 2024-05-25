using HealthNCare.Areas.Identity.Data;
using HealthNCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using System.Linq;
public class AppointmentsController : Controller
{
    private readonly UserManager<Patients1> _userManager;
    private readonly AppDbContext _context;

    public AppointmentsController(AppDbContext context, UserManager<Patients1> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> SelectLocation()
    {
        var locations = await _context.Locations.ToListAsync();
        return View(locations);
    }

    [HttpPost]
    public IActionResult SelectLocation(string selectedLocationId)
    {
        TempData["SelectedLocation"] = selectedLocationId;
        return RedirectToAction("SelectHospital");
    }

    public async Task<IActionResult> SelectHospital()
    {
        var locationId = TempData["SelectedLocation"] as string;
        if (string.IsNullOrEmpty(locationId))
        {
            return RedirectToAction("SelectLocation");
        }

        TempData.Keep("SelectedLocation");

        var hospitals = await _context.Hospitals.Where(h => h.LocationId == locationId).ToListAsync();
        return View(hospitals);
    }

    [HttpPost]
    public IActionResult SelectHospital(string selectedHospitalId)
    {
        TempData["SelectedHospital"] = selectedHospitalId;
        return RedirectToAction("SelectDepartment");
    }

    public async Task<IActionResult> SelectDepartment()
    {
        var hospitalId = TempData["SelectedHospital"] as string;
        if (string.IsNullOrEmpty(hospitalId))
        {
            return RedirectToAction("SelectHospital");
        }

        TempData.Keep("SelectedHospital");
        TempData.Keep("SelectedLocation");

        var departments = await _context.Departments.Where(d => d.HospitalId == hospitalId).ToListAsync();
        return View(departments);
    }

    [HttpPost]
    public IActionResult SelectDepartment(string selectedDepartmentId)
    {
        TempData["SelectedDepartment"] = selectedDepartmentId;
        return RedirectToAction("SelectDoctor");
    }

    public async Task<IActionResult> SelectDoctor()
    {
        var departmentId = TempData["SelectedDepartment"] as string;
        if (string.IsNullOrEmpty(departmentId))
        {
            return RedirectToAction("SelectDepartment");
        }

        TempData.Keep("SelectedDepartment");
        TempData.Keep("SelectedHospital");
        TempData.Keep("SelectedLocation");

        var doctors = await _context.Doctors.Where(d => d.DepartmentId == departmentId).ToListAsync();
        return View(doctors);
    }

    [HttpPost]
    public IActionResult SelectDoctor(string selectedDoctorId)
    {
        TempData["SelectedDoctor"] = selectedDoctorId;
        return RedirectToAction("SelectDateTime");
    }

    public async Task<IActionResult> SelectDateTime()
    {
        var doctorId = TempData["SelectedDoctor"] != null ? TempData["SelectedDoctor"].ToString() : null;

        if (string.IsNullOrEmpty(doctorId))
        {
            return RedirectToAction("SelectDoctor");
        }

        TempData.Keep("SelectedDoctor");
        TempData.Keep("SelectedDepartment");
        TempData.Keep("SelectedHospital");
        TempData.Keep("SelectedLocation");

        var appointmentDates = await _context.AppointmentDates
            .Where(a => a.DoctorId == doctorId)
            .OrderBy(a => a.Date)
            .ToListAsync();

        if (appointmentDates.Count == 0)
        {
            return View("NoAppointments");
        }

        var appointmentTimes = await _context.AppointmentTimes
            .Where(t => appointmentDates.Select(d => d.AppointmentDateId).Contains(t.AppointmentDateId))
            .ToListAsync();

        appointmentTimes = appointmentTimes.OrderBy(t => t.Time).ToList();

        var viewModel = new AppointmentViewModel
        {
            AppointmentDates = appointmentDates,
            AppointmentTimes = appointmentTimes
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult SelectDateTime(AppointmentViewModel model)
    {
        TempData["SelectedDate"] = model.SelectedDateId;
        TempData["SelectedTime"] = model.SelectedTimeId;

        return RedirectToAction("ConfirmAppointment");
    }

 public IActionResult ConfirmAppointment()
{
    var selectedDateId = TempData.Peek("SelectedDate")?.ToString();
    var selectedTimeId = TempData.Peek("SelectedTime")?.ToString();

    if (string.IsNullOrEmpty(selectedDateId) || string.IsNullOrEmpty(selectedTimeId))
    {
        return RedirectToAction("SelectDateTime");
    }

    TempData.Keep("SelectedDate");
    TempData.Keep("SelectedTime");
    TempData.Keep("SelectedDoctor");
    TempData.Keep("SelectedDepartment");
    TempData.Keep("SelectedHospital");
    TempData.Keep("SelectedLocation");

    var selectedDate = _context.AppointmentDates.FirstOrDefault(d => d.AppointmentDateId == selectedDateId);
    var selectedTime = _context.AppointmentTimes.FirstOrDefault(t => t.AppointmentTimeId == selectedTimeId && t.AppointmentDateId == selectedDateId);
    var selectedDoctor = _context.Doctors.FirstOrDefault(d => d.DoctorId == TempData.Peek("SelectedDoctor").ToString());
    var selectedDepartment = _context.Departments.FirstOrDefault(d => d.DepartmentId == TempData.Peek("SelectedDepartment").ToString());
    var selectedHospital = _context.Hospitals.FirstOrDefault(h => h.HospitalId == TempData.Peek("SelectedHospital").ToString());
    var selectedLocation = _context.Locations.FirstOrDefault(l => l.LocationId == TempData.Peek("SelectedLocation").ToString());

    string selectedTimeFormatted = null;
    if (selectedTime != null)
    {
        try
        {
            selectedTimeFormatted = selectedTime.Time.ToString(@"hh\:mm");
        }
        catch (FormatException ex)
        {
            // Handle the format exception, log if necessary
            return RedirectToAction("Error");
        }
    }

    var viewModel = new ConfirmAppointmentViewModel
    {
        SelectedDateId = selectedDateId,
        SelectedTimeId = selectedTimeId,
        SelectedDoctorId = TempData.Peek("SelectedDoctor").ToString(),
        SelectedDepartmentId = TempData.Peek("SelectedDepartment").ToString(),
        SelectedHospitalId = TempData.Peek("SelectedHospital").ToString(),
        SelectedLocationId = TempData.Peek("SelectedLocation").ToString(),

        SelectedDate = selectedDate?.Date.ToString("yyyy-MM-dd"),
        SelectedTime = selectedTimeFormatted,
        SelectedDoctor = selectedDoctor?.Name,
        SelectedDepartment = selectedDepartment?.Name,
        SelectedHospital = selectedHospital?.Name,
        SelectedLocation = selectedLocation?.Name
    };

    return View(viewModel);
}

[HttpGet]
    public IActionResult GetAppointmentTimes(string dateId)
    {
        // Convert dateId to int or Guid based on your AppointmentDateId type
        // Retrieve appointment times for the selected date from your database
        var appointmentTimes = _context.AppointmentTimes
            .Where(t => t.AppointmentDateId == dateId)
            .Select(t => new { appointmentTimeId = t.AppointmentTimeId, time = t.Time.ToString(@"hh\:mm") })
            .ToList();

        return Json(appointmentTimes);
    }

    [HttpPost]
public async Task<IActionResult> SaveAppointment(ConfirmAppointmentViewModel model)
{
    if (model.SelectedHospitalId == null || model.SelectedLocationId == null || model.SelectedDepartmentId == null || model.SelectedDoctorId == null || model.SelectedDateId == null || model.SelectedTimeId == null)
    {
        return RedirectToAction("SelectLocation");
    }

    var selectedHospital = await _context.Hospitals.FirstOrDefaultAsync(h => h.HospitalId == model.SelectedHospitalId);
    var selectedLocation = await _context.Locations.FirstOrDefaultAsync(k => k.LocationId == model.SelectedLocationId);
    var selectedDepartment = await _context.Departments.FirstOrDefaultAsync(p => p.DepartmentId == model.SelectedDepartmentId);
    var selectedDoctor = await _context.Doctors.FirstOrDefaultAsync(u => u.DoctorId == model.SelectedDoctorId);
    var selectedAppointmentDate = await _context.AppointmentDates.FirstOrDefaultAsync(d => d.AppointmentDateId == model.SelectedDateId);
    var selectedAppointmentTime = await _context.AppointmentTimes.FirstOrDefaultAsync(t => t.AppointmentTimeId == model.SelectedTimeId && t.AppointmentDateId == model.SelectedDateId);

    if (selectedHospital != null && selectedLocation != null && selectedDepartment != null && selectedDoctor != null && selectedAppointmentDate != null && selectedAppointmentTime != null)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            var userId = user.Id;
            
            var appointmentRecord = new AppointmentRecord
            {
                Id = Guid.NewGuid().ToString(),
                Patients1Id = userId,
                HospitalId = selectedHospital.HospitalId,
                LocationId = selectedLocation.LocationId,
                DepartmentId = selectedDepartment.DepartmentId,
                DoctorId = selectedDoctor.DoctorId,
                AppointmentDateId = selectedAppointmentDate.AppointmentDateId,
                AppointmentTimeId = selectedAppointmentTime.AppointmentTimeId
            };

            _context.AppointmentRecords.Add(appointmentRecord);
            await _context.SaveChangesAsync(); // HospitalContext üzerinden kaydedin

            TempData["SuccessMessage"] = "Your Appoinment Successfully Added!";
            return RedirectToAction("Patientpage", "PatientPage");
        }
        else
        {
            return RedirectToAction("Error");
        }
    }

    return RedirectToAction("SelectLocation");
}
public IActionResult ListAppointments()
{
    var userId = _userManager.GetUserId(User); // Mevcut kullanıcı ID'sini alır
    var appointments = _context.AppointmentRecords
        .Include(a => a.Hospital)
        .Include(a => a.Location)
        .Include(a => a.Department)
        .Include(a => a.Doctor)
        .Include(a => a.AppointmentDate)
        .Include(a => a.AppointmentTime)
        .Where(a => a.Patients1Id == userId)
        .ToList();

    var viewModel = appointments.Select(a => new AppointmentViewModel
    {
        SelectedDate = a.AppointmentDate.Date.ToString("yyyy-MM-dd"),
        SelectedTime = a.AppointmentTime.Time.ToString(@"hh\:mm"),
        SelectedDoctor = a.Doctor.Name,
        SelectedDepartment = a.Department.Name,
        SelectedHospital = a.Hospital.Name,
        SelectedLocation = a.Location.Name
    }).ToList();

    return View(viewModel);
}


}
