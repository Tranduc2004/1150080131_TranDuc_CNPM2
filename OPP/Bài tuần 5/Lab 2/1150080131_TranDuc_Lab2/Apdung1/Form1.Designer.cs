namespace ApDung1
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

        private System.Windows.Forms.GroupBox grpNhap;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;

        private System.Windows.Forms.GroupBox grpChon;
        private System.Windows.Forms.RadioButton radUSCLN; // ƯSCLN
        private System.Windows.Forms.RadioButton radBSCNN; // BSCNN

        private System.Windows.Forms.GroupBox grpKQ;
        private System.Windows.Forms.TextBox txtKetQua;

        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnThoat;

        private void InitializeComponent()
        {
            this.grpNhap = new System.Windows.Forms.GroupBox();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();

            this.grpChon = new System.Windows.Forms.GroupBox();
            this.radUSCLN = new System.Windows.Forms.RadioButton();
            this.radBSCNN = new System.Windows.Forms.RadioButton();

            this.grpKQ = new System.Windows.Forms.GroupBox();
            this.txtKetQua = new System.Windows.Forms.TextBox();

            this.btnTim = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();

            this.grpNhap.SuspendLayout();
            this.grpChon.SuspendLayout();
            this.grpKQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 260);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm ƯSCLN và BSCNN của a, b";
            this.AcceptButton = this.btnTim;     // Enter = Tìm
            this.CancelButton = this.btnThoat;   // Esc = Thoát
            // 
            // grpNhap
            // 
            this.grpNhap.Controls.Add(this.lblA);
            this.grpNhap.Controls.Add(this.txtA);
            this.grpNhap.Controls.Add(this.lblB);
            this.grpNhap.Controls.Add(this.txtB);
            this.grpNhap.Location = new System.Drawing.Point(15, 15);
            this.grpNhap.Name = "grpNhap";
            this.grpNhap.Size = new System.Drawing.Size(330, 100);
            this.grpNhap.TabIndex = 0;
            this.grpNhap.TabStop = false;
            this.grpNhap.Text = "Nhập dữ liệu";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(15, 28);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(76, 15);
            this.lblA.TabIndex = 0;
            this.lblA.Text = "Số nguyên a:";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(110, 25);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(200, 23);
            this.txtA.TabIndex = 1;
            this.txtA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress_Int);
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(15, 62);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(76, 15);
            this.lblB.TabIndex = 2;
            this.lblB.Text = "Số nguyên b:";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(110, 59);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(200, 23);
            this.txtB.TabIndex = 3;
            this.txtB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress_Int);
            // 
            // grpChon
            // 
            this.grpChon.Controls.Add(this.radUSCLN);
            this.grpChon.Controls.Add(this.radBSCNN);
            this.grpChon.Location = new System.Drawing.Point(360, 15);
            this.grpChon.Name = "grpChon";
            this.grpChon.Size = new System.Drawing.Size(180, 100);
            this.grpChon.TabIndex = 1;
            this.grpChon.TabStop = false;
            this.grpChon.Text = "Tùy chọn";
            // 
            // radUSCLN
            // 
            this.radUSCLN.AutoSize = true;
            this.radUSCLN.Location = new System.Drawing.Point(18, 30);
            this.radUSCLN.Name = "radUSCLN";
            this.radUSCLN.Size = new System.Drawing.Size(67, 19);
            this.radUSCLN.TabIndex = 0;
            this.radUSCLN.TabStop = true;
            this.radUSCLN.Text = "USCLN";
            this.radUSCLN.UseVisualStyleBackColor = true;
            // 
            // radBSCNN
            // 
            this.radBSCNN.AutoSize = true;
            this.radBSCNN.Location = new System.Drawing.Point(18, 60);
            this.radBSCNN.Name = "radBSCNN";
            this.radBSCNN.Size = new System.Drawing.Size(65, 19);
            this.radBSCNN.TabIndex = 1;
            this.radBSCNN.Text = "BSCNN";
            this.radBSCNN.UseVisualStyleBackColor = true;
            // 
            // grpKQ
            // 
            this.grpKQ.Controls.Add(this.txtKetQua);
            this.grpKQ.Location = new System.Drawing.Point(15, 125);
            this.grpKQ.Name = "grpKQ";
            this.grpKQ.Size = new System.Drawing.Size(330, 60);
            this.grpKQ.TabIndex = 2;
            this.grpKQ.TabStop = false;
            this.grpKQ.Text = "Kết quả";
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(18, 24);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.Size = new System.Drawing.Size(292, 23);
            this.txtKetQua.TabIndex = 0;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(375, 135);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(150, 30);
            this.btnTim.TabIndex = 3;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(375, 175);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(150, 30);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // add controls
            // 
            this.Controls.Add(this.grpNhap);
            this.Controls.Add(this.grpChon);
            this.Controls.Add(this.grpKQ);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnThoat);
            this.grpNhap.ResumeLayout(false);
            this.grpNhap.PerformLayout();
            this.grpChon.ResumeLayout(false);
            this.grpChon.PerformLayout();
            this.grpKQ.ResumeLayout(false);
            this.grpKQ.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
