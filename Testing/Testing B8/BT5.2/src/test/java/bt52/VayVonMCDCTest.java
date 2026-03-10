package bt52;

import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

public class VayVonMCDCTest {

    @DataProvider(name = "mcdcCases")
    public Object[][] mcdcCases() {
        return new Object[][]{
                {"MCDC_A_Base", 25, 12_000_000, true, 650, true,
                        "Case co ban A=1,B=1,C=1,D=0 phai du dieu kien vay"},
                {"MCDC_A_TuoiDocLap_ThapHon22", 20, 12_000_000, true, 650, false,
                        "Chi doi A tu true sang false thi ket qua phai doi"},
                {"MCDC_B_ThuNhapDocLap_Duoi10Tr", 25, 8_000_000, true, 650, false,
                        "Chi doi B tu true sang false thi ket qua phai doi"},
                {"MCDC_CD_Baseline_KhongTaiSan_DiemThap", 25, 12_000_000, false, 650, false,
                        "A=1,B=1,C=0,D=0 phai khong du dieu kien vay"},
                {"MCDC_D_DiemTinDungDocLap_Tren700", 25, 12_000_000, false, 720, true,
                        "Chi doi D tu false sang true thi ket qua phai doi"}
        };
    }

    @Test(
            description = "MC/DC: Assert true/false voi thong bao loi ro rang va DataProvider",
            dataProvider = "mcdcCases"
    )
    public void testMCDC_WithDataProvider(
            String caseName,
            int tuoi,
            double thuNhap,
            boolean coTaiSanBaoLanh,
            int diemTinDung,
            boolean expected,
            String assertionMessage
    ) {
        boolean actual = LoanEligibilityService.duDieuKienVay(tuoi, thuNhap, coTaiSanBaoLanh, diemTinDung);
        Assert.assertEquals(actual, expected, "[" + caseName + "] " + assertionMessage);
    }
}
