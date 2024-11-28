using BodegroASP.Converters;
using BodegroASP.Models;
using BodegroASP.ViewConverter;
using DAL;
using Domain.Containers.PatientFile;
using Domain.Containers.ProtocolFile;
using Domain.Containers.SubscriptionFile;
using Domain.Enums;
using Domain.Modules;
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
        private readonly IConfiguration iConfiguration;
        private ProtocolConverter ProtocolConverter = new ProtocolConverter();
        private User user;
        private readonly PatientConvertert patientConverter = new PatientConvertert();
        public PatientController()
        {
            _patientserver = new PatientContainer(new PatientDAL(iConfiguration));
            _protocolserver = new ProtocolContainer(new ProtocolDAL(iConfiguration), new StepDAL(iConfiguration));
            _subscriptionserver = new SubscriptionContainer(new SubscriptionDAL(iConfiguration));
            user = new User(1, "Tim", "timHaiwan", Role.Doctor, true);
        }
        public IActionResult Index()
        {
            List<Patient> templist = _patientserver.GetPatientsOfUser(user);
            List<PatientViewModel> list = patientConverter.ListObjectToVieuw(templist);
            return View(list);
        }

        public IActionResult AddProtocolPatient(PatientViewModel patient)
        {
            List<ProtocolViewModel> list = ProtocolConverter.ListObjectToView(_protocolserver.GetProtocols());
            var model = new AddProtocolPatientViewModel
            {
                Patient = patientConverter.ObjectToVieuw(_patientserver.GetPatientID(patient.Email)),
                Protocols = list
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

            // Redirect or render a confirmation view
            TempData["SuccessMessage"] = "Subscription confirmed and saved successfully!";
            return RedirectToAction("Index");
        }
    }
}
