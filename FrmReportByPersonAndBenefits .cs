using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace Balance_Sheet
{
    public partial class FrmReportByPersonAndBenefits : Form
    {
        public FrmReportByPersonAndBenefits()
        {
            InitializeComponent();
        }

        public FrmReportByPersonAndBenefits(ReportDataSource rprtDTSource, System.Data.DataTable dtPerson)
        {
            InitializeComponent();

            try
            {
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rprtDTSource);
               
                reportViewer1.RefreshReport();
            }
            catch
            {
                throw;
            }
        }

        private void FrmReportByPersonAndBenefits_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
