using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JobLeet.WebApi.JobLeet.Api.Models.Common.V1
{
    public class PhoneModel : BaseModel
    {
        [Range(0, int.MaxValue, ErrorMessage = "Country Code must be a positive number")]
        public int CountryCode { get; set; }

        [RegularExpression(
            @"^[0-9]+$",
            ErrorMessage = "Invalid Phone Number format. Use only digits."
        )]
        public string? PhoneNumber { get; set; }
    }
}
