using DataBase;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace Balance_Sheet
{
    internal class PrintLocalReport
    {
        static public void PrintReportDirectlyFromPrinter(DataTable dtPersonJoinBenefits, DataTable dtPerson, bool reportCompleted = false)
        {
            try
            {
                LocalReport localReport = new LocalReport();
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dtBenefitsByPersonId", dtPersonJoinBenefits));
                if (dtPerson != null)
                {
                    localReport.DataSources.Add(new ReportDataSource("dtPersons", dtPerson));
                }
                //localReport.ReportPath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\ReportPerson.rdlc";
                //localReport.ReportPath = $"C:\\Users\\jojoc\\OneDrive\\Documentos\\Meus projetos\\balance-sheet\\ReportPerson.rdlc";
                localReport.ReportEmbeddedResource = reportCompleted ? "Balance_Sheet.ReportPersonAndBenefits.rdlc" : "Balance_Sheet.ReportPerson.rdlc";

                if (dtPerson != null)
                    localReport.SetParameters(ReportParameters.SetParametersReport(dtPerson));
                    
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
