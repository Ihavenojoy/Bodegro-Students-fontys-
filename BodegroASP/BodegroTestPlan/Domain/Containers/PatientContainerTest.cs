using BLL.Modules;
using DAL;
using Domain.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.Domain.Containers
{
    [TestClass]
    public class PatientContainerTest
    {
        [TestMethod]

        public void AskAllPatientsOfDoctor()
        {
            //Arrange
            PatientDAL patientDAL = new PatientDAL();
            PatientContainer Container = new PatientContainer(patientDAL);
            User user = new Doctor(5, "timo", "timoo",Regio.Ijsselland,1,true);

            //Act
            List<Patient> list = Container.AskAllPatientsOfDoctor(user);

            //Assert
            Assert.IsNotNull(list);
            foreach (Patient pat in list)
            {
                Assert.IsNotNull(pat);
            }
        }
    }
}
