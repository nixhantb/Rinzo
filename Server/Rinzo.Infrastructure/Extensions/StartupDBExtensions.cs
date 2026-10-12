using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Extensions
{
    public static class StartupDBExtensions
    {
        public static async void CreateDataBaseTableIfNotPresent(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dataBaseContext = services.GetRequiredService<BaseDBContext>();

            var logger = services
                .GetRequiredService<ILoggerFactory>()
                .CreateLogger(typeof(StartupDBExtensions).FullName!);

            try
            {
                dataBaseContext.Database.EnsureCreated();
                dataBaseContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                logger.LogError($"There is something wrong with the Migration{ex.Message}");
            }
        }
    }
}
