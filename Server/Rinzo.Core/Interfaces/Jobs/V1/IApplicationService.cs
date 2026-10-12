using Rinzo.Core.Entities.Jobs.V1;

namespace Rinzo.Core.Interfaces.Jobs.V1
{
    public interface IApplicationService : IService<Application>
    {
        Task<Application> ApplyForJobAsync(string seekerId, string jobId, string companyId);
        Task<Application> UpdateApplicationStatusAsync(string applicationId, Status status);
        Task<Application> GetApplicationDetailsAsync(string applicationId);
        Task<List<Application>> GetApplicationBySeekersId(string seekerId);
    }
}
