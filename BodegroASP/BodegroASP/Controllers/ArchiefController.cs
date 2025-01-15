using Domain.Modules;
using Microsoft.AspNetCore.Mvc;
using Domain.Services;
using DAL;
using BodegroASP.Converters;
using BodegroASP.ViewConverter;
using Domain.Containers.PatientFile;
using Domain.Containers.ProtocolFile;
using Domain.Containers.SubscriptionFile;
using Domain.Containers.UserFile;

namespace BodegroASP.Controllers
{
    public class ArchiefController : BaseController
    {
        PatientConvertert PatientConverter { get; set; }
        ProtocolConvertert ProtocolConverter { get; set; }
        SubscriptionConvertert SubscriptionConverter { get; set; }
        UserConvertert UserConverter { get; set; }
        PatientContainer PatientContainer { get; set; }
        ProtocolContainer ProtocolContainer { get; set; }
        SubscriptionContainer SubscriptionContainer { get; set; }
        UserContainer UserContainer { get; set; }
        GetInactive GetInactive { get; set; }
        IConfiguration _configuration;
        public ArchiefController()
        {
            PatientDAL patientDAL = new(_configuration);
            ProtocolDAL protocolDAL = new(_configuration);
            StepDAL stepDAL = new(_configuration);
            UserDAL userDAL = new(_configuration);
            SubscriptionDAL subscriptionDAL = new(_configuration);
            GetInactive = new(patientDAL, protocolDAL, stepDAL, userDAL, subscriptionDAL);
            ProtocolContainer = new(protocolDAL, stepDAL);
            SubscriptionContainer = new(subscriptionDAL);
            UserContainer = new(userDAL);
            PatientContainer = new(patientDAL);
            PatientConverter = new();
            ProtocolConverter = new();
            SubscriptionConverter = new();
            UserConverter = new();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ArchiveerPatients()
        {
            List<Patient> patients = GetInactive.GetPatients();
            return View("Patients", PatientConverter.ListObjectToVieuw(patients));
        }

        public IActionResult ArchiveerProtocols()
        {
            List<Protocol> protocols = GetInactive.GetProtocols();
            return View("Protocols", ProtocolConverter.ListObjectToView(protocols));
        }
        public IActionResult ArchiveerSubscriptions()
        {
            List<Subscription> subscriptions = GetInactive.GetSubscriptions();
            return View("Subscriptions", SubscriptionConverter.ListObjectToView(subscriptions));
        }

        public IActionResult ArchiveerUsers()
        {
            List<User> users = GetInactive.GetUsers();
            return View("Users", UserConverter.ListObjectToVieuw(users));
        }
        public IActionResult ArchiveSubscription(int id)
        {
            if (SubscriptionContainer.SetActive(id))
            {
                TempData["Message"] = $"Subscription with ID {id} has been reactivated.";
            }
            else
            {
                TempData["Message"] = $"Subscription with ID {id} could not be reactivated.";
            }
            return RedirectToAction("Index");
        }
        public IActionResult ArchivePatient(int id)
        {
            if (PatientContainer.SetActive(id))
            {
                TempData["Message"] = $"Patient with ID {id} has been reactivated.";
            }
            else
            {
                TempData["Message"] = $"Patient with ID {id} could not be reactivated.";
            }
            return RedirectToAction("Index");
        }
        public IActionResult ArchiveUser(int id)
        {
            if (UserContainer.SetActive(id))
            {
                TempData["Message"] = $"User with ID {id} has been reactivated.";
            }
            else
            {
                TempData["Message"] = $"User with ID {id} could not be reactivated.";
            }
            return RedirectToAction("Index");
        }
        public IActionResult ArchiveProtocol(int id)
        {
            if (ProtocolContainer.SetActive(id))
            {
                TempData["Message"] = $"Protocol with ID {id} has been reactivated.";
            }
            else
            {
                TempData["Message"] = $"Protocol with ID {id} could not be reactivated.";
            }
            return RedirectToAction("Index");
        }
    }
}
