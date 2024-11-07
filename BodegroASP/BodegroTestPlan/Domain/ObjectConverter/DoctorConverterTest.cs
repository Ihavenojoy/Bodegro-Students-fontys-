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
    public class DoctorConverterTest
    {
        [TestMethod]
        public void ObjectToDTO()
        {
            //Arrange
            DoctorConverter converter = new DoctorConverter();
            DoctorDTO testdto = new DoctorDTO { ID = 0, Name = "Test", Email = "Test", Regio = 3 , Admin_ID = 2, IsActive = true};

            //Act
            Doctor test = converter.DTOToObject(testdto);

            //Assert
            Assert.AreEqual(test.ID, testdto.ID);
            Assert.AreEqual(test.Name, testdto.Name);
            Assert.AreEqual(test.Email, testdto.Email);
            Assert.AreEqual((int)test.Regio, (int)testdto.Regio);
            Assert.AreEqual(test.Admin_ID, testdto.Admin_ID);
            Assert.AreEqual(test.IsActive, testdto.IsActive);
        }
    }
}
