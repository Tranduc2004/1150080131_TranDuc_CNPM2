using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
// using LabUnitTest.Core;
namespace LabUnitTest.Tests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod]
        public void Cal_Returns_Correct_Value()
        {
            // P(x) = 1 + 2x + 3x^2
            var p = new Polynomial(2, new List<int> { 1, 2, 3 });
            Assert.AreEqual(17, p.Cal(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_Throws_When_Missing_Coefficients()
        {
            _ = new Polynomial(2, new List<int> { 1, 2 }); // thiếu 1 hệ số
        }

        [TestMethod]
        public void Ctor_Throws_With_Message_When_Negative_Degree()
        {
            try
            {
                _ = new Polynomial(-1, new List<int> { 1 });
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid Data", ex.Message);
            }
        }
    }
}