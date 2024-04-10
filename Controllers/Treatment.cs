using HealthNCare.Models;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace HealthNCare.Controllers
{
    public class TreatmentController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }
        public IActionResult Sign(){
            return  View();
        }
        public IActionResult Apply() 
        {
            return View();
        }
        public IActionResult Counter(){
             return View();
        }
        public IActionResult DoctorSign(){
            return View();
        }
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm]Patient model){
            if (Care.Applications.Any(c => c.Email.Equals(model.Email)))
            {
                ModelState.AddModelError("", "There is already an applications");
            }
            if (ModelState.IsValid){
                    Care.Add(model);
            return View("SignAfterRe",model);
            }
            return View();
        }
    }
}