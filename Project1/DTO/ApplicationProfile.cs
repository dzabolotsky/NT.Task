using AutoMapper;
using NT.Tasks.Domain.Enums;
using NT.Tasks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NT.Tasks.Web.DTO
{
    public class ApplicationProfile:Profile
    {
        public ApplicationProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastDTO>()
                .ForMember(m=>m.CloudCoverCondition,mdt=>mdt.MapFrom(x=>Enum.GetName(typeof(CloudCoverConditionEnum),x.CloudCoverCondition)))
                .ForMember(m=>m.CityName,mdt=>mdt.MapFrom(x=>x.City.Name))
                ;
        }
    }
}
