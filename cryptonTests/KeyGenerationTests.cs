using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace crypton.Tests
{
    [TestClass()]
    public class KeyGenerationTests
    {
        [TestMethod()]
        public void GetRandomBytesTest()
        {
            try
            {
                KeyGeneration.GetRandomBytes(0);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is ArgumentOutOfRangeException);
            }

            try
            {
                KeyGeneration.GetRandomBytes(-1);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is ArgumentOutOfRangeException);
            }

            Assert.AreEqual(5, KeyGeneration.GetRandomBytes(5).Length);
        }
    }
}