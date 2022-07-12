using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Model
{
    public class Balance
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int UserId { get; set; }
        public static int id = 0;

        public Balance(double value, int userId)
        {
            Value = value;
            UserId = userId;
            Id = ++id;
        }
    }
}
