using Domain.DTOConverter;
using Domain.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.Domain.DTOConverter
{
    [TestClass]
    public class UserDTOConverterTest
    {
        [TestMethod]

        public void ObjectToDTO()
        {
            //Arrange
            UserDTOConverter converter = new UserDTOConverter();
            User test = new User(2,"test","test");

            //Act
            UserDTO testdto = converter.ObjectToDTO(test);

            //Assert
            Assert.AreEqual(test.ID,testdto.ID);
            Assert.AreEqual(test.Name,testdto.Name);
            Assert.AreEqual(test.Email,testdto.Email);

        }
    }
}
