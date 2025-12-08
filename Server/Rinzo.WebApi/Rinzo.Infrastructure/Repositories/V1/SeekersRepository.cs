using System.Data.Common;
using System.Security.Claims;
using JobLeet.WebApi.JobLeet.Api.Models.Seekers.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Seekers.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Seekers.V1;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts.V1.Identity;
using JobLeet.WebApi.JobLeet.Mappers.V1;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Repositories.Seekers.V1
{
    public class SeekersRepository : ISeekerRepository
    {
        #region Initialization
        private readonly BaseDBContext _dbContext;
        private readonly ApplicationDbContext _authContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

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

        public async Task<SeekerModel> AddAsync(Seeker entity)
        {
            try
            {
                // Get the logged-in user's ID from the claims
                var userId = _httpContextAccessor
                    .HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)
                    ?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    throw new Exception("Unable to retrieve the logged-in user ID.");
                }

                var user = await _authContext.Users.FirstOrDefaultAsync(e => e.Id == userId);
                if (user == null)
                {
                    throw new Exception("User not found in the identity database.");
                }

                var seekersEntity = SeekersMapper.ToSeekerDataBase(entity, userId);

                await _dbContext.AddAsync(seekersEntity);
                await _dbContext.SaveChangesAsync();

                var seekersResponse = SeekersMapper.ToSeekerModel(seekersEntity);
                return seekersResponse;
            }
            catch (DbUpdateException dbEx)
                when (dbEx.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
            {
                throw new Exception("Seeker already exists with the same ID.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding seeker: {ex.Message}");
            }
        }

        public async Task<SeekerModel> GetByIdAsync(string id)
        {
            try
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

                var seekerModel = SeekersMapper.ToSeekerModel(seeker);
                return seekerModel;
            }
            catch (Exception ex) when (ex is DbUpdateException || ex is DbException)
            {
                throw new Exception(
                    "The Seekers with the requested ID doesn't exist or a database exception occurred.",
                    ex
                );
            }
        }

        //b4dc5b8a-a78b-4a8c-8308-20c7e5ad73a4
        public async Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SeekerModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Seeker entity)
        {
            throw new NotImplementedException();
        }
    }
}
