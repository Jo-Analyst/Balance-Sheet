using DataBase;
using System;
using System.Data;
using System.Windows.Forms;

namespace Balance_Sheet
{
    public partial class FrmSavePerson : Form
    {

        public bool studentWasSaved { get; set; }
        Person person = new Person();
        BenefitsReceived benefitsReceived = new BenefitsReceived();
        int person_id, benefits_id;

        public FrmSavePerson()
        {
            InitializeComponent();
        }
        public FrmSavePerson(int id, string name, string CPF, string RG, string address, string number_adress, string phone, decimal income, decimal help, int number_of_members)
        {
            InitializeComponent();

            this.person_id = id;
            txtName.Text = name;
            mkCPF.Text = CPF;
            txtRG.Text = RG;
            txtAddress.Text = address;
            txtNumberAddress.Text = number_adress;
            mkPhone.Text = phone;
            txtIncome.Text = income.ToString();
            txtHelp.Text = help.ToString();
            ndNumberOfMembers.Value = number_of_members;
            LoadBenefitsReceived();
        }

        private void LoadBenefitsReceived()
        {
            DataTable dtBenefitsReceived = benefitsReceived.FindByPersonId(person_id);
            foreach (DataRow rowBenefitsReceived in dtBenefitsReceived.Rows)
            {
                int index = dgvBenefitsReceived.Rows.Add();
                dgvBenefitsReceived.Rows[index].Cells[0].Value = rowBenefitsReceived["id"].ToString();
                dgvBenefitsReceived.Rows[index].Cells[1].Value = rowBenefitsReceived["description"].ToString();
                dgvBenefitsReceived.Rows[index].Cells[2].Value = Convert.ToDateTime(rowBenefitsReceived["date_benefits"].ToString()).ToShortDateString();
                dgvBenefitsReceived.Rows[index].Height = 35;
            }
            dgvBenefitsReceived.ClearSelection();
        }

        public bool ValidatedFields()
        {
            bool validated = false;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Preencha o nome do(a) responsável!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (mkCPF.MaskCompleted && !ValidateCPF.validate(mkCPF.Text))
                MessageBox.Show("CPF inválido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                validated = true;

            return validated;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidatedFields())
                    return;

                person.id = person_id;
                person.name = txtName.Text.Trim();
                person.CPF = mkCPF.MaskCompleted ? mkCPF.Text.Trim() : string.Empty;
                person.RG = txtRG.Text.Trim();
                person.address = txtAddress.Text.Trim();
                person.numberOfMembers = int.Parse(ndNumberOfMembers.Value.ToString());
                person.phone = mkPhone.MaskCompleted ? mkPhone.Text.Trim() : string.Empty;
                person.income = string.IsNullOrWhiteSpace(txtIncome.Text) ? 0 : decimal.Parse(txtIncome.Text.Trim());
                person.help = string.IsNullOrWhiteSpace(txtHelp.Text) ? 0 : decimal.Parse(txtHelp.Text.Trim());
                person.numberAddress = txtNumberAddress.Text.Trim();

                person.Save(dtBenefitsReceived);


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

        DataTable dtBenefitsReceived = new DataTable();
        private void btnADD_Click(object sender, EventArgs e)
        {
            dtBenefitsReceived.Rows.Add("0", rtDescription.Text.Trim(), dtDateBenefits.Value.ToString());
            dgvBenefitsReceived.Rows.Add("0", rtDescription.Text.Trim(), dtDateBenefits.Value.ToShortDateString());
            dgvBenefitsReceived.Rows[dgvBenefitsReceived.Rows.Count - 1].Height = 35;
            dgvBenefitsReceived.ClearSelection();
            rtDescription.Clear();
            btnDelete.Visible = false;
        }

        private void CreateColumnDtBenefitsReceived()
        {
            dtBenefitsReceived.Columns.Add("id", typeof(string));
            dtBenefitsReceived.Columns.Add("description", typeof(string));
            dtBenefitsReceived.Columns.Add("date_benefits", typeof(string));
        }

        private void rtDescription_TextChanged(object sender, EventArgs e)
        {
            btnADD.Enabled = !string.IsNullOrEmpty(rtDescription.Text);
        }

        private void ndNumberOfMembers_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                FormatterFields.FormatterDecimal(e, txtIncome);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtHelp_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatterFields.FormatterDecimal(e, txtHelp);
        }

        private void dgvBenefitsReceived_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            benefits_id = int.Parse(dgvBenefitsReceived.CurrentRow.Cells[0].Value.ToString());
            rtDescription.Text = dgvBenefitsReceived.CurrentRow.Cells[1].Value.ToString();
            dtDateBenefits.Value = Convert.ToDateTime(dgvBenefitsReceived.CurrentRow.Cells[2].Value.ToString());
            btnDelete.Visible = true;
            btnADD.Enabled = true;
            clearSelection(e);
        }

        private void clearSelection(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgvBenefitsReceived.ClearSelection();
            }
        }

        private void dgvBenefitsReceived_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clearSelection(e);
        }

        private void txtIncome_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!IsFieldDecimal(txtIncome))
                    return;
                txtIncome.Text = FormatterFields.AddDecimalPlaces(txtIncome.Text.Trim());
            }
            catch { }
        }

        private void txtHelp_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!IsFieldDecimal(txtHelp))
                    return;

                txtHelp.Text = FormatterFields.AddDecimalPlaces(txtHelp.Text.Trim());

            }
            catch { }
        }

        public bool IsFieldDecimal(TextBox value)
        {
            bool isDecimal = false;
            if (!string.IsNullOrEmpty(value.Text) && !decimal.TryParse(value.Text, out decimal result))
            {
                value.Clear();
                value.Focus();
            }
            else
                isDecimal = true;

            return isDecimal;
        }

        private void FrmSavePerson_Load(object sender, EventArgs e)
        {
            CreateColumnDtBenefitsReceived();
        }
    }
}