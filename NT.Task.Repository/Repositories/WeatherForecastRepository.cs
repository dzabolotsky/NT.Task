using Microsoft.EntityFrameworkCore;
using NT.Tasks.Domain.interfaces;
using NT.Tasks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Tasks.Repository
{
    internal class WeatherForecastRepository : EntityRepository<WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(AppDbContext context) : base(context) { }
        public Task<WeatherForecast> GetByCurrentDateAndCity(Guid cityId)
        {
            var startDate = DateTime.Now.Date;
            var endDate = startDate.AddDays(1).AddMinutes(-1);
            return Query().Include(r => r.City).FirstOrDefaultAsync(r => r.CityId == cityId && r.Date > startDate && r.Date <= endDate);
        }

        public async Task<(double maxTemperature, double minTemperature)> GetMaxAndMinTemperatureForCity(Guid cityId)
        {
           var result=await Query().Where(r=>r.CityId==cityId).GroupBy(r => r.CityId)
                    .Select(grp => new
                    {
                        ID = grp.Key,
                        Min = grp.Min(t => t.Temperature),
                        Max = grp.Max(t => t.Temperature)
                    }).FirstOrDefaultAsync();
            if (result == null)
                throw new Exception($"Cannot find records for city:{cityId}");
            return (result.Max, result.Min);
        }
    }
}
