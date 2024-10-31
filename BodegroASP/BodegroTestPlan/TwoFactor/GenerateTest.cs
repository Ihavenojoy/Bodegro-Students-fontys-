using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twofactor;

namespace BodegroTestPlan.TwoFactor
{
    [TestClass]
    public class GenerateTest
    {
        [TestMethod]

        public void OTP()
        {
            //Arrange
            byte[] bytes = Generate.RandomKey(32);
            string check = Code32.Encode(bytes);

            //Act
            string test = Generate.OTP(check, 6, 30);

            //Assert
            Assert.AreEqual(test.Length, 6);
        }

        [TestMethod]
        public void RandomKey()
        {
            //Arrange
            int length = 32;

            //Act
            byte[] test = Generate.RandomKey(length);

            //Assert
            Assert.AreEqual(test.Length, 32);
        }
    }
}
