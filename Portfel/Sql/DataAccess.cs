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

namespace Portfel.Sql
{

    public class DataAccess : IDataAccess
    {
        private readonly string connectionString = "Server=LAPTOP-VQRVD89V\\SQLEXPRESS;Database=Wallet;Trusted_Connection=True;";
        private User actuallyUser;
        public SqlCommand Connect(string queryString)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand(queryString, conn);
            command.Connection.Open();

            return command;



        }
        // this method inserts user to the database
        public void Registration(User user)
        {
            SqlCommand command = Connect(($"Insert Into [User] (UserId,FirstName, LastName, Email, Password) " +
                $"Values ('{user.Id}','{user.FirstName}','{user.LastName}'," +
                $"'{user.EMail}','{user.Password}')"));

            command.ExecuteNonQuery();
            command.Connection.Close();


        }
        // this method checks if there is a user with the specified email and password
        public User Login(string email, string password)
        {
            SqlCommand command = Connect($"Select * From [User] Where Email = '{email}' And Password = '{password}'");


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
            command.Connection.Close();


            return actuallyUser;
        }
        // this method returns all users from database
        public List<User> GetAll()
        {

            SqlCommand command = Connect($"Select * from [User]");
            List<User> users = new List<User>();
            User user;



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
            command.Connection.Close();


            return users;
        }
        // this method returns enrypted password from database
        public string GetEncyptedPassword(string email)
        {
            SqlCommand command = Connect($"Select * From [User] Where Email = '{email}'");
            string encryptedPassword = null;


            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {

                    encryptedPassword = reader["Password"].ToString();
                    

                }
            }
            command.ExecuteNonQuery();

            command.Connection.Close();
            return encryptedPassword;


        }
        // this method insert income to the database
        public void AddIncome(User user, Income income)
        {
            SqlCommand command = Connect($"Insert into [Income] (IncomeId, Value, Date, UserId)" +
                    $"Values ('{income.Id}', '{income.Value}', '{income.Date}', '{user.Id}')  ");
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        // this method returns higher income id
        public int GetHigherIncomeId()
        {
            SqlCommand command = Connect($"Select MAX(IncomeId) from [Income]");


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
            command.ExecuteNonQuery();
            command.Connection.Close();

            return 0;
        }



        // this method return income from databse
        public double GetIncome(User user)
        {
            double value = 0;
            SqlCommand command = Connect($"Select Value From [Income] Where UserId = '{user.Id}' And IncomeId = '{GetHigherIncomeId()} ");

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
            finally
            {
                command.Connection.Close();
            }

            return value;

        }
        // this method inserts expense to the database
        public void AddExpense(User user, Expense expense)
        {
            SqlCommand command = Connect($"Insert into [Expense] (ExpenseId, Value, UserId, ProductName, Date)" +
                    $"Values ('{expense.Id}', '{expense.Value}', '{user.Id}', '{expense.ProductName}', '{expense.Date}')  ");
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        // this method insterts balance to the database
        public void AddBalance(Balance balance)
        {
            SqlCommand command = Connect($"Insert into [Balance] (BalanceId, Value, UserId)" +
                $"Values ('{balance.Id}', '{balance.Value}', '{balance.UserId}') " );
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        // this method returns balance from database
        public double GetBalance(User user)
        {
            double value = 0;
            SqlCommand command = Connect($"Select Value From [Balance] Where UserId = '{user.Id}' And BalanceId = '{GetHigherBalanceId()}'   ");

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {

                    value += double.Parse(reader["Value"].ToString());
                }
            }


            command.ExecuteNonQuery();
            command.Connection.Close();
            return value;

        }
        // this method return higher expense id
        public int GetHigherExpenseId()
        {
            SqlCommand command = Connect($"Select MAX(ExpenseId) from [Expense]");

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    try
                    {
                        int id = reader.GetInt32(0);
                        return id;

                    }
                    catch (SqlNullValueException e)
                    {

                    }

                }

            }


            command.Connection.Close();
            return 0;

        }
        // this method returns higher balance id
        public int GetHigherBalanceId()
        {
            SqlCommand command = Connect($"Select MAX(BalanceId) from [Balance]");

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
                    finally
                    {
                        command.Connection.Close();
                    }

                    }

                

                return 0;
            }
        }
        // this method returns all user expenses
        public DataTable GetExpenses(User user)
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
        // this method returns all user incomes
        public DataTable GetIncomes(User user)
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
        // this method returns the amount of expenses for a given product
        public double GetExpenseByProductName(User user, string productName)
        {
            double value = 0;
            SqlCommand command = Connect($"Select Value From [Expense] Where UserId = '{user.Id}' And ProductName = '{productName}'   ");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        value += double.Parse(reader["Value"].ToString());
                    }
                }


                command.ExecuteNonQuery();
            command.Connection.Close();
                return value;
            }
        }


    }


