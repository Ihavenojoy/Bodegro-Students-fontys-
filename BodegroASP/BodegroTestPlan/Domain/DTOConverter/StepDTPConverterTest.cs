using Domain.Converter;
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
    public class StepDTPConverterTest
    {
        [TestMethod]

        public void ObjectToDTO()
        {
            //Arrange
            StepConverter converter = new StepConverter();
            Step test = new Step(6,6,"test", "test", 6,"Test",6);

            //Act
            StepDTO testdto = converter.ObjectToDTO(test);

            //Assert
            Assert.AreEqual(test.ID, testdto.ID);
            Assert.AreEqual(test.Name, testdto.Name);
            Assert.AreEqual(test.Description, testdto.Description);
            Assert.AreEqual(test.ProtocolID, testdto.ProtocolID);
            Assert.AreEqual(test.Order, testdto.Order);
            Assert.AreEqual(test.Test, testdto.Test);
            Assert.AreEqual(test.Interval, testdto.Interval);

        }
    }
}
