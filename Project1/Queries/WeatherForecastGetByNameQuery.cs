using MediatR;
using NT.Tasks.Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NT.Tasks.Web.Queries
{
    public class WeatherForecastGetByNameQuery:IRequest<WeatherForecastDTO>
    {
        public WeatherForecastGetByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
