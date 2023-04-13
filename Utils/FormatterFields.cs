using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balance_Sheet
{
    class FormatterFields
    {
       static public void formatterDecimal(KeyPressEventArgs e, TextBox field)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (e.KeyChar != ((int)Keys.Back))
                        if (e.KeyChar != ',')
                            e.Handled = true;
                        else if (field.Text.IndexOf(',') > 0)
                            e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
