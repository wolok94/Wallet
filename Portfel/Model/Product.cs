using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExpenseId { get; set; }
        public  Expense Expense { get; set; }

    }
}
