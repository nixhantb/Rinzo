using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Rinzo.Core.Entities.Companies.V1;
using Rinzo.Core.Entities.Seekers.V1;

namespace Rinzo.Core.Entities.Jobs.V1
{
    public class Application : BaseEntity
    {
        public string SeekerId { get; set; }
        public Seeker? Seekers { get; set; }

        public string CompanyId { get; set; }
        public Company? Company { get; set; }

        public string JobsId { get; set; }

        public JobEntity? Jobs { get; set; }
        public ApplicationDate? ApplicationDate { get; set; }
        public Status? Status { get; set; }
    }
}
