using BodegroASP.Converters;
using BodegroASP.Models;
using BodegroASP.ViewConverter;
using DAL;
using Domain.Containers.PatientFile;
using Domain.Containers.ProtocolFile;
using Domain.Containers.StepFile;
using Domain.Containers.SubscriptionFile;
using Domain.Enums;
using Domain.Modules;
using Domain.Services;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace BodegroASP.Controllers
{
    public class PatientController : Controller
    {
        public PatientContainer _patientserver;
        public ProtocolContainer _protocolserver;
        public SubscriptionContainer _subscriptionserver;
        public StepContainer _stepserver;
        public GetProtocolForPatient GetProtocolForPatient;
        private readonly IConfiguration iConfiguration;
        private ProtocolConvertert ProtocolConverter = new ProtocolConvertert();
        private User user;
        private readonly PatientConvertert patientConverter = new PatientConvertert();
        private readonly SubscriptionConvertert subscriptionConverter = new SubscriptionConvertert(); 
        SearchService SearchService { get; set; }
        public PatientController()
        {
            _patientserver = new PatientContainer(new PatientDAL(iConfiguration));
            _protocolserver = new ProtocolContainer(new ProtocolDAL(iConfiguration), new StepDAL(iConfiguration));
            _subscriptionserver = new SubscriptionContainer(new SubscriptionDAL(iConfiguration));
            GetProtocolForPatient = new(new ProtocolDAL(iConfiguration), new StepDAL(iConfiguration));
            user = new User(1, "Tim", "timHaiwan", Role.Doctor, true);
            _stepserver = new(new StepDAL(iConfiguration));
            SearchService = new(new PatientDAL(iConfiguration), new SubscriptionDAL(iConfiguration));
        }
        public IActionResult Index()
        {
            List<Patient> templist = new List<Patient>();
            if ((int)user.Role == 1)
            {
                templist = _patientserver.GetAll();
            }
            else
            {
                templist = _patientserver.GetPatientsOfUser(user);
            }
            
            List<PatientViewModel> list = patientConverter.ListObjectToVieuw(templist);
            PatientFormViewModel model = new PatientFormViewModel()
            {
                Patients = list,
                Search = ""
            };
            return View(model);
        }

        public IActionResult AddProtocolPatient(PatientViewModel patient)
        {
            PatientViewModel Patient = patientConverter.ObjectToVieuw(_patientserver.GetPatient(patient.ID));
            List<ProtocolViewModel> list = ProtocolConverter.ListObjectToView(GetProtocolForPatient.GetProtocolForSubscriptions(_subscriptionserver.GetSubscriptionsOfPatiënt(Patient.ID)));
            var model = new AddProtocolPatientViewModel
            {
                Patient = Patient,
                Protocols = list
            };

            return View(model);
        }
        public IActionResult ViewSubscriptionsPatient(int patientid)
        {
            PatientViewModel patient = patientConverter.ObjectToVieuw(_patientserver.GetPatient(patientid));
            List<SubscriptionViewModel> list = subscriptionConverter.ListObjectToView(_subscriptionserver.GetSubscriptionsOfPatiënt(patientid));
            var model = new PatientSubscriptionsViewModel
            {
                Patient = patient,
                Subccriptions = list
            };

            return View(model);
        }
        public IActionResult ConfirmProtocolLinking(ConfirmProtocolLinkingViewModel temp) // subscription
        {
            if (temp.Patientid == 0 || temp.Protocolid == 0)
            {
                return NotFound("Patient or protocol ID is missing."); 
            }

            Patient patient = _patientserver.GetPatient(temp.Patientid);
            var protocol = _protocolserver.GetProtocolbyid(temp.Protocolid);

            var model = new SubscriptionViewModel
            {
                Patient = patientConverter.ObjectToVieuw(patient),
                Protocol = ProtocolConverter.ObjectToView(protocol),
                StartDate = temp.StartDate,
                StepsTaken = 0
            };
            return View(model);  // You can pass the model to a confirmation view
        }
        public IActionResult Search(PatientFormViewModel model)
        {
            if (model.Search != null && model.Search != "")
            {
                List<PatientViewModel> Patients = patientConverter.ListObjectToVieuw(SearchService.SearchPatient(model.Search, user));
                model.Patients = Patients;
                return View("Index", model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SaveSubscription([FromBody] ConfirmProtocolLinkingViewModel subscription)
        {
            if (subscription == null)
            {
                TempData["ErrorMessage"] = "Subscription was null";
                return RedirectToAction("Index");
            }

            if (subscription.Patientid == 0 || subscription.Protocolid == 0)
            {
                TempData["ErrorMessage"] = "Missing patient or protocol data";
                return RedirectToAction("Index");
            }

            // Retrieve the necessary entities from the database
            var patient = _patientserver.GetPatient(subscription.Patientid);
            var protocol = _protocolserver.GetProtocolbyid(subscription.Protocolid);

            // Save the subscription in the database
            _subscriptionserver.AddSubscription(protocol, patient, subscription.StartDate);

            TempData["SuccessMessage"] = "Subscription confirmed and saved successfully!";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteProtocol([FromBody] SubscriptionViewModel model)
        {
            if (_subscriptionserver.DeleteSubscription(model.ID))
            {
                return Ok();
            }
            else
            {
                TempData["ErrorMessage"] = "Subscriptie verwijderen mislukt";
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult VieuwSteps(int id)
        {
            List<Step> protocolSteps = _stepserver.GetStepsOfProtocol(id);
            List<StepViewModellook> steps = new List<StepViewModellook>();
            steps = protocolSteps.Select(step => new StepViewModellook
            {
                Name = step.Name,
                Description = step.Description,
                Order = step.Order,
                Interval = step.Interval,
                Test = step.Test,
                UserId = user.ID
            }).ToList();

            if (protocolSteps != null)
            {
                return PartialView("ProtocolSteps", steps);
            }

            TempData["ErrorMessage"] = "Protocol steps not found!";
            return RedirectToAction("PatientProtocols", new { patientId = id });
        }
    }
}
