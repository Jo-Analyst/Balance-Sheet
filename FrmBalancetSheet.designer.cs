﻿using System.Windows.Forms;

namespace Balance_Sheet
{
    partial class FrmBalanceSheet
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBalanceSheet));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBackupAndRestore = new System.Windows.Forms.Button();
            this.btnPerson = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 52);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(517, 437);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnBackupAndRestore);
            this.panel1.Controls.Add(this.btnPerson);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Location = new System.Drawing.Point(549, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 436);
            this.panel1.TabIndex = 1;
            // 
            // btnBackupAndRestore
            // 
            this.btnBackupAndRestore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBackupAndRestore.BackColor = System.Drawing.Color.White;
            this.btnBackupAndRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackupAndRestore.FlatAppearance.BorderSize = 0;
            this.btnBackupAndRestore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBackupAndRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBackupAndRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupAndRestore.Image = ((System.Drawing.Image)(resources.GetObject("btnBackupAndRestore.Image")));
            this.btnBackupAndRestore.Location = new System.Drawing.Point(223, 189);
            this.btnBackupAndRestore.Margin = new System.Windows.Forms.Padding(6);
            this.btnBackupAndRestore.Name = "btnBackupAndRestore";
            this.btnBackupAndRestore.Size = new System.Drawing.Size(165, 97);
            this.btnBackupAndRestore.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnBackupAndRestore, "Backup e Restauração");
            this.btnBackupAndRestore.UseVisualStyleBackColor = false;
            this.btnBackupAndRestore.Click += new System.EventHandler(this.btnBackupAndRestore_Click);
            // 
            // btnPerson
            // 
            this.btnPerson.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPerson.BackColor = System.Drawing.Color.White;
            this.btnPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPerson.FlatAppearance.BorderSize = 0;
            this.btnPerson.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnPerson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnPerson.Image")));
            this.btnPerson.Location = new System.Drawing.Point(45, 57);
            this.btnPerson.Margin = new System.Windows.Forms.Padding(6);
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(343, 117);
            this.btnPerson.TabIndex = 5;
            this.btnPerson.Text = "Cadastro";
            this.btnPerson.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnPerson, "Cadastro");
            this.btnPerson.UseVisualStyleBackColor = false;
            this.btnPerson.Click += new System.EventHandler(this.btnPerson_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReport.BackColor = System.Drawing.Color.White;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.Location = new System.Drawing.Point(46, 189);
            this.btnReport.Margin = new System.Windows.Forms.Padding(6);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(165, 97);
            this.btnReport.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnReport, "Relatório");
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // FrmBalanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1010, 531);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmBalanceSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Balance Sheet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBalanceSheet_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Button btnReport;
        private ToolTip toolTip1;
        private Button btnPerson;
        private Button btnBackupAndRestore;
    }
}