package bt22.tests;

import bt22.base.DriverFactory;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Parameters;
import org.testng.annotations.Test;

import java.time.Duration;

public class LoginTest {

    @BeforeMethod
    @Parameters("browser")
    public void setUp(String browser) {
        DriverFactory.initDriver(browser);
    }

    @Test
    public void testLoginPageDisplayed() {
        WebDriver driver = DriverFactory.getDriver();
        WebDriverWait wait = new WebDriverWait(driver, Duration.ofSeconds(10));

        driver.get("https://www.saucedemo.com/");
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("login-button")));

        String threadName = Thread.currentThread().getName();
        System.out.println("[" + threadName + "] LoginTest - current URL: " + driver.getCurrentUrl());

        holdForManualScreenshot();

        Assert.assertTrue(driver.getTitle().contains("Swag Labs"), "Tieu de trang dang nhap khong dung");
    }

    @AfterMethod
    public void tearDown() {
        DriverFactory.quitDriver();
    }

    private void holdForManualScreenshot() {
        try {
            Thread.sleep(10000);
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
            throw new RuntimeException("Bi ngat trong luc cho chup man hinh", e);
        }
    }
}
