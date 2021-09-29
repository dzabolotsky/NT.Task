using Microsoft.EntityFrameworkCore;
using NT.Tasks.Domain.Enums;
using NT.Tasks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Tasks.Repository.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                return;
            var cityNames = new string[] { "Berlin", "Hamburg", "	München", "Köln", "	Frankfurt am Main", "Stuttgart", "Düsseldorf", "Leipzig", "Dortmund", "Essen" };
            var cities = cityNames.ToList().Select(r => new City(Guid.NewGuid(), r)).ToList();
            modelBuilder.Entity<City>().HasData(cities);
            var forecasts = new List<WeatherForecast>();
            foreach (var city in cities)
            {
                forecasts.AddRange(GetDataByCity(city));
            }
            modelBuilder.Entity<WeatherForecast>().HasData(forecasts);
        }

        private static IEnumerable<WeatherForecast> GetDataByCity(City city)
        {
            var rng = new Random();
            return Enumerable.Range(0, 9).Select(index => new WeatherForecast(
                Guid.NewGuid(),
                DateTime.Now.AddDays(-index),
                city,
                rng.Next(-20, 55),
                rng.Next(50, 100),
                rng.Next(1000, 1200),
                rng.Next(5, 9) + rng.NextDouble(),
                rng.Next(90, 200), (CloudCoverConditionEnum)rng.Next(0, 2))

                )
            .ToArray();
        }
    }
}
