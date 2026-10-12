using Rinzo.Core.Entities.Companies.V1;
using Rinzo.Core.Interfaces.Companies.V1;

namespace Rinzo.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository =
                companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }

        public Task<Company> AddAsync(Company entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return _companyRepository.AddAsync(entity);
        }

        public Task DeleteAsync(string id) => _companyRepository.DeleteAsync(id);

        public Task<List<Company>> GetAllAsync() => _companyRepository.GetAllAsync();

        public Task<Company> GetByIdAsync(string id) => _companyRepository.GetByIdAsync(id);

        public Task UpdateAsync(Company entity) => _companyRepository.UpdateAsync(entity);
    }
}
