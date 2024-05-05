using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Authentication;
using HealthNCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthNCare.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly PatientDbContext _context;

        public object UserVerificationCode1 { get; private set; }

        public TreatmentController(PatientDbContext context)
        {
            _context = context;
        }

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private void SendVerificationEmail(string emailAddress, string verificationCode)
        {
            try
            {
                // Set the SSL/TLS protocol version
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)(SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls);

                // Configure SMTP client for Gmail
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("healthncareappoitnmentsystem@gmail.com", "bYvmyb-kyccyp-vanme8"),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    TargetName = "smtp.gmail.com"
                };

                // Construct the email message
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("healthncareappoitnmentsystem@gmail.com"),
                    Subject = "Verification Code",
                    Body = $"Your verification code is: {verificationCode}",
                    IsBodyHtml = false
                };

                mailMessage.To.Add(emailAddress);

                // Send the email
                smtpClient.Send(mailMessage);
            }
            catch (SmtpException ex)
            {
                // Handle SMTP exceptions
                if (ex.StatusCode == SmtpStatusCode.MustIssueStartTlsFirst ||
                    ex.StatusCode == SmtpStatusCode.ClientNotPermitted ||
                    ex.StatusCode == SmtpStatusCode.TransactionFailed)
                {
                    Console.WriteLine("Failed to send verification email: The SMTP server requires a secure connection.");
                }
                else if (ex.StatusCode == SmtpStatusCode.GeneralFailure && ex.Message.Contains("5.7.0 Authentication Required"))
                {
                    Console.WriteLine("Failed to send verification email: Authentication failed. Please check your email address and password.");
                }
                else
                {
                    Console.WriteLine($"Failed to send verification email: {ex.Message}");
                }

                // Log the exception for debugging
                Console.WriteLine($"Exception details: {ex}");

                throw; // Rethrow the exception or handle it according to your application's requirements
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"Failed to send verification email: {ex.Message}");
                // Log the exception for debugging
                Console.WriteLine($"Exception details: {ex}");
                throw; // Rethrow the exception or handle it according to your application's requirements
            }
        }

        // Method to generate a verification code
        private string GenerateVerificationCode()
        {
            // Generate a random verification code
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var code = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            return code;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sign()
        {
            return View();
        }

        public IActionResult Apply()
        {
            return View();
        }

        public IActionResult Counter()
        {
            return View();
        }

        public IActionResult DoctorSign()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm] Patient model)
        {
            var verification = GenerateVerificationCode();
            UserVerificationCode1 = verification;
            SendVerificationEmail(model.Email, verification);
            return RedirectToAction("Verify", "Treatment");
        }

        public void SaveChangesOfData([FromForm] Patient model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public IActionResult SignAfterRe(Patient model)
        {
            return View(model);
        }

        public IActionResult Verify([FromForm] VerificationCode model)
        {

            if (UserVerificationCode1 == model.UserVerificationCode)
            {
                SaveChangesOfData();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private void SaveChangesOfData()
        {
            throw new NotImplementedException();
        }
    }
}
