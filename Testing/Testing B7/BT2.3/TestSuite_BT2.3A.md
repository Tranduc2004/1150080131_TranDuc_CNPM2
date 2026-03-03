# BT2.3A - Test Suite Giỏ Hàng & Checkout (End-to-End)

Nguồn: yêu cầu Bài 2.3 (saucedemo inventory -> cart -> checkout step 1 -> step 2 -> complete)

## Phạm vi
- Thêm/xóa sản phẩm trong giỏ và kiểm tra badge/cart list.
- Sort sản phẩm theo 4 kiểu.
- Checkout flow (validate form, continue/cancel, finish).
- Kiểm tra tính toán `Item total`, `Tax (8%)`, `Total`.
- Kiểm tra reset giỏ sau khi hoàn tất.
- Kiểm tra hành vi với `problem_user` (ghi nhận bug nếu có).

## Mặc định dữ liệu giá sản phẩm (để đối chiếu)
- Sauce Labs Backpack: $29.99
- Sauce Labs Bike Light: $9.99
- Sauce Labs Bolt T-Shirt: $15.99
- Sauce Labs Fleece Jacket: $49.99
- Sauce Labs Onesie: $7.99
- Test.allTheThings() T-Shirt (Red): $15.99

> Tổng 6 sản phẩm: `Item total = 129.94`, `Tax = 10.40` (8%), `Total = 140.34`

## Bảng test case

