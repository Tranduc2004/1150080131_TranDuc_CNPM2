# BT1.1 - Thiết lập Selenium WebDriver với Eclipse/IntelliJ và Maven

## 1) Mục tiêu
- Cài đặt và cấu hình Selenium WebDriver.
- Viết test case kiểm thử chức năng đăng nhập của trang https://www.saucedemo.com/.
- Đảm bảo môi trường: JDK 11+, Maven, trình duyệt Chrome.

## 2) Công nghệ sử dụng
- Java 17 (tương thích yêu cầu JDK 11+)
- Maven
- TestNG
- Selenium WebDriver
- WebDriverManager

## 3) Yêu cầu bắt buộc đã đáp ứng
1. Mỗi `@Test` dùng `@BeforeMethod` để mở trình duyệt mới và `@AfterMethod` để đóng trình duyệt.
2. Dùng Explicit Wait (`WebDriverWait`), không dùng `Thread.sleep()`.
3. Mỗi lệnh assert có message lỗi rõ ràng (tham số thứ 3 của `Assert.assertEquals` hoặc message của `Assert.assertTrue`).
4. Chạy đủ 5 test case theo đề BT1.2.
5. Mỗi test case được chụp màn hình tự động ở cuối test (`PASS/FAIL`).

## 4) Cấu trúc dự án
```
BT1.1/
├─ pom.xml
├─ testng.xml
└─ src/
   └─ test/
      └─ java/
         └─ bt11/
            └─ LoginTest.java
```

## 5) Khung Test Case (theo mẫu bảng)

| TC ID | Trạng thái ban đầu | Hành động / Sự kiện | Trạng thái kết thúc mong đợi | Dữ liệu đặc biệt | Hợp lệ? | Kết quả mong đợi chi tiết |
|---|---|---|---|---|---|---|
| TC_LG_01 | Trang đăng nhập | Nhập Username & Password chuẩn | Đăng nhập thành công | `standard_user / secret_sauce` | Có | Chuyển hướng đến trang sản phẩm (`/inventory.html`). |
| TC_LG_06 | Trang đăng nhập | Đăng nhập tài khoản bị khóa | Báo lỗi tài khoản bị khóa | `locked_out_user / secret_sauce` | Không | Hiển thị lỗi: `Epic sadface: Sorry, this user has been locked out.` |
| TC_LG_08 | Trang đăng nhập | Nhập sai mật khẩu | Báo lỗi sai thông tin | `standard_user / wrong_password` | Không | Hiển thị lỗi: `Epic sadface: Username and password do not match any user in this service` |
| TC_LG_12 | Trang đăng nhập | Để trống Username | Báo lỗi thiếu trường | `"" / secret_sauce` | Không | Hiển thị lỗi: `Epic sadface: Username is required` |
| TC_LG_13 | Trang đăng nhập | Để trống Password | Báo lỗi thiếu trường | `standard_user / ""` | Không | Hiển thị lỗi: `Epic sadface: Password is required` |

## 6) Mapping test method ↔ test case

| Test method (LoginTest.java) | TC ID tương ứng |
|---|---|
| `testLoginSuccess()` | TC_LG_01 |
| `testLoginLockedUser()` | TC_LG_06 |
| `testLoginWrongPassword()` | TC_LG_08 |
| `testLoginEmptyUsername()` | TC_LG_12 |
| `testLoginEmptyPassword()` | TC_LG_13 |

## 7) Cách chạy test
### Chạy toàn bộ test
```bash
mvn test
```

### Chạy theo TestNG suite
```bash
mvn test -Dsurefire.suiteXmlFiles=testng.xml
```

## 8) Kết quả và report
- Report Maven Surefire/TestNG sinh tại:
  - `target/surefire-reports/`
- Ảnh chụp từng testcase sinh tại:
  - `target/screenshots/`
  - Quy tắc tên file: `<tenTestMethod>_PASS.png` hoặc `<tenTestMethod>_FAIL.png`
- Khi nộp bài, chụp màn hình:
  1. Cửa sổ chạy test (5 test case).
  2. File report HTML trong `target/surefire-reports`.
  3. 05 ảnh testcase trong `target/screenshots`.

## 9) Bước chụp màn hình cho từng testcase
1. Chạy lệnh:
   ```bash
   mvn test
   ```
2. Sau khi chạy xong, mở thư mục `target/screenshots/`.
3. Kiểm tra đủ 5 ảnh tương ứng 5 test:
   - `testLoginSuccess_PASS.png`
   - `testLoginWrongPassword_PASS.png`
   - `testLoginEmptyUsername_PASS.png`
   - `testLoginEmptyPassword_PASS.png`
   - `testLoginLockedUser_PASS.png`
4. Nếu testcase fail, tên file sẽ tự đổi thành hậu tố `_FAIL.png` để dễ đối chiếu report.

## 10) Ghi chú
- Có thể xuất hiện warning CDP theo phiên bản Chrome mới, nhưng không ảnh hưởng kết quả test đăng nhập.
- Nếu lỗi không mở được trình duyệt, kiểm tra lại phiên bản Chrome và quyền chạy WebDriver trên máy.
