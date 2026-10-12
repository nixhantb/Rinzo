using System.Text.Json.Serialization;

namespace Rinzo.Core.Models.Common.V1
{
    public class PersonNameModel : BaseModel
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
    }
}
