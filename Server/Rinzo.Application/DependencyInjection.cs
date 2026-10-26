using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Rinzo.Application.Abstractions;
using Rinzo.Application.Applications;
using Rinzo.Application.Common;
using Rinzo.Application.Companies;
using Rinzo.Application.Employers;
using Rinzo.Application.Events;
using Rinzo.Application.Export;
using Rinzo.Application.Jobs;
using Rinzo.Application.Seekers;

namespace Rinzo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Finds every AbstractValidator<T> in this assembly and registers it.
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        AddCompanies(services);
        AddEmployers(services);
        AddJobs(services);
        AddApplications(services);
        AddSeekers(services);

        // Export Strategy + Factory, as open generics: works for every resource's
        // response DTO with no per-resource registration.
        services.AddSingleton(typeof(IExporter<>), typeof(CsvExporter<>));
        services.AddSingleton(typeof(IExporter<>), typeof(JsonExporter<>));
        services.AddSingleton(typeof(IExporterFactory<>), typeof(ExporterFactory<>));

        // Observer: one audit-log handler reacts to every domain event type.
        services.AddScoped(typeof(IDomainEventHandler<>), typeof(LogDomainEventHandler<>));

        return services;
    }

    // Real service registered by its class name; the interface resolves to the
    // caching Decorator wrapped around it, so every caller still just asks for the
    // interface and gets caching "for free".
    private static void AddCompanies(IServiceCollection services)
    {
        services.AddScoped<CompanyService>();
        services.AddScoped<ICompanyService>(sp => new CachedCompanyService(
            sp.GetRequiredService<CompanyService>(),
            sp.GetRequiredService<IMemoryCache>(),
            sp.GetRequiredService<IOptions<CacheOptions>>()
        ));
    }

    private static void AddEmployers(IServiceCollection services)
    {
        services.AddScoped<EmployerService>();
        services.AddScoped<IEmployerService>(sp => new CachedEmployerService(
            sp.GetRequiredService<EmployerService>(),
            sp.GetRequiredService<IMemoryCache>(),
            sp.GetRequiredService<IOptions<CacheOptions>>()
        ));
    }

    private static void AddJobs(IServiceCollection services)
    {
        services.AddScoped<JobService>();
        services.AddScoped<IJobService>(sp => new CachedJobService(
            sp.GetRequiredService<JobService>(),
            sp.GetRequiredService<IMemoryCache>(),
            sp.GetRequiredService<IOptions<CacheOptions>>()
        ));
    }

    private static void AddApplications(IServiceCollection services)
    {
        services.AddScoped<ApplicationService>();
        services.AddScoped<IApplicationService>(sp => new CachedApplicationService(
            sp.GetRequiredService<ApplicationService>(),
            sp.GetRequiredService<IMemoryCache>(),
            sp.GetRequiredService<IOptions<CacheOptions>>()
        ));
    }

    private static void AddSeekers(IServiceCollection services)
    {
        services.AddScoped<SeekerService>();
        services.AddScoped<ISeekerService>(sp => new CachedSeekerService(
            sp.GetRequiredService<SeekerService>(),
            sp.GetRequiredService<IMemoryCache>(),
            sp.GetRequiredService<IOptions<CacheOptions>>()
        ));
    }
}
