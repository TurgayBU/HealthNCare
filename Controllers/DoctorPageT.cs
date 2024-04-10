using Microsoft.AspNetCore.Mvc;

namespace HealthNCare.Controllers{
public class DoctorPageTController : Controller
{
    public IActionResult Doctorpage(){
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

}
}
