using Portfel.Model;
using Portfel.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portfel.Forms
{
    public partial class MainForm : Form
    {
        ConnectWithSql sql = new ConnectWithSql();
        Income income;
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ProfitButton_Click(object sender, EventArgs e)
        {
            double value = double.Parse(profitBox.Text);
            DateTime date = new DateTime(); ;
            date = monthCalendar1.SelectionRange.Start;
            income = new Income(value, date);
            sql.update(Wallet.actuallyUser, income);

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
