using System.Text.Json.Serialization;

namespace Rinzo.Core.Models.Common.V1
{
    public class QualificationModel : BaseModel
    {
        public QualificationCategory QualificationType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? QualificationInformation { get; set; }
    }
}
