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
                Patient = patient,
                Protocols = list
            };

            return View(model);
        }
        public IActionResult ConfirmProtocolLinking(ConfirmProtocolLinkingViewModel temp)
        {
            if (temp.Patient == 0 || temp.Protocol == 0)
            {
                return NotFound("Patient or protocol ID is missing.");
            }

            Patient patient = _patientserver.GetPatient(temp.Patient);
            var protocol = _protocolserver.GetProtocolbyid(temp.Protocol);

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
        public IActionResult SaveSubscription(int patientId, int protocolId, DateTime startDate, int stepsTaken)
        {
            if (patientId == 0 || protocolId == 0)
            {
                return BadRequest("Missing patient or protocol data.");
            }

            // Retrieve the necessary entities from the database
            var patient = _patientserver.GetPatient(patientId);
            var protocol = _protocolserver.GetProtocolbyid(protocolId);

            // Save the subscription in the database
            _subscriptionserver.AddSubscription(protocol, patient, startDate);

            // Redirect or render a confirmation view
            TempData["SuccessMessage"] = "Subscription confirmed and saved successfully!";
            return RedirectToAction("Index");  // Or redirect to a confirmation page
        }
    }
}
