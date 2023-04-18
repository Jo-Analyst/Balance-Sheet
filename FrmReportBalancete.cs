using Balance_Sheet.Properties;
using DataBase;
using Microsoft.Reporting.WinForms;
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

        private void FrmReportBalancete_Load(object sender, EventArgs e)
        {
            LoadDataPersonAndBenefits();
            btnPrint.Enabled = dgvPerson.Rows.Count > 0;
        }

        DataTable dtPerson;

        private void LoadDataPersonAndBenefits()
        {
            try
            {
                dgvPerson.Rows.Clear();
                string columnTable = rbName.Checked ? "name" : "address";
                dtPerson = string.IsNullOrWhiteSpace(txtField.Text)
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDataSource rprtDTSource = new ReportDataSource("dtPersonAndBenefits", dtPerson);

                if (!Convert.ToBoolean(Settings.Default["print_directory_direct"]))
                    new FrmReportByPersonAndBenefits(rprtDTSource, dtPerson).ShowDialog();
                else
                    PrintLocalReport.PrintReportDirectlyFromPrinter(dtPerson, null, true);
            }
            catch
            {
                MessageBox.Show("Houve um erro ao imprimir.Tente novamente. Caso o erro persista contate o suporte", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmReportBalancete_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnPrint.Enabled && e.Control && e.KeyCode == Keys.P)
                btnPrint_Click(sender, e);
        }
    }
}
