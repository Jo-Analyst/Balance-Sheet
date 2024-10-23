using DataBase;
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
    public partial class FrmService : Form
    {    
        public int id { get; set; }
        public string description { get; set; }
        public DateTime dateService { get; set; }
        public int personId { get; set; }
        public bool thereWasEdition { get; set; }
        Service service = new Service();
        
        public FrmService(int personId)
        {
            InitializeComponent();

            this.personId = personId;
        } 
        
        public FrmService(int id, string description, DateTime dateService, int personId)
        {
            InitializeComponent();

            this.personId = personId;
            rtDescription.Text = description;
            dtDateService.Value = dateService;
            this.id = id;
        }


        private void btnADD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtDescription.Text))
            {
                MessageBox.Show("Faça a descrição do atendimento", "Balance Sheet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            service.id = id;
            service.description = rtDescription.Text;
            service.dateService = dtDateService.Value;  
            service.person_id = personId;

            service.Save();

            description = rtDescription.Text;
            dateService = dtDateService.Value;
            id = service.id;
            thereWasEdition = true;

           Close();
        }

        private void FrmService_Load(object sender, EventArgs e)
        {
           dtDateService.MaxDate = DateTime.Now;
        }
    }
}
