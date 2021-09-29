using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NT.Tasks.Domain.interfaces;
using NT.Tasks.Domain.Models;
using NT.Tasks.Web.DTO;
using NT.Tasks.Web.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NT.Tasks.Web.QueryHandlers
{
    public class WeatherForecastGetByNameQueryHandler : IRequestHandler<WeatherForecastGetByNameQuery, WeatherForecastDTO>
    {
        private readonly IWeatherForecastRepository _entityRepository;
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public WeatherForecastGetByNameQueryHandler(IWeatherForecastRepository entityRepository, IMapper mapper,ICityRepository cityRepository)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        public async Task<WeatherForecastDTO> Handle(WeatherForecastGetByNameQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Name))
            {
                var city = await _cityRepository.GetByName(request.Name);
                if (city == null)
                    return null;
                var currentItem = await _entityRepository.GetByCurrentDateAndCity(city.Id);
                if (currentItem == null)
                    return null;
                var dto = _mapper.Map<WeatherForecast, WeatherForecastDTO>(currentItem);
                var aggregated = await _entityRepository.GetMaxAndMinTemperatureForCity(city.Id);
                dto.MinTemperature = aggregated.minTemperature;
                dto.MaxTemperature = aggregated.maxTemperature;
                return dto;
            }
            return null;
        }
    }
}
