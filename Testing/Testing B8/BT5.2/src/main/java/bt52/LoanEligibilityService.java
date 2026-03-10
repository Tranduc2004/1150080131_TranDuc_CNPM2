package bt52;

public class LoanEligibilityService {

    public static boolean duDieuKienVay(int tuoi, double thuNhap, boolean coTaiSanBaoLanh, int diemTinDung) {
        boolean dieuKienCoBan = (tuoi >= 22) && (thuNhap >= 10_000_000);
        boolean dieuKienBaoDam = coTaiSanBaoLanh || (diemTinDung >= 700);
        return dieuKienCoBan && dieuKienBaoDam;
    }
}
