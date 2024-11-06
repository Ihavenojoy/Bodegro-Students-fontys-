using BLL.Modules;
using BLL.ObjectConverter;
using BodegroInterfaces;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.BLL_Test.BLL_Containers
{
    [TestClass]
    public class AdminContainerTest
    {
        [TestMethod]
        public void Login()
        {
            //Arrange
            string EmailInput = "dfgdg";
            string Passwordinput = "kghkg5@gf";
            AdminConverter AdminConverter = new AdminConverter();
            ILogin _InlogService = new LoginDal();

            //Act
            AdminDTO admindto = _InlogService.AdminLogin(EmailInput, Passwordinput);
            Admin adminacc = AdminConverter.DTOToObject(admindto);

            //Asstert
            Assert.AreEqual(admindto.Email, EmailInput);
            Assert.AreEqual(admindto.ID, adminacc.ID);
            Assert.AreEqual(admindto.Name, adminacc.Name);
            Assert.AreEqual(admindto.Email, adminacc.Email);
        }
    }
}
