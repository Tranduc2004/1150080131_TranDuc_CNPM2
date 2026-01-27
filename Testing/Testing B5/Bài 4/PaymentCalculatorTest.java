import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class PaymentCalculatorTest {
    private PaymentCalculatorLogic calculator;
    
    @BeforeEach
    public void setUp() {
        calculator = new PaymentCalculatorLogic();
    }
    
    // Test cases for Male
    @Test
    public void testMaleAge18To35() {
        assertEquals(100, calculator.calculatePayment("Male", 18), "Male age 18 should be 100 euro");
        assertEquals(100, calculator.calculatePayment("Male", 25), "Male age 25 should be 100 euro");
        assertEquals(100, calculator.calculatePayment("Male", 35), "Male age 35 should be 100 euro");
    }
    
    @Test
    public void testMaleAge36To50() {
        assertEquals(120, calculator.calculatePayment("Male", 36), "Male age 36 should be 120 euro");
        assertEquals(120, calculator.calculatePayment("Male", 43), "Male age 43 should be 120 euro");
        assertEquals(120, calculator.calculatePayment("Male", 50), "Male age 50 should be 120 euro");
    }
    
    @Test
    public void testMaleAge51To145() {
        assertEquals(140, calculator.calculatePayment("Male", 51), "Male age 51 should be 140 euro");
        assertEquals(140, calculator.calculatePayment("Male", 100), "Male age 100 should be 140 euro");
        assertEquals(140, calculator.calculatePayment("Male", 145), "Male age 145 should be 140 euro");
    }
    
    // Test cases for Female
    @Test
    public void testFemaleAge18To35() {
        assertEquals(80, calculator.calculatePayment("Female", 18), "Female age 18 should be 80 euro");
        assertEquals(80, calculator.calculatePayment("Female", 25), "Female age 25 should be 80 euro");
        assertEquals(80, calculator.calculatePayment("Female", 35), "Female age 35 should be 80 euro");
    }
    
    @Test
    public void testFemaleAge36To50() {
        assertEquals(110, calculator.calculatePayment("Female", 36), "Female age 36 should be 110 euro");
        assertEquals(110, calculator.calculatePayment("Female", 43), "Female age 43 should be 110 euro");
        assertEquals(110, calculator.calculatePayment("Female", 50), "Female age 50 should be 110 euro");
    }
    
    @Test
    public void testFemaleAge51To145() {
        assertEquals(140, calculator.calculatePayment("Female", 51), "Female age 51 should be 140 euro");
        assertEquals(140, calculator.calculatePayment("Female", 100), "Female age 100 should be 140 euro");
        assertEquals(140, calculator.calculatePayment("Female", 145), "Female age 145 should be 140 euro");
    }
    
    // Test cases for Child
    @Test
    public void testChildAge0To17() {
        assertEquals(50, calculator.calculatePayment("Child", 0), "Child age 0 should be 50 euro");
        assertEquals(50, calculator.calculatePayment("Child", 10), "Child age 10 should be 50 euro");
        assertEquals(50, calculator.calculatePayment("Child", 17), "Child age 17 should be 50 euro");
    }
    
    // Boundary test cases
    @Test
    public void testBoundaryValues() {
        // Lower boundaries
        assertEquals(50, calculator.calculatePayment("Child", 0), "Child age 0 (lower boundary)");
        assertEquals(100, calculator.calculatePayment("Male", 18), "Male age 18 (lower boundary)");
        assertEquals(120, calculator.calculatePayment("Male", 36), "Male age 36 (lower boundary)");
        assertEquals(140, calculator.calculatePayment("Male", 51), "Male age 51 (lower boundary)");
        
        // Upper boundaries
        assertEquals(50, calculator.calculatePayment("Child", 17), "Child age 17 (upper boundary)");
        assertEquals(100, calculator.calculatePayment("Male", 35), "Male age 35 (upper boundary)");
        assertEquals(120, calculator.calculatePayment("Male", 50), "Male age 50 (upper boundary)");
        assertEquals(140, calculator.calculatePayment("Male", 145), "Male age 145 (upper boundary)");
    }
    
    // Invalid test cases
    @Test
    public void testInvalidAge() {
        assertThrows(IllegalArgumentException.class, () -> {
            calculator.calculatePayment("Male", -1);
        }, "Negative age should throw exception");
        
        assertThrows(IllegalArgumentException.class, () -> {
            calculator.calculatePayment("Male", 146);
        }, "Age > 145 should throw exception");
        
        assertThrows(IllegalArgumentException.class, () -> {
            calculator.calculatePayment("Child", 18);
        }, "Child age >= 18 should throw exception");
    }
    
    @Test
    public void testInvalidGender() {
        assertThrows(IllegalArgumentException.class, () -> {
            calculator.calculatePayment("Unknown", 25);
        }, "Invalid gender should throw exception");
        
        assertThrows(IllegalArgumentException.class, () -> {
            calculator.calculatePayment("", 25);
        }, "Empty gender should throw exception");
        
        assertThrows(NullPointerException.class, () -> {
            calculator.calculatePayment(null, 25);
        }, "Null gender should throw exception");
    }
    
    // Edge cases between ranges
    @Test
    public void testEdgeCasesBetweenRanges() {
        // Child to Adult transition
        assertEquals(50, calculator.calculatePayment("Child", 17), "Child age 17");
        assertEquals(100, calculator.calculatePayment("Male", 18), "Male age 18");
        assertEquals(80, calculator.calculatePayment("Female", 18), "Female age 18");
        
        // 35 to 36 transition
        assertEquals(100, calculator.calculatePayment("Male", 35), "Male age 35");
        assertEquals(120, calculator.calculatePayment("Male", 36), "Male age 36");
        assertEquals(80, calculator.calculatePayment("Female", 35), "Female age 35");
        assertEquals(110, calculator.calculatePayment("Female", 36), "Female age 36");
        
        // 50 to 51 transition
        assertEquals(120, calculator.calculatePayment("Male", 50), "Male age 50");
        assertEquals(140, calculator.calculatePayment("Male", 51), "Male age 51");
        assertEquals(110, calculator.calculatePayment("Female", 50), "Female age 50");
        assertEquals(140, calculator.calculatePayment("Female", 51), "Female age 51");
    }
}
