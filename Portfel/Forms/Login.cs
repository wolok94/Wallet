using Portfel.Forms;
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

namespace Portfel
{
    public partial class Login : Form
    {
        private ConnectWithSql sql = new ConnectWithSql();
        private Wallet wallet = new Wallet();
        private MainForm main = new MainForm();
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Please enter your password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PasswordBox.Text = Encrypter.Encrypt(PasswordBox.Text);
            User user = sql.Login(EmailBox.Text, PasswordBox.Text);
            if (user is null)
            {
                label3.Visible = true;
                label3.Text = "Incorrect email or password";
            }
            else
            {
                Wallet.actuallyUser = user;
                this.Hide();
                main.ShowDialog();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            PasswordBox.PasswordChar = '*';
        }
    }
}
