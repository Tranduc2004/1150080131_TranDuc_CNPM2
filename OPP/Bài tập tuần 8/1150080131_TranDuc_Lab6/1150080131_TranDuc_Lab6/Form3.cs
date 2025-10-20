using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _1150080131_TranDuc_Lab6
{
    public partial class Form3 : Form
    {
        // 👉 Sửa chuỗi kết nối cho đúng máy bạn
        private readonly string _connStr =
            @"Data Source=LAPTOP-LQGGA8E3\MSSQLSERVER2;
              Initial Catalog=QLSV;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True;";

        private SqlConnection _conn;

        public Form3()
        {
            InitializeComponent();
            this.AcceptButton = btnLuu;
            this.CancelButton = btnDong;
        }

        private void OpenConn()
        {
            if (_conn == null) _conn = new SqlConnection(_connStr);
            if (_conn.State != ConnectionState.Open) _conn.Open();
        }
        private void CloseConn()
        {
            if (_conn != null && _conn.State == ConnectionState.Open) _conn.Close();
        }

        // ====== Nút: Tải dữ liệu theo Mã ======
        private void btnTai_Click(object sender, EventArgs e)
        {
            string ma = txtMaNXB.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Nhập Mã NXB trước khi tải.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNXB.Focus(); return;
            }
            if (ma.Length > 10)
            {
                MessageBox.Show("Mã NXB tối đa 10 ký tự (CHAR(10)).");
                txtMaNXB.Focus(); return;
            }

            try
            {
                OpenConn();
                using (var cmd = new SqlCommand(
                    "SELECT TenNXB, DiaChi FROM dbo.NhaXuatBan WHERE NXB = @ma", _conn))
                {
                    cmd.Parameters.Add("@ma", SqlDbType.Char, 10).Value = ma;

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            txtTenNXB.Text = r.IsDBNull(0) ? "" : r.GetString(0);
                            txtDiaChi.Text = r.IsDBNull(1) ? "" : r.GetString(1);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy NXB có mã này.");
                            txtTenNXB.Clear();
                            txtDiaChi.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { CloseConn(); }
        }

        // ====== Nút: Lưu (gọi proc CapNhatThongTin) ======
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMaNXB.Text.Trim();
            string ten = txtTenNXB.Text.Trim();
            string dc = txtDiaChi.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma) || ma.Length > 10)
            {
                MessageBox.Show("Mã NXB không hợp lệ (tối đa 10 ký tự).");
                txtMaNXB.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập Tên NXB.");
                txtTenNXB.Focus(); return;
            }

            try
            {
                OpenConn();
                using (var cmd = new SqlCommand("CapNhatThongTin", _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@maNXB", SqlDbType.Char, 10).Value = ma;
                    cmd.Parameters.Add("@tenNXB", SqlDbType.NVarChar, 100).Value = ten;
                    cmd.Parameters.Add("@diaChi", SqlDbType.NVarChar, 500).Value =
                        string.IsNullOrEmpty(dc) ? (object)DBNull.Value : dc;

                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                        MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    else
                        MessageBox.Show("Không có dòng nào được cập nhật (mã không tồn tại?).");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL khi cập nhật:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { CloseConn(); }
        }

        private void btnDong_Click(object sender, EventArgs e) => this.Close();
    }
}
