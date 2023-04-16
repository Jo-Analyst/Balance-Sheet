using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace Balance_Sheet
{
    public partial class FrmReportPerson : Form
    {
        public FrmReportPerson()
        {
            InitializeComponent();
        }

        public FrmReportPerson(ReportDataSource rprtDTSource, System.Data.DataTable dtPerson)
        {
            InitializeComponent();
            //reportBenefitsTableAdapter.Fill(dtReport.ReportBenefits, person_id);            
            try
            {
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rprtDTSource);
                reportViewer1.LocalReport.SetParameters(ReportParameters.SetParametersReport(dtPerson));
                reportViewer1.RefreshReport();
            }
            catch
            {
                throw;
            }
        }

        private void FrmReportPerson_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
