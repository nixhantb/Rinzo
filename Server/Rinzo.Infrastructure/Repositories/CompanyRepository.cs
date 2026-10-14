using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Entities.Companies;
using Rinzo.Core.Interfaces.Companies;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Companies
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly BaseDBContext _dbContext;

        public CompanyRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // Shared by GetAllAsync/GetByIdAsync/UpdateAsync so the three can't silently drift
        // apart. All single-reference includes (Profile -> one of each) - no collections
        // here, so no cartesian-explosion risk to worry about in this one.
        private IQueryable<Company> CompaniesWithProfile() =>
            _dbContext
                .Companies.Include(c => c.Profile)
                .ThenInclude(p => p.ContactEmail)
                .Include(c => c.Profile)
                .ThenInclude(p => p.CompanyAddress)
                .Include(c => c.Profile)
                .ThenInclude(p => p.ContactPhone)
                .Include(c => c.Profile)
                .ThenInclude(p => p.IndustryTypes);

        public async Task<Company> AddAsync(Company entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbContext.Companies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            var existing = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Company with id {id} not found");
            }

            // This only removes the Company row. Company holds the FK pointing *to*
            // CompanyProfile (see the migration - FK_jblt_company_..._ProfileId lives on
            // jblt_company), and that relationship isn't configured with cascade delete,
            // so deleting a Company is safe on its own - but it leaves the Profile (and
            // the Profile's own nested Address/Phone/Email/Industry rows) behind,
            // orphaned. Whether to cascade-delete those too, null them out, or keep them
            // around for audit purposes is a real product decision, not a technical
            // default - left as-is deliberately rather than guessed at here.
            _dbContext.Companies.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await CompaniesWithProfile().ToListAsync();
        }

        public async Task<Company> GetByIdAsync(string id)
        {
            var company = await CompaniesWithProfile().FirstOrDefaultAsync(c => c.Id == id);

            return company ?? throw new KeyNotFoundException($"Company with id {id} not found");
        }

        public async Task UpdateAsync(Company entity)
        {
            var existing = await CompaniesWithProfile().FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Company with id {entity.Id} not found");
            }

            existing.CompanyName = entity.CompanyName;
            UpdateProfile(existing, entity.Profile);

            await _dbContext.SaveChangesAsync();
        }

        // Mutates the already-tracked `existing` graph field-by-field instead of
        // attaching `updated` directly, so EF generates UPDATE statements against the
        // rows that are actually there instead of risking new rows / losing the
        // existing Address/Phone/Email/Industry ids.
        private static void UpdateProfile(Company existing, CompanyProfile? updated)
        {
            if (updated == null)
            {
                return;
            }

            existing.Profile ??= new CompanyProfile();
            existing.Profile.ProfileInfo = updated.ProfileInfo;
            existing.Profile.Website = updated.Website;

            if (updated.CompanyAddress != null)
            {
                existing.Profile.CompanyAddress ??= new Address();
                existing.Profile.CompanyAddress.Street = updated.CompanyAddress.Street;
                existing.Profile.CompanyAddress.City = updated.CompanyAddress.City;
                existing.Profile.CompanyAddress.State = updated.CompanyAddress.State;
                existing.Profile.CompanyAddress.PostalCode = updated.CompanyAddress.PostalCode;
                existing.Profile.CompanyAddress.Country = updated.CompanyAddress.Country;
            }

            if (updated.ContactPhone != null)
            {
                existing.Profile.ContactPhone ??= new Phone();
                existing.Profile.ContactPhone.CountryCode = updated.ContactPhone.CountryCode;
                existing.Profile.ContactPhone.PhoneNumber = updated.ContactPhone.PhoneNumber;
            }

            if (updated.ContactEmail != null)
            {
                existing.Profile.ContactEmail ??= new Email();
                existing.Profile.ContactEmail.EmailAddress = updated.ContactEmail.EmailAddress;
                existing.Profile.ContactEmail.EmailType = updated.ContactEmail.EmailType;
            }

            if (updated.IndustryTypes != null)
            {
                existing.Profile.IndustryTypes ??= new Industry();
                existing.Profile.IndustryTypes.IndustryType = updated.IndustryTypes.IndustryType;
            }
        }
    }
}
