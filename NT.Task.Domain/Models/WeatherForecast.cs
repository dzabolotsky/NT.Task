using NT.Tasks.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Tasks.Domain.Models
{
    public class WeatherForecast
    {
        protected WeatherForecast()
        {
        }

        public WeatherForecast(Guid id, DateTime date, City city, double temporature,int humidity, double airPressure, double windSpeed, double windDirection, CloudCoverConditionEnum cloudCoverCondition)
        {
            Id = id;
            Date = date;
            Temperature = temporature;
            AirPressure = airPressure;
            WindSpeed = windSpeed;
            WindDirection = windDirection;
            CloudCoverCondition = cloudCoverCondition;
            CityId = city.Id;
            // City = city;
        }

        #region Properties
        public Guid Id { get; set; }

        public double Temperature { get; set; }

        public double AirPressure { get; set; }

        public int Humidity { get; set; }

        public double WindSpeed { get; set; }
        public double WindDirection { get; set; }

        public CloudCoverConditionEnum CloudCoverCondition { get; set; }

        public DateTime Date { get; set; }

        public Guid CityId { get; set; }
        #endregion

        public virtual City City { get; set; }
    }
}
