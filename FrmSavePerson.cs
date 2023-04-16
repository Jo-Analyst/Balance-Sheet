using Balance_Sheet.Properties;
using DataBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Balance_Sheet
{
    public partial class FrmSavePerson : Form
    {

        public bool wasDataSaved { get; set; }
        Person person = new Person();
        BenefitsReceived benefitsReceived = new BenefitsReceived();
        int person_id, benefits_id;
        bool isEditicion;

        public FrmSavePerson()
        {
            InitializeComponent();
        }
        public FrmSavePerson(int id, string name, string CPF, string RG, string address, string number_adress, string phone, decimal income, decimal help, int number_of_members, bool isEditicion = true)
        {
            InitializeComponent();

            person_id = id;
            txtName.Text = name;
            mkCPF.Text = CPF;
            txtRG.Text = RG;
            txtAddress.Text = address;
            txtNumberAddress.Text = number_adress;
            mkPhone.Text = phone;
            txtIncome.Text = income.ToString();
            txtHelp.Text = help.ToString();
            ndNumberOfMembers.Value = number_of_members;
            this.isEditicion = isEditicion;
            LoadBenefitsReceived();
            EnabledFieldBenefits();
            if (dgvBenefitsReceived.Rows.Count > 0)
                btnPrint.Enabled = true;
        }

        private void LoadBenefitsReceived()
        {
            DataTable dtBenefitsReceived = benefitsReceived.FindByPersonId(person_id);
            foreach (DataRow rowBenefitsReceived in dtBenefitsReceived.Rows)
            {
                int index = dgvBenefitsReceived.Rows.Add();
                dgvBenefitsReceived.Rows[index].Cells[0].Value = Properties.Resources.Custom_Icon_Design_Flatastic_1_Edit_24;
                dgvBenefitsReceived.Rows[index].Cells[1].Value = Properties.Resources.trash_24_icon;
                dgvBenefitsReceived.Rows[index].Cells[2].Value = rowBenefitsReceived["id"].ToString();
                dgvBenefitsReceived.Rows[index].Cells[3].Value = rowBenefitsReceived["description"].ToString();
                dgvBenefitsReceived.Rows[index].Cells[4].Value = Convert.ToDateTime(rowBenefitsReceived["date_benefits"].ToString()).ToShortDateString();
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
            else if (mkCPF.MaskCompleted && person.FindByCPF(mkCPF.Text).Rows.Count == 1 && !isEditicion)
                MessageBox.Show("Não foi possível cadastrar. O CPF já está cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (mkCPF.MaskCompleted && person.FindByCpfForPerson(mkCPF.Text, person_id).Rows.Count == 1 && isEditicion)
                MessageBox.Show("Não foi possível editar. O CPF que está tentando editar já está cadastrado no sistema", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                validated = true;

            return validated;
        }

        private void FrmSavePerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnsave_Click(sender, e);
            }

            if (btnADD.Enabled && e.KeyCode == Keys.F2)
                btnADD_Click(sender, e);

            if (btnPrint.Enabled && Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.P)
                btnPrint_Click(sender, e);
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                benefitsReceived.id = benefits_id;
                benefitsReceived.description = rtDescription.Text.Trim();
                benefitsReceived.dateBenefits = dtDateBenefits.Value;
                benefitsReceived.person_id = person_id;
                benefitsReceived.Save();

                if (benefits_id == 0)
                {
                    dgvBenefitsReceived.Rows.Add(Properties.Resources.Custom_Icon_Design_Flatastic_1_Edit_24, Properties.Resources.trash_24_icon, benefitsReceived.id, rtDescription.Text.Trim(), dtDateBenefits.Value.ToShortDateString());
                    dgvBenefitsReceived.Rows[dgvBenefitsReceived.Rows.Count - 1].Height = 35;
                    dgvBenefitsReceived.ClearSelection();
                }
                else
                {
                    dgvBenefitsReceived.Rows[indexRowPress].Cells["ColDescripition"].Value = rtDescription.Text.Trim();
                    dgvBenefitsReceived.Rows[indexRowPress].Cells["ColDate"].Value = dtDateBenefits.Text.Trim();
                }

                rtDescription.Clear();
                benefits_id = 0;
                btnPrint.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Houve um erro no servidor. Feche o aplicativo e tente novamente. Caso o erro persista entre em contato com o suporte", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtDescription_TextChanged(object sender, EventArgs e)
        {
            btnADD.Enabled = !string.IsNullOrWhiteSpace(rtDescription.Text);
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

        int indexRowPress;

        private void dgvBenefitsReceived_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                dgvBenefitsReceived.ClearSelection();
                return;
            }

            if (dgvBenefitsReceived.CurrentCell.ColumnIndex == 0)
            {
                EditBenefits();
                btnADD.Enabled = true;
                indexRowPress = e.RowIndex;      
            }
            else if (dgvBenefitsReceived.CurrentCell.ColumnIndex == 1)
                DeleteBenefits();

            clearSelection(e);
        }

        private void DeleteBenefits()
        {
            try
            {
                DialogResult dr = MessageBox.Show($"Deseja mesmo excluir o benefício da base de dados?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    benefitsReceived.Delete(int.Parse(dgvBenefitsReceived.CurrentRow.Cells[2].Value.ToString()));
                    ClearFielsBenefits();
                    dgvBenefitsReceived.Rows.Remove(dgvBenefitsReceived.CurrentRow);

                    if(dgvBenefitsReceived.Rows.Count == 0)
                        btnPrint.Enabled = false;
                }

                dgvBenefitsReceived.ClearSelection();

            }
            catch
            {
                MessageBox.Show("Houve um erro ao excluir. Feche o aplicativo e tente novamente. Caso o erro persista entre em contato com o suporte", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFielsBenefits()
        {
            if (benefits_id == int.Parse(dgvBenefitsReceived.CurrentRow.Cells["ColumnID"].Value.ToString()))
                ClearFieldBenefits();
        }

        private void EditBenefits()
        {
            benefits_id = int.Parse(dgvBenefitsReceived.CurrentRow.Cells[2].Value.ToString());
            rtDescription.Text = dgvBenefitsReceived.CurrentRow.Cells[3].Value.ToString();
            dtDateBenefits.Value = Convert.ToDateTime(dgvBenefitsReceived.CurrentRow.Cells[4].Value.ToString());            
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (!ValidatedFields())
                return;

            if (btnsave.Text.ToLower() == "salvar - [f1]")
            {
                SalvePerson();

                if(!isEditicion)
                    DisabledFieldsPerson();

            }
            else
            {
                ClearFieldsPerson();
                EnabledFieldsPerson();
                 lblStatus.Text = "Status:";
            }

            btnsave.Text = btnsave.Text.ToLower() == "salvar - [f1]" && !isEditicion ? "Novo - [F1]" : "Salvar - [F1]";
            
        }

        private void ClearFieldsPerson()
        {
            txtName.Clear();
            mkCPF.Clear();
            txtRG.Clear();
            mkPhone.Clear();
            txtAddress.Clear();
            txtNumberAddress.Clear();
            txtIncome.Clear();
            txtHelp.Clear();
            ndNumberOfMembers.Value = 0;
            ClearFieldBenefits();
            dgvBenefitsReceived.Rows.Clear();
            person_id = 0;
        }

        private void EnabledFieldsPerson()
        {
            txtName.Enabled = true;
            mkCPF.Enabled = true;
            txtRG.Enabled = true;
            mkPhone.Enabled = true;
            txtAddress.Enabled = true;
            txtNumberAddress.Enabled = true;
            txtIncome.Enabled = true;
            txtHelp.Enabled = true;
            ndNumberOfMembers.Enabled = true;
        }

        private void DisabledFieldsPerson()
        {
            txtName.Enabled = false;
            mkCPF.Enabled = false;
            txtRG.Enabled = false;
            mkPhone.Enabled = false;
            txtAddress.Enabled = false;
            txtNumberAddress.Enabled = false;
            txtIncome.Enabled = false;
            txtHelp.Enabled = false;
            ndNumberOfMembers.Enabled = false;
        }

        private void SalvePerson()
        {
            try
            {
                lblStatus.Text = "Status: Salvando...";
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

                person.Save();
                mkCPF.Text = person.CPF;
                lblStatus.Text = "Status: Salvo";
                person_id = person.id;
                EnabledFieldBenefits();
                wasDataSaved = true;
            }
            catch (Exception ex)
            {
                 lblStatus.Text = "Status:";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnabledFieldBenefits()
        {
            rtDescription.Enabled = true;
            dtDateBenefits.Enabled = true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
             lblStatus.Text = "Status:";
        }

        private void txtRG_TextChanged(object sender, EventArgs e)
        {
             lblStatus.Text = "Status:";
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
             lblStatus.Text = "Status:";
        }

        private void txtNumberAddress_TextChanged(object sender, EventArgs e)
        {
             lblStatus.Text = "Status:";
        }

        private void txtIncome_TextChanged(object sender, EventArgs e)
        {
             lblStatus.Text = "Status:";
        }

        private void txtHelp_TextChanged(object sender, EventArgs e)
        {
             lblStatus.Text = "Status:";
        }

        private void ndNumberOfMembers_ValueChanged(object sender, EventArgs e)
        {
             lblStatus.Text = "Status:";
        }

        private void mkCPF_TextChanged(object sender, EventArgs e)
        {
             lblStatus.Text = "Status:";
        }

        private void mkPhone_TextChanged(object sender, EventArgs e)
        {
             lblStatus.Text = "Status:";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable bennefits = new BenefitsReceived().FindByPersonId(person_id);
            ReportDataSource rprtDTSource = new ReportDataSource("dtBenefits", bennefits);
          
            if (!Convert.ToBoolean(Settings.Default["print_directory_direct"]))
                new FrmReportPerson(rprtDTSource).ShowDialog();
            else
                printDirectyTheReport(rprtDTSource);
        }

        private void printDirectyTheReport(ReportDataSource rprtDTSource)
        {
            LocalReport localReport = new LocalReport();
            localReport.DataSources.Clear();
            localReport.DataSources.Add(rprtDTSource);
            //localReport.ReportPath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\ReportPerson.rdlc";
            localReport.ReportPath = $"C:\\Users\\jojoc\\OneDrive\\Documentos\\Meus projetos\\balance-sheet\\ReportPerson.rdlc";
            localReport.PrintToPrinter();
        }

        private void ClearFieldBenefits()
        {
            rtDescription.Clear();
            dtDateBenefits.Value = DateTime.Now;
            benefits_id = 0;
        }
    }
}