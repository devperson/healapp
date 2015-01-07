using HServer.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace HServer.Models.Repository
{
    public class TipRepository : Repository<Tip>
    {
        public TipRepository()
            : this(new DataBaseContext())
        {
        }
        public TipRepository(DbContext context)
            : base(context)
        {
        }        

        public IEnumerable<Tip> GetByCategoryId(int id)
        {
            return this.Find(t => t.CategoryId == id).Include("Localizations.Localization");
        }
    }

    public class TipCategoryRepository : Repository<TipCategory>
    {
        public TipCategoryRepository()
            : this(new DataBaseContext())
        {
        }
        public TipCategoryRepository(DbContext context)
            : base(context)
        {
        }        
    }

    public class DoctorRepository : Repository<Doctor>
    {
        public DoctorRepository()
            : this(new DataBaseContext())
        {
        }
        public DoctorRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<Doctor> GetIgerly()
        {
            return this._context.Set<Doctor>()                
                .Include("Localizations.Localization")                
                .Include("Position.Localizations.Localization")
                .Include("Department.Localizations.Localization")
                .Include("SubDepartment.Localizations.Localization")
                .Include("Languages.Localizations.Localization")
                .Include("Qualifications.Localizations.Localization").AsEnumerable();
        }
    }

    public class PositionRepository : Repository<Position>
    {
        public PositionRepository(DbContext context)
            : base(context)
        {
        }
        public PositionRepository()
            : this(new DataBaseContext())
        {
        }
    }

    public class CmeRepository : Repository<Cme>
    {
        public CmeRepository(DbContext context)
            : base(context)
        {
        }
        public CmeRepository()
            : this(new DataBaseContext())
        {
        }


        public IEnumerable<Cme> GetCME()
        {
            var result = _context.Set<Cme>().Include("Localizations.Localization").Where(s => _context.Set<Event>().Any(e => e.Date.Day == s.Date.Day && e.Date.Month == s.Date.Month && e.Date.Year == s.Date.Year));
            return result;
        }
    }

    public class EventRepository : Repository<Event>
    {
        public EventRepository(DbContext context)
            : base(context)
        {
        }
        public EventRepository()
            : this(new DataBaseContext())
        {
        }
    }

    public class ExistingAppointmentRepository : Repository<ExistingAppointment>
    {
        private DataBaseContext _context;
        public ExistingAppointmentRepository(DbContext context)
            : base(context)
        {
            _context = context as DataBaseContext;
        }
        public ExistingAppointmentRepository()
            : this(new DataBaseContext())
        {
        }

        public void ImportData()
        {
            string data = null;
            var listFiles = Directory.EnumerateFiles(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data"));
            if (listFiles.Count() > 0)
            {
                data = System.IO.File.ReadAllText(listFiles.FirstOrDefault());
            }
            if (!string.IsNullOrEmpty(data))
            {
                foreach (var record in data.Split('%'))
                {
                    try
                    {
                        var fields = record.Split('|');
                        var schedValue = fields[0].Replace("\"", "");
                        var scheduleID = int.Parse(schedValue);
                        if (_context.ExistAppointments.Any(s => s.ScheduleEventID == scheduleID))
                            continue;

                        var model = new ExistingAppointment();
                        model.ScheduleEventID = scheduleID;

                        var dateValue = fields[1].Replace("\"", "");
                        if (!string.IsNullOrEmpty(dateValue))
                        {
                            var date = DateTime.ParseExact(dateValue, "dd/MMM/yyyy", CultureInfo.InvariantCulture);
                            model.AppointmentDate = date;
                        }

                        var timeValue = fields[2].Replace("\"", "");
                        if (!string.IsNullOrEmpty(timeValue))
                        {
                            var time = TimeSpan.Parse(timeValue.Substring(0, 2) + ":" + timeValue.Substring(3, 2) + ":00");
                            model.AppointmentTime = DateTime.Now.Date + time;
                        }

                        var emirateValue = fields[4].Replace("\"", "");
                        if (!string.IsNullOrEmpty(emirateValue))
                            model.EmiratesID = emirateValue;

                        model.MRN = fields[3].Replace("\"", "");
                        model.Resource = fields[5].Replace("\"", "");
                        model.ApptLocation = fields[6].Replace("\"", "");
                        model.Language = fields[7].Replace("\"", "");
                        model.Nationality = fields[8].Replace("\"", "");

                        
                        _context.ExistAppointments.Add(model);
                    }
                    catch (Exception ex)
                    {

                    }

                }

                _context.SaveChanges();
            }
        }



    }
}