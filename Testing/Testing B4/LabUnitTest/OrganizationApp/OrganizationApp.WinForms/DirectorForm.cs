using System;
using System.Windows.Forms;

namespace OrganizationApp.WinForms
{
    public partial class DirectorForm : Form
    {
        private readonly int _orgId;

        public DirectorForm(int orgId)
        {
            InitializeComponent();
            _orgId = orgId;
        }

        private void DirectorForm_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "Organization ID: " + _orgId;
        }
    }
}
