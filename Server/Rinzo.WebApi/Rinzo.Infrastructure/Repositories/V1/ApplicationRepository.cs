using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Api.Models.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Jobs.V1;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts.V1.Identity;
using JobLeet.WebApi.JobLeet.Mappers.V1;
using Microsoft.EntityFrameworkCore;

namespace JobLeet.WebApi.JobLeetInfrastructure.Repositories.Companies.V1
{
    public class ApplicationRepository : IApplicationRepository
    {
        #region Initialization
        private readonly BaseDBContext _dbContext;
        private readonly ApplicationDbContext _authContext;

        #endregion

        public ApplicationRepository(BaseDBContext dbContext, ApplicationDbContext authContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));
        }

        public async Task<ApplicationModel> AddAsync(Application entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                var userId = _authContext.Users.FirstOrDefault()?.Id;

                var saveToDb = ApplicationMapper.ToApplicationDataBase(entity, userId);
                await _dbContext.Applications.AddAsync(saveToDb);
                await _dbContext.SaveChangesAsync();

                var apiResponse = ApplicationMapper.ToApplicationModel(saveToDb);
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding company", ex);
            }
        }

        public async Task<Application> ApplyForJobAsync(
            string seekerId,
            string jobId,
            string companyId
        )
        {
            try
            {
                var seeker = await _dbContext
                    .Seekers.Include(s => s.Phone)
                    .Include(s => s.Education)
                    .Include(s => s.Address)
                    .Include(s => s.Skills)
                    .FirstOrDefaultAsync(s => s.Id == seekerId);
                if (seeker == null)
                {
                    throw new Exception($"Seeker with ID {seekerId} not found");
                }

                var company = await _dbContext
                    .Companies.Include(c => c.Profile)
                    .FirstOrDefaultAsync(c => c.Id == companyId);
                if (company == null)
                {
                    throw new Exception($"Company with ID {companyId} not found");
                }

                var job = await _dbContext
                    .Jobs.Include(j => j.CompanyDescription)
                    .Include(j => j.SkillsRequired)
                    .FirstOrDefaultAsync(j => j.Id == jobId);
                if (job == null)
                {
                    throw new Exception($"Job with ID {jobId} not found.");
                }

                var existingApplication = await _dbContext.Applications.FirstOrDefaultAsync(a =>
                    a.SeekerId == seekerId && a.JobsId == jobId
                );
                if (existingApplication != null)
                {
                    throw new Exception("Seeker has already applied for this job.");
                }

                var application = new Application
                {
                    SeekerId = seekerId,
                    JobsId = jobId,
                    CompanyId = companyId,
                    Seekers = null,
                    Jobs = null,
                    Company = null,
                    ApplicationDate = new()
                    {
                        SubmitDate = DateTime.UtcNow,
                        ReviewDate = DateTime.UtcNow,
                        DecisionDate = DateTime.UtcNow,
                        Comments = "Successfully Applied to the new Job",
                    },
                    Status = new Status
                    {
                        StatusName = JobLeet.Core.Entities.Jobs.V1.StatusName.Active,
                    },
                };

                _dbContext.Add(application);

                try
                {
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateException dbEx)
                {
                    throw new Exception(
                        "Database update error occurred.",
                        dbEx.InnerException ?? dbEx
                    );
                }

                return application;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while applying for the job.", ex);
            }
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicationModel>> GetAllAsync()
        {
            try
            {
                var entities = await _dbContext
                    .Applications.Include(p => p.Company)
                    .ThenInclude(p => p.Profile)
                    .Include(p => p.Company)
                    .ThenInclude(p => p.Profile)
                    .ThenInclude(p => p.CompanyAddress)
                    .Include(p => p.Company)
                    .ThenInclude(p => p.Profile)
                    .ThenInclude(p => p.ContactEmail)
                    .Include(p => p.Company)
                    .ThenInclude(p => p.Profile)
                    .ThenInclude(p => p.ContactPhone)
                    .Include(p => p.Company)
                    .ThenInclude(p => p.Profile)
                    .ThenInclude(p => p.IndustryTypes)
                    .Include(j => j.Jobs)
                    .ThenInclude(j => j.JobAddress)
                    .Include(j => j.ApplicationDate)
                    .Include(j => j.Status)
                    .ToListAsync();

                if (!entities.Any())
                {
                    return new List<ApplicationModel>();
                }

                return entities.Select(ApplicationMapper.ToApplicationModel).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving applications: " + ex.Message, ex);
            }
        }

        public async Task<ApplicationModel> GetByIdAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentException("Application ID cannot be null or empty.");
                }

                var application = await _dbContext
                    .Applications.Include(a => a.Seekers)
                    .Include(a => a.Jobs)
                    .Include(a => a.Company)
                    .Include(a => a.ApplicationDate)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (application == null)
                {
                    throw new KeyNotFoundException($"Application with ID {id} not found.");
                }

                return ApplicationMapper.ToApplicationModel(application);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving application with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<List<ApplicationModel>> GetApplicationBySeekersId(string seekerId)
        {
            try
            {
                if (string.IsNullOrEmpty(seekerId))
                {
                    throw new ArgumentException("Seeker ID cannot be null or empty.");
                }

                var entities = await _dbContext
                    .Applications.Include(p => p.Company)
                    .ThenInclude(p => p.Profile)
                    .Include(p => p.Company)
                    .ThenInclude(p => p.Profile)
                    .ThenInclude(p => p.CompanyAddress)
                    .Include(p => p.Company)
                    .ThenInclude(p => p.Profile)
                    .ThenInclude(p => p.ContactEmail)
                    .Include(p => p.Company)
                    .ThenInclude(p => p.Profile)
                    .ThenInclude(p => p.ContactPhone)
                    .Include(p => p.Company)
                    .ThenInclude(p => p.Profile)
                    .ThenInclude(p => p.IndustryTypes)
                    .Include(j => j.Jobs)
                    .ThenInclude(j => j.JobAddress)
                    .Include(j => j.ApplicationDate)
                    .Include(j => j.Status)
                    .Where(a => a.SeekerId == seekerId)
                    .ToListAsync();

                return entities.Select(ApplicationMapper.ToApplicationModel).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error retrieving applications for Seeker ID {seekerId}: {ex.Message}",
                    ex
                );
            }
        }

        public Task<Application> UpdateApplicationStatusAsync(string applicationId, Status status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Application entity)
        {
            throw new NotImplementedException();
        }
    }
}
