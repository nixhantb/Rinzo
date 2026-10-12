using System.Text.Json.Serialization;

namespace Rinzo.Core.Models.Common.V1
{
    public class SkillModel : BaseModel
    {
        public List<string>? Title { get; set; }
        public List<string>? Description { get; set; }
    }
}
