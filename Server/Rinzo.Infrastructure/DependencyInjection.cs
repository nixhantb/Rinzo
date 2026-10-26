using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rinzo.Application.Abstractions;
using Rinzo.Infrastructure.Events;
using Rinzo.Infrastructure.Persistence;
using Rinzo.Infrastructure.Persistence.Repositories;

namespace Rinzo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString
    )
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention()
        );

        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IEmployerRepository, EmployerRepository>();
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<IApplicationRepository, ApplicationRepository>();
        services.AddScoped<ISeekerRepository, SeekerRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

        return services;
    }
}
