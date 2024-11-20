using BodegroASP.Converters;
using BodegroASP.Models;
using BodegroASP.ViewConverter;
using DAL;
using Domain.Containers.PatientFile;
using Domain.Containers.ProtocolFile;
using Domain.Containers.SubscriptionFile;
using Domain.Enums;
using Domain.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BodegroASP.Controllers
{
    public class PatientController : Controller
    {
        public PatientContainer _patientserver;
        public ProtocolContainer _protocolserver;
        private readonly IConfiguration iConfiguration;
        private ProtocolConverter ProtocolConverter = new ProtocolConverter();
        private User user;
        private readonly PatientConvertert patientConverter = new PatientConvertert();
        public PatientController()
        {
            _patientserver = new PatientContainer(new PatientDAL(iConfiguration));
            _protocolserver = new ProtocolContainer(new ProtocolDAL(iConfiguration), new StepDAL(iConfiguration));
            user = new User(1,"Tim","timHaiwan",Role.Doctor, true);
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

    }
}
