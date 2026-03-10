package bt52;

import org.testng.Assert;
import org.testng.annotations.Test;

public class LoanConditionCoverageTest {

    @Test(description = "CC-TC1: A,B,C,D deu True")
    public void cc_tc1_allConditionsTrue() {
        boolean actual = LoanEligibilityService.duDieuKienVay(25, 15_000_000, true, 750);
        Assert.assertTrue(actual, "Tat ca dieu kien true thi ket qua phai true");
    }

    @Test(description = "CC-TC2: A,B,C,D deu False")
    public void cc_tc2_allConditionsFalse() {
        boolean actual = LoanEligibilityService.duDieuKienVay(20, 8_000_000, false, 650);
        Assert.assertFalse(actual, "Tat ca dieu kien false thi ket qua phai false");
    }
}
