using HServer.Models;
using HServer.Models.ApiModels;
using HServer.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;

namespace HServer.Controllers
{
    /// <summary>
    /// Represents Web Api service for Doctors data.
    /// </summary>
    public class DoctorsController : ApiController
    {
        DoctorRepository context = new DoctorRepository();

        // GET api/Doctors
        public IEnumerable<DoctorModel> Get(string local)
        {
            var list = context.GetIgerly().Select(d => ToDoctorModel(d, local)).ToList();

            return list;
        }

        // POST api/doctors/SearchDoctors
        [HttpPost]
        public IEnumerable<DoctorModel> SearchDoctors([FromBody]SearchDoctorParams _params)
        {
            Func<Doctor, bool> predicate = d =>
                (!string.IsNullOrEmpty(_params.Title) ? d.Localizations.First(l => l.Localization.Name == _params.Local).Name.ToLower().StartsWith(_params.Title.Trim().ToLower()) : true) &&
                (_params.PositionId > 0 ? d.PositionId.Value == _params.PositionId : true);

            return context.GetIgerly().Where(predicate).Select(d => ToDoctorModel(d, _params.Local));
        }

        /// <summary>
        /// Helper method to convert model to lighter model for http transmistion.
        /// </summary>   
        [NonAction]
        public DoctorModel ToDoctorModel(Doctor d, string local)
        {
            return new DoctorModel
            {
                Id = d.Id,
                Title = d.Localizations.First(l => l.Localization.Name == local).Name,
                Bio = d.Localizations.First(l => l.Localization.Name == local).Bio,
                ImageUrl = this.ToAbsoluteUrl(string.Format("/Images/Doctors/{0}", d.ImageFileName)),
                Department = d.Department.Localizations.First(l => l.Localization.Name == local).Name,
                SubDepartment = d.SubDepartment != null ? d.SubDepartment.Localizations.First(l => l.Localization.Name == local).Name : "",
                Position = d.Position.Localizations.First(l => l.Localization.Name == local).Name,
                Qualifications = d.Qualifications.Select(q => q.Localizations.First(l => l.Localization.Name == local).Name).ToList(),
                Languages = d.Languages.Select(l => l.Localizations.First(lz => lz.Localization.Name == local).Name).ToList()
            };
        }

        /// <summary>
        /// Converts the provided app-relative path into an absolute Url containing the 
        /// full host name
        /// </summary>        
        [NonAction]
        public string ToAbsoluteUrl(string relativeUrl)
        {
            var url = HttpContext.Current.Request.Url;
            var port = (url.AbsoluteUri.Contains("localhost") || url.AbsoluteUri.Contains("pc")) ? (":" + url.Port) : String.Empty;

            return String.Format("{0}://{1}{2}{3}", url.Scheme, url.Host, port, VirtualPathUtility.ToAbsolute(relativeUrl));
        }
    }
}
