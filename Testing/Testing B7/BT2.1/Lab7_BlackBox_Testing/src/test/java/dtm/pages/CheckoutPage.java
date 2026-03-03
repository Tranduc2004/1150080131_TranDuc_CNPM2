package dtm.pages;

import org.openqa.selenium.By;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.TimeoutException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.time.Duration;

public class CheckoutPage {
    private final WebDriver driver;
    private final WebDriverWait wait;

    private final By firstNameInput = By.cssSelector("#first-name, [data-test='firstName']");
    private final By lastNameInput = By.cssSelector("#last-name, [data-test='lastName']");
    private final By postalCodeInput = By.cssSelector("#postal-code, [data-test='postalCode']");
    private final By continueButton = By.cssSelector("#continue, [data-test='continue'], button#continue");
    private final By finishButton = By.cssSelector("#finish, [data-test='finish'], button#finish");
    private final By cancelStepOneButton = By.id("cancel");
    private final By cancelStepTwoButton = By.id("cancel");
    private final By completeHeader = By.cssSelector("h2.complete-header, [data-test='complete-header']");
    private final By backHomeButton = By.id("back-to-products");
    private final By errorMessage = By.cssSelector("h3[data-test='error'], div.error-message-container h3");
    private final By itemTotalLabel = By.cssSelector(".summary_subtotal_label, [data-test='subtotal-label']");
    private final By taxLabel = By.cssSelector(".summary_tax_label, [data-test='tax-label']");
    private final By totalLabel = By.cssSelector(".summary_total_label, [data-test='total-label']");
    private final By shippingInfo = By.xpath("//div[contains(@class,'summary_info_label') and contains(.,'Shipping Information')]/following-sibling::div[1]");
    private final By paymentInfo = By.xpath("//div[contains(@class,'summary_info_label') and contains(.,'Payment Information')]/following-sibling::div[1]");

    public CheckoutPage(WebDriver driver) {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, Duration.ofSeconds(10));
    }

    public void fillCustomerInfo(String firstName, String lastName, String postalCode) {
        wait.until(ExpectedConditions.visibilityOfElementLocated(firstNameInput)).clear();
        driver.findElement(firstNameInput).sendKeys(firstName);
        driver.findElement(lastNameInput).clear();
        driver.findElement(lastNameInput).sendKeys(lastName);
        driver.findElement(postalCodeInput).clear();
        driver.findElement(postalCodeInput).sendKeys(postalCode);

        WebElement continueElement = wait.until(ExpectedConditions.elementToBeClickable(continueButton));
        continueElement.click();

        boolean movedToStepTwo = wait.until(d ->
                !d.findElements(finishButton).isEmpty() || !d.findElements(errorMessage).isEmpty());

        if (movedToStepTwo && !driver.findElements(errorMessage).isEmpty()) {
            String error = driver.findElement(errorMessage).getText();
            throw new IllegalStateException("Checkout step one failed: " + error);
        }
    }

    public void nhapThongTinKhachHang(String firstName, String lastName, String postalCode) {
        wait.until(ExpectedConditions.visibilityOfElementLocated(firstNameInput)).clear();
        driver.findElement(firstNameInput).sendKeys(firstName == null ? "" : firstName);
        driver.findElement(lastNameInput).clear();
        driver.findElement(lastNameInput).sendKeys(lastName == null ? "" : lastName);
        driver.findElement(postalCodeInput).clear();
        driver.findElement(postalCodeInput).sendKeys(postalCode == null ? "" : postalCode);
    }

    public void clickContinue() {
        wait.until(ExpectedConditions.elementToBeClickable(continueButton)).click();
    }

    public void clickCancelStepOne() {
        wait.until(ExpectedConditions.elementToBeClickable(cancelStepOneButton)).click();
    }

    public void clickCancelStepTwo() {
        wait.until(ExpectedConditions.elementToBeClickable(cancelStepTwoButton)).click();
    }

    public boolean isCheckoutInfoStepLoaded() {
        try {
            wait.until(ExpectedConditions.or(
                    ExpectedConditions.urlContains("/checkout-step-one.html"),
                    ExpectedConditions.visibilityOfElementLocated(firstNameInput)));
            return driver.getCurrentUrl().contains("/checkout-step-one.html")
                    || !driver.findElements(firstNameInput).isEmpty();
        } catch (TimeoutException ex) {
            return false;
        }
    }

    public String layThongBaoLoi() {
        if (driver.findElements(errorMessage).isEmpty()) {
            return "";
        }
        return wait.until(ExpectedConditions.visibilityOfElementLocated(errorMessage)).getText();
    }

    public boolean isCheckoutStepTwoLoaded() {
        try {
            wait.until(ExpectedConditions.or(
                    ExpectedConditions.urlContains("/checkout-step-two.html"),
                    ExpectedConditions.presenceOfElementLocated(finishButton)));
            return driver.getCurrentUrl().contains("/checkout-step-two.html")
                    || !driver.findElements(finishButton).isEmpty();
        } catch (TimeoutException ex) {
            return false;
        }
    }

    public double layItemTotal() {
        String text = wait.until(ExpectedConditions.visibilityOfElementLocated(itemTotalLabel)).getText();
        return parseMoney(text);
    }

    public double layTax() {
        String text = wait.until(ExpectedConditions.visibilityOfElementLocated(taxLabel)).getText();
        return parseMoney(text);
    }

    public double layTotal() {
        String text = wait.until(ExpectedConditions.visibilityOfElementLocated(totalLabel)).getText();
        return parseMoney(text);
    }

    public String layShippingInfo() {
        return wait.until(ExpectedConditions.visibilityOfElementLocated(shippingInfo)).getText();
    }

    public String layPaymentInfo() {
        return wait.until(ExpectedConditions.visibilityOfElementLocated(paymentInfo)).getText();
    }

    public void finishOrder() {
        WebElement finishElement = wait.until(ExpectedConditions.presenceOfElementLocated(finishButton));
        ((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView({block:'center'});", finishElement);
        wait.until(ExpectedConditions.elementToBeClickable(finishElement)).click();
    }

    public boolean isOrderCompleted() {
        return wait.until(ExpectedConditions.visibilityOfElementLocated(completeHeader)).isDisplayed();
    }

    public String layCompleteHeader() {
        return wait.until(ExpectedConditions.visibilityOfElementLocated(completeHeader)).getText().trim();
    }

    public void clickBackHome() {
        wait.until(ExpectedConditions.elementToBeClickable(backHomeButton)).click();
    }

    private double parseMoney(String text) {
        int idx = text.indexOf("$");
        if (idx < 0) {
            return 0;
        }
        return Double.parseDouble(text.substring(idx + 1).trim());
    }
}