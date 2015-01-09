using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Models
{
    /// <summary>
    /// This class represents News object.
    /// </summary>
    public class News
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string DateFormated
        {
            get { return Date.ToString("MM/dd/yyyy"); }
        }
    }
}
