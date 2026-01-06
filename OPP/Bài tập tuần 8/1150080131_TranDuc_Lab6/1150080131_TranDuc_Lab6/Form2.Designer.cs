namespace _1150080131_TranDuc_Lab6
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lsvDanhSach;
        private System.Windows.Forms.ColumnHeader colMa;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colDiaChi;

        private System.Windows.Forms.GroupBox grpNhap;
        private System.Windows.Forms.TextBox txtNXB;
        private System.Windows.Forms.TextBox txtTenNXB;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblNXB;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblDiaChi;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoaTrang;

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
            this.grpNhap = new System.Windows.Forms.GroupBox();
            this.lblNXB = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtNXB = new System.Windows.Forms.TextBox();
            this.txtTenNXB = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoaTrang = new System.Windows.Forms.Button();
            this.grpNhap.SuspendLayout();
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
            this.lsvDanhSach.Size = new System.Drawing.Size(860, 280);
            this.lsvDanhSach.TabIndex = 0;
            this.lsvDanhSach.UseCompatibleStateImageBehavior = false;
            this.lsvDanhSach.View = System.Windows.Forms.View.Details;
            this.lsvDanhSach.FullRowSelect = true;
            this.lsvDanhSach.GridLines = true;
            this.lsvDanhSach.SelectedIndexChanged += new System.EventHandler(this.lsvDanhSach_SelectedIndexChanged);
            // 
            // colMa
            // 
            this.colMa.Text = "Mã NXB";
            this.colMa.Width = 120;
            // 
            // colTen
            // 
            this.colTen.Text = "Tên NXB";
            this.colTen.Width = 280;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Text = "Địa chỉ";
            this.colDiaChi.Width = 440;
            // 
            // grpNhap
            // 
            this.grpNhap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNhap.Controls.Add(this.txtDiaChi);
            this.grpNhap.Controls.Add(this.txtTenNXB);
            this.grpNhap.Controls.Add(this.txtNXB);
            this.grpNhap.Controls.Add(this.lblDiaChi);
            this.grpNhap.Controls.Add(this.lblTen);
            this.grpNhap.Controls.Add(this.lblNXB);
            this.grpNhap.Location = new System.Drawing.Point(12, 310);
            this.grpNhap.Name = "grpNhap";
            this.grpNhap.Size = new System.Drawing.Size(860, 150);
            this.grpNhap.TabIndex = 1;
            this.grpNhap.TabStop = false;
            this.grpNhap.Text = "Thêm / Xem chi tiết";
            // 
            // labels
            // 
            this.lblNXB.AutoSize = true; this.lblNXB.Location = new System.Drawing.Point(18, 28);
            this.lblNXB.Text = "Mã NXB (*)";
            this.lblTen.AutoSize = true; this.lblTen.Location = new System.Drawing.Point(18, 61);
            this.lblTen.Text = "Tên NXB (*)";
            this.lblDiaChi.AutoSize = true; this.lblDiaChi.Location = new System.Drawing.Point(18, 94);
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // txtNXB
            // 
            this.txtNXB.Location = new System.Drawing.Point(110, 25);
            this.txtNXB.MaxLength = 10;
            this.txtNXB.Size = new System.Drawing.Size(200, 23);
            // 
            // txtTenNXB
            // 
            this.txtTenNXB.Location = new System.Drawing.Point(110, 58);
            this.txtTenNXB.MaxLength = 100;
            this.txtTenNXB.Size = new System.Drawing.Size(720, 23);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(110, 91);
            this.txtDiaChi.MaxLength = 500;
            this.txtDiaChi.Size = new System.Drawing.Size(720, 23);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnThem.Location = new System.Drawing.Point(586, 470);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 30);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLamMoi.Location = new System.Drawing.Point(684, 470);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 30);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoaTrang
            // 
            this.btnXoaTrang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnXoaTrang.Location = new System.Drawing.Point(782, 470);
            this.btnXoaTrang.Name = "btnXoaTrang";
            this.btnXoaTrang.Size = new System.Drawing.Size(90, 30);
            this.btnXoaTrang.TabIndex = 4;
            this.btnXoaTrang.Text = "Xóa trắng";
            this.btnXoaTrang.UseVisualStyleBackColor = true;
            this.btnXoaTrang.Click += new System.EventHandler(this.btnXoaTrang_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.btnXoaTrang);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grpNhap);
            this.Controls.Add(this.lsvDanhSach);
            this.MinimumSize = new System.Drawing.Size(760, 480);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách & Thêm NXB";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpNhap.ResumeLayout(false);
            this.grpNhap.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
