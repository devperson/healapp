using HealthDemo.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Models
{
    public class Doctor : ViewModelBase
    {
        
        public int ID { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string SubDept { get; set; }
        public string Bio { get; set; }
        [JsonProperty(PropertyName = "Qualifications")]
        public List<string> QualifiList { get; set; }
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "Languages")]
        public List<string> LangList { get; set; }
        public string Qualification
        {
            get
            {
                if (QualifiList != null && QualifiList.Count > 0)
                    return string.Join(", ", QualifiList);
                return string.Empty;
            }
        }
        public string Language
        {
            get
            {
                if (LangList != null && LangList.Count > 0)
                    return string.Join(", ", LangList);
                return string.Empty;
            }
        }

        
        

        

    }
}
