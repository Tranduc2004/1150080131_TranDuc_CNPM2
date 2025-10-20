using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _1150080131_TranDuc_Lab6
{
    public partial class Form4 : Form
    {
        // 👉 Sửa chuỗi kết nối cho đúng máy bạn
        private readonly string _connStr =
            @"Data Source=LAPTOP-LQGGA8E3\MSSQLSERVER2;
              Initial Catalog=QLSV;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True;";

        private SqlConnection _conn;

        public Form4()
        {
            InitializeComponent();
            lsvDanhSach.FullRowSelect = true;
            lsvDanhSach.GridLines = true;
            lsvDanhSach.View = View.Details;
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

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadNXB();
        }

        private void LoadNXB()
        {
            try
            {
                OpenConn();

                // Ưu tiên dùng proc HienThiNXB nếu bạn đã tạo; nếu chưa có, dùng SELECT
                using (var cmd = new SqlCommand("HienThiNXB", _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        lsvDanhSach.Items.Clear();
                        while (rd.Read())
                        {
                            // Giả sử thứ tự cột: NXB, TenNXB, DiaChi
                            var it = new ListViewItem(rd.GetString(0).Trim());
                            it.SubItems.Add(rd.GetString(1));
                            it.SubItems.Add(rd.IsDBNull(2) ? "" : rd.GetString(2));
                            lsvDanhSach.Items.Add(it);
                        }
                    }
                }
            }
            catch   // nếu chưa có proc, fallback sang SELECT
            {
                try
                {
                    using (var cmd2 = new SqlCommand(
                        "SELECT NXB, TenNXB, DiaChi FROM dbo.NhaXuatBan ORDER BY NXB", _conn))
                    using (var rd = cmd2.ExecuteReader())
                    {
                        lsvDanhSach.Items.Clear();
                        while (rd.Read())
                        {
                            var it = new ListViewItem(rd.GetString(0).Trim());
                            it.SubItems.Add(rd.GetString(1));
                            it.SubItems.Add(rd.IsDBNull(2) ? "" : rd.GetString(2));
                            lsvDanhSach.Items.Add(it);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không tải được danh sách:\n" + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally { CloseConn(); }

            ClearDetail();
        }

        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count == 0) return;
            var it = lsvDanhSach.SelectedItems[0];
            txtMaNXB.Text = it.SubItems[0].Text;
            txtTenNXB.Text = it.SubItems[1].Text;
            txtDiaChi.Text = it.SubItems[2].Text;
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => LoadNXB();

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaNXB.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Hãy chọn một NXB để xóa.");
                return;
            }

            var yes = MessageBox.Show(
                $"Bạn chắc chắn muốn xóa NXB [{ma}]?\nThao tác này không thể hoàn tác.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (yes != DialogResult.Yes) return;

            try
            {
                OpenConn();
                using (var cmd = new SqlCommand("XoaNXB", _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@maNXB", SqlDbType.Char, 10) { Value = ma });
                    int kq = cmd.ExecuteNonQuery();

                    if (kq > 0)
                        MessageBox.Show("Đã xóa thành công.", "Thông báo");
                    else
                        MessageBox.Show("Không có dòng nào bị xóa (mã không tồn tại?).");
                }
            }
            catch (SqlException ex)
            {
                // Có thể vướng khóa ngoại (NXB đang được tham chiếu bởi bảng Sách)
                MessageBox.Show("Lỗi SQL khi xóa:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConn();
                LoadNXB(); // refresh danh sách
            }
        }

        private void btnDong_Click(object sender, EventArgs e) => this.Close();

        private void ClearDetail()
        {
            txtMaNXB.Clear();
            txtTenNXB.Clear();
            txtDiaChi.Clear();
            lsvDanhSach.SelectedItems.Clear();
        }
    }
}
