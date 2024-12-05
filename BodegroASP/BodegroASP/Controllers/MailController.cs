using Microsoft.AspNetCore.Mvc;

namespace BodegroASP.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
