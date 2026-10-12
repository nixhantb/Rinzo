using System.Text.Json.Serialization;
using Rinzo.Core.Models.Common.V1;

namespace Rinzo.Core.Models.Companies.V1
{
    public class IndustryModel : BaseModel
    {
        public IndustryCategory IndustryType { get; set; }
    }
}
