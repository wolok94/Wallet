using Portfel.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.SQL
{
    public class ConnectWithSql
    {
        private readonly string connectionString = "Server=LAPTOP-VQRVD89V\\SQLEXPRESS;Database=Wallet;Trusted_Connection=True;";

        public void Connect(User user)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Insert Into dbo.Users (id,FirstName, LastName, Email, Password) " +
                    $"Values ('{user.Id}','{user.FirstName}','{user.LastName}'," +
                    $"'{user.EMail}','{user.Password}')", conn);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
