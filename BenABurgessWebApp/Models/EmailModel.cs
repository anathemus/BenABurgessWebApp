using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace BenABurgessWebApp.Models
{
    public class EmailModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }

        public string SendEmail(string toAddress, string fromAddress, string subject, string message)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    const string email = "benjamin.burgess.azure@gmail.com";
                    const string password = "Tj09212014";

                    var loginInfo = new NetworkCredential(email, password);


                    mail.From = new MailAddress(fromAddress);
                    mail.To.Add(new MailAddress(toAddress));
                    mail.Subject = subject;
                    mail.Body = message;
                    mail.IsBodyHtml = true;

                    try
                    {
                        var smtpClient = new SmtpClient();
                        Page page = new Page();
                        ClientScriptManager clientScript = page.ClientScript;
                        smtpClient.Host = "smtp.gmail.com";
                        smtpClient.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential(email, password);
                        smtpClient.UseDefaultCredentials = true;
                        smtpClient.Credentials = NetworkCred;
                        smtpClient.Port = 587;
                        smtpClient.Send(mail);
                        clientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
                    }

                    finally
                    {
                        //dispose the client
                        mail.Dispose();
                    }

                }
                Error = "none";
                return Error;
            }
            catch (SmtpFailedRecipientsException ex)
            {
                foreach (SmtpFailedRecipientException t in ex.InnerExceptions)
                {
                    var status = t.StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        Error = "Delivery failed - retrying in 5 seconds.";
                        System.Threading.Thread.Sleep(5000);
                        //resend
                        //smtpClient.Send(message);
                        return Error;
                    }
                    else
                    {
                        Error = String.Format("Failed to deliver message to {0}", t.FailedRecipient);
                        return Error;
                    }
                }
            }
            catch (SmtpException Se)
            {
                // handle exception here
                Error = Se.ToString();
                return Error;
            }

            catch (Exception ex)
            {
                Error = ex.ToString();
            }

            Error = "none";
            return Error;

        }
    }
}