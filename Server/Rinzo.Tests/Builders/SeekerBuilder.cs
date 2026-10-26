using Rinzo.Domain.Common.ValueObjects;
using Rinzo.Domain.Seekers;

namespace Rinzo.Tests.Builders;

public sealed class SeekerBuilder
{
    private PersonName _personName = PersonName.Create("John", null, "Smith");

    public SeekerBuilder WithName(string firstName, string lastName)
    {
        _personName = PersonName.Create(firstName, null, lastName);
        return this;
    }

    public Seeker Build() =>
        Seeker.Create(_personName, null, null, null, null, [], [], [], [], [], [], [], []);
}
