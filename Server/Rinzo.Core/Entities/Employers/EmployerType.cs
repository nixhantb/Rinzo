namespace Rinzo.Core.Entities.Employers
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
