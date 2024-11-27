using Microsoft.AspNetCore.Mvc.Rendering;

namespace BodegroASP.Models
{
    public class LinkDoctorToPatientViewModel
    {
       public List<SelectListItem> allDoctors {  get; set; }
       public List<SelectListItem> allPatients { get; set; }

        public int SelectedDoctorID { get; set; }
        public int SelectedPatientID { get; set; }
    }
}
