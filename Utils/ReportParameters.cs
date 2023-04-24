using Microsoft.Reporting.WinForms;
using Possible_Benefits.Properties;

namespace Possible_Benefits
{
    public class ReportParameters
    {

        static public ReportParameterCollection SetParametersReportHeader()
        {
            ReportParameterCollection rpc = new ReportParameterCollection
            {
                new ReportParameter("name_institution", Settings.Default["name"].ToString()),
               new ReportParameter("address_institution", Settings.Default["address"].ToString()),
               new ReportParameter("number_institution", Settings.Default["number"].ToString()),
               new ReportParameter("district_institution", Settings.Default["district"].ToString()),
               new ReportParameter("city_institution", Settings.Default["city"].ToString()),
               new ReportParameter("cep_institution", Settings.Default["cep"].ToString()),
               new ReportParameter("state_institution", Settings.Default["state"].ToString()),
               new ReportParameter("phone_institution", Settings.Default["phone"].ToString()),
               new ReportParameter("email_institution", Settings.Default["email"].ToString())
            };

            return rpc;
        }
    }
}
