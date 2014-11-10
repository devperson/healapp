using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    
    public class TipCategory
    {
        public TipCategory()
        {
            this.Tips = new List<Tip>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tip> Tips { get; set; }
    }
}