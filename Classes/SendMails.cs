using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

namespace Classes
{
    public class SendMails
    {
        /*
        public string sendmail(string to, string from, string body, string subject)
        {
            MailAddressCollection mac;
            MailMessage msgmail = new MailMessage();
            msgmail.From = new MailAddress("info@gangdhari.com", "Gangdhari");
            msgmail.To.Add(new MailAddress(to));
            msgmail.Subject = subject;
            msgmail.Body = body;

            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress(MailFrom);
            Msg.To.Add(MailTo);
            Msg.Subject = MailSubject;
            Msg.Body = MailBody;
            Msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtpout.secureserver.net";
            smtp.Port = 25;// 587;// 281;//587;//21;
            smtp.Credentials = new System.Net.NetworkCredential("info@gangdhari.com", "9829880533");
            smtp.Send(Msg);
            return "";

            SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();
            string smtpEmail = System.Web.HttpContext.Current.Application["SMTPAddress"].ToString();
            string smtpPassword = System.Web.HttpContext.Current.Application["SMTPPassword"].ToString();
            string smtpAddress = System.Web.HttpContext.Current.Application["SMTPServer"].ToString();
            string smtpPort = System.Web.HttpContext.Current.Application["SMTPPort"].ToString();

            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpAddress);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", smtpPort);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpEmail);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPassword);


            try
            {
                SmtpMail.Send(msgmail);
                return "Email has been sent successfully sent";
            }
            catch (Exception ex)
            {
                //System.Web.HttpContext.Current.Response.Write("to:" + to + "<br>");
                //System.Web.HttpContext.Current.Response.Write("from:" + from + "<br>");
                //System.Web.HttpContext.Current.Response.Write("subject:" + subject + "<br>");
                //System.Web.HttpContext.Current.Response.Write("body:" + body + "<br>");
                return ex.Message;
            }
        }

        public string sendmail(string to, string from, string cc, string bcc, string body, string subject)
        {
            MailMessage msgmail = new MailMessage();
            msgmail.From = from.ToString();
            msgmail.To = to.ToString();
            msgmail.Cc = cc.ToString();
            msgmail.Bcc = bcc.ToString();
            msgmail.Subject = subject;
            msgmail.BodyFormat = MailFormat.Html;

            msgmail.Body = body;

            //SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();

            SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();
            string smtpEmail = System.Web.HttpContext.Current.Application["SMTPAddress"].ToString();
            string smtpPassword = System.Web.HttpContext.Current.Application["SMTPPassword"].ToString();
            string smtpAddress = System.Web.HttpContext.Current.Application["SMTPServer"].ToString();
            string smtpPort = System.Web.HttpContext.Current.Application["SMTPPort"].ToString();

            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpAddress);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", smtpPort);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpEmail);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPassword);


            try
            {
                SmtpMail.Send(msgmail);
                return "Email has been sent successfully sent";
            }
            catch (Exception ex)
            {
                //System.Web.HttpContext.Current.Response.Write("to:" + to + "<br>");
                //System.Web.HttpContext.Current.Response.Write("from:" + from + "<br>");
                //System.Web.HttpContext.Current.Response.Write("subject:" + subject + "<br>");
                //System.Web.HttpContext.Current.Response.Write("body:" + body + "<br>");
                return ex.Message;
            }
        }

        public string sendmail(string to, string bcc, string from, string body, string subject)
        {
            MailMessage msgmail = new MailMessage();
            msgmail.From = from.ToString();
            msgmail.To = to.ToString();
            msgmail.Bcc = bcc.ToString();
            msgmail.Subject = subject;
            msgmail.BodyFormat = MailFormat.Html;

            msgmail.Body = body;

            // SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();

            SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();
            string smtpEmail = System.Web.HttpContext.Current.Application["SMTPAddress"].ToString();
            string smtpPassword = System.Web.HttpContext.Current.Application["SMTPPassword"].ToString();
            string smtpAddress = System.Web.HttpContext.Current.Application["SMTPServer"].ToString();
            string smtpPort = System.Web.HttpContext.Current.Application["SMTPPort"].ToString();

            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpAddress);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", smtpPort);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpEmail);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPassword);


            try
            {
                SmtpMail.Send(msgmail);
                return "Email has been sent successfully sent";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string sendmailWithAttachment(string to, string from, string body, string subject, string FileName)
        {
            MailMessage msgmail = new MailMessage();
            msgmail.From = from.ToString();
            msgmail.To = to.ToString();
            msgmail.Subject = subject;
            msgmail.BodyFormat = MailFormat.Html;
            if (System.IO.File.Exists(FileName))
            {
                msgmail.Attachments.Add(new MailAttachment(FileName));
            }
            msgmail.Body = body;

            // SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();

            SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();
            string smtpEmail = System.Web.HttpContext.Current.Application["SMTPAddress"].ToString();
            string smtpPassword = System.Web.HttpContext.Current.Application["SMTPPassword"].ToString();
            string smtpAddress = System.Web.HttpContext.Current.Application["SMTPServer"].ToString();
            string smtpPort = System.Web.HttpContext.Current.Application["SMTPPort"].ToString();

            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpAddress);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", smtpPort);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpEmail);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPassword);


            try
            {
                SmtpMail.Send(msgmail);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string sendmailWithAttachment(string to, string from, string body, string subject, DataTable dt_Files, string Reply_to, string cc)
        {
            MailMessage msgmail = new MailMessage();
            msgmail.From = from.ToString();
            msgmail.To = to.ToString();
            msgmail.Cc = cc;
            msgmail.Subject = subject;
            msgmail.BodyFormat = MailFormat.Html;
            msgmail.Headers.Add("Reply-To", Reply_to);
            for (int i = 0; i < dt_Files.Rows.Count; i++)
            {
                if (System.IO.File.Exists(dt_Files.Rows[i]["File"].ToString()))
                {
                    msgmail.Attachments.Add(new MailAttachment(dt_Files.Rows[i]["File"].ToString()));
                }
            }
            msgmail.Body = body;

            Client c = new Client();
            //SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();

            SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();
            string smtpEmail = System.Web.HttpContext.Current.Application["SMTPAddress"].ToString();
            string smtpPassword = System.Web.HttpContext.Current.Application["SMTPPassword"].ToString();
            string smtpAddress = System.Web.HttpContext.Current.Application["SMTPServer"].ToString();
            string smtpPort = System.Web.HttpContext.Current.Application["SMTPPort"].ToString();

            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpAddress);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", smtpPort);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpEmail);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPassword);


            try
            {
                SmtpMail.Send(msgmail);
                c.write_log("emailerror", "Mail sent to " + to.ToString() + " ----Subject: " + subject, DateTime.Now.ToString());
                return "";
            }
            catch (Exception ex)
            {
                c.write_log("emailerror", ex.Message, DateTime.Now.ToString());
                return ex.Message;
            }
        }

        public string sendmailWithAttachment(string to, string from, string body, string subject, DataTable dt_Files, string BCC)
        {
            MailMessage msgmail = new MailMessage();
            msgmail.From = from.ToString();
            msgmail.To = to.ToString();
            msgmail.Subject = subject;
            msgmail.Bcc = BCC;

            msgmail.BodyFormat = MailFormat.Html;

            for (int i = 0; i < dt_Files.Rows.Count; i++)
            {
                if (System.IO.File.Exists(dt_Files.Rows[i]["File"].ToString()))
                {
                    msgmail.Attachments.Add(new MailAttachment(dt_Files.Rows[i]["File"].ToString()));
                }
            }
            msgmail.Body = body;

            Client c = new Client();
            //SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();

            SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();
            string smtpEmail = System.Web.HttpContext.Current.Application["SMTPAddress"].ToString();
            string smtpPassword = System.Web.HttpContext.Current.Application["SMTPPassword"].ToString();
            string smtpAddress = System.Web.HttpContext.Current.Application["SMTPServer"].ToString();
            string smtpPort = System.Web.HttpContext.Current.Application["SMTPPort"].ToString();

            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpAddress);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", smtpPort);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpEmail);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPassword);


            try
            {
                SmtpMail.Send(msgmail);
                c.write_log("emailerror", "Mail sent to " + to.ToString() + " ----Subject: " + subject, DateTime.Now.ToString());
                return "";
            }
            catch (Exception ex)
            {
                c.write_log("emailerror", ex.Message + "\n" + from + "\n" + to + "\n" + subject + "\n" + body, DateTime.Now.ToString());
                return ex.Message;
            }
        }

        public string sendmailWithAttachment(string to, string from, string body, string subject, DataTable dt_Files, string Reply_to, string cc, string bcc)
        {
            MailMessage msgmail = new MailMessage();
            msgmail.From = from.ToString();
            msgmail.To = to.ToString();
            msgmail.Cc = cc;
            msgmail.Bcc = bcc;
            msgmail.Subject = subject;
            msgmail.BodyFormat = MailFormat.Html;
            msgmail.Headers.Add("Reply-To", Reply_to);
            for (int i = 0; i < dt_Files.Rows.Count; i++)
            {
                if (System.IO.File.Exists(dt_Files.Rows[i]["File"].ToString()))
                {
                    msgmail.Attachments.Add(new MailAttachment(dt_Files.Rows[i]["File"].ToString()));
                }
            }
            msgmail.Body = body;

            //SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();

            SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString();
            string smtpEmail = System.Web.HttpContext.Current.Application["SMTPAddress"].ToString();
            string smtpPassword = System.Web.HttpContext.Current.Application["SMTPPassword"].ToString();
            string smtpAddress = System.Web.HttpContext.Current.Application["SMTPServer"].ToString();
            string smtpPort = System.Web.HttpContext.Current.Application["SMTPPort"].ToString();

            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpAddress);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", smtpPort);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpEmail);
            msgmail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPassword);


            try
            {
                SmtpMail.Send(msgmail);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
         * */
    }
}
