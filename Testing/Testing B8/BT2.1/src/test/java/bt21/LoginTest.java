package bt21;

import org.testng.Assert;
import org.testng.annotations.Test;

public class LoginTest {

    @Test(groups = {"smoke", "regression"})
    public void testLoginWithValidCredential() {
        System.out.println("[LoginTest] testLoginWithValidCredential - smoke, regression");
        boolean loginSuccess = true;
        Assert.assertTrue(loginSuccess, "Dang nhap hop le phai thanh cong");
    }

    @Test(groups = {"regression"})
    public void testLoginWithInvalidPassword() {
        System.out.println("[LoginTest] testLoginWithInvalidPassword - regression");
        String errorMessage = "Invalid username or password";
        Assert.assertEquals(errorMessage, "Invalid username or password", "Thong bao loi dang nhap sai mat khau khong dung");
    }
}
