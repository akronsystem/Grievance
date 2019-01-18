using Griveance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Griveance.ParamModel
{
    public class Email
    {
        public bool SendEmail(string MailAddress, string msg, string Subject, string UserName, string Password, string Port, string SMTPhost)
        {
            GRContext db = new GRContext();
            try
            {
                var Hostinfo = db.tbl_emailsettings.FirstOrDefault();
                var username = Hostinfo.fromid;


                SmtpClient mailSender = new SmtpClient(Hostinfo.host);//"smtp.gmail.com"

                //mailSender.Port = Int32.Parse(Port );// 25;
                mailSender.Port = 25;


                MailMessage message = new MailMessage();

                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(username,CryptIt.Decrypt( Hostinfo.password));
                mailSender.Credentials = credentials;
                mailSender.EnableSsl = true;



                message.From = new MailAddress(username, "GRIEVANCE");
                if (MailAddress.Contains(","))//MailAddress
                {
                    string[] Multiple = MailAddress.Split(',');
                    foreach (string Multi in Multiple)
                    {
                        message.To.Add(new MailAddress(Multi));
                    }

                }
                else
                {
                    message.To.Add(new MailAddress(MailAddress));//MailAddress
                }


                message.Subject = Subject;
                message.Body = msg;
                message.IsBodyHtml = true;

                mailSender.Send(message);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}