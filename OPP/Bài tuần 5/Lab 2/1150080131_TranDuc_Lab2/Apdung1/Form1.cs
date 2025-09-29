using System;
using System.Windows.Forms;

namespace ApDung1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radUSCLN.Checked = true; // mặc định
            txtA.Focus();
        }

        // --- Sự kiện ---
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (!TryReadInt(txtA.Text, out int a) || !TryReadInt(txtB.Text, out int b))
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ cho a và b.",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKetQua.Clear();
                return;
            }

            if (radUSCLN.Checked)
            {
                int g = Gcd(a, b);
                txtKetQua.Text = $"USCLN({a}, {b}) = {g}";
            }
            else
            {
                int g = Gcd(a, b);
                long l = Lcm(a, b, g);
                txtKetQua.Text = $"BSCNN({a}, {b}) = {l}";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e) => this.Close();

        // Chỉ cho nhập số nguyên và phím điều khiển (+/- cho số âm nếu muốn)
        private void txt_KeyPress_Int(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                e.Handled = true;

            // chỉ một dấu '-' ở đầu
            var tb = sender as TextBox;
            if (e.KeyChar == '-' && (tb == null || tb.SelectionStart != 0 || tb.Text.Contains("-")))
                e.Handled = true;
        }

        // --- Logic ---
        private static int Gcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0) return b;
            if (b == 0) return a;
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        private static long Lcm(int a, int b, int gcd)
        {
            if (a == 0 || b == 0) return 0;
            return Math.Abs((long)a / gcd * b); // tránh tràn
        }

        private static bool TryReadInt(string s, out int v) => int.TryParse(s, out v);
    }
}
