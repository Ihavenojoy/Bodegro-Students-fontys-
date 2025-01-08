using Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using DAL;
using Domain.Containers.PatientFile;
using Microsoft.Extensions.Configuration;

namespace BodegroTestPlan.Domain.Containers
{
    [TestClass]
    public class PatientContainerTest
    {
        PatientContainer container;
        IConfiguration configuration;
        [TestInitialize]
        public void Initialize()
        {
            PatientDAL patient = new PatientDAL(configuration);
            container = new PatientContainer(patient);
        }
        [TestMethod]
        public void AskAllPatientsOfUser()
        {
            //Arrange
            User user = new User(5, "timo", "timoo",(Role)1,true);

            //Act
            List<Patient> list = container.GetPatientsOfUser((User)user);

            //Assert
            Assert.IsNotNull(list);
            foreach (Patient pat in list)
            {
                Assert.IsNotNull(pat);
            }
        }
    }
}
