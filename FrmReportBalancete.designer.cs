namespace Balance_Sheet
{
    partial class FrmReportBalancete
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportBalancete));
            this.dgvPerson = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNumberAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIncome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHelp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNumberOfMembers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDateBenefits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbAddress = new System.Windows.Forms.RadioButton();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtField = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPerson
            // 
            this.dgvPerson.AllowUserToAddRows = false;
            this.dgvPerson.AllowUserToDeleteRows = false;
            this.dgvPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPerson.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPerson.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPerson.ColumnHeadersHeight = 40;
            this.dgvPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColCPF,
            this.ColRG,
            this.ColAddress,
            this.ColNumberAddress,
            this.ColPhone,
            this.ColIncome,
            this.ColHelp,
            this.ColNumberOfMembers,
            this.ColDescription,
            this.ColDateBenefits});
            this.dgvPerson.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvPerson.EnableHeadersVisualStyles = false;
            this.dgvPerson.Location = new System.Drawing.Point(17, 79);
            this.dgvPerson.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPerson.Name = "dgvPerson";
            this.dgvPerson.ReadOnly = true;
            this.dgvPerson.RowHeadersVisible = false;
            this.dgvPerson.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPerson.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPerson.Size = new System.Drawing.Size(1049, 385);
            this.dgvPerson.TabIndex = 2;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColName.DataPropertyName = "name";
            this.ColName.HeaderText = "Nome";
            this.ColName.MinimumWidth = 6;
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.Width = 76;
            // 
            // ColCPF
            // 
            this.ColCPF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColCPF.HeaderText = "CPF";
            this.ColCPF.Name = "ColCPF";
            this.ColCPF.ReadOnly = true;
            this.ColCPF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCPF.Width = 46;
            // 
            // ColRG
            // 
            this.ColRG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColRG.HeaderText = "RG";
            this.ColRG.Name = "ColRG";
            this.ColRG.ReadOnly = true;
            this.ColRG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColRG.Width = 40;
            // 
            // ColAddress
            // 
            this.ColAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColAddress.HeaderText = "Endereço";
            this.ColAddress.Name = "ColAddress";
            this.ColAddress.ReadOnly = true;
            this.ColAddress.Width = 103;
            // 
            // ColNumberAddress
            // 
            this.ColNumberAddress.HeaderText = "Número";
            this.ColNumberAddress.Name = "ColNumberAddress";
            this.ColNumberAddress.ReadOnly = true;
            this.ColNumberAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColPhone
            // 
            this.ColPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColPhone.HeaderText = "Tel/Cel";
            this.ColPhone.Name = "ColPhone";
            this.ColPhone.ReadOnly = true;
            this.ColPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPhone.Width = 63;
            // 
            // ColIncome
            // 
            this.ColIncome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.ColIncome.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColIncome.HeaderText = "Renda";
            this.ColIncome.Name = "ColIncome";
            this.ColIncome.ReadOnly = true;
            this.ColIncome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColIncome.Width = 63;
            // 
            // ColHelp
            // 
            this.ColHelp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.ColHelp.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColHelp.HeaderText = "Bolsa Família";
            this.ColHelp.Name = "ColHelp";
            this.ColHelp.ReadOnly = true;
            this.ColHelp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColHelp.Width = 109;
            // 
            // ColNumberOfMembers
            // 
            this.ColNumberOfMembers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColNumberOfMembers.HeaderText = "Composição Familiar";
            this.ColNumberOfMembers.Name = "ColNumberOfMembers";
            this.ColNumberOfMembers.ReadOnly = true;
            this.ColNumberOfMembers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColNumberOfMembers.Width = 162;
            // 
            // ColDescription
            // 
            this.ColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColDescription.HeaderText = "Benefícios recebidos";
            this.ColDescription.MinimumWidth = 45;
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            this.ColDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDescription.Width = 162;
            // 
            // ColDateBenefits
            // 
            this.ColDateBenefits.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColDateBenefits.HeaderText = "Data do benefício";
            this.ColDateBenefits.MinimumWidth = 45;
            this.ColDateBenefits.Name = "ColDateBenefits";
            this.ColDateBenefits.ReadOnly = true;
            this.ColDateBenefits.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDateBenefits.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDateBenefits.Width = 140;
            // 
            // rbAddress
            // 
            this.rbAddress.AutoSize = true;
            this.rbAddress.ForeColor = System.Drawing.Color.White;
            this.rbAddress.Location = new System.Drawing.Point(252, 13);
            this.rbAddress.Margin = new System.Windows.Forms.Padding(4);
            this.rbAddress.Name = "rbAddress";
            this.rbAddress.Size = new System.Drawing.Size(96, 24);
            this.rbAddress.TabIndex = 11;
            this.rbAddress.Text = "Endereço";
            this.rbAddress.UseVisualStyleBackColor = true;
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Checked = true;
            this.rbName.ForeColor = System.Drawing.Color.White;
            this.rbName.Location = new System.Drawing.Point(156, 13);
            this.rbName.Margin = new System.Windows.Forms.Padding(4);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(69, 24);
            this.rbName.TabIndex = 10;
            this.rbName.TabStop = true;
            this.rbName.Text = "Nome";
            this.rbName.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Procurar por: ";
            // 
            // txtField
            // 
            this.txtField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtField.Location = new System.Drawing.Point(16, 45);
            this.txtField.Margin = new System.Windows.Forms.Padding(4);
            this.txtField.MaxLength = 100;
            this.txtField.Name = "txtField";
            this.txtField.Size = new System.Drawing.Size(1046, 26);
            this.txtField.TabIndex = 8;
            this.txtField.TextChanged += new System.EventHandler(this.txtField_TextChanged_1);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Enabled = false;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(916, 472);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(150, 50);
            this.btnPrint.TabIndex = 35;
            this.btnPrint.Text = "Imprimir";
            this.toolTip.SetToolTip(this.btnPrint, "Imprimir - [CTRL + P]");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmReportBalancete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1075, 530);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rbAddress);
            this.Controls.Add(this.rbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtField);
            this.Controls.Add(this.dgvPerson);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmReportBalancete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmStudent_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReportBalancete_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumberAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIncome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumberOfMembers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDateBenefits;
        private System.Windows.Forms.RadioButton rbAddress;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtField;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ToolTip toolTip;
    }
}