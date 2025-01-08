using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twofactor;

namespace BodegroTestPlan.TwoFactor
{
    [TestClass]
    public class ValidateTest
    {
        [TestMethod]

        public void OTP()
        {
            //Arrange
            byte[] bytes = Generate.RandomKey(32);
            string check = Code32.Encode(bytes);
            string otp = Generate.OTP(check, 6, 30);

            //Act
            bool test = Validation.OTP(check, otp, DateTime.Now, 30, 0);

            //Assert
            Assert.IsTrue(test);
        }
    }
}
