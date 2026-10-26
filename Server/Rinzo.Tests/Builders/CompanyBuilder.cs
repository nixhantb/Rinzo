using Rinzo.Domain.Companies;

namespace Rinzo.Tests.Builders;

public sealed class CompanyBuilder
{
    private string _companyName = "Acme Corp";

    public CompanyBuilder WithName(string companyName)
    {
        _companyName = companyName;
        return this;
    }

    public Company Build() => Company.Create(_companyName, null, null, null, null, null, null);
}
