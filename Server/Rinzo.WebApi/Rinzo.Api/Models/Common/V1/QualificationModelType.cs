using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JobLeet.WebApi.JobLeet.Api.Models.Common.V1
{
    public class QualificationModelType
    {
        public QualificationCategory QualificationCategory { get; set; }
    }

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
