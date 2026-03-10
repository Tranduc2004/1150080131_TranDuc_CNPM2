package dtm;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.By;
import org.openqa.selenium.OutputType;
import org.openqa.selenium.TakesScreenshot;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
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

public class TitleTest {
    WebDriver driver;

    @BeforeMethod
    public void setUp() {
        WebDriverManager.chromedriver().setup();
        driver = new ChromeDriver();
        driver.manage().window().maximize();
        driver.get("https://www.saucedemo.com");
    }

    @Test(description = "Kiem thu tieu de trang chu")
    public void testTitle() {
        String expectedTitle = "Swag Labs";
        String actualTitle = driver.getTitle();
        Assert.assertEquals(actualTitle, expectedTitle, "Tieu de trang khong dung!");
    }

    @Test(description = "Kiem thu URL trang chu")
    public void testURL() {
        String actualUrl = driver.getCurrentUrl();
        Assert.assertTrue(actualUrl.contains("saucedemo"), "URL khong hop le!");
    }

    @Test(description = "Kiem thu source code trang")
    public void testPageSource() {
        String pageSource = driver.getPageSource();
        Assert.assertTrue(pageSource.contains("Swag Labs"), "Page source khong chua noi dung mong doi!");
    }

    @Test(description = "Kiem thu form dang nhap hien thi")
    public void testLoginFormDisplayed() {
        WebElement usernameInput = driver.findElement(By.id("user-name"));
        WebElement passwordInput = driver.findElement(By.id("password"));
        WebElement loginButton = driver.findElement(By.id("login-button"));

        Assert.assertTrue(usernameInput.isDisplayed(), "Khong hien thi o nhap Username!");
        Assert.assertTrue(passwordInput.isDisplayed(), "Khong hien thi o nhap Password!");
        Assert.assertTrue(loginButton.isDisplayed(), "Khong hien thi nut Login!");
    }

    @AfterMethod
    public void tearDown(ITestResult result) {
        if (driver != null) {
            captureScreenshot(result);
            driver.quit();
        }
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
            throw new RuntimeException("Khong the chup man hinh cho test: " + result.getMethod().getMethodName(), e);
        }
    }
}
