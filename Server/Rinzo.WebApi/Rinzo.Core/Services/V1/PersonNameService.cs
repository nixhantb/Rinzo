using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
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

        public async Task<PersonNameModel> AddAsync(PersonName entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var result = await _personNameRepository.AddAsync(entity);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            await _personNameRepository.DeleteAsync(id);
        }

        public async Task<List<PersonNameModel>> GetAllAsync()
        {
            var person = await _personNameRepository.GetAllAsync();
            return person;
        }

        public async Task<PersonNameModel> GetByIdAsync(string id)
        {
            var job = await _personNameRepository.GetByIdAsync(id);
            if (job == null)
            {
                throw new Exception($"Person with ID {id} not found.");
            }
            return job;
        }

        public async Task UpdateAsync(PersonName entity)
        {
            await _personNameRepository.UpdateAsync(entity);
        }
    }
}
