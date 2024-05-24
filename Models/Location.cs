using HealthNCare.Areas.Identity.Data;
using Microsoft.Build.Framework;
namespace HealthNCare.Models
{

    public class Location
{
    
    public string LocationId { get; set; }
    public string Name { get; set; }
    public List<Hospital>Hospitals{get;set;}
    public ICollection<AppointmentRecord> AppointmentRecords { get; set; }
}


}

