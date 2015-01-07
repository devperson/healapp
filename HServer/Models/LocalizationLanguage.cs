using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HServer.Models
{
    public class LocalizationLanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DoctorLocalization> LocalDoctors { get; set; }
        public List<TipLocalization> LocalTips { get; set; }
        public List<TipCategoryLocalization> LocalCategories { get; set; }
        public List<FaqLocalization> LocalFaqs { get; set; }
        public List<InsuranceLocalization> LocalInsurance { get; set; }
        public List<NewsLocalization> LocalNews { get; set; }
        public List<CmeLocalization> LocalCmes { get; set; }
        public List<EventLocalization> LocalEvents { get; set; }
    }
}
