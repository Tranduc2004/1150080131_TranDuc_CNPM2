public class PaymentCalculatorLogic {
    
    /**
     * Calculate payment based on gender and age
     * @param gender "Male", "Female", or "Child"
     * @param age Age in years
     * @return Payment amount in euros
     * @throws IllegalArgumentException if age or gender is invalid
     */
    public int calculatePayment(String gender, int age) {
        if (gender == null) {
            throw new NullPointerException("Gender cannot be null");
        }
        
        if (gender.isEmpty()) {
            throw new IllegalArgumentException("Gender cannot be empty");
        }
        
        if (age < 0 || age > 145) {
            throw new IllegalArgumentException("Age must be between 0 and 145");
        }
        
        switch (gender) {
            case "Child":
                if (age >= 0 && age <= 17) {
                    return 50;
                } else {
                    throw new IllegalArgumentException("Child age must be between 0 and 17");
                }
                
            case "Male":
                if (age < 18) {
                    throw new IllegalArgumentException("Male age must be 18 or above");
                }
                if (age >= 18 && age <= 35) {
                    return 100;
                } else if (age >= 36 && age <= 50) {
                    return 120;
                } else if (age >= 51 && age <= 145) {
                    return 140;
                }
                break;
                
            case "Female":
                if (age < 18) {
                    throw new IllegalArgumentException("Female age must be 18 or above");
                }
                if (age >= 18 && age <= 35) {
                    return 80;
                } else if (age >= 36 && age <= 50) {
                    return 110;
                } else if (age >= 51 && age <= 145) {
                    return 140;
                }
                break;
                
            default:
                throw new IllegalArgumentException("Invalid gender: " + gender);
        }
        
        throw new IllegalArgumentException("Invalid age or gender combination");
    }
}
