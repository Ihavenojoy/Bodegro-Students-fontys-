using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Modules;
using DTO;
using Domain.Containers.PatientFile;
using System;
using System.Collections.Generic;
using UnitTest.MockDAL;

namespace UnitTest.PatientContainerTests
{
    [TestClass]
    public class PatientContainerTests
    {
        private PatientenContainerTestMockDAL mockDAL;
        private PatientContainer patientContainer;

        [TestInitialize]
        public void Setup()
        {
            mockDAL = new PatientenContainerTestMockDAL();
            patientContainer = new PatientContainer(mockDAL);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PatientContainer_ShouldThrowArgumentNullException_WhenDALIsNull()
        {
            new PatientContainer(null);
        }

        [TestMethod]
        public void GetPatientsOfUser_ShouldReturnEmptyList_WhenUserIsNull()
        {
            var result = patientContainer.GetPatientsOfUser(null);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetPatientsOfUser_ShouldReturnSomePatients_WhenUserIsValid()
        {
            var user = new User { ID = 1 };
            var result = patientContainer.GetPatientsOfUser(user);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetPatient_ShouldReturnNull_WhenPatientDoesNotExist()
        {
            var result = patientContainer.GetPatient(999);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetPatient_ShouldReturnPatient_WhenPatientExists()
        {
            var result = patientContainer.GetPatient(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

        [TestMethod]
        public void GetPatientID_ShouldReturnNull_WhenEmailIsNull()
        {
            var result = patientContainer.GetPatientID(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetPatientID_ShouldReturnNull_WhenEmailIsEmpty()
        {
            var result = patientContainer.GetPatientID("");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetPatientID_ShouldReturnPatient_WhenEmailExists()
        {
            var result = patientContainer.GetPatientID("john.doe@example.com");
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

        [TestMethod]
        public void GetPatientIDOfUser_ShouldReturnEmptyList_WhenNoPatientsForUser()
        {
            var result = patientContainer.GetPatientIDOfUser(999);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetPatientIDOfUser_ShouldReturnSomePatientIDs_WhenUserHasPatients()
        {
            var result = patientContainer.GetPatientIDOfUser(1);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void SetActive_ShouldReturnFalse_WhenPatientDoesNotExist()
        {
            var result = patientContainer.SetActive(999);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetActive_ShouldReturnTrue_WhenPatientExists()
        {
            var result = patientContainer.SetActive(1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetInactivePatients_ShouldReturnEmptyList_WhenNoInactivePatients()
        {
            var result = patientContainer.GetInactivePatients();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetAll_ShouldReturnSomePatients_WhenPatientsExist()
        {
            var result = patientContainer.GetAll();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void AddPatient_ShouldReturnFalse_WhenPatientIsNull()
        {
            var result = patientContainer.AddPatient(null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddPatient_ShouldReturnTrue_WhenPatientIsValid()
        {
            var patient = new Patient(3, "New Patient", "new.patient@example.com", 1234567890, "No history", 1);
            var result = patientContainer.AddPatient(patient);
            Assert.IsTrue(result);
        }
    }
}
