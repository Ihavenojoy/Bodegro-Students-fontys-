using Domain.DTOConverter;
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
    public class DoctorDTOConverterTest
    {
        [TestMethod]
        public void ObjectToDTO()
        {
            //Arrange
            DoctorDTOConverter converter = new DoctorDTOConverter();
            Doctor test = new Doctor(2, "test", "test",Regio.Haaglanden,5,true);

            //Act
            DoctorDTO testdto = converter.ObjectToDTO(test);

            //Assert
            Assert.AreEqual(test.ID, testdto.ID);
            Assert.AreEqual(test.Name, testdto.Name);
            Assert.AreEqual(test.Email, testdto.Email);
            Assert.AreEqual(test.IsActive, testdto.IsActive);
            Assert.AreEqual((int)test.Regio, (int)testdto.Regio);
            Assert.AreEqual(test.Admin_ID, testdto.Admin_ID);
        }
    }
}
