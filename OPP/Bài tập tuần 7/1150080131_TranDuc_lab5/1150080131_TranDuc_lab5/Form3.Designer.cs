namespace _1150080131_TranDuc_lab5
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpTop;
        private System.Windows.Forms.Label lblChonLop;
        private System.Windows.Forms.ComboBox cboLop;

        private System.Windows.Forms.GroupBox grpLeft;
        private System.Windows.Forms.DataGridView dgvSV;

        private System.Windows.Forms.GroupBox grpRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenSV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQueQuan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Button btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.lblChonLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.grpLeft = new System.Windows.Forms.GroupBox();
            this.dgvSV = new System.Windows.Forms.DataGridView();
            this.grpRight = new System.Windows.Forms.GroupBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQueQuan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenSV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpTop.SuspendLayout();
            this.grpLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSV)).BeginInit();
            this.grpRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTop
            // 
            this.grpTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTop.Controls.Add(this.cboLop);
            this.grpTop.Controls.Add(this.lblChonLop);
            this.grpTop.Location = new System.Drawing.Point(12, 12);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(1160, 60);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // lblChonLop
            // 
            this.lblChonLop.AutoSize = true;
            this.lblChonLop.Location = new System.Drawing.Point(20, 25);
            this.lblChonLop.Text = "Chọn mã lớp:";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.Location = new System.Drawing.Point(110, 21);
            this.cboLop.Size = new System.Drawing.Size(220, 24);
            this.cboLop.SelectionChangeCommitted += new System.EventHandler(this.cboLop_SelectionChangeCommitted);
            // 
            // grpLeft
            // 
            this.grpLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grpLeft.Controls.Add(this.dgvSV);
            this.grpLeft.Location = new System.Drawing.Point(12, 78);
            this.grpLeft.Name = "grpLeft";
            this.grpLeft.Size = new System.Drawing.Size(620, 540);
            this.grpLeft.TabIndex = 1;
            this.grpLeft.TabStop = false;
            this.grpLeft.Text = "Danh sách sinh viên:";
            // 
            // dgvSV
            // 
            this.dgvSV.AllowUserToAddRows = false;
            this.dgvSV.AllowUserToDeleteRows = false;
            this.dgvSV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSV.ReadOnly = true;
            this.dgvSV.RowHeadersVisible = false;
            this.dgvSV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSV_CellClick);
            // 
            // grpRight
            // 
            this.grpRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRight.Controls.Add(this.btnSua);
            this.grpRight.Controls.Add(this.txtMaLop);
            this.grpRight.Controls.Add(this.label6);
            this.grpRight.Controls.Add(this.txtQueQuan);
            this.grpRight.Controls.Add(this.label5);
            this.grpRight.Controls.Add(this.dtNgaySinh);
            this.grpRight.Controls.Add(this.label4);
            this.grpRight.Controls.Add(this.cboGioiTinh);
            this.grpRight.Controls.Add(this.label3);
            this.grpRight.Controls.Add(this.txtTenSV);
            this.grpRight.Controls.Add(this.label2);
            this.grpRight.Controls.Add(this.txtMaSV);
            this.grpRight.Controls.Add(this.label1);
            this.grpRight.Location = new System.Drawing.Point(638, 78);
            this.grpRight.Name = "grpRight";
            this.grpRight.Size = new System.Drawing.Size(534, 540);
            this.grpRight.TabIndex = 2;
            this.grpRight.TabStop = false;
            this.grpRight.Text = "Thông tin sinh viên:";
            // 
            // label1..btnSua
            // 
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(30, 45); this.label1.Text = "Mã SV:";
            this.txtMaSV.Location = new System.Drawing.Point(140, 42); this.txtMaSV.Size = new System.Drawing.Size(180, 22);

            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(30, 85); this.label2.Text = "Tên SV:";
            this.txtTenSV.Location = new System.Drawing.Point(140, 82); this.txtTenSV.Size = new System.Drawing.Size(360, 22);

            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(30, 125); this.label3.Text = "Giới tính:";
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            this.cboGioiTinh.Location = new System.Drawing.Point(140, 122); this.cboGioiTinh.Size = new System.Drawing.Size(180, 24);

            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(30, 165); this.label4.Text = "Ngày sinh:";
            this.dtNgaySinh.Location = new System.Drawing.Point(140, 162); this.dtNgaySinh.Size = new System.Drawing.Size(180, 22);

            this.label5.AutoSize = true; this.label5.Location = new System.Drawing.Point(30, 205); this.label5.Text = "Quê quán:";
            this.txtQueQuan.Location = new System.Drawing.Point(140, 202); this.txtQueQuan.Size = new System.Drawing.Size(360, 22);

            this.label6.AutoSize = true; this.label6.Location = new System.Drawing.Point(30, 245); this.label6.Text = "Mã lớp:";
            this.txtMaLop.Location = new System.Drawing.Point(140, 242); this.txtMaLop.Size = new System.Drawing.Size(180, 22);

            this.btnSua.Location = new System.Drawing.Point(33, 300);
            this.btnSua.Size = new System.Drawing.Size(467, 40);
            this.btnSua.Text = "Sửa thông tin (Parameter)";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1184, 641);
            this.Controls.Add(this.grpRight);
            this.Controls.Add(this.grpLeft);
            this.Controls.Add(this.grpTop);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Áp dụng 2: Sửa dữ liệu có dùng Parameter";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            this.grpLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSV)).EndInit();
            this.grpRight.ResumeLayout(false);
            this.grpRight.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
