using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace Balance_Sheet
{
    public partial class FrmReportByPerson : Form
    {
        public FrmReportByPerson()
        {
            InitializeComponent();
        }

        public FrmReportByPerson(DataTable dtPersonJoinBenefits, DataTable dtPerson)
        {
            InitializeComponent();
            //reportBenefitsTableAdapter.Fill(dtReport.ReportBenefits, person_id);            
            try
            {
                rpvPerson.LocalReport.DataSources.Clear();
                rpvPerson.LocalReport.DataSources.Add(new ReportDataSource("dtPenefitsByPersonId", dtPersonJoinBenefits));
                rpvPerson.LocalReport.DataSources.Add(new ReportDataSource("dtPersons", dtPerson));
                rpvPerson.LocalReport.SetParameters(ReportParameters.SetParametersReport(dtPerson));
                rpvPerson.RefreshReport();
            }
            catch
            {
                throw;
            }
        }

        private void FrmReportPerson_Load(object sender, EventArgs e)
        {
            this.rpvPerson.RefreshReport();
        }
    }
}
