using Microsoft.AspNetCore.Mvc;
using BodegroASP.Models;
using Domain.Modules;
using Domain.Containers.TwoFactorFile;
using DAL.DAL_s;
using Interfaces;
using Domain.Containers.UserFile;

namespace BodegroASP.Controllers
{
    public class TwoFAController : BaseController
    {
        private TwoFactorContainer _TwofactorContainer;
        private UserContainer _UserContainer; 
        ITwoFactor Daltwofactor;
        IUser Daluser;
        public TwoFAController(ITwoFactor daltwofactor, IUser daluser)
        {
            Daltwofactor = daltwofactor;
            Daluser = daluser;
            _TwofactorContainer = new TwoFactorContainer(Daltwofactor);
            _UserContainer = new UserContainer(Daluser);
        }
        public IActionResult Index()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            TwoFAViewModel model = new TwoFAViewModel()
            {
                input = "",
                UserID = id
            };
            _TwofactorContainer.Remove(id);
            if (!_TwofactorContainer.Exist(id))
            {
                _TwofactorContainer.Create(id, _UserContainer.GetUserByID(id).Email);
            }
            _TwofactorContainer.Send(id, _UserContainer.GetUserByID(id).Email);
            return View(model);
        }
        public IActionResult Check(TwoFAViewModel model)
        {
            if (model.input != null)
            {
                if (_TwofactorContainer.check(model.UserID,model.input))
                {
                    TempData["ErrorMessage"] = "U bent succesvol ingelogd";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Verkeerde otp";
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
            _TwofactorContainer.Remove(userID);
            if (!_TwofactorContainer.Exist(userID))
            {
                _TwofactorContainer.Create(userID, _UserContainer.GetUserByID(userID).Email);
            }
            _TwofactorContainer.Send(userID, _UserContainer.GetUserByID(userID).Email);
            TempData["ErrorMessage"] = "Has been sent" ;
            return RedirectToAction("Index");
        }
    }
}
