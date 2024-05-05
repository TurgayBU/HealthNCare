using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HealthNCare.Models
{
    public class Patient : IdentityUser
    {
        public int PatientId { get; set; }
        [Required(ErrorMessage ="Please fill the Email")]
         public String? Email { get; set; } = String.Empty;
        [Required(ErrorMessage ="Please enter your First name")]
         public String? FirstName {get;set;}=String.Empty;
        [Required(ErrorMessage ="Please enter your Second name")]
        public String? SecondName {get;set;}=String.Empty;
        public String? FullName=> $"{FirstName}{SecondName?.ToUpper()}";
        public int? Age{get;set;}
        [Required(ErrorMessage ="Please enter your Weight")]
        public int? Weight{get;set;}
        [Required(ErrorMessage ="Please enter your Height")]
        public int? Height{get;set;}
        
        [Required(ErrorMessage ="Please select your Bloodtype")]
        public String? BloodType{get;set;}=String.Empty;
        [Required(ErrorMessage ="Please enter your Password")]
        public String? Password{get;set;}=String.Empty;

       [Required(ErrorMessage ="Please enter your Gender")]
        public String? Gender=String.Empty;
       

    }
    
}