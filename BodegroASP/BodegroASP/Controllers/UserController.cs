using Domain.Containers;
using Microsoft.AspNetCore.Mvc;

namespace BodegroASP.Controllers
{
    public class UserController : Controller
    {

        private readonly UserContainer _userContainer;

        public UserController(UserContainer userContainer)
        {
            _userContainer = userContainer;
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
