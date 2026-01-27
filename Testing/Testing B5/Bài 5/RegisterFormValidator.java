import java.time.LocalDate;
import java.time.Period;
import java.util.regex.Pattern;

public class RegisterFormValidator {
    
    // Validate Mã Khách Hàng
    public static String validateMaKhachHang(String maKhachHang) {
        if (maKhachHang == null || maKhachHang.trim().isEmpty()) {
            return "Mã Khách Hàng là trường bắt buộc";
        }
        
        maKhachHang = maKhachHang.trim();
        
        if (maKhachHang.length() < 6 || maKhachHang.length() > 10) {
            return "Mã Khách Hàng phải có độ dài từ 6 đến 10 ký tự";
        }
        
        if (!maKhachHang.matches("^[a-zA-Z0-9]+$")) {
            return "Mã Khách Hàng chỉ cho phép nhập chữ (a-z, A-Z) và số (0-9)";
        }
        
        // Kiểm tra trùng lặp với database
        if (DatabaseService.isMaKhachHangExists(maKhachHang)) {
            return "Mã Khách Hàng đã tồn tại";
        }
        
        return null; // Hợp lệ
    }
    
    // Validate Họ và Tên
    public static String validateHoTen(String hoTen) {
        if (hoTen == null || hoTen.trim().isEmpty()) {
            return "Họ và Tên là trường bắt buộc";
        }
        
        hoTen = hoTen.trim();
        
        if (hoTen.length() < 5 || hoTen.length() > 50) {
            return "Họ và Tên phải có độ dài từ 5 đến 50 ký tự";
        }
        
        // Kiểm tra chỉ cho phép chữ, số, khoảng trắng và ký tự dấu tiếng Việt
        if (!hoTen.matches("^[a-zA-Z0-9À-ỿ\\s]+$")) {
            return "Họ và Tên không hợp lệ";
        }
        
        return null; // Hợp lệ
    }
    
    // Validate Email
    public static String validateEmail(String email) {
        if (email == null || email.trim().isEmpty()) {
            return "Email là trường bắt buộc";
        }
        
        email = email.trim();
        
        String emailPattern = "^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$";
        if (!Pattern.matches(emailPattern, email)) {
            return "Email không hợp lệ (ví dụ: nguyenvana@email.com)";
        }
        
        // Kiểm tra trùng lặp với database
        if (DatabaseService.isEmailExists(email)) {
            return "Email đã được đăng ký";
        }
        
        return null; // Hợp lệ
    }
    
    // Validate Số Điện Thoại
    public static String validateSoDienThoai(String soDienThoai) {
        if (soDienThoai == null || soDienThoai.trim().isEmpty()) {
            return "Số Điện Thoại là trường bắt buộc";
        }
        
        soDienThoai = soDienThoai.trim();
        
        if (!soDienThoai.matches("^[0-9]+$")) {
            return "Số Điện Thoại chỉ cho phép nhập số (0-9)";
        }
        
        if (soDienThoai.length() < 10 || soDienThoai.length() > 12) {
            return "Số Điện Thoại phải có độ dài từ 10 đến 12 ký tự";
        }
        
        if (!soDienThoai.startsWith("0")) {
            return "Số Điện Thoại phải bắt đầu bằng số 0";
        }
        
        return null; // Hợp lệ
    }
    
    // Validate Địa Chỉ
    public static String validateDiaChi(String diaChi) {
        if (diaChi == null || diaChi.trim().isEmpty()) {
            return "Địa Chỉ là trường bắt buộc";
        }
        
        diaChi = diaChi.trim();
        
        if (diaChi.length() > 255) {
            return "Địa Chỉ không được vượt quá 255 ký tự";
        }
        
        return null; // Hợp lệ
    }
    
    // Validate Mật Khẩu
    public static String validateMatKhau(String matKhau) {
        if (matKhau == null || matKhau.isEmpty()) {
            return "Mật Khẩu là trường bắt buộc";
        }
        
        if (matKhau.length() < 8) {
            return "Mật Khẩu phải có ít nhất 8 ký tự";
        }
        
        return null; // Hợp lệ
    }
    
    // Validate Xác Nhận Mật Khẩu
    public static String validateXacNhanMatKhau(String matKhau, String xacNhanMatKhau) {
        if (xacNhanMatKhau == null || xacNhanMatKhau.isEmpty()) {
            return "Xác Nhận Mật Khẩu là trường bắt buộc";
        }
        
        if (!matKhau.equals(xacNhanMatKhau)) {
            return "Xác Nhận Mật Khẩu không khớp với Mật Khẩu";
        }
        
        return null; // Hợp lệ
    }
    
    // Validate Ngày Sinh
    public static String validateNgaySinh(LocalDate ngaySinh) {
        if (ngaySinh == null) {
            return null; // Không bắt buộc
        }
        
        LocalDate today = LocalDate.now();
        int age = Period.between(ngaySinh, today).getYears();
        
        if (age < 18) {
            return "Bạn phải đủ 18 tuổi để đăng ký";
        }
        
        return null; // Hợp lệ
    }
    
    // Validate Điều Khoản Dịch Vụ
    public static String validateDongYDieuKhoan(boolean dongY) {
        if (!dongY) {
            return "Bạn phải đồng ý với các điều khoản dịch vụ";
        }
        
        return null; // Hợp lệ
    }
}
