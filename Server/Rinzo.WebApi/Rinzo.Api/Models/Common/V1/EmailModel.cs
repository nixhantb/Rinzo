using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JobLeet.WebApi.JobLeet.Api.Models.Common.V1
{
    public class EmailModel : BaseModel
    {
        [Required(ErrorMessage = "Email Type is required")]
        public EmailCategory EmailType { get; set; }

        public EmailModel()
        {
            EmailType = EmailCategory.Personal;
        }

        [Required(ErrorMessage = "Email Address is required")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? EmailAddress { get; set; }
    }
}
