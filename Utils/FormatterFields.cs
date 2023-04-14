using System;
using System.Windows.Forms;

namespace Balance_Sheet
{
    class FormatterFields
    {
        static public void FormatterDecimal(KeyPressEventArgs e, TextBox field)
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
            catch
            {
                throw;
            }
        }

        static public string AddDecimalPlaces(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : Convert.ToDouble(value).ToString("0.00");
        }

        static public bool IsFieldDecimal(string value)
        {
            bool isDecimal = false;
            if (decimal.TryParse(value, out decimal result))
            {
                isDecimal = true;
            }

            return isDecimal;
        }
    }
}