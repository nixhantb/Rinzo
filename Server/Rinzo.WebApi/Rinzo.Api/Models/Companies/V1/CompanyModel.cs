namespace JobLeet.WebApi.JobLeet.Api.Models.Companies.V1
{
    public class CompanyModel : BaseModel
    {
        public string? CompanyName { get; set; }
        public CompanyProfileModel? Profile { get; set; }
    }
}
