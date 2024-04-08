using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HealthNCare.Models;
namespace HealthNCare.Controllers;

public class HomeTController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeTController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
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
