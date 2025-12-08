using JobLeet.WebApi.JobLeet.Api.Models.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Companies.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
{
    public class IndustryTypeService : IIndustryTypeService
    {
        private readonly IIndustryTypeRepository _industryTypeRepository;

        public IndustryTypeService(IIndustryTypeRepository industryTypeRepository)
        {
            _industryTypeRepository =
                industryTypeRepository
                ?? throw new ArgumentNullException(nameof(industryTypeRepository));
        }

        public async Task<IndustryModel> AddAsync(Industry entity)
        {
            var industry = await _industryTypeRepository.AddAsync(entity);
            return industry;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IndustryModel>> GetAllAsync()
        {
            var industry = await _industryTypeRepository.GetAllAsync();
            return industry;
        }

        public async Task<IndustryModel> GetByIdAsync(string id)
        {
            var industry = await _industryTypeRepository.GetByIdAsync(id);
            if (industry == null)
            {
                throw new Exception($"Job with ID {id} not found.");
            }
            return industry;
        }

        public async Task UpdateAsync(Industry entity)
        {
            await _industryTypeRepository.UpdateAsync(entity);
        }
    }
}
