namespace ThucHanh2
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
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.ErrorProvider err;

        private System.Windows.Forms.GroupBox grpDichVu;
        private System.Windows.Forms.CheckBox chkCaoRang;
        private System.Windows.Forms.CheckBox chkTayTrang;
        private System.Windows.Forms.CheckBox chkHanRang;
        private System.Windows.Forms.CheckBox chkBeRang;
        private System.Windows.Forms.CheckBox chkBocRang;
        private System.Windows.Forms.Label lblGiaCaoRang;
        private System.Windows.Forms.Label lblGiaTayTrang;
        private System.Windows.Forms.Label lblGiaHanRang;
        private System.Windows.Forms.Label lblGiaBeRang;
        private System.Windows.Forms.Label lblGiaBocRang;
        private System.Windows.Forms.NumericUpDown nudHan;
        private System.Windows.Forms.NumericUpDown nudBe;
        private System.Windows.Forms.NumericUpDown nudBoc;

        private System.Windows.Forms.GroupBox grpChucNang;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.TextBox txtTong;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);

            this.grpDichVu = new System.Windows.Forms.GroupBox();
            this.chkCaoRang = new System.Windows.Forms.CheckBox();
            this.chkTayTrang = new System.Windows.Forms.CheckBox();
            this.chkHanRang = new System.Windows.Forms.CheckBox();
            this.chkBeRang = new System.Windows.Forms.CheckBox();
            this.chkBocRang = new System.Windows.Forms.CheckBox();
            this.lblGiaCaoRang = new System.Windows.Forms.Label();
            this.lblGiaTayTrang = new System.Windows.Forms.Label();
            this.lblGiaHanRang = new System.Windows.Forms.Label();
            this.lblGiaBeRang = new System.Windows.Forms.Label();
            this.lblGiaBocRang = new System.Windows.Forms.Label();
            this.nudHan = new System.Windows.Forms.NumericUpDown();
            this.nudBe = new System.Windows.Forms.NumericUpDown();
            this.nudBoc = new System.Windows.Forms.NumericUpDown();

            this.grpChucNang = new System.Windows.Forms.GroupBox();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTong = new System.Windows.Forms.Label();
            this.txtTong = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.grpDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoc)).BeginInit();
            this.grpChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHÒNG KHÁM NHA KHOA HẢI ÂU";
            this.AcceptButton = this.btnTinhTien;
            this.CancelButton = this.btnThoat;
            // 
            // Title
            // 
            this.lblTitle.BackColor = System.Drawing.Color.LimeGreen;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Text = "PHÒNG KHÁM NHA KHOA HẢI ÂU";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(640, 50);
            // 
            // Ten
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(18, 65);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(88, 15);
            this.lblTen.Text = "Tên khách hàng:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(120, 62);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(490, 23);
            this.txtTen.TabIndex = 0;
            this.txtTen.Validating += new System.ComponentModel.CancelEventHandler(this.txtTen_Validating);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // grpDichVu
            // 
            this.grpDichVu.Text = "Dịch vụ tại phòng khám:";
            this.grpDichVu.Location = new System.Drawing.Point(20, 100);
            this.grpDichVu.Size = new System.Drawing.Size(600, 160);
            this.grpDichVu.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.chkCaoRang, this.chkTayTrang, this.chkHanRang, this.chkBeRang, this.chkBocRang,
                this.lblGiaCaoRang, this.lblGiaTayTrang, this.lblGiaHanRang, this.lblGiaBeRang, this.lblGiaBocRang,
                this.nudHan, this.nudBe, this.nudBoc
            });
            // 
            // Checkboxes
            // 
            this.chkCaoRang.Location = new System.Drawing.Point(20, 30);
            this.chkCaoRang.Text = "Lấy cao răng";
            this.chkTayTrang.Location = new System.Drawing.Point(20, 55);
            this.chkTayTrang.Text = "Tẩy trắng răng";
            this.chkHanRang.Location = new System.Drawing.Point(20, 80);
            this.chkHanRang.Text = "Hàn răng";
            this.chkBeRang.Location = new System.Drawing.Point(20, 105);
            this.chkBeRang.Text = "Bẻ răng";
            this.chkBocRang.Location = new System.Drawing.Point(20, 130);
            this.chkBocRang.Text = "Bọc răng";

            this.chkHanRang.CheckedChanged += new System.EventHandler(this.chkTheoRang_CheckedChanged);
            this.chkBeRang.CheckedChanged += new System.EventHandler(this.chkTheoRang_CheckedChanged);
            this.chkBocRang.CheckedChanged += new System.EventHandler(this.chkTheoRang_CheckedChanged);
            // 
            // Labels giá
            // 
            this.lblGiaCaoRang.Location = new System.Drawing.Point(200, 30);
            this.lblGiaCaoRang.AutoSize = true;
            this.lblGiaCaoRang.Text = "50.000đ";
            this.lblGiaTayTrang.Location = new System.Drawing.Point(200, 55);
            this.lblGiaTayTrang.AutoSize = true;
            this.lblGiaTayTrang.Text = "100.000đ";
            this.lblGiaHanRang.Location = new System.Drawing.Point(200, 80);
            this.lblGiaHanRang.AutoSize = true;
            this.lblGiaHanRang.Text = "100.000đ / 1 răng";
            this.lblGiaBeRang.Location = new System.Drawing.Point(200, 105);
            this.lblGiaBeRang.AutoSize = true;
            this.lblGiaBeRang.Text = "10.000đ / 1 răng";
            this.lblGiaBocRang.Location = new System.Drawing.Point(200, 130);
            this.lblGiaBocRang.AutoSize = true;
            this.lblGiaBocRang.Text = "1.000.000đ / 1 răng";
            // 
            // NumericUpDown
            // 
            this.nudHan.Location = new System.Drawing.Point(520, 78);
            this.nudBe.Location = new System.Drawing.Point(520, 103);
            this.nudBoc.Location = new System.Drawing.Point(520, 128);
            this.nudHan.Size = this.nudBe.Size = this.nudBoc.Size = new System.Drawing.Size(60, 23);
            this.nudHan.Minimum = this.nudBe.Minimum = this.nudBoc.Minimum = 0;
            this.nudHan.Maximum = this.nudBe.Maximum = this.nudBoc.Maximum = 32;
            this.nudHan.Enabled = this.nudBe.Enabled = this.nudBoc.Enabled = false; // chỉ bật khi tick
            // 
            // grpChucNang
            // 
            this.grpChucNang.Text = "Chức năng:";
            this.grpChucNang.Location = new System.Drawing.Point(20, 270);
            this.grpChucNang.Size = new System.Drawing.Size(600, 70);
            // 
            // lblTong & txtTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Location = new System.Drawing.Point(20, 300);
            this.lblTong.Text = "Tổng tiền:";
            this.txtTong.Location = new System.Drawing.Point(85, 297);
            this.txtTong.ReadOnly = true;
            this.txtTong.Size = new System.Drawing.Size(250, 23);
            // 
            // Buttons
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(360, 295);
            this.btnTinhTien.Size = new System.Drawing.Size(100, 28);
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);

            this.btnThoat.Location = new System.Drawing.Point(480, 295);
            this.btnThoat.Size = new System.Drawing.Size(100, 28);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // Add controls to form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.grpDichVu);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.txtTong);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.btnThoat);

            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.grpDichVu.ResumeLayout(false);
            this.grpDichVu.PerformLayout();
            this.grpChucNang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
