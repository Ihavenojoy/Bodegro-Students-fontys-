using Domain.Modules;
using Domain.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using DAL;

namespace BodegroTestPlan.Domain.Containers
{
    [TestClass]
    public class SubscriptionContainerTest
    {
        [TestMethod]

        public void Getpatients()
        {
            //Arrange
            Doctor doctor = new Doctor(6, "", "", Regio.Drente, 1, true);
            SubscriptionDAL subscriptionDAL = new SubscriptionDAL();
            PatientDAL patientDAL = new PatientDAL();
            ProtocolDAL protocolDAL = new ProtocolDAL();
            SubscriptionContainer container = new SubscriptionContainer(doctor, subscriptionDAL, patientDAL, protocolDAL);

            //Act
            List<Patient> patiens = container.GetPatients();

            //Assert
            foreach (Patient pat in patiens)
            {
                Assert.IsNotNull(pat.Name);
                Assert.IsNotNull(pat.Email);
                Assert.IsNotNull(pat.PhoneNumber);
            }
        }

        [TestMethod]
            public void GetProtocols()
        {
            //Arrange
            Doctor doctor = new Doctor(6, "", "", Regio.Drente, 1, true);
            SubscriptionDAL subscriptionDAL = new SubscriptionDAL();
            PatientDAL patientDAL = new PatientDAL();
            ProtocolDAL protocolDAL = new ProtocolDAL();
            SubscriptionContainer container = new SubscriptionContainer(doctor, subscriptionDAL, patientDAL, protocolDAL);

            //Act
            List<Protocol> list = container.GetProtocols();

            //Assert
            foreach (Protocol protocol in list)
            {
                Assert.IsNotNull(protocol.Name);
                Assert.IsNotNull(protocol.Description);
            }
        }

        [TestMethod]

        public void Datumcheck()
        {
            //Arrange
            DateTime currentime = DateTime.Now;
            DateTime Endtime = DateTime.Today;
            Doctor doctor = new Doctor(6, "", "", Regio.Drente, 1, true);
            SubscriptionDAL subscriptionDAL = new SubscriptionDAL();
            PatientDAL patientDAL = new PatientDAL();
            ProtocolDAL protocolDAL = new ProtocolDAL();
            SubscriptionContainer container = new SubscriptionContainer(doctor, subscriptionDAL, patientDAL,protocolDAL);

            //Act
            bool check1 = container.Datumcheck(currentime, Endtime);
            bool check2 = container.Datumcheck(Endtime, currentime);

            //Assert
            Assert.IsFalse(check1);
            Assert.IsTrue(check2);
        }
    }
}
