using Microsoft.AspNetCore.Mvc;

namespace BodegroASP.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
