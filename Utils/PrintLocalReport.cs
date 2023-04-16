using Microsoft.Reporting.WinForms;
using System.Data;

namespace Balance_Sheet
{
    internal class PrintLocalReport
    {
        static public void PrintReportDirectlyFromPrinter(ReportDataSource rprtDTSource, DataTable person )
        {
            try
            {
                LocalReport localReport = new LocalReport();
                localReport.DataSources.Clear();
                localReport.DataSources.Add(rprtDTSource);
                //localReport.ReportPath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\ReportPerson.rdlc";
                //localReport.ReportPath = $"C:\\Users\\jojoc\\OneDrive\\Documentos\\Meus projetos\\balance-sheet\\ReportPerson.rdlc";
                localReport.ReportEmbeddedResource = $"Balance_Sheet.ReportPerson.rdlc";
                localReport.SetParameters(ReportParameters.SetParametersReport(person));
                localReport.PrintToPrinter();
            }
            catch
            {
                throw;
            }
        }
    }
}
