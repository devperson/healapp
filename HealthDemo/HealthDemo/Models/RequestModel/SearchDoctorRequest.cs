using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Service.RequestModel
{
    public class SearchDoctorRequest
    {
        public string Title { get; set; }
        public int PositionId { get; set; }
    }
}
