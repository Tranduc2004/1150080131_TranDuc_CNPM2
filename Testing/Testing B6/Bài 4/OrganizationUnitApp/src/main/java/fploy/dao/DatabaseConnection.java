package fploy.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DatabaseConnection {
    // Cấu hình kết nối - Có thể thay đổi theo môi trường
    private static final String SERVER = "LAPTOP-KN5KJVA1";
    private static final String DATABASE = "lab6_testing";
    
    // Option 1: SQL Authentication (Khuyến nghị)
    private static final String USERNAME = "appuser";  // Thay bằng username của bạn
    private static final String PASSWORD = "App@123456";     // Thay bằng password của bạn
    
    private static final String CONNECTION_STRING = 
        "jdbc:sqlserver://" + SERVER + ";" +
        "databaseName=" + DATABASE + ";" +
        "user=" + USERNAME + ";" +
        "password=" + PASSWORD + ";" +
        "encrypt=true;" +
        "trustServerCertificate=true;";
    
    // Option 2: Integrated Security (Nếu có sqljdbc_auth.dll)
    /*
    private static final String CONNECTION_STRING = 
        "jdbc:sqlserver://" + SERVER + ";" +
        "databaseName=" + DATABASE + ";" +
        "integratedSecurity=true;" +
        "encrypt=true;" +
        "trustServerCertificate=true;";
    */

    public static Connection getConnection() throws SQLException {
        try {
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            return DriverManager.getConnection(CONNECTION_STRING);
        } catch (ClassNotFoundException e) {
            throw new SQLException("SQL Server Driver not found", e);
        }
    }
}
