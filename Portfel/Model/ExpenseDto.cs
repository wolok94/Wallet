using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Model
{
    public class ExpenseDto
    {
        public string Date { get; set; }
        public string ProductName { get; set; }
        public double Value { get; set; }

        public ExpenseDto(double value, string productName, string date)
        {
            Value = value;
            ProductName = productName;
            Date = date;
        }
    }
}
