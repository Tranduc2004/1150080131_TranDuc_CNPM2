using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _1150080131_TranDuc_Lab6
{
    public partial class Form1 : Form
    {

        private readonly string _connStr =
    @"Data Source=LAPTOP-LQGGA8E3\MSSQLSERVER2;
      Initial Catalog=QLSV;
      Integrated Security=True;
      Encrypt=True;
      TrustServerCertificate=True;";

        private SqlConnection _conn;

        public Form1()
        {
            InitializeComponent();
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
            TryLoadNXB();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            TryLoadNXB();
        }

        private void TryLoadNXB()
        {
            try
            {
                LoadNXB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách NXB:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNXB()
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
                        // Giả sử proc trả: MaNXB (0), TenNXB (1), DiaChi (2)
                        string ma = rd.GetString(0).Trim();
                        string ten = rd.GetString(1);
                        string diachi = rd.GetString(2);

                        var item = new ListViewItem(ma);
                        item.SubItems.Add(ten);
                        item.SubItems.Add(diachi);
                        lsvDanhSach.Items.Add(item);
                    }
                }
            }

            CloseConn();
            ClearDetail();
        }

        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count == 0) return;
            string ma = lsvDanhSach.SelectedItems[0].SubItems[0].Text;
            ShowNXBById(ma);
        }

        private void ShowNXBById(string maNXB)
        {
            try
            {
                OpenConn();
                using (var cmd = new SqlCommand("HienThiChiTietNXB", _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@maNXB", SqlDbType.Char, 10) { Value = maNXB });

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            txtMaNXB.Text = rd.GetString(0).Trim();
                            txtTenNXB.Text = rd.GetString(1);
                            txtDiaChi.Text = rd.GetString(2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải chi tiết NXB:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConn();
            }
        }

        private void ClearDetail()
        {
            txtMaNXB.Clear();
            txtTenNXB.Clear();
            txtDiaChi.Clear();
        }
    }
}
