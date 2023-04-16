using Microsoft.Reporting.WinForms;

namespace Balance_Sheet
{
    internal class PrintLocalReport
    {
        static public void PrintReportDirectlyFromPrinter(ReportDataSource rprtDTSource, System.Data.DataTable person)
        {
            try
            {
                LocalReport localReport = new LocalReport();
                localReport.DataSources.Clear();
                localReport.DataSources.Add(rprtDTSource);
                //localReport.ReportPath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\ReportPerson.rdlc";
                localReport.ReportPath = $"C:\\Users\\jojoc\\OneDrive\\Documentos\\Meus projetos\\balance-sheet\\ReportPerson.rdlc";
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
