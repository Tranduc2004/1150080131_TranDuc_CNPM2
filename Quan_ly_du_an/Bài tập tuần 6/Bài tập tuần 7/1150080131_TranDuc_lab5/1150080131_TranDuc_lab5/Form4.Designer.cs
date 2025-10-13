namespace _1150080131_TranDuc_lab5
{
    partial class Form4
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
        private System.Windows.Forms.Button btnXoa;

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
            this.btnXoa = new System.Windows.Forms.Button();
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
            this.grpLeft.Size = new System.Drawing.Size(760, 540);
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
            this.grpRight.Controls.Add(this.btnXoa);
            this.grpRight.Controls.Add(this.txtMaSV);
            this.grpRight.Controls.Add(this.label1);
            this.grpRight.Location = new System.Drawing.Point(778, 78);
            this.grpRight.Name = "grpRight";
            this.grpRight.Size = new System.Drawing.Size(394, 540);
            this.grpRight.TabIndex = 2;
            this.grpRight.TabStop = false;
            this.grpRight.Text = "Xóa sinh viên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 48);
            this.label1.Text = "Mã SV cần xóa:";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(120, 45);
            this.txtMaSV.ReadOnly = true;
            this.txtMaSV.Size = new System.Drawing.Size(240, 22);
            // 
            // btnXoa
            // 
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(29, 95);
            this.btnXoa.Size = new System.Drawing.Size(331, 40);
            this.btnXoa.Text = "Xóa sinh viên (Không dùng Parameter)";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1184, 641);
            this.Controls.Add(this.grpRight);
            this.Controls.Add(this.grpLeft);
            this.Controls.Add(this.grpTop);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thực hành 4: Xóa dữ liệu không dùng Parameter";
            this.Load += new System.EventHandler(this.Form4_Load);
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
