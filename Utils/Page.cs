using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balance_Sheet.Utils
{
    internal class PageData
    {
        static public double quantityRowsSelected { get; set; }

        static private double quantityPersons;

        static public int SetPageQuantityPersons()
        {
            quantityPersons = Person.CountQuantityPersons();
            return CalculacalculateNumberOfPage();
        } 
        
        static public int SetPageQuantityBenefitsReceived()
        {
            quantityPersons = BenefitsReceived.CountQuantityPersonsBenefitsReceived();
            return CalculacalculateNumberOfPage();
        }

        static public int SetPageQuantityByNameOrAddressPersons(string text, string column)
        {
            quantityPersons = Person.CountQuantityPersonsByNameOrAddress(text, column);
            return CalculacalculateNumberOfPage();
        }

        static private int CalculacalculateNumberOfPage()
        {
            double result = quantityPersons / quantityRowsSelected;
            return (int)Math.Ceiling(result);
        }
    }
}
