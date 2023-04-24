using Balance_Sheet.Properties;
using System;
using System.Windows.Forms;

namespace Balance_Sheet
{
    public partial class FrmSaveInstitution : Form
    {
        public FrmSaveInstitution()
        {
            InitializeComponent();
        }

        private void FrmSaveInstitution_Load(object sender, EventArgs e)
        {
            txtName.Text = Settings.Default["name"].ToString();
            txtAddress.Text = Settings.Default["address"].ToString();
            nupNumber.Value = decimal.Parse(Settings.Default["number"].ToString());
            txtDistrict.Text = Settings.Default["district"].ToString();
            txtCity.Text = Settings.Default["city"].ToString();
            mkbCEP.Text = Settings.Default["cep"].ToString();
            txtState.Text = Settings.Default["state"].ToString();
            mtbPhone.Text = Settings.Default["phone"].ToString();
            txtEmail.Text = Settings.Default["email"].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FieldValidate())
                return;

            Settings.Default["name"] = txtName.Text;
            Settings.Default["address"] = txtAddress.Text;
            Settings.Default["number"] = int.Parse(nupNumber.Value.ToString());
            Settings.Default["district"] = txtDistrict.Text;
            Settings.Default["city"] = txtCity.Text;
            Settings.Default["cep"] = mkbCEP.Text;
            Settings.Default["state"] = txtState.Text;
            Settings.Default["phone"] = mtbPhone.Text;
            Settings.Default["email"] = txtEmail.Text;
            Settings.Default.Save();
            this.Close();
        }

        private bool FieldValidate()
        {
            bool fieldValidate = true;
            try
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox)
                    {
                        if (control.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show($"Digite o campo '{GetFieldName(control.Name)}'", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            fieldValidate = false;
                            break;
                        }
                    }
                    else if (control is MaskedTextBox maskedTextBox)
                    {
                        if (!maskedTextBox.MaskCompleted)
                        {
                            MessageBox.Show($"Digite o campo {GetFieldName(control.Name)}", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            fieldValidate = false;
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return fieldValidate;
        }

        private string GetFieldName(string name)
        {
            string textFieldControls = "";

            if (name.ToLower() == "txtname")
                textFieldControls = lblName.Text;
            else if (name.ToLower() == "mtbphone")
                textFieldControls = lblPhone.Text;
            else if (name.ToLower() == "mkbcep")
                textFieldControls = lblCEP.Text;
            else if (name.ToLower() == "txtaddress")
                textFieldControls = lbladdress.Text;
            else if (name.ToLower() == "txtdistrict")
                textFieldControls = lblDistrict.Text;
            else if (name.ToLower() == "txtcity")
                textFieldControls = lblCity.Text;
            else if (name.ToLower() == "txtstate")
                textFieldControls = lblState.Text;
            else if (name.ToLower() == "txtemail")
                textFieldControls = lblEmail.Text;

            return textFieldControls;
        }

        private void FrmSaveInstitution_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave_Click(sender, e);
        }
    }
}