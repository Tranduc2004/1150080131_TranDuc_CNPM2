using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace ThucHanh2
{
    public partial class Form1 : Form
    {
        // Giá dịch vụ (đồng)
        private const decimal GIA_CAO_RANG = 50_000m;
        private const decimal GIA_TAY_TRANG = 100_000m;
        private const decimal GIA_HAN = 100_000m;     // / răng
        private const decimal GIA_BE = 10_000m;       // / răng
        private const decimal GIA_BOC = 1_000_000m;   // / răng

        private readonly CultureInfo _vi = new CultureInfo("vi-VN");

        public Form1()
        {
            InitializeComponent();
        }

        // Bật/tắt số răng theo checkbox
        private void chkTheoRang_CheckedChanged(object sender, EventArgs e)
        {
            nudHan.Enabled = chkHanRang.Checked;
            nudBe.Enabled = chkBeRang.Checked;
            nudBoc.Enabled = chkBocRang.Checked;

            if (!chkHanRang.Checked) nudHan.Value = 0;
            if (!chkBeRang.Checked) nudBe.Value = 0;
            if (!chkBocRang.Checked) nudBoc.Value = 0;
        }

        // Validate tên KH (không để trống)
        private void txtTen_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                e.Cancel = true;
                err.SetError(txtTen, "Không được để trống tên khách hàng");
            }
            else
            {
                err.SetError(txtTen, "");
            }
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            // bắt buộc tên
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                err.SetError(txtTen, "Không được để trống tên khách hàng");
                txtTen.Focus();
                return;
            }
            err.SetError(txtTen, "");

            decimal tong = 0;
            if (chkCaoRang.Checked) tong += GIA_CAO_RANG;
            if (chkTayTrang.Checked) tong += GIA_TAY_TRANG;
            if (chkHanRang.Checked) tong += GIA_HAN * nudHan.Value;
            if (chkBeRang.Checked) tong += GIA_BE * nudBe.Value;
            if (chkBocRang.Checked) tong += GIA_BOC * nudBoc.Value;

            txtTong.Text = tong.ToString("c0", _vi); // định dạng tiền VNĐ
        }

        private void btnThoat_Click(object sender, EventArgs e) => Close();
    }
}
