package dtm.pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.time.Duration;
import java.util.ArrayList;
import java.util.List;

public class CartPage {
    private final WebDriver driver;
    private final WebDriverWait wait;

    @FindBy(id = "checkout")
    private WebElement checkoutButton;

    @FindBy(id = "continue-shopping")
    private WebElement continueShoppingButton;

    @FindBy(css = ".cart_item .inventory_item_name")
    private List<WebElement> cartItemNames;

    private final By cartItemNamesBy = By.cssSelector(".cart_item .inventory_item_name");

    public CartPage(WebDriver driver) {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, Duration.ofSeconds(10));
        PageFactory.initElements(driver, this);
    }

    public boolean hasProduct(String productName) {
        By product = By.xpath("//div[contains(@class,'inventory_item_name') and normalize-space(.)='" + productName + "']");
        return !driver.findElements(product).isEmpty();
    }

    public List<String> layDanhSachTenSanPhamTrongGio() {
        wait.until(ExpectedConditions.presenceOfAllElementsLocatedBy(cartItemNamesBy));
        List<String> names = new ArrayList<>();
        for (WebElement item : cartItemNames) {
            names.add(item.getText().trim());
        }
        return names;
    }

    public int laySoLuongSanPhamTrongGio() {
        return driver.findElements(cartItemNamesBy).size();
    }

    public void xoaSanPhamTheoTen(String tenSanPham) {
        String slug = tenSanPham.toLowerCase()
                .replaceAll("[^a-z0-9]+", "-")
                .replaceAll("^-+|-+$", "");
        By removeButton = By.id("remove-" + slug);
        wait.until(ExpectedConditions.elementToBeClickable(removeButton)).click();
    }

    public void xoaTatCaSanPham() {
        while (laySoLuongSanPhamTrongGio() > 0) {
            List<WebElement> removeButtons = driver.findElements(By.cssSelector("button[id^='remove-']"));
            if (removeButtons.isEmpty()) {
                break;
            }
            wait.until(ExpectedConditions.elementToBeClickable(removeButtons.get(0))).click();
        }
    }

    public void clickContinueShopping() {
        wait.until(ExpectedConditions.elementToBeClickable(continueShoppingButton)).click();
    }

    public boolean isCheckoutEnabled() {
        return checkoutButton.isEnabled();
    }

    public void clickCheckout() {
        wait.until(ExpectedConditions.elementToBeClickable(checkoutButton)).click();
    }
}