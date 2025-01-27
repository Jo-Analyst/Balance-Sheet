﻿namespace Balance_Sheet
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
            this.rbAddress = new System.Windows.Forms.RadioButton();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtField = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbRows = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ndPage = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNumberAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIncome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHelp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNumberOfMembers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantityBenefits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndPage)).BeginInit();
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
            this.ColBirth,
            this.ColAddress,
            this.ColNumberAddress,
            this.ColPhone,
            this.ColIncome,
            this.ColHelp,
            this.ColNumberOfMembers,
            this.ColQuantityBenefits,
            this.Column1});
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
            this.rbAddress.CheckedChanged += new System.EventHandler(this.rbAddress_CheckedChanged);
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
            this.rbName.CheckedChanged += new System.EventHandler(this.rbName_CheckedChanged);
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
            this.txtField.TextChanged += new System.EventHandler(this.txtField_TextChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Enabled = false;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(880, 472);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(186, 50);
            this.btnPrint.TabIndex = 35;
            this.btnPrint.Text = "Imprimir";
            this.toolTip.SetToolTip(this.btnPrint, "Imprimir - [CTRL + P]");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cbRows
            // 
            this.cbRows.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRows.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbRows.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "50"});
            this.cbRows.Location = new System.Drawing.Point(532, 494);
            this.cbRows.Name = "cbRows";
            this.cbRows.Size = new System.Drawing.Size(121, 28);
            this.cbRows.TabIndex = 36;
            this.cbRows.TabStop = false;
            this.cbRows.SelectedIndexChanged += new System.EventHandler(this.cbRows_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(528, 472);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "Linhas";
            // 
            // ndPage
            // 
            this.ndPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ndPage.Location = new System.Drawing.Point(438, 496);
            this.ndPage.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.ndPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ndPage.Name = "ndPage";
            this.ndPage.ReadOnly = true;
            this.ndPage.Size = new System.Drawing.Size(84, 26);
            this.ndPage.TabIndex = 38;
            this.ndPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ndPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ndPage.ValueChanged += new System.EventHandler(this.ndPage_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(434, 472);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Página";
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
            this.ColCPF.MinimumWidth = 6;
            this.ColCPF.Name = "ColCPF";
            this.ColCPF.ReadOnly = true;
            this.ColCPF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCPF.Width = 46;
            // 
            // ColRG
            // 
            this.ColRG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColRG.HeaderText = "RG";
            this.ColRG.MinimumWidth = 6;
            this.ColRG.Name = "ColRG";
            this.ColRG.ReadOnly = true;
            this.ColRG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColRG.Width = 40;
            // 
            // ColBirth
            // 
            this.ColBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColBirth.HeaderText = "Data de Nascimento";
            this.ColBirth.Name = "ColBirth";
            this.ColBirth.ReadOnly = true;
            this.ColBirth.Width = 179;
            // 
            // ColAddress
            // 
            this.ColAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColAddress.HeaderText = "Endereço";
            this.ColAddress.MinimumWidth = 6;
            this.ColAddress.Name = "ColAddress";
            this.ColAddress.ReadOnly = true;
            this.ColAddress.Width = 103;
            // 
            // ColNumberAddress
            // 
            this.ColNumberAddress.HeaderText = "Número";
            this.ColNumberAddress.MinimumWidth = 6;
            this.ColNumberAddress.Name = "ColNumberAddress";
            this.ColNumberAddress.ReadOnly = true;
            this.ColNumberAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColNumberAddress.Width = 125;
            // 
            // ColPhone
            // 
            this.ColPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColPhone.HeaderText = "Tel/Cel";
            this.ColPhone.MinimumWidth = 6;
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
            this.ColIncome.MinimumWidth = 6;
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
            this.ColHelp.MinimumWidth = 6;
            this.ColHelp.Name = "ColHelp";
            this.ColHelp.ReadOnly = true;
            this.ColHelp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColHelp.Width = 109;
            // 
            // ColNumberOfMembers
            // 
            this.ColNumberOfMembers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColNumberOfMembers.HeaderText = "Composição Familiar";
            this.ColNumberOfMembers.MinimumWidth = 6;
            this.ColNumberOfMembers.Name = "ColNumberOfMembers";
            this.ColNumberOfMembers.ReadOnly = true;
            this.ColNumberOfMembers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColNumberOfMembers.Width = 162;
            // 
            // ColQuantityBenefits
            // 
            this.ColQuantityBenefits.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColQuantityBenefits.HeaderText = "Quantidade de Benefícios";
            this.ColQuantityBenefits.MinimumWidth = 45;
            this.ColQuantityBenefits.Name = "ColQuantityBenefits";
            this.ColQuantityBenefits.ReadOnly = true;
            this.ColQuantityBenefits.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColQuantityBenefits.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColQuantityBenefits.Width = 198;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "id";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 125;
            // 
            // FrmReportBalancete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1075, 530);
            this.Controls.Add(this.cbRows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ndPage);
            this.Controls.Add(this.label2);
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
            this.Load += new System.EventHandler(this.FrmReportBalancete_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReportBalancete_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPerson;
        private System.Windows.Forms.RadioButton rbAddress;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtField;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox cbRows;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ndPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumberAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIncome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumberOfMembers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantityBenefits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}