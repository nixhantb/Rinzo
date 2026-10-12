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
            return await _dbContext
                .Qualifications.Select(e => new QualificationModel
                {
                    Id = e.Id,
                    QualificationType = e.QualificationType,
                    QualificationInformation = e.QualificationInformation,
                })
                .ToListAsync();
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
