using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfel.SQL;


namespace Portfel.Model
{
    public class Wallet
    {
        public List<User> Users { get; set; }
        public UserDto actuallyUser { get; set; }
        public int MyProperty { get; set; }
        private ConnectWithSql sql = new ConnectWithSql();
        private Login login;

        public string addUser(User user)
        {
            string queryString = $"Insert Into dbo.Users (id,FirstName, LastName, Email, Password) " +
                    $"Values ('{user.Id}','{user.FirstName}','{user.LastName}'," +
                    $"'{user.EMail}','{user.Password}')";

            return queryString;
        }
        public string getUserFromEmailAndPassword(string email, string password)
        {
            string queryString = $"Select * From dbo.Users Where Email = '{email}' And Password = '{password}'";
            return queryString;
        }

    }
}
