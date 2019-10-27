using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {

        //The const(final) value of token assigned by OPen Weather Api
        private readonly string ApiKey = string.Empty;
        private readonly IRestService _restService;

        public WeatherController(IRestService restService)
        {
            //assigning the base address to http client for open weather "http://api.openweathermap.org/data/2.5/weather"
            ApiKey = "f964cb899d76cf18bf20cdba2c6ef574";
            _restService = restService;
        }

        [HttpGet("city/{cityName}")]
        public  ActionResult<AllWeatherData> GetWeatherByCityName(string cityName)
        {
            string appendingUrl = "http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appId=" + ApiKey;
            return  _restService.Get(appendingUrl).GetAwaiter().GetResult();
        }
        [HttpGet("zipCode/{zipCode}")]
        public  ActionResult<AllWeatherData> GetWeatherByZipCode(string zipCode)
        {
            string appendingUrlZipCode = "http://api.openweathermap.org/data/2.5/weather?q=?zip=" + zipCode + "&appId=" + ApiKey;
            return  _restService.Get(appendingUrlZipCode).GetAwaiter().GetResult();
        }

        
    }
}