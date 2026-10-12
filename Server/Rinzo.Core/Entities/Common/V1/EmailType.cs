using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Rinzo.Core.Entities.Common.V1
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EmailCategory
    {
        [Display(Name = "Personal")]
        Personal = 1,

        [Display(Name = "Work")]
        Work = 2,

        [Display(Name = "Other")]
        Other = 3,
    }
}
