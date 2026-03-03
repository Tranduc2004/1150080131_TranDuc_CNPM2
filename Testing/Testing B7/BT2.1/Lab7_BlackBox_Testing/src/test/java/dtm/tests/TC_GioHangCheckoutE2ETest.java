package dtm.tests;

import dtm.base.BaseTest;
import dtm.pages.CartPage;
import dtm.pages.CheckoutPage;
import dtm.pages.InventoryPage;
import dtm.pages.LoginPage;
import org.testng.Assert;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.time.Duration;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class TC_GioHangCheckoutE2ETest extends BaseTest {
    private static final String BASE_URL = "https://www.saucedemo.com/";

    private InventoryPage inventoryPage;
    private CartPage cartPage;
    private CheckoutPage checkoutPage;

    @BeforeMethod(alwaysRun = true)
    public void chuanBi() {
        LoginPage loginPage = new LoginPage(getDriver());
        inventoryPage = new InventoryPage(getDriver());
        cartPage = new CartPage(getDriver());
        checkoutPage = new CheckoutPage(getDriver());

        loginPage.open(BASE_URL);
        loginPage.dangNhap("standard_user", "secret_sauce");
        Assert.assertTrue(inventoryPage.isLoaded(), "Đăng nhập trước test thất bại.");
    }

    @Test(groups = {"smoke"}, description = "TC_CART_001: Thêm 1 sản phẩm - badge = 1")
    public void themMotSanPham() {
        inventoryPage.themSanPhamTheoTen("Sauce Labs Backpack");
        Assert.assertEquals(inventoryPage.laySoLuongBadge(), 1);
    }

    @Test(groups = {"smoke"}, description = "TC_CART_002: Thêm 3 sản phẩm - badge = 3")
    public void them3SanPham() {
        inventoryPage.themNSanPhamDauTien(3);
        Assert.assertEquals(inventoryPage.laySoLuongBadge(), 3);
    }

    @Test(groups = {"regression"}, description = "TC_CART_003: Xóa hết - giỏ trống")
    public void xoaHetSanPham() {
        inventoryPage.themNSanPhamDauTien(3);
        inventoryPage.goToCart();
        cartPage.xoaTatCaSanPham();
        Assert.assertEquals(cartPage.laySoLuongSanPhamTrongGio(), 0);
    }

    @Test(groups = {"regression"}, description = "TC_CART_004: Sort giá tăng dần")
    public void sortGiaTangDan() {
        inventoryPage.sortSanPham("lohi");
        List<Double> prices = inventoryPage.layDanhSachGiaSanPham();
        List<Double> sorted = new ArrayList<>(prices);
        Collections.sort(sorted);
        Assert.assertEquals(prices, sorted, "Danh sách giá không tăng dần đúng.");
    }

    @Test(groups = {"regression"}, description = "TC_CART_005: Sort giá giảm dần")
    public void sortGiaGiamDan() {
        inventoryPage.sortSanPham("hilo");
        List<Double> prices = inventoryPage.layDanhSachGiaSanPham();
        List<Double> sorted = new ArrayList<>(prices);
        sorted.sort(Collections.reverseOrder());
        Assert.assertEquals(prices, sorted, "Danh sách giá không giảm dần đúng.");
    }

    @Test(groups = {"regression"}, description = "TC_CART_006: Sort tên A->Z")
    public void sortTenAZ() {
        inventoryPage.sortSanPham("az");
        List<String> names = inventoryPage.layDanhSachTenSanPham();
        List<String> sorted = new ArrayList<>(names);
        Collections.sort(sorted);
        Assert.assertEquals(names, sorted, "Danh sách tên không theo A->Z.");
    }

    @Test(groups = {"regression"}, description = "TC_CART_007: Sort tên Z->A")
    public void sortTenZA() {
        inventoryPage.sortSanPham("za");
        List<String> names = inventoryPage.layDanhSachTenSanPham();
        List<String> sorted = new ArrayList<>(names);
        sorted.sort(Collections.reverseOrder());
        Assert.assertEquals(names, sorted, "Danh sách tên không theo Z->A.");
    }

    @Test(groups = {"regression"}, description = "TC_CHK_001: Validate thiếu First Name")
    public void checkoutThieuFirstName() {
        vaoCheckoutStepOneVoiMotSanPham();
        checkoutPage.nhapThongTinKhachHang("", "Nguyen", "700000");
        checkoutPage.clickContinue();
        Assert.assertTrue(checkoutPage.layThongBaoLoi().toLowerCase().contains("first name"),
            "Không thấy lỗi First Name required.");
    }

    @Test(groups = {"regression"}, description = "TC_CHK_002: Validate thiếu Last Name")
    public void checkoutThieuLastName() {
        vaoCheckoutStepOneVoiMotSanPham();
        checkoutPage.nhapThongTinKhachHang("A", "", "700000");
        checkoutPage.clickContinue();
        Assert.assertTrue(checkoutPage.layThongBaoLoi().toLowerCase().contains("last name"),
            "Không thấy lỗi Last Name required.");
    }

    @Test(groups = {"regression"}, description = "TC_CHK_003: Validate thiếu Postal Code")
    public void checkoutThieuPostalCode() {
        vaoCheckoutStepOneVoiMotSanPham();
        checkoutPage.nhapThongTinKhachHang("A", "B", "");
        checkoutPage.clickContinue();
        Assert.assertTrue(checkoutPage.layThongBaoLoi().toLowerCase().contains("postal code"),
            "Không thấy lỗi Postal Code required.");
    }

    @Test(groups = {"smoke"}, description = "TC_CHK_004: Điền đủ Step 1 và sang Step 2")
    public void checkoutDayDuSangStepHai() {
        vaoCheckoutStepOneVoiMotSanPham();
        checkoutPage.nhapThongTinKhachHang("A", "B", "700000");
        checkoutPage.clickContinue();
        Assert.assertTrue(checkoutPage.isCheckoutStepTwoLoaded(), "Không chuyển sang checkout step two.");
    }

    @Test(groups = {"regression"}, description = "TC_CHK_005: Verify Item total/Tax/Total với 2 items")
    public void verifyTinhTienHaiSanPham() {
        inventoryPage.themSanPhamTheoTen("Sauce Labs Backpack");
        inventoryPage.themSanPhamTheoTen("Sauce Labs Bike Light");
        inventoryPage.goToCart();
        cartPage.clickCheckout();
        checkoutPage.nhapThongTinKhachHang("A", "B", "700000");
        checkoutPage.clickContinue();

        Assert.assertEquals(checkoutPage.layItemTotal(), 39.98, 0.01);
        Assert.assertEquals(checkoutPage.layTax(), 3.20, 0.01);
        Assert.assertEquals(checkoutPage.layTotal(), 43.18, 0.01);
    }

    @Test(groups = {"regression"}, description = "TC_CHK_006: Verify shipping info")
    public void verifyShippingInfo() {
        vaoCheckoutStepTwoVoiMotSanPham();
        Assert.assertTrue(checkoutPage.layShippingInfo().toLowerCase().contains("free pony express"),
            "Shipping info không đúng mong đợi.");
    }

    @Test(groups = {"regression"}, description = "TC_CHK_007: Cancel ở step 1")
    public void cancelTaiStepMot() {
        vaoCheckoutStepOneVoiMotSanPham();
        checkoutPage.clickCancelStepOne();
        Assert.assertTrue(getDriver().getCurrentUrl().contains("/cart.html"));
    }

    @Test(groups = {"regression"}, description = "TC_CHK_008: Cancel ở step 2")
    public void cancelTaiStepHai() {
        vaoCheckoutStepTwoVoiMotSanPham();
        checkoutPage.clickCancelStepTwo();
        Assert.assertTrue(getDriver().getCurrentUrl().contains("/inventory.html"));
    }

    @Test(groups = {"smoke"}, description = "TC_CHK_009: Finish và Back Home reset badge")
    public void finishVaBackHomeResetGio() {
        vaoCheckoutStepTwoVoiMotSanPham();
        checkoutPage.finishOrder();
        Assert.assertTrue(checkoutPage.isOrderCompleted());
        Assert.assertTrue(checkoutPage.layCompleteHeader().toLowerCase().contains("thank you for your order"));
        checkoutPage.clickBackHome();
        Assert.assertEquals(inventoryPage.laySoLuongBadge(), 0);
    }

    @Test(groups = {"regression"}, description = "TC_BUG_001: Chạy flow cơ bản với problem_user")
    public void quanSatProblemUserFlow() {
        LoginPage loginPage = new LoginPage(getDriver());
        getDriver().manage().deleteAllCookies();
        loginPage.open(BASE_URL);
        loginPage.dangNhap("problem_user", "secret_sauce");

        Assert.assertTrue(inventoryPage.isLoaded(), "problem_user không vào được inventory.");
        inventoryPage.themSanPhamTheoTen("Sauce Labs Backpack");
        Assert.assertEquals(inventoryPage.laySoLuongBadge(), 1, "problem_user có hành vi bất thường khi add cart.");
    }

    private void vaoCheckoutStepOneVoiMotSanPham() {
        inventoryPage.themSanPhamTheoTen("Sauce Labs Backpack");
        Assert.assertEquals(inventoryPage.laySoLuongBadge(), 1, "Badge phải là 1 trước khi vào cart.");
        inventoryPage.goToCart();
        new WebDriverWait(getDriver(), Duration.ofSeconds(8)).until(ExpectedConditions.urlContains("/cart.html"));
        Assert.assertTrue(cartPage.hasProduct("Sauce Labs Backpack"), "Cart không có sản phẩm để checkout.");
        cartPage.clickCheckout();

        if (!checkoutPage.isCheckoutInfoStepLoaded() && getDriver().getCurrentUrl().contains("/cart.html")) {
            cartPage.clickCheckout();
        }
        Assert.assertTrue(checkoutPage.isCheckoutInfoStepLoaded(), "Không mở được step one.");
    }

    private void vaoCheckoutStepTwoVoiMotSanPham() {
        vaoCheckoutStepOneVoiMotSanPham();
        checkoutPage.nhapThongTinKhachHang("A", "B", "700000");
        checkoutPage.clickContinue();
        Assert.assertTrue(checkoutPage.isCheckoutStepTwoLoaded(), "Không mở được step two.");
    }
}