package bt71;

import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import java.util.List;

public class OrderProcessorTest {

    private static final double DELTA = 0.0001;
    private final OrderProcessor processor = new OrderProcessor();

    private List<Item> items(double... prices) {
        return java.util.Arrays.stream(prices).mapToObj(Item::new).toList();
    }

    @Test(description = "BP1: D1 true -> throw Gio hang trong")
    public void basisPath_shouldThrowWhenItemsNull() {
        IllegalArgumentException ex = Assert.expectThrows(
                IllegalArgumentException.class,
                () -> processor.calculateTotal(null, null, "SILVER", "CARD")
        );
        Assert.assertEquals(ex.getMessage(), "Gio hang trong");
    }

    @Test(description = "BP2: D1 false, no coupon, no member, D7 true, D8 true")
    public void basisPath_noCouponNoMember_onlineShip30000() {
        double actual = processor.calculateTotal(items(100_000, 200_000), null, "SILVER", "CARD");
        Assert.assertEquals(actual, 330_000, DELTA);
    }

    @Test(description = "BP3: no coupon, no member, D7 true, D8 false (COD)")
    public void basisPath_noCouponNoMember_codShip20000() {
        double actual = processor.calculateTotal(items(100_000, 200_000), null, "SILVER", "COD");
        Assert.assertEquals(actual, 320_000, DELTA);
    }

    @Test(description = "BP4: coupon SALE10, GOLD, D7 false")
    public void basisPath_sale10_gold_noShip() {
        double actual = processor.calculateTotal(items(400_000, 400_000), "SALE10", "GOLD", "CARD");
        Assert.assertEquals(actual, 684_000, DELTA);
    }

    @Test(description = "BP5: coupon SALE20, PLATINUM, D7 false")
    public void basisPath_sale20_platinum_noShip() {
        double actual = processor.calculateTotal(items(600_000, 400_000), "SALE20", "PLATINUM", "CARD");
        Assert.assertEquals(actual, 720_000, DELTA);
    }

    @Test(description = "BP6: invalid coupon -> throw")
    public void basisPath_invalidCoupon_shouldThrow() {
        IllegalArgumentException ex = Assert.expectThrows(
                IllegalArgumentException.class,
                () -> processor.calculateTotal(items(100_000), "BAD", "SILVER", "CARD")
        );
        Assert.assertEquals(ex.getMessage(), "Ma giam gia khong hop le");
    }

    @DataProvider(name = "mcdcCouponD2D3")
    public Object[][] mcdcCouponD2D3() {
        return new Object[][]{
                {null, "SILVER", "CARD", 130_000.0, false},
                {"", "SILVER", "CARD", 130_000.0, false},
                {"SALE10", "SILVER", "CARD", 120_000.0, true}
        };
    }

    @Test(dataProvider = "mcdcCouponD2D3", description = "MC/DC for D2&&D3: decision A&&(coupon==SALE10)")
    public void mcdc_coupon_D2_and_D3(String coupon, String member, String payment,
                                      double expected, boolean shouldApplySale10) {
        double actual = processor.calculateTotal(items(100_000), coupon, member, payment);
        Assert.assertEquals(actual, expected, DELTA);

        if (shouldApplySale10) {
            Assert.assertEquals(actual, 120_000.0, DELTA);
        } else {
            Assert.assertEquals(actual, 130_000.0, DELTA);
        }
    }
}
