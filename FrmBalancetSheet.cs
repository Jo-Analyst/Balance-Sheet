using DataBase;
using System;
using System.Windows.Forms;

namespace Balance_Sheet
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
            //new FrmReport().ShowDialog();
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
    }
}