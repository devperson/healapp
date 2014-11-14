using HServer.Models;
using HServer.Models.ApiModels;
using HServer.Models.DataAccess;
using HServer.Models.Repository;
using HServer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HServer.Controllers
{    
    public class TipCategoriesController : ApiController
    {
        TipCategoryRepository context = new TipCategoryRepository();
        public IEnumerable<TipCategory> Get()
        {
            return context.GetAll();            
        }
    }

    public class TipsController : ApiController
    {
        TipRepository context = new TipRepository();

        // GET api/Tips
        public IEnumerable<Tip> Get()
        {
            return context.GetAll();
        }

        // GET api/Tips/GetByCatId?id=1
        public IEnumerable<Tip> GetByCatId(int id)
        {
            return context.GetByCategoryId(id);
        }
    }

    public class DoctorsController : ApiController
    {
        DoctorRepository context = new DoctorRepository();

        // GET api/Doctors
        public IEnumerable<DoctorModel> Get()
        {
            var list = context.GetIgerly().Select(d => ToDoctorModel(d)).ToList();

            return list;
        }

        // POST api/doctors/SearchDoctors
        [HttpPost]
        public IEnumerable<DoctorModel> SearchDoctors([FromBody]SearchDoctorParams _params)
        {
            Func<Doctor, bool> predicate = d =>
                (!string.IsNullOrEmpty(_params.Title) ? d.Name.ToLower().StartsWith(_params.Title.Trim().ToLower()) : true) &&
                (_params.PositionId > 0 ? d.PositionId.Value == _params.PositionId : true);
            
            return context.GetIgerly().Where(predicate).Select(d => ToDoctorModel(d));
        }
        
        [NonAction]
        public DoctorModel ToDoctorModel(Doctor d)
        {            
            return new DoctorModel
            {
                Id = d.Id,
                Title = d.Name,
                Bio = d.Bio,
                ImageUrl = this.ToAbsoluteUrl(string.Format("/Images/Doctors/{0}", d.ImageFileName)),
                Department = d.Department.Name,
                SubDepartment = d.SubDepartment != null ? d.SubDepartment.Name : "",
                Position = d.Position.Name,
                Qualifications = d.Qualifications.Select(q => q.Name).ToList(),
                Languages = d.Languages.Select(l => l.Name).ToList()
            };
        }

        /// <summary>
        /// Converts the provided app-relative path into an absolute Url containing the 
        /// full host name
        /// </summary>
        /// <param name="relativeUrl">App-Relative path</param>
        /// <returns>Provided relativeUrl parameter as fully qualified Url</returns>
        /// <example>~/path/to/foo to http://www.web.com/path/to/foo</example>
        [NonAction]
        public string ToAbsoluteUrl(string relativeUrl)
        {            
            var url = HttpContext.Current.Request.Url;
            var port = (url.AbsoluteUri.Contains("localhost") || url.AbsoluteUri.Contains("pc")) ? (":" + url.Port) : String.Empty;

            return String.Format("{0}://{1}{2}{3}", url.Scheme, url.Host, port, VirtualPathUtility.ToAbsolute(relativeUrl));
        }    
    }

    public class PositionController : ApiController
    {
        DepartmentRepository context = new DepartmentRepository();
        public IEnumerable<Position> Get()
        {
            return context.GetAll();
        }
    }

    public class FaqController : ApiController
    {
        Repository<Faq> context = new Repository<Faq>(new DataBaseContext());
        public IEnumerable<Faq> Get()
        {
            return context.GetAll();
        }
    }

    public class NewsController : ApiController
    {
        Repository<News> context = new Repository<News>(new DataBaseContext());
        public IEnumerable<News> Get()
        {
            return context.GetAll();
        }
    }

    public class InsuranceController : ApiController
    {
        Repository<Insurance> context = new Repository<Insurance>(new DataBaseContext());
        public IEnumerable<Insurance> Get()
        {
            return context.GetAll();
        }
    }
}
