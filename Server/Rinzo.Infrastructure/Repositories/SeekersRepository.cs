using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Rinzo.Core.Entities.Seekers;
using Rinzo.Core.Interfaces.Seekers;
using Rinzo.Infrastructure.Data.Contexts;
using Rinzo.Infrastructure.Data.Contexts.Identity;

namespace Rinzo.Infrastructure.Repositories.Seekers
{
    public class SeekersRepository : ISeekerRepository
    {
        private readonly BaseDBContext _dbContext;
        private readonly ApplicationDbContext _authContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SeekersRepository(
            BaseDBContext dbContext,
            ApplicationDbContext authContext,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));
            _httpContextAccessor =
                httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<Seeker> AddAsync(Seeker entity)
        {
            // Get the logged-in user's ID from the claims
            var userId = _httpContextAccessor
                .HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)
                ?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("Unable to retrieve the logged-in user ID.");
            }

            var user = await _authContext.Users.FirstOrDefaultAsync(e => e.Id == userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found in the identity database.");
            }

            // The seeker's id is the identity user's id (shared primary key).
            entity.Id = userId;

            try
            {
                await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
                when (dbEx.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
            {
                throw new ApplicationException("Seeker already exists with the same ID.", dbEx);
            }

            return entity;
        }

        public async Task<Seeker> GetByIdAsync(string id)
        {
            var seeker = await _dbContext
                .Seekers.Include(p => p.PersonName)
                .Include(c => c.Phone)
                .Include(c => c.Address)
                .Include(c => c.Skills)
                .Include(c => c.Education)
                .Include(c => c.Qualifications)
                .Include(c => c.Experience)
                .ThenInclude(e => e.Company)
                .Include(p => p.Projects)
                .Include(s => s.SocialMedias)
                .FirstOrDefaultAsync(j => j.Id == id);

            return seeker ?? throw new KeyNotFoundException($"Seeker with id {id} not found");
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Seeker>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Seeker entity)
        {
            throw new NotImplementedException();
        }
    }
}
