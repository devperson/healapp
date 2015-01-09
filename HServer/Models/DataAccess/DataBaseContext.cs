using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HServer.Models.DataAccess
{
    /// <summary>
    /// This is EF data context class it holds all tables.
    /// </summary>
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        //Constructor sets initializer
        static DataBaseContext()
        {
            Database.SetInitializer<DataBaseContext>(new DataBaseInitializer());
        }

        /// <summary>
        /// Configure table to object mapping.
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new DoctorModelConfig());
            modelBuilder.Configurations.Add(new TipCategoryModelConfig());                        
            modelBuilder.Configurations.Add(new TipModelConfig());
            modelBuilder.Configurations.Add(new ExistingAppointConfig());
        }

        //These properties represents Tables in Database.

        public DbSet<Tip> Tips { get; set; }
        public DbSet<TipCategory> TipCategories { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Cme> Cmes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ExistingAppointment> ExistAppointments { get; set; }
    }
}