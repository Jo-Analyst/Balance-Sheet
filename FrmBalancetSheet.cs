using DataBase;
using System;
using System.Windows.Forms;

namespace Possible_Benefits
{
    public partial class FrmBalanceSheet : Form
    {
        public FrmBalanceSheet()
        {
            InitializeComponent();
        }

        Person person = new Person();

        private void btnPerson_Click(object sender, EventArgs e)
        {
            var savePerson = new FrmSavePerson();

            if (person.FindAll().Rows.Count > 0)
            {
                new FrmPerson().ShowDialog();
                return;
            }

            savePerson.ShowDialog();
            if (savePerson.wasDataSaved)
            {
                new FrmPerson().ShowDialog();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            new FrmReportBalancete().ShowDialog();
        }

        private void btnBackupAndRestore_Click(object sender, EventArgs e)
        {
            new FrmBackupAndRestore().ShowDialog();
        }

        private void FrmBalanceSheet_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            new FrmSetting().ShowDialog();
        }

        private void FrmBalanceSheet_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.C)
            {
                btnPerson_Click(sender, e);
            }
            else if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.R)
                btnReport_Click(sender, e);
            else if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.B)
                btnBackupAndRestore_Click(sender, e);
            else if (e.Control && e.Shift && e.KeyCode == Keys.C)
                btnSetting_Click(sender, e);
        }
    }
}