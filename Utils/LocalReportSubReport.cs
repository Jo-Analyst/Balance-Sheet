using DataBase;
using Microsoft.Reporting.WinForms;

namespace Balance_Sheet
{
    internal class LocalReportSubReport
    {
        static public void Processing(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Clear();

            if (e.ReportPath == "ReportBenefits")
            {
                e.DataSources.Add(new ReportDataSource("dtBenefits", BenefitsReceived.FindByPersonId(int.Parse(e.Parameters["person_id"].Values[0]))));
            }
            else if (e.ReportPath == "ReportCountBenefitsByDescription")
            {
                e.DataSources.Add(new ReportDataSource("dtCountBenefits", BenefitsReceived.CountBenefitsByPersonId(int.Parse(e.Parameters["person_id"].Values[0]))));
            }
            else if (e.ReportPath == "ReportTotalBenefits")
            {
                e.DataSources.Add(new ReportDataSource("dtTotalBenefits", BenefitsReceived.ShowTotalBenefits(int.Parse(e.Parameters["person_id"].Values[0]))));
            }
        }
    }
}
