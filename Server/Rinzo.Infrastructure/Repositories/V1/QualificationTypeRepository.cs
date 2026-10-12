using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Common.V1
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
                        QualificationType = (Rinzo.Core.Models.Common.V1.QualificationCategory)
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
