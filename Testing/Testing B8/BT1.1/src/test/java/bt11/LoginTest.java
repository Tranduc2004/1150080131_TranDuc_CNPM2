package bt11;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.By;
import org.openqa.selenium.OutputType;
import org.openqa.selenium.TakesScreenshot;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.ITestResult;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.time.Duration;

public class LoginTest {
    private static final String BASE_URL = "https://www.saucedemo.com/";

    private WebDriver driver;
    private WebDriverWait wait;

    @BeforeMethod
    public void setUp() {
        WebDriverManager.chromedriver().setup();
        driver = new ChromeDriver();
        driver.manage().window().maximize();
        wait = new WebDriverWait(driver, Duration.ofSeconds(10));
        driver.get(BASE_URL);
    }

    @AfterMethod
    public void tearDown(ITestResult result) {
        if (driver != null) {
            captureScreenshot(result);
            driver.quit();
        }
    }

    @Test
    public void testLoginSuccess() {
        login("standard_user", "secret_sauce");

        boolean navigatedToInventory = wait.until(ExpectedConditions.urlContains("/inventory.html"));
        Assert.assertTrue(
                navigatedToInventory,
                "Đăng nhập hợp lệ nhưng không chuyển sang trang inventory."
        );

        Assert.assertEquals(
                driver.getCurrentUrl(),
                "https://www.saucedemo.com/inventory.html",
                "URL sau đăng nhập không đúng trang inventory."
        );
    }

    @Test
    public void testLoginWrongPassword() {
        login("standard_user", "wrong_password");

        String actualError = getErrorMessage();
        String expectedError = "Epic sadface: Username and password do not match any user in this service";

        Assert.assertEquals(
                actualError,
                expectedError,
                "Nhập sai mật khẩu nhưng thông báo lỗi không đúng."
        );
    }

    @Test
    public void testLoginEmptyUsername() {
        login("", "secret_sauce");

        String actualError = getErrorMessage();
        String expectedError = "Epic sadface: Username is required";

        Assert.assertEquals(
                actualError,
                expectedError,
                "Bỏ trống username nhưng thông báo lỗi không phải 'Username is required'."
        );
    }

    @Test
    public void testLoginEmptyPassword() {
        login("standard_user", "");

        String actualError = getErrorMessage();
        String expectedError = "Epic sadface: Password is required";

        Assert.assertEquals(
                actualError,
                expectedError,
                "Bỏ trống password nhưng thông báo lỗi không phải 'Password is required'."
        );
    }

    @Test
    public void testLoginLockedUser() {
        login("locked_out_user", "secret_sauce");

        String actualError = getErrorMessage();
        String expectedError = "Epic sadface: Sorry, this user has been locked out.";

        Assert.assertEquals(
                actualError,
                expectedError,
                "Đăng nhập bằng locked_out_user nhưng thông báo khóa tài khoản không đúng."
        );
    }

    private void login(String username, String password) {
        WebElement usernameInput = wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("user-name")));
        WebElement passwordInput = wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("password")));
        WebElement loginButton = wait.until(ExpectedConditions.elementToBeClickable(By.id("login-button")));

        usernameInput.clear();
        usernameInput.sendKeys(username);

        passwordInput.clear();
        passwordInput.sendKeys(password);

        loginButton.click();
    }

    private String getErrorMessage() {
        WebElement errorElement = wait.until(
                ExpectedConditions.visibilityOfElementLocated(By.cssSelector("h3[data-test='error']"))
        );
        return errorElement.getText().trim();
    }

    private void captureScreenshot(ITestResult result) {
        try {
            Path screenshotDir = Paths.get("target", "screenshots");
            Files.createDirectories(screenshotDir);

            String status = result.isSuccess() ? "PASS" : "FAIL";
            String fileName = result.getMethod().getMethodName() + "_" + status + ".png";
            Path targetPath = screenshotDir.resolve(fileName);

            File sourceFile = ((TakesScreenshot) driver).getScreenshotAs(OutputType.FILE);
            Files.copy(sourceFile.toPath(), targetPath, java.nio.file.StandardCopyOption.REPLACE_EXISTING);
        } catch (IOException e) {
            throw new RuntimeException("Không thể chụp màn hình cho test case: " + result.getMethod().getMethodName(), e);
        }
    }
}
