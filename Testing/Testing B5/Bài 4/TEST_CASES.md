# Payment Calculator - Test Cases Documentation

## Bảng test cases cho hệ thống tính tiền thanh toán

### 1. Test Cases cho Nam giới (Male)

| Test Case ID | Giới tính | Tuổi | Kết quả mong đợi | Ghi chú |
|--------------|-----------|------|------------------|---------|
| TC_M_01 | Male | 18 | 100 euro | Biên dưới nhóm 18-35 |
| TC_M_02 | Male | 25 | 100 euro | Giá trị giữa 18-35 |
| TC_M_03 | Male | 35 | 100 euro | Biên trên nhóm 18-35 |
| TC_M_04 | Male | 36 | 120 euro | Biên dưới nhóm 36-50 |
| TC_M_05 | Male | 43 | 120 euro | Giá trị giữa 36-50 |
| TC_M_06 | Male | 50 | 120 euro | Biên trên nhóm 36-50 |
| TC_M_07 | Male | 51 | 140 euro | Biên dưới nhóm 51-145 |
| TC_M_08 | Male | 100 | 140 euro | Giá trị giữa 51-145 |
| TC_M_09 | Male | 145 | 140 euro | Biên trên nhóm 51-145 |

### 2. Test Cases cho Nữ giới (Female)

| Test Case ID | Giới tính | Tuổi | Kết quả mong đợi | Ghi chú |
|--------------|-----------|------|------------------|---------|
| TC_F_01 | Female | 18 | 80 euro | Biên dưới nhóm 18-35 |
| TC_F_02 | Female | 25 | 80 euro | Giá trị giữa 18-35 |
| TC_F_03 | Female | 35 | 80 euro | Biên trên nhóm 18-35 |
| TC_F_04 | Female | 36 | 110 euro | Biên dưới nhóm 36-50 |
| TC_F_05 | Female | 43 | 110 euro | Giá trị giữa 36-50 |
| TC_F_06 | Female | 50 | 110 euro | Biên trên nhóm 36-50 |
| TC_F_07 | Female | 51 | 140 euro | Biên dưới nhóm 51-145 |
| TC_F_08 | Female | 100 | 140 euro | Giá trị giữa 51-145 |
| TC_F_09 | Female | 145 | 140 euro | Biên trên nhóm 51-145 |

### 3. Test Cases cho Trẻ em (Child)

| Test Case ID | Giới tính | Tuổi | Kết quả mong đợi | Ghi chú |
|--------------|-----------|------|------------------|---------|
| TC_C_01 | Child | 0 | 50 euro | Biên dưới nhóm 0-17 |
| TC_C_02 | Child | 10 | 50 euro | Giá trị giữa 0-17 |
| TC_C_03 | Child | 17 | 50 euro | Biên trên nhóm 0-17 |

### 4. Test Cases cho biên giá trị (Boundary Value Analysis)

| Test Case ID | Giới tính | Tuổi | Kết quả mong đợi | Loại test |
|--------------|-----------|------|------------------|-----------|
| TC_B_01 | Child | 17 | 50 euro | Biên trên Child |
| TC_B_02 | Male | 18 | 100 euro | Biên dưới Male nhóm 1 |
| TC_B_03 | Male | 35 | 100 euro | Biên trên Male nhóm 1 |
| TC_B_04 | Male | 36 | 120 euro | Biên dưới Male nhóm 2 |
| TC_B_05 | Male | 50 | 120 euro | Biên trên Male nhóm 2 |
| TC_B_06 | Male | 51 | 140 euro | Biên dưới Male nhóm 3 |
| TC_B_07 | Male | 145 | 140 euro | Biên trên Male nhóm 3 |
| TC_B_08 | Female | 18 | 80 euro | Biên dưới Female nhóm 1 |
| TC_B_09 | Female | 35 | 80 euro | Biên trên Female nhóm 1 |
| TC_B_10 | Female | 36 | 110 euro | Biên dưới Female nhóm 2 |
| TC_B_11 | Female | 50 | 110 euro | Biên trên Female nhóm 2 |
| TC_B_12 | Female | 51 | 140 euro | Biên dưới Female nhóm 3 |

### 5. Test Cases cho giá trị không hợp lệ (Invalid Test Cases)

| Test Case ID | Giới tính | Tuổi | Kết quả mong đợi | Ghi chú |
|--------------|-----------|------|------------------|---------|
| TC_I_01 | Male | -1 | Exception | Tuổi âm |
| TC_I_02 | Male | 146 | Exception | Tuổi > 145 |
| TC_I_03 | Child | 18 | Exception | Child tuổi >= 18 |
| TC_I_04 | Unknown | 25 | Exception | Giới tính không hợp lệ |
| TC_I_05 | "" | 25 | Exception | Giới tính rỗng |
| TC_I_06 | null | 25 | Exception | Giới tính null |

### 6. Các phương pháp kiểm thử đã sử dụng

#### 6.1. Equivalence Partitioning (Phân vùng tương đương)
- **Child (0-17)**: 50 euro
- **Male (18-35)**: 100 euro
- **Male (36-50)**: 120 euro
- **Male (51-145)**: 140 euro
- **Female (18-35)**: 80 euro
- **Female (36-50)**: 110 euro
- **Female (51-145)**: 140 euro

#### 6.2. Boundary Value Analysis (Phân tích giá trị biên)
- Test các giá trị ở ranh giới của mỗi khoảng tuổi
- Test giá trị min (0), max (145)
- Test giá trị tại các điểm chuyển đổi (17-18, 35-36, 50-51)

#### 6.3. Error Guessing (Dự đoán lỗi)
- Tuổi âm
- Tuổi vượt quá giới hạn
- Giới tính không hợp lệ
- Giá trị null hoặc rỗng
- Trẻ em với tuổi người lớn

### 7. Hướng dẫn chạy test

#### Biên dịch và chạy ứng dụng:
```bash
javac PaymentCalculator.java PaymentCalculatorLogic.java
java PaymentCalculator
```

#### Chạy test cases (với JUnit 5):
```bash
javac -cp .;junit-platform-console-standalone-1.9.2.jar PaymentCalculatorTest.java PaymentCalculatorLogic.java
java -jar junit-platform-console-standalone-1.9.2.jar --class-path . --scan-class-path
```

### 8. Kết quả mong đợi
- Tất cả test cases phải pass
- Không có exception ngoài các trường hợp invalid data
- GUI hoạt động mượt mà và hiển thị đúng kết quả

### 9. Coverage
- **Equivalence Partitioning**: 7 phân vùng chính
- **Boundary Value Analysis**: 12+ test cases cho các biên
- **Invalid Cases**: 6+ test cases cho dữ liệu không hợp lệ
- **Total Test Cases**: 30+ test cases
