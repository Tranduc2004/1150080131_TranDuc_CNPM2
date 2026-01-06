using System;
using System.Windows.Forms;

namespace ThucHanh2
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }

        // Kiểm tra dữ liệu tối thiểu
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được rỗng.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var item = new ListViewItem(txtHoTen.Text.Trim());
            item.SubItems.Add(dtpNgaySinh.Value.ToString("dd/MM/yyyy"));
            item.SubItems.Add(txtLop.Text.Trim());
            item.SubItems.Add(txtDiaChi.Text.Trim());

            lvSinhVien.Items.Add(item);
            ClearInputs();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 dòng để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInput()) return;

            var it = lvSinhVien.SelectedItems[0];
            it.Text = txtHoTen.Text.Trim();
            it.SubItems[1].Text = dtpNgaySinh.Value.ToString("dd/MM/yyyy");
            it.SubItems[2].Text = txtLop.Text.Trim();
            it.SubItems[3].Text = txtDiaChi.Text.Trim();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 dòng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa dòng đã chọn?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lvSinhVien.Items.Remove(lvSinhVien.SelectedItems[0]);
                ClearInputs();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Khi chọn 1 dòng -> đổ dữ liệu lên form
        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0) return;
            var it = lvSinhVien.SelectedItems[0];

            txtHoTen.Text = it.Text;
            if (DateTime.TryParse(it.SubItems[1].Text, out var d))
                dtpNgaySinh.Value = d;
            else
                dtpNgaySinh.Value = DateTime.Today;

            txtLop.Text = it.SubItems[2].Text;
            txtDiaChi.Text = it.SubItems[3].Text;
        }

        private void ClearInputs()
        {
            txtHoTen.Clear();
            txtLop.Clear();
            txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            txtHoTen.Focus();
        }
    }
}
