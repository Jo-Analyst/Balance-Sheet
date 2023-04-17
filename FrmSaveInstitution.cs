using Balance_Sheet.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            txtDistrito.Text = Settings.Default["district"].ToString();
            mkbCEP.Text = Settings.Default["cep"].ToString();
            txtState.Text = Settings.Default["state"].ToString();
            mtbPhone.Text = Settings.Default["phone"].ToString();
            txtEmail.Text = Settings.Default["email"].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default["name"] = txtName.Text;
            Settings.Default["address"] = txtAddress.Text;
            Settings.Default["number"] = int.Parse(nupNumber.Value.ToString());
            Settings.Default["district"] = txtDistrito.Text;
            Settings.Default["cep"] = mkbCEP.Text;
            Settings.Default["state"] = txtState.Text;
            Settings.Default["phone"] = mtbPhone.Text;
            Settings.Default["email"] = txtEmail.Text;
            Settings.Default.Save();
            this.Close();
        }
    }
}
