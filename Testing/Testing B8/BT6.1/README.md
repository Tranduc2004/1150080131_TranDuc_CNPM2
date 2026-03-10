# BT6.1 - TDD: Thiết kế CFG -> Viết Test -> Viết Code

## Mục tiêu
Kiểm tra tính hợp lệ của số điện thoại Việt Nam bằng phương pháp TDD.

## Quy tắc hợp lệ
- Bắt đầu bằng `0` hoặc `+84`
- Sau khi chuẩn hóa về dạng bắt đầu bằng `0`, đầu số phải là: `03`, `05`, `07`, `08`, `09`
- Tổng số chữ số sau chuẩn hóa là 10
- Trước khi chuẩn hóa chỉ cho phép: chữ số `0-9`, ký tự `+`, và khoảng trắng

## 1) Show phần phân tích (CFG + đường đi)

### CFG rút gọn cho `isValid(phone)`
```text
Start
	|
	|-- [phone == null || blank] --true--> return false
	|                                \
	|                                 false
	v
compact = remove spaces
	|
	|-- [contains char ngoài 0-9,+] --true--> return false
	|                                      \
	|                                       false
	v
	|-- [startsWith(+84)] --true--> compact = "0" + rest
	|              \
	|               false
	|                |
	|-- [startsWith(0)] --false--> return false
	v
return compact matches 0[35789]\d{8}
```

### Tính CC (Cyclomatic Complexity)
- Số nút quyết định trong hàm `isValid`: 5
	1) `phone == null || blank`
	2) `contains char ngoài 0-9,+`
	3) `startsWith(+84)`
	4) `startsWith(0)` (nhánh `else if`)
	5) `compact matches 0[35789]\d{8}`
- Công thức: `CC = số quyết định + 1 = 5 + 1 = 6`
- Kết luận: số test case tối thiểu theo **Basis Path** là **6**.

### Basis path gợi ý (6 đường đi độc lập)
- P1: null/blank -> `false`
- P2: ký tự không hợp lệ -> `false`
- P3: không bắt đầu `0` hoặc `+84` -> `false`
- P4: bắt đầu `+84`, regex fail -> `false`
- P5: bắt đầu `+84`, regex pass -> `true`
- P6: bắt đầu `0`, regex pass -> `true`

## 2) Show phần test trước (RED)
- File test: `src/test/java/bt61/PhoneValidatorTest.java`
- Ý nghĩa test:
	- Nhóm hợp lệ: `0987654321`, `0351234567`, `+84987654321`, có khoảng trắng...
	- Nhóm không hợp lệ: null/blank, sai prefix, sai độ dài, chứa ký tự lạ...
- Khi demo RED: để method `isValid` chưa xử lý (hoặc throw exception) rồi chạy `mvn test` để thấy FAIL.

## 3) Show phần code chức năng (GREEN)
- File code: `src/main/java/bt61/PhoneValidator.java`
- Chạy lại:
```bash
mvn test
```
- Kết quả hiện tại: pass toàn bộ test (`16/16`).

## 4) Show coverage theo yêu cầu B6.1
- Chạy:
```bash
mvn clean test
```
- Mở báo cáo:
	- `target/site/jacoco/index.html`
- Khi nộp/đứng lớp: chụp 3 ảnh
	1) Console test PASS
	2) JaCoCo report tổng quan
	3) JaCoCo của class `PhoneValidator`

## 5) Checklist nộp bài nhanh
- Có CFG + tính CC + basis path
- Có test viết trước (RED) và chạy lại PASS (GREEN)
- Có code `isValid(String phone)`
- Có report JaCoCo
- Có README mô tả cách chạy

## Cấu trúc
- Logic: `src/main/java/bt61/PhoneValidator.java`
- Test: `src/test/java/bt61/PhoneValidatorTest.java`
- Suite: `testng.xml`

## Chạy test
```bash
mvn test
```

## Coverage JaCoCo
```bash
mvn clean test
```
Báo cáo: `target/site/jacoco/index.html`
