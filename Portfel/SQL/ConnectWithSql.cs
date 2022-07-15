using Portfel.Exceptions;
using Portfel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
                        actuallyUser = new User(FirstName, LastName, EMail, Password, Id);
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
                        User.id = Id;
                        user = new User(FirstName, LastName, EMail, Password, Id);
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
        public void addIncome(User user, Income income)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Insert into [Income] (IncomeId, Value, Date, UserId)" +
                    $"Values ('{income.Id}', '{income.Value}', '{income.Date}', '{user.Id}')  "
                    , conn);

                command.Connection.Open();
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
                        try
                        {
                            int id = reader.GetInt32(0);
                            return id;
                            command.ExecuteNonQuery();
                        }
                        catch (SqlNullValueException e)
                        {

                        }

                    }

                }

                return 0;
            }


        }
        public double getIncome(User user)
        {
            double value = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Select Value From [Income] Where UserId = '{user.Id}' And IncomeId = '{getHigherIncomeId()} "
                    , conn);
                command.Connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            value += double.Parse(reader["Value"].ToString());
                        }
                    }

                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {

                }

                return value;
            }
        }
        public void addExpense(User user, Expense expense)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Insert into [Expense] (ExpenseId, Value, UserId, ProductName, Date)" +
                    $"Values ('{expense.Id}', '{expense.Value}', '{user.Id}', '{expense.ProductName}', '{expense.Date}')  "
                    , conn);

                command.Connection.Open();
                command.ExecuteNonQuery();

            }
        }
        public void addBalance(User user, Balance balance)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Insert into [Balance] (BalanceId, Value, UserId)" +
                    $"Values ('{balance.Id}', '{balance.Value}', '{user.Id}')  "
                    , conn);

                command.Connection.Open();
                command.ExecuteNonQuery();

            }
        }
        public double getBalance(User user)
        {
            double value = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Select Value From [Balance] Where UserId = '{user.Id}' And BalanceId = '{getHigherBalanceId()}'   "
                    , conn);
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        value += double.Parse(reader["Value"].ToString());
                    }
                }


                command.ExecuteNonQuery();
                return value;
            }
        }
        public int getHigherExpenseId()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Select MAX(ExpenseId) from [Expense]"
                    , conn);
                command.Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        try
                        {
                            int id = reader.GetInt32(0);
                            return id;
                            command.ExecuteNonQuery();
                        }
                        catch (SqlNullValueException e)
                        {

                        }

                    }

                }

                return 0;
            }
        }
        public int getHigherBalanceId()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Select MAX(BalanceId) from [Balance]"
                    , conn);
                command.Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        try
                        {
                            int id = reader.GetInt32(0);
                            return id;
                            command.ExecuteNonQuery();
                        }
                        catch (SqlNullValueException e)
                        {

                        }

                    }

                }

                return 0;
            }
        }
        public DataTable getExpenses(User user)
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = connectionString;
                conn.Open();
                SqlDataAdapter command = new SqlDataAdapter($"Select * From [Expense] Where UserId = '{Wallet.actuallyUser.Id}'    "
                    , conn);

                
                command.Fill(dtbl);
                


            }
            return dtbl;
        }
        public DataTable getIncomes(User user)
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = connectionString;
                conn.Open();
                SqlDataAdapter command = new SqlDataAdapter($"Select * From [Income] Where UserId = '{Wallet.actuallyUser.Id}'    "
                    , conn);


                command.Fill(dtbl);



            }
            return dtbl;
        }
        public double getExpenseByProductName(User user, string productName)
        {
            double value = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand command = new SqlCommand($"Select Value From [Expense] Where UserId = '{user.Id}' And ProductName = '{productName}'   "
                    , conn);
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        value += double.Parse(reader["Value"].ToString());
                    }
                }


                command.ExecuteNonQuery();
                return value;
            }
        }
    }
}

