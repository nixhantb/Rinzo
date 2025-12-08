using JobLeet.WebApi.JobLeet.Api.Models.Seekers.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Seekers.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Seekers.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
{
    public class SeekersService : ISeekerService
    {
        private readonly ISeekerRepository _seekerRepository;

        public SeekersService(ISeekerRepository seekerRepository)
        {
            _seekerRepository =
                seekerRepository ?? throw new ArgumentNullException(nameof(seekerRepository));
        }

        public Task<SeekerModel> AddAsync(Seeker entity)
        {
            var seeker = _seekerRepository.AddAsync(entity);
            return seeker;
        }

        public async Task DeleteAsync(string id)
        {
            await _seekerRepository.DeleteAsync(id);
        }

        public Task<List<SeekerModel>> GetAllAsync()
        {
            var seeker = _seekerRepository.GetAllAsync();
            return seeker;
        }

        public Task<SeekerModel> GetByIdAsync(string id)
        {
            var seeker = _seekerRepository.GetByIdAsync(id);
            if (seeker == null)
            {
                throw new Exception($"seeker with ID {id} not found.");
            }
            return seeker;
        }

        public async Task UpdateAsync(Seeker entity)
        {
            await _seekerRepository.UpdateAsync(entity);
        }
    }
}
