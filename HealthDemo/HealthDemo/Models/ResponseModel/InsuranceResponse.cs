using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Models.ResponseModel
{
    public class InsuranceResponse : ResponseBase
    {
        public List<Insurance> Result { get; set; }
    }
}
