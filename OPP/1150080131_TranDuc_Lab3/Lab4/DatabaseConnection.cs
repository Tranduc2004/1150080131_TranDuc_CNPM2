using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab4
{
    public static class DatabaseConnection
    {
        // 🔹 Chuỗi kết nối toàn cục
        private static readonly string connectionString =
            @"Data Source=LAPTOP-LQGGA8E3\MSSQLSERVER2;
              Initial Catalog=QuanLyBanHang;
              Integrated Security=True;";

        // 🔹 Hàm trả về SqlConnection (chưa mở)
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // 🔹 Hàm mở kết nối nhanh, có try-catch
        public static SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể mở kết nối đến CSDL: " + ex.Message);
            }
            return conn;
        }

        // 🔹 Hàm kiểm tra trạng thái kết nối
        public static bool TestConnection()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
