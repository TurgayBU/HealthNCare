/*using HealthNCare.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HealthNCare.Controllers
{
    class RandevuController:Controller{
        public readonly AppointmentRecord _appointmentRecord;
        public readonly AppointmentViewModel _appointmentViewModel;
        public readonly Patients1 _patients1;

        public RandevuController(AppointmentRecord appointmentRecord,AppointmentViewModel appointmentViewModel,Patients1 patients1){
            _appointmentRecord = appointmentRecord;
            _appointmentViewModel = appointmentViewModel;
            _patients1=patients1;
        }
        public IActionResult RandevuListele(){
            return View(_appointmentRecord);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı kimliğini al
                var userId = (_patients1);

                if (userId == null)
                {
                    // Kullanıcı kimliği null ise, bir hata mesajı göster veya kullanıcıyı login sayfasına yönlendir
                    ModelState.AddModelError("", "User ID cannot be null. Please log in.");
                    return RedirectToAction("Login", "Account");
                }

                var appointmentRecord = new AppointmentRecord
                {
                    UserId = userId,
                    Hospital = model.SelectedHospital,
                    Department = model.SelectedDepartment,
                    Doctor = model.SelectedDoctor,
                    Location = model.SelectedLocation,
                    Date = model.Date,
                    Time = model.Time
                };
                _patients1DbContext.AppointmentRecords.Add(appointmentRecord);
                await _patients1DbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            // Model geçerli değilse, formu tekrar göster
            return View(model);
        }        public Task<IActionResult>Input(){

        }
    }
}*/