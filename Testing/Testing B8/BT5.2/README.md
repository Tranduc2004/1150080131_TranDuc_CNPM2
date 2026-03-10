# BT5.2 - Condition Coverage và MC/DC

## 1) Hàm kiểm tra điều kiện vay
```java
public static boolean duDieuKienVay(int tuoi, double thuNhap,
                                    boolean coTaiSanBaoLanh, int diemTinDung) {
    boolean dieuKienCoBan = (tuoi >= 22) && (thuNhap >= 10_000_000);
    boolean dieuKienBaoDam = coTaiSanBaoLanh || (diemTinDung >= 700);
    return dieuKienCoBan && dieuKienBaoDam;
}
```

Đặt điều kiện đơn:
- A: `tuoi >= 22`
- B: `thuNhap >= 10_000_000`
- C: `coTaiSanBaoLanh`
- D: `diemTinDung >= 700`

Biểu thức quyết định:
- `F = (A && B) && (C || D)`

## 2) Truth table cho toàn bộ biểu thức

| Row | A | B | C | D | A&&B | C\|\|D | F |
|---|---|---|---|---|---|---|---|
| 1 | T | T | T | T | T | T | T |
| 2 | T | T | T | F | T | T | T |
| 3 | T | T | F | T | T | T | T |
| 4 | T | T | F | F | T | F | F |
| 5 | T | F | T | T | F | T | F |
| 6 | T | F | T | F | F | T | F |
| 7 | T | F | F | T | F | T | F |
| 8 | T | F | F | F | F | F | F |
| 9 | F | T | T | T | F | T | F |
| 10 | F | T | T | F | F | T | F |
| 11 | F | T | F | T | F | T | F |
| 12 | F | T | F | F | F | F | F |
| 13 | F | F | T | T | F | T | F |
| 14 | F | F | T | F | F | T | F |
| 15 | F | F | F | T | F | T | F |
| 16 | F | F | F | F | F | F | F |

## 3) Condition Coverage (mỗi điều kiện đơn có T/F)

### Bộ test condition coverage
- CC-TC1: A=T, B=T, C=T, D=T
- CC-TC2: A=F, B=F, C=F, D=F

Nhận xét:
- Mỗi điều kiện A,B,C,D đều xuất hiện cả True và False ít nhất 1 lần.
- Đạt Condition Coverage.

## 4) MC/DC

Mục tiêu MC/DC: với mỗi điều kiện đơn, tìm cặp test chỉ thay đổi điều kiện đó (các điều kiện khác giữ nguyên), và output đổi.

### Bộ test MC/DC đã chọn

| TC | A | B | C | D | F |
|---|---|---|---|---|---|
| M1 | T | T | T | F | T |
| M2 | F | T | T | F | F |
| M3 | T | F | T | F | F |
| M4 | T | T | F | F | F |
| M5 | T | T | F | T | T |

### Cặp chứng minh độc lập
- A độc lập: M1 vs M2 (chỉ A đổi, F đổi T->F)
- B độc lập: M1 vs M3 (chỉ B đổi, F đổi T->F)
- C độc lập: M1 vs M4 (chỉ C đổi, F đổi T->F)
- D độc lập: M4 vs M5 (chỉ D đổi, F đổi F->T)

=> Bộ tối thiểu theo MC/DC: **5 test case**.

## 5) Code TestNG
- Hàm nghiệp vụ: `src/main/java/bt52/LoanEligibilityService.java`
- Test Condition Coverage: `src/test/java/bt52/LoanConditionCoverageTest.java`
- Test MC/DC (theo đề bài 5.2): `src/test/java/bt52/VayVonMCDCTest.java`
- Suite: `testng.xml`

## 6) Cách chạy
```bash
mvn test
```

## 7) Kết quả mong đợi
- Tổng test hiện có: 7 (2 condition + 5 MC/DC tối thiểu)
- Pass: 100%
- Report: `target/surefire-reports/`
