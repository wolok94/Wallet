﻿using System;
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
using System.Security.Cryptography;

namespace Portfel.Forms
{
    public partial class Registration : Form
    {
        private ConnectWithSql sql = new ConnectWithSql();
        private Wallet wallet = new Wallet();
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
            if (string.IsNullOrEmpty(passwordBox.Text))
            {
                MessageBox.Show("Please enter your password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            passwordBox.Text = Encrypter.Encrypt(passwordBox.Text);
            string firstName = firstNameBox.Text;
            string lastName = lastNameBox.Text;
            string eMail = emailBox.Text;
            string password = passwordBox.Text;
            user = new User(firstName, lastName, eMail, password);
            sql.Registration(user);

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

            passwordBox.PasswordChar = '*';
        }
    }
}
