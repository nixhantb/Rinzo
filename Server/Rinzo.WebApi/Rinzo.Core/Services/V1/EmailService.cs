using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmaiTypeRepository _emailTypeRepository;

        public EmailService(IEmaiTypeRepository emaiTypeRepository)
        {
            _emailTypeRepository =
                emaiTypeRepository ?? throw new ArgumentNullException(nameof(emaiTypeRepository));
        }

        public async Task<EmailModel> AddAsync(Email entity)
        {
            var email = await _emailTypeRepository.AddAsync(entity);
            return email;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmailModel>> GetAllAsync()
        {
            var email = await _emailTypeRepository.GetAllAsync();
            return email;
        }

        public async Task<EmailModel> GetByIdAsync(string id)
        {
            var email = await _emailTypeRepository.GetByIdAsync(id);
            if (email == null)
            {
                throw new Exception($"Job with ID {id} not found.");
            }
            return email;
        }

        public async Task UpdateAsync(Email entity)
        {
            await _emailTypeRepository.UpdateAsync(entity);
        }
    }
}
