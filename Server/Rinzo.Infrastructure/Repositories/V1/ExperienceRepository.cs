using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Common.V1
{
    public class ExperienceRepository : IExperienceRepository
    {
        #region Initialization
        // <returns>The list of initializations</returns>
        private readonly BaseDBContext _dbContext;

        public ExperienceRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        #endregion
        public Task<ExperienceModel> AddAsync(Experience entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        #region Retrieve Experience Asynchronously
        /// <returns>The list of experiences.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all experiences from the database using Entity Framework Core.</remarks>
        public async Task<List<ExperienceModel>> GetAllAsync()
        {
            return await _dbContext
                .Experiences.Select(e => new ExperienceModel
                {
                    Id = e.Id,
                    ExperienceLevel = e.ExperienceLevel,
                })
                .ToListAsync();
        }
        #endregion

        #region Retrieve Experience ID Asynchronously
        /// <returns>The list of experience Id's.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all experience Id's from the database using Entity Framework Core.</remarks>
        public Task<ExperienceModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        #endregion
        public Task UpdateAsync(Experience entity)
        {
            throw new NotImplementedException();
        }
    }
}
