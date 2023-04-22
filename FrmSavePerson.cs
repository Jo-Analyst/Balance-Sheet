using Balance_Sheet.Properties;
using DataBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Balance_Sheet
{
    public partial class FrmSavePerson : Form
    {

        public bool wasDataSaved { get; set; }
        Person person = new Person();
        BenefitsReceived benefitsReceived = new BenefitsReceived();

        int person_id, benefits_id;
        bool isEdition;

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
            this.isEdition = isEditicion;
            LoadBenefitsReceived();
            EnabledFieldBenefits();
            if (dgvBenefitsReceived.Rows.Count > 0)
                btnPrint.Enabled = true;
        }

        private void LoadBenefitsReceived()
        {
            DataTable dtBenefitsReceived = BenefitsReceived.FindByPersonId(person_id);
            foreach (DataRow rowBenefitsReceived in dtBenefitsReceived.Rows)
            {
                int index = dgvBenefitsReceived.Rows.Add();
                dgvBenefitsReceived.Rows[index].Cells[0].Value = Properties.Resources.Custom_Icon_Design_Flatastic_1_Edit_24;
                dgvBenefitsReceived.Rows[index].Cells[1].Value = Properties.Resources.trash_24_icon;
                dgvBenefitsReceived.Rows[index].Cells[2].Value = rowBenefitsReceived["id"].ToString();
                dgvBenefitsReceived.Rows[index].Cells[3].Value = rowBenefitsReceived["description"].ToString();
                dgvBenefitsReceived.Rows[index].Cells[4].Value = Convert.ToDateTime(rowBenefitsReceived["date_benefit"].ToString()).ToShortDateString();
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
                txtName.Focus();
            }
            else if (mkCPF.MaskCompleted && !ValidateCPF.validate(mkCPF.Text))
                MessageBox.Show("CPF inválido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (btnSave.Text == "Salvar" && mkCPF.MaskCompleted && person.FindByCPF(mkCPF.Text).Rows.Count == 1 && !isEdition)
                MessageBox.Show("Não foi possível cadastrar. O CPF já está cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (mkCPF.MaskCompleted && person.FindByCpfForPerson(mkCPF.Text, person_id).Rows.Count == 1 && isEdition)
                MessageBox.Show("Não foi possível editar. O CPF que está tentando editar já está cadastrado no sistema", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                validated = true;

            return validated;
        }

        private void FrmSavePerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnSave.Text == "Novo" && e.Control && e.KeyCode == Keys.N || btnSave.Text == "Salvar" && e.Control && e.KeyCode == Keys.S)
            {
                btnSave_Click(sender, e);
            }

            if (btnADD.Enabled && e.Control && e.Shift && e.KeyCode == Keys.A)
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
                btnADD.Text = "Adicionar";
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
                btnADD.Text = "Alterar";
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

                    if (dgvBenefitsReceived.Rows.Count == 0)
                        btnPrint.Enabled = false;

                    btnADD.Text = "Adicionar";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidatedFields())
                return;

            if (btnSave.Text.ToLower() == "salvar")
            {
                SalvePerson();

                if (!isEdition)
                    DisabledFieldsPerson();

            }
            else
            {
                ClearFieldsPerson();
                EnabledFieldsPerson();
                DisabledFieldsBenefit();
                lblStatus.Text = "Status:";
                txtName.Focus();
            }

            toolTip.SetToolTip(btnSave, btnSave.Text.ToLower() == "salvar" && !isEdition ? "Novo - [CTRL + N]" : "Salvar - [CTRL + S]");
            btnSave.Text = btnSave.Text.ToLower() == "salvar" && !isEdition ? "Novo" : "Salvar";

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

        private void DisabledFieldsBenefit()
        {
            rtDescription.Enabled = false;
            dtDateBenefits.Enabled = false;
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

        ToolTip toolTip = new ToolTip();

        private void FrmSavePerson_Load(object sender, EventArgs e)
        {
            if (!bool.Parse(Settings.Default["print_directory_direct"].ToString()))
            { 
                btnPrint.Text = "Visualizar e imprimir";
            }

            toolTip.SetToolTip(btnPrint, "Imprimir - [CTRL + P]");
            toolTip.SetToolTip(btnSave, "Salvar - [CTRL + S]");
            toolTip.SetToolTip(btnADD, "Adicionar - [CTRL + SHIFT + A]");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPersonJoinBenefits = Person.FindByPersonJoinBenefitsId(person_id);
                DataTable dtPerson = Person.FindById(person_id);

                if (!Convert.ToBoolean(Settings.Default["print_directory_direct"]))
                    new FrmReportByPerson(dtPersonJoinBenefits, dtPerson).ShowDialog();
                else
                    PrintLocalReport.PrintReportDirectlyFromPrinter(dtPersonJoinBenefits, dtPerson);
            }
            catch
            {
                MessageBox.Show("Houve um erro ao imprimir.Tente novamente. Caso o erro persista contate o suporte", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBenefitsReceived_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvBenefitsReceived.Cursor = e.ColumnIndex == 0 || e.ColumnIndex == 1 ? Cursors.Hand : Cursors.Arrow;
        }

        private void ClearFieldBenefits()
        {
            rtDescription.Clear();
            dtDateBenefits.Value = DateTime.Now;
            benefits_id = 0;
        }
    }
}