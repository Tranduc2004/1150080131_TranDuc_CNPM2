using System;
using System.Globalization;
using System.Windows.Forms;

namespace _1150080131_TranDuc_Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // txtKetQua chỉ hiển thị kết quả
            if (txtKetQua != null) txtKetQua.ReadOnly = true;
        }

        // --- Helpers ---
        private bool TryGetInputs(out double a, out double b)
        {
            // Chấp nhận cả dấu , và .
            bool okA = double.TryParse(txtA.Text.Replace(',', '.'),
                                       NumberStyles.Float, CultureInfo.InvariantCulture, out a);
            bool okB = double.TryParse(txtB.Text.Replace(',', '.'),
                                       NumberStyles.Float, CultureInfo.InvariantCulture, out b);
            if (!okA || !okB)
            {
                MessageBox.Show("Vui lòng nhập số thực hợp lệ cho a và b.",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKetQua.Clear();
                return false;
            }
            return true;
        }

        // --- Event handlers mà Designer đang gắn ---

        private void txt_KeyPress_Number(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số, ., , và phím điều khiển
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            if (!TryGetInputs(out double a, out double b)) return;
            txtKetQua.Text = (a + b).ToString();
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            if (!TryGetInputs(out double a, out double b)) return;
            txtKetQua.Text = (a - b).ToString();
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (!TryGetInputs(out double a, out double b)) return;
            txtKetQua.Text = (a * b).ToString();
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            if (!TryGetInputs(out double a, out double b)) return;
            if (b == 0)
            {
                MessageBox.Show("Không thể chia cho 0.", "Lỗi tính toán",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKetQua.Clear();
                return;
            }
            txtKetQua.Text = (a / b).ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtKetQua.Clear();
            txtA.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
