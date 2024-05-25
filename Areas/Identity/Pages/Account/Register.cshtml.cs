// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using HealthNCare.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HealthNCare.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Patients1> _signInManager;
        private readonly UserManager<Patients1> _userManager;
        private readonly IUserStore<Patients1> _userStore;
        private readonly IUserEmailStore<Patients1> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<Patients1> userManager,
            IUserStore<Patients1> userStore,
            SignInManager<Patients1> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name ="First Name")]
            public string FirstName { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name ="Last Name")]
            public string LastName { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name ="Gender")]
            public string Gender { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name ="BloodType")]
            public string BloodType { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name ="Age")]
            public int Age  { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name ="Height")]
            public int Height { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name ="Weight")]
            public int Weight { get; set; }
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            if(User.Identity.IsAuthenticated){
                Response.Redirect("~/PatientPage/PatientPage");
            }
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

   public async Task<IActionResult> OnPostAsync(string returnUrl = null)
{
    returnUrl ??= Url.Content("~/PatientPage/PatientPage");
    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
    
    if (ModelState.IsValid)
    {
        var user = CreateUser();
        user.FirstName = Input.FirstName;
        user.LastName = Input.LastName;
        user.Gender = Input.Gender;
        user.BloodType = Input.BloodType;
        user.Weight = Input.Weight;
        user.Height = Input.Height;
        user.Age = Input.Age;

        // Geçici olarak kullanıcının bilgilerini saklayın
        TempData["User"] = JsonConvert.SerializeObject(user);
        TempData["Password"] = Input.Password;
        TempData["Email"] = Input.Email;

        // Kullanıcıya onay kodu gönderin
        var confirmationCode = GenerateConfirmationCode();
        TempData["ConfirmationCode"] = confirmationCode;
        await _emailSender.SendEmailAsync(Input.Email, "Email Confirmation Code",
            $"Your confirmation code is: {confirmationCode}");

        // Kullanıcıyı doğrulama kodu gireceği sayfaya yönlendirin
        return RedirectToPage("/Account/VerifyCode", new { returnUrl });
    }

    // If we got this far, something failed, redisplay form
    return Page();
}

private string GenerateConfirmationCode()
{
    var random = new Random();
    return random.Next(100000, 999999).ToString(); // 6 haneli onay kodu üretir
}


        private Patients1 CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Patients1>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Patients1)}'. " +
                    $"Ensure that '{nameof(Patients1)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<Patients1> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<Patients1>)_userStore;
        }
    }
}
