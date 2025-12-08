namespace JobLeet.WebApi.JobLeet.Core.Entities.Common.V1
{
    /// <summary>
    /// new Skill { Title = "Programming", Description = "Software development skills" },
    /// </summary>

    public class Skill : BaseEntity
    {
        public List<string>? Title { get; set; }
        public List<string>? Description { get; set; }
    }
}
