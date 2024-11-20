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
    public class ProtocolConverterTest
    {
        [TestMethod]
        public void ObjectToDTO()
        {
            //Arrange
            ProtocolConverter converter = new ProtocolConverter();
            List<StepDTO> steps = new List<StepDTO>();
            ProtocolDTO testdto = new ProtocolDTO { ID = 0, Name = "Test", Description = "Test", Steps = steps, User_ID = 8};

            //Act
            Protocol test = converter.DTOToObject(testdto);

            //Assert
            Assert.AreEqual(test.ID, testdto.ID);
            Assert.AreEqual(test.Name, testdto.Name);
            Assert.AreEqual(test.Description, testdto.Description);
            Assert.AreEqual(test.Steps.Count, testdto.Steps.Count);
            Assert.AreEqual(test.User_ID, testdto.User_ID);
        }

        [TestMethod]
        public void DTOToObjectList()
        {
            //Arrange
            ProtocolConverter converter = new ProtocolConverter();
            List<StepDTO> steps = new List<StepDTO>();
            ProtocolDTO testdto = new ProtocolDTO { ID = 0, Name = "Test", Description = "Test", Steps = steps, User_ID = 8 };
            List<ProtocolDTO> testlist = new List<ProtocolDTO>();
            testlist.Add(testdto);
            testlist.Add(testdto);
            testlist.Add(testdto);
            testlist.Add(testdto);

            //Act
            List<Protocol> test = converter.ListDTOToListObject(testlist);

            //Assert
            for (int i = 0; i < testlist.Count; i++)
            {
                Assert.AreEqual(test[i].ID, testlist[i].ID);
                Assert.AreEqual(test[i].Name, testlist[i].Name);
                Assert.AreEqual(test[i].Description, testlist[i].Description);
                Assert.AreEqual(test[i].Steps.Count, testlist[i].Steps.Count);
                Assert.AreEqual(test[i].User_ID, testlist[i].User_ID);
            }
        }
    }
}
