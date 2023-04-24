using Microsoft.Reporting.WinForms;
using System.Data;

namespace Balance_Sheet
{
    internal class PrintLocalReport
    {

        static public void PrintReportDirectlyFromPrinter(DataTable dtPersonJoinBenefits, DataTable dt = null)
        {
            try
            {
                LocalReport localReport = new LocalReport();
                localReport.ReportEmbeddedResource = dt == null ? "Balance_Sheet.ReportPersonAndBenefits.rdlc" : "Balance_Sheet.ReportPerson.rdlc";
                localReport.DataSources.Clear();

                if (dt == null)
                {
                    localReport.DataSources.Add(new ReportDataSource("dtPersons", dtPersonJoinBenefits));
                }
                else
                {
                    localReport.DataSources.Add(new ReportDataSource("dtPersons", dt));
                    localReport.DataSources.Add(new ReportDataSource("dtBenefitsByPersonId", dtPersonJoinBenefits));
                }

                localReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReportSubReport.Processing);

                localReport.SetParameters(ReportParameters.SetParametersReportHeader());

                localReport.PrintToPrinter();
            }
            catch
            {
                throw;
            }
        }
    }
}
