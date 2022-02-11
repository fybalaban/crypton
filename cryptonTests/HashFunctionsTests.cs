using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace crypton.Tests
{
    [TestClass()]
    public class HashFunctionsTests
    {
        [TestMethod()]
        public void PerformHashTest()
        {
            try
            {
                HashFunctions.PerformHash("", HashFunctions.HashFunction.Sha1);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is ArgumentNullException);
            }

            Assert.AreEqual("0a4d55a8d778e5022fab701977c5d840bbc486d0", HashFunctions.PerformHash("Hello World", HashFunctions.HashFunction.Sha1));
            Assert.AreEqual("648a6a6ffffdaa0badb23b8baf90b6168dd16b3a", HashFunctions.PerformHash("Hello World\n", HashFunctions.HashFunction.Sha1));

            Assert.AreEqual("a591a6d40bf420404a011733cfb7b190d62c65bf0bcda32b57b277d9ad9f146e", HashFunctions.PerformHash("Hello World", HashFunctions.HashFunction.Sha256));
            Assert.AreEqual("d2a84f4b8b650937ec8f73cd8be2c74add5a911ba64df27458ed8229da804a26", HashFunctions.PerformHash("Hello World\n", HashFunctions.HashFunction.Sha256));

            Assert.AreEqual("2c74fd17edafd80e8447b0d46741ee243b7eb74dd2149a0ab1b9246fb30382f27e853d8585719e0e67cbda0daa8f51671064615d645ae27acb15bfb1447f459b", HashFunctions.PerformHash("Hello World", HashFunctions.HashFunction.Sha512));
            Assert.AreEqual("e1c112ff908febc3b98b1693a6cd3564eaf8e5e6ca629d084d9f0eba99247cacdd72e369ff8941397c2807409ff66be64be908da17ad7b8a49a2a26c0e8086aa", HashFunctions.PerformHash("Hello World\n", HashFunctions.HashFunction.Sha512));
        }
    }
}