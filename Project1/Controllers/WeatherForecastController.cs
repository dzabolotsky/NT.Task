using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NT.Tasks.Domain.interfaces;
using NT.Tasks.Domain.Models;
using NT.Tasks.Web.DTO;
using NT.Tasks.Web.Queries;
using Project1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NT.Tasks.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }

        [HttpGet]

        public Task<WeatherForecastDTO> Get(string name, CancellationToken cancellationToken) => _mediator.Send(new WeatherForecastGetByNameQuery(name), cancellationToken);

    }
}
