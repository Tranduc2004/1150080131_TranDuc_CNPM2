using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _1150080131_TranDuc_lab5.Repositories
{
    public class SinhVienRepo
    {
        private readonly string _connStr =
            ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;

        public int InsertSinhVien(string maSV, string tenSV, string gioiTinh,
                                  DateTime ngaySinh, string queQuan, string maLop)
        {
            const string SQL = @"
INSERT INTO dbo.SinhVien (MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop)
VALUES (@MaSV, @TenSV, @GioiTinh, @NgaySinh, @QueQuan, @MaLop);";

            using (var conn = new SqlConnection(_connStr))
            using (var cmd = new SqlCommand(SQL, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.VarChar, 20) { Value = maSV.Trim() });
                cmd.Parameters.Add(new SqlParameter("@TenSV", SqlDbType.NVarChar, 100) { Value = tenSV.Trim() });
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", SqlDbType.NVarChar, 10) { Value = gioiTinh });
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", SqlDbType.Date) { Value = ngaySinh.Date });
                cmd.Parameters.Add(new SqlParameter("@QueQuan", SqlDbType.NVarChar, 100)
                { Value = string.IsNullOrWhiteSpace(queQuan) ? (object)DBNull.Value : queQuan.Trim() });
                cmd.Parameters.Add(new SqlParameter("@MaLop", SqlDbType.VarChar, 20) { Value = maLop.Trim() });

                conn.Open();
                return cmd.ExecuteNonQuery(); // 1 nếu thêm thành công
            }
        }

        public DataTable GetAll()
        {
            const string SQL = @"SELECT MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop
                                 FROM dbo.SinhVien ORDER BY MaSV;";
            using (var conn = new SqlConnection(_connStr))
            using (var da = new SqlDataAdapter(SQL, conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
