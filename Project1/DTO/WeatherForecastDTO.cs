using NT.Tasks.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NT.Tasks.Web.DTO
{
    public class WeatherForecastDTO
    {       

        public double Temperature { get; set; }

        public double MinTemperature { get; set; }

        public double MaxTemperature { get; set; }

        public double AirPressure { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public double WindDirection { get; set; }

        public string CloudCoverCondition { get; set; }

        public string CityName { get; set; }

        public DateTime Date { get; set; }

        public Guid CityId { get; set; }


       
    }
}
