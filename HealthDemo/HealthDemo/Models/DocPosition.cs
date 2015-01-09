using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HealthDemo.Models
{
    /// <summary>
    /// This class represents DocPosition object.
    /// </summary>
    public class DocPosition
    {
        public int ID { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Title { get; set; }
    }
}
