namespace _1150080131_TranDuc_Lab6
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lsvDanhSach;
        private System.Windows.Forms.ColumnHeader colMa;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colDiaChi;

        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtMaNXB;
        private System.Windows.Forms.TextBox txtTenNXB;
        private System.Windows.Forms.TextBox txtDiaChi;

        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lsvDanhSach = new System.Windows.Forms.ListView();
            this.colMa = new System.Windows.Forms.ColumnHeader();
            this.colTen = new System.Windows.Forms.ColumnHeader();
            this.colDiaChi = new System.Windows.Forms.ColumnHeader();

            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtMaNXB = new System.Windows.Forms.TextBox();
            this.txtTenNXB = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();

            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();

            this.grpChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvDanhSach
            // 
            this.lsvDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvDanhSach.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colMa, this.colTen, this.colDiaChi});
            this.lsvDanhSach.Location = new System.Drawing.Point(12, 12);
            this.lsvDanhSach.MultiSelect = false;
            this.lsvDanhSach.Name = "lsvDanhSach";
            this.lsvDanhSach.Size = new System.Drawing.Size(820, 270);
            this.lsvDanhSach.TabIndex = 0;
            this.lsvDanhSach.UseCompatibleStateImageBehavior = false;
            this.lsvDanhSach.View = System.Windows.Forms.View.Details;
            this.lsvDanhSach.SelectedIndexChanged += new System.EventHandler(this.lsvDanhSach_SelectedIndexChanged);
            // 
            // column headers
            // 
            this.colMa.Text = "Mã NXB"; this.colMa.Width = 120;
            this.colTen.Text = "Tên NXB"; this.colTen.Width = 260;
            this.colDiaChi.Text = "Địa chỉ"; this.colDiaChi.Width = 420;
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpChiTiet.Controls.Add(this.txtDiaChi);
            this.grpChiTiet.Controls.Add(this.txtTenNXB);
            this.grpChiTiet.Controls.Add(this.txtMaNXB);
            this.grpChiTiet.Controls.Add(this.lblDiaChi);
            this.grpChiTiet.Controls.Add(this.lblTen);
            this.grpChiTiet.Controls.Add(this.lblMa);
            this.grpChiTiet.Location = new System.Drawing.Point(12, 298);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(820, 130);
            this.grpChiTiet.TabIndex = 1;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Chi tiết (dòng được chọn)";
            // 
            // labels
            // 
            this.lblMa.AutoSize = true; this.lblMa.Location = new System.Drawing.Point(18, 28); this.lblMa.Text = "Mã NXB";
            this.lblTen.AutoSize = true; this.lblTen.Location = new System.Drawing.Point(18, 58); this.lblTen.Text = "Tên NXB";
            this.lblDiaChi.AutoSize = true; this.lblDiaChi.Location = new System.Drawing.Point(18, 88); this.lblDiaChi.Text = "Địa chỉ";
            // 
            // textboxes
            // 
            this.txtMaNXB.Location = new System.Drawing.Point(90, 25); this.txtMaNXB.ReadOnly = true; this.txtMaNXB.Size = new System.Drawing.Size(180, 23);
            this.txtTenNXB.Location = new System.Drawing.Point(90, 55); this.txtTenNXB.ReadOnly = true; this.txtTenNXB.Size = new System.Drawing.Size(710, 23);
            this.txtDiaChi.Location = new System.Drawing.Point(90, 85); this.txtDiaChi.ReadOnly = true; this.txtDiaChi.Size = new System.Drawing.Size(710, 23);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnXoa.Location = new System.Drawing.Point(548, 436);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 30);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLamMoi.Location = new System.Drawing.Point(646, 436);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 30);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDong.Location = new System.Drawing.Point(744, 436);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 30);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(844, 478);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.lsvDanhSach);
            this.MinimumSize = new System.Drawing.Size(760, 480);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xóa Nhà Xuất Bản";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
