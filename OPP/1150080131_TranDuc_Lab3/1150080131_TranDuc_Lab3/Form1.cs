using System;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace _1150080131_TranDuc_Lab3
{
    public partial class Form1 : Form
    {
        private DataTable orderTable;
        private readonly string[] MENU = {
            "Cơm chiên trứng","Bánh mì ốp la","Coca","Lipton",
            "Ốc rang muối","Khoai tây chiên","7 up","Cam",
            "Mỳ xào hải sản","Cá viên chiên","Pepsi","Cafe",
            "Buger bò nướng","Đùi gà rán","Bún bò Huế"
        };

        public Form1() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Bàn
            cboTable.Items.AddRange(Enumerable.Range(1, 20).Select(i => $"Bàn {i}").ToArray());
            cboTable.SelectedIndex = 0;

            // Grid
            orderTable = new DataTable();
            orderTable.Columns.Add("Món", typeof(string));
            orderTable.Columns.Add("Số lượng", typeof(int));
            dgv.DataSource = orderTable;

            // Sinh nút món
            foreach (var name in MENU)
            {
                var b = new Button { Text = name, Width = 180, Height = 36, Margin = new Padding(8) };
                b.Click += (s, _) => AddOrIncrease(name);
                pnlMenu.Controls.Add(b);
            }
        }

        private void AddOrIncrease(string name)
        {
            foreach (DataRow r in orderTable.Rows)
                if ((string)r["Món"] == name) { r["Số lượng"] = (int)r["Số lượng"] + 1; return; }
            orderTable.Rows.Add(name, 1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow != null)
                dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (orderTable.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có món nào!"); return;
            }
            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Orders");
            Directory.CreateDirectory(dir);
            var fname = $"{cboTable.SelectedItem}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            var path = Path.Combine(dir, fname);
            var sb = new StringBuilder();
            sb.AppendLine($"BÀN: {cboTable.SelectedItem}");
            sb.AppendLine($"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine(new string('-', 40));
            foreach (DataRow r in orderTable.Rows)
                sb.AppendLine($"{r["Món"]} x {r["Số lượng"]}");
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
            MessageBox.Show($"Đã ghi file:\n{path}");
            orderTable.Clear();
        }
    }
}
