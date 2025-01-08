using Microsoft.AspNetCore.Mvc;
using BodegroASP.Models;
using Domain.Modules;
using Domain.Containers.TwoFactorFile;
using DAL.DAL_s;
using Interfaces;

namespace BodegroASP.Controllers
{
    public class TwoFAController : Controller
    {
        private TwoFactorContainer _TwofactorContainer;
        ITwoFactor Dal;
        public TwoFAController(ITwoFactor dal)
        {
            Dal = dal;
            _TwofactorContainer = new TwoFactorContainer(Dal);
        }
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
            _TwofactorContainer.Create(userID);
            TempData["ErrorMessage"] = "Has been sent" ;
            return RedirectToAction("Index");
        }
    }
}
