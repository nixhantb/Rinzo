using Rinzo.Application.Common;
using Rinzo.Domain.Common.ValueObjects;
using Rinzo.Domain.Employers;

namespace Rinzo.Application.Employers;

public sealed record EmployerRequest(
    Guid CompanyId,
    PersonNameDto Name,
    AddressDto? EmployerAddress,
    PhoneDto? EmployerPhone,
    EmployerType EmployerType,
    IndustryType? IndustryType
);

public sealed record EmployerResponse(
    Guid Id,
    Guid CompanyId,
    PersonNameDto Name,
    AddressDto? EmployerAddress,
    PhoneDto? EmployerPhone,
    EmployerType EmployerType,
    IndustryType? IndustryType,
    DateTime CreatedOn,
    DateTime? UpdatedOn
);
