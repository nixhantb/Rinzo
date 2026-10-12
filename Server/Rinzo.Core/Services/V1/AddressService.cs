using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.Core.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository =
                addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
        }

        public Task<Address> AddAsync(Address entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return _addressRepository.AddAsync(entity);
        }

        public Task DeleteAsync(string id) => _addressRepository.DeleteAsync(id);

        public Task<List<Address>> GetAllAsync() => _addressRepository.GetAllAsync();

        public Task<Address> GetByIdAsync(string id) => _addressRepository.GetByIdAsync(id);

        public Task UpdateAsync(Address entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return _addressRepository.UpdateAsync(entity);
        }
    }
}
