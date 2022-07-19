

using Portfel.Exceptions;
using Portfel.Model;
using Portfel.Sql;
using System.Data.SqlClient;

namespace Portfel
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Wallet wallet = new Wallet();
            DataAccess dataAccess = new DataAccess();
            wallet.Users = dataAccess.GetAll();

                Income.id = dataAccess.GetHigherIncomeId();
                Expense.id = dataAccess.GetHigherExpenseId();
                Balance.id = dataAccess.GetHigherBalanceId();

                ApplicationConfiguration.Initialize();
                Application.Run(new Logowanie());

            }
        }
    }
