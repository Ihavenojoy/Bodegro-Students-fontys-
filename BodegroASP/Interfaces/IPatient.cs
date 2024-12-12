using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPatient
    {
        public bool CreatePatient(PatientDTO patient);
        public List<int> GetPatientIDOfUser(int id);
        public PatientDTO GetPatient(int id);
        public PatientDTO GetPatientID(string email);
        public List<PatientDTO> GetInactivePatients();
        public bool SetActive(int id);
    }
}
