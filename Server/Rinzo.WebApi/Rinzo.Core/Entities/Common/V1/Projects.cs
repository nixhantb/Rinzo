namespace JobLeet.WebApi.JobLeet.Core.Entities.Common.V1
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }

        public List<string> Responsibilities { get; set; }

        public List<string> TechnologiesUsed { get; set; }

        public string? Role { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public bool IsOngoing => !EndDate.HasValue;

        public string? ProjectUrl { get; set; }
        public string? GitHubUrl { get; set; }
    }
}
