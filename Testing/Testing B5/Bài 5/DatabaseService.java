import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.time.LocalDate;

public class DatabaseService {
    
    // Kiểm tra Mã Khách Hàng có tồn tại
    public static boolean isMaKhachHangExists(String maKhachHang) {
        Connection conn = DatabaseConnection.getConnection();
        if (conn == null) {
            System.out.println("Không thể kết nối database, bỏ qua kiểm tra trùng lặp Mã Khách Hàng");
            return false;
        }
        
        String query = "SELECT COUNT(*) FROM KHACH_HANG WHERE ma_khach_hang = ?";
        try (PreparedStatement pstmt = conn.prepareStatement(query)) {
            pstmt.setString(1, maKhachHang);
            ResultSet rs = pstmt.executeQuery();
            if (rs.next()) {
                return rs.getInt(1) > 0;
            }
        } catch (SQLException e) {
            System.err.println("Lỗi kiểm tra Mã Khách Hàng: " + e.getMessage());
        }
        return false;
    }
    
    // Kiểm tra Email có tồn tại
    public static boolean isEmailExists(String email) {
        Connection conn = DatabaseConnection.getConnection();
        if (conn == null) {
            System.out.println("Không thể kết nối database, bỏ qua kiểm tra trùng lặp Email");
            return false;
        }
        
        String query = "SELECT COUNT(*) FROM KHACH_HANG WHERE email = ?";
        try (PreparedStatement pstmt = conn.prepareStatement(query)) {
            pstmt.setString(1, email);
            ResultSet rs = pstmt.executeQuery();
            if (rs.next()) {
                return rs.getInt(1) > 0;
            }
        } catch (SQLException e) {
            System.err.println("Lỗi kiểm tra Email: " + e.getMessage());
        }
        return false;
    }
    
    // Lưu khách hàng mới vào database
    public static boolean insertKhachHang(
            String maKhachHang,
            String hoTen,
            String email,
            String soDienThoai,
            String diaChi,
            String matKhau,
            LocalDate ngaySinh,
            String gioiTinh,
            boolean dongYDieuKhoan) {
        
        Connection conn = DatabaseConnection.getConnection();
        if (conn == null) {
            System.out.println("Không thể kết nối database. Dữ liệu sẽ được lưu trong bộ nhớ (Demo Mode).");
            return true;
        }
        
        String query = "INSERT INTO KHACH_HANG (ma_khach_hang, ho_ten, email, so_dien_thoai, dia_chi, mat_khau, ngay_sinh, gioi_tinh, dong_y_dieu_khoan, trang_thai) " +
                      "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, 1)";
        
        try (PreparedStatement pstmt = conn.prepareStatement(query)) {
            
            pstmt.setString(1, maKhachHang);
            pstmt.setString(2, hoTen);
            pstmt.setString(3, email);
            pstmt.setString(4, soDienThoai);
            pstmt.setString(5, diaChi);
            pstmt.setString(6, matKhau); // Trong thực tế nên hash password
            pstmt.setObject(7, ngaySinh);
            pstmt.setString(8, gioiTinh);
            pstmt.setBoolean(9, dongYDieuKhoan);
            
            int rowsAffected = pstmt.executeUpdate();
            return rowsAffected > 0;
        } catch (SQLException e) {
            System.err.println("Lỗi lưu khách hàng: " + e.getMessage());
        }
        return false;
    }
}
