using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using BodegroASP.Models;
using Domain.Modules;
using Domain.Containers.UserFile;
using Domain.Enums;

namespace BodegroASP.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserContainer userContainer;

        public AdminController(UserContainer userContainer)
        {
            this.userContainer = userContainer;
        }

        public IActionResult Index()
        {
            var Doctors = userContainer.GetAllUsers().Select(x => new UserViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Email = x.Email,
                Role = (int)x.Role,
                IsActive = x.IsActive
            }).ToList();
            return View(Doctors);
        }
        public IActionResult CreateDoctor()
        {
            var model = new UserViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateDoctor(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User(model.Name, model.Email, (Role)model.Role, true);
                string defaultPassword = "defaultPassword"; 
                userContainer.CreateUser(user, defaultPassword);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
