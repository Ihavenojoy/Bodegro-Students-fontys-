using Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using DAL;
using Domain.Containers.UserFile;

namespace BodegroTestPlan.Domain.Containers
{
    [TestClass]
    public class UserContainerTest
    {
        [TestMethod]

        public void CreatUser()
        {
            //Arrange
            UserDAL Userdal = new UserDAL();
            UserContainer container = new UserContainer(Userdal);
            User User = new User(6,"","",Regio.Drente,0,false);
            string Password = "password";
            //Act
            int check = container.CreateUser(User, Password);
            //Assert
            Assert.AreEqual(-1, check);
        }

        [TestMethod]

        public void UserExist()
        {
            //Arrange
            UserDAL Userdal = new UserDAL();
            UserContainer container = new UserContainer(Userdal);
            string Usermail = "1";
            //Act
            bool check = container.UserExists(Usermail);
            //Assert
            Assert.IsFalse(check);
        }

        [TestMethod]

        public void DeleteUser()
        {
            //Arrange
            UserDAL Userdal = new UserDAL();
            UserContainer container = new UserContainer(Userdal);
            int UserId = 4;
            //Act
            bool check = container.DeleteUser(UserId);
            //Assert
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void GetAllUsers()
        {
            //Arrange
            UserDAL Userdal = new UserDAL();
            UserContainer container = new UserContainer(Userdal);
            //Act
            List<User> check = container.GetAllUsers();
            //Assert
            Assert.IsNotNull(check);
        }

        [TestMethod]
        public void Login()
        {
            //Arrange
            UserDAL Userdal = new UserDAL();
            UserContainer container = new UserContainer(Userdal);
            string Emailinput = "timoo";
            string PasswordInput = "Welkom01???";
            string WrongEmail = "432423";
            string WrongPassword = "52sdf-32";

            //Act
            User succesUser = container.Login(Emailinput, PasswordInput);
            User failUser = container.Login(WrongEmail, WrongPassword);
            //Assert

            Assert.IsNotNull(succesUser);
            Assert.IsNull(failUser.Name);
            Assert.IsNull(failUser.Email);
        }
    }
}
