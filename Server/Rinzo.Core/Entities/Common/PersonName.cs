using System.Text.Json.Serialization;

namespace Rinzo.Core.Entities.Common
{
    public class PersonName : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
    }
}
