using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Employers.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Seekers.V1;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts.V1;
using JobLeet.WebApi.JobLeet.Infrastructure.Repositories.Seekers.V1;
using Microsoft.EntityFrameworkCore;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts
{
    public class BaseDBContext : DbContext
    {
        public BaseDBContext(DbContextOptions<BaseDBContext> options)
            : base(options) { }

        #region Entity Configuration

        // Entities must be passed into the DbSet for mapping purposes in Repository classes
        // Define DbSet properties for each entity in the DbContext
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<PersonName> PersonNames { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<JobEntity> Jobs { get; set; }
        public virtual DbSet<Industry> IndustryTypes { get; set; }
        public virtual DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Seeker> Seekers { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Application> Applications { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new PersonNameConfiguration());
            modelBuilder.ApplyConfiguration(new ExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new QualificationConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
            modelBuilder.ApplyConfiguration(new EducationConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new IndustryConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyProfileConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new SeekersConfiguration());
            modelBuilder.ApplyConfiguration(new EmployerConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<EmployerType>();
        }
    }
}