| TC ID | Tiêu đề test case | Tiền điều kiện | Bước thực hiện (mô tả ngắn) | Kết quả mong đợi |
|---|---|---|---|---|
| CART-01 | Thêm 1 sản phẩm vào giỏ | Đăng nhập `standard_user` thành công, ở `/inventory.html` | Click `Add to cart` của Backpack -> mở icon giỏ | Badge = 1, `/cart.html` có Backpack, qty = 1 |
| CART-02 | Thêm nhiều sản phẩm (3 items) | Đăng nhập `standard_user` | Add Backpack, Bike Light, Onesie -> mở giỏ | Badge = 3, cart có đúng 3 items tương ứng |
| CART-03 | Thêm tất cả 6 sản phẩm | Đăng nhập `standard_user` | Click Add cho toàn bộ 6 sản phẩm -> mở giỏ | Badge = 6, cart có đủ 6 items |
| CART-04 | Remove 1 sản phẩm từ inventory | Đăng nhập `standard_user`, đã add 2 items | Tại inventory click `Remove` 1 item | Badge giảm 1, item bị remove không còn trong cart |
| CART-05 | Remove từng sản phẩm trong cart | Đăng nhập, cart có 3 items | Vào cart -> Remove từng item | Badge giảm theo từng lần, danh sách cart cập nhật đúng |
| CART-06 | Remove tất cả -> cart rỗng | Đăng nhập, cart có >=1 item | Vào cart -> remove hết | Cart rỗng, badge biến mất, nút Checkout không cho đi tiếp khi không item |
| CART-07 | Continue Shopping từ cart | Đăng nhập, cart có item | Vào cart -> click `Continue Shopping` | Quay lại `/inventory.html` |
| CART-08 | Nút cart icon điều hướng đúng | Đăng nhập, ở inventory | Click icon cart góc phải trên | Điều hướng đến `/cart.html` |
| SORT-01 | Sort Name A->Z | Đăng nhập `standard_user` | Chọn sort `Name (A to Z)` | Tên sản phẩm hiển thị đúng thứ tự tăng dần A-Z |
| SORT-02 | Sort Name Z->A | Đăng nhập `standard_user` | Chọn sort `Name (Z to A)` | Tên sản phẩm hiển thị đúng thứ tự giảm dần Z-A |
| SORT-03 | Sort Price low->high | Đăng nhập `standard_user` | Chọn sort `Price (low to high)` | Giá hiển thị từ thấp đến cao (7.99 -> 49.99) |
| SORT-04 | Sort Price high->low | Đăng nhập `standard_user` | Chọn sort `Price (high to low)` | Giá hiển thị từ cao xuống thấp (49.99 -> 7.99) |
| CHK-01 | Checkout với cart rỗng | Đăng nhập, cart rỗng | Mở `/cart.html` -> click `Checkout` | Không cho tiếp tục flow checkout, vẫn ở cart hoặc thông báo phù hợp |
| CHK-02 | Checkout Step1 thiếu First Name | Đăng nhập, cart có 1 item, vào Step1 | Để trống First Name, nhập Last+Zip, click `Continue` | Báo lỗi `First Name is required` |
| CHK-03 | Checkout Step1 thiếu Last Name | Đăng nhập, cart có 1 item | Nhập First, trống Last, nhập Zip, click Continue | Báo lỗi `Last Name is required` |
| CHK-04 | Checkout Step1 thiếu Zip/Postal Code | Đăng nhập, cart có 1 item | Nhập First+Last, trống Zip, click Continue | Báo lỗi `Postal Code is required` |
| CHK-05 | Checkout Step1 nhập đầy đủ dữ liệu hợp lệ | Đăng nhập, cart có >=1 item | Nhập First/Last/Zip không rỗng -> Continue | Chuyển sang `/checkout-step-two.html` |
| CHK-06 | Cancel tại Step1 | Đăng nhập, cart có item, đang ở Step1 | Click `Cancel` | Quay về `/cart.html`, item vẫn giữ nguyên |
| CHK-07 | Cancel tại Step2 | Đăng nhập, cart có item, đang ở Step2 | Click `Cancel` | Quay về `/inventory.html`, giỏ chưa bị reset |
| CHK-08 | Verify item list tại Step2 | Đăng nhập, add 2 item, đi tới Step2 | Quan sát danh sách item | Danh sách item/qty/price đúng với cart |
| CHK-09 | Verify Payment Information hiển thị | Đăng nhập, đang ở Step2 | Kiểm tra block Payment Info | Có thông tin thanh toán mô phỏng (không rỗng) |
| CHK-10 | Verify Shipping Information | Đăng nhập, đang ở Step2 | Kiểm tra block Shipping Info | Hiển thị `Free Pony Express Delivery!` |
| CHK-11 | Verify Item total, Tax, Total (2 items) | Đăng nhập, add Backpack+Bike Light, vào Step2 | Tính expected: item total=39.98, tax=3.20, total=43.18 | Giá trị UI khớp expected |
| CHK-12 | Verify Item total, Tax, Total (all 6) | Đăng nhập, add toàn bộ 6 item, vào Step2 | So expected: item total=129.94, tax=10.40, total=140.34 | Giá trị UI khớp expected |
| CHK-13 | Finish order thành công | Đăng nhập, cart có item, đang ở Step2 | Click `Finish` | Sang `/checkout-complete.html`, header `Thank you for your order!` |
| CHK-14 | Back Home sau complete | Vừa complete thành công | Click `Back Home` | Về `/inventory.html`, badge giỏ = 0 (đã reset) |
| CHK-15 | Xác nhận cart reset sau complete | Đã complete và back home | Mở cart icon | Cart rỗng, không còn item cũ |
| CHK-16 | Thử checkout lại sau complete | Đã complete 1 đơn | Add mới 1 item và checkout lại | Flow mới chạy bình thường, không bị dính dữ liệu đơn cũ |
| BUG-01 | Chạy luồng add->checkout với `problem_user` | Đăng nhập `problem_user` thành công | Add item, mở cart, checkout step1/step2 | Nếu có lệch ảnh/label/giá/flow thì ghi BUG; nếu không có thì PASS + note |

## Ghi chú thực thi
- Bộ trên có **25 test case** (>= 20 theo yêu cầu).
- Khi automation, nên gắn tag nhóm: `cart`, `sort`, `checkout`, `calculation`, `bug-observation`.
- Ưu tiên chạy smoke: `CART-01`, `SORT-03`, `CHK-05`, `CHK-11`, `CHK-13`, `CHK-14`.