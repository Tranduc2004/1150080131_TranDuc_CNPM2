using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace _1150080131_TranDuc_lab5
{
    public partial class Form2 : Form
    {
        // lấy từ App.config, nếu thiếu thì dùng chuỗi fallback
        private readonly string _connStr =
            ConfigurationManager.ConnectionStrings["QLSV"]?.ConnectionString
            ?? @"Data Source=LAPTOP-LQGGA8E3\MSSQLSERVER2;Initial Catalog=QLSV;Integrated Security=True;Persist Security Info=False;TrustServerCertificate=True";

        private string _originalMaSV = "";  // giữ MaSV gốc khi sửa

        public Form2()
        {
            InitializeComponent();
        }

        private SqlConnection Conn() => new SqlConnection(_connStr);

        private void Form2_Load(object sender, EventArgs e)
        {
            // format ngày
            dtNgaySinh.Format = DateTimePickerFormat.Custom;
            dtNgaySinh.CustomFormat = "yyyy-MM-dd";

            // combobox giới tính
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.SelectedIndex = 0;

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
                cboLop.SelectedIndex = -1; // xem tất cả khi mới mở
            }
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
        }

        private static string Esc(string s) => (s ?? string.Empty).Replace("'", "''"); // escape đơn giản

        private void cboLop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadGrid(cboLop.SelectedValue?.ToString());
            ClearInputs();
        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvSV.Rows[e.RowIndex];

            _originalMaSV = row.Cells["MaSV"].Value?.ToString() ?? "";
            txtMaSV.Text = _originalMaSV;
            txtTenSV.Text = row.Cells["TenSV"].Value?.ToString();
            cboGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString() ?? "Nam";
            txtQueQuan.Text = row.Cells["QueQuan"].Value?.ToString();
            txtMaLop.Text = row.Cells["MaLop"].Value?.ToString();

            if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out var d))
                dtNgaySinh.Value = d;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_originalMaSV))
            {
                MessageBox.Show("Hãy chọn một sinh viên ở danh sách bên trái.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtTenSV.Text) ||
                string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Mã SV, Tên SV, Mã lớp không được trống.");
                return;
            }

            // GHÍ CHÚ: theo yêu cầu bài, KHÔNG dùng parameter → nối chuỗi
            string que = string.IsNullOrWhiteSpace(txtQueQuan.Text)
                ? "NULL" : $"N'{Esc(txtQueQuan.Text)}'";

            var sb = new StringBuilder();
            sb.Append("UPDATE dbo.SinhVien SET ");
            sb.Append($"MaSV='{Esc(txtMaSV.Text)}', ");
            sb.Append($"TenSV=N'{Esc(txtTenSV.Text)}', ");
            sb.Append($"GioiTinh=N'{Esc(cboGioiTinh.Text)}', ");
            sb.Append($"NgaySinh='{dtNgaySinh.Value:yyyy-MM-dd}', ");
            sb.Append($"QueQuan={que}, ");
            sb.Append($"MaLop='{Esc(txtMaLop.Text)}' ");
            sb.Append($"WHERE MaSV='{Esc(_originalMaSV)}';");

            try
            {
                using (var conn = Conn())
                using (var cmd = new SqlCommand(sb.ToString(), conn))
                {
                    conn.Open();
                    int n = cmd.ExecuteNonQuery();  // Sửa dữ liệu: ExecuteNonQuery
                    if (n == 1)
                    {
                        MessageBox.Show("Sửa thành công!");
                        LoadGrid(cboLop.SelectedIndex >= 0 ? cboLop.SelectedValue?.ToString() : null);
                    }
                    else
                    {
                        MessageBox.Show("Không có bản ghi nào được cập nhật.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa dữ liệu: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            _originalMaSV = "";
            txtMaSV.Clear();
            txtTenSV.Clear();
            cboGioiTinh.SelectedIndex = 0;
            dtNgaySinh.Value = DateTime.Today;
            txtQueQuan.Clear();
            txtMaLop.Clear();
        }
    }
}
