using BLL.Modules;
using Domain.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.Domain.Containers
{
    [TestClass]
    public class DoctorContainerTest
    {
        [TestMethod]

        public void CreatDoctor()
        {
            //Arrange
            DoctorContainer container = new DoctorContainer();
            Doctor doctor = new Doctor(6,"","",Regio.Drente,0,false);
            string Password = "password";
            //Act
            int check = container.CreateDoctor(doctor, Password);
            //Assert
            Assert.AreEqual(-1, check);
        }

        [TestMethod]

        public void DoctorExist()
        {
            //Arrange
            DoctorContainer container = new DoctorContainer();
            string doctormail = "1";
            //Act
            bool check = container.DoctorExists(doctormail);
            //Assert
            Assert.IsFalse(check);
        }

        [TestMethod]

        public void DeleteDoctor()
        {
            //Arrange
            DoctorContainer container = new DoctorContainer();
            int doctorId = 4;
            //Act
            bool check = container.DeleteDoctor(doctorId);
            //Assert
            Assert.IsFalse(check);
        }

        [TestMethod]
        public void GetAllDoctors()
        {
            //Arrange
            DoctorContainer container = new DoctorContainer();
            //Act
            List<Doctor> check = container.GetAllDoctors();
            //Assert
            Assert.IsNotNull(check);
        }

        [TestMethod]
        public void Login()
        {
            //Arrange
            DoctorContainer container = new DoctorContainer();
            string Emailinput = "timoo";
            string PasswordInput = "Welkom01???";
            string WrongEmail = "432423";
            string WrongPassword = "52sdf-32";

            //Act
            Doctor succesadmin = container.Login(Emailinput, PasswordInput);
            Doctor failadmin = container.Login(WrongEmail, WrongPassword);
            //Assert

            Assert.IsNotNull(succesadmin);
            Assert.IsNull(failadmin.Name);
            Assert.IsNull(failadmin.Email);
        }
    }
}
