package dtm.pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.time.Duration;

public class LoginPage {
    private final WebDriver driver;
    private final WebDriverWait wait;

    @FindBy(id = "user-name")
    private WebElement userNameField;

    @FindBy(id = "password")
    private WebElement passwordField;

    @FindBy(id = "login-button")
    private WebElement loginButton;

    @FindBy(css = "h3[data-test='error']")
    private WebElement errorMessage;

    public LoginPage(WebDriver driver) {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, Duration.ofSeconds(6));
        PageFactory.initElements(driver, this);
    }

    public void open(String baseUrl) {
        driver.get(baseUrl);
    }

    public void nhapUsername(String username) {
        String safeUsername = username == null ? "" : username;
        wait.until(ExpectedConditions.visibilityOf(userNameField));
        userNameField.clear();
        userNameField.sendKeys(safeUsername);
    }

    public void nhapPassword(String password) {
        String safePassword = password == null ? "" : password;
        passwordField.clear();
        passwordField.sendKeys(safePassword);
    }

    public void clickDangNhap() {
        wait.until(ExpectedConditions.elementToBeClickable(loginButton)).click();
    }

    public void dangNhap(String user, String pass) {
        nhapUsername(user);
        nhapPassword(pass);
        clickDangNhap();
    }

    public void login(String username, String password) {
        dangNhap(username, password);
    }

    public boolean isErrorVisible() {
        return !driver.findElements(org.openqa.selenium.By.cssSelector("h3[data-test='error']")).isEmpty();
    }

    public String layThongBaoLoi() {
        if (!isErrorVisible()) {
            return "";
        }
        return wait.until(ExpectedConditions.visibilityOf(errorMessage)).getText();
    }

    public String getErrorText() {
        return layThongBaoLoi();
    }

    public boolean isLoginButtonEnabled() {
        return loginButton.isEnabled();
    }

    public boolean isDangOTrangSanPham() {
        return driver.getCurrentUrl().contains("/inventory.html");
    }

    public boolean isInInventoryPage() {
        return isDangOTrangSanPham();
    }
}