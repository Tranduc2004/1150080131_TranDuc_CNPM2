package bt61;

import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import static org.testng.Assert.assertFalse;
import static org.testng.Assert.assertTrue;

public class PhoneValidatorTest {

    private final PhoneValidator validator = new PhoneValidator();

    @DataProvider(name = "validPhones")
    public Object[][] validPhones() {
        return new Object[][]{
                {"0987654321"},
                {"0351234567"},
                {"+84987654321"},
                {"+84 987 654 321"},
                {"0 987 654 321"}
        };
    }

    @DataProvider(name = "invalidPhones")
    public Object[][] invalidPhones() {
        return new Object[][]{
                {null},
                {""},
                {"   "},
                {"+84123456789"},
                {"0123456789"},
                {"099876543"},
                {"09987654321"},
                {"84 987654321"},
                {"+84-987654321"},
                {"03a1234567"},
                {"+84+987654321"}
        };
    }

    @Test(dataProvider = "validPhones")
    public void shouldAcceptValidVietnamPhone(String phone) {
        assertTrue(validator.isValid(phone));
    }

    @Test(dataProvider = "invalidPhones")
    public void shouldRejectInvalidVietnamPhone(String phone) {
        assertFalse(validator.isValid(phone));
    }
}
