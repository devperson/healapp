using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class Tip
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public TipCategory Category { get; set; }
        public int CategoryId { get; set; }
    }
}