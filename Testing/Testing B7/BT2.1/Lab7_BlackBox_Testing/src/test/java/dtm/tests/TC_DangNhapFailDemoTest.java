package dtm.tests;

import dtm.base.BaseTest;
import dtm.pages.LoginPage;
import org.testng.Assert;
import org.testng.annotations.Test;

public class TC_DangNhapFailDemoTest extends BaseTest {
    private static final String BASE_URL = "https://www.saucedemo.com/";

    @Test(description = "Demo FAIL để chứng minh cơ chế tự động chụp screenshot")
    public void demoFailScreenshot() {
        LoginPage loginPage = new LoginPage(getDriver());
        loginPage.open(BASE_URL);
        loginPage.dangNhap("standard_user", "secret_sauce");

        Assert.assertTrue(loginPage.isErrorVisible(), "Demo FAIL: đăng nhập đúng nên không có lỗi, test này cố ý fail.");
    }
}