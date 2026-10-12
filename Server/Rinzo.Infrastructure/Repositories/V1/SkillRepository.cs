using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Common.V1
{
    public class SkillRepository : ISkillRepository
    {
        #region Initialization
        // <returns>The list of initializations</returns>
        private readonly BaseDBContext _dbContext;

        public SkillRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Retrieve SkillModel Asynchronously
        /// <returns>The list of skill-models by Id.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches Skill Model from the database using Entity Framework Core.</remarks>
        public async Task<List<SkillModel>> GetAllAsync()
        {
            return await _dbContext
                .Skills.Select(e => new SkillModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                })
                .ToListAsync();
        }
        #endregion

        #region Retrieve skill-models Asynchronously By ID
        /// <returns>The list of email-types by Id.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all skill-models by Id from the database using Entity Framework Core.</remarks>
        public Task<SkillModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        #endregion
        public Task<SkillModel> AddAsync(Skill entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Skill entity)
        {
            throw new NotImplementedException();
        }
    }
}
