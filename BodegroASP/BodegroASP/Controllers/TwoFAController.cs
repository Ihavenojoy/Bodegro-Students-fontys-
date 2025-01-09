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
<<<<<<< Updated upstream
        ITwoFactor Dal;
        public TwoFAController(ITwoFactor dal)
=======
        private Twofactor
        private UserContainer _UserContainer; 
        ITwoFactor Daltwofactor;
        IUser Daluser;
        public TwoFAController(ITwoFactor daltwofactor, IUser daluser)
>>>>>>> Stashed changes
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
                if(_TwofactorContainer.check(model.UserID,model.input))
                {
                    TempData["ErrorMessage"] = "Succesvol ingelogd";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Onjuist OTP";
                    return View("Index", model);
                }
                
            }
            else
            {
                TempData["ErrorMessage"] = "Vul het veld in";
                return View("Index", model);
            }
        }
        public IActionResult ReSend(int userID)
        {
<<<<<<< Updated upstream
            _TwofactorContainer.Create(userID);
=======
            if (_TwofactorContainer.Exist(userID))
            {
                _TwofactorContainer.Create(userID, _UserContainer.GetUserByID(userID).Email, DateTime.Now);
            }
>>>>>>> Stashed changes
            TempData["ErrorMessage"] = "Has been sent" ;
            return RedirectToAction("Index");
        }
    }
}
