using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using HealthNCare.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text;

namespace HealthNCare.Areas.Identity.Pages.Account
{
    public class VerifyCodeModelT : PageModel
    {
        private readonly UserManager<Patients1> _userManager;
        private readonly SignInManager<Patients1> _signInManager;
        private readonly ILogger<VerifyCodeModel> _logger;
        private readonly IEmailSender _emailSender;

        public VerifyCodeModelT(
            UserManager<Patients1> userManager,
            SignInManager<Patients1> signInManager,
            ILogger<VerifyCodeModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Code { get; set; }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/PatientPageT/PatientPage");

            if (Input.Code == TempData["ConfirmationCode"]?.ToString())
            {
                var user = JsonSerializer.Deserialize<Patients1>(TempData["User"]?.ToString());
                var password = TempData["Password"]?.ToString();
                var email = TempData["Email"]?.ToString();

                user.UserName = email;
                user.Email = email;

                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        TempData["Message"] = "Registration successful. Please check your email for verification instructions.";
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                TempData["Attempts"] = (int)(TempData["Attempts"] ?? 0) + 1;

                if ((int)TempData["Attempts"] >= 3)
                {
                    TempData["Message"] = "Too many attempts. Please try again.";
                    return RedirectToPage("Index");
                }

                ModelState.AddModelError(string.Empty, "Invalid confirmation code.");
            }

            return Page();
        }
    }
}
