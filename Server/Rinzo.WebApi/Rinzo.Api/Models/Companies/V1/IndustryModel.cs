using System.Text.Json.Serialization;
using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;

namespace JobLeet.WebApi.JobLeet.Api.Models.Companies.V1
{
    public class IndustryModel : BaseModel
    {
        public IndustryCategory IndustryType { get; set; }
    }
}
