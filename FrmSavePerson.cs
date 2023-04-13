using Balance_Sheet;
using DataBase;
using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CourseManagement
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
                person.CPF = mkCPF.MaskCompleted ?  mkCPF.Text.Trim() : string.Empty;
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
            dtBenefitsReceived.Rows.Add("", rtDescription.Text.Trim(), dtDateBenefits.Value);
            dgvBenefitsReceived.Rows.Add("", rtDescription.Text.Trim(), dtDateBenefits.Value.ToShortDateString());
            dgvBenefitsReceived.ClearSelection();
            rtDescription.Clear();
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
                FormatterFields.formatterDecimal(e, txtIncome);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtHelp_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatterFields.formatterDecimal(e, txtHelp);
        }

        private void FrmSavePerson_Load(object sender, EventArgs e)
        {
            CreateColumnDtBenefitsReceived();
        }
    }
}