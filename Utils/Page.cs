using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Balance_Sheet.Utils
{
    internal class Page
    {
        public double quantityRowsSelected {  get; set; }

        private double quantityPersons;

        public int SetPageQuantity()
        {
            quantityPersons = Person.CountQuantityPersons();
            return CalculacalculateNumberOfPage();
        } 
        
        public int SetPageQuantityByNameOrAddress(string text, string column)
        {
            quantityPersons = Person.CountQuantityPersonsByNameOrAddress(text, column);
            return CalculacalculateNumberOfPage();
        }

        private int CalculacalculateNumberOfPage()
        {
            double result = quantityPersons / quantityRowsSelected;
            return (int)Math.Ceiling(result);
        }
    }
}
