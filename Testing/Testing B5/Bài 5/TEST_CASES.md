# TEST CASES - Form Đăng Ký Tài Khoản Khách Hàng

## 1. TEST CASES CHO MÃ KHÁCH HÀNG

| STT | Test Case | Input | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 1.1 | Để trống Mã Khách Hàng | "" | "Mã Khách Hàng là trường bắt buộc" | | |
| 1.2 | Mã KH < 6 ký tự | "abc12" | "Mã Khách Hàng phải có độ dài từ 6 đến 10 ký tự" | | |
| 1.3 | Mã KH = 6 ký tự (hợp lệ) | "abc123" | Không có lỗi | | |
| 1.4 | Mã KH = 10 ký tự (hợp lệ) | "abc1234567" | Không có lỗi | | |
| 1.5 | Mã KH > 10 ký tự | "abc12345678" | "Mã Khách Hàng phải có độ dài từ 6 đến 10 ký tự" | | |
| 1.6 | Mã KH có ký tự đặc biệt | "abc@123" | "Mã Khách Hàng chỉ cho phép nhập chữ (a-z, A-Z) và số (0-9)" | | |
| 1.7 | Mã KH có khoảng trắng | "abc 123" | "Mã Khách Hàng chỉ cho phép nhập chữ (a-z, A-Z) và số (0-9)" | | |
| 1.8 | Mã KH có tiếng Việt | "abcđ123" | "Mã Khách Hàng chỉ cho phép nhập chữ (a-z, A-Z) và số (0-9)" | | |
| 1.9 | Mã KH chỉ chữ | "abcdef" | Không có lỗi | | |
| 1.10 | Mã KH chỉ số | "123456" | Không có lỗi | | |
| 1.11 | Mã KH trùng với DB | "EXIST01" (đã tồn tại) | "Mã Khách Hàng đã tồn tại" | | |
| 1.12 | Mã KH hợp lệ, chưa tồn tại | "NEW01234" | Không có lỗi | | |

---

## 2. TEST CASES CHO HỌ VÀ TÊN

| STT | Test Case | Input | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 2.1 | Để trống Họ và Tên | "" | "Họ và Tên là trường bắt buộc" | | |
| 2.2 | Họ và Tên < 5 ký tự | "Hùng" | "Họ và Tên phải có độ dài từ 5 đến 50 ký tự" | | |
| 2.3 | Họ và Tên = 5 ký tự (hợp lệ) | "Nguyễn" | Không có lỗi | | |
| 2.4 | Họ và Tên = 50 ký tự (hợp lệ) | "Nguyễn Văn Hùng Ngô Thị Thu Hương Đặng Minh Tuấn Phạm" | Không có lỗi | | |
| 2.5 | Họ và Tên > 50 ký tự | "Nguyễn Văn Hùng Ngô Thị Thu Hương Đặng Minh Tuấn Phạm Quốc" | "Họ và Tên phải có độ dài từ 5 đến 50 ký tự" | | |
| 2.6 | Họ và Tên có dấu tiếng Việt | "Nguyễn Văn A" | Không có lỗi | | |
| 2.7 | Họ và Tên có dấu huyền | "Nguyền Văn Hùng" | Không có lỗi | | |
| 2.8 | Họ và Tên có khoảng trắng | "Nguyễn  Văn  Hùng" | Không có lỗi | | |
| 2.9 | Họ và Tên chỉ chữ cái | "NguyenVanHung" | Không có lỗi | | |
| 2.10 | Họ và Tên có số | "Nguyen Van 123" | "Họ và Tên không hợp lệ" | | |
| 2.11 | Họ và Tên có ký tự đặc biệt | "Nguyễn Văn @ Hùng" | "Họ và Tên không hợp lệ" | | |
| 2.12 | Họ và Tên hợp lệ | "Nguyễn Văn A" | Không có lỗi | | |

---

## 3. TEST CASES CHO EMAIL

