using Rinzo.Core.Entities.Common.V1;

namespace Rinzo.Core.Models.Common.V1
{
    public class ExperienceModel : BaseModel
    {
        public ExperienceLevel ExperienceLevel { get; set; }
        public string? CompanyNameModel { get; set; }
        public List<string>? Responsibilities { get; set; }
        public DateTime ExperienceDateFrom { get; set; }
        public DateTime ExperienceDateTill { get; set; }
    }
}
