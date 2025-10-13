using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace _1150080131_TranDuc_lab5
{
    public partial class Form3 : Form
    {
        private readonly string _connStr =
            ConfigurationManager.ConnectionStrings["QLSV"]?.ConnectionString
            ?? @"Data Source=LAPTOP-LQGGA8E3\MSSQLSERVER2;Initial Catalog=QLSV;Integrated Security=True;Persist Security Info=False;TrustServerCertificate=True";

        private string _originalMaSV = ""; // giữ MaSV gốc để WHERE khi cho phép đổi MaSV

        public Form3()
        {
            InitializeComponent();
        }

        private SqlConnection Conn() => new SqlConnection(_connStr);

        private void Form3_Load(object sender, EventArgs e)
        {
            // Combobox giới tính
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.SelectedIndex = 0;

            // Combobox lớp
            LoadLop();

            // Ngày sinh
            dtNgaySinh.Format = DateTimePickerFormat.Custom;
            dtNgaySinh.CustomFormat = "yyyy-MM-dd";

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
                cboLop.SelectedIndex = -1; // xem tất cả
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
        }

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
                MessageBox.Show("Hãy chọn một sinh viên ở danh sách.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtTenSV.Text) ||
                string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Mã SV, Tên SV, Mã lớp không được trống.");
                return;
            }

            const string SQL = @"
UPDATE dbo.SinhVien
SET MaSV=@MaSV, TenSV=@TenSV, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh,
    QueQuan=@QueQuan, MaLop=@MaLop
WHERE MaSV=@OriginalMaSV;";

            try
            {
                using (var conn = Conn())
                using (var cmd = new SqlCommand(SQL, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.VarChar, 20) { Value = txtMaSV.Text.Trim() });
                    cmd.Parameters.Add(new SqlParameter("@TenSV", SqlDbType.NVarChar, 100) { Value = txtTenSV.Text.Trim() });
                    cmd.Parameters.Add(new SqlParameter("@GioiTinh", SqlDbType.NVarChar, 10) { Value = cboGioiTinh.Text });
                    cmd.Parameters.Add(new SqlParameter("@NgaySinh", SqlDbType.Date) { Value = dtNgaySinh.Value.Date });
                    // cho phép null
                    var q = string.IsNullOrWhiteSpace(txtQueQuan.Text) ? (object)DBNull.Value : txtQueQuan.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@QueQuan", SqlDbType.NVarChar, 100) { Value = q });
                    cmd.Parameters.Add(new SqlParameter("@MaLop", SqlDbType.VarChar, 20) { Value = txtMaLop.Text.Trim() });
                    cmd.Parameters.Add(new SqlParameter("@OriginalMaSV", SqlDbType.VarChar, 20) { Value = _originalMaSV });

                    conn.Open();
                    int n = cmd.ExecuteNonQuery(); // dùng ExecuteNonQuery
                    if (n == 1)
                    {
                        MessageBox.Show("Sửa thành công!");
                        LoadGrid(cboLop.SelectedIndex >= 0 ? cboLop.SelectedValue?.ToString() : null);
                        _originalMaSV = txtMaSV.Text.Trim(); // cập nhật khoá gốc nếu bạn vừa đổi MaSV
                    }
                    else
                    {
                        MessageBox.Show("Không có bản ghi nào được cập nhật.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL lỗi: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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
