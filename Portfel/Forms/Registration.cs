using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Portfel.Model;
using Portfel.SQL;

namespace Portfel.Forms
{
    public partial class Registration : Form
    {
        private ConnectWithSql sql = new ConnectWithSql();
        private Wallet wallet;
        private User user;
        public Registration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = firstNameBox.Text;
            string lastName = lastNameBox.Text;
            string eMail = emailBox.Text;
            string password = passwordBox.Text;
            user = new User(firstName, lastName, eMail, password);
            sql.Connect(wallet.addUser(user));
            

        }
    }
}
