using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HealthNCare.Areas.Identity.Data;

namespace HealthNCare.Models
{public class AppointmentRecord
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string Patients1Id { get; set; }

    public Patients1 Patients1 { get; set; }

    [Required]
    public string HospitalId { get; set; } // Hospital adını tutmak için
    public Hospital Hospital{get;set;}

    [Required]
    public string LocationId { get; set; } // Location adını tutmak için
    public Location Location{get;set;}
    [Required]
    public string DepartmentId { get; set; } // Department adını tutmak için
    public Department Department{get;set;}
    [Required]
    public string DoctorId { get; set; } // Doctor adını tutmak için
    public Doctor Doctor{get;set;}
  [Required]
    public string AppointmentDateId { get; set; }
    public AppointmentDate AppointmentDate { get; set; }

    [Required]
    public string AppointmentTimeId { get; set; }
    public AppointmentTime AppointmentTime { get; set; }
}

}
