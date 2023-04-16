using DataBase;
using System;
using System.Data;
using System.Windows.Forms;

namespace Balance_Sheet
{
    public partial class FrmReportBalancete : Form
    {
        int personId;
        Person person = new Person();

        public FrmReportBalancete()
        {
            InitializeComponent();
            ToFocus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var savePerson = new FrmSavePerson();
            savePerson.ShowDialog();

            if (savePerson.wasDataSaved)
                LoadDataPersonAndBenefits();
        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            LoadDataPersonAndBenefits();
            btnPrint.Enabled =  dgvPerson.Rows.Count > 0;
        }

        private void LoadDataPersonAndBenefits()
        {
            try
            {
                dgvPerson.Rows.Clear();
                string columnTable = rbName.Checked ? "name" : "address";
                DataTable dtPerson = string.IsNullOrWhiteSpace(txtField.Text)
                    ? person.FindAllPersonAndBenefits()
                    : person.FindAllPersonAndBenefitsByNameOrAddress(txtField.Text, columnTable);

                foreach (DataRow dr in dtPerson.Rows)
                {
                    int index = dgvPerson.Rows.Add();
                    dgvPerson.Rows[index].Cells[0].Value = dr["name"].ToString();
                    dgvPerson.Rows[index].Cells[1].Value = dr["CPF"].ToString();
                    dgvPerson.Rows[index].Cells[2].Value = dr["RG"].ToString();
                    dgvPerson.Rows[index].Cells[3].Value = dr["address"].ToString();
                    dgvPerson.Rows[index].Cells[4].Value = dr["number_address"].ToString();
                    dgvPerson.Rows[index].Cells[5].Value = dr["phone"].ToString();
                    dgvPerson.Rows[index].Cells[6].Value = $"R$ {dr["income"]}";
                    dgvPerson.Rows[index].Cells[7].Value = $"R$ {dr["help"]}";
                    dgvPerson.Rows[index].Cells[8].Value = dr["number_of_members"].ToString();
                    dgvPerson.Rows[index].Cells[9].Value = dr["description"].ToString();
                    dgvPerson.Rows[index].Cells[10].Value = dr["date_benefit"].ToString();
                    dgvPerson.Rows[index].Height = 35;
                }

                dgvPerson.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtField_TextChanged(object sender, EventArgs e)
        {
            LoadDataPersonAndBenefits();
        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataPersonAndBenefits();
            ToFocus();
        }

        private void ToFocus()
        {
            if (string.IsNullOrEmpty(txtField.Text))
                txtField.Focus();
        }

        private void rbAddress_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataPersonAndBenefits();
            ToFocus();
        }

        private void txtField_TextChanged_1(object sender, EventArgs e)
        {
            LoadDataPersonAndBenefits();
        }
    }
}
