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
    /// Represents Web Api service for Cme data.
    /// </summary>
    public class CmeController : ApiControllerEx
    {
        public CmeController() : base() { }
        CmeRepository context = new CmeRepository();

        // GET api/Cme?local=En
        public IEnumerable<CmeModel> Get(string local)
        {
            return context.GetCME().Select(t => this.ToModel(t, local)).ToList();
        }

        /// <summary>
        /// Helper method to convert model to lighter model for http transmistion.
        /// </summary>   
        private CmeModel ToModel(Cme c, string local)
        {
            return new CmeModel
            {
                ID = c.Id,
                Title = c.Localizations.First(l => l.Localization.Name == local).Title,
                Description = c.Localizations.First(l => l.Localization.Name == local).Description,
                Speaker = c.Localizations.First(l => l.Localization.Name == local).Speaker,
                Venue = c.Localizations.First(l => l.Localization.Name == local).Venue,
                CreditHours = c.Localizations.First(l => l.Localization.Name == local).CreditHours,
                Date = c.Date
            };
        }

        // POST api/Cme/RegisterCme body regData
        [HttpPost]
        public bool RegisterCme(CMEReg regData)
        {
            InvokeAfterSec(2000, () =>
            {
                mailer.SendCMERegistration(regData);
            });
            return true;
        }
    }
}
