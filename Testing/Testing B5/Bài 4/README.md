# Payment Calculator Application

## Mô tả
Ứng dụng Java tính toán tiền thanh toán dựa trên giới tính và độ tuổi của bệnh nhân.

## Cấu trúc dự án

```
Testing B5/
├── PaymentCalculator.java          # GUI application (Swing)
├── PaymentCalculatorLogic.java     # Business logic
├── PaymentCalculatorTest.java      # JUnit test cases
├── TEST_CASES.md                   # Tài liệu test cases chi tiết
└── README.md                       # File này
```

## Bảng giá

### Nam giới (Male)
- 18-35 tuổi: 100 euro
- 36-50 tuổi: 120 euro
- 51-145 tuổi: 140 euro

### Nữ giới (Female)
- 18-35 tuổi: 80 euro
- 36-50 tuổi: 110 euro
- 51-145 tuổi: 140 euro

### Trẻ em (Child)
- 0-17 tuổi: 50 euro

## Yêu cầu hệ thống
- Java Development Kit (JDK) 8 trở lên
- JUnit 5 (cho việc chạy test cases)

## Cách chạy ứng dụng

### 1. Biên dịch
```bash
javac PaymentCalculator.java PaymentCalculatorLogic.java
```

### 2. Chạy ứng dụng
```bash
java PaymentCalculator
```

### 3. Sử dụng
1. Chọn giới tính/loại (Male, Female, hoặc Child)
2. Nhập tuổi vào ô "Age (Years)"
3. Nhấn nút "Calculate"
4. Kết quả sẽ hiển thị trong ô "Payment is"

## Chạy Test Cases

### Với JUnit 5:

1. Tải JUnit Platform Console Standalone:
```bash
# Download từ Maven Central hoặc sử dụng Maven/Gradle
```

2. Biên dịch test:
```bash
javac -cp .;junit-platform-console-standalone-1.9.2.jar PaymentCalculatorTest.java PaymentCalculatorLogic.java
```

3. Chạy test:
```bash
java -jar junit-platform-console-standalone-1.9.2.jar --class-path . --scan-class-path
```

## Phương pháp kiểm thử

Dự án sử dụng các phương pháp kiểm thử sau:

1. **Equivalence Partitioning**: Chia các trường hợp thành các nhóm tương đương
2. **Boundary Value Analysis**: Kiểm tra các giá trị biên
3. **Error Guessing**: Kiểm tra các trường hợp lỗi có thể xảy ra

Chi tiết xem file [TEST_CASES.md](TEST_CASES.md)

## Tính năng

- ✅ Giao diện người dùng thân thiện
- ✅ Tính toán chính xác theo bảng giá
- ✅ Xử lý lỗi và validation dữ liệu
- ✅ Test coverage toàn diện (30+ test cases)
- ✅ Phân tích giá trị biên
- ✅ Kiểm tra dữ liệu không hợp lệ

## Xử lý lỗi

Ứng dụng xử lý các trường hợp sau:
- Tuổi không hợp lệ (< 0 hoặc > 145)
- Chưa chọn giới tính
- Nhập tuổi không phải số
- Trẻ em với tuổi >= 18
- Giới tính null hoặc rỗng

## Tác giả
Bài tập Testing - Bài 4 (3.0 điểm)
