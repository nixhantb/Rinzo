using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;

namespace JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1
{
    public class JobEntity : BaseEntity
    {
        public Company? CompanyDescription { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? JobType { get; set; }
        public Address? JobAddress { get; set; }
        public int? Vacancies { get; set; }
        public BasicPay? BasicPay { get; set; }
        public string? FunctionalArea { get; set; }
        public Skill? SkillsRequired { get; set; }
        public Qualification? RequiredQualification { get; set; }
        public Experience? RequiredExperience { get; set; }
        public List<string>? PreferredQualifications { get; set; }
        public List<string>? JobResponsibilities { get; set; }
        public List<string>? Benefits { get; set; }
        public List<string>? Tags { get; set; }
        public string? WorkEnvironment { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? ApplicationDeadline { get; set; }
    }
}
