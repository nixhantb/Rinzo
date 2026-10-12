using Rinzo.Core.Models.Employers.V1;
using Rinzo.Core.Entities.Employers.V1;
using Rinzo.Core.Interfaces.Employers.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Rinzo.Infrastructure.Mappers.V1;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Employers.V1
{
    public class EmployersRepository : IEmployerRepository
    {
        #region Initialization
        // <returns>The list of initializations</returns>
        private readonly BaseDBContext _dbContext;

        public EmployersRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        #endregion
        public async Task<EmployerModel> AddAsync(Employer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var saveToDb = EmployerMapper.ToEmployer(entity);
            await _dbContext.Employers.AddAsync(saveToDb);
            await _dbContext.SaveChangesAsync();

            return EmployerMapper.ToEmployerModel(saveToDb);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployerModel>> GetAllAsync()
        {
            var employers = await _dbContext.Employers.ToListAsync();
            return employers.Select(EmployerMapper.ToEmployerModel).ToList();
        }

        public Task<EmployerModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employer entity)
        {
            throw new NotImplementedException();
        }
    }
}
