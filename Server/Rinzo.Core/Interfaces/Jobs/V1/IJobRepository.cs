using Rinzo.Core.Models.Jobs.V1;
using Rinzo.Core.Entities.Jobs.V1;

namespace Rinzo.Core.Interfaces.Jobs.V1
{
    public interface IJobRepository : IRepository<JobEntity, JobModel> { }
}
