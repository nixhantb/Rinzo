using Rinzo.Application.Abstractions;

namespace Rinzo.Tests.Fakes;

// Counts how many times the service saved. Tests check this number.
public sealed class FakeUnitOfWork : IUnitOfWork
{
    public int SaveCount { get; private set; }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        SaveCount++;
        return Task.FromResult(1);
    }
}
