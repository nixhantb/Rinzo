using Rinzo.Core.Entities.Jobs;

namespace Rinzo.Core.Interfaces.Jobs
{
    public interface IApplicationRepository : IRepository<Application>
    {
        Task<Application> ApplyForJobAsync(string seekerId, string jobId, string companyId);
        Task<List<Application>> GetApplicationBySeekersId(string seekerId);
        Task<Application> UpdateApplicationStatusAsync(string applicationId, Status status);
    }
}
