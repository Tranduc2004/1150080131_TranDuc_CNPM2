# Bài 3 – Minh họa JUnit4 Annotations

## Mục tiêu
- Thực hành @BeforeClass, @Before, @After, @AfterClass, @Test (timeout/expected), @Ignore.
- Quan sát thứ tự chạy và hành vi fixture trên danh sách `ArrayList` đơn giản.

## Danh sách test case
| ID | Annotation | Phương thức | Kỳ vọng / Hành vi | Ghi chú |
|----|------------|-------------|-------------------|---------|
| TC01 | @BeforeClass | m1 | In ra thông báo trước tất cả test | Chạy 1 lần đầu suite |
| TC02 | @Before | m2 | Khởi tạo `list` trước mỗi test, in thông báo | Chạy trước từng test |
| TC03 | @Test | m5 | Thêm phần tử vào list, `size()==1`, `isEmpty()==false` | Test chính trên list |
| TC04 | @After | m4 | `list.clear()` và in thông báo sau mỗi test | Dọn tài nguyên |
| TC05 | @AfterClass | m3 | In thông báo sau tất cả test | Chạy 1 lần cuối suite |
| TC06 | @Ignore + @Test | m6 | Bị bỏ qua, không thực thi | Minh họa skip |
| TC07 | @Test(timeout=10) | m7 | Hoàn thành trong giới hạn 10ms, in thông báo | Không timeout nên pass |
| TC08 | @Test(expected=NoSuchMethodException.class) | m8 | Ném `NoSuchMethodException` và pass | Minh họa expected exception |

## Mapping
- Fixture & test: [JUnitAnnotationsExample.java](JUnitAnnotationsExample.java#L1-L58)
- Runner: [TestRunner.java](TestRunner.java#L1-L12)

## Cách chạy
1. Biên dịch: `javac -cp .;junit-4.13.2.jar;hamcrest-core-1.3.jar Bài 3/*.java`
2. Chạy: `java -cp .;junit-4.13.2.jar;hamcrest-core-1.3.jar org.junit.runner.JUnitCore JUnitAnnotationsExample`
3. Hoặc dùng runner: `java -cp .;junit-4.13.2.jar;hamcrest-core-1.3.jar TestRunner`
