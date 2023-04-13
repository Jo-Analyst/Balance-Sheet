using System;
using System.Windows.Forms;

namespace CourseManagement
{
    public partial class FrmPerson : Form
    {
        int studentId;
        public FrmPerson()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new FrmSavePerson().ShowDialog();
            LoadDataStudent();
        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            //LoadDataStudent();
        }

        private void LoadDataStudent()
        {
            //try
            //{
            //    dgvStudent.Rows.Clear();
            //    string option = rbName.Checked ? "nome" : "class";
            //    DataTable dtStudent = string.IsNullOrWhiteSpace(txtField.Text)
            //        ? student.FindAll()
            //        : student.FindByName(txtField.Text, option);

            //    foreach (DataRow dr in dtStudent.Rows)
            //    {
            //        int index = dgvStudent.Rows.Add();
            //        dgvStudent.Rows[index].Cells["id"].Value = dr["id"].ToString();
            //        dgvStudent.Rows[index].Cells["name"].Value = dr["name"].ToString();
            //        dgvStudent.Rows[index].Cells["classStudent"].Value = dr["class"].ToString();
            //        dgvStudent.Rows[index].Cells["shift"].Value = dr["shift"].ToString();
            //        dgvStudent.Rows[index].Cells["classId"].Value = dr["class_id"].ToString();
            //        dgvStudent.Rows[index].Cells["gender"].Value = dr["gender"].ToString();
            //        dgvStudent.Rows[index].Cells["created_at"].Value = dr["created_at"].ToString();
            //        dgvStudent.Rows[index].Cells["updated_at"].Value = dr["updated_at"].ToString();
            //        dgvStudent.Rows[index].Height = 35;
            //    }

            //    dgvStudent.ClearSelection();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (studentId == 0)
            {
                MessageBox.Show("Selecione o dado do aluno que deseja editar", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //var saveStudent = new FrmSavePerson(int.Parse(dgvStudent.CurrentRow.Cells["id"].Value.ToString()), dgvStudent.CurrentRow.Cells["name"].Value.ToString(), dgvStudent.CurrentRow.Cells["shift"].Value.ToString(), dgvStudent.CurrentRow.Cells["classStudent"].Value.ToString(), dgvStudent.CurrentRow.Cells["gender"].Value.ToString());
            //saveStudent.ShowDialog();

            //studentId = 0;
            //dgvStudent.ClearSelection();
            //if (saveStudent.studentWasSaved)
            //    LoadDataStudent();
        }

        string genderStudent, nameStudent;
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                studentId = int.Parse(dgvStudent.Rows[e.RowIndex].Cells["id"].Value.ToString());
                nameStudent = dgvStudent.Rows[e.RowIndex].Cells["name"].Value.ToString();
                genderStudent = dgvStudent.Rows[e.RowIndex].Cells["gender"].Value.ToString();
            }
        }

        private void txtField_TextChanged(object sender, EventArgs e)
        {
            LoadDataStudent();
        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataStudent();
        }

        private void rbClass_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataStudent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (studentId == 0)
            //{
            //    MessageBox.Show("Selecione o dado do aluno que deseja excluir", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //string article = genderStudent == "M" ? "o" : "a";
            //string studentMorF = genderStudent == "M" ? "aluno" : "aluna";

            //DialogResult dr = MessageBox.Show($"Deseja mesmo excluir {article} {studentMorF} {nameStudent} da base de dados?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (dr == DialogResult.Yes)
            //{
            //    student._id = studentId;
            //    student.Delete();
            //    LoadDataStudent();
            //}

            //studentId = 0;
            //dgvStudent.ClearSelection();

        }
    }
}
