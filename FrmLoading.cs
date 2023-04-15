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
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (pbLoading.Value < 100)
            {
                pbLoading.Value += 5;
            }
            else
            {
                timer.Stop();
                this.Visible = false;
                try
                {
                    if (!DB.ExistsDataBase())
                    {
                        DB.CreateDatabase();
                        DB.CreateTables();
                    }

                    new FrmBalanceSheet().ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Houve um problema no servidor. Tente novamente. Caso o erro persista contate o suporte.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }
    }
}
