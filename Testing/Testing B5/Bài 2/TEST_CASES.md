# Bài 2 – Test Suite với JUnit 4

## Mục tiêu
- Tạo test suite chạy gộp hai lớp test độc lập.
- Kiểm tra hành vi ném ngoại lệ và trả về chuỗi của `JUnitMessage`.
- Kiểm tra so sánh chuỗi đơn giản ở lớp test thứ hai.

## Danh sách test case
| ID | Lớp | Phương thức | Đầu vào | Kỳ vọng | Ghi chú |
|----|-----|-------------|---------|---------|---------|
| TC01 | SuiteTest1 | testJUnitMessage | message = "Fpoly" | Ném `ArithmeticException` khi gọi `printMessage()` | Kiểm tra expected exception |
| TC02 | SuiteTest1 | testJUnitHiMessage | message ban đầu = "Fpoly" | `printHiMessage()` trả "Hi!Fpoly" | Ghép tiền tố "Hi!" |
| TC03 | SuiteTest2 | createAndSetName | expected = "Y", actual = "Y" | assertEquals pass | Kiểm tra so khớp chuỗi |

## Mapping sang mã nguồn
- TC01–TC02: [SuiteTest1.java](SuiteTest1.java#L1-L21)
- TC03: [SuiteTest2.java](SuiteTest2.java#L1-L11)
- Suite runner: [JUnitTest.java](JUnitTest.java#L1-L9)

## Cách chạy
1. Biên dịch: `javac -cp .;junit-4.13.2.jar;hamcrest-core-1.3.jar Bài 2/*.java`
2. Chạy suite: `java -cp .;junit-4.13.2.jar;hamcrest-core-1.3.jar org.junit.runner.JUnitCore JUnitTest`
3. Xem kết quả: 3 test, 0 failure theo đề bài.
