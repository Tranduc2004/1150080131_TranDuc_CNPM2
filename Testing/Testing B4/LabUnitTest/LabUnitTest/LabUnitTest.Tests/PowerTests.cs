using Microsoft.VisualStudio.TestTools.UnitTesting;
// Nếu Core có namespace thì mở dòng dưới:
// using LabUnitTest.Core;
namespace LabUnitTest.Tests
{
    [TestClass]
    public class PowerTests
    {
        [TestMethod]
        public void Power_N_Equal_Zero_Returns_One()
        {
            Assert.AreEqual(1.0, MathEx.Power(5.7, 0), 1e-12);
        }

        [TestMethod]
        public void Power_Positive_N_Works()
        {
            Assert.AreEqual(8.0, MathEx.Power(2.0, 3), 1e-12);
            Assert.AreEqual(81.0, MathEx.Power(3.0, 4), 1e-12);
        }

        [TestMethod]
        public void Power_Negative_N_Works()
        {
            Assert.AreEqual(0.25, MathEx.Power(2.0, -2), 1e-12);
            Assert.AreEqual(0.5, MathEx.Power(2.0, -1), 1e-12);
        }

        [TestMethod]
        public void Power_Negative_Base_Odd_Even()
        {
            Assert.AreEqual(-8.0, MathEx.Power(-2.0, 3), 1e-12);
            Assert.AreEqual(16.0, MathEx.Power(-2.0, 4), 1e-12);
        }
    }
}