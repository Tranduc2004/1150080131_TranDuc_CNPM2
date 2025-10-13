using System;
using System.Configuration;             // nhớ Add Reference: System.Configuration
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ThucHanh1
{
    public partial class Form1 : Form
    {
        private readonly string _connStr;

        public Form1()
        {
            InitializeComponent();

            // lấy chuỗi kết nối từ App.config (fallback nếu thiếu)
            _connStr = ConfigurationManager.ConnectionStrings["QLSV"]?.ConnectionString
                ?? @"Data Source=LAPTOP-LQGGA8E3\MSSQLSERVER2;Initial Catalog=QLSV;Integrated Security=True;Persist Security Info=False;TrustServerCertificate=True";
        }

        private SqlConnection GetConn() => new SqlConnection(_connStr);

        private void Form1_Load(object sender, EventArgs e)
        {
            // combobox giới tính
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.SelectedIndex = 0;

            // format ngày
            dtNgaySinh.Format = DateTimePickerFormat.Custom;
            dtNgaySinh.CustomFormat = "yyyy-MM-dd";

            // cấu hình DataGridView (nếu bạn chưa set trong Designer)
            dgvSV.AutoGenerateColumns = true;
            dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSV.RowHeadersVisible = false;
            dgvSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSV.ReadOnly = true;

            LoadSinhVien();
        }

        private void LoadSinhVien()
        {
            try
            {
                using (var conn = GetConn())
                using (var cmd = new SqlCommand(@"
                    SELECT MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop
                    FROM dbo.SinhVien
                    ORDER BY MaSV;", conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvSV.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // validate
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtTenSV.Text) ||
                string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SV, Tên SV và Mã lớp.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = GetConn())
                using (var cmd = new SqlCommand(@"
                    INSERT INTO dbo.SinhVien(MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop)
                    VALUES (@MaSV, @TenSV, @GioiTinh, @NgaySinh, @QueQuan, @MaLop);", conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenSV", txtTenSV.Text.Trim());
                    cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.SelectedItem?.ToString() ?? "Nam");
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtNgaySinh.Value.Date;
                    cmd.Parameters.AddWithValue("@QueQuan", string.IsNullOrWhiteSpace(txtQueQuan.Text) ? (object)DBNull.Value : txtQueQuan.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                ClearInputs();
                LoadSinhVien();
                MessageBox.Show("Thêm sinh viên thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtMaSV.Clear();
            txtTenSV.Clear();
            cboGioiTinh.SelectedIndex = 0;
            dtNgaySinh.Value = DateTime.Today;
            txtQueQuan.Clear();
            txtMaLop.Clear();
            txtMaSV.Focus();
        }
    }
}
