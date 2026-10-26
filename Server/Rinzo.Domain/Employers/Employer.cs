using Rinzo.Domain.Common;
using Rinzo.Domain.Common.ValueObjects;

namespace Rinzo.Domain.Employers;

public sealed class Employer : BaseEntity
{
    public PersonName Name { get; private set; } = null!;
    public Address? EmployerAddress { get; private set; }
    public Phone? EmployerPhone { get; private set; }
    public EmployerType EmployerType { get; private set; }
    public IndustryType? IndustryType { get; private set; }

    // Reference to the owning Company by id, not by embedding the whole aggregate.
    public Guid CompanyId { get; private set; }

    private Employer() { }

    public static Employer Create(
        Guid companyId,
        PersonName name,
        Address? employerAddress,
        Phone? employerPhone,
        EmployerType employerType,
        IndustryType? industryType
    )
    {
        if (companyId == Guid.Empty)
        {
            throw new ArgumentException("A company id is required.", nameof(companyId));
        }

        ArgumentNullException.ThrowIfNull(name);

        var employer = new Employer
        {
            CompanyId = companyId,
            Name = name,
            EmployerAddress = employerAddress,
            EmployerPhone = employerPhone,
            EmployerType = employerType,
            IndustryType = industryType,
        };

        employer.AddDomainEvent(new EmployerCreatedEvent(employer.Id, employer.CompanyId));
        return employer;
    }

    public void Update(
        PersonName name,
        Address? employerAddress,
        Phone? employerPhone,
        EmployerType employerType,
        IndustryType? industryType
    )
    {
        ArgumentNullException.ThrowIfNull(name);

        Name = name;
        EmployerAddress = employerAddress;
        EmployerPhone = employerPhone;
        EmployerType = employerType;
        IndustryType = industryType;
        MarkAsUpdated();
    }
}
