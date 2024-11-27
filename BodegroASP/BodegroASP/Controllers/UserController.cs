using BodegroASP.Models;
using Domain.Containers.UserFile;
using Domain.Enums;
using Domain.Modules;
using Microsoft.AspNetCore.Mvc;

namespace BodegroASP.Controllers
{
    public class UserController : Controller
    {

        private readonly UserContainer userContainer;

        public UserController(UserContainer userContainer)
        {
            this.userContainer = userContainer;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<User> doctors = userContainer.GetAllUsers();
            List<UserViewModel> doctorViewModels = doctors.Select(x => new UserViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Email = x.Email,
                Role = (int)x.Role,
                IsActive = x.IsActive
            }).ToList();

            return View(doctorViewModels);
        }
        [HttpGet]
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
                var user = new User(model.Name, model.Email, (Role)2 , true);
                string defaultPassword = "defaultPassword";
                userContainer.CreateUser(user, defaultPassword);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = userContainer.GetUserByID(id);
            var model = new UserViewModel
            {
                ID = doctor.ID,
                Name = doctor.Name,
                Email = doctor.Email,
                Role = (int)doctor.Role,
                IsActive = doctor.IsActive
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteDoctor(UserViewModel model)
        {
            userContainer.DeleteUser(model.ID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateDoctor(int id)
        {
            var doctor = userContainer.GetUserByID(id);
            var model = new UserViewModel
            {
                ID = doctor.ID,
                Name = doctor.Name,
                Email = doctor.Email,
                Role = (int)doctor.Role,
                IsActive = doctor.IsActive
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateDoctor(UserViewModel model)
        {
            var doctor = userContainer.GetUserByID(model.ID);
            doctor.Name = model.Name;
            doctor.Email = model.Email;
            doctor.Role = (Role)2;
            doctor.IsActive = true;
            string defaultPassword = "defaultPassword"; // Add a default password or retrieve it from the model///
            userContainer.UpdateUser(doctor, defaultPassword);
            return RedirectToAction("Index");
        }

    }
}
