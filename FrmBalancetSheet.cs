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
            var saveStudent = new FrmSavePerson();

            if (person.FindAll().Rows.Count > 0)
            {
                new FrmPerson().ShowDialog();
                return;
            }

            saveStudent.ShowDialog();
            if (saveStudent.wasDataSaved)
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
    }
}