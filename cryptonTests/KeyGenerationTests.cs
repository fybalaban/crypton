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

        [TestMethod()]
        public void Pbkdf2Test()
        {
            byte[] validPassword = { 1, 2, 3, 4, 5 };
            byte[] invalidPassword1 = {};
            byte[] invalidPassword2 = null;
            byte[] validSalt = { 1, 2, 3, 4, 5 };
            byte[] invalidSalt1 = { };
            byte[] invalidSalt2 = null;
            int validRepetition = 10000;
            int invalidRepetition1 = 0;
            int invalidRepetition2 = -1;
            int invalidLength1 = 0;
            int invalidLength2 = -1;

            try
            {
                KeyGeneration.Pbkdf2(invalidPassword1, validSalt, validRepetition, 160, HashFunctions.HashFunction.Sha1);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is ArgumentOutOfRangeException);
            }

            try
            {
                KeyGeneration.Pbkdf2(invalidPassword2, validSalt, validRepetition, 160, HashFunctions.HashFunction.Sha1);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is ArgumentNullException);
            }

            try
            {
                KeyGeneration.Pbkdf2(validPassword, invalidSalt1, validRepetition, 160, HashFunctions.HashFunction.Sha1);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is ArgumentOutOfRangeException);
            }
            
            try
            {
                KeyGeneration.Pbkdf2(validPassword, invalidSalt2, validRepetition, 160, HashFunctions.HashFunction.Sha1);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is ArgumentNullException);
            }

            try
            {
                KeyGeneration.Pbkdf2(validPassword, validSalt, invalidRepetition1, 160, HashFunctions.HashFunction.Sha1);
                KeyGeneration.Pbkdf2(validPassword, validSalt, invalidRepetition2, 160, HashFunctions.HashFunction.Sha1);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is ArgumentOutOfRangeException);
            }

            try
            {
                KeyGeneration.Pbkdf2(validPassword, validSalt, validRepetition, invalidLength1, HashFunctions.HashFunction.Sha1);
                KeyGeneration.Pbkdf2(validPassword, validSalt, validRepetition, invalidLength2, HashFunctions.HashFunction.Sha1);
            }
            catch(Exception exception)
            {
                Assert.IsTrue(exception is ArgumentOutOfRangeException);
            }

            Exception thisShouldBeNull = null;
            try
            {
                KeyGeneration.Pbkdf2(validPassword, validSalt, validRepetition, 160, HashFunctions.HashFunction.Sha1);
            }
            catch (Exception exception)
            {
                thisShouldBeNull = exception;
            }
            Assert.AreEqual(null, thisShouldBeNull);
        }
    }
}