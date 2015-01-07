using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class News
    {
        public News()
        {
            this.Localizations = new List<NewsLocalization>();
        }
        public int Id { get; set; }       
        public DateTime? Date { get; set; }
        public List<NewsLocalization> Localizations { get; set; }
    }

    public class NewsLocalization
    {
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public News News { get; set; }
    }

    public class NewsModel
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}