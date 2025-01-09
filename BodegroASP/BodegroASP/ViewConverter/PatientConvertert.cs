using BodegroASP.Models;
using Domain.Modules;

namespace BodegroASP.Converters
{
    public class PatientConvertert
    {
        public List<PatientViewModel> ListObjectToVieuw(List<Patient> patients)
        {
            List<PatientViewModel> list = new List<PatientViewModel>();
            foreach (Patient patient in patients)
            {
                PatientViewModel temp = new PatientViewModel()
                {
                    Email = patient.Email,
                    MedicalHistory = patient.MedicalHistory,
                    Name = patient.Name,
                    PhoneNumber = patient.PhoneNumber
                };
                list.Add(temp);
            }
            return list;
        }
    }
}
