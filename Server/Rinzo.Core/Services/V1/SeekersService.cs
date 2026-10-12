using Rinzo.Core.Entities.Seekers.V1;
using Rinzo.Core.Interfaces.Seekers.V1;

namespace Rinzo.Core.Services
{
    public class SeekersService : ISeekerService
    {
        private readonly ISeekerRepository _seekerRepository;

        public SeekersService(ISeekerRepository seekerRepository)
        {
            _seekerRepository =
                seekerRepository ?? throw new ArgumentNullException(nameof(seekerRepository));
        }

        public Task<Seeker> AddAsync(Seeker entity) => _seekerRepository.AddAsync(entity);

        public Task DeleteAsync(string id) => _seekerRepository.DeleteAsync(id);

        public Task<List<Seeker>> GetAllAsync() => _seekerRepository.GetAllAsync();

        public Task<Seeker> GetByIdAsync(string id) => _seekerRepository.GetByIdAsync(id);

        public Task UpdateAsync(Seeker entity) => _seekerRepository.UpdateAsync(entity);
    }
}
