using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.Core.Services
{
    public class QualificationService : IQualificationService
    {
        private readonly IQualificationTypeRepository _qualificationTypeRepository;

        public QualificationService(IQualificationTypeRepository qualificationTypeRepository)
        {
            _qualificationTypeRepository =
                qualificationTypeRepository
                ?? throw new ArgumentNullException(nameof(qualificationTypeRepository));
        }

        public Task<Qualification> AddAsync(Qualification entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return _qualificationTypeRepository.AddAsync(entity);
        }

        public Task DeleteAsync(string id) => _qualificationTypeRepository.DeleteAsync(id);

        public Task<List<Qualification>> GetAllAsync() =>
            _qualificationTypeRepository.GetAllAsync();

        public Task<Qualification> GetByIdAsync(string id) =>
            _qualificationTypeRepository.GetByIdAsync(id);

        public Task UpdateAsync(Qualification entity) =>
            _qualificationTypeRepository.UpdateAsync(entity);
    }
}
