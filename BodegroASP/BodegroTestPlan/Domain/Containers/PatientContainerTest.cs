using Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using DAL;
using Domain.Containers.PatientFile;

namespace BodegroTestPlan.Domain.Containers
{
    [TestClass]
    public class PatientContainerTest
    {
        [TestMethod]

        public void AskAllPatientsOfUser()
        {
            //Arrange
            PatientDAL patient = new PatientDAL();
            PatientContainer Container = new PatientContainer(patient);
            User user = new User(5, "timo", "timoo",Regio.Ijsselland,1,true);

            //Act
            List<Patient> list = Container.GetPatientsOfUser((User)user);

            //Assert
            Assert.IsNotNull(list);
            foreach (Patient pat in list)
            {
                Assert.IsNotNull(pat);
            }
        }
    }
}
