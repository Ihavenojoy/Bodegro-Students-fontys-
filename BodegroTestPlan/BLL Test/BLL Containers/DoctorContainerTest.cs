using BLL.Modules;
using BodegroInterfaces;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Containers;

namespace BodegroTestPlan.BLL_Test.BLL_Containers
{
    [TestClass]
    public class DoctorContainerTest
    {
        [TestMethod]
        public void CreateDoctor()
        {
            //Arrange
            Doctor doctor = new Doctor("asdd", "dw", (BLL.Enums.Regio)18, 1, false);
            string password = "123";
            Doctor fakedoctor = new Doctor("Peter","Peter@gmail.com",BLL.Enums.Regio.Amsterdam,2,true);
            string fakepassword = "TestPassword";
            DoctorContainer doctorContainer = new DoctorContainer();

            //Act
            int fakecheckint = doctorContainer.CreateDoctor(fakedoctor, fakepassword);
            int checkint = doctorContainer.CreateDoctor(doctor, password);

            //Asstert
            Assert.AreEqual(fakecheckint, -1);
            Assert.AreEqual(checkint, doctor.ID);
        }
    }
}
