using HealthNCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
/*
namespace HealthNCare.Controllers{
    public class LocationController : Controller{
        private readonly LocationContext _location;
        public LocationController(LocationContext location){
            _location = location;
        }
        public async Task<IActionResult>Index(){
            var locations = await _location.Locations.ToListAsync();
            return View(locations);
        }
        public async Task<IActionResult>Details(string id){
            if (id==null){
                return NotFound();
            }
            var location1= await _location.Locations.FirstOrDefaultAsync(m=>m.LocationId==id);
            if(id==null){
                return NotFound();
            }
            return View(location1);
        }
    }


}*/