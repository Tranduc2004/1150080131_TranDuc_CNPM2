package bt42;

import org.testng.Assert;
import org.testng.annotations.Test;

public class PhiShipBasisPathTest {

    @Test(description = "Path 1: Trong luong khong hop le")
    public void testPath1_InvalidWeight() {
        Assert.assertThrows(
                IllegalArgumentException.class,
                () -> PhiShip.tinhPhiShip(-1, "noi_thanh", false)
        );
    }

    @Test(description = "Path 2: Noi thanh, <= 5kg, khong member")
    public void testPath2_NoiThanhNheKhongMember() {
        double expected = 15000.0;
        double actual = PhiShip.tinhPhiShip(3, "noi_thanh", false);
        Assert.assertEquals(actual, expected, 0.01, "Phi ship noi thanh <= 5kg khong dung");
    }

    @Test(description = "Path 3: Noi thanh, > 5kg, khong member")
    public void testPath3_NoiThanhNangKhongMember() {
        double expected = 19000.0;
        double actual = PhiShip.tinhPhiShip(7, "noi_thanh", false);
        Assert.assertEquals(actual, expected, 0.01, "Phi ship noi thanh > 5kg khong dung");
    }

    @Test(description = "Path 4: Ngoai thanh, <= 3kg, khong member")
    public void testPath4_NgoaiThanhNheKhongMember() {
        double expected = 25000.0;
        double actual = PhiShip.tinhPhiShip(3, "ngoai_thanh", false);
        Assert.assertEquals(actual, expected, 0.01, "Phi ship ngoai thanh <= 3kg khong dung");
    }

    @Test(description = "Path 5: Ngoai thanh, > 3kg, khong member")
    public void testPath5_NgoaiThanhNangKhongMember() {
        double expected = 31000.0;
        double actual = PhiShip.tinhPhiShip(5, "ngoai_thanh", false);
        Assert.assertEquals(actual, expected, 0.01, "Phi ship ngoai thanh > 3kg khong dung");
    }

    @Test(description = "Path 6: Vung khac, <= 2kg, khong member")
    public void testPath6_VungKhacNheKhongMember() {
        double expected = 50000.0;
        double actual = PhiShip.tinhPhiShip(2, "mien_nui", false);
        Assert.assertEquals(actual, expected, 0.01, "Phi ship vung khac <= 2kg khong dung");
    }

    @Test(description = "Path 7: Vung khac, > 2kg, khong member")
    public void testPath7_VungKhacNangKhongMember() {
        double expected = 60000.0;
        double actual = PhiShip.tinhPhiShip(4, "mien_nui", false);
        Assert.assertEquals(actual, expected, 0.01, "Phi ship vung khac > 2kg khong dung");
    }

    @Test(description = "Path 8: Co member, giam 10%")
    public void testPath8_MemberDiscount() {
        double expected = 13500.0;
        double actual = PhiShip.tinhPhiShip(3, "noi_thanh", true);
        Assert.assertEquals(actual, expected, 0.01, "Thanh vien phai duoc giam 10% phi ship");
    }
}
