namespace Lab4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNhapID;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnXemChiTiet;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.ListView lvProducts;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnListByCategory;
        private System.Windows.Forms.Label lblCategoryName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNhapID = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.lvProducts = new System.Windows.Forms.ListView();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.btnListByCategory = new System.Windows.Forms.Button();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTitle.Location = new System.Drawing.Point(90, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 25);
            this.lblTitle.Text = "THỰC HÀNH 2 – TRUY VẤN DỮ LIỆU";
            // 
            // lblNhapID
            // 
            this.lblNhapID.AutoSize = true;
            this.lblNhapID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhapID.Location = new System.Drawing.Point(26, 64);
            this.lblNhapID.Name = "lblNhapID";
            this.lblNhapID.Size = new System.Drawing.Size(114, 19);
            this.lblNhapID.Text = "Nhập ProductID:";
            // 
            // txtProductID
            // 
            this.txtProductID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProductID.Location = new System.Drawing.Point(146, 61);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(100, 25);
            // 
            // btnCount
            // 
            this.btnCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCount.Location = new System.Drawing.Point(26, 103);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(180, 35);
            this.btnCount.Text = "Đếm số lượng sản phẩm";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnXemChiTiet.Location = new System.Drawing.Point(222, 103);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(180, 35);
            this.btnXemChiTiet.Text = "Xem chi tiết sản phẩm";
            this.btnXemChiTiet.UseVisualStyleBackColor = true;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnList.Location = new System.Drawing.Point(418, 103);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(180, 35);
            this.btnList.Text = "Xem danh sách sản phẩm";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // lvProducts
            // 
            this.lvProducts.HideSelection = false;
            this.lvProducts.Location = new System.Drawing.Point(26, 156);
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.Size = new System.Drawing.Size(572, 260);
            this.lvProducts.TabIndex = 0;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            // 
            // cboCategory
            // 
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategory.Location = new System.Drawing.Point(390, 61);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(120, 25);
            // 
            // btnListByCategory
            // 
            this.btnListByCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnListByCategory.Location = new System.Drawing.Point(418, 400);
            this.btnListByCategory.Name = "btnListByCategory";
            this.btnListByCategory.Size = new System.Drawing.Size(180, 35);
            this.btnListByCategory.Text = "Xem sản phẩm theo danh mục";
            this.btnListByCategory.UseVisualStyleBackColor = true;
            this.btnListByCategory.Click += new System.EventHandler(this.btnListByCategory_Click);
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCategoryName.Location = new System.Drawing.Point(270, 64);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(120, 19);
            this.lblCategoryName.Text = "Chọn danh mục:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.btnListByCategory);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.lvProducts);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnXemChiTiet);
            this.Controls.Add(this.btnCount);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.lblNhapID);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "Thực hành 2 – Truy vấn dữ liệu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
