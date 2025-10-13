using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace _1150080131_TranDuc_lab5.Repositories
{
    public class SinhVienRepo_NoParam
    {
        private readonly string _connStr =
            ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;

        private SqlConnection Conn() => new SqlConnection(_connStr);

        public DataTable GetAll()
        {
            const string sql = @"SELECT MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop
                                 FROM dbo.SinhVien ORDER BY MaSV;";
            using (var da = new SqlDataAdapter(sql, Conn()))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetByClass(string maLop)
        {
            string sql = string.IsNullOrWhiteSpace(maLop)
                ? @"SELECT MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop FROM dbo.SinhVien ORDER BY MaSV;"
                : $@"SELECT MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop
                     FROM dbo.SinhVien WHERE MaLop = '{Esc(maLop)}' ORDER BY MaSV;";
            using (var da = new SqlDataAdapter(sql, Conn()))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetAllLop()
        {
            const string sql = @"SELECT MaLop FROM dbo.Lop ORDER BY MaLop;";
            using (var da = new SqlDataAdapter(sql, Conn()))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Sửa dữ liệu KHÔNG DÙNG PARAMETER – dùng nối chuỗi (chỉ cho bài thực hành)
        /// </summary>
        public int UpdateSinhVien_NoParam(
            string originalMaSV, string maSV, string tenSV, string gioiTinh,
            DateTime ngaySinh, string queQuan, string maLop)
        {
            // Escape đơn giản: thay ' -> ''  (chỉ giảm rủi ro, KHÔNG an toàn tuyệt đối)
            string EscN(string s) => $"N'{Esc(s)}'";
            string que = string.IsNullOrWhiteSpace(queQuan) ? "NULL" : EscN(queQuan);

            var sb = new StringBuilder();
            sb.Append("UPDATE dbo.SinhVien SET ");
            sb.Append($"MaSV='{Esc(maSV)}', ");
            sb.Append($"TenSV={EscN(tenSV)}, ");
            sb.Append($"GioiTinh={EscN(gioiTinh)}, ");
            sb.Append($"NgaySinh='{ngaySinh:yyyy-MM-dd}', ");
            sb.Append($"QueQuan={que}, ");
            sb.Append($"MaLop='{Esc(maLop)}' ");
            sb.Append($"WHERE MaSV='{Esc(originalMaSV)}';");

            using (var conn = Conn())
            using (var cmd = new SqlCommand(sb.ToString(), conn))
            {
                conn.Open();
                return cmd.ExecuteNonQuery();  // trả về số dòng bị ảnh hưởng
            }
        }

        private static string Esc(string input) => (input ?? string.Empty).Replace("'", "''");
    }
}
