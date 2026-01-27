import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DatabaseConnection {
    private static final String SERVER_NAME = "LAPTOP-KN5KJVA1"; // ← TÊN GIỐNG TRONG SSMS
    private static final String DATABASE_NAME = "TestingDB";
    private static Connection connection = null;
    
    public static Connection getConnection() {
        if (connection != null) {
            return connection;
        }
        
        try {
            // Dùng đúng tên server như trong SSMS
            String connectionURL = "jdbc:sqlserver://" + SERVER_NAME
                + ";databaseName=" + DATABASE_NAME 
                + ";integratedSecurity=true"
                + ";trustServerCertificate=true"
                + ";encrypt=false";
            
            System.out.println("Đang kết nối: " + connectionURL);
            
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            connection = DriverManager.getConnection(connectionURL);
            
            System.out.println("✅ Kết nối database thành công!");
            return connection;
            
        } catch (ClassNotFoundException e) {
            System.err.println("❌ Thiếu JDBC Driver: " + e.getMessage());
        } catch (SQLException e) {
            System.err.println("❌ Lỗi kết nối: " + e.getMessage());
            System.err.println("\nKiểm tra:");
            System.err.println("1. Database 'TestingDB' đã tạo chưa?");
            System.err.println("2. Trong SSMS, tạo database: CREATE DATABASE TestingDB");
        }
        
        return null;
    }
    
    public static void closeConnection() {
        if (connection != null) {
            try {
                connection.close();
                connection = null;
                System.out.println("✅ Đã đóng kết nối database");
            } catch (SQLException e) {
                System.err.println("❌ Lỗi đóng kết nối: " + e.getMessage());
            }
        }
    }
    
    public static void main(String[] args) {
        System.out.println("=== TEST KẾT NỐI SQL SERVER ===\n");
        Connection conn = getConnection();
        if (conn != null) {
            System.out.println("\n🎉 Thành công!");
            closeConnection();
        } else {
            System.out.println("\n💔 Thất bại!");
        }
    }
}