using Rinzo.Application.Common;
using Rinzo.Domain.Employers;

namespace Rinzo.Application.Employers;

public static class EmployerMappings
{
    public static EmployerResponse ToResponse(this Employer employer) =>
        new(
            employer.Id,
            employer.CompanyId,
            employer.Name.ToDto(),
            employer.EmployerAddress?.ToDto(),
            employer.EmployerPhone?.ToDto(),
            employer.EmployerType,
            employer.IndustryType,
            employer.CreatedOn,
            employer.UpdatedOn
        );
}
