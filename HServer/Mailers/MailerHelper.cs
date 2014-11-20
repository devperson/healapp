using System.Net.Configuration;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using HServer.Utils;
using SmartFormat;
using HServer.Models;
using System.IO;


namespace HServer.Mailers
{
	public class MailerHelper
	{
        public MailerHelper()
        {
            AppointmentHtmlBody = new AssemblyResourceReader(HttpContext.Current.ApplicationInstance.GetType().BaseType.Assembly)
                .ReadResourceAsString("Areas.HealthDemo.Resources.NewAppoint.html");
        }

		public static string Username { get { return ConfigurationManager.AppSettings["Username"]; } }
        public static string To { get { return ConfigurationManager.AppSettings["SendTo"]; } }
        public string AppointmentHtmlBody { get; set; }

		public bool SendEmail(string to, string subject, string body, Attachment atachedfile = null)
		{
			var message = new MailMessage();
			message.From = new MailAddress(Username);
			message.To.Add(to);
			message.Subject = subject;
			message.Body = body;
			message.IsBodyHtml = true;
            if (atachedfile != null)
                message.Attachments.Add(atachedfile);

			var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
			var username = smtpSection.Network.UserName;
			var password = smtpSection.Network.Password;

			var client = new SmtpClient { Credentials = new NetworkCredential(username, password) };

			try
			{
				client.Send(message);
			}
			catch (Exception e)
			{
				return false;
			}
			return true;
		}

		public bool SendNewAppoitment(Appointment appointment)
		{
			var subject = "New Appointment";
			var body = Smart.Format(AppointmentHtmlBody, appointment);
			return SendEmail(To, subject, body);
		}

        public bool SendNewFile(FileModel file)
        {
            return true;
        }

	}
}
