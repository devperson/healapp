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
    /// Represents Web Api service for Events data.
    /// </summary>
    public class EventController : ApiController
    {
        EventRepository context = new EventRepository();
        // GET api/event?local=En
        public IEnumerable<EventModel> Get(string local)
        {
            return context.GetWithLocal().Select(t => this.ToModel(t, local)).ToList();
        }

        // GET api/event/GetByCME?id=0&local=En
        public IEnumerable<EventModel> GetByCME(int cmeId, string local)
        {
            CmeRepository contextCme = new CmeRepository();
            var cme = contextCme.FindOne(s => s.Id == cmeId);
            return context.GetWithLocal().Where(e => e.Date.Day == cme.Date.Day && e.Date.Month == cme.Date.Month && e.Date.Year == cme.Date.Year).Select(t => this.ToModel(t, local)).ToList();
        }

        /// <summary>
        /// Helper method to convert model to lighter model for http transmistion.
        /// </summary>   
        private EventModel ToModel(Event c, string local)
        {
            return new EventModel
            {
                ID = c.Id,
                Date = c.Date,
                Title = c.Localizations.First(l => l.Localization.Name == local).Title,
                Description = c.Localizations.First(l => l.Localization.Name == local).Description,
                Venue = c.Localizations.First(l => l.Localization.Name == local).Venue
            };
        }
    }
}
