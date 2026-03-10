package bt31;

import org.testng.Assert;
import org.testng.annotations.Test;

public class XepLoaiBranchCoverageTest {

    @Test(description = "TC1 - Diem khong hop le (N1=True)")
    public void tc1_invalidScore() {
        String actual = XepLoaiService.xepLoai(-1, false);
        Assert.assertEquals(actual, "Diem khong hop le", "Diem ngoai [0,10] phai tra ve 'Diem khong hop le'");
    }

    @Test(description = "TC2 - Xep loai Gioi (N2=True)")
    public void tc2_gioi() {
        String actual = XepLoaiService.xepLoai(9, false);
        Assert.assertEquals(actual, "Gioi", "Diem >= 8.5 phai xep loai 'Gioi'");
    }

    @Test(description = "TC3 - Xep loai Kha (N3=True)")
    public void tc3_kha() {
        String actual = XepLoaiService.xepLoai(7, false);
        Assert.assertEquals(actual, "Kha", "Diem >= 7.0 va < 8.5 phai xep loai 'Kha'");
    }

    @Test(description = "TC4 - Xep loai Trung Binh (N4=True)")
    public void tc4_trungBinh() {
        String actual = XepLoaiService.xepLoai(6, false);
        Assert.assertEquals(actual, "Trung Binh", "Diem >= 5.5 va < 7.0 phai xep loai 'Trung Binh'");
    }

    @Test(description = "TC5 - Thi lai (N5=True)")
    public void tc5_thiLai() {
        String actual = XepLoaiService.xepLoai(4, true);
        Assert.assertEquals(actual, "Thi lai", "Diem < 5.5 va coThiLai=true phai tra ve 'Thi lai'");
    }

    @Test(description = "TC6 - Yeu Hoc lai (N5=False)")
    public void tc6_yeuHocLai() {
        String actual = XepLoaiService.xepLoai(4, false);
        Assert.assertEquals(actual, "Yeu - Hoc lai", "Diem < 5.5 va coThiLai=false phai tra ve 'Yeu - Hoc lai'");
    }
}
