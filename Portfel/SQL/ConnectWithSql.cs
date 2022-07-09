﻿using Portfel.Exceptions;
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
        private User actuallyUser;
        public void Registration(User user)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Insert Into [User] (UserId,FirstName, LastName, Email, Password) " +
                $"Values ('{user.Id}','{user.FirstName}','{user.LastName}'," +
                $"'{user.EMail}','{user.Password}')", conn);
                command.Connection.Open();

                command.ExecuteNonQuery();
            }


        }
        public User Login(string email, string password)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Select * From [User] Where Email = '{email}' And Password = '{password}'"
                    , conn);
                command.Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        string FirstName = reader["FirstName"].ToString();
                        string LastName = reader["lastName"].ToString();
                        string EMail = reader["Email"].ToString();
                        int Id = int.Parse(reader["UserId"].ToString());
                        string Password = reader["Password"].ToString();
                        actuallyUser = new User(FirstName, LastName, EMail, Password);
                    }
                }
                command.ExecuteNonQuery();
            }

            return actuallyUser;
        }
        public List<User> getAll()
        {
            List<User> users = new List<User>();
            User user;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Select * from [User]"
                    , conn);
                command.Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        string FirstName = reader["FirstName"].ToString();
                        string LastName = reader["lastName"].ToString();
                        string EMail = reader["Email"].ToString();
                        int Id = int.Parse(reader["UserId"].ToString());
                        string Password = reader["Password"].ToString();
                        user = new User(FirstName, LastName, EMail, Password);
                        users.Add(user);
                    }
                }
                command.ExecuteNonQuery();
            }

            return users;
        }
        public string getEncyptedPassword(string email)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Select * From [User] Where Email = '{email}'"
                    , conn);
                command.Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        string encryptedPassword = reader["Password"].ToString();
                        return encryptedPassword;

                    }
                }
                command.ExecuteNonQuery();
            }
            throw new ValueNotFoundException();


        }
        public void update(User user, Income income)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Insert into [Income] (IncomeId, Value, Date)" +
                    $"Values ('{income.Id}', '{income.Value}', '{income.Date}')  "
                    , conn);

                command.Connection.Open();
                command.ExecuteNonQuery();
                command = new SqlCommand($"Update [User] set IncomeId = {income.Id} Where Email = '{user.EMail}'", conn);

                command.ExecuteNonQuery();
            }
        }
        public int getHigherIncomeId()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Select MAX(IncomeId) from [Income]"
                    , conn);
                command.Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        return id;
                    }
                    command.ExecuteNonQuery();
                }

                throw new ValueNotFoundException();
            }

        }
    }
}


