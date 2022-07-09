using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Model
{
    public class Income
    {
        public static int id = 1;
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        public Income(double value, DateTime date)
        {

                Id = ++id;

            
            Value = value;
            Date = date;
        }
    }
}
