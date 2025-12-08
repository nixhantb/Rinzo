using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JobLeet.WebApi.JobLeet.Api.Models.Common.V1
{
    public class EmailModelType
    {
        public EmailCategory EmailCategory { get; set; }
    }

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
