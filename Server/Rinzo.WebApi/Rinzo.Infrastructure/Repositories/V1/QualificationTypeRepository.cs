using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Repositories.Common.V1
{
    public class QualificationTypeRepository : IQualificationTypeRepository
    {
        private readonly BaseDBContext _dbContext;

        public QualificationTypeRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<QualificationModel> AddAsync(Qualification entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<QualificationModel>> GetAllAsync()
        {
            try
            {
                var result = await _dbContext
                    .Qualifications.Select(e => new QualificationModel
                    {
                        Id = e.Id,
                        QualificationType = (Api.Models.Common.V1.QualificationCategory)
                            e.QualificationType,
                        QualificationInformation = e.QualificationInformation,
                    })
                    .ToListAsync();

                return result;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(
                    "Error while fetching the database. Please try again later" + ex.Message
                );
            }
        }

        public Task<QualificationModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Qualification entity)
        {
            throw new NotImplementedException();
        }
    }
}
