using Rinzo.Domain.Common.ValueObjects;
using Rinzo.Domain.Employers;

namespace Rinzo.Tests.Builders;

public sealed class EmployerBuilder
{
    private Guid _companyId = Guid.CreateVersion7();
    private PersonName _name = PersonName.Create("Jane", null, "Doe");
    private EmployerType _employerType = EmployerType.SmallBusiness;

    public EmployerBuilder WithCompanyId(Guid companyId)
    {
        _companyId = companyId;
        return this;
    }

    public EmployerBuilder WithName(string firstName, string lastName)
    {
        _name = PersonName.Create(firstName, null, lastName);
        return this;
    }

    public Employer Build() => Employer.Create(_companyId, _name, null, null, _employerType, null);
}
