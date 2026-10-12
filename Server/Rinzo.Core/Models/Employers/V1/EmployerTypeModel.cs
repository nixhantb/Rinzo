namespace Rinzo.Core.Models.Employers.V1
{
    public class EmployerTypeModel
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
