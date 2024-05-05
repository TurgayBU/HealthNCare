using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HealthNCare.Models;
using Microsoft.AspNetCore.Identity;
using HealthNCare.Areas.Identity.Data;
namespace HealthNCare.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<Patients1> _userManager;

    public HomeController(ILogger<HomeController> logger,UserManager<Patients1> userManager)
    {
        _logger = logger;
        this._userManager = userManager;
    }

    public IActionResult Index()
    {
        ViewData["UserID"]=_userManager.GetUserId(this.User);
        return View();
    }

    
[HttpGet]
    public IActionResult Languages()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Language(Languages model)
    {
        if (ModelState.IsValid)
        {
            switch (model.Language)
            {
                case "Turkish":
                    // Redirect to the Turkish page
                    return RedirectToAction("Index","HomeT");
                case "English":
                    // Redirect to the English page
                    return RedirectToAction("Index","Home");
                default:
                    // Handle other languages if needed
                    break;
            }
        }

        // If ModelState is not valid, redirect back to the "Languages" action or view to display errors
        return RedirectToAction("Languages");
    }

    public IActionResult TurkishPage()
    {
        return View();
    }

    public IActionResult EnglishPage()
    {
        return View();
    }

    public IActionResult Private(){
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}
