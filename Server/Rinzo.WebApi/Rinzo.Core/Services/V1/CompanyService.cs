using JobLeet.WebApi.JobLeet.Api.Models.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Companies.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository =
                companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }

        public async Task<CompanyModel> AddAsync(Company entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return await _companyRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
                throw new Exception($"Application with ID {id} not found.");

            await _companyRepository.DeleteAsync(id);
        }

        public async Task<List<CompanyModel>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<CompanyModel> GetByIdAsync(string id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
                throw new Exception($"Company with ID {id} not found.");

            return company;
        }

        public async Task UpdateAsync(Company entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _companyRepository.UpdateAsync(entity);
        }
    }
}
