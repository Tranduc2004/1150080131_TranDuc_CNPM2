    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    namespace Apdung3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            // Validate rỗng – gọi khi rời control hoặc khi bấm Đăng nhập
            private void txtUsername_Validating(object sender, CancelEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    e.Cancel = true;
                    err.SetError(txtUsername, "Không được để trống Username");
                }
                else err.SetError(txtUsername, "");
            }

            private void txtPassword_Validating(object sender, CancelEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    e.Cancel = true;
                    err.SetError(txtPassword, "Không được để trống Password");
                }
                else err.SetError(txtPassword, "");
            }

            private void chkShow_CheckedChanged(object sender, EventArgs e)
            {
                txtPassword.UseSystemPasswordChar = !chkShow.Checked;
            }

            private void btnLogin_Click(object sender, EventArgs e)
            {
                // Kích hoạt Validate cho toàn form
                if (!ValidateChildren())
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Username và Password.",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chỗ này bạn có thể kiểm tra tài khoản thực (DB/Hardcode)
                // Demo: chấp nhận mọi cặp không rỗng
                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ví dụ mở form chính:
                // new MainForm().Show();
                // this.Hide();
            }

            private void btnExit_Click(object sender, EventArgs e) => Close();
        }
    }
