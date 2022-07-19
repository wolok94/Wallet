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
using System.Security.Cryptography;
using Portfel.SendEmail;
using Portfel.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Portfel.Sql;

namespace Portfel.Forms
{
    public partial class Registration : Form
    {
        private DataAccess dataAccess = new DataAccess();
        private User user;
        private Login login = new Login();
        private string decryptedPassword;
        public Registration()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            check();
            decryptedPassword = passwordBox.Text;
           
            passwordBox.Text = Encrypter.Encrypt(passwordBox.Text);
            string firstName = firstNameBox.Text;
            string lastName = lastNameBox.Text;
            string eMail = emailBox.Text;
            string password = passwordBox.Text;
            user = new User(firstName, lastName, eMail, password);
            dataAccess.Registration(user);

            sendEmail(eMail, firstName);
            
            this.Hide();
            login.ShowDialog();

        }
        // validate entered data
        private void check()
        {
            if (string.IsNullOrEmpty(passwordBox.Text))
            {
                showMessageBox("Wpisz swoje hasło");
                return;
            }
            if (passwordBox.Text != confirmPasswordBox.Text)
            {
                showMessageBox("Hasła się nie zgadzają.");
                return;
            }

            if (isThatEmail(dataAccess.GetAll()))
            {
                showMessageBox("Istnieje już użytkownik z takim adresem e-mail");
                return;
            }
            if (!isValid(emailBox.Text))
            {
                showMessageBox("Niepoprawny e-mail");
                return;
            }
            if (!regexValidation(passwordBox.Text))
            {
                showMessageBox("Hasło musi mieć conajmniej 9 znaków");
                return;
            }
        }
        // validate length of password
        private bool regexValidation(string password)
        {
            Regex regex = new Regex("^(?=.*?[a-z])(?=.*?[0-9]).{8,}$");
            if (regex.IsMatch(password))
            {
                return true;
            }
            else
                return false;
        }
        // shows messagebox
        private void showMessageBox(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        // validate email address
        private bool isValid (string emailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);
                return true;
            }
            catch (FormatException e)
            {
                
                
                return false;
            }
        }
        // checks if that email is already in the database
        private bool isThatEmail(List<User> users)
        {
            if (users.Any(u => u.EMail == emailBox.Text))
            {
                return true;
            }
            else
                return false;
        }
        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

            passwordBox.PasswordChar = '*';
        }
        // sends registration email
        private void sendEmail(string eMail, string firstName)
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
            email.SendEmail(eMail, firstName, "Rejestracja", file.ReadFile(), decryptedPassword);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void confirmPasswordBox_TextChanged(object sender, EventArgs e)
        {
            confirmPasswordBox.PasswordChar = '*';
        }
    }
}
