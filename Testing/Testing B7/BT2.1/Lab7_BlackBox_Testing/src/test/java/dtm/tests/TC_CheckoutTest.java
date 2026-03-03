package dtm.tests;

import dtm.base.BaseTest;
import dtm.pages.CartPage;
import dtm.pages.CheckoutPage;
import dtm.pages.InventoryPage;
import dtm.pages.LoginPage;
import org.testng.Assert;
import org.testng.annotations.Test;

public class TC_CheckoutTest extends BaseTest {
    private static final String BASE_URL = "https://www.saucedemo.com/";

    @Test(groups = {"smoke"})
    public void testCheckoutThanhCong() {
        LoginPage loginPage = new LoginPage(getDriver());
        InventoryPage inventoryPage = new InventoryPage(getDriver());
        CartPage cartPage = new CartPage(getDriver());
        CheckoutPage checkoutPage = new CheckoutPage(getDriver());

        loginPage.open(BASE_URL);
        loginPage.login("standard_user", "secret_sauce");

        Assert.assertTrue(inventoryPage.isLoaded(), "Không vào được trang inventory.");
        inventoryPage.addProductToCart("Sauce Labs Backpack");
        inventoryPage.goToCart();

        Assert.assertTrue(cartPage.hasProduct("Sauce Labs Backpack"), "Giỏ hàng không có sản phẩm cần checkout.");
        cartPage.clickCheckout();
        Assert.assertTrue(checkoutPage.isCheckoutInfoStepLoaded(), "Không vào được màn hình Checkout: Your Information.");
    }
}