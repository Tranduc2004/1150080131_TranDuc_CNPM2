package fploy.db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DatabaseConnection {
    private static final String SERVER = "LAPTOP-KN5KJVA1";
    private static final String DATABASE = "lab6_testing";
    private static final String USERNAME = "appuser";
    private static final String PASSWORD = "App@123456";
    
    private static final String URL = "jdbc:sqlserver://" + SERVER + 
                                     ";databaseName=" + DATABASE +
                                     ";encrypt=false;trustServerCertificate=true";
    
    public static Connection getConnection() throws SQLException {
        try {
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            return DriverManager.getConnection(URL, USERNAME, PASSWORD);
        } catch (ClassNotFoundException e) {
            throw new SQLException("SQL Server JDBC Driver not found", e);
        }
    }
    
    public static void closeConnection(Connection conn) {
        if (conn != null) {
            try {
                conn.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }
}
