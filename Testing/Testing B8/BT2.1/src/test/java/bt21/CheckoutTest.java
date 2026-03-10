package bt21;

import org.testng.Assert;
import org.testng.annotations.Test;

public class CheckoutTest {

    @Test(groups = {"smoke", "regression"})
    public void testCheckoutWithValidInformation() {
        System.out.println("[CheckoutTest] testCheckoutWithValidInformation - smoke, regression");
        boolean checkoutSuccess = true;
        Assert.assertTrue(checkoutSuccess, "Checkout voi du lieu hop le phai thanh cong");
    }

    @Test(groups = {"regression"})
    public void testCheckoutWithEmptyPostalCode() {
        System.out.println("[CheckoutTest] testCheckoutWithEmptyPostalCode - regression");
        String errorMessage = "Postal Code is required";
        Assert.assertEquals(errorMessage, "Postal Code is required", "Thong bao loi thieu Postal Code khong dung");
    }
}
