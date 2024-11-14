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
    public class ProtocolDTOConverterTest
    {
        [TestMethod]

        public void ObjectToDTO()
        {
            //Arrange
            ProtocolDTOConverter converter = new ProtocolDTOConverter();
            List<Step> steps = new List<Step>();
            Protocol test = new Protocol(6,"test", "test", steps, 6);

            //Act
            ProtocolDTO testdto = converter.ObjectToDTO(test);

            //Assert
            Assert.AreEqual(test.ID, testdto.ID);
            Assert.AreEqual(test.Name, testdto.Name);
            Assert.AreEqual(test.Description, testdto.Description);
            Assert.AreEqual(test.User_ID, testdto.User_ID);
        }
    }
}
