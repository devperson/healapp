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
    /// Represents Web Api service for tip categories data.
    /// </summary>
    public class TipCategoriesController : ApiController
    {
        TipCategoryRepository context = new TipCategoryRepository();
        // GET api/TipCategories?local=En
        public IEnumerable<TipCategoryModel> Get(string local)
        {
            return context.GetWithLocal().Select(t => this.ToCategoryModel(t, local)).ToList();
        }

        /// <summary>
        /// Helper method to convert model to lighter model for http transmistion.
        /// </summary>        
        private TipCategoryModel ToCategoryModel(TipCategory c, string local)
        {
            return new TipCategoryModel
            {
                ID = c.Id,
                Name = c.Localizations.First(l => l.Localization.Name == local).Name
            };
        }
    }
}
