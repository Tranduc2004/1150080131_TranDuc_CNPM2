# Bài 1 – Test Cases cho MathFunc

## Mục tiêu
- Kiểm tra hàm `factorial(int)` với đầu vào hợp lệ, biên, và bất hợp lệ.
- Kiểm tra hàm `plus(int, int)` (được đánh dấu bỏ qua theo yêu cầu @Ignore).
- Kiểm tra biến đếm số lần gọi `calls` thông qua các phương thức.

## Danh sách test case

| ID | Chức năng | Đầu vào | Kỳ vọng | Ghi chú |
|----|-----------|---------|---------|---------|
| TC01 | factorial | number = 0 | Kết quả = 1 | Biên dưới hợp lệ |
| TC02 | factorial | number = 1 | Kết quả = 1 | Trường hợp đơn vị |
| TC03 | factorial | number = 5 | Kết quả = 120 | Giá trị trung bình |
| TC04 | factorial (exception) | number = -1 | Ném `IllegalArgumentException` | Đầu vào âm |
| TC05 | calls counter | Gọi `factorial(1)` 2 lần | Giá trị `calls` tăng từ 0 → 1 → 2 | Kiểm tra fixture @Before/@After reset |
| TC06 | plus (ignored) | num1 = 1, num2 = 1 | (Bỏ qua) | Test @Ignore, kỳ vọng 1+1=3 theo đề bài minh họa |

## Mapping sang mã nguồn test
- TC01–TC03: `factorial()` trong [MathFuncTest.java](MathFuncTest.java#L28-L34)
- TC04: `factorialNegative()` trong [MathFuncTest.java](MathFuncTest.java#L36-L39)
- TC05: `calls()` trong [MathFuncTest.java](MathFuncTest.java#L14-L26)
- TC06: `todo()` (bị @Ignore) trong [MathFuncTest.java](MathFuncTest.java#L41-L49)

## Cách chạy
1. Biên dịch: `javac -cp .;junit-4.13.2.jar;hamcrest-core-1.3.jar Bài 1/*.java`
2. Chạy test: `java -cp .;junit-4.13.2.jar;hamcrest-core-1.3.jar org.junit.runner.JUnitCore MathFuncTest`
3. Hoặc chạy runner: `java -cp .;junit-4.13.2.jar;hamcrest-core-1.3.jar TestRunner`
