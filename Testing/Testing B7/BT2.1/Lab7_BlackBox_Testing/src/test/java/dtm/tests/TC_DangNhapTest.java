package dtm.tests;

import dtm.base.BaseTest;
import dtm.data.DangNhapData;
import dtm.pages.LoginPage;
import org.testng.Assert;
import org.testng.annotations.Test;

public class TC_DangNhapTest extends BaseTest {
    private static final String BASE_URL = "https://www.saucedemo.com/";

    @Test(
            dataProvider = "du_lieu_dang_nhap",
            dataProviderClass = DangNhapData.class,
            description = "Kiểm thử đăng nhập với nhiều bộ dữ liệu",
            groups = {"smoke"}
    )
    public void kiemThuDangNhap(String username, String password, String ketQuaMongDoi, String moTa) {
        LoginPage loginPage = new LoginPage(getDriver());

        loginPage.open(BASE_URL);
        Assert.assertTrue(loginPage.isLoginButtonEnabled(), "Nút Login phải luôn enable. Case: " + moTa);
        loginPage.dangNhap(username, password);

        switch (ketQuaMongDoi) {
            case "THANH_CONG" -> {
                Assert.assertTrue(loginPage.isDangOTrangSanPham(), "URL không chuyển sang inventory.html. Case: " + moTa);
            }
            case "BI_KHOA" -> {
                Assert.assertTrue(loginPage.isErrorVisible(), "Không hiển thị lỗi tài khoản bị khóa. Case: " + moTa);
                Assert.assertTrue(loginPage.layThongBaoLoi().toLowerCase().contains("locked out"),
                        "Thông báo không đúng lỗi locked out. Case: " + moTa);
            }
            case "TRUONG_TRONG" -> {
                Assert.assertTrue(loginPage.isErrorVisible(), "Không hiển thị lỗi trường trống. Case: " + moTa);
                Assert.assertTrue(loginPage.layThongBaoLoi().toLowerCase().contains("required"),
                        "Thông báo không đúng lỗi required. Case: " + moTa);
            }
            case "SAI_THONG_TIN" -> {
                Assert.assertTrue(loginPage.isErrorVisible(), "Không hiển thị lỗi sai thông tin. Case: " + moTa);
                Assert.assertTrue(loginPage.layThongBaoLoi().toLowerCase().contains("do not match any user"),
                        "Thông báo không đúng lỗi sai thông tin đăng nhập. Case: " + moTa);
            }
            default -> Assert.fail("ketQuaMongDoi không hợp lệ: " + ketQuaMongDoi + " | Case: " + moTa);
        }
    }
}