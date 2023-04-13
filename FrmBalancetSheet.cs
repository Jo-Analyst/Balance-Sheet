using DataBase;
using System;
using System.Windows.Forms;

namespace CourseManagement
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
            if (person.FindAll().Rows.Count > 0)
            {
                new FrmPerson().ShowDialog();
                return;
            }

            var saveStudent = new FrmSavePerson();
            saveStudent.ShowDialog();
            if (saveStudent.studentWasSaved)
            {
                new FrmPerson().ShowDialog();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //new FrmReport().ShowDialog();
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            //Class @class = new Class();

            //if (@class.FindAll().Rows.Count > 0)
            //{
            //    new FrmClass().ShowDialog();
            //    return;
            //}

            //var saveClass = new FrmSaveClass();
            //saveClass.ShowDialog();
            //if (saveClass.classWasSaved)
            //{
            //    new FrmClass().ShowDialog();
            //}
        }

        //Content content = new Content();
        private void btnContent_Click(object sender, EventArgs e)
        {
            //if (content.FindAll().Rows.Count > 0)
            //    new FrmContent().ShowDialog();
            //else
            //{
            //    var saveContent = new FrmSaveContent();
            //    saveContent.ShowDialog();
            //    if (saveContent.contentWasSaved)
            //    {
            //        new FrmContent().ShowDialog();
            //    }
            //}

        }

        private void btnBackupAndRestore_Click(object sender, EventArgs e)
        {
            new FrmBackupAndRestore().ShowDialog();
        }
    }
}