| STT | Test Case | Input | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 3.1 | Để trống Email | "" | "Email là trường bắt buộc" | | |
| 3.2 | Email không có @  | "nguyenvana.email.com" | "Email không hợp lệ" | | |
| 3.3 | Email không có tên miền | "nguyenvana@" | "Email không hợp lệ" | | |
| 3.4 | Email không có phần sau @ | "nguyenvana@email" | "Email không hợp lệ" | | |
| 3.5 | Email có @ ở đầu | "@nguyenvana.email.com" | "Email không hợp lệ" | | |
| 3.6 | Email hợp lệ cơ bản | "nguyenvana@email.com" | Không có lỗi | | |
| 3.7 | Email hợp lệ với số | "nguyenvana123@email.com" | Không có lỗi | | |
| 3.8 | Email hợp lệ với dấu gạch dưới | "nguyen_van_a@email.com" | Không có lỗi | | |
| 3.9 | Email hợp lệ với dấu chấm | "nguyen.van.a@email.com" | Không có lỗi | | |
| 3.10 | Email có ký tự đặc biệt lạ | "nguyen*van@email.com" | "Email không hợp lệ" | | |
| 3.11 | Email có khoảng trắng | "nguyen van a@email.com" | "Email không hợp lệ" | | |
| 3.12 | Email trùng với DB | "existing@email.com" (đã tồn tại) | "Email đã được đăng ký" | | |
| 3.13 | Email chưa tồn tại, hợp lệ | "newemail@email.com" | Không có lỗi | | |

---

## 4. TEST CASES CHO SỐ ĐIỆN THOẠI

| STT | Test Case | Input | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 4.1 | Để trống Số Điện Thoại | "" | "Số Điện Thoại là trường bắt buộc" | | |
| 4.2 | Số ĐT < 10 ký tự | "0123456789" | Không có lỗi | | |
| 4.3 | Số ĐT = 10 ký tự (hợp lệ) | "0123456789" | Không có lỗi | | |
| 4.4 | Số ĐT = 12 ký tự (hợp lệ) | "012345678901" | Không có lỗi | | |
| 4.5 | Số ĐT > 12 ký tự | "0123456789012" | "Số Điện Thoại phải có độ dài từ 10 đến 12 ký tự" | | |
| 4.6 | Số ĐT < 10 ký tự | "012345678" | "Số Điện Thoại phải có độ dài từ 10 đến 12 ký tự" | | |
| 4.7 | Số ĐT không bắt đầu bằng 0 | "1123456789" | "Số Điện Thoại phải bắt đầu bằng số 0" | | |
| 4.8 | Số ĐT có chữ cái | "012345678a" | "Số Điện Thoại chỉ cho phép nhập số (0-9)" | | |
| 4.9 | Số ĐT có ký tự đặc biệt | "0123456-789" | "Số Điện Thoại chỉ cho phép nhập số (0-9)" | | |
| 4.10 | Số ĐT có khoảng trắng | "0123 456 789" | "Số Điện Thoại chỉ cho phép nhập số (0-9)" | | |
| 4.11 | Số ĐT hợp lệ bắt đầu 09 | "0987654321" | Không có lỗi | | |
| 4.12 | Số ĐT hợp lệ bắt đầu 08 | "0812345678" | Không có lỗi | | |

---

## 5. TEST CASES CHO ĐỊA CHỈ

| STT | Test Case | Input | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 5.1 | Để trống Địa Chỉ | "" | "Địa Chỉ là trường bắt buộc" | | |
| 5.2 | Địa Chỉ chỉ có 1 ký tự | "A" | Không có lỗi | | |
| 5.3 | Địa Chỉ hợp lệ | "123 Đường Lê Lợi, Quận 1, TP.HCM" | Không có lỗi | | |
| 5.4 | Địa Chỉ có tiếng Việt + dấu | "Số 10 Phố Huế, Hà Nội" | Không có lỗi | | |
| 5.5 | Địa Chỉ = 255 ký tự (hợp lệ) | (255 ký tự) | Không có lỗi | | |
| 5.6 | Địa Chỉ > 255 ký tự | (256+ ký tự) | "Địa Chỉ không được vượt quá 255 ký tự" | | |
| 5.7 | Địa Chỉ có ký tự đặc biệt | "123 Đường ABC@##$%, Quận 1" | Không có lỗi | | |
| 5.8 | Địa Chỉ rất dài nhưng hợp lệ | "Tầng 5, Tòa nhà A, Số 20 Đường Nguyễn Huệ, Quận 1, TP.HCM, Việt Nam" | Không có lỗi | | |

