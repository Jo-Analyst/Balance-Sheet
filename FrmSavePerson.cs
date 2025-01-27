﻿using DataBase;
using Balance_Sheet.Properties;
using System;
using System.Data;
using System.Windows.Forms;
using Balance_Sheet.Utils;

namespace Balance_Sheet
{
    public partial class FrmSavePerson : Form
    {

        public bool wasDataSaved { get; set; }
        Person person = new Person();
        BenefitsReceived benefitsReceived = new BenefitsReceived();

        int personId, benefits_id;
        bool isEdition;

        public FrmSavePerson()
        {
            InitializeComponent();
        }

        public FrmSavePerson(int id, string name, string CPF, string RG, string address, string number_adress, string phone, decimal income, decimal help, int number_of_members, String birth, bool isEditicion = true)
        {
            InitializeComponent();

            cbRowsBenefits.SelectedIndex = 1;
            cbRowsService.SelectedIndex = 1;
            personId = id;
            txtName.Text = name;
            mkCPF.Text = CPF;
            txtRG.Text = RG;
            txtAddress.Text = address;
            txtNumberAddress.Text = number_adress;
            mkPhone.Text = phone;
            txtIncome.Text = income.ToString();
            txtHelp.Text = help.ToString();
            dtBirth.Text = birth.ToString();
            ndNumberOfMembers.Value = number_of_members;
            this.isEdition = isEditicion;
            btnSave.Focus();
            LoadBenefitsReceived();
            LoadServices();
            EnabledFieldBenefitsAndService();
            if (dgvBenefitsReceived.Rows.Count > 0)
                btnPrint.Enabled = true;

            if (isEditicion)
            {
                btnVizAdd.Visible = ndNumberOfMembers.Value > 0;
            }
        }

        private void LoadServices()
        {

            PageData.quantityRowsSelected = int.Parse(cbRowsService.SelectedItem.ToString());

            int maximumPage = PageData.SetPageQuantityServices(personId);

            ndPageService.Maximum = maximumPage > 0 ? maximumPage : 1;

            int pageSelected = (int)((Math.Max(1, int.Parse(ndPageService.Value.ToString())) - 1) * PageData.quantityRowsSelected);

            dgvService.Rows.Clear();

            DataTable dtServices = Service.FindByPersonId(personId, pageSelected, PageData.quantityRowsSelected);

            foreach (DataRow data in dtServices.Rows)
            {
                AddDgvService(int.Parse(data["id"].ToString()), data["description"].ToString(), DateTime.Parse(data["date_service"].ToString()));
            }
        }

