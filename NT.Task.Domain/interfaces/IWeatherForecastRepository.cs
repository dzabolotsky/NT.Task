using NT.Tasks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Tasks.Domain.interfaces
{
    public interface IWeatherForecastRepository:IEntityRepository<WeatherForecast>
    {
        Task<WeatherForecast> GetByCurrentDateAndCity(Guid cityId);
        Task<(double maxTemperature, double minTemperature)> GetMaxAndMinTemperatureForCity(Guid cityId);
    }
}
