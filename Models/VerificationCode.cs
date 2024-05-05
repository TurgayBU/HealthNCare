using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HealthNCare.Models{
    public class VerificationCode{
         public String? UserVerificationCode{get;set;}=String.Empty;
    }
}