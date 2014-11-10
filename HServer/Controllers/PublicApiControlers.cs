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
            //return context.GetIgerly().Select(tc => new TipCategoryModel
            //                                {
            //                                    Name = tc.Name,
            //                                    Tips = tc.Tips.Select(t => new TipModel { Name = t.Name, Description = t.Description }).ToList()
            //                                }).ToList();
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
                ImageUrl = string.Format("{0}/Images/Doctors/{1}", HttpContext.Current.Request.Url.AbsoluteUri, d.ImageFileName),
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
        //[NonAction]
        //public string ToAbsoluteUrl(string relativeUrl)
        //{            
        //    if (string.IsNullOrEmpty(relativeUrl))
        //        return relativeUrl;
        //    var r = HttpContext.Current.Request;
        //    if (HttpContext.Current == null)
        //        return relativeUrl;

        //    if (relativeUrl.StartsWith("/"))
        //        relativeUrl = relativeUrl.Insert(0, "~");
        //    if (!relativeUrl.StartsWith("~/"))
        //        relativeUrl = relativeUrl.Insert(0, "~/");

        //    var url = HttpContext.Current.Request.Url;
        //    var port = url.Port != 80 ? (":" + url.Port) : String.Empty;

        //    return String.Format("{0}://{1}{2}{3}", url.Scheme, url.Host, port, VirtualPathUtility.ToAbsolute(relativeUrl));
        //}    
    }

    public class PositionController : ApiController
    {
        DepartmentRepository context = new DepartmentRepository();
        public IEnumerable<Position> Get()
        {
            return context.GetAll();
        }
    }
}
