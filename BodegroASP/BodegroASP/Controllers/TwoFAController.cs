using Microsoft.AspNetCore.Mvc;
using BodegroASP.Models;
using Domain.Modules;

namespace BodegroASP.Controllers
{
    public class TwoFAController : Controller
    {
        public IActionResult Index()
        {
            TwoFAViewModel model = new TwoFAViewModel()
            {
                input = "",
                UserID = 3
            };
            return View(model);
        }
        public IActionResult Check(TwoFAViewModel model)
        {
            if (model.input != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Index", model);
        }
        public IActionResult ReSend(int userID)
        {
            return RedirectToAction("Index");
        }
    }
}