---

## 6. TEST CASES CHO MẬT KHẨU

| STT | Test Case | Input | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 6.1 | Để trống Mật Khẩu | "" | "Mật Khẩu là trường bắt buộc" | | |
| 6.2 | Mật Khẩu < 8 ký tự | "abc1234" | "Mật Khẩu phải có ít nhất 8 ký tự" | | |
| 6.3 | Mật Khẩu = 8 ký tự (hợp lệ) | "abc12345" | Không có lỗi | | |
| 6.4 | Mật Khẩu > 8 ký tự (hợp lệ) | "abc123456789" | Không có lỗi | | |
| 6.5 | Mật Khẩu chỉ chữ cái | "abcdefgh" | Không có lỗi | | |
| 6.6 | Mật Khẩu chỉ số | "12345678" | Không có lỗi | | |
| 6.7 | Mật Khẩu hỗn hợp | "abc12345!" | Không có lỗi | | |
| 6.8 | Mật Khẩu có ký tự đặc biệt | "Pass@123#" | Không có lỗi | | |
| 6.9 | Mật Khẩu có khoảng trắng | "abc 12345" | Không có lỗi | | |

---

## 7. TEST CASES CHO XÁC NHẬN MẬT KHẨU

| STT | Test Case | Input MK | Input XN MK | Expected Output | Actual | Status |
|-----|-----------|----------|------------|-----------------|--------|--------|
| 7.1 | Để trống XN Mật Khẩu | "abc12345" | "" | "Xác Nhận Mật Khẩu là trường bắt buộc" | | |
| 7.2 | XN MK khác MK | "abc12345" | "abc12346" | "Xác Nhận Mật Khẩu không khớp với Mật Khẩu" | | |
| 7.3 | XN MK khớp MK | "abc12345" | "abc12345" | Không có lỗi | | |
| 7.4 | XN MK khớp MK (dài) | "Pass@123456" | "Pass@123456" | Không có lỗi | | |
| 7.5 | XN MK sai 1 ký tự | "abc12345" | "abc12346" | "Xác Nhận Mật Khẩu không khớp với Mật Khẩu" | | |
| 7.6 | XN MK khác case | "Abc12345" | "abc12345" | "Xác Nhận Mật Khẩu không khớp với Mật Khẩu" | | |

---

## 8. TEST CASES CHO NGÀY SINH

| STT | Test Case | Input | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 8.1 | Để trống Ngày Sinh | "" | Không có lỗi (không bắt buộc) | | |
| 8.2 | Ngày Sinh định dạng sai | "27-01-2026" | "Ngày sinh không hợp lệ (mm/dd/yyyy)" | | |
| 8.3 | Ngày Sinh định dạng đúng | "01/15/2008" | Không có lỗi (18 tuổi) | | |
| 8.4 | Ngày Sinh < 18 tuổi | "01/15/2010" | "Bạn phải đủ 18 tuổi để đăng ký" | | |
| 8.5 | Ngày Sinh đúng 18 tuổi hôm nay | (18 tuổi) | Không có lỗi | | |
| 8.6 | Ngày Sinh ngày hôm nay | "01/27/2026" | "Bạn phải đủ 18 tuổi để đăng ký" | | |
| 8.7 | Ngày Sinh > 18 tuổi | "05/20/1990" | Không có lỗi | | |
| 8.8 | Ngày Sinh không tồn tại (2/30) | "02/30/2000" | "Ngày sinh không hợp lệ" | | |
| 8.9 | Ngày Sinh tháng không hợp lệ | "13/01/2000" | "Ngày sinh không hợp lệ" | | |

---

## 9. TEST CASES CHO GIỚI TÍNH

| STT | Test Case | Input | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 9.1 | Không chọn Giới Tính | (không chọn) | Không có lỗi (không bắt buộc) | | |
| 9.2 | Chọn Nam | "Nam" | Không có lỗi | | |
| 9.3 | Chọn Nữ | "Nữ" | Không có lỗi | | |
| 9.4 | Chọn Khác | "Khác" | Không có lỗi | | |
| 9.5 | Thay đổi giới tính | Nam → Nữ | Thay đổi được giá trị | | |

