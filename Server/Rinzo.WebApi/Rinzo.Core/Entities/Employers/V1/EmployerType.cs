namespace JobLeet.WebApi.JobLeet.Core.Entities.Employers.V1
{
    public class EmployerType
    {
        public EmployerCategory EmployerCategory { get; set; }
    }

    public enum EmployerCategory
    {
        SmallBusiness,
        MediumBusiness,
        LargeCorporation,
    }
}
