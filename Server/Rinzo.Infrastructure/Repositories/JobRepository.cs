using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Entities.Companies;
using Rinzo.Core.Entities.Jobs;
using Rinzo.Core.Interfaces.Jobs;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Jobs
{
    public class JobRepository : IJobRepository
    {
        private readonly BaseDBContext _dbContext;

        public JobRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        private IQueryable<JobEntity> JobsWithDetails() =>
            _dbContext
                .Jobs.Include(j => j.CompanyDescription)
                .ThenInclude(c => c.Profile)
                .ThenInclude(p => p.ContactEmail)
                .Include(j => j.CompanyDescription)
                .ThenInclude(c => c.Profile)
                .ThenInclude(p => p.CompanyAddress)
                .Include(j => j.CompanyDescription)
                .ThenInclude(c => c.Profile)
                .ThenInclude(p => p.ContactPhone)
                .Include(j => j.JobAddress)
                .Include(j => j.SkillsRequired)
                .Include(j => j.RequiredQualification)
                .Include(j => j.RequiredExperience);

        public async Task<JobEntity> AddAsync(JobEntity entity)
        {
            _dbContext.Jobs.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            var existing = await _dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Job with id {id} not found");
            }
            _dbContext.Jobs.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<JobEntity>> GetAllAsync()
        {
            return await JobsWithDetails().ToListAsync();
        }

        public async Task<JobEntity> GetByIdAsync(string id)
        {
            var jobEntry = await JobsWithDetails().FirstOrDefaultAsync(j => j.Id == id);

            return jobEntry ?? throw new KeyNotFoundException($"Job with id {id} not found");
        }

        public async Task UpdateAsync(JobEntity entity)
        {
            var existing = await JobsWithDetails().FirstOrDefaultAsync(j => j.Id == entity.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Jobs with id {entity.Id} not found");
            }

            UpdateDetails(existing, entity);

            await _dbContext.SaveChangesAsync();
        }

        // Mutates the already-tracked `existing` graph field-by-field instead of
        // attaching `updated` directly, so EF generates UPDATE statements against the
        // rows that are actually there instead of risking new rows / losing the
        // existing CompanyDescription/JobAddress/SkillsRequired/RequiredQualification/
        // RequiredExperience ids.
        private static void UpdateDetails(JobEntity existing, JobEntity updated)
        {
            existing.JobTitle = updated.JobTitle;
            existing.JobDescription = updated.JobDescription;
            existing.JobType = updated.JobType;
            existing.Vacancies = updated.Vacancies;
            existing.BasicPay = updated.BasicPay;
            existing.FunctionalArea = updated.FunctionalArea;
            existing.PreferredQualifications = updated.PreferredQualifications;
            existing.JobResponsibilities = updated.JobResponsibilities;
            existing.Benefits = updated.Benefits;
            existing.Tags = updated.Tags;
            existing.WorkEnvironment = updated.WorkEnvironment;
            existing.PostingDate = updated.PostingDate;
            existing.ApplicationDeadline = updated.ApplicationDeadline;

            // CompanyDescription is intentionally left alone here: it's a shared Company
            // row that many Jobs can point at (CompanyDescriptionId is not unique), so
            // mutating its CompanyName from a Job update would silently rename the company
            // for every other job referencing it too. Company has its own update endpoint
            // for that.

            if (updated.JobAddress != null)
            {
                existing.JobAddress ??= new Address();
                existing.JobAddress.Street = updated.JobAddress.Street;
                existing.JobAddress.City = updated.JobAddress.City;
                existing.JobAddress.State = updated.JobAddress.State;
                existing.JobAddress.PostalCode = updated.JobAddress.PostalCode;
                existing.JobAddress.Country = updated.JobAddress.Country;
            }

            if (updated.SkillsRequired != null)
            {
                existing.SkillsRequired ??= new Skill();
                existing.SkillsRequired.Title = updated.SkillsRequired.Title;
                existing.SkillsRequired.Description = updated.SkillsRequired.Description;
            }

            if (updated.RequiredQualification != null)
            {
                existing.RequiredQualification ??= new Qualification();
                existing.RequiredQualification.QualificationType = updated
                    .RequiredQualification
                    .QualificationType;
                existing.RequiredQualification.QualificationInformation = updated
                    .RequiredQualification
                    .QualificationInformation;
            }

            if (updated.RequiredExperience != null)
            {
                existing.RequiredExperience ??= new Experience();
                existing.RequiredExperience.ExperienceLevel = updated
                    .RequiredExperience
                    .ExperienceLevel;
                existing.RequiredExperience.Company = updated.RequiredExperience.Company;
                existing.RequiredExperience.Responsibilities = updated
                    .RequiredExperience
                    .Responsibilities;
                existing.RequiredExperience.ExperienceDateFrom = updated
                    .RequiredExperience
                    .ExperienceDateFrom;
                existing.RequiredExperience.ExperienceDateTill = updated
                    .RequiredExperience
                    .ExperienceDateTill;
            }
        }
    }
}
