using System.Text.Json.Serialization;
using Rinzo.Core.Models.Companies.V1;
using Rinzo.Core.Models.Seekers.V1;

namespace Rinzo.Core.Models.Jobs.V1
{
    public class ApplicationModel : BaseModel
    {
        public string SeekerId { get; set; }

        [JsonIgnore]
        public SeekerModel? Seekers { get; set; }
        public string CompanyId { get; set; }
        public CompanyModel? Company { get; set; }
        public string JobId { get; set; }

        public JobModel? Jobs { get; set; }
        public ApplicationDateModel? ApplicationDate { get; set; }
        public StatusModel? Status { get; set; }
    }
}
