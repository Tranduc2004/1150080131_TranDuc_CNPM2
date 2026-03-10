package bt21;

import org.testng.Assert;
import org.testng.annotations.Test;

public class CartTest {

    @Test(groups = {"smoke", "regression"})
    public void testAddItemToCart() {
        System.out.println("[CartTest] testAddItemToCart - smoke, regression");
        int cartItemCount = 1;
        Assert.assertEquals(cartItemCount, 1, "Them san pham vao gio hang that bai");
    }

    @Test(groups = {"regression"})
    public void testRemoveItemFromCart() {
        System.out.println("[CartTest] testRemoveItemFromCart - regression");
        int cartItemCountAfterRemove = 0;
        Assert.assertEquals(cartItemCountAfterRemove, 0, "Xoa san pham khoi gio hang that bai");
    }
}
