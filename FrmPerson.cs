using DataBase;
using System;
using System.Data;
using System.Windows.Forms;

namespace CourseManagement
{
    public partial class FrmPerson : Form
    {
        int personId;
        Person person =new Person();

        public FrmPerson()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new FrmSavePerson().ShowDialog();
            LoadDataPerson();
        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            LoadDataPerson();
        }

        private void LoadDataPerson()
        {
            try
            {
                dgvPerson.Rows.Clear();
                string option = rbName.Checked ? "nome" : "class";
                DataTable dtPerson = string.IsNullOrWhiteSpace(txtField.Text)
                    ? person.FindAll()
                    : person.FindByAddress(txtField.Text);

                foreach (DataRow dr in dtPerson.Rows)
                {
                    int index = dgvPerson.Rows.Add();
                    dgvPerson.Rows[index].Cells[0].Value = dr["id"].ToString();
                    dgvPerson.Rows[index].Cells[1].Value = dr["name"].ToString();
                    dgvPerson.Rows[index].Cells[2].Value = dr["CPF"].ToString();
                    dgvPerson.Rows[index].Cells[3].Value = dr["RG"].ToString();
                    dgvPerson.Rows[index].Cells[4].Value = dr["address"].ToString();
                    dgvPerson.Rows[index].Cells[5].Value = dr["number_address"].ToString();
                    dgvPerson.Rows[index].Cells[6].Value = dr["phone"].ToString();
                    dgvPerson.Rows[index].Cells[7].Value = $"R$ {dr["income"]}";
                    dgvPerson.Rows[index].Cells[8].Value = $"R$ {dr["help"]}";
                    dgvPerson.Rows[index].Cells[9].Value = dr["number_of_members"].ToString();
                    dgvPerson.Rows[index].Height = 35;
                }

                dgvPerson.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           var savePerson = new FrmSavePerson(int.Parse(dgvPerson.CurrentRow.Cells[0].Value.ToString()), dgvPerson.CurrentRow.Cells[1].Value.ToString(), dgvPerson.CurrentRow.Cells[2].Value.ToString(), dgvPerson.CurrentRow.Cells[3].Value.ToString(), dgvPerson.CurrentRow.Cells[4].Value.ToString(), dgvPerson.CurrentRow.Cells[5].Value.ToString(), dgvPerson.CurrentRow.Cells[6].Value.ToString(), decimal.Parse(dgvPerson.CurrentRow.Cells[7].Value.ToString().Substring(2)), decimal.Parse(dgvPerson.CurrentRow.Cells[8].Value.ToString().Substring(2)), int.Parse(dgvPerson.CurrentRow.Cells[9].Value.ToString()));
            savePerson.ShowDialog();

            personId = 0;
            dgvPerson.ClearSelection();
            DisableButtons();
            if (savePerson.studentWasSaved)
                LoadDataPerson();
        }

        private void txtField_TextChanged(object sender, EventArgs e)
        {
            LoadDataPerson();
        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataPerson();
        }

        private void rbClass_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataPerson();
        }

        private void dgvPerson_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true; ;
                personId = int.Parse(dgvPerson.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void DisableButtons()
        {
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show($"Deseja mesmo excluir a(o) responsável '{dgvPerson.CurrentRow.Cells[1].Value}' da base de dados?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    person.id = personId;
                    person.Delete();
                    dgvPerson.Rows.Remove(dgvPerson.CurrentRow);
                }
                
                personId = 0;
                dgvPerson.ClearSelection();
                DisableButtons();

            }
            catch 
            {
                MessageBox.Show("Houve um erro ao excluir. Feche o aplicativo e tente novamente. Caso o erro persiste, entre em contato com o suporte", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
