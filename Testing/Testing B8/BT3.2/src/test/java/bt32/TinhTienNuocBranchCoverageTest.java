package bt32;

import org.testng.Assert;
import org.testng.annotations.Test;

public class TinhTienNuocBranchCoverageTest {

    @Test(description = "TC1 - N1 True: soM3 <= 0")
    public void tc1_invalidSoM3() {
        double actual = TinhTienNuocService.tinhTienNuoc(0, "dan_cu");
        Assert.assertEquals(actual, 0.0, "soM3 <= 0 phai tra ve 0");
    }

    @Test(description = "TC2 - N2 True: ho_ngheo")
    public void tc2_hoNgheo() {
        double actual = TinhTienNuocService.tinhTienNuoc(5, "ho_ngheo");
        Assert.assertEquals(actual, 25000.0, "ho_ngheo phai tinh don gia 5000");
    }

    @Test(description = "TC3 - N3 True, N4 True: dan_cu <=10")
    public void tc3_danCuBac1() {
        double actual = TinhTienNuocService.tinhTienNuoc(8, "dan_cu");
        Assert.assertEquals(actual, 60000.0, "dan_cu bac <=10 phai tinh don gia 7500");
    }

    @Test(description = "TC4 - N4 False, N5 True: dan_cu 11..20")
    public void tc4_danCuBac2() {
        double actual = TinhTienNuocService.tinhTienNuoc(15, "dan_cu");
        Assert.assertEquals(actual, 148500.0, "dan_cu bac 11..20 phai tinh don gia 9900");
    }

    @Test(description = "TC5 - N5 False: dan_cu >20")
    public void tc5_danCuBac3() {
        double actual = TinhTienNuocService.tinhTienNuoc(25, "dan_cu");
        Assert.assertEquals(actual, 285000.0, "dan_cu >20 phai tinh don gia 11400");
    }

    @Test(description = "TC6 - N3 False: kinh_doanh")
    public void tc6_kinhDoanh() {
        double actual = TinhTienNuocService.tinhTienNuoc(5, "kinh_doanh");
        Assert.assertEquals(actual, 110000.0, "khach hang khac dan_cu/ho_ngheo phai tinh don gia 22000");
    }
}
