package bt62.tests;

import bt62.pages.TextBoxPage;
import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.OutputType;
import org.openqa.selenium.TakesScreenshot;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
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
import java.nio.file.StandardCopyOption;

public class TextBoxWhiteBoxTest {

    private WebDriver driver;
    private TextBoxPage textBoxPage;

    @BeforeMethod
    public void setUp() {
        WebDriverManager.chromedriver().setup();

        ChromeOptions options = new ChromeOptions();
        options.addArguments("--window-size=1920,1080");
        options.addArguments("--disable-notifications");
        options.addArguments("--remote-allow-origins=*");

        driver = new ChromeDriver(options);
        textBoxPage = new TextBoxPage(driver);
        textBoxPage.open();
    }

    @Test(description = "TC01 - Boundary: Empty input -> khong hien thi output")
    public void shouldNotDisplayOutputWhenAllFieldsEmpty() {
        textBoxPage.fillAndSubmit("", "", "");

        Assert.assertFalse(textBoxPage.isOutputDisplayed(),
                "Khong duoc hien thi output khi tat ca truong rong.");
    }

    @Test(description = "TC02 - Boundary: Space-only input -> van hien thi output (khong trim)")
    public void shouldDisplayOutputWhenOnlySpaces() {
        textBoxPage.fillAndSubmit("   ", "   ", "   ");

        Assert.assertTrue(textBoxPage.isOutputDisplayed(),
                "He thong hien tai van hien thi output khi chi nhap khoang trang.");
    }

    @Test(description = "TC03 - Boundary: Invalid email format -> email bi danh dau loi")
    public void shouldMarkEmailInvalidWhenFormatIsWrong() {
        textBoxPage.fillAndSubmit("Nguyen Van A", "abc", "Ha Noi");

        Assert.assertTrue(textBoxPage.isEmailInvalidStyleApplied(),
                "Email sai dinh dang phai bi danh dau field-error.");
    }

    @Test(description = "TC04 - Valid flow: du lieu hop le -> output hien thi")
    public void shouldDisplayOutputWhenInputIsValid() {
        textBoxPage.fillAndSubmit("Nguyen Van A", "a@gmail.com", "Ha Noi");

        Assert.assertTrue(textBoxPage.isOutputDisplayed(),
                "Output phai hien thi voi input hop le.");
        Assert.assertTrue(textBoxPage.getOutputText().contains("Nguyen Van A"),
                "Output phai chua ho ten da nhap.");
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
            Files.copy(sourceFile.toPath(), targetPath, StandardCopyOption.REPLACE_EXISTING);
        } catch (IOException e) {
            throw new RuntimeException("Khong the chup man hinh cho test: " + result.getMethod().getMethodName(), e);
        }
    }
}
