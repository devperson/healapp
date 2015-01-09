using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HServer.Models.DataAccess
{
    //These classes configures some of the mapping from Db table column to object properties, by default all mappings from db column to object properties happens by name matching.

    public class TipModelConfig : EntityTypeConfiguration<Tip>
    {
        public TipModelConfig()
        {            
            HasKey(x => x.Id);
            this.HasRequired(x => x.Category).WithMany(c => c.Tips).HasForeignKey(x => x.CategoryId);            
        }
    }
    public class TipLocalizationModelConfig : EntityTypeConfiguration<TipLocalization>
    {
        public TipLocalizationModelConfig()
        {
            HasKey(x => x.Id);
            this.HasOptional(x => x.Localization).WithMany(c => c.LocalTips).HasForeignKey(x => x.LocalizationId);
            this.HasOptional(x => x.Tip).WithMany(c => c.Localizations).HasForeignKey(x => x.TipId);      
        }
    }

    public class TipCategoryModelConfig : EntityTypeConfiguration<TipCategory>
    {
        public TipCategoryModelConfig()
        {
            HasKey(x => x.Id);            
        }
    }
    public class TipCategoryLocalModelConfig : EntityTypeConfiguration<TipCategoryLocalization>
    {
        public TipCategoryLocalModelConfig()
        {
            HasKey(x => x.Id);
            this.HasOptional(x => x.Localization).WithMany(c => c.LocalCategories).HasForeignKey(x => x.LocalizationId);
            this.HasOptional(x => x.TipCategory).WithMany(c => c.Localizations).HasForeignKey(x => x.TipCategoryId);      
        }
    }

    public class DoctorModelConfig : EntityTypeConfiguration<Doctor>
    {
        public DoctorModelConfig()
        {
            this.HasKey(x => x.Id);
            this.HasOptional(x => x.Department).WithMany(c => c.Doctors).HasForeignKey(x => x.DepartmentId);
            this.HasOptional(x => x.SubDepartment).WithMany(c => c.Doctors).HasForeignKey(x => x.SubDepartmentId);
            this.HasOptional(x => x.Position).WithMany(c => c.Doctors).HasForeignKey(x => x.PositionId);
            this.HasMany(x => x.Qualifications).WithMany(c => c.Doctors);
            this.HasMany(x => x.Languages).WithMany(c => c.Doctors);
        }
    }
    public class DoctorLocalizationModelConfig : EntityTypeConfiguration<DoctorLocalization>
    {
        public DoctorLocalizationModelConfig()
        {
            this.HasKey(x => x.Id);
            this.HasOptional(x => x.Localization).WithMany(c => c.LocalDoctors).HasForeignKey(x => x.LocalizationId);
            this.HasOptional(x => x.Doctor).WithMany(c => c.Localizations).HasForeignKey(x => x.DoctorId);            
        }
    }

    public class DepartmentModelConfig : EntityTypeConfiguration<Department>
    {
        public DepartmentModelConfig()
        {
            HasKey(x => x.Id);            
        }
    }

    public class SubDepartmentModelConfig : EntityTypeConfiguration<SubDepartment>
    {
        public SubDepartmentModelConfig()
        {
            HasKey(x => x.Id);            
        }
    }

    public class PositionModelConfig : EntityTypeConfiguration<Position>
    {
        public PositionModelConfig()
        {
            HasKey(x => x.Id);            
        }
    }

    public class QualificationModelConfig : EntityTypeConfiguration<Qualification>
    {
        public QualificationModelConfig()
        {
            HasKey(x => x.Id);
        }
    }

    public class LanguageModelConfig : EntityTypeConfiguration<Language>
    {
        public LanguageModelConfig()
        {
            HasKey(x => x.Id);
        }
    }

    public class FaqModelConfig : EntityTypeConfiguration<Faq>
    {
        public FaqModelConfig()
        {
            HasKey(x => x.Id);
        }
    }
    public class FaqLocalModelConfig : EntityTypeConfiguration<FaqLocalization>
    {
        public FaqLocalModelConfig()
        {
            HasKey(x => x.Id);
            this.HasOptional(x => x.Localization).WithMany(c => c.LocalFaqs).HasForeignKey(x => x.LocalizationId);
            this.HasOptional(x => x.Faq).WithMany(c => c.Localizations).HasForeignKey(x => x.FaqId);    
        }
    }

    public class NewsModelConfig : EntityTypeConfiguration<News>
    {
        public NewsModelConfig()
        {
            HasKey(x => x.Id);
        }
    }
    public class NewsLocalModelConfig : EntityTypeConfiguration<NewsLocalization>
    {
        public NewsLocalModelConfig()
        {
            HasKey(x => x.Id);
            this.HasOptional(x => x.Localization).WithMany(c => c.LocalNews).HasForeignKey(x => x.LocalizationId);
            this.HasOptional(x => x.News).WithMany(c => c.Localizations).HasForeignKey(x => x.NewsId);
        }
    }

    public class InsuranceModelConfig : EntityTypeConfiguration<Insurance>
    {
        public InsuranceModelConfig()
        {
            HasKey(x => x.Id);
        }
    }
    public class InsuranceLocalModelConfig : EntityTypeConfiguration<InsuranceLocalization>
    {
        public InsuranceLocalModelConfig()
        {
            HasKey(x => x.Id);
            this.HasOptional(x => x.Localization).WithMany(c => c.LocalInsurance).HasForeignKey(x => x.LocalizationId);
            this.HasOptional(x => x.Insurance).WithMany(c => c.Localizations).HasForeignKey(x => x.InsuranceId);
        }
    }

    public class CmeModelConfig : EntityTypeConfiguration<Cme>
    {
        public CmeModelConfig()
        {
            HasKey(x => x.Id);
        }
    }
    public class CmelocalModelConfig : EntityTypeConfiguration<CmeLocalization>
    {
        public CmelocalModelConfig()
        {
            HasKey(x => x.Id);
            this.HasOptional(x => x.Localization).WithMany(c => c.LocalCmes).HasForeignKey(x => x.LocalizationId);
            this.HasOptional(x => x.Cme).WithMany(c => c.Localizations).HasForeignKey(x => x.CmeId);
        }
    }

    public class ExistingAppointConfig : EntityTypeConfiguration<ExistingAppointment>
    {
        public ExistingAppointConfig()
        {
            HasKey(x => x.Id);
        }
    }
   
}