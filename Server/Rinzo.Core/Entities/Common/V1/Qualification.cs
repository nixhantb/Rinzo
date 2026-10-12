using System.Text.Json.Serialization;

namespace Rinzo.Core.Entities.Common.V1
{
    public class Qualification : BaseEntity
    {
        public QualificationCategory QualificationType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? QualificationInformation { get; set; }
    }
}
