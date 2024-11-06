using Domain.Modules;
using Domain.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace BodegroTestPlan.Domain.Containers
{
    [TestClass]
    public class PatientContainerTest
    {
        [TestMethod]

        public void AskAllPatientsOfDoctor()
        {
            //Arrange
            PatientContainer Container = new PatientContainer();
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
