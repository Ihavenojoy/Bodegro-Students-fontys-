using BodegroASP.Models;
using BodegroASP.ViewConverter;
using DAL;
using Domain.Containers.SubscriptionFile;
using Domain.Modules;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Enums;

namespace BodegroASP.Controllers
{
    public class MailController : Controller
    {
        MailConvertert MailConvertert { get; set; }
        MailServices MailContainer { get; set; }
        User User;
        SearchService SearchService { get; set; }
        IConfiguration configuration { get; set; }
        public MailController()
        {
            MailConvertert = new();
            SubscriptionDAL subscriptionDAL = new(configuration);
            PatientDAL patientDAL = new(configuration);
            SearchService = new(patientDAL, subscriptionDAL);
            MailContainer = new(subscriptionDAL, patientDAL);
            User = new("Henk", "HenkvdPost@gmail.com", Role.Admin, true);
        }
        public IActionResult Index()
        {
            List<MailInfo> mailInfos;
            if (User.Role == Role.Admin)
            {
                mailInfos = MailContainer.GetNextMailDates();
            }
            else if (User.Role == Role.Doctor)
            {
                mailInfos = MailContainer.GetNextMailDates(User);
            }
            else
            {
                mailInfos = [];
            }
            List<EmailViewModel> mailViewModels = MailConvertert.ListObjectToVieuw(mailInfos);
            MailFormViewModel mailFormViewModel = new MailFormViewModel()
            {
                Emails = mailViewModels,
                Search = ""
            };
            return View(mailFormViewModel);
        }
        [HttpPost]
        public IActionResult Search(MailFormViewModel model)
        {
            if (model.Search != null && model.Search != "")
            {
                List<EmailViewModel> mailInfos;
                if (User.Role == Role.Admin)
                {
                    mailInfos = MailConvertert.ListObjectToVieuw(SearchService.SearchMail(model.Search));
                }
                else if (User.Role == Role.Doctor)
                {
                    mailInfos = MailConvertert.ListObjectToVieuw(SearchService.SearchMail(model.Search, User));
                }
                else
                {
                    mailInfos = [];
                }
                model.Emails = mailInfos;
                return View("Index", model);
            }
            return RedirectToAction("Index");
        }
    }
}
