using BodegroASP.Models;
using DAL;
using Domain.Containers.PatientFile;


using Domain.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Containers.UserFile;

namespace BodegroASP.Controllers
{
    public class LinkDoctorToPatientController : Controller
    {
        private readonly UserContainer uc;
        private readonly PatientContainer pc;
        IConfiguration configuration;
        public LinkDoctorToPatientController()
        {
            uc = new UserContainer(new UserDAL(configuration));
            pc = new PatientContainer(new PatientDAL());
        }
        [HttpGet]
        public IActionResult LinkDoctorToPatient()
        {
            LinkDoctorToPatientViewModel model = new LinkDoctorToPatientViewModel();

            List<User> allDoctors = uc.GetAllUsers();
            List<Patient> allPatients = pc.GetAllPatients();

            model.allDoctors = allDoctors.Select(d => new SelectListItem
            {
                Value = d.ID.ToString(), 
                Text = d.Name            
            }).ToList();

            model.allPatients = allPatients.Select(p => new SelectListItem
            {
                Value = p.ID.ToString(), 
                Text = p.Name            
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult LinkDoctorToPatient(LinkDoctorToPatientViewModel model)
        {
            

            bool isDone = uc.LinkDoctorToPatient(model.SelectedDoctorID, model.SelectedPatientID);

            //temporary
            LinkDoctorToPatientViewModel Newmodel = new LinkDoctorToPatientViewModel();

            List<User> allDoctors = uc.GetAllUsers();
            List<Patient> allPatients = pc.GetAllPatients();

            Newmodel.allDoctors = allDoctors.Select(d => new SelectListItem
            {
                Value = d.ID.ToString(),
                Text = d.Name
            }).ToList();

            Newmodel.allPatients = allPatients.Select(p => new SelectListItem
            {
                Value = p.ID.ToString(),
                Text = p.Name
            }).ToList();

            return View(model);
        }

    }
}
