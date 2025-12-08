using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Api.Models.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Api.Models.Jobs.V1
{
    public class JobModel : BaseModel
    {
        public CompanyModel? CompanyDescription { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? JobType { get; set; }
        public AddressModel? JobAddress { get; set; }
        public int? Vacancies { get; set; }
        public BasicPayModel? BasicPay { get; set; }
        public string? FunctionalArea { get; set; }
        public SkillModel? SkillsRequired { get; set; }
        public QualificationModel? RequiredQualification { get; set; }
        public ExperienceModel? RequiredExperience { get; set; }
        public List<string>? PreferredQualifications { get; set; }
        public List<string>? JobResponsibilities { get; set; }
        public List<string>? Benefits { get; set; }
        public List<string>? Tags { get; set; }
        public string? WorkEnvironment { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? ApplicationDeadline { get; set; }
    }
}
