package dtm.base;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.OutputType;
import org.openqa.selenium.TakesScreenshot;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.testng.ITestResult;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;

import java.io.IOException;
import java.lang.reflect.Method;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.time.Duration;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public abstract class BaseTest {
    private static final ThreadLocal<WebDriver> DRIVER = new ThreadLocal<>();

    @BeforeMethod(alwaysRun = true)
    public void setUp(Method method) {
        WebDriverManager.chromedriver().setup();

        ChromeOptions options = new ChromeOptions();
        WebDriver driver = new ChromeDriver(options);
        driver.manage().window().maximize();
        driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(10));

        DRIVER.set(driver);
        System.out.println("[START] Running test: " + method.getName());
    }

    @AfterMethod(alwaysRun = true)
    public void tearDown(ITestResult result) {
        WebDriver driver = DRIVER.get();
        try {
            if (driver != null && result.getStatus() == ITestResult.FAILURE) {
                captureScreenshot(result, driver);
            }
        } finally {
            if (driver != null) {
                driver.quit();
            }
            DRIVER.remove();
            System.out.println("[END] Test finished: " + result.getMethod().getMethodName());
        }
    }

    public WebDriver getDriver() {
        return DRIVER.get();
    }

    private void captureScreenshot(ITestResult result, WebDriver driver) {
        try {
            Path screenshotDir = Paths.get("screenshots");
            Files.createDirectories(screenshotDir);

            String timestamp = LocalDateTime.now().format(DateTimeFormatter.ofPattern("yyyyMMdd_HHmmss"));
            String filename = result.getMethod().getMethodName() + "_" + timestamp + ".png";
            Path targetPath = screenshotDir.resolve(filename);

            Path sourcePath = ((TakesScreenshot) driver).getScreenshotAs(OutputType.FILE).toPath();
            Files.copy(sourcePath, targetPath, StandardCopyOption.REPLACE_EXISTING);
            System.out.println("[SCREENSHOT] Saved to: " + targetPath.toAbsolutePath());
        } catch (IOException ex) {
            System.out.println("[SCREENSHOT] Failed to save screenshot: " + ex.getMessage());
        }
    }
}