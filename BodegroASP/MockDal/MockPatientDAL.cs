using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDal
{
    public class MockPatientDAL
    {
        public object check;
        public List<Object> checklist;
        public bool CreatePatient(PatientDTO patient)
        {
            if (patient != null)
            {
                check = patient;
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<int> GetPatientIDOfUser(int id)
        {
            Random r = new Random();
            List<int> list = new List<int>();
            for (int i =id; id > 0; id--)
            {
                list.Add(r.Next(0,100));
            }
            checklist = (List<object>)list.Cast<object>();
            return list;
        }
        public PatientDTO GetPatient(int id, int UserID)
        {
            PatientDTO patientDTO = new PatientDTO {ID = id, Email = "TestMail", User_ID = UserID, MedicalHistory = "TestHistory", Name = "Test", PhoneNumber = 78654757};
            return patientDTO;
        }
    }
}
