using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Model
{
    public class Expense
    {
        public static int id = 0;
        public int Id { get; set; }
        public double Value { get; set; }
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public virtual User user { get; set; }

        public Expense(double value, string productName, DateTime date )
        {
            Value = value;
            ProductName = productName;
            Date = date;
            Id = ++id;
        }
 
    }
}
