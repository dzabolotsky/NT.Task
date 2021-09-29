using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Tasks.Domain.Models
{
    public class City
    {
        protected City()
        {

        }

        public City(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WeatherForecast> WeatherForecasts { get; protected set; } = new HashSet<WeatherForecast>();
    }
}
