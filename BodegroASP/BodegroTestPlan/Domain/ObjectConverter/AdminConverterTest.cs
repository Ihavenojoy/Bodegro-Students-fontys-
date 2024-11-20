using Domain.Converters;
using Domain.DTOConverter;
using Domain.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.Domain.ObjectConverter
{
    [TestClass]
    public class UserConverterTest
    {
        [TestMethod]
        public void ObjectToDTO()
        {
            //Arrange
            UserConverter converter = new UserConverter();
            UserDTO testdto = new UserDTO { ID = 0,Name = "Test",Email = "Test" };

            //Act
            User test = converter.DTOToObject(testdto);

            //Assert
            Assert.AreEqual(test.ID, testdto.ID);
            Assert.AreEqual(test.Name, testdto.Name);
            Assert.AreEqual(test.Email, testdto.Email);
        }
    }
}
