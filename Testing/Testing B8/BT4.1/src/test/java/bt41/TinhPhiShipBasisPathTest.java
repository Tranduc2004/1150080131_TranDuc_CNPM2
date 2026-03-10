package bt41;

import org.testng.Assert;
import org.testng.annotations.Test;

public class TinhPhiShipBasisPathTest {

    @Test(description = "BP1: D1=True -> throw")
    public void bp1_invalidWeight_throwsException() {
        Assert.expectThrows(
                IllegalArgumentException.class,
                () -> ShippingFeeService.tinhPhiShip(0, "noi_thanh", false)
        );
    }

    @Test(description = "BP2: D1=F, D2=T, D3=F, D7=F")
    public void bp2_noiThanh_noExtra_notMember() {
        double actual = ShippingFeeService.tinhPhiShip(3, "noi_thanh", false);
        Assert.assertEquals(actual, 15000.0, "Noi thanh <=5kg, khong member phai tinh 15000");
    }

    @Test(description = "BP3: D1=F, D2=T, D3=T, D7=F")
    public void bp3_noiThanh_extra_notMember() {
        double actual = ShippingFeeService.tinhPhiShip(7, "noi_thanh", false);
        Assert.assertEquals(actual, 19000.0, "Noi thanh >5kg, khong member tinh sai");
    }

    @Test(description = "BP4: D1=F, D2=F, D4=T, D5=F, D7=F")
    public void bp4_ngoaiThanh_noExtra_notMember() {
        double actual = ShippingFeeService.tinhPhiShip(3, "ngoai_thanh", false);
        Assert.assertEquals(actual, 25000.0, "Ngoai thanh <=3kg, khong member phai tinh 25000");
    }

    @Test(description = "BP5: D1=F, D2=F, D4=T, D5=T, D7=F")
    public void bp5_ngoaiThanh_extra_notMember() {
        double actual = ShippingFeeService.tinhPhiShip(5, "ngoai_thanh", false);
        Assert.assertEquals(actual, 31000.0, "Ngoai thanh >3kg, khong member tinh sai");
    }

    @Test(description = "BP6: D1=F, D2=F, D4=F, D6=F, D7=F")
    public void bp6_khacVung_noExtra_notMember() {
        double actual = ShippingFeeService.tinhPhiShip(2, "mien_nui", false);
        Assert.assertEquals(actual, 50000.0, "Vung khac <=2kg, khong member phai tinh 50000");
    }

    @Test(description = "BP7: D1=F, D2=F, D4=F, D6=T, D7=F")
    public void bp7_khacVung_extra_notMember() {
        double actual = ShippingFeeService.tinhPhiShip(4, "mien_nui", false);
        Assert.assertEquals(actual, 60000.0, "Vung khac >2kg, khong member tinh sai");
    }

    @Test(description = "BP8: D1=F, D2=T, D3=F, D7=T")
    public void bp8_memberDiscountPath() {
        double actual = ShippingFeeService.tinhPhiShip(3, "noi_thanh", true);
        Assert.assertEquals(actual, 13500.0, "Member phai duoc giam 10% phi ship");
    }
}
