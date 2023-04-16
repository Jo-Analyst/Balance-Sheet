using DataBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balance_Sheet
{
    public partial class FrmReportPerson : Form
    {
        public FrmReportPerson()
        {
            InitializeComponent();
        }
        
        public FrmReportPerson(ReportDataSource rprtDTSource)
        {
            InitializeComponent();
            //reportBenefitsTableAdapter.Fill(dtReport.ReportBenefits, person_id);            
            reportViewer1.LocalReport.DataSources.Clear();           
            reportViewer1.LocalReport.DataSources.Add(rprtDTSource);
            reportViewer1.RefreshReport();
        }

        private void FrmReportPerson_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
