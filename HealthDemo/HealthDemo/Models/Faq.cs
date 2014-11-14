using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Models
{
    public class Faq
    {
        public int ID { get; set; }
        [JsonProperty(PropertyName = "Question")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "Answer")]
        public string Description { get; set; }
    }
}
