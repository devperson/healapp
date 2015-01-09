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
    /// Represents Web Api service for faq data.
    /// </summary>
    public class FaqController : ApiController
    {
        Repository<Faq> context = new Repository<Faq>(new DataBaseContext());

        // GET api/faq?local=En
        public IEnumerable<FaqModel> Get(string local)
        {
            return context.GetWithLocal().Select(t => this.ToModel(t, local)).ToList();
        }

        /// <summary>
        /// Helper method to convert model to lighter model for http transmistion.
        /// </summary>   
        private FaqModel ToModel(Faq c, string local)
        {
            return new FaqModel
            {
                ID = c.Id,
                Question = c.Localizations.First(l => l.Localization.Name == local).Question,
                Answer = c.Localizations.First(l => l.Localization.Name == local).Answer
            };
        }
    }
}
