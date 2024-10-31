﻿using BLL.Modules;
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
    public class DoctorContainerTest
    {
        [TestMethod]

        public void CreatDoctor()
        {
            //Arrange
            DoctorDAL doctorDAL = new DoctorDAL();
            DoctorContainer container = new DoctorContainer(doctorDAL);
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
            DoctorDAL doctorDAL = new DoctorDAL();
            DoctorContainer container = new DoctorContainer(doctorDAL);
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
            DoctorDAL doctorDAL = new DoctorDAL();
            DoctorContainer container = new DoctorContainer(doctorDAL);
            int doctorId = 4;
            //Act
            bool check = container.DeleteDoctor(doctorId);
            //Assert
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void GetAllDoctors()
        {
            //Arrange
            DoctorDAL doctorDAL = new DoctorDAL();
            DoctorContainer container = new DoctorContainer(doctorDAL);
            //Act
            List<Doctor> check = container.GetAllDoctors();
            //Assert
            Assert.IsNotNull(check);
        }

        [TestMethod]
        public void Login()
        {
            //Arrange
            DoctorDAL doctorDAL = new DoctorDAL();
            DoctorContainer container = new DoctorContainer(doctorDAL);
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
