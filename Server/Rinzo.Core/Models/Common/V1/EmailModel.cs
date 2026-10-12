using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Rinzo.Core.Entities.Common.V1;

namespace Rinzo.Core.Models.Common.V1
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
