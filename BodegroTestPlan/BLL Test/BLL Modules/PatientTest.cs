using BLL.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.BLL_Test.BLL_Modules
{
    public class PatientTest
    {
        public void IDCheck()
        {
            //Arange
            List<string> MedicalHistory = new List<string>();
            Patient patient = new Patient(25, "", "", 0, MedicalHistory, 0);
            Patient falsepatient = new Patient(15, "", "", 0, MedicalHistory, 0);

            //Act
            bool correct = patient.IDCheck(25);
            bool incorrect = patient.IDCheck(25);

            //Assert
            Assert.AreEqual(true, correct);
            Assert.AreEqual(false, incorrect);
        }
    }
}
