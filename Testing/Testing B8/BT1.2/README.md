# BT1.2 - Kiểm thử tiêu đề trang web (Selenium + TestNG + Maven)

## 1) Mục tiêu
- Tạo project Maven tên `Bai1_Selenium`.
- Kiểm thử trang https://www.saucedemo.com với các tiêu chí theo đề.
- Bổ sung test tự thiết kế cho `page source` và hiển thị form đăng nhập.

## 2) Công nghệ sử dụng
- Java 17 (tương thích yêu cầu JDK 11+)
- Maven
- TestNG
- Selenium WebDriver
- WebDriverManager

## 3) Yêu cầu bắt buộc đã đáp ứng
1. Có test kiểm thử tiêu đề trang chủ (`testTitle`).
2. Có test kiểm thử URL trang chủ (`testURL`).
3. Có thêm test tự thiết kế kiểm thử nguồn trang (`testPageSource`).
4. Có thêm test tự thiết kế kiểm thử form đăng nhập hiển thị (`testLoginFormDisplayed`).
5. Mỗi `@Test` dùng `@BeforeMethod` để mở trình duyệt mới và `@AfterMethod` để đóng trình duyệt.
6. Mỗi assert có thông báo lỗi rõ ràng.
7. Mỗi testcase được chụp màn hình tự động cuối test (`PASS/FAIL`).

## 4) Cấu trúc dự án
```
BT1.2/
├─ pom.xml
├─ testng.xml
└─ src/
   └─ test/
      └─ java/
         └─ dtm/
            └─ TitleTest.java
```

## 5) Khung Test Case (theo mẫu bảng)

| TC ID | Trạng thái ban đầu | Hành động / Sự kiện | Trạng thái kết thúc mong đợi | Dữ liệu đặc biệt | Hợp lệ? | Kết quả mong đợi chi tiết |
|---|---|---|---|---|---|---|
| TC_TT_01 | Mở trang đăng nhập | Kiểm tra tiêu đề trang | Tiêu đề đúng | `https://www.saucedemo.com` | Có | Tiêu đề trang bằng `Swag Labs`. |
| TC_TT_02 | Mở trang đăng nhập | Kiểm tra URL | URL hợp lệ | `https://www.saucedemo.com` | Có | URL hiện tại chứa `saucedemo`. |
| TC_TT_03 | Mở trang đăng nhập | Kiểm tra page source | Nguồn trang hợp lệ | `Page Source` | Có | Source chứa chuỗi `Swag Labs`. |
| TC_TT_04 | Mở trang đăng nhập | Kiểm tra form đăng nhập hiển thị | Form hiển thị đầy đủ | `user-name`, `password`, `login-button` | Có | Ô Username, ô Password và nút Login đều hiển thị. |

## 6) Mapping test method ↔ test case

| Test method (TitleTest.java) | TC ID tương ứng |
|---|---|
| `testTitle()` | TC_TT_01 |
| `testURL()` | TC_TT_02 |
| `testPageSource()` | TC_TT_03 |
| `testLoginFormDisplayed()` | TC_TT_04 |

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
  1. Cửa sổ chạy test (4 test case).
  2. File report HTML trong `target/surefire-reports`.
  3. 04 ảnh testcase trong `target/screenshots`.

## 9) Bước chụp màn hình cho từng testcase
1. Chạy lệnh:
   ```bash
   mvn test
   ```
2. Sau khi chạy xong, mở thư mục `target/screenshots/`.
3. Kiểm tra đủ 4 ảnh tương ứng 4 test:
   - `testTitle_PASS.png`
   - `testURL_PASS.png`
   - `testPageSource_PASS.png`
   - `testLoginFormDisplayed_PASS.png`
4. Nếu testcase fail, tên file sẽ tự đổi thành hậu tố `_FAIL.png` để dễ đối chiếu report.

## 10) Ghi chú
- Có thể xuất hiện warning CDP theo phiên bản Chrome mới, nhưng không ảnh hưởng kết quả test.
- Nếu lỗi không mở được trình duyệt, kiểm tra lại phiên bản Chrome và quyền chạy WebDriver trên máy.
