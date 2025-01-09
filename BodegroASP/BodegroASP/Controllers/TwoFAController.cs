﻿using Microsoft.AspNetCore.Mvc;
using BodegroASP.Models;
using Domain.Modules;
using Domain.Containers.TwoFactorFile;
using DAL.DAL_s;
using Interfaces;
using Domain.Containers.UserFile;

namespace BodegroASP.Controllers
{
    public class TwoFAController : Controller
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
            TwoFAViewModel model = new TwoFAViewModel()
            {
                input = "",
                UserID = Convert.ToInt32(HttpContext.Session.GetString("UserId"))
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
            _TwofactorContainer.Create(userID, _UserContainer.GetUserByID(userID).Email);
            TempData["ErrorMessage"] = "Has been sent" ;
            return RedirectToAction("Index");
        }
    }
}
