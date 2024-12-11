using BodegroASP.Models;
using BodegroASP.ViewConverter;
using DAL;
using Domain.Containers.SubscriptionFile;
using Domain.Modules;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BodegroASP.Controllers
{
    public class MailController : Controller
    {
        MailConvertert MailConvertert { get; set; }
        MailServices MailContainer { get; set; }
        IConfiguration configuration { get; set; }
        public MailController()
        {
            MailConvertert = new();
            SubscriptionDAL subscriptionDAL = new(configuration);
            MailContainer = new(subscriptionDAL);
        }
        public IActionResult Index()
        {
            List<MailInfo> mailInfos = MailContainer.GetNextMailDates();
            List<EmailViewModel> mailViewModels = MailConvertert.ListObjectToVieuw(mailInfos);
            return View(mailViewModels);
        }
    }
}
