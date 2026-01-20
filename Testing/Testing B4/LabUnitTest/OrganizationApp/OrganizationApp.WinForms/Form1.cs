using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OrganizationApp.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; // gắn sự kiện load
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(Db.ConnectionString))
                {
                    conn.Open();
                    MessageBox.Show("Connected to SQL Server successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message);
            }
        }
    }
}
