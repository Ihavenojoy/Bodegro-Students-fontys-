using BodegroASP.Models;
using DAL;
using Domain.Containers;
using Domain.Containers.UserFile;
using Domain.Containers.PatientFile;
using Domain.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BodegroASP.Controllers
{
    public class LinkDoctorToPatientController : Controller
    {
        private readonly UserContainer dc;
        private readonly PatientContainer pc;
        private readonly IConfiguration configuration;
        public LinkDoctorToPatientController()
        {
            dc = new UserContainer(new UserDAL(configuration));
            pc = new PatientContainer(new PatientDAL(configuration));
        }
        public IActionResult LinkDoctorToPatient()
        {
            LinkDoctorToPatientViewModel model = new LinkDoctorToPatientViewModel();

            //List<User> allDoctors = dc.GetAllUsers();
            //List<Patient> allPatients = pc.GetAllPatients();
            //
            //model.allDoctors = allDoctors.Select(d => new SelectListItem
            //{
            //    Value = d.ID.ToString(), 
            //    Text = d.Name            
            //}).ToList();
            //
            //model.allPatients = allPatients.Select(p => new SelectListItem
            //{
            //    Value = p.ID.ToString(), 
            //    Text = p.Name            
            //}).ToList();

            return View(model);
        }

    }
}
