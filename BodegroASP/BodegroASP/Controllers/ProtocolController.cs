using BodegroASP.Models;
using DAL;
using Domain.Containers.ProtocolFile;
using Domain.Containers.StepFile;
using Domain.Modules;
using Microsoft.AspNetCore.Mvc;

namespace BodegroASP.Controllers
{
    public class ProtocolController : Controller
    {
        ProtocolContainer protocolContainer;
        StepContainer stepContainer;
        private readonly IConfiguration configuration;
        public ProtocolController()
        {
            protocolContainer = new(new ProtocolDAL(configuration), new StepDAL(configuration));
            stepContainer = new(new StepDAL(configuration));
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = new ProtocolViewModel
            {
                Steps = new List<StepViewModel>()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(ProtocolViewModel model)
        {
            var bookingSuccess = false;
            var StepCheck = true;
            foreach (var modelstep in model.Steps)
            {
                if (modelstep.Name == null || modelstep.Test == null || modelstep.Interval == 0 || modelstep.Description == null)
                {
                    StepCheck = false;
                }
            }
            if (StepCheck)
            {
                List<Step> steps = [];
                Protocol TempProtocol = new(model.Name, model.Description, steps, model.User_ID);
                bookingSuccess = protocolContainer.AddProtocol(TempProtocol);
            }
            if (bookingSuccess)
            {
                Protocol protocol = protocolContainer.GetProtocol(model.Name);
                foreach (var modelstep in model.Steps)
                {
                    Step step = new(protocol.ID, modelstep.Name, modelstep.Description, modelstep.Order, modelstep.Test, modelstep.Interval);
                    stepContainer.AddStep(step);
                }
                ViewData["SuccessMessage"] = "Protocol submitted successfully!";
                return RedirectToAction("Index");

            }
            ViewData["ErrorMessage"] = "There was an issue with your submission."; 
            return RedirectToAction("Index");
        }
    }
}
