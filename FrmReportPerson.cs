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
        
        public FrmReportPerson(int person_id)
        {
            InitializeComponent();
            reportBenefitsTableAdapter.Fill(dtReport.ReportBenefits, person_id);
        }

        private void FrmReportPerson_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
