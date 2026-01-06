using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace _1150080131_TranDuc_lab5
{
    public partial class Form5 : Form
    {
        private readonly string _connStr =
            ConfigurationManager.ConnectionStrings["QLSV"]?.ConnectionString
            ?? @"Data Source=LAPTOP-LQGGA8E3\MSSQLSERVER2;Initial Catalog=QLSV;Integrated Security=True;Persist Security Info=False;TrustServerCertificate=True";

        public Form5()
        {
            InitializeComponent();
        }

        private SqlConnection Conn() => new SqlConnection(_connStr);

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadLop();
            LoadGrid(null);
        }

        private void LoadLop()
        {
            const string sql = "SELECT MaLop FROM dbo.Lop ORDER BY MaLop;";
            using (var da = new SqlDataAdapter(sql, Conn()))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cboLop.DataSource = dt;
                cboLop.DisplayMember = "MaLop";
                cboLop.ValueMember = "MaLop";
                cboLop.SelectedIndex = -1;   // xem tất cả
            }
        }

        private void LoadGrid(string maLop)
        {
            var sql = @"SELECT MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop
                        FROM dbo.SinhVien {0} ORDER BY MaSV;";
            var where = string.IsNullOrWhiteSpace(maLop) ? "" : "WHERE MaLop = @MaLop";

            using (var conn = Conn())
            using (var cmd = new SqlCommand(string.Format(sql, where), conn))
            {
                if (!string.IsNullOrWhiteSpace(maLop))
                    cmd.Parameters.Add(new SqlParameter("@MaLop", SqlDbType.VarChar, 20) { Value = maLop });

                using (var da = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvSV.DataSource = dt;
                }
            }

            txtMaSV.Clear();
            btnXoa.Enabled = false;
        }

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
                MessageBox.Show("Hãy chọn một sinh viên để xóa.");
                return;
            }

            var maSV = txtMaSV.Text.Trim();
            var confirm = MessageBox.Show(
                $"Bạn chắc chắn xóa sinh viên có Mã SV = '{maSV}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            const string SQL = "DELETE FROM dbo.SinhVien WHERE MaSV = @MaSV;";

            try
            {
                using (var conn = Conn())
                using (var cmd = new SqlCommand(SQL, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.VarChar, 20) { Value = maSV });

                    conn.Open();
                    int n = cmd.ExecuteNonQuery();              // DELETE với Parameter
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
