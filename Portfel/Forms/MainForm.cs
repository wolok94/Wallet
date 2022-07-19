using Portfel.IO;
using Portfel.Model;
using Portfel.SendEmail;
using Portfel.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portfel.Forms
{
    public partial class MainForm : Form
    {
        DataAccess dataAccess = new DataAccess();
        Income income;
        Expense expense;
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void ProfitButton_Click(object sender, EventArgs e)
        {
            double value = 0;
            try
            {
                value = double.Parse(profitBox.Text);
                isValueLessThan0(value);

            }catch(FormatException f)
            {
                MessageBox.Show(f.Message);
            }
            DateTime date = new DateTime(); ;
            date = monthCalendar1.SelectionRange.Start;
            income = new Income(value, date);
            dataAccess.AddIncome(Wallet.actuallyUser, income);

            double valueOfBalance = dataAccess.GetBalance(Wallet.actuallyUser) + value;
            Balance balance = new Balance(valueOfBalance, Wallet.actuallyUser.Id);
            dataAccess.AddBalance(balance);
            settingValuesOfIncome();
            profitBox.Text = "";

        }
        // checks if the value is <=0
        private void isValueLessThan0(double value)
        {
            if (value <= 0)
            {
                MessageBox.Show("Wpisywana kwota nie może być mniejsza, bądź równa 0"
                    , "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            settingValuesOfIncome();
            
            
        }
        // setting Value of income in label
        private void settingValuesOfIncome()
        {
            double value = dataAccess.GetBalance(Wallet.actuallyUser);
            if (value > 0)
            label1.Text = "Na twoim koncie pozostało: " + value.ToString();
            else
                label1.Text = "Na twoim koncie pozostało: " + dataAccess.GetIncome(Wallet.actuallyUser);
        }

        private void WasteButton_Click(object sender, EventArgs e)
        {
            double value = 0;
            try
            {
                value = double.Parse(expenseBox.Text);
                isValueLessThan0(value);
            }
            catch(FormatException f)
            {
                MessageBox.Show(f.Message);
            }
            string name = productComboBox.Text;
            DateTime date = new DateTime();
            date = monthCalendar1.SelectionRange.Start;
            addExpenseToDataBase(value,name,date);


            addBalanceToDataBase(countValueOfBalance(value));
            settingValuesOfIncome();
        }
        // adding expense to database
        private void addExpenseToDataBase(double value, string name, DateTime date)
        {
            expense = new Expense(value, name, date);
            dataAccess.AddExpense(Wallet.actuallyUser, expense);
        }
        // adding balance to database
        private void addBalanceToDataBase(double valueOfBalance)
        {
            Balance balance = new Balance(valueOfBalance, Wallet.actuallyUser.Id);
            dataAccess.AddBalance(balance);
        }
        // calculates the balance value
        private double countValueOfBalance(double value)
        {
            double balance = dataAccess.GetBalance(Wallet.actuallyUser);
            double valueOfBalance = 0;
            if (balance == 0)
            {
                valueOfBalance = double.Parse(dataAccess.GetIncome(Wallet.actuallyUser).ToString()) - value;
            }
            else
            {
                valueOfBalance = balance - value;
            }
            if (valueOfBalance <= 0)
            {
                debetEmail();
            }
            return valueOfBalance;

        }
        // sends email if a debit has been accrued
        private void debetEmail()
        {
            var email = new Send(new EmailParams
            {
                HostSmtp = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                SenderName = "Kamil Wolak",
                SenderEmail = "thewolok@gmail.com",
                SenderEmailPassword = "zvksayjiyzglsdxw"
            });
            FileManager file = new FileManager();
            email.SendEmail(Wallet.actuallyUser.EMail, Wallet.actuallyUser.FirstName
                , "Debet", file.ReadDebetFile());
        }
        // display expense on data grid view
        private void displayExpense_Click(object sender, EventArgs e)
        {
            dgv2.Visible = false;
            dgv.Visible = true;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = dataAccess.GetExpenses(Wallet.actuallyUser);
        }
        // display income on data grid view
        private void displayIncome_Click(object sender, EventArgs e)
        {
            dgv.Visible = false;
            dgv2.Visible = true;
            dgv2.AutoGenerateColumns = false;
            dgv2.DataSource = dataAccess.GetIncomes(Wallet.actuallyUser);
            
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // generate report
        private void button1_Click(object sender, EventArgs e)
        {
            GenerateExcelChart gen = new GenerateExcelChart();
            gen.Generate();
        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
