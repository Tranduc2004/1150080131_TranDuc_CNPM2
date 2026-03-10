# BT4.2 - Viết Test Case TestNG từ Basis Path

## 1) Mục tiêu
- Viết class TestNG dựa trên các Basis Path của bài 4.1.
- Viết đủ số test method tương ứng số lượng đường cơ sở (CC = 8).
- Mỗi test method có `@Test(description=...)` rõ ràng.
- Assert số thực dùng sai số `delta = 0.01`.

## 1.1) Checklist yêu cầu đề bài (đã đáp ứng)
- [x] Viết đầy đủ test method theo từng Basis Path với số lượng bằng `CC = 8`.
- [x] Mỗi test method đều có `@Test(description = "...")` rõ ràng.
- [x] Các assert số thực (`double`) đều dùng `delta = 0.01`.
- [x] Đã chạy TestNG và kết quả `100% PASS`.

## 2) Thành phần chính
- Hàm cần test: `src/main/java/bt42/PhiShip.java`
- Test class: `src/test/java/bt42/PhiShipBasisPathTest.java`
- Suite TestNG: `testng.xml`

## 3) Danh sách test theo Basis Path
1. `testPath1_InvalidWeight` - Path 1: trọng lượng không hợp lệ (throw exception).
2. `testPath2_NoiThanhNheKhongMember` - Path 2: nội thành, <= 5kg, không member.
3. `testPath3_NoiThanhNangKhongMember` - Path 3: nội thành, > 5kg, không member.
4. `testPath4_NgoaiThanhNheKhongMember` - Path 4: ngoại thành, <= 3kg, không member.
5. `testPath5_NgoaiThanhNangKhongMember` - Path 5: ngoại thành, > 3kg, không member.
6. `testPath6_VungKhacNheKhongMember` - Path 6: vùng khác, <= 2kg, không member.
7. `testPath7_VungKhacNangKhongMember` - Path 7: vùng khác, > 2kg, không member.
8. `testPath8_MemberDiscount` - Path 8: member giảm 10%.

## 4) Chạy test
```bash
mvn test
```

## 5) Kết quả mong đợi
- Tests run: 8
- Failures: 0
- Errors: 0
- Report HTML/TestNG: `target/surefire-reports/`

## 5.1) Kết quả chạy thực tế
- `mvn test` đã chạy thành công.
- Kết quả thực tế: `Tests run: 8, Failures: 0, Errors: 0, Skipped: 0`.

## 5.2) File report HTML để chụp nộp bài
- `target/surefire-reports/index.html`
- `target/surefire-reports/emailable-report.html`
- `target/surefire-reports/BT4.2 Basis Path Test Suite/`

## 6) Gợi ý nộp bài
- Chụp màn hình console Maven sau khi chạy test (8 PASS).
- Chụp báo cáo HTML trong `target/surefire-reports`.
