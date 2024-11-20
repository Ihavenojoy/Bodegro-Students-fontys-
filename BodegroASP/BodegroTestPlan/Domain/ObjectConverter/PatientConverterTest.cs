using Domain.Converters;
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
    public class PatientConverterTest
    {
        [TestMethod]
        public void ObjectToDTO()
        {
            //Arrange
            PatientConverter converter = new PatientConverter();
            PatientDTO testdto = new PatientDTO { ID = 0, Name = "Test", Email = "Test", PhoneNumber = 3, MedicalHistory = "Test", User_ID = 8 };

            //Act
            Patient test = converter.DTOToObject(testdto);

            //Assert
            Assert.AreEqual(test.ID, testdto.ID);
            Assert.AreEqual(test.Name, testdto.Name);
            Assert.AreEqual(test.Email, testdto.Email);
            Assert.AreEqual(test.PhoneNumber, testdto.PhoneNumber);
            Assert.AreEqual(test.MedicalHistory, testdto.MedicalHistory);
            Assert.AreEqual(test.User_ID, testdto.User_ID);
        }
    }
}