---

## 10. TEST CASES CHO ĐIỀU KHOẢN DỊCH VỤ

| STT | Test Case | Input | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 10.1 | Không tích Điều Khoản | (không tích) | "Bạn phải đồng ý với các điều khoản dịch vụ" | | |
| 10.2 | Tích Điều Khoản | (tích) | Không có lỗi | | |
| 10.3 | Tích và bỏ tích Điều Khoản | (tích → bỏ tích) | Thay đổi được trạng thái | | |

---

## 11. TEST CASES TÍCH HỢP (HAPPY PATH)

| STT | Test Case | Mô Tả | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 11.1 | Đăng ký thành công với đầy đủ thông tin | Tất cả trường hợp lệ + tích Điều Khoản | "Đăng ký tài khoản thành công!" | | |
| 11.2 | Đăng ký thành công, không nhập Ngày Sinh | Tất cả trường bắt buộc hợp lệ, bỏ Ngày Sinh | "Đăng ký tài khoản thành công!" | | |
| 11.3 | Đăng ký thành công, không chọn Giới Tính | Tất cả trường bắt buộc hợp lệ, bỏ Giới Tính | "Đăng ký tài khoản thành công!" | | |

---

## 12. TEST CASES CHO NÚT NHẬP LẠI

| STT | Test Case | Mô Tả | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 12.1 | Click nút Nhập lại | Form có dữ liệu đã nhập | Form trống, lỗi biến mất | | |
| 12.2 | Nhập dữ liệu, click Nhập lại, nhập lại | Nhập dữ liệu mới | Form cập nhật dữ liệu mới | | |

---

## 13. TEST CASES CHO NÚT ĐĂNG KÝ

| STT | Test Case | Mô Tả | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 13.1 | Click Đăng ký với form trống | Không nhập gì | Tất cả lỗi xác thực hiển thị | | |
| 13.2 | Click Đăng ký với một số trường sai | Vài trường không hợp lệ | Chỉ lỗi của trường sai hiển thị | | |
| 13.3 | Click Đăng ký sau khi sửa lỗi | Sửa tất cả lỗi | "Đăng ký tài khoản thành công!" | | |

---

## 14. TEST CASES EDGE CASE

| STT | Test Case | Input | Expected Output | Actual | Status |
|-----|-----------|-------|-----------------|--------|--------|
| 14.1 | Khoảng trắng ở đầu/cuối Mã KH | "  abc123  " | Trim và validate | | |
| 14.2 | Khoảng trắng ở đầu/cuối Email | "  user@email.com  " | Trim và validate | | |
| 14.3 | Khoảng trắng ở đầu/cuối Họ Tên | "  Nguyễn Văn A  " | Trim và validate | | |
| 14.4 | Nhập ký tự khoảng trắng chỉ | "   " | "Mã Khách Hàng là trường bắt buộc" | | |
| 14.5 | Nhập 2 lần dữ liệu giống nhau | Nhập, reset, nhập lại dữ liệu cũ | Đăng ký lần đầu thành công, lần 2 báo lỗi (trùng) | | |

---

## TÓNG KẾT TEST EXECUTION

### Tổng số test case: 
- Mã Khách Hàng: 12
- Họ và Tên: 12
- Email: 13
- Số Điện Thoại: 12
- Địa Chỉ: 8
- Mật Khẩu: 9
- Xác Nhận Mật Khẩu: 6
- Ngày Sinh: 9
- Giới Tính: 5
- Điều Khoản: 3
- Tích Hợp: 3
- Nút Nhập Lại: 2
- Nút Đăng Ký: 3
- Edge Case: 5
- **TOTAL: 122 test cases**

### Thống kê kết quả:
- Passed: _____ / 122
- Failed: _____ / 122
- Blocked: _____ / 122
- Pass Rate: ____%

---

## GHI CHÚ
- Lưu ý: Cần setup database và seed dữ liệu test trước (ví dụ: Mã KH "EXIST01", Email "existing@email.com")
- Các ngày sinh test phải tính toán dựa trên ngày hiện tại (01/27/2026)
- Test case có thể mở rộng tùy theo yêu cầu cụ thể của dự án
