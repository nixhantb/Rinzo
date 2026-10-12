using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.Core.Services
{
    public class PersonNameService : IPersonNameService
    {
        private readonly IPersonNameRepository _personNameRepository;

        public PersonNameService(IPersonNameRepository personNameRepository)
        {
            _personNameRepository =
                personNameRepository
                ?? throw new ArgumentNullException(nameof(personNameRepository));
        }

        public Task<PersonName> AddAsync(PersonName entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return _personNameRepository.AddAsync(entity);
        }

        public Task DeleteAsync(string id) => _personNameRepository.DeleteAsync(id);

        public Task<List<PersonName>> GetAllAsync() => _personNameRepository.GetAllAsync();

        public Task<PersonName> GetByIdAsync(string id) => _personNameRepository.GetByIdAsync(id);

        public Task UpdateAsync(PersonName entity) => _personNameRepository.UpdateAsync(entity);
    }
}
