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
        IConfiguration configuration { get; set; }
        public MailController()
        {
            MailConvertert = new();
            SubscriptionDAL subscriptionDAL = new(configuration);
            PatientDAL patientDAL = new(configuration);
            MailContainer = new(subscriptionDAL, patientDAL);
            User = new("Henk", "HenkvdPost@gmail.com", Role.User, true);
        }
        public IActionResult Index()
        {
            List<MailInfo> mailInfos;
            if (User.Role == Role.User)
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
            return View(mailViewModels);
        }
    }
}
