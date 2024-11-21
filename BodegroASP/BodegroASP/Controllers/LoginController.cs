using BodegroASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace BodegroASP.Controllers
{
    public class LoginController : Controller
    {
        // Example user with hashed password
        private static readonly List<LoginViewModel> Users = new List<LoginViewModel>
        {
            new LoginViewModel
            {
                Email = "user@example.com",
                Password = ComputeSha256Hash("securepassword123") // Pre-hashed password
            }
        };
        public IActionResult Login()
        {
            return View();
        }
       [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel request)
        {
            var user = Users.FirstOrDefault(u => u.Email == request.Email);
            if (user == null || user.Password != ComputeSha256Hash(request.Password))
            {
                return Unauthorized(new { success = false, message = "Invalid email or password." });
            }

            // Fake session handling for demonstration purposes
            HttpContext.Session.SetString("UserId", user.Email);

            return Ok(new { success = true, is2FAEnabled = false });
        }

        [HttpPost]
        public IActionResult Verify2FA([FromBody] TwoFactorViewModel request)
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { success = false, message = "Session expired. Please log in again." });
            }

            // Fake 2FA validation
            if (request.Code != "123456") // Replace with real 2FA logic
            {
                return Unauthorized(new { success = false, message = "Invalid 2FA code." });
            }

            return Ok(new { success = true });
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        public IActionResult PatientIndex()
        {
            return Ok("Welcome to the Patient Index!");
        }
    }
}
