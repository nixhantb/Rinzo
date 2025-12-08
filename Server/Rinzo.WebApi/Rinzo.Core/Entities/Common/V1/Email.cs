using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JobLeet.WebApi.JobLeet.Core.Entities.Common.V1
{
    public class Email : BaseEntity
    {
        public EmailCategory EmailType { get; set; }

        public Email()
        {
            EmailType = EmailCategory.Personal;
        }

        public string? EmailAddress { get; set; }
    }
}
