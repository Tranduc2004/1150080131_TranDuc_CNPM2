using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _1150080131_TranDuc_Lab6
{
    public partial class Form2 : Form
    {
        // SỬA lại chuỗi kết nối phù hợp máy bạn
        private readonly string _connStr =
            @"Data Source=LAPTOP-LQGGA8E3\MSSQLSERVER2;
              Initial Catalog=QLSV;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True;";

        private SqlConnection _conn;

        public Form2()
        {
            InitializeComponent();
            // ListView config (nếu chưa set trong Designer)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadNXB();
        }

        // ====== HIỂN THỊ DANH SÁCH ======
        private void LoadNXB()
        {
            try
            {
                OpenConn();
                using (var cmd = new SqlCommand("HienThiNXB", _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        lsvDanhSach.Items.Clear();
                        while (rd.Read())
                        {
                            // Giả sử proc trả (NXB, TenNXB, DiaChi)
                            var item = new ListViewItem(rd.GetString(0).Trim());
                            item.SubItems.Add(rd.GetString(1));
                            item.SubItems.Add(rd.IsDBNull(2) ? "" : rd.GetString(2));
                            lsvDanhSach.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách NXB:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { CloseConn(); }
        }

        // Chọn 1 dòng -> đổ xuống ô nhập (để nhìn rõ/hoặc chuẩn bị sửa sau này)
        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count == 0) return;
            var it = lsvDanhSach.SelectedItems[0];
            txtNXB.Text = it.SubItems[0].Text;
            txtTenNXB.Text = it.SubItems[1].Text;
            txtDiaChi.Text = it.SubItems[2].Text;
        }

        // ====== THÊM DỮ LIỆU ======
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNXB.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã NXB (tối đa 10 ký tự).");
                txtNXB.Focus(); return false;
            }
            if (txtNXB.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã NXB tối đa 10 ký tự (CHAR(10)).");
                txtNXB.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenNXB.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên NXB.");
                txtTenNXB.Focus(); return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                OpenConn();
                using (var cmd = new SqlCommand("ThemDuLieu", _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@maNXB", SqlDbType.Char, 10)
                    { Value = txtNXB.Text.Trim() });
                    cmd.Parameters.Add(new SqlParameter("@tenNXB", SqlDbType.NVarChar, 100)
                    { Value = txtTenNXB.Text.Trim() });
                    cmd.Parameters.Add(new SqlParameter("@diaChi", SqlDbType.NVarChar, 500)
                    { Value = (object)txtDiaChi.Text.Trim() ?? DBNull.Value });

                    cmd.ExecuteNonQuery();
                }


                MessageBox.Show("Thêm NXB thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadNXB();      // reload để thấy ngay dòng mới
                ClearInputs();  // xóa ô nhập
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL khi thêm dữ liệu:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { CloseConn(); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => LoadNXB();
        private void btnXoaTrang_Click(object sender, EventArgs e) => ClearInputs();

        private void ClearInputs()
        {
            txtNXB.Clear();
            txtTenNXB.Clear();
            txtDiaChi.Clear();
            txtNXB.Focus();
            lsvDanhSach.SelectedItems.Clear();
        }
    }
}
