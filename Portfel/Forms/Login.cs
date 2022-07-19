using Portfel.Forms;
using Portfel.Model;
using Portfel.Sql;
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
        
        private Wallet wallet = new Wallet();
        private MainForm main = new MainForm();
        private DataAccess data = new DataAccess();
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
        {   // this conditional statement checks if you have entered a password
            if (string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Wpisz swoje hasło", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // encrypt password
            PasswordBox.Text = Encrypter.Encrypt(PasswordBox.Text);
            User user = data.Login(EmailBox.Text, PasswordBox.Text);
            //checks validation email and password
            if (user is null)
            {
                MessageBox.Show("Nieprawidłowy e-mail lub hasło", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
