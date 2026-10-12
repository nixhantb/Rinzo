using Rinzo.Core.Entities.Common;

namespace Rinzo.Core.Entities.Companies
{
    public class CompanyProfile : BaseEntity
    {
        public string? ProfileInfo { get; set; }
        public Address? CompanyAddress { get; set; }
        public Phone? ContactPhone { get; set; }
        public Email? ContactEmail { get; set; }

        /// <summary>
        /// Website can be extended in future based on the requirements
        /// </summary>
        public string? Website { get; set; }
        public Industry? IndustryTypes { get; set; }
    }
}
