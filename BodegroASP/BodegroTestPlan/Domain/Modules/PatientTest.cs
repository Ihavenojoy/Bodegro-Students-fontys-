using BLL.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlan.BLL_Test.BLL_Modules
{
    [TestClass]
    public class PatientTest
    {
        [TestMethod]
        public void IDCheck()
        {
            //Arrange
            int i = 6;
            Patient patient = new Patient(6,"","",0,"",0);
            //ACT
            bool check = patient.IDCheck(6);
            //Assert
            Assert.IsTrue(check);
        }
    }
}
