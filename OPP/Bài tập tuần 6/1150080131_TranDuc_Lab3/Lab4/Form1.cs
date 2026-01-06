using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitListView();
            LoadCategories(); // Tải danh mục vào ComboBox
        }

        private void InitListView()
        {
            lvProducts.View = View.Details;
            lvProducts.FullRowSelect = true;
            lvProducts.GridLines = true;
            lvProducts.Columns.Clear();
            lvProducts.Columns.Add("ProductID", 80);
            lvProducts.Columns.Add("ProductName", 200);
            lvProducts.Columns.Add("UnitPrice", 100);
            lvProducts.Columns.Add("Unit", 80);
        }

        private void LoadCategories()
        {
            cboCategory.Items.Clear();
            try
            {
                using (var conn = DatabaseConnection.OpenConnection())
                using (var cmd = new SqlCommand("SELECT CategoryName FROM dbo.Categories", conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        cboCategory.Items.Add(r["CategoryName"].ToString());
                    }
                }
                if (cboCategory.Items.Count > 0)
                    cboCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        // 1) Đếm số lượng sản phẩm
        private void btnCount_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseConnection.OpenConnection())
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Products", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    MessageBox.Show($"Tổng số sản phẩm: {count}", "Kết quả");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // 2) Xem chi tiết sản phẩm theo ID
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            string id = txtProductID.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng nhập ProductID!");
                return;
            }

            lvProducts.Items.Clear(); // Xóa các dòng cũ
            try
            {
                using (var conn = DatabaseConnection.OpenConnection())
                using (var cmd = new SqlCommand(
                    "SELECT ProductID, ProductName, UnitPrice, Unit, IsActive FROM dbo.Products WHERE ProductID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        var item = new ListViewItem(r["ProductID"].ToString());
                        item.SubItems.Add(r["ProductName"].ToString());
                        item.SubItems.Add(string.Format("{0:N0}", r["UnitPrice"]));
                        item.SubItems.Add(r["Unit"].ToString());
                        lvProducts.Items.Add(item);
                    }
                    else MessageBox.Show("Không tìm thấy sản phẩm này!");
                    r.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // 3) Liệt kê tất cả sản phẩm
        private void btnList_Click(object sender, EventArgs e)
        {
            lvProducts.Items.Clear();
            try
            {
                using (var conn = DatabaseConnection.OpenConnection())
                using (var cmd = new SqlCommand(
                    "SELECT ProductID, ProductName, UnitPrice, Unit FROM dbo.Products", conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var item = new ListViewItem(r["ProductID"].ToString());
                        item.SubItems.Add(r["ProductName"].ToString());
                        item.SubItems.Add(string.Format("{0:N0}", r["UnitPrice"]));
                        item.SubItems.Add(r["Unit"].ToString());
                        lvProducts.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // 4) Hiển thị sản phẩm theo tên danh mục
        private void btnListByCategory_Click(object sender, EventArgs e)
        {
            if (cboCategory.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục!");
                return;
            }
            string categoryName = cboCategory.SelectedItem.ToString();
            lvProducts.Items.Clear();
            try
            {
                using (var conn = DatabaseConnection.OpenConnection())
                using (var cmd = new SqlCommand(
                    "SELECT p.ProductID, p.ProductName, p.UnitPrice, p.Unit FROM dbo.Products p INNER JOIN dbo.Categories c ON p.CategoryID = c.CategoryID WHERE c.CategoryName = @name", conn))
                {
                    cmd.Parameters.AddWithValue("@name", categoryName);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var item = new ListViewItem(r["ProductID"].ToString());
                            item.SubItems.Add(r["ProductName"].ToString());
                            item.SubItems.Add(string.Format("{0:N0}", r["UnitPrice"]));
                            item.SubItems.Add(r["Unit"].ToString());
                            lvProducts.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
