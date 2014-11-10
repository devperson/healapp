using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Models
{
    public class HealthCategory
    {
        public int ID { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Title { get; set; }
        
    }
}
