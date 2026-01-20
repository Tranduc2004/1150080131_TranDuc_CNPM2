using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
// using LabUnitTest.Core;
namespace LabUnitTest.Tests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void Area_Is_Correct()
        {
            var r = new HinhChuNhat(new Diem(0, 10), new Diem(5, 0));
            Assert.AreEqual(50.0, r.DienTich(), 1e-12);
        }

        [TestMethod]
        public void Intersects_When_Overlap()
        {
            var a = new HinhChuNhat(new Diem(0, 10), new Diem(5, 0));
            var b = new HinhChuNhat(new Diem(3, 8), new Diem(8, 2));
            Assert.IsTrue(a.GiaoNhau(b));
        }

        [TestMethod]
        public void Not_Intersects_When_Separate()
        {
            var a = new HinhChuNhat(new Diem(0, 10), new Diem(5, 0));
            var b = new HinhChuNhat(new Diem(6, 10), new Diem(9, 0));
            Assert.IsFalse(a.GiaoNhau(b));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_Throws_When_Invalid_Corners()
        {
            _ = new HinhChuNhat(new Diem(5, 0), new Diem(0, 10));
        }
    }
}