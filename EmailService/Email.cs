using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmailService
{
    class Email
    {
        string sender_email_id = null;
        string smtpclient = null;
        string subject = null;
        string password = null;
        string recipient_email_address = null;
        string body = null;
        Database db = new Database();
        public void configuresettings()
        {
            sender_email_id = "cybergroup20@gmail.com";
            smtpclient = "smtp.gmail.com";
            subject = "This is Demo Mail";
            password = "cybergrouptest";
            recipient_email_address = "anshul30jan@gmail.com";
            body = "This is a test email from cyber group.";
        }
        public void sendemail()
        {
            this.configuresettings();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(sender_email_id);
            //mail.To.Add(recipient_email_address);
            mail.Subject = subject;
            mail.Body = body;
            //mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(smtpclient);
            client.Port = 25;
            client.Credentials = new System.Net.NetworkCredential(sender_email_id, password);
            client.EnableSsl = true;
            /*SqlConnection con = new SqlConnection("server=CYG152; database=practise; User Id=sa; Password=P@ssw0rd;");
            SqlCommand cmd = new SqlCommand("Select EMAIL from tblEmployee", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                recipient_email_address = rdr["EMAIL"].ToString();
                mail.To.Add(recipient_email_address);
                client.Send(mail);
            }*/
            recipient_email_address = db.getallemails();
            //string s = "hello";
            string[] rec_email = recipient_email_address.Split(',');
            int i=0;
            while(i<rec_email.Length-1)
            {
                mail.To.Add(rec_email[i]);
                i++;     
            }
            client.Send(mail);
        }
    }
}
