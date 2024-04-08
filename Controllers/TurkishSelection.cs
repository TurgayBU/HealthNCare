using HealthNCare.Models;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
namespace HealthNCare.Controllers{

public class TurkishSelection : Controller
{
    public IActionResult Location()
    {
        return View();
    }

    public IActionResult Doctor()
    {
        return View();
    }
    public IActionResult Treatment()
    {
        return View();
    }
     public IActionResult Date(){
            return View();
        }
    public IActionResult Hospital(){
        return View();
    }
}

}