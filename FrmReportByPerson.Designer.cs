namespace Balance_Sheet
{
    partial class FrmReportByPerson
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportByPerson));
            this.rpvPerson = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.rpvPerson.BackColor = System.Drawing.Color.Silver;
            this.rpvPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "dtBenefits";
            reportDataSource2.Value = null;
            this.rpvPerson.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvPerson.LocalReport.ReportEmbeddedResource = "Balance_Sheet.ReportPerson.rdlc";
            this.rpvPerson.Location = new System.Drawing.Point(0, 0);
            this.rpvPerson.Name = "reportViewer1";
            this.rpvPerson.ServerReport.BearerToken = null;
            this.rpvPerson.Size = new System.Drawing.Size(800, 450);
            this.rpvPerson.TabIndex = 0;
            // 
            // FrmReportPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvPerson);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReportPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReportPerson_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPerson;
    }
}