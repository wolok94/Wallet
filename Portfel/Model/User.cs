using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Model
{
    public class User
    {
        public static int id = 0;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public int ExpenseId { get; set; }
        public double IncomeId { get; set; }
        public virtual List<Expense> Expenses { get; set; }


        public User(string firstName, string lastName, string eMail, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            Password = password;
            Id = ++id;
        }
        public User(string firstName, string lastName, string eMail, string password, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            Password = password;
            Id = id;
        }



    }
}
