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

public class CartTest {

    @BeforeMethod
    @Parameters("browser")
    public void setUp(String browser) {
        DriverFactory.initDriver(browser);
    }

    @Test
    public void testCartIconVisibleAfterLogin() {
        WebDriver driver = DriverFactory.getDriver();
        WebDriverWait wait = new WebDriverWait(driver, Duration.ofSeconds(10));

        driver.get("https://www.saucedemo.com/");
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("user-name"))).sendKeys("standard_user");
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("password"))).sendKeys("secret_sauce");
        wait.until(ExpectedConditions.elementToBeClickable(By.id("login-button"))).click();

        wait.until(ExpectedConditions.visibilityOfElementLocated(By.className("shopping_cart_link")));

        String threadName = Thread.currentThread().getName();
        System.out.println("[" + threadName + "] CartTest - inventory URL: " + driver.getCurrentUrl());

        holdForManualScreenshot();

        Assert.assertTrue(driver.getCurrentUrl().contains("inventory"), "Khong dieu huong den trang inventory sau dang nhap");
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
