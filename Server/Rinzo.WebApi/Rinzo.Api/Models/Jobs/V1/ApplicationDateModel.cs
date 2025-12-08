namespace JobLeet.WebApi.JobLeet.Api.Models.Jobs.V1
{
    public class ApplicationDateModel : BaseModel
    {
        public DateTime SubmitDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime DecisionDate { get; set; }
        public string? Comments { get; set; }
    }
}
