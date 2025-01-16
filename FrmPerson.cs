using Balance_Sheet.Utils;
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
        DataTable dtPerson = new DataTable();
        bool isDelete = false;

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

        private void FrmPerson_Load(object sender, EventArgs e)
        {
            cbRows.SelectedIndex = 1;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnNew, "Novo - [CTRL + N]");
        }


        private void LoadDataPerson()
        {
            try
            {
                PageData.quantityRowsSelected = int.Parse(cbRows.SelectedItem.ToString());
                dgvPerson.Rows.Clear();
             
                if(dtPerson.Rows.Count > 0)
                {
                    dtPerson.Rows.Clear();
                }


                string field = rbName.Checked ? "name" : "address";
                int maximumPage = string.IsNullOrWhiteSpace(txtField.Text) ? 1 : PageData.SetPageQuantityByNameOrAddressPersons(txtField.Text, field);

                ndPage.Maximum = string.IsNullOrWhiteSpace(txtField.Text) ? PageData.SetPageQuantityPersons() : Math.Max(maximumPage, 1);

                int pageSelected = (int)((Math.Max(1, int.Parse(ndPage.Value.ToString())) - 1) * PageData.quantityRowsSelected);

                dtPerson = string.IsNullOrWhiteSpace(txtField.Text)
                    ? person.FindAll(pageSelected, PageData.quantityRowsSelected)
                    : person.FindByNameOrAddress(txtField.Text, field, pageSelected, PageData.quantityRowsSelected);


                foreach (DataRow dr in dtPerson.Rows)
                {
                    int index = dgvPerson.Rows.Add();
                    dgvPerson.Rows[index].Cells[0].Value = Properties.Resources.Custom_Icon_Design_Flatastic_1_Edit_24;
                    dgvPerson.Rows[index].Cells[1].Value = Properties.Resources.trash_24_icon;
                    dgvPerson.Rows[index].Cells["ColId"].Value = dr["id"].ToString();
                    dgvPerson.Rows[index].Cells["ColName"].Value = dr["name"].ToString();
                    dgvPerson.Rows[index].Cells["ColCPF"].Value = dr["CPF"].ToString();
                    dgvPerson.Rows[index].Cells["ColRG"].Value = dr["RG"].ToString();
                    dgvPerson.Rows[index].Cells["ColAddress"].Value = dr["address"].ToString();
                    dgvPerson.Rows[index].Cells["ColNumberAddress"].Value = dr["number_address"].ToString();
                    dgvPerson.Rows[index].Cells["ColPhone"].Value = dr["phone"].ToString();
                    dgvPerson.Rows[index].Cells["ColIncome"].Value = $"R$ {dr["income"]}";
                    dgvPerson.Rows[index].Cells["ColHelp"].Value = $"R$ {dr["help"]}";
                    dgvPerson.Rows[index].Cells["ColNumberOfMembers"].Value = dr["number_of_members"].ToString();
                    dgvPerson.Rows[index].Cells["ColBirth"].Value = dr["birth"].ToString();
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
            var savePerson = new FrmSavePerson(int.Parse(dgvPerson.CurrentRow.Cells["ColId"].Value.ToString()),
             dgvPerson.CurrentRow.Cells["ColName"].Value.ToString(),
             dgvPerson.CurrentRow.Cells["ColCPF"].Value.ToString(),
             dgvPerson.CurrentRow.Cells["ColRG"].Value.ToString(),
             dgvPerson.CurrentRow.Cells["ColAddress"].Value.ToString(),
             dgvPerson.CurrentRow.Cells["ColNumberAddress"].Value.ToString(),
             dgvPerson.CurrentRow.Cells["ColPhone"].Value.ToString(),
            decimal.Parse(dgvPerson.CurrentRow.Cells["ColIncome"].Value.ToString().Substring(2)),
             decimal.Parse(dgvPerson.CurrentRow.Cells["ColHelp"].Value.ToString().Substring(2)),
            int.Parse(dgvPerson.CurrentRow.Cells["ColNumberOfMembers"].Value.ToString()), dgvPerson.CurrentRow.Cells["ColBirth"].Value.ToString());
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
                    isDelete = true;
                    person.id = personId;
                    person.Delete();
                    LoadDataPerson();

                    isDelete = false;

                    if (dtPerson.Rows.Count == 0)
                    {
                        this.Visible = false;
                        FrmSavePerson savePerson = new FrmSavePerson();
                        savePerson.ShowDialog();

                        if (savePerson.wasDataSaved)
                        {
                            this.Visible = true;
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
            if (e.Control && Keys.N == e.KeyCode)
            {
                btnNew_Click(sender, e);
            }
        }

        private void dgvPerson_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvPerson.Cursor = e.ColumnIndex == 0 || e.ColumnIndex == 1 ? Cursors.Hand : Cursors.Arrow;

        }

        private void cbRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataPerson();
        }

        private void ndPage_ValueChanged(object sender, EventArgs e)
        {
            if (!isDelete)
                LoadDataPerson();
        }
    }
}
