using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HServer.Models.DataAccess
{    
    public class TipModelConfig : EntityTypeConfiguration<Tip>
    {
        public TipModelConfig()
        {            
            HasKey(x => x.Id);
            this.HasRequired(x => x.Category).WithMany(c => c.Tips).HasForeignKey(x => x.CategoryId);            
        }
    }

    public class TipCategoryModelConfig : EntityTypeConfiguration<TipCategory>
    {
        public TipCategoryModelConfig()
        {
            HasKey(x => x.Id);            
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

    public class NewsModelConfig : EntityTypeConfiguration<News>
    {
        public NewsModelConfig()
        {
            HasKey(x => x.Id);
        }
    }

    public class InsuranceModelConfig : EntityTypeConfiguration<Insurance>
    {
        public InsuranceModelConfig()
        {
            HasKey(x => x.Id);
        }
    }
}