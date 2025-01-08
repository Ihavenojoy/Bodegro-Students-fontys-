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
        public void GetPatientsOfUser()
        {
            //Arrange
            

            //Act
            

            //Assert


        }
        [TestMethod]
        public void GetPatient(int id)
        {
            //Arrange


            //Act


            //Assert


        }
        [TestMethod]
        public void GetPatientID(string email)
        {
            //Arrange


            //Act


            //Assert


        }
        [TestMethod]
        public void GetPatientIDOfUser(int id)
        {
            //Arrange


            //Act


            //Assert


        }
        [TestMethod]
        public void SetActive(int id)
        {
            //Arrange


            //Act


            //Assert


        }
        [TestMethod]
        public void GetInactivePatients()
        {
            //Arrange


            //Act


            //Assert


        }
        [TestMethod]
        public void GetAll()
        {
            //Arrange


            //Act


            //Assert


        }
    }
}
