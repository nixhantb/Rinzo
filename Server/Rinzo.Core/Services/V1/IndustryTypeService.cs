using Rinzo.Core.Entities.Companies.V1;
using Rinzo.Core.Interfaces.Companies.V1;

namespace Rinzo.Core.Services
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

        public Task<Industry> AddAsync(Industry entity) => _industryTypeRepository.AddAsync(entity);

        public Task DeleteAsync(string id) => _industryTypeRepository.DeleteAsync(id);

        public Task<List<Industry>> GetAllAsync() => _industryTypeRepository.GetAllAsync();

        public Task<Industry> GetByIdAsync(string id) => _industryTypeRepository.GetByIdAsync(id);

        public Task UpdateAsync(Industry entity) => _industryTypeRepository.UpdateAsync(entity);
    }
}
