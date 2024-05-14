using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HealthNCare.Models;
using Microsoft.AspNetCore.Identity;

namespace HealthNCare.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Patients1 class
public class Patients1 : IdentityUser
{
    [PersonalData]
    [Column(TypeName ="nvarchar(100)")]
    public string FirstName { get; set; }
    [PersonalData]
    [Column(TypeName ="nvarchar(100)")]
    public string LastName { get; set; }
    [PersonalData]
    public int Age {get;set;}
    [PersonalData]
    public string Gender { get; set; }
    [PersonalData]
    public string BloodType{get;set;}
    [PersonalData]
    public int Height{get;set;}
    [PersonalData]
    public int Weight{get;set;}
    public ICollection<Location> Locations { get; set; } = new List<Location>();

}

