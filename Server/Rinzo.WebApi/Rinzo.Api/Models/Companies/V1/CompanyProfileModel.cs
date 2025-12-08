using System.Text.Json.Serialization;
using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;

namespace JobLeet.WebApi.JobLeet.Api.Models.Companies.V1
{
    public class CompanyProfileModel : BaseModel
    {
        public string? ProfileInfo { get; set; }
        public AddressModel? CompanyAddress { get; set; }
        public PhoneModel? ContactPhone { get; set; }
        public EmailModel? ContactEmail { get; set; }

        /// <summary>
        /// Website can be extended in future based on the requirements
        /// </summary>
        public string? Website { get; set; }
        public IndustryModel? IndustryType { get; set; }
    }
}
