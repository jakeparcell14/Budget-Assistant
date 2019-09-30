using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Helper
{
    [Serializable]
    public class Expense
    {
        //name of expense
        public string Name { get; set; }

        //date of expense
        public DateTime Date { get; set; }

        //cost of expense in dollars
        public double Cost { get; set; }

        //constructor that takes no arguments
        public Expense()
        {
            Name = "";
            Date = new DateTime();
            Cost = 0.0;
        }

        //constructor that takes in arguments for name, date, and cost
        public Expense(string n, DateTime d, double c)
        {
            Name = n;
            Date = d;
            Cost = c;
        }
    }
}
