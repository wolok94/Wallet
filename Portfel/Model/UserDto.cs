using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Model
{
    public class UserDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }

        public UserDto(string firstName, string lastName, string eMail, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            Password = password;

        }
    }
}
