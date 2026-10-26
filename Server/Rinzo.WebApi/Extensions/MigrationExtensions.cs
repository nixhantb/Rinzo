using Microsoft.EntityFrameworkCore;
using Rinzo.Infrastructure.Persistence;

namespace Rinzo.WebApi.Extensions;

public static class MigrationExtensions
{
    // async Task (not async void), so Program.cs can await it and see errors fail fast.
    public static async Task ApplyMigrationsAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.MigrateAsync();
    }
}
