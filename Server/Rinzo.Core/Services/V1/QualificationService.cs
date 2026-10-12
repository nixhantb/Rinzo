using Rinzo.Core.Models.Common.V1;
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

        public async Task<QualificationModel> AddAsync(Qualification entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var result = await _qualificationTypeRepository.AddAsync(entity);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            await _qualificationTypeRepository.DeleteAsync(id);
        }

        public async Task<List<QualificationModel>> GetAllAsync()
        {
            var qualification = await _qualificationTypeRepository.GetAllAsync();
            return qualification;
        }

        public async Task<QualificationModel> GetByIdAsync(string id)
        {
            var qualification = await _qualificationTypeRepository.GetByIdAsync(id);
            if (qualification == null)
            {
                throw new Exception($"Job with ID {id} not found.");
            }
            return qualification;
        }

        public async Task UpdateAsync(Qualification entity)
        {
            await _qualificationTypeRepository.UpdateAsync(entity);
        }
    }
}
