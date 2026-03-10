package bt61;

public class PhoneValidator {

    public boolean isValid(String phone) {
        if (phone == null || phone.isBlank()) {
            return false;
        }

        String compact = phone.replace(" ", "");
        if (!compact.matches("[0-9+]+")) {
            return false;
        }

        if (compact.startsWith("+84")) {
            compact = "0" + compact.substring(3);
        } else if (!compact.startsWith("0")) {
            return false;
        }

        return compact.matches("0[35789]\\d{8}");
    }
}
