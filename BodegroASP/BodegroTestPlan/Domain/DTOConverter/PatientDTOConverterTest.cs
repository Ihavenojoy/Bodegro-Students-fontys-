using Domain.Converter;
using Domain.Enums;
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
    public class PatientDTOConverterTest
    {
        [TestMethod]
        public void ObjectToDTO()
        {
            //Arrange
            PatientConverter converter = new PatientConverter();
            Patient test = new Patient(2, "test", "test",6,"Test",54);

            //Act
            PatientDTO testdto = converter.ObjectToDTO(test);

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
