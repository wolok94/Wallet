using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Model
{
    public class Expense
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int ProductId { get; set; }
        public DateTime date { get; set; }
        public virtual User user { get; set; }
        public virtual Product product { get; set; }
    }
}
