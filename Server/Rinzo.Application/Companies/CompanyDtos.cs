using Rinzo.Application.Common;
using Rinzo.Domain.Common.ValueObjects;

namespace Rinzo.Application.Companies;

public sealed record CompanyRequest(
    string CompanyName,
    string? ProfileInfo,
    string? Website,
    IndustryType? Industry,
    AddressDto? CompanyAddress,
    PhoneDto? ContactPhone,
    EmailDto? ContactEmail
);

public sealed record CompanyResponse(
    Guid Id,
    string CompanyName,
    string? ProfileInfo,
    string? Website,
    IndustryType? Industry,
    AddressDto? CompanyAddress,
    PhoneDto? ContactPhone,
    EmailDto? ContactEmail,
    DateTime CreatedOn,
    DateTime? UpdatedOn
);
