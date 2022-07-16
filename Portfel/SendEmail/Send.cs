using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.SendEmail
{
    public class Send 
    {
        public string hostSmtp { get; set; }
        public bool enableSsl { get; set; }
        public int port { get; set; }
        public string senderEmail { get; set; }
        public string senderEmailPassword { get; set; }
        public string senderName { get; set; }

        private  SmtpClient smtp;
        private  MailMessage message;
        public Send(EmailParams emailParams)
        {
            hostSmtp = emailParams.HostSmtp;
            enableSsl = emailParams.EnableSsl;
            port = emailParams.Port;
            senderEmail = emailParams.SenderEmail;
            senderEmailPassword = emailParams.SenderEmailPassword;
            senderName = emailParams.SenderName;
        }

        public  async Task SendEmail(string email, string name, string subject, string lyric, string password)
        {
            smtp = new SmtpClient
            {
                Host = hostSmtp,
                EnableSsl = enableSsl,
                Port = port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail, senderEmailPassword)
            };
            string newLyric = lyric.Replace("{name}", name);
            newLyric = newLyric.Replace("{password}", password);

             message = new MailMessage();
            message.From = new MailAddress(senderEmail, senderName);
            message.To.Add(new MailAddress(email, name));
            message.Subject = subject;
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = newLyric;
            message.BodyEncoding = Encoding.UTF8;

            smtp.SendCompleted += OnSendCompleted;
            smtp.SendMailAsync(message);


        }
        public async Task SendEmail(string email, string name, string subject, string lyric)
        {
            smtp = new SmtpClient
            {
                Host = hostSmtp,
                EnableSsl = enableSsl,
                Port = port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail, senderEmailPassword)
            };
            string newLyric = lyric.Replace("{name}", name);


            message = new MailMessage();
            message.From = new MailAddress(senderEmail, senderName);
            message.To.Add(new MailAddress(email, name));
            message.Subject = subject;
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = newLyric;
            message.BodyEncoding = Encoding.UTF8;

            smtp.SendCompleted += OnSendCompleted;
            smtp.SendMailAsync(message);


        }

        private void OnSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            smtp.Dispose();
            message.Dispose();
        }
    }
}
