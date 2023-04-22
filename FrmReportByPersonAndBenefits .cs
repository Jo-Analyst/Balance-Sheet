using DataBase;
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

        void LocalReportSubReportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if(e.ReportPath == "ReportBenefits")
            {
                e.DataSources.Clear();
                e.DataSources.Add(new ReportDataSource("dtBenefits", BenefitsReceived.FindByPersonId(int.Parse(e.Parameters["person_id"].Values[0]))));
            }

            if(e.ReportPath == "ReportCountBenefitsByDescription")
            {
                e.DataSources.Clear();
                e.DataSources.Add(new ReportDataSource("dtCountBenefits", BenefitsReceived.CountBenefitsByPersonId(int.Parse(e.Parameters["person_id"].Values[0]))));
            }
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
                reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReportSubReportProcessing);
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
