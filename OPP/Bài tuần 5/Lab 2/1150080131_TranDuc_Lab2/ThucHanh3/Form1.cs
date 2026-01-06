using System;
using System.Linq;
using System.Windows.Forms;

namespace ThucHanh3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtSoNguyen.Focus();
        }

        // Chỉ cho nhập số nguyên (cho phép dấu - ở đầu)
        private void txtSoNguyen_KeyPress_IntOnly(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '-' && txtSoNguyen.SelectionStart == 0 && !txtSoNguyen.Text.Contains("-"))
                return;
            e.Handled = true;
        }

        // Enter để thêm số
        private void txtSoNguyen_KeyDown_EnterToAdd(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnNhapSo.PerformClick(); e.SuppressKeyPress = true; }
        }

        private void btnNhapSo_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoNguyen.Text, out int value))
            {
                lsbDaySo.Items.Add(value);
                txtSoNguyen.Clear();
                txtSoNguyen.Focus();
            }
            else
            {
                MessageBox.Show("Hãy nhập số nguyên hợp lệ.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoNguyen.SelectAll();
                txtSoNguyen.Focus();
            }
        }

        private void btnTang2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsbDaySo.Items.Count; i++)
            {
                int v = (int)lsbDaySo.Items[i];
                lsbDaySo.Items[i] = v + 2;
            }
        }

        private void btnChonChanDau_Click(object sender, EventArgs e)
        {
            lsbDaySo.ClearSelected();
            for (int i = 0; i < lsbDaySo.Items.Count; i++)
            {
                if (((int)lsbDaySo.Items[i]) % 2 == 0) { lsbDaySo.SelectedIndex = i; break; }
            }
        }

        private void btnChonLeCuoi_Click(object sender, EventArgs e)
        {
            lsbDaySo.ClearSelected();
            for (int i = lsbDaySo.Items.Count - 1; i >= 0; i--)
            {
                if (Math.Abs((int)lsbDaySo.Items[i]) % 2 == 1) { lsbDaySo.SelectedIndex = i; break; }
            }
        }

        private void btnXoaDangChon_Click(object sender, EventArgs e)
        {
            while (lsbDaySo.SelectedIndices.Count > 0)
                lsbDaySo.Items.RemoveAt(lsbDaySo.SelectedIndices[0]);
        }

        private void btnXoaDau_Click(object sender, EventArgs e)
        {
            if (lsbDaySo.Items.Count > 0) lsbDaySo.Items.RemoveAt(0);
        }

        private void btnXoaCuoi_Click(object sender, EventArgs e)
        {
            int n = lsbDaySo.Items.Count;
            if (n > 0) lsbDaySo.Items.RemoveAt(n - 1);
        }

        private void btnXoaDaySo_Click(object sender, EventArgs e)
        {
            lsbDaySo.Items.Clear();
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
