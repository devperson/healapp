using HServer.Models;
using HServer.Models.ApiModels;
using HServer.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace HServer.Controllers
{
    /// <summary>
    /// Represents Web Api service for doctor positions data.
    /// </summary>
    public class PositionController : ApiController
    {
        PositionRepository context = new PositionRepository();

        // GET api/Position?local=En
        public IEnumerable<PositionModel> Get(string local)
        {
            return context.GetWithLocal().Select(t => this.ToModel(t, local)).ToList(); ;
        }

        /// <summary>
        /// Helper method to convert model to lighter model for http transmistion.
        /// </summary>   
        private PositionModel ToModel(Position c, string local)
        {
            return new PositionModel
            {
                ID = c.Id,
                Name = c.Localizations.First(l => l.Localization.Name == local).Name
            };
        }
    }
}
