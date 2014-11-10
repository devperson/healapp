using HealthDemo.Models;
using HealthDemo.Models.ResponseModel;
using HealthDemo.Service.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Service
{
    public interface IWebService
    {
        void SearchDoctors(SearchDoctorRequest request, Action<DoctorResponse> onCompleted);
        void GetCategories(Action<CategoryResponse> onCompleted);
        void GetHealthTipsByCategory(int categoryID, Action<HealthTipResponse> onCompleted);
        void GetSpeicalties(Action<PositionResponse> onCompleted);
    }
}
