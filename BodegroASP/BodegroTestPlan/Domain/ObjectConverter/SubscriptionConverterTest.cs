using Domain.Converter;
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
    public class SubscriptionConverterTest
    {
        [TestMethod]

        public void DTOToObjectList()
        {
            //Arrange
            SubscriptionConverter converter = new SubscriptionConverter();
            PatientDTO patientDTO = new PatientDTO { User_ID = 6, Email = "Test", ID = 6, MedicalHistory = "Test", Name = "Test", PhoneNumber = 64};
            List<StepDTO> steps = new List<StepDTO>();
            ProtocolDTO protocolDTO = new ProtocolDTO {User_ID = 6, Name = "Test", ID = 6, Description = "Test", Steps = steps};
            SubscriptionDTO testdto = new SubscriptionDTO {StartDate = DateTime.Now, StepsTaken = 0};
            List<SubscriptionDTO> testlist = new List<SubscriptionDTO>();
            testlist.Add(testdto);
            testlist.Add(testdto);
            testlist.Add(testdto);
            testlist.Add(testdto);

            //Act
            List<Subscription> test = converter.ListDTOToListObject(testlist);

            //Assert
            for (int i = 0; i < testlist.Count; i++)
            {
                Assert.AreEqual(test[i].StartDate, testlist[i].StartDate);
                Assert.AreEqual(test[i].StepsTaken, testlist[i].StepsTaken);
            }
        }
    }
}
