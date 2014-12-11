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
using System.Web.Http;


namespace HServer.Mailers
{
	public class MailerHelper
	{
        public MailerHelper()
        {
            AppointmentHtmlBody = new AssemblyResourceReader(HttpContext.Current.ApplicationInstance.GetType().BaseType.Assembly)
                .ReadResourceAsString("Areas.HealthDemo.Resources.NewAppoint.html");
            AppointmentHtmlBody2 = new AssemblyResourceReader(HttpContext.Current.ApplicationInstance.GetType().BaseType.Assembly)
                .ReadResourceAsString("Areas.HealthDemo.Resources.NewAppoint2.html");
            FileHtmlBody = new AssemblyResourceReader(HttpContext.Current.ApplicationInstance.GetType().BaseType.Assembly)
                .ReadResourceAsString("Areas.HealthDemo.Resources.NewFilePage.html");
            CMERegHtmlBody = new AssemblyResourceReader(HttpContext.Current.ApplicationInstance.GetType().BaseType.Assembly)
                .ReadResourceAsString("Areas.HealthDemo.Resources.CMEReg.html");
        }

		public static string Username { get { return ConfigurationManager.AppSettings["From"]; } }
        public static string To { get { return ConfigurationManager.AppSettings["SendTo"]; } }
        public string AppointmentHtmlBody { get; set; }
        public string AppointmentHtmlBody2 { get; set; }
        public string FileHtmlBody { get; set; }
        public string CMERegHtmlBody { get; set; }

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
            var body = Smart.Format(appointment.ThiqaYes ? AppointmentHtmlBody2 : AppointmentHtmlBody, appointment);
			return SendEmail(To, subject, body);
		}

        public bool SendNewFile(FileModel file)
        {
            var subject = "New File";
            var body = Smart.Format(FileHtmlBody, file);

            Attachment attachment = null;
            if(!string.IsNullOrEmpty(file.ImageExtension))
            {                
                var mediatype = file.ImageExtension.Contains("jp") ? "image/jpeg" : "image/png";
                attachment = new Attachment(new MemoryStream(this.ParseUrlData(file.ImageAsString)), "attach" + file.ImageExtension, mediatype);
            }

            return SendEmail(To, subject, body, attachment);
        }

        public bool SendCMERegistration(CMEReg regData)
        {
            var subject = "New CME Registration";
            var body = Smart.Format(CMERegHtmlBody, regData);
            return SendEmail(To, subject, body);
        }

        private byte[] ParseUrlData(string urldata)
        {
            var parts = urldata.Split(';');
            if (parts.Length != 2)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var data = parts[0].Split(':');
            if (data.Length != 2)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            data = parts[1].Split(',');
            if (data.Length != 2)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var bytes = Convert.FromBase64String(data[1]);
            return bytes;
        }

	}
}
