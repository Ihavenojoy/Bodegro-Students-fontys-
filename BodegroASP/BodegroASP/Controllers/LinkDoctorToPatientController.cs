using BodegroASP.Models;
using DAL;
using Domain.Containers;
using Domain.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BodegroASP.Controllers
{
    public class LinkDoctorToPatientController : Controller
    {
        private readonly DoctorContainer dc;
        private readonly PatientContainer pc;
        public LinkDoctorToPatientController()
        {
            dc = new DoctorContainer(new DoctorDAL());
            pc = new PatientContainer(new PatientDAL());
        }
        public IActionResult LinkDoctorToPatient()
        {
            LinkDoctorToPatientViewModel model = new LinkDoctorToPatientViewModel();

            List<Doctor> allDoctors = dc.GetAllDoctors();
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

    }
}
