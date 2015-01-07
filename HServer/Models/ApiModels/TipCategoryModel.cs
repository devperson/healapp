using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models.ApiModels
{    
    public class TipCategoryModel
    {
        public int ID { get; set; }
        public string Name { get; set; }        
    }

    public class TipModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}