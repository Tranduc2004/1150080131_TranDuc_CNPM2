# BT7.1 - Phân tích và thiết kế Test Suite toàn diện (OrderProcessor)

## 1) Bài toán
Hàm kiểm thử:

```java
public double calculateTotal(List<Item> items, String couponCode,
                             String memberLevel, String paymentMethod)
```

Decision trong code:
- D1: `items == null || items.isEmpty()`
- D2: `couponCode != null && !couponCode.isEmpty()`
- D3-D4: nhánh chọn coupon (`SALE10` / `SALE20` / invalid)
- D5-D6: nhánh chọn member (`GOLD` / `PLATINUM` / khác)
- D7: `total < 500_000`
- D8: `!paymentMethod.equals("COD")`

## 2) CFG đầy đủ (đánh số node & edge)

### 2.1 Nodes
- N1: Start
- N2: D1?
- N3: throw `Gio hang trong`
- N4: tính `subtotal`
- N5: D2?
- N6: D3?
- N7: `discount = subtotal * 0.10`
- N8: D4?
- N9: `discount = subtotal * 0.20`
- N10: throw `Ma giam gia khong hop le`
- N11: `memberDiscount = 0`
- N12: D5?
- N13: set GOLD 5%
- N14: D6?
- N15: set PLATINUM 10%
- N16: `total = subtotal - discount - memberDiscount`
- N17: D7?
- N18: D8?
- N19: `total += 30_000`
- N20: `total += 20_000`
- N21: `return total`

### 2.2 Edges
- E1: N1->N2
- E2: N2(T)->N3
- E3: N2(F)->N4
- E4: N4->N5
- E5: N5(T)->N6
- E6: N5(F)->N11
- E7: N6(T)->N7
- E8: N6(F)->N8
- E9: N7->N11
- E10: N8(T)->N9
- E11: N8(F)->N10
- E12: N9->N11
- E13: N11->N12
- E14: N12(T)->N13
- E15: N12(F)->N14
- E16: N13->N16
- E17: N14(T)->N15
- E18: N14(F)->N16
- E19: N15->N16
- E20: N16->N17
- E21: N17(T)->N18
- E22: N17(F)->N21
- E23: N18(T)->N19
- E24: N18(F)->N20
- E25: N19->N21
- E26: N20->N21

## 3) Tính Cyclomatic Complexity (CC)

### Cách 1: E - N + 2P
- Số node: N = 21
- Số edge: E = 26
- Số thành phần liên thông: P = 1

$$CC = E - N + 2P = 26 - 21 + 2*1 = 7$$

### Cách 2: Đếm decision
Theo CFG ở trên (gộp cặp `if/else if` coupon thành 1 nút quyết định và member thành 1 nút quyết định), số decision node là:
- D1, D2, (D3-D4), (D5-D6), D7, D8 => 6 decision

$$CC = Decision + 1 = 6 + 1 = 7$$

=> Hai cách cho cùng kết quả: **CC = 7**.

## 4) Basis Path và dữ liệu test

Vì `CC = 7`, số đường cơ sở độc lập cần có là **7**.

| BP | Đường đi tóm tắt | Dữ liệu test | Kỳ vọng |
|---|---|---|---|
| BP1 | D1=T -> throw | items=null | `IllegalArgumentException("Gio hang trong")` |
| BP2 | D1=F,D2=F,D5=F,D6=F,D7=T,D8=T | items=[100k,200k], coupon=null, member=SILVER, pay=CARD | 330000 |
| BP3 | D1=F,D2=F,D5=F,D6=F,D7=T,D8=F | items=[100k,200k], coupon=null, member=SILVER, pay=COD | 320000 |
| BP4 | D2=T,D3=T,D5=T,D7=F | items=[400k,400k], coupon=SALE10, member=GOLD, pay=CARD | 684000 |
| BP5 | D2=T,D3=F,D4=T,D5=F,D6=T,D7=F | items=[600k,400k], coupon=SALE20, member=PLATINUM, pay=CARD | 720000 |
| BP6 | D2=T,D3=F,D4=F -> throw | items=[100k], coupon=BAD, member=SILVER, pay=CARD | `IllegalArgumentException("Ma giam gia khong hop le")` |
| BP7 | D2=T,D3=T,D5=F,D6=F,D7=T,D8=T | items=[100k], coupon=SALE10, member=SILVER, pay=CARD | 120000 |

## 5) MC/DC cho điều kiện coupon: D2 && D3

Xét decision con tại nhánh SALE10: `A && B`, trong đó:
- A = `couponCode != null && !couponCode.isEmpty()` (D2)
- B = `couponCode.equals("SALE10")` (D3, chỉ xét khi A true)

Bộ test MC/DC tối thiểu:

| TC | couponCode | A(D2) | B(D3) | Kết quả decision A&&B |
|---|---|---|---|---|
| M1 | `null` | F | F* | F |
| M2 | `"SALE10"` | T | T | T |
| M3 | `""` | F | F* | F |

Chứng minh độc lập:
- Điều kiện A ảnh hưởng output: so sánh M1 vs M2 (A đổi F->T, decision đổi F->T).
- Điều kiện B ảnh hưởng output trong miền A=true: dùng SALE10 vs SALE20 (đã có BP4/BP5 thể hiện rõ nhánh đổi).

## 6) Class TestNG thực thi Basis Path + MC/DC

- File test: `src/test/java/bt71/OrderProcessorTest.java`
- Bao gồm:
  - 7 test Basis Path (`BP1...BP7`)
  - 1 test DataProvider cho MC/DC `D2&&D3`

## 7) Cấu trúc dự án
- Logic: `src/main/java/bt71/OrderProcessor.java`
- Model: `src/main/java/bt71/Item.java`
- Test: `src/test/java/bt71/OrderProcessorTest.java`
- Suite: `testng.xml`

## 8) Cách chạy

```bash
mvn test
```
