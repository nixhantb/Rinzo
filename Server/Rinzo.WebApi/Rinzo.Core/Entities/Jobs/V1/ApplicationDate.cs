namespace JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1
{
    public class ApplicationDate : BaseEntity
    {
        public DateTime SubmitDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime DecisionDate { get; set; }
        public string? Comments { get; set; }
    }
}
