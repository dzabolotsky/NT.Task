using Microsoft.Extensions.DependencyInjection;
using NT.Tasks.Domain.interfaces;
using NT.Tasks.Repository.Repositories;

namespace NT.Tasks.Repository
{
    public static class AddScopedExtension
    {

        public static void AddAllRepoScoped(this IServiceCollection services)
        {
           

            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
        }

    }
}
