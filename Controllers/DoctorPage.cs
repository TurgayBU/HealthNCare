using Microsoft.AspNetCore.Mvc;

namespace HealthNCare.Controllers{
public class DoctorPageController : Controller
{
    public IActionResult DoctorPage(){
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Patient(){
        return View();
    }
}
}
