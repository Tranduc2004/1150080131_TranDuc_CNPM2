using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;

namespace SecurityPanelApp
{
    public partial class Form1 : Form
    {
        // map mật mã -> tên nhóm
        private readonly Dictionary<string, string> _passToGroup = new Dictionary<string, string>
        {
            { "1496", "Phát triển công nghệ" },
            { "2673", "Phát triển công nghệ" },
            { "7462", "Nghiên cứu viên" },
            { "8884", "Thiết kế mô hình" },
            { "3842", "Thiết kế mô hình" },
            { "3383", "Thiết kế mô hình" }
        };

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // cho phép nhận phím Enter/Esc
        }

        // --- EVENTS ---

        private void Key_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length >= 4) return; // chỉ 4 chữ số
            var btn = (Button)sender;
            txtPassword.Text += btn.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtPassword.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            var pw = txtPassword.Text.Trim();
            CheckPasswordAndLog(pw);
            txtPassword.Clear();
            txtPassword.Focus();
        }

        private void btnRing_Click(object sender, EventArgs e)
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("Chuông đang reo!", "RING", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- CORE ---

        private void CheckPasswordAndLog(string pw)
        {
            string group = _passToGroup.TryGetValue(pw, out string g) ? g : "Không có";
            bool accepted = group != "Không có";

            string result = accepted ? "Chấp nhận!" : "Từ chối!";
            var item = new ListViewItem(DateTime.Now.ToString("g")); // ngày giờ ngắn
            item.SubItems.Add(group);
            item.SubItems.Add(result);
            lvLog.Items.Insert(0, item); // mới nhất lên đầu

            // âm báo nhỏ
            if (accepted) SystemSounds.Asterisk.Play();
            else SystemSounds.Hand.Play();
        }

        // hỗ trợ phím Enter/Esc
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter) { btnEnter.PerformClick(); return true; }
            if (keyData == Keys.Escape) { btnClear.PerformClick(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
