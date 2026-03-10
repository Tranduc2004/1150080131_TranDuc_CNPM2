# BT2.2 - Parallel Execution với ThreadLocal

## 1) Mục tiêu
- Xây dựng `DriverFactory` dùng `ThreadLocal<WebDriver>` để chạy song song an toàn.
- Cấu hình TestNG chạy song song theo class với:
  - `parallel="classes"`
  - `thread-count="2"`
- Chạy đồng thời `LoginTest` và `CartTest`.

## 2) Cấu trúc dự án
```
BT2.2/
├─ pom.xml
├─ testng.xml
└─ src/
   └─ test/
      └─ java/
         └─ bt22/
            ├─ base/
            │  └─ DriverFactory.java
            └─ tests/
               ├─ LoginTest.java
               └─ CartTest.java
```

## 3) Cách chạy
```bash
mvn test
```

## 4) Kết quả mong đợi
- 2 class test chạy đồng thời trên 2 thread khác nhau.
- Mỗi thread dùng WebDriver riêng thông qua `ThreadLocal`, tránh race condition.
- Console hiển thị log có tên thread cho từng test.

## 5) Chụp màn hình theo yêu cầu bài
1. Chạy `mvn test`.
2. Khi test đang chạy, quan sát 2 cửa sổ Chrome mở cùng lúc.
3. Chụp ảnh màn hình desktop thể hiện đồng thời 2 cửa sổ.
4. Đính kèm ảnh khi nộp bài.
