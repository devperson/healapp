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
    /// Represents Web Api service for news data.
    /// </summary>
    public class NewsController : ApiController
    {
        Repository<News> context = new Repository<News>(new DataBaseContext());

        // GET api/News?local=En
        public IEnumerable<NewsModel> Get(string local)
        {
            return context.GetWithLocal().Select(t => this.ToModel(t, local)).ToList();
        }

        /// <summary>
        /// Helper method to convert model to lighter model for http transmistion.
        /// </summary>   
        private NewsModel ToModel(News c, string local)
        {
            return new NewsModel
            {
                ID = c.Id,
                Date = c.Date,
                Title = c.Localizations.First(l => l.Localization.Name == local).Title,
                Description = c.Localizations.First(l => l.Localization.Name == local).Description
            };
        }
    }
}
