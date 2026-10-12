using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.Core.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository =
                phoneRepository ?? throw new ArgumentNullException(nameof(phoneRepository));
        }

        public Task<Phone> AddAsync(Phone entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return _phoneRepository.AddAsync(entity);
        }

        public Task DeleteAsync(string id) => _phoneRepository.DeleteAsync(id);

        public Task<List<Phone>> GetAllAsync() => _phoneRepository.GetAllAsync();

        public Task<Phone> GetByIdAsync(string id) => _phoneRepository.GetByIdAsync(id);

        public Task UpdateAsync(Phone entity) => _phoneRepository.UpdateAsync(entity);
    }
}
