using System;
using System.Windows.Forms;
using OrganizationApp.Core;

namespace OrganizationApp.WinForms
{
    public partial class OrganizationForm : Form
    {
        private int _savedOrgId = 0;

        public OrganizationForm()
        {
            InitializeComponent();

            btnDirector.Enabled = false;

            btnSave.Click += btnSave_Click;
            btnBack.Click += btnBack_Click;
            btnDirector.Click += btnDirector_Click;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            try
            {
                var org = new Organization
                {
                    OrgName = txtOrgName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text
                };

                var service = new OrganizationService(new OrganizationRepository());

                // Save trả về OrgID
                _savedOrgId = service.Save(org);

                MessageBox.Show("Save successfully");   // đúng đề
                btnDirector.Enabled = true;             // đúng đề
            }
            catch (ArgumentException ex)
            {
                // Mapping lỗi theo message (để hiện đúng từng field)
                // Bạn giữ message y như trong Service để map chuẩn.
                if (ex.Message.Contains("OrgName"))
                    errorProvider1.SetError(txtOrgName, ex.Message);

                else if (ex.Message.Contains("Email"))
                    errorProvider1.SetError(txtEmail, ex.Message);

                else if (ex.Message.Contains("Phone"))
                    errorProvider1.SetError(txtPhone, ex.Message);

                else if (ex.Message == "Organization Name already exists")
                    errorProvider1.SetError(txtOrgName, ex.Message);

                else
                    MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnDirector_Click(object sender, EventArgs e)
        {
            if (_savedOrgId <= 0)
            {
                MessageBox.Show("Please save Organization first.");
                return;
            }

            using (var f = new DirectorForm(_savedOrgId))
            {
                f.ShowDialog();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
