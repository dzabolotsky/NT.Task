
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NT.Tasks.Repository;
using System;

namespace NT.Tasks.Web
{
    public static class MigrationManager
    {

        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public static IWebHost MigrateDatabase(this IWebHost webHost)
        {
            if (webHost != null)
            {
                using (var scope = webHost.Services.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
                    {
                        try
                        {
                            appContext.Database.EnsureDeleted();
                            if (!appContext.Database.EnsureCreated())
                            {
                                //  appContext.();
                                // appContext.Database.Migrate();
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(ex, "An error occurred migrating the DB.");
                            throw;
                        }
                    }
                }
            }

            return webHost;
        }
    }
}
