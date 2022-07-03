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
        private UserDto user;
        public UserDto Connect(string queryString )
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Connection.Open();
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        string FirstName = reader["FirstName"].ToString();
                        string LastName = reader["lastName"].ToString();
                        string EMail = reader["Email"].ToString();
                        int Id = int.Parse(reader["id"].ToString());
                        string Password = reader["Password"].ToString();
                        user = new UserDto(FirstName, LastName, EMail, Password);
                    }
                }
                command.ExecuteNonQuery();
            }

            return user;
        }
    }
}
