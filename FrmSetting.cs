using Balance_Sheet.Properties;
using System;
using System.Windows.Forms;

namespace Balance_Sheet
{
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();

            cbPrint.Checked = bool.Parse(Settings.Default["print_directory_direct"].ToString());
            txtDirectoryBackup.Text = Settings.Default["path_Backup"].ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Settings.Default["print_directory_direct"] = cbPrint.Checked;
            Settings.Default["path_Backup"] = txtDirectoryBackup.Text;
            Settings.Default.Save();
            this.Close();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog.ShowDialog())
            {
                txtDirectoryBackup.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            txtDirectoryBackup.Focus();
        }

        private void FrmSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
                btnConfirm_Click((object)sender, e);

            if (e.Control && e.KeyCode == Keys.O)
                btnSelectFolder_Click((object)sender, e);
        }

        private void lkSalveInstituition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmSaveInstitution().ShowDialog();
        }
    }
}
