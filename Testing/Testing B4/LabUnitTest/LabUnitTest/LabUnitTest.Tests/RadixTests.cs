using LabUnitTest.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
// using LabUnitTest.Core;
namespace LabUnitTest.Tests
{


    [TestClass]
    public class RadixTests
    {
        [TestMethod]
        public void Convert_To_Binary()
        {
            var r = new Radix(10);
            Assert.AreEqual("1010", r.ConvertDecimalToAnother(2));
        }

        [TestMethod]
        public void Convert_To_Hex_Uses_A_F()
        {
            var r = new Radix(26);
            Assert.AreEqual("1A", r.ConvertDecimalToAnother(16));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_Throws_When_Invalid_Radix_Low()
        {
            var r = new Radix(10);
            r.ConvertDecimalToAnother(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_Throws_When_Number_Negative()
        {
            _ = new Radix(-5);
        }
    }
}