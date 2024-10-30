using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroInterfaces
{
    public interface IPatient
    {
        public int CreatePatient(PatientDTO patient);
        public List<int> GetPatientIDOfDoctor(int id);
        public PatientDTO GetPatient(int id, int DoctorID);
    }
}
