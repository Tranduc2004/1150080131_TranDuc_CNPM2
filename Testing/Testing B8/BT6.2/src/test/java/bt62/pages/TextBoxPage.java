package bt62.pages;

import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;

public class TextBoxPage {
    private final WebDriver driver;

    @FindBy(id = "userName")
    private WebElement nameField;

    @FindBy(id = "userEmail")
    private WebElement emailField;

    @FindBy(id = "currentAddress")
    private WebElement currentAddressField;

    @FindBy(id = "permanentAddress")
    private WebElement permanentAddressField;

    @FindBy(id = "submit")
    private WebElement submitBtn;

    @FindBy(id = "output")
    private WebElement outputSection;

    public TextBoxPage(WebDriver driver) {
        this.driver = driver;
        PageFactory.initElements(driver, this);
    }

    public void open() {
        driver.get("https://demoqa.com/text-box");
    }

    public void fillAndSubmit(String name, String email, String address) {
        nameField.clear();
        if (name != null) {
            nameField.sendKeys(name);
        }

        emailField.clear();
        if (email != null) {
            emailField.sendKeys(email);
        }

        currentAddressField.clear();
        if (address != null) {
            currentAddressField.sendKeys(address);
        }

        permanentAddressField.clear();
        if (address != null) {
            permanentAddressField.sendKeys(address);
        }

        ((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView(true);", submitBtn);
        ((JavascriptExecutor) driver).executeScript("arguments[0].click();", submitBtn);
    }

    public boolean isOutputDisplayed() {
        if (driver.findElements(By.id("output")).isEmpty()) {
            return false;
        }
        return outputSection.isDisplayed();
    }

    public String getOutputText() {
        return outputSection.getText();
    }

    public boolean isEmailInvalidStyleApplied() {
        String classAttr = emailField.getAttribute("class");
        return classAttr != null && classAttr.contains("field-error");
    }
}
