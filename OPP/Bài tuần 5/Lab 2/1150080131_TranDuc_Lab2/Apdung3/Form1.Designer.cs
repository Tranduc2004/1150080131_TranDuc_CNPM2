namespace Apdung3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ErrorProvider err;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 220);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.AcceptButton = this.btnLogin;     // Enter = Đăng nhập
            this.CancelButton = this.btnExit;      // Esc   = Thoát
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "LOGIN";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 48;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Text = "Username:";
            this.lblUser.Location = new System.Drawing.Point(28, 70);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(110, 66);
            this.txtUsername.Size = new System.Drawing.Size(270, 23);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Text = "Password:";
            this.lblPass.Location = new System.Drawing.Point(28, 105);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(110, 101);
            this.txtPassword.Size = new System.Drawing.Size(270, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // chkShow
            // 
            this.chkShow.AutoSize = true;
            this.chkShow.Text = "Hiện mật khẩu";
            this.chkShow.Location = new System.Drawing.Point(110, 130);
            this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Location = new System.Drawing.Point(110, 160);
            this.btnLogin.Size = new System.Drawing.Size(120, 30);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Text = "Thoát";
            this.btnExit.Location = new System.Drawing.Point(260, 160);
            this.btnExit.Size = new System.Drawing.Size(120, 30);
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // add controls
            // 
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.chkShow);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnExit);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
