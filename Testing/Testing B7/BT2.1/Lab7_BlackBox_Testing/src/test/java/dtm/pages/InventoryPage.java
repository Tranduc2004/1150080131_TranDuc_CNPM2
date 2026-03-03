package dtm.pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.time.Duration;
import java.util.ArrayList;
import java.util.List;

public class InventoryPage {
    private final WebDriver driver;
    private final WebDriverWait wait;

    @FindBy(css = "span.title")
    private WebElement title;

    @FindBy(css = ".product_sort_container")
    private WebElement sortDropdown;

    @FindBy(css = "button.btn_inventory")
    private List<WebElement> actionButtons;

    @FindBy(css = ".shopping_cart_badge")
    private List<WebElement> cartBadges;

    @FindBy(css = ".shopping_cart_link")
    private WebElement cartLink;

    @FindBy(css = ".inventory_item_name")
    private List<WebElement> productNames;

    @FindBy(css = ".inventory_item_price")
    private List<WebElement> productPrices;

    private final By cartBadge = By.cssSelector(".shopping_cart_badge");

    public InventoryPage(WebDriver driver) {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, Duration.ofSeconds(10));
        PageFactory.initElements(driver, this);
    }

    public boolean isLoaded() {
        wait.until(ExpectedConditions.visibilityOf(title));
        return "Products".equalsIgnoreCase(title.getText().trim());
    }

    public void themSanPhamTheoTen(String tenSanPham) {
        addProductToCart(tenSanPham);
    }

    public void themNSanPhamDauTien(int n) {
        int remaining = n;
        for (WebElement button : actionButtons) {
            if (remaining <= 0) {
                break;
            }
            String text = button.getText().trim().toLowerCase();
            if (text.contains("add to cart")) {
                wait.until(ExpectedConditions.elementToBeClickable(button)).click();
                remaining--;
            }
        }
    }

    public int laySoLuongBadge() {
        return getCartBadgeCount();
    }

    public void sortSanPham(String option) {
        wait.until(ExpectedConditions.visibilityOf(sortDropdown));
        new Select(sortDropdown).selectByValue(option);
    }

    public List<String> layDanhSachTenSanPham() {
        List<String> result = new ArrayList<>();
        for (WebElement name : productNames) {
            result.add(name.getText().trim());
        }
        return result;
    }

    public List<Double> layDanhSachGiaSanPham() {
        List<Double> result = new ArrayList<>();
        for (WebElement price : productPrices) {
            String raw = price.getText().trim().replace("$", "");
            result.add(Double.parseDouble(raw));
        }
        return result;
    }

    public void addProductToCart(String productName) {
        String slug = toSauceDemoSlug(productName);
        By addButton = By.id("add-to-cart-" + slug);
        wait.until(ExpectedConditions.elementToBeClickable(addButton)).click();
    }

    public boolean isProductVisible(String productName) {
        By product = By.xpath("//div[contains(@class,'inventory_item_name') and normalize-space(.)='" + productName + "']");
        return !driver.findElements(product).isEmpty();
    }

    public int getCartBadgeCount() {
        if (cartBadges.isEmpty() || driver.findElements(cartBadge).isEmpty()) {
            return 0;
        }
        return Integer.parseInt(driver.findElement(cartBadge).getText().trim());
    }

    public void goToCart() {
        wait.until(ExpectedConditions.elementToBeClickable(cartLink)).click();
    }

    private String toSauceDemoSlug(String productName) {
        return productName.toLowerCase()
                .replaceAll("[^a-z0-9]+", "-")
                .replaceAll("^-+|-+$", "");
    }
}