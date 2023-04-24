using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace Possible_Benefits
{
    public partial class FrmReportByPersonAndBenefits : Form
    {
        public FrmReportByPersonAndBenefits()
        {
            InitializeComponent();
        }

        DataTable dtPersons;
        public FrmReportByPersonAndBenefits(DataTable dtPersons)
        {
            InitializeComponent();
            this.dtPersons = dtPersons;

        }

        private void FrmReportByPersonAndBenefits_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReportSubReport.Processing);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtPersons", dtPersons));
                //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtBenefitsReceived", dtCountBenefits));
                reportViewer1.LocalReport.SetParameters(ReportParameters.SetParametersReportHeader());
                reportViewer1.RefreshReport();
            }
            catch
            {
                throw;
            }

            this.reportViewer1.RefreshReport();
        }
    }
}
