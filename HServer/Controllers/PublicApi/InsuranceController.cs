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
    /// Represents Web Api service for insurenses data.
    /// </summary>
    public class InsuranceController : ApiController
    {
        Repository<Insurance> context = new Repository<Insurance>(new DataBaseContext());

        // GET api/Insurance?local=En
        public IEnumerable<InsuranceModel> Get(string local)
        {
            return context.GetWithLocal().Select(t => this.ToModel(t, local)).ToList();
        }

        /// <summary>
        /// Helper method to convert model to lighter model for http transmistion.
        /// </summary>   
        private InsuranceModel ToModel(Insurance c, string local)
        {
            return new InsuranceModel
            {
                ID = c.Id,
                Title = c.Localizations.First(l => l.Localization.Name == local).Title,
                Description = c.Localizations.First(l => l.Localization.Name == local).Description
            };
        }
    }
}
