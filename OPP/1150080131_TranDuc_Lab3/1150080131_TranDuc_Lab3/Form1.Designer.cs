namespace _1150080131_TranDuc_Lab3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.FlowLayoutPanel pnlMenu;

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblChooseTable;
        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.Button btnOrder;

        private System.Windows.Forms.DataGridView dgv;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();

            this.pnlMenu = new System.Windows.Forms.FlowLayoutPanel();

            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblChooseTable = new System.Windows.Forms.Label();
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.btnOrder = new System.Windows.Forms.Button();

            this.dgv = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlHeader.Size = new System.Drawing.Size(860, 70);
            this.pnlHeader.TabIndex = 0;

            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Location = new System.Drawing.Point(12, 8);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(80, 54);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;

            // (tuỳ ý gán Image trong Designer sau)

            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.SeaGreen;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(92, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.lblTitle.Size = new System.Drawing.Size(756, 54);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Quán ăn nhanh Hưng Thịnh";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 70);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(8);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(12);
            this.pnlMenu.Size = new System.Drawing.Size(860, 210);
            this.pnlMenu.TabIndex = 1;
            this.pnlMenu.WrapContents = true;
            this.pnlMenu.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;

            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.btnDelete);
            this.pnlToolbar.Controls.Add(this.lblChooseTable);
            this.pnlToolbar.Controls.Add(this.cboTable);
            this.pnlToolbar.Controls.Add(this.btnOrder);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 280);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.pnlToolbar.Size = new System.Drawing.Size(860, 48);
            this.pnlToolbar.TabIndex = 2;

            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // lblChooseTable
            // 
            this.lblChooseTable.AutoSize = true;
            this.lblChooseTable.Location = new System.Drawing.Point(120, 15);
            this.lblChooseTable.Name = "lblChooseTable";
            this.lblChooseTable.Size = new System.Drawing.Size(63, 15);
            this.lblChooseTable.TabIndex = 1;
            this.lblChooseTable.Text = "Chọn bàn:";

            // 
            // cboTable
            // 
            this.cboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTable.FormattingEnabled = true;
            this.cboTable.Location = new System.Drawing.Point(189, 11);
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size(180, 23);
            this.cboTable.TabIndex = 2;

            // 
            // btnOrder
            // 
            this.btnOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder.Location = new System.Drawing.Point(758, 9);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(90, 30);
            this.btnOrder.TabIndex = 3;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);

            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 328);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(860, 272);
            this.dgv.TabIndex = 3;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 600);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDA Order – Quán ăn nhanh Hưng Thịnh";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
