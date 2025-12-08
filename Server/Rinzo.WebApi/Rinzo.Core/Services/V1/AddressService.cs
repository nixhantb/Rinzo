using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository =
                addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
        }

        public Task<AddressModel> AddAsync(Address entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var result = _addressRepository.AddAsync(entity);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            await _addressRepository.DeleteAsync(id);
        }

        public async Task<List<AddressModel>> GetAllAsync()
        {
            var address = await _addressRepository.GetAllAsync();
            return address;
        }

        public async Task<AddressModel> GetByIdAsync(string id)
        {
            var address = await _addressRepository.GetByIdAsync(id);

            if (address == null)
            {
                throw new Exception($"Address with ID {id} not found.");
            }
            return address;
        }

        public async Task UpdateAsync(Address entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _addressRepository.UpdateAsync(entity);
        }
    }
}
