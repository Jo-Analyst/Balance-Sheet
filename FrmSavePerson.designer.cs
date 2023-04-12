namespace CourseManagement
{
    partial class FrmSavePerson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSavePerson));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbFeminine = new System.Windows.Forms.RadioButton();
            this.rbMasculine = new System.Windows.Forms.RadioButton();
            this.cbShift = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(14, 45);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(592, 26);
            this.txtName.TabIndex = 0;
            // 
            // btnsave
            // 
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(388, 168);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(220, 46);
            this.btnsave.TabIndex = 2;
            this.btnsave.TabStop = false;
            this.btnsave.Text = "Salvar";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(205, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Turma";
            // 
            // cbClass
            // 
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(209, 116);
            this.cbClass.Margin = new System.Windows.Forms.Padding(4);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(186, 28);
            this.cbClass.TabIndex = 2;
            this.cbClass.SelectedIndexChanged += new System.EventHandler(this.cbClass_SelectedIndexChanged);
            this.cbClass.Click += new System.EventHandler(this.cbClass_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gênero";
            // 
            // rbFeminine
            // 
            this.rbFeminine.AutoSize = true;
            this.rbFeminine.ForeColor = System.Drawing.Color.White;
            this.rbFeminine.Location = new System.Drawing.Point(154, 184);
            this.rbFeminine.Margin = new System.Windows.Forms.Padding(4);
            this.rbFeminine.Name = "rbFeminine";
            this.rbFeminine.Size = new System.Drawing.Size(92, 24);
            this.rbFeminine.TabIndex = 4;
            this.rbFeminine.Text = "Feminino";
            this.rbFeminine.UseVisualStyleBackColor = true;
            // 
            // rbMasculine
            // 
            this.rbMasculine.AutoSize = true;
            this.rbMasculine.Checked = true;
            this.rbMasculine.ForeColor = System.Drawing.Color.White;
            this.rbMasculine.Location = new System.Drawing.Point(19, 184);
            this.rbMasculine.Margin = new System.Windows.Forms.Padding(4);
            this.rbMasculine.Name = "rbMasculine";
            this.rbMasculine.Size = new System.Drawing.Size(98, 24);
            this.rbMasculine.TabIndex = 3;
            this.rbMasculine.TabStop = true;
            this.rbMasculine.Text = "Masculino";
            this.rbMasculine.UseVisualStyleBackColor = true;
            // 
            // cbShift
            // 
            this.cbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbShift.FormattingEnabled = true;
            this.cbShift.Items.AddRange(new object[] {
            "Manhã",
            "Tarde",
            "Noite"});
            this.cbShift.Location = new System.Drawing.Point(14, 116);
            this.cbShift.Margin = new System.Windows.Forms.Padding(4);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(186, 28);
            this.cbShift.TabIndex = 1;
            this.cbShift.SelectedIndexChanged += new System.EventHandler(this.cbShift_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(11, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Turno";
            // 
            // FrmSavePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(635, 232);
            this.Controls.Add(this.cbShift);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbFeminine);
            this.Controls.Add(this.rbMasculine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSavePerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro do responsável Familiar";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaveStudent_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbFeminine;
        private System.Windows.Forms.RadioButton rbMasculine;
        private System.Windows.Forms.ComboBox cbShift;
        private System.Windows.Forms.Label label4;
    }
}