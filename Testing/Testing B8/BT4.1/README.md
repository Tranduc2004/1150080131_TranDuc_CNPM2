# BT4.1 - Tính CC và Basis Path cho hàm `tinhPhiShip`

## 1) Hàm phân tích
```java
public static double tinhPhiShip(double trongLuong, String vung, boolean laMember) {
    if (trongLuong <= 0) { // D1
        throw new IllegalArgumentException("Trong luong phai > 0");
    }

    double phi = 0;

    if ("noi_thanh".equals(vung)) { // D2
        phi = 15000;
        if (trongLuong > 5) { // D3
            phi += (trongLuong - 5) * 2000;
        }
    } else if ("ngoai_thanh".equals(vung)) { // D4
        phi = 25000;
        if (trongLuong > 3) { // D5
            phi += (trongLuong - 3) * 3000;
        }
    } else {
        phi = 50000;
        if (trongLuong > 2) { // D6
            phi += (trongLuong - 2) * 5000;
        }
    }

    if (laMember) { // D7
        phi = phi * 0.9;
    }

    return phi;
}
```

## 2) Đếm số lượng decision (D) và tính CC theo công thức nhanh
- Decision nodes:
  - D1: `trongLuong <= 0`
  - D2: `vung == noi_thanh`
  - D3: `trongLuong > 5`
  - D4: `vung == ngoai_thanh`
  - D5: `trongLuong > 3`
  - D6: `trongLuong > 2`
  - D7: `laMember`
- Tổng số decision: **D = 7**
- Cyclomatic Complexity theo công thức nhanh:
  - `CC = D + 1 = 7 + 1 = 8`

## 3) CFG đầy đủ (đánh số node và edge)

### 3.1 Node
- N0: Entry
- N1 (D1): `trongLuong <= 0`
- N2: `throw IllegalArgumentException`
- N3: `phi = 0`
- N4 (D2): `vung == noi_thanh`
- N5: `phi = 15000`
- N6 (D3): `trongLuong > 5`
- N7: `phi += (trongLuong - 5) * 2000`
- N8 (D4): `vung == ngoai_thanh`
- N9: `phi = 25000`
- N10 (D5): `trongLuong > 3`
- N11: `phi += (trongLuong - 3) * 3000`
- N12: `phi = 50000`
- N13 (D6): `trongLuong > 2`
- N14: `phi += (trongLuong - 2) * 5000`
- N15 (D7): `laMember`
- N16: `phi = phi * 0.9`
- N17: `return phi`
- N18: Exit

### 3.2 Edge
- E1: N0 -> N1
- E2: N1(True) -> N2
- E3: N2 -> N18
- E4: N1(False) -> N3
- E5: N3 -> N4
- E6: N4(True) -> N5
- E7: N5 -> N6
- E8: N6(True) -> N7
- E9: N7 -> N15
- E10: N6(False) -> N15
- E11: N4(False) -> N8
- E12: N8(True) -> N9
- E13: N9 -> N10
- E14: N10(True) -> N11
- E15: N11 -> N15
- E16: N10(False) -> N15
- E17: N8(False) -> N12
- E18: N12 -> N13
- E19: N13(True) -> N14
- E20: N14 -> N15
- E21: N13(False) -> N15
- E22: N15(True) -> N16
- E23: N16 -> N17
- E24: N15(False) -> N17
- E25: N17 -> N18

## 4) Kiểm tra lại CC = E - N + 2P
- Số node: `N = 19` (N0..N18)
- Số edge: `E = 25` (E1..E25)
- Số thành phần liên thông: `P = 1`
- Tính lại:
  - `CC = E - N + 2P = 25 - 19 + 2*1 = 8`
- Khớp với công thức nhanh (`CC = 8`).

## 5) Basis Path - liệt kê đủ CC đường cơ sở và dữ liệu test

Vì `CC = 8`, cần **8 đường cơ sở**.

| BP | Đường đi quyết định | Dữ liệu test `(trongLuong, vung, laMember)` | Kết quả mong đợi |
|---|---|---|---:|
| BP1 | D1(T) | `(0, "noi_thanh", false)` | Throw exception |
| BP2 | D1(F) -> D2(T) -> D3(F) -> D7(F) | `(3, "noi_thanh", false)` | `15000` |
| BP3 | D1(F) -> D2(T) -> D3(T) -> D7(F) | `(7, "noi_thanh", false)` | `19000` |
| BP4 | D1(F) -> D2(F) -> D4(T) -> D5(F) -> D7(F) | `(3, "ngoai_thanh", false)` | `25000` |
| BP5 | D1(F) -> D2(F) -> D4(T) -> D5(T) -> D7(F) | `(5, "ngoai_thanh", false)` | `31000` |
| BP6 | D1(F) -> D2(F) -> D4(F) -> D6(F) -> D7(F) | `(2, "mien_nui", false)` | `50000` |
| BP7 | D1(F) -> D2(F) -> D4(F) -> D6(T) -> D7(F) | `(4, "mien_nui", false)` | `60000` |
| BP8 | D1(F) -> D2(T) -> D3(F) -> D7(T) | `(3, "noi_thanh", true)` | `13500` |

## 6) Bảng theo dõi nhánh được phủ bởi từng TC

| Nhánh | BP/TC phủ |
|---|---|
| D1-True | BP1 |
| D1-False | BP2, BP3, BP4, BP5, BP6, BP7, BP8 |
| D2-True | BP2, BP3, BP8 |
| D2-False | BP4, BP5, BP6, BP7 |
| D3-True | BP3 |
| D3-False | BP2, BP8 |
| D4-True | BP4, BP5 |
| D4-False | BP6, BP7 |
| D5-True | BP5 |
| D5-False | BP4 |
| D6-True | BP7 |
| D6-False | BP6 |z
| D7-True | BP8 |
| D7-False | BP2, BP3, BP4, BP5, BP6, BP7 |

## 7) Code TestNG thực thi basis path
- Hàm nghiệp vụ: `src/main/java/bt41/ShippingFeeService.java`
- Test Basis Path: `src/test/java/bt41/TinhPhiShipBasisPathTest.java`
- Suite: `testng.xml`

## 8) Cách chạy
```bash
mvn test
```

## 9) Kết quả mong đợi
- Tests run: 8
- Failures: 0
- Errors: 0
- Report: `target/surefire-reports/`
