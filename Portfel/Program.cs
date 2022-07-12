

using Portfel.Exceptions;
using Portfel.Model;
using Portfel.SQL;
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
            ConnectWithSql sql = new ConnectWithSql();
            Wallet wallet = new Wallet();
            wallet.Users = sql.getAll();

                Income.id = sql.getHigherIncomeId();
                Expense.id = sql.getHigherExpenseId();
                Balance.id = sql.getHigherBalanceId();

                ApplicationConfiguration.Initialize();
                Application.Run(new Logowanie());

            }
        }
    }
