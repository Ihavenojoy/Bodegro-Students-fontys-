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
            if (model.Steps == null)
            {
                TempData["ErrorMessage"] = "Een protocol moet een step hebben";
                return View(model);
            }
            var bookingSuccess = false;
            var StepCheck = true;
            int TotalInterval = 0;
            foreach (var modelstep in model.Steps)
            {
                TotalInterval += modelstep.Interval;
                if (modelstep.Name == null || modelstep.Test == null || modelstep.Interval == 0 || modelstep.Description == null)
                {
                    StepCheck = false;
                    TempData["ErrorMessage"] = $"Step {modelstep.Order} was niet volledig ingevult";
                    return View(model);
                }
            }
            if (TotalInterval > 365)
            {
                TempData["ErrorMessage"] = "De totale interval ging boven het jaar uit";
                return View(model);
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
                TempData["SuccessMessage"] = "Protocol toegevoegd";
                return RedirectToAction("Index");

            }
            TempData["ErrorMessage"] = "Er is iets fout gegaan"; 
            return View(model);
        }
    }
}
