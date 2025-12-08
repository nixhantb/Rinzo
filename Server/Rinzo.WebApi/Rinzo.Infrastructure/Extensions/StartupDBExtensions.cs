using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Extensions
{
    public static class StartupDBExtensions
    {
        public static async void CreateDataBaseTableIfNotPresent(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dataBaseContext = services.GetRequiredService<BaseDBContext>();

            var logger = services.GetRequiredService<ILogger<Program>>();

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
