package dtm.data;

import org.testng.annotations.DataProvider;

public class GioHangData {
    @DataProvider(name = "gioHangData")
    public static Object[][] gioHangData() {
        return new Object[][]{
                {"Sauce Labs Backpack"},
                {"Sauce Labs Bike Light"}
        };
    }
}