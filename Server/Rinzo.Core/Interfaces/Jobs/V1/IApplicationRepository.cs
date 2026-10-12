using Rinzo.Core.Models.Jobs.V1;
using Rinzo.Core.Entities.Jobs.V1;

namespace Rinzo.Core.Interfaces.Jobs.V1
{
    public interface IApplicationRepository : IRepository<Application, ApplicationModel>
    {
        Task<Application> ApplyForJobAsync(string seekerId, string jobId, string companyId);
        Task<List<ApplicationModel>> GetApplicationBySeekersId(string seekerId);
        Task<Application> UpdateApplicationStatusAsync(string applicationId, Status status);
    }
}
