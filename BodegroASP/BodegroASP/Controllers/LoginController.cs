using BodegroASP.Models;
using Domain.Containers.UserFile;
using Domain.Modules;
using Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BodegroASP.Controllers
{
    public class LoginController : BaseController
    {
        private readonly UserContainer _userContainer;

        public LoginController(UserContainer userContainer)
        {
            _userContainer = userContainer;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(vm);

                var user = _userContainer.UserLogin(vm.Email, vm.Password);
                if (user == null)
                {
                    ModelState.AddModelError("LoginFailed", "Invalid username or password.");
                    return View(vm);
                }

                await SignInUser(user);
                HttpContext.Session.SetString("UserId", user.ID.ToString());
                HttpContext.Session.SetString("UserName", user.Name.ToString());
                HttpContext.Session.SetString("UserRole", user.Role.ToString());
                return RedirectToAction("Index", "TwoFA");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An unexpected error occurred. Please try again.");
                return View(vm);
            }



        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("UserRole");
            return RedirectToAction("LogIn");
        }

        private async Task SignInUser(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            // Add more claims as necessary
        };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("CookieAuth", principal);

        }
    }
}
