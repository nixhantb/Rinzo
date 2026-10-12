using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Rinzo.Core.Entities.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QualificationCategory
    {
        [Display(Name = "Education")]
        Education = 1,

        [Display(Name = "Skill")]
        Skill = 2,

        [Display(Name = "Certification")]
        Certification = 3,
    }
}
