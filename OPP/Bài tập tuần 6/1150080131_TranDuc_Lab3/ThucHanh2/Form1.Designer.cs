namespace ThucHanh2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;

        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.ListView lvSinhVien;
        private System.Windows.Forms.ColumnHeader colHoTen;
        private System.Windows.Forms.ColumnHeader colNgaySinh;
        private System.Windows.Forms.ColumnHeader colLop;
        private System.Windows.Forms.ColumnHeader colDiaChi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblLop = new System.Windows.Forms.Label();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();

            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();

            this.grpList = new System.Windows.Forms.GroupBox();
            this.lvSinhVien = new System.Windows.Forms.ListView();
            this.colHoTen = new System.Windows.Forms.ColumnHeader();
            this.colNgaySinh = new System.Windows.Forms.ColumnHeader();
            this.colLop = new System.Windows.Forms.ColumnHeader();
            this.colDiaChi = new System.Windows.Forms.ColumnHeader();

            this.grpInfo.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.grpList.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Text = "DANH MỤC SINH VIÊN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Height = 50;

            // grpInfo
            this.grpInfo.Text = "Thông tin sinh viên:";
            this.grpInfo.Location = new System.Drawing.Point(12, 58);
            this.grpInfo.Size = new System.Drawing.Size(660, 110);

            // Họ tên
            this.lblHoTen.Text = "Họ tên:";
            this.lblHoTen.Location = new System.Drawing.Point(15, 30);
            this.txtHoTen.Location = new System.Drawing.Point(75, 27);
            this.txtHoTen.Size = new System.Drawing.Size(210, 23);

            // Lớp
            this.lblLop.Text = "Lớp:";
            this.lblLop.Location = new System.Drawing.Point(310, 30);
            this.txtLop.Location = new System.Drawing.Point(350, 27);
            this.txtLop.Size = new System.Drawing.Size(120, 23);

            // Ngày sinh
            this.lblNgaySinh.Text = "Ngày sinh:";
            this.lblNgaySinh.Location = new System.Drawing.Point(15, 70);
            this.dtpNgaySinh.Location = new System.Drawing.Point(75, 66);
            this.dtpNgaySinh.Size = new System.Drawing.Size(210, 23);
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";

            // Địa chỉ
            this.lblDiaChi.Text = "Địa chỉ:";
            this.lblDiaChi.Location = new System.Drawing.Point(310, 70);
            this.txtDiaChi.Location = new System.Drawing.Point(350, 66);
            this.txtDiaChi.Size = new System.Drawing.Size(290, 23);

            // add to grpInfo
            this.grpInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblHoTen, this.txtHoTen,
                this.lblLop, this.txtLop,
                this.lblNgaySinh, this.dtpNgaySinh,
                this.lblDiaChi, this.txtDiaChi
            });

            // grpActions
            this.grpActions.Text = "Chức năng:";
            this.grpActions.Location = new System.Drawing.Point(12, 174);
            this.grpActions.Size = new System.Drawing.Size(660, 60);

            // buttons
            this.btnThem.Text = "Thêm";
            this.btnThem.Location = new System.Drawing.Point(20, 22);
            this.btnThem.Size = new System.Drawing.Size(90, 28);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new System.Drawing.Point(130, 22);
            this.btnSua.Size = new System.Drawing.Size(90, 28);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(240, 22);
            this.btnXoa.Size = new System.Drawing.Size(90, 28);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnThoat.Text = "Thoát";
            this.btnThoat.Location = new System.Drawing.Point(560, 22);
            this.btnThoat.Size = new System.Drawing.Size(75, 28);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            this.grpActions.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnThem, this.btnSua, this.btnXoa, this.btnThoat
            });

            // grpList
            this.grpList.Text = "Thông tin chung sinh viên:";
            this.grpList.Location = new System.Drawing.Point(12, 240);
            this.grpList.Size = new System.Drawing.Size(660, 270);

            // ListView
            this.lvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSinhVien.FullRowSelect = true;
            this.lvSinhVien.GridLines = true;
            this.lvSinhVien.HideSelection = false;
            this.lvSinhVien.MultiSelect = false;
            this.lvSinhVien.View = System.Windows.Forms.View.Details;
            this.lvSinhVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colHoTen, this.colNgaySinh, this.colLop, this.colDiaChi
            });
            this.lvSinhVien.SelectedIndexChanged += new System.EventHandler(this.lvSinhVien_SelectedIndexChanged);

            this.colHoTen.Text = "Họ tên";
            this.colHoTen.Width = 170;
            this.colNgaySinh.Text = "Ngày sinh";
            this.colNgaySinh.Width = 110;
            this.colLop.Text = "Lớp";
            this.colLop.Width = 100;
            this.colDiaChi.Text = "Địa chỉ";
            this.colDiaChi.Width = 250;

            this.grpList.Controls.Add(this.lvSinhVien);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 521);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sinh viên";

            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpActions.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
    }
}
