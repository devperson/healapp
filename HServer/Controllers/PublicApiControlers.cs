using HServer.Mailers;
using HServer.Models;
using HServer.Models.ApiModels;
using HServer.Models.DataAccess;
using HServer.Models.Repository;
using HServer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HServer.Controllers
{    
    public class TipCategoriesController : ApiController
    {
        TipCategoryRepository context = new TipCategoryRepository();
        public IEnumerable<TipCategoryModel> Get(string local)
        {
            return context.GetWithLocal().Select(t => this.ToCategoryModel(t, local)).ToList();            
        }

        private TipCategoryModel ToCategoryModel(TipCategory c, string local)
        {
            return new TipCategoryModel
            {
                ID = c.Id,
                Name = c.Localizations.First(l => l.Localization.Name == local).Name                
            };
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
        public IEnumerable<TipModel> GetByCatId(int id, string local)
        {
            return context.GetByCategoryId(id).Select(t => this.ToModel(t, local)).ToList();
        }

        [NonAction]
        public TipModel ToModel(Tip t, string local)
        {
            return new TipModel
            {
                ID = t.Id,
                Name = t.Localizations.First(l => l.Localization.Name == local).Name,
                Description = t.Localizations.First(l => l.Localization.Name == local).Description,
                CategoryID = t.CategoryId
            };
        }
    }

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
        PositionRepository context = new PositionRepository();
        public IEnumerable<PositionModel> Get(string local)
        {
            return context.GetWithLocal().Select(t => this.ToModel(t, local)).ToList(); ;
        }

        private PositionModel ToModel(Position c, string local)
        {
            return new PositionModel
            {
                ID = c.Id,
                Name = c.Localizations.First(l => l.Localization.Name == local).Name
            };
        }        
    }

    public class FaqController : ApiController
    {
        Repository<Faq> context = new Repository<Faq>(new DataBaseContext());
        public IEnumerable<FaqModel> Get(string local)
        {
            return context.GetWithLocal().Select(t => this.ToModel(t, local)).ToList();     
        }

        private FaqModel ToModel(Faq c, string local)
        {
            return new FaqModel
            {
                ID = c.Id,
                Question = c.Localizations.First(l => l.Localization.Name == local).Question,
                Answer = c.Localizations.First(l => l.Localization.Name == local).Answer
            };
        }        
    }

    public class NewsController : ApiController
    {
        Repository<News> context = new Repository<News>(new DataBaseContext());
        public IEnumerable<NewsModel> Get(string local)
        {
            return context.GetWithLocal().Select(t => this.ToModel(t, local)).ToList();     
        }

        private NewsModel ToModel(News c, string local)
        {
            return new NewsModel
            {
                ID = c.Id,
                Date = c.Date,
                Title = c.Localizations.First(l => l.Localization.Name == local).Title,
                Description = c.Localizations.First(l => l.Localization.Name == local).Description
            };
        }       
    }

    public class InsuranceController : ApiController
    {
        Repository<Insurance> context = new Repository<Insurance>(new DataBaseContext());
        public IEnumerable<InsuranceModel> Get(string local)
        {
            return context.GetWithLocal().Select(t => this.ToModel(t, local)).ToList();     
        }

        private InsuranceModel ToModel(Insurance c, string local)
        {
            return new InsuranceModel
            {
                ID = c.Id,
                Title = c.Localizations.First(l => l.Localization.Name == local).Title,
                Description = c.Localizations.First(l => l.Localization.Name == local).Description
            };
        }       
    }

    public class ApiControllerEx : ApiController
    {
        protected MailerHelper mailer;
        public ApiControllerEx()
        {
            mailer = new MailerHelper();
        }
        static System.Timers.Timer t;
        [NonAction]
        protected void InvokeAfterSec(double sec, Action action)
        {
            t = new System.Timers.Timer();
            t.Interval = sec;
            t.Elapsed += (s, e) =>
            {
                var timer = s as System.Timers.Timer;
                timer.Stop();
                action();
            };
            t.Start();
        }
              
    }

    public class AppointmentController : ApiControllerEx
    {   
        public AppointmentController() : base() { }
        
        [HttpPost]
        public bool RequestAppointment(Appointment apt)
        {
            InvokeAfterSec(2000, () =>
                {
                    mailer.SendNewAppoitment(apt);
                });
            
            return true;
        }
    }

    public class FileServiceController : ApiControllerEx
    {
        public FileServiceController() : base() { }

        public IEnumerable<string> Get()
        {
            return new List<string>();
        }

        [HttpPost]
        public bool CreateFile(FileModel file)
        {
            InvokeAfterSec(2000, () =>
            {
                mailer.SendNewFile(file);
            });
            return true;
        }
    }

    public class CmeController : ApiControllerEx
    {
        public CmeController() : base() { }
        CmeRepository context = new CmeRepository();
        public IEnumerable<CmeModel> Get(string local)
        {
            return context.GetCME().Select(t => this.ToModel(t, local)).ToList(); 
        }

        private CmeModel ToModel(Cme c, string local)
        {
            return new CmeModel
            {
                ID = c.Id,
                Title = c.Localizations.First(l => l.Localization.Name == local).Title,
                Description = c.Localizations.First(l => l.Localization.Name == local).Description,
                Speaker = c.Localizations.First(l => l.Localization.Name == local).Speaker,
                Venue = c.Localizations.First(l => l.Localization.Name == local).Venue,
                CreditHours = c.Localizations.First(l => l.Localization.Name == local).CreditHours,
                Date = c.Date
            };
        }     

        [HttpPost]
        public bool RegisterCme(CMEReg regData)
        {
            InvokeAfterSec(2000, () =>
            {
                mailer.SendCMERegistration(regData);
            });
            return true;
        }
    }

    public class EventController : ApiController
    {
        EventRepository context = new EventRepository();
        public IEnumerable<EventModel> Get(string local)
        {
            return context.GetWithLocal().Select(t => this.ToModel(t, local)).ToList();     
        }

        public IEnumerable<EventModel> GetByCME(int cmeId, string local)
        {
            CmeRepository contextCme = new CmeRepository();
            var cme = contextCme.FindOne(s => s.Id == cmeId);
            return context.GetWithLocal().Where(e => e.Date.Day == cme.Date.Day && e.Date.Month == cme.Date.Month && e.Date.Year == cme.Date.Year).Select(t => this.ToModel(t, local)).ToList();
        }

        private EventModel ToModel(Event c, string local)
        {
            return new EventModel
            {
                ID = c.Id,       
                Date = c.Date,
                Title = c.Localizations.First(l => l.Localization.Name == local).Title,
                Description = c.Localizations.First(l => l.Localization.Name == local).Description,
                Venue = c.Localizations.First(l => l.Localization.Name == local).Venue
            };
        }       
    }

    public class ExistAppointController : ApiController
    {
        ExistingAppointmentRepository context = new ExistingAppointmentRepository();
       
        [HttpGet]
        public IEnumerable<ExistingAppointment> Search(string mrn = "", long emirate = 0)
        {
            context.ImportData();
            var emID = emirate.ToString();
            return context.Find(d =>
                (!string.IsNullOrEmpty(mrn) ? d.MRN.ToLower().StartsWith(mrn.Trim().ToLower()) : true) &&
                (emirate > 0 ? d.EmiratesID.StartsWith(emID) : true));
        }
        
    }
}
