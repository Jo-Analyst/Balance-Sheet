using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace Balance_Sheet
{
    public partial class FrmReportByPersonAndBenefits : Form
    {
        public FrmReportByPersonAndBenefits()
        {
            InitializeComponent();
        }

        public FrmReportByPersonAndBenefits(DataTable dtPerson)
        {
            InitializeComponent();

            try
            {
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtBenefitsByPersonId", dtPerson));
                reportViewer1.LocalReport.SetParameters(ReportParameters.SetParametersReportHeader());
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
