package dtm.tests;

import dtm.base.BaseTest;
import dtm.data.GioHangData;
import dtm.pages.CartPage;
import dtm.pages.InventoryPage;
import dtm.pages.LoginPage;
import org.testng.Assert;
import org.testng.annotations.Test;

public class TC_GioHangTest extends BaseTest {
    private static final String BASE_URL = "https://www.saucedemo.com/";

    @Test(dataProvider = "gioHangData", dataProviderClass = GioHangData.class, groups = {"smoke"})
    public void testThemSanPhamVaoGio(String productName) {
        LoginPage loginPage = new LoginPage(getDriver());
        InventoryPage inventoryPage = new InventoryPage(getDriver());
        CartPage cartPage = new CartPage(getDriver());

        loginPage.open(BASE_URL);
        loginPage.login("standard_user", "secret_sauce");

        Assert.assertTrue(inventoryPage.isLoaded(), "Không vào được trang inventory sau đăng nhập.");
        inventoryPage.addProductToCart(productName);
        Assert.assertTrue(inventoryPage.getCartBadgeCount() >= 1, "Giỏ hàng chưa tăng số lượng.");

        inventoryPage.goToCart();
        Assert.assertTrue(cartPage.hasProduct(productName), "Sản phẩm chưa xuất hiện trong giỏ hàng.");
    }
}