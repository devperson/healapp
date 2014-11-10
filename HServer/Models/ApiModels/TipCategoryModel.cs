using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models.ApiModels
{
    public class TipCategoryModel
    {
        public string Name { get; set; }
        public List<TipModel> Tips { get; set; }
    }

    public class TipModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}