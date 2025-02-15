﻿using Domain.Converter;
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
    public class SubscriptionDTOConverterTest
    {
        [TestMethod]


        public void ObjectToDTO()
        {
            //Arrange
            SubscriptionConverter converter = new SubscriptionConverter();
            List<Step> Steps = new List<Step>();
            Protocol protocol = new Protocol("test", "test", Steps, 9);
            Patient patient = new Patient(6, "test", "test", 4, "test", 8);
            Subscription test = new Subscription(DateTime.Now, protocol, patient);

            //Act
            SubscriptionDTO testdto = converter.ObjectToDTO(test);

            //Assert
            Assert.AreEqual(test.StepsTaken, testdto.StepsTaken);
        }
    }
}
