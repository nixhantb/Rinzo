using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Entities.Companies;
using Rinzo.Core.Entities.Employers;
using Rinzo.Core.Interfaces.Employers;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Employers
{
    public class EmployersRepository : IEmployerRepository
    {
        private readonly BaseDBContext _dbContext;

        public EmployersRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        private IQueryable<Employer> EmployerWithProfile() =>
            _dbContext
                .Employers.Include(e => e.Address)
                .Include(e => e.Name)
                .Include(e => e.Phone)
                .Include(e => e.Company)
                .Include(e => e.EmployerType)
                .Include(e => e.IndustryType);

        public async Task<Employer> AddAsync(Employer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbContext.Employers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            var existing = await _dbContext.Employers.FirstOrDefaultAsync(c => c.Id == id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Employer with id {id} not found");
            }
            _dbContext.Employers.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Employer>> GetAllAsync()
        {
            return await EmployerWithProfile().ToListAsync();
        }

        public async Task<Employer> GetByIdAsync(string id)
        {
            var employer = await EmployerWithProfile().FirstOrDefaultAsync(e => e.Id == id);

            return employer ?? throw new KeyNotFoundException($"Employer with id {id} not found");
        }

        public async Task UpdateAsync(Employer entity)
        {
            var existing = await EmployerWithProfile().FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Employer with id {entity.Id} not found");
            }

            UpdateProfile(existing, entity);

            await _dbContext.SaveChangesAsync();
        }

        private static void UpdateProfile(Employer existing, Employer updated)
        {
            if (updated.Name != null)
            {
                existing.Name ??= new PersonName();
                existing.Name.FirstName = updated.Name.FirstName;
                existing.Name.MiddleName = updated.Name.MiddleName;
                existing.Name.LastName = updated.Name.LastName;
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

            if (updated.Phone != null)
            {
                existing.Phone ??= new Phone();
                existing.Phone.CountryCode = updated.Phone.CountryCode;
                existing.Phone.PhoneNumber = updated.Phone.PhoneNumber;
            }

            // Company is intentionally left alone here: it's a shared row that many
            // Employers can point at (CompanyId is not unique), so mutating its
            // CompanyName from an Employer update would silently rename the company for
            // every other employer referencing it too. Company has its own update
            // endpoint for that.

            if (updated.EmployerType != null)
            {
                existing.EmployerType ??= new EmployerType();
                existing.EmployerType.EmployerCategory = updated.EmployerType.EmployerCategory;
            }

            if (updated.IndustryType != null)
            {
                existing.IndustryType ??= new Industry();
                existing.IndustryType.IndustryType = updated.IndustryType.IndustryType;
            }
        }
    }
}
