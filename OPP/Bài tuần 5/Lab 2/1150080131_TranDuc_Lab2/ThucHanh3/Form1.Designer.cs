namespace ThucHanh3
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
        private System.Windows.Forms.Label lblNhap;
        private System.Windows.Forms.TextBox txtSoNguyen;
        private System.Windows.Forms.Button btnNhapSo;
        private System.Windows.Forms.ListBox lsbDaySo;
        private System.Windows.Forms.GroupBox grpChucNang;
        private System.Windows.Forms.Button btnTang2;
        private System.Windows.Forms.Button btnChonChanDau;
        private System.Windows.Forms.Button btnChonLeCuoi;
        private System.Windows.Forms.Button btnXoaDangChon;
        private System.Windows.Forms.Button btnXoaDau;
        private System.Windows.Forms.Button btnXoaCuoi;
        private System.Windows.Forms.Button btnXoaDaySo;
        private System.Windows.Forms.Button btnKetThuc;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNhap = new System.Windows.Forms.Label();
            this.txtSoNguyen = new System.Windows.Forms.TextBox();
            this.btnNhapSo = new System.Windows.Forms.Button();
            this.lsbDaySo = new System.Windows.Forms.ListBox();
            this.grpChucNang = new System.Windows.Forms.GroupBox();
            this.btnTang2 = new System.Windows.Forms.Button();
            this.btnChonChanDau = new System.Windows.Forms.Button();
            this.btnChonLeCuoi = new System.Windows.Forms.Button();
            this.btnXoaDangChon = new System.Windows.Forms.Button();
            this.btnXoaDau = new System.Windows.Forms.Button();
            this.btnXoaCuoi = new System.Windows.Forms.Button();
            this.btnXoaDaySo = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();

            this.grpChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 430);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ứng dụng xử lý dãy số";
            this.AcceptButton = this.btnNhapSo;
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Ứng dụng xử lý dãy số";
            this.lblTitle.BackColor = System.Drawing.Color.Teal;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 56;
            // 
            // lblNhap
            // 
            this.lblNhap.AutoSize = true;
            this.lblNhap.Location = new System.Drawing.Point(18, 70);
            this.lblNhap.Text = "Nhập số nguyên:";
            // 
            // txtSoNguyen
            // 
            this.txtSoNguyen.Location = new System.Drawing.Point(130, 66);
            this.txtSoNguyen.Size = new System.Drawing.Size(220, 23);
            this.txtSoNguyen.TabIndex = 0;
            this.txtSoNguyen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoNguyen_KeyPress_IntOnly);
            this.txtSoNguyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoNguyen_KeyDown_EnterToAdd);
            // 
            // btnNhapSo
            // 
            this.btnNhapSo.Location = new System.Drawing.Point(360, 64);
            this.btnNhapSo.Size = new System.Drawing.Size(95, 27);
            this.btnNhapSo.Text = "Nhập số";
            this.btnNhapSo.Click += new System.EventHandler(this.btnNhapSo_Click);
            // 
            // lsbDaySo
            // 
            this.lsbDaySo.Location = new System.Drawing.Point(21, 105);
            this.lsbDaySo.Size = new System.Drawing.Size(300, 270);
            this.lsbDaySo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // grpChucNang
            // 
            this.grpChucNang.Text = "Chức năng:";
            this.grpChucNang.Location = new System.Drawing.Point(340, 105);
            this.grpChucNang.Size = new System.Drawing.Size(280, 270);
            this.grpChucNang.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnTang2, this.btnChonChanDau, this.btnChonLeCuoi,
                this.btnXoaDangChon, this.btnXoaDau, this.btnXoaCuoi, this.btnXoaDaySo
            });
            // 
            // Buttons in group
            // 
            int x = 20, w = 240, h = 32, y = 25, step = 36;
            this.btnTang2.SetBounds(x, y + 0 * step, w, h);
            this.btnChonChanDau.SetBounds(x, y + 1 * step, w, h);
            this.btnChonLeCuoi.SetBounds(x, y + 2 * step, w, h);
            this.btnXoaDangChon.SetBounds(x, y + 3 * step, w, h);
            this.btnXoaDau.SetBounds(x, y + 4 * step, w, h);
            this.btnXoaCuoi.SetBounds(x, y + 5 * step, w, h);
            this.btnXoaDaySo.SetBounds(x, y + 6 * step, w, h);

            this.btnTang2.Text = "Tăng mỗi phần tử lên 2";
            this.btnChonChanDau.Text = "Chọn số chẵn đầu";
            this.btnChonLeCuoi.Text = "Chọn số lẻ cuối";
            this.btnXoaDangChon.Text = "Xóa phần tử đang chọn";
            this.btnXoaDau.Text = "Xóa phần tử đầu";
            this.btnXoaCuoi.Text = "Xóa phần tử cuối";
            this.btnXoaDaySo.Text = "Xóa dãy số";

            this.btnTang2.Click += new System.EventHandler(this.btnTang2_Click);
            this.btnChonChanDau.Click += new System.EventHandler(this.btnChonChanDau_Click);
            this.btnChonLeCuoi.Click += new System.EventHandler(this.btnChonLeCuoi_Click);
            this.btnXoaDangChon.Click += new System.EventHandler(this.btnXoaDangChon_Click);
            this.btnXoaDau.Click += new System.EventHandler(this.btnXoaDau_Click);
            this.btnXoaCuoi.Click += new System.EventHandler(this.btnXoaCuoi_Click);
            this.btnXoaDaySo.Click += new System.EventHandler(this.btnXoaDaySo_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Text = "Kết thúc ứng dụng";
            this.btnKetThuc.BackColor = System.Drawing.Color.IndianRed;
            this.btnKetThuc.ForeColor = System.Drawing.Color.White;
            this.btnKetThuc.Location = new System.Drawing.Point(21, 385);
            this.btnKetThuc.Size = new System.Drawing.Size(600, 30);
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // add controls
            // 
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNhap);
            this.Controls.Add(this.txtSoNguyen);
            this.Controls.Add(this.btnNhapSo);
            this.Controls.Add(this.lsbDaySo);
            this.Controls.Add(this.grpChucNang);
            this.Controls.Add(this.btnKetThuc);
            this.grpChucNang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
