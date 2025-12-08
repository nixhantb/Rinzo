using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository =
                phoneRepository ?? throw new ArgumentNullException(nameof(phoneRepository));
        }

        public async Task<PhoneModel> AddAsync(Phone entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var result = await _phoneRepository.AddAsync(entity);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            await _phoneRepository.DeleteAsync(id);
        }

        public async Task<List<PhoneModel>> GetAllAsync()
        {
            var phone = await _phoneRepository.GetAllAsync();
            return phone;
        }

        public async Task<PhoneModel> GetByIdAsync(string id)
        {
            var phone = await _phoneRepository.GetByIdAsync(id);
            if (phone == null)
            {
                throw new Exception($"phone with ID {id} not found.");
            }
            return phone;
        }

        public async Task UpdateAsync(Phone entity)
        {
            await _phoneRepository.UpdateAsync(entity);
        }
    }
}
