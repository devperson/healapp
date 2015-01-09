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
    /// Represents Web Api service for tips data.
    /// </summary>
    public class TipsController : ApiController
    {
        TipRepository context = new TipRepository();

        // GET api/Tips
        public IEnumerable<Tip> Get()
        {
            return context.GetAll();
        }

        // GET api/Tips/GetByCatId?id=1&local=En
        public IEnumerable<TipModel> GetByCatId(int id, string local)
        {
            return context.GetByCategoryId(id).Select(t => this.ToModel(t, local)).ToList();
        }

        /// <summary>
        /// Helper method to convert model to lighter model for http transmistion.
        /// </summary>        
        [NonAction]
        public TipModel ToModel(Tip t, string local)
        {
            return new TipModel
            {
                ID = t.Id,
                Name = t.Localizations.First(l => l.Localization.Name == local).Name,
                Description = t.Localizations.First(l => l.Localization.Name == local).Description,
                CategoryID = t.CategoryId
            };
        }
    }
}
