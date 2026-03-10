# BT2.1 - Xây dựng TestNG Suite XML

## 1) Mục tiêu bài thực hành
- Xây dựng `testng.xml` để quản lý 3 class kiểm thử: `LoginTest`, `CartTest`, `CheckoutTest`.
- Mỗi class có ít nhất 2 test method.
- Phân nhóm test theo `smoke` (mỗi class 1 test) và `regression` (tất cả test).
- Chạy 2 lượt (`smoke` và `regression`) và so sánh kết quả console output.

## 2) Công nghệ sử dụng
- Java 17 (tương thích JDK 11+)
- Maven
- TestNG

## 3) Cấu trúc dự án
```
BT2.1/
├─ pom.xml
├─ testng.xml
├─ outputs/
│  ├─ smoke-run.txt
│  └─ regression-run.txt
└─ src/
   └─ test/
      └─ java/
         └─ bt21/
            ├─ LoginTest.java
            ├─ CartTest.java
            └─ CheckoutTest.java
```

## 4) Thiết kế test class và groups

### 4.1 LoginTest
- `testLoginWithValidCredential()` → groups: `smoke`, `regression`
- `testLoginWithInvalidPassword()` → groups: `regression`

### 4.2 CartTest
- `testAddItemToCart()` → groups: `smoke`, `regression`
- `testRemoveItemFromCart()` → groups: `regression`

### 4.3 CheckoutTest
- `testCheckoutWithValidInformation()` → groups: `smoke`, `regression`
- `testCheckoutWithEmptyPostalCode()` → groups: `regression`

## 5) Cấu hình testng.xml

### Lượt 1 - Chạy nhóm smoke
```xml
<groups>
    <run>
        <include name="smoke"/>
    </run>
</groups>
```

### Lượt 2 - Cấu hình lại chạy nhóm regression
```xml
<groups>
    <run>
        <include name="regression"/>
    </run>
</groups>
```

## 6) Lệnh chạy và lưu console output

### Chạy lượt smoke
```bash
mvn test *> .\outputs\smoke-run.txt
```

### Chạy lượt regression
```bash
mvn test *> .\outputs\regression-run.txt
```

## 7) Kết quả thực tế và so sánh
- Kết quả smoke: `Tests run: 3, Failures: 0, Errors: 0, Skipped: 0`
- Kết quả regression: `Tests run: 6, Failures: 0, Errors: 0, Skipped: 0`

### Nhận xét
- Nhóm `smoke` chỉ chạy 1 test mỗi class ⇒ tổng 3 test.
- Nhóm `regression` chạy toàn bộ test trong 3 class ⇒ tổng 6 test.
- Không có test fail ở cả 2 lượt chạy.

## 8) File minh chứng nộp bài
- Console lượt smoke: `outputs/smoke-run.txt`
- Console lượt regression: `outputs/regression-run.txt`
- Test report Maven/TestNG: `target/surefire-reports/`
