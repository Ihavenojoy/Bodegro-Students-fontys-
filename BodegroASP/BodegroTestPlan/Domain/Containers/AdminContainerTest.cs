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
    public class AdminContainerTest
    {
        [TestMethod]
        public void Login()
        {
            //Arrange
            AdminDAL adminDAL = new AdminDAL();
            AdminContainer adminContainer = new AdminContainer(adminDAL);
            string Emailinput = "Abed007";
            string PasswordInput = "1234";
            string WrongEmail = "432423";
            string WrongPassword = "52sdf-32";

            //Act
            Admin succesadmin = adminContainer.Login(Emailinput, PasswordInput);
            Admin failadmin = adminContainer.Login(WrongEmail, WrongPassword);
            //Assert

            Assert.IsNotNull(succesadmin);
            Assert.IsNull(failadmin.Name);
            Assert.IsNull(failadmin.Email);
        }
    }
}
