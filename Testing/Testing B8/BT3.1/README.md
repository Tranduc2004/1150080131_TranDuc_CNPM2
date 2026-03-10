# BT3.1 - Phân tích CFG và tính toán Coverage

## 1) Hàm cần kiểm thử
```java
public static String xepLoai(int diemTB, boolean coThiLai) {
    if (diemTB < 0 || diemTB > 10) {
        return "Diem khong hop le"; // N1
    }

    if (diemTB >= 8.5) {
        return "Gioi"; // N2
    } else if (diemTB >= 7.0) {
        return "Kha"; // N3
    } else if (diemTB >= 5.5) {
        return "Trung Binh"; // N4
    } else {
        if (coThiLai) {
            return "Thi lai"; // N5
        }
    }

    return "Yeu - Hoc lai"; // N6
}
```

## 2) CFG (mô tả văn bản)
- Entry -> N1 (`diemTB < 0 || diemTB > 10`)
  - N1[True] -> Exit(`Diem khong hop le`)
  - N1[False] -> N2 (`diemTB >= 8.5`)
    - N2[True] -> Exit(`Gioi`)
    - N2[False] -> N3 (`diemTB >= 7.0`)
      - N3[True] -> Exit(`Kha`)
      - N3[False] -> N4 (`diemTB >= 5.5`)
        - N4[True] -> Exit(`Trung Binh`)
        - N4[False] -> N5 (`coThiLai`)
          - N5[True] -> Exit(`Thi lai`)
          - N5[False] -> Exit(`Yeu - Hoc lai`)

## 3) Tập test case tối thiểu đạt 100% Statement Coverage

Lý do tối thiểu: hàm có 6 điểm thoát (`return`) loại trừ nhau, nên cần ít nhất 6 test để thực thi toàn bộ statement.

| TC | diemTB | coThiLai | Đường đi | Kết quả mong đợi |
|---|---:|---|---|---|
| TC1 | -1 | false | N1(True) -> Exit | Diem khong hop le |
| TC2 | 9 | false | N1(F) -> N2(True) -> Exit | Gioi |
| TC3 | 7 | false | N1(F) -> N2(F) -> N3(True) -> Exit | Kha |
| TC4 | 6 | false | N1(F) -> N2(F) -> N3(F) -> N4(True) -> Exit | Trung Binh |
| TC5 | 4 | true | N1(F) -> N2(F) -> N3(F) -> N4(F) -> N5(True) -> Exit | Thi lai |
| TC6 | 4 | false | N1(F) -> N2(F) -> N3(F) -> N4(F) -> N5(F) -> Exit | Yeu - Hoc lai |

- Statement Coverage = `6/6 = 100%` (6 điểm return/khối lệnh chính đều được thực thi).

## 4) Tập test case tối thiểu đạt 100% Branch Coverage

Lý do tối thiểu: cần phủ cả True/False cho 5 quyết định (N1..N5), tức 10 nhánh; với cấu trúc rẽ nhánh lồng nhau này, tập 6 test TC1..TC6 là nhỏ nhất để phủ đủ.

### Các nhánh cần phủ
- N1-True, N1-False
- N2-True, N2-False
- N3-True, N3-False
- N4-True, N4-False
- N5-True, N5-False

### Bảng nhánh được phủ bởi test case nào

| Nhánh | Mô tả | Test case phủ |
|---|---|---|
| N1-True | `diemTB < 0 || diemTB > 10` đúng | TC1 |
| N1-False | Điểm nằm trong [0..10] | TC2, TC3, TC4, TC5, TC6 |
| N2-True | `diemTB >= 8.5` đúng | TC2 |
| N2-False | `diemTB < 8.5` | TC3, TC4, TC5, TC6 |
| N3-True | `diemTB >= 7.0` đúng | TC3 |
| N3-False | `diemTB < 7.0` | TC4, TC5, TC6 |
| N4-True | `diemTB >= 5.5` đúng | TC4 |
| N4-False | `diemTB < 5.5` | TC5, TC6 |
| N5-True | `coThiLai = true` | TC5 |
| N5-False | `coThiLai = false` | TC6 |

Tập test TC1..TC6 phủ đủ toàn bộ 10/10 nhánh.

- Branch Coverage = `10/10 = 100%`

## 5) Mã test TestNG
- Hàm nghiệp vụ: `src/main/java/bt31/XepLoaiService.java`
- Test branch coverage: `src/test/java/bt31/XepLoaiBranchCoverageTest.java`

## 6) Cách chạy
```bash
mvn test
```

## 7) Kết quả mong đợi khi chạy
- Tổng số test: 6
- Pass: 6
- Fail: 0
- Report: `target/surefire-reports/`
