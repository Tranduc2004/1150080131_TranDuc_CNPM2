using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
// using LabUnitTest.Core;
namespace LabUnitTest.Tests
{

    [TestClass]
    public class ScholarshipTests
    {
        [TestMethod]
        public void Eligible_When_Avg_Gte_8_And_No_Subject_Below_5()
        {
            var hv = new HocVien("HV01", "A", "HCM", 8, 8, 8);
            Assert.IsTrue(hv.DuHocBong());
        }

        [TestMethod]
        public void Not_Eligible_When_Any_Subject_Below_5()
        {
            var hv = new HocVien("HV02", "B", "HCM", 10, 9, 4.9);
            Assert.IsFalse(hv.DuHocBong());
        }

        [TestMethod]
        public void Filter_Returns_Only_Eligible_Students()
        {
            var ds = new List<HocVien>
        {
            new HocVien("HV01","A","HCM",8,8,8),
            new HocVien("HV02","B","HCM",9,9,4),
            new HocVien("HV03","C","HCM",10,7,7) // avg=8, môn>=5 => đủ
        };

            var hb = HocBongService.LayDanhSachHocBong(ds);

            Assert.AreEqual(2, hb.Count);
            Assert.AreEqual("HV01", hb[0].MaSo);
            Assert.AreEqual("HV03", hb[1].MaSo);
        }
    }
}