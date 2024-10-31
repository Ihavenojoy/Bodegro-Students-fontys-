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
    public class StepConverterTest
    {
        [TestMethod]
        public void ObjectToDTO()
        {
            //Arrange
            StepConverter converter = new StepConverter();
            StepDTO testdto = new StepDTO { ID = 0, Name = "Test", Description = "Test", Interval = 6, Order = 5 , ProtocolID = 5, Test = "Test" };

            //Act
            Step test = converter.DTOToObject(testdto);

            //Assert
            Assert.AreEqual(test.ID, testdto.ID);
            Assert.AreEqual(test.Name, testdto.Name);
            Assert.AreEqual(test.Description, testdto.Description);
            Assert.AreEqual(test.Interval, testdto.Interval);
            Assert.AreEqual(test.Order, testdto.Order);
            Assert.AreEqual(test.ProtocolID, testdto.ProtocolID);
            Assert.AreEqual(test.Test, testdto.Test);
        }

        [TestMethod]
        public void DTOToObjectList()
        {
            //Arrange
            StepConverter converter = new StepConverter();
            StepDTO testdto = new StepDTO { ID = 0, Name = "Test", Description = "Test", Interval = 6, Order = 5, ProtocolID = 5, Test = "Test" };
            List<StepDTO> testlist = new List<StepDTO>();
            testlist.Add(testdto);
            testlist.Add(testdto);
            testlist.Add(testdto);
            testlist.Add(testdto);

            //Act
            List<Step> test = converter.ListDTOToListObject(testlist);

            //Assert
            for (int i = 0; i < testlist.Count; i++)
            {
                Assert.AreEqual(test[i].ID, testlist[i].ID);
                Assert.AreEqual(test[i].Name, testlist[i].Name);
                Assert.AreEqual(test[i].Description, testlist[i].Description);
                Assert.AreEqual(test[i].ProtocolID, testlist[i].ProtocolID);
                Assert.AreEqual(test[i].Order, testlist[i].Order);
                Assert.AreEqual(test[i].Test, testlist[i].Test);
                Assert.AreEqual(test[i].Interval, testlist[i].Interval);
            }
        }
    }
}
