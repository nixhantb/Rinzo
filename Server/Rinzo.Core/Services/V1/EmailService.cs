using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmaiTypeRepository _emailTypeRepository;

        public EmailService(IEmaiTypeRepository emaiTypeRepository)
        {
            _emailTypeRepository =
                emaiTypeRepository ?? throw new ArgumentNullException(nameof(emaiTypeRepository));
        }

        public Task<Email> AddAsync(Email entity) => _emailTypeRepository.AddAsync(entity);

        public Task DeleteAsync(string id) => _emailTypeRepository.DeleteAsync(id);

        public Task<List<Email>> GetAllAsync() => _emailTypeRepository.GetAllAsync();

        public Task<Email> GetByIdAsync(string id) => _emailTypeRepository.GetByIdAsync(id);

        public Task UpdateAsync(Email entity) => _emailTypeRepository.UpdateAsync(entity);
    }
}
