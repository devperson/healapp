using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HServer.Models.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        static DataBaseContext()
        {
            Database.SetInitializer<DataBaseContext>(new DataBaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new DoctorModelConfig());
            modelBuilder.Configurations.Add(new TipCategoryModelConfig());                        
            modelBuilder.Configurations.Add(new TipModelConfig());            
        }

        public DbSet<Tip> Tips { get; set; }
        public DbSet<TipCategory> TipCategories { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Cme> Cmes { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}