using Domain.DTOConverter;
using Domain.Modules;
using Domain.ObjectConverter;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.Domain.ObjectConverter
{
    [TestClass]
    public class AdminConverterTest
    {
        [TestMethod]
        public void ObjectToDTO()
        {
            //Arrange
            AdminConverter converter = new AdminConverter();
            AdminDTO testdto = new AdminDTO { ID = 0,Name = "Test",Email = "Test" };

            //Act
            Admin test = converter.DTOToObject(testdto);

            //Assert
            Assert.AreEqual(test.ID, testdto.ID);
            Assert.AreEqual(test.Name, testdto.Name);
            Assert.AreEqual(test.Email, testdto.Email);
        }
    }
}
