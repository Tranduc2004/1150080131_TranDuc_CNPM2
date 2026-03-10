# BT3.2 - Statement & Branch Coverage thực tế

## 1) Hàm cần phân tích
```java
public static double tinhTienNuoc(int soM3, String loaiKhachHang) {
    if (soM3 <= 0) return 0; // N1
    double don_gia;

    if (loaiKhachHang.equals("ho_ngheo")) { // N2
        don_gia = 5000;
    } else if (loaiKhachHang.equals("dan_cu")) { // N3
        if (soM3 <= 10) { // N4
            don_gia = 7500;
        } else if (soM3 <= 20) { // N5
            don_gia = 9900;
        } else {
            don_gia = 11400;
        }
    } else {
        don_gia = 22000; // kinh_doanh
    }

    return soM3 * don_gia;
}
```

## 2) CFG - đánh số node và edge

### Node
- Node 0: Entry
- Node 1 (N1): `soM3 <= 0`
- Node 2: `return 0`
- Node 3: `double donGia`
- Node 4 (N2): `loaiKhachHang == ho_ngheo`
- Node 5: `donGia = 5000`
- Node 6 (N3): `loaiKhachHang == dan_cu`
- Node 7 (N4): `soM3 <= 10`
- Node 8: `donGia = 7500`
- Node 9 (N5): `soM3 <= 20`
- Node 10: `donGia = 9900`
- Node 11: `donGia = 11400`
- Node 12: `donGia = 22000`
- Node 13: `return soM3 * donGia`
- Node 14: Exit

### Edge
- E1: 0 -> 1
- E2: 1(T) -> 2
- E3: 2 -> 14
- E4: 1(F) -> 3
- E5: 3 -> 4
- E6: 4(T) -> 5
- E7: 5 -> 13
- E8: 4(F) -> 6
- E9: 6(T) -> 7
- E10: 7(T) -> 8
- E11: 8 -> 13
- E12: 7(F) -> 9
- E13: 9(T) -> 10
- E14: 10 -> 13
- E15: 9(F) -> 11
- E16: 11 -> 13
- E17: 6(F) -> 12
- E18: 12 -> 13
- E19: 13 -> 14

## 3) Đếm tổng số lệnh và tổng số nhánh
- Tổng số lệnh (statement) thực thi trong hàm: **12**
  - 5 điều kiện: N1, N2, N3, N4, N5
    - 7 lệnh gán/return chính: `return0`, `donGia=5000`, `donGia=7500`, `donGia=9900`, `donGia=11400`, `donGia=22000`, `return soM3*donGia`
- Tổng số nhánh (branch): **10**
  - 5 quyết định x 2 nhánh (True/False): N1..N5

## 4) Test suite tối thiểu đạt 100% Branch Coverage

| TC | Input `(soM3, loaiKhachHang)` | Kết quả mong đợi | Đường đi CFG |
|---|---|---:|---|
| TC1 | `(0, "dan_cu")` | `0` | N1(T) |
| TC2 | `(5, "ho_ngheo")` | `25000` | N1(F)->N2(T) |
| TC3 | `(8, "dan_cu")` | `60000` | N1(F)->N2(F)->N3(T)->N4(T) |
| TC4 | `(15, "dan_cu")` | `148500` | N1(F)->N2(F)->N3(T)->N4(F)->N5(T) |
| TC5 | `(25, "dan_cu")` | `285000` | N1(F)->N2(F)->N3(T)->N4(F)->N5(F) |
| TC6 | `(5, "kinh_doanh")` | `110000` | N1(F)->N2(F)->N3(F) |

Số lượng tối thiểu để đạt 100% branch coverage: **6 test case**.

## 5) Bảng theo dõi nhánh: mỗi TC phủ nhánh nào

| Nhánh | Mô tả | TC phủ |
|---|---|---|
| N1-True | `soM3 <= 0` đúng | TC1 |
| N1-False | `soM3 <= 0` sai | TC2, TC3, TC4, TC5, TC6 |
| N2-True | `loaiKhachHang == ho_ngheo` đúng | TC2 |
| N2-False | `loaiKhachHang == ho_ngheo` sai | TC3, TC4, TC5, TC6 |
| N3-True | `loaiKhachHang == dan_cu` đúng | TC3, TC4, TC5 |
| N3-False | `loaiKhachHang == dan_cu` sai | TC6 |
| N4-True | `soM3 <= 10` đúng | TC3 |
| N4-False | `soM3 <= 10` sai | TC4, TC5 |
| N5-True | `soM3 <= 20` đúng | TC4 |
| N5-False | `soM3 <= 20` sai | TC5 |

Kết quả: phủ đủ **10/10 nhánh = 100% Branch Coverage**.

## 6) Code TestNG chạy các TC
- Hàm nghiệp vụ: `src/main/java/bt32/TinhTienNuocService.java`
- Bộ test branch coverage: `src/test/java/bt32/TinhTienNuocBranchCoverageTest.java`
- Suite TestNG: `testng.xml`

## 7) Cách chạy
```bash
mvn test
```

## 8) Kết quả mong đợi
- Tests run: 6
- Failures: 0
- Errors: 0
- Report: `target/surefire-reports/`
