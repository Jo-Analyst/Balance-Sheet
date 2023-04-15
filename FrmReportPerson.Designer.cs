namespace Balance_Sheet
{
    partial class FrmReportPerson
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtReport = new Balance_Sheet.dtReport();
            this.reportBenefitsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportBenefitsTableAdapter = new Balance_Sheet.dtReportTableAdapters.ReportBenefitsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBenefitsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "dtBenefits";
            reportDataSource2.Value = this.reportBenefitsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Balance_Sheet.ReportPerson.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtReport
            // 
            this.dtReport.DataSetName = "dtReport";
            this.dtReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportBenefitsBindingSource
            // 
            this.reportBenefitsBindingSource.DataMember = "ReportBenefits";
            this.reportBenefitsBindingSource.DataSource = this.dtReport;
            // 
            // reportBenefitsTableAdapter
            // 
            this.reportBenefitsTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReportPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReportPerson";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReportPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBenefitsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reportBenefitsBindingSource;
        private dtReport dtReport;
        private dtReportTableAdapters.ReportBenefitsTableAdapter reportBenefitsTableAdapter;
    }
}