        private void LoadBenefitsReceived()
        {

            PageData.quantityRowsSelected = int.Parse(cbRowsBenefits.SelectedItem.ToString());

            int maximunPage = PageData.SetPageQuantityBenefitsReceived(personId);

            ndPageBenefits.Maximum = maximunPage > 0 ? maximunPage : 1;

            int pageSelected = (int)((Math.Max(1, int.Parse(ndPageBenefits.Value.ToString())) - 1) * PageData.quantityRowsSelected);

            dgvBenefitsReceived.Rows.Clear();

            DataTable dtBenefitsReceived = BenefitsReceived.FindByPersonId(personId, pageSelected, PageData.quantityRowsSelected);

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
            else if (mkCPF.MaskCompleted && person.FindByCpfForPerson(mkCPF.Text, personId).Rows.Count == 1 && isEdition)
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

            if (btnAddService.Enabled && e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                btnVizAdd_Click(sender, e);
            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                benefitsReceived.id = benefits_id;
                benefitsReceived.description = rtDescription.Text.Trim();
                benefitsReceived.dateBenefits = dtDateBenefits.Value;
                benefitsReceived.person_id = personId;
                benefitsReceived.Save();

                if (benefits_id == 0)
                {                    
                    LoadBenefitsReceived();
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

            ClearSelection(e);
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
                    LoadBenefitsReceived();

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

        private void ClearSelection(DataGridViewCellEventArgs e, bool isService = false)
        {
            if (e.RowIndex > -1)
            {
                if (isService)
                    dgvService.ClearSelection();
                else
                    dgvBenefitsReceived.ClearSelection();
            }
        }

        private void dgvBenefitsReceived_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearSelection(e);
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
            personId = 0;
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
                person.id = personId;
                person.name = txtName.Text.Trim();
                person.CPF = mkCPF.MaskCompleted ? mkCPF.Text.Trim() : string.Empty;
                person.RG = txtRG.Text.Trim();
                person.address = txtAddress.Text.Trim();
                person.numberOfMembers = int.Parse(ndNumberOfMembers.Value.ToString());
                person.birth = dtBirth.Text;
                person.phone = mkPhone.MaskCompleted ? mkPhone.Text.Trim() : string.Empty;
                person.income = string.IsNullOrWhiteSpace(txtIncome.Text) ? 0 : decimal.Parse(txtIncome.Text.Trim());
                person.help = string.IsNullOrWhiteSpace(txtHelp.Text) ? 0 : decimal.Parse(txtHelp.Text.Trim());
                person.numberAddress = txtNumberAddress.Text.Trim();

                person.Save();
                mkCPF.Text = person.CPF;
                lblStatus.Text = "Status: Salvo";
                personId = person.id;
                EnabledFieldBenefitsAndService();
                wasDataSaved = true;
                btnVizAdd.Visible = ndNumberOfMembers.Value > 0;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Status:";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnabledFieldBenefitsAndService()
        {
            rtDescription.Enabled = true;
            dtDateBenefits.Enabled = true;
            btnAddService.Enabled = true;
        }

        private void DisabledFieldsBenefit()
        {
            rtDescription.Enabled = false;
            dtDateBenefits.Enabled = false;
            btnAddService.Enabled = false;
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
            toolTip.SetToolTip(btnVizAdd, "Visualizar | Adicionar Membros - [CTRL + SHIFT + S]");
            dtDateBenefits.MaxDate = DateTime.Now;
            dtBirth.MaxDate = DateTime.Now;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPersonJoinBenefits = Person.FindByPersonJoinBenefitsId(personId);
                DataTable dtPerson = Person.FindById(personId);

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

        private void btnVizAdd_Click(object sender, EventArgs e)
        {
            new FrmSaveMember(personId, txtName.Text.Trim()).ShowDialog();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            FrmService service = new FrmService(personId);
            service.ShowDialog();

            if (service.id > 0)
            {
                LoadServices();
            }
        }

        private void AddDgvService(int id, string description, DateTime dateService)
        {
            int index = dgvService.Rows.Add();
            dgvService.Rows[index].Cells["ColEditService"].Value = Resources.Custom_Icon_Design_Flatastic_1_Edit_24;
            dgvService.Rows[index].Cells["ColDeleteService"].Value = Resources.trash_24_icon;
            dgvService.Rows[index].Cells["ColIdService"].Value = id.ToString();
            dgvService.Rows[index].Cells["ColDescriptionService"].Value = description;
            dgvService.Rows[index].Cells["ColDateService"].Value = dateService.ToShortDateString();
            dgvService.Rows[index].Height = 35;
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                ClearSelection(e, true);
                return;
            }

            if (dgvService.CurrentCell.ColumnIndex == 0)
            {
                EditService();
                indexRowPress = e.RowIndex;
            }
            else if (dgvService.CurrentCell.ColumnIndex == 1)
                DeleteService(e);

            ClearSelection(e, true);
        }

        private void DeleteService(DataGridViewCellEventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show($"Deseja mesmo excluir o atendimento da base de dados?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    Service.Delete(int.Parse(dgvService.CurrentRow.Cells["ColIdService"].Value.ToString()));
                    LoadServices();

                    //dgvService.Rows.Remove(dgvService.CurrentRow);
                }

                ClearSelection(e, true);

            }
            catch
            {
                MessageBox.Show("Houve um erro ao excluir. Feche o aplicativo e tente novamente. Caso o erro persista entre em contato com o suporte", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditService()
        {
            int id = int.Parse(dgvService.CurrentRow.Cells["ColIdService"].Value.ToString());
            string description = dgvService.CurrentRow.Cells["ColDescriptionService"].Value.ToString();
            DateTime dateService = DateTime.Parse(dgvService.CurrentRow.Cells["ColDateService"].Value.ToString());

            FrmService service = new FrmService(id, description, dateService, personId);
            service.ShowDialog();

            if (service.thereWasEdition)
            {
                dgvService.Rows[indexRowPress].Cells["ColDescriptionService"].Value = service.description;
                dgvService.Rows[indexRowPress].Cells["ColDateService"].Value = service.dateService.ToShortDateString();
            }
        }

        private void dgvService_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearSelection(e, true);
        }

        private void dgvService_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvService.Cursor = e.ColumnIndex == 0 || e.ColumnIndex == 1 ? Cursors.Hand : Cursors.Arrow;
        }

        private void cbRowsBenefits_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBenefitsReceived();
        }

        private void ndPageBenefits_ValueChanged(object sender, EventArgs e)
        {
            LoadBenefitsReceived();
        }

        private void ndPageService_ValueChanged(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void cbPageService_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void ClearFieldBenefits()
        {
            rtDescription.Clear();
            dtDateBenefits.Value = DateTime.Now;
            benefits_id = 0;
        }
    }
}