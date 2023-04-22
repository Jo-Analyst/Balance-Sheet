using DataBase;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace Balance_Sheet
{
    internal class PrintLocalReport
    {

        static private void LocalSubReportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if(e.ReportPath == "ReportBenefits")
            {
                e.DataSources.Clear();
                e.DataSources.Add(new ReportDataSource("dtBenefits", BenefitsReceived.FindByPersonId(int.Parse(e.Parameters["person_id"].Values[0]))));
            }
            else if(e.ReportPath == "ReportCountBenefitsByDescription")
            {
                e.DataSources.Clear();
                e.DataSources.Add(new ReportDataSource("dtCountBenefits", BenefitsReceived.CountBenefitsByPersonId(int.Parse(e.Parameters["person_id"].Values[0]))));
            }
        }

        static public void PrintReportDirectlyFromPrinter(DataTable dtPersonJoinBenefits , DataTable dt = null) 
        {            
            try
            {
                LocalReport localReport = new LocalReport();
                localReport.ReportEmbeddedResource = dt == null ? "Balance_Sheet.ReportPersonAndBenefits.rdlc" : "Balance_Sheet.ReportPerson.rdlc";
                localReport.DataSources.Clear();
               
                if(dt == null)
                {
                    localReport.DataSources.Add(new ReportDataSource("dtPersons", dtPersonJoinBenefits));
                }
                else
                {
                    localReport.DataSources.Add(new ReportDataSource("dtPersons", dt));
                    localReport.DataSources.Add(new ReportDataSource("dtBenefitsByPersonId", dtPersonJoinBenefits));
                }

                localReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalSubReportProcessing);

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
