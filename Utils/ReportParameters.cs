using Microsoft.Reporting.WinForms;
using System.Data;

namespace Balance_Sheet
{
    public class ReportParameters
    {

        static public ReportParameterCollection SetParametersReport(DataTable data)
        {
            ReportParameterCollection rpc = new ReportParameterCollection
            {
                new ReportParameter("name", data.Rows[0]["name"].ToString()),
                new ReportParameter("CPF", !string.IsNullOrEmpty(data.Rows[0]["CPF"].ToString()) ? data.Rows[0]["CPF"].ToString() : "***"),
                new ReportParameter("RG", !string.IsNullOrEmpty(data.Rows[0]["RG"].ToString()) ? data.Rows[0]["RG"].ToString() : "***"),
                new ReportParameter("address", !string.IsNullOrEmpty(data.Rows[0]["address"].ToString()) ? data.Rows[0]["address"].ToString() : "***"),
                new ReportParameter("number", !string.IsNullOrEmpty(data.Rows[0]["number_address"].ToString()) ? data.Rows[0]["number_address"].ToString() : "***"),
                new ReportParameter("phone", !string.IsNullOrEmpty(data.Rows[0]["phone"].ToString()) ? data.Rows[0]["phone"].ToString() : "***"),
                new ReportParameter("income", !string.IsNullOrEmpty(data.Rows[0]["income"].ToString()) ? data.Rows[0]["income"].ToString() : "***"),
                new ReportParameter("help", !string.IsNullOrEmpty(data.Rows[0]["help"].ToString()) ? data.Rows[0]["help"].ToString() : "***"),
                new ReportParameter("number_of_members", !string.IsNullOrEmpty(data.Rows[0]["number_of_members"].ToString()) ? data.Rows[0]["number_of_members"].ToString() : "***")
            };

            return rpc;
        }


    }
}
