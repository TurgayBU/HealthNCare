using Microsoft.AspNetCore.Mvc;

namespace HealthNCare.Models{
    public class PatientPageController : Controller{
        public IActionResult PatientPage(){
            return View();
        }
        public IActionResult Privacy(){
            return View();
        }
    }
}