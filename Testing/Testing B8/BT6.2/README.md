# BT6.2 - White-Box + Selenium: Kiểm thử form giao diện

## Link hệ thống kiểm thử
- https://demoqa.com/text-box

## 1) CFG luồng xử lý form (phân tích white-box)

```text
Start
  |
  v
Open page Text Box
  |
  v
Nhập Name / Email / Address
  |
  v
Click Submit
  |
  +--> [Email format hợp lệ?] --No--> Đánh dấu lỗi field-error (email)
  |                                  |
  |                                  v
  |                           Không hiển thị output hợp lệ
  |
  +--> [Có dữ liệu hợp lệ để hiển thị?] --No--> Không hiển thị output
                                     |
                                     Yes
                                     v
                               Hiển thị output (#output)
                                     |
                                     v
                                    End
```

## 2) Boundary value & trường hợp biên từ CFG

- Biên 1: Tất cả input rỗng (`""`) -> không hiển thị output
- Biên 2: Chỉ nhập khoảng trắng (`"   "`) -> **vẫn hiển thị output** (hệ thống không trim/không chặn)
- Biên 3: Email sai định dạng (`abc`) -> email bị đánh dấu lỗi `field-error`
- Biên 4: Dữ liệu hợp lệ tối thiểu -> hiển thị output

## 3) Cài đặt theo Page Object Model

- Page object: `src/test/java/bt62/pages/TextBoxPage.java`
  - `fillAndSubmit(String name, String email, String address)`
  - `isOutputDisplayed()`
- Test class: `src/test/java/bt62/tests/TextBoxWhiteBoxTest.java`
  - `shouldNotDisplayOutputWhenAllFieldsEmpty()`
  - `shouldDisplayOutputWhenOnlySpaces()`
  - `shouldMarkEmailInvalidWhenFormatIsWrong()`
  - `shouldDisplayOutputWhenInputIsValid()`

## 4) Chạy test

```bash
mvn test
```

## 5) Kết quả mong đợi
- Tất cả test case PASS
- Chứng minh được các nhánh chính trong CFG:
  - Nhánh invalid email
  - Nhánh empty/space
  - Nhánh valid output

## 6) Tự động chụp ảnh khi chạy test
- Ảnh được chụp sau mỗi test (cả PASS/FAIL)
- Thư mục ảnh: `target/screenshots`
- Tên file: `<tenTest>_PASS.png` hoặc `<tenTest>_FAIL.png`
