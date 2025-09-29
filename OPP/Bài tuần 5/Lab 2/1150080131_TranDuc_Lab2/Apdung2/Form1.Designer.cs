namespace SecurityPanelApp
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

        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox grpKeyboard;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnRing;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colGroup;
        private System.Windows.Forms.ColumnHeader colResult;

        private void InitializeComponent()
        {
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.grpKeyboard = new System.Windows.Forms.GroupBox();
            this.btn1 = new System.Windows.Forms.Button(); this.btn2 = new System.Windows.Forms.Button(); this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button(); this.btn5 = new System.Windows.Forms.Button(); this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button(); this.btn8 = new System.Windows.Forms.Button(); this.btn9 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button(); this.btnEnter = new System.Windows.Forms.Button(); this.btnRing = new System.Windows.Forms.Button();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.lvLog = new System.Windows.Forms.ListView();
            this.colTime = new System.Windows.Forms.ColumnHeader();
            this.colGroup = new System.Windows.Forms.ColumnHeader();
            this.colResult = new System.Windows.Forms.ColumnHeader();
            this.grpKeyboard.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 420);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Panel";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 15);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 15);
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(85, 12);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOnly = true;               // chỉ nhập bằng keypad
            this.txtPassword.Size = new System.Drawing.Size(510, 23);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.UseSystemPasswordChar = true;  // che ký tự
            // 
            // grpKeyboard
            // 
            this.grpKeyboard.Controls.Add(this.btn1); this.grpKeyboard.Controls.Add(this.btn2); this.grpKeyboard.Controls.Add(this.btn3);
            this.grpKeyboard.Controls.Add(this.btn4); this.grpKeyboard.Controls.Add(this.btn5); this.grpKeyboard.Controls.Add(this.btn6);
            this.grpKeyboard.Controls.Add(this.btn7); this.grpKeyboard.Controls.Add(this.btn8); this.grpKeyboard.Controls.Add(this.btn9);
            this.grpKeyboard.Controls.Add(this.btnClear); this.grpKeyboard.Controls.Add(this.btnEnter); this.grpKeyboard.Controls.Add(this.btnRing);
            this.grpKeyboard.Location = new System.Drawing.Point(15, 50);
            this.grpKeyboard.Name = "grpKeyboard";
            this.grpKeyboard.Size = new System.Drawing.Size(580, 160);
            this.grpKeyboard.Text = "Keyboard:";
            // 
            // keypad buttons (3x3)
            // 
            int left = 20, top = 25, step = 55, w = 45, h = 35;
            // btn1..btn9 geometry
            this.btn1.Location = new System.Drawing.Point(left + 0 * step, top + 0 * step); this.btn1.Size = new System.Drawing.Size(w, h); this.btn1.Text = "1";
            this.btn2.Location = new System.Drawing.Point(left + 1 * step, top + 0 * step); this.btn2.Size = new System.Drawing.Size(w, h); this.btn2.Text = "2";
            this.btn3.Location = new System.Drawing.Point(left + 2 * step, top + 0 * step); this.btn3.Size = new System.Drawing.Size(w, h); this.btn3.Text = "3";
            this.btn4.Location = new System.Drawing.Point(left + 0 * step, top + 1 * step); this.btn4.Size = new System.Drawing.Size(w, h); this.btn4.Text = "4";
            this.btn5.Location = new System.Drawing.Point(left + 1 * step, top + 1 * step); this.btn5.Size = new System.Drawing.Size(w, h); this.btn5.Text = "5";
            this.btn6.Location = new System.Drawing.Point(left + 2 * step, top + 1 * step); this.btn6.Size = new System.Drawing.Size(w, h); this.btn6.Text = "6";
            this.btn7.Location = new System.Drawing.Point(left + 0 * step, top + 2 * step); this.btn7.Size = new System.Drawing.Size(w, h); this.btn7.Text = "7";
            this.btn8.Location = new System.Drawing.Point(left + 1 * step, top + 2 * step); this.btn8.Size = new System.Drawing.Size(w, h); this.btn8.Text = "8";
            this.btn9.Location = new System.Drawing.Point(left + 2 * step, top + 2 * step); this.btn9.Size = new System.Drawing.Size(w, h); this.btn9.Text = "9";

            this.btn1.Click += new System.EventHandler(this.Key_Click);
            this.btn2.Click += new System.EventHandler(this.Key_Click);
            this.btn3.Click += new System.EventHandler(this.Key_Click);
            this.btn4.Click += new System.EventHandler(this.Key_Click);
            this.btn5.Click += new System.EventHandler(this.Key_Click);
            this.btn6.Click += new System.EventHandler(this.Key_Click);
            this.btn7.Click += new System.EventHandler(this.Key_Click);
            this.btn8.Click += new System.EventHandler(this.Key_Click);
            this.btn9.Click += new System.EventHandler(this.Key_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Khaki;
            this.btnClear.Location = new System.Drawing.Point(370, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 35);
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.PaleGreen;
            this.btnEnter.Location = new System.Drawing.Point(370, 70);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(120, 35);
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnRing
            // 
            this.btnRing.BackColor = System.Drawing.Color.LightCoral;
            this.btnRing.Location = new System.Drawing.Point(370, 115);
            this.btnRing.Name = "btnRing";
            this.btnRing.Size = new System.Drawing.Size(120, 35);
            this.btnRing.Text = "RING";
            this.btnRing.UseVisualStyleBackColor = false;
            this.btnRing.Click += new System.EventHandler(this.btnRing_Click);
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.lvLog);
            this.grpLog.Location = new System.Drawing.Point(15, 220);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(580, 180);
            this.grpLog.Text = "Login Log:";
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colTime, this.colGroup, this.colResult});
            this.lvLog.FullRowSelect = true;
            this.lvLog.GridLines = true;
            this.lvLog.Location = new System.Drawing.Point(15, 22);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(550, 145);
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // columns
            // 
            this.colTime.Text = "Ngày giờ";
            this.colTime.Width = 170;
            this.colGroup.Text = "Nhóm";
            this.colGroup.Width = 220;
            this.colResult.Text = "Kết quả";
            this.colResult.Width = 140;
            // 
            // add controls
            // 
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.grpKeyboard);
            this.Controls.Add(this.grpLog);
            this.grpKeyboard.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
