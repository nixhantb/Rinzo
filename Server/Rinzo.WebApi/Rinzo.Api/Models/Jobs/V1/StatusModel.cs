using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using JobLeet.WebApi.JobLeet.Api.Models;

namespace JobLeet.WebApi.JobLeet.Api.Models.Jobs.V1
{
    public class StatusModel : BaseModel
    {
        public StatusName StatusName { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusName
    {
        [Display(Name = "Active")]
        Active = 0,

        [Display(Name = "Inactive")]
        Inactive = 1,

        [Display(Name = "Pending")]
        Pending = 2,

        [Display(Name = "Reviewed")]
        Reviewed = 3,

        [Display(Name = "Cancelled")]
        Cancelled = 4,

        [Display(Name = "Accepted")]
        Accepted = 5,

        [Display(Name = "Rejected")]
        Rejected = 6,

        [Display(Name = "Interview Scheduled")]
        Interview = 7,
    }
}
