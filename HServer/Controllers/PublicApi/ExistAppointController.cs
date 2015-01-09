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
    /// Represents Web Api service for exist appointment data.
    /// </summary>
    public class ExistAppointController : ApiController
    {
        ExistingAppointmentRepository context = new ExistingAppointmentRepository();

        // GET api/faq?mrn=""&emirate=0
        [HttpGet]
        public IEnumerable<ExistingAppointment> Search(string mrn = "", long emirate = 0)
        {
            context.ImportData();
            var emID = emirate.ToString();
            return context.Find(d =>
                (!string.IsNullOrEmpty(mrn) ? d.MRN.ToLower().StartsWith(mrn.Trim().ToLower()) : true) &&
                (emirate > 0 ? d.EmiratesID.StartsWith(emID) : true));
        }

    }


}
