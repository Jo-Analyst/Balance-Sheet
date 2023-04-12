using DataBase;
using System;
using System.Data;
using System.Windows.Forms;

namespace CourseManagement
{
    public partial class FrmSavePerson : Form
    {

        public bool studentWasSaved { get; set; }
        Student student = new Student();
        Class @class = new Class();
        int class_id;

        public FrmSavePerson()
        {
            InitializeComponent();
        }

        public FrmSavePerson(int id, string name, string shift, string _class, string gender)
        {
            InitializeComponent();
            student._id = id;
            txtName.Text = name;
            cbShift.Text = shift;
            LoadCbClass();
            cbClass.Text = _class;
            if (gender == "F")
                rbFeminine.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Preencha o nome do(a) aluno(a)", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cbShift.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o turno", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cbClass.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione a turma", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                student._name = txtName.Text.Trim();
                student._class_id = class_id;
                student._gender = rbMasculine.Checked ? "M" : "F";
                student.Save();
                studentWasSaved = true;

                if (student._id == 0)
                {
                    DialogResult dr = MessageBox.Show("Deseja incluir mais um novo aluno?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        txtName.Clear();
                        cbClass.SelectedIndex = -1;
                        cbShift.SelectedIndex = -1;
                        rbMasculine.Checked = true;
                        txtName.Focus();
                        return;
                    }
                }

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

        DataTable dtClass;
        private void LoadCbClass()
        {
            cbClass.Items.Clear();
            dtClass = @class.FindByClassForShift(cbShift.Text);
            foreach (DataRow dt in dtClass.Rows)
            {
                cbClass.Items.Add(dt["name"]);
            }
        }

        private void cbClass_Click(object sender, EventArgs e)
        {
            if (cbShift.SelectedIndex > -1 && cbClass.Items.Count == 0)
            {
                var saveClass = new FrmSaveClass(cbShift.Text);
                saveClass.ShowDialog();
                if (saveClass.classWasSaved)
                {
                    LoadCbClass();
                    if (!string.IsNullOrEmpty(saveClass.nameClass))
                        cbClass.Text = saveClass.nameClass;
                }
            }
        }

        private void cbShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCbClass();
            cbClass.SelectedIndex = dtClass.Rows.Count > 0 ? 0 : -1;
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                class_id = int.Parse(@class.FindByClass(cbClass.Text).Rows[0]["id"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}