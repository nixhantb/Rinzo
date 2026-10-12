using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Common.V1
{
    public class EducationRepository : IEducationRepository
    {
        #region Initialization
        // <returns>The list of initializations</returns>
        private readonly BaseDBContext _dbContext;

        public EducationRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        #endregion
        public Task<EducationModel> AddAsync(Education entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        #region Retrieve Education Asynchronously
        /// <returns>The list of educations.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all educations from the database using Entity Framework Core.</remarks>
        public async Task<List<EducationModel>> GetAllAsync()
        {
            return await _dbContext
                .Educations.Select(e => new EducationModel
                {
                    Id = e.Id,
                    Degree = e.Degree,
                    Major = e.Major,
                    Institution = e.Institution,
                    GraduationDate = e.GraduationDate,
                    Cgpa = e.Cgpa,
                })
                .ToListAsync();
        }
        #endregion

        public Task<EducationModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Education entity)
        {
            throw new NotImplementedException();
        }
    }
}
