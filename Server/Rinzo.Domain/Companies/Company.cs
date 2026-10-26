using Rinzo.Domain.Common;
using Rinzo.Domain.Common.ValueObjects;

namespace Rinzo.Domain.Companies;

public sealed class Company : BaseEntity
{
    public string CompanyName { get; private set; } = string.Empty;
    public string? ProfileInfo { get; private set; }
    public string? Website { get; private set; }
    public IndustryType? Industry { get; private set; }
    public Address? CompanyAddress { get; private set; }
    public Phone? ContactPhone { get; private set; }
    public Email? ContactEmail { get; private set; }

    // EF Core needs a parameterless constructor. Private = nobody else can use it.
    private Company() { }

    // Factory Method: the only way to create a Company from outside this class.
    public static Company Create(
        string companyName,
        string? profileInfo,
        string? website,
        IndustryType? industry,
        Address? companyAddress,
        Phone? contactPhone,
        Email? contactEmail
    )
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(companyName);

        var company = new Company
        {
            CompanyName = companyName.Trim(),
            ProfileInfo = profileInfo?.Trim(),
            Website = website?.Trim(),
            Industry = industry,
            CompanyAddress = companyAddress,
            ContactPhone = contactPhone,
            ContactEmail = contactEmail,
        };

        company.AddDomainEvent(new CompanyCreatedEvent(company.Id, company.CompanyName));
        return company;
    }

    public void Update(
        string companyName,
        string? profileInfo,
        string? website,
        IndustryType? industry,
        Address? companyAddress,
        Phone? contactPhone,
        Email? contactEmail
    )
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(companyName);

        CompanyName = companyName.Trim();
        ProfileInfo = profileInfo?.Trim();
        Website = website?.Trim();
        Industry = industry;
        CompanyAddress = companyAddress;
        ContactPhone = contactPhone;
        ContactEmail = contactEmail;
        MarkAsUpdated();
    }
}
