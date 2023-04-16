using DataBase;
using System;
using System.Data;
using System.Windows.Forms;

namespace Balance_Sheet
{
    public partial class FrmPerson : Form
    {
        int personId;
        Person person = new Person();

        public FrmPerson()
        {
            InitializeComponent();
            ToFocus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var savePerson = new FrmSavePerson();
            savePerson.ShowDialog();

            if (savePerson.wasDataSaved)
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
                string field = rbName.Checked ? "name" : "address";
                DataTable dtPerson = string.IsNullOrWhiteSpace(txtField.Text)
                    ? person.FindAll()
                    : person.FindByNameOrAddress(txtField.Text, field);

                foreach (DataRow dr in dtPerson.Rows)
                {
                    int index = dgvPerson.Rows.Add();
                    dgvPerson.Rows[index].Cells[0].Value = Properties.Resources.Custom_Icon_Design_Flatastic_1_Edit_24;
                    dgvPerson.Rows[index].Cells[1].Value = Properties.Resources.trash_24_icon;
                    dgvPerson.Rows[index].Cells[2].Value = dr["id"].ToString();
                    dgvPerson.Rows[index].Cells[3].Value = dr["name"].ToString();
                    dgvPerson.Rows[index].Cells[4].Value = dr["CPF"].ToString();
                    dgvPerson.Rows[index].Cells[5].Value = dr["RG"].ToString();
                    dgvPerson.Rows[index].Cells[6].Value = dr["address"].ToString();
                    dgvPerson.Rows[index].Cells[7].Value = dr["number_address"].ToString();
                    dgvPerson.Rows[index].Cells[8].Value = dr["phone"].ToString();
                    dgvPerson.Rows[index].Cells[9].Value = $"R$ {dr["income"]}";
                    dgvPerson.Rows[index].Cells[10].Value = $"R$ {dr["help"]}";
                    dgvPerson.Rows[index].Cells[11].Value = dr["number_of_members"].ToString();
                    dgvPerson.Rows[index].Height = 35;
                }

                dgvPerson.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditPerson()
        {
            var savePerson = new FrmSavePerson(int.Parse(dgvPerson.CurrentRow.Cells[2].Value.ToString()), dgvPerson.CurrentRow.Cells[3].Value.ToString(), dgvPerson.CurrentRow.Cells[4].Value.ToString(), dgvPerson.CurrentRow.Cells[5].Value.ToString(), dgvPerson.CurrentRow.Cells[6].Value.ToString(), dgvPerson.CurrentRow.Cells[7].Value.ToString(), dgvPerson.CurrentRow.Cells[8].Value.ToString(), decimal.Parse(dgvPerson.CurrentRow.Cells[9].Value.ToString().Substring(2)), decimal.Parse(dgvPerson.CurrentRow.Cells[10].Value.ToString().Substring(2)), int.Parse(dgvPerson.CurrentRow.Cells[11].Value.ToString()));
            savePerson.ShowDialog();

            personId = 0;
            dgvPerson.ClearSelection();

            if (savePerson.wasDataSaved)
                LoadDataPerson();
        }

        private void txtField_TextChanged(object sender, EventArgs e)
        {
            LoadDataPerson();
        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataPerson();
            ToFocus();
        }

        private void ToFocus()
        {
            if (string.IsNullOrEmpty(txtField.Text))
                txtField.Focus();
        }

        private void rbAddress_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataPerson();
            ToFocus();
        }

        private void dgvPerson_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                personId = int.Parse(dgvPerson.CurrentRow.Cells[2].Value.ToString());
                if (dgvPerson.CurrentCell.ColumnIndex == 0)
                    EditPerson();
                else if (dgvPerson.CurrentCell.ColumnIndex == 1)
                {
                    DeletePerson();
                }
            }

            dgvPerson.ClearSelection();
        }

        private void DeletePerson()
        {
            try
            {
                DialogResult dr = MessageBox.Show($"Deseja mesmo excluir a(o) responsável '{dgvPerson.CurrentRow.Cells[3].Value}' da base de dados?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    person.id = personId;
                    person.Delete();
                    dgvPerson.Rows.Remove(dgvPerson.CurrentRow);
                    if (dgvPerson.Rows.Count == 0)
                    {
                        this.Visible = false;
                        FrmSavePerson savePerson = new FrmSavePerson();
                        savePerson.ShowDialog();

                        if (savePerson.wasDataSaved)
                        {
                            this.Visible = true;
                            LoadDataPerson();
                        }
                        else
                            this.Close();
                    }

                }

                personId = 0;
                dgvPerson.ClearSelection();

            }
            catch
            {
                MessageBox.Show("Houve um erro ao excluir. Feche o aplicativo e tente novamente. Caso o erro persiste, entre em contato com o suporte", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.F1 == e.KeyCode)
            {
                btnNew_Click(sender, e);
            }
        }
    }
}
