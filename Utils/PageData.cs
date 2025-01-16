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

        static private double quantity;

        static public int SetPageQuantityPersons()
        {
            quantity = Person.CountQuantityPersons();
            return CalculacalculateNumberOfPage();
        } 
        
        static public int SetPageQuantityBenefitsReceived()
        {
            quantity = BenefitsReceived.CountQuantityBenefitsReceived();
            return CalculacalculateNumberOfPage();
        }
        
        static public int SetPageQuantityServices()
        {
            quantity = Service.CountQuantityServices();
            return CalculacalculateNumberOfPage();
        }
        
        static public int SetPageQuantityMembers()
        {
            quantity = Member.CountQuantityMember();
            return CalculacalculateNumberOfPage();
        }

        static public int SetPageQuantityByNameOrAddressPersons(string text, string column)
        {
            quantity = Person.CountQuantityPersonsByNameOrAddress(text, column);
            return CalculacalculateNumberOfPage();
        }

        static private int CalculacalculateNumberOfPage()
        {
            double result = quantity / quantityRowsSelected;
            return (int)Math.Ceiling(result);
        }
    }
}
