using _1150080131_TranDuc_lab5.Repositories;
using System;
using System.Windows.Forms;

namespace _1150080131_TranDuc_lab5
{
    public partial class Form1 : Form
    {
        private readonly SinhVienRepo _repo = new SinhVienRepo();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.SelectedIndex = 0;

            dtNgaySinh.Format = DateTimePickerFormat.Custom;
            dtNgaySinh.CustomFormat = "yyyy-MM-dd";

            LoadGrid();
        }

        private void LoadGrid()
        {
            try { dgvSV.DataSource = _repo.GetAll(); }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtTenSV.Text) ||
                string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Nhập Mã SV, Tên SV, Mã lớp.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var n = _repo.InsertSinhVien(
                     maSV: txtMaSV.Text,
                     tenSV: txtTenSV.Text,
                     gioiTinh: cboGioiTinh.SelectedItem != null ? cboGioiTinh.SelectedItem.ToString() : "",
                     ngaySinh: dtNgaySinh.Value,
                     queQuan: txtQueQuan.Text,
                     maLop: txtMaLop.Text
                 );

                if (n == 1)
                {
                    ClearInputs();
                    LoadGrid();
                    MessageBox.Show("Thêm sinh viên thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
