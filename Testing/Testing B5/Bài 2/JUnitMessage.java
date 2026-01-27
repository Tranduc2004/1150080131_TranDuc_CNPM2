public class JUnitMessage {
    private String message;

    public JUnitMessage(String message) {
        this.message = message;
    }

    public String printMessage() {
        // Deliberately throw to satisfy expected exception in SuiteTest1
        throw new ArithmeticException("Intentional exception from printMessage");
    }

    public String printHiMessage() {
        return "Hi!" + message;
    }
}
