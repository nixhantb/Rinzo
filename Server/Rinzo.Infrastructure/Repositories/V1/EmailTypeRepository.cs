using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Common.V1
{
    public class EmailTypeRepository : IEmaiTypeRepository
    {
        #region Initialization
        // <returns>The list of initializations</returns>
        private readonly BaseDBContext _dbContext;

        public EmailTypeRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Retrieve EmailTypes Asynchronously By ID
        /// <returns>The list of email-types by Id.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all email-types by Id from the database using Entity Framework Core.</remarks>
        public async Task<EmailModel> GetByIdAsync(string id)
        {
            var email = await _dbContext
                .Emails.Where(e => e.Id == id)
                .Select(e => new EmailModel
                {
                    Id = e.Id,
                    EmailType = e.EmailType,
                })
                .FirstOrDefaultAsync();

            return email ?? throw new KeyNotFoundException($"Email with id {id} not found");
        }
        #endregion

        #region Retrieve EmailTypes Asynchronously
        /// <returns>The list of email-types.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all email-types from the database using Entity Framework Core.</remarks>
        public async Task<List<EmailModel>> GetAllAsync()
        {
            return await _dbContext
                .Emails.Select(e => new EmailModel
                {
                    Id = e.Id,
                    EmailType = e.EmailType,
                })
                .ToListAsync();
        }
        #endregion

        public Task<EmailModel> AddAsync(Email emailType)
        {
            throw new NotSupportedException();
        }

        public Task UpdateAsync(Email emailType)
        {
            throw new NotSupportedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotSupportedException();
        }
    }
}
