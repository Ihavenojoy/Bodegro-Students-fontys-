using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twofactor;

namespace BodegroTestPlan.TwoFactor
{
    [TestClass]
    public class Code32Test
    {
        [TestMethod]

        public void Encode()
        {
            //Arrange
            byte[] bytes = Generate.RandomKey(32);

            //Act
            Code32.Encode(bytes);

            //Assert
            Assert.AreEqual(32, bytes.Length);

        }

        [TestMethod]

        public void Decode()
        {
            //Arrange
            byte[] bytes = Generate.RandomKey(32);
            string check = Code32.Encode(bytes);

            //Act
            byte[] test = Code32.Decode(check);

            //Assert
            for (int i = 0; i < test.Length; i++)
            {
                Assert.AreEqual((int)test[i], (int)bytes[i]);
            }
        }
    }
}
