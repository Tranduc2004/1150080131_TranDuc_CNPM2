    package dtm.tests;

    import dtm.base.BaseTest;
    import dtm.pages.InventoryPage;
    import dtm.pages.LoginPage;
    import org.testng.Assert;
    import org.testng.annotations.Test;

    public class TC_TimKiemTest extends BaseTest {
        private static final String BASE_URL = "https://www.saucedemo.com/";

        @Test
        public void testTimKiemSanPhamTonTaiTrongDanhSach() {
            LoginPage loginPage = new LoginPage(getDriver());
            InventoryPage inventoryPage = new InventoryPage(getDriver());

            loginPage.open(BASE_URL);
            loginPage.login("standard_user", "secret_sauce");

            Assert.assertTrue(inventoryPage.isLoaded(), "Không vào được trang inventory.");
            Assert.assertTrue(inventoryPage.isProductVisible("Sauce Labs Backpack"), "Không tìm thấy sản phẩm cần kiểm tra.");
        }
    }