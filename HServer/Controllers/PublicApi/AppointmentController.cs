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
    /// Represents Web Api service for Appointments data.
    /// </summary>
    public class AppointmentController : ApiControllerEx
    {
        public AppointmentController() : base() { }

        // POST api/Appointment/RequestAppointment body apt
        [HttpPost]
        public bool RequestAppointment(Appointment apt)
        {
            InvokeAfterSec(2000, () =>
            {
                mailer.SendNewAppoitment(apt);
            });

            return true;
        }
    }
}
