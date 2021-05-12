using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI_With_Inherited_Interface.AnotherDataService;
using DI_With_Inherited_Interface.DataService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DI_With_Inherited_Interface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAnotherDataService _iAnotherDataService;
        private readonly I2 _i2;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, I2 i2, IAnotherDataService iAnotherDataService)
        {
            _logger = logger;
            _iAnotherDataService = iAnotherDataService;
            _i2 = i2;
        }

        [HttpGet]
        public string Get()
        {
            _i2.SetData = "Data Set at Controller";
            return this._iAnotherDataService.GetActualData();
        }
    }
}
