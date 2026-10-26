using Rinzo.Application.Common;
using Rinzo.Domain.Companies;

namespace Rinzo.Application.Companies;

public static class CompanyMappings
{
    public static CompanyResponse ToResponse(this Company company) =>
        new(
            company.Id,
            company.CompanyName,
            company.ProfileInfo,
            company.Website,
            company.Industry,
            company.CompanyAddress?.ToDto(),
            company.ContactPhone?.ToDto(),
            company.ContactEmail?.ToDto(),
            company.CreatedOn,
            company.UpdatedOn
        );
}
