using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace _1150080131_TranDuc_lab5
{
    public partial class Form4 : Form
    {
        private readonly string _connStr =
            ConfigurationManager.ConnectionStrings["QLSV"]?.ConnectionString
            ?? @"Data Source=LAPTOP-LQGGA8E3\MSSQLSERVER2;Initial Catalog=QLSV;Integrated Security=True;Persist Security Info=False;TrustServerCertificate=True";

        public Form4()
        {
            InitializeComponent();
        }

        private SqlConnection Conn() => new SqlConnection(_connStr);

        private void Form4_Load(object sender, EventArgs e)
        {
            // load lớp
            using (var da = new SqlDataAdapter("SELECT MaLop FROM dbo.Lop ORDER BY MaLop;", Conn()))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cboLop.DataSource = dt;
                cboLop.DisplayMember = "MaLop";
                cboLop.ValueMember = "MaLop";
                cboLop.SelectedIndex = -1; // xem tất cả
            }

            LoadGrid(null);
        }

        private void LoadGrid(string maLop)
        {
            string sql = string.IsNullOrWhiteSpace(maLop)
                ? @"SELECT MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop
                    FROM dbo.SinhVien ORDER BY MaSV;"
                : $@"SELECT MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop
                    FROM dbo.SinhVien WHERE MaLop = '{Esc(maLop)}' ORDER BY MaSV;";

            using (var da = new SqlDataAdapter(sql, Conn()))
            {
                var dt = new DataTable();
                da.Fill(dt);
                dgvSV.DataSource = dt;
            }

            txtMaSV.Clear();
            btnXoa.Enabled = false;
        }

        private static string Esc(string s) => (s ?? string.Empty).Replace("'", "''");

        private void cboLop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadGrid(cboLop.SelectedValue?.ToString());
        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvSV.Rows[e.RowIndex];
            txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
            btnXoa.Enabled = !string.IsNullOrWhiteSpace(txtMaSV.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Hãy chọn một sinh viên để xóa.", "Thông báo");
                return;
            }

            var maSV = txtMaSV.Text.Trim();
            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sinh viên có Mã SV = '{maSV}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            // KHÔNG dùng parameter theo yêu cầu bài: nối chuỗi
            string sql = $"DELETE FROM dbo.SinhVien WHERE MaSV = '{Esc(maSV)}';";

            try
            {
                using (var conn = Conn())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    int n = cmd.ExecuteNonQuery();          // ExecuteNonQuery để xóa
                    if (n == 1)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadGrid(cboLop.SelectedIndex >= 0 ? cboLop.SelectedValue?.ToString() : null);
                    }
                    else
                    {
                        MessageBox.Show("Không có bản ghi nào bị xóa.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL lỗi: " + ex.Message, "SQL Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
