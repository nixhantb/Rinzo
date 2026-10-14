using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Rinzo.Core.Entities;
using Rinzo.Core.Entities.Common;
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

        // Education, Qualifications, Experience, Projects, and SocialMedias are all
        // separate one-to-many collections. Including more than one collection in a
        // single query makes EF Core join them all together, and those joins
        // multiply row counts against each other (Education count x Experience count
        // x Qualifications count x ...) instead of just adding them up - the classic
        // EF Core "cartesian explosion". AsSplitQuery() makes EF issue one query per
        // collection instead of one giant join, which is what this shape needs.
        private IQueryable<Seeker> SeekersWithDetails() =>
            _dbContext
                .Seekers.Include(p => p.PersonName)
                .Include(c => c.Phone)
                .Include(c => c.Address)
                .Include(c => c.Skills)
                .Include(c => c.Education)
                .Include(c => c.Qualifications)
                .Include(c => c.Experience)
                .Include(p => p.Projects)
                .Include(s => s.SocialMedias)
                .AsSplitQuery();

        public async Task<Seeker> GetByIdAsync(string id)
        {
            var seeker = await SeekersWithDetails().FirstOrDefaultAsync(j => j.Id == id);

            return seeker ?? throw new KeyNotFoundException($"Seeker with id {id} not found");
        }

        public async Task DeleteAsync(string id)
        {
            // Unlike Company/Employer/Job, Seeker is the *parent* side here: Education,
            // Experience, Qualifications, Projects, and SocialMedias each hold a SeekerId
            // FK pointing back to this row, with no cascade configured. Fetching without
            // these included means EF never learns those child rows exist, so it can't do
            // anything about them - the DELETE just hits the FK constraint in Postgres and
            // fails for any seeker that actually has data. Loading them first (same
            // SeekersWithDetails() GetByIdAsync already uses) lets EF remove the whole
            // graph together.
            var existing = await SeekersWithDetails().FirstOrDefaultAsync(s => s.Id == id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Seeker with id {id} not found");
            }

            _dbContext.Seekers.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Seeker>> GetAllAsync()
        {
            return await SeekersWithDetails().ToListAsync();
        }

        public async Task UpdateAsync(Seeker entity)
        {
            var existing = await SeekersWithDetails().FirstOrDefaultAsync(s => s.Id == entity.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Seeker with id {entity.Id} not found");
            }

            UpdateDetails(existing, entity);

            await _dbContext.SaveChangesAsync();
        }

        // Mutates the already-tracked `existing` graph instead of attaching `updated`
        // directly. Single-reference fields are merged field-by-field so EF generates
        // UPDATE statements against the rows that are actually there. The list fields
        // (Education/Experience/Qualifications/Projects/SocialMedias) are fully replaced
        // by SyncCollection - see its comment for why a merge-by-id isn't possible here.
        private void UpdateDetails(Seeker existing, Seeker updated)
        {
            if (updated.PersonName != null)
            {
                existing.PersonName.FirstName = updated.PersonName.FirstName;
                existing.PersonName.MiddleName = updated.PersonName.MiddleName;
                existing.PersonName.LastName = updated.PersonName.LastName;
            }

            if (updated.Phone != null)
            {
                existing.Phone ??= new Phone();
                existing.Phone.CountryCode = updated.Phone.CountryCode;
                existing.Phone.PhoneNumber = updated.Phone.PhoneNumber;
            }

            if (updated.Address != null)
            {
                existing.Address ??= new Address();
                existing.Address.Street = updated.Address.Street;
                existing.Address.City = updated.Address.City;
                existing.Address.State = updated.Address.State;
                existing.Address.PostalCode = updated.Address.PostalCode;
                existing.Address.Country = updated.Address.Country;
            }

            if (updated.Skills != null)
            {
                existing.Skills ??= new Skill();
                existing.Skills.Title = updated.Skills.Title;
                existing.Skills.Description = updated.Skills.Description;
            }

            existing.DateOfBirth = updated.DateOfBirth;
            existing.ProfileSummary = updated.ProfileSummary;
            existing.Interests = updated.Interests;
            existing.Achievements = updated.Achievements;

            if (updated.Education != null)
            {
                existing.Education ??= new List<Education>();
                SyncCollection(existing.Education, updated.Education);
            }

            if (updated.Experience != null)
            {
                existing.Experience ??= new List<Experience>();
                SyncCollection(existing.Experience, updated.Experience);
            }

            if (updated.Qualifications != null)
            {
                existing.Qualifications ??= new List<Qualification>();
                SyncCollection(existing.Qualifications, updated.Qualifications);
            }

            if (updated.Projects != null)
            {
                existing.Projects ??= new List<Project>();
                SyncCollection(existing.Projects, updated.Projects);
            }

            if (updated.SocialMedias != null)
            {
                existing.SocialMedias ??= new List<SocialMedia>();
                SyncCollection(existing.SocialMedias, updated.SocialMedias);
            }
        }

        // BaseEntity.Id is [JsonIgnore]'d on purpose (clients can't forge/tamper ids), but
        // that means every incoming list item arrives with a brand-new random Guid already
        // assigned by its own field initializer - there is no way to tell "this is the same
        // Education row, just edited" apart from "this is a new one." Matching by id can
        // never actually find a match, so the honest behavior is a full replace: drop
        // everything that was there and insert what was sent, rather than pretending to
        // merge.
        private void SyncCollection<T>(List<T> existing, List<T> updated)
            where T : BaseEntity
        {
            if (existing.Count > 0)
            {
                _dbContext.RemoveRange(existing);
                existing.Clear();
            }

            existing.AddRange(updated);
        }
    }
}
