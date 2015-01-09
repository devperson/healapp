using HServer.Mailers;
using HServer.Models;
using HServer.Models.ApiModels;
using HServer.Models.DataAccess;
using HServer.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace HServer.Controllers
{
    /// <summary>
    /// Represents Web Api service for File data.
    /// </summary>
    public class FileServiceController : ApiControllerEx
    {
        public FileServiceController() : base() { }

        // GET api/FileService
        public IEnumerable<string> Get()
        {
            return new List<string>();
        }

        // POST api/CreateFile body file
        [HttpPost]
        public bool CreateFile(FileModel file)
        {
            InvokeAfterSec(2000, () =>
            {
                mailer.SendNewFile(file);
            });
            return true;
        }
    }

    /// <summary>
    /// Base api class
    /// </summary>
    public class ApiControllerEx : ApiController
    {
        protected MailerHelper mailer;
        public ApiControllerEx()
        {
            mailer = new MailerHelper();
        }

        static System.Timers.Timer t;
        [NonAction]
        protected void InvokeAfterSec(double sec, Action action)
        {
            t = new System.Timers.Timer();
            t.Interval = sec;
            t.Elapsed += (s, e) =>
            {
                var timer = s as System.Timers.Timer;
                timer.Stop();
                action();
            };
            t.Start();
        }

    }
}
