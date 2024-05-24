using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HealthNCare.Areas.Identity.Data;
using System.Threading.Tasks;

namespace HealthNCare.Controllers
{
    public class PatientPageTController : Controller
    {
        private readonly UserManager<Patients1> _userManager;

        public PatientPageTController(UserManager<Patients1> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Privacy()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                // Handle the case where the user is not found
                return NotFound();
            }
          /* if (user.LocationId==null){
                return View(user);
            }*/
            return View(user);
        }
        public IActionResult Patientpage(){
            return View();
        }
    }
}
