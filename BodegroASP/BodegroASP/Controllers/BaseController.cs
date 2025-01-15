using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BodegroASP.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var UserRole = HttpContext.Session.GetString("UserRole");
            ViewBag.UserRole = UserRole;
            base.OnActionExecuting(context);
        }
    }
}
