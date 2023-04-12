using DataBase;
using System;
using System.Data;
using System.Windows.Forms;

namespace CourseManagement
{
    public partial class FrmSavePerson : Form
    {

        public bool studentWasSaved { get; set; }
      
        public FrmSavePerson()
        {
            InitializeComponent();
        }

        public FrmSavePerson(int id, string name, string shift, string _class, string gender)
        {
            InitializeComponent();
            txtName.Text = name;
            
            LoadCbClass();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Preencha o nome do(a) aluno(a)", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           

            try
            {
                

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmSaveStudent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        DataTable dtClass;
        private void LoadCbClass()
        {
           
        }

        private void cbShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCbClass();
        }
    }